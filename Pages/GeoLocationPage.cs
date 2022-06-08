// Geolocation
// https://docs.microsoft.com/de-de/dotnet/maui/platform-integration/device/geolocation?tabs=windows

using Microsoft.Maui.Dispatching;

namespace MauiEssentialsApp1.Pages;

public class GeoLocationPage : ContentPage {

	private static readonly Dictionary<GeolocationAccuracy, string> _accuracyDic = new() {
#if ANDROID
		{GeolocationAccuracy.Default, ""},
		{GeolocationAccuracy.Lowest, "500"},
		{GeolocationAccuracy.Low, "500"},
		{GeolocationAccuracy.Medium, "100-500"},
		{GeolocationAccuracy.High, "0-100"},
		{GeolocationAccuracy.Best, "0-100"},
#elif IOS || MACCATALYST
		{GeolocationAccuracy.Default, ""},
		{GeolocationAccuracy.Lowest, "3000"},
		{GeolocationAccuracy.Low, "1000"},
		{GeolocationAccuracy.Medium, "100"},
		{GeolocationAccuracy.High, "10"},
		{GeolocationAccuracy.Best, "~0"},
#elif WINDOWS
		{GeolocationAccuracy.Default, ""},
		{GeolocationAccuracy.Lowest, "1000-5000"},
		{GeolocationAccuracy.Low, "300-3000"},
		{GeolocationAccuracy.Medium, "100-500"},
		{GeolocationAccuracy.High, "<= 10"},
		{GeolocationAccuracy.Best, "<= 10"},
#endif
	};
	private static readonly Dictionary<GeolocationAccuracy, string> _accuracyDescriptionDic = new() {
		{GeolocationAccuracy.Default, "Default accuracy (Medium), typically within {0} meters."}, 
		{GeolocationAccuracy.Lowest, "Lowest accuracy, using the least power to obtain and typically within {0} meters."},
		{GeolocationAccuracy.Low, "Low accuracy, typically within {0} meters."},
		{GeolocationAccuracy.Medium, "Medium accuracy, typically within {0} meters."},
		{GeolocationAccuracy.High, "High accuracy, typically within {0} meters.0"},
		{GeolocationAccuracy.Best, "Best accuracy, using the most power to obtain and typically within {0} meters."},
	};
	private readonly Label _positionLabel;
	private readonly Picker _accuracyPicker;

	private readonly Label _accuracyDescriptionLabel;
	private Switch _requestFullAccuracySwitch;
	private CancellationTokenSource _cancelTokenSource;
	private readonly ProgressBar _progressBar;
	private IDispatcherTimer? _timer;
	private DateTime _timeoutTime;
	private readonly Button _cancelButton;
	private readonly Button _updateButton;
	private Slider _accuracySlider;
	private Location? _location;
	private Button _openInMapsButton;

	public GeoLocationPage() {
		Title = "Geolocation";
		Content = new StackLayout {
			Children = {
				new Label{Text = "Accuracy:"},
				new Picker{
					IsVisible = false,
					Items = {
						nameof(GeolocationAccuracy.Default),
						nameof(GeolocationAccuracy.Lowest),
						nameof(GeolocationAccuracy.Low),
						nameof(GeolocationAccuracy.Medium),
						nameof(GeolocationAccuracy.High),
						nameof(GeolocationAccuracy.Best),
					},
					SelectedIndex = 3
				}.Assign(out _accuracyPicker).Invoke(p=>p.SelectedIndexChanged+=AccuracyPickerOnSelectedIndexChanged),
				new Slider{Maximum = 5, Value = 3, Minimum = 1}.Assign(out _accuracySlider).Invoke(p=>p.ValueChanged+=AccuracySliderOnValueChanged),
				new Label{TextColor = ThemeColors.Gray}.Assign(out _accuracyDescriptionLabel),
#if IOS14_0_OR_GREATER
				new HorizontalStackLayout {
					Children = {
						new Switch().Assign(out _requestFullAccuracySwitch),
						new Label{Text="Full accuracy"}
					}
				}.Margins(0,10,0,0),
#endif
				new Label {Text = "Position"}.Margins(0,10,0,0),
				new Label { }.Assign(out _positionLabel),
				new Button {Text = "Refresh"}.Assign(out _updateButton).Invoke(b => b.Clicked += OnRefreshRequested).Margins(0,10,0,0),
				new Button {Text = "Cancel", IsVisible = false}.Assign(out _cancelButton).Invoke(b => b.Clicked += OnCancelRequested).Margins(0,10,0,0),
				new ProgressBar{IsVisible = false, ProgressColor = ThemeColors.LightBlue}.Assign(out _progressBar),
				new Button {Text="Open in Maps", IsEnabled = false}.Margins(0,10,0,0).Assign(out _openInMapsButton).Invoke(b=>b.Clicked+=(s, e) => _location?.OpenMapsAsync())
			}
		}.Margins(10,0,10,0);
		AccuracyPickerOnSelectedIndexChanged(null,EventArgs.Empty);
	}

	private void AccuracySliderOnValueChanged(object? sender, ValueChangedEventArgs e) {
		var v = (int) Math.Round(e.NewValue);
		_accuracyPicker.SelectedIndex = v;
		Dispatcher.Dispatch(() => _accuracySlider.Value = v);
	}

