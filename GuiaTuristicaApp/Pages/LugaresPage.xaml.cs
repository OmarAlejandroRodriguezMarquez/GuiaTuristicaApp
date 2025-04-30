using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaTuristicaApp.Pages;

public partial class LugaresPage : ContentPage
{
    public LugaresPage()
    {
        InitializeComponent();

        var layout = new StackLayout()
        {
            Padding = 20,
            Margin = 10
        };

        Content = new ScrollView()
        {
            Content = layout
        };

        for (int i = 0; i < 5; i++)
        {
            var btnLugar = new ImageButton()
            {
                Source = "https://cdn.milenio.com/uploads/media/2022/09/16/alhondiga-de-granaditas-ana-ortigoza.jpg",
                HeightRequest = 200,
                WidthRequest = 200,
            };
            
            layout.Children.Add(btnLugar);
        }
    }
}