namespace TestXF.ViewModels
{
    using System.Threading.Tasks;
    using System.Windows.Input;
    using TestXF.Extensions;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {

        private string _userName;
        private string _password;

        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public ICommand SignInCommand => new AsyncCommand(SignInAsync, CanExecute);

        public async Task SignInAsync()
        {
            IsBusy = true;

            await Task.Delay(5000);

            if (!string.IsNullOrWhiteSpace(UserName) || !string.IsNullOrWhiteSpace(Password))
            {
                await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
            }

            IsBusy = false;
        }

        protected bool CanExecute() => !IsBusy;

    }
}
