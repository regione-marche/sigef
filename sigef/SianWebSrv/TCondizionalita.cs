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
    /// Impegno dell'azienda
    /// </summary>
    public struct TImpegnoCondizionalita
    {
        /// <summary>
        /// codice fiscale azienda agricola
        /// </summary>
        public string CUAA;
        /// <summary>
        /// Codice impegno: vedi tabella "codici condizionalità"
        /// </summary>
        public string CodiceCondizionalita;
    }

    public class TCondizionalita : System.Collections.CollectionBase
    {
        public void Add(TImpegnoCondizionalita Proprietario)
        {
            List.Add(Proprietario);
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
        public TImpegnoCondizionalita Item(int Index)
        {
            return (TImpegnoCondizionalita)List[Index];
        }

        public TCondizionalita(SIANGateway.SianResult SianData)
        {
            XPathNodeIterator ImpegnoCondizionalita = 
                SianData.getIterator(SIANGateway.XPathFascicolo20.ISWSCondizionalita.Root);
            for (int i = 1; i <= ImpegnoCondizionalita.Count; ++i)
            {
                ImpegnoCondizionalita.MoveNext();
                TImpegnoCondizionalita newItem = new TImpegnoCondizionalita();

                newItem.CUAA = SianData.getValue(
                        SIANGateway.XPathFascicolo20.ISWSCondizionalita.CUAA
                        , ImpegnoCondizionalita, false
                    );
                newItem.CodiceCondizionalita = SianData.getValue(
                        SIANGateway.XPathFascicolo20.ISWSCondizionalita.CodiceCondizionalita
                        , ImpegnoCondizionalita, false
                    );

                this.Add(newItem);
            }
        }

    }
}
