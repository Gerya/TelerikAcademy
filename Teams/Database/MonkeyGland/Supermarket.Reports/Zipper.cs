using Ionic.Zip;
using System;

namespace Supermarket.Reports
{
    public static class Zipper
    {
        public static void UnzipFiles()
        {
            string zipToUnpack = @"../../../../Reports/Sample-Sales-Reports.zip";
            string unpackDirectory = @"../../../../Reports/Sample-Sales-Extracted Files";
            using (ZipFile zip1 = ZipFile.Read(zipToUnpack))
            {
                // here, we extract every entry, but we could extract conditionally
                // based on entry name, size, date, checkbox status, etc.  
                foreach (ZipEntry file in zip1)
                {
                    file.Extract(unpackDirectory, ExtractExistingFileAction.OverwriteSilently);
                }
            }
        }
    }
}
