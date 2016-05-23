using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFA_Engine.Framework;

namespace WFA_Engine
{
    public partial class Form1 : Form
    {
        AbstractGame game;
        
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            game = new AbstractGame(this);
            game.start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(game.graphics.canvas, 0, 0);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            game.dispose();
        }
    }
}
