using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace TilesGame
{
    public class TileManager
    {
        public Model ModelRef { get; private set; }
        public TilesCollection Tiles { get; set; } = new TilesCollection();
        public Tile ActiveTile { get; set; }
        public bool NoActiveTile { get { return ActiveTile == null; } }

        public TileManager(Model model, int numberOfTiles)
        {
            ModelRef = model;
            if (numberOfTiles >= ModelRef.Grid.Nodes.Count || numberOfTiles<0)
                throw new Exception("Invalid number of tiles!");

            var nodes = (IEnumerable<Node>)ModelRef.Grid.Nodes;
            for (int i =0; i < numberOfTiles; i++)
            {
                var result = nodes.RandomElementExclude();
                nodes = result.NewCollection;
                Tiles.Add(new Tile(new Size(50, 50), ModelRef.Grid, result.Element));
            }
        }

        public void ActivateTile(Point mousePosition)
        {
            ActiveTile = GetTileByCursorPosition(mousePosition);
            if (ActiveTile != null)
            {
                ActiveTile.State = TileState.Dragged;
                ActiveTile.DockToNode(null);
            }
        }
        public void DropTile(Point mousePosition)
        {
            ActiveTile.DockToNode(ModelRef.Grid.ActiveNode);
            ActiveTile.State = TileState.Normal;
            ActiveTile = null;
        }
        public void Hover(Point mousePosition)
        {
            foreach (var t in Tiles)
                t.State = TileState.Normal;
            var tile = GetTileByCursorPosition(mousePosition);
            if (tile!=null)
                tile.State = TileState.Hovered;
        }
        public void Drag(Point mousePosition)
        {
            ActiveTile.Position = mousePosition;
        }

        private Tile GetTileByCursorPosition(Point mousePosition)
        {
            // Не будет ли находить два тайла при наложении? 
            var query = Tiles.Where(t => t.GetRectangle().Contains(mousePosition));
            var result = query.ToArray();
            if (result.Count() > 1)
                throw new Exception("Два тайла не могут быть активированы!");
            if (result.Count() == 0)
                return null;
            else
                return result.Single(); //Если Single возвращает null при необнаружении значения, то функцию можно упростить.
        }


    }
}
