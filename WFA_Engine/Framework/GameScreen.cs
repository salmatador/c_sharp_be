using System;
using System.Diagnostics;
using System.Drawing;

namespace WFA_Engine.Framework
{
    internal abstract class GameScreen
    {
        public AbstractGame game { get; private set; }
        public GameGraphics g { get; private set; }

        public GameScreen(AbstractGame abstractGame)
        {
            this.game = abstractGame;
            g = game.graphics;

        }

        internal abstract void Update(float delta);

        internal abstract void Draw(float delta);

        internal abstract void ChangeScreen();
        
    }
}