using System;

namespace Breakout_Game.Game{
    public abstract class Event{
        protected string EventName = null;
        private bool _isCancelled = false;

        protected Event(){ }
        
        public string GetEventName(){
            return this.EventName ?? this.GetType().Name;
        }

        public bool IsCancelled(){
            if (!(this is ICancellable)) {
                throw new Exception("This event is not cancellable.");
            }

            return this._isCancelled;
        }

        public void SetCancelled(){
            this.SetCancelled(true);
        }

        public void SetCancelled(bool value){
            if (!(this is ICancellable)) {
                throw new Exception("This event is not cancellable.");
            }

            this._isCancelled = true;
        }
        
    }
}