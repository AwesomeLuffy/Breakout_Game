namespace Breakout_Game.Game{
    interface ICancellable{
        bool IsCancelled();
        void SetCancelled();
        void SetCancelled(bool cancelled);

    }
}