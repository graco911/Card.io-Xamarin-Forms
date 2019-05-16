using AppDemo.DependencyServices;
using AppDemo.ViewModels;
using System;
using Xamarin.Forms;

namespace AppDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            AppViewModel = new AppViewModel();

            BindingContext = AppViewModel;
        }

        public static AppViewModel AppViewModel { get; set; }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
