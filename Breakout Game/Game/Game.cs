using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using Breakout_Game.Audio;
using Breakout_Game.Game.Events;
using Breakout_Game.Game.Forms;
using Breakout_Game.Game.Levels;
using Breakout_Game.Game.Text;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Breakout_Game.Game{
    internal sealed class Game : GameBase{
        private static Game _gmInstance = null;
        private readonly GameWindow _gameWindow;

        private Brick brick;
        private Brick bricks;
        private Brick brickss;
        private Ball ball;
        private Level first;

        
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
            GL.ClearColor(.75f, .75f, .75f, 1.0f);
            GL.Enable(EnableCap.Texture2D);
            
            new Thread(AudioManager.init).Start(); 
            //TODO
            this.brick = new Brick(new Vector2(-290, 140));
            this.bricks = new Brick(new Vector2(-80.0f, -40.0f));
            this.brickss = new Brick(new Vector2(-100, 100));
            
            TextManager.init();
            
            LevelManager.CreateFirstLevel();
            this.first = LevelManager.GetFirstLevel();





        }

        private void Update(object sender, EventArgs e){
        }

        private void Render(object sender, EventArgs eventArgs){
            GL.Clear(ClearBufferMask.ColorBufferBit);

            foreach (List<Brick> firstBrick in this.first.bricks) {
                foreach (Brick brick1 in firstBrick) {
                    brick1?.Draw();
                }
            }
            
            TextManager.TestText.Draw();
            
            //this.brick.Draw();

            this._gameWindow.SwapBuffers();
        }

        public static void CallEvent(Event e){ //If an event called ...
        }
        
        

    }
}