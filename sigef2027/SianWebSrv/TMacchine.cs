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
    /// Dettagli macchina
    /// </summary>
    public struct TMacchina
    {
        /// <summary>
        /// codice fiscale azienda agricola
        /// </summary>
        public string CUAA;
        /// <summary>
        /// vedi tabella "tipo macchina agricola"
        /// </summary>
        public string TipoMacchina;
        /// <summary>
        /// Forma di possesso
        /// </summary>
        /// Può assumere i seguenti valori
        /// <ul>
        /// <li>L - Leasing</li>
        /// <li>N - a nolo</li>
        /// <li>P - Proprietario</li>
        /// <li>PU - proprietario utilizzatore</li>
        /// <li>U - utilizzatore</li>
        /// </ul>
        public string FormaPossesso;
        /// <summary>
        /// Targa della macchina
        /// </summary>
        public string Targa;
        /// <summary>
        /// Tipo di targa
        /// </summary>
        /// Può assumere i seguenti valori
        /// <ul>
        /// <li>F - senza targa</li>
        /// <li>S - stradale</li>
        /// <li>R - stradale per rimorchi</li>
        /// <li>T - triangolare</li>
        /// </ul>
        public string TipoTarga;
        /// <summary>
        /// marca della macchina
        /// </summary>
        public string Marca;
        /// <summary>
        /// modello della macchina
        /// </summary>
        public string Modello;
        /// <summary>
        /// codice/numero ditelaio
        /// </summary>
        public string Telaio;
        /// <summary>
        /// Tipo di carburante utilizzato
        /// </summary>
        /// Può assumere i seguenti valori
        /// <ul>
        /// <li>B - benzina</li>
        /// <li>G - gasolio</li>
        /// <li>P - petrolio</li>
        /// <li>N - nessun carburante</li>
        /// </ul>
        public string Carburante;
        /// <summary>
        /// Tipo di trazione
        /// </summary>
        /// Può assumere i seguenti valori
        /// <ul>
        /// <li>C - cingoli</li>
        /// <li>DT - doppia trazione</li>
        /// <li>F - fisso</li>
        /// <li>M - mobile</li>
        /// <li>R - ruote</li>
        /// <li>SC - semicingoli</li>
        /// </ul>
        public string Trazione;
        /// <summary>
        /// data iscrizione al registro macchine agricole
        /// </summary>
        public DatetimeNT DataIscrizione;
        /// <summary>
        /// data cancellazione dal registro macchine agricole
        /// </summary>
        public DatetimeNT DataCessazione;
    }

    public class TMacchine : System.Collections.CollectionBase
    {
        public void Add(TMacchina Destinazione)
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
        public TMacchina Item(int Index)
        {
            return (TMacchina)List[Index];
        }

        public TMacchine(SIANGateway.SianResult SianData)
        {
            string valore;
            XPathNodeIterator Macchine = SianData.getIterator(SIANGateway.XPathFascicolo20.risposta7.Root);
            for (int i = 1; i <= Macchine.Count; ++i)
            {
                Macchine.MoveNext();
                TMacchina newItem = new TMacchina();

                newItem.Carburante = SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta7.Carburante,
                        Macchine, false
                    );

                newItem.CUAA = SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta7.CUAA,
                        Macchine, false
                    );

                valore = SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta7.DataCessazione,
                        Macchine, false
                    );
                newItem.DataCessazione = new DataSIAN(valore).getDatetimeNT();

                valore = SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta7.DataIscrizione,
                        Macchine, false
                    );
                newItem.DataIscrizione = new DataSIAN(valore).getDatetimeNT();

                newItem.FormaPossesso = SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta7.FormaPossesso,
                        Macchine, false
                    );
                newItem.Marca = SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta7.Marca,
                        Macchine, false
                    );
                newItem.Modello = SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta7.Modello,
                        Macchine, false
                    );
                newItem.Targa = SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta7.Targa,
                        Macchine, false
                    );
                newItem.Telaio = SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta7.Telaio,
                        Macchine, false
                    );
                newItem.TipoMacchina = SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta7.TipoMacchina,
                        Macchine, false
                    );
                newItem.TipoTarga = SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta7.TipoTarga,
                        Macchine, false
                    );
                newItem.Trazione = SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta7.Trazione,
                        Macchine, false
                    );

                this.Add(newItem);
            }

        }
    }
}
