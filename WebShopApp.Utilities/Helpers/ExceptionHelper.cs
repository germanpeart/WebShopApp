namespace WebShopApp.Utilities.Helpers
{
    public static class ExceptionHelper
    {
        public static string GetInnerMessage(this Exception exception)
        {
            var innerException = exception.InnerException;

            while (innerException is not null)
            {
                exception = innerException;
                innerException = exception.InnerException;
            }

            return exception.Message;
        }
    }
}
