namespace HangFirePostgresIssue
{
    public class DummyJob
    {
        private ILogger<DummyJob> _logger;

        public DummyJob(ILogger<DummyJob> logger)
        {
            _logger = logger;
        }

        public void LogSomething()
        {
            _logger.LogInformation("Hello");
        }
    }
}
