# Using WaifuWallpaperSetter Console
WaifuWallpaperSetter has an included version as a barebones console with optional search parameters. The program can be run as is from the .exe or from a .bat (match) script. Below are the parameters you can add to a .bat script:

### Parameters:
```
--token (text) - Specifies the account to modify favorites to (Requires an account on waifu.im)
--userid (number) - Specifies the user to modify favorites for (if authorized)
--includetags (Waifu Maid etc) - Specifies the images with tags to include when searching 
--excludetags (Waifu Maid etc) - Specifies the images with tags to not include when searching
--nsfw (true/false) - Specifies if the images should also be not safe for work
--gif (true/false) - Specifies if the images should only be in .GIF file format
--order (Favorites, UploadedAt, Random, LikedAt) - Specifies the order in which images in a search should be
--orientation (Landscape, Portrait) - Specifies the rotation the returned images should be
--includefiles (file1.png file2.jpg etc) - Specifies the image files to include in the search
--excludefiles (file1.png file2.jpg etc) - Specifies the image files to exclude in the search
--favorites (true/false) - Specifies if the search should only look at your favorites (Requires token)
--fit (Fill, Fit, Center, Stretch, Tile, Span) - Overrides the automatic fit
--imageloc (location) - Specifies a location downloaded images are, default is user's desktop
--noprompt (true/false) - (Doesn't show any console messages and doesn't ask to add/remove image to/from favorites)
```

### Example:
```
WaifuWallpaperSetter.exe --includetags Waifu Maid --fit Fill --orientation Landscape --order Favorites 
--nsfw false --imageloc "C:\"
```

### Tag Reference:
[Tags](https://www.waifu.im/docs/#tags)