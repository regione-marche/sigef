using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using SianWebSrv.Utils;
using System.Globalization;
using SiarLibrary.NullTypes;

namespace SianWebSrv
{
    /// <summary>
    /// Classe su cui viene mappato l'oggetto ISWSAllevamenti esposto dal
    /// web service ISWSAgeaToOpr.trovaFascicolo
    /// Contiene la lista dei principali allevamenti dell'azienda
    /// </summary>
    public class CollOfAllevamento : System.Collections.CollectionBase
    { 
        /// <summary>
        /// Aggiunge un elemento alla lista
        /// </summary>
        /// <param name="aAllevamento">Elemento da aggiungere in coda alla lista</param>
        public void Add(Allevamento aAllevamento)
        { 
            List.Add(aAllevamento);
        }
        /// <summary>
        /// Rimuove un elemento dalla lista
        /// </summary>
        /// <param name="index">Posizione base 0 dell'elemento da rimuovere</param>
        public void Remove(int index)
        {
            if (index > Count - 1 || index < 0)
            {
                throw new Exception("Collection index out of range");
            }
            else
            {
                List.RemoveAt(index);
            }
        }
        /// <summary>
        /// Recupera un elemento della lista
        /// </summary>
        /// <param name="Index">Posizione base 0 dell'elemento da recuperare</param>
        public Allevamento Item(int Index)
        {
            return (Allevamento)List[Index];
        }
        internal CollOfAllevamento(SIANGateway.SianResult SianData)
        {
            XPathNodeIterator elementi = SianData.getIterator(SIANGateway.XPathInterscambioWS.Response.ANAGRAFICA_ALLEVAMENTO.Root);
            for (int i = 1; i <= elementi.Count; ++i)
            {
                elementi.MoveNext();
                Allevamento newItem = new Allevamento(SianData, elementi);
                this.Add(newItem);
            }
            /*
            XPathNodeIterator elementi = SianData.Select("./i");
            for (int i = 1; i <= elementi.Count; i = 1 + i)
            {
                elementi.MoveNext();
                Allevamento newItem = new Allevamento(elementi.Current);
                this.Add(newItem);
            }
            */
        }
    }

    /// <summary>
    /// Attributi gestiti di un allevamento
    /// </summary>
    public class Allevamento
    {
        private int StrToInt( string strValue)
        {
            try
            {
               return System.Convert.ToInt32(strValue);
            }
            catch
            {
               return 0;
            }
        }
        private double StrToDouble(string strValue)
        {
            try
            {
                NumberFormatInfo myFormat = new NumberFormatInfo();
                myFormat.CurrencyDecimalSeparator = ".";
                return System.Convert.ToDouble(strValue, myFormat);
            }
            catch
            {
                return 0;
            }
        }

        private int _allevId;
        /// Identificativo dell’allevamento nella BDN (Banca Dati Nazionale?)
        public int allevId
        {
            get { return _allevId; }
            set { _allevId = value; }
        }

        private string _autorizzazioneLatte;
        /// <summary>
        /// Flag indicante se l’allevamento ha o meno l’autorizzazione sanitaria
        /// alla produzione di latte alimentare.
        /// </summary>
        /// <remarks>
        /// Può assumere i seguenti valori: S, N
        /// </remarks>
        public string autorizzazioneLatte
        {
            get { return _autorizzazioneLatte; }
            set { _autorizzazioneLatte = value; }
        }

        private string _aziendaCodice;
        /// Codice aziendale assegnato all’allevamento, 8 caratteri
        public string aziendaCodice
        {
            get { return _aziendaCodice; }
            set { _aziendaCodice = value; }
        }

        private string _cap;
        /// CAP dell’allevamento
        public string cap
        {
            get { return _cap; }
            set { _cap = value; }
        }

        private int _capiTotali;
        /// Numero dei capi presenti nell’allevamento (relativi alla specie indicata) alla data di calcolo indicata
        public int capiTotali
        {
            get { return _capiTotali; }
            set { _capiTotali = value; }
        }

