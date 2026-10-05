# KSP Diag - Terrain Height

**⚠️ Work in progress.** This is an active investigation, not a finished mod. The figures, the code and the conclusions on this page can still change, and several questions are still open.

A measuring instrument for KSP 1.12. It lets you check, on your own install, a claim about the patch
of ground your craft is parked on:

> **The ground KSP builds under you is never built at the same height twice.** Load the same save five
> times, and the surface your craft is standing on comes back a little higher or a little lower each
> time — a few centimetres apart on Kerbin, less on smaller worlds, and up to seventy on Earth in
> Real Solar System.

**How this was made.** Written with Claude, Anthropic's AI assistant, and reviewed line by line by a
human — me. I am saying so up front, because contributions made with an AI deserve a closer look than
others, and because some people would rather stop reading here. That look is easy to give here: this
mod changes nothing in the game, so what there is to check is the reading itself — the two methods that
take it are quoted in full, the source is public, the protocol runs on a stock install with no
dependency of any kind, and every figure on these pages is read straight off the screenshot next to it,
on your own craft if you would rather take them again.

## Why it matters

Every time you load, it is a coin toss between two outcomes.

**The ground comes back lower than it was when you saved.** Your craft is now hovering a couple of
centimetres above it, so it drops those two centimetres. You never notice, and nothing breaks.

**The ground comes back higher than it was when you saved.** Your craft is now *inside* the ground —
and the physics engine will not leave two solid things overlapping. It pushes them apart, hard, in
the only direction available: up. Your craft gets launched.

