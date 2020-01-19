namespace TestXF.ViewModels
{
    using TestXF.Interfaces;

    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            Initialize();
        }

        public MainViewModel(IDependencyService dependencyService) : base(dependencyService)
        {
            Initialize();
        }

        public async void Initialize()
        {
           var apiService = DependencyService.Get<IApiService>();

           var films = await apiService.GetAllFilm();
        }
    }
}
