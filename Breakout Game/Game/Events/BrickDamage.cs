using System;
using Breakout_Game.Game.Forms;

namespace Breakout_Game.Game.Events{
    public sealed class BrickDamage : Event{
        internal static event EventHandler Handler;
        
        internal Brick Brick{ get; private set; }
        internal int DamageAmount{ get; private set; }
        

        internal BrickDamage(Brick brick, int amount){
            this.Brick = brick;
            this.DamageAmount = amount;
            Handler?.Invoke(this, EventArgs.Empty);
        }

        public EventHandler GetHandler(){
            return Handler;
        }
    }
}