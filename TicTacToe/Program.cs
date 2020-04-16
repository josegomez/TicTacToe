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
            string[,] tickTacToeBoard = new string[3, 3];

            ResetBoard(tickTacToeBoard);


            //Game Loop
            while (!CheckWinner(tickTacToeBoard))
            {
                Console.Clear();
                PrintBoard(tickTacToeBoard);
                Console.Write($"Player {currentPlayer} Enter Position to Play (1-9):");
                string enteredPosition = Console.ReadLine();// Check the user entered 1-9 and if that space is avaialble then set it to X or Y then check if someone won...
                int enteredNum;
                bool canConvert = int.TryParse(enteredPosition, out enteredNum);
                if (canConvert == true)
                {
                    if (enteredNum > 0 && enteredNum < 10)
                    {
                        //Print the board after every turn and swap between X and Y player alternating
                        int y = (enteredNum - 1) / 3;
                        int x = (enteredNum - (y * 3)) - 1;
                        if (tickTacToeBoard[y, x] != "X" && tickTacToeBoard[y, x] != "O")
                        {
                            tickTacToeBoard[y, x] = currentPlayer;
                            if (currentPlayer == "X")
                            {
                                currentPlayer = "O";
                            }
                            else if (currentPlayer == "O")
                            {
                                currentPlayer = "X";
                            }
                            //PrintBoard(tickTacToeBoard);
                        }
                    }
                }
            }

        }

        private static bool CheckWinner(string[,] tickTacToeBoard)
        {
            //TODO: Implement Logic check to see if someone won.
            for (int i = 0; i < 3; i++)
            {
                string[] checkarray = new string[3];
                for (int j = 0; j < 3; j++)
                {
                    checkarray[j] = tickTacToeBoard[i, j];
                }
                if (CheckMyArray(checkarray) == true)
                {
                    Console.WriteLine($"{checkarray[0]} is the winner!");
                    Console.ReadLine();
                    return true;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                string[] checkarray = new string[3];
                for (int j = 0; j < 3; j++)
                {
                    checkarray[j] = tickTacToeBoard[j, i];
                }
                if (CheckMyArray(checkarray) == true)
                {
                    Console.WriteLine($"{checkarray[0]} is the winner!");
                    Console.ReadLine();
                    return true;
                }
            }
            string[] crossCheckarray = new string[3];
            crossCheckarray[0] = tickTacToeBoard[0, 0];
            crossCheckarray[1] = tickTacToeBoard[1, 1];
            crossCheckarray[2] = tickTacToeBoard[2, 2];
            if (CheckMyArray(crossCheckarray) == true)
            {
                Console.WriteLine($"{crossCheckarray[0]} is the winner!");
                Console.ReadLine();
                return true;
            }
            crossCheckarray[0] = tickTacToeBoard[0, 2];
            crossCheckarray[1] = tickTacToeBoard[1, 1];
            crossCheckarray[2] = tickTacToeBoard[2, 0];
            if (CheckMyArray(crossCheckarray) == true)
            {
                Console.WriteLine($"{crossCheckarray[0]} is the winner!");
                Console.ReadLine();
                return true;
            }
            return false;
        }


        /// <summary>
        /// Resets the board up, placing a sequential number on each box to allow the players to play
        /// </summary>
        /// <param name="tickTacToeBoard"></param>
        private static void ResetBoard(string[,] tickTacToeBoard)
        {
            int ct = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tickTacToeBoard[i, j] = (ct++).ToString();
                }
            }
        }

        public static bool CheckMyArray(string[] myCheckArray)
        {
            if (myCheckArray[0] == myCheckArray[1])
            {
                if (myCheckArray[1] == myCheckArray[2])
                {
                    return true;
                }
                else return false;
            }
            else return false;
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
