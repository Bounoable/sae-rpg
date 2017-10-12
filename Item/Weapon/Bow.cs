namespace RPG.Item.Weapon {
    class Bow: Weapon, IRanged
    {
        public int Range { get; protected set; }

        public Bow(string name, int damage, int durability, int range)
        {
            this.Name = name;
            this.Damage = damage;
            this.Durability = durability;
            this.Range = range;
        }
    }
}