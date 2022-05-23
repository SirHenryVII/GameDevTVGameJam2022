using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevTVGameJam2022
{
    public class AlivePlatform : Tile
    {
        public AlivePlatform() : base(new Vector2(0, 0), Game1.Player[0], 1, true)
        {

        }

        public override void Update(GameTime gametime)
        {

        }
    }
}
