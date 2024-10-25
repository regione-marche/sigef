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
    /// Classe su cui viene mappato l'oggetto ISWSQuotelatte esposto dal
    /// web service ISWSAgeaToOpr.trovaFascicolo
    /// Contiene la lista delle assegnazioni di quote latte dell'azienda
    /// </summary>
    public class CollOfQuoteLatte : System.Collections.CollectionBase
    {
        /// <summary>
        /// Aggiunge un elemento alla lista
        /// </summary>
        /// <param name="aQuoteLatte">Elemento da aggiungere in coda alla lista</param>
        public void Add(QuoteLatte aQuoteLatte)
        {
            List.Add(aQuoteLatte);
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
        public QuoteLatte Item(int Index)
        {
            return (QuoteLatte)List[Index];
        }
        internal CollOfQuoteLatte(XPathNavigator SianData)
        {
            XPathNodeIterator elementi = SianData.Select("./i");
            for (int i = 1; i <= elementi.Count; i = 1 + i)
            {
                elementi.MoveNext();
                QuoteLatte newItem = new QuoteLatte(elementi.Current);
                this.Add(newItem);
            }
        }
    }

    /// <summary>
    /// Attributi gestiti per l'assegnazione quote latte
    /// </summary>
    public class QuoteLatte
    {
        private int StrToInt(string strValue)
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

        private string _CauseForzaMaggiore;
        /// Impostato a "S" in presenza di cause di forza maggiore riconosciute ai fini del regime quote latte
        public string CauseForzaMaggiore
        {
            get { return _CauseForzaMaggiore; }
            set { _CauseForzaMaggiore = value; }
        }

        private int _QuotaConsegneDis;
        /// Quantitativo disponibile a fine campagna per le consegne alle latterie
        public int QuotaConsegneDis
        {
            get { return _QuotaConsegneDis; }
            set { _QuotaConsegneDis = value; }
        }

        private int _QuotaConsegneRif;
        /// Quantitativo di riferimento ad inizio campagna per le consegne alle latterie
        public int QuotaConsegneRif
        {
            get { return _QuotaConsegneRif; }
            set { _QuotaConsegneRif = value; }
        }

        private int _QuotaVenditeDiretteDis;
        /// Quantitativo disponibile a fine campagna per le consegne alle latterie
        public int QuotaVenditeDiretteDis
        {
            get { return _QuotaVenditeDiretteDis; }
            set { _QuotaVenditeDiretteDis = value; }
        }

        private int _QuotaVenditeDiretteRif;
        /// Quantitativo di riferimento ad inizio campagna per le vendite dirette
        public int QuotaVenditeDiretteRif
        {
            get { return _QuotaVenditeDiretteRif; }
            set { _QuotaVenditeDiretteRif = value; }
        }

        private double _TenoreGrassoDis;
        /// Tenore rappresentativo di materia grassa espresso in percentuale (fine campagna)
        public double TenoreGrassoDis
        {
            get { return _TenoreGrassoDis; }
            set { _TenoreGrassoDis = value; }
        }

        private double _TenoreGrassoRif;
        /// Tenore rappresentativo di materia grassa espresso in percentuale (inizio campagna)
        public double TenoreGrassoRif
        {
            get { return _TenoreGrassoRif; }
            set { _TenoreGrassoRif = value; }
        }

        private int _campagnaLattiera;
        /// indica l’anno di inizio della campagna lattiera
        public int campagnaLattiera
        {
            get { return _campagnaLattiera; }
            set { _campagnaLattiera = value; }
        }

        private string _cuaa;
        /// Codice fiscale azienda agricola
        public string cuaa
        {
            get { return _cuaa; }
            set { _cuaa = value; }
        }

        private string _ute;
        /// Codice ISTAT del comune (codice provincia più codice comune)
        public string ute
        {
            get { return _ute; }
            set { _ute = value; }
        }

        /// <summary>
        /// Istanzia la classe leggendone i campi dal SOAP Envelope estratto
        /// dalla risposta del WebService
        /// </summary>
        /// <param name="SianData">
        /// Soap Envelope estratto dalla risposta SOAP.
        /// Vedi metodo quoteLatte della classe SIANGateway
        /// </param>
        internal QuoteLatte(XPathNavigator SianData)
        {

            this.campagnaLattiera = StrToInt(SianData.SelectSingleNode("campagnaLattiera").Value);
            this.CauseForzaMaggiore = SianData.SelectSingleNode("CauseForzaMaggiore").Value;
            this.cuaa = SianData.SelectSingleNode("cuaa").Value;
            this.QuotaConsegneDis = StrToInt(SianData.SelectSingleNode("QuotaConsegneDis").Value);
            this.QuotaConsegneRif = StrToInt(SianData.SelectSingleNode("QuotaConsegneRif").Value);
            this.QuotaVenditeDiretteDis = StrToInt(SianData.SelectSingleNode("QuotaVenditeDiretteDis").Value);
            this.QuotaVenditeDiretteRif = StrToInt(SianData.SelectSingleNode("QuotaVenditeDiretteRif").Value);
            this.TenoreGrassoDis = StrToDouble(SianData.SelectSingleNode("TenoreGrassoDis").Value);
            this.TenoreGrassoRif = StrToDouble(SianData.SelectSingleNode("TenoreGrassoRif").Value);
            this.ute = SianData.SelectSingleNode("ute").Value;
        }

    }

}
