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
    /// Dettaglio coltura 
    /// </summary>
    public struct TDettaglioColtura
    {
        /// Codice prodotto, sempre presente
        public string codiceProdotto;
        /// Codice varietà, non obbligatorio
        public string codiceVarieta;
        /// Superficie in mq destinata allo specifico macrouso
        public int superficieUtilizzata;
    }

    /// Lista di destinazioni
    public class TDettagliColture : System.Collections.CollectionBase
    {
        public void Add(TDettaglioColtura Destinazione)
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
        public TDettaglioColtura Item(int Index)
        {
            return (TDettaglioColtura)List[Index];
        }
    }

    /// <summary>
    /// Dettaglio particella coltivata
    /// </summary>
    public class TColturaImpiantata
    {
        /// <summary>
        /// codice fiscale azienda agricola
        /// </summary>
        public string CUAA;
        /// <summary>
        /// codice ISTAT provincia ubicazione terreno
        /// </summary>
        public string Provincia;
        /// <summary>
        /// codice ISTAT comune ubicazione terreno
        /// </summary>
        public string Comune;
        /// <summary>
        /// sezione catastale terreno
        /// </summary>
        public string Sezione;
        /// <summary>
        /// foglio catastale terreno
        /// </summary>
        public string Foglio;
        /// <summary>
        /// particella catastale terreno
        /// </summary>
        public string Particella;
        /// <summary>
        /// sublaterno catastale terreno
        /// </summary>
        public string Subalterno;
        /// <summary>
        /// Codice tipo conduzione
        /// </summary>
        /// Può assumere i seguenti valori:
        /// <ul>
        /// <li>1 - proprietà o comproprietà</li>
        /// <li>2 - affitto</li>
        /// <li>3 - mezzadria</li>
        /// <li>4 - altro</li>
        /// </ul>
        public string CodiceTipoConduzione;
        /// <summary>
        /// lista colture impiantate
        /// </summary>
        public TDettagliColture Destinazioni = new TDettagliColture();
    }

    public class TPianoColturale : System.Collections.CollectionBase
    {
        public void Add(TColturaImpiantata Destinazione)
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
        public TColturaImpiantata Item(int Index)
        {
            return (TColturaImpiantata)List[Index];
        }

        public TPianoColturale(SIANGateway.SianResult SianData)
        {
            XPathNodeIterator ColturaImpiantata =
                SianData.getIterator(SIANGateway.XPathFascicolo20.risposta9.Root);
            for (int i = 1; i <= ColturaImpiantata.Count; i = 1 + i)
            {
                ColturaImpiantata.MoveNext();
                TColturaImpiantata newItem = new TColturaImpiantata();

                // recupero le i dettagli della coltura impianatata sulla particella
                XPathNodeIterator DettaglioColturaXml = SianData.getIterator(
                     SIANGateway.XPathFascicolo20.risposta9.Destinazione.Root,
                     ColturaImpiantata, false
                );
                for (int nDett = 1; nDett <= DettaglioColturaXml.Count; ++nDett)
                {
                    DettaglioColturaXml.MoveNext();
                    TDettaglioColtura DettaglioColtura = new TDettaglioColtura();
                    DettaglioColtura.codiceProdotto = SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta9.Destinazione.codiceProdotto,
                        DettaglioColturaXml
                    );
                    DettaglioColtura.codiceVarieta = SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta9.Destinazione.codiceVarieta,
                        DettaglioColturaXml
                    );
                    DettaglioColtura.superficieUtilizzata = Utils.SianConvert.SianValueToInt( SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta9.Destinazione.superficieUtilizzata,
                        DettaglioColturaXml)
                    );
                    newItem.Destinazioni.Add(DettaglioColtura);
                }

                newItem.CodiceTipoConduzione = SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta9.CodiceTipoConduzione,
                        ColturaImpiantata, true
                        );

                newItem.Comune = SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta9.Comune,
                        ColturaImpiantata, true
                        );

                newItem.CUAA = SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta9.CUAA,
                        ColturaImpiantata, true
                        );

                newItem.Foglio = SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta9.Foglio,
                        ColturaImpiantata, false
                        );

                newItem.Particella = SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta9.Particella,
                        ColturaImpiantata, false
                        );

                newItem.Provincia = SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta9.Provincia,
                        ColturaImpiantata, true
                        );

                newItem.Sezione = SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta9.Sezione,
                        ColturaImpiantata, false
                        );

                newItem.Subalterno = SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta9.Subalterno,
                        ColturaImpiantata, false
                        );

                this.Add(newItem);

            }

        }
    }
}
