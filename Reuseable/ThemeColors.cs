using System.Runtime.CompilerServices;
using KsWare.Maui;

namespace MauiEssentialsApp1;

public class ThemeColors {

	private static readonly Dictionary<AppTheme, Dictionary<string, Color>> _dic = new() {
		{
			AppTheme.Light, new Dictionary<string, Color>() {
				// copy from Colors
				{"AliceBlue", Colors.AliceBlue},
				{"AntiqueWhite", Color.FromUint(0xFFFAEBD7)},
				{"Aqua", Color.FromUint(0xFF00FFFF)},
				{"Aquamarine", Color.FromUint(0xFF7FFFD4)},
				{"Azure", Color.FromUint(0xFFF0FFFF)},
				{"Beige", Color.FromUint(0xFFF5F5DC)},
				{"Bisque", Color.FromUint(0xFFFFE4C4)},
				{"Black", Color.FromUint(0xFF000000)},
				{"BlanchedAlmond", Color.FromUint(0xFFFFEBCD)},
				{"Blue", Color.FromUint(0xFF0000FF)},
				{"BlueViolet", Color.FromUint(0xFF8A2BE2)},
				{"Brown", Color.FromUint(0xFFA52A2A)},
				{"BurlyWood", Color.FromUint(0xFFDEB887)},
				{"CadetBlue", Color.FromUint(0xFF5F9EA0)},
				{"Chartreuse", Color.FromUint(0xFF7FFF00)},
				{"Chocolate", Color.FromUint(0xFFD2691E)},
				{"Coral", Color.FromUint(0xFFFF7F50)},
				{"CornflowerBlue", Color.FromUint(0xFF6495ED)},
				{"Cornsilk", Color.FromUint(0xFFFFF8DC)},
				{"Crimson", Color.FromUint(0xFFDC143C)},
				{"Cyan", Color.FromUint(0xFF00FFFF)},
				{"DarkBlue", Color.FromUint(0xFF00008B)},
				{"DarkCyan", Color.FromUint(0xFF008B8B)},
				{"DarkGoldenrod", Color.FromUint(0xFFB8860B)},
				{"DarkGray", Color.FromUint(0xFF2B2B2B)}, //FIX
				{"DarkGreen", Color.FromUint(0xFF006400)},
				{"DarkGrey", Colors.DarkGray},
				{"DarkKhaki", Color.FromUint(0xFFBDB76B)},
				{"DarkMagenta", Color.FromUint(0xFF8B008B)},
				{"DarkOliveGreen", Color.FromUint(0xFF556B2F)},
				{"DarkOrange", Color.FromUint(0xFFFF8C00)},
				{"DarkOrchid", Color.FromUint(0xFF9932CC)},
				{"DarkRed", Color.FromUint(0xFF8B0000)},
				{"DarkSalmon", Color.FromUint(0xFFE9967A)},
				{"DarkSeaGreen", Color.FromUint(0xFF8FBC8F)},
				{"DarkSlateBlue", Color.FromUint(0xFF483D8B)},
				{"DarkSlateGray", Color.FromUint(0xFF2F4F4F)},
				{"DarkSlateGrey", Colors.DarkSlateGray},
				{"DarkTurquoise", Color.FromUint(0xFF00CED1)},
				{"DarkViolet", Color.FromUint(0xFF9400D3)},
				{"DeepPink", Color.FromUint(0xFFFF1493)},
				{"DeepSkyBlue", Color.FromUint(0xFF00BFFF)},
				{"DimGray", Color.FromUint(0xFF696969)},
				{"DimGrey", Colors.DimGray},
				{"DodgerBlue", Color.FromUint(0xFF1E90FF)},
				{"Firebrick", Color.FromUint(0xFFB22222)},
				{"FloralWhite", Color.FromUint(0xFFFFFAF0)},
				{"ForestGreen", Color.FromUint(0xFF228B22)},
				{"Fuchsia", Color.FromUint(0xFFFF00FF)},
				{"Gainsboro", Color.FromUint(0xFFDCDCDC)},
				{"GhostWhite", Color.FromUint(0xFFF8F8FF)},
				{"Gold", Color.FromUint(0xFFFFD700)},
				{"Goldenrod", Color.FromUint(0xFFDAA520)},
				{"Gray", Color.FromUint(0xFF808080)},
				{"Green", Color.FromUint(0xFF008000)},
				{"GreenYellow", Color.FromUint(0xFFADFF2F)},
				{"Grey", Colors.Gray},
				{"Honeydew", Color.FromUint(0xFFF0FFF0)},
				{"HotPink", Color.FromUint(0xFFFF69B4)},
				{"IndianRed", Color.FromUint(0xFFCD5C5C)},
				{"Indigo", Color.FromUint(0xFF4B0082)},
				{"Ivory", Color.FromUint(0xFFFFFFF0)},
				{"Khaki", Color.FromUint(0xFFF0E68C)},
				{"Lavender", Color.FromUint(0xFFE6E6FA)},
				{"LavenderBlush", Color.FromUint(0xFFFFF0F5)},
				{"LawnGreen", Color.FromUint(0xFF7CFC00)},
				{"LemonChiffon", Color.FromUint(0xFFFFFACD)},
				{"LightBlue", Color.FromUint(0xFFADD8E6)},
				{"LightCoral", Color.FromUint(0xFFF08080)},
				{"LightCyan", Color.FromUint(0xFFE0FFFF)},
				{"LightGoldenrodYellow", Color.FromUint(0xFFFAFAD2)},
				{"LightGray", Color.FromUint(0xFFD3D3D3)},
				{"LightGreen", Color.FromUint(0xFF90EE90)},
				{"LightGrey", Color.FromUint(0xFFD3D3D3)},
				{"LightPink", Color.FromUint(0xFFFFB6C1)},
				{"LightSalmon", Color.FromUint(0xFFFFA07A)},
				{"LightSeaGreen", Color.FromUint(0xFF20B2AA)},
				{"LightSkyBlue", Color.FromUint(0xFF87CEFA)},
				{"LightSlateGray", Color.FromUint(0xFF778899)},
				{"LightSlateGrey", Colors.LightSlateGray},
				{"LightSteelBlue", Color.FromUint(0xFFB0C4DE)},
				{"LightYellow", Color.FromUint(0xFFFFFFE0)},
				{"Lime", Color.FromUint(0xFF00FF00)},
				{"LimeGreen", Color.FromUint(0xFF32CD32)},
				{"Linen", Color.FromUint(0xFFFAF0E6)},
				{"Magenta", Color.FromUint(0xFFFF00FF)},
				{"Maroon", Color.FromUint(0xFF800000)},
				{"MediumAquamarine", Color.FromUint(0xFF66CDAA)},
				{"MediumBlue", Color.FromUint(0xFF0000CD)},
				{"MediumOrchid", Color.FromUint(0xFFBA55D3)},
				{"MediumPurple", Color.FromUint(0xFF9370D8)},
				{"MediumSeaGreen", Color.FromUint(0xFF3CB371)},
				{"MediumSlateBlue", Color.FromUint(0xFF7B68EE)},
				{"MediumSpringGreen", Color.FromUint(0xFF00FA9A)},
				{"MediumTurquoise", Color.FromUint(0xFF48D1CC)},
				{"MediumVioletRed", Color.FromUint(0xFFC71585)},
				{"MidnightBlue", Color.FromUint(0xFF191970)},
				{"MintCream", Color.FromUint(0xFFF5FFFA)},
				{"MistyRose", Color.FromUint(0xFFFFE4E1)},
				{"Moccasin", Color.FromUint(0xFFFFE4B5)},
				{"NavajoWhite", Color.FromUint(0xFFFFDEAD)},
				{"Navy", Color.FromUint(0xFF000080)},
				{"OldLace", Color.FromUint(0xFFFDF5E6)},
				{"Olive", Color.FromUint(0xFF808000)},
				{"OliveDrab", Color.FromUint(0xFF6B8E23)},
				{"Orange", Color.FromUint(0xFFFFA500)},
				{"OrangeRed", Color.FromUint(0xFFFF4500)},
				{"Orchid", Color.FromUint(0xFFDA70D6)},
				{"PaleGoldenrod", Color.FromUint(0xFFEEE8AA)},
				{"PaleGreen", Color.FromUint(0xFF98FB98)},
				{"PaleTurquoise", Color.FromUint(0xFFAFEEEE)},
				{"PaleVioletRed", Color.FromUint(0xFFD87093)},
				{"PapayaWhip", Color.FromUint(0xFFFFEFD5)},
				{"PeachPuff", Color.FromUint(0xFFFFDAB9)},
				{"Peru", Color.FromUint(0xFFCD853F)},
				{"Pink", Color.FromUint(0xFFFFC0CB)},
				{"Plum", Color.FromUint(0xFFDDA0DD)},
				{"PowderBlue", Color.FromUint(0xFFB0E0E6)},
				{"Purple", Color.FromUint(0xFF800080)},
				{"Red", Color.FromUint(0xFFFF0000)},
				{"RosyBrown", Color.FromUint(0xFFBC8F8F)},
				{"RoyalBlue", Color.FromUint(0xFF4169E1)},
				{"SaddleBrown", Color.FromUint(0xFF8B4513)},
				{"Salmon", Color.FromUint(0xFFFA8072)},
				{"SandyBrown", Color.FromUint(0xFFF4A460)},
				{"SeaGreen", Color.FromUint(0xFF2E8B57)},
				{"SeaShell", Color.FromUint(0xFFFFF5EE)},
				{"Sienna", Color.FromUint(0xFFA0522D)},
				{"Silver", Color.FromUint(0xFFC0C0C0)},
				{"SkyBlue", Color.FromUint(0xFF87CEEB)},
				{"SlateBlue", Color.FromUint(0xFF6A5ACD)},
				{"SlateGray", Color.FromUint(0xFF708090)},
				{"SlateGrey", Colors.SlateGray},
				{"Snow", Color.FromUint(0xFFFFFAFA)},
				{"SpringGreen", Color.FromUint(0xFF00FF7F)},
				{"SteelBlue", Color.FromUint(0xFF4682B4)},
				{"Tan", Color.FromUint(0xFFD2B48C)},
				{"Teal", Color.FromUint(0xFF008080)},
				{"Thistle", Color.FromUint(0xFFD8BFD8)},
				{"Tomato", Color.FromUint(0xFFFF6347)},
				{"Transparent", Color.FromUint(0x00000000)},
				{"Turquoise", Color.FromUint(0xFF40E0D0)},
				{"Violet", Color.FromUint(0xFFEE82EE)},
				{"Wheat", Color.FromUint(0xFFF5DEB3)},
				{"White", Color.FromUint(0xFFFFFFFF)},
				{"WhiteSmoke", Color.FromUint(0xFFF5F5F5)},
				{"Yellow", Color.FromUint(0xFFFFFF00)},
				{"YellowGreen", Color.FromUint(0xFF9ACD32)},
			}
		},
		{AppTheme.Dark, new Dictionary<string, Color>()},
		{AppTheme.Unspecified, new Dictionary<string, Color>()}
	};

