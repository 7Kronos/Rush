using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rush.World
{
    public abstract class Thing
    {
        public Point Position { get; set; }
        public Point Destination { get; set; }

        protected virtual void Update(GameTime gameTime)
        {
        }

        protected virtual void Draw(GameTime gameTime)
        {
        }
    }
}
