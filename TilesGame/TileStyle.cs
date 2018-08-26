using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TilesGame.View
{
    public struct TileStyle
    {
        public readonly Color BorderColor;
        public readonly Color FillColor;
        public readonly int BorderWidth;

        public TileStyle(Color fillColor, Color borderColor, int borderWidth)
        {
            BorderColor = borderColor;
            FillColor = fillColor;
            BorderWidth = borderWidth;
        }
    }
}
