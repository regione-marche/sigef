using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using SiarLibrary.NullTypes;
using System.Xml;
using System.Xml.XPath;
using SianWebSrv.Utils;


namespace SianWebSrv
{
    /// <summary>
    /// dettaglio segnalazione
    /// </summary>
    public struct TSegnalazione
    {
        /// <summary>
        /// codice fiscale azienda agricola
        /// </summary>
        public string CUAA ;
        /// <summary>
        /// codice ISTAT provincia terreno oggetto di segnalazione
        /// </summary>
        public string provincia;
        /// <summary>
        /// codice ISTAT comune terreno oggetto di segnalazione
        /// </summary>
        public string comune;
        /// <summary>
        /// sezione catastale terreno oggetto di segnalazione
        /// </summary>
        public string sezione;
        /// <summary>
        /// folgio catastale terreno oggetto di segnalazione
        /// </summary>
        public string foglio;
        /// <summary>
        /// particella catastale terreno oggetto di segnalazione
        /// </summary>
        public string particella;
        /// <summary>
        /// subalterno catastale terreno oggetto di segnalazione
        /// </summary>
        public string subalterno;
        /// <summary>
        /// codice macrouso cui è desinato il terreno oggetto di segnalazione
        /// </summary>
        public string CodiceMacrouso;
        /// <summary>
        /// codice tipo segnalazione: vedi tabella "codici segnalazione"
        /// </summary>
        public string CodiceTipoSegnalazione;
        /// <summary>
        /// codice segnalazione: vedi tabella "codici segnalazione"
        /// </summary>
        public string CodiceSegnalazione;
    }
    public class TSegnalazioni : System.Collections.CollectionBase
    {
        public void Add(TSegnalazione Destinazione)
        {
            List.Add(Destinazione);
        }
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
        public TSegnalazione Item(int Index)
        {
            return (TSegnalazione)List[Index];
        }

        public TSegnalazioni(SIANGateway.SianResult SianData)
        {
            XPathNodeIterator Segnalazioni = SianData.getIterator(
                SIANGateway.XPathFascicolo20.ISWSSegnalazione.Root);
            for (int i = 1; i <= Segnalazioni.Count; ++i)
            {
                Segnalazioni.MoveNext();
                TSegnalazione newItem = new TSegnalazione();

                newItem.CodiceMacrouso = SianData.getValue(
                        SIANGateway.XPathFascicolo20.ISWSSegnalazione.CodiceMacrouso
                        , Segnalazioni, false
                    );
                newItem.CodiceSegnalazione = SianData.getValue(
                        SIANGateway.XPathFascicolo20.ISWSSegnalazione.CodiceSegnalazione
                        , Segnalazioni, false
                    );
                newItem.CodiceTipoSegnalazione = SianData.getValue(
                        SIANGateway.XPathFascicolo20.ISWSSegnalazione.CodiceTipoSegnalazione
                        , Segnalazioni, false
                    );
                newItem.comune = SianData.getValue(
                        SIANGateway.XPathFascicolo20.ISWSSegnalazione.comune
                        , Segnalazioni, false
                    );
                newItem.CUAA = SianData.getValue(
                        SIANGateway.XPathFascicolo20.ISWSSegnalazione.CUAA
                        , Segnalazioni, false
                    );
                newItem.foglio = SianData.getValue(
                        SIANGateway.XPathFascicolo20.ISWSSegnalazione.foglio
                        , Segnalazioni, false
                    );
                newItem.particella = SianData.getValue(
                        SIANGateway.XPathFascicolo20.ISWSSegnalazione.particella
                        , Segnalazioni, false
                    );
                newItem.provincia = SianData.getValue(
                        SIANGateway.XPathFascicolo20.ISWSSegnalazione.provincia
                        , Segnalazioni, false
                    );
                newItem.sezione = SianData.getValue(
                        SIANGateway.XPathFascicolo20.ISWSSegnalazione.sezione
                        , Segnalazioni, false
                    );
                newItem.subalterno = SianData.getValue(
                        SIANGateway.XPathFascicolo20.ISWSSegnalazione.subalterno
                        , Segnalazioni, false
                    );

                this.Add(newItem);
            }
        }

    }
}
