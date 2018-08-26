using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TilesGame.BaseTypes
{
    public static class Extensions
    {
        private static Random rnd = new Random();
        public static Point Shift(this Point point, int x, int y)
        {
            return new Point(point.X + x, point.Y + y);
        }
        public static (T Element, IEnumerable<T> NewCollection) RandomElementExclude<T>(this IEnumerable<T> list)
        {
            var element = list.RandomElement();
            var temp = list.ToList();
            temp.Remove(element);
            return (element, temp);

        }
        public static T RandomElement<T>(this IEnumerable<T> list)
        {
            return list.ToArray()[rnd.Next(list.Count())];
        }
        public static double GetDistanceExt(this Node node, Point pt)
        {
            int dX = Math.Abs(node.AbsPosition.X - pt.X);
            int dY = Math.Abs(node.AbsPosition.Y - pt.Y);

            return Math.Sqrt(dX * dX + dY * dY);
        }

    }
}
