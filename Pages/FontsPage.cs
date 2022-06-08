namespace MauiEssentialsApp1.Pages;

public class FontsPage : ContentPage {

	public FontsPage() {
		Title = "Fonts";
		Content = new StackLayout {
			Children = {
				new Label {Text = "default"},
				new Label {Text = "cursive", FontFamily = "cursive"},
				new Label {Text = "fantasy", FontFamily = "fantasy"},
				new Label {Text = "monospace", FontFamily = "monospace"},
				new Label {Text = "serif", FontFamily = "serif"},
				new Label {Text = "sans-serif", FontFamily = "sans-serif"},
			}
		};
	}

}