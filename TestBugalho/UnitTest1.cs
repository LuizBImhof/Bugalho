using Bugalho;

namespace TestBugalho
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestBoardSimplePoints()
        {
            Game game = new();
            game.PlayValue(1, 5, 0);
            game.PlayValue(1, 3, 1);
            Assert.AreEqual(8, game.GetBoardPoints(1));
        }
        
        [TestMethod]
        public void TestBoardComplexPointsOnColumnA()
        {
            Game game = new();
            game.PlayValue(1, 3, 0);
            game.PlayValue(1, 2, 0);
            game.PlayValue(1, 3, 0);
            Assert.AreEqual(14, game.GetBoardPoints(1));
        }

        [TestMethod]
        public void TestFullBoardPoints()
        {
            Game game = new();
            game.PlayValue(2, 3, 1);
            game.PlayValue(2, 2, 1);
            game.PlayValue(2, 1, 0);
            game.PlayValue(2, 4, 2);
            game.PlayValue(2, 3, 1);
            game.PlayValue(2, 6, 2);
            game.PlayValue(2, 1, 0);
            game.PlayValue(2, 5, 2);
            game.PlayValue(2, 1, 0);
            Assert.AreEqual(38, game.GetBoardPoints(2));
        }

        [TestMethod]
        public void TestSimpleRemovalOfPoints()
        {
            Game game = new();
            game.PlayValue(1, 2, 0);
            game.PlayValue(2, 2, 0);
            Assert.AreEqual(2, game.GetBoardPoints(2));
            Assert.AreEqual(0, game.GetBoardPoints(1));
        }

        [TestMethod]
        public void TestComplexRemovalOfPoints()
        {
            Game game = new();
            game.PlayValue(1, 2, 0);
            game.PlayValue(1, 2, 0);
            game.PlayValue(1, 2, 0);
            game.PlayValue(2, 2, 0);
            Assert.AreEqual(2, game.GetBoardPoints(2));
            Assert.AreEqual(0, game.GetBoardPoints(1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]  
        public void TestPlayingMoreThanThreeOnSameColumn()
        {
            Game game = new();
            game.PlayValue(1,2,0);
            game.PlayValue(1,2,0);
            game.PlayValue(1,2,0);
            game.PlayValue(1,2,0);
            Assert.AreEqual(18, game.GetBoardPoints(1));
        }
    }
}