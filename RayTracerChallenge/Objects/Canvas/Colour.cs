namespace RayTracerChallenge.Objects.Canvas
{
    public class Colour
    {
        const double EPSILON = 0.0001;
        public double Red { get; set; }
        public double Green { get; set; }
        public double Blue { get; set; }

        public Colour()
        {

        }

        public Colour(double red, double green, double blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        #region OperatorOverrides

        public static bool operator ==(Colour a, Colour b)
        {
            if (Math.Abs(a.Red - b.Red) < EPSILON && Math.Abs(a.Green - b.Green) < EPSILON && Math.Abs(a.Blue - b.Blue) < EPSILON)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Colour a, Colour b)
        {
            if (Math.Abs(a.Red - b.Red) > EPSILON || Math.Abs(a.Green - b.Green) > EPSILON || Math.Abs(a.Blue - b.Blue) > EPSILON)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Colour operator +(Colour a, Colour b)
        {
            return new Colour()
            {
                Red = a.Red + b.Red,
                Green = a.Green + b.Green,
                Blue = a.Blue + b.Blue
            };
        }

        public static Colour operator -(Colour a, Colour b)
        {
            return new Colour()
            {
                Red = a.Red - b.Red,
                Green = a.Green - b.Green,
                Blue = a.Blue - b.Blue
            };
        }
        public static Colour operator *(Colour a, double scalar)
        {
            return new Colour()
            {
                Red = a.Red * scalar,
                Green = a.Green * scalar,
                Blue = a.Blue * scalar
            };
        }
        public static Colour operator *(Colour a, Colour b)
        {
            return new Colour()
            {
                Red = a.Red * b.Red,
                Green = a.Green * b.Green,
                Blue = a.Blue * b.Blue
            };
        }

        #endregion
    }
}
