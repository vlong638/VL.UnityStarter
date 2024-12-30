using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.Gaming.Unity.Gaming.Content.Enums
{
    public enum InstrumentType
    {
        None = 0,

        Walls = 100,
        WoodenWalls,
        StoneWalls,
        MagicWalls,

        Towers = 100,
        ArcherTowers,
        CannonTowers,

        Traps = 200,

        SiegeEngines = 300,
        Catapults,//Used for long-range attacks on walls and enemies
        BatteringRams,//Used to break down walls and gates
        SiegeTowers,//Provide a height advantage for attacking walls, can accommodate multiple soldiers for the assault.

        MedicalFacilities = 400,
        HealingStations,//Provide continuous healing effects to units within range.
        MedicalTents,//Offer temporary healing and resting spots.
        HealingCrystals,//Release healing waves, restoring the health of nearby units.
    }
}
