using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Rush.World.States;
using Rush.World.States.Bee;

namespace Rush.World
{
    public class Bee : Thing
    {
        private static IBeeState[] States = {
            new Standby(),
            new Move()
        };

        public Hive CurrentHive { get; set; }

        public Bee() : base()
        {
            CurrentState = States[0] as IBasicState<Thing>;
        }
    }
}
