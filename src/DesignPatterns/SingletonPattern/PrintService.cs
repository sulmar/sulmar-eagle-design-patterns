namespace SingletonPattern
{
    public class PrintService
    {
        public Logger _logger { get; set; }

        public PrintService(Logger logger)
        {
            _logger = logger;
        }

        public void Print(string content, int copies)
        {
            for (int i = 1; i < copies+1; i++)
            {
                _logger.LogInformation($"Print {i} copy of {content}");
            }
        }
    }
}
