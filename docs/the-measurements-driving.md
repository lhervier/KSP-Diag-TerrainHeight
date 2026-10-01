# The measurements: driving on while the world moves

Part of [Terrain Precision Fix Diag 2](../README.md): the readings taken with
[the driving protocol](the-protocol-driving.md) — a rover alone on flat ground, read just before and
just after the game moves its whole world, then the same few metres farther on with no move. Nothing is
loaded at any point: from the first line to the last of a run, it is one single flight. The other series
are in
[The measurements: loading the same save](the-measurements-loading.md),
[The measurements: coming back to a craft you left](the-measurements-approach.md),
[The measurements: switching to a craft far away](the-measurements-switching.md) and
[The measurements: the runway and the grass beside it](the-measurements-runway.md).

The save the protocol uses is [`diag/driving-kerbin.sfs`](../diag/driving-kerbin.sfs), and
[the protocol page](the-protocol-driving.md#the-save) says what it holds.

## The install

KSP 1.12.5 on Windows, with `GameData` holding Harmony, ModuleManager,
[KSP Community Fixes](https://github.com/KSPModdingLibs/KSPCommunityFixes) 1.41.1, this mod and
[Terrain Precision Fix Diag 3](https://github.com/lhervier/KSP-TerrainPrecisionFixDiag3), which only
reads, and nothing else.

## The readings

Two runs, each starting from the save, driving due south. Each run is logged:
[`diag/runs/driving-stock-1.log`](../diag/runs/driving-stock-1.log) and
[`driving-stock-2.log`](../diag/runs/driving-stock-2.log). On every line, Diag 3 confirms what the
protocol expects: 1 in **Shifts** on each line taken just after a move, with a **Last shift** of 500.0 m
to within five centimetres, and 0 on each line taken with no move — except the first line of a run,
which reads the move the game makes as the scene opens.

On the three lines of each move kept below, **Ground KSP computes** reads the same digits to within seven
thousandths of a millimetre: the three lines are read on the same flat ground. In *Difference*, in
millimetres:

| run, move | line 1, just before | line 2, just after | line 3, same distance again | 1 → 2, across the move | 2 → 3, no move |
|---|---|---|---|---|---|
| 1, 1 | +98.195 | +93.998 | +95.164 | **−4.197** | +1.166 |
| 1, 2 | +110.705 | +99.013 | +98.273 | **−11.692** | −0.740 |
| 1, 3 | −292.737 | −283.149 | −283.140 | **+9.588** | +0.009 |
| 2, 1 | +47.858 | +36.076 | +35.848 | **−11.782** | −0.228 |
| 2, 2 | +69.161 | +79.910 | +79.434 | **+10.749** | −0.476 |

The first run, Diag 3 then Diag 2:

![The first run, read by Diag 3: twelve lines, four moves](../imgs/measures/driving/run1-diag3.png)

![The first run, read by Diag 2: twelve lines, four moves](../imgs/measures/driving/run1-diag2.png)

The second run, Diag 3 then Diag 2:

![The second run, read by Diag 3: nine lines, three moves](../imgs/measures/driving/run2-diag3.png)

![The second run, read by Diag 2: nine lines, three moves](../imgs/measures/driving/run2-diag2.png)

### The two moves left out

Both are in the screenshots, and both are left out by their own third line.

- **The fourth move of the first run** (lines 10 to 12), about two kilometres south of the runway, where
  the ground slopes down: **Ground KSP computes** drops by 153 mm from line 10 to line 11 and by 291 mm
  from line 11 to line 12, and *Difference* changes by +175.7 mm from line 11 to line 12, with no move.
  That move is why [the protocol](the-protocol-driving.md#the-protocol) stops at three.
- **The third move of the second run** (lines 7 to 9): **Ground KSP computes** stays within three
  thousandths of a millimetre, but *Difference* changes by +20.289 mm from line 8 to line 9, with no
  move — more than the +14.203 mm across the move. On that ground, a few metres change the reading as
  much as the move does, so the move cannot be told apart.

## What the readings say

**The ground moves when the world moves.** Across each of the five moves kept, *Difference* changes by
4.2 to 11.8 mm, upwards or downwards. Across the same few metres with no move, it changes by 1.2 mm at
most, and by less than half a millimetre three times out of five. The computed height reads the same
digits throughout, so it is the ground under the rover that moved, in the middle of a drive, with
nothing loaded.

**How far it moves is drawn afresh at every move**, from 4.2 to 11.8 mm here, so one move says little on
its own. It is the series that is worth reading, not a line.

**Line 7 of both runs reads almost 30 cm below the computed height** (−292.737 and −284.904 mm), at the
same spot, about a kilometre and a half south of the runway, where every other line kept reads between
+36 and +111 mm. This page does not explain it. It does not change the reading of the move
there in the first run, whose third line holds within nine thousandths of a millimetre.
