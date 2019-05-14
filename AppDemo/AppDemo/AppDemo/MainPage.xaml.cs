using AppDemo.DependencyServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void onScanCard(object sender, EventArgs e)
        {
            DependencyService.Get<ICardService>().StartCapture();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
