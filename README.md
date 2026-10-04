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

![A craft jumping on its own the moment a save is reloaded](https://raw.githubusercontent.com/lhervier/KSP-TerrainPrecisionFix/master/imgs/Booing-scaled.gif)

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

## The protocol

Three protocols, one for each way the game can set a craft down on the ground, a fourth for the
runway, which is not the ground, a fifth for a rover that keeps driving while the game moves its world,
and a sixth for the runway and the grass while it does. All six fill the same window.

**Loading the same save.** Launch a craft, move it off the runway onto bare ground with the debug
menu, let it settle and save once — then load that same save, wait for the digits to stop moving,
press *Record*, and do it again five or six times. One loading proves nothing: the error is drawn
afresh every time, and can come out small by luck. Step by step, with screenshots.

**→ Full chapter: [The protocol: loading the same save](docs/the-protocol-loading.md)**

**Coming back to a craft you left.** This one loads nothing at all. A craft stays parked while you
drive a rover away from it, past 2500 m, where the game unloads it — then back to within 200 m, where
its physics starts again. Five records per round trip, and as many round trips as you like, without
ever changing scene.

**→ Full chapter: [The protocol: coming back to a craft you left](docs/the-protocol-approach.md)**

**Switching to a craft far away.** Two craft landed 1.97 km apart, in a save that comes with this
mod. Load the save while flying one, press *Record*, switch to the other with the game's own key, and
press *Record* again. Then load the same save again, six times in all.

**→ Full chapter: [The protocol: switching to a craft far away](docs/the-protocol-switching.md)**

**The runway and the grass beside it.** Where the first protocol tells you not to fire the ray. Two
craft, one on the runway and one on the grass beside it. Load the save while flying the one on the
grass, press *Record*, switch to the other with the game's own key, and press *Record* again. Then load
the same save again, six times in all. A second save does the same on the Mun, beside a runway placed
by Kerbal Konstructs.

**→ Full chapter: [The protocol: the runway and the grass beside it](docs/the-protocol-runway.md)**

**Driving on while the world moves.** Every 500 m the craft you fly travels, the game moves its whole
world back under it, the ground included. A rover alone on flat grass, read just before such a move and
just after, a few metres apart, then the same few metres farther on with no move in between. One single
flight, three records per move, with
[KSP Diag - Floating Origin](https://github.com/lhervier/KSP-Diag-FloatingOrigin) beside this
mod to tell when the world moves.

**→ Full chapter: [The protocol: driving on while the world moves](docs/the-protocol-driving.md)**

**The runway and the grass, while the world moves.** A rover alone by the runway reads a spot on the
grass and a spot on the deck, comes back to both, drives on until the world moves, and comes back to
both again. Played by hand, or by a Python script that drives the rover through
[KSP-MCPServer](https://github.com/lhervier/KSP-MCPServer) and parks it on the same spots to within a
centimetre — the way to trust the numbers.

**→ Full chapter: [The protocol: the runway and the grass, while the world moves](docs/the-protocol-driving-runway.md)**

## The measurements

Taken in an install with Harmony, ModuleManager and
[KSP Community Fixes](https://github.com/KSPModdingLibs/KSPCommunityFixes) — what most players run —
with this mod added. The first series also goes to the Moon and to Earth, in that install with
[Real Solar System](https://github.com/KSP-RO/RealSolarSystem) added, the runway series to the Mun,
with [Kerbal Konstructs](https://github.com/KSP-RO/Kerbal-Konstructs) added, and the last one is read
with [KSP Diag - Floating Origin](https://github.com/lhervier/KSP-Diag-FloatingOrigin) beside
this mod.

**Loading the same save** ([the protocol in full](docs/the-protocol-loading.md)). The same save,
loaded six times, on Kerbin, on the Mun, on Minmus and on Gilly, then on the Moon and Earth of Real
Solar System, much larger, each with a lone capsule then with two parts, every series played by a
script through KSP-MCPServer. The computed height comes back with the same digits every time — spread
over 0.000 mm on Kerbin and on Minmus, a tenth of a millimetre at most on the Mun and on Gilly, as long
as the craft is read where it came back; on the Moon and Earth, a craft pushed out of the ground came
to rest elsewhere. The ground the craft is standing on never comes back twice: lowest to highest, with
one part then two, 73.7 and 43.6 mm on Kerbin, 5.5 and 18.0 mm on the Mun, 4.6 and 7.3 mm on Minmus,
1.4 and 2.3 mm on Gilly, then 48.7 mm on the Moon and 292.3 mm on Earth. One held still and the other
wandered, with nothing changed in between.

**→ Full chapter: [The measurements: loading the same save](docs/the-measurements-loading.md)**

**Coming back to a craft you left** ([the protocol in full](docs/the-protocol-approach.md)). Six
round trips in a row on Kerbin, in a single flight, with nothing loaded at any point. The computed
height reads the same digits on every line; the ground under the craft comes back somewhere else
every time, by 6.4 to 37.2 mm, and it has already moved by the time the craft is back in range,
before physics takes it over.

**→ Full chapter: [The measurements: coming back to a craft you left](docs/the-measurements-approach.md)**

**Switching to a craft far away** ([the protocol in full](docs/the-protocol-switching.md)). Six
rounds on Kerbin, each starting by loading the save. The ground under the capsule is somewhere else at
every loading, over 112.1 mm, and switching to the capsule does not move it: the two lines of a round
agree to within two thousandths of a millimetre.

**→ Full chapter: [The measurements: switching to a craft far away](docs/the-measurements-switching.md)**

**The runway and the grass beside it** ([the protocol in full](docs/the-protocol-runway.md)). Six
loadings on Kerbin, two craft 152 m apart. The computed height reads the same digits every time, at
both spots. The grass comes back somewhere else at every loading, over 88.3 mm, and so does the runway
deck, over 130.1 mm: the runway is a structure, not the terrain, and it moves just the same. And not
together: the step between the grass and the runway spreads over 81.7 mm. The same on the Mun, beside a
runway placed by [Kerbal Konstructs](https://github.com/KSP-RO/Kerbal-Konstructs): over 24.2 mm on the
ground, 33.5 mm on the runway deck, 43.0 mm for the step. Whether the game or a mod places it, a
structure behaves the same.

**→ Full chapter: [The measurements: the runway and the grass beside it](docs/the-measurements-runway.md)**

**Driving on while the world moves** ([the protocol in full](docs/the-protocol-driving.md)). A rover
alone on the grass south of the runway, two runs on Kerbin and two on Earth in Real Solar System. On
Kerbin, across each of five moves of the world kept, the ground under the rover changes by 4.2 to
11.8 mm; across the same few metres with no move, by 1.2 mm at most. On Earth, by 142 to 421 mm across
three moves kept, 15 mm at most with no move, and the rover jumps when the ground rises under it. The
ground moves in the middle of a drive, with nothing loaded. The moves left out are shown, each with the
reason.

**→ Full chapter: [The measurements: driving on while the world moves](docs/the-measurements-driving.md)**

**The runway and the grass, while the world moves** ([the protocol in full](docs/the-protocol-driving-runway.md)).
One run by the script on Kerbin, two moves of the world kept, and one on Earth in Real Solar System.
The runway moves at each move, by −8.85 and +48.47 mm on Kerbin, by −375.89 and +45.69 mm on Earth, and
the grass beside it by the same amount, to within five hundredths of a millimetre: across a move of the
world, the runway and the ground are carried together — unlike at a loading, where each draws a
placement of its own.

**→ Full chapter: [The measurements: the runway and the grass, while the world moves](docs/the-measurements-driving-runway.md)**

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
