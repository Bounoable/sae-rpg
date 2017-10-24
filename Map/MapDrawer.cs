using System;
using RPG.Item;

namespace RPG.Map {
    class MapDrawer
    {
        protected Map map;
        protected IDrawable[] objects;

        public MapDrawer(Map map, IDrawable[] objects)
        {
            this.map = map;
            this.objects = objects;
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

            Console.Write(". ");
        }

        protected IDrawable GetObjectAt(Vector2D position)
        {
            foreach (IDrawable obj in objects) {
                if (obj.IsAtPosition(position)) {
                    return obj;
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
    }
}
