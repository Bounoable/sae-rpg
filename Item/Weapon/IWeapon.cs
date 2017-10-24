namespace RPG.Item.Weapon {
    interface IWeapon
    {
        int Durability { get; }
        Weapon.Rarity RarityType { get; }
    }
}