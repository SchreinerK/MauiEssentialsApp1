namespace MauiEssentialsApp1;

public class PreferencesPage : ContentPage {

	private readonly Entry _entry;
	private readonly Switch _switch;

	public PreferencesPage() {
		Title = "Preferences";
		Content = new StackLayout {
			Children = {
				new Entry{Placeholder = "Your Name"}.Assign(out _entry),
				new Switch{}.Assign(out _switch),
			}
		}.Margins(10,0,10,0);
	}

	protected override void OnAppearing() {
		base.OnAppearing();
		_entry.Text = Preferences.Get("Entry", "");
		_switch.IsToggled=Preferences.Get("Switch", false);
	}

	protected override void OnDisappearing() {
		base.OnDisappearing();
		Preferences.Set("Entry", _entry.Text);
		Preferences.Set("Switch",_switch.IsToggled);
	}

}