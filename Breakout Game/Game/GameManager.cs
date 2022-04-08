using System;
using OpenTK;

namespace Breakout_Game.Game{
    internal sealed class GameManager{
        private static GameManager _gmInstance = null;
        private readonly GameWindow _gameWindow;

        
        internal static GameManager GetInstance (GameWindow gw){
            //?? -> is null
            return GameManager._gmInstance ?? (GameManager._gmInstance = new GameManager(gw));
        }
        
        private GameManager(GameWindow gameWindow){
            this._gameWindow = gameWindow;
            this.Start();
        }

        private void Start(){
            TestEv eventTest = new TestEv();
            eventTest.TestHandler += this.OntestEvcall;
        }
        

        private void OntestEvcall(object sender, EventArgs e){
            Console.WriteLine("test");
        }

    }
}