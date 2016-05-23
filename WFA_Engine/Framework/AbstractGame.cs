using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFA_Engine.GameScreens;

namespace WFA_Engine.Framework
{
    class AbstractGame
    {
        private const int GAME_WIDTH = 800;
        private const int GAME_HEIGHT = 600;

        private Bitmap canvas;
        public GameRenderer renderer { get; private set; }
        public GameInputs inputs { get; private set; }

        public GameScreen screen { get; set; }
        public GameGraphics graphics { get; private set; }
        public float scaleY { get;  private set; }
        public float scaleX { get;  private set; }
        public Form app { get; internal set; }
        //public Graphics g { get; private set; }
        public AbstractGame(Form app)
        {
            this.app = app;
            //g = app.CreateGraphics();
            // Could Do Somethin here

            //Auto Call Init so we don't forget 
            init();
        }

        internal void dispose()
        {
            renderer.pause();
            screen = null;
            inputs = null;
            graphics = null;
            canvas = null;
        }

        public void init()
        {
            canvas = new Bitmap(GAME_WIDTH, GAME_HEIGHT, PixelFormat.Format24bppRgb);
            graphics = new GameGraphics(canvas);
            renderer = new GameRenderer(this, scaleX = 0.0f, scaleY = 0.0f);
            inputs = new GameInputs(this);
            loadScreen(new testScreen(this));
        }

        public void loadScreen(GameScreen screen)
        {
            this.screen = screen;
        }

        public void start()
        {
            renderer.start();
        }
    }
}
