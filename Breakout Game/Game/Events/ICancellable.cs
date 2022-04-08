namespace Breakout_Game.Game{
    internal interface ICancellable{
        bool IsCancelled();
        void SetCancelled();
        void SetCancelled(bool cancelled);

    }
}