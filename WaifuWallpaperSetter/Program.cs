using CommandLine;
using CommandLine.Text;
using WaifuImAPI_NET;
using WaifuImAPI_NET.Models.Objects;
using WaifuImAPI_NET.Models.Objects.Lists;
using WaifuWallpaperSetter.Objects;

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
    string extension = (arguments.OnlyGif.HasValue && arguments.OnlyGif.HasValue) ? ".gif" : image.Extension;
    string location = !string.IsNullOrWhiteSpace(arguments.ImageLocation) && Directory.Exists(arguments.ImageLocation) ? arguments.ImageLocation : Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
    string path = Path.Combine(location, $"image_{image.ImageId}{extension}");

    Console.WriteLine($"Downloading image from Waifu.Im with image URL of \"{image.Url}\" to \"{path}\"\n");
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

    Console.WriteLine($"Setting wallpaper with fit of \"{style}\" to image from \"{path}\"\n");
    Wallpaper.Set(path, style);

    Console.Write("Would you like to add/remove this image from your favorites? (Type y or n)\nYour choice: ");
    char c = Console.ReadKey().KeyChar;
    Console.WriteLine();
    Console.WriteLine();

    if (c.ToString().ToLowerInvariant().Equals("y"))
    {
        string token = "";
        if (!string.IsNullOrWhiteSpace(arguments.Token))
        {
            token = arguments.Token;
        }
        else
        {
            Console.Write($"Enter your token here: ");
            token = Console.ReadLine();
            Console.WriteLine();
        }

        Console.WriteLine($"Modifying selected favorite\n");
        WaifuImFavorite favorite = await client.ToggleFavoriteAsync(arguments.Token, new WaifuImFavoriteSettings() { ImageId = image.ImageId.Value });
    }
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred with this program: " + ex.Message);
    Console.ReadKey();
}

