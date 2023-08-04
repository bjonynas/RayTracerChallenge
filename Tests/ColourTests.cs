using RayTracerChallenge.Objects.Canvas;

namespace Tests
{
    [TestFixture]
    public class ColourTests
    {
        [Test]
        public void AddingColoursReturnsCorrectValue()
        {
            var c1 = new Colour(0.9, 0.6, 0.75);
            var c2 = new Colour(0.7, 0.1, 0.25);
            var result = c1 + c2;

            var expected = new Colour(1.6, 0.7, 1.0);
            Assert.True(result == expected);
        }

        [Test]
        public void SubtractingColoursReturnsCorrectValue()
        {
            var c1 = new Colour(0.9, 0.6, 0.75);
            var c2 = new Colour(0.7, 0.1, 0.25);
            var result = c1 - c2;

            var expected = new Colour(0.2, 0.5, 0.5);
            Assert.True(result == expected);
        }

        [Test]
        public void MultiplyingColoursByScalarReturnsCorrectValue()
        {
            var c = new Colour(0.2, 0.3, 0.4);
            var result = c * 2;

            var expected = new Colour(0.4, 0.6, 0.8);
            Assert.True(result == expected);
        }

        [Test]
        public void MultiplyingColoursReturnsCorrectValue()
        {
            var c1 = new Colour(1, 0.2, 0.4);
            var c2 = new Colour(0.9, 1, 0.1);
            var result = c1 * c2;

            var expected = new Colour(0.9, 0.2, 0.04);
            Assert.True(result == expected);
        }
    }
}
