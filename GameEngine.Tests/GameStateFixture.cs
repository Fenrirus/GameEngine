using System;

namespace GameEngine.Tests
{
    public class GameStateFixture : IDisposable
    {
        public GameStateFixture()
        {
            State = new GameState();
        }

        public GameState State { get; private set; }

        public void Dispose()
        {
            //cleanup
        }
    }
}