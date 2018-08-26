using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TilesGame.BaseTypes
{
    public class Node // Узел сетки
    {
        public readonly IGrid GridReference;
        public readonly (int X, int Y) Index; // Позиция (индексы) в массиве сетки.
        public Point AbsPosition { get; private set; } // Вычисляемое значение, которое не меняется в ходе выполнения программы.

        public Node(IGrid grid, (int x, int y) index)
        {
            GridReference = grid;
            Index = index;
            var x = GridReference.Position.X + index.x * GridReference.CellSize.Width + GridReference.CellSize.Width / 2;
            var y = GridReference.Position.Y + index.y * GridReference.CellSize.Height + GridReference.CellSize.Height / 2;
            AbsPosition = new Point(x, y);
        }        
    }
}
