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
    /// Dati dettaglio per classe di manodopera
    /// </summary>
    public struct TClasseManodopera
    {
        /// <summary>
        /// codice fiscale azienda agricola
        /// </summary>
        public string CUAA;
        /// <summary>
        /// Tipologia di lavoro prevalente
        /// </summary>
        /// Può assumere uno dei valori:
        /// <ul>
        /// <li>0 - solo manodopera familiare</li>
        /// <li>1 - manodopera familiare prevalente</li>
        /// <li>2 - manodopera extrafamiliare prevalente</li>
        /// <li>3 - conduzione non diretta con salariati</li>
        /// <li>4 - conduzione non diretta con altra forma</li>
        /// </ul>
        public string TipoLavoroPrevalente;
        /// <summary>
        /// Tipologia di collaborazione
        /// </summary>
        /// Può assumere uno dei valori:
        /// <ul>
        /// <li>0 - Non specificato</li>
        /// <li>1 - Familiari</li>
        /// <li>2 - Salariati</li>
        /// <li>3 - Altri collaboratori</li>
        /// </ul>
        public string TipoCollaborazione;
        /// <summary>
        /// Tipologia di lavoratori
        /// </summary>
        /// Può assumere uno dei valori:
        /// <ul>
        /// <li>0 - Non specificato</li>
        /// <li>1 - Uomini</li>
        /// <li>2 - Donne</li>
        /// <li>3 - Giovani</li>
        /// <li>4 - Avventizi</li>
        /// </ul>
        public string TipoLavoratori;
        /// <summary>
        /// Unità di misura
        /// </summary>
        /// Può assumere uno dei valori:
        /// <ul>
        /// <li>0 - Non specificato</li>
        /// <li>1 - tempo pieno</li>
        /// <li>2 - tempo parziale</li>
        /// <li>3 - giornate annue</li>
        /// <li>4 - uso esclusivo</li>
        /// <li>5 - uso prevalente</li>
        /// <li>6 - uso non diretto</li>
        /// </ul>
        public string UnitaMisura;
        /// Quantita
        public string Quantita;
    }

    public class TClassiManodopera : System.Collections.CollectionBase
    {
        public void Add(TClasseManodopera Proprietario)
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
        public TClasseManodopera Item(int Index)
        {
            return (TClasseManodopera)List[Index];
        }

        public TClassiManodopera(SIANGateway.SianResult SianData)
        {
            XPathNodeIterator ClasseManodopera = 
                SianData.getIterator(SIANGateway.XPathFascicolo20.ISWSLavoro.Root);
            for (int i = 1; i <= ClasseManodopera.Count; ++i)
            {
                ClasseManodopera.MoveNext();
                TClasseManodopera newItem = new TClasseManodopera();

                newItem.CUAA = SianData.getValue(
                        SIANGateway.XPathFascicolo20.ISWSLavoro.CUAA
                        , ClasseManodopera, false
                    );
                newItem.Quantita = SianData.getValue(
                        SIANGateway.XPathFascicolo20.ISWSLavoro.Quantita
                        , ClasseManodopera, false
                    );
                newItem.TipoCollaborazione = SianData.getValue(
                        SIANGateway.XPathFascicolo20.ISWSLavoro.TipoCollaborazione
                        , ClasseManodopera, false
                    );
                newItem.TipoLavoratori = SianData.getValue(
                        SIANGateway.XPathFascicolo20.ISWSLavoro.TipoLavoratori
                        , ClasseManodopera, false
                    );
                newItem.TipoLavoroPrevalente = SianData.getValue(
                        SIANGateway.XPathFascicolo20.ISWSLavoro.TipoLavoroPrevalente
                        , ClasseManodopera, false
                    );
                newItem.UnitaMisura = SianData.getValue(
                        SIANGateway.XPathFascicolo20.ISWSLavoro.UnitaMisura
                        , ClasseManodopera, false
                    );

                this.Add(newItem);
            }

        }
    }
}
