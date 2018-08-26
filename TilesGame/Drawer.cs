using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using TilesGame.BaseTypes;

namespace TilesGame.View
{
    public static class Drawer
    {
        public static void DrawTile(Graphics g, Tile tile)
        {
            switch (tile.State)
            {
                case TileState.Normal:
                    DrawNormalTile(g, tile); break;
                case TileState.Hovered:
                    DrawHoveredTile(g, tile); break;
                case TileState.Dragged:
                    DrawDragged(g, tile); break;
            }
        }
        private static void DrawDragged(Graphics g, Tile tile)
        {
            var style = new TileStyle(Color.FromArgb(100, Color.Blue), Color.DarkBlue, 1);
            DrawHelper(g, tile, style);
        }
        private static void DrawHelper(Graphics g, Tile tile, TileStyle style)
        {
            var rect = tile.GetRectangle();
            g.FillRectangle(new SolidBrush(style.FillColor), rect);
            g.DrawRectangle(new Pen(style.BorderColor) { Width = style.BorderWidth }, rect);
        }

        private static void DrawNormalTile(Graphics g, Tile tile)
        {
            var style = new TileStyle(Color.Blue, Color.DarkBlue, 1);
            DrawHelper(g, tile, style);
        }
        private static void DrawHoveredTile(Graphics g, Tile tile)
        {
            var style = new TileStyle(Color.Blue, Color.DarkBlue, 3);
            DrawHelper(g, tile, style);
        }

        public static void DrawGrid(Graphics g, IGrid grid)
        {
            foreach (var node in grid.Nodes)
                if (node != grid.ActiveNode)
                    DrawNode(g, node);
                else
                    DrawActiveNode(g, node);
        }
        private static void DrawNode(Graphics g, Node node)
        {
            int r = 56;

            g.DrawRectangle(new Pen(Color.LightGray) , node.AbsPosition.X - r / 2, node.AbsPosition.Y - r / 2, r, r);
        }

        private static void DrawActiveNode(Graphics g, Node node)
        {
            int r = 56;
            g.DrawRectangle(new Pen(Color.Blue) { Width = 2 }, node.AbsPosition.X-r/2, node.AbsPosition.Y - r/2, r, r);
        }
    }
}
