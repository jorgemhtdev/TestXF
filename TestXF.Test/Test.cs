namespace TestXF.Test
{
    using Moq;
    using TestXF.Interfaces;
    using TestXF.Test.Services;
    using Xamarin.Forms.Mocks;
    //using INavigation = Interfaces.INavigation;

    public class Tests
    {
        protected DependencyServiceStub DependencyService { get; set; }
        protected Mock<IConnectivity> ConnMock { get; set; }
        protected Mock<IApiService> RestMock { get; set; }

        public Tests()
        {
            MockForms.Init();

            DependencyService = new DependencyServiceStub();
            ConnMock = new Mock<IConnectivity>();
            RestMock = new Mock<IApiService>();

            DependencyService.Register<IConnectivity>(ConnMock.Object);
            DependencyService.Register<IApiService>(RestMock.Object);
        }
    }
}
