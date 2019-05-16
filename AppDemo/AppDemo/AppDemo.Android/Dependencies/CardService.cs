using Android.App;
using Android.Content;
using AppDemo.DependencyServices;
using AppDemo.Droid.Dependencies;
using Card.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(CardService))]
namespace AppDemo.Droid.Dependencies
{
    public class CardService : ICardService
    {
        private Activity activity;

        public void StartCapture()
        {
            InitCardService();

            var intent = new Intent(activity, typeof(CardIOActivity));
            intent.PutExtra(CardIOActivity.ExtraRequireExpiry, true);
            intent.PutExtra(CardIOActivity.ExtraRequireCvv, true);
            intent.PutExtra(CardIOActivity.ExtraRequirePostalCode, true);
            intent.PutExtra(CardIOActivity.ExtraUseCardioLogo, true);
            intent.PutExtra(CardIOActivity.ExtraRequireCardholderName, true);
            intent.PutExtra(CardIOActivity.ExtraScanInstructions, true);

            activity.StartActivityForResult(intent, 101);
        }

        public string GetCardHolderName()
        {
            return (InfoShareHelper.Instance.CardInfo != null) ? InfoShareHelper.Instance.CardInfo.CardholderName : null;
        }

        public string GetCardNumber()
        {
            return (InfoShareHelper.Instance.CardInfo != null) ? InfoShareHelper.Instance.CardInfo.CardNumber : null;
        }

        private void InitCardService()
        {
            var context = Forms.Context;
            activity = context as Activity;
        }
    }

    public class InfoShareHelper
    {
        private static InfoShareHelper instance = null;
        private static readonly object padlock = new object();

        public CreditCard CardInfo { get; set; }

        public static InfoShareHelper Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new InfoShareHelper();
                    }
                    return instance;
                }
            }
        }
    }

}