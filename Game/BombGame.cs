using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class BombGame
    {
        private Board hiddenBoard;
        private PlayerBoard pBoard;
        private BoardOfSuspects suspects;
        private int numOfBombs;
        public Board HiddenBoard { get => hiddenBoard; set => hiddenBoard = value; }
        public PlayerBoard PBoard { get => pBoard; set => pBoard = value; }
        public BoardOfSuspects Suspects { get => suspects; set => suspects = value; }
        public int NumOfBombs { get => numOfBombs; set => numOfBombs = value; }

        public BombGame(int rows, int columns)
        {
            Random rnd = new Random();
            NumOfBombs = rnd.Next(1, rows * columns / 4);
            this.HiddenBoard = new Board(rows, columns, numOfBombs);
            this.PBoard = new PlayerBoard(rows, columns);
            this.Suspects = new BoardOfSuspects(rows, columns);

        }

        public bool CheckingTheSelection(int r, int c, Board board, PlayerBoard gamePlayer)
        {
            if(Suspects.GetData(r, c) == 0)
            {
                int a = 0;
                if (board.GetData(r, c) == 9)
                {
                    Console.WriteLine("loss :(");

                    //ShowAllBombs();
                    return false;

                }
                else if (board.GetData(r, c) > 0)
                {

                    gamePlayer.SetData(r, c, board, a);
                    return true;
                }
                else if (gamePlayer.GetData(r, c) == -1)
                {

                    if (r > 0 && r < gamePlayer.RowLengh - 1 && c > 0 && c < gamePlayer.ColLengh - 1)
                    {
                        gamePlayer.SetData(r, c, board, a);
                        CheckingTheSelection(r - 1, c - 1, board, gamePlayer);
                        CheckingTheSelection(r - 1, c, board, gamePlayer);
                        CheckingTheSelection(r - 1, c + 1, board, gamePlayer);
                        CheckingTheSelection(r, c - 1, board, gamePlayer);
                        CheckingTheSelection(r, c + 1, board, gamePlayer);
                        CheckingTheSelection(r + 1, c - 1, board, gamePlayer);
                        CheckingTheSelection(r + 1, c, board, gamePlayer);
                        CheckingTheSelection(r + 1, c + 1, board, gamePlayer);
                    }
                    else if (r == 0 && c > 0 && c < gamePlayer.ColLengh - 1)
                    {
                        gamePlayer.SetData(r, c, board, a);
                        CheckingTheSelection(r, c - 1, board, gamePlayer);
                        CheckingTheSelection(r, c + 1, board, gamePlayer);
                        CheckingTheSelection(r + 1, c - 1, board, gamePlayer);
                        CheckingTheSelection(r + 1, c, board, gamePlayer);
                        CheckingTheSelection(r + 1, c + 1, board, gamePlayer);
                    }
                    else if (r > 0 && r < gamePlayer.RowLengh - 1 && c == 0)
                    {
                        gamePlayer.SetData(r, c, board, a);
                        CheckingTheSelection(r - 1, c, board, gamePlayer);
                        CheckingTheSelection(r - 1, c + 1, board, gamePlayer);
                        CheckingTheSelection(r, c + 1, board, gamePlayer);
                        CheckingTheSelection(r + 1, c, board, gamePlayer);
                        CheckingTheSelection(r + 1, c + 1, board, gamePlayer);
                    }
                    else if (r == gamePlayer.RowLengh - 1 && c > 0 && c < gamePlayer.ColLengh - 1)
                    {
                        gamePlayer.SetData(r, c, board, a);
                        CheckingTheSelection(r - 1, c - 1, board, gamePlayer);
                        CheckingTheSelection(r - 1, c, board, gamePlayer);
                        CheckingTheSelection(r - 1, c + 1, board, gamePlayer);
                        CheckingTheSelection(r, c - 1, board, gamePlayer);
                        CheckingTheSelection(r, c + 1, board, gamePlayer);
                    }
                    else if (r > 0 && r < gamePlayer.RowLengh - 1 && c == gamePlayer.ColLengh - 1)
                    {
                        gamePlayer.SetData(r, c, board, a);
                        CheckingTheSelection(r - 1, c - 1, board, gamePlayer);
                        CheckingTheSelection(r - 1, c, board, gamePlayer);
                        CheckingTheSelection(r, c - 1, board, gamePlayer);
                        CheckingTheSelection(r + 1, c - 1, board, gamePlayer);
                        CheckingTheSelection(r + 1, c, board, gamePlayer);
                    }
                    else if (r == 0 && c == 0)
                    {
                        gamePlayer.SetData(r, c, board, a);
                        CheckingTheSelection(r, c + 1, board, gamePlayer);
                        CheckingTheSelection(r + 1, c, board, gamePlayer);
                        CheckingTheSelection(r + 1, c + 1, board, gamePlayer);
                    }
                    else if (r == gamePlayer.RowLengh - 1 && c == gamePlayer.ColLengh - 1)
                    {
                        gamePlayer.SetData(r, c, board, a);
                        CheckingTheSelection(r, c - 1, board, gamePlayer);
                        CheckingTheSelection(r - 1, c, board, gamePlayer);
                        CheckingTheSelection(r - 1, c - 1, board, gamePlayer);
                    }
                    else if (r == 0 && c == gamePlayer.ColLengh - 1)
                    {
                        gamePlayer.SetData(r, c, board, a);
                        CheckingTheSelection(r, c - 1, board, gamePlayer);
                        CheckingTheSelection(r + 1, c - 1, board, gamePlayer);
                        CheckingTheSelection(r + 1, c, board, gamePlayer);
                    }
                    else if (r == gamePlayer.RowLengh - 1 && c == 0)
                    {
                        gamePlayer.SetData(r, c, board, a);
                        CheckingTheSelection(r - 1, c, board, gamePlayer);
                        CheckingTheSelection(r - 1, c + 1, board, gamePlayer);
                        CheckingTheSelection(r, c + 1, board, gamePlayer);
                    }
                    return true;
                }
            }
            return true;
        }
        public void stopTheGame()
        {
            Console.WriteLine("You can not continue playing, you do not follow the rules of the game");
        }
        public void MarkOrSuspect(ref int r,ref int c)
        {
            Console.WriteLine("you want to mark a suspect?");
            Console.WriteLine("Press 1 to suspect. 2 to unSuspect, otherwise write any number you want");
            int answer = Int32.Parse(Console.ReadLine());
            Console.WriteLine("enter r:");
            r = Int32.Parse(Console.ReadLine());
            Console.WriteLine("enter c:");
            c = Int32.Parse(Console.ReadLine());
            Console.WriteLine();
            if (answer == 1)
            {
                if (this.Suspects.GetData(r, c) == 1)
                {
                    Console.WriteLine("Wrong Step");
                    return;
                }
                else
                {
                    if (PBoard.GetData(r, c) != -1)
                        Console.WriteLine("The slot is already suspicious");
                    else
                        Suspects.SetData(r, c);
                }
            }
            if (answer == 2)
            {
                PBoard.SetBackToUnKnown(r, c);                     
                Suspects.SetDataZero(r, c);
            }                
        }
        public void Play()
        {
            Console.WriteLine("player");
            PBoard.Draw();
            Console.WriteLine("***");
            Console.WriteLine("bombs");
            HiddenBoard.Draw();
            int r=0, c=0;
            MarkOrSuspect(ref r,ref c);
            while (CheckingTheSelection(r, c, this.hiddenBoard, this.pBoard))
            {
                PBoard.Draw();
                if (this.numOfBombs == pBoard.SumOfEmptySquares())
                {
                        Console.WriteLine("Triumph :)");
                        break;
                }
                MarkOrSuspect(ref r, ref c); 
            }
        }  
    }
}

