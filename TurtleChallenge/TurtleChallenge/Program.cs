using System;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace TurtleChallenge
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("game-settings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("moves.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();
            var gameSettings = configuration.Get<GameSettings>();
            var moves = configuration.GetSection("sequences").GetChildren().Select(sequence => sequence.Value).ToArray();

            var turtle = new Turtle(gameSettings);

            for (int i = 0; i < moves.Length; i++)
            {
                var sequenceNumber = i;
                var move = moves[i];
                if (move.Equals("rotate", StringComparison.InvariantCultureIgnoreCase))
                {
                    turtle.Rotate();
                    continue;
                }

               turtle.Move();
               CheckTurtleStatus(sequenceNumber, gameSettings.Board, turtle.Coordinate);
            }
        }

        public static void CheckTurtleStatus(int sequenceNumber, BoardSettings settings, Coordinate turtleCoordinates)
        {
            if (settings.Mines.Any(mine => mine.X == turtleCoordinates.X && mine.Y == turtleCoordinates.Y))
            {
                Console.WriteLine("Sequence " +sequenceNumber + ": " + "Mine hit!");
                return;
            }
            if (turtleCoordinates.X == settings.Exit.X && turtleCoordinates.Y == settings.Exit.Y)
            {
                Console.WriteLine("Sequence " +sequenceNumber + ": " + "Success!");
                return;
            }

            Console.WriteLine("Sequence " +sequenceNumber + ": " + "Still in danger!");
           
        }
    }
}   