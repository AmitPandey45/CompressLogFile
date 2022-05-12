namespace Melissa.ArchiveLog.Extension
{
    public static class NumberExtension
    {
        const int value = 1024;

        /// Convert bytes to KB
        /// </summary>
        /// <param name="bytes">Accept bytes as input</param>
        /// <returns>Return converted value in KB</returns>
        public static double ToKB(this long bytes)
        {
            return bytes / (1.0 * value);
        }

        /// Convert bytes to MB
        /// </summary>
        /// <param name="bytes">Accept bytes as input</param>
        /// <returns>Return converted value in MB</returns>
        public static double ToMB(this long bytes)
        {
            return bytes / (1.0 * value * value);
        }

        /// Convert bytes to GB
        /// </summary>
        /// <param name="bytes">Accept bytes as input</param>
        /// <returns>Return converted value in GB</returns>
        public static double ToGB(this long bytes)
        {
            return bytes / (1.0 * value * value * value);
        }
    }
}
