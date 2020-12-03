using SquirtingElephant.Helpers;
using UnityEngine;
using Verse;

namespace SquirtingElephant.MoreSecurity
{
    public class TurretSettings
    {
        #region Fields
        
        public string TranslationKey; // Keyed translation string.
        public string DefName; // Def name of Turret itself.
        public string BulletDefName; // Def name of the bullet that this turret uses.
        public int MaxHP;
        public int Beauty;
        public float StoppingPower;
        public int BulletSpeed;
        public float BurstCooldown;
        public int CostSteel;
        public int CostComponent;

        public string TranslationKey_Default;
        public string DefName_Default;
        public string BulletDefName_Default;
        public int MaxHP_Default;
        public int Beauty_Default;
        public float StoppingPower_Default;
        public int BulletSpeed_Default;
        public float BurstCooldown_Default;
        public int CostSteel_Default;
        public int CostComponent_Default;

        private readonly int SettingsRowIdx;
        private const float ICON_WIDTH = 32f;

        private static readonly string[] HEADER_TRANSLATION_KEYS = { "MS_MaxHP", "MS_Beauty", "MS_StoppingPower", "MS_BulletSpeed", "MS_TurretBurstCooldownTime", "MS_CostSteel", "MS_CostComponent" };

        #region Min & Max
        private const int MIN_TURRET_HP = 1;
        private const int MAX_TURRET_HP = 100000;
        private const int MIN_BEAUTY = -500;
        private const int MAX_BEAUTY = 500;
        private const float MIN_STOPPING_POWER = 0.0f;
        private const float MAX_STOPPING_POWER = 12.0f;
        private const int MIN_BULLET_SPEED = 1;
        private const int MAX_BULLET_SPEED = 165;
        private const float MIN_TURRET_SHOOT_COOLDOWN = 0.001f;
        private const float MAX_TURRET_SHOOT_COOLDOWN = 100.0f;
        private const int MIN_COST = 1;
        private const int MAX_COST = 100000;
        #endregion

        #endregion

        public TurretSettings(int settingsRowIdx, string translationKey, string defName, string bulletDefName, int maxHP, int beauty, float stoppingPower, int bulletSpeed, float burstCooldown, int costSteel, int costComponent)
        {
            this.SettingsRowIdx = settingsRowIdx;

            // This could/should be refactored but I have no time right now.
            this.TranslationKey = TranslationKey_Default = translationKey;
            this.DefName        = DefName_Default        = defName;
            this.BulletDefName  = BulletDefName_Default  = bulletDefName;
            this.MaxHP          = MaxHP_Default          = maxHP;
            this.Beauty         = Beauty_Default         = beauty;
            this.StoppingPower  = StoppingPower_Default  = stoppingPower;
            this.BulletSpeed    = BulletSpeed_Default    = bulletSpeed;
            this.BurstCooldown  = BurstCooldown_Default  = burstCooldown;
            this.CostSteel      = CostSteel_Default      = costSteel;
            this.CostComponent  = CostComponent_Default  = costComponent;
        }

        #region Settings GUI
        public void DoSettingsWindowContents(Listing_Standard ls)
        {
            Rect rowRect = MoreSecuritySettings.Table.GetRowRect(SettingsRowIdx);
            Rect labelRect = MoreSecuritySettings.Table.GetFieldRect(0, SettingsRowIdx);

            Widgets.ThingIcon(labelRect.Replace_Width(ICON_WIDTH), DefDatabase<ThingDef>.GetNamed(DefName), (ThingDef)null, 1f);
            Widgets.Label(labelRect.Add_X(ICON_WIDTH + 2), TranslationKey.Translate().CapitalizeFirst());

            MakeTextFieldNumeric(MoreSecuritySettings.Table.GetFieldRect(     1, SettingsRowIdx), ref MaxHP,         MIN_TURRET_HP,             MAX_TURRET_HP);
            MakeTextFieldNumeric(MoreSecuritySettings.Table.GetFieldRect(     2, SettingsRowIdx), ref Beauty,        MIN_BEAUTY,                MAX_BEAUTY);
            MakeTextFieldNumericFloat(MoreSecuritySettings.Table.GetFieldRect(3, SettingsRowIdx), ref StoppingPower, MIN_STOPPING_POWER,        MAX_STOPPING_POWER);
            MakeTextFieldNumeric(MoreSecuritySettings.Table.GetFieldRect(     4, SettingsRowIdx), ref BulletSpeed,   MIN_BULLET_SPEED,          MAX_BULLET_SPEED);
            MakeTextFieldNumericFloat(MoreSecuritySettings.Table.GetFieldRect(5, SettingsRowIdx), ref BurstCooldown, MIN_TURRET_SHOOT_COOLDOWN, MAX_TURRET_SHOOT_COOLDOWN);
            MakeTextFieldNumeric(MoreSecuritySettings.Table.GetFieldRect(     6, SettingsRowIdx), ref CostSteel,     MIN_COST,                  MAX_COST);
            MakeTextFieldNumeric(MoreSecuritySettings.Table.GetFieldRect(     7, SettingsRowIdx), ref CostComponent, MIN_COST,                  MAX_COST);

            if (Mouse.IsOver(rowRect))
                Widgets.DrawHighlight(rowRect);
            TooltipHandler.TipRegion(rowRect.LeftHalf(), TranslationKey.Translate().CapitalizeFirst());

            ls.Gap();
        }

        public static void CreateHeaders()
        {
            for (int i = 0; i < HEADER_TRANSLATION_KEYS.Length; i++)
            {
                Widgets.Label(MoreSecuritySettings.Table.GetHeaderRect(i + 1), HEADER_TRANSLATION_KEYS[i].Translate().CapitalizeFirst());
            }
        }

        private void MakeTextFieldNumeric(Rect rect, ref int setting, int min, int max)
        {
            string buffer = setting.ToString();
            Widgets.TextFieldNumeric(rect, ref setting, ref buffer, min, max);
        }
        private void MakeTextFieldNumericFloat(Rect rect, ref float setting, float min, float max)
        {
            string buffer = setting.ToString();
            Widgets.TextFieldNumeric(rect, ref setting, ref buffer, min, max);
        }
        #endregion

        public void ExposeData()
        {
            Scribe_Values.Look(ref MaxHP,         DefName + "_MaxHP",         MaxHP_Default);
            Scribe_Values.Look(ref Beauty,        DefName + "_Beauty",        Beauty_Default);
            Scribe_Values.Look(ref StoppingPower, DefName + "_StoppingPower", StoppingPower_Default);
            Scribe_Values.Look(ref BulletSpeed,   DefName + "_BulletSpeed",   BulletSpeed_Default);
            Scribe_Values.Look(ref BurstCooldown, DefName + "_BurstCooldown", BurstCooldown_Default);
            Scribe_Values.Look(ref CostSteel,     DefName + "_CostSteel",     CostSteel_Default);
            Scribe_Values.Look(ref CostComponent, DefName + "_CostComponent", CostComponent_Default);
        }
    }
}
