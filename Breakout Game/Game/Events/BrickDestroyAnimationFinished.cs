using System;
using Breakout_Game.Game.Forms;

namespace Breakout_Game.Game.Events{
    public sealed class BrickDestroyAnimationFinished : Event{
        internal static event EventHandler Handler;
        internal Brick Brick{ get; private set; }

        internal BrickDestroyAnimationFinished(Brick brick){
            this.Brick = brick;
            Handler?.Invoke(this, EventArgs.Empty);
        }

        public EventHandler GetHandler(){
            return Handler;
        }
        
    }
}