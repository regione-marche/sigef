using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using SianWebSrv.Utils;
using SiarLibrary.NullTypes;

namespace SianWebSrv
{
    /// <summary>
    /// Classe su cui viene mappato l'oggetto ISWSRespAnagFascicolo esposto dal
    /// web service ISWSAgeaToOpr.trovaFascicolo
    /// Contiene i dati anagrafici principali dell'azienda
    /// </summary>
    public class RespAnagFascicolo2
    {
        private string _CUAA;
        /// Codice fiscale azienda agricola. 11 o 16 caratteri
        public string CUAA
        {
            get { return _CUAA; }
            set { _CUAA = value; }
        }

        private string _tipoAzienda;
        /// Valori possibili: PF=Persona fisica, PG=Persona Giuridica 
        public string tipoAzienda
        {
            get { return _tipoAzienda; }
            set { _tipoAzienda = value; }
        }

        private string _denominazione;
        /// Denominazione per persone giuridiche, Cognome per persone fisiche, 150 caratteri
        public string denominazione
        {
            get { return _denominazione; }
            set { _denominazione = value; }
        }

        private string _nomePF;
        /// Nome se azienda è ditta individuale 
        public string nomePF
        {
            get { return _nomePF; }
            set { _nomePF = value; }
        }

        private string _sessoPF;
        /// Sesso se azienda è ditta individuale, M=Maschi, F=Femmina 
        public string sessoPF
        {
            get { return _sessoPF; }
            set { _sessoPF = value; }
        }

        private DatetimeNT _dataNascitaPF;
        /// Data nascita soggetto se l'azienda è una ditta individuale
        public DatetimeNT dataNascitaPF
        {
            get { return _dataNascitaPF; }
            set { _dataNascitaPF = value; }
        }

        private string _comuneNascitaPF;
        /// Codice Belfiore comune o stato estero di nascita per le ditte individuali 
        public string comuneNascitaPF
        {
            get { return _comuneNascitaPF; }
            set { _comuneNascitaPF = value; }
        }

        private string _TipoDocumento;
        ///<summary>
        /// Codice tipo documento di riconoscimento 1 = Carta di identita, 2 = Patente auto, 3 = Tessera delle Ferrovie dello Stato,
        /// 4 = Passaporto, 5 = Tessera postale, 6 = Altro documento, 7 = Libretto postale
        /// </summary>
        public string TipoDocumento
        {
            get { return _TipoDocumento; }
            set { _TipoDocumento = value; }
        }

        private string _NumeroDocumento;
        /// Numero documento di riconoscimento 
        public string NumeroDocumento
        {
            get { return _NumeroDocumento; }
            set { _NumeroDocumento = value; }
        }

        private DatetimeNT _DataDocumento;
        /// Data rilascio documento di identita
        public DatetimeNT DataDocumento
        {
            get { return _DataDocumento; }
            set { _DataDocumento = value; }
        }

        private DatetimeNT _DataScadDocumento;
        /// Data scadenza documento identita
        public DatetimeNT DataScadDocumento
        {
            get { return _DataScadDocumento; }
            set { _DataScadDocumento = value; }
        }

        private string _provinciaResidenza;
        /// Sigla provincia residenza per persone fisiche o sede legale per persone giuridiche
        public string provinciaResidenza
        {
            get { return _provinciaResidenza; }
            set { _provinciaResidenza = value; }
        }

        private string _comuneResidenza;
        /// Denominazione comune residenza per persone fisiche o sede legale per persone giuridiche
        public string comuneResidenza
        {
            get { return _comuneResidenza; }
            set { _comuneResidenza = value; }
        }

        private string _indirizzoResidenza;
        /// Indirizzo residenza per persone fisiche o sede legale per persone giuridiche
        public string indirizzoResidenza
        {
            get { return _indirizzoResidenza; }
            set { _indirizzoResidenza = value; }
        }

        private string _capResidenza;
        /// Cap residenza per persone fisiche o sede legale per persone giuridiche
        public string capResidenza
        {
            get { return _capResidenza; }
            set { _capResidenza = value; }
        }

        private string _codiceStatoEsteroResidenza;
        /// Codice stato estero residenza per persone fisiche o sede legale per persone giuridiche
        public string codiceStatoEsteroResidenza
        {
            get { return _codiceStatoEsteroResidenza; }
            set { _codiceStatoEsteroResidenza = value; }
        }

