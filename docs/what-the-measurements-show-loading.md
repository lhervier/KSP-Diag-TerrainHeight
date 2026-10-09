# What the measurements show: loading the same save

Part of [KSP Diag - Terrain Height](../README.md): what [the measurements of loading the same save](the-measurements-loading.md)
say, on the four worlds of stock KSP and on the Moon and Earth of Real Solar System.

**Ground KSP computes never moves.** On the levelled grass of Kerbin and on the Minmus flats it reads
the same digits six times over — `0.000` on Minmus, which is as plain as this argument gets. On Gilly
it wanders by a hundredth of a millimetre, on the Mun by a tenth: on ground that is not perfectly level, a craft that settles a hair to one side is asking for the height of a slightly
different point, and that shows. Nothing surprising in any of it. That height is worked out from the
formulas the world is made of, and reloading a save does not change the world. On Real Solar System it
moved more, for the same reason: on the Moon, the craft came back inside the ground at every loading
and was pushed out of it ([KSP Diag - Landed Vessel](https://github.com/lhervier/KSP-TerrainPrecisionFix/blob/main/docs/checking-the-culprit-loading.md#the-craft-over-six-loads)
reads it rising at all six), coming to rest a little to one side each time; on Earth, nearly all of
its 0.697 mm comes from the first loading, where the craft was pushed out the same way, the five others
staying within 0.06 mm.

**Ground under craft moves every time.** On Kerbin it lands somewhere else on each of the six lines,
over a range of more than four centimetres, and on none of the six bodies does it come back to the same
place: 2.3 mm on Gilly, 7.3 mm on Minmus, 18.0 mm on the Mun, 43.6 mm on Kerbin, then 48.7 mm on the
Moon of Real Solar System and 292.3 mm on its Earth. Six loadings are few, and they do not rank the worlds one by one, but from Gilly to Earth
the spread grows by two orders of magnitude. Smaller world, smaller spread — but it never goes away.

The bottom two rows of each table of [the measurements](the-measurements-loading.md#the-readings) are the
argument entire. The craft's save never changed and the spot
never changed, so nothing about that patch of ground was different from one loading to the next — and
yet one of the two heights held still while the other wandered, by two orders of magnitude or more,
world after world — and still by a factor of ten on the Moon, where the craft came to rest
somewhere else each time. The one that moved is the one that is wrong, and it is the one that describes
the surface your landing legs actually touch: it was simply not built in the same place twice.

On the Mun, *Difference* sits 26 to 44 mm below zero on every line. That offset
belongs to the spot, not to the loading: the flat triangles the game collides with miss the shape of
the terrain between their corners (see
[Why a correct reading is not zero](this-mods-demonstration.md#why-a-correct-reading-is-not-zero)).
That part is the same on every loading, so it does not reach the spread — only the part that moves
does.

Every figure above is read straight off the screenshots of [the measurements](the-measurements-loading.md#the-readings), and nothing here asks you to take
any of them on trust: reproducing them is what this mod is for.
