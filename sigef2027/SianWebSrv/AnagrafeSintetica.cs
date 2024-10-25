using System;
using System.Xml;
using System.Xml.XPath;
using SianWebSrv.Utils;
using SiarLibrary.NullTypes;

namespace SianWebSrv
{
    /// <summary>
    /// Classe su cui viene mappato l'oggetto ISATSint esposto dal
    /// web service AnagrafeAT. Contiene un sottoinsieme dei dati anagrafici
    /// identificativi di un'azienda per il ministero delle finanze
    /// </summary>
    /// <remarks>
    /// I dati di residenza sono presenti solo per le persone fisiche.
    /// I dati della sede legale sono presenti per le persone giuridiche, e 
    /// per le persone fisiche solo se il luogo di esercizio dell'attività
    /// non coincide con la residenza del soggetto.
    /// Il domicilio è presente solo quando non coincide con la residenza o 
    /// con la sede legale del soggetto.
    /// </remarks>
    public class AnagrafeSintetica
    {
        private string _capDomicilioFiscale;
        /// CAP Domicilio fiscale soggetto, 5 caratteri
        public string capDomicilioFiscale
        {
            get { return _capDomicilioFiscale; }
            set { _capDomicilioFiscale = value; }
        }
        private string _capResidenza;
        /// CAP residenza soggetto, 5 caratteri
        public string capResidenza
        {
            get { return _capResidenza; }
            set { _capResidenza = value; }
        }
        private string _capSedeLegale;
        /// CAP sede legale soggetto, 5 caratteri
        public string capSedeLegale
        {
            get { return _capSedeLegale; }
            set { _capSedeLegale = value; }
        }

        private string _codiceFiscale;
        /// Codice fiscale soggetto ovvero CUAA azienda agricola, 11 o 16 caratteri sempre presente
        public string codiceFiscale
        {
            get { return _codiceFiscale; }
            set { _codiceFiscale = value; }
        }

        private string _comuneDomicilioFiscale;
        /// Descrizione del comune di domicilio del soggetto, 45 caratteri
        public string comuneDomicilioFiscale
        {
            get { return _comuneDomicilioFiscale; }
            set { _comuneDomicilioFiscale = value; }
        }

        private string _comuneNascita;
        /// Descrizione del comune di nascita del soggetto, 45 caratteri
        public string comuneNascita
        {
            get { return _comuneNascita; }
            set { _comuneNascita = value; }
        }

        private string _comuneResidenza;
        /// Descrizione del comune di residenza del soggetto, 45 caratteri
        public string comuneResidenza
        {
            get { return _comuneResidenza; }
            set { _comuneResidenza = value; }
        }

        private string _comuneSedeLegale;
        /// Descrizione del comune sede legale del soggetto, 45 caratteri
        public string comuneSedeLegale
        {
            get { return _comuneSedeLegale; }
            set { _comuneSedeLegale = value; }
        }

        private DatetimeNT _dataNascita;
        /// Data nascita del soggetto, solo se persona fisica
        public DatetimeNT dataNascita
        {
            get { return _dataNascita; }
            set { _dataNascita = value; }
        }

        private string _denominazione;
        /// Denominazione soggetto se persona giuridica, 150 caratteri
        public string denominazione
        {
            get { return _denominazione; }
            set { _denominazione = value; }
        }

        private string _indirizzoDomicilioFiscale;
        /// Indirizzo domicilio fiscale, 35 caratteri
        public string indirizzoDomicilioFiscale
        {
            get { return _indirizzoDomicilioFiscale; }
            set { _indirizzoDomicilioFiscale = value; }
        }

        private string _indirizzoResidenza;
        /// Indirizzo residenza, 35 caratteri
        public string indirizzoResidenza
        {
            get { return _indirizzoResidenza; }
            set { _indirizzoResidenza = value; }
        }

        private string _indirizzoSedeLegale;
        /// Indirizzo sede legale, 35 caratteri
        public string indirizzoSedeLegale
        {
            get { return _indirizzoSedeLegale; }
            set { _indirizzoSedeLegale = value; }
        }

        private string _naturaGiuridica;
        /// Descrizione natura giuridica del soggetto, è assente per le persone fisiche. 56 caratteri
        public string naturaGiuridica
        {
            get { return _naturaGiuridica; }
            set { _naturaGiuridica = value; }
        }

        private string _nome;
        /// Nome del soggetto se persona fisica, 20 carateri
        public string nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        private string _partitaIva;
        /// Partita IVA del soggetto, 11 caratteri
        public string partitaIva
        {
            get { return _partitaIva; }
            set { _partitaIva = value; }
        }

        private string _provinciaDomicilioFiscale;
        /// Sigla provincia domicilio fiscale del soggetto, 2 caratteri
        public string provinciaDomicilioFiscale
        {
            get { return _provinciaDomicilioFiscale; }
            set { _provinciaDomicilioFiscale = value; }
        }

