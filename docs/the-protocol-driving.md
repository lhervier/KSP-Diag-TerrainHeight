# The protocol: driving on while the world moves

Part of [KSP Diag - Terrain Height](../README.md): how to read the ground under a rover that keeps
driving, just before and just after the game moves its whole world. Nothing is loaded here — from the
first line to the last, it is one single flight. The columns it fills are in [The window](the-window.md),
and what it reads is in [The measurements: driving on while the world moves](the-measurements-driving.md).

The other protocols read the ground under a craft the game sets down: handed back by a save —
[The protocol: loading the same save](the-protocol-loading.md) — loaded again as you come back to it —
[The protocol: coming back to a craft you left](the-protocol-approach.md) — or flown after a switch —
[The protocol: switching to a craft far away](the-protocol-switching.md). Here the rover never leaves
physics: what changes is the world around it.

KSP keeps the craft you fly near the centre of Unity's world. Every 500 m it drives, the game moves the
whole world back under it, the ground included: this is called the *floating origin*, and
[KSP Diag - Floating Origin](https://github.com/lhervier/KSP-Diag-FloatingOrigin) explains it
and counts those moves
([What it measures](https://github.com/lhervier/KSP-Diag-FloatingOrigin/blob/master/docs/what-it-measures.md)).
This protocol reads the ground on either side of one such move, a few metres apart, then the same few
metres farther on, with no move in between, to tell what the move does from what the few metres do.

## Two instruments

This protocol needs Diag FloatingOrigin in the same install as this mod. Diag FloatingOrigin only reads; it is there to tell you
when the world moves, through two of its columns:

- **Origin distance (m)**, how far the rover is from the origin of the world. It grows as you drive,
  and drops back near zero when the world moves;
- **Shifts**, how many times the world moved since its previous line. The game moves it once as the
  scene opens, so the first line of the series reads 1 although the rover has not driven 500 m yet.

Every record below is taken in both windows: press *Record* in this mod's window, then in Diag FloatingOrigin's,
without moving in between. The two tables then have the same number of lines, and each line of Diag FloatingOrigin
says whether the world moved since the line before.

## The save

[`driving-kerbin.sfs`](../diag/driving-kerbin.sfs), a sandbox game of KSP 1.12.5. Copy it into the
folder of a sandbox game and load it from that game. It holds a single craft,
[`Diag2-Rover`](../craft/Diag2-Rover.craft), a crewed rover on four wheels, with batteries and solar
panels to recharge them, landed on the flat grass south of the runway of the KSC, at latitude −0.0581°,
longitude −74.7241°, facing due south. No target is set.

**The rover is alone, and has to be.** While another landed craft is loaded nearby, the game does not
move the world at all, however far the rover drives; it only catches up when that craft is unloaded,
2500 m away ([Diag FloatingOrigin, case 3](https://github.com/lhervier/KSP-Diag-FloatingOrigin/blob/master/docs/the-measurements.md#case-3-a-rover-near-a-parked-craft-then-on-its-own)).
With a second craft parked nearby, nothing on this page would happen.

You can make your own: copy [`craft/Diag2-Rover.craft`](../craft/Diag2-Rover.craft) into the
`Ships/SPH` folder of a sandbox game, launch it from the Spaceplane Hangar onto the runway, and drive
due south until it is off the runway and on the grass. Stop, put the brakes on, and save once.

### The same on Earth, in Real Solar System

[`driving-earth-rss.sfs`](../diag/driving-earth-rss.sfs) holds the same rover on Earth, on the grass
south of the runway of the KSC at Cape Canaveral, at latitude 28.6119°, longitude −80.6176°. It only
loads in an install with [Real Solar System](https://github.com/KSP-RO/RealSolarSystem) and what it
requires. It was made the same way, from the Spaceplane Hangar of that install.

Real Solar System keeps the origin of the world from moving while a craft rolls on the runway of the KSC:
the whole series is driven on the grass.

## The protocol

Load the save and **do not change scene again** — no save, no load, no trip back to the space centre.
Diag FloatingOrigin reads an **Origin distance** near zero: the origin of the world is on the rover.

Drive due south across the flat grass, away from the runway and the buildings. Then, for each
move of the world, three records.

**1. Just before.** Stop when **Origin distance** reads about 490 m — between 498 and 500 m on Earth.
Wait for the digits of this mod to stop moving, then record.

**2. Just after.** Creep forward until **Origin distance** drops back near zero: the world has moved.
Stop a few metres on — within 2 m on Earth — wait, and record. Diag FloatingOrigin's line reads 1 in **Shifts**.

**3. The same distance again.** Creep forward about as far as from 1 to 2 — another 2 m on Earth — stop,
wait, and record. Diag FloatingOrigin's line reads 0 in **Shifts**.

Then drive on to the next move, 500 m farther, and do it again, three moves in all.

**Three moves, and no more**, because on Kerbin the grass south of the runway is flat for about a
kilometre and a half only. Beyond, the ground slopes down, and on a slope a few metres change **Difference** far more
than a move does: the third line, with no move, shows it. A fourth move, about two kilometres south of
the runway, gave a computed height dropping by 15 to 29 cm from one line to the next, and a
**Difference** changing by 176 mm with no move at all.

## What the three lines are worth

| line | between it and the line before | what the line is worth |
|---|---|---|
| 1 | the rover drove about 490 m | the ground just before the move |
| 2 | a few metres, and one move of the world | the ground just after it |
| 3 | the same few metres, and no move | the same step, without the move |

**Read the change from line 1 to line 2 against the change from line 2 to line 3.** Lines 1 and 2 are
not read at the same spot, so **Difference** can change between them even if the move did nothing:
the ground is built out of flat triangles that do not follow its curve exactly
([This mod's demonstration](this-mods-demonstration.md)), and now and then a few metres cross from one
piece of the ground to the next. Line 3 measures what the few metres do on their own, with no move in
between.

⚠️ **Keep a move only when its second line changes at least three times as much as its third.** Below
that, a few metres change the reading nearly as much as the move does, and the move cannot be told
apart.

**Ground KSP computes** says how much the ground's own shape changes between the lines. On the grass of
Kerbin, it reads the same digits to a few thousandths of a millimetre. On Earth, around the KSC, it
changes by about a centimetre per metre: hence the closer stops there, which keep the third line small.

⚠️ **Compare only lines a few metres apart.** Between line 3 of one move and line 1 of the next, the
rover drives about 480 m: **Difference** can change by several centimetres over that distance, with no
move at all.

⚠️ **Stay on the grass.** The ray stops at the first surface it meets: on the runway or a building, it
reads a structure, not the ground.

⚠️ **Do not save while the series is running.** The readings are only comparable if they are all taken
in the one flight the save opened.

**One move says nothing on its own.** It is the series that is worth reading, not a line.
