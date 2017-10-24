namespace RPG.Item.Weapon {
    abstract class Weapon: Item, IWeapon
    {
        public enum Rarity {
            Common,
            Rare,
            Epic,
            Legendary
        }
        
        public int Durability { get; protected set; }
        public Rarity Type { get; protected set; }

        protected int CalculateDamage(int baseDamage)
        {
            return baseDamage;
        }
    }
}
