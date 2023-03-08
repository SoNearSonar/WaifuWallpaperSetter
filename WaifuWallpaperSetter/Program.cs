using WaifuImAPI_NET;
using WaifuImAPI_NET.Models.Enums;
using WaifuImAPI_NET.Models.Objects;
using WaifuImAPI_NET.Models.Objects.Lists;

bool isNotWindowsPlatform = Environment.OSVersion.Platform != PlatformID.Win32NT;
bool isNotCompatibleWindowsPlatform = Environment.OSVersion.Version.Major + Environment.OSVersion.Version.Minor < 7;

if (isNotWindowsPlatform || isNotCompatibleWindowsPlatform)
{
    Console.WriteLine("You can only run this program on Windows 7 or later");
    Console.WriteLine("Press any key to exit.");
    Console.ReadKey();
    Environment.Exit(0);
}

WaifuImClient client = new WaifuImClient();
WaifuImSearchSettings settings = new WaifuImSearchSettings()
{
    Orientation = Orientation.Landscape
};

try
{
    Console.WriteLine("Getting wallpaper from Waifu.Im\n");
    WaifuImImageList imageList = await client.GetImagesAsync(settings);
    WaifuImImage image = imageList.Images[0];

    string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "image.png");
    Console.WriteLine($"Downloading wallpaper from Waifu.Im with image URL of \"{image.Url}\" to \"{path}\"\n");
    HttpClient httpClient = new HttpClient();
    byte[] wallpaperImage = await httpClient.GetByteArrayAsync(image.Url);
    await File.WriteAllBytesAsync(path, wallpaperImage);

    Console.WriteLine($"Setting wallpaper to image from \"{path}\"\n");
    Wallpaper.Set(path, Wallpaper.Style.Fill);

    Console.WriteLine($"Done setting wallpaper!\n");
    Console.WriteLine("Press any key to exit.");
    Console.ReadKey();
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred with this program: " + ex.Message);
    Console.WriteLine("Press any key to exit.");
    Console.ReadKey();
    Environment.Exit(0);
}