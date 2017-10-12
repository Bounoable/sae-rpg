using System;
using System.Collections.Generic;

namespace RPG.Map {
    abstract class Obstacle: IDrawable
    {
        protected Vector2D topLeftPosition;
        protected Dictionary<Vector2D, char> characters = new Dictionary<Vector2D, char>();

        public Obstacle(Vector2D position)
        {
            this.topLeftPosition = position;
            this.Generate();
        }

        public Vector2D[] GetMapPositions()
        {
            List<Vector2D> positions = new List<Vector2D>();

            foreach (KeyValuePair<Vector2D, char> character in characters) {
                positions.Add(character.Key);
            }

            return positions.ToArray();
        }

        public char GetMapCharacter(Vector2D position)
        {
            foreach (KeyValuePair<Vector2D, char> character in characters) {
                if (character.Key.IsSameAs(position)) {
                    return character.Value;
                }
            }

            throw new Exception("No character defined for this tree at this position.");
        }

        abstract protected void Generate();

        abstract public ConsoleColor GetMapCharacterColor(Vector2D position);
    }
}