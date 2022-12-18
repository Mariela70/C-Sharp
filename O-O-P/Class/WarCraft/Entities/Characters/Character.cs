using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.Bag = bag;
        }

        // TODO: Implement the rest of the class.
        public string Name { get => name; set => name = value; }
        public int BaseHealth { get => baseHealth; set => baseHealth = value; }
        public int Health { get => health; set => health = value; }
        public int BaseArmor { get => baseArmor; set => baseArmor = value; }
        public int Armor { get => armor; set => armor = value; }
        public int AbilityPoints { get => abilityPoints; set => abilityPoints = value; }
        public IBag bag { get; set; }

        public bool IsAlive { get; set; } = true;

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}