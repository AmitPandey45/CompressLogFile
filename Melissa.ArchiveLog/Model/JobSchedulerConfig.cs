using System.Collections.Generic;

namespace Melissa.ArchiveLog.Model
{
    public class JobSchedulerConfig
    {
        public IEnumerable<JobScheduler> SchedulerConfig { get; set; }
    }
}
