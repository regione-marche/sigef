using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WsSigef
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ISigefService
    {


        [OperationContract]
        ProgettoResultInfo InviaProgetto(ProgettoIn progetto);

        [OperationContract]
        ProceduraAttivazioneResultInfo InviaProceduraAttivazione(ProceduraAttivazioneIn proceduraAttivazione);

        [OperationContract]
        DomandaPagamentoResultInfo InviaDomandaPagamento(DomandaPagamentoIn domandaPagamento);

        [OperationContract]
        DomandaPagamentoResultInfo InviaDomandaAnticipo(DomandaAnticipoIn domandaAnticipo);

        [OperationContract]
        DomandaVarianteResultInfo InviaDomandaVariante(DomandaVarianteIn domandaVariante);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class ProgettoIn
    {
        [DataMember]
        public string SistemaMittente { get; set; }

        [DataMember]
        public string IstanzaProgetto { get; set; }
    }

    [DataContract]
    public class ProceduraAttivazioneIn
    {
        [DataMember]
        public string SistemaMittente { get; set; }

        [DataMember]
        public string IstanzaProceduraAttivazione { get; set; }
    }

    [DataContract]
    public class DomandaPagamentoIn
    {
        [DataMember]
        public string SistemaMittente { get; set; }

        [DataMember]
        public string IstanzaDomandaPagamento { get; set; }
    }

    [DataContract]
    public class DomandaAnticipoIn
    {
        [DataMember]
        public string SistemaMittente { get; set; }

        [DataMember]
        public string IstanzaDomandaAnticipo { get; set; }
    }

    [DataContract]
    public class DomandaVarianteIn
    {
        [DataMember]
        public string SistemaMittente { get; set; }

        [DataMember]
        public string IstanzaDomandaVariante { get; set; }
    }
}
