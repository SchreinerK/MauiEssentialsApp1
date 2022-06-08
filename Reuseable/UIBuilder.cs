
// ReSharper disable once CheckNamespace
namespace KsWare.Maui.Controls; 

internal static class UIBuilder {
	//TODO the names conflicts with control names if dependency properties are used. eg. Button.TextColorProperty

	// ReSharper disable once FieldCanBeMadeReadOnly.Global
	// ReSharper disable once MemberCanBePrivate.Global
	public static IUIBuilder Default = new IUIBuilderImpl();

	public static Button Button(string text, EventHandler clicked) => Default.Button(text, clicked);
	public static Button Button(out Button button, string text, EventHandler clicked) => Default.Button(out button, text, clicked);

	public static Button Button(string text, Action clicked) => Default.Button(text, clicked);
	public static Button Button(out Button button, string text, Action clicked) => Default.Button(out button, text, clicked);

	public static Button NavigationButton(string text, Type pageType) {
		var button = new Button {
			Text = text,
		};
		button.Clicked += (s, e) => {
			var b = (Button?) s;
			var page = (Page?) Activator.CreateInstance(pageType);
			b.Navigation.PushAsync(page);
		};
		return button;
	}

	public static Entry Entry(string placeholder, string? text = null) => Default.Entry(placeholder, text);
	public static Entry Entry(out Entry entry, string placeholder, string? text = null) => Default.Entry(out entry, placeholder, text);

	public static Label Label(string text) => Default.Label(text);
	public static Label Label(out Label label, string placeholder) => Default.Label(out label, placeholder);

	public static StackBase Property(string title, IView contentView) => Default.Property(title, contentView);

	public static StackBase Property<TView>(string title, out TView contentView) where TView:View =>
		Default.Property<TView>(title, out contentView);
	
	public static Label PropertyLabel(string title) => Default.PropertyLabel(title);

	public static StackBase TextProperty(string title, object content) => Default.TextProperty(title, content);
	public static StackBase TextProperty(string title, out Label contentLabel, object content) => Default.TextProperty(title, out contentLabel, content);

	public static StackBase SwitchProperty(out Switch @switch, string title, bool isToggled = false) =>
		Default.SwitchProperty(out @switch, title, isToggled);

	public static StackBase SliderProperty(string title, out Slider slider, double value, double minimum, double maximum)
		=> Default.SliderProperty(title, out slider, value, minimum, maximum);

	public static ItemsLayoutOrientation PropertyOrientation {
		get => Default.PropertyOrientation;
		set => Default.PropertyOrientation = value;
	}
}

public interface IUIBuilder {

	Button Button(string text, EventHandler clicked);
	Button Button(out Button button, string text, EventHandler clicked);

	Button Button(string text, Action clicked);
	Button Button(out Button button, string text, Action clicked);

	Entry Entry(string placeholder, string? text);
	Entry Entry(out Entry entry, string placeholder, string? text);

	Label Label(string text);
	Label Label(out Label label, string text);

	ItemsLayoutOrientation PropertyOrientation { get; set; }

	StackBase Property(string title, IView contentView);
	StackBase Property<TView>(string title, out TView contentView) where TView : View;

	Label PropertyLabel(string title);

	StackBase TextProperty(string title, object content);
	StackBase TextProperty(string title, out Label contentLabel, object content);

	StackBase SwitchProperty(out Switch @switch, string title, bool isToggled = false);

	StackBase SliderProperty(string title, out Slider slider, double value, double minimum, double maximum);
}

internal class IUIBuilderImpl : IUIBuilder {

	public Button Button(string text, EventHandler clicked) => Button(out _, text, clicked);

	public Button Button(out Button button, string text, EventHandler clicked) {
		button = new Button {
				Text = text
			}
			.Invoke(b => b.Clicked += clicked);
		return button;
	}

	public Button Button(string text, Action clicked) => Button(out _, text, clicked);

	public Button Button(out Button button, string text, Action clicked) {
		button = new Button {
				Text = text
			}
			.Invoke(b => b.Clicked += (_,_) => clicked());
		return button;
	}

	public Entry Entry(string placeholder, string? text) => Entry(out _, placeholder, text);

	public Entry Entry(out Entry entry, string placeholder, string? text) {
		entry = new Entry {
			Placeholder = placeholder,
			Text = text,
		};
		return entry;
	}

	public Label Label(string text) => Label(out _, text);

	public Label Label(out Label label, string text) {
		label = new Label {
			Text = text
		};
		return label;
	}

	public StackBase Property(string title, IView contentView) {
		var layout = PropertyOrientation==ItemsLayoutOrientation.Horizontal ? (StackBase)new HorizontalStackLayout() : new VerticalStackLayout();
		layout.Children.Add(PropertyLabel(title));
		layout.Children.Add(contentView);

		// if (PropertyOrientation == ItemsLayoutOrientation.Horizontal) {
		// 	((View) layout.Children[0]).VerticalOptions = LayoutOptions.Center;
		// 	((View) layout.Children[1]).VerticalOptions = LayoutOptions.Center;
		// }
		return layout;
	}

	public StackBase Property<TView>(string title, out TView contentView) where TView : View {
		contentView = Activator.CreateInstance<TView>();
		return Property(title, contentView);
	}

	public Label PropertyLabel(string title) {
		var label = new Label {
			Text = $"{title}:",
			FontSize = 13,
			VerticalOptions = PropertyOrientation==ItemsLayoutOrientation.Horizontal ? LayoutOptions.Center : LayoutOptions.End,
		}.SetAppThemeTextColor()
			.SetAppAutoThemeColor(Microsoft.Maui.Controls.Label.TextColorProperty, Color.FromHsv(0f, 0f, 0.25f));
		return label;
	}

	public ItemsLayoutOrientation PropertyOrientation { get; set; }

	public StackBase TextProperty(string title, object content) => TextProperty(title, out _, content);

	public StackBase TextProperty(string title, out Label contentLabel, object content) {
		return Property(
			title,
			new Label {
				Text = $"{content}",
				VerticalOptions = PropertyOrientation==ItemsLayoutOrientation.Horizontal ? LayoutOptions.Center : LayoutOptions.Start,
			}.Assign(out contentLabel)
		);
	}

	public StackBase SwitchProperty(out Switch @switch, string title, bool isToggled = false) {
		return Property(
			title,
			new Switch {
				IsToggled = isToggled,
				VerticalOptions = PropertyOrientation==ItemsLayoutOrientation.Horizontal ? LayoutOptions.Center : LayoutOptions.Start,
				HorizontalOptions = PropertyOrientation==ItemsLayoutOrientation.Horizontal ? LayoutOptions.End : LayoutOptions.Start,
			}.Assign(out @switch)
		);
	}

	public StackBase SliderProperty(string title, out Slider slider, double value, double minimum, double maximum) {
		slider=new Slider();
		if (value < 0) slider.Minimum = minimum;
		else if (value > 1) slider.Maximum = maximum;
		else slider.Value = value;
		slider.Minimum = minimum;
		slider.Maximum = maximum;
		slider.HorizontalOptions = PropertyOrientation==ItemsLayoutOrientation.Horizontal ? LayoutOptions.Fill : LayoutOptions.Start;
		return Property(title, slider);
	}

}