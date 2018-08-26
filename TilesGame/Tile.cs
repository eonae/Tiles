using System.Drawing;

namespace TilesGame
{
    public enum TileState { Normal, Hovered, Dragged }

    public class Tile
    {
        public Point Position { get; set; } // Позиция центральной точки
        public readonly Size Size;
        public readonly Grid GridReference;
        public TileState State { get; set; }
        public Node DockedTo { get; private set; }

        public Tile(Size size, Grid gridRef, Node node)
        {
            Size = size;
            GridReference = gridRef;
            DockToNode(node);
        }
        public void DockToNode(Node node)
        {
            DockedTo = node;
            if (node != null)
                Position = node.AbsPosition;
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(new Point(Position.X - Size.Width / 2, Position.Y - Size.Height / 2), Size);
        }
        public bool CheckHover(Point mousePosition)
        {
            return GetRectangle().Contains(mousePosition);
        }
        public void SetPosition(Point pointPosition)
        {
            Position = pointPosition;
        }
    }

}
