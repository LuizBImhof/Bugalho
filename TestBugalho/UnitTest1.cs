using Bugalho;

namespace TestBugalho
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestBoards()
        {
            Game game = new();

            Assert.IsNotNull(game);
            Assert.AreEqual(3, game.boardA.columnA.Capacity);
            Assert.AreEqual(3, game.boardA.columnB.Capacity);
            Assert.AreEqual(3, game.boardA.columnC.Capacity);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]  
        public void TestPlayValueOnBoard()
        {
            Game game = new();
            game.PlayValue(1, 2, 0);
            game.PlayValue(1, 4, 0);
            game.PlayValue(1, 5, 0);
            
            Assert.AreEqual(2, game.boardA.columnA[0]);
            Assert.AreEqual(4, game.boardA.columnA[1]);
            Assert.AreEqual(5, game.boardA.columnA[2]);

            game.PlayValue(1, 2, 1);
            game.PlayValue(1, 4, 1);
            Assert.AreEqual(2, game.boardA.columnB[0]);
            Assert.AreEqual(4, game.boardA.columnB[1]);

            game.PlayValue(3, 5, 2);
            Assert.AreEqual(5, game.boardA.columnC[0]);
            Assert.AreEqual(0, game.boardA.columnC[1]);
            Assert.AreEqual(0, game.boardA.columnC[2]);
        }

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
            Console.WriteLine(game.ToString());
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
        public void TestRemovalOfPoints()
        {
            Game game = new();
            game.PlayValue(1, 2, 0);
            Console.WriteLine(game);
            game.PlayValue(2, 2, 0);
            Console.WriteLine(game);
            Assert.AreEqual(2, game.GetBoardPoints(2));
            Assert.AreEqual(0, game.GetBoardPoints(1));

        }
    }
}