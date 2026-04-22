namespace MyMauiApp;

public partial class MainPage : ContentPage
{
	private Random _random = new Random();

	public MainPage()
	{
		InitializeComponent();
	}

	// Se llama cada vez que se mueve un slider
	private void OnSliderCambiado(object sender, ValueChangedEventArgs e)
	{
		int r = (int)SliderR.Value;
		int g = (int)SliderG.Value;
		int b = (int)SliderB.Value;

		AplicarColor(r, g, b);
	}

	// Genera valores RGB al azar y actualiza los sliders
	private void OnColorAleatorioClicked(object sender, EventArgs e)
	{
		SliderR.Value = _random.Next(0, 256);
		SliderG.Value = _random.Next(0, 256);
		SliderB.Value = _random.Next(0, 256);

		// OnSliderCambiado se ejecuta automáticamente al cambiar los sliders
	}

	// Copia el hex al portapapeles
	private async void OnCopiarHexClicked(object sender, EventArgs e)
	{
		await Clipboard.SetTextAsync(LabelHex.Text);
		await DisplayAlert("Copiado", LabelHex.Text + " copiado al portapapeles", "OK");
	}

	// Aplica el color al fondo y actualiza el label hex
	private void AplicarColor(int r, int g, int b)
	{
		string hex = $"#{r:X2}{g:X2}{b:X2}";

		LabelHex.Text = hex;
		FondoColor.Color = Color.FromRgb(r, g, b);
	}
}