using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using Windows.Media.Core;
using Windows.Storage.Pickers;

namespace UnoApp.VideoGalery.Presentation;
internal partial class NavtiveVideoViewModel : ObservableObject
{
    [ObservableProperty]
    private MediaSource _videoSource;

    public NavtiveVideoViewModel()
    {
        VideoSource = MediaSource.CreateFromUri(new Uri ("ms-appx:///Assets/Videos/sample.mp4"));
    }

    [RelayCommand]
    private async Task ShowPopupLoadVideo()
    {
        var picker = new FileOpenPicker
        {
            SuggestedStartLocation = PickerLocationId.VideosLibrary
        };

        picker.FileTypeFilter.Add(".mp4");
        picker.FileTypeFilter.Add(".avi");
        picker.FileTypeFilter.Add(".mkv");
        picker.FileTypeFilter.Add(".mov");
        picker.FileTypeFilter.Add(".wmv");

        var file = await picker.PickSingleFileAsync();
        if (file is null) return;

        var copied = await file.CopyAsync(
            ApplicationData.Current.LocalFolder,
            file.Name,
            NameCollisionOption.GenerateUniqueName);

        var uri = new Uri($"ms-appdata:///local/{copied.Name}");

        VideoSource = MediaSource.CreateFromUri(uri);
    }
}
