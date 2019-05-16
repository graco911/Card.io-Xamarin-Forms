using AppDemo.DependencyServices;
using AppDemo.Models;
using MvvmHelpers;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppDemo.ViewModels
{
    public class AppViewModel : BaseViewModel
    {
        private ICommand _cardcommand;

        public ICommand CardCommand
        {
            get
            {
                return _cardcommand ?? (_cardcommand = new Command(() => LaunchCardReader()));
            }
        }

        private string _cardname;

        public string CardName
        {
            get { return _cardname; }
            set { SetProperty(ref _cardname, value); }
        }

        private string _cardnumber;

        public string CardNumber
        {
            get { return _cardnumber; }
            set { SetProperty(ref _cardnumber, value); }
        }
        
        private CreditCard_PCL _cardobject;

        public CreditCard_PCL CardObject
        {
            get { return _cardobject; }
            set
            {
                SetProperty(ref _cardobject, value);

                if (CardObject != null)
                {
                    CardNumber = CardObject.cardNumber;
                    CardName = CardObject.cardholderName;
                }               
            }
        }

        private void LaunchCardReader()
        {
            DependencyService.Get<ICardService>().StartCapture();
        }
    }
}
