using KsWare.Maui.Controls;

namespace MauiEssentialsApp1.Pages;
using static UIBuilder;

public class VersionTrackingPage : ContentPage {

	public VersionTrackingPage() {
		Title = "VersionTracking";
		Content = new StackLayout {
			Spacing = 6,
			Children = {
				TextProperty("CurrentVersion",$"{VersionTracking.CurrentVersion} (build {VersionTracking.CurrentBuild})"),
				TextProperty("FirstInstalledVersion",$"{VersionTracking.PreviousVersion} (build {VersionTracking.PreviousBuild})"),
				TextProperty("FirstInstalledVersion",$"{VersionTracking.FirstInstalledVersion} (build {VersionTracking.FirstInstalledBuild})"),
				TextProperty("IsFirstLaunchEver",VersionTracking.IsFirstLaunchEver),
				TextProperty("IsFirstLaunchForCurrentVersion",VersionTracking.IsFirstLaunchForCurrentVersion),				
				TextProperty("IsFirstLaunchForCurrentBuild",VersionTracking.IsFirstLaunchForCurrentBuild),
				TextProperty("History","  "+string.Join("\n  ", VersionTracking.VersionHistory)),
			}
		}.Margins(10,0,10,0);
	}

}