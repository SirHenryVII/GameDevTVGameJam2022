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

        public Player player;

        public Level(int lives)
        {
            player = new Player(new Vector2(400), Color.White, 0.5, 3);
        }
        public void Update(GameTime gameTime)
        {
            player.Update(gameTime);

            if (player.Alive)
            {
                foreach (Tile tile in AliveTileList)
                {
                    tile.Update(gameTime);
                }
            }
            else
            {
                foreach (Tile tile in DeadTileList)
                {
                    tile.Update(gameTime);
                }
            }
        }

        public void Draw(SpriteBatch batch)
        {
            if (player.Alive)
            {
                foreach (Tile tile in AliveTileList)
                {
                    tile.Draw(batch);
                }
            }
            else
            {
                foreach (Tile tile in DeadTileList)
                {
                    tile.Draw(batch);
                }
            }

            player.Draw(batch);
        }
    }
}
