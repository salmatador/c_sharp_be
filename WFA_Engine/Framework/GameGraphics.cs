using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace WFA_Engine.Framework
{
    internal class GameGraphics
    {
        public Bitmap canvas { get; private set; }
        public Graphics graphics { get; private set; }
        public Pen pen { get; set;}
        public SolidBrush brush { get; set; }
        public GameGraphics(Bitmap canvas)
        {
            this.canvas = canvas;
            pen = new Pen(Color.White, 1.0f);
            brush = new SolidBrush(Color.Green);
            graphics = Graphics.FromImage(canvas);

            
        }

        public void clearScreen(Color color)
        {
            pen.Color = color;
            brush.Color = color;
            drawRect(pen, getBounds());
            fillRect(brush, getBounds());
        }

        public void drawRect(Pen p, Rectangle rect)
        {
            graphics.DrawRectangle(p, rect);
        }

        public void drawRect(Rectangle rect)
        {
            graphics.DrawRectangle(pen, rect);
        }

        public void fillRect(Brush b, Rectangle rect)
        {
            graphics.FillRectangle(b, rect);
        }

        public void fillRect(Rectangle rect)
        {
            graphics.FillRectangle(brush, rect);
        }

        public void resizeCanvas(int width, int height)
        {
            canvas = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            graphics = Graphics.FromImage(canvas);
        }

        private Rectangle getBounds()
        {
            return new Rectangle(0, 0, 800, 600);
        }
    }
}