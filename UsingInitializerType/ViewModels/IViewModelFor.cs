namespace UsingInitializerType.ViewModels
{
    public interface IViewModelFor<in TArgs> : IViewModel
    {
    }
}