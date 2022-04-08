using System;

namespace Breakout_Game.Game{
    public sealed class Ev : Event{
        private static event EventHandler TestHandler;

        public Ev() {
            TestHandler += EventListener.OnTestEv;
            TestHandler?.Invoke(this, EventArgs.Empty);
        }

        public EventHandler GetHandler(){
            return TestHandler;
        }
    }
}