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
            DashingUp,
        }
        PlayerStates playerState = PlayerStates.Idle;

        public Texture2D image = Textures.Player;
        public Color tint;

        public Rectangle HitBox;
        public Vector2 velocity;
        public bool onGround;
        public SpriteEffects direction = SpriteEffects.None;
        public bool Alive = true;
        public int Lives;

        bool dashReady = true;
        TimeSpan dashInterval = TimeSpan.FromMilliseconds(120);
        TimeSpan dashTimeElapsed = TimeSpan.Zero;
        TimeSpan startTime;

        private Rectangle deathCounterRect;
        private int deathCounter;
        private Texture2D pixel = Textures.Pixel;
        private double imageScale;
        private float transparency = 1f;

        private float velocityCapX = 10f;

        public Player(Vector2 pos, Color Tint, double scale, int lives)
        {
            tint = Tint;
            HitBox = new Rectangle((int)pos.X, (int)pos.Y, (int)(image.Width * scale), (int)(image.Height * scale));
            Lives = lives;
            imageScale = scale;
        }

        public void Update(GameTime gameTime)
        {
            dashTimeElapsed += gameTime.ElapsedGameTime;

            #region Collision Logic
            //Collision Logic Y
            Rectangle FloorPlayerHitBox = new Rectangle(HitBox.X, HitBox.Y + (int)(image.Height * imageScale) - 10, (int)(image.Width * imageScale), 10);
            if (Alive)
            {
                bool check = false;
                foreach(Tile tile in Game1.currentLevel.AliveTileList)
                {
                    if (FloorPlayerHitBox.Intersects(tile.HitBox) && velocity.Y >= 0)
                    {
                        onGround = true;
                        velocity.Y = 0;
                        check = true;
                        HitBox.Y = tile.HitBox.Top - (int)(image.Height * imageScale) + 1;

                        if (tile.Harmful)
                        {
                            Alive = false;
                            deathCounter = 150;
                            Lives -= 1;
                        }
                        break;
                    }
                }
                foreach (Tile tile in Game1.currentLevel.BothTileList)
                {
                    if (FloorPlayerHitBox.Intersects(tile.HitBox) && velocity.Y >= 0)
                    {
                        onGround = true;
                        velocity.Y = 0;
                        check = true;
                        HitBox.Y = tile.HitBox.Top - (int)(image.Height * imageScale) + 1;

                        if (tile.Harmful)
                        {
                            Alive = false;
                            deathCounter = 150;
                            Lives -= 1;
                        }
                        break;
                    }
                }
                if (!check)
                {
                    onGround = false;
                }
            }
            else
            {
                bool check = false;
                foreach (Tile tile in Game1.currentLevel.DeadTileList)
                {
                    if (FloorPlayerHitBox.Intersects(tile.HitBox) & velocity.Y >= 0)
                    {
                        onGround = true;
                        velocity.Y = 0;
                        check = true;
                        HitBox.Y = tile.HitBox.Top - (int)(image.Height * imageScale) + 1;
                        break;
                    }
                }
                foreach (Tile tile in Game1.currentLevel.BothTileList)
                {
                    if (FloorPlayerHitBox.Intersects(tile.HitBox) && velocity.Y >= 0)
                    {
                        onGround = true;
                        velocity.Y = 0;
                        check = true;
                        HitBox.Y = tile.HitBox.Top - (int)(image.Height * imageScale) + 1;

                        if (tile.Harmful)
                        {
                            Alive = false;
                            deathCounter = 150;
                            Lives -= 1;
                        }
                        break;
                    }
                }
                if (!check)
                {
                    onGround = false;
                }
            }

            //Collision Logic X
            if (HitBox.X < 0)
            {
                velocity.X = 0;
                HitBox.X = 0;
            }
            if (HitBox.X > Game1.Graphics.PreferredBackBufferWidth - (int)(image.Width * imageScale))
            {
                velocity.X = 0;
                HitBox.X = Game1.Graphics.PreferredBackBufferWidth - (int)(image.Width * imageScale);
            }

            #endregion
            //Set dashReady
            if (!dashReady && playerState != PlayerStates.Dashing && onGround && playerState != PlayerStates.DashingUp)
            {
                dashReady = true;
            }
            
            if (playerState != PlayerStates.Dashing && playerState != PlayerStates.DashingUp)
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
                    playerState = PlayerStates.Walking;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.A) && velocity.X > velocityCapX * -1)
                {
                    if (onGround) velocity.X -= 2;
                    else velocity.X -= 1;
                    direction = SpriteEffects.FlipHorizontally;
                    playerState = PlayerStates.Walking;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Space) && onGround)
                {
                    velocity.Y = -20;
                    onGround = false;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) && dashReady && Alive && !onGround)
                {
                    if (!Keyboard.GetState().IsKeyDown(Keys.W))
                    {
                        playerState = PlayerStates.Dashing;
                        dashReady = false;

                        velocity.Y = 0;
                        if (direction == SpriteEffects.None) velocity.X = 29;
                        else velocity.X = -29;

                        dashTimeElapsed = TimeSpan.Zero;
                    }
                }

                if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) && Keyboard.GetState().IsKeyDown(Keys.W) && dashReady && !Alive && !onGround)
                {
                    playerState = PlayerStates.DashingUp;
                    dashReady = false;

                    velocity.X = 0;
                    velocity.Y = -23;

                    dashTimeElapsed = TimeSpan.Zero;
                }
                #endregion

                //Death Logic
                if (!Alive)
                {
                    transparency = 0.7f;
                    deathCounterRect = new Rectangle(100, 1000, deathCounter, 30);
                    if (deathCounter == 0)
                    {
                        Alive = true;
                        transparency = 1f;
                    }
                }

                //GameOver Logic
                if(Lives <= 0)
                {
                    Game1.currentLevel.Reload();
                }
            }
            else 
            {
                if (dashTimeElapsed >= dashInterval)
                {
                    if (playerState == PlayerStates.Dashing)
                    {
                        if (direction == SpriteEffects.None) velocity.X = velocityCapX;
                        else velocity.X = -velocityCapX;
                    }
                    else velocity.Y = -10;

                    playerState = PlayerStates.Idle;

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
            batch.Draw(image, HitBox, tint * transparency);
        }

    }
}
