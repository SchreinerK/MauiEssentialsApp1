namespace MauiEssentialsApp1.StorageSamples;

public class SecureStoragePage : ContentPage {

	private readonly Entry _secretEntry;

	public SecureStoragePage() {
		Content = new VerticalStackLayout {
			Children = {
				new Label{Text = "SecureStorage"},
				new Entry{Placeholder = "Put in you secret"}.Assign(out _secretEntry),
				new Button{Text = "Save"}.Invoke(b=>b.Clicked+=SaveClicked),
				new Button{Text = "Show"}.Invoke(b=>b.Clicked+=ShowClicked),
			}
		};
	}

	private async void SaveClicked(object sender, EventArgs e) {
		await SecureStorage.SetAsync("secret", _secretEntry.Text);
	}

	private async void ShowClicked(object sender, EventArgs e) {
		var secret = await SecureStorage.GetAsync("secret");
		await DisplayAlert($"Your secret is", secret ?? "(none)", "OK");
	}

}