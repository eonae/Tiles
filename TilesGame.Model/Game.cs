using System.Drawing;
using TilesGame.View;

namespace TilesGame.Model
{
    public class Game
    {
        public Grid Grid { get; private set; }
        public TileManager TileManager { get; private set; }
        public MainForm View { get; set; }

        public Game(MainForm view)
        {
            View = view;
            Grid = new Grid(this, new Size(6, 6), new Size(60, 60), new Point(20, 20));
            TileManager = new TileManager(this, 5);
        }

        public void UpdateView()
        {
            View.Invalidate();
        }




    }
}
