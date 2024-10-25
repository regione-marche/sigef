using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolloBatchManager
{
    public partial class ProgettoProtocollabile
    {
        public int IdProgetto { get; set; }
        public int IdIstanza { get; set; }
        public string Segnatura { get; set; }
    }

    public partial class Istanza
    {
        public int IdIstanza { get; set; }
        public int IdProgetto { get; set; }
        public string RagioneSociale { get; set; }
        public string PartitaIva { get; set; }
        public string RappresentanteLegale { get; set; }
        public byte[] FileDocumento { get; set; }
        public string TokenCohesion { get; set; }
        public DateTime DataConferma { get; set; }
        public string Segnatura { get; set; }
        public string CodiceStatoProgetto { get; set; }
        public int IdBando { get; set; }
        public string DescrizioneBando { get; set; }
        public string CodiceEnte { get; set; }
        public string NumeroAtto { get; set; }
        public DateTime DataAtto { get; set; }
        public DateTime DataScadenza { get; set; }
        public string Programmazione { get; set; }
        public string Fascicolo { get; set; }
    }

    public class Bando
    {
        public int IdBando { get; set; }
        public string Descrizione { get; set; }
    }


    public class ResultInfo
    {
        public int IdIstanza { get; set; }
        public int IdProgetto { get; set; }
        public string Segnatura { get; set; }
        public string Esito { get; set; }
        public string DescrizioneEsito { get; set; }
        public DateTime? DataRisposta { get; set; }
    }


    public class ProtocolloLog
    {
        public int? IdProtocolloLog { get; set; }
        public int? IdProgetto { get; set; }
        public string Segnatura { get; set; }
        public DateTime? DataRichiesta { get; set; }
        public DateTime? DataRisposta { get; set; }
        public string Esito { get; set; }
        public string DescrizioneEsito { get; set; }
    }
}
