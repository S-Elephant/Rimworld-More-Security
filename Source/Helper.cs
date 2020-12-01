using RimWorld;
using System;
using System.Linq;
using Verse;

namespace SquirtingElephant.MoreSecurity
{
    /// <summary>
    /// Helper class.
    /// </summary>
    public static class Helper
    {
        public static int RoundToNearestMultiple(int value, float multiple) => (int)(Math.Round(value / multiple) * multiple);
        private static void LogWarning(string defName) => Log.Warning("Unable to find Def: " + defName);

        public static ThingDef GetThingDef(string thingDefName)
        {
            var def = DefDatabase<ThingDef>.GetNamed(thingDefName);
            if (def != null)
                return def;

            LogWarning(thingDefName);
            return null;
        }

        public static void SetResearchBaseCost(string researchDefName, int newResearchCost)
        {
            var def = DefDatabase<ResearchProjectDef>.GetNamed(researchDefName);
            if (def != null)
                def.baseCost = newResearchCost;
            else
                LogWarning(researchDefName);
        }

        public static void SetThingMaxHP(string thingDefName, int newHP) => SetThingStat(thingDefName, "MaxHitPoints", newHP);
        public static void SetThingMaxBeauty(string thingDefName, int newBeauty) => SetThingStat(thingDefName, "Beauty", newBeauty);

        public static void SetThingTurretBurstCooldown(string thingDefName, float newTurretBurstCooldown)
        {
            var def = GetThingDef(thingDefName);
            if (def != null)
                def.building.turretBurstCooldownTime = newTurretBurstCooldown;
        }

        private static void SetThingStat(string thingDefName, string statDefName, float newValue)
        {
            var def = GetThingDef(thingDefName);
            if (def != null)
                def.statBases.Find(s => s.stat.defName == statDefName).value = newValue;
        }

        public static void SetThingSteelCost(string thingDefName, int newSteelCost)
        {
            var def = GetThingDef(thingDefName);
            if (def != null)
            {
                ThingDefCountClass costDef = def.costList.FirstOrDefault(c => c.thingDef == ThingDefOf.Steel);
                if (costDef != null) { costDef.count = newSteelCost; }
            }
        }

        public static void SetThingComponentCost(string thingDefName, int newComponentCost)
        {
            var def = GetThingDef(thingDefName);
            if (def != null)
            {
                ThingDefCountClass costDef = def.costList.FirstOrDefault(c => c.thingDef == ThingDefOf.ComponentIndustrial);
                if (costDef != null) { costDef.count = newComponentCost; }
            }
        }

        public static void SetThingComponentSpacerCost(string thingDefName, int newComponentSpacerCost)
        {
            var def = GetThingDef(thingDefName);
            if (def != null)
            {
                ThingDefCountClass costDef = def.costList.FirstOrDefault(c => c.thingDef == ThingDefOf.ComponentSpacer);
                if (costDef != null) { costDef.count = newComponentSpacerCost; }
            }
        }
    }
}
