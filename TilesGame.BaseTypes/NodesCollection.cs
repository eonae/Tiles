using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TilesGame.BaseTypes
{
    public class NodesCollection : ElementsCollection<Node>
    {
        public Node this[int x, int y]
        {
            get { return list.Where(node => node.Index.X == x && node.Index.Y == y).Single(); }
        }
    }
}