	public static Color AliceBlue => GetColorCore();
	public static Color AntiqueWhite => GetColorCore();
	public static Color Aqua => GetColorCore();
	public static Color Aquamarine => GetColorCore();
	public static Color Azure => GetColorCore();
	public static Color Beige => GetColorCore();
	public static Color Bisque => GetColorCore();
	public static Color Black => GetColorCore();
	public static Color BlanchedAlmond => GetColorCore();
	public static Color Blue => GetColorCore();
	public static Color BlueViolet => GetColorCore();
	public static Color Brown => GetColorCore();
	public static Color BurlyWood => GetColorCore();
	public static Color CadetBlue => GetColorCore();
	public static Color Chartreuse => GetColorCore();
	public static Color Chocolate => GetColorCore();
	public static Color Coral => GetColorCore();
	public static Color CornflowerBlue => GetColorCore();
	public static Color Cornsilk => GetColorCore();
	public static Color Crimson => GetColorCore();
	public static Color Cyan => GetColorCore();
	public static Color DarkBlue => GetColorCore();
	public static Color DarkCyan => GetColorCore();
	public static Color DarkGoldenrod => GetColorCore();
	public static Color DarkGray => GetColorCore();
	public static Color DarkGreen => GetColorCore();
	public static Color DarkGrey => GetColorCore();
	public static Color DarkKhaki => GetColorCore();
	public static Color DarkMagenta => GetColorCore();
	public static Color DarkOliveGreen => GetColorCore();
	public static Color DarkOrange => GetColorCore();
	public static Color DarkOrchid => GetColorCore();
	public static Color DarkRed => GetColorCore();
	public static Color DarkSalmon => GetColorCore();
	public static Color DarkSeaGreen => GetColorCore();
	public static Color DarkSlateBlue => GetColorCore();
	public static Color DarkSlateGray => GetColorCore();
	public static Color DarkSlateGrey => GetColorCore();
	public static Color DarkTurquoise => GetColorCore();
	public static Color DarkViolet => GetColorCore();
	public static Color DeepPink => GetColorCore();
	public static Color DeepSkyBlue => GetColorCore();
	public static Color DimGray => GetColorCore();
	public static Color DimGrey => GetColorCore();
	public static Color DodgerBlue => GetColorCore();
	public static Color Firebrick => GetColorCore();
	public static Color FloralWhite => GetColorCore();
	public static Color ForestGreen => GetColorCore();
	public static Color Fuchsia => GetColorCore();
	public static Color Gainsboro => GetColorCore();
	public static Color GhostWhite => GetColorCore();
	public static Color Gold => GetColorCore();
	public static Color Goldenrod => GetColorCore();
	public static Color Gray => GetColorCore();
	public static Color Green => GetColorCore();
	public static Color GreenYellow => GetColorCore();
	public static Color Grey => GetColorCore();
	public static Color Honeydew => GetColorCore();
	public static Color HotPink => GetColorCore();
	public static Color IndianRed => GetColorCore();
	public static Color Indigo => GetColorCore();
	public static Color Ivory => GetColorCore();
	public static Color Khaki => GetColorCore();
	public static Color Lavender => GetColorCore();
	public static Color LavenderBlush => GetColorCore();
	public static Color LawnGreen => GetColorCore();
	public static Color LemonChiffon => GetColorCore();
	public static Color LightBlue => GetColorCore();
	public static Color LightCoral => GetColorCore();
	public static Color LightCyan => GetColorCore();
	public static Color LightGoldenrodYellow => GetColorCore();
	public static Color LightGray => GetColorCore();
	public static Color LightGreen => GetColorCore();
	public static Color LightGrey => GetColorCore();
	public static Color LightPink => GetColorCore();
	public static Color LightSalmon => GetColorCore();
	public static Color LightSeaGreen => GetColorCore();
	public static Color LightSkyBlue => GetColorCore();
	public static Color LightSlateGray => GetColorCore();
	public static Color LightSlateGrey => GetColorCore();
	public static Color LightSteelBlue => GetColorCore();
	public static Color LightYellow => GetColorCore();
	public static Color Lime => GetColorCore();
	public static Color LimeGreen => GetColorCore();
	public static Color Linen => GetColorCore();
	public static Color Magenta => GetColorCore();
	public static Color Maroon => GetColorCore();
	public static Color MediumAquamarine => GetColorCore();
	public static Color MediumBlue => GetColorCore();
	public static Color MediumOrchid => GetColorCore();
	public static Color MediumPurple => GetColorCore();
	public static Color MediumSeaGreen => GetColorCore();
	public static Color MediumSlateBlue => GetColorCore();
	public static Color MediumSpringGreen => GetColorCore();
	public static Color MediumTurquoise => GetColorCore();
	public static Color MediumVioletRed => GetColorCore();
	public static Color MidnightBlue => GetColorCore();
	public static Color MintCream => GetColorCore();
	public static Color MistyRose => GetColorCore();
	public static Color Moccasin => GetColorCore();
	public static Color NavajoWhite => GetColorCore();
	public static Color Navy => GetColorCore();
	public static Color OldLace => GetColorCore();
	public static Color Olive => GetColorCore();
	public static Color OliveDrab => GetColorCore();
	public static Color Orange => GetColorCore();
	public static Color OrangeRed => GetColorCore();
	public static Color Orchid => GetColorCore();
	public static Color PaleGoldenrod => GetColorCore();
	public static Color PaleGreen => GetColorCore();
	public static Color PaleTurquoise => GetColorCore();
	public static Color PaleVioletRed => GetColorCore();
	public static Color PapayaWhip => GetColorCore();
	public static Color PeachPuff => GetColorCore();
	public static Color Peru => GetColorCore();
	public static Color Pink => GetColorCore();
	public static Color Plum => GetColorCore();
	public static Color PowderBlue => GetColorCore();
	public static Color Purple => GetColorCore();
	public static Color Red => GetColorCore();
	public static Color RosyBrown => GetColorCore();
	public static Color RoyalBlue => GetColorCore();
	public static Color SaddleBrown => GetColorCore();
	public static Color Salmon => GetColorCore();
	public static Color SandyBrown => GetColorCore();
	public static Color SeaGreen => GetColorCore();
	public static Color SeaShell => GetColorCore();
	public static Color Sienna => GetColorCore();
	public static Color Silver => GetColorCore();
	public static Color SkyBlue => GetColorCore();
	public static Color SlateBlue => GetColorCore();
	public static Color SlateGray => GetColorCore();
	public static Color SlateGrey => GetColorCore();
	public static Color Snow => GetColorCore();
	public static Color SpringGreen => GetColorCore();
	public static Color SteelBlue => GetColorCore();
	public static Color Tan => GetColorCore();
	public static Color Teal => GetColorCore();
	public static Color Thistle => GetColorCore();
	public static Color Tomato => GetColorCore();
	public static Color Transparent => GetColorCore();
	public static Color Turquoise => GetColorCore();
	public static Color Violet => GetColorCore();
	public static Color Wheat => GetColorCore();
	public static Color White => GetColorCore();
	public static Color WhiteSmoke => GetColorCore();
	public static Color Yellow => GetColorCore();
	public static Color YellowGreen => GetColorCore();

	private static Color GetColorCore([CallerMemberName] string? name = null) {
		if(name == null) throw new ArgumentNullException(nameof(name));

		if (!_dic.TryGetValue(AppInfo.RequestedTheme, out var colorDic))
			colorDic = new Dictionary<string, Color>();
		if (colorDic.TryGetValue(name, out var color)) return color;

		switch (AppInfo.RequestedTheme) {
			case AppTheme.Light: return Colors.Black; // not defined
			case AppTheme.Dark: return ThemeHelper.InvertLuminance(_dic[AppTheme.Light][name]);
			default:
				if(_dic[AppTheme.Light].TryGetValue(name, out color)) return color;
				return Colors.Black; // not defined
		}
	}
}