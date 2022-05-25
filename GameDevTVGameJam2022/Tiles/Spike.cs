using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevTVGameJam2022
{
    public class Spike : Tile
    {
        public Spike(Vector2 pos, int scale, bool alive) : base(Textures.Spike, true)
        {
            HitBox = new Rectangle((int)pos.X, (int)pos.Y, Image.Width * scale, Image.Height * scale);
            Alive = alive;
        }
        public override void Update(GameTime gametime)
        {

        }
    }
}
