using RayTracerChallenge.Objects;
using Environment = RayTracerChallenge.Objects.Environment;

var projectile = new Projectile(new Point(0, 1, 0), new Vector(1, 1, 0).Normalize());
var env = new Environment(new Vector(0, -0.1, 0), new Vector(-0.01, 0, 0));

var ticks = 0;
Console.WriteLine($"Starting position: {projectile.Position}");

while(projectile.Position.Y > 0)
{
    projectile.Position = projectile.Position + projectile.Velocity;
    projectile.Velocity = projectile.Velocity + env.Gravity + env.Wind;
    Console.WriteLine($"New Position: {projectile.Position}");
    ticks++;
}

Console.WriteLine($"Final position: {projectile.Position}");
Console.WriteLine($"Number of ticks: {ticks}");