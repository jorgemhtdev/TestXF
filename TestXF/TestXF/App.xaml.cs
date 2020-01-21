namespace TestXF
{
    using TestXF.Interfaces;
    using TestXF.Services;
    using TestXF.Views;
    using Xamarin.Forms;

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            LoadDependency();

            MainPage = new NavigationPage(new LoginView());
        }

        private void LoadDependency()
        {
            DependencyService.Register<IApiService, ApiService>();
            DependencyService.Register<IConnectivity, ConnectivityServices>();
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
