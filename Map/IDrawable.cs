using System;

namespace RPG.Map {
    interface IDrawable
    {
        Vector2D[] GetMapPositions();
        char GetMapCharacter(Vector2D position);
        ConsoleColor GetMapCharacterColor(Vector2D position);
    }
}