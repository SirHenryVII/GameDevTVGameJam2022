using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevTVGameJam2022
{
    public class AlivePlatform : Tile
    {
        public AlivePlatform(Vector2 pos, int scale) : base(Game1.Player[0])
        {
            HitBox = new Rectangle((int)pos.X, (int)pos.Y, Image.Width * scale, Image.Height * scale);
        }

        public override void Update(GameTime gametime)
        {

        }
    }
}
