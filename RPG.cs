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
            var characters = new IDrawable[0];
            var levelGenerator = new LevelGenerator(40, 15, characters);

            Level level = levelGenerator.GetNext();

            level.DrawMap();
        }
    }
}
