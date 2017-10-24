namespace RPG.Item.Armor {
    class Armor: Item, IArmor
    {
        protected int physicalDefense;
        protected int magicDefense;

        public Armor(string name, int physical, int magic)
        {
            this.Name = name;
            this.physicalDefense = physical;
            this.magicDefense = magic;
        }

        public int GetPhysicalDefense() => this.physicalDefense;

        public int GetMagicDefense() => this.magicDefense;
    }
}