using Verse;

namespace SquirtingElephant.MoreSecurity
{
    [StaticConstructorOnStartup] // This makes the static constructor get called AFTER defs are loaded.
    public class MS_OnDefsLoaded
    {
        static MS_OnDefsLoaded()
        {
            ApplySettingsToDefs();

            #if debug
            Log.Message("MS_ModName".Translate() + ": Settings applied");
            #endif
        }

        public static void ApplySettingsToDefs()
        {
            ApplyResearch();
            ApplySandbags();
            ApplyTurrets();
        }

        private static void ApplyResearch()
        {
            Helper.SetResearchBaseCost("MoreTrapsMKII", MS_Settings.Settings.ResearchCost_TrapsMKII);
            Helper.SetResearchBaseCost("MoreTurretsMKII", MS_Settings.Settings.ResearchCost_GunTurretMKII);
            Helper.SetResearchBaseCost("MoreTurretsMKIII", MS_Settings.Settings.ResearchCost_GunTurretMKIII);
            Helper.SetResearchBaseCost("MoreTurretsMKIV", MS_Settings.Settings.ResearchCost_GunTurretMKIV);
        }

        private static void ApplySandbags()
        {
            Helper.SetThingMaxHP("Sandbags_MKII", MS_Settings.Settings.SandbagMKII_MaxHP);
            Helper.SetThingMaxHP("Sandbags_MKIII", MS_Settings.Settings.SandbagMKIII_MaxHP);
        }

        private static void ApplyTurrets()
        {
            MS_Settings.Settings.AllTurretSettings.ForEach(s => ApplyTurretSettings(s));
        }

        private static void ApplyTurretSettings(TurretSettings turretSettings)
        {
            Helper.SetThingMaxHP(turretSettings.DefName, turretSettings.MaxHp);
            Helper.SetThingMaxBeauty(turretSettings.DefName, turretSettings.Beauty);
            Helper.SetThingTurretBurstCooldown(turretSettings.DefName, turretSettings.BurstCooldown);
            
            ThingDef bulletDef = Helper.GetThingDef(turretSettings.BulletDefName);
            if (bulletDef != null)
            {
                bulletDef.projectile.stoppingPower = turretSettings.StoppingPower;
                bulletDef.projectile.speed = turretSettings.BulletSpeed;
            }

            Helper.SetThingSteelCost(turretSettings.DefName, turretSettings.CostSteel);
            Helper.SetThingComponentCost(turretSettings.DefName, turretSettings.CostComponent);
            //SE_Helper.SetThingComponentSpacerCost(turretSettings.DefName, turretSettings.CostComponentSpacer);
        }
    }
}
