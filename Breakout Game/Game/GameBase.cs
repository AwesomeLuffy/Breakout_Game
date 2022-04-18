using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Breakout_Game.Game{
    public abstract class GameBase{
        private readonly GameWindow GameWindow;

        protected GameBase(GameWindow gameWindow){
            this.GameWindow = gameWindow;
        }

        protected void Resize(object sender, EventArgs eventArgs){
            GL.Viewport(0, 0, this.GameWindow.Width, this.GameWindow.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-300.0, 300.0, -150.0, 150, -1.0, 1.0);
            GL.MatrixMode(MatrixMode.Modelview);
        }


    }
}