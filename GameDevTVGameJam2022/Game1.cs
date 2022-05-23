﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameDevTVGameJam2022
{
    public class Game1 : Game
    {
        public static GraphicsDeviceManager Graphics;
        private SpriteBatch SpriteBatch;
        public static Camera camera;
        public static Level currentLevel;
        public static List<Texture2D> Player = new List<Texture2D>();

        #region Functions

        public void ChangeResolution(int width, int height)
        {
            Graphics.PreferredBackBufferWidth = width;
            Graphics.PreferredBackBufferHeight = height;
            Graphics.ApplyChanges();
        }

        #endregion

        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            ChangeResolution(1920, 1080);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            //innit Camera
            camera = new Camera(GraphicsDevice.Viewport);

            //Load Textures
            Player.Add(Content.Load<Texture2D>("pixel"));
            Player.Add(Content.Load<Texture2D>("benBoi"));

            //Load Level TEMP
            currentLevel = new Level1();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Update Camera
            camera.setPos(new Vector2(0));

            //Update Level
            if (currentLevel.player.Alive) currentLevel.UpdateDead(gameTime);
            else currentLevel.UpdateDead(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.transform);

            //Draw Level
            if (currentLevel.player.Alive) currentLevel.Draw(SpriteBatch);
            else currentLevel.DrawDead(SpriteBatch);

            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
