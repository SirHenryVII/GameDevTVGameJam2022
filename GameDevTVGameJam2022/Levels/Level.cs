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
        public List<Tile> BothTileList = new List<Tile>();


        private Vector2 playerSpawnPos;
        public int Lives;

        public Player player;

        public Level(int lives, Vector2 playerspawnpos)
        {
            playerSpawnPos = playerspawnpos;
            Lives = lives;
            player = new Player(playerspawnpos, Color.White, 0.5, lives);
        }
        public void Update(GameTime gameTime)
        {
            foreach (Tile tile in AliveTileList)
            {
                tile.Update(gameTime);
            }

            foreach (Tile tile in DeadTileList)
            {
                tile.Update(gameTime);
            }

            foreach (Tile tile in BothTileList)
            {
                tile.Update(gameTime);
            }

            player.Update(gameTime);
        }

        public void Draw(SpriteBatch batch)
        {
            foreach (Tile tile in BothTileList)
            {
                tile.Draw(batch, 1f);
            }

            if (player.Alive)
            {
                foreach (Tile tile in AliveTileList)
                {
                    tile.Draw(batch, 1f);
                }

                foreach (Tile tile in DeadTileList)
                {
                    tile.Draw(batch, 0.3f);
                }
            }
            else
            {
                foreach (Tile tile in DeadTileList)
                {
                    tile.Draw(batch, 1f);
                }

                foreach (Tile tile in AliveTileList)
                {
                    tile.Draw(batch, 0.3f);
                }
            }

            player.Draw(batch);
        }

        public void Reload()
        {
            player = new Player(playerSpawnPos, Color.White, 0.5, Game1.currentLevel.Lives);
        }
    }
}
