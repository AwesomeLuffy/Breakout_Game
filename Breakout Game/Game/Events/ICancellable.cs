namespace Breakout_Game.Game.Events{
    internal interface ICancellable{
        bool IsCancelled();
        void SetCancelled();
        void SetCancelled(bool cancelled);

    }
}