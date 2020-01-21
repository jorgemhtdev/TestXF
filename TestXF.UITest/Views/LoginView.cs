namespace TestXF.UITest.Views
{
    using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

    public class LoginView : BasePage
    {
        readonly Query emailField;
        readonly Query passwordField;
        readonly Query signInButton;

        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("Email"),
            iOS = x => x.Marked("Email")
        };

        public LoginView()
        {
            emailField = x => x.Marked("email");
            passwordField = x => x.Marked("password");
            signInButton = x => x.Marked("signin");
        }

        public LoginView EnterCredentials(string email, string password)
        {
            App.WaitForElement(emailField);
            App.Tap(emailField);
            App.EnterText(email);
            App.DismissKeyboard();
            App.Tap(passwordField);
            App.EnterText(password);
            App.DismissKeyboard();
            App.Screenshot("Credentials Entered");
            return this;
        }
        public LoginView SignIn()
        {
            App.Tap(signInButton);

            return this;
        }

        public void CheckThereIsNoNavigation()
        {
            App.WaitForElement(emailField);
            App.WaitForElement(passwordField);
            App.WaitForElement(signInButton);
        }
    }
}