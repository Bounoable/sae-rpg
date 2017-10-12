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
            Vector2D bottom = new Vector2D(top.X, top.Y + 1);

            characters.Add(top, 'ਓ');
            characters.Add(bottom, 'ਓ');
        }

        public override ConsoleColor GetMapCharacterColor(Vector2D position) => ConsoleColor.Green;
    }
}