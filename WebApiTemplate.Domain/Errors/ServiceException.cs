namespace WebApiTemplate.Domain.Errors
{
    public class ServiceException : Exception
    {
        public ServiceException() { }

        public ServiceException(string msg)
            : base(String.Format(msg))
        {

        }
    }
}
