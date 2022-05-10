using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Breakout_Game.Audio;
using Breakout_Game.Game.Events;
using Breakout_Game.Game.Forms;
using Breakout_Game.Game.Levels;
using Breakout_Game.Game.Menu;
using Breakout_Game.Game.Text;
using Breakout_Game.Game.Texture;
using Breakout_Game.Game.UserInterac;
using Breakout_Game.Game.Utils;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using ThreadState = System.Diagnostics.ThreadState;

namespace Breakout_Game.Game{
    internal sealed class Game : GameBase{
        
        public static Ball ball;
        private static Game _gmInstance = null;
        private readonly GameWindow _gameWindow;

        internal static bool IsGamePause = false;

        internal static List<IRenderable> Renderables = new List<IRenderable>();

        internal static int ActualLevelNumber = 1;

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
            GL.ClearColor(.9f, .9f, .9f, .9f);
            GL.Enable(EnableCap.Texture2D);
            //TODO
            
            TextManager.init();
            new Thread((AudioManager.init)).Start();
            LevelManager.GenerateLevel(ref ActualLevelNumber);

            ball = new Ball(new Vector2(40.0f, -40.0f), 30, 30, "ball.bmp");

            Renderables.Add(new Racket());
        }

        [SuppressMessage("ReSharper.DPA", "DPA0001: Memory allocation issues")]
        private void Update(object sender, EventArgs e){
            UserControl.AnyKeyDown();
            if (!Game.IsGamePause) {
                if (ball.isActivated)
                {
                    ball.Update();
                }
                Colisions.checkColisions();
            }
        }

        private void Render(object sender, EventArgs eventArgs){
            GL.Clear(ClearBufferMask.ColorBufferBit);

            foreach (IRenderable renderable in Renderables) {
                renderable.Draw();
            }

            foreach (var renderable in Renderables) {
                if (renderable is Racket racket) {
                    var sides = racket.GetSides();
                }
            }

            foreach (List<Brick> firstBrick in LevelManager.Level.bricks) {
                foreach (Brick brick1 in firstBrick) {
                    brick1?.Draw();
                }
            }

            if (ball.isActivated)
            {
                ball.Draw();
            }

            if (Game.IsGamePause) {
                MenuManager.ActualMenu.DrawText();
            }

            this._gameWindow.SwapBuffers();
        }

        public static void CallEvent(Event e){ //If an event called ...
        }
        
    }
}