// ReSharper disable once CheckNamespace
namespace KsWare.Maui.Controls.Xaml; 

[ContentProperty(nameof(Default))]
public class AppAutoThemeBindingExtension : IMarkupExtension<BindingBase> {

	private AppThemeBindingExtension _baseExtension = new AppThemeBindingExtension();
	private bool _darkSpecified;
	private bool _defaultSpecified;
	private bool _lightSpecified;

	public object Default {
		get => _baseExtension.Light;
		set {
			_baseExtension.Light = value;
			_defaultSpecified = true;
		}
	}

	public object Light {
		get => _baseExtension.Light;
		set {
			_baseExtension.Light = value;
			_lightSpecified = true;
		}
	}

	public object Dark {
		get => _baseExtension.Dark;
		set {
			_baseExtension.Dark = value;
			_darkSpecified = true;
		}
	}

	public object Value => _baseExtension.Value;

	BindingBase IMarkupExtension<BindingBase>.ProvideValue(IServiceProvider serviceProvider) {
		return (BindingBase) ProvideValue(serviceProvider);
	}

	public object ProvideValue(IServiceProvider serviceProvider) {
		if (_lightSpecified && !_defaultSpecified)
			Default = Light;
		if (_defaultSpecified && !_lightSpecified)
			Light = Default;
		if (!_darkSpecified) {
			switch (Light) {
				case Color color: Dark = InvertLuminance(color); break;
				case SolidColorBrush solid: Dark = new SolidColorBrush(InvertLuminance(solid.Color)); break;
				case LinearGradientBrush linear: Dark = InvertLuminance(linear); break;
				case RadialGradientBrush radial: Dark = InvertLuminance(radial); break;
			}
		}
		return _baseExtension.ProvideValue(serviceProvider);
	}

	private static RadialGradientBrush InvertLuminance(RadialGradientBrush brush) {
		var stops = new GradientStopCollection();
		foreach (var p in brush.GradientStops) {
			stops.Add(new GradientStop(InvertLuminance(p.Color),p.Offset));
		}
		return new RadialGradientBrush(stops,brush.Center,brush.Radius);
	}

	private static LinearGradientBrush InvertLuminance(LinearGradientBrush brush) {
		var stops = new GradientStopCollection();
		return new LinearGradientBrush(stops, brush.StartPoint, brush.EndPoint);
	}

	private static Color InvertLuminance(Color color) {
		color.ToHsl(out var h, out var s, out var l);
		return Color.FromHsla(h, s, 1 - l);
	}

}