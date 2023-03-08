using CommandLine;
using CommandLine.Text;
using WaifuImAPI_NET;
using WaifuImAPI_NET.Models.Objects;
using WaifuImAPI_NET.Models.Objects.Lists;
using WaifuWallpaperSetter.Objects;

WaifuImSearchSettings settings = null;
CommandLineOptions arguments = null;

Console.WriteLine("WaifuWallpaperSetter by SoNearSonar (https://github.com/SoNearSonar)\n");

// Grabs all command line options that were passed in
Parser.Default.ParseArguments<CommandLineOptions>(args)
.WithParsed(options => {
    settings = new WaifuImSearchSettings()
    {
        UserId = options.UserId,
        IncludedTags = options.IncludedTags.ToArray(),
        ExcludedTags = options.ExcludedTags.ToArray(),
        IsNsfw = options.IsNsfw,
        OnlyGif = options.OnlyGif,
        Orientation = options.Orientation,
        ManyFiles = options.ManyFiles,
        IncludedFiles = options.IncludedFiles.ToArray(),
        ExcludedFiles = options.ExcludedFiles.ToArray(),
    };
    arguments = options;
})
.WithNotParsed(errors => {
    SentenceBuilder builder = SentenceBuilder.Create();
    foreach (Error err in errors)
    {
        Console.WriteLine(builder.FormatError(err));
    }
    Console.WriteLine("Press any key to exit.");
});

// Checks if the OS is Windows and the version is Windows 8 or higher
bool isNotWindowsPlatform = Environment.OSVersion.Platform != PlatformID.Win32NT;
bool isNotCompatibleWindowsPlatform = Environment.OSVersion.Version.Major + Environment.OSVersion.Version.Minor < 8;

if (isNotWindowsPlatform || isNotCompatibleWindowsPlatform)
{
    Console.WriteLine("You can only run this program on Windows 8 or later");
    Console.WriteLine("Press any key to exit.");
    Console.ReadKey();
    Environment.Exit(0);
}

WaifuImClient client = new WaifuImClient();
WaifuImImageList imageList = null;
Random randomImageNumber = new Random();

try
{
    // Contacts the API to get an image object that is used in the program for wallpaper setting
    if (arguments != null && arguments.OnlyFavorites.HasValue && !string.IsNullOrWhiteSpace(arguments.Token))
    {
        Console.WriteLine("Getting wallpaper from your favorites on Waifu.Im\n");
        imageList = await client.GetFavoritesAsync(arguments.Token, settings);
    }
    else
    {
        Console.WriteLine("Getting wallpaper from Waifu.Im\n");
        imageList = await client.GetImagesAsync(settings);
    }

    WaifuImImage image = imageList.Images[randomImageNumber.Next(imageList.Images.Count)];

    // Checks if the user only wants .GIF files to be returned
    Console.WriteLine("Checking if \"gif\" command line option was set\n");
    string extension = (arguments.OnlyGif.HasValue && arguments.OnlyGif.HasValue) ? ".gif" : image.Extension;


    // Checks if the user wanted to save the location of the image somewhere else other than desktop
    Console.WriteLine("Checking if \"imageloc\" command line option was set\n");
    string location = !string.IsNullOrWhiteSpace(arguments.ImageLocation) && Directory.Exists(arguments.ImageLocation) ? arguments.ImageLocation : Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
    string path = Path.Combine(location, $"image{extension}");

    // Download the image from waifu.im and save it to disk
    Console.WriteLine($"Downloading image from Waifu.Im with image URL of \"{image.Url}\" to \"{path}\"\n");
    HttpClient httpClient = new HttpClient();
    byte[] wallpaperImage = await httpClient.GetByteArrayAsync(image.Url);
    await File.WriteAllBytesAsync(path, wallpaperImage);

    // Determine if the image should be forced to resize on desktop or automatically resize to appropriorate fit
    Console.WriteLine("Checking if \"userfit\" or \"autofit\" command line option was set\n");
    Wallpaper.Style style = Wallpaper.Style.Fill;

    if (arguments.Fit.HasValue)
    {
        style = arguments.Fit.Value;
    }
    else if (arguments.AutoFit && arguments.AutoFit)
    {
        if (image.Width > image.Height)
        {
            style = Wallpaper.Style.Fit;
        }
    }

    // Set the desktop wallpaper
    Console.WriteLine($"Setting wallpaper with fit of \"{style}\" to image from \"{path}\"\n");
    Wallpaper.Set(path, style);

    Console.WriteLine($"Desktop wallpaper has been set!\n");
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