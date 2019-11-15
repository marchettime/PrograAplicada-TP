﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SpaceMonkey.Sprites
{
   public class ColecccionOvnis : Actualizable
    {
        protected static Random random;
        protected int time;
        TimeSpan bombatime;
        public ColecccionOvnis()
        {
            if (random == null)
                random = new Random();
            time = random.Next(0, 5);
        }

        public void Update(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.Subtract(bombatime).Seconds >= time)
            {
                bombatime = gameTime.TotalGameTime;
                Game1.TheGame.Actualizaciones.Add(new Ovnis());
                time = random.Next(2, 5);
            }
        }
    }
}
