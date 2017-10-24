using System;

namespace RPG.Character {
    abstract class Player: Character
    {
        protected static Random randomizer = new Random();

        protected ConsoleColor color;

        public Player(string name, Vector2D position): base(name, position)
        {
            this.SetColor();
        }

        protected void SetColor()
        {
            Array colors = Enum.GetValues(typeof(ConsoleColor));
            color = (ConsoleColor) colors.GetValue(randomizer.Next(0, colors.Length));
        }

        public override char GetMapCharacter(Vector2D position) => '@';

        public override ConsoleColor GetMapCharacterColor(Vector2D position) => ConsoleColor.Green;
    }
}