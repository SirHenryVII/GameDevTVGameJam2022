using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace GameDevTVGameJam2022
{
    public abstract class Tile
    {
        public Rectangle HitBox;
        public Texture2D Image;

        public Tile(Vector2 pos, Texture2D image, int scale)
        {
            HitBox = new Rectangle((int)pos.X, (int)pos.Y, image.Width * scale, image.Height * scale);
        }
    }
}
