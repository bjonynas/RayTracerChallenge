using RayTracerChallenge.Objects;
using Tuple = RayTracerChallenge.Objects.Tuple;
using Vector = RayTracerChallenge.Objects.Vector;

namespace Tests
{
    [TestFixture]
    public class TupleTests
    {
        const double EPSILON = 0.0001;

        private bool isEqual(double a, double b)
        {
            if(Math.Abs(a - b) < EPSILON)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [Test]
        public void PointCreatesTupleWhereWIs1()
        {
            var point = new Point(1, 1, 1);
            Assert.True(isEqual(point.W, 1));
        }

        [Test]
        public void VectorCreatesTupleWhereWIs0()
        {
            var vector = new Vector(1.0, 1.0, 1.0);
            Assert.True(isEqual(vector.W, 0.0));
        }

        [Test]
        public void AddingVectorToPointCreatesPoint()
        {
            var a = new Point(3, -2, 5);
            var b = new Vector(-2, 3, 1);
            var result = a + b;

            var expected = new Point(1, 1, 6);
            Assert.True(result == expected);
        }

        [Test]
        public void AddingTwoVectorsCreatesVector()
        {
            var a = new Vector(3, -2, 5);
            var b = new Vector(-2, 3, 1);
            var result = a + b;

            var expected = new Vector(1, 1, 6);
            Assert.True(result == expected);
        }

        [Test]
        public void SubtractingTwoPointsProducesVector()
        {
            var p1 = new Point(3, 2, 1);
            var p2 = new Point(5, 6, 7);
            var result = p1 - p2;

            var expected = new Vector(-2, -4, -6);
            Assert.True(result == expected);
        }

        [Test]
        public void SubtractingVectorFromPointProducesPoint()
        {
            var p = new Point(3, 2, 1);
            var v = new Vector(5, 6, 7);
            var result = p - v;

            var expected = new Point(-2, -4, -6);
            Assert.True(result == expected);
        }

        [Test]
        public void SubtractingVectorsProducesVector()
        {
            var v1 = new Vector(3, 2, 1);
            var v2 = new Vector(5, 6, 7);
            var result = v1 - v2;

            var expected = new Vector(-2, -4, -6, 0);
            Assert.True(result == expected);
        }

        [Test]
        public void NegatingVectorReturnsNegatedVector()
        {
            var v = new Vector(1, -2, 3);
            var result = -v;

            var expected = new Vector(-1, 2, -3);
            Assert.True(result == expected);
        }

        [Test]
        public void MultiplyingTupleVectorByScalarReturnsVector()
        {
            var t = new Vector(1, -2, 3, -4);
            var result = t * 3.5;

            var expected = new Vector(3.5, -7, 10.5, -14);
            Assert.True(result == expected);
        }

        [Test]
        public void MultiplyingTupleByFractionReturnsCorrectValue()
        {
            var t = new Vector(1, -2, 3, -4);
            var result = t * 0.5;

            var expected = new Vector(0.5, -1, 1.5, -2);
            Assert.True(result == expected);
        }

        [Test]
        public void DividingVectorByScalarReturnsCorrectValue()
        {
            var t = new Vector(1, -2, 3, -4);
            var result = t / 2;

            var expected = new Vector(0.5, -1, 1.5, -2);
            Assert.True(result == expected);
        }

        [Test]
        public void VectorXOnlyMagnitudeCalculatedCorrectly()
        {
            var v = new Vector(1, 0, 0);
            Assert.IsTrue(isEqual(v.Magnitude, 1));
        }

        [Test]
        public void VectorYOnlyMagnitudeCalculatedCorrectly()
        {
            var v = new Vector(0, 1, 0);
            Assert.IsTrue(isEqual(v.Magnitude, 1));
        }

        [Test]
        public void VectorZOnlyMagnitudeCalculatedCorrectly()
        {
            var v = new Vector(0, 0, 1);
            Assert.IsTrue(isEqual(v.Magnitude, 1));
        }

        [Test]
        public void VectorMagnitudeCalculatedCorrectly()
        {
            var v = new Vector(1, 2, 3);
            Assert.IsTrue(isEqual(v.Magnitude, Math.Sqrt(14)));
        }

        [Test]
        public void NegativeVectorMagnitudeCalculatedCorrectly()
        {
            var v = new Vector(-1, -2, -3);
            Assert.IsTrue(isEqual(v.Magnitude, Math.Sqrt(14)));
        }

        [Test]
        public void XOnlyVectorNormalizedCorrectly()
        {
            var v = new Vector(4, 0, 0);
            var result = v.Normalize();

            var expected = new Vector(1, 0, 0);
            Assert.True(result == expected);
        }

        [Test]
        public void VectorNormalizedCorrectly()
        {
            var v = new Vector(1, 2, 3);
            var sqrtOf14 = Math.Sqrt(14);
            var result = v.Normalize();

            var expected = new Vector(1/sqrtOf14, 2/sqrtOf14, 3/sqrtOf14);
            Assert.True(result == expected);
        }

        [Test]
        public void NormalizedVectorHasMagnitude1()
        {
            var v = new Vector(1, 2, 3);
            var result = v.Normalize();

            Assert.True(isEqual(result.Magnitude, 1));
        }

        [Test]
        public void VectorDotProductCalculatedCorrectly()
        {
            var v1 = new Vector(1, 2, 3);
            var v2 = new Vector(2, 3, 4);
            var result = Vector.Dot(v1, v2);

            var expected = 20;
            Assert.True(isEqual(result, expected));
        }

        [Test]
        public void VectorCrossProductCalculatedCorrectly()
        {
            var v1 = new Vector(1, 2, 3);
            var v2 = new Vector(2, 3, 4);
            var result = Vector.Cross(v1, v2);

            var expected = new Vector(-1, 2, -1);
            Assert.True(result == expected);
        }

        [Test]
        public void VectorCrossProductChangingOrderNegatesResult()
        {
            var v1 = new Vector(1, 2, 3);
            var v2 = new Vector(2, 3, 4);
            var result = Vector.Cross(v2, v1);

            var expected = new Vector(-1, 2, -1);
            expected = (Vector)(-expected);
            Assert.True(result == expected);
        }
    }
}