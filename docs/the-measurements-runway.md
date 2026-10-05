# The measurements: the runway and the grass beside it

Part of [KSP Diag - Terrain Height](../README.md): the readings taken with
[the runway protocol](the-protocol-runway.md) — one craft on the grass and one on the runway, 152 m
apart, the ground under both read at each of six loadings of the same save; then the same on the Mun,
beside a runway placed by a mod.

The save the protocol uses is [`diag/runway-kerbin.sfs`](../diag/runway-kerbin.sfs), and
[the protocol page](the-protocol-runway.md#the-save) says what it holds. The Mun series uses
[`diag/runway-mun-kk.sfs`](../diag/runway-mun-kk.sfs), with Kerbal Konstructs installed and the two files
of its runway copied into `GameData` ([the protocol page](the-protocol-runway.md#the-same-on-the-mun-with-a-runway-placed-by-a-mod)).

## The install

KSP 1.12.5 on Windows, with `GameData` holding Harmony, ModuleManager,
[KSP Community Fixes](https://github.com/KSPModdingLibs/KSPCommunityFixes) 1.41.1, this mod,
[KSP Diag - Landed Vessel](https://github.com/lhervier/KSP-Diag-LandedVessel), which reads the same
craft at the same moments, and [KSP-MCPServer](https://github.com/lhervier/KSP-MCPServer), which plays the
protocol, and nothing else. For the Mun, [Kerbal Konstructs](https://github.com/KSP-RO/Kerbal-Konstructs)
1.12.3 is added, with CustomPreLaunchChecks 1.8.1, which it requires.

Both series were played by [the script of the protocol](the-protocol-runway.md#played-by-a-script),
`run-runway.py`, one session each.

## The readings

Six loadings on each body, two lines each: the odd lines on the ground, the even lines on the runway,
after switching to it. The bottom line of each screenshot is the reading in progress, not a record.

**On Kerbin**, the runway of the KSC and the grass beside it:

![Six loadings on Kerbin, the craft on the grass then the craft on the runway](../imgs/measures/runway/six-loads.png)

**Ground KSP computes** reads 64,784.990 mm under the craft on the grass at all six loadings, and
64,785.047 mm under the craft on the runway. **Ground under craft**, in millimetres, and the step
between the two:

| loading | on the grass | on the runway | **step**: runway minus grass |
|---|---|---|---|
| 1 | 64,791.881 | 69,073.344 | 4,281.462 |
| 2 | 64,765.674 | 69,061.464 | 4,295.789 |
| 3 | 64,827.271 | 69,126.356 | 4,299.084 |
| 4 | 64,797.291 | 69,086.255 | 4,288.964 |
| 5 | 64,737.747 | 69,009.807 | 4,272.060 |
| 6 | 64,771.056 | 69,081.451 | 4,310.395 |
| **lowest to highest** | **89.5 mm** | **116.5 mm** | **38.3 mm** |

In *Difference*, the grass goes from −47.243 to +42.282 mm, the runway from +4,224.760 to +4,341.309 mm.

**On the Mun**, a runway placed by Kerbal Konstructs and the ground 42 m from it:

![Six loadings on the Mun, the craft on the ground then the craft on the runway placed by Kerbal Konstructs](../imgs/measures/runway/six-loads-mun-kk.png)

**Ground KSP computes** reads from 4,123,942.923 to 4,123,942.950 mm under the craft on the ground,
and 4,121,155.656 or .657 mm under the craft on the runway. **Ground under craft**, in millimetres, and
the step between the two:

| loading | on the ground | on the runway | **step**: runway minus ground |
|---|---|---|---|
| 1 | 4,123,549.481 | 4,122,756.005 | −793.475 |
| 2 | 4,123,567.818 | 4,122,738.290 | −829.528 |
| 3 | 4,123,572.074 | 4,122,754.787 | −817.287 |
| 4 | 4,123,558.788 | 4,122,746.229 | −812.558 |
| 5 | 4,123,575.467 | 4,122,755.879 | −819.588 |
| 6 | 4,123,570.767 | 4,122,749.210 | −821.557 |
| **lowest to highest** | **26.0 mm** | **17.7 mm** | **36.1 mm** |

In *Difference*, the ground goes from −393.443 to −367.473 mm, the runway from +1,582.634 to
+1,600.349 mm.

**→ What they show: [What the measurements show: the runway and the grass beside it](what-the-measurements-show-runway.md)**

## The logs

[`diag/runs/runway-stock.log`](../diag/runs/runway-stock.log) — the `KSP.log` of the session the six
loadings on Kerbin were taken in; what the script printed is in
[`runway-stock-script.txt`](../diag/runs/runway-stock-script.txt), and every line it recorded, in both
instruments, in [`runway-stock-lines.json`](../diag/runs/runway-stock-lines.json).

[`diag/runs/runway-mun-kk-stock.log`](../diag/runs/runway-mun-kk-stock.log) — the `KSP.log` of the
session the six loadings on the Mun were taken in; what the script printed is in
[`runway-mun-kk-stock-script.txt`](../diag/runs/runway-mun-kk-stock-script.txt), and every line it
recorded in [`runway-mun-kk-stock-lines.json`](../diag/runs/runway-mun-kk-stock-lines.json).
