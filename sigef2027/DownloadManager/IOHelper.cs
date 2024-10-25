using System;
using System.IO;
using System.Configuration;

namespace DownloadManager
{
    internal partial class IOHelper
    {
        private string _rootPath;
        private ZipManager _zip { get; set; }

        internal IOHelper()
        {
            _rootPath = ConfigurationManager.AppSettings["DownloadRootPath"].ToString();
            if (!Directory.Exists(_rootPath))
            {
                Directory.CreateDirectory(_rootPath);
            }
            _zip = new ZipManager();
        }

        internal string CreateTicketDirectory(int idTicket)
        {
            string path = "";
            if(!Directory.Exists(_rootPath + "\\" + idTicket.ToString()))
            {
               var d =  Directory.CreateDirectory(_rootPath + "\\" + idTicket.ToString());
               path = d.FullName;
            }
            else
            {
                var d = new DirectoryInfo(_rootPath + "\\" + idTicket.ToString());
                path = d.FullName;
            }
           
            return path;
            
        }


        internal string WriteFileToDirectory(byte[] file, string directory)
        {
            try
            {
                File.WriteAllBytes(directory, file);
                return "OK";
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }


        internal decimal CreateZipFile(int idTicket, bool deleteDirectory)
        {
            try
            {
                string path = _rootPath + "\\" + idTicket.ToString();
                _zip.Compress(path);
                FileInfo fi = new FileInfo(path + ".zip");
                decimal size = fi.Length;
                if (deleteDirectory)
                {
                    this.DeleteDirectory(path);
                }
                return size;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        internal void DeleteZipFile(int idTicket)
        {
            try
            {
                string path = _rootPath + "\\" + idTicket.ToString() + ".zip";
                File.Delete(path);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        internal string DeleteDirectory(string directory)
        {
            try
            {
                System.IO.Directory.Delete(directory, true);
                return "OK";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
