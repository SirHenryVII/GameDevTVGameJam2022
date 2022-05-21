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
        public Color tint;

        public Rectangle HitBox;
        public Vector2 velocity;
        public Boolean onGround;
        public SpriteEffects direction;

        private float velocityCapX = 10f;

        KeyboardState prevKeyboardState = Keyboard.GetState();

        public Player(Texture2D Image, Vector2 pos, Color Tint, int scale)
        {
            image = Image;
            tint = Tint;
            HitBox = new Rectangle((int)pos.X, (int)pos.Y, Image.Width * scale, Image.Height * scale);
            direction = SpriteEffects.None;
        }

        public void Update(GameTime gameTime)
        {
            //Collision Logic
            if (HitBox.Bottom > Game1.Graphics.PreferredBackBufferHeight)
            {
                onGround = true;
                velocity.Y = 0;
            }

            //Slow Velocity X
            if (velocity.X >= 1 && !Keyboard.GetState().IsKeyDown(Keys.A) && !Keyboard.GetState().IsKeyDown(Keys.D))
            {
                velocity.X -= 0.6f;
            }
            else if (velocity.X <= -1 && !Keyboard.GetState().IsKeyDown(Keys.D) && !Keyboard.GetState().IsKeyDown(Keys.A))
            {
                velocity.X += 0.6f;
            }
            else if(velocity.X >= 1 && velocity.X <= -1)
            {
                velocity.X = 0;
            }

            //Gravity
            if (!onGround)
            {
                velocity.Y += 1;
            }

            //Inputs
            if (Keyboard.GetState().IsKeyDown(Keys.D) && velocity.X < velocityCapX)
            {
                if (onGround) velocity.X += 2;
                else velocity.X += 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A) && velocity.X > velocityCapX * -1)
            {
                if (onGround) velocity.X -= 2;
                else velocity.X -= 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && onGround)
            {
                velocity.Y = -25;
                onGround = false;
            }
            if(Keyboard.GetState().IsKeyDown(Keys.LeftShift))


            prevKeyboardState = Keyboard.GetState();

            HitBox.X += (int)(velocity.X * 1.0);
            HitBox.Y += (int)(velocity.Y * 1.0);
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(image, HitBox, tint);
        }

    }
}