        private string _provinciaRecapito;
        /// Sigla provincia recapito, presente solo se diverso da residenza/sede legale 
        public string provinciaRecapito
        {
            get { return _provinciaRecapito; }
            set { _provinciaRecapito = value; }
        }

        private string _comuneRecapito;
        /// Denominazione comune recapito, presente solo se diverso da residenza/sede legale
        public string comuneRecapito
        {
            get { return _comuneRecapito; }
            set { _comuneRecapito = value; }
        }

        private string _indirizzoRecapito;
        /// Indirizzo recapito, presente solo se diverso da residenza/sede legale 
        public string indirizzoRecapito
        {
            get { return _indirizzoRecapito; }
            set { _indirizzoRecapito = value; }
        }

        private string _capRecapito;
        /// CAP recapito, presente solo se diverso da residenza/sede legale 
        public string capRecapito
        {
            get { return _capRecapito; }
            set { _capRecapito = value; }
        }

        private string _codiceStatoEsteroRecapito;
        /// Codice stato estero recapito, presente solo se diverso da residenza/sede legale
        public string codiceStatoEsteroRecapito
        {
            get { return _codiceStatoEsteroRecapito; }
            set { _codiceStatoEsteroRecapito = value; }
        }

        private string _partitaIVA;
        /// Partita IVA Azienda
        public string partitaIVA
        {
            get { return _partitaIVA; }
            set { _partitaIVA = value; }
        }

        private string _iscrizioneRea;
        /// Codice CCIAA di iscrizione al REA
        public string iscrizioneRea
        {
            get { return _iscrizioneRea; }
            set { _iscrizioneRea = value; }
        }

        private string _iscrizioneRegistroImprese;
        /// Cod. CCIAA di iscr. al Registro Imprese 
        public string iscrizioneRegistroImprese
        {
            get { return _iscrizioneRegistroImprese; }
            set { _iscrizioneRegistroImprese = value; }
        }

        private string _codiceInps;
        /// Codice I.N.P.S. azienda agricola, 15 caratteri 
        public string codiceInps
        {
            get { return _codiceInps; }
            set { _codiceInps = value; }
        }

        private string _organismoPagatore;
        /// Codice di identificazione dell’OP competente (FEOGA) 
        public string organismoPagatore
        {
            get { return _organismoPagatore; }
            set { _organismoPagatore = value; }
        }

        private DatetimeNT _dataAperturaFascicolo;
        /// Data prima costituzione fascicolo presso il CAA 
        public DatetimeNT dataAperturaFascicolo
        {
            get { return _dataAperturaFascicolo; }
            set { _dataAperturaFascicolo = value; }
        }

        private DatetimeNT _dataChiusuraFascicolo;
        /// Data chiusura/revoca fascicolo presso il CAA 
        public DatetimeNT dataChiusuraFascicolo
        {
            get { return _dataChiusuraFascicolo; }
            set { _dataChiusuraFascicolo = value; }
        }

        private string _tipoDetentore;
        /// Codice di riconoscimento della tipologia del detentore, 3 caratteri
        public string tipoDetentore
        {
            get { return _tipoDetentore; }
            set { _tipoDetentore = value; }
        }

        private string _detentore;
        /// Codice di identificazione dell’ufficio presso cui è custodito il fascicolo cartaceo
        public string detentore
        {
            get { return _detentore; }
            set { _detentore = value; }
        }

        private string _pec;
        /// pec aziendale
        public string pec
        {
            get { return _pec; }
            set { _pec = value; }
        }

        private DatetimeNT _dataValidazFascicolo;
        /// Data validazione fascicolo
        public DatetimeNT dataValidazFascicolo
        {
            get { return _dataValidazFascicolo; }
            set { _dataValidazFascicolo = value; }
        }

        private string _schedaValidazione;
        /// Numero della scheda di validazione
        public string schedaValidazione
        {
            get { return _schedaValidazione; }
            set { _schedaValidazione = value; }
        }

        private DatetimeNT _dataSchedaValidazione;
        /// Data della scheda di validazione fascicolo
        public DatetimeNT dataSchedaValidazione
        {
            get { return _dataSchedaValidazione; }
            set { _dataSchedaValidazione = value; }
        }

        private DatetimeNT _dataSottMandato;
        /// Data sottoscrizione mandato al CAA
        public DatetimeNT dataSottMandato
        {
            get { return _dataSottMandato; }
            set { _dataSottMandato = value; }
        }

        private DatetimeNT _dataElaborazione;
        /// Data validità controlli sul fascicolo
        public DatetimeNT dataElaborazione
        {
            get { return _dataElaborazione; }
            set { _dataElaborazione = value; }
        }

