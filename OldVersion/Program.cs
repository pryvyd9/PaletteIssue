using ImageMagick;

namespace OldVersion
{
    internal class Program
    {
        static string filename = "img.png";

        static void WriteFile()
        {
            var settings = new MagickReadSettings()
            {
                Width = 15,
                Height = 15,
            };
            using var img = new MagickImage("xc:#ff0080", settings);
            var drawables = new Drawables();
            drawables
                .DisableStrokeAntialias()
                .StrokeColor(MagickColors.White)
                .FillColor(MagickColors.White)
                .Polygon([new PointD(5, 5), new PointD(5, 10), new PointD(10, 10), new PointD(10, 5)]);

            img.Draw(drawables);

            img.Settings.SetDefine("png:color-type", "1");
            string[] colormap = [
                "#00FF00",
                "#FF0000",
                "#FFFC00",
                "#00E1FF",
                "#00C8FF",
                "#0096FF",
                "#0064FF",
                "#0000FF",
                "#0000E1",
                "#0000C8",
                "#000096",
                "#000064",
                "#005500",
                "#007D00",
                "#009E00",
                "#18CE00",
                "#FF0080",
                "#FFFFFF",
            ];

            img.Map(colormap.Select(n => new MagickColor(n)));
            img.Write(filename);
        }

        static void Main(string[] args)
        {
            WriteFile();
            var img = new MagickImage(filename);
            Console.WriteLine($"Depth: {img.Depth}");
            Console.WriteLine($"ColorType: {img.ColorType}");
            Console.WriteLine($"ColormapSize: {img.ColormapSize}");
        }
    }
}
