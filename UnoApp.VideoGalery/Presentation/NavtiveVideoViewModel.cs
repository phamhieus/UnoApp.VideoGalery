using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoApp.VideoGalery.Presentation;
internal partial class NavtiveVideoViewModel : ObservableObject
{
    [ObservableProperty]
    private string _videoSource = "ms-appx:///Assets/Videos/sample.mp4";

    public NavtiveVideoViewModel()
    {
    }

    private void ShowPopupLoadVideo()
    {
        // Logic to load or prepare the video can be added here
    }
}
