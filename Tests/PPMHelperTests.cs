using RayTracerChallenge.Helpers;
using RayTracerChallenge.Objects.Canvas;
using Point = RayTracerChallenge.Objects.Point;

namespace Tests
{
    [TestFixture]
    public class PPMHelperTests
    {
        [Test]
        public void PPMHeaderIsCorrect()
        {
            var helper = new PPMHelper();
            var canvas = new Canvas(5, 3);

            string[] image = helper.CanvasToPPM(canvas).ToArray();
            Assert.True(image[0].Equals("P3\n"));
            Assert.True(image[1].Equals("5 3\n"));
            Assert.True(image[2].Equals("255\n"));
        }

        [Test]
        public void PPMImagePixelsAreCorrect()
        {
            var helper = new PPMHelper();
            var canvas = new Canvas(5, 3);
            var c1 = new Colour(1.5, 0, 0);
            var c2 = new Colour(0, 0.5, 0);
            var c3 = new Colour(-0.5, 0, 1);

            canvas.WritePixel(new Point(0, 0), c1);
            canvas.WritePixel(new Point(2, 1), c2);
            canvas.WritePixel(new Point(4, 2), c3);

            string[] image = helper.CanvasToPPM(canvas).ToArray();

            var l3 = "255 0 0 0 0 0 0 0 0 0 0 0 0 0 0\n";
            var l4 = "0 0 0 0 0 0 0 128 0 0 0 0 0 0 0\n";
            var l5 = "0 0 0 0 0 0 0 0 0 0 0 0 0 0 255\n";

            Assert.IsTrue(image[3].Equals(l3));
            Assert.IsTrue(image[4].Equals(l4));
            Assert.IsTrue(image[5].Equals(l5));
        }

        [Test]
        public void PPMLinesCorrectlySplit()
        {
            var helper = new PPMHelper();
            var colour = new Colour(1, 0.8, 0.6);
            var canvas = new Canvas(10, 2, colour);

            string[] image = helper.CanvasToPPM(canvas).ToArray();

            var l3 = "255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204\n";
            var l4 = "153 255 204 153 255 204 153 255 204 153 255 204 153\n";
            var l5 = "255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204\n";
            var l6 = "153 255 204 153 255 204 153 255 204 153 255 204 153\n";

            Assert.IsTrue(image[3].Equals(l3));
            Assert.IsTrue(image[4].Equals(l4));
            Assert.IsTrue(image[5].Equals(l5));
            Assert.IsTrue(image[6].Equals(l6));
        }

        [Test]
        public void PPMFileEndsWithNewLine()
        {
            var helper = new PPMHelper();
            var canvas = new Canvas(5, 3);
            string[] image = helper.CanvasToPPM(canvas).ToArray();

            Assert.IsTrue(image[image.Length -1].EndsWith("\n"));
        }
    }
}
