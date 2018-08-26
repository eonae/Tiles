using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace TilesGame
{
    public class Controller
    {
        public readonly Model ModelRef;
        public readonly MainForm FormRef;

        public Controller(Model modelRef, MainForm formRef)
        {
            ModelRef = modelRef;
            FormRef = formRef;
        }

        public void Paint(object sender, PaintEventArgs args)
        {
            args.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            Drawer.DrawGrid(args.Graphics, ModelRef.Grid);
            foreach (var t in ModelRef.TileManager.Tiles.Where(t=>t.State==TileState.Normal))
                Drawer.DrawTile(args.Graphics, t);
            foreach (var t in ModelRef.TileManager.Tiles.Where(t => t.State == TileState.Hovered))
                Drawer.DrawTile(args.Graphics, t);
            foreach (var t in ModelRef.TileManager.Tiles.Where(t => t.State == TileState.Dragged))
                Drawer.DrawTile(args.Graphics, t);
        }
        public void MouseMove(object sender, MouseEventArgs args)
        {
            Point mousePosition = FormRef.PointToClient(Cursor.Position);

            if (ModelRef.TileManager.NoActiveTile)
                ModelRef.TileManager.Hover(mousePosition);
            else
            {
                ModelRef.TileManager.Drag(mousePosition);
                ModelRef.Grid.UpdateNearest(mousePosition);
            }
            FormRef.Invalidate();
        }
        public void MouseDown(object sender, MouseEventArgs args)
        {
            Point mousePosition = FormRef.PointToClient(Cursor.Position);
            ModelRef.TileManager.ActivateTile(mousePosition);
            FormRef.Invalidate();
        }
        public void MouseUp(object sender, MouseEventArgs args)
        {
            Point mousePosition = FormRef.PointToClient(Cursor.Position);
            if (!ModelRef.TileManager.NoActiveTile)
                ModelRef.TileManager.DropTile(mousePosition);
            ModelRef.Grid.ActiveNode = null;
            FormRef.Invalidate();
        }
    }
}
