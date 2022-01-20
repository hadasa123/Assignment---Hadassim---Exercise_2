using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class PlayerBoard:BaseBoard
    {
       
        public PlayerBoard(int r, int c)
        {
            this.BoardData = new int[r, c];
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    this.BoardData[i, j] = -1;
                }
            }
        }
        public void SetBackToUnKnown(int r, int c)
        {
            this.BoardData[r, c] = -1;
        }
        public void SetData(int r, int c, Board board)
        {
            this.BoardData[r, c]= board.GetData(r, c); 
        }
        public int SumOfEmptySquares()
        {
            int acount = 0;
            for (int i = 0; i < RowLengh; i++)
                for (int j = 0; j < ColLengh; j++)
                    if (this.BoardData[i, j] ==-1)
                        acount++;
            return acount;
        }
    }
}
