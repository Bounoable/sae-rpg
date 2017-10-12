using System;
using RPG.Item;

namespace RPG.Map {
    class MapDrawer
    {
        protected Map map;
        protected IDrawable[] characters;
        protected IDrawable[] npcs;
        protected IDrawable[] obstacles;
        protected IDrawable[] stores;

        public MapDrawer(Map map, IDrawable[] characters, IDrawable[] npcs, IDrawable[] obstacles, IDrawable[] stores)
        {
            this.map = map;
            this.characters = characters;
            this.npcs = npcs;
            this.obstacles = obstacles;
            this.stores = stores;
        }

        public void Draw()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Clear();

            Console.Write(" ");
            for (int x = 0; x <= map.Width; ++x) {
                Console.Write("ࡷ ");
            }
            Console.Write("\n");

            for (int y = 0; y < map.Height; ++y) {
                DrawRow(y);
            }

            Console.Write(" ");
            for (int x = 0; x <= map.Width; ++x) {
                Console.Write("ࡷ ");
            }
            Console.Write("\n");
        }

        protected void DrawRow(int y)
        {
            Console.Write("ࡷ ");

            for (int x = 0; x < map.Width; ++x) {
                DrawPosition(new Vector2D(x, y));
            }

            Console.Write('ࡷ');

            Console.Write("\n");
        }

        protected void DrawPosition(Vector2D position)
        {
            try {
                DrawObject(GetObjectAt(position), position);
                return;
            } catch (Exception) {}

            Console.Write("  ");
        }

        protected IDrawable GetObjectAt(Vector2D position)
        {
            foreach (IDrawable character in characters) {
                if (Array.FindAll(character.GetMapPositions(), charPos => charPos.IsSameAs(position)).Length > 0) {
                    return character;
                }
            }

            foreach (IDrawable npc in npcs) {
                if (Array.FindAll(npc.GetMapPositions(), npcPos => npcPos.IsSameAs(position)).Length > 0) {
                    return npc;
                }
            }

            foreach (IDrawable obstacle in obstacles) {
                if (Array.FindAll(obstacle.GetMapPositions(), obstaclePos => obstaclePos.IsSameAs(position)).Length > 0) {
                    return obstacle;
                }
            }

            foreach (IDrawable store in stores) {
                if (Array.FindAll(store.GetMapPositions(), storePos => storePos.IsSameAs(position)).Length > 0) {
                    return store;
                }
            }

            throw new Exception("No object at this position.");
        }

        protected void DrawObject(IDrawable drawable, Vector2D position)
        {
            Console.ForegroundColor = drawable.GetMapCharacterColor(position);
            Console.Write($"{drawable.GetMapCharacter(position)} ");
            Console.ResetColor();
        }

        protected IDrawable GetObstacleAt(Vector2D position)
        {
            foreach (IDrawable obstacle in obstacles) {
                if (Array.FindAll(obstacle.GetMapPositions(), obstaclePos => obstaclePos.IsSameAs(position)).Length > 0) {
                    return obstacle;
                }
            }

            throw new Exception("No obstacle at this position.");
        }
    }
}
