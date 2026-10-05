# The measurements: driving on while the world moves

Part of [KSP Diag - Terrain Height](../README.md): the readings taken with
[the driving protocol](the-protocol-driving.md) — a rover alone on the grass, read just before and
just after the game moves its whole world, then the same few metres farther on with no move. Nothing is
loaded at any point: from the first line to the last of a run, it is one single flight. The series runs
on Kerbin, then on Earth in Real Solar System, much larger.

The saves the protocol uses are [`diag/driving-kerbin.sfs`](../diag/driving-kerbin.sfs) and
[`diag/driving-earth-rss.sfs`](../diag/driving-earth-rss.sfs), and
[the protocol page](the-protocol-driving.md#the-save) says what they hold.

## The install

KSP 1.12.5 on Windows, with `GameData` holding Harmony, ModuleManager,
[KSP Community Fixes](https://github.com/KSPModdingLibs/KSPCommunityFixes) 1.41.1, this mod,
[KSP Diag - Floating Origin](https://github.com/lhervier/KSP-Diag-FloatingOrigin), which only
reads, and [KSP-MCPServer](https://github.com/lhervier/KSP-MCPServer), which drives the rover, and
nothing else. On Earth, that install with
[Real Solar System](https://github.com/KSP-RO/RealSolarSystem) 20.1.3.0 and what it requires added
(Kopernicus 248, Modular Flight Integrator, KSPTextureLoader, the RSS textures).

Each series is one run of three moves, played by
[the script of the protocol](the-protocol-driving.md#played-by-a-script), `run-driving.py`.

## The readings

Each run starts from the save and drives due south. On every line, Diag FloatingOrigin confirms what the protocol
expects: 1 in **Shifts** on each line taken just after a move, with a **Last shift** of 500.0 m to
within three centimetres, and 0 on each line taken with no move — except the first line of a run, which
reads the moves the game makes as the scene opens: one on Kerbin, two on Earth.

A move is kept when its second line changes at least three times as much as its third
([the protocol](the-protocol-driving.md#what-the-three-lines-are-worth)). In *Difference*, in
millimetres.

### On Kerbin

Logged in [`diag/runs/driving-stock.log`](../diag/runs/driving-stock.log); what the script printed is
in [`driving-stock-script.txt`](../diag/runs/driving-stock-script.txt), and every line it recorded in
[`driving-stock-lines.json`](../diag/runs/driving-stock-lines.json). On the three lines of each move,
**Ground KSP computes** reads the same digits to within six thousandths of a millimetre: the three
lines are read on the same flat ground. The rover drove 6 to 10 m from line 1 to line 2 of a move.

| move | line 1, just before | line 2, just after | line 3, same distance again | 1 → 2, across the move | 2 → 3, no move | kept |
|---|---|---|---|---|---|---|
| 1 | +1.091 | +2.307 | +3.663 | +1.216 | +1.356 | no |
| 2 | −16.116 | +10.470 | +5.935 | **+26.586** | −4.535 | yes |
| 3 | −437.069 | −461.733 | −456.077 | **−24.665** | +5.656 | yes |

Diag FloatingOrigin then Diag TerrainHeight:

![The run on Kerbin, read by Diag FloatingOrigin: nine lines, three moves](../imgs/measures/driving/run1-diag3.png)

![The run on Kerbin, read by Diag TerrainHeight: nine lines, three moves](../imgs/measures/driving/run1-diag2.png)

### On Earth

The ground around the KSC of Real Solar System is not flat to the millimetre: in this run,
**Ground KSP computes** changes by up to 86 mm between two lines of a move, which the rover reads 0.7 to
1.4 m apart. Logged in [`diag/runs/driving-earth-rss-stock.log`](../diag/runs/driving-earth-rss-stock.log);
what the script printed is in [`driving-earth-rss-stock-script.txt`](../diag/runs/driving-earth-rss-stock-script.txt),
and every line it recorded in [`driving-earth-rss-stock-lines.json`](../diag/runs/driving-earth-rss-stock-lines.json).

| move | line 1, just before | line 2, just after | line 3, same distance again | 1 → 2, across the move | 2 → 3, no move | kept |
|---|---|---|---|---|---|---|
| 1 | +426.907 | +267.768 | +243.492 | **−159.139** | −24.276 | yes |
| 2 | +311.326 | +68.345 | −12.779 | −242.981 | −81.124 | no, 2.995 times |
| 3 | −507.817 | −276.286 | −194.253 | +231.530 | +82.033 | no, 2.8 times |

Diag FloatingOrigin then Diag TerrainHeight:

![The run on Earth, read by Diag FloatingOrigin: nine lines, three moves](../imgs/measures/driving/earth-run1-diag3.png)

![The run on Earth, read by Diag TerrainHeight: nine lines, three moves](../imgs/measures/driving/earth-run1-diag2.png)

**The rover was seen to jump** in two earlier runs of the same save, played by hand and watched
(logged in [`driving-earth-rss-stock-1.log`](../diag/runs/driving-earth-rss-stock-1.log) and
[`driving-earth-rss-stock-2.log`](../diag/runs/driving-earth-rss-stock-2.log)): at the two moves where
the ground under it rose, by 156 and 150 mm.

**→ What they show: [What the measurements show: driving on while the world moves](what-the-measurements-show-driving.md)**
