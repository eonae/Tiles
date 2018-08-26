using System.Drawing;

namespace TilesGame.BaseTypes
{
    public interface IGrid
    {
        Node ActiveNode { get; set; }
        Size CellSize { get; set; }
        Point Position { get; set; }
        NodesCollection Nodes { get; set; }

        void UpdateNearest(Point mousePosition);
    }
}