        private string _codFiscaleDeten;
        /// <summary>
        /// Codice fiscale della persona fisica o giuridica che risulta detentore 
        /// degli animali presenti in allevamento (nel caso di allevamento 
        /// in soccida riporta gli estremi del soccidario se il CUAA passato
        /// fa riferimento a questi; se il CUAA fa riferimento alla figura del 
        /// proprietario il campo risulterà vuoto)
        /// </summary>
        public string codFiscaleDeten
        {
            get { return _codFiscaleDeten; }
            set { _codFiscaleDeten = value; }
        }

        private string _codFiscaleProp;
        /// Codice fiscale della persona fisica o giuridica proprietaria dell’allevamento
        public string codFiscaleProp
        {
            get { return _codFiscaleProp; }
            set { _codFiscaleProp = value; }
        }

        private string _comune;
        /// Denominazione del Comune in cui risulta ubicata l’azienda
        public string comune
        {
            get { return _comune; }
            set { _comune = value; }
        }

        private DatetimeNT _dataCalcoloCapi;
        /// Data alla quale è calcolato il numero di capi presenti nell’allevamento
        public DatetimeNT dataCalcoloCapi
        {
            get { return _dataCalcoloCapi; }
            set { _dataCalcoloCapi = value; }
        }

        private string _denomDetentore;
        /// Denominazione della persona fisica o giuridica che risulta detentore degli animali presenti in allevamento (nel caso di allevamento in soccida riporta gli estremi del soccidario se il CUAA passato fa riferimento a questi; se il CUAA fa riferimento alla figura del proprietario il campo risulterà vuoto)
        public string denomDetentore
        {
            get { return _denomDetentore; }
            set { _denomDetentore = value; }
        }

        private string _denomProprietario;
        /// Denominazione della persona fisica o giuridica proprietaria dell’allevamento
        public string denomProprietario
        {
            get { return _denomProprietario; }
            set { _denomProprietario = value; }
        }

        private string _denominazione;
        /// Denominazione dell'allevamento
        public string denominazione
        {
            get { return _denominazione; }
            set { _denominazione = value; }
        }

        private DatetimeNT _dtFineAttivita;
        /// Data di chiusura dell’allevamento
        public DatetimeNT dtFineAttivita
        {
            get { return _dtFineAttivita; }
            set { _dtFineAttivita = value; }
        }

        private DatetimeNT _dtFineDetentore;
        /// Data da cui il detentore non risulta più essere responsabile sui capi presenti in allevamento
        public DatetimeNT dtFineDetentore
        {
            get { return _dtFineDetentore; }
            set { _dtFineDetentore = value; }
        }

        private DatetimeNT _dtInizioAttivita;
        /// Data di apertura dell’allevamento
        public DatetimeNT dtInizioAttivita
        {
            get { return _dtInizioAttivita; }
            set { _dtInizioAttivita = value; }
        }

        private DatetimeNT _dtInizoDetentore;
        /// Data da cui il detentore indicato risulta responsabile sui capi presenti in allevamento (nel caso di allevamenti in soccida ed il CUAA passato fa riferimento al codice fiscale del proprietario il campo risulterà vuoto)
        public DatetimeNT dtInizoDetentore
        {
            get { return _dtInizoDetentore; }
            set { _dtInizoDetentore = value; }
        }

        private string _foglioCatastale;
        /// Codice del foglio catastale in cui è ubicata l’azienda
        public string foglioCatastale
        {
            get { return _foglioCatastale; }
            set { _foglioCatastale = value; }
        }

        private string _indirizzo;
        /// Indirizzo dell’allevamento (sede di ubicazione degli animali)
        public string indirizzo
        {
            get { return _indirizzo; }
            set { _indirizzo = value; }
        }

        private double _latitudine;
        /// Coordinate geografiche – Latitudine
        public double latitudine
        {
            get { return _latitudine; }
            set { _latitudine = value; }
        }

        private string _localita;
        /// Località dell’allevamento
        public string localita
        {
            get { return _localita; }
            set { _localita = value; }
        }

        private double _longitudine;
        /// Coordinate geografiche – Longitudine
        public double longitudine
        {
            get { return _longitudine; }
            set { _longitudine = value; }
        }

