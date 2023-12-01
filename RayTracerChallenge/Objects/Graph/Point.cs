namespace RayTracerChallenge.Objects
{
    public class Point : Tuple
    {
        public Point ()
        {

        }

        public Point (double x, double y, double z = 0)
        {
            X = x;
            Y = y;
            Z = z;
            W = 1.0;
        }

        public Point(Tuple tuple)
        {
            X = tuple.X;
            Y = tuple.Y;
            Z = tuple.Z;
            W = 1.0;
        }

        public override string ToString()
        {
            return $"{X}, {Y}, {Z}, {W}";
        }

        #region OperatorOverrides

        public static Point operator +(Point a, Vector b)
        {
            return new Point()
            {
                X = a.X + b.X,
                Y = a.Y + b.Y,
                Z = a.Z + b.Z,
                W = a.W + b.W
            };
        }

        public static Point operator -(Point a, Vector b)
        {
            return new Point()
            {
                X = a.X - b.X,
                Y = a.Y - b.Y,
                Z = a.Z - b.Z,
                W = a.W - b.W
            };
        }

        public static Vector operator -(Point a, Point b)
        {
            return new Vector()
            {
                X = a.X - b.X,
                Y = a.Y - b.Y,
                Z = a.Z - b.Z,
                W = a.W - b.W
            };
        }

        #endregion
    }
}