        private string _provinciaNascita;
        /// Sigla provincia di nascita del soggetto, EE per nati all'estero. 2 caratteri
        public string provinciaNascita
        {
            get { return _provinciaNascita; }
            set { _provinciaNascita = value; }
        }

        private string _provinciaResidenza;
        /// Sigla provincia di residenza del soggetto. 2 caratteri
        public string provinciaResidenza
        {
            get { return _provinciaResidenza; }
            set { _provinciaResidenza = value; }
        }

        private string _provinciaSedeLegale;
        /// Sigla provincia sede lagale del soggetto. 2 caratteri
        public string provinciaSedeLegale
        {
            get { return _provinciaSedeLegale; }
            set { _provinciaSedeLegale = value; }
        }

        private string _sesso;
        /// Se persona fisica M=Maschio, F=Femmina
        public string sesso
        {
            get { return _sesso; }
            set { _sesso = value; }
        }

        private string _cognome;
        public string cognome
        {
            get { return _cognome; }
            set { _cognome = value; }
        }

        /// <summary>
        /// Istanzia la classe leggendone i campi dal SOAP Envelope estratto
        /// dalla risposta del WebService
        /// </summary>
        /// <param name="SianData">
        /// Soap Envelope estratto dalla risposta SOAP.
        /// Vedi metodo getAnagraficaSintetica della classe SianGateway
        /// </param>
        /*internal void LoadFromSianData(XPathNavigator SianData)
        {
            // con un po' di reflection si potrebbe fare di sicuro meglio... se si 
            // poteva fare con Delphi di sicuro si può fare anche in C#
            //this.CUAA = DatiSian.getValue(SIANGateway.XPathFascicolo20.risposta10.CUAA);

            capDomicilioFiscale = SianData.SelectSingleNode("ns1:capDomicilioFiscale").Value;
            capResidenza = SianData.SelectSingleNode("ns1:capResidenza").Value;
            capSedeLegale = SianData.SelectSingleNode("ns1:capSedeLegale").Value;
            codiceFiscale = SianData.SelectSingleNode("ns1:codiceFiscale").Value;
            comuneDomicilioFiscale = SianData.SelectSingleNode("ns1:comuneDomicilioFiscale").Value;
            comuneNascita = SianData.SelectSingleNode("ns1:comuneNascita").Value;
            comuneResidenza = SianData.SelectSingleNode("ns1:comuneResidenza").Value;
            comuneSedeLegale = SianData.SelectSingleNode("ns1:comuneSedeLegale").Value;
            DataSIAN dataNasObj = new DataSIAN(SianData.SelectSingleNode("ns1:dataNascita").Value);
            dataNascita = dataNasObj.getDatetimeNT();
            denominazione = SianData.SelectSingleNode("ns1:denominazione").Value;
            indirizzoDomicilioFiscale = SianData.SelectSingleNode("ns1:indirizzoDomicilioFiscale").Value;
            indirizzoResidenza = SianData.SelectSingleNode("ns1:indirizzoResidenza").Value;
            indirizzoSedeLegale = SianData.SelectSingleNode("ns1:indirizzoSedeLegale").Value;
            naturaGiuridica = SianData.SelectSingleNode("ns1:naturaGiuridica").Value;
            partitaIva = SianData.SelectSingleNode("ns1:partitaIva").Value;
            provinciaDomicilioFiscale = SianData.SelectSingleNode("ns1:provinciaDomicilioFiscale").Value;
            provinciaNascita = SianData.SelectSingleNode("ns1:provinciaNascita").Value;
            provinciaResidenza = SianData.SelectSingleNode("ns1:provinciaResidenza").Value;
            provinciaSedeLegale = SianData.SelectSingleNode("ns1:provinciaSedeLegale").Value;
            sesso = SianData.SelectSingleNode("ns1:sesso").Value;
            nome = SianData.SelectSingleNode("ns1:nome").Value;
            cognome = SianData.SelectSingleNode("ns1:cognome").Value;

        }*/

