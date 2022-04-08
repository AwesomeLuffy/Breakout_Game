using System;

namespace Breakout_Game.Game{
    public abstract class EventTest{
        protected string EventName = null;
        private bool _isCancelled = false;

        protected EventTest(string eventName){
            this.EventName = eventName;
        }
        
        public string GetEventName(){
            return this.EventName ?? this.GetType().Name;
        }
        
    }
}