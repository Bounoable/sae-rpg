using System;
using RPG.Character;
using System.Collections.Generic;

namespace RPG.Map {
    class LevelGenerator
    {
        protected static Random randomizer = new Random();
        protected int width = 30;
        protected int height = 10;

        protected List<IDrawable> generatedObstacles = new List<IDrawable>();

        public LevelGenerator()
        {
            // 
        }

        public LevelGenerator MapWidth(int width)
        {
            this.width = width;
            return this;
        }

        public LevelGenerator MapHeight(int height)
        {
            this.height = height;
            return this;
        }

        public Map GenerateMap()
        {
            return new Map(width, height);
        }

        public IDrawable[] GenerateObstacles()
        {
            var obstacles = new List<IDrawable>();
            var count = randomizer.Next(15, 21);

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

            this.generatedObstacles = obstacles;

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
                if (Array.FindAll(drawable.GetMapPositions(), position => {
                    return Array.FindAll(generated.GetMapPositions(), genPos => genPos.IsSameAs(position)).Length > 0;
                }).Length > 0) return true;
            }

            return false;
        }

        public IDrawable[] GenerateNPCs()
        {
            var npcs = new List<IDrawable>();
            var count = randomizer.Next(3, 7);

            for (var i = 0; i < count; ++i) {
                npcs.Add(GenerateNPC());
            }

            return npcs.ToArray();
        }

        protected IDrawable GenerateNPC()
        {
            NPC npc = null;

            while (npc == null) {
                npc = new NPC(GetRandomPosition());

                if (ObjectOverlapsWith(generatedObstacles.ToArray(), npc)) npc = null;
            }

            return npc;
        }
    }
}
