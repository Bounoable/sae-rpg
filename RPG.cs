using System;
using RPG.Map;
using RPG.Item;
using RPG.Character;

namespace RPG
{
    class RPG
    {
        static void Main(string[] args)
        {
            var character = new Orc("Saman", new Vector2D(0, 0));

            var levelGenerator = new LevelGenerator(40, 15, character);

            Level level = levelGenerator.GetNext();

            while (true) {
                level.DrawMap();

                ConsoleKey key = Console.ReadKey().Key;

                switch (key) {
                    case ConsoleKey.UpArrow:
                        character.Move(Character.Character.Direction.Up, level);
                        break;
                    case ConsoleKey.DownArrow:
                        character.Move(Character.Character.Direction.Down, level);
                        break;
                    case ConsoleKey.LeftArrow:
                        character.Move(Character.Character.Direction.Left, level);
                        break;
                    case ConsoleKey.RightArrow:
                        character.Move(Character.Character.Direction.Right, level);
                        break;
                    default:
                        continue;
                }
            }
        }
    }
}
