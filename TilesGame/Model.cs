using System.Drawing;
using System.Collections.Generic;

namespace TilesGame
{
    public class Model
    {
        public Grid Grid { get; private set; }
        public TileManager TileManager { get; private set; }

        public Model()
        {
            Grid = new Grid(this, new Size(6, 6), new Size(60, 60), new Point(20, 20));
            TileManager = new TileManager(this, 5);
        }
        // Здесь же можно установить связи между всеми слоями приложения..

    }
}
