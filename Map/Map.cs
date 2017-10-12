namespace RPG.Map {
    class Map
    {
        public int Width { get; protected set; }
        public int Height { get; protected set; }

        public Map(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }
    }
}