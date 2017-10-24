using RPG.Character;

namespace RPG.Map {
    interface IMovable
    {
        Vector2D Move(Character.Character.Direction direction, Level level);
    }
}
