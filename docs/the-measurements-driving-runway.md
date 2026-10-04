# The measurements: the runway and the grass, while the world moves

Part of [KSP Diag - Terrain Height](../README.md): the readings taken with
[the protocol](the-protocol-driving-runway.md) — a rover alone by the runway of the KSC, reading a spot
on the grass and a spot on the deck just before and just after the game moves its whole world. Nothing
is loaded at any point: from the first line to the last, it is one single flight. The grass alone, read
the same way, is in [The measurements: driving on while the world moves](the-measurements-driving.md),
and the runway and the grass at every loading in
[The measurements: the runway and the grass beside it](the-measurements-runway.md).

## The install

KSP 1.12.5 on Windows, with `GameData` holding Harmony, ModuleManager,
[KSP Community Fixes](https://github.com/KSPModdingLibs/KSPCommunityFixes) 1.41.1, this mod,
[KSP Diag - Floating Origin](https://github.com/lhervier/KSP-Diag-FloatingOrigin) and
[KSP-MCPServer](https://github.com/lhervier/KSP-MCPServer), which only read the game and drive the
rover, and nothing else. On Earth, [Real Solar System](https://github.com/KSP-RO/RealSolarSystem)
20.1.3.0 and what it requires as well (Kopernicus 248, Modular Flight Integrator, KSPTextureLoader, the
RSS textures), built without its runway fix ([On Earth](#on-earth)).

## On Kerbin

One run, played by [the script](the-protocol-driving-runway.md#played-by-a-script) from
[`diag/driving-runway-kerbin.sfs`](../diag/driving-runway-kerbin.sfs), three moves of the world, logged in
[`diag/runs/driving-runway-stock.log`](../diag/runs/driving-runway-stock.log); what the script printed is in
[`driving-runway-stock-script.txt`](../diag/runs/driving-runway-stock-script.txt), and every line it
recorded in [`driving-runway-stock-lines.json`](../diag/runs/driving-runway-stock-lines.json). It was played with an earlier setting of the script, stopping 468 m from the origin of the world
before the turn instead of 455 m: G stood 489 to 493 m from it before each move, instead of about 480 m.
The rover stopped 13 to 16 cm from each spot. On every line, Diag FloatingOrigin reads 1 in **Shifts** on the first
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

The first move, Diag FloatingOrigin then Diag TerrainHeight:

![The first move, read by Diag FloatingOrigin](../imgs/measures/driving-runway/move1-diag3.png)

![The first move, read by Diag TerrainHeight](../imgs/measures/driving-runway/move1-diag2.png)

The second move:

![The second move, read by Diag FloatingOrigin](../imgs/measures/driving-runway/move2-diag3.png)

![The second move, read by Diag TerrainHeight](../imgs/measures/driving-runway/move2-diag2.png)

### The move left out

The third move, about 1.5 km east of the save, is in the screenshots and left out. There, **Ground KSP
computes** reads about a metre lower than at the first two, and changes from one visit of a spot to the
next by up to 15 mm: the grass is no longer flat, and the lines taken at a spot spread over up to 16 mm
— as much as a move does. That move is why [the protocol](the-protocol-driving-runway.md#the-protocol)
stops at two.

![The third move, read by Diag FloatingOrigin](../imgs/measures/driving-runway/move3-diag3.png)

![The third move, read by Diag TerrainHeight](../imgs/measures/driving-runway/move3-diag2.png)

## On Earth

Real Solar System ships a fix of its own for the runway of the KSC, `RSSRunwayFix`. Once a craft has
rolled onto the deck, it raises the distance at which KSP moves the floating origin from 500 m to
2,700 m, and keeps it there after the craft has left the deck: the rover, which reads P on the deck
before each move, would never see the world move at 500 m. So Real Solar System is built from the
sources of its release 20.1.3.0 with that fix kept from doing anything, the one change in
[`rss-20.1.3-without-its-runway-fix.diff`](https://github.com/lhervier/KSP-TerrainPrecisionFix/blob/master/diag/rss-runway-fix/rss-20.1.3-without-its-runway-fix.diff);
everything else is Real Solar System as released.

One run, played by [the script](the-protocol-driving-runway.md#played-by-a-script) from
[`diag/driving-runway-earth-rss.sfs`](../diag/driving-runway-earth-rss.sfs), with `--radius 6371000`, two
moves of the world, logged in
[`diag/runs/driving-runway-earth-rss-stock.log`](../diag/runs/driving-runway-earth-rss-stock.log); what
the script printed is in
[`driving-runway-earth-rss-stock-script.txt`](../diag/runs/driving-runway-earth-rss-stock-script.txt),
and every line it recorded in
[`driving-runway-earth-rss-stock-lines.json`](../diag/runs/driving-runway-earth-rss-stock-lines.json).
G stood 476 to 479 m from the origin of the world before each move. The rover stopped 14 to 15 cm from
each spot. Diag FloatingOrigin reads 1 in **Shifts** on the first line after a move, with a **Last shift** of 500.0 m
to within five centimetres, and 0 on the others.

In *Difference*, in millimetres:

| move | G before | G after | P before | P after |
|---|---|---|---|---|
| 1 | −31.215, −31.334, −31.289 | −407.186, −407.182 | +3741.389, +3741.414 | +3365.502, +3365.525 |
| 2 | −697.608, −697.650, −697.659 | −652.012, −651.993 | +3263.485, +3263.486 | +3309.172, +3309.170 |

Across each move, the mean of the lines after minus the mean of the lines before:

| move | the grass, G | the deck, P | the step, P − G | spread at a spot, at most |
|---|---|---|---|---|
| 1 | **−375.905** | **−375.888** | +0.017 | 0.120 |
| 2 | **+45.637** | **+45.685** | +0.049 | 0.051 |

**Ground KSP computes** reads the same digits at a spot on every line of a move, to within three
hundredths of a millimetre.

The first move, Diag FloatingOrigin then Diag TerrainHeight:

![The first move on Earth, read by Diag FloatingOrigin](../imgs/measures/driving-runway-earth/move1-diag3.png)

![The first move on Earth, read by Diag TerrainHeight](../imgs/measures/driving-runway-earth/move1-diag2.png)

The second move:

![The second move on Earth, read by Diag FloatingOrigin](../imgs/measures/driving-runway-earth/move2-diag3.png)

![The second move on Earth, read by Diag TerrainHeight](../imgs/measures/driving-runway-earth/move2-diag2.png)

## What the readings say

**The runway moves when the world moves**, in the middle of a drive, with nothing loaded: on Kerbin,
by −8.85 mm at the first move and +48.47 mm at the second; on Earth, by −375.89 mm and +45.69 mm. Each
time, hundreds or thousands of times the spread of the lines taken at the same spot.

**And it moves with the ground beside it.** The grass moves by the same amount, to within five
hundredths of a millimetre on both bodies, so the step between the deck and the grass stays what it was.
Across a move of the world, the runway and the ground are carried together. On Earth, a rover rolling on
the runway is no better off than one rolling on the grass beside it
([The measurements: driving on while the world moves](the-measurements-driving.md#on-earth)): both see
the ground under them move by up to several tenths of a metre.

That is not what happens at a loading, where the step between the same two kinds of spot changes by up
to 38.3 mm from one loading to the next
([The measurements: the runway and the grass beside it](the-measurements-runway.md)): there, the runway
and the ground each draw a placement of their own.
