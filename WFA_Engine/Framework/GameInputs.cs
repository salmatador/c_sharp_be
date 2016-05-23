using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace WFA_Engine.Framework
{
    internal class GameInputs
    {
        private AbstractGame game;
        public MouseEventArgs lastMouseEvent { get; set; }
        public MouseEventArgs lastMouseClickEvent { get; set; }
        public KeyEventArgs lastKeyEvent { get; set; }
        public GameInputs(AbstractGame abstractGame)
        {
            this.game = abstractGame;
            game.app.MouseMove += mouse_event;
            game.app.MouseClick += mouse_click_event;
            game.app.KeyDown += key_down;
            //System.ev events = game.app.KeyDown();
        }

        private void mouse_click_event(object sender, MouseEventArgs e)
        {
            lastMouseClickEvent = e;
            
            e = null;
        }

        private void key_down(object sender, KeyEventArgs e)
        {
            
            lastKeyEvent = e;
            e = null;
        }

        private void mouse_event(object sender, MouseEventArgs e)
        {
            //Debug.WriteLine("Mouse Events Just Happened");
            lastMouseEvent = e;
            e = null;
        }

        
        
    }
}
