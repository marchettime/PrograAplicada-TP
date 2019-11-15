using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;


namespace SpaceMonkey.Sprites
{
    public class Banana: RectanguloAnimacion
    {
        Mono mono;
        bool firstRun = true;
        public Banana(Mono dueño,int XE, int YE)
        {
            mono = dueño;
            Image = Game1.TheGame.Content.Load<Texture2D>("Images/banana_shoot");
            Rectangle = new Rectangle(XE, YE, 50, 50);
            Vida = 100;
            var w = Image.Width / 12;
            for (int i = 0; i < 12; i++)
            {
                rectangulos.Add(new Rectangle(w * i, 0, w, Image.Height));
            }
        }
        TimeSpan frametime; 
        public override void Update(GameTime gameTime)
        {
            if (firstRun)
            {
                SoundEffect sonido = Game1.TheGame.Sounds[Game1.Sonidos.Disparo];
                sonido.CreateInstance();
                sonido.Play();
                firstRun = false;
            }
                if (gameTime.TotalGameTime.Subtract(frametime).Milliseconds > 60)
            {
                frametime = gameTime.TotalGameTime;
                selectedRectangle++;
                if (selectedRectangle > 11)
                    selectedRectangle = 0;
            }
            #region coordenadas

            int x = Rectangle.X;
            x += 4;

            Rectangle = new Rectangle(x, Rectangle.Y,
                Rectangle.Width, Rectangle.Height);

            if (Rectangle.X < -100 || Rectangle.X>999)
            {
                Game1.TheGame.Actualizaciones.Add(this);
            }

            #endregion
            #region Colision
            foreach (var item in Game1.TheGame.sprites)
            {
                Ovnis bomba = item as Ovnis;
                if (bomba != null /*item is Bomba*/)
                {
                    if (bomba.Rectangle.Intersects(Rectangle))
                    {
                        bomba.Vida -= 50;
                        mono.Score += 10;
                        Game1.TheGame.Actualizaciones.Add(this);
                        break;
                    }
                }
            }
            #endregion

        }

        public override void Draw(GameTime gameTime)
        {
                     Game1.TheGame.spriteBatch.Draw(Image, Rectangle, rectangulos[selectedRectangle], Color);
        }

    }
}
