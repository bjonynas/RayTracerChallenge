namespace RayTracerChallenge.Objects.Canvas
{
    public class Pixel
    {
        public Point Position { get; set; }
        public Colour Colour { get; set; }

        public Pixel(Point position, Colour colour)
        {
            Position = new Point(position.X, position.Y, position.Z);
            Colour = new Colour(colour.Red, colour.Green, colour.Blue);
        }

        public void SetColour(Colour colour)
        {
            Colour = new Colour(colour.Red, colour.Green, colour.Blue);
        }
    }
}
