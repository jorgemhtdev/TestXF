namespace TestXF.Exceptions
{
    using System;

    public class ConnectivityException : Exception
    {
        public ConnectivityException() { }

        public ConnectivityException(string message) : base(message) { }
    }
}
