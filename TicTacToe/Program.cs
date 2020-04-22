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
        static bool debug = false;
        static void Main(string[] args)
        {

            
            //Declares a 3x3 array for the board. 
            //Any given position in the board can be accessed by the x,y coordiantes IE: tickTacToeBoard[1,2]
            /*
            string[,] tickTacToeBoard = new string[3, 3];

            ResetBoard(tickTacToeBoard);
            

            
            PrintBoard(tickTacToeBoard);
            Console.ReadLine();
            */

            //this section is for testing
            BoardTree allBoards = new BoardTree();
            BoardTree currentBoard = new BoardTree();
            ResetBoard(allBoards.Board);
            ResetBoard(currentBoard.Board);
            AddChildren(allBoards, "X");
            currentPlayer = "X";
            bool humanTurn = true;
            while (currentBoard.endState == false)
            {
                Console.Clear();
                PrintBoard(currentBoard.Board);
                Console.WriteLine($"win: {currentBoard.winner.ToString()} . Endstate {currentBoard.endState.ToString()} Plays: {currentBoard.plays} WinValue: {currentBoard.winValue}");
                //this loop is used to troubleshoot what the next move is
                
                foreach (var nextBoard in currentBoard.Children)
                {
                    Console.WriteLine(nextBoard.winValue.ToString() + nextBoard.nextMoveWin);
                }
                
                if (humanTurn)
                {
                    Console.Write($"Player {currentPlayer} Enter Position to Play (1-9):");
                    string enteredPosition = Console.ReadLine();
                    currentBoard = AddMove(currentBoard, enteredPosition);
                    foreach (var childBoard in allBoards.Children)
                    {

                        if (childBoard.ToString() == currentBoard.ToString())
                        {
                            currentBoard = childBoard;
                            break;
                        }
                    }

                    allBoards = currentBoard;
                    humanTurn = false;
                }
                else
                {
                    Console.WriteLine("Computers turn, hit enter");
                    Console.ReadLine();
                    decimal maxwin = 0;
                    bool first = true;
                    BoardTree nextboard = null;
                    foreach (var winmax in allBoards.Children)
                    {
                        if (first == true)
                        {
                            maxwin = winmax.winValue;
                            nextboard = winmax;
                            first = false;
                        }
                        if (winmax.nextMoveWin == false)
                        {
                            if (winmax.winValue <= maxwin)
                            {
                                maxwin = winmax.winValue;
                                nextboard = winmax;
                            }
                            if (winmax.winner == -1)
                            {
                                nextboard = winmax;
                                break;
                            }
                        }

                    }
                    currentBoard = nextboard;
                    allBoards = currentBoard;
                    humanTurn = true;
                    SwitchPlayer();
                }
            }

            string winningPlayer = currentPlayer == "X" ? "O" : currentPlayer == "O" ? "X" : currentPlayer;
            Console.Clear();
            Console.WriteLine(currentBoard);
            if (currentBoard.winner != 0)
            {
                Console.WriteLine($"Player {winningPlayer} wins!");
            }
            else
            {
                Console.WriteLine("Stalemate");
            }
            Console.ReadLine();


            /*
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
                        int row = (enteredNum - 1) / 3;
                        int column = (enteredNum - (row * 3)) - 1;
                        if (tickTacToeBoard[row, column] != "X" && tickTacToeBoard[row, column] != "O")
                        {
                            tickTacToeBoard[row, column] = currentPlayer;
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
            */

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

        public static void AddChildren(BoardTree node, string player)
        {
            if (node.endState == false)
            {
                bool emtpySpaces = false;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (node.Board[i, j] != "X" && node.Board[i, j] != "O")
                        {
                            BoardTree newchild = new BoardTree((string[,])node.Board.Clone());
                            newchild.Board[i, j] = player;
                            //newchild.plays = node.plays +1;
                            node.AddChild(newchild, i, j, node.plays);
                            if (debug == true)
                            {
                                Console.WriteLine(newchild);
                                Console.WriteLine($"win: {newchild.winner.ToString()} . Endstate {newchild.endState.ToString()} Plays: {newchild.plays}");
                                Console.ReadLine();
                            }
                            emtpySpaces = true;
                            AddChildren(newchild, player=="X"?"O":player=="O"?"X":player);
                        }
                        
                    }
                }

                
                if (emtpySpaces == false)
                {
                    node.endState = true;
                    node.winner = 0;
                }
            }
        }

        public static BoardTree AddMove(BoardTree currentBoard, string enteredPosition)
        {
            bool canConvert = int.TryParse(enteredPosition, out int enteredNum);
            if (canConvert == true)
            {
                if (enteredNum > 0 && enteredNum < 10)
                {
                    int row = (enteredNum - 1) / 3;
                    int column = (enteredNum - (row * 3)) - 1;
                    string existing = currentBoard.Board[row, column];
                    if (existing != "X" && existing != "O")
                    {
                        currentBoard.Board[row, column] = currentPlayer;
                        SwitchPlayer();
                    }
                    
                }
            }
            return currentBoard;
        }

        public static void SwitchPlayer()
        {
            if (currentPlayer == "X")
            {
                currentPlayer = "O";
            }
            else if (currentPlayer == "O")
            {
                currentPlayer = "X";
            }
        }
    }
}
