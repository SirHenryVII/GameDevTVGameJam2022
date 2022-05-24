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

        public Tile(Texture2D image)
        {
            Image = image;
        }

        public abstract void Update(GameTime gametime);
        public void Draw(SpriteBatch batch)
        {
            batch.Draw(Image, HitBox, Color.White);
        }

    }
}
