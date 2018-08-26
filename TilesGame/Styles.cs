using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TilesGame.View
{
    public static class Styles
    {
        public static TileStyle MainTileStyle { get; } = new TileStyle(Color.Blue, Color.DarkBlue, 1);
        public static TileStyle HoveredTileStyle { get; } = new TileStyle(Color.Blue, Color.DarkBlue, 4);
        public static TileStyle GridTileStyle { get; } = new TileStyle(Color.LightGray, Color.Gray, 1);

    }
}
