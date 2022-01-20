using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game;
namespace TryMe
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the game Select a board size");
            Console.WriteLine("Select the number of rows"  );
            int rows = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Select the number of columns");
            int columns = Int32.Parse(Console.ReadLine());           
            BombGame bGame = new BombGame(rows, columns);
            bGame.Play();
        }
    }
}
