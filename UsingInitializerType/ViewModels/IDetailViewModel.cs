namespace UsingInitializerType.ViewModels
{
    public interface IDetailViewModel : IInstanceFor<IDetailViewModel, ShowCustomerDetails>, IViewModel
    {
    }

    public class ShowCustomerDetails
    {
        public int CustomerId { get; private set; }

        public ShowCustomerDetails(int customerId)
        {
            CustomerId = customerId;
        }
    }
}