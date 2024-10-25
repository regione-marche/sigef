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
    /// Classe su cui viene mappato l'oggetto ISWSTerritorio esposto dal
    /// web service ISWSAgeaToOpr.trovaFascicolo
    /// Contiene la lista dei principali allevamenti dell'azienda
    /// </summary>
    public class CollOfProprietario : System.Collections.CollectionBase
    {
        /// <summary>
        /// Aggiunge un elemento alla lista
        /// </summary>
        /// Elemento da aggiungere in coda alla lista
        public void Add(string Proprietario)
        {
            List.Add(Proprietario);
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
        public string Item(int Index)
        {
            return (string)List[Index];
        }
        internal CollOfProprietario(SIANGateway.SianResult DatiSian, XPathNodeIterator Proprietari, bool TipoRisposta2)
        {
            string xPath;
            if (TipoRisposta2)
            {
                xPath = SIANGateway.XPathFascicolo20.risposta2TP.Proprietari.Proprietario;
            }else{
                xPath = SIANGateway.XPathFascicolo20.risposta2.ISWSTerritorio.Proprietari.Proprietario;
            }
            for (int i = 0; i < Proprietari.Count; ++i)
            {
                Proprietari.MoveNext();
                string valore = DatiSian.getValue(xPath, Proprietari, false);
                this.Add(valore);
            }
        }
    }

    /// <summary>
    /// Attributi gestiti dell'utilizzo terreni (coltivazione)
    /// </summary>
    public struct destinazione
    {
        /// Codice prodotto codifica prodotti AGEA (ex PAC)
        public string codiceProdotto;
        /// Codice varietà codifica prodotti AGEA (ex PAC)
        public string codiceVarieta;
        /// Superfiicie destinata alla coltura [mq]
        public int superficieUtilizzata;
    }

    /// <summary>
    /// Lista degli utilizzi cui è destinato un terreno
    /// </summary>
    public class CollOfdestinazione : System.Collections.CollectionBase
    {
        /// <summary>
        /// Aggiunge un elemento alla lista
        /// </summary>
        /// <param name="aDestinazione">Elemento da aggiungere in coda alla lista</param>
        public void Add(destinazione aDestinazione)
        {
            List.Add(aDestinazione);
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
        public destinazione Item(int Index)
        {
            return (destinazione)List[Index];
        }
        internal CollOfdestinazione(SIANGateway.SianResult DatiSian, XPathNodeIterator DestinazioneXml, bool TipoRisposta2)
        {
            XPathNodeIterator Utilizzi;
                DestinazioneXml.MoveNext();
                string xPath;
                if (TipoRisposta2)
                {
                    Utilizzi = DestinazioneXml;
                }
                else
                {
                    xPath = SIANGateway.XPathFascicolo20.risposta2.ISWSTerritorio.Destinazione.ISWSUtilizzoTerra.Root;
                    Utilizzi = DatiSian.getIterator(xPath, DestinazioneXml, true);
                }
                
                for (int j = 0; j < Utilizzi.Count; ++j)
                {
                    destinazione newItem = new destinazione();
                    Utilizzi.MoveNext();
                    string xPathCodiceProdotto, xPathCodiceVarieta, xPathSuperficieUtilizzata;
                    if (TipoRisposta2)
                    {
                        xPathCodiceProdotto = SIANGateway.XPathFascicolo20.risposta2TP.Destinazione.codiceProdotto;
                        xPathCodiceVarieta = SIANGateway.XPathFascicolo20.risposta2TP.Destinazione.codiceVarieta;
                        xPathSuperficieUtilizzata = SIANGateway.XPathFascicolo20.risposta2TP.Destinazione.superficieUtilizzata;
                    }
                    else
                    {
                        xPathCodiceProdotto = SIANGateway.XPathFascicolo20.risposta2.ISWSTerritorio.Destinazione.ISWSUtilizzoTerra.codiceProdotto;
                        xPathCodiceVarieta = SIANGateway.XPathFascicolo20.risposta2.ISWSTerritorio.Destinazione.ISWSUtilizzoTerra.codiceVarieta;
                        xPathSuperficieUtilizzata = SIANGateway.XPathFascicolo20.risposta2.ISWSTerritorio.Destinazione.ISWSUtilizzoTerra.superficieUtilizzata;
                    }
                    //xPath = SIANGateway.XPathFascicolo20.risposta2.ISWSTerritorio.Destinazione.ISWSUtilizzoTerra.codiceProdotto;
                    newItem.codiceProdotto = DatiSian.getValue(xPathCodiceProdotto, Utilizzi, true);
                    //xPath = SIANGateway.XPathFascicolo20.risposta2.ISWSTerritorio.Destinazione.ISWSUtilizzoTerra.codiceVarieta;
                    newItem.codiceVarieta = DatiSian.getValue(xPathCodiceVarieta, Utilizzi, true);
                    //xPath = SIANGateway.XPathFascicolo20.risposta2.ISWSTerritorio.Destinazione.ISWSUtilizzoTerra.superficieUtilizzata;
                    string strSup = DatiSian.getValue(xPathSuperficieUtilizzata, Utilizzi, true);
                    try
                    {
                        newItem.superficieUtilizzata = System.Convert.ToInt32(strSup);
                    }
                    catch
                    {
                        newItem.superficieUtilizzata = 0;
                    }
                    this.Add(newItem);
              
            }
            /*
            XPathNodeIterator elementi = SianData.Select("./i");
            for (int i = 1; i <= elementi.Count; i = 1 + i)
            {
                elementi.MoveNext();
                destinazione newItem = new destinazione();
                newItem.codiceProdotto = elementi.Current.SelectSingleNode("codiceProdotto").Value;
                newItem.codiceVarieta = elementi.Current.SelectSingleNode("codiceVarieta").Value;
                string strSup = elementi.Current.SelectSingleNode("superficieUtilizzata").Value;
                try
                {
                    newItem.superficieUtilizzata = System.Convert.ToInt32(strSup);
                }catch{
                    newItem.superficieUtilizzata = 0;
                }
                this.Add(newItem);
            }
            */ 
        }
    }

    /// <summary>
    /// Attributi gestiti dei terreni di cui dispone l'azienda
    /// </summary>
    public class Territorio
    {
        private DatetimeNT _DataFineConduzione;
        /// Date di fine disponibilità terreno da parte dell'azienda
        public DatetimeNT DataFineConduzione
        {
            get { return _DataFineConduzione; }
            set { _DataFineConduzione = value; }
        }

        private DatetimeNT _DataInizioConduzione;
        /// Date di inizio disponibilità terreno da parte dell'azienda
        public DatetimeNT DataInizioConduzione
        {
            get { return _DataInizioConduzione; }
            set { _DataInizioConduzione = value; }
        }

        private string _Sezione;
        /// Sezione catastale, non supera mia un carattere
        public string Sezione
        {
            get { return _Sezione; }
            set { _Sezione = value; }
        }

        private string _Foglio;
        /// Foglio catastale, è un numero intero
        public string Foglio
        {
            get { return _Foglio; }
            set { _Foglio = value; }
        }

        private string _Particella;
        /// Particella catastale, è un numero intero
        public string Particella
        {
            get { return _Particella; }
            set { _Particella = value; }
        }

        private string _Subalterno;
        /// Subalterno catastale, è al massimo di un carettere
        public string Subalterno
        {
            get { return _Subalterno; }
            set { _Subalterno = value; }
        }

        private int _SuperficieCatastale;
        /// Superficie catastale [mq]
        public int SuperficieCatastale
        {
            get { return _SuperficieCatastale; }
            set { _SuperficieCatastale = value; }
        }

        private int _SuperficieCondotta;
        /// Superficie in uso presso l'azienda, [mq]
        public int SuperficieCondotta
        {
            get { return _SuperficieCondotta; }
            set { _SuperficieCondotta = value; }
        }

        private string _codiceTipoConduzione;
        /// Durata della disponibilità del terreno.
        /// Può assumere i seguenti valori:
        /// <list><item>P: Proprietà</item>
        /// <item>T: Temporanea</item>
        /// </list>
        public string codiceTipoConduzione
        {
            get { return _codiceTipoConduzione; }
            set { _codiceTipoConduzione = value; }
        }

        private string _CUAA;
        /// Codice fiscale azienda agricola
        public string CUAA
        {
            get { return _CUAA; }
            set { _CUAA = value; }
        }

        private string _Comune;
        /// Primi 3 caratteri codice ISTAT comune terreno
        public string Comune
        {
            get { return _Comune; }
            set { _Comune = value; }
        }

        private string _Provincia;
        /// Primi 3 caratteri codice ISTAT provincia terreno
        public string Provincia
        {
            get { return _Provincia; }
            set { _Provincia = value; }
        }

        public CollOfProprietario _Proprietario;
        /// Lista dei proprietari del terreno
        public CollOfProprietario Proprietario
        {
            get { return _Proprietario; }
            set { _Proprietario = value; }
        }

        public CollOfdestinazione _destinazione;
        /// Lista delle colture impiantate sul terreno
        public CollOfdestinazione destinazione
        {
            get { return _destinazione; }
            set { _destinazione = value; }
        }

        public Territorio(SIANGateway.SianResult SianData, XPathNodeIterator Terreno, bool TipoRisposta2)
        {
            string xPath;
            xPath = SIANGateway.XPathFascicolo20.risposta2.ISWSTerritorio.Sezione;
            this.Sezione = SianData.getValue(xPath, Terreno, false);
            xPath = SIANGateway.XPathFascicolo20.risposta2.ISWSTerritorio.Foglio;
            this.Foglio = SianData.getValue(xPath, Terreno);
            xPath = SIANGateway.XPathFascicolo20.risposta2.ISWSTerritorio.Particella;
            this.Particella = SianData.getValue(xPath, Terreno);
            xPath = SIANGateway.XPathFascicolo20.risposta2.ISWSTerritorio.Subalterno;
            this.Subalterno = SianData.getValue(xPath, Terreno, false);
            xPath = SIANGateway.XPathFascicolo20.risposta2.ISWSTerritorio.codiceTipoConduzione;
            this.codiceTipoConduzione = SianData.getValue(xPath, Terreno);

            xPath = SIANGateway.XPathFascicolo20.risposta2.ISWSTerritorio.DataFineConduzione;
            this.DataFineConduzione = new DataSIAN(SianData.getValue(xPath, Terreno)).getDatetimeNT();

            xPath = SIANGateway.XPathFascicolo20.risposta2.ISWSTerritorio.DataInizioConduzione;
            this.DataInizioConduzione = new DataSIAN(SianData.getValue(xPath, Terreno)).getDatetimeNT();

            xPath = SIANGateway.XPathFascicolo20.risposta2.ISWSTerritorio.SuperficieCatastale;
            try
            {
                this.SuperficieCatastale = System.Convert.ToInt32(SianData.getValue(xPath, Terreno));
            }
            catch
            {
                this.SuperficieCatastale = 0;
            }
            xPath = SIANGateway.XPathFascicolo20.risposta2.ISWSTerritorio.SuperficieCondotta;
            try
            {
                this.SuperficieCondotta = System.Convert.ToInt32(SianData.getValue(xPath, Terreno));
            }
            catch
            {
                this.SuperficieCondotta = 0;
            }
            xPath = SIANGateway.XPathFascicolo20.risposta2.ISWSTerritorio.CUAA;
            this.CUAA = SianData.getValue(xPath, Terreno);
            xPath = SIANGateway.XPathFascicolo20.risposta2.ISWSTerritorio.Comune;
            this.Comune = SianData.getValue(xPath, Terreno);
            xPath = SIANGateway.XPathFascicolo20.risposta2.ISWSTerritorio.Provincia;
            this.Provincia = SianData.getValue(xPath, Terreno);

            if (TipoRisposta2)
            {
                xPath = SIANGateway.XPathFascicolo20.risposta2TP.Proprietari.Root;
            }
            else
            {
                xPath = SIANGateway.XPathFascicolo20.risposta2.ISWSTerritorio.Proprietari.Root;
            }
            XPathNodeIterator Proprietari = SianData.getIterator(xPath, Terreno, false);
            this.Proprietario = new CollOfProprietario(SianData, Proprietari, TipoRisposta2);

            if (TipoRisposta2)
            {
                xPath = SIANGateway.XPathFascicolo20.risposta2TP.Destinazione.Root;
            }
            else
            {
                xPath = SIANGateway.XPathFascicolo20.risposta2.ISWSTerritorio.Destinazione.Root;
            }
            XPathNodeIterator Destinazioni = SianData.getIterator(xPath, Terreno, false);
            this.destinazione = new CollOfdestinazione(SianData, Destinazioni, TipoRisposta2);

        }
    }

    /// <summary>
    /// Classe su cui viene mappato l'oggetto ISWSTerritorio esposto dal
    /// web service ISWSAgeaToOpr.trovaFascicolo
    /// Contiene la lista dei terreni dell'azienda
    /// </summary>
    public class CollOfTerritorio : System.Collections.CollectionBase
    {
        /// <summary>
        /// Aggiunge un elemento alla lista
        /// </summary>
        /// Elemento da aggiungere in coda alla lista
        public void Add(Territorio aTerritorio)
        {
            List.Add(aTerritorio);
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
        public Territorio Item(int Index)
        {
            return (Territorio)List[Index];
        }
        /// <summary>
        /// Istanzia la classe leggendone i campi dal SOAP Envelope estratto
        /// dalla risposta del WebService
        /// </summary>
        /// <param name="SianData">
        /// Soap Envelope estratto dalla risposta SOAP.
        /// Vedi metodo leggiTerritorio della classe SIANGateway
        /// </param>
        internal CollOfTerritorio(SIANGateway.SianResult SianData)
        {
            SianData.RootXPath = SIANGateway.XPathFascicolo20.Root +
                                  SIANGateway.XPathFascicolo20.risposta2.Root;

            XPathNodeIterator Terreni = SianData.getIterator(SIANGateway.XPathFascicolo20.risposta2.ISWSTerritorio.Root);
            for (int i = 1; i <= Terreni.Count; i = 1 + i)
            {
                Terreni.MoveNext();
                Territorio newItem = new Territorio(SianData, Terreni, false);
                this.Add(newItem);
            }
        }

    }


}
