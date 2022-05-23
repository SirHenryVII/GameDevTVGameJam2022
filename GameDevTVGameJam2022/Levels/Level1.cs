using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevTVGameJam2022
{
    public class Level1 : Level
    {
        public Level1() : base(3)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
        }
        public override void Draw(SpriteBatch batch)
        {
            player.Draw(batch);
        }

        public override void UpdateDead(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public override void DrawDead(SpriteBatch batch)
        {
            throw new NotImplementedException();
        }
    }
}
