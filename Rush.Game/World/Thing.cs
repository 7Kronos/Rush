using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rush.World.States;

namespace Rush.World
{
    public abstract class Thing
    {
        public Vector2 Position { get; set; }
        public Nullable<Vector2> Destination { get; set; }

        protected IBasicState<Thing> CurrentState { get; set; }

        public static readonly IBasicState<Thing> EmptyState = new EmptyState();

        public Thing()
        {
            CurrentState = new EmptyState();
            Main.Things.Add(this);
        }

        public virtual void Update(GameTime gameTime)
        {
            CurrentState.Update(this, gameTime);
        }

        public virtual void Draw(GraphicsDeviceManager gfx, SpriteBatch batch, GameTime gameTime)
        {
            CurrentState.Draw(this, gameTime);
        }
    }
}
