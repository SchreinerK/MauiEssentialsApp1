using static KsWare.Maui.Controls.UIBuilder;

namespace MauiEssentialsApp1.Pages;

public class DeviceInfoPage : ContentPage {

	public DeviceInfoPage() {
		Title = "Device Info";
		Content = new StackLayout {
			Spacing = 6,
			Children = {
				TextProperty("Name", DeviceInfo.Name),
				TextProperty("Manufacturer", DeviceInfo.Manufacturer),
				TextProperty("Model",DeviceInfo.Model),
				TextProperty("DeviceType",DeviceInfo.DeviceType),
				TextProperty("Platform", DeviceInfo.Platform),
				TextProperty("VersionString", DeviceInfo.VersionString),
				TextProperty("Idiom",DeviceInfo.Idiom),
			}
		}.Margins(10,0,10,0);
	}

}