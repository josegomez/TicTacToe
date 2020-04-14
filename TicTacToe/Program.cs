using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static string currentPlayer = "X";
        static void Main(string[] args)
        {
            string[,] tickTacToeBoard= new string[3,3];
            ResetBoard(tickTacToeBoard);
            PrintBoard(tickTacToeBoard);
            
            while(true)
            {
                Console.Write($"Player {currentPlayer} Enter Position to Play (1-9):");
                string enteredPosition = Console.ReadLine();
            }

        }

        private static void ResetBoard(string[,] tickTacToeBoard)
        {
            int ct = 1;
            for (int i = 0; i < 3; i ++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tickTacToeBoard[i, j] = (ct++).ToString();   
                }
            }
        }

        public static void PrintBoard(string[,] tickTacToeBoard)
        {

            Console.WriteLine($"-----------------CURRENT BOARD STATE-----------------{Environment.NewLine}");
            Console.WriteLine("\t\t     |     |      ");

            Console.WriteLine($"\t\t  {tickTacToeBoard[0, 0]}  |  {tickTacToeBoard[0, 1]}  |  {tickTacToeBoard[0, 2]}");

            Console.WriteLine("\t\t_____|_____|_____ ");

            Console.WriteLine("\t\t     |     |      ");

            Console.WriteLine($"\t\t  {tickTacToeBoard[1, 0]}  |  {tickTacToeBoard[1, 1]}  |  {tickTacToeBoard[1, 2]}");

            Console.WriteLine("\t\t_____|_____|_____ ");

            Console.WriteLine("\t\t     |     |      ");

            Console.WriteLine($"\t\t  {tickTacToeBoard[2, 0]}  |  {tickTacToeBoard[2, 1]}  |  {tickTacToeBoard[2, 2]}");

            Console.WriteLine("\t\t     |     |      ");
        }
    }
}
