using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFA_Engine.Framework;

namespace WFA_Engine.GameScreens
{
    class testScreen : GameScreen
    {
        Rectangle test1;
        Rectangle test2;

        public testScreen(AbstractGame abstractGame) : base(abstractGame)
        {
            
            test1 = new Rectangle(0, 0, 100, 100);
            test2 = new Rectangle(200, 200, 100, 100);
        }

        internal override void ChangeScreen()
        {
            game.renderer.pause();
            game.loadScreen(new blueScreen(game));
            if (game.renderer.isRenderPaused())
            {
                game.renderer.resume();
            }
        }

        internal override void Draw(float delta)
        {
            g.clearScreen(Color.DarkGray);

            g.pen.Color = Color.White;
            g.brush.Color = Color.LightGray;

            g.drawRect(test1);
            g.fillRect(test2);


        }

        internal override void Update(float delta)
        {
            
            
            MouseEventArgs moveE = game.inputs.lastMouseEvent;
            MouseEventArgs clickE = game.inputs.lastMouseClickEvent;
            KeyEventArgs keyE = game.inputs.lastKeyEvent;

            if(keyE != null)
            {
                Debug.WriteLine("Key Down");
                ChangeScreen();
                game.inputs.lastKeyEvent = null;
            }
            if (clickE != null && clickE.Clicks > 0)
            {
                Debug.WriteLine("Called Click");
                clickE = null;
              //  ChangeScreen();
            }
            if (moveE != null)
            {
                test1 = new Rectangle(moveE.X - 50 / 2, moveE.Y- 50 /2, 50, 50);
                moveE = null;
                Debug.WriteLine("Called Move");
            }
        }
    }
}
