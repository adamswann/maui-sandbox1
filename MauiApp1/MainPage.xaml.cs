namespace MauiApp1;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);

    }

    private async void OnBrowserClicked(object sender, EventArgs e) {
        Uri uri = new Uri("https://www.twitter.com");
        await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
    }

    private  void OnAlertClicked(object sender, EventArgs e) {
        DisplayAlert("Alert", "Hello, World.", "OK");
    }
    private async void OnPickerClicked(object sender, EventArgs e)
    {

        var customFileType = new FilePickerFileType(
                new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.iOS, new[] { "public.text" } }, // UTType values
                    { DevicePlatform.Android, new[] { "text/*" } }, // MIME type
                    { DevicePlatform.WinUI, new[] { ".txt" } }, // file extension
                    { DevicePlatform.Tizen, new[] { "*/*" } },
                    { DevicePlatform.macOS, new[] { "txt" } }, // UTType values
                });

        PickOptions options = new()
        {
            PickerTitle = "Please select a text file",
            FileTypes = customFileType,
        };

        var result = await FilePicker.Default.PickAsync(options);

        if (result == null) {
            await DisplayAlert("Alert", $"You picked nothing.", "OK");
        } else { 
            await DisplayAlert("Alert", $"You picked {result?.FileName}.", "OK");
        }
        
    }
}

