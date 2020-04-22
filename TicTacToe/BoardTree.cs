using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class BoardTree
    {
        public string[,] Board { get; set; }

        public decimal winner { get; set; }
        //+1 means that O is the winner, -1 means that O is the winner, 0 means tie or game not done

        public bool endState { get; set; }
        //if this is true, it either means there is a declared winner, or the game is a draw. No more children

        public int plays { get; set; }

        public decimal winValue { get; set; }

        public decimal numChild;

        public List<BoardTree> Children { get; set; }

        public BoardTree parent { get; set; }

        public BoardTree(string[,] Board)
        {
            this.Children = new List<BoardTree>();
            this.Board = Board;
        }

        public BoardTree()
        {
            this.Board = new string[3, 3];
            this.Children = new List<BoardTree>();
            this.plays = 0;
        }

        public void AddChild(BoardTree node, int row, int column, int plays)
        {
            this.Children.Add(node);
            node.CheckWin(row, column);
            node.plays = plays +1;
            node.parent = this;
            if (node.winner != 0)
            {
                node.numChild = 1;
                node.winValue = node.winner;
                node.SetWinStats();
            }
            if (node.plays == 9)
            {
                node.endState = true;
                node.SetWinStats();
            }
            
        }

        public override string ToString()
        {
            StringBuilder boardString = new StringBuilder();
            //boardString.Append()
            boardString.AppendLine("\t\t     |     |      ");
            boardString.AppendLine($"\t\t  {this.Board[0, 0]}  |  {this.Board[0, 1]}  |  {this.Board[0, 2]}");
            boardString.AppendLine("\t\t_____|_____|_____ ");
            boardString.AppendLine("\t\t     |     |      ");
            boardString.AppendLine($"\t\t  {this.Board[1, 0]}  |  {this.Board[1, 1]}  |  {this.Board[1, 2]}");
            boardString.AppendLine("\t\t_____|_____|_____ ");
            boardString.AppendLine("\t\t     |     |      ");
            boardString.AppendLine($"\t\t  {this.Board[2, 0]}  |  {this.Board[2, 1]}  |  {this.Board[2, 2]}");
            boardString.AppendLine("\t\t     |     |      ");

            return boardString.ToString();
        }

        private void CheckWin(int row, int column)
        {
            //int row = (enteredNum - 1) / 3;
            //int column = (enteredNum - (row * 3)) - 1;
            if (this.Board[row, 0] == this.Board[row, 1] && this.Board[row, 0] == this.Board[row, 2])
            {
                Setwinner(this, row, column);
            }
            else if (this.Board[0, column] == this.Board[1, column] && this.Board[0, column] == this.Board[2, column])
            {
                Setwinner(this, row, column);
            }
            else if (this.Board[0, 0] == this.Board[1, 1] && this.Board[0, 0] == this.Board[2, 2])
            {
                Setwinner(this, row, column);
            }
            else if (this.Board[0, 2] == this.Board[1, 1] && this.Board[0, 2] == this.Board[2, 0])
            {
                Setwinner(this, row, column);
            }

        }

        private void Setwinner(BoardTree board, int row, int column)
        {
            if (board.Board[row, column] == "X")
            {
                board.winner = 20;
            }
            if (board.Board[row, column] == "O")
            {
                board.winner = -20;
            }
            board.endState = true;
        }

        private void SetWinStats()
        {
            if (this.parent != null)
            {
                BoardTree parent = this.parent;
                parent.winValue = ((parent.winValue * parent.Children.Count) + this.winValue) / (parent.Children.Count + 1);
                //parent.numChild += 1;
                parent.SetWinStats();
            }   
        }
    }
}
