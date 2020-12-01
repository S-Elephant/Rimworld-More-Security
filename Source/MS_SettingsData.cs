using System.Collections.Generic;
using Verse;

namespace SquirtingElephant.MoreSecurity
{
    public class MS_SettingsData : ModSettings
    {
        public int ResearchCost_TrapsMKII = 1250;
        public int ResearchCost_GunTurretMKII = 1250;
        public int ResearchCost_GunTurretMKIII = 6000;
        public int ResearchCost_GunTurretMKIV = 22000;

        public int SandbagMKII_MaxHP = 675;
        public int SandbagMKIII_MaxHP = 1000;

        private TurretSettings ShotgunTurretSettings = new TurretSettings
        {
            TranslationKey = "MS_ShotgunTurret",
            DefName = "SE_ShotgunTurret",
            BulletDefName = "Bullet_SE_ShotgunTurret",
            MaxHp = 425,
            Beauty = -5,
            StoppingPower = 3.0f,
            BulletSpeed = 65,
            BurstCooldown = 2.5f,
            CostSteel = 225,
            CostComponent = 3
        };

        private TurretSettings FlameThrowerTurretSettings = new TurretSettings
        {
            TranslationKey = "MS_FlamethrowerTurret",
            DefName = "SE_Turret_FlamethrowerTurret",
            BulletDefName = "SE_Bullet_Flamethrower",
            MaxHp = 425,
            Beauty = -5,
            StoppingPower = 3.0f,
            BulletSpeed = 65,
            BurstCooldown = 2.5f,
            CostSteel = 225,
            CostComponent = 3
        };

        private TurretSettings HitechUraniumTurretSettings = new TurretSettings
        {
            TranslationKey = "MS_HitechUraniumTurret",
            DefName = "Turret_SniperMKII",
            BulletDefName = "Bullet_TurretSniperMKII",
            MaxHp = 825,
            Beauty = -2,
            StoppingPower = 6.0f,
            BulletSpeed = 165,
            BurstCooldown = 5.0f,
            CostSteel = 975,
            CostComponent = 12
        };

        private TurretSettings UltraUraniumTurretSettings = new TurretSettings
        {
            TranslationKey = "MS_UltraUraniumTurret",
            DefName = "Turret_SniperMKIII",
            BulletDefName = "Bullet_TurretSniperMKIII",
            MaxHp = 1550,
            Beauty = -2,
            StoppingPower = 12.0f,
            BulletSpeed = 160,
            BurstCooldown = 2.0f,
            CostSteel = 3550,
            CostComponent = 0
        };

        private TurretSettings HitechMinigunTurretMKISettings = new TurretSettings
        {
            TranslationKey = "MS_HitechMinigunTurretMKI",
            DefName = "HT_MinigunTurret",
            BulletDefName = "HT_MinigunTurret_Bullet",
            MaxHp = 1100,
            Beauty = -2,
            StoppingPower = 0.0f,
            BulletSpeed = 130,
            BurstCooldown = 2.0f,
            CostSteel = 600,
            CostComponent = 10
        };

        private TurretSettings HitechMinigunTurretMKIISettings = new TurretSettings
        {
            TranslationKey = "MS_HitechMinigunTurretMKII",
            DefName = "HT_MinigunTurretMKII",
            BulletDefName = "HT_MinigunTurret_BulletMKII",
            MaxHp = 1600,
            Beauty = -2,
            StoppingPower = 1.0f,
            BulletSpeed = 130,
            BurstCooldown = 2.0f,
            CostSteel = 1200,
            CostComponent = 15
        };

        private List<TurretSettings> _AllTurretSettings;

        public List<TurretSettings> AllTurretSettings
        {
            get => _AllTurretSettings ?? new List<TurretSettings> { ShotgunTurretSettings, FlameThrowerTurretSettings, HitechUraniumTurretSettings, UltraUraniumTurretSettings, HitechMinigunTurretMKISettings, HitechMinigunTurretMKIISettings };
            set => _AllTurretSettings = value;
        }

        public override void ExposeData()
        {
            // Research
            Scribe_Values.Look(ref ResearchCost_TrapsMKII, "ResearchCost_TrapsMKII", 1250);
            Scribe_Values.Look(ref ResearchCost_GunTurretMKII, "ResearchCost_GunTurretMKII", 1250);
            Scribe_Values.Look(ref ResearchCost_GunTurretMKIII, "ResearchCost_GunTurretMKIII", 6000);
            Scribe_Values.Look(ref ResearchCost_GunTurretMKIV, "ResearchCost_GunTurretMKIV", 22000);

            // Sandbags
            Scribe_Values.Look(ref SandbagMKII_MaxHP, "SandbagMKII_MaxHP", 675);
            Scribe_Values.Look(ref SandbagMKIII_MaxHP, "SandbagMKIII_MaxHP", 1000);
            
            // Turrets
            AllTurretSettings.ForEach(s => s.ExposeData());

            base.ExposeData();
        }
    }
}
