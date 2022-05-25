using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevTVGameJam2022
{
    public class Cobblestone : Tile
    {
        public Cobblestone(Vector2 pos, int scale, bool alive) : base(Textures.Cobblestone, false)
        {
            HitBox = new Rectangle((int)pos.X, (int)pos.Y, Image.Width * scale, Image.Height * scale);
            Alive = alive;
        }

        public override void Update(GameTime gametime)
        {

        }
    }
}
