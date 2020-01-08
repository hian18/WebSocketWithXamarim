using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteWebSocket.ViewModels;
using Xamarin.Forms;

namespace TesteWebSocket
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {


        MainViewModel MainViewModel => BindingContext as MainViewModel;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //await MainViewModel.GetEvento();

        }
    }
}
