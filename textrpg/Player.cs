using System;
using System.Collections.Generic;
namespace TextRpg
{
    class Player
    {
        public PlayerStats baseStats;
        public PlayerStats currentStats;
        public double health;

        public int healthInt => (int)Math.Ceiling(health);
        public double mana;
        public int manaInt => (int)Math.Ceiling(mana);

        public bool inDialog;

        public List<ActiveEffect> effects;

        public ushort[] location;
        public List<ushort[]> locTargets;
        public uint dimension;
        public void InvokeFunction(Functions.Function function)
            => function.Invoke(this);
        public void InvokeFunction(Functions.Function[] functions)
        {
            foreach(Functions.Function function in functions) function.Invoke(this);
        }
        public List<ItemStack> inventory;

        public void PerformTurn()
        {
            List<int> remIndex = new List<int>();
            for (int i = 0; i < effects.Count; i++)
                if (effects[i].Tick(this)) remIndex.Add(i);
            foreach (int i in remIndex)
                effects.RemoveAt(i);

            health = Math.Min(health, currentStats.maxHealth);
        }

        public bool ActivateItem(ItemActivable itemC)
        {
            if (!Item.CanBeActivated(itemC)) return false;
            if (itemC.RemoveOnConsume)
            {
                for(int i = 0; i < inventory.Count; i++)
                {
                    if(inventory[i].itemId == itemC.id)
                    {
                        if (--inventory[i].amount == 0) inventory.RemoveAt(i);
                        break;
                    }
                }
            }
            InvokeFunction(itemC.OnActivate);
            return true;
        }

        public Player()
        {
            baseStats = new();
            currentStats = new();
            health = 100d;
            mana = 0d;
            location = new ushort[] { 0 };
            dimension = 0;
            inventory = new List<ItemStack>();
            inDialog = false;
            effects = new List<ActiveEffect>();
        }
        public Player(ulong playerId)
        {

        }
    }
    class PlayerStats
    {
        public PlayerStats()
        {
            maxHealth = 100;
            maxMana = 0;
            speed = 1;
            resistance = 0;

            inventorySize = 9;

            resistanceGeneric = 0d;
            resistancePiercing = 0d;
            resistanceSlashing = 0d;
            resistanceCrushing = 0d;
            resistanceAcid = 0d;
            resistanceCold = 0d;
            resistanceFire = 0d;
            resistanceForce = 0d;
            resistanceElectrical = 0d;
            resistanceNecrotic = 0d;
            resistancePoison = 0d;
            resistancePsychic = 0d;
            resistanceAudial = 0d;
            resistanceRadiational = 0d;
            resistanceStarving = 0d;
            resistanceThirst = 0d;
            resistanceSuffocating = 0d;
            resistanceBleeding = 0d;
        }

        public double maxHealth;
        public int maxHealthInt => (int)Math.Ceiling(maxHealth);

        public double maxMana;
        public int maxManaInt => (int)Math.Ceiling(maxMana);

        public double speed;
        public int speedInt => (int)Math.Round(speed);

        public double resistance;
        public int resistanceInt => (int)Math.Round(resistance * 100);

        public uint inventorySize;

        #region DamageTypes
        public double resistanceGeneric;
        public int resistanceGenericInt => (int)Math.Round(resistanceGeneric * 100);
        public double resistancePiercing;
        public int resistancePiercingInt => (int)Math.Round(resistancePiercing * 100);
        public double resistanceSlashing;
        public int resistanceSlashingInt => (int)Math.Round(resistanceSlashing * 100);
        public double resistanceCrushing;
        public int resistanceCrushingInt => (int)Math.Round(resistanceCrushing * 100);
        public double resistanceAcid;
        public int resistanceAcidInt => (int)Math.Round(resistanceAcid * 100);
        public double resistanceCold;
        public int resistanceColdInt => (int)Math.Round(resistanceCold * 100);
        public double resistanceFire;
        public int resistanceFireInt => (int)Math.Round(resistanceFire * 100);
        public double resistanceForce;
        public int resistanceForceInt => (int)Math.Round(resistanceForce * 100);
        public double resistanceElectrical;
        public int resistanceElectricalInt => (int)Math.Round(resistanceElectrical * 100);
        public double resistanceNecrotic;
        public int resistanceNecroticInt => (int)Math.Round(resistanceNecrotic * 100);
        public double resistancePoison;
        public int resistancePoisonInt => (int)Math.Round(resistancePoison * 100);
        public double resistancePsychic;
        public int resistancePsychicInt => (int)Math.Round(resistancePsychic * 100);
        public double resistanceAudial;
        public int resistanceAudialInt => (int)Math.Round(resistanceAudial * 100);
        public double resistanceRadiational;
        public int resistanceRadiationalInt => (int)Math.Round(resistanceRadiational * 100);
        public double resistanceStarving;
        public int resistanceStarvingInt => (int)Math.Round(resistanceStarving * 100);
        public double resistanceThirst;
        public int resistanceThirstInt => (int)Math.Round(resistanceThirst * 100);
        public double resistanceSuffocating;
        public int resistanceSuffocatingInt => (int)Math.Round(resistanceSuffocating * 100);
        public double resistanceBleeding;
        public int resistanceBleedingInt => (int)Math.Round(resistanceBleeding * 100);
        public double resistanceIllness;
        public int resistanceIllnessInt => (int)Math.Round(resistanceIllness * 100);
        #endregion
    }
}