        private string _particella;
        /// Codice della particella catastale in cui è ubicata l’azienda
        public string particella
        {
            get { return _particella; }
            set { _particella = value; }
        }

        private string _sezione;
        /// Sezione catastale
        public string sezione
        {
            get { return _sezione; }
            set { _sezione = value; }
        }

        private string _soccida;
        /// <summary>
        /// Flag indicante se l’allevamento è gestito con più contratti di soccida.
        /// </summary>
        /// Può assumere i seguenti valori:
        /// <list type="bullet">
        /// <item>S: l’allevamento è in contratto di soccida</item>
        /// <item>N: l’allevamento non è gestito in contratto di soccida</item>
        /// </list>
        public string soccida
        {
            get { return _soccida; }
            set { _soccida = value; }
        }

        private string _speCodice;
        /// Codice Specie Animale allevata
        public string speCodice
        {
            get { return _speCodice; }
            set { _speCodice = value; }
        }

        private string _subalterno;
        /// Subalterno dell’unità immobiliare come dichiarato nella mappa catastale
        public string subalterno
        {
            get { return _subalterno; }
            set { _subalterno = value; }
        }

        private string _tipoProduzione;
        /// <summary>
        /// Tipologia di produzione dell’allevamento.
        /// </summary>
        /// Può assumere uno dei seguenti valori:
        /// <list type="bullet">
        /// <item>C: produzione carne</item>
        /// <item>L: produzione latte</item>
        /// <item>M: produzione mista</item>
        /// <item>U: produzione non indicata</item>
        /// </list>
        public string tipoProduzione
        {
            get { return _tipoProduzione; }
            set { _tipoProduzione = value; }
        }

        private string _ORIENTAMENTO_PRODUTTIVO;
        public string ORIENTAMENTO_PRODUTTIVO
        {
            get { return _ORIENTAMENTO_PRODUTTIVO; }
            set { _ORIENTAMENTO_PRODUTTIVO = value; }
        }

