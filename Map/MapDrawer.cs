using System;

namespace RPG.Map {
    class MapDrawer
    {
        protected Map map;
        protected IDrawable[] characters;

        public MapDrawer(Map map, IDrawable[] characters)
        {
            this.map = map;
            this.characters = characters;
        }

        public void Draw()
        {
            Console.Clear();

            for (int y = 0; y < map.Height; ++y) {
                DrawRow(y);
            }
        }

        protected void DrawRow(int y)
        {
            for (int x = 0; x < map.Width; ++x) {
                DrawPosition(new Vector2D(x, y));
            }

            Console.Write("\n");
        }

        protected void DrawPosition(Vector2D position)
        {
            if (AnyCharacterIsAt(position)) {
                DrawCharacter(GetFirstCharacterAt(position));
                return;
            }

            Console.Write("X ");
        }

        protected bool AnyCharacterIsAt(Vector2D position)
        {
            return GetCharactersAt(position).Length > 0;
        }

        protected bool CharacterIsAt(Vector2D position, IDrawable character)
        {
            return position.X == character.Position.X && position.Y == character.Position.Y;
        }

        protected IDrawable[] GetCharactersAt(Vector2D position)
        {
            return Array.FindAll(characters, character => CharacterIsAt(position, character));
        }

        protected void DrawCharacter(IDrawable character)
        {
            Console.ForegroundColor = character.GetMapCharacterColor(character.Position);
            Console.Write($"{character.GetMapCharacter(character.Position)} ");
            Console.ResetColor();
        }

        protected IDrawable GetFirstCharacterAt(Vector2D position)
        {
            IDrawable[] characters = GetCharactersAt(position);

            if (characters.Length == 0) {
                throw new Exception($"Kein Charakter an der Position ({position.X}, {position.Y})");
            }

            return characters[0];
        }
    }
}
