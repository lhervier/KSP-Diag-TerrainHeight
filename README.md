# KSP Diag - Terrain Height

**⚠️ Work in progress.** This is an active investigation, not a finished mod. The code and the pages of this repository can still change.

**How this was made.** Written with Claude, Anthropic's AI assistant, and reviewed line by line by a
human — me. I am saying so up front, because contributions made with an AI deserve a closer look than
others, and because some people would rather stop reading here. That look is easy to give here: this
mod changes nothing in the game, so what there is to check is the reading itself — the two methods that
take it are quoted in full in [This mod's demonstration](docs/this-mods-demonstration.md), and the
source is public.

A measuring instrument for KSP 1.12. It reads, for the spot your craft is standing on, two heights of
the ground: the one the game computes, and the one it builds, the surface your landing legs touch. It
lets you check, on your own install, whether the ground under a craft comes back at the same height when
the game builds it again: at every loading, when you come back to a craft you left parked, when you
switch to a craft far away, while you drive.

Why that matters, and what was found with it, is told by
[Terrain Precision Fix](https://github.com/lhervier/KSP-TerrainPrecisionFix#why-the-moving-ground-matters).

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

## Taking a reading

Set a craft down where you want the ground read, and save once. Load that save, wait for the digits to
stop moving, and press *Record*. Load the same save again, and record again. Each line is one loading:
it is the series that is worth reading, not a line. The craft only marks the spot the ray is fired at,
and what it is made of does not change the reading. A few rules keep that spot the same:

- **A craft that does not slide.** If the digits never stop, the craft is sliding: turn SAS on before
  saving, or pick another spot.
- **Do not touch the throttle.** Open it, even by a few percent, and the game no longer holds a landed
  craft still: on a slope, it creeps, and the readings creep with it.
- **Never save during the series.** Every loading must start from the same save.
- **Bare ground, unless the structure is what you want to read.** The ray stops at the first surface it
  meets: on a runway, a launch pad or a building, it reads the structure, not the ground.
- **Watch Ground KSP computes.** A line where it reads differently from the others was taken somewhere
  else: the craft jumped or tipped over at that loading.

The window reads the ground under your target when you have set one on another craft, so a parked craft
can be followed while you drive away from it and back. Under a rover, it reads the ground while you
drive: stop before each record.

## Measured campaigns

This instrument reads the ground in the campaigns of
[Terrain Precision Fix](https://github.com/lhervier/KSP-TerrainPrecisionFix), each played without that
mod and with it, with its protocol, its saves, its scripts and its logs: loading the same save,
[on bare ground](https://github.com/lhervier/KSP-TerrainPrecisionFix/blob/main/docs/checking-the-culprit-loading/the-ground.md#the-ground-over-six-loads)
and [on a runway and the ground beside it](https://github.com/lhervier/KSP-TerrainPrecisionFix/blob/main/docs/checking-the-culprit-loading/the-statics.md#the-deck-of-a-runway);
[coming back to a craft left parked](https://github.com/lhervier/KSP-TerrainPrecisionFix/blob/main/docs/checking-the-culprit-approach.md);
[switching to a craft far away](https://github.com/lhervier/KSP-TerrainPrecisionFix/blob/main/docs/checking-the-culprit-switching.md);
driving on while the world moves,
[on the grass](https://github.com/lhervier/KSP-TerrainPrecisionFix/blob/main/docs/checking-the-culprit-driving/the-ground.md)
and [by the runway](https://github.com/lhervier/KSP-TerrainPrecisionFix/blob/main/docs/checking-the-culprit-driving/the-statics.md);
and [launching from a launch pad of Making History](https://github.com/lhervier/KSP-TerrainPrecisionFix/blob/main/docs/checking-the-culprit-launch-pad.md).
The figures read with it are on those pages.

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
