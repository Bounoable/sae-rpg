using System;
using RPG.Map;
using RPG.Item;

namespace RPG {
    class Character: IDrawable
    {
        public enum Direction {
            Up,
            Down,
            Left,
            Right
        }

        public Vector2D Position { get; protected set; } = new Vector2D(0, 0);
        public Direction Facing { get; protected set; } = Direction.Down;
        public Inventory Inventory { get; protected set; } = new Inventory();

        public char GetMapCharacter(Vector2D Position)
        {
            return '@';
        }

        public ConsoleColor GetMapCharacterColor(Vector2D position)
        {
            return ConsoleColor.Green;
        }
    }
}
