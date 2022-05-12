using Melissa.ArchiveLog.Extension;
using System.IO;
using System.IO.Compression;

namespace Melissa.ArchiveLog.Utility
{
    public class DirectoryUtil
    {
        public static void DoDirectoryMove(string sourceDirectory, string destDirectory, bool onlyMoveContent = false)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(sourceDirectory);
            if (!dirInfo.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirectory);
            }

            if (!onlyMoveContent)
            {
                Directory.Move(sourceDirectory, destDirectory);
                return;
            }

            dirInfo.FileMove(destDirectory);
            dirInfo.SubDirectoryMove(destDirectory);
        }

        public static void DoDirectoryCompress(string sourceDirectory, string destDirectory = null)
        {
            string compressFilePath = string.Empty;
            if (string.IsNullOrEmpty(destDirectory))
                compressFilePath = string.Format("{0}{1}", sourceDirectory, ".zip");
            else
                compressFilePath = string.Format("{0}{1}", destDirectory, ".zip");

            ZipFile.CreateFromDirectory(sourceDirectory, compressFilePath);

        }

    }
}
