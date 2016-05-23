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
    class blueScreen : GameScreen
    {
        Rectangle test1;
        Rectangle test2;

        public blueScreen(AbstractGame abstractGame) : base(abstractGame)
        {
            test1 = new Rectangle(0, 0, 100, 100);
            test2 = new Rectangle(200, 200, 100, 100);
        }

        internal override void ChangeScreen()
        {
            game.renderer.pause();
            game.loadScreen(new testScreen(game));
            
        }

        internal override void Draw(float delta)
        {
            g.clearScreen(Color.IndianRed);

            g.pen.Color = Color.White;
            g.brush.Color = Color.LightGray;

            g.drawRect(test1);
            g.fillRect(test2);
        }

        internal override void Update(float delta)
        {
            MouseEventArgs moveE = game.inputs.lastMouseEvent;
            MouseEventArgs clickE = game.inputs.lastMouseClickEvent;
            KeyEventArgs keyDown = game.inputs.lastKeyEvent;

            if(keyDown != null)
            {
                //game.loadScreen(new testScreen(game));
            }
            if (clickE != null && clickE.Clicks > 0)
            {

                //Debug.WriteLine(clickE.Button);
                game.inputs.lastMouseClickEvent = null;
                ChangeScreen();
            }
            if (moveE != null)
            {
                test1 = new Rectangle(moveE.X - 50 / 2, moveE.Y - 50 / 2, 50, 50);
                moveE = null;
                //Debug.WriteLine("Called Move");
            }
        }
    }
}
