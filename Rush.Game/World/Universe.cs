using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Rush.Maps;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rush.World
{
    /// <summary>
    /// Comprend le background + la map et les content
    /// </summary>
    public class Universe
    {
        public MapBase Map { get; set; }

        public Universe()
        {
        }

        public void LoadMap<TMap>(ContentManager contentManager) where TMap : MapBase
        { 
            Map = Activator.CreateInstance<TMap>();
            Map.Load(contentManager);
        }

        
    }
}
