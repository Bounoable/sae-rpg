using System.Collections.Generic;

namespace RPG.Map {
    class Level
    {
        protected int level;
        protected Map map;
        protected IDrawable character;
        protected List<IDrawable> npcs = new List<IDrawable>();
        protected List<IDrawable> obstacles = new List<IDrawable>();
        protected List<IDrawable> stores = new List<IDrawable>();

        public Level(int level, Map map, IDrawable character, IDrawable[] npcs, IDrawable[] obstacles, IDrawable[] stores)
        {
            this.level = level;
            this.map = map;
            this.character = character;
            this.npcs.AddRange(npcs);
            this.obstacles.AddRange(obstacles);
            this.stores.AddRange(stores);
        }

        public void DrawMap()
        {
            var objects = new List<IDrawable>();
            objects.Add(character);
            objects.AddRange(npcs);
            objects.AddRange(obstacles);
            objects.AddRange(stores);

            var map = new MapDrawer(this.map, objects.ToArray());

            map.Draw();
        }

        public bool ObjectIsAt(Vector2D position)
        {
            if (IsOutsideOfMap(position)) return true;
            if (character.IsAtPosition(position)) return true;

            foreach (IDrawable npc in npcs) {
                if (npc.IsAtPosition(position)) return true;
            }

            foreach (IDrawable obstacle in obstacles) {
                if (obstacle.IsAtPosition(position)) return true;
            }

            foreach (IDrawable store in stores) {
                if (store.IsAtPosition(position)) return true;
            }

            return false;
        }

        protected bool IsOutsideOfMap(Vector2D position)
        {
            return position.X < 0 || position.Y < 0 || position.X >= map.Width || position.Y >= map.Height;
        }
    }
}