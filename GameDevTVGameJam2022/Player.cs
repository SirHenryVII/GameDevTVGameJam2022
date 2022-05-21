using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace GameDevTVGameJam2022
{
    public class Player
    {
        public Texture2D image;
        public Vector2 position;
        public Color tint;

        public Rectangle HitBox => new Rectangle((int)(position.X), (int)(position.Y), image.Width, image.Height);
        public Vector2 velocity;

        KeyboardState prevKeyboardState = Keyboard.GetState();

        public Player(Texture2D Image, Vector2 Postion, Color Tint)
        {
            image = Image;
            position = Postion;
            tint = Tint;
        }

        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                velocity.X++;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                velocity.X--;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                velocity.Y--;
            }

            prevKeyboardState = Keyboard.GetState();
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(image, HitBox, tint);
        }

    }
}
