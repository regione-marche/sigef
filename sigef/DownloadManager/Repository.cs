using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadManager
{
    public partial class DownloadRequest
    {
        public int IdProgetto { get; set; }
        public int? IdDomandaPagamento { get; set; }
        public int? IdIntegrazione { get; set; }
        public int IdTicket { get; set; }
        public string Segnatura { get; set; }
    }

    public partial class ResultInfo: DownloadRequest
    {
        public string Esito { get; set; }
        public string DescrizioneEsito { get; set; }
        public DateTime? DataRisposta { get; set; }
        public int NrDocumenti { get; set; }
    }


    public partial class WriteResult
    {
        public string Esito { get; set; }
        public string DescrizioneEsito { get; set; }
        public string FileName { get; set; }
    }
}
