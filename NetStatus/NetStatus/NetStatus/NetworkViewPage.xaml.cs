using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Connectivity;
namespace NetStatus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NetworkViewPage : ContentPage
    {
        Label ConnectionDetails;

        public NetworkViewPage()
        {
            InitializeComponent();
            ConnectionDetails = new Label()
            {
                TextColor = Color.FromRgb(0x40, 0x40, 0x40),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            Content = ConnectionDetails;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if(CrossConnectivity.Current == null)
                return;


            ConnectionDetails.Text = CrossConnectivity.Current.ConnectionTypes.First().ToString();
            CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
        }

        private void Current_ConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {
            if(CrossConnectivity.Current != null && CrossConnectivity.Current.ConnectionTypes != null)
            {
                var connectionType = CrossConnectivity.Current.ConnectionTypes.First().ToString();
                ConnectionDetails.Text = connectionType;
            }

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if(CrossConnectivity.Current != null)
            {
                CrossConnectivity.Current.ConnectivityChanged -= Current_ConnectivityChanged;
            }
        }
    }


}