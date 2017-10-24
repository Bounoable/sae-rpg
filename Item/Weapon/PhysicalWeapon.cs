namespace RPG.Item.Weapon {
    abstract class PhyiscalWeapon: Weapon, IPhysical
    {
        protected int damage;

        public int GetPhysicalDamage() => this.damage;
    }
}