using CommandLine;
using CommandLine.Text;
using WaifuImAPI_NET;
using WaifuImAPI_NET.Models.Objects;
using WaifuImAPI_NET.Models.Objects.Lists;
using WaifuWallpaperSetter.Objects;
using WaifuWallpaperSetter.Utilities;

WaifuImSearchSettings settings = null;
CommandLineOptions arguments = null;

Console.WriteLine("WaifuWallpaperSetter by SoNearSonar (https://github.com/SoNearSonar)\n");

Parser.Default.ParseArguments<CommandLineOptions>(args)
.WithParsed(options => {
    settings = new WaifuImSearchSettings()
    {
        UserId = options.UserId,
        IncludedTags = options.IncludedTags.ToArray(),
        ExcludedTags = options.ExcludedTags.ToArray(),
        IsNsfw = options.IsNsfw,
        OnlyGif = options.OnlyGif,
        OrderBy = options.OrderBy,
        Orientation = options.Orientation,
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
    Console.ReadKey();
    Environment.Exit(0);
});

// Checks if the OS is Windows and the version is Windows 8 or higher
bool isNotWindowsPlatform = Environment.OSVersion.Platform != PlatformID.Win32NT;
bool isNotCompatibleWindowsPlatform = Environment.OSVersion.Version.Major + Environment.OSVersion.Version.Minor < 8;

if (isNotWindowsPlatform || isNotCompatibleWindowsPlatform)
{
    Console.WriteLine("You can only run this program on Windows 8 or later");
    Console.ReadKey();
    Environment.Exit(0);
}

WaifuImClient client = new WaifuImClient();
WaifuImImageList imageList = null;
Random randomImageNumber = new Random();

try
{
    if (arguments != null && (arguments.OnlyFavorites.HasValue && arguments.OnlyFavorites.Value) && !string.IsNullOrWhiteSpace(arguments.Token))
    {
        ConsoleTextDisplayer.DisplayConsoleText("Getting wallpaper from your favorites on Waifu.Im\n", arguments.NoPrompt);
        imageList = await client.GetFavoritesAsync(arguments.Token, settings);
    }
    else
    {
        ConsoleTextDisplayer.DisplayConsoleText("Getting wallpaper from Waifu.Im\n", arguments.NoPrompt);
        imageList = await client.GetImagesAsync(settings);
    }

    WaifuImImage image = imageList.Images[0];
    string extension = (arguments.OnlyGif.HasValue && arguments.OnlyGif.HasValue) ? ".gif" : image.Extension;
    string location = !string.IsNullOrWhiteSpace(arguments.ImageLocation) && Directory.Exists(arguments.ImageLocation) ? arguments.ImageLocation : Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
    string path = Path.Combine(location, $"image_{image.ImageId}{extension}");

    bool isInFavorites = false;
    if (arguments.Token != null)
    {
        imageList = await client.GetFavoritesAsync(arguments.Token, settings);
        foreach (WaifuImImage img in imageList.Images)
        {
            if (img.ImageId == image.ImageId)
            {
                isInFavorites = true;
            }
        }
    }

    ConsoleTextDisplayer.DisplayConsoleText($"Downloading image from Waifu.Im with image URL of \"{image.Url}\" to \"{path}\"\n", arguments.NoPrompt);
    HttpClient httpClient = new HttpClient();
    byte[] wallpaperImage = await httpClient.GetByteArrayAsync(image.Url);
    await File.WriteAllBytesAsync(path, wallpaperImage);

    Wallpaper.Style style = Wallpaper.Style.Fill;

    if (image.Height > image.Width)
    {
        style = Wallpaper.Style.Fit;
    }
    if (arguments.Fit.HasValue)
    {
        style = arguments.Fit.Value;
    }

    ConsoleTextDisplayer.DisplayConsoleText($"Setting wallpaper with fit of \"{style}\" to image from \"{path}\"\n", arguments.NoPrompt);
    Wallpaper.Set(path, style);

    if (arguments.Token != null && !arguments.NoPrompt)
    {
        string favoriteToggle = !isInFavorites ? "add" : "remove";
        string wording = !isInFavorites ? "to" : "from";
        Console.Write($"Would you like to {favoriteToggle} this image {wording} your favorites? (Type y or n)\nYour choice: ");
        char c = Console.ReadKey().KeyChar;
        Console.WriteLine();
        Console.WriteLine();

        if (c.ToString().ToLowerInvariant().Equals("y"))
        {
            ConsoleTextDisplayer.DisplayConsoleText($"Modifying selected favorite (Program will exit automatically when done)\n", arguments.NoPrompt);
            WaifuImFavorite favorite = await client.ToggleFavoriteAsync(arguments.Token, new WaifuImFavoriteSettings() { ImageId = image.ImageId.Value });
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred with this program: " + ex.Message);
    Console.ReadKey();
}

