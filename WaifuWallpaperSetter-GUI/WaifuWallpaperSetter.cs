using Ookii.Dialogs.WinForms;
using WaifuImAPI_NET;
using WaifuImAPI_NET.Models.Enums;
using WaifuImAPI_NET.Models.Objects;
using WaifuImAPI_NET.Models.Objects.Lists;

namespace WaifuWallpaperSetter_GUI
{
    public partial class WaifuWallpaperSetter : Form
    {
        public WaifuWallpaperSetter()
        {
            InitializeComponent();
        }

        private void WaifuWallpaperSetter_Load(object sender, EventArgs e)
        {
            TXT_IncludedTags.Text = Properties.Settings.Default.IncludedTags;
            TXT_ExcludedTags.Text = Properties.Settings.Default.ExcludedTags;
            TXT_IncludedFiles.Text = Properties.Settings.Default.IncludedFiles;
            TXT_ExcludedFiles.Text = Properties.Settings.Default.ExcludedFiles;
            CBX_OrderBy.SelectedIndex = Properties.Settings.Default.OrderByIndex;
            CBX_Orientation.SelectedIndex = Properties.Settings.Default.OrientationIndex;
            CHK_NsfwResults.Checked = Properties.Settings.Default.AllowNsfw;
            CHK_OnlyGif.Checked = Properties.Settings.Default.OnlyGifs;
            TXT_ImageLocation.Text = Properties.Settings.Default.ImageLocation;
            CBX_WallpaperFit.SelectedIndex = Properties.Settings.Default.WallpaperFitIndex;
            CHK_OnlyFavorites.Checked = Properties.Settings.Default.OnlySearchFavorites;
        }

        private void WaifuWallpaperSetter_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.IncludedTags = TXT_IncludedTags.Text;
            Properties.Settings.Default.ExcludedTags = TXT_ExcludedTags.Text;
            Properties.Settings.Default.IncludedFiles = TXT_IncludedFiles.Text;
            Properties.Settings.Default.ExcludedFiles = TXT_ExcludedFiles.Text;
            Properties.Settings.Default.OrderByIndex = CBX_OrderBy.SelectedIndex;
            Properties.Settings.Default.OrientationIndex = CBX_Orientation.SelectedIndex;
            Properties.Settings.Default.AllowNsfw = CHK_NsfwResults.Checked;
            Properties.Settings.Default.OnlyGifs = CHK_OnlyGif.Checked;
            Properties.Settings.Default.ImageLocation = TXT_ImageLocation.Text;
            Properties.Settings.Default.WallpaperFitIndex = CBX_WallpaperFit.SelectedIndex;
            Properties.Settings.Default.OnlySearchFavorites = CHK_OnlyFavorites.Checked;
            Properties.Settings.Default.Save();
        }

