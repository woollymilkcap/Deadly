using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;

public class Wallpaper
{
    //wallpaper via C#
    // https://stackoverflow.com/questions/1061678/change-desktop-wallpaper-using-code-in-net/1061682#1061682
    //This used 
    //https://docs.microsoft.com/en-us/cpp/dotnet/how-to-call-native-dlls-from-managed-code-using-pinvoke?view=vs-2019
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern Int32 SystemParametersInfo(UInt32 uiAction, UInt32 uiParam, String pvParam, UInt32 fWinIni);

    private static UInt32 SPI_SETDESKWALLPAPER = 20;
    private static UInt32 SPIF_UPDATEINIFILE = 0x1;
    private static String imageFileName = "c:\\test\\test.bmp";
    const int SPIF_SENDWININICHANGE = 0x02;

    public enum Style : int
    {
        Tile,
        Center,
        Stretch,
        Fill,
        Fit,
        Span,
    }

    public static void SetImage(string filename)
    {
        SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, filename, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
    }

    public static void SetStyle(Style style)
    {
        RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
        if (style == Style.Fill)
        {
            key.SetValue(@"WallpaperStyle", 10.ToString());
            key.SetValue(@"TileWallpaper", 0.ToString());
        }
        if (style == Style.Fit)
        {
            key.SetValue(@"WallpaperStyle", 6.ToString());
            key.SetValue(@"TileWallpaper", 0.ToString());
        }
        if (style == Style.Span) // Windows 8 or newer only!
        {
            key.SetValue(@"WallpaperStyle", 22.ToString());
            key.SetValue(@"TileWallpaper", 0.ToString());
        }
        if (style == Style.Stretch)
        {
            key.SetValue(@"WallpaperStyle", 2.ToString());
            key.SetValue(@"TileWallpaper", 0.ToString());
        }
        if (style == Style.Tile)
        {
            key.SetValue(@"WallpaperStyle", 0.ToString());
            key.SetValue(@"TileWallpaper", 1.ToString());
        }
        if (style == Style.Center)
        {
            key.SetValue(@"WallpaperStyle", 0.ToString());
            key.SetValue(@"TileWallpaper", 0.ToString());
        }
    }

}
