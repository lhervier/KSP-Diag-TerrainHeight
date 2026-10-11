# This mod's demonstration

Part of [KSP Diag - Terrain Height](../README.md): the two heights the mod reads, why a correct reading is not zero, and what the readings cannot tell.

There are two grounds in KSP, and they are not the same object.

One is **computed**. The game works out the height of its terrain, for any spot on any world, from the
formulas the world is made of. That is the number behind altimeters, maps, and where the sea ends.

The other is **built**. The game assembles a mesh of triangles for the terrain around you. That mesh is what your landing legs touch, what your wheels roll on, what stops you
falling through.

This mod reads both, for the spot your craft is standing on, every frame, and records them side by side
when you ask.

The built one is read by pointing a ray straight down at it and asking the physics engine where it was
stopped:

```csharp
private static double MeasureCollisionSurface(Vessel vessel)
{
    CelestialBody body = vessel.mainBody;
    Vector3 position = vessel.vesselTransform.position;
    Vector3 up = FlightGlobals.getUpAxis(body, position);
    RaycastHit hit;
    if (!Physics.Raycast(position + up * Constants.RAY_START_HEIGHT, -up, out hit,
            Constants.RAY_LENGTH, Constants.LOCAL_SCENERY_MASK, QueryTriggerInteraction.Ignore))
    {
        return double.NaN;
    }

    return (((Vector3d)hit.point - body.position).magnitude - body.pqsController.radius) * 1000.0;
}
```

The computed one is simply asked for, at the same latitude and longitude:

```csharp
private static double MeasureComputedTerrain(Vessel vessel)
{
    CelestialBody body = vessel.mainBody;
    Vector3 position = vessel.vesselTransform.position;

    return body.TerrainAltitude(
        body.GetLatitude(position),
        body.GetLongitude(position),
        allowNegative: true
    ) * 1000.0;
}
```

Two things about that pair are deliberate. **They share nothing but the vessel**: each one reads the
position and the body again for itself, and neither is computed from the other — which is what makes
putting them side by side worth anything. And **they describe the same spot for free**: the ray runs
along the radius through the vessel, and latitude and longitude are what a direction from the centre of
a body *is*, so they hold all the way down that radius. Wherever the ray lands, it lands at the
vessel's own latitude and longitude — whatever the slope, and however the craft leans. Both sides are
in double precision from end to end, because reading a few millimetres out of six hundred kilometres
leaves no room for anything less.

## Why a correct reading is not zero

The two never land on the same number, and they are not supposed to. Zero is the wrong thing to hope
for: **a correct reading is a small number that is not zero**, and it is the shape of the ground that
decides how large it is and which sign it takes.

The collision mesh is made of flat triangles about a hundred and fifty metres across, with their
corners sitting on the surface the game computes. Chained one to the next, those flat pieces do follow
the lie of the land — that is what makes a mesh look like ground at all. What they cannot follow is
what the ground does *between* two corners. A hummock, a dip, the shoulder of a crater: the flat piece
cuts straight across, and the ray hits it wherever it happens to pass.

![On rough ground the mesh cuts straight across whatever the ground does between two corners](../imgs/why-not-zero-rough.svg)

So the ray stops short of the computed height, or goes past it, by whatever the mesh left out — on
rough ground, centimetres. The sign is the ground's to give: under the computed height where the
ground rises between two corners, over it where it dips. None of that is an error: it is what flat
triangles make of the shape of the ground at that spot.

A legitimate zero exists, it is simply not something you can aim for: right on a corner, the one place
where the mesh touches the surface it stands in for, and anywhere between two corners where the ground
happens to cross the flat piece spanning it. Everywhere else there is a gap.

> **And note that even perfectly flat ground does not read zero.** Worlds in KSP are round, so a flat
> triangle laid across the curve of one sags below it — the way a straight plank across the top of a
> barrel touches only at its two ends. On Kerbin that sag is about **−5.5 mm**. It is the floor under
> every reading, and out on ground as flat as the apron by the runway it is very nearly the whole of a
> correct one: negative, and known before you take it.

**A zero is not what a correct reading looks like. A small number, whose size and sign follow the
shape of the ground, is.**

## What this instrument shows, and what it does not

Both readings are of **the ground**, at the spot the craft marks: the craft itself is never read —
neither where the game places it, nor where it comes to rest.

**A craft that jumped or tipped over is read somewhere else.** The reading is taken where the craft
came to rest, so a craft that jumped or tipped over gives a line for another spot. The difference does
not say so, but **Ground KSP computes** gives it away: it follows the spot, so when it changes, the
craft is no longer where it was. Note what you saw next to each line.

Another instrument,
[KSP Diag - Landed Vessel](https://github.com/lhervier/KSP-Diag-LandedVessel), measures the
**craft** itself — where the game places it, and where it comes to rest — and never looks at the
ground. You do not need it to follow these readings.
