using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rush.Support
{
    public static class Randomizer
    {
        private static Random rnd = new Random();

        public static int Next(int min, int max)
        {
            return rnd.Next(min, max);
        }
    }
}
