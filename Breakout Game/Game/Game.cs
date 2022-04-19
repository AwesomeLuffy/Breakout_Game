using System;
using Breakout_Game.Audio;
using Breakout_Game.Game.Events;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Threading;
using Breakout_Game.Game.Text;

namespace Breakout_Game.Game{
    internal sealed class Game : GameBase{
        private static Game _gmInstance = null;
        private readonly GameWindow _gameWindow;
        
        internal static Game GetInstance (GameWindow gw){
            //?? -> is null
            return Game._gmInstance ?? (Game._gmInstance = new Game(gw));
        }
        
        private Game(GameWindow gameWindow) : base(gameWindow){
            this._gameWindow = gameWindow;
            this.Start();
        }

        private void Start(){
            EventListener.InitEventListener();
            this._gameWindow.Load += this.Load;
            this._gameWindow.UpdateFrame += this.Update;
            this._gameWindow.RenderFrame += this.Render;
            this._gameWindow.Resize += base.Resize;

            this._gameWindow.Run(1.0/60.0);
        }

        private void Load(object sender, EventArgs e){
            //TODO
            GL.ClearColor(.75f, .75f, .75f, 1.0f);
            GL.Enable(EnableCap.Texture2D);
            AudioManager.init();
            TextManager.init();
        }

        private void Update(object sender, EventArgs e){
            //TextManager.TestText.setTxt();
        }

        private void Render(object sender, EventArgs e){
            GL.Clear(ClearBufferMask.ColorBufferBit);

            this._gameWindow.SwapBuffers();
        }

        public static void CallEvent(Event e){ 
            //If an event called ...
        }
        
        

    }
}