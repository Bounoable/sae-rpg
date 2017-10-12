using System;

namespace RPG.Character {
    class NPC: Character
    {
        public NPC(Vector2D position): base(position)
        {}

        public override char GetMapCharacter(Vector2D Position) => 'Ф';

        public override ConsoleColor GetMapCharacterColor(Vector2D position) => ConsoleColor.Red;
    }
}