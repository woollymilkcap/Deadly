using System;
using System.IO;

namespace deadly
{
    static class Program
    {
        //using Dragonfruit model https://github.com/dotnet/command-line-api/wiki/Your-first-app-with-System.CommandLine.DragonFruit
        /// <summary>
        /// My example app
        /// </summary>
        /// <param name="filename">Give the absolute filepath to an image</param>
        /// <param name="style">Give one of the style of the wallpaper { tile, center, stretch, fill, fit, span }</param>
        static void Main(string filename = @"F:\Abhi\shop\deadly\deadly\Sample.png", string style = "Center")
        {
            string path = filename;

            Wallpaper.Style sty = Wallpaper.Style.Center;

            switch (style) {
                case "center"   : sty = Wallpaper.Style.Center; break;
                case "tile"     : sty = Wallpaper.Style.Tile; break;
                case "strech"   : sty = Wallpaper.Style.Stretch; break;
                case "fill"     : sty = Wallpaper.Style.Fill; break;
                case "fit"      : sty = Wallpaper.Style.Fit; break;
                case "span"     : sty = Wallpaper.Style.Span; break;
            }

            if (File.Exists(path))
            {
                SetWallpaper(path, sty);
            }
            else
            {
                Console.WriteLine("File doesn't exist");
            }
        }

        // Pass in a relative path to a file inside the local appdata folder 
        static void SetWallpaper(string filePath, Wallpaper.Style style)
        {
            Wallpaper.SetStyle(style);
            Wallpaper.SetImage(filePath);
        }


    }
}
