using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Rush.World;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rush.Maps
{
    public abstract class MapBase
    {
        ICollection<Hive> _hives;
        IDictionary<string, Texture2D> _textures;

        public MapBase()
        {
            _hives = new List<Hive>();
            _textures = new ConcurrentDictionary<string, Texture2D>();
        }

        public Texture2D GetTexture(string contentKey)
        { 
            Texture2D content;
            _textures.TryGetValue(contentKey, out content);
            return content;
        }

        protected void RegisterTexture(string contentKey, Texture2D texture)
        {
            _textures.Add(contentKey, texture);
        }

        public virtual void Load(ContentManager contentManager)
        {
            RegisterTexture("defaultHive", contentManager.Load<Texture2D>(@"Textures\hive"));
        }

        protected void Spawn(Point location, int level = 1)
        {
            _hives.Add(new Hive(this) { 
                Position = location,
                Level = level,
                Upgrading = false,
                Destination = Point.Zero
            });
        }
    }
}
