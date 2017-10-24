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
        protected int level = 1;

        public Character(string name, Vector2D position)
        {
            this.Name = name;
            this.position = position;
        }

        public bool Move(Direction direction, Level level)
        {
            int x = position.X;
            int y = position.Y;

            switch (direction) {
                case Direction.Up:
                    y -= 1;
                    break;
                case Direction.Down:
                    y += 1;
                    break;
                case Direction.Left:
                    x -= 1;
                    break;
                case Direction.Right:
                default:
                    x += 1;
                    break;
            }

            var toPosition = new Vector2D(x, y);

            if (level.ObjectIsAt(toPosition)) {
                return false;
            }

            position = toPosition;
            return true;
        }

        public bool IsAtPosition(Vector2D position) => this.position.IsSameAs(position);

        public Vector2D[] GetMapPositions() => new Vector2D[1] { position };

        abstract public char GetMapCharacter(Vector2D Position);

        abstract public ConsoleColor GetMapCharacterColor(Vector2D position);
    }
}
