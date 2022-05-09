using System;
using Breakout_Game.Game.Forms;

namespace Breakout_Game.Game.Events{
    public sealed class RacketUpdate : Event, ICancellable{
        internal static event EventHandler Handler;

        
        private Racket _racket{ get; set; }
        internal Racket Racket{
            get => _racket;
            set {
                _racket = value;
                Handler?.Invoke(this, EventArgs.Empty);
            }
        }

        internal RacketUpdate(Racket racket){
            this.Racket = racket;
        }

        public EventHandler GetHandler(){
            return Handler;
        }
    }
}