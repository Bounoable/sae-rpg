namespace RPG.Item {
    class PowerPotion: Item, IConsumable
    {
        protected int power;

        public PowerPotion(string name, int power)
        {
            this.Name = name;
            this.power = power;
        }

        public int GetHealth()
        {
            return 0;
        }

        public int GetPower()
        {
            return this.power;
        }
    }
}
