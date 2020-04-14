using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        //Holds the currentPlayer change this to Y and back for every turn
        static string currentPlayer = "X";
        static void Main(string[] args)
        {
            //Declares a 3x3 array for the board. 
            //Any given position in the board can be accessed by the x,y coordiantes IE: tickTacToeBoard[1,2]
            string[,] tickTacToeBoard= new string[3,3];

            ResetBoard(tickTacToeBoard);
            PrintBoard(tickTacToeBoard);
            
            //Game Loop
            while(!CheckWinner(tickTacToeBoard))
            {
                Console.Write($"Player {currentPlayer} Enter Position to Play (1-9):");
                string enteredPosition = Console.ReadLine(); // Check the user entered 1-9 and if that space is avaialble then set it to X or Y then check if someone won...
            }

        }

        private static bool CheckWinner(string[,] tickTacToeBoard)
        {
            //TODO: Implement Logic check to see if someone won.
            return false;
        }

        /// <summary>
        /// Resets the board up, placing a sequential number on each box to allow the players to play
        /// </summary>
        /// <param name="tickTacToeBoard"></param>
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

        /// <summary>
        /// Prints the Game Board
        /// </summary>
        /// <param name="tickTacToeBoard"></param>
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
