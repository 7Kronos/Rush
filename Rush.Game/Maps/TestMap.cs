using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rush.Maps
{
    public class TestMap : MapBase
    {
        public override void Load(ContentManager contentManager)
        {
            base.Load(contentManager);

            Spawn(new Vector2(-10, 0));
            Spawn(new Vector2(+10, 0));
        }
    }
}
