using KsWare.Maui.Controls;

namespace MauiEssentialsApp1.Pages;
using static UIBuilder;

public class LauncherPage : ContentPage {

	private Entry _linkEntry;

	public LauncherPage() {
		Title = "Launcher";
		Content = new StackLayout {
			Spacing = 6,
			Children = {
				Entry(out _linkEntry, "Application url").Invoke(e=>e.Text="maps://home"),
				Button("Launch",OnLaunchUrl),
				Button("Launch file...",OnLaunchFile)
			}
		};
	}

	private async void OnLaunchUrl() {
		if (await Launcher.CanOpenAsync(_linkEntry.Text)) {
			await Launcher.OpenAsync(_linkEntry.Text);
		}
	}
	
	private async void OnLaunchFile() {
		var fileResult = await FilePicker.PickAsync();
		var request = new OpenFileRequest("Open it", fileResult);
		await Launcher.OpenAsync(request);
	}
}