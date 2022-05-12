using Melissa.ArchiveLog.Extension;
using Melissa.ArchiveLog.Model;
using Melissa.ArchiveLog.Utility;
using System;
using System.Diagnostics;
using System.IO;

namespace Melissa.ArchiveLog
{
    public static class CompressLog
    {
        public static void CompressLogFile()
        {
            try
            {
                var scheduleJobs = JsonReader.GetObjectFromJsonFile<JobSchedulerConfig>("JobSchedulerConfig.json");

                foreach (JobScheduler scheduleJob in scheduleJobs.SchedulerConfig)
                {
                    CompressedArchiveLog(scheduleJob);
                    DeleteCompressedLog(scheduleJob);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        private static void CompressedArchiveLog(JobScheduler scheduleJob)
        {
            double directorySizeInMB = new DirectoryInfo(scheduleJob.SourceDirectory).DirectorySize().ToMB();

            if (scheduleJob.IsCompressEnabled && directorySizeInMB >= scheduleJob.ArchiveSize)
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch = stopWatch.StartWatch();

                Console.WriteLine(string.Format("Compressing Archive log for Key={0}, Application Name={1}", scheduleJob.Key, scheduleJob.ApplicationName));
                Console.WriteLine("Start execution at " + DateTime.Now);

                string destDirectory = string.Format("{0}{1}{2}", scheduleJob.DestinationDirectory, @"\", DateTime.Now.GetTimeStamp());

                DirectoryUtil.DoDirectoryMove(scheduleJob.SourceDirectory, destDirectory, true);
                DirectoryUtil.DoDirectoryCompress(destDirectory);
                new DirectoryInfo(destDirectory).DirectoryDelete();

                Console.WriteLine(string.Format("Elapsed time to Compress Archive log in seconds- {0}", stopWatch.GetElapsedTimeInSecond()));
                Console.WriteLine("Completed execution at " + DateTime.Now);
            }
        }

        private static void DeleteCompressedLog(JobScheduler scheduleJob)
        {
            if (scheduleJob.IsDeleteEnabledForCompressFile)
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch = stopWatch.StartWatch();

                Console.WriteLine(string.Format("Deleting older compressed Archive log for Key={0}, Application Name={1}, older than month={2}", scheduleJob.Key, scheduleJob.ApplicationName, scheduleJob.DeletesFileOlderThanMonth));
                Console.WriteLine("Start execution at " + DateTime.Now);

                new DirectoryInfo(scheduleJob.DestinationDirectory).DeleteFile(scheduleJob.DeletesFileOlderThanMonth);

                Console.WriteLine(string.Format("Elapsed time to Delete Compress Archive log in seconds- {0}", stopWatch.GetElapsedTimeInSecond()));
                Console.WriteLine("Completed execution at " + DateTime.Now);
            }
        }

    }
}
