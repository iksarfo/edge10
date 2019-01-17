using System;
using System.Linq;

namespace edge10
{
    public static class Turns
    {
        public static Turn Min => Enum.GetValues(typeof(Turn)).Cast<Turn>().Min();
        public static Turn Max => Enum.GetValues(typeof(Turn)).Cast<Turn>().Max();
    }
}