namespace RPG.Item.Weapon {
    interface IWeapon
    {
        int Damage { get; }
        int Durability { get; }
        Weapon.Rarity RarityType { get; }
    }
}