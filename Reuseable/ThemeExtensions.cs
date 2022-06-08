using Kotlin;

namespace KsWare.Maui.Controls;

// SetAppThemeColor => Microsoft.Maui.Controls
// CommunityToolkit.Maui.Markup

public static class ThemeExtensions {

	// combine SetAppThemeColor + auto dark + CommunityToolkit.Markup
	public static T SetAppAutoThemeColor<T>(this T view, BindableProperty targetProperty, Color light) where T:View{
		view.SetAppThemeColor(targetProperty, light, ThemeHelper.InvertLuminance(light));
		return view;
	}

	// combine SetAppThemeColor + TextColorProperty + auto dark + CommunityToolkit.Markup
	public static T SetAppThemeTextColor<T>(this T view, Color light) where T:View {
		if(typeof(T).IsAssignableTo(typeof(Label))) view.SetAppThemeColor(Label.TextColorProperty, light, ThemeHelper.InvertLuminance(light));
		else if(typeof(T).IsAssignableTo(typeof(Button))) view.SetAppThemeColor(Button.TextColorProperty, light, ThemeHelper.InvertLuminance(light));
		else if(typeof(T).IsAssignableTo(typeof(Entry))) view.SetAppThemeColor(Entry.TextColorProperty, light, ThemeHelper.InvertLuminance(light));
		else if (typeof(T).IsAssignableTo(typeof(Editor))) view.SetAppThemeColor(Editor.TextColorProperty, light, ThemeHelper.InvertLuminance(light));
		else if (typeof(T).IsAssignableTo(typeof(Picker))) view.SetAppThemeColor(Picker.TextColorProperty, light, ThemeHelper.InvertLuminance(light));
		// TODO add more controls
		// TODO try reflection
		else throw new NotImplementedError();
		return view;
	}

	// combine SetAppThemeColor + BackgroundColorProperty + auto dark + CommunityToolkit.Markup
	public static T SetAppThemeBackgroundColor<T>(this T view, Color light) where T:View {
		if(typeof(T).IsAssignableTo(typeof(VisualElement))) view.SetAppThemeColor(VisualElement.BackgroundColorProperty, light, ThemeHelper.InvertLuminance(light));
		else throw new NotImplementedError();
		return view;
	}

	// combine combine SetAppThemeColor + CommunityToolkit.Markup
	// name SetAppThemeColor is already in use
	public static T SetAppThemeColorExt<T>(this T view, BindableProperty targetProperty, Color light, Color dark) where T:View{
		view.SetAppThemeColor(targetProperty, light, dark);
		return view;
	}
	 
}
