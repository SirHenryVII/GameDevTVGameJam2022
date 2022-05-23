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
        public bool Alive;

        public Tile(Vector2 pos, Texture2D image, int scale, bool alive)
        {
            HitBox = new Rectangle((int)pos.X, (int)pos.Y, image.Width * scale, image.Height * scale);
            Image = image;
            Alive = alive;
        }

        public abstract void Update(GameTime gametime);
        public abstract void Draw(GameTime gametime);

    }
}
