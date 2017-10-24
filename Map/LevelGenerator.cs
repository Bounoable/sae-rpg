using System;
using RPG.Item;
using RPG.Character;
using System.Collections.Generic;

namespace RPG.Map {
    class LevelGenerator
    {
        protected static Random randomizer = new Random();
        protected int width;
        protected int height;
        protected int currentLevel = 1;

        protected List<IDrawable> generatedObjects = new List<IDrawable>();
        protected Character.Character character;

        public LevelGenerator(int mapWidth, int mapHeight, Character.Character character)
        {
            this.width = mapWidth;
            this.height = mapHeight;
            this.character = character;
        }

        public Level GetNext()
        {
            Level level = Generate(currentLevel);
            currentLevel++;

            return level;
        }

        protected Level Generate(int level)
        {
            ClearGenerated();
            return new Level(level, GenerateMap(level), character, GenerateNPCs(), GenerateObstacles(), GenerateStores());
        }

        protected void ClearGenerated() => generatedObjects.Clear();

        protected Map GenerateMap(int level)
        {
            return new Map(width, height, level);
        }

        protected IDrawable[] GenerateObstacles()
        {
            var obstacles = new List<IDrawable>();
            int approx = (int)Math.Round((float)(width * height / 10));
            int count = randomizer.Next(approx - 5, approx + 10);

            for (var i = 0; i < count; ++i) {
                var type = randomizer.Next(0, 2);
                var obstaclesArray = obstacles.ToArray();

                switch (type) {
                    case 0:
                        obstacles.Add(GenerateTree(obstaclesArray));
                        break;
                    case 1:
                        obstacles.Add(GenerateLake(obstaclesArray));
                        break;
                    default:
                        break;
                }
            }

            this.generatedObjects = obstacles;

            return obstacles.ToArray();
        }

        protected IDrawable GenerateTree(IDrawable[] obstacles)
        {
            Tree tree = null;

            while (tree == null) {
                tree = new Tree(GetRandomPosition());

                if (ObjectOverlapsWith(obstacles, tree)) tree = null;
            }

            return tree;
        }

        protected IDrawable GenerateLake(IDrawable[] obstacles)
        {
            Lake lake = null;

            while (lake == null) {
                lake = new Lake(GetRandomPosition());

                if (ObjectOverlapsWith(obstacles, lake)) lake = null;
            }

            return lake;
        }

        protected Vector2D GetRandomPosition()
        {
            return new Vector2D(randomizer.Next(0, width), randomizer.Next(0, height));
        }

        protected bool ObjectOverlapsWith(IDrawable[] drawables, IDrawable generated)
        {
            foreach (IDrawable drawable in drawables) {
                if (Array.FindAll(drawable.GetMapPositions(), generated.IsAtPosition).Length > 0) return true;
            }

            return false;
        }

        public IDrawable[] GenerateNPCs()
        {
            var npcs = new List<IDrawable>();
            var count = randomizer.Next(5, 10);

            for (var i = 0; i < count; ++i) {
                npcs.Add(GenerateNPC());
            }

            return npcs.ToArray();
        }

        protected IDrawable GenerateNPC()
        {
            NPC npc = null;

            while (npc == null) {
                npc = new NPC("", GetRandomPosition());

                if (ObjectOverlapsWith(generatedObjects.ToArray(), npc)) npc = null;
            }

            return npc;
        }

        protected IDrawable[] GenerateStores()
        {
            var stores = new List<IDrawable>();
            var count = randomizer.Next(3, 7);

            for (var i = 0; i < count; ++i) {
                stores.Add(GenerateStore());
            }

            return stores.ToArray();
        }

        protected IDrawable GenerateStore()
        {
            Store store = null;

            while (store == null) {
                store = new Store(GetRandomPosition());

                if (ObjectOverlapsWith(generatedObjects.ToArray(), store)) store = null;
            }

            return store;
        }
    }
}
