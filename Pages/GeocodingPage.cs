using static KsWare.Maui.Controls.UIBuilder;

namespace MauiEssentialsApp1.Pages;

public class GeocodingPage : ContentPage {

	private readonly Entry _addressEntry;
	private readonly Label _positionLabel;

	public GeocodingPage() {
		Title = "Geocoding";
		Content = new StackLayout {
			Children = {
				Entry(out _addressEntry, "Address"),
				Button("Get Location", Clicked),
				Label(out _positionLabel, "")
			}
		};
	}

	private async void Clicked(object? sender, EventArgs e) {
		try {
			_positionLabel.Text = "";
			var result = await Geocoding.GetLocationsAsync(_addressEntry.Text);
			foreach (var location in result) {
				if (_positionLabel.Text.Length > 0) _positionLabel.Text += "\n";
				_positionLabel.Text += $"{location.Altitude},{location.Longitude}";
				var result2 = await Geocoding.GetPlacemarksAsync(location);
				foreach (var placemark in result2) {
					_positionLabel.Text += "\n  ";
					_positionLabel.Text += $"{placemark.Locality}, {placemark.CountryName}";
					_positionLabel.Text += $"\n  {placemark.Thoroughfare} {placemark.FeatureName}";
				}
			}
		}
		catch {

		}
	}

}