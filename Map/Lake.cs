using System;

namespace RPG.Map {
    class Lake: Obstacle
    {
        public Lake(Vector2D position): base(position)
        {}

        protected override void Generate()
        {
            Vector2D left = topLeftPosition;
            Vector2D middle = new Vector2D(left.X + 1, left.Y);
            Vector2D right = new Vector2D(middle.X + 1, middle.Y);

            characters.Add(left, '~');
            characters.Add(middle, '~');
            characters.Add(right, '~');
        }

        public override ConsoleColor GetMapCharacterColor(Vector2D position) => ConsoleColor.Blue;
    }
}