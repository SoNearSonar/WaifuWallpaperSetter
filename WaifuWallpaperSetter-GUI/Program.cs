namespace WaifuWallpaperSetter_GUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Checks if the OS is Windows and the version is Windows 8 or higher
            bool isNotWindowsPlatform = Environment.OSVersion.Platform != PlatformID.Win32NT;
            bool isNotCompatibleWindowsPlatform = Environment.OSVersion.Version.Major + Environment.OSVersion.Version.Minor < 8;

            if (isNotWindowsPlatform || isNotCompatibleWindowsPlatform)
            {
                MessageBox.Show("You can only run this program on Windows 8 or higher", "Unsupported OS", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new WaifuWallpaperSetter());
        }
    }
}