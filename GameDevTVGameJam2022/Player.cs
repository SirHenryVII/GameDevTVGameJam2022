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
        public bool onGround;
        public SpriteEffects direction;
        public bool Alive;
        public int Lives;

        private float velocityCapX = 10f;

        public Player(Vector2 pos, Color Tint, double scale, int lives)
        {
            image = Game1.Player[0];
            tint = Tint;
            HitBox = new Rectangle((int)pos.X, (int)pos.Y, (int)(image.Width * scale), (int)(image.Height * scale));
            direction = SpriteEffects.None;
            Alive = true;
            Lives = lives;
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
                if (onGround) velocity.X -= 0.6f;
                else velocity.X -= 0.2f;
            }
            else if (velocity.X <= -1 && !Keyboard.GetState().IsKeyDown(Keys.D) && !Keyboard.GetState().IsKeyDown(Keys.A))
            {
                if (onGround) velocity.X += 0.6f;
                else velocity.X += 0.2f;
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
                direction = SpriteEffects.None;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A) && velocity.X > velocityCapX * -1)
            {
                if (onGround) velocity.X -= 2;
                else velocity.X -= 1;
                direction = SpriteEffects.FlipHorizontally;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && onGround)
            {
                velocity.Y = -20;
                onGround = false;
            }

            HitBox.X += (int)(velocity.X * 1.0);
            HitBox.Y += (int)(velocity.Y * 1.0);
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(image, HitBox, tint);
        }

    }
}