![A craft jumping on its own the moment a save is reloaded](https://raw.githubusercontent.com/lhervier/KSP-TerrainPrecisionFix/main/imgs/Booing-scaled.gif)

*KSP 1.12 with [KSP Community Fixes](https://github.com/KSPModdingLibs/KSPCommunityFixes) as the only
mod installed. A pod on an empty fuel tank, parked in the grass at the KSC, saved, then reloaded from the
pause menu, several times if needed — nothing touched in between.*

That second case is the symptom everybody already knows. The lander that twitches, hops or flips the
moment the scene finishes loading. The base that sat perfectly flush yesterday and is buried up to
the hatches today. The big base that tears itself apart the very first time you load it, and never
again afterwards. A craft with many parts spread over a wide area gives the coin toss more chances
to land the wrong way up.

### Disclaimer: it is not the only cause

The ground moving is one cause among several, and this page does not claim it is the only one. Plenty
of other things move a craft when a scene opens. Two well-known examples, among others:

- **suspensions.** Landing legs and wheels come back fully extended, because that is the only state
  KSP can restore them to. They then compress under the weight of the craft, and the craft moves
  while they do.
- **a craft bent to fit the ground.** While you play, physics twists the joints between parts so the
  craft settles onto the shape of the ground beneath it. That twisting is not saved. On loading, the
  craft comes back in its original, unbent shape — and if the ground is not flat, part of it really
  *is* underground, with no measurement error involved.

Neither of them touches the reading below: this instrument measures the ground itself, and does not
care what the craft standing on it is made of.

## This mod's demonstration

There are two grounds in KSP, and they are not the same object: the one the game **computes** for any
spot on any world, from the formulas that world is made of, and the one it **builds** out of flat
triangles when the scene opens — the one your landing legs touch. They should agree. This mod reads
both for the spot your craft is standing on, from two short methods that share nothing but the vessel,
and records them side by side, one line per loading. A correct reading is not zero, and the shape of
the ground says how far from it, and on which side.

**→ Full chapter: [This mod's demonstration](docs/this-mods-demonstration.md)**

## The window

In flight, a window shows a table with one line per loading, in millimetres: **Ground under craft**,
**Ground KSP computes**, and **Difference**, the first minus the second. The bottom line is the reading
in progress, measured afresh every frame, until the *Record* button at the end of it freezes it into the
table. The table survives scene changes, lives in memory only, and is gone when you close the game.

**→ Full chapter: [The window](docs/the-window.md)**

## The situations

Each situation below comes with its protocol, its measurements and what they show, and all of them
fill the same window: the ways the game sets a craft down on the ground, the runway, and a rover that
keeps driving while the game moves its world. Every series was taken with Harmony,
ModuleManager and [KSP Community Fixes](https://github.com/KSPModdingLibs/KSPCommunityFixes) — what
most players run — and this mod, played by the script of its protocol through
[KSP-MCPServer](https://github.com/lhervier/KSP-MCPServer). Each page gives its install in full.

## Loading the same save

Set a craft down on bare ground, save once, then load that same save six times, recording after each
loading; on the four stock worlds, then on the Moon and Earth of Real Solar System. On the stock worlds,
the computed height comes back with the same digits; the ground under the craft never does: up to
43.6 mm apart on Kerbin, 292.3 mm on Earth.

**→ [The protocol](docs/the-protocol-loading.md) · [The measurements](docs/the-measurements-loading.md) · [What they show](docs/what-the-measurements-show-loading.md)**

## Coming back to a craft you left

In one single flight, drive a rover away from a parked craft until the game unloads it, then back
until its physics starts again; six round trips on Kerbin. Nothing is loaded, yet the ground under the
parked craft comes back somewhere else every time, by 6.4 to 37.2 mm.

**→ [The protocol](docs/the-protocol-approach.md) · [The measurements](docs/the-measurements-approach.md) · [What they show](docs/what-the-measurements-show-approach.md)**

## Switching to a craft far away

Load a save holding two craft 1.97 km apart, record, switch to the other with the game's own key, and
record again; six rounds on Kerbin. The ground under the capsule moves at every loading, over
112.1 mm, and the switch itself moves nothing.

**→ [The protocol](docs/the-protocol-switching.md) · [The measurements](docs/the-measurements-switching.md) · [What they show](docs/what-the-measurements-show-switching.md)**

## The runway and the grass beside it

Six loadings of a save holding two craft, one on the runway and one on the grass beside it, on Kerbin,
then on the Mun beside a runway placed by Kerbal Konstructs. The runway deck moves at every loading
like the grass, but not with it: the step between them spreads over 38.3 mm on Kerbin. The runway on
the Mun does the same.

**→ [The protocol](docs/the-protocol-runway.md) · [The measurements](docs/the-measurements-runway.md) · [What they show](docs/what-the-measurements-show-runway.md)**

## Driving on while the world moves

A rover alone on flat grass, read just before and just after the game moves its world, with
[KSP Diag - Floating Origin](https://github.com/lhervier/KSP-Diag-FloatingOrigin) beside this mod to
tell when it does. With nothing loaded, the ground under the rover moves at each move of the world:
about 25 mm on Kerbin, 159 to 243 mm on Earth in Real Solar System.

**→ [The protocol](docs/the-protocol-driving.md) · [The measurements](docs/the-measurements-driving.md) · [What they show](docs/what-the-measurements-show-driving.md)**

## The runway and the grass, while the world moves

A rover by the runway of the KSC reads a spot on the grass and a spot on the runway deck, just before
and just after the game moves its world. The runway moves at each move, by up to 54.85 mm on Kerbin
and 231.84 mm on Earth, but the grass beside it moves with it: unlike at a loading, the two are carried
together.

**→ [The protocol](docs/the-protocol-driving-runway.md) · [The measurements](docs/the-measurements-driving-runway.md) · [What they show](docs/what-the-measurements-show-driving-runway.md)**

## Get it

Either way you end up with the same `GameData/KSPDiagTerrainHeight/` folder.

**Download it** — from the assets of the
[latest release](https://github.com/lhervier/KSP-Diag-TerrainHeight/releases/latest).

**Or compile it** — clone this repository, set `KSPDIR` to your KSP install folder and run
`build.bat`. It needs the .NET SDK and
[KSP-MCPServer](https://github.com/lhervier/KSP-MCPServer) installed in that KSP, takes a few seconds,
reads the KSP assemblies straight from your install, and puts the DLL in
`GameData/KSPDiagTerrainHeight/` inside the repository. It does not install anything.
KSP-MCPServer is only needed to compile: it provides the attribute that marks what this mod offers to
it, and this mod runs the same without it. Worth doing if you would rather not run a binary you have no source for while
reporting a measurement.

## Install

Drop `GameData/KSPDiagTerrainHeight` into the `GameData` of KSP, so that you end up with
`GameData/KSPDiagTerrainHeight/KSPDiagTerrainHeight.dll`. It runs on a stock install:
no Harmony, no ModuleManager, no dependency of any kind.

It reads the world and writes nothing at all: the table lives in memory and is gone when you close the
game. Your saves are never touched. Removing the folder removes the mod.

## License

MIT
