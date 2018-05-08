using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using Verse;

namespace ShottyNoodleFloatingSolarPanels
{
    public class PlaceWorker_FloatableSolarPanel : PlaceWorker {
        public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map, Thing thingToIgnore = null){
            TerrainDef terraindef = map.terrainGrid.TerrainAt(loc);
            if (terraindef == TerrainDef.Named("WaterDeep") || terraindef == TerrainDef.Named("WaterOceanDeep") || terraindef == TerrainDef.Named("WaterMovingDeep")) {
               return true;
            }
            return new AcceptanceReport("SS.OnlyDeepWater".Translate());
        }
    }

    public class PlaceWorker_FloatableConduit : PlaceWorker {
        public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map, Thing thingToIgnore = null){
            TerrainDef terraindef = map.terrainGrid.TerrainAt(loc);
            if (terraindef == TerrainDef.Named("WaterDeep") || terraindef == TerrainDef.Named("WaterOceanDeep") || terraindef == TerrainDef.Named("WaterMovingDeep") ||
                 terraindef == TerrainDef.Named("WaterShallow") || terraindef == TerrainDef.Named("WaterOceanShallow") || terraindef == TerrainDef.Named("WaterMovingShallow")) {
               return true;
            }
            return new AcceptanceReport("SS.OnlyWater".Translate());
        }
    }
}