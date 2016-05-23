using System;
using System.Diagnostics;
using System.Threading;

namespace WFA_Engine.Framework
{
    internal class GameRenderer
    {
        private AbstractGame game;
        private float scaleX { get; set; }
        private float scaleY { get; set; }

        Thread gameThread;
        bool isRunning;
        public bool isPaused { get; set; }

        public GameRenderer(AbstractGame abstractGame, float scaleX, float scaleY)
        {
            this.game = abstractGame;
            this.scaleX = scaleX;
            this.scaleY = scaleY;
            this.isPaused = true;
        }

        internal bool isRenderPaused()
        {
            return isPaused;
        }

        public void start()
        {
            isPaused = false;
            isRunning = true;
            gameThread = new Thread(run);
            gameThread.Start();

        }

        public void pause()
        {
            isPaused = true;
            isRunning = false;
            gameThread.Join();
            gameThread = null;
        }

        public void resume()
        {
            start();
            Debug.WriteLine("Resume Called");
        }

        public void run()
        {
            Stopwatch tickTimer = Stopwatch.StartNew();

            while(isRunning && gameThread == Thread.CurrentThread)
            {
                float delta = tickTimer.ElapsedMilliseconds;

                game.screen.Update(delta);
                game.screen.Draw(delta);

                
                game.app.Invalidate();

                tickTimer.Restart();
                Thread.Sleep(100);
            }

        }
    }
}