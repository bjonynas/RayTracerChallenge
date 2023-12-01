namespace RayTracerChallenge.Objects
{
    public class Matrix
    {
        double[,] matrix;

        public Matrix(int size) {
            matrix = new double[size, size];
        }

        public Matrix(double[,] m)
        {
            matrix = m;
        }

        public static Matrix IdentityMatrix()
        {
            return new Matrix(new double[,] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } });
        }

        public int GetRowCount()
        {
            return matrix.GetLength(0);
        }

        public int GetColumnCount()
        {
            return matrix.GetLength(1);
        }

        public Matrix Transpose(Matrix matrix)
        {
            //assuming square matrix
            var resultMatrix = new Matrix(matrix.GetRowCount());

            for(int row = 0; row < matrix.GetRowCount(); row++)
            {
                for(int col = 0; col < matrix.GetColumnCount(); col++)
                {
                    resultMatrix[col, row] = matrix[row, col];
                }
            }

            return resultMatrix;
        }

        #region Operator Overrides

        public double this[int index1, int index2]
        {
            get
            {
                return matrix[index1, index2];
            }
            set { 
                matrix[index1, index2] = value;
            }
        }

        public static bool operator==(Matrix a, Matrix b)
        {
            var rowCountA = a.GetRowCount();
            var rowCountB = b.GetRowCount();

            if (rowCountA != rowCountB)
            {
                return false;
            }
            var columnCountA = a.GetColumnCount();
            var columnCountB = b.GetColumnCount();

            if(columnCountA != columnCountB)
            {
                return false;
            }

            for(int row = 0; row < rowCountA; row++)
            {
                for(int column = 0; column < columnCountA; column++) {
                    if (a[row, column] != b[row, column])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator!=(Matrix a, Matrix b)
        {
            return !(a == b);
        }

        public static Matrix operator*(Matrix a, Matrix b)
        {
            //assuming we're using square matrices
            var resultMatrix = new Matrix(a.GetRowCount());

            for(int row = 0; row < a.GetRowCount(); row++) {
                for(int col = 0; col < b.GetColumnCount(); col++)
                {
                    var resultPos = 0.0;
                    for(int pos = 0; pos < a.GetColumnCount(); pos++)
                    {
                        resultPos = resultPos + (a[row, pos] * b[pos, col]);
                    }
                    resultMatrix[row, col] = resultPos;
                }
            }

            return resultMatrix;
        }

        public static Tuple operator*(Matrix a, Tuple b)
        {
            var resultArray = new double[4];
            var bArray = b.ToArray();
            
            for(int row = 0; row < a.GetRowCount(); row++)
            {
                var resultPos = 0.0;
                for(int pos = 0; pos < a.GetColumnCount(); pos++)
                {
                    resultPos = resultPos + (a[row, pos] * bArray[pos]);
                }
                resultArray[row] = resultPos;
            }

            return new Tuple(resultArray[0], resultArray[1], resultArray[2], resultArray[3]);
        }

        #endregion
    }
}
