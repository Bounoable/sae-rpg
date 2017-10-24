namespace RPG.Item.Weapon {
    class Bow: Weapon, IRanged
    {
        protected int range;

        public Bow(string name, int damage, int durability, int range)
        {
            this.Name = name;
            this.Damage = damage;
            this.Durability = durability;
            this.range = range;
        }

        public int GetRange() => range;
    }
}