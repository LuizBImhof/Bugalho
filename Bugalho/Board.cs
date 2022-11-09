using Newtonsoft.Json.Linq;

namespace Bugalho
{
    public class Board
    {

        public List<int> columnA;
        public List<int> columnB;
        public List<int> columnC;
        int points;

        public Board()
        {
            columnA = new List<int>(3);
            columnB = new List<int>(3);
            columnC = new List<int>(3);
            points = 0;
        }

        internal int GetPoints()
        {
            return points;
        }

        internal void PlayValue(int value, int column)
        {

            if (column == 0)
                columnA.Add(value);
            else if (column == 1)
                columnB.Add(value);
            else if (column == 2)
                columnC.Add(value);
            AddPoints(value, column);
        }

        private void AddPoints(int value, int column)
        {
            if (column == 0)
                CalculateAndAddColumnPoints(value, columnA);
            else if (column == 1)
                CalculateAndAddColumnPoints(value, columnB);
            else if (column == 2)
                CalculateAndAddColumnPoints(value, columnC);
        }

        internal void RemoveValue(int value, int column)
        {
            if (column == 0)
            {
                if (columnA.Contains(value))
                {
                    columnA.Remove(value);
                }
            }
            else if (column == 1)
            {

            }
            else if (column == 2)
            {

            }
            Console.WriteLine("points before removing: " + points);
            AddPoints(value, column);
            Console.WriteLine("points after removing: " + points);
        }

        private void CalculateAndAddColumnPoints(int value, List<int> column)
        {
            column.Sort();
            if (column.Count == 3)
                CalculatePointsWithThreeValuesInColumn(value, column);
            if (column.Count == 2)
                CalculatePontsWithTwoValuesInColumn(value, column);
            else
                CalculateSimplePoints(value);
        }

        private void CalculatePontsWithTwoValuesInColumn(int value, List<int> column)
        {
            if (CheckIfTwoOfTwoEqual(column))
                CalculatePointsWhenTwoOfTwoEqual(value);
            else
                CalculateSimplePoints(value);
        }

        private void CalculatePointsWithThreeValuesInColumn(int value, List<int> column)
        {
            if (CheckIfThreeEqual(column))
                CalculatePointsWhenThreeEqual(value);
            else if (CheckIfTwoOfThreeEqual(column))
                CalculatePointsWhenTwoOfThreeEqual(value);
        }

        private void CalculateSimplePoints(int value)
        {
            points += value;
        }

        private void CalculatePointsWhenTwoOfTwoEqual(int value)
        {
            points += 3 * value;
        }

        private void CalculatePointsWhenTwoOfThreeEqual(int value)
        {
            points += 2 * value;
        }

        private void CalculatePointsWhenThreeEqual(int value)
        {
            points -= 5 * value;
            points += (value * 3) * 3;
        }

        private static bool CheckIfTwoOfTwoEqual(List<int> column)
        {
            return column[0] == column[1];
        }

        private static bool CheckIfTwoOfThreeEqual(List<int> column)
        {
            return column[0] == column[1] || column[2] == column[1];
        }

        private static bool CheckIfThreeEqual(List<int> column)
        {
            return column[0] == column[2];
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

        public int CalculatePoints()
        {
            return CalculateCollumnA() + CalculateCollumnB() + CalculateCollumnC();
        }
        private int CalculateCollumnA()
        {
            columnA.Sort();
            int columnAPoints = 0;
            if (columnA.Count == 1)
            {
                columnAPoints = columnA[0];
            }
            else if (columnA.Count == 2)
            {
                if (columnA[0] == columnA[1])
                {
                    columnAPoints = 2 *(columnA[0] + columnA[1]);
                }
                else
                {
                    columnAPoints = columnA[0] + columnA[1];
                }
            }
            else if (columnA.Count == 3)
            {
                if (columnA[0] == columnA[1] && columnA[1] == columnA[2])
                {
                    columnAPoints = 3 *(columnA[0] + columnA[1] + columnA[2]);
                }
                else if (columnA[0] == columnA[1]) 
                {
                    columnAPoints = (2 * (columnA[0]+ columnA[1])) + columnA[2];
                }
                else if(columnA[1] == columnA[2])
                {
                    columnAPoints = (2 * (columnA[1] + columnA[2])) + columnA[0];
                }
                else
                {
                    columnAPoints = columnA[0] + columnA[1] + columnA[2];
                }
            }
            return columnAPoints;
        }
        private int CalculateCollumnB()
        {
            columnB.Sort();
            int columnBPoints = 0;
            if (columnB.Count == 1)
            {
                columnBPoints = columnB[0];
            }
            else if (columnB.Count == 2)
            {
                if (columnB[0] == columnB[1])
                {
                    columnBPoints = 2 * (columnB[0] + columnB[1]);
                }
                else
                {
                    columnBPoints = columnB[0] + columnB[1];
                }
            }
            else if (columnB.Count == 3)
            {
                if (columnB[0] == columnB[1] && columnB[1] == columnB[2])
                {
                    columnBPoints = 3 * (columnB[0] + columnB[1] + columnB[2]);
                }
                else if (columnB[0] == columnB[1])
                {
                    columnBPoints = (2 * (columnB[0] + columnB[1])) + columnB[2];
                }
                else if (columnB[1] == columnB[2])
                {
                    columnBPoints = (2 * (columnB[1] + columnB[2])) + columnB[0];
                } 
                else
                {
                    columnBPoints = columnB[0] + columnB[1] + columnB[2];
                }
            }
            return columnBPoints;
        }


        private int CalculateCollumnC()
        {
            columnC.Sort();
            int columnCPoints = 0;
            if (columnC.Count == 1)
            {
                columnCPoints = columnC[0];
            }
            else if (columnC.Count == 2)
            {
                if (columnC[0] == columnC[1])
                {
                    columnCPoints = 2 * (columnC[0] + columnC[1]);
                }
                else
                {
                    columnCPoints = columnC[0] + columnC[1];
                }
            }
            else if (columnC.Count == 3)
            {
                if (columnC[0] == columnC[1] && columnC[1] == columnC[2])
                {
                    columnCPoints = 3 * (columnC[0] + columnC[1] + columnC[2]);
                }
                else if (columnC[0] == columnC[1])
                {
                    columnCPoints = (2 * (columnC[0] + columnC[1])) + columnC[2];
                }
                else if (columnC[1] == columnC[2])
                {
                    columnCPoints = (2 * (columnC[1] + columnC[2])) + columnC[0];
                }
                else
                {
                    columnCPoints = columnC[0] + columnC[1] + columnC[2];
                }
            }
            return columnCPoints;
        }

    }
        
}