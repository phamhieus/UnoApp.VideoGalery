namespace UnoApp.VideoGalery.Presentation;

public partial class MainViewModel : ObservableObject
{
    private INavigator _navigator;
    public string? Title { get; }
    public ICommand GotoNativeVideo { get; }
    public ICommand GotoVLCVideo { get; }

    public MainViewModel(
        IStringLocalizer localizer,
        IOptions<AppConfig> appInfo,
        INavigator navigator)
    {
        _navigator = navigator;
        Title = "Main";
        Title += $" - {localizer["ApplicationName"]}";
        Title += $" - {appInfo?.Value?.Environment}";

        GotoVLCVideo = new AsyncRelayCommand(GotoVLCVideoView);
        GotoNativeVideo = new AsyncRelayCommand(GotoNativeVideoView);
    }

    private async Task GotoNativeVideoView()
    {
        await _navigator.NavigateViewModelAsync<NavtiveVideoViewModel>(this);

    }

    private async Task GotoVLCVideoView()
    {
        await _navigator.NavigateViewModelAsync<VLCVideoViewModel>(this);
    }

}
