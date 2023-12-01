using Matrix = RayTracerChallenge.Objects.Matrix;
using Tuple = RayTracerChallenge.Objects.Tuple;

namespace Tests
{
    [TestFixture]
    public class MatrixTests
    {
        [Test]
        public void MatrixInitialisedToCorrectSize()
        {
            var m = new Matrix(4);
            Assert.IsTrue(m.GetRowCount() == 4);
            Assert.IsTrue(m.GetColumnCount() == 4);
        }

        [Test]
        public void FourByFourMatrixCorrectlyCreated()
        {
            double[,] matrix = { { 1, 2, 3, 4}, { 5.5, 6.5, 7.5, 8.5}, { 9, 10, 11, 12 }, { 13.5, 14.5, 15.5, 16.5 } };
            var m = new Matrix(matrix);

            Assert.IsTrue(m[0, 0] == 1);
            Assert.IsTrue(m[0, 3] == 4);
            Assert.IsTrue(m[1, 0] == 5.5);
            Assert.IsTrue(m[1, 2] == 7.5);
            Assert.IsTrue(m[2, 2] == 11);
            Assert.IsTrue(m[3, 0] == 13.5);
            Assert.IsTrue(m[3, 2] == 15.5);
        }

        [Test]
        public void ComparingEqualMatricesReturnsCorrectValue()
        {
            double[,] matrixA = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 8, 7, 6 }, { 5, 4, 3, 2 } };
            double[,] matrixB = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 8, 7, 6 }, { 5, 4, 3, 2 } };

            var a = new Matrix(matrixA);
            var b = new Matrix(matrixB);

            Assert.IsTrue(a == b);
            Assert.IsFalse(a != b);
        }

        [Test]
        public void ComparingDifferentMatricesReturnsCorrectValue()
        {
            double[,] matrixA = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 8, 7, 6 }, { 5, 4, 3, 2 } };
            double[,] matrixB = { { 2, 3, 4, 5 }, { 6, 7, 8, 9 }, { 8, 7, 6, 5 }, { 4, 3, 2, 1 } };

            var a = new Matrix(matrixA);
            var b = new Matrix(matrixB);

            Assert.IsTrue(a != b);
            Assert.IsFalse(a == b);
        }

        [Test]
        public void MultiplyingMatricesReturnsCorrectResult()
        {
            double[,] matrixA = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 8, 7, 6 }, { 5, 4, 3, 2 } };
            double[,] matrixB = { { -2, 1, 2, 3 }, { 3, 2, 1, -1 }, { 4, 3, 6, 5 }, { 1, 2, 7, 8 } };

            var a = new Matrix(matrixA);
            var b = new Matrix(matrixB);

            double[,] resultMatrix = { { 20, 22, 50, 48 }, { 44, 54, 114, 108 }, { 40, 58, 110, 102 }, { 16, 26, 46, 42 } };
            var expected = new Matrix(resultMatrix);

            var result = a * b;
            Assert.IsTrue(expected == result);
        }

        [Test]
        public void MultiplyingMatrixByTupleReturnsCorrectResult()
        {
            Matrix matrix = new Matrix( new double[,] { { 1, 2, 3, 4 }, { 2, 4, 4, 2 }, { 8, 6, 4, 1 }, { 0, 0, 0, 1 } });
            Tuple tuple = new Tuple(1, 2, 3, 1);

            var expected = new Tuple(18, 24, 33, 1);

            var result = matrix * tuple;

            Assert.IsTrue(result == expected);
        }

        [Test]
        public void MatrixMultipliedByIdentityMatrixDoesntChange()
        {
            Matrix matrix = new Matrix(new double[,] { { 0, 1, 2, 4 }, { 1, 2, 4, 8 }, { 2, 4, 8, 16 }, { 4, 8, 16, 32 } });
            var identityMatrix = Matrix.IdentityMatrix();

            var result = matrix * identityMatrix;
            Assert.IsTrue(result == matrix);
        }

        [Test]
        public void TupleMultipliedByIdentityMatrixDoesntChange()
        {
            var tuple = new Tuple(1, 2, 3, 4);
            var identityMatrix = Matrix.IdentityMatrix();

            var result = identityMatrix * tuple;
            Assert.IsTrue(result == tuple);
        }

        [Test]
        public void TransposingMatrixReturnsCorrectResult()
        {
            var matrix = new Matrix(new double[,] { { 0, 9, 3, 0 }, { 9, 8, 0, 8 }, { 1, 8, 5, 3 }, { 0, 0, 5, 8 } });
            var result = matrix.Transpose(matrix);

            var expected = new Matrix(new double[,] { { 0, 9, 1, 0 }, { 9, 8, 8, 0 }, { 3, 0, 5, 5 }, { 0, 8, 3, 8 } });
            Assert.IsTrue(expected == result);
        }
    }
}
