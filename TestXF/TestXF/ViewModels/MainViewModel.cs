namespace TestXF.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using TestXF.Interfaces;
    using TestXF.Models;

    public class MainViewModel : BaseViewModel
    {
        private string userName;
        private string password;
        private bool isAuthenticated;
        private ObservableCollection<Film> films;

        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                if (userName != value)
                {
                    userName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return isAuthenticated;
            }
            set
            {
                if (isAuthenticated != value)
                {
                    isAuthenticated = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<Film> Films
        {
            get => films;
            set
            {
                films = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel() { }

        public MainViewModel(IDependencyService dependencyService) : base(dependencyService) { }

        public async void LoadFilm()
        {
            if (Online)
            {
                var apiService = DependencyService.Get<IApiService>();

                new ObservableCollection<Film>(await apiService.GetAllFilm());
            }
            else
            {
                throw new Exception();
            }

        }

        public void Login()
        {
            if (String.IsNullOrWhiteSpace(UserName) || String.IsNullOrWhiteSpace(Password))
            {
                
            }
            else
            {
                isAuthenticated = true;
            }
        }
    }
}
