using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace SpaceMonkey.Sprites
{
    public class BasuraEspacial : Sprite
    {
        public Texture2D Image2 { get; protected set; }
        public int tipo;
        public BasuraEspacial()
        {
            int size = random.Next(30, 60);
            Image = Game1.TheGame.Content.Load<Texture2D>("Images/satellite");
            Image2 = Game1.TheGame.Content.Load<Texture2D>("Images/meteorito");
            Rectangle = new Rectangle(
                Game1.TheGame.GraphicsDevice.Viewport.Width,
                random.Next(Game1.TheGame.GraphicsDevice.Viewport.Height - 80),
                size, size);
            Color = Color.White * 0.5f;
            tipo = random.Next(1, 3);
        }
        public override void Draw(GameTime gameTime)
        {
            if (tipo == 1)
                Game1.TheGame.spriteBatch.Draw(Image, Rectangle, Color);
            else
                Game1.TheGame.spriteBatch.Draw(Image2, Rectangle, Color);

        }

        public override void Update(GameTime gameTime)
        {
            int x = Rectangle.X;
            x -= 2;

            Rectangle = new Rectangle(x, Rectangle.Y, Rectangle.Width, Rectangle.Height);

            if (Rectangle.X < -200)
                Game1.TheGame.Actualizaciones.Add(this);
        }
    }
}
