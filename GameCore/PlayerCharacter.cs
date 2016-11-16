using System;
using System.Collections.Generic;
using System.Linq;

namespace GameCore
{
    public class PlayerCharacter
    {
        public int Health { get; private set; } = 100;

        public bool IsDead { get; private set; }

        public int DamageResistence { get; set; }

        public int MagicalPower
        {
            get { return MagicalItems.Sum(x => x.Power); }
        }

        public List<MagicalItem> MagicalItems { get; set; } = new List<MagicalItem>();

        public List<Weapon> Weapons { get; set; } = new List<Weapon>();

        public int WeaponsValue
        {
            get { return Weapons.Sum(x => x.Value); }
        }

        public CharacterClass CharacterClass { get; set; }

        public string Race { get; set; }

        public DateTime LastSleepTime { get; set; }

        public void Hit(int damage) {
            var raceSpecificDamageResistance = 0;

            if (Race == "Elf") {
                raceSpecificDamageResistance = 20;
            }

            var totalDamageTaken =
                Math.Max(damage - raceSpecificDamageResistance - DamageResistence, 0);

            Health -= totalDamageTaken;

            if (Health <= 0) {
                IsDead = true;
            }
        }

        public void CastHealingSpell() {
            if (this.CharacterClass == CharacterClass.Healer) {
                this.Health = 100;
            }
        }

        public void UseMagicalItem( string magicalItemType  ) {

            //UseMagicalItem("Amulet")
            //if (this.CharacterClass == CharacterClass.Healer) {
            //    this.Health = 100;
            //}
        }


    }
}