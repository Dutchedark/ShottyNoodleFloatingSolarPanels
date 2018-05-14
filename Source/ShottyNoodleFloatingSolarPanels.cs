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

    public class Building_FloatableSolarPanel : Building
    {
        public string TerrainTypeAtBaseCellDefAsString;
        public override void Destroy(DestroyMode mode = 0)
        {
            base.Map.snowGrid.SetDepth(base.Position, 0f);
            if (this.TerrainTypeAtBaseCellDefAsString != null)
            {
                base.Map.terrainGrid.SetTerrain(base.Position, TerrainDef.Named(this.TerrainTypeAtBaseCellDefAsString));
            }
            base.Destroy(mode);
        }
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look<string>(ref this.TerrainTypeAtBaseCellDefAsString, "TerrainTypeAtBaseCellDefAsString", null, false);
        }

        public override void SpawnSetup(Map map, bool flag)
        {
            base.SpawnSetup(map, flag);
            TerrainDef terrainDef = map.terrainGrid.TerrainAt(base.Position);

            if (terrainDef.defName.Contains("Water"))
            {
                if (terrainDef == TerrainDef.Named("WaterDeep") || terrainDef == TerrainDef.Named("WaterOceanDeep") || terrainDef == TerrainDef.Named("WaterMovingDeep"))
                {
                    map.terrainGrid.SetTerrain(base.Position, TerrainDef.Named("UnderPanelWater"));
                }
            }
        }
    }
}