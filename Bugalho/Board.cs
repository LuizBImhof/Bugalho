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