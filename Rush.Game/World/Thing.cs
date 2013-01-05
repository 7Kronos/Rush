using Microsoft.Xna.Framework;
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
        public Point Position { get; set; }
        public Point Destination { get; set; }

        protected IBasicState<Thing> CurrentState { get; set; }

        public static readonly IBasicState<Thing> EmptyState = new EmptyState();

        public Thing()
        {
            CurrentState = EmptyState;
        }

        protected virtual void Update(GameTime gameTime)
        {
            CurrentState.Update(this, gameTime);
        }

        protected virtual void Draw(GameTime gameTime)
        {
            CurrentState.Draw(this, gameTime);
        }
    }
}
