namespace RPG {
    class Vector2D
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector2D(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public bool IsSameAs(Vector2D position) {
            return position.X == X && position.Y == Y;
        }
    }
}