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
            AliveTileList.Add(new Cobblestone(new Vector2(450, 1000), 5, true));
            AliveTileList.Add(new Spike(new Vector2(500, 1000), 5, true));
            DeadTileList.Add(new AlivePlatform(new Vector2(450, 1000), 5, false));
        }

    }
}
