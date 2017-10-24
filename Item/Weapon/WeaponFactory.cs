using System;

namespace RPG.Item.Weapon {
    class WeaponFactory
    {
        protected static Random randomizer = new Random();
        protected static string[] names = new string[12] {
            "Reforged Defender",
            "Blood Infuser",
            "Wind's Carver",
            "Lightbringer",
            "Rigormortis",
            "Brutality",
            "Loyalty",
            "Orenmir",
            "Needle",
            "Prick",
            "Chaos",
            "Wolf",
        };

        public WeaponFactory()
        {
            // 
        }

        public IWeapon[] Generate(int quantity)
        {
            var weapons = new IWeapon[quantity];

            for (var i = 0; i < quantity; ++i) {
                switch (randomizer.Next(0, 1)) {
                    case 0:
                        weapons[i] = GenerateSword();
                        break;
                    default:
                        break;
                }
            }

            return weapons;
        }

        public Sword GenerateSword()
        {
            Weapon.Rarity rarity = RandomRarity();

            return new Sword($"{Enum.GetName(typeof(Weapon.Rarity), rarity)} {RandomName("Sword")}", 100, 15, rarity);
        }

        protected Weapon.Rarity RandomRarity()
        {
            Array rarities = Enum.GetValues(typeof(Weapon.Rarity));
            return (Weapon.Rarity) rarities.GetValue(randomizer.Next(0, rarities.Length));
        }

        protected string RandomName(string suffix = "")
        {
            return $"{names[randomizer.Next(0, names.Length)]} {suffix}".Trim();
        }
    }
}