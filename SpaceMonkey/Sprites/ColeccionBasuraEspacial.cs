using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace SpaceMonkey.Sprites
{
    public class ColeccionBasuraEspacial : Actualizable
    {
        protected static Random random;
        protected int time;
        TimeSpan nubetime;
        public ColeccionBasuraEspacial()
        {
            if (random == null)
                random = new Random();
            time = random.Next(0, 150);
        }

        public void Update(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.Subtract(nubetime).Milliseconds >=time)
            {
                nubetime = gameTime.TotalGameTime;
                Game1.TheGame.Actualizaciones.Add(new BasuraEspacial());
                time = random.Next(600, 900);
            }
        }
    }
}
