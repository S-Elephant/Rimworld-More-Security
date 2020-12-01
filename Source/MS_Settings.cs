using UnityEngine;
using Verse;

namespace SquirtingElephant.MoreSecurity
{
    public class MS_Settings : Mod
    {
        private Vector2 ScrollPosition = Vector2.zero;
        private Rect ViewRect = new Rect(0.0f, 0.0f, 100.0f, 10000.0f);
        public static MS_SettingsData Settings;
        
        private const int MAX_RESEARCH_COST = 1000000;
        private const int MIN_SANDBAG_HP = 1;
        private const int MAX_SANDBAG_HP = 100000;

        /// <summary>
        /// A mandatory constructor.
        /// </summary>
        public MS_Settings(ModContentPack content) : base(content)
        {
            Settings = GetSettings<MS_SettingsData>();
        }

        /// <summary>
        /// Mod Settings GUI.
        /// </summary>
        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard ls = new Listing_Standard();
            ls.BeginScrollView(inRect, ref ScrollPosition, ref ViewRect);

            #region Research costs
            ls.Label("MS_ResearchCosts".Translate());
            ls.Gap(2);

            string bufferResearchCost_TrapsMKII = Settings.ResearchCost_TrapsMKII.ToString();
            ls.TextFieldNumericLabeled<int>("MS_TrapMKIIResearchCost".Translate(), ref Settings.ResearchCost_TrapsMKII, ref bufferResearchCost_TrapsMKII, 0, MAX_RESEARCH_COST);

            string bufferResearchCost_MoreTurretsMKII = Settings.ResearchCost_GunTurretMKII.ToString();
            ls.TextFieldNumericLabeled<int>("MS_TurretsMKIIResearchCost".Translate(), ref Settings.ResearchCost_GunTurretMKII, ref bufferResearchCost_MoreTurretsMKII, 0, MAX_RESEARCH_COST);

            string bufferResearchCost_MoreTurretsMKIII = Settings.ResearchCost_GunTurretMKIII.ToString();
            ls.TextFieldNumericLabeled<int>("MS_TurretsMKIIIResearchCost".Translate(), ref Settings.ResearchCost_GunTurretMKIII, ref bufferResearchCost_MoreTurretsMKIII, 0, MAX_RESEARCH_COST);

            string bufferResearchCost_MoreTurretsMKIV = Settings.ResearchCost_GunTurretMKIV.ToString();
            ls.TextFieldNumericLabeled<int>("MS_TurretsMKIVResearchCost".Translate(), ref Settings.ResearchCost_GunTurretMKIV, ref bufferResearchCost_MoreTurretsMKIV, 0, MAX_RESEARCH_COST);
            #endregion

            ls.GapLine();

            #region Sandbags
            ls.Label("MS_Sandbags".Translate());
            ls.Gap(2);

            string bufferSandbagsMKII_HP = Helper.RoundToNearestMultiple(Settings.SandbagMKII_MaxHP, 5).ToString();
            ls.TextFieldNumericLabeled<int>("MS_SandbagsMKII".Translate() + "MS_Sandbags_MaxHP".Translate(), ref Settings.SandbagMKII_MaxHP, ref bufferSandbagsMKII_HP, MIN_SANDBAG_HP, MAX_SANDBAG_HP);
            
            string bufferSandbagsMKIII_HP = Helper.RoundToNearestMultiple(Settings.SandbagMKIII_MaxHP, 5).ToString();
            ls.TextFieldNumericLabeled<int>("MS_SandbagsMKIII".Translate() + "MS_Sandbags_MaxHP".Translate(), ref Settings.SandbagMKIII_MaxHP, ref bufferSandbagsMKIII_HP, MIN_SANDBAG_HP, MAX_SANDBAG_HP);
            #endregion

            // Turrets
            MS_Settings.Settings.AllTurretSettings.ForEach(s => s.DoSettingsWindowContents(ls));

            /// Note
            ls.GapLine();
            ls.Label("MS_NeedRebuild".Translate());

            MS_OnDefsLoaded.ApplySettingsToDefs();

            ls.EndScrollView(ref ViewRect);
            base.DoSettingsWindowContents(inRect);
        }

        /// <summary>
        /// This is the name as how it'll appear ain the game's settings menu.
        /// </summary>
        public override string SettingsCategory()
        {
            return "MS_SettingsCategory".Translate();
        }
    }
}
