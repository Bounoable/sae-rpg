using System;
using System.Collections.Generic;

namespace RPG.Map {
    class Tree: Obstacle
    {
        public Tree(Vector2D position): base(position)
        {}

        protected override void Generate()
        {
            Vector2D top = new Vector2D(topLeftPosition.X, topLeftPosition.Y);
            Vector2D bottom;

            switch (randomizer.Next(0, 2)) {
                case 0:
                    bottom = new Vector2D(top.X, top.Y + 1);
                    break;
                case 1:
                default:
                    bottom = new Vector2D(top.X + 1, top.Y);
                    break;
            }

            characters.Add(top, 'ਓ');
            characters.Add(bottom, 'ਓ');
        }

        public override ConsoleColor GetMapCharacterColor(Vector2D position) => ConsoleColor.Green;
    }
}