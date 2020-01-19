namespace TestXF.Services
{
    using TestXF.Interfaces;
    using Xamarin.Essentials;

    public class ConnectivityServices : IConnectivity
    {
        public event OnConnectivityChangeHandler OnConnectivityChanged;

        public ConnectivityServices() => Connectivity.ConnectivityChanged += ConnectivityChanged;

        public bool Connected
        {
            get => Connectivity.NetworkAccess == NetworkAccess.Internet;
        }

        public void ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
            => OnConnectivityChanged?.Invoke(sender, e);
    }
}
