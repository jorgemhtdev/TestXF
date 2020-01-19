namespace TestXF.Interfaces
{
    using Xamarin.Forms;

    public interface IDependencyService
    {
        T Get<T>() where T : class;
    }

    public class DependencyServiceWrapper : IDependencyService
    {
        public T Get<T>() where T : class => DependencyService.Get<T>();
    }
}
