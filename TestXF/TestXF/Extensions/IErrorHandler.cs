namespace TestXF.Extensions
{
    using System;
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}
