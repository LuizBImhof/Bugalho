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
            else if(column == 1)
                columnB.Add(value);
            else if(column == 2)
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
            points += (value * 2) * 2 - value;
        }

        private void CalculatePointsWhenTwoOfThreeEqual(int value)
        {
            points += (value * 2) * 2 - 2 * value;
        }

        private void CalculatePointsWhenThreeEqual(int value)
        {
            points = points - (value * 2) * 2 - value;
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
            for(int i = 0; i<3; i++)
            {
                if (columnA.Count > i)
                    result += "|" + columnA[i] + "|";
                else
                    result += "|" +0 + "|";
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