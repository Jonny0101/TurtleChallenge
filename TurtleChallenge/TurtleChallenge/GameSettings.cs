namespace TurtleChallenge
{
    public sealed class GameSettings
    {
        public BoardSettings Board { get; set; }
        public TurtleSettings Turtle { get; set; }
    }

    public sealed class BoardSettings
    {
        public Coordinate[] Mines { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public Coordinate Exit { get; set; }
    }

    public sealed class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public sealed class TurtleSettings
    {
        public Coordinate Start { get; set; }
        public Directions Direction { get; set; }
    }
}