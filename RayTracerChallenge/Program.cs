using RayTracerChallenge.Helpers;
using RayTracerChallenge.Objects;
using RayTracerChallenge.Objects.Canvas;

var ppmHelper = new PPMHelper();

var projectile = new Projectile(new Point(0, 1, 0), new Vector(1, 1.8, 0).Normalize() * 11.25);
var env = new RayTracerChallenge.Objects.Environment(new Vector(0, -0.1, 0), new Vector(-0.01, 0, 0));

var canvas = new Canvas(900, 550);
var white = new Colour(1, 1, 1);
Point roundedPoint;

var ticks = 0;
Console.WriteLine($"Starting position: {projectile.Position}");

while(projectile.Position.Y > 0)
{
    projectile.Position = projectile.Position + projectile.Velocity;
    projectile.Velocity = projectile.Velocity + env.Gravity + env.Wind;
    Console.WriteLine($"New Position: {projectile.Position}");
    ticks++;

    roundedPoint = new Point(Math.Ceiling(projectile.Position.X), canvas.Height - Math.Ceiling(projectile.Position.Y), Math.Ceiling(projectile.Position.Z));
    if(roundedPoint.X >= 0 && roundedPoint.X <= 900 && roundedPoint.Y >= 0 && roundedPoint.Y <= 550)
    {
        canvas.WritePixel(roundedPoint, white);
    }
}

Console.WriteLine($"Final position: {projectile.Position}");
Console.WriteLine($"Number of ticks: {ticks}");

var ppmLines = ppmHelper.CanvasToPPM(canvas);

string docPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);


Console.WriteLine("Writing to file");
using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "flightpath.ppm")))
{
    foreach (string line in ppmLines)
        outputFile.WriteLine(line);
}