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
        enum PlayerStates
        {
            Idle,
            Walking,
            Jumping,
            Dashing,
        }
        PlayerStates playerState = PlayerStates.Idle;

        public Texture2D image;
        public Color tint;

        public Rectangle HitBox;
        public Vector2 velocity;
        public bool onGround;
        public SpriteEffects direction;
        public bool Alive;
        public int Lives;

        bool dashReady = true;
        TimeSpan dashInterval = TimeSpan.FromMilliseconds(100);
        TimeSpan dashTimeElapsed = TimeSpan.Zero;
        TimeSpan startTime;

        public Rectangle deathCounterRect;
        private int deathCounter;
        private Texture2D pixel;
        private double imageScale;

        private float velocityCapX = 10f;

        public Player(Vector2 pos, Color Tint, double scale, int lives)
        {
            image = Game1.Player[1];
            pixel = Game1.Player[0];
            tint = Tint;
            HitBox = new Rectangle((int)pos.X, (int)pos.Y, (int)(image.Width * scale), (int)(image.Height * scale));
            direction = SpriteEffects.None;
            Alive = true;
            Lives = lives;
            imageScale = scale;
        }

        public void Update(GameTime gameTime)
        {
            dashTimeElapsed += gameTime.ElapsedGameTime;

            //Collision Logic
            Rectangle FloorPlayerHitBox = new Rectangle(HitBox.X, HitBox.Y + (int)(image.Height * imageScale) - 10, (int)(image.Width * imageScale), 10);
            if (Alive)
            {
                foreach(Tile tile in Game1.currentLevel.AliveTileList)
                {
                    if (FloorPlayerHitBox.Intersects(tile.HitBox) && velocity.Y >= 0)
                    {
                        onGround = true;
                        velocity.Y = 0;
                    }
                }


                //foreach (Tile tile in Game1.currentLevel.AliveHurtTileList)
                //{
                //    if (FloorPlayerHitBox.Intersects(tile.HitBox) & velocity.Y >= 0)
                //    {
                //        Lives -= 1;
                //        Alive = false;
                //        onGround = true;
                //        velocity.Y = 0;
                //    }
                //}
            }
            else
            {
                foreach (Tile tile in Game1.currentLevel.DeadTileList)
                {
                    if (FloorPlayerHitBox.Intersects(tile.HitBox) & velocity.Y >= 0)
                    {
                        onGround = true;
                        velocity.Y = 0;
                    }
                }
            }

            if (!dashReady && playerState != PlayerStates.Dashing && onGround)
            {
                dashReady = true;
            }

            if (playerState != PlayerStates.Dashing)
            {
                #region Slow Velocity X

                //Slow Velocity X
                if (velocity.X >= 1)
                {
                    if (onGround) velocity.X -= 0.6f;
                    else velocity.X -= 0.2f;
                }
                else if (velocity.X <= -1)
                {
                    if (onGround) velocity.X += 0.6f;
                    else velocity.X += 0.2f;
                }
                else if (velocity.X >= 1 && velocity.X <= -1)
                {
                    velocity.X = 0;
                }
                #endregion

                //Gravity
                if (!onGround)
                {
                    velocity.Y += 1;
                }

                #region Inputs
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

                if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) && dashReady && Alive)
                {
                    playerState = PlayerStates.Dashing;
                    dashReady = false;

                    velocity.Y = 0;
                    if (direction == SpriteEffects.None) velocity.X = 23;
                    else velocity.X = -23;

                    dashTimeElapsed = TimeSpan.Zero;
                }
                #endregion

                //Death Logic
                if (!Alive)
                {
                    deathCounterRect = new Rectangle(100, 1000, deathCounter, 30);
                    if (deathCounter == 0)
                    {
                        Alive = true;
                    }
                }
            }
            else 
            {
                if (dashTimeElapsed >= dashInterval)
                {
                    playerState = PlayerStates.Idle;

                    if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.D))
                    {
                        playerState = PlayerStates.Walking;
                    }
                }

                dashTimeElapsed += gameTime.ElapsedGameTime;
            }


            HitBox.X += (int)(velocity.X * 1.0);
            HitBox.Y += (int)(velocity.Y * 1.0);

            deathCounter--;
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(pixel, deathCounterRect, tint);
            batch.Draw(image, HitBox, tint);
        }

    }
}
