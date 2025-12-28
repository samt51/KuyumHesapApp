namespace KuyumHesap.Application.Common.Exceptions
{
    public class BaseException : ApplicationException
    {
        public BaseException() { }
        public BaseException(string message) : base(message) { }
    }
}
