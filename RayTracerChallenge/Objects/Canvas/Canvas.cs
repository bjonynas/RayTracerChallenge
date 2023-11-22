namespace RayTracerChallenge.Objects.Canvas
{
    public class Canvas
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public List<Pixel> Pixels { get; set; }

        public Canvas(int width, int height, Colour colour)
        {
            Width = width;
            Height = height;
            Pixels = new List<Pixel>();
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var position = new Point(x, y, 0);
                    Pixels.Add(new Pixel(position, colour));
                }
            }
        }

        public Canvas(int width, int height) : this(width, height, new Colour(0, 0, 0))
        {
        }

        

        public Pixel PixelAt(Point position)
        {
            return Pixels.First(p => p.Position == position);
        }

        public void WritePixel(Point position, Colour colour)
        {
            var p = PixelAt(position);
            p.SetColour(colour);
        }
    }
}
