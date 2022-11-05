namespace Bugalho
{
    public class Game
    {     
        
        public Board boardA;
        public Board boardB;

        public Game ()
        {
            this.boardA = new Board();
            this.boardB = new Board();
        }

        public int GetBoardPoints(int board)
        {
            int points = 0;
            if(board == 1)
            {
                points = GetPoints(boardA);
            }
            if(board == 2)
            {
                points = GetPoints(boardB);
            }
            return points;
        }

        private int GetPoints(Board board)
        {
            int points = board.GetPoints();
            return points;
        }

        public void PlayValue(int board, int value, int column)
        {
            if(board == 1)
            {
                boardA.PlayValue(value, column);
                boardB.RemoveValue(value, column);
            }
            if(board == 2)
            {
                boardB.PlayValue(value, column);
                boardA.RemoveValue(value, column);
            }

        }

        public override string? ToString()
        {
            string? result = boardA.ToString() + Environment.NewLine + boardB.ToString();
            return result;
        }
    }
}