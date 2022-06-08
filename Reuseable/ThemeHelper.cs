
// ReSharper disable once CheckNamespace
namespace KsWare.Maui;

public static class ThemeHelper {

	public static Color InvertLuminance(Color color) {
		color.ToHsl(out var h, out var s, out var l);
		return Color.FromHsla(h, s, 1 - l);
	}
}
