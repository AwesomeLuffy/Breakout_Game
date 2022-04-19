namespace Breakout_Game.Game.Forms{
    /// <summary>
    /// Interface to implement the Draw method
    /// </summary>
    internal interface IDrawable{
        void Draw();
    }

    /// <summary>
    /// Interface to implement the Update method
    /// </summary>
    internal interface IUpdatable{
        void Update();
    }
    /// <summary>
    /// Interface to implement the Draw And Update method
    /// </summary>
    internal interface IRenderable : IUpdatable, IDrawable{
        
    }
}