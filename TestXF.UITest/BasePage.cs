﻿namespace TestXF.UITest
{
    using NUnit.Framework;
    using System;
    using Xamarin.UITest;

    public abstract class BasePage
    {
        protected IApp App => AppManager.App;
        protected bool OnAndroid => AppManager.Platform == Platform.Android;
        protected bool OniOS => AppManager.Platform == Platform.iOS;

        protected abstract PlatformQuery Trait { get; }

        protected BasePage()
        {
            AssertOnPage(TimeSpan.FromSeconds(30));
            App.Screenshot("On " + this.GetType().Name);
        }

        protected void AssertOnPage(TimeSpan? timeout = default(TimeSpan?))
        {
            var message = "Unable to verify on page: " + this.GetType().Name;

            if (timeout == null)
                Assert.IsNotEmpty(App.Query(Trait.Current), message);
            else
                Assert.DoesNotThrow(() => App.WaitForElement(Trait.Current, timeout: timeout), message);
        }

        protected void WaitForPageToLeave(TimeSpan? timeout = default(TimeSpan?))
        {
            timeout = timeout ?? TimeSpan.FromSeconds(5);
            var message = "Unable to verify *not* on page: " + this.GetType().Name;

            Assert.DoesNotThrow(() => App.WaitForNoElement(Trait.Current, timeout: timeout), message);
        }

        // You can edit this file to define functionality that is common across many or all pages in your app.
        // For example, you could add a method here to open a side menu that is accesible from all pages.
        // To keep things more organized, consider subclassing BasePage and including common page actions there.
        // For some examples check out https://github.com/xamarin-automation-service/uitest-pop-example/wiki
        public void SelectMenuOption(NavigationMenuOptions item)
        {
            App.Screenshot($"Selecting Option {item.Current.GetType().Name}");
            App.Tap(item.Current);
        }

        public class NavigationMenuOptions : PlatformQuery
        {
            public static readonly NavigationMenuOptions Home = new NavigationMenuOptions
            {
                Android = x => x.Marked("Home"),
                iOS = x => x.Marked("Home")
            };
        }
    }
}