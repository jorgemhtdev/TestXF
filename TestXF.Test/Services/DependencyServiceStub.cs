namespace TestXF.Test.Services
{
    using System;
    using System.Collections.Generic;
    using TestXF.Interfaces;

    public class DependencyServiceStub : IDependencyService
    {
        readonly Dictionary<Type, object> _registeredServices = new Dictionary<Type, object>();

        public void Register<T>(object impl) => _registeredServices[typeof(T)] = impl;

        public T Get<T>() where T : class => (T)_registeredServices[typeof(T)];
    }
}
