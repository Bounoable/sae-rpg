using System;
using RPG.Map;

namespace RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Character player1 = new Character();
            Character player2 = new Character();

            IDrawable[] characters = new IDrawable[2] { player1, player2 };

            Map.Map map = new Map.Map(40, 10);
            Map.MapDrawer mapDrawer = new Map.MapDrawer(map, characters);

            mapDrawer.Draw();
        }
    }
}
