using System;

namespace Breakout_Game.Game.Events{
    public sealed class EvExemple : Event{
        private static event EventHandler TestHandler;

        public EvExemple() {
            TestHandler += EventListener.OnTestEv;
            TestHandler?.Invoke(this, EventArgs.Empty);
        }

        public EventHandler GetHandler(){
            return TestHandler;
        }
    }
}