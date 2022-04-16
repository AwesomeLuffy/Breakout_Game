using System;
using Breakout_Game.Game.Forms;

namespace Breakout_Game.Game.Events{
    public sealed class CreateFormEvent : Event{
        private static event EventHandler Handler;

        private readonly BaseForm _form;

        internal CreateFormEvent(BaseForm form){
            this._form = form;
            Handler += EventListener.OnFormCreate;
            Handler?.Invoke(this, EventArgs.Empty);
        }

        public EventHandler GetHandler(){
            return Handler;
        }

        internal BaseForm GetForm(){
            return this._form;
        }

        internal Type GetTypeInstance(){
            return this._form.GetType();
        }
        
        
    }
}