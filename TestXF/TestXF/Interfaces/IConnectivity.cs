namespace TestXF.Interfaces
{
    using Xamarin.Essentials;

    public delegate void OnConnectivityChangeHandler(object sender, ConnectivityChangedEventArgs e);

    public interface IConnectivity
    {
        bool Connected { get; }

        event OnConnectivityChangeHandler OnConnectivityChanged;
    }
}
