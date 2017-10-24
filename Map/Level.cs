using System.Collections.Generic;

namespace RPG.Map {
    class Level
    {
        protected int level;
        protected Map map;
        protected List<IDrawable> characters = new List<IDrawable>();
        protected List<IDrawable> npcs = new List<IDrawable>();
        protected List<IDrawable> obstacles = new List<IDrawable>();
        protected List<IDrawable> stores = new List<IDrawable>();

        public Level(int level, Map map, IDrawable[] characters, IDrawable[] npcs, IDrawable[] obstacles, IDrawable[] stores)
        {
            this.level = level;
            this.map = map;
            this.characters.AddRange(characters);
            this.npcs.AddRange(npcs);
            this.obstacles.AddRange(obstacles);
            this.stores.AddRange(stores);
        }

        public void DrawMap()
        {
            var map = new MapDrawer(this.map, characters.ToArray(), npcs.ToArray(), obstacles.ToArray(), stores.ToArray());

            map.Draw();
        }

        public bool ObjectIsAt(Vector2D position)
        {
            foreach (IDrawable character in characters) {
                if (character.IsAtPosition(position)) {
                    return true;
                }
            }

            foreach (IDrawable npc in npcs) {
                if (npc.IsAtPosition(position)) {
                    return true;
                }
            }

            foreach (IDrawable obstacle in obstacles) {
                if (obstacle.IsAtPosition(position)) {
                    return true;
                }
            }

            foreach (IDrawable store in stores) {
                if (store.IsAtPosition(position)) {
                    return true;
                }
            }

            return false;
        }
    }
}