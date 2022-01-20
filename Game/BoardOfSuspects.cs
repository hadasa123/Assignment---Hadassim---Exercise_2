using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class BoardOfSuspects:BaseBoard
    {
        public   void SetData(int r, int c)
        {
            this.BoardData[r, c] = 1;
        }
        public void SetDataZero(int r, int c)
        {
            this.BoardData[r, c] = 0;
        }
        public BoardOfSuspects(int r, int c)
        {
            BoardData = new int[r, c];
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    BoardData[i, j]=0;
                }
            }
        }
    }
}
