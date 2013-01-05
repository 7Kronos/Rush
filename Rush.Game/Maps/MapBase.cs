using Rush.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rush.Maps
{
    public abstract class MapBase
    {
        ICollection<Hive> Hives;

        public MapBase()
        {
            Hives = new List<Hive>();
        }

        public abstract void Load();
    }
}
