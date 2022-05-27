using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevTVGameJam2022
{
    class DeadMovingPlatform : Tile
    {
        private int Length;
        private int lengthCounter;
        private bool isLeft = true;
        private int Speed;
        public DeadMovingPlatform(Vector2 pos, int scale, bool alive, int length, int speed) : base(Textures.PlatformAlive, false)
        {
            HitBox = new Rectangle((int)pos.X, (int)pos.Y, Image.Width * scale, Image.Height * scale);
            Alive = alive;
            Length = length;
            Speed = speed;
        }

        public override void Update(GameTime gametime)
        {
            if (lengthCounter >= Length / Speed)
            {
                lengthCounter = 0;
                if (isLeft) isLeft = false;
                else isLeft = true;
            }

            if (isLeft) HitBox.X += Speed;
            else HitBox.X -= Speed;

            lengthCounter++;
        }
    }
}

