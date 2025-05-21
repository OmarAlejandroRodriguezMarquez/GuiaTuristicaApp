using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuiaTuristicaApp.Models;

namespace GuiaTuristicaApp.Pages;

public partial class DetallePage : ContentPage
{
    public DetallePage(Lugar lugar)
    {
        InitializeComponent();
        BindingContext = lugar;
    }
}