        /// <summary>
        /// Istanzia la classe leggendone i campi dal SOAP Envelope estratto
        /// dalla risposta del WebService.
        /// </summary>
        /// <param name="SianData">
        /// Soap Envelope estratto dalla risposta SOAP. 
        /// Vedi metodo leggiAllevamenti della classe SIANGateway
        /// </param>
        internal Allevamento(SIANGateway.SianResult SianData, XPathNodeIterator Elemento)
        {
            string AppStr = "";
            AppStr = SianData.getValue(
                      SIANGateway.XPathInterscambioWS.Response.ANAGRAFICA_ALLEVAMENTO.ALLEV_ID,
                      Elemento);

            this.allevId = StrToInt(AppStr);
            this.autorizzazioneLatte = SianData.getValue(
                      SIANGateway.XPathInterscambioWS.Response.ANAGRAFICA_ALLEVAMENTO.AUTORIZZAZIONE_LATTE,
                      Elemento,false);
            this.aziendaCodice = SianData.getValue(
                      SIANGateway.XPathInterscambioWS.Response.ANAGRAFICA_ALLEVAMENTO.AZIENDA_CODICE,
                      Elemento);
            this.cap = SianData.getValue(
                      SIANGateway.XPathInterscambioWS.Response.ANAGRAFICA_ALLEVAMENTO.CAP,
                      Elemento,false);
            AppStr = SianData.getValue(
                      SIANGateway.XPathInterscambioWS.Response.ANAGRAFICA_ALLEVAMENTO.CAPI_TOTALI,
                      Elemento,false);
            this.capiTotali = StrToInt(AppStr);
            this.codFiscaleDeten = SianData.getValue(
                      SIANGateway.XPathInterscambioWS.Response.ANAGRAFICA_ALLEVAMENTO.COD_FISCALE_DETEN,
                      Elemento,false);
            this.codFiscaleProp = SianData.getValue(
                      SIANGateway.XPathInterscambioWS.Response.ANAGRAFICA_ALLEVAMENTO.COD_FISCALE_PROP,
                      Elemento);
            this.comune = SianData.getValue(
                      SIANGateway.XPathInterscambioWS.Response.ANAGRAFICA_ALLEVAMENTO.COMUNE,
                      Elemento);
            AppStr = SianData.getValue(
                      SIANGateway.XPathInterscambioWS.Response.ANAGRAFICA_ALLEVAMENTO.DATA_CALCOLO_CAPI,
                      Elemento,false);
            DataSIAN DTCalcoloCapi = new DataSIAN(AppStr);
            this.dataCalcoloCapi = DTCalcoloCapi.getDatetimeNT();
            this.denomDetentore = SianData.getValue(
                      SIANGateway.XPathInterscambioWS.Response.ANAGRAFICA_ALLEVAMENTO.DENOM_DETENTORE,
                      Elemento,false);
            this.denominazione = SianData.getValue(
                      SIANGateway.XPathInterscambioWS.Response.ANAGRAFICA_ALLEVAMENTO.DENOMINAZIONE,
                      Elemento);
            this.denomProprietario = SianData.getValue(
                      SIANGateway.XPathInterscambioWS.Response.ANAGRAFICA_ALLEVAMENTO.DENOM_PROPRIETARIO,
                      Elemento);
            AppStr = SianData.getValue(
                      SIANGateway.XPathInterscambioWS.Response.ANAGRAFICA_ALLEVAMENTO.DT_FINE_ATTIVITA,
                      Elemento,false);
            DataSIAN DataFineAttivita = new DataSIAN(AppStr);
            this.dtFineAttivita = DataFineAttivita.getDatetimeNT();
            AppStr = SianData.getValue(
                      SIANGateway.XPathInterscambioWS.Response.ANAGRAFICA_ALLEVAMENTO.DT_FINE_DETENTORE,
                      Elemento,false);
            DataSIAN DataFineDetentore = new DataSIAN(AppStr);
            this.dtFineDetentore = DataFineDetentore.getDatetimeNT();
            AppStr = SianData.getValue(
                      SIANGateway.XPathInterscambioWS.Response.ANAGRAFICA_ALLEVAMENTO.DT_INIZIO_ATTIVITA,
                      Elemento);
            DataSIAN DataInizioAttivita = new DataSIAN(AppStr);
            this.dtInizioAttivita = DataInizioAttivita.getDatetimeNT();
            AppStr = SianData.getValue(
                      SIANGateway.XPathInterscambioWS.Response.ANAGRAFICA_ALLEVAMENTO.DT_INIZIO_DETENTORE,
                      Elemento,false);
            DataSIAN DataInizoDetentore = new DataSIAN(AppStr);
            this.dtInizoDetentore = DataInizoDetentore.getDatetimeNT();
            this.foglioCatastale = SianData.getValue(
                      SIANGateway.XPathInterscambioWS.Response.ANAGRAFICA_ALLEVAMENTO.FOGLIO_CATASTALE,
                      Elemento, false);
            this.indirizzo = SianData.getValue(
                      SIANGateway.XPathInterscambioWS.Response.ANAGRAFICA_ALLEVAMENTO.INDIRIZZO,
                      Elemento,false);
            AppStr = SianData.getValue(
                      SIANGateway.XPathInterscambioWS.Response.ANAGRAFICA_ALLEVAMENTO.LATITUDINE,
                      Elemento,false);
            this.latitudine = StrToDouble(AppStr);
            this.localita = SianData.getValue(
                      SIANGateway.XPathInterscambioWS.Response.ANAGRAFICA_ALLEVAMENTO.LOCALITA,
                      Elemento,false);
            AppStr = SianData.getValue(
                      SIANGateway.XPathInterscambioWS.Response.ANAGRAFICA_ALLEVAMENTO.LONGITUDINE,
                      Elemento,false);
            this.longitudine = StrToDouble(AppStr);
            this.particella = SianData.getValue(
                      SIANGateway.XPathInterscambioWS.Response.ANAGRAFICA_ALLEVAMENTO.PARTICELLA,
                      Elemento,false);
            this.sezione = SianData.getValue(
                      SIANGateway.XPathInterscambioWS.Response.ANAGRAFICA_ALLEVAMENTO.SEZIONE,
                      Elemento,false);
            this.soccida = SianData.getValue(
                      SIANGateway.XPathInterscambioWS.Response.ANAGRAFICA_ALLEVAMENTO.SOCCIDA,
                      Elemento,false);
            this.speCodice = SianData.getValue(
                      SIANGateway.XPathInterscambioWS.Response.ANAGRAFICA_ALLEVAMENTO.SPE_CODICE,
                      Elemento);
            this.subalterno = SianData.getValue(
                      SIANGateway.XPathInterscambioWS.Response.ANAGRAFICA_ALLEVAMENTO.SUBALTERNO,
                      Elemento,false);
            this.tipoProduzione = SianData.getValue(
                      SIANGateway.XPathInterscambioWS.Response.ANAGRAFICA_ALLEVAMENTO.TIPO_PRODUZIONE,
                      Elemento);
            this.ORIENTAMENTO_PRODUTTIVO = SianData.getValue(
                      SIANGateway.XPathInterscambioWS.Response.ANAGRAFICA_ALLEVAMENTO.ORIENTAMENTO_PRODUTTIVO,
                      Elemento, false);

            /*
            this.allevId = StrToInt(SianData.SelectSingleNode("allevId").Value);
            this.autorizzazioneLatte = SianData.SelectSingleNode("autorizzazioneLatte").Value;
            this.aziendaCodice = SianData.SelectSingleNode("aziendaCodice").Value;
            this.cap = SianData.SelectSingleNode("cap").Value;
            this.capiTotali = StrToInt( SianData.SelectSingleNode("capiTotali").Value ); 
            this.codFiscaleDeten = SianData.SelectSingleNode("codFiscaleDeten").Value;
            this.codFiscaleProp = SianData.SelectSingleNode("codFiscaleProp").Value;
            this.comune = SianData.SelectSingleNode("comune").Value;
            DataSIAN DTCalcoloCapi = new DataSIAN(SianData.SelectSingleNode("dataCalcoloCapi").Value);
            this.dataCalcoloCapi = DTCalcoloCapi.getDatetimeNT();
            this.denomDetentore = SianData.SelectSingleNode("denomDetentore").Value;
            this.denominazione = SianData.SelectSingleNode("denominazione").Value;
            this.denomProprietario = SianData.SelectSingleNode("denomProprietario").Value;
            DataSIAN DataFineAttivita = new DataSIAN(SianData.SelectSingleNode("dtFineAttivita").Value);
            this.dtFineAttivita = DataFineAttivita.getDatetimeNT();
            DataSIAN DataFineDetentore = new DataSIAN(SianData.SelectSingleNode("dtFineDetentore").Value);
            this.dtFineDetentore = DataFineDetentore.getDatetimeNT();
            DataSIAN DataInizioAttivita = new DataSIAN(SianData.SelectSingleNode("dtInizioAttivita").Value);
            this.dtInizioAttivita = DataInizioAttivita.getDatetimeNT();
            DataSIAN DataInizoDetentore = new DataSIAN(SianData.SelectSingleNode("dtInizoDetentore").Value);
            this.dtInizoDetentore = DataInizoDetentore.getDatetimeNT();
            this.foglioCatastale = SianData.SelectSingleNode("foglioCatastale").Value;
            this.indirizzo = SianData.SelectSingleNode("indirizzo").Value;
            this.latitudine = StrToDouble(SianData.SelectSingleNode("latitudine").Value);
            this.localita = SianData.SelectSingleNode("localita").Value;
            this.longitudine = StrToDouble(SianData.SelectSingleNode("longitudine").Value);
            this.particella = SianData.SelectSingleNode("particella").Value;
            this.sezione = SianData.SelectSingleNode("sezione").Value;
            this.soccida = SianData.SelectSingleNode("soccida").Value;
            this.speCodice = SianData.SelectSingleNode("speCodice").Value;
            this.subalterno = SianData.SelectSingleNode("subalterno").Value;
            this.tipoProduzione = SianData.SelectSingleNode("tipoProduzione").Value;
            */ 
        }

    }
}
