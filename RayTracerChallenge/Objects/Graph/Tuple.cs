namespace RayTracerChallenge.Objects
{
    public class Tuple
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double W { get; set; }

        public Tuple() { }

        public Tuple(double x, double y, double z, double w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public double[] ToArray()
        {
            return new double[] { X, Y, Z, W };
        }

        public static bool operator ==(Tuple a, Tuple b)
        {
            if (a.X == b.X && a.Y == b.Y && a.Z == b.Z && a.W == b.W)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Tuple a, Tuple b)
        {
            if (a.X != b.X || a.Y != b.Y || a.Z != b.Z || a.W != b.W)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
