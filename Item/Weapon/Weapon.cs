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
        public Rarity RarityType { get; protected set; }
    }
}
