using static UnityEngine.UI.Image;

namespace VL.Gaming.Scripts.Common.Entities
{
    [System.Serializable]
    public class Serializable2DArray<T>
    {
        public T[] Array;
        public int Rows;
        public int Cols;

        public Serializable2DArray(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            Array = new T[rows * cols];
        }
        public Serializable2DArray(T[,] original)
        {
            Rows = original.GetLength(0);
            Cols = original.GetLength(1);
            Array = new T[Rows * Cols];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    Array[i * Cols + j] = original[i, j];
                }
            }
        }

        public T[,] To2DArray()
        {
            T[,] result = new T[Rows, Cols];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    result[i, j] = Array[i * Cols + j];
                }
            }
            return result;
        }
    }
}
