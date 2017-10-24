namespace RPG.Item.Weapon {
    interface IWeapon
    {
        int Durability { get; }
        Weapon.Rarity Type { get; }
    }
}