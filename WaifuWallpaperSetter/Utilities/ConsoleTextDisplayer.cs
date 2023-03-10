namespace WaifuWallpaperSetter.Utilities
{
    public static class ConsoleTextDisplayer
    {
        public static void DisplayConsoleText(string text, bool shouldNotDisplay)
        {
            if (!shouldNotDisplay)
            {
                Console.WriteLine(text);
            }
        }
    }
}
