using RayTracerChallenge.Objects.Canvas;

namespace RayTracerChallenge.Helpers
{
    public class PPMHelper
    {
        private const string IDENTIFIER = "P3";
        private const int COLOURMAX = 255;
        private const int MAXLINELENGTH = 70;

        public string CanvasToPPM(Canvas canvas)
        {
            var result = $"{IDENTIFIER}\n";
            result = result + $"{canvas.Width} {canvas.Height}\n";
            result = result + $"{COLOURMAX}\n";

            for(int row = 0; row < canvas.Height; row++)
            {
                var line = "";
                var pixels = canvas.Pixels.Where(p => p.Position.Y == row);
                
                foreach(var pixel in pixels)
                {
                    var colourString = ColourToPPMString(pixel.Colour);
                    if(line.Length + colourString.Length + 1 <= MAXLINELENGTH)
                    {
                        line = line + colourString + " ";
                    }
                    else
                    {
                        var colourValues = colourString.Split(" ");
                        while(colourValues.Length > 0)
                        {
                            if(line.Length + colourValues[0].Length +1 <= MAXLINELENGTH)
                            {
                                line += colourValues[0] + " ";
                                colourValues = colourValues.TakeLast(colourValues.Length - 1).ToArray();
                            }
                            else
                            {
                                line = line.Remove(line.Length - 1, 1);
                                result = result + line + "\n";
                                line = "";
                                for(int c = 0; c < colourValues.Length; c++)
                                {
                                    line = line + colourValues[c] + " ";
                                }
                                break;
                            }
                        }
                    }
                    
                }
                line = line.Remove(line.Length - 1, 1) + "\n";
                result = result + line;
            }

            return result;
        }

        private string ColourToPPMString(Colour colour)
        {
            var red = Math.Clamp(Math.Ceiling(colour.Red * COLOURMAX), 0, COLOURMAX);
            var green = Math.Clamp(Math.Ceiling(colour.Green * COLOURMAX), 0, COLOURMAX);
            var blue = Math.Clamp(Math.Ceiling(colour.Blue * COLOURMAX), 0, COLOURMAX);

            return $"{red} {green} {blue}";
        }
    }
}
