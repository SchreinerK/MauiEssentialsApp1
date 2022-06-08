namespace MauiEssentialsApp1;

public class SharePage : ContentPage {

	private readonly Entry _textEntry;

	public SharePage() {
		Content = new StackLayout {
			Children = {
				new Label {Text = "Share"},

				new Entry{Placeholder = "Text to share", Text = "Share me"}.Assign(out _textEntry),
				new Button{Text = "Share"}.Invoke(b=>b.Clicked+=ShareTextOnClicked),

				new Button{Text = "Share Image..."}.Invoke(b=>b.Clicked+=ShareImageOnClicked)
			}
		};
	}

	private async void ShareImageOnClicked(object sender, EventArgs e) {
		var image = await MediaPicker.PickPhotoAsync();
		if(image == null) return;
		await Share.RequestAsync(new ShareFileRequest {
			Title = "Share from MAUI DemoApp",
			File = new ShareFile(image)
		});
	}

	private async void ShareTextOnClicked(object sender, EventArgs e) {
		await Share.RequestAsync(_textEntry.Text, "Share from MAUI DemoApp");
	}

}