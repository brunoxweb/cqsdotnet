namespace CQSDotnet.Exceptions
{
    public class HandlerNotFoundException : Exception
    {
        public HandlerNotFoundException(string name, Exception? innerException) : base($"Handler not found for {name}", innerException)
        {
        }
    }
}