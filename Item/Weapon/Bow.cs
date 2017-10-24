namespace RPG.Item.Weapon {
    class Bow: PhysicalWeapon, IRanged
    {
        protected int range;

        public Bow(string name, int damage, int durability, int range, Rarity type)
        {
            this.Name = name;
            this.Durability = durability;
            this.Type = type;
            this.damage = damage;
            this.range = range;
        }

        public int GetRange() => range;
    }
}