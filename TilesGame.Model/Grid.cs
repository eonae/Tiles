using System;
using System.Drawing;
using TilesGame.BaseTypes;
using System.Linq;


namespace TilesGame.Model
{
    public class Grid : IGrid
    {
        public readonly Game GameRef;
        public NodesCollection Nodes { get; set; } = new NodesCollection(); // Открытый, чтобы интерфейс!
        public Point Position { get; set; }     // Положение левого верхнего угла сетки.
        public readonly Size Dimention; // Размерность сетки
        public Size CellSize { get; set; }  // Размер одной ячейки
        public Node ActiveNode { get; set; }

        public Grid(Game game, Size dimention, Size cellSize, Point position)
        {
            // Нужно добавить проверки: размер не слишком маленький dimention не менее, чем 1,1

            GameRef = game;
            CellSize = cellSize;
            Position = position;
            Dimention = dimention;

            for (int i = 0; i < Dimention.Height; i++)
                for (int j = 0; j < Dimention.Width; j++)
                    Nodes.Add(new Node(this, (i, j)));
        }

        public void UpdateNearest(Point mousePosition)
        {
            var nearest = GetNearestNode(mousePosition);
            if (ActiveNode!=nearest)
                ActiveNode = nearest;
        }

        private Node GetNearestNode(Point pt)
        {
            double min_dist = Nodes.Except(GameRef.TileManager.Tiles.Select(t => t.DockedTo)).Min(n => n.GetDistanceExt(pt));
            return Nodes.Where(n => n.GetDistanceExt(pt) == min_dist).Take(1).Single();
        }
        private double GetDistance(Point A, Point B)
        {
            int dX = Math.Abs(A.X - B.X);
            int dY = Math.Abs(A.Y - B.Y);
            return Math.Sqrt(dX * dX + dY * dY);
        }
    }


}
