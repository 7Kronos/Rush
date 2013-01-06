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
        readonly string __texture = "defaultHive";
        readonly string __beeTexture = "defaultBee";
        MapBase _parentMap;

        public int Level { get; set; }
        public bool Upgrading { get; set; }

        TimeSpan nextBeeProduction;

        public Hive(MapBase parentMap)
        {
            Level = 1;
            _parentMap = parentMap;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (gameTime.TotalGameTime >= nextBeeProduction)
            {
                var newBee = new Bee() { 
                    CurrentHive = this,
                    Position = GetRandomPosition(),
                    SpriteTexture = _parentMap.GetTexture(__beeTexture)
                };

                Main.Things.Add(newBee);

                nextBeeProduction = gameTime.TotalGameTime + new TimeSpan(0, 0, 0, 0, 100);
            }
        }

        private Vector2 GetRandomPosition()
        {
            var len = Randomizer.Next(0, 10);
            var angle = Randomizer.Next(0, 359);

            return Position + new Vector2((float)(len * Math.Cos(MathHelper.ToRadians(angle))), (float)(len * Math.Sin(MathHelper.ToRadians(angle))));
        }

        public override void Draw(GraphicsDeviceManager gfx, SpriteBatch batch, GameTime gameTime)
        {
            base.Draw(gfx, batch, gameTime);
            Point baseLocation = CameraManager.GetPointInScreen(Position);
            baseLocation.X -= 24;
            baseLocation.Y -= 24;

            batch.Draw(_parentMap.GetTexture(__texture), new Rectangle(baseLocation.X, baseLocation.Y, 48, 48), Color.White);
        }
    }
}
