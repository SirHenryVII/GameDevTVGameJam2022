using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace GameDevTVGameJam2022
{
    static class Textures
    {
        public static Texture2D Player;
        public static Texture2D PlatformAlive;
        public static Texture2D PlatformDead;
        public static Texture2D Cobblestone;
        public static Texture2D Spike;
        public static Texture2D Pixel;
        public static Texture2D Goal;
        public static Texture2D Background;

        public static void LoadTextures(ContentManager content)
        {
            Player = content.Load<Texture2D>("benboi");
            PlatformAlive = content.Load<Texture2D>("PlatformAlive");
            PlatformDead = content.Load<Texture2D>("PlatformDead");
            Cobblestone = content.Load<Texture2D>("Cobble");
            Spike = content.Load<Texture2D>("Spike");
            Pixel = content.Load<Texture2D>("pixel");
            Goal = content.Load<Texture2D>("Goal");
            Background = content.Load<Texture2D>("Background");
        }
    }
}
