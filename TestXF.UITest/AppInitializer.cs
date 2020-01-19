namespace TestXF.UITest
{
    using Xamarin.UITest;

    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .InstalledApp("com.jorgemht.testxf")
                    .EnableLocalScreenshots()
                    .StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }
    }
}