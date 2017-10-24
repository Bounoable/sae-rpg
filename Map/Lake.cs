using System;

namespace RPG.Map {
    class Lake: Obstacle
    {
        public Lake(Vector2D position): base(position)
        {}

        protected override void Generate()
        {
            Vector2D left = topLeftPosition;
            Vector2D middle;
            Vector2D right;

            switch (randomizer.Next(0, 2)) {
                case 0:
                    middle = new Vector2D(left.X + 1, left.Y);
                    right = new Vector2D(middle.X + 1, middle.Y);
                    break;
                case 1:
                default:
                    middle = new Vector2D(left.X, left.Y + 1);
                    right = new Vector2D(middle.X, middle.Y + 1);
                    break;
            }

            characters.Add(left, '~');
            characters.Add(middle, '~');
            characters.Add(right, '~');
        }

        public override ConsoleColor GetMapCharacterColor(Vector2D position) => ConsoleColor.Blue;
    }
}