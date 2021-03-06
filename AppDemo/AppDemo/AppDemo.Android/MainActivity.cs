﻿using System;
using Card.IO;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.Content;
using AppDemo.Droid.Dependencies;
using AppDemo.Models;

namespace AppDemo.Droid
{
    [Activity(Label = "AppDemo", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (data != null)
            {
                // Be sure to JavaCast to a CreditCard (normal cast won‘t work)      
                InfoShareHelper.Instance.CardInfo = data.GetParcelableExtra(CardIOActivity.ExtraScanResult).JavaCast<CreditCard>();

                MainPage.AppViewModel.CardObject = new CreditCard_PCL
                {
                    cardholderName = InfoShareHelper.Instance.CardInfo.CardholderName,
                    cardNumber = InfoShareHelper.Instance.CardInfo.CardNumber,
                    ccv = InfoShareHelper.Instance.CardInfo.Cvv,
                    expr = InfoShareHelper.Instance.CardInfo.ExpiryMonth.ToString() + InfoShareHelper.Instance.CardInfo.ExpiryYear.ToString(),
                    redactedCardNumber = InfoShareHelper.Instance.CardInfo.RedactedCardNumber
                };
            }
            else
            {
                Console.WriteLine("Scanning Canceled!");
            }
        }

    }
}