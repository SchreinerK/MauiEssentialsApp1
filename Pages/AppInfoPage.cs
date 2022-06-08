// App information
// https://docs.microsoft.com/en-us/dotnet/maui/platform-integration/appmodel/app-information?tabs=android
using static KsWare.Maui.Controls.UIBuilder;
namespace MauiEssentialsApp1.Pages;

public class AppInfoPage : ContentPage {

	public AppInfoPage() {
		Title = "AppInfo";
		Content = new StackLayout {
			Spacing = 6,
			Children = {
				TextProperty("Name",AppInfo.Name),
				TextProperty("BuildString",AppInfo.BuildString),
				TextProperty("PackageName",AppInfo.PackageName),
				TextProperty("VersionString",AppInfo.VersionString),
				TextProperty("PackagingModel",AppInfo.PackagingModel),
				TextProperty("RequestedLayoutDirection",AppInfo.RequestedLayoutDirection),
				TextProperty("RequestedTheme",AppInfo.RequestedTheme),
				TextProperty("Version",AppInfo.Version),
				Button("Open Settings", AppInfo.ShowSettingsUI)
			}
		};
	}

}