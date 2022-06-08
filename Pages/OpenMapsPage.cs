using Microsoft.Maui.Controls.Shapes;

namespace MauiEssentialsApp1.Pages;

public class OpenMapsPage : ContentPage {

	private Entry _coordinatesEntry;
	private Entry _locationEntry;
	private Entry _countryNameEntry;
	private Entry _localityEntry;
	private Entry _thoroughfareEntry;
	private Switch _navigationSwitch;

	public OpenMapsPage() {
		Content = new StackLayout {
			Children = {
				new Entry {Placeholder = "Coordinates e.g 52.516,13.377", Text = "52.5162697,13.3776789"}.Assign(out _coordinatesEntry),
				new Button {Text = "Open Maps"}.Invoke(b=>b.Clicked+=OpenMapsWithCoordinatesClicked),
				___,
				new Entry {Placeholder = "Country e.g. Deutschland ", Text = "Deutschland"}.Assign(out _countryNameEntry),
				new Entry {Placeholder = "Locality e.g Berlin", Text = "Berlin"}.Assign(out _localityEntry),
				new Entry {Placeholder = "Thoroughfare e.g Brandenburger Tor", Text = "Brandenburger Tor"}.Assign(out _thoroughfareEntry),
				new HorizontalStackLayout {
					new Label{Text = "Navigation",VerticalOptions = LayoutOptions.Center},
					new Switch().Assign(out _navigationSwitch),
				},
				new Button {Text = "Open Maps"}.Invoke(b=>b.Clicked+=OpenMapsWithPlacemarkClicked),
			}
		};
	}

	private async void OpenMapsWithCoordinatesClicked(object? sender, EventArgs e) {
		if(!PointF.TryParse(_coordinatesEntry.Text.Replace(" ",""), out var point)) {
			await DisplayAlert("Oops", "The coordinates are incorrectly formatted.\nUse e.g. 52.516,13.377", "OK");
			return;
		}
		if(_navigationSwitch.IsToggled)
			await Map.TryOpenAsync(point.X, point.Y, new MapLaunchOptions{NavigationMode = NavigationMode.Default});
		else 
			await Map.TryOpenAsync(point.X, point.Y);
		
	}

	private async void OpenMapsWithPlacemarkClicked(object? sender, EventArgs e) {
		var placemark=new Placemark {
			CountryName = _countryNameEntry.Text,
			// CountryCode = ,
			// AdminArea = ,
			// SubAdminArea = ,
			// FeatureName = ,
			Locality = _localityEntry.Text,
			// SubLocality = ,
			// PostalCode = ,
			Thoroughfare = _thoroughfareEntry.Text, // Stadtviertel/Straße/Verkehrsweg
			// SubThoroughfare = 
		};
		var options = new MapLaunchOptions {
			NavigationMode = NavigationMode.Default
		};

		if(_navigationSwitch.IsToggled)
			await Map.TryOpenAsync(placemark, options);
		else 
			await Map.TryOpenAsync(placemark);
		
	}

	private async void OpenMapsWithLocationClicked(object? sender, EventArgs e) {

		await Map.TryOpenAsync(52.5207968, 13.4094517,
			new MapLaunchOptions {Name = "Route", NavigationMode = NavigationMode.Walking});
		// or location.OpenMapsAsync()
	}

	private static IView ___ => new Line(0, 0, 0, 6);

}