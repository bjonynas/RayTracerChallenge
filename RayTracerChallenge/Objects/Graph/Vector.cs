namespace RayTracerChallenge.Objects
{
    public class Vector : Tuple
    {
        public double Magnitude { get => Math.Sqrt(X * X + Y * Y + Z * Z + W * W); }

        public Vector()
        {

        }

        public Vector(double x, double y, double z): this(x, y, z, 0.0)
        {

        }

        public Vector(double x, double y, double z, double w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public Vector Normalize()
        {
            return new Vector()
            {
                X = X / Magnitude,
                Y = Y / Magnitude,
                Z = Z / Magnitude,
                W = W / Magnitude
            };
        }

        public static double Dot(Vector a, Vector b)
        {
            return (
                a.X * b.X +
                a.Y * b.Y +
                a.Z * b.Z +
                a.W * b.W
            );
        }

        public static Vector Cross(Vector a, Vector b)
        {
            return new Vector(
                a.Y * b.Z - a.Z * b.Y,
                a.Z * b.X - a.X * b.Z,
                a.X * b.Y - a.Y * b.X
            );
        }

        public override string ToString()
        {
            return $"{X}, {Y}, {Z}, {W}";
        }

        #region OperatorOverrides

        public static bool operator ==(Vector a, Vector b)
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
        
        public static bool operator !=(Vector a, Vector b)
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

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector()
            {
                X = a.X + b.X,
                Y = a.Y + b.Y,
                Z = a.Z + b.Z,
                W = a.W + b.W
            };
        }
        
        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector()
            {
                X = a.X - b.X,
                Y = a.Y - b.Y,
                Z = a.Z - b.Z,
                W = a.W - b.W
            };
        }

        public static Vector operator -(Vector a)
        {
            var zero = new Vector(0, 0, 0);
            return zero - a;
        }

        public static Vector operator *(Vector a, double scalar)
        {
            return new Vector()
            {
                X = a.X * scalar,
                Y = a.Y * scalar,
                Z = a.Z * scalar,
                W = a.W * scalar
            };
        }

        public static Vector operator /(Vector a, double scalar)
        {
            return new Vector()
            {
                X = a.X / scalar,
                Y = a.Y / scalar,
                Z = a.Z / scalar,
                W = a.W / scalar
            };
        }

        #endregion
    }
}
