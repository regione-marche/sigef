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
    public class RespAnagFascicolo
    {
        private string _CUAA;
        /// Codice fiscale azienda agricola. 11 o 16 caratteri
        public string CUAA
        {
            get { return _CUAA; }
            set { _CUAA = value; }
        }

        private string _codiceInps;
        /// Codice I.N.P.S. azienda agricola, 15 caratteri 
        public string codiceInps
        {
            get { return _codiceInps; }
            set { _codiceInps = value; }
        }

        private string _comuneNascitaPF;
        /// Codice Belfiore comune o stato estero di nascita per le ditte individuali 
        public string comuneNascitaPF
        {
            get { return _comuneNascitaPF; }
            set { _comuneNascitaPF = value; }
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

        private DatetimeNT _dataElaborazione;
        /// Data validità controlli sul fascicolo
        public DatetimeNT dataElaborazione
        {
            get { return _dataElaborazione; }
            set { _dataElaborazione = value; }
        }

        private DatetimeNT _dataNascitaPF;
        /// Data nascita soggetto se l'azienda è una ditta individuale
        public DatetimeNT dataNascitaPF
        {
            get { return _dataNascitaPF; }
            set { _dataNascitaPF = value; }
        }

        private DatetimeNT _dataValidazFascicolo;
        /// Data ultima convalida da parte utente dell'utente CAA
        public DatetimeNT dataValidazFascicolo
        {
            get { return _dataValidazFascicolo; }
            set { _dataValidazFascicolo = value; }
        }

        private string _denominazione;
        /// Denominazione per persone giuridiche, Cognome per persone fisiche, 150 caratteri
        public string denominazione 
        {
            get { return _denominazione; }
            set { _denominazione = value; }
        }

        private string _detentore;
        /// Codice di identificazione dell’ufficio presso cui è custodito il fascicolo cartaceo, 9 caratteri
        public string detentore
        {
            get { return _detentore; }
            set { _detentore = value; }
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

        private string _nomePF;
        /// Nome se azienda è ditta individuale 
        public string nomePF
        {
            get { return _nomePF; }
            set { _nomePF = value; }
        }

        private string _organismoPagatore;
        /// Codice di identificazione dell’OP competente (FEOGA) 
        public string organismoPagatore
        {
            get { return _organismoPagatore; }
            set { _organismoPagatore = value; }
        }

        private string _partitaIVA;
        /// Partita IVA Azienda
        public string partitaIVA
        {
            get { return _partitaIVA; }
            set { _partitaIVA = value; }
        }

        private string _sessoPF;
        /// Sesso se azienda è ditta individuale, M=Maschi, F=Femmina 
        public string sessoPF
        {
            get { return _sessoPF; }
            set { _sessoPF = value; }
        }

        private string _tipoAzienda;
        /// Valori possibili: PF=Persona fisica, PG=Persona Giuridica 
        public string tipoAzienda
        {
            get { return _tipoAzienda; }
            set { _tipoAzienda = value; }
        }

        private string _tipoDetentore;
        /// Codice di riconoscimento della tipologia del detentore, 3 caratteri
        public string tipoDetentore
        {
            get { return _tipoDetentore; }
            set { _tipoDetentore = value; }
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

        private string _provinciaRecapito;
        /// Sigla provincia recapito, presente solo se diverso da residenza/sede legale 
        public string provinciaRecapito
        {
            get { return _provinciaRecapito; }
            set { _provinciaRecapito = value; }
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

        private string _provinciaResidenza;
        /// Sigla provincia residenza per persone fisiche o sede legale per persone giuridiche
        public string provinciaResidenza
        {
            get { return _provinciaResidenza; }
            set { _provinciaResidenza = value; }
        }

        /// <summary>
        /// Istanzia la classe leggendone i campi dal SOAP Envelope estratto
        /// dalla risposta del WebService
        /// </summary>
        /// <param name="SianData">
        /// Soap Envelope estratto dalla risposta SOAP.
        /// Vedi metodo trovaFascicolo della classe SIANGateway
        /// </param>
        internal RespAnagFascicolo(SIANGateway.SianResult DatiSian)
        {
            // modificato 12/03/2008 per adeguamento versione TrovaFascicolo 2.0 
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
            this.partitaIVA = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.partitaIVA);
            this.iscrizioneRea = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.iscrizioneRea, false);
            this.iscrizioneRegistroImprese = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.iscrizioneRegistroImprese, false);
            this.codiceInps = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.codiceInps, false);
            this.organismoPagatore = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.organismoPagatore);
            DataSIAN DTAperturaFascicolo = new DataSIAN( DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.dataAperturaFascicolo));
            this.dataAperturaFascicolo = DTAperturaFascicolo.getDatetimeNT();
            DataSIAN DTChiusuraFascicolo = new DataSIAN(DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.dataChiusuraFascicolo, false));
            this.dataChiusuraFascicolo = DTChiusuraFascicolo.getDatetimeNT();
            this.tipoDetentore = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.tipoDetentore, false);
            this.detentore = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.detentore, false);
            DataSIAN DTValidazFascicolo = new DataSIAN(DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.dataValidazFascicolo));
            this.dataValidazFascicolo = DTValidazFascicolo.getDatetimeNT();
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

            this.provinciaRecapito = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.recapito.provincia,false);
            this.comuneRecapito = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.recapito.comune, false);
            this.indirizzoRecapito = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.recapito.indirizzo, false);
            this.capRecapito = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.recapito.cap, false);
            this.codiceStatoEsteroRecapito = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.recapito.codiceStatoEstero, false);

        }

        /*

        internal RespAnagFascicolo(SIANGateway.SianResult DatiSian)
        {
            DatiSian.RootXPath = SIANGateway.XPathFascicolo20.Root +
                                 SIANGateway.XPathFascicolo20.risposta1.Root;

            this.CUAA = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta1.CUAA);
            this.tipoAzienda = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta1.tipoAzienda);
            this.denominazione = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta1.denominazione);
            this.nomePF = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta1.nomePF);
            this.sessoPF = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta1.sessoPF, false);
            DataSIAN DTAnascita = new DataSIAN(DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta1.dataNascitaPF, false));
            this.dataNascitaPF = DTAnascita.getDatetimeNT();
            this.comuneNascitaPF = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta1.comuneNascitaPF, false);
            this.partitaIVA = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta1.partitaIVA);
            this.iscrizioneRea = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta1.iscrizioneRea, false);
            this.iscrizioneRegistroImprese = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta1.iscrizioneRegistroImprese, false);
            this.codiceInps = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta1.codiceInps, false);
            this.organismoPagatore = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta1.organismoPagatore);
            DataSIAN DTAperturaFascicolo = new DataSIAN( DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta1.dataAperturaFascicolo));
            this.dataAperturaFascicolo = DTAperturaFascicolo.getDatetimeNT();
            DataSIAN DTChiusuraFascicolo = new DataSIAN(DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta1.dataChiusuraFascicolo, false));
            this.dataChiusuraFascicolo = DTChiusuraFascicolo.getDatetimeNT();
            this.tipoDetentore = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta1.tipoDetentore, false);
            this.detentore = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta1.detentore, false);
            DataSIAN DTValidazFascicolo = new DataSIAN(DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta1.dataValidazFascicolo));
            this.dataValidazFascicolo = DTValidazFascicolo.getDatetimeNT();
            DataSIAN DTElaborazioneFascicolo = new DataSIAN(DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta1.dataElaborazione));
            this.dataElaborazione = DTElaborazioneFascicolo.getDatetimeNT();

            DatiSian.RootXPath = SIANGateway.XPathFascicolo20.Root +
                                 SIANGateway.XPathFascicolo20.risposta1.Root +
                                 SIANGateway.XPathFascicolo20.risposta1.sedeResidenza.Root;

            this.provinciaResidenza = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta1.sedeResidenza.provincia, false);
            this.comuneResidenza = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta1.sedeResidenza.comune, false);
            this.indirizzoResidenza = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta1.sedeResidenza.indirizzo, false);
            this.capResidenza = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta1.sedeResidenza.cap, false);
            this.codiceStatoEsteroResidenza = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta1.sedeResidenza.codiceStatoEstero, false);

            DatiSian.RootXPath = SIANGateway.XPathFascicolo20.Root +
                                 SIANGateway.XPathFascicolo20.risposta1.Root +
                                 SIANGateway.XPathFascicolo20.risposta1.recapito.Root;

            this.provinciaRecapito = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta1.recapito.provincia,false);
            this.comuneRecapito = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta1.recapito.comune, false);
            this.indirizzoRecapito = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta1.recapito.indirizzo, false);
            this.capRecapito = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta1.recapito.cap, false);
            this.codiceStatoEsteroRecapito = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta1.recapito.codiceStatoEstero, false);

        }
        
        internal RespAnagFascicolo(XPathNavigator SianData)
        {
            this.capResidenza = SianData.SelectSingleNode("sedeResidenza/cap").Value;
            string pippo = SianData.SelectSingleNode("recapito/cap").Value;

            this.capRecapito = SianData.SelectSingleNode("recapito/cap").Value;
            this.capResidenza = SianData.SelectSingleNode("sedeResidenza/cap").Value;
            this.codiceInps = SianData.SelectSingleNode("codiceInps").Value;
            this.codiceStatoEsteroRecapito = SianData.SelectSingleNode("recapito/codiceStatoEstero").Value;
            this.codiceStatoEsteroResidenza = SianData.SelectSingleNode("sedeResidenza/codiceStatoEstero").Value;
            this.comuneNascitaPF = SianData.SelectSingleNode("comuneNascitaPF").Value;
            this.comuneRecapito = SianData.SelectSingleNode("recapito/comune").Value;
            this.comuneResidenza = SianData.SelectSingleNode("sedeResidenza/comune").Value;
            this.CUAA = SianData.SelectSingleNode("CUAA").Value;
            DataSIAN DTApertura = new DataSIAN(SianData.SelectSingleNode("dataAperturaFascicolo").Value);
            this.dataAperturaFascicolo = DTApertura.getDatetimeNT();
            DataSIAN DTChiusursa = new DataSIAN(SianData.SelectSingleNode("dataChiusuraFascicolo").Value);
            this.dataChiusuraFascicolo = DTChiusursa.getDatetimeNT();
            DataSIAN DTElaborazione = new DataSIAN(SianData.SelectSingleNode("dataElaborazione").Value);
            this.dataElaborazione = DTElaborazione.getDatetimeNT();
            DataSIAN DTNascitaPF = new DataSIAN(SianData.SelectSingleNode("dataNascitaPF").Value);
            this.dataNascitaPF = DTNascitaPF.getDatetimeNT();
            DataSIAN DTValFascicolo = new DataSIAN(SianData.SelectSingleNode("dataValidazFascicolo").Value);
            this.dataValidazFascicolo = DTValFascicolo.getDatetimeNT();
            this.denominazione = SianData.SelectSingleNode("denominazione").Value;
            this.detentore = SianData.SelectSingleNode("detentore").Value;
            this.indirizzoRecapito = SianData.SelectSingleNode("recapito/indirizzo").Value;
            this.indirizzoResidenza = SianData.SelectSingleNode("sedeResidenza/indirizzo").Value;
            this.iscrizioneRea = SianData.SelectSingleNode("iscrizioneRea").Value;
            this.iscrizioneRegistroImprese = SianData.SelectSingleNode("iscrizioneRegistroImprese").Value;
            this.nomePF = SianData.SelectSingleNode("nomePF").Value;
            this.organismoPagatore = SianData.SelectSingleNode("organismoPagatore").Value;
            this.partitaIVA = SianData.SelectSingleNode("partitaIVA").Value;
            this.provinciaRecapito = SianData.SelectSingleNode("recapito/provincia").Value;
            this.provinciaResidenza = SianData.SelectSingleNode("sedeResidenza/provincia").Value;
            this.sessoPF = SianData.SelectSingleNode("sessoPF").Value;
            this.tipoAzienda = SianData.SelectSingleNode("tipoAzienda").Value;
            this.tipoDetentore = SianData.SelectSingleNode("tipoDetentore").Value;
        }
        */

    }
}
