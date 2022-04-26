using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Breakout_Game.Audio;
using Breakout_Game.Game.Events;
using Breakout_Game.Game.Forms;
using Breakout_Game.Game.Levels;
using Breakout_Game.Game.Text;
using Breakout_Game.Game.Texture;
using Breakout_Game.Game.UserInterac;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using ThreadState = System.Diagnostics.ThreadState;

namespace Breakout_Game.Game{
    internal sealed class Game : GameBase{
        private static Game _gmInstance = null;
        private readonly GameWindow _gameWindow;

        internal static bool IsActive;
        internal static bool IsFinished;

        internal static List<IDrawable> Renderables = new List<IDrawable>();

        private static int ActualLevelNumber = 0;

        private Text.Text Text1;
        private Text.Text Text2;
        
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

            this._gameWindow.KeyDown += UserControl.OnKeyDown;

            this._gameWindow.Run(1.0/60.0);
        }

        private void Load(object sender, EventArgs e){
            GL.ClearColor(.75f, .75f, .75f, 1.0f);
            GL.Enable(EnableCap.Texture2D);
            //TODO
            
            TextManager.init();
            new Thread((AudioManager.init)).Start();
            LevelManager.GenerateFirstLevel();

            Brick brick = new Brick(new Vector2(0, 0), 1);
            Renderables.Add(new Racket());
        }

        private void Update(object sender, EventArgs e){
            if (Game.IsActive && !Game.IsFinished) {
                
            }
        }

        private void Render(object sender, EventArgs eventArgs){
            if(Game.IsFinished) return;

            GL.Clear(ClearBufferMask.ColorBufferBit);
            
            foreach (IRenderable renderable in Renderables) {
                renderable.Draw();
            }

            foreach (List<Brick> firstBrick in LevelManager._levels[ActualLevelNumber].bricks) {
                foreach (Brick brick1 in firstBrick) {
                    brick1?.Draw();
                }
            }

            this._gameWindow.SwapBuffers();
        }

        public static void CallEvent(Event e){ //If an event called ...
        }

        internal static void GameAction(string action){
            switch (action) {
                case "pause":
                    Game.IsActive = false;
                    //TODO Start menu
                    break;
                case "stop":
                    Game.IsActive = false;
                    Game.IsFinished = true;
                    break;
                default:
                    break;
            }
        }

    }
}