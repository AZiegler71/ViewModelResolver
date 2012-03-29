namespace UsingInitializerType.ViewModels
{
  public interface IViewModelFor<in TInitializer>
  {
    void SetModel(TInitializer model);
  }
}