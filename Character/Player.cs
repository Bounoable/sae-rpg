using System;

namespace RPG.Character {
    abstract class Player: Character
    {
        protected static Random randomizer = new Random();

        protected ConsoleColor color;
        protected int experience;
        protected int maxExperience;

        public Player(string name, Vector2D position): base(name, position)
        {
            this.experience = 0;
            this.maxExperience = 10;
            this.SetColor();
        }

        protected void SetColor()
        {
            Array colors = Enum.GetValues(typeof(ConsoleColor));
            color = (ConsoleColor) colors.GetValue(randomizer.Next(0, colors.Length));
        }

        public void GiveExperience(int exp)
        {
            experience += exp;
            
            if (experience > maxExperience) {
                LevelUp();
            }
        }

        protected void LevelUp()
        {
            level++;
            experience = experience - maxExperience;
            maxExperience = (int)Math.Round(maxExperience * (float)randomizer.Next(135, 176) / 100);
        }

        public override char GetMapCharacter(Vector2D position) => '@';

        public override ConsoleColor GetMapCharacterColor(Vector2D position) => ConsoleColor.Green;
    }
}