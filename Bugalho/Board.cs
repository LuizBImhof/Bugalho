namespace Bugalho
{
    public class Board
    {

        public List<int> columnA;
        public List<int> columnB;
        public List<int> columnC;

        public Board()
        {
            columnA = new List<int>(3);
            columnB = new List<int>(3);
            columnC = new List<int>(3);
        }

        internal void PlayValue(int value, int column)
        {

            if (column == 0)
                columnA.Add(value);
            else if (column == 1)
                columnB.Add(value);
            else if (column == 2)
                columnC.Add(value);
        }

        internal void RemoveValue(int value, int column)
        {
            if (column == 0)
            {
                while (columnA.Contains(value))
                {
                    columnA.Remove(value);
                }
            }
            else if (column == 1)
            {
                while (columnB.Contains(value))
                {
                    columnB.Remove(value);
                }
            }
            else if (column == 2)
            {
                while (columnC.Contains(value))
                {
                    columnC.Remove(value);
                }
            }
        }

        public int CalculatePoints()
        {
            return CalculateCollumn(columnA) + CalculateCollumn(columnB) + CalculateCollumn(columnC);
        }

        private static int CalculateCollumn(List<int> column)
        {
            column.Sort();
            int columnAPoints = 0;
            if (column.Count == 1)
                columnAPoints = column[0];
            else if (column.Count == 2)
                columnAPoints = CalculateTwoValues(column);
            else if (column.Count == 3)
                columnAPoints = CalculateThreeValues(column);
            return columnAPoints;
        }

        private static int CalculateThreeValues(List<int> column)
        {
            int columnAPoints;
            if (ThreeSameValues(column))
            {
                columnAPoints = CalculateValueWhenAllThreeValuesAreTheSame(column[0]);
            }
            else if (FirstTwoSameValues(column))
            {
                columnAPoints = CalculateTwoOfTheSameValues(column[0]) + column[2];
            }
            else if (LastTwoSameValues(column))
            {
                columnAPoints = CalculateTwoOfTheSameValues(column[1]) + column[0];
            }
            else
            {
                columnAPoints = CalculateThreeDifferentValues(column);
            }

            return columnAPoints;
        }

        private static int CalculateTwoValues(List<int> column)
        {
            int columnAPoints;
            if (FirstTwoSameValues(column))
            {
                columnAPoints = CalculateTwoOfTheSameValues(column[0]);
            }
            else
            {
                columnAPoints = column[0] + column[1];
            }

            return columnAPoints;
        }

        private static int CalculateThreeDifferentValues(List<int> column)
        {
            return column[0] + column[1] + column[2];
        }

        private static int CalculateValueWhenAllThreeValuesAreTheSame(int value)
        {
            return 9 * value;
        }
                
        private static int CalculateTwoOfTheSameValues(int value)
        {
            return 4 * value;
        }

        private static bool LastTwoSameValues(List<int> column)
        {
            return column[1] == column[2];
        }

        private static bool FirstTwoSameValues(List<int> column)
        {
            return column[0] == column[1];
        }

        private static bool ThreeSameValues(List<int> column)
        {
            return column[0] == column[1] && column[1] == column[2];
        }

        public override string? ToString()
        {
            string result = string.Empty;
            for (int i = 0; i < 3; i++)
            {
                if (columnA.Count > i)
                    result += "|" + columnA[i] + "|";
                else
                    result += "|" + 0 + "|";
                if (columnB.Count > i)
                    result += columnB[i] + "|";
                else
                    result += 0 + "|";
                if (columnC.Count > i)
                    result += columnC[i] + "|";
                else
                    result += 0 + "|";
                result += Environment.NewLine;
            }
            return result;
        }
    }
        
}