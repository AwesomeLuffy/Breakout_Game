﻿using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Breakout_Game.Game{
    public abstract class GameBase{
        private readonly GameWindow GameWindow;
        public const int WindowOrthoMinWidth = -300;
        public const int WindowOrthoMaxWidth = 300;
        public const int WindowOrthoMinHeight = -150;
        public const int WindowOrthoMaxHeight = 150;

        protected GameBase(GameWindow gameWindow){
            this.GameWindow = gameWindow;
        }

        protected void Resize(object sender, EventArgs eventArgs){
            GL.Viewport(0, 0, this.GameWindow.Width, this.GameWindow.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(WindowOrthoMinWidth, WindowOrthoMaxWidth, WindowOrthoMinHeight, WindowOrthoMaxHeight, -1.0, 1.0);
            GL.MatrixMode(MatrixMode.Modelview);
        }


    }
}