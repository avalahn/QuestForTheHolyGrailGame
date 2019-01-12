using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuestForTheHolyGrailGame;

namespace UnitTestProject
{
    [TestClass]
    public class GameClassTests
    {
        [TestMethod]
        public void WorldIsCreated()
        {
            Game game = new Game();
            game.Run();
            Assert.IsNotNull(game.world);
        }

        [TestMethod]
        public void HeroIsCreated()
        {
            Game game = new Game();
            game.Run();
            Assert.IsNotNull(game.hero);
        }

        [TestMethod]
        public void HeroHasStats()
        {
            Game game = new Game();
            game.Run();
            Assert.IsNotNull(game.hero.name);
            Assert.IsNotNull(game.hero.heroType);
        }

        [TestMethod]
        public void EventIsTriggered()
        {
            Game game = new Game();
            game.Run();
            Assert.IsNotNull(game.currentEvent);
        }

        [TestMethod]
        public void GameEnentHasType()
        {
            Game game = new Game();
            game.Run();
            Assert.IsNotNull(game.currentEvent.type);
        }
    }
}