        private async void BTN_DownloadSetWallpaper_Click(object sender, EventArgs e)
        {
            try
            {
                WaifuImClient client = new WaifuImClient();
                string[] includedTags = !string.IsNullOrWhiteSpace(TXT_IncludedTags.Text) ? TXT_IncludedTags.Text.Replace(" ", "").Trim().Split(',') : null;
                string[] excludedTags = !string.IsNullOrWhiteSpace(TXT_ExcludedTags.Text) ? TXT_ExcludedTags.Text.Replace(" ", "").Trim().Split(',') : null;
                string[] includedFiles = !string.IsNullOrWhiteSpace(TXT_IncludedFiles.Text) ? TXT_IncludedFiles.Text.Replace(" ", "").Trim().Split(',') : null;
                string[] excludedFiles = !string.IsNullOrWhiteSpace(TXT_ExcludedFiles.Text) ? TXT_ExcludedFiles.Text.Replace(" ", "").Trim().Split(',') : null;
                WaifuImSearchSettings settings = new WaifuImSearchSettings()
                {
                    IncludedTags = GetTags(includedTags),
                    ExcludedTags = GetTags(excludedTags),
                    IncludedFiles = includedFiles,
                    ExcludedFiles = excludedFiles,
                    OrderBy = GetOrder(CBX_OrderBy.SelectedItem.ToString()),
                    Orientation = GetOrientation(CBX_Orientation.SelectedItem.ToString()),
                    IsNsfw = CHK_NsfwResults.Checked,
                    OnlyGif = CHK_OnlyGif.Checked
                };

                WaifuImImageList list = new WaifuImImageList();
                if (CHK_OnlyFavorites.Checked && !string.IsNullOrWhiteSpace(TXT_Token.Text))
                {
                    list = await client.GetFavoritesAsync(TXT_Token.Text, settings);
                }
                else
                {
                    CHK_OnlyFavorites.Checked = false;
                    list = await client.GetImagesAsync(settings);
                }

                WaifuImImage image = list.Images[0];
                string extension = image.Extension;
                string location = !string.IsNullOrWhiteSpace(TXT_ImageLocation.Text) && Directory.Exists(TXT_ImageLocation.Text) ? TXT_ImageLocation.Text : Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string path = Path.Combine(location, $"image_{image.ImageId}{extension}");
                bool hasToken = !string.IsNullOrWhiteSpace(TXT_Token.Text);

                bool isInFavorites = CHK_OnlyFavorites.Checked && hasToken;
                if (!CHK_OnlyFavorites.Checked && hasToken)
                {
                    list = await client.GetFavoritesAsync(TXT_Token.Text, settings);
                    foreach (WaifuImImage img in list.Images)
                    {
                        if (img.ImageId == image.ImageId)
                        {
                            isInFavorites = true;
                        }
                    }
                }

                HttpClient httpClient = new HttpClient();
                byte[] wallpaperImage = await httpClient.GetByteArrayAsync(image.Url);
                await File.WriteAllBytesAsync(path, wallpaperImage);

                Wallpaper.Style style = Wallpaper.Style.Fill;
                if (image.Height > image.Width)
                {
                    style = Wallpaper.Style.Fit;
                }

                Wallpaper.Style? overrideStyle = GetStyle(CBX_WallpaperFit.SelectedText);
                if (overrideStyle.HasValue)
                {
                    style = overrideStyle.Value;
                }

                Wallpaper.Set(path, style);
                MessageBox.Show("Wallpaper has been set!", "Set wallpaper", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (hasToken)
                {
                    string messageDescriptor = isInFavorites ? "removed from" : "added to";
                    string titleDescriptor = isInFavorites ? "Remove from" : "Add to";
                    DialogResult result = MessageBox.Show($"Would you like this to be {messageDescriptor} your favorites?", $"{titleDescriptor} favorites?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        await client.InsertFavoriteAsync(TXT_Token.Text, new WaifuImFavoriteSettings() { ImageId = image.ImageId.Value });
                        MessageBox.Show($"Image has been {messageDescriptor} your favorites", "Favorite modified", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occurred: {ex.Message}", "Error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTN_Open_Click(object sender, EventArgs e)
        {
            VistaFolderBrowserDialog dialog = new VistaFolderBrowserDialog()
            {
                Description = "Select folder for downloaded files",
                UseDescriptionForTitle = true
            };
            DialogResult selectedFolder = dialog.ShowDialog();
            if (selectedFolder == DialogResult.OK)
            {
                TXT_ImageLocation.Text = dialog.SelectedPath;
            }
            dialog.Dispose();
        }

        private Tags[] GetTags(string[] array)
        {
            List<Tags> tags = new List<Tags>();
            if (array != null)
            {
                foreach (string str in array)
                {
                    if (Enum.TryParse(str, out Tags tag))
                    {
                        tags.Add(tag);
                    }
                }
                return tags.ToArray();
            }
            else
            {
                return null;
            }
        }

        private WaifuImAPI_NET.Models.Enums.Orientation? GetOrientation(string value)
        {
            return Enum.TryParse(value, out WaifuImAPI_NET.Models.Enums.Orientation order) ? order : null;
        }

        private Order? GetOrder(string value)
        {
            return Enum.TryParse(value, out Order order) ? order : null;
        }

        private Wallpaper.Style? GetStyle(string value)
        {
            return Enum.TryParse(value, out Wallpaper.Style style) ? style : null;
        }
    }
}