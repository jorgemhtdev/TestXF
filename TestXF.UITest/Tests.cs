namespace TestXF.UITest
{
    using NUnit.Framework;
    using TestXF.UITest.Views;
    using Xamarin.UITest;

    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests : BaseTestFixture
    {
        public Tests(Platform platform)
            : base(platform) { }

        [Test]
        public void SuccessSignInTest()
        {
            new LoginView()
                .EnterCredentials(TestSettings.TestUsername, TestSettings.TestPassword)
                .SignIn();
        }
    }
}
