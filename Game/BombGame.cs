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
        public void ShowAllBombs(Board board, PlayerBoard gamePlayer)
        {
            for (int i = 0; i < board.RowLengh; i++)
            {
                for (int j = 0; j < board.ColLengh; j++)
                {
                    if(board.GetData(i, j)==9)
                        gamePlayer.SetData(i, j, board);
                }  
            }
            gamePlayer.Draw();
        }
        public bool CheckingTheSelection(int r, int c, Board board, PlayerBoard gamePlayer)
        {
            if(Suspects.GetData(r, c) == 0)
            {
               
                if (board.GetData(r, c) == 9)
                {

                    ShowAllBombs( board,  gamePlayer);
                    Console.WriteLine("loss :(");
                    return false;

                }
                else if (board.GetData(r, c) > 0)
                {

                    gamePlayer.SetData(r, c, board);
                    return true;
                }
                else if (gamePlayer.GetData(r, c) == -1)
                {

                    if (r > 0 && r < gamePlayer.RowLengh - 1 && c > 0 && c < gamePlayer.ColLengh - 1)
                    {
                        gamePlayer.SetData(r, c, board);
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
                        gamePlayer.SetData(r, c, board);
                        CheckingTheSelection(r, c - 1, board, gamePlayer);
                        CheckingTheSelection(r, c + 1, board, gamePlayer);
                        CheckingTheSelection(r + 1, c - 1, board, gamePlayer);
                        CheckingTheSelection(r + 1, c, board, gamePlayer);
                        CheckingTheSelection(r + 1, c + 1, board, gamePlayer);
                    }
                    else if (r > 0 && r < gamePlayer.RowLengh - 1 && c == 0)
                    {
                        gamePlayer.SetData(r, c, board);
                        CheckingTheSelection(r - 1, c, board, gamePlayer);
                        CheckingTheSelection(r - 1, c + 1, board, gamePlayer);
                        CheckingTheSelection(r, c + 1, board, gamePlayer);
                        CheckingTheSelection(r + 1, c, board, gamePlayer);
                        CheckingTheSelection(r + 1, c + 1, board, gamePlayer);
                    }
                    else if (r == gamePlayer.RowLengh - 1 && c > 0 && c < gamePlayer.ColLengh - 1)
                    {
                        gamePlayer.SetData(r, c, board);
                        CheckingTheSelection(r - 1, c - 1, board, gamePlayer);
                        CheckingTheSelection(r - 1, c, board, gamePlayer);
                        CheckingTheSelection(r - 1, c + 1, board, gamePlayer);
                        CheckingTheSelection(r, c - 1, board, gamePlayer);
                        CheckingTheSelection(r, c + 1, board, gamePlayer);
                    }
                    else if (r > 0 && r < gamePlayer.RowLengh - 1 && c == gamePlayer.ColLengh - 1)
                    {
                        gamePlayer.SetData(r, c, board);
                        CheckingTheSelection(r - 1, c - 1, board, gamePlayer);
                        CheckingTheSelection(r - 1, c, board, gamePlayer);
                        CheckingTheSelection(r, c - 1, board, gamePlayer);
                        CheckingTheSelection(r + 1, c - 1, board, gamePlayer);
                        CheckingTheSelection(r + 1, c, board, gamePlayer);
                    }
                    else if (r == 0 && c == 0)
                    {
                        gamePlayer.SetData(r, c, board);
                        CheckingTheSelection(r, c + 1, board, gamePlayer);
                        CheckingTheSelection(r + 1, c, board, gamePlayer);
                        CheckingTheSelection(r + 1, c + 1, board, gamePlayer);
                    }
                    else if (r == gamePlayer.RowLengh - 1 && c == gamePlayer.ColLengh - 1)
                    {
                        gamePlayer.SetData(r, c, board);
                        CheckingTheSelection(r, c - 1, board, gamePlayer);
                        CheckingTheSelection(r - 1, c, board, gamePlayer);
                        CheckingTheSelection(r - 1, c - 1, board, gamePlayer);
                    }
                    else if (r == 0 && c == gamePlayer.ColLengh - 1)
                    {
                        gamePlayer.SetData(r, c, board);
                        CheckingTheSelection(r, c - 1, board, gamePlayer);
                        CheckingTheSelection(r + 1, c - 1, board, gamePlayer);
                        CheckingTheSelection(r + 1, c, board, gamePlayer);
                    }
                    else if (r == gamePlayer.RowLengh - 1 && c == 0)
                    {
                        gamePlayer.SetData(r, c, board);
                        CheckingTheSelection(r - 1, c, board, gamePlayer);
                        CheckingTheSelection(r - 1, c + 1, board, gamePlayer);
                        CheckingTheSelection(r, c + 1, board, gamePlayer);
                    }
                    return true;
                }
            }
            return true;
        }
       
        public void MarkOrSuspect(ref int r,ref int c,ref bool stop)
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
                    stop = true;
                    return;
                }
                else
                {
                    if (PBoard.GetData(r, c) == -1)
                        Suspects.SetData(r, c);
                    else
                    {
                        Console.WriteLine("Sorry, but it's not possible in this square");
                        Console.WriteLine("Wrong Step");
                        stop = true;
                        return;
                    }     
                }
            }
            if (answer == 2)
            {
                if (Suspects.GetData(r,c)==1)
                {
                    PBoard.SetBackToUnKnown(r, c);
                    Suspects.SetDataZero(r, c);
                }
                else
                {
                    Console.WriteLine("The square was not suspicious");
                    Console.WriteLine("Wrong Step");
                    stop = true;
                    return;
                }
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
            bool stop = false;
            MarkOrSuspect(ref r,ref c, ref stop);
            if (!stop)
            {
                while (CheckingTheSelection(r, c, this.hiddenBoard, this.pBoard))
                {
                    PBoard.Draw();
                    if (this.numOfBombs == pBoard.SumOfEmptySquares())
                    {
                        Console.WriteLine("Triumph :)");
                        break;
                    }
                    MarkOrSuspect(ref r, ref c, ref stop);
                    if (stop)
                        break;
                }
            }
        }  
    }
}

