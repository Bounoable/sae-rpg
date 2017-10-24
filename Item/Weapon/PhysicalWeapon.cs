namespace RPG.Item.Weapon {
    abstract class PhysicalWeapon: Weapon, IPhysical
    {
        protected int damage;

        public int GetPhysicalDamage() => CalculateDamage(damage);
    }
}