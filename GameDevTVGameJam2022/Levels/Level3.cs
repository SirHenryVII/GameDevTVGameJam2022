using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevTVGameJam2022
{
    class Level3 : Level
    {
        public Level3() : base(3, new Vector2(10, Game1.Graphics.PreferredBackBufferHeight - 100))
        {
            BothTileList.Add(new Cobblestone(new Vector2(0, 1000), 5, true));
            BothTileList.Add(new Cobblestone(new Vector2(80, 1000), 5, true));

            BothTileList.Add(new Lava(new Vector2(80 * 2, 1005), 5 * 16, true));
            BothTileList.Add(new Lava(new Vector2(80 * 3, 1005), 5 * 16, true));
            BothTileList.Add(new Lava(new Vector2(80 * 4, 1005), 5 * 16, true));
            BothTileList.Add(new Lava(new Vector2(80 * 5, 1005), 5 * 16, true));
            BothTileList.Add(new Lava(new Vector2(80 * 6, 1005), 5 * 16, true));
            BothTileList.Add(new Lava(new Vector2(80 * 7, 1005), 5 * 16, true));
            BothTileList.Add(new Lava(new Vector2(80 * 8, 1005), 5 * 16, true));
            BothTileList.Add(new Lava(new Vector2(80 * 9, 1005), 5 * 16, true));
            BothTileList.Add(new Lava(new Vector2(80 * 10, 1005), 5 * 16, true));
            BothTileList.Add(new Lava(new Vector2(80 * 11, 1005), 5 * 16, true));
            BothTileList.Add(new Lava(new Vector2(80 * 12, 1005), 5 * 16, true));
            BothTileList.Add(new Lava(new Vector2(80 * 13, 1005), 5 * 16, true));
            BothTileList.Add(new Lava(new Vector2(80 * 14, 1005), 5 * 16, true));
            BothTileList.Add(new Lava(new Vector2(80 * 15, 1005), 5 * 16, true));
            BothTileList.Add(new Lava(new Vector2(80 * 16, 1005), 5 * 16, true));
            BothTileList.Add(new Lava(new Vector2(80 * 17, 1005), 5 * 16, true));
            BothTileList.Add(new Lava(new Vector2(80 * 18, 1005), 5 * 16, true));
            BothTileList.Add(new Lava(new Vector2(80 * 19, 1005), 5 * 16, true));
            BothTileList.Add(new Lava(new Vector2(80 * 20, 1005), 5 * 16, true));
            BothTileList.Add(new Lava(new Vector2(80 * 21, 1005), 5 * 16, true));

            BothTileList.Add(new Cobblestone(new Vector2(80 * 22, 1000), 5, true));
            BothTileList.Add(new Cobblestone(new Vector2(80 * 23, 1000), 5, true));

            BothTileList.Add(new Goal(new Vector2(1800, 830), 6, true));
        }
    }   
}       

