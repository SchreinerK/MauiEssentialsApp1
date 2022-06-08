using KsWare.Maui.Controls;
using static KsWare.Maui.Controls.UIBuilder;
using Label = Microsoft.Maui.Controls.Label;
namespace MauiEssentialsApp1.Pages;

public partial class LightDarkPage : ContentPage {

	private readonly Picker _userAppThemePicker;

	public LightDarkPage() {
		InitializeComponent();

		RootLayout.Children.AddRange(new IView[] {
			new Label {
				Text = "SetAppThemeColor"
			}.Invoke(l => l.SetAppThemeColor(Label.TextColorProperty, Color.FromArgb("#FF2B2B2B"), Colors.LightGray)),
			new Label {
				Text = "SetAppThemeColor"
			}.SetAppAutoThemeColor(Label.TextColorProperty, Color.FromArgb("#FF2B2B2B")),
			Property<Picker>("UserAppTheme", out _userAppThemePicker)
		});

		_userAppThemePicker.ItemsSource = Enum.GetValues<AppTheme>().ToList();
		_userAppThemePicker.SelectedItem = Application.Current.UserAppTheme;
		_userAppThemePicker.SelectedIndexChanged += (s, e) =>
			Application.Current.UserAppTheme = (AppTheme) _userAppThemePicker.SelectedItem;
		
		Application.Current.RequestedThemeChanged += (s, a) => {
			// Respond to the theme change
		};
	}

}