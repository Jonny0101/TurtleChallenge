
namespace TurtleChallenge
{
    public class Turtle
    {
        private int _xvalue;
        private int _yvalue;
        private Directions _direction;
        private Coordinate[] _mines;

        public Coordinate Coordinate => new Coordinate {X = _xvalue, Y = _yvalue};

        public Turtle(GameSettings settings)
        {
            _direction = settings.Turtle.Direction;
            _xvalue = settings.Turtle.Start.X;
            _yvalue = settings.Turtle.Start.Y;
            _mines = settings.Board.Mines;
        }

        public void Rotate()
        {
            switch (_direction)
            {
                case Directions.North:
                    _direction = Directions.East;
                    break;
                case Directions.East:
                    _direction = Directions.South;
                    break;
                case Directions.South:
                    _direction = Directions.West;
                    break;
                case Directions.West:
                    _direction = Directions.North;
                    break;
            }
        }

        public void Move()
        {
            switch (_direction)
            {
                case Directions.North:
                    _yvalue++;
                    break;

                case Directions.East:
                    _xvalue++;
                    break;

                case Directions.South:
                    _yvalue--;
                    break;

                case Directions.West:
                    _xvalue--;
                    break;
            }
        }
    }
}