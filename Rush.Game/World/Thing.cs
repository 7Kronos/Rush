using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rush.World
{
    public abstract class Thing
    {
        public Vector2 Position { get; set; }
        public Nullable<Vector2> Destination { get; set; }

        public Thing()
        {
            Main.Things.Add(this);
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(GraphicsDeviceManager gfx, SpriteBatch batch, GameTime gameTime)
        {
        }
    }
}
