using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Rush.World.States.Bee
{
    public interface IBeeState : IBasicState<Rush.World.Bee>
    {

    }

    public class Standby : IBeeState
    {
        public void Update(Rush.World.Bee thing, GameTime gameTime)
        {

        }

        public void Draw(Rush.World.Bee thing, GameTime gameTime)
        {

        }
    }

    public class Move : IBeeState
    {
        public void Update(Rush.World.Bee thing, GameTime gameTime)
        {

        }

        public void Draw(Rush.World.Bee thing, GameTime gameTime)
        {

        }
    }
}
