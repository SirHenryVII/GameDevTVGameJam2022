using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevTVGameJam2022
{
    public class Level1 : Level
    {
        public Level1() : base(3, new Vector2(10, Game1.Graphics.PreferredBackBufferHeight - 100))
        {
            BothTileList.Add(new Cobblestone(new Vector2(0, 1000), 5, true));
            BothTileList.Add(new Cobblestone(new Vector2(80 * 1, 1000), 5, true));
            BothTileList.Add(new Cobblestone(new Vector2(80 * 2, 1000), 5, true));
            BothTileList.Add(new Cobblestone(new Vector2(80 * 3, 1000), 5, true));
            BothTileList.Add(new Cobblestone(new Vector2(80 * 4, 1000), 5, true));
            BothTileList.Add(new Cobblestone(new Vector2(80 * 5, 1000), 5, true));
            BothTileList.Add(new Cobblestone(new Vector2(80 * 6, 1000), 5, true));
            BothTileList.Add(new Cobblestone(new Vector2(80 * 7, 1000), 5, true));

            AliveTileList.Add(new Lava(new Vector2(80 * 8, 1005), 5*16, true));
            AliveTileList.Add(new Lava(new Vector2(80 * 9, 1005), 5*16, true));
            AliveTileList.Add(new Lava(new Vector2(80 * 10, 1005), 5*16, true));
            AliveTileList.Add(new Lava(new Vector2(80 * 11, 1005), 5*16, true));
            AliveTileList.Add(new Lava(new Vector2(80 * 12, 1005), 5*16, true));
            AliveTileList.Add(new Lava(new Vector2(80 * 13, 1005), 5*16, true));
            AliveTileList.Add(new Lava(new Vector2(80 * 14, 1005), 5*16, true));
            AliveTileList.Add(new Lava(new Vector2(80 * 15, 1005), 5*16, true));
            AliveTileList.Add(new Lava(new Vector2(80 * 16, 1005), 5*16, true));

            BothTileList.Add(new Cobblestone(new Vector2(80 * 17, 1000), 5, true));
            BothTileList.Add(new Cobblestone(new Vector2(80 * 18, 1000), 5, true));
            BothTileList.Add(new Cobblestone(new Vector2(80 * 19, 1000), 5, true));
            BothTileList.Add(new Cobblestone(new Vector2(80 * 20, 1000), 5, true));
            BothTileList.Add(new Cobblestone(new Vector2(80 * 21, 1000), 5, true));
            BothTileList.Add(new Cobblestone(new Vector2(80 * 22, 1000), 5, true));
            BothTileList.Add(new Cobblestone(new Vector2(80 * 23, 1000), 5, true));

            AliveTileList.Add(new Spike(new Vector2(300, 957), 4, true));
            AliveTileList.Add(new Spike(new Vector2(370, 957), 4, true));
            AliveTileList.Add(new Spike(new Vector2(440, 957), 4, true));

            DeadTileList.Add(new AlivePlatform(new Vector2(880, 880), 4, false));
        }

    }
}
