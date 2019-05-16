using AppDemo.DependencyServices;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppDemo
{
    public partial class App : Application
    {
        private MainPage main;

        public App()
        {
            InitializeComponent();

            main = new MainPage();

            MainPage = main;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            
        }
    }
}