        /// <summary>
        /// Istanzia la classe leggendone i campi dal SOAP Envelope estratto
        /// dalla risposta del WebService
        /// </summary>
        /// <param name="SianData">
        /// Soap Envelope estratto dalla risposta SOAP.
        /// Vedi metodo AnagraficaAziendaFS10 della classe SIANGateway
        /// </param>
        internal RespAnagFascicolo2(SIANGateway.SianResult DatiSian)
        {
            DatiSian.RootXPath = SIANGateway.XPathFascicolo20.Root +
                                 SIANGateway.XPathFascicolo20.risposta10.Root;

            this.CUAA = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.CUAA);
            this.tipoAzienda = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.tipoAzienda);
            this.denominazione = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.denominazione);
            this.nomePF = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.nomePF);
            this.sessoPF = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.sessoPF, false);
            DataSIAN DTAnascita = new DataSIAN(DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.dataNascitaPF, false));
            this.dataNascitaPF = DTAnascita.getDatetimeNT();
            this.comuneNascitaPF = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.comuneNascitaPF, false);

            this.TipoDocumento = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.TipoDocumento, false);
            this.NumeroDocumento = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.NumeroDocumento, false);
            DataSIAN DataDocumento = new DataSIAN(DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.DataDocumento, false));
            this.DataDocumento = DataDocumento.getDatetimeNT();
            DataSIAN DataScadDocumento = new DataSIAN(DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.DataScadDocumento, false));
            this.DataScadDocumento = DataScadDocumento.getDatetimeNT();

            this.partitaIVA = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.partitaIVA);
            this.iscrizioneRea = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.iscrizioneRea, false);
            this.iscrizioneRegistroImprese = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.iscrizioneRegistroImprese, false);
            this.codiceInps = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.codiceInps, false);
            this.organismoPagatore = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.organismoPagatore);
            DataSIAN DTAperturaFascicolo = new DataSIAN(DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.dataAperturaFascicolo));
            this.dataAperturaFascicolo = DTAperturaFascicolo.getDatetimeNT();
            DataSIAN DTChiusuraFascicolo = new DataSIAN(DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.dataChiusuraFascicolo, false));
            this.dataChiusuraFascicolo = DTChiusuraFascicolo.getDatetimeNT();
            this.tipoDetentore = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.tipoDetentore, false);
            this.detentore = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.detentore, false);
            this.pec = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.pec, false);
            DataSIAN DTValidazFascicolo = new DataSIAN(DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.dataValidazFascicolo));
            this.dataValidazFascicolo = DTValidazFascicolo.getDatetimeNT();

            this.schedaValidazione = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.schedaValidazione, false);
            DataSIAN dataSchedaValidazione = new DataSIAN(DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.dataSchedaValidazione, false));
            this.dataSchedaValidazione = dataSchedaValidazione.getDatetimeNT();
            DataSIAN dataSottMandato = new DataSIAN(DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.dataSottMandato, false));
            this.dataSottMandato = dataSottMandato.getDatetimeNT();

            DataSIAN DTElaborazioneFascicolo = new DataSIAN(DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.dataElaborazione));
            this.dataElaborazione = DTElaborazioneFascicolo.getDatetimeNT();

            DatiSian.RootXPath = SIANGateway.XPathFascicolo20.Root +
                                 SIANGateway.XPathFascicolo20.risposta10.Root +
                                 SIANGateway.XPathFascicolo20.risposta10.sedeResidenza.Root;

            this.provinciaResidenza = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.sedeResidenza.provincia, false);
            this.comuneResidenza = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.sedeResidenza.comune, false);
            this.indirizzoResidenza = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.sedeResidenza.indirizzo, false);
            this.capResidenza = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.sedeResidenza.cap, false);
            this.codiceStatoEsteroResidenza = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.sedeResidenza.codiceStatoEstero, false);

            DatiSian.RootXPath = SIANGateway.XPathFascicolo20.Root +
                                 SIANGateway.XPathFascicolo20.risposta10.Root +
                                 SIANGateway.XPathFascicolo20.risposta10.recapito.Root;

            this.provinciaRecapito = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.recapito.provincia, false);
            this.comuneRecapito = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.recapito.comune, false);
            this.indirizzoRecapito = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.recapito.indirizzo, false);
            this.capRecapito = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.recapito.cap, false);
            this.codiceStatoEsteroRecapito = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.recapito.codiceStatoEstero, false);

        }


    }
}
