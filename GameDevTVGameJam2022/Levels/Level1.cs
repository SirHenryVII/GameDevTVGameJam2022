﻿using Microsoft.Xna.Framework;
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
            AliveTileList.Add(new AlivePlatform());
        }

    }
}
