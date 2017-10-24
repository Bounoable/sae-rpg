using System;
using RPG.Map;
using RPG.Item.Armor;
using RPG.Item.Weapon;
using System.Collections.Generic;

namespace RPG.Item {
    class Store: IDrawable
    {
        protected Vector2D position;
        protected List<IConsumable> consumables = new List<IConsumable>();
        protected List<IWeapon> weapons = new List<IWeapon>();
        protected List<IArmor> armors = new List<IArmor>();

        public Store(Vector2D position)
        {
            this.position = position;
            this.GenerateItems();
        }

        protected void GenerateItems()
        {
            // 
        }

        public bool IsAtPosition(Vector2D position) => this.position.IsSameAs(position);

        public Vector2D[] GetMapPositions() => new Vector2D[1] { position };
        
        public char GetMapCharacter(Vector2D position) => '$';

        public ConsoleColor GetMapCharacterColor(Vector2D position) => ConsoleColor.Yellow;
    }
}