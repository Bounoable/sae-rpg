using RPG.Character;

namespace RPG.Map {
    interface IMovable
    {
        bool Move(Character.Character.Direction direction, Level level);
    }
}
