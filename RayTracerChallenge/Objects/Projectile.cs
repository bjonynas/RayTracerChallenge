﻿namespace RayTracerChallenge.Objects
{
    public class Projectile
    {
        public Point Position { get; set; }
        public Vector Velocity { get; set; }

        public Projectile(Point position, Vector velocity)
        {
            Position = position;
            Velocity = velocity;
        }
    }
}
