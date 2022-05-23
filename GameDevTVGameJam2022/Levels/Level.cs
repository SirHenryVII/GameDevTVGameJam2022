using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameDevTVGameJam2022
{
    public abstract class Level
    {
        public List<Tile> AliveTileList = new List<Tile>();
        public List<Tile> DeadTileList = new List<Tile>();
        public List<Tile> AliveHurtTileList = new List<Tile>();
        public List<Tile> DeadHurtTileList = new List<Tile>();

        public Player player;

        public Level(int lives)
        {
            player = new Player(new Vector2(400), Color.White, 0.5, 3);
        }
        public abstract void Update(GameTime gameTime);
        public abstract void UpdateDead(GameTime gameTime);
        public abstract void Draw(SpriteBatch batch);
        public abstract void DrawDead(SpriteBatch batch);

    }
}
