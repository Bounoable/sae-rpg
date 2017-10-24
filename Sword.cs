namespace RPG.Item.Weapon {
    class Sword: PhysicalWeapon, IMelee
    {
        public Sword(string name, int damage, int durability, Rarity type)
        {
            this.Name = name;
            this.damage = damage;
            this.Durability = durability;
            this.Type = type;
        }
    }
}