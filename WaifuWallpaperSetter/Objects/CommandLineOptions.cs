using CommandLine;
using WaifuImAPI_NET.Models;

namespace WaifuWallpaperSetter.Objects
{
    public class CommandLineOptions
    {
        [Option(longName: "token", Required = false, HelpText = "Token used for favorites", Default = null)]
        public string Token { get; set; }

        [Option(longName: "userid", Required = false, HelpText = "User ID", Default = null)]
        public uint UserId { get; set; }

        [Option(longName: "includetags", Required = false, HelpText = "Tags to include with image searches", Default = null)]
        public IEnumerable<Tags>? IncludedTags { get; set; }

        [Option(longName: "excludetags", Required = false, HelpText = "Tags to exclude with image searches", Default = null)]
        public IEnumerable<Tags>? ExcludedTags { get; set; }

        [Option(longName: "nsfw", Required = false, HelpText = "If returned images should be NSFW (not safe for work)", Default = false)]
        public bool? IsNsfw { get; set; }

        [Option(longName: "gif", Required = false, HelpText = "If returned images should only be in .GIF format", Default = null)]
        public bool? OnlyGif { get; set; }

        [Option(longName: "order", Required = false, HelpText = "The orientation returned images should be in", Default = Order.Random)]
        public Order? OrderBy { get; set; }

        [Option(longName: "orientation", Required = false, HelpText = "The orientation returned images should be in", Default = null)]
        public Orientation? Orientation { get; set; }

        [Option(longName: "includefiles", Required = false, HelpText = "Files to include with image searches", Default = null)]
        public IEnumerable<string>? IncludedFiles { get; set; }

        [Option(longName: "excludefiles", Required = false, HelpText = "Files to exclude with image searches", Default = null)]
        public IEnumerable<string>? ExcludedFiles { get; set; }

        [Option(longName: "favorites", Required = false, HelpText = "Only look from favorites (required token to be added)", Default = false)]
        public bool? OnlyFavorites { get; set; }

        [Option(longName: "fit", Required = false, HelpText = "The re-sizing that takes place when the image that is added to the desktop", Default = null)]
        public Wallpaper.Style? Fit { get; set; }

        [Option(longName: "imageloc", Required = false, HelpText = "Location of path to save downloaded image from search to", Default = null)]
        public string ImageLocation { get; set; }

        [Option(longName: "noprompt", Required = false, HelpText = "Don't display any message prompts ", Default = false)]
        public bool NoPrompt { get; set; }
    }
}
