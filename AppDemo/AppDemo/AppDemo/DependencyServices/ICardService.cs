namespace AppDemo.DependencyServices
{
    public interface ICardService
    {
        void StartCapture();

        string GetCardNumber();

        string GetCardHolderName();
    }
}
