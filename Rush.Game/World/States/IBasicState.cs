using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Rush.World.States
{
    public interface IBasicState<T> where T : Thing
    {
        void Update(T thing, GameTime gameTime);
        void Draw(T thing, GameTime gameTime);
    }

    public class EmptyState : IBasicState<Thing>
    {

        public void Update(Thing thing, GameTime gameTime)
        {
            
        }

        public void Draw(Thing thing, GameTime gameTime)
        {
            
        }
    }
}
