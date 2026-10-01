# The saves and the runs

Part of [Terrain Precision Fix Diag 2](../README.md): the saves and the logs of
[the approach protocol](../docs/the-protocol-approach.md),
[the switching protocol](../docs/the-protocol-switching.md),
[the runway protocol](../docs/the-protocol-runway.md) and
[the driving protocol](../docs/the-protocol-driving.md), and of loadings on Real Solar System. What their readings say is in
[The measurements: coming back to a craft you left](../docs/the-measurements-approach.md),
[The measurements: switching to a craft far away](../docs/the-measurements-switching.md),
[The measurements: the runway and the grass beside it](../docs/the-measurements-runway.md) and
[The measurements: driving on while the world moves](../docs/the-measurements-driving.md).

- [`approach-kerbin.sfs`](approach-kerbin.sfs) — the save the approach protocol uses: a capsule
  landed on the flat grass west of the KSC, and a rover 26 m from it.
- [`driving-kerbin.sfs`](driving-kerbin.sfs) — the save the driving protocol uses:
  [`Diag2-Rover`](../craft/Diag2-Rover.craft), alone on the grass south of the runway.
- [`switch-kerbin.sfs`](switch-kerbin.sfs) — the save the switching protocol uses: a capsule landed
  on the same grass, and a rover 1.97 km to the south of it.
- [`runway-kerbin.sfs`](runway-kerbin.sfs) — the save the runway protocol uses: two identical craft,
  one on the grass beside the runway and one on the runway, 152 m apart.
- [`runway-mun-kk.sfs`](runway-mun-kk.sfs) — the same protocol on the Mun: two identical craft, one on
  a runway placed by [Kerbal Konstructs](https://github.com/KSP-RO/Kerbal-Konstructs) 1.12.3 and one on
  the ground 42 m away. The runway itself is in the two files of
  [`runway-mun-kk/GameData/KerbalKonstructs/NewInstances/`](runway-mun-kk/GameData/KerbalKonstructs/NewInstances/):
  copy that `GameData` into the folder of KSP, over its own, before loading the save.

Copy a save into the folder of a sandbox game and load it from that game.

- [`runs/switching-stock.log`](runs/switching-stock.log) — the `KSP.log` of the session the six
  switching rounds were taken in.
- [`runs/runway-stock.log`](runs/runway-stock.log) — the `KSP.log` of the session the six loadings
  of the runway protocol were taken in.
- [`runs/runway-mun-kk-stock.log`](runs/runway-mun-kk-stock.log) — the `KSP.log` of the session the six
  loadings on the Mun, beside the runway placed by Kerbal Konstructs, were taken in.
- [`runs/driving-stock-1.log`](runs/driving-stock-1.log) and
  [`runs/driving-stock-2.log`](runs/driving-stock-2.log) — the `KSP.log` of the sessions the two runs of
  the driving protocol were taken in.

## On Real Solar System

Taken on [Real Solar System](https://github.com/KSP-RO/RealSolarSystem) 20.1.3.0 and what it requires
(Kopernicus, Modular Flight Integrator, KSPTextureLoader, the RSS textures), on an install of their own:
these saves only load there. The protocol is [the loading protocol](../docs/the-protocol-loading.md).

- [`reload-moon-rss.sfs`](reload-moon-rss.sfs) — a capsule on an empty FL-T100, landed on flat ground
  on the Moon.
- [`reload-moon-rss-resave.sfs`](reload-moon-rss-resave.sfs) — the same craft, saved again at a later
  load.
- [`reload-earth-rss-resave.sfs`](reload-earth-rss-resave.sfs) — the same kind of craft, on the grass
  about 1.4 km west of the KSC on Earth.
- [`reload-earth-rss-landed.sfs`](reload-earth-rss-landed.sfs) — the save above, with one line changed
  in the file: the situation of the craft, from `PRELAUNCH` to `LANDED`.

Copy a save into the folder of a sandbox game and load it from that game.

- [`runs/reload-moon-rss-stock.log`](runs/reload-moon-rss-stock.log) — six loads of
  `reload-moon-rss-resave.sfs`.
- [`runs/reload-earth-rss-stock.log`](runs/reload-earth-rss-stock.log) — six loads of
  `reload-earth-rss-resave.sfs`.