        internal void LoadFromDatiSian(SIANGateway.SianResult DatiSian)
        {
            DatiSian.RootXPath = SIANGateway.XPathAT.RootSint +
                                 SIANGateway.XPathAT.rispostaSint.Root;

            capDomicilioFiscale = DatiSian.getValue(SIANGateway.XPathAT.rispostaSint.capDomicilioFiscale);
            capResidenza = DatiSian.getValue(SIANGateway.XPathAT.rispostaSint.capResidenza);
            capSedeLegale = DatiSian.getValue(SIANGateway.XPathAT.rispostaSint.capSedeLegale);
            codiceFiscale = DatiSian.getValue(SIANGateway.XPathAT.rispostaSint.codiceFiscale);
            comuneDomicilioFiscale = DatiSian.getValue(SIANGateway.XPathAT.rispostaSint.comuneDomicilioFiscale);
            comuneNascita = DatiSian.getValue(SIANGateway.XPathAT.rispostaSint.comuneNascita);
            comuneResidenza = DatiSian.getValue(SIANGateway.XPathAT.rispostaSint.comuneResidenza);
            comuneSedeLegale = DatiSian.getValue(SIANGateway.XPathAT.rispostaSint.comuneSedeLegale);
            string DataInXML = DatiSian.getValue(SIANGateway.XPathAT.rispostaSint.dataNascita, false);
            if (DataInXML != "")
            {
                //DateTime dt = System.Convert.ToDateTime(DataInXML.Substring(0, 10));
                //DataSIAN DTAnascita = new DataSIAN(dt);
                dataNascita = new DatetimeNT(DataInXML.Substring(0, 10));
            }
            else
            {
                // manca la data di nascita
                dataNascita = new DatetimeNT();
            }
            denominazione = DatiSian.getValue(SIANGateway.XPathAT.rispostaSint.denominazione);
            indirizzoDomicilioFiscale = DatiSian.getValue(SIANGateway.XPathAT.rispostaSint.indirizzoDomicilioFiscale);
            indirizzoResidenza = DatiSian.getValue(SIANGateway.XPathAT.rispostaSint.indirizzoResidenza);
            indirizzoSedeLegale = DatiSian.getValue(SIANGateway.XPathAT.rispostaSint.indirizzoSedeLegale);
            naturaGiuridica = DatiSian.getValue(SIANGateway.XPathAT.rispostaSint.naturaGiuridica);
            partitaIva = DatiSian.getValue(SIANGateway.XPathAT.rispostaSint.partitaIva);
            provinciaDomicilioFiscale = DatiSian.getValue(SIANGateway.XPathAT.rispostaSint.provinciaDomicilioFiscale);
            provinciaNascita = DatiSian.getValue(SIANGateway.XPathAT.rispostaSint.provinciaNascita);
            provinciaResidenza = DatiSian.getValue(SIANGateway.XPathAT.rispostaSint.provinciaResidenza);
            provinciaSedeLegale = DatiSian.getValue(SIANGateway.XPathAT.rispostaSint.provinciaSedeLegale);
            sesso = DatiSian.getValue(SIANGateway.XPathAT.rispostaSint.sesso);
            nome = DatiSian.getValue(SIANGateway.XPathAT.rispostaSint.nome);
            cognome = DatiSian.getValue(SIANGateway.XPathAT.rispostaSint.cognome);

        }

        private string nullToString(string s){
            if (s == null)
            {
                return "";
            }
            else
            {
                return s;
            }
        }

        /*internal void LoadFromSianData(WSAnagrafeTributaria.ISATSint DatiSian)
        {
            this.capDomicilioFiscale = nullToString(DatiSian.capDomicilioFiscale);
            this.capResidenza = nullToString(DatiSian.capResidenza);
            this.capSedeLegale = nullToString(DatiSian.capSedeLegale);
            this.codiceFiscale = nullToString(DatiSian.codiceFiscale);
            this.cognome = nullToString(DatiSian.cognome);
            this.comuneDomicilioFiscale = nullToString(DatiSian.comuneDomicilioFiscale);
            this.comuneNascita = nullToString(DatiSian.comuneNascita);
            this.comuneResidenza = nullToString(DatiSian.comuneResidenza);
            if (DatiSian.dataNascita != null)
            {
                this.dataNascita = new DatetimeNT(DatiSian.dataNascita.Substring(0, 10));
            }
            else
            {
                // manca la data di nascita
                dataNascita = new DatetimeNT();
            }
            this.denominazione = nullToString(DatiSian.denominazione);
            this.indirizzoDomicilioFiscale = nullToString(DatiSian.indirizzoDomicilioFiscale);
            this.indirizzoResidenza = nullToString(DatiSian.indirizzoResidenza);
            this.indirizzoSedeLegale = nullToString(DatiSian.indirizzoSedeLegale);
            this.naturaGiuridica = nullToString(DatiSian.naturaGiuridica);
            this.nome = nullToString(DatiSian.nome);
            this.partitaIva = nullToString(DatiSian.partitaIva);
            this.provinciaDomicilioFiscale = nullToString(DatiSian.provinciaDomicilioFiscale);
            this.provinciaNascita = nullToString(DatiSian.provinciaNascita);
            this.provinciaResidenza = nullToString(DatiSian.provinciaResidenza);
            this.provinciaSedeLegale = nullToString(DatiSian.provinciaSedeLegale);
            this.sesso = nullToString(DatiSian.sesso);
        }*/

    }
}
