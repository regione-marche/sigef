﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Il codice è stato generato da uno strumento.
//     Versione runtime:4.0.30319.42000
//
//     Le modifiche apportate a questo file possono provocare un comportamento non corretto e andranno perse se
//     il codice viene rigenerato.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CupManager.svcCUP {
    using System.Runtime.Serialization;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="esitoElaborazioneCUP_Type", Namespace="http://serviziCUP.mef.it/types/")]
    public enum esitoElaborazioneCUP_Type : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ELABORAZIONE_ESEGUITA = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ERRORE_NELLA_ELABORAZIONE_DEL_MESSAGGIO = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        RICHIESTA_NON_PRESENTE = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ERRORE_APPLICATIVO = 3,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace=" http://serviziCUP.mef.it", ConfigurationName="svcCUP.ElaborazioniCUP")]
    public interface ElaborazioniCUP {
        
        // CODEGEN: Generazione di un contratto di messaggio perché lo spazio dei nomi wrapper (http://serviziCUP.mef.it/types/) del messaggio RichiestaRispostaSincrona_RichiestaDettaglioCUPRequest non corrisponde al valore predefinito ( http://serviziCUP.mef.it)
        [System.ServiceModel.OperationContractAttribute(Action="RichiestaRispostaSincrona_RichiestaDettaglioCUP", ReplyAction="*")]
        CupManager.svcCUP.RichiestaRispostaSincrona_RichiestaDettaglioCUPResponse RichiestaRispostaSincrona_RichiestaDettaglioCUP(CupManager.svcCUP.RichiestaRispostaSincrona_RichiestaDettaglioCUPRequest request);
        
        // CODEGEN: Generazione di un contratto di messaggio perché lo spazio dei nomi wrapper (http://serviziCUP.mef.it/types/) del messaggio RichiestaRispostaSincrona_ListaCUPRequest non corrisponde al valore predefinito ( http://serviziCUP.mef.it)
        [System.ServiceModel.OperationContractAttribute(Action="RichiestaRispostaSincrona_ListaCUP", ReplyAction="*")]
        CupManager.svcCUP.RichiestaRispostaSincrona_ListaCUPResponse RichiestaRispostaSincrona_ListaCUP(CupManager.svcCUP.RichiestaRispostaSincrona_ListaCUPRequest request);
        
        // CODEGEN: Generazione di un contratto di messaggio perché lo spazio dei nomi wrapper (http://serviziCUP.mef.it/types/) del messaggio RichiestaRispostaSincrona_RichiestaGenerazioneCUPRequest non corrisponde al valore predefinito ( http://serviziCUP.mef.it)
        [System.ServiceModel.OperationContractAttribute(Action="RichiestaRispostaSincrona_RichiestaGenerazioneCUP", ReplyAction="*")]
        CupManager.svcCUP.RichiestaRispostaSincrona_RichiestaGenerazioneCUPResponse RichiestaRispostaSincrona_RichiestaGenerazioneCUP(CupManager.svcCUP.RichiestaRispostaSincrona_RichiestaGenerazioneCUPRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="richiesta_RichiestaRispostaSincrona_RichiestaDettaglioCUP", WrapperNamespace="http://serviziCUP.mef.it/types/", IsWrapped=true)]
    public partial class RichiestaRispostaSincrona_RichiestaDettaglioCUPRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string TitoloRichiesta;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=1)]
        public byte[] richiesta;
        
        public RichiestaRispostaSincrona_RichiestaDettaglioCUPRequest() {
        }
        
        public RichiestaRispostaSincrona_RichiestaDettaglioCUPRequest(string TitoloRichiesta, byte[] richiesta) {
            this.TitoloRichiesta = TitoloRichiesta;
            this.richiesta = richiesta;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="risposta_RichiestaRispostaSincrona_RisultatoDettaglioCUP", WrapperNamespace="http://serviziCUP.mef.it/types/", IsWrapped=true)]
    public partial class RichiestaRispostaSincrona_RichiestaDettaglioCUPResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string TitoloRisposta;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=1)]
        public CupManager.svcCUP.esitoElaborazioneCUP_Type EsitoElaborazione;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=2)]
        public byte[] risposta;
        
        public RichiestaRispostaSincrona_RichiestaDettaglioCUPResponse() {
        }
        
        public RichiestaRispostaSincrona_RichiestaDettaglioCUPResponse(string TitoloRisposta, CupManager.svcCUP.esitoElaborazioneCUP_Type EsitoElaborazione, byte[] risposta) {
            this.TitoloRisposta = TitoloRisposta;
            this.EsitoElaborazione = EsitoElaborazione;
            this.risposta = risposta;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="richiesta_RichiestaRispostaSincrona_RichiestaListaCUP", WrapperNamespace="http://serviziCUP.mef.it/types/", IsWrapped=true)]
    public partial class RichiestaRispostaSincrona_ListaCUPRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string TitoloRichiesta;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=1)]
        public byte[] richiesta;
        
        public RichiestaRispostaSincrona_ListaCUPRequest() {
        }
        
        public RichiestaRispostaSincrona_ListaCUPRequest(string TitoloRichiesta, byte[] richiesta) {
            this.TitoloRichiesta = TitoloRichiesta;
            this.richiesta = richiesta;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="risposta_RichiestaRispostaSincrona_ListaCUP", WrapperNamespace="http://serviziCUP.mef.it/types/", IsWrapped=true)]
    public partial class RichiestaRispostaSincrona_ListaCUPResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string TitoloRisposta;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=1)]
        public CupManager.svcCUP.esitoElaborazioneCUP_Type EsitoElaborazione;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=2)]
        public byte[] risposta;
        
        public RichiestaRispostaSincrona_ListaCUPResponse() {
        }
        
        public RichiestaRispostaSincrona_ListaCUPResponse(string TitoloRisposta, CupManager.svcCUP.esitoElaborazioneCUP_Type EsitoElaborazione, byte[] risposta) {
            this.TitoloRisposta = TitoloRisposta;
            this.EsitoElaborazione = EsitoElaborazione;
            this.risposta = risposta;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="richiesta_RichiestaRispostaSincrona_RichiestaGenerazioneCUP", WrapperNamespace="http://serviziCUP.mef.it/types/", IsWrapped=true)]
    public partial class RichiestaRispostaSincrona_RichiestaGenerazioneCUPRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string TitoloRichiesta;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=1)]
        public byte[] richiesta;
        
        public RichiestaRispostaSincrona_RichiestaGenerazioneCUPRequest() {
        }
        
        public RichiestaRispostaSincrona_RichiestaGenerazioneCUPRequest(string TitoloRichiesta, byte[] richiesta) {
            this.TitoloRichiesta = TitoloRichiesta;
            this.richiesta = richiesta;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="risposta_RichiestaRispostaSincrona_EsitoGenerazioneCUP", WrapperNamespace="http://serviziCUP.mef.it/types/", IsWrapped=true)]
    public partial class RichiestaRispostaSincrona_RichiestaGenerazioneCUPResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string TitoloRisposta;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=1)]
        public CupManager.svcCUP.esitoElaborazioneCUP_Type EsitoElaborazione;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=2)]
        public byte[] risposta;
        
        public RichiestaRispostaSincrona_RichiestaGenerazioneCUPResponse() {
        }
        
        public RichiestaRispostaSincrona_RichiestaGenerazioneCUPResponse(string TitoloRisposta, CupManager.svcCUP.esitoElaborazioneCUP_Type EsitoElaborazione, byte[] risposta) {
            this.TitoloRisposta = TitoloRisposta;
            this.EsitoElaborazione = EsitoElaborazione;
            this.risposta = risposta;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ElaborazioniCUPChannel : CupManager.svcCUP.ElaborazioniCUP, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ElaborazioniCUPClient : System.ServiceModel.ClientBase<CupManager.svcCUP.ElaborazioniCUP>, CupManager.svcCUP.ElaborazioniCUP {
        
        public ElaborazioniCUPClient() {
        }
        
        public ElaborazioniCUPClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ElaborazioniCUPClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ElaborazioniCUPClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ElaborazioniCUPClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        CupManager.svcCUP.RichiestaRispostaSincrona_RichiestaDettaglioCUPResponse CupManager.svcCUP.ElaborazioniCUP.RichiestaRispostaSincrona_RichiestaDettaglioCUP(CupManager.svcCUP.RichiestaRispostaSincrona_RichiestaDettaglioCUPRequest request) {
            return base.Channel.RichiestaRispostaSincrona_RichiestaDettaglioCUP(request);
        }
        
        public string RichiestaRispostaSincrona_RichiestaDettaglioCUP(string TitoloRichiesta, byte[] richiesta, out CupManager.svcCUP.esitoElaborazioneCUP_Type EsitoElaborazione, out byte[] risposta) {
            CupManager.svcCUP.RichiestaRispostaSincrona_RichiestaDettaglioCUPRequest inValue = new CupManager.svcCUP.RichiestaRispostaSincrona_RichiestaDettaglioCUPRequest();
            inValue.TitoloRichiesta = TitoloRichiesta;
            inValue.richiesta = richiesta;
            CupManager.svcCUP.RichiestaRispostaSincrona_RichiestaDettaglioCUPResponse retVal = ((CupManager.svcCUP.ElaborazioniCUP)(this)).RichiestaRispostaSincrona_RichiestaDettaglioCUP(inValue);
            EsitoElaborazione = retVal.EsitoElaborazione;
            risposta = retVal.risposta;
            return retVal.TitoloRisposta;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        CupManager.svcCUP.RichiestaRispostaSincrona_ListaCUPResponse CupManager.svcCUP.ElaborazioniCUP.RichiestaRispostaSincrona_ListaCUP(CupManager.svcCUP.RichiestaRispostaSincrona_ListaCUPRequest request) {
            return base.Channel.RichiestaRispostaSincrona_ListaCUP(request);
        }
        
        public string RichiestaRispostaSincrona_ListaCUP(string TitoloRichiesta, byte[] richiesta, out CupManager.svcCUP.esitoElaborazioneCUP_Type EsitoElaborazione, out byte[] risposta) {
            CupManager.svcCUP.RichiestaRispostaSincrona_ListaCUPRequest inValue = new CupManager.svcCUP.RichiestaRispostaSincrona_ListaCUPRequest();
            inValue.TitoloRichiesta = TitoloRichiesta;
            inValue.richiesta = richiesta;
            CupManager.svcCUP.RichiestaRispostaSincrona_ListaCUPResponse retVal = ((CupManager.svcCUP.ElaborazioniCUP)(this)).RichiestaRispostaSincrona_ListaCUP(inValue);
            EsitoElaborazione = retVal.EsitoElaborazione;
            risposta = retVal.risposta;
            return retVal.TitoloRisposta;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        CupManager.svcCUP.RichiestaRispostaSincrona_RichiestaGenerazioneCUPResponse CupManager.svcCUP.ElaborazioniCUP.RichiestaRispostaSincrona_RichiestaGenerazioneCUP(CupManager.svcCUP.RichiestaRispostaSincrona_RichiestaGenerazioneCUPRequest request) {
            return base.Channel.RichiestaRispostaSincrona_RichiestaGenerazioneCUP(request);
        }
        
        public string RichiestaRispostaSincrona_RichiestaGenerazioneCUP(string TitoloRichiesta, byte[] richiesta, out CupManager.svcCUP.esitoElaborazioneCUP_Type EsitoElaborazione, out byte[] risposta) {
            CupManager.svcCUP.RichiestaRispostaSincrona_RichiestaGenerazioneCUPRequest inValue = new CupManager.svcCUP.RichiestaRispostaSincrona_RichiestaGenerazioneCUPRequest();
            inValue.TitoloRichiesta = TitoloRichiesta;
            inValue.richiesta = richiesta;
            CupManager.svcCUP.RichiestaRispostaSincrona_RichiestaGenerazioneCUPResponse retVal = ((CupManager.svcCUP.ElaborazioniCUP)(this)).RichiestaRispostaSincrona_RichiestaGenerazioneCUP(inValue);
            EsitoElaborazione = retVal.EsitoElaborazione;
            risposta = retVal.risposta;
            return retVal.TitoloRisposta;
        }
    }
}
