namespace SingletonPattern
{
    public class MessageService
    {
        public Logger _logger;

        public MessageService(Logger logger)
        {
            _logger = logger;
        }

        public void Send(string message)
        {
            _logger.LogInformation($"Send {message}");
        }
    }
}
