namespace Melissa.ArchiveLog.Model
{
    public class JobScheduler
    {
        public string Key { get; set; }
        public string ApplicationName { get; set; }
        public bool IsCompressEnabled { get; set; }
        public string SourceDirectory { get; set; }
        public string DestinationDirectory { get; set; }
        public double ArchiveSize { get; set; }
        public bool IsDeleteEnabledForCompressFile { get; set; }
        public int DeletesFileOlderThanMonth { get; set; }
    }
}
