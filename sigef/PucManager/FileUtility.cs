using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ionic.Zip;
using System.IO;
using System.Configuration;
using System.Xml;

namespace PucManager
{
    internal static class FileUtility
    {
        private const string sharp = "#";
        private const string pipe = "|";
        private static string _IdSistema { get; set; }
        private static string _IdAmministrazione { get; set; }


        internal static ZipFile StringToZip(string filename, string file)
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Level9;
                zip.AddEntry(filename, file);
                return zip;
            }
        }


        internal static byte[] StringToZipArray(string filename, string file)
        {
            using (ZipFile zip = new ZipFile())
            {
                Encoding utf8WithoutBom = new UTF8Encoding(false);
                zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Level9;
                zip.AddEntry(filename, file, utf8WithoutBom);
                using (MemoryStream stream = new MemoryStream())
                {
                    zip.Save(stream);
                    stream.Position = 0;
                    return stream.ToArray();
                }
                
            }
        }


        internal static String NormalizzaDato(Object valore)
        {
            String normalized = "";

            //Qui devo trattare solo i tipi Interi, Decimali, Date e Boolean
            Type tipoValore = valore.GetType();

            switch (tipoValore.ToString())
            {
                case "System.Boolean":
                    {
                        bool val = (bool)valore;
                        if (val == true)
                            normalized = "S";
                        else
                            normalized = "N";
                    }
                    break;

                case "System.Decimal":
                    normalized = System.Math.Round(Convert.ToDecimal(valore), 2, MidpointRounding.AwayFromZero).ToString().Replace(".", ",");
                    break;

                case "System.Int32":
                    normalized = System.Math.Abs(Convert.ToInt32(valore)).ToString();
                    //return normalized;
                    break;

                case "System.String":
                    string temp = valore.ToString().Replace("\r", " ");
                    temp = temp.Replace("\n", " ");
                    temp = temp.Replace("\t", " ");
                    temp = temp.Replace("•", " ");
                    temp = temp.Replace("#", " ");
                    temp = temp.Replace("|", " ");
                    normalized = temp;
                    break;
                default:
                    return valore.ToString();
            }

            return normalized;
        }


        internal static string GeneraFile(System.Data.DataTable DTable, string NomeFile, bool IncludeHeaderFooter)
        {
            string result = string.Empty;
            var rowCount = 0;
            var recBuilder = new StringBuilder();
            var fileBuilder = new StringBuilder();
            string row = "";
            if (DTable != null && DTable.Rows.Count > 0)
            {
                var last = DTable.Columns.IndexOf("FLG_CANCELLAZIONE") < 0 ? DTable.Columns.IndexOf("OPERAZIONE")-1 : DTable.Columns.IndexOf("FLG_CANCELLAZIONE");
                foreach (System.Data.DataRow item in DTable.Rows)
                {
                    rowCount++;
                    if (!NomeFile.StartsWith("TR"))
                    {
                        row = NomeFile + sharp;
                        row += item["NR_RIGA_INVIO"].ToString() + sharp + item[0] + sharp;
                        for (int i = 1; i <= last; i++)
                        {
                            row += item[i] + pipe;
                        }
                    }
                    else
                    {
                        row = NomeFile + sharp;
                        row += item["NR_RIGA_INVIO"].ToString() + sharp + item[0] + sharp + item[1] + sharp + item[2] + sharp;
                        for (int i = 3; i <= last; i++)
                        {
                            row += FileUtility.NormalizzaDato(item[i]) + pipe;
                        }
                    }
                    var newrow = row.Remove(row.Length - 1, 1);
                    recBuilder.AppendLine(row.Remove(row.Length - 1, 1) + sharp);
                    row = "";
                }
                if (IncludeHeaderFooter)
                {
                    fileBuilder.AppendLine(GetHeaderRow(rowCount));
                }               
                fileBuilder.Append(recBuilder.ToString());
                if (IncludeHeaderFooter)
                {
                    fileBuilder.Append(GetFooterRow(rowCount));
                }
                result = fileBuilder.ToString();
            }
            return result;
        }


        //internal static string GeneraFileNoHF(System.Data.DataTable DTable, string NomeFile)
        //{
        //    string result = string.Empty;
        //    var rowCount = 0;
        //    var recBuilder = new StringBuilder();
        //    var fileBuilder = new StringBuilder();
        //    string row = "";
        //    if (DTable.Rows.Count > 0)
        //    {
        //        var last = DTable.Columns.IndexOf("FLG_CANCELLAZIONE") < 0 ? DTable.Columns.IndexOf("OPERAZIONE") - 1 : DTable.Columns.IndexOf("FLG_CANCELLAZIONE");
        //        foreach (System.Data.DataRow item in DTable.Rows)
        //        {
        //            rowCount++;
        //            if (!NomeFile.StartsWith("TR"))
        //            {
        //                row = NomeFile + sharp;
        //                row += item["NR_RIGA_INVIO"].ToString() + sharp + item[0] + sharp;
        //                for (int i = 1; i <= last; i++)
        //                {
        //                    row += item[i] + pipe;
        //                }
        //            }
        //            else
        //            {
        //                row = NomeFile + sharp;
        //                row += item["NR_RIGA_INVIO"].ToString() + sharp + item[0] + sharp + item[1] + sharp + item[2] + sharp;
        //                for (int i = 3; i <= last; i++)
        //                {
        //                    row += FileUtility.NormalizzaDato(item[i]) + pipe;
        //                }
        //            }
        //            var newrow = row.Remove(row.Length - 1, 1);
        //            recBuilder.AppendLine(row.Remove(row.Length - 1, 1) + sharp);
        //            row = "";
        //        }
        //        //fileBuilder.AppendLine(GetHeaderRow(rowCount));
        //        fileBuilder.Append(recBuilder.ToString());
        //        //fileBuilder.Append(GetFooterRow(rowCount));
        //        result = fileBuilder.ToString();
        //    }
        //    return result;
        //}

        
        internal static string GetHeaderRow(int records)
        {
            _IdSistema = ConfigurationManager.AppSettings["IgrueIdSistema"].ToString();
            _IdAmministrazione = ConfigurationManager.AppSettings["IgrueIdAmministrazione"].ToString();
            string header = "HH" + sharp + "0" + sharp + _IdSistema + _IdAmministrazione + sharp + "PUC" + sharp + records.ToString() + sharp;
            return header;
        }


        internal static string GetFooterRow(int records) 
        {
            records++;
            string footer = "FF" + sharp + records.ToString() + sharp;
            return footer;
        }


        internal static string ZipArrayToString(byte[] ZippedFile)
        {
            string result = null;
            using (MemoryStream stream = new MemoryStream(ZippedFile))
            {
                using (ZipFile zip = ZipFile.Read(stream))
                {
                    ZipEntry e = zip[0];

                    using (MemoryStream outstream = new MemoryStream())
                    {
                        e.Extract(outstream);
                        result = Encoding.Default.GetString(outstream.ToArray());
                    }

                }
            }
            return result;
        }

        
    }
}
