using System.Diagnostics;

namespace Melissa.ArchiveLog.Extension
{
    public static class StopWatchExtension
    {
        public static Stopwatch StartWatch(this Stopwatch stopWatch)
        {
            stopWatch.Start();
            return stopWatch;
        }

        public static double GetElapsedTimeInSecond(this Stopwatch stopWatch)
        {
            stopWatch.Stop();
            return stopWatch.Elapsed.TotalSeconds;
        }
    }
}
