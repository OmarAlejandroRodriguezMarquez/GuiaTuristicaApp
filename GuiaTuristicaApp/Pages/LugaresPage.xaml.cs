using GuiaTuristicaApp.Models;
using GuiaTuristicaApp.Services;

namespace GuiaTuristicaApp.Pages;

public partial class LugaresPage : ContentPage
{
    private readonly IAPIService _apiService;
    List<Lugar> lugares = new();

    private ActivityIndicator activityIndicator;
    private Grid mainLayout;

    public LugaresPage(IAPIService apiService)
    {
        _apiService = apiService;
        InitializeComponent();

        activityIndicator = new ActivityIndicator
        {
            IsRunning = true,
            IsVisible = true,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center
        };

        mainLayout = new Grid
        {
            Children =
            {
                activityIndicator
            }
        };

        Content = mainLayout;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        activityIndicator.IsRunning = true;
        activityIndicator.IsVisible = true;

        lugares = await ObtenerDatos();

        activityIndicator.IsRunning = false;
        activityIndicator.IsVisible = false;

        if (lugares == null || lugares.Count == 0)
        {
            await DisplayAlert("Error", "No se encontraron lugares.", "OK");
            return;
        }

        var grid = new Grid
        {
            Padding = 10,
            ColumnSpacing = 15,
            RowSpacing = 15
        };

        for (int i = 0; i < 3; i++)
        {
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
        }

        int totalRows = (int)Math.Ceiling(lugares.Count / 3.0);
        for (int i = 0; i < totalRows; i++)
        {
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        }

        int index = 0;
        for (int row = 0; row < totalRows; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (index >= lugares.Count)
                    break;

                var lugar = lugares[index];

                var imageButton = new ImageButton
                {
                    Source = lugar.Imagen,
                    HeightRequest = 150,
                    WidthRequest = 150,
                    Aspect = Aspect.AspectFill,
                    BackgroundColor = Colors.Transparent,
                    CornerRadius = 15
                };

                imageButton.Clicked += async (s, e) =>
                {
                    await Navigation.PushAsync(new DetallePage(lugar));
                };

                var frame = new Frame
                {
                    CornerRadius = 10,
                    Padding = 0,
                    Content = imageButton
                };

                grid.Add(frame, col, row);
                index++;
            }
        }

        mainLayout.Children.Add(new ScrollView
        {
            Content = grid
        });
    }

    private async Task<List<Lugar>> ObtenerDatos()
    {
        var items = await _apiService.GetAsync<List<Lugar>>("lugar/lugares");
        return items ?? new List<Lugar>();
    }
}
