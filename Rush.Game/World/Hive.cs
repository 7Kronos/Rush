using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Rush.Maps;
using Rush.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rush.World
{
    public class Hive : Thing
    {
        readonly string texture = "defaultHive";
        MapBase _parentMap;

        public int Level { get; set; }
        public bool Upgrading { get; set; }

        public Hive(MapBase parentMap)
        {
            Level = 1;
            _parentMap = parentMap;
        }

        public override void Draw(GraphicsDeviceManager gfx, SpriteBatch batch, GameTime gameTime)
        {
            base.Draw(gfx, batch, gameTime);
            Point baseLocation = CameraManager.GetPointInScreen(Position);
            baseLocation.X -= 24;
            baseLocation.Y -= 24;

            batch.Draw(_parentMap.GetTexture(texture), new Rectangle(baseLocation.X, baseLocation.Y, 48, 48), Color.White);
        }
    }
}
