namespace TestXF
{
    using System.ComponentModel;
    using TestXF.ViewModels;
    using Xamarin.Forms;

    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainViewModel();
        }
    }
}
