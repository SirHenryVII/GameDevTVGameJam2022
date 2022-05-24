using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevTVGameJam2022
{
    public class AlivePlatform : Tile
    {
        public AlivePlatform(Vector2 pos, int scale, bool alive) : base(Textures.PlatformAlive)
        {
            HitBox = new Rectangle((int)pos.X, (int)pos.Y, Image.Width * scale, Image.Height * scale);
            Alive = alive;
        }

        public override void Update(GameTime gametime)
        {

        }
    }
}
