using Microsoft.Win32;
using System.Runtime.InteropServices;


/*
 * Credit to: https://stackoverflow.com/users/4792350/badsamaritan
 * From: https://stackoverflow.com/a/40950312
 */
public sealed class Wallpaper
{
    Wallpaper() { }

    const int SPI_SETDESKWALLPAPER = 20;
    const int SPIF_UPDATEINIFILE = 0x01;
    const int SPIF_SENDWININICHANGE = 0x02;

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

    public enum Style : int
    {
        Fill,
        Fit,
        Span,
        Stretch,
        Tile,
        Center
    }

    public static void Set(string imagePath, Style style)
    {
        RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
        if (style == Style.Fill)
        {
            key.SetValue(@"WallpaperStyle", "10");
            key.SetValue(@"TileWallpaper", "0");
        }
        if (style == Style.Fit)
        {
            key.SetValue(@"WallpaperStyle", "6");
            key.SetValue(@"TileWallpaper", "0");
        }
        if (style == Style.Span) // Windows 8 or newer only!
        {
            key.SetValue(@"WallpaperStyle", "22");
            key.SetValue(@"TileWallpaper", "0");
        }
        if (style == Style.Stretch)
        {
            key.SetValue(@"WallpaperStyle", "2");
            key.SetValue(@"TileWallpaper", "0");
        }
        if (style == Style.Tile)
        {
            key.SetValue(@"WallpaperStyle", "0");
            key.SetValue(@"TileWallpaper", "1");
        }
        if (style == Style.Center)
        {
            key.SetValue(@"WallpaperStyle", "0");
            key.SetValue(@"TileWallpaper", "0");
        }

        SystemParametersInfo(SPI_SETDESKWALLPAPER,
            0,
            imagePath,
            SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
    }
}