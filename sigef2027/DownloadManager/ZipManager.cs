using System;
using System.Linq;
using System.IO.Compression;

namespace DownloadManager
{
    internal partial class ZipManager
    {
        internal void Compress(string path)
        {
            try
            {
                ZipFile.CreateFromDirectory(path, path.Split('/').Last() + ".zip");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
