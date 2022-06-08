using MauiEssentialsApp1.Pages;
using MauiEssentialsApp1.StorageSamples;
using static KsWare.Maui.Controls.UIBuilder;
namespace MauiEssentialsApp1;

public class MainPage : ContentPage {

	public MainPage() {
		Content = new StackLayout {
			Children = {
				Label  ("Welcome to .NET MAUI!"),
				NavigationButton ("App Info", typeof(AppInfoPage)),
				NavigationButton ("Device Info", typeof(DeviceInfoPage)),
				NavigationButton ("FilePicker", typeof(FilePickerPage)),
				NavigationButton ("SecureStorage", typeof(SecureStoragePage)),
				NavigationButton ("FileSystem", typeof(FileSystemPage)),
				NavigationButton ("Share", typeof(SharePage)),
				NavigationButton ("Fonts", typeof(FontsPage)),
				NavigationButton ("Preferences", typeof(PreferencesPage)),
				NavigationButton ("Geolocation", typeof(GeoLocationPage)),
				NavigationButton ("Geocoding", typeof(GeocodingPage)),
				NavigationButton ("Open Maps", typeof(OpenMapsPage)),
				NavigationButton ("Accelerometer", typeof(AccelerometerPage)),
				NavigationButton ("VersionTracking",typeof(VersionTrackingPage)),
				NavigationButton ("Launcher",typeof(LauncherPage)),
				NavigationButton ("Text to Speech",typeof(TextToSpeechPage)),
				NavigationButton ("Layout",typeof(LayoutPage)),
				NavigationButton ("Light & Dark",typeof(LightDarkPage)),
			}
		};
		VersionTracking.Track();
	}

}