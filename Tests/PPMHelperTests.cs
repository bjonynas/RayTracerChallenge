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

            string image = helper.CanvasToPPM(canvas);
            var lines = image.Split("\n");
            Assert.True(lines[0].Equals("P3"));
            Assert.True(lines[1].Equals("5 3"));
            Assert.True(lines[2].Equals("255"));
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

            string image = helper.CanvasToPPM(canvas);
            var lines = image.Split("\n");

            var l3 = "255 0 0 0 0 0 0 0 0 0 0 0 0 0 0";
            var l4 = "0 0 0 0 0 0 0 128 0 0 0 0 0 0 0";
            var l5 = "0 0 0 0 0 0 0 0 0 0 0 0 0 0 255";

            Assert.IsTrue(lines[3].Equals(l3));
            Assert.IsTrue(lines[4].Equals(l4));
            Assert.IsTrue(lines[5].Equals(l5));
        }

        [Test]
        public void PPMLinesCorrectlySplit()
        {
            var helper = new PPMHelper();
            var colour = new Colour(1, 0.8, 0.6);
            var canvas = new Canvas(10, 2, colour);

            string image = helper.CanvasToPPM(canvas);
            var lines = image.Split("\n");

            var l3 = "255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204";
            var l4 = "153 255 204 153 255 204 153 255 204 153 255 204 153";
            var l5 = "255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204";
            var l6 = "153 255 204 153 255 204 153 255 204 153 255 204 153";

            Assert.IsTrue(lines[3].Equals(l3));
            Assert.IsTrue(lines[4].Equals(l4));
            Assert.IsTrue(lines[5].Equals(l5));
            Assert.IsTrue(lines[6].Equals(l6));
        }

        [Test]
        public void PPMFileEndsWithNewLine()
        {
            var helper = new PPMHelper();
            var canvas = new Canvas(5, 3);
            string image = helper.CanvasToPPM(canvas);

            Assert.IsTrue(image.EndsWith("\n"));
        }
    }
}
