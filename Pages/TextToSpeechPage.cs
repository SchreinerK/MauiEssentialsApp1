using KsWare.Maui.Controls;

namespace MauiEssentialsApp1.Pages;

using static UIBuilder;

public class TextToSpeechPage : ContentPage
{

	private readonly Editor _textEditor;
	private CancellationTokenSource? _cancel;
	private readonly Task<IEnumerable<Locale>> _localesTask;
	private IEnumerable<Locale> _locales;
	private readonly Slider _pitchSlider;
	private readonly Picker _languagePicker;
	private readonly Picker _speakerPicker;
	private readonly Picker _countryPicker;

	public TextToSpeechPage() {
		UIBuilder.PropertyOrientation = ItemsLayoutOrientation.Horizontal;
		Title = "Text to Speech";
		Content = new StackLayout {
			Children = {
				// Editor(out _textEntry, "Text to speech","Hello how are you"),
				new Editor {
					Placeholder = "Text to speech",
					Text = "Hello how are you"
				}.Assign(out _textEditor),
				SliderProperty("Pitch", out _pitchSlider, 1, 0, 2),
				Property<Picker>("Language", out _languagePicker),
				Property<Picker>("Country", out _countryPicker),
				Property<Picker>("Speaker", out _speakerPicker),
				// SliderPropertyH(out _volumeSlider, 0, 0, 1),
				Button("Speak", OnSpeak),
				Button("Stop", OnCancel)
			}
		};

		_languagePicker.SelectedIndexChanged += (s, e) => {
			if (_languagePicker.SelectedItem == null) {
				_countryPicker.SelectedIndex = -1;
				return;
			}
			var countries =_locales
				.Where(l => l.Language.Split('-')[0] == (string)_languagePicker.SelectedItem)
				.Select(l => l.Country+l.Language.Split('-').Skip(1).FirstOrDefault())
				.Distinct().ToList();
			_countryPicker.ItemsSource = countries;
			_countryPicker.SelectedIndex = countries.Count > 0 ? 0 : -1;
		};

		_countryPicker.SelectedIndexChanged += (s, e) => {
			if (_languagePicker.SelectedItem == null) {
				_speakerPicker.SelectedIndex = -1;
				_speakerPicker.ItemsSource = null;
				return;
			}
			var speakers = _locales
				.Where(l => l.Language ==
				            (string) _languagePicker.SelectedItem + "-" + (string) _countryPicker.SelectedItem ||
				            (l.Language == (string) _languagePicker.SelectedItem &&
				             l.Country == (string) _countryPicker.SelectedItem))
				.Select(l => l.Name)
				.Distinct().ToList();
			_speakerPicker.ItemsSource = speakers;
			_speakerPicker.SelectedIndex = 0;
		};

		_localesTask = TextToSpeech.GetLocalesAsync();
	}

	protected override async void OnAppearing() {
		base.OnAppearing();
		_locales = (await _localesTask).ToList();
		
		var languages = _locales.Select(l => l.Language.Split('-')[0]).Distinct().ToList();
		_languagePicker.ItemsSource = languages;
		_languagePicker.SelectedItem = languages.FirstOrDefault(l=>l == "en");
		if (_languagePicker.SelectedItem == null) _languagePicker.SelectedItem = languages.FirstOrDefault();
	}

	private async void OnSpeak() {
		_cancel?.Cancel();
		_cancel = new CancellationTokenSource();

		var options = new SpeechOptions {
			Locale = _locales.FirstOrDefault(l=>
				(l.Language == (string)_languagePicker.SelectedItem+"-"+(string)_countryPicker.SelectedItem || 
				 (l.Language == (string)_languagePicker.SelectedItem && l.Country == (string)_countryPicker.SelectedItem)  ) &&
				l.Name == (string)_speakerPicker.SelectedItem),
			Pitch = (float?) _pitchSlider.Value
		};

		await TextToSpeech.SpeakAsync(_textEditor.Text, options, _cancel.Token).ContinueWith((t) => {
			// Logic that will run after utterance finishes.
			_cancel = null;
		}, TaskScheduler.FromCurrentSynchronizationContext());
	}

	private void OnCancel() {
		_cancel?.Cancel();
	}

}
/* Bug: TextToSpeech.GetLocalesAsync(); inconsistent values in class Locale, 
in Windows
  Language="en-US"
  Country =""
in Android
  Language="en"
  Country ="US"
*/