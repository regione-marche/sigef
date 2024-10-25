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
    /// Dettaglio utilizzatori fabbricato
    /// </summary>
    public struct TUtilizzatoreFabbricato
    {
        /// <summary>
        /// codice fiscale del soggetto utilizzatore
        /// </summary>
        public string CUAA;
        /// <summary>
        /// qualifica del soggetto utilizzatore dei locali
        /// </summary>
        /// Può assumere i seguenti valori
        /// <ul>
        /// <li>1 - Proprietario</li>
        /// <li>2 - Affittuario</li>
        /// <li>3 - Conduttore</li>
        /// <li>4 - Familiare convivente del proprietario a carico</li>
        /// <li>5 - Familiare convivente dell'affittuario a carico</li>
        /// <li>6 - Familiare convivente del conduttore a carico</li>
        /// <li>7 - Salariato</li>
        /// <li>8 - Guardiano</li>
        /// <li>9 - Proprietario</li>
        /// <li>10 - Lavoratore saltuario con almeno 100 giornate lavorative</li>
        /// <li>11 - Coadiuvanti iscritti come tali ai fini previdenziali</li>
        /// <li>12 - Altro</li>
        /// </ul>
        public string qualifica;
    }
    public class TUtilizzatoriFabbricati : System.Collections.CollectionBase
    {
        public void Add(TUtilizzatoreFabbricato Destinazione)
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
        public TUtilizzatoreFabbricato Item(int Index)
        {
            return (TUtilizzatoreFabbricato)List[Index];
        }

    }

    public class TFabbricato
    {
        /// <summary>
        /// codice fiscale azienda agricola
        /// </summary>
        public string CUAA;
        /// <summary>
        /// Codice ISTAT provincia ubicazione fabbricato
        /// </summary>
        public string provincia;
        /// <summary>
        /// Codice ISTAT comune ubicazione fabbricato
        /// </summary>
        public string comune;
        /// <summary>
        /// Sezione catastale ubicazione fabbricato
        /// </summary>
        public string sezione;
        /// <summary>
        /// foglio catastale ubicazione fabbricato
        /// </summary>
        public string foglio;
        /// <summary>
        /// particella catastale ubicazione fabbricato
        /// </summary>
        public string particella;
        /// <summary>
        /// subalterno catastale ubicazione fabbricato
        /// </summary>
        public string subalterno;
        /// <summary>
        /// Tipo di fabbricato: vedere tabella di decodifica
        /// </summary>
        public string tipo;
        /// <summary>
        /// Destinazione d'uso dei locali
        /// </summary>
        /// Può assumere uno dei valori:
        /// <ul>
        /// <li>1 - Abitazione</li>
        /// <li>2 - Agriturismo</li>
        /// <li>3 - Ufficio</li>
        /// <li>4 - Locali per vendita</li>
        /// <li>5 - Stalla</li>
        /// <li>6 - Magazzino</li>
        /// <li>7 - Rimessa macchine agricole</li>
        /// <li>8 - Silos</li>
        /// <li>9 - Tettoia</li>
        /// <li>10 - Celle frigorifere</li>
        /// <li>11 - Altro</li>
        /// </ul>
        public string destinazione;
        /// <summary>
        /// Caso particolare che giustifica l'assenza dei riferimenti catastali: vedere tabella di decodifica 
        /// </summary>
        public string CasiParticolari;
        /// <summary>
        /// Superficie coperta in mq
        /// </summary>
        public int SuperficieCoperta;
        /// <summary>
        /// Superficie scoperta in mq
        /// </summary>
        public int SuperficieScoperta;
        /// <summary>
        /// volume coperto in mc
        /// </summary>
        public int Volume;
        /// <summary>
        /// Numero posti
        /// </summary>
        public int NumeroPosti;
        /// <summary>
        /// Tipo di conduzione
        /// </summary>
        /// Può assumere i valori:
        /// <ul>
        /// <li>1 - proprietà o comproprietà</li>
        /// <li>2 - affitto</li>
        /// <li>3 - mezzadria</li>
        /// <li>4 - altro</li>
        /// </ul>
        public string TipoConduzione;
        /// <summary>
        /// Data inizio conduzione
        /// </summary>
        public DatetimeNT DataInizioConduzione;
        /// <summary>
        /// Data termine conduzione
        /// </summary>
        public DatetimeNT DataFineConduzione;
        /// <summary>
        /// Dettagli sugli utilizzatori del fabbricato <seealso cref="TUtilizzatoreFabbricato"/>
        /// </summary>
        public TUtilizzatoriFabbricati usi = new TUtilizzatoriFabbricati();
        /// <summary>
        /// Lista codici fiscali dei proprietari del fabbricato
        /// </summary>
        public TProprietari proprietari = new TProprietari();
    }

    public class TFabbricati : System.Collections.CollectionBase
    {
        public void Add(TFabbricato Destinazione)
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
        public TFabbricato Item(int Index)
        {
            return (TFabbricato)List[Index];
        }

        public TFabbricati(SIANGateway.SianResult SianData)
        {
            string valore;
            XPathNodeIterator Fabbricati = SianData.getIterator(SIANGateway.XPathFascicolo20.ISWSFabbricato.Root);
            for (int i = 1; i <= Fabbricati.Count; ++i)
            {
                Fabbricati.MoveNext();
                TFabbricato newItem = new TFabbricato();

                newItem.CasiParticolari = SianData.getValue(
                        SIANGateway.XPathFascicolo20.ISWSFabbricato.CasiParticolari
                        ,Fabbricati, false
                    );
                newItem.comune = SianData.getValue(
                        SIANGateway.XPathFascicolo20.ISWSFabbricato.comune
                        , Fabbricati, true
                    );
                newItem.CUAA = SianData.getValue(
                        SIANGateway.XPathFascicolo20.ISWSFabbricato.CUAA
                        , Fabbricati, true
                    );

                valore = SianData.getValue(
                        SIANGateway.XPathFascicolo20.ISWSFabbricato.DataFineConduzione
                        , Fabbricati, false
                    );
                newItem.DataFineConduzione = new DataSIAN(valore).getDatetimeNT();

                valore = SianData.getValue(
                        SIANGateway.XPathFascicolo20.ISWSFabbricato.DataInizioConduzione
                        , Fabbricati, false
                    );
                newItem.DataInizioConduzione = new DataSIAN(valore).getDatetimeNT();

                newItem.destinazione = SianData.getValue(
                        SIANGateway.XPathFascicolo20.ISWSFabbricato.destinazione
                        , Fabbricati, true
                    );

                newItem.foglio = SianData.getValue(
                        SIANGateway.XPathFascicolo20.ISWSFabbricato.foglio
                        , Fabbricati, false
                    );

                newItem.particella = SianData.getValue(
                        SIANGateway.XPathFascicolo20.ISWSFabbricato.particella
                        , Fabbricati, false
                    );

                newItem.provincia = SianData.getValue(
                        SIANGateway.XPathFascicolo20.ISWSFabbricato.provincia
                        , Fabbricati, true
                    );

                newItem.sezione = SianData.getValue(
                        SIANGateway.XPathFascicolo20.ISWSFabbricato.sezione
                        , Fabbricati, false
                    );

                newItem.subalterno = SianData.getValue(
                        SIANGateway.XPathFascicolo20.ISWSFabbricato.subalterno
                        , Fabbricati, false
                    );

                newItem.tipo = SianData.getValue(
                        SIANGateway.XPathFascicolo20.ISWSFabbricato.tipo
                        , Fabbricati, false
                    );

                newItem.TipoConduzione = SianData.getValue(
                        SIANGateway.XPathFascicolo20.ISWSFabbricato.TipoConduzione
                        , Fabbricati, false
                    );

                newItem.NumeroPosti = Utils.SianConvert.SianValueToInt(
                        SianData.getValue(
                            SIANGateway.XPathFascicolo20.ISWSFabbricato.NumeroPosti
                            , Fabbricati, false
                        )
                    );
                newItem.SuperficieCoperta = Utils.SianConvert.SianValueToInt(
                        SianData.getValue(
                            SIANGateway.XPathFascicolo20.ISWSFabbricato.SuperficieCoperta
                            , Fabbricati, false
                        )
                    );
                newItem.SuperficieScoperta = Utils.SianConvert.SianValueToInt(
                        SianData.getValue(
                            SIANGateway.XPathFascicolo20.ISWSFabbricato.SuperficieScoperta
                            , Fabbricati, false
                        )
                    );
                newItem.Volume = Utils.SianConvert.SianValueToInt(
                        SianData.getValue(
                            SIANGateway.XPathFascicolo20.ISWSFabbricato.Volume
                            , Fabbricati, false
                        )
                    );

                // recupero gli utilizzatori del fabbricato
                XPathNodeIterator Utilizzatori = SianData.getIterator(
                     SIANGateway.XPathFascicolo20.ISWSFabbricato.ISWSUtilizzoFabbricato.Root
                     , Fabbricati, false
                );
                for (int nUtil = 1; nUtil <= Utilizzatori.Count; ++nUtil)
                {
                    Utilizzatori.MoveNext();
                    TUtilizzatoreFabbricato Utilizzatore = new TUtilizzatoreFabbricato();
                    Utilizzatore.CUAA = SianData.getValue(
                        SIANGateway.XPathFascicolo20.ISWSFabbricato.ISWSUtilizzoFabbricato.CUAA,
                        Utilizzatori
                    );
                    Utilizzatore.qualifica = SianData.getValue(
                        SIANGateway.XPathFascicolo20.ISWSFabbricato.ISWSUtilizzoFabbricato.qualifica,
                        Utilizzatori
                    );
                    newItem.usi.Add(Utilizzatore);
                }

                // recupero i proprietari del fabbricato
                XPathNodeIterator Proprietari = SianData.getIterator(
                     SIANGateway.XPathFascicolo20.ISWSFabbricato.ISWSProprietario.Root
                     , Fabbricati, false
                );
                for (int nProp = 1; nProp <= Proprietari.Count; ++nProp)
                {
                    Proprietari.MoveNext();
                    string proprietario = SianData.getValue(
                        SIANGateway.XPathFascicolo20.ISWSFabbricato.ISWSProprietario.proprietario
                        ,Proprietari
                    );
                    newItem.proprietari.Add(proprietario);
                }

                this.Add(newItem);
            }

        }
    }
}
