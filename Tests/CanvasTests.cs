using RayTracerChallenge.Objects.Canvas;
using Point = RayTracerChallenge.Objects.Point;

namespace Tests
{
    [TestFixture]
    public class CanvasTests
    {
        [Test]
        public void NewCanvasInitialisedWithBlackPixels()
        {
            var width = 10;
            var height = 20;
            var black = new Colour(0, 0, 0);

            var canvas = new Canvas(width, height);

            Assert.True(canvas.Width == width);
            Assert.True(canvas.Height == height);
            foreach(var pixel in canvas.Pixels)
            {
                Assert.IsTrue(pixel.Colour == black);
            }
        }

        [Test]
        public void WritePixelSetsCorrectColour()
        {
            var width = 10;
            var height = 20;
            var pixelToWrite = new Point(2, 3);
            var red = new Colour(1, 0, 0);

            var canvas = new Canvas(width, height);
            canvas.WritePixel(pixelToWrite, red);

            var pixel = canvas.Pixels.First(p => p.Position == pixelToWrite);
            Assert.True(pixel.Colour == red);
        }
    }
}
