using Verse;

namespace SquirtingElephant.MoreSecurity
{
    public class TurretSettings
    {
        public string TranslationKey; // Keyed translation string.
        public string DefName; // Def name of Turret itself.
        public string BulletDefName; // Def name of the bullet that this turret uses.
        public int MaxHp;
        public int Beauty;
        public float StoppingPower;
        public int BulletSpeed;
        public float BurstCooldown;
        public int CostSteel;
        public int CostComponent;
        //public int CostComponentSpacer;

        private const int MIN_TURRET_HP = 1;
        private const int MAX_TURRET_HP = 100000;
        private const int MIN_BEAUTY = -500;
        private const int MAX_BEAUTY = 500;
        private const float MIN_STOPPING_POWER = 0.0f;
        private const float MAX_STOPPING_POWER = 10.0f;
        private const int MIN_BULLET_SPEED = 1;
        private const int MAX_BULLET_SPEED = 160;
        private const float MIN_TURRET_SHOOT_COOLDOWN = 0.001f;
        private const float MAX_TURRET_SHOOT_COOLDOWN = 100.0f;
        private const int MIN_COST = 1;
        private const int MAX_COST = 100000;

        public void DoSettingsWindowContents(Listing_Standard ls)
        {
            ls.GapLine();
            ls.Label(TranslationKey.Translate());
            CreateTurretSettingHP(ls, ref MaxHp);
            CreateTurretSettingBeauty(ls, ref Beauty);
            CreateTurretSettingStoppingPower(ls, ref StoppingPower);
            CreateTurretSettingBulletSpeed(ls, ref BulletSpeed);
            CreateTurretSettingCooldown(ls, ref BurstCooldown);
            CreateTurretSettingCostSteel(ls, ref CostSteel);
            CreateTurretSettingCostComponents(ls, ref CostComponent);
            //MS_Settings.CreateTurretSettingCostComponentsSpacer(ls, ref CostComponentSpacer);
        }

        public void ExposeData()
        {
            Scribe_Values.Look(ref MaxHp, DefName + "_MaxHP", MaxHp);
            Scribe_Values.Look(ref Beauty, DefName + "_Beauty", Beauty);
            Scribe_Values.Look(ref StoppingPower, DefName + "_StoppingPower", StoppingPower);
            Scribe_Values.Look(ref BulletSpeed, DefName + "_BulletSpeed", BulletSpeed);
            Scribe_Values.Look(ref BurstCooldown, DefName + "_BurstCooldown", BurstCooldown);
            Scribe_Values.Look(ref CostSteel, DefName + "_CostSteel", CostSteel);
            Scribe_Values.Look(ref CostComponent, DefName + "_CostComponent", CostComponent);
            //Scribe_Values.Look(ref CostComponentSpacer, DefName + "_CostComponentSpacer", CostComponentSpacer);
        }

        #region Helper Methods

        private static void CreateTurretSettingHP(Listing_Standard ls, ref int settingMaxHP)
        {
            string buffer = Helper.RoundToNearestMultiple(settingMaxHP, 5).ToString();
            ls.TextFieldNumericLabeled<int>("MS_MaxHP".Translate(), ref settingMaxHP, ref buffer, MIN_TURRET_HP, MAX_TURRET_HP);
        }

        private static void CreateTurretSettingBeauty(Listing_Standard ls, ref int settingBeauty)
        {
            string buffer = settingBeauty.ToString();
            ls.TextFieldNumericLabeled<int>("MS_Beauty".Translate(), ref settingBeauty, ref buffer, MIN_BEAUTY, MAX_BEAUTY);
        }

        private static void CreateTurretSettingStoppingPower(Listing_Standard ls, ref float settingStoppingPower)
        {
            string buffer = settingStoppingPower.ToString();
            ls.TextFieldNumericLabeled<float>("MS_StoppingPower".Translate(), ref settingStoppingPower, ref buffer, MIN_STOPPING_POWER, MAX_STOPPING_POWER);
            settingStoppingPower = ls.Slider(settingStoppingPower, MIN_STOPPING_POWER, MAX_STOPPING_POWER);
        }

        private static void CreateTurretSettingBulletSpeed(Listing_Standard ls, ref int settingBulletSpeed)
        {
            string buffer = settingBulletSpeed.ToString();
            ls.TextFieldNumericLabeled<int>("MS_BulletSpeed".Translate(), ref settingBulletSpeed, ref buffer, MIN_BULLET_SPEED, MAX_BULLET_SPEED);
        }

        private static void CreateTurretSettingCooldown(Listing_Standard ls, ref float settingCooldown)
        {
            string buffer = settingCooldown.ToString();
            ls.TextFieldNumericLabeled<float>("MS_TurretBurstCooldownTime".Translate(), ref settingCooldown, ref buffer, MIN_TURRET_SHOOT_COOLDOWN, MAX_TURRET_SHOOT_COOLDOWN);
            settingCooldown = ls.Slider(settingCooldown, MIN_TURRET_SHOOT_COOLDOWN, MAX_TURRET_SHOOT_COOLDOWN);
        }

        private static void CreateTurretSettingCostSteel(Listing_Standard ls, ref int settingCostSteel)
        {
            string buffer = settingCostSteel.ToString();
            ls.TextFieldNumericLabeled<int>("MS_CostSteel".Translate(), ref settingCostSteel, ref buffer, MIN_COST, MAX_COST);
        }

        private static void CreateTurretSettingCostComponents(Listing_Standard ls, ref int settingCostComponents)
        {
            string buffer = settingCostComponents.ToString();
            ls.TextFieldNumericLabeled<int>("MS_CostComponent".Translate(), ref settingCostComponents, ref buffer, MIN_COST, MAX_COST);
        }

        public static void CreateTurretSettingCostComponentsSpacer(Listing_Standard ls, ref int settingCostComponentsSpacer)
        {
            string buffer = settingCostComponentsSpacer.ToString();
            ls.TextFieldNumericLabeled<int>("MS_CostComponentSpacer".Translate(), ref settingCostComponentsSpacer, ref buffer, MIN_COST, MAX_COST);
        }
        
        #endregion
    }
}
