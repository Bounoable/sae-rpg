using RPG.Item.Armor;
using RPG.Item.Weapon;
using System.Collections.Generic;

namespace RPG.Item {
    class Inventory
    {
        public List<IConsumable> Consumables { get; protected set; } = new List<IConsumable>();
        public List<IWeapon> Weapons { get; protected set; } = new List<IWeapon>();
        public List<IArmor> Armors { get; protected set; } = new List<IArmor>();

        public void AddConsumable(IConsumable item)
        {
            this.Consumables.Add(item);
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.Weapons.Add(weapon);
        }

        public void AddArmor(IArmor armor)
        {
            this.Armors.Add(armor);
        }
    }
}
