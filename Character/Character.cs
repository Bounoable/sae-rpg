using System;
using RPG.Map;
using RPG.Item;

namespace RPG.Character {
    abstract class Character: IDrawable, IMovable
    {
        public enum Direction {
            Up,
            Down,
            Left,
            Right
        }

        public string Name { get; protected set; }

        protected Vector2D position;
        protected Direction facing = Direction.Down;
        protected Inventory inventory = new Inventory();

        public Character(string name, Vector2D position)
        {
            this.Name = name;
            this.position = position;
        }

        public bool IsAtPosition(Vector2D position) => this.position.IsSameAs(position);

        public Vector2D[] GetMapPositions() => new Vector2D[1] { position };

        abstract public char GetMapCharacter(Vector2D Position);

        abstract public ConsoleColor GetMapCharacterColor(Vector2D position);
    }
}
