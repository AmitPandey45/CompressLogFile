using System;

namespace Melissa.ArchiveLog.Extension
{
    public static class DateTimeExtension
    {
        public static string GetTimeStamp(this DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssfff");
        }
    }
}
