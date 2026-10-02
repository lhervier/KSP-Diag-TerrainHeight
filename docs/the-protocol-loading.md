# The protocol: loading the same save

Part of [KSP Diag - Terrain Height](../README.md): how to take the reading yourself, step by step. The columns it fills are in [The window](the-window.md), and the readings it produced are in [The measurements: loading the same save](the-measurements-loading.md).

The two other protocols read the ground under a craft you drive away from and back to —
[The protocol: coming back to a craft you left](the-protocol-approach.md) — and under a craft you
switch to — [The protocol: switching to a craft far away](the-protocol-switching.md).

**1. Launch a craft.** Anything will do — the ray does not care what it is made of.

![A capsule on the runway, the window already reading](../imgs/protocols/reload/00-launching.png)

(The probe window is draggable — drop it wherever it does not get in the way.)

Note what it reads there: **+4,262.636 mm**. The ray is hitting the runway, and the runway deck sits
four metres above the terrain the game computes underneath it. The deck is a structure, not the terrain,
and its height has a wobble of its own — [The measurements: the runway and the grass beside it](the-measurements-runway.md).
Which is what the next step is about.

**2. Move it off onto bare ground.** `Alt+F12 → Cheats → Set Position`. Tick *Use middle click to set
position*, set *Pitch* to 90 so the craft comes down upright, then middle-click a patch of grass just
off the end of the runway. No need to go far, but you do have to be off the tarmac itself.

![Setting the position from the debug menu](../imgs/protocols/reload/10-cheat-position.png)

**3. Save once.**

![Creating the save](../imgs/protocols/reload/20-create-save.png)

**4. Load that same save.** Not a new save — the one from step 3.

![Loading the save](../imgs/protocols/reload/30-load.png)

**5. Wait for the digits to stop moving, then press *Record*.** They stop when the craft does.

⚠️ **Do not touch the throttle.** A landed craft at rest is held in place by the game, but only while
its throttle is closed. Open it, even by a few percent, and on a slope the craft creeps downhill, and
the readings creep with it. The throttle stays where you left it: a single press of Shift is enough,
and only `X` closes it again. On some of the screenshots of this page, the throttle gauge left of the
navball is not at zero: they were taken with Shift+Win+S, and its Shift opened the throttle. Take
yours with F1 or Print Screen, which leave the throttle alone.

![The craft settled, about to record](../imgs/protocols/reload/40-record.png)

The first line appears, with the live line carrying on underneath it.

![The first loading recorded](../imgs/protocols/reload/50-recorded.png)

**6. Load the same save again.** The one from step 3, again.

![Loading the same save again](../imgs/protocols/reload/60-load-again.png)

**7. Settle, and record again.** A second line appears under the first — and *Difference* has already
moved, by thirty millimetres.

![A second loading recorded](../imgs/protocols/reload/70-record-again.png)

**8. Repeat steps 6 and 7** until you have five or six lines. One loading proves nothing: the error is
drawn afresh every time, and can come out small by luck.

![Six loadings recorded](../imgs/protocols/reload/80-record-again-and-again.png)

Then install [Terrain Precision Fix](https://github.com/lhervier/KSP-TerrainPrecisionFix) and do the
same thing again.
