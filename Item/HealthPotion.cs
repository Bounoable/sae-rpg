namespace RPG.Item {
    class HealthPotion: Item, IConsumable
    {
        protected int health;

        public HealthPotion(string name, int health)
        {
            this.Name = name;
            this.health = health;
        }

        public int GetHealth()
        {
            return this.health;
        }

        public int GetPower()
        {
            return 0;
        }
    }
}
