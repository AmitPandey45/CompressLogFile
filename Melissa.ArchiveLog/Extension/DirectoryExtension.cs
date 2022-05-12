using System;
using System.IO;
using System.Linq;

namespace Melissa.ArchiveLog.Extension
{
    public static class DirectoryExtension
    {
        /// <summary>
        /// Move all files inside a directory
        /// </summary>
        /// <param name="dirInfo">Object of DirectoryInfo class</param>
        /// <param name="destDirectory">Destination path of directory where file will be moved</param>
        public static void FileMove(this DirectoryInfo dirInfo, string destDirectory)
        {
            if (!Directory.Exists(destDirectory))
            {
                Directory.CreateDirectory(destDirectory);
            }

            FileInfo[] files = dirInfo.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destDirectory, file.Name);
                if (!File.Exists(tempPath))
                    file.MoveTo(tempPath);
            }
        }

        /// <summary>
        /// Move all sub-directory inside a directory
        /// </summary>
        /// <param name="dirInfo">Object of DirectoryInfo class</param>
        /// <param name="destDirectory">Destination path of directory where sub-directory will be moved</param>
        public static void SubDirectoryMove(this DirectoryInfo dirInfo, string destDirectory)
        {
            DirectoryInfo[] dirs = dirInfo.GetDirectories();
            foreach (DirectoryInfo subDirectoryInfo in dirs)
            {
                string tempPath = Path.Combine(destDirectory, subDirectoryInfo.Name);
                Directory.Move(subDirectoryInfo.FullName, tempPath);
            }
        }

        /// <summary>
        /// True- Delete this directory, its subdirectories, and all files; otherwise, False
        /// </summary>
        /// <param name="dirInfo">Object of DirectoryInfo class</param>
        /// <param name="path">path of the directory</param>
        public static void DirectoryDelete(this DirectoryInfo dirInfo, bool deleteFilesAndSubDirectories = true)
        {
            if (deleteFilesAndSubDirectories && dirInfo.GetFiles().Length > 0)
                dirInfo.Delete(deleteFilesAndSubDirectories);
            else
                dirInfo.Delete();
        }

        /// <summary>
        /// Deletes all the files from directory older than provided months
        /// </summary>
        /// <param name="dirInfo">Object of DirectoryInfo class</param>
        /// <param name="olderThanMonth">Deletes the files from directory older than provided months</param>
        /// <param name="deleteSubDirectoryFile">Default value is true to delete sub-directories files older than provided months</param>
        public static void DeleteFile(this DirectoryInfo dirInfo, int olderThanMonth, bool deleteSubDirectoryFile = true)
        {
            dirInfo.GetFiles()
                   .Where(w => w.LastWriteTime < DateTime.Now.AddMonths(-olderThanMonth))
                   .ToList()
                   .ForEach(file => file.Delete());

            if (deleteSubDirectoryFile)
            {
                DirectoryInfo[] dirs = dirInfo.GetDirectories();
                foreach (DirectoryInfo subDirectoryInfo in dirs)
                {
                    subDirectoryInfo.DeleteFile(olderThanMonth, deleteSubDirectoryFile);
                }
            }
        }

        /// <summary>
        /// Return the size of a directory in bytes
        /// </summary>
        /// <param name="dirInfo">Object of DirectoryInfo class</param>
        /// <param name="includeSubDir">Return the size of directory including all sub-directory</param>
        /// <returns></returns>
        public static long DirectorySize(this DirectoryInfo dirInfo, bool includeSubDir = true)
        {
            long totalSize = dirInfo.EnumerateFiles()
                         .Sum(file => file.Length);
            if (includeSubDir)
            {
                totalSize += dirInfo.EnumerateDirectories()
                         .Sum(dir => DirectorySize(dir, includeSubDir));
            }
            return totalSize;
        }
    }
}
