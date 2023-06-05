using System.Drawing;
using Tuple = RayTracerChallenge.Objects.Tuple;

namespace Tests
{
    public class Tests
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
            var point = Tuple.Point(1.0, 1.0, 1.0);
            Assert.True(isEqual(point.W, 1.0));
        }

        [Test]
        public void VectorCreatesTupleWhereWIs1()
        {
            var vector = Tuple.Vector(1.0, 1.0, 1.0);
            Assert.True(isEqual(vector.W, 0.0));
        }

        [Test]
        public void AddingTuplesWorksCorrectly()
        {
            var a = new Tuple(3, -2, 5, 1);
            var b = new Tuple(-2, 3, 1, 0);
            var result = a + b;

            var expected = new Tuple(1, 1, 6, 1);
            Assert.True(result == expected);
        }

        [Test]
        public void SubtractingPointsProducesCorrectVector()
        {
            var p1 = Tuple.Point(3, 2, 1);
            var p2 = Tuple.Point(5, 6, 7);
            var result = p1 - p2;

            var expected = new Tuple(-2, -4, -6, 0);
            Assert.True(result == expected);
        }

        [Test]
        public void SubtractingVectorFromPointProducesCorrectPoint()
        {
            var p = Tuple.Point(3, 2, 1);
            var v = Tuple.Vector(5, 6, 7);
            var result = p - v;

            var expected = new Tuple(-2, -4, -6, 1);
            Assert.True(result == expected);
        }

        [Test]
        public void SubtractingVectorsProducesVector()
        {
            var v1 = Tuple.Vector(3, 2, 1);
            var v2 = Tuple.Vector(5, 6, 7);
            var result = v1 - v2;

            var expected = new Tuple(-2, -4, -6, 0);
            Assert.True(result == expected);
        }

        [Test]
        public void NegatingVectorReturnsNegatedVector()
        {
            var v = Tuple.Vector(1, -2, 3);
            var result = -v;

            var expected = new Tuple(-1, 2, -3, 0);
            Assert.True(result == expected);
        }
    }
}