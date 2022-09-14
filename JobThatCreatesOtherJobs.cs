using Hangfire;

namespace HangFirePostgresIssue
{
    public class JobThatCreatesOtherJobs
    {
        public void CreateJobs()
        {
            BackgroundJob.Enqueue<DummyJob>((dj) => dj.LogSomething());
            BackgroundJob.Enqueue<DummyJob>((dj) => dj.LogSomething());
            BackgroundJob.Enqueue<DummyJob>((dj) => dj.LogSomething());
            BackgroundJob.Enqueue<DummyJob>((dj) => dj.LogSomething());
            BackgroundJob.Enqueue<DummyJob>((dj) => dj.LogSomething());
        }
    }
}
