namespace MauiEssentialsApp1.StorageSamples;

public class FilePickerPage : ContentPage {
	// Pick a file
	// https://docs.microsoft.com/en-us/dotnet/maui/platform-integration/storage/file-picker

	public FilePickerPage() {
		var customFileType = new FilePickerFileType(
			new Dictionary<DevicePlatform, IEnumerable<string>> {
				{ DevicePlatform.iOS, new[] { "public.my.comic.extension" } }, // or general UTType values
				{ DevicePlatform.Android, new[] { "application/comics" } },
				{ DevicePlatform.WinUI, new[] { ".cbr", ".cbz" } },
				{ DevicePlatform.Tizen, new[] { "*/*" } },
				{ DevicePlatform.macOS, new[] { "cbr", "cbz" } }, // or general UTType values
			});
		var customOptions = new PickOptions () {
			PickerTitle = "Please select a comic file",
			FileTypes = customFileType,
		};

		Content = new StackLayout {
			Children = {
				new Label {Text = "FilePicker", FontSize = 36},
				new CheckBox().Assign(out CheckBox multiselectCheckBox),
				new Button {Text = "Pick File"}.Invoke(b => b.Clicked += async (s, e) => await PickAndShow(PickOptions.Default, multiselectCheckBox.IsChecked)),
				new Button {Text = "Pick Image"}.Invoke(b => b.Clicked += async (s, e) => await PickAndShow(PickOptions.Images, multiselectCheckBox.IsChecked)),
				new Button {Text = "Pick Custom"}.Invoke(b => b.Clicked += async (s, e) => await PickAndShow(customOptions, multiselectCheckBox.IsChecked)),
			}
		};
	}

	public async Task PickAndShow(PickOptions options, bool multiSelect) {
		try {
			if (multiSelect) {
				var fileResult = await FilePicker.Default.PickMultipleAsync(options);
				var text = string.Join("\n", fileResult.Select(r => $"{r.ContentType}\n{r.FileName}"));
				if (text == String.Empty) text = "nothing";
				await DisplayAlert("You picked...", text, "OK");
			}
			else {
				var fileResult = await FilePicker.Default.PickAsync(options);
				var text = fileResult != null ? $"{fileResult.ContentType}\n{fileResult.FileName}" : "nothing";

				if (fileResult != null) {
					if (fileResult.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
					    fileResult.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase)) {
						await using var stream = await fileResult.OpenReadAsync();
						var image = ImageSource.FromStream(() => stream);
					}
				}
				else {
					await DisplayAlert("You picked...", text, "OK");
				}				
			}
		}
		catch (Exception ex) {
			// The user canceled or something went wrong
			await DisplayAlert("Ooops, something went wrong...", ex.Message, "OK");
		}
	}

}