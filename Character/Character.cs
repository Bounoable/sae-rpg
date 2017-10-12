using System;
using RPG.Map;
using RPG.Item;

namespace RPG.Character {
    abstract class Character: IDrawable
    {
        public enum Direction {
            Up,
            Down,
            Left,
            Right
        }

        public Vector2D Position { get; protected set; }
        public Direction Facing { get; protected set; } = Direction.Down;
        public Inventory Inventory { get; protected set; } = new Inventory();

        public Character(Vector2D position)
        {
            this.Position = position;
        }

        public Vector2D[] GetMapPositions() => new Vector2D[1] { Position };

        abstract public char GetMapCharacter(Vector2D Position);

        abstract public ConsoleColor GetMapCharacterColor(Vector2D position);
    }
}
