# The measurements: the runway and the grass, while the world moves

Part of [Terrain Precision Fix Diag 2](../README.md): the readings taken with
[the protocol](the-protocol-driving-runway.md) — a rover alone by the runway of the KSC, reading a spot
on the grass and a spot on the deck just before and just after the game moves its whole world. Nothing
is loaded at any point: from the first line to the last, it is one single flight. The grass alone, read
the same way, is in [The measurements: driving on while the world moves](the-measurements-driving.md),
and the runway and the grass at every loading in
[The measurements: the runway and the grass beside it](the-measurements-runway.md).

## The install

KSP 1.12.5 on Windows, with `GameData` holding Harmony, ModuleManager,
[KSP Community Fixes](https://github.com/KSPModdingLibs/KSPCommunityFixes) 1.41.1, this mod,
[Terrain Precision Fix Diag 3](https://github.com/lhervier/KSP-TerrainPrecisionFixDiag3) and
[KSP-MCPServer](https://github.com/lhervier/KSP-MCPServer), which only read the game and drive the
rover, and nothing else.

## The readings

One run, played by [the script](the-protocol-driving-runway.md#played-by-a-script) from
[`diag/driving-runway-kerbin.sfs`](../diag/driving-runway-kerbin.sfs), three moves of the world, logged in
[`diag/runs/driving-runway-stock.log`](../diag/runs/driving-runway-stock.log); what the script printed is in
[`driving-runway-stock-script.txt`](../diag/runs/driving-runway-stock-script.txt), and every line it
recorded in [`driving-runway-stock-lines.json`](../diag/runs/driving-runway-stock-lines.json). It was played with an earlier setting of the script, stopping 468 m from the origin of the world
before the turn instead of 455 m: G stood 489 to 493 m from it before each move, instead of about 480 m.
The rover stopped 13 to 16 cm from each spot. On every line, Diag 3 reads 1 in **Shifts** on the first
line after a move, with a **Last shift** of 500.0 m to within four centimetres, and 0 on the others.

In *Difference*, in millimetres:

| move | G before | G after | P before | P after |
|---|---|---|---|---|
| 1 | −44.295, −44.290, −44.299 | −53.116, −53.160 | +3492.283, +3492.293 | +3483.432, +3483.442 |
| 2 | −44.307, −44.318, −44.317 | +4.214, +4.170 | +3016.140, +3016.146 | +3064.616, +3064.611 |

Across each move, the mean of the lines after minus the mean of the lines before:

| move | the grass, G | the deck, P | the step, P − G | spread at a spot, at most |
|---|---|---|---|---|
| 1 | **−8.843** | **−8.851** | −0.008 | 0.044 |
| 2 | **+48.506** | **+48.471** | −0.035 | 0.044 |

**Ground KSP computes** reads the same digits at a spot on every line of a move, to within a thousandth
of a millimetre: the rover was read on the same spots before and after.

The first move, Diag 3 then Diag 2:

![The first move, read by Diag 3](../imgs/measures/driving-runway/move1-diag3.png)

![The first move, read by Diag 2](../imgs/measures/driving-runway/move1-diag2.png)

The second move:

![The second move, read by Diag 3](../imgs/measures/driving-runway/move2-diag3.png)

![The second move, read by Diag 2](../imgs/measures/driving-runway/move2-diag2.png)

### The move left out

The third move, about 1.5 km east of the save, is in the screenshots and left out. There, **Ground KSP
computes** reads about a metre lower than at the first two, and changes from one visit of a spot to the
next by up to 15 mm: the grass is no longer flat, and the lines taken at a spot spread over up to 16 mm
— as much as a move does. That move is why [the protocol](the-protocol-driving-runway.md#the-protocol)
stops at two.

![The third move, read by Diag 3](../imgs/measures/driving-runway/move3-diag3.png)

![The third move, read by Diag 2](../imgs/measures/driving-runway/move3-diag2.png)

## What the readings say

**The runway moves when the world moves**, in the middle of a drive, with nothing loaded: by −8.85 mm at
the first move, +48.47 mm at the second, each time hundreds of times the spread of the lines taken at
the same spot.

**And it moves with the ground beside it.** The grass moves by the same amount, to within four
hundredths of a millimetre, so the step between the deck and the grass stays what it was. Across a move
of the world, the runway and the ground are carried together.

That is not what happens at a loading, where the step between the same two kinds of spot changes by up
to 81.7 mm from one loading to the next
([The measurements: the runway and the grass beside it](the-measurements-runway.md)): there, the runway
and the ground each draw a placement of their own.