	protected override void OnDisappearing() {
		base.OnDisappearing();
		_cancelTokenSource?.Cancel(throwOnFirstException: false);
	}

	private void OnCancelRequested(object? sender, EventArgs e) {
		_cancelTokenSource?.Cancel();
	}

	private void AccuracyPickerOnSelectedIndexChanged(object? sender, EventArgs e) {
		var v = Enum.Parse<GeolocationAccuracy>($"{_accuracyPicker.SelectedItem}");
		var v2 = v == GeolocationAccuracy.Default ? GeolocationAccuracy.Medium : v;
		_accuracyDescriptionLabel.Text = string.Format(_accuracyDescriptionDic[v], _accuracyDic[v2]);
	}

	private async void OnRefreshRequested(object? sender, EventArgs e) {
		await UpdateAsync();
	}

	protected override async void OnAppearing() {
		base.OnAppearing();
		await UpdateAsync();
	}

	protected async Task UpdateAsync() {
		_positionLabel.Text = "requesting...";
		_timeoutTime = DateTime.Now.AddMinutes(1);
		_timer = Dispatcher.CreateTimer();
		_timer.Interval = TimeSpan.FromSeconds(1);
		_timer.Tick += (s, e) => _progressBar.Progress = _timeoutTime.Subtract(DateTime.Now).TotalMinutes;
		_timer.Start();
		_progressBar.Progress = 1;
		_progressBar.IsVisible = true;
		_updateButton.IsVisible = false;
		_cancelButton.IsVisible = true;
		_cancelTokenSource = new CancellationTokenSource();
		_openInMapsButton.IsEnabled = false;

		_location = null;
		try {
			var accuracy = Enum.Parse<GeolocationAccuracy>($"{_accuracyPicker.SelectedItem}");
			var request = new GeolocationRequest(accuracy, TimeSpan.FromMinutes(1));
#if IOS14_0_OR_GREATER
			request.RequestFullAccuracy = true;
#endif
			_location = await Geolocation.GetLocationAsync(request, _cancelTokenSource.Token);
		}
		catch (FeatureNotSupportedException fnsEx) {
			// Handle not supported on device exception
			_positionLabel.Text = "ERR: Feature not supported";
			return;
		}
		catch (FeatureNotEnabledException fneEx) {
			// Handle not enabled on device exception
			_positionLabel.Text = "ERR: Feature not enabled";
			return;
		}
		catch (PermissionException pEx) {
			// 'You need to declare the capability `location` in your AppxManifest.xml file'
			_positionLabel.Text = "ERR: Feature not allowed";
			return;
		}
		catch (Exception ex) {
			// Unable to get location
			_positionLabel.Text = $"ERR: {ex.Message}";
			return;
		}
		finally {
			_timer?.Stop();
			_timer = null;
			_progressBar.IsVisible = false;
			_cancelButton.IsVisible = false;
			_updateButton.IsVisible = true;
		}

		if (_location == null) {
			_positionLabel.Text = "unknown";
			return;
		}

		_positionLabel.Text = $"Lat: {_location.Latitude}, Lng: {_location.Longitude}";
		_positionLabel.Text += $"\nIs simulated: {_location.IsFromMockProvider}";
		_positionLabel.Text += $"\nAccuracy: {_location.Accuracy}";
#if IOS14_0_OR_GREATER
		_positionLabel.Text += $"\nReduced Accuracy: {_location.ReducedAccuracy}";
#endif
		_positionLabel.Text += $"\nCourse: {_location.Course}°";
		_positionLabel.Text += $"\nSpeed: {_location.Speed} m/s ({_location.Speed*3.6} km/s)";
		_positionLabel.Text += $"\nAltitude: {_location.Altitude} m ";
		_positionLabel.Text += $"\nAccuracy: {_location.VerticalAccuracy}";
		_positionLabel.Text += $"\nReferenceSystem: {_location.AltitudeReferenceSystem}";
		_openInMapsButton.IsEnabled = true;

		// result.Accuracy;
		// result.Altitude;
		// result.AltitudeReferenceSystem;
		// result.Course;
		// result.Latitude;
		// result.Longitude;
		// result.ReducedAccuracy;
		// result.Speed;
		// result.Timestamp;
		// result.VerticalAccuracy;
	}

}

/*	Platforms\Android\AndroidManifest.xml

	<uses-permission android:name="android.permission.ACCESS_COARSE_LOCATION" />
	<uses-permission android:name="android.permission.ACCESS_FINE_LOCATION" />
	<uses-feature android:name="android.hardware.location" android:required="false" />
	<uses-feature android:name="android.hardware.location.gps" android:required="false" />
	<uses-feature android:name="android.hardware.location.network" android:required="false" />
	<uses-permission android:name="android.permission.ACCESS_BACKGROUND_LOCATION" />
*/

/*	Platforms\iOS\Info.plist

 	<key>NSLocationWhenInUseUsageDescription</key>
	<string>For using the geolocation API</string>
	<key>NSLocationTemporaryUsageDescriptionDictionary</key>
	<array>
		<dict>
			<key>TemporaryFullAccuracyUsageDescription</key>
			<string>For using the geolocation API</string>
		</dict>
	</array>
*/

/*	Platforms/Windows/Package.appxmanifest

	<Capabilities>
		<DeviceCapability Name="location"/>
	</Capabilities>
*/
