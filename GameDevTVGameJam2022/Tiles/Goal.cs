using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevTVGameJam2022
{
    public class Goal : Tile
    {
        public Goal(Vector2 pos, int scale, bool alive) : base(Textures.Goal, false)
        {
            HitBox = new Rectangle((int)pos.X, (int)pos.Y, Image.Width * scale, Image.Height * scale);
            Alive = alive;
        }
        public override void Update(GameTime gametime)
        {
            if (HitBox.Intersects(Game1.currentLevel.player.HitBox))
            {
                if (Game1.currentLevel is Level1) Game1.currentLevel = new Level2();
                else if (Game1.currentLevel is Level2) Game1.currentLevel = new Level3();
            }
        }
    }
}
