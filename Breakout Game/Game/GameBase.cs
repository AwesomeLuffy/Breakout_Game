using System;
using Breakout_Game.Game.Utils;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Breakout_Game.Game{
    public abstract class GameBase{
        private readonly GameWindow _gameWindow;
        public const int WindowOrthoMinWidth = -300;
        public const int WindowOrthoMaxWidth = 300;
        public const int WindowOrthoMinHeight = -150;
        public const int WindowOrthoMaxHeight = 150;

        protected GameBase(GameWindow gameWindow){
            this._gameWindow = gameWindow;
        }

        protected void Resize(object sender, EventArgs eventArgs){
            GL.Viewport(0, 0, this._gameWindow.Width, this._gameWindow.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(WindowOrthoMinWidth, WindowOrthoMaxWidth, WindowOrthoMinHeight, WindowOrthoMaxHeight, -1.0, 1.0);
            GL.MatrixMode(MatrixMode.Modelview);
            Log.Send("GameBase",
                "Becareful, depending of your device, the mouse click coordinate should not work correctly and menu will not be as exact position.",
                LogType.Warn);
        }


    }
}