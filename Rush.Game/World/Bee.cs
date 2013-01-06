using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Rush.Support;
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
        private static readonly IBeeState[] States = {
            new Standby(),
            new Move()
        };

        public Hive CurrentHive { get; set; }
        public Texture2D SpriteTexture { get; set; }

        public Bee() : base()
        {
            CurrentState = States[0];
        }

        public override void Draw(GraphicsDeviceManager gfx, SpriteBatch batch, GameTime gameTime)
        {
            base.Draw(gfx, batch, gameTime);

            Point baseLocation = CameraManager.GetPointInScreen(Position);
            baseLocation.X -= 4;
            baseLocation.Y -= 4;

            batch.Draw(SpriteTexture, new Rectangle(baseLocation.X, baseLocation.Y, 8, 8), Color.White);
        }
    }
}
