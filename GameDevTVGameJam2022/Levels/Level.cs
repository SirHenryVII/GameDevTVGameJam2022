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

        public Player player;

        public Level(int lives)
        {
            player = new Player(new Vector2(400), Color.White, 0.5, 3);
        }
        public void Update(GameTime gameTime)
        {
            player.Update(gameTime);

            foreach(Tile tile in AliveTileList)
            {
                tile.Update(gameTime);
            }

            foreach (Tile tile in AliveHurtTileList)
            {
                tile.Update(gameTime);
            }
        }
        public void UpdateDead(GameTime gameTime)
        {
            player.Update(gameTime);

            foreach (Tile tile in DeadTileList)
            {
                tile.Update(gameTime);
            }
        }
        public void Draw(SpriteBatch batch)
        {
            player.Draw(batch);

            foreach (Tile tile in AliveTileList)
            {
                tile.Draw(batch);
            }

            foreach (Tile tile in AliveHurtTileList)
            {
                tile.Draw(batch);
            }
        }
        public void DrawDead(SpriteBatch batch)
        {
            player.Draw(batch);

            foreach (Tile tile in DeadTileList)
            {
                tile.Draw(batch);
            }
        }

    }
}
