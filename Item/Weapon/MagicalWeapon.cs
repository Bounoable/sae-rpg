namespace RPG.Item.Weapon {
    abstract class MagicalWeapon: Weapon, IMagical
    {
        protected int damage;

        public int GetMagicalDamage() => this.damage;
    }
}