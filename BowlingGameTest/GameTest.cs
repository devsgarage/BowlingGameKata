using BowlingGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGameTest
{
    [TestClass]
    public class GameTest
    {
        static Game game;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
        }


        [TestInitialize]
        public void Init()
        {
            game = new Game();
        }

        private void Roll(int rolled, int rollTimes)
        {
            for (int i = 0; i < rollTimes; i++)
            {
                game.Roll(rolled);
            }
        }

        [TestMethod]
        public void GutterGameTest()
        {
            Roll(0, 20);
            Assert.AreEqual(0, game.Total);
        }

        [TestMethod]
        public void AllOnesTest()
        {
            Roll(1, 20);
            Assert.AreEqual(20, game.Total);
        }

        [TestMethod]
        public void TestOneSpare()
        {
            game.Roll(5);
            game.Roll(5);
            game.Roll(2);
            Roll(0, 17);
            Assert.AreEqual(14, game.Total);
        }

        [TestMethod]
        public void TestOneStrike()
        {
            game.Roll(10);
            game.Roll(2);
            game.Roll(2);
            Roll(0, 16);
            Assert.AreEqual(18, game.Total);
        }

        [TestMethod]
        public void TestPerfectGame()
        {
            Roll(10, 12);
            Assert.AreEqual(300, game.Total);
        }
    }
}
