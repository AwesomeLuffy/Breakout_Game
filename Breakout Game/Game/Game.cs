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
        internal static bool IsGameStarted = false;
        internal static bool IsGameInProgress;
        internal static bool IsGameOver = false;
        internal static bool IsGameWin = false;
        internal static bool IsLevelChoosed = false;

        internal static Racket Racket;

        internal static int ActualLevelNumber;
        internal static int PointCounter = 0;
        internal static int BallCounter = 3;

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
            this._gameWindow.MouseDown += UserControl.OnMouseDown;
            Log.Send("Game", "Game started", LogType.Warn);
            this._gameWindow.Run(1.0/60.0);
            
        }

        private void Load(object sender, EventArgs e){
            GL.ClearColor(.9f, .9f, .9f, .9f);
            GL.Enable(EnableCap.Texture2D);
            
            TextManager.init();
            new Thread((AudioManager.init)).Start();

            ball = new Ball();

            Racket = new Racket();
            
            IsGameInProgress = true;
            
            AudioManager.BackgroundSound.play();
            
            Log.Send("Game", "Game loaded !", LogType.Success);
        }

        [SuppressMessage("ReSharper.DPA", "DPA0001: Memory allocation issues")]
        private void Update(object sender, EventArgs e){
            if (Game.IsLevelChoosed) {
                UserControl.AnyKeyDown();
                TextManager.CompteurPoint.setText(PointCounter.ToString() + " pts");
                TextManager.CompteurBall.setText(BallCounter.ToString() + " ball");
                if (!Game.IsGamePause && Game.IsGameStarted) {
                    if (IsGameInProgress) {
                        if (ball.isActivated) {
                            ball.Update();
                            if (Colisions.checkColisions()) {
                                AudioManager.BouncSound.play();
                            }
                        }
                    }
                }
            }
        }

        private void Render(object sender, EventArgs eventArgs){
            GL.Clear(ClearBufferMask.ColorBufferBit);

            TextManager.CompteurPoint.Draw();
            TextManager.CompteurBall.Draw();
            
            Racket.Draw();

            if (Game.IsLevelChoosed) {
                if (LevelManager.Level != null) {
                    foreach (List<Brick> firstBrick in LevelManager.Level.bricks) {
                        foreach (Brick brick1 in firstBrick) {
                            brick1?.Draw();
                        }
                    }
                }

            }

            
            if (IsGameInProgress)
            {
                if (ball.isActivated)
                {
                    ball.Draw();
                }

                if (IsGameWin)
                {
                    AudioManager.BackgroundSound.stop();
                    AudioManager.VictorySound.play();
                    IsGameInProgress = false;
                }
                
                if (IsGameOver)
                {
                    
                    AudioManager.BackgroundSound.stop();
                    AudioManager.GameOverSound.play();
                    
                    IsGameInProgress = false;
                }
            }

            switch (MenuManager.ActualMenu) {
                case MenuStart _:
                    if (!Game.IsGameStarted) {
                        MenuManager.ActualMenu.Draw();
                    }
                    break;
                case MenuPause _: {
                    if (Game.IsGamePause) {
                        MenuManager.ActualMenu.Draw();
                    }
                    break;
                }
                case MenuLevel _:
                    if (!Game.IsLevelChoosed) {
                        MenuManager.ActualMenu.Draw();
                    }
                    break;
            }
            this._gameWindow.SwapBuffers();
        }

        public static void CallEvent(Event e){ //If an event called ...
            Log.Send("Game", "Event Called " + e, LogType.Info);
        }

        public static void GameAction(GameAction action, object[] parameters = null){
            switch (action) {
                case Utils.GameAction.Pause:
                    Game.IsGamePause = true;
                    break;
                case Utils.GameAction.Resume:
                    Game.IsGamePause = false;
                    break;
                case Utils.GameAction.Start:
                    Game.IsGameStarted = true;
                    break;
                case Utils.GameAction.Back://Back from a level just generated
                    if (MenuManager.ActualMenu is MenuStart || MenuManager.ActualMenu is MenuPause) {
                        Game.IsGameStarted = false;
                        Game.IsLevelChoosed = false;
                        MenuManager.ChangeMenu("level");
                    }
                    break;
                case Utils.GameAction.GenerateLevel:
                    try {
                        ActualLevelNumber = (int) parameters[0];
                        LevelManager.GenerateLevel(ActualLevelNumber);
                        Game.IsLevelChoosed = true;
                        MenuManager.ChangeMenu("start");
                        Game.GameAction(Utils.GameAction.Init);
                    }
                    catch (Exception e) {
                        Log.Send("Game", "Error for Action : " + action + "\n " + e, LogType.Error);
                    }
                    break;
                case Utils.GameAction.Init:
                    Game.IsGameStarted = false;
                    Racket.SetBasePos();
                    ball.setPosition();
                    ball.isActivated = true;
                    break;
                case Utils.GameAction.Quit:
                    Log.Send("Game", "User quit the game, closing...", LogType.Info);
                    Environment.Exit(1);
                    break;
            }
        }
    }
}