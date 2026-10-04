# The measurements: switching to a craft far away

Part of [KSP Diag - Terrain Height](../README.md): the readings taken with
[the switching protocol](the-protocol-switching.md) — a capsule and a rover landed 1.97 km apart, the
save loaded while flying the rover, then the game's *switch vessel* key pressed to fly the capsule.

The save the protocol uses is [`diag/switch-kerbin.sfs`](../diag/switch-kerbin.sfs), and
[the protocol page](the-protocol-switching.md#the-save) says what it holds.

## The install

KSP 1.12.5 on Windows, with `GameData` holding Harmony, ModuleManager,
[KSP Community Fixes](https://github.com/KSPModdingLibs/KSPCommunityFixes) 1.41.1, this mod,
[KSP Diag - Landed Vessel](https://github.com/lhervier/KSP-Diag-LandedVessel), which reads the capsule
at the same moments, and [KSP-MCPServer](https://github.com/lhervier/KSP-MCPServer),
which plays the protocol, and nothing else.

The six rounds were played by [the script of the protocol](the-protocol-switching.md#played-by-a-script),
`run-switching.py`, in a single session.

## The readings

Six rounds, two lines each: the first recorded as the save opens, flying the rover, the second a few
seconds after switching to the capsule. The bottom line of the screenshot is the reading in progress,
not a record.

![Six rounds of loading the save and switching to the capsule](../imgs/measures/switch-vessel/six-rounds.png)

**Ground KSP computes** reads 64,784.828 mm on all twelve lines. In *Difference*, in millimetres:

| round | as the save opens | after the switch | moved by the switch |
|---|---|---|---|
| 1 | +9.821 | +9.821 | 0.000 |
| 2 | +18.533 | +18.533 | 0.000 |
| 3 | +46.138 | +46.136 | −0.002 |
| 4 | −65.912 | −65.912 | 0.000 |
| 5 | +9.744 | +9.743 | −0.001 |
| 6 | −44.427 | −44.426 | +0.001 |
| **lowest to highest** | **112.1 mm** | **112.0 mm** | |

## What these readings show

**The height KSP computes never moves.** The same digits on all twelve lines.

**The ground under the capsule is somewhere else at every loading.** From one round to the next it
lands anywhere within 112.1 mm, upwards as well as downwards — of the same order as
[the loading series](the-measurements-loading.md) on Kerbin, and for the same reason: every round
starts by loading the save.

**The switch does not move it.** Within a round, the line taken after the switch reads the ground the
line before it read, to within two thousandths of a millimetre — the capsule settling a hair once
physics takes it over, and moving the spot the ray is fired at with it. Whatever the ground under the
capsule is going to be, it already is the moment the save opens — with the capsule still two
kilometres from the craft being flown, and not yet flown itself.

## The logs

[`diag/runs/switching-stock.log`](../diag/runs/switching-stock.log) — the `KSP.log` of the session
the six rounds were taken in; what the script printed is in
[`switching-stock-script.txt`](../diag/runs/switching-stock-script.txt), and every line it recorded,
in both instruments, in [`switching-stock-lines.json`](../diag/runs/switching-stock-lines.json).
