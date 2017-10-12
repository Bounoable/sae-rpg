using System;
using RPG.Map;
using RPG.Item;
using RPG.Character;

namespace RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            var level = new LevelGenerator();

            var map = level.MapWidth(40).MapHeight(15).GenerateMap();
            var obstacles = level.GenerateObstacles();
            var npcs = level.GenerateNPCs();

            NPC npc1 = new NPC(new Vector2D(15, 9));

            IDrawable[] characters = new IDrawable[0];

            Store store1 = new Store(new Vector2D(20, 8));

            Store[] stores = new Store[1] { store1 };

            MapDrawer mapDrawer = new MapDrawer(map, characters, npcs, obstacles, stores);

            mapDrawer.Draw();
        }
    }
}
