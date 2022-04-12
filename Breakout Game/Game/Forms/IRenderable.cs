using System;

namespace Breakout_Game.Forms{
    /// <summary>
    /// Interface to implement the Draw method
    /// </summary>
    internal interface IRenderable{
        void Draw();
    }

    /// <summary>
    /// Interface to implement the Draw And Update method
    /// </summary>
    internal interface IUpdatable : IRenderable{
        void Update();
    }
}