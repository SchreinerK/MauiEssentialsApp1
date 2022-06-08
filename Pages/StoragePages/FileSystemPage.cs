// File system helpers
// https://docs.microsoft.com/en-us/dotnet/maui/platform-integration/storage/file-system-helpers?tabs=windows

namespace MauiEssentialsApp1.StorageSamples;

public class FileSystemPage : ContentPage {

	public FileSystemPage() {

		Content = new StackLayout {
			Children = {
				new Label {Text = "File system helpers"},
				new Label(),
				new Label {Text = "Cache directory"},
				new Label {Text = "FileSystem.Current.CacheDirectory", FontFamily = "monospace"},
				new Label {Text = FileSystem.Current.CacheDirectory},
				new Label(),
				new Label {Text = "App data directory"},
				new Label {Text = "FileSystem.Current.AppDataDirectory", FontFamily = "monospace"},
				new Label {Text = FileSystem.Current.AppDataDirectory},
				new Label(),
				new Button {Text = "Open bundled file"}.Invoke(b => b.Clicked += OpenBundledFileOnClicked),
				new Label {Text = "FileSystem.OpenAppPackageFileAsync", FontFamily = "monospace"},
			}
		};
	}

	private async void OpenBundledFileOnClicked(object sender, EventArgs e) {
		using var fileStream = await FileSystem.Current.OpenAppPackageFileAsync(@"Resources\Sample.txt");
		using var reader = new StreamReader(fileStream);
		var text = await reader.ReadToEndAsync();
		await DisplayAlert("Content", text, "OK");
	}

}