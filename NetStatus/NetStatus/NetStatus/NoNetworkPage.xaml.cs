using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NetStatus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoNetworkPage : ContentPage
    {
        public NoNetworkPage()
        {
            InitializeComponent();
            Content = new Label
            {
                Text = "No Network Connection Available",
                TextColor = Color.FromRgb(0x40,0x40,0x40),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            BackgroundColor = Color.FromRgb(0xf0, 0xf0, 0xf0);
        }
    }
}