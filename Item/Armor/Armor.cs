namespace RPG.Item.Armor {
    class Armor: Item, IArmor
    {
        public int PhysicalDefense { get; protected set; }
        public int MagicDefense { get; protected set; }

        public Armor(string name, int physical, int magic)
        {
            this.Name = name;
            this.PhysicalDefense = physical;
            this.MagicDefense = magic;
        }
    }
}