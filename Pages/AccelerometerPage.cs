namespace MauiEssentialsApp1.Pages;

public class AccelerometerPage : ContentPage {

	private readonly Label _labelInfo;
	private readonly Label _shakingLabel;
	private int _shakingCount;

	public AccelerometerPage() {
		Title = "Accelerometer";
		Content = new StackLayout {
			Children = {
				new Label { }.Assign(out _labelInfo),
				new Label { }.Assign(out _shakingLabel)
			}
		};
		Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
		Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;
	}

	private void Accelerometer_ShakeDetected(object? sender, EventArgs e) {
		_shakingCount++;
		_shakingLabel.Text = $"Shaking: {_shakingCount}";
	}

	protected override void OnAppearing() {
		base.OnAppearing();
		Accelerometer.Start(SensorSpeed.UI);
	}

	protected override void OnDisappearing() {
		base.OnDisappearing();
		Accelerometer.Stop();
	}

	private void Accelerometer_ReadingChanged(object? sender, AccelerometerChangedEventArgs e) {
		_labelInfo.Text = $@"X: {e.Reading.Acceleration.X}
Y: {e.Reading.Acceleration.Y}
Z: {e.Reading.Acceleration.Z}";
	}

}