namespace TestXF.ViewModels
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using TestXF.Exceptions;
    using TestXF.Interfaces;
    using Xamarin.Forms;

    public class BaseViewModel : BindableObject
    {
        internal IDependencyService DependencyService;

        internal IConnectivity ConnectivityServices;

        public bool Online => ConnectivityServices.Connected;

        public bool Offline => !Online;

        private bool _isBusy = false;

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();
                OnPropertyChanged("IsNotBusy");
            }
        }

        public bool IsNotBusy => !IsBusy;

        CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public BaseViewModel() : this(new DependencyServiceWrapper()) { }

        public BaseViewModel(IDependencyService dependencyService)
        {
            DependencyService = dependencyService;
            ConnectivityServices = DependencyService.Get<IConnectivity>();

            ConnectivityServices.OnConnectivityChanged += async (sender, e) =>
            {
                OnPropertyChanged("Online");
                OnPropertyChanged("Offline");
                if (Online)
                {
                    try
                    {
                        // Do something when connection recovered
                    }
                    catch { }
                }
                else
                {
                    // Do something when lost the connection recovered
                    CancelTasks();
                }
            };
        }

        public CancellationToken CancellationToken => _cancellationTokenSource.Token;

        public virtual void CancelTasks()
        {
            if (!_cancellationTokenSource.IsCancellationRequested && CancellationToken.CanBeCanceled)
            {
                _cancellationTokenSource.Cancel();
                _cancellationTokenSource = new CancellationTokenSource();
            }
        }

        public async Task RunSafe(Func<Task> execute, bool notifyOnError = false)
        {
            Exception exception = null;

            try
            {
                if (!ConnectivityServices.Connected)
                {
                    throw new ConnectivityException();
                }

                if (!CancellationToken.IsCancellationRequested)
                {
                    await execute();
                }
            }
            catch (TaskCanceledException)
            {
                Debug.WriteLine("Task Cancelled");
            }
            catch (ConnectivityException ex)
            {
                exception = ex;
                if (notifyOnError)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                exception = ex;
                Debug.WriteLine(@"Exception handled {0}", ex.Message);
            }
            finally
            {
                if (exception != null) { }
            }
        }

    }
}
