# What the measurements show: coming back to a craft you left

Part of [KSP Diag - Terrain Height](../README.md): what [the measurements of coming back to a craft you left](the-measurements-approach.md)
say, six round trips on Kerbin, in one single flight.

**The height KSP computes never moves.** The same digits on every line, from the first round trip to
the last.

**The ground under the craft comes back somewhere else every time.** From 6.4 to 37.2 mm per round
trip, upwards or downwards. Over the whole series — where it started, and where each of the six
round trips left it — it spans 49.3 mm.

**It moves while the craft is away.** Driving off does not move it: lines 1 and 2 of
[each round trip](the-measurements-approach.md#the-readings) are the same to the
micrometre. By the time the craft is back in range, line 4, before physics has taken it over, the
ground is already somewhere else. From line 4 to line 5, when physics takes the craft over, it moves
by 0.023 mm at most — the craft settling and moving the spot the ray is fired at.

**Nothing was loaded.** No scene change, no save, no quickload: the whole series was taken in one
flight, by driving away and coming back.

The size is not the same from one round trip to the next. That is why the protocol asks for a series.
