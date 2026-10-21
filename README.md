# KSP Diag - Terrain Height

**⚠️ Work in progress.** This is an active investigation, not a finished mod. The code and the pages of this repository can still change.

**How this was made.** Written with Claude, Anthropic's AI assistant, and reviewed line by line by a
human — me. I am saying so up front, because contributions made with an AI deserve a closer look than
others, and because some people would rather stop reading here. That look is easy to give here: this
mod changes nothing in the game, so what there is to check is the reading itself — the two methods that
take it are quoted in full in [This mod's demonstration](docs/this-mods-demonstration.md), and the
source is public.

A measuring instrument for KSP 1.12. It reads two heights of the ground, in millimetres, at the spot
a craft is standing on — the craft you are flying, or your target: the one the game computes, and the
one it builds, the surface your landing legs touch. It reads them live, every frame, and records them
side by side when you ask.

## This mod's demonstration

KSP has two grounds: the one it **computes** from the formulas a world is made of, and the one it
**builds** out of triangles, which your landing legs touch. The mod reads both under your craft, from
two short methods that share nothing but the vessel.

**→ Full chapter: [This mod's demonstration](docs/this-mods-demonstration.md)**

## The window

In flight, a window shows a table with one line per reading, in millimetres: **Ground under craft**,
**Ground KSP computes**, and **Difference**, the first minus the second. The bottom line is the reading
in progress, measured afresh every frame, until the *Record* button at the end of it freezes it into the
table. The table survives scene changes, lives in memory only, and is gone when you close the game.

**→ Full chapter: [The window](docs/the-window.md)**

## Taking a reading

Set a craft down where you want the ground read, wait for the digits to stop moving, and press
*Record*. The craft only marks the spot the ray is fired at, and what it is made of does not change the
reading.

Some situations change what a reading says, and are worth keeping in mind when you read it. For
instance:

- **A craft that slides.** The digits never stop. SAS, or another spot, holds it still.
- **An open throttle**, even by a few percent: the game no longer holds a landed craft still. On a
  slope, it creeps, and the readings creep with it.
- **A runway, a launch pad or a building.** The ray stops at the first surface it meets: it reads the
  structure, not the ground.
- **A craft that jumped or tipped over.** The reading is of another spot. **Ground KSP computes** gives
  it away: it follows the spot, so it changes too.

The window reads the ground under your target when you have set one on another craft. Under a rover, it
reads the ground while you drive: stop before each record.

## Driving it by script

With [KSP-Util-MCPServer](https://github.com/lhervier/KSP-Util-MCPServer) installed next to it, this mod offers
its window to a program, as tools of that server: a script presses its buttons and reads what it shows,
as a player would. Without the server, this mod runs the same.

| tool | what it does |
|---|---|
| `terrainheight_record` | presses *Record*: freezes the line in progress into the table and returns it (`CollisionSurfaceMm`, `ComputedTerrainMm`) |
| `terrainheight_read` | reads the window: the recorded lines and the line in progress |
| `terrainheight_clear` | presses *Clear table* |
| `terrainheight_move_window` | moves the window, as dragging it does: `x` and `y` in pixels from the top left corner of the screen; returns its position and size |
| `terrainheight_show_window` | shows or hides the window, as `Alt+F6` does; the reading goes on either way |

## Get it

Either way you end up with the same `GameData/KSPDiagTerrainHeight/` folder.

**Download it** — from the assets of the
[latest release](https://github.com/lhervier/KSP-Diag-TerrainHeight/releases/latest).

**Or compile it** — clone this repository, set `KSPDIR` to your KSP install folder and run
`build.bat`. It needs the .NET SDK and
[KSP-Util-MCPServer](https://github.com/lhervier/KSP-Util-MCPServer) installed in that KSP, takes a few seconds,
reads the KSP assemblies straight from your install, and puts the DLL in
`GameData/KSPDiagTerrainHeight/` inside the repository. It does not install anything.
KSP-Util-MCPServer is only needed to compile: it provides the attribute that marks what this mod offers to
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
