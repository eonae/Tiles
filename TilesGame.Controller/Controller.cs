using System;
using System.Linq;
using System.Drawing;
using TilesGame.BaseTypes;
using TilesGame.Model;

namespace TilesGame
{
    public class Controller
    {
        public readonly Game GameRef;

        public Controller(Game gameRef)
        {
            GameRef = gameRef;
        }

        public void Paint(object sender, EventArgs args) //Вынести в модель!
        {
            args.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            Drawer.DrawGrid(args.Graphics, GameRef.Grid);
            foreach (var t in GameRef.TileManager.Tiles.Where(t=>t.State==TileState.Normal))
                Drawer.DrawTile(args.Graphics, t);
            foreach (var t in GameRef.TileManager.Tiles.Where(t => t.State == TileState.Hovered))
                Drawer.DrawTile(args.Graphics, t);
            foreach (var t in GameRef.TileManager.Tiles.Where(t => t.State == TileState.Dragged))
                Drawer.DrawTile(args.Graphics, t);
        }

        // Сделать так, чтобы позиция курсора уже пересчитанная заходила как параметр
        // Подписать котроллер на события MainForm (сейчас этого нет)
        // Вынести рисование в модель

        public void MouseMove(Point mousePosition) 
        {
            if (GameRef.TileManager.NoActiveTile)
                GameRef.TileManager.Hover(mousePosition);
            else
            {
                GameRef.TileManager.Drag(mousePosition);
                GameRef.Grid.UpdateNearest(mousePosition);
            }
            GameRef.UpdateView();
        }
        public void MouseDown(Point mousePosition)
        {
            GameRef.TileManager.ActivateTile(mousePosition);
            GameRef.UpdateView();
        }
        public void MouseUp(Point mousePosition)
        {
            if (!GameRef.TileManager.NoActiveTile)
                GameRef.TileManager.DropTile(mousePosition);
            GameRef.Grid.ActiveNode = null;
            GameRef.UpdateView();
        }
    }
}
