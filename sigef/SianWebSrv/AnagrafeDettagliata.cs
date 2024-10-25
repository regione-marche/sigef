using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using System.Xml;
using System.Xml.XPath;
using SianWebSrv.Utils;
using SiarLibrary.NullTypes;

namespace SianWebSrv
{
    /// <summary>
    /// Lista di codici fiscali collegati al soggetto
    /// </summary>
    public class CollOfCfCollegati : System.Collections.Specialized.StringCollection
    {
        /// <summary>
        /// Istanzia un oggetto CollOfCfCollegati leggendo il contenuto
        /// della risposta SOAP di AGRISIAN
        /// </summary>
        /// <param name="SianData">Contenuto SOAP envelope</param>
        /*
        internal CollOfCfCollegati(XPathNavigator SianData)
        {
            XPathNodeIterator elementi = SianData.Select("./cfCollegati/elements/i");
            for (int i = 1; i <= elementi.Count; i = 1 + i)
            {
                elementi.MoveNext();
                this.Add( elementi.Current.Value );
            }
        }
        */
        internal CollOfCfCollegati(SIANGateway.SianResult SianData)
        {
            XPathNodeIterator Lista = SianData.getIterator(SIANGateway.XPathAT.rispostaDett.cfCollegati.Root);

            for (int i = 1; i <= Lista.Count; ++i)
            {
                Lista.MoveNext();
                this.Add(Lista.Current.Value);
            }

        }
    }

    /// Attributi gestiti dei domicili fiscali variati
    public struct DomicilioFiscale
    {
        /// CAP, 5 caratteri
        public string cap;
        /// Descrizione comune, 45 caratteri
        public string comune;
        /// Data fine validità
        public DatetimeNT dataFine;
        /// indirizzo, 35 caratteri
        public string indirizzo;
        /// sigla provincia, 2 caratteri
        public string provincia;
    }
    /// Lista di indirizzi attributit al soggetto
    public class CollOfDomicilioFiscale : System.Collections.CollectionBase
    {
        /// <summary>
        /// Aggiunge un indirizzo alla collection
        /// </summary>
        /// <param name="aDomicilioFiscale">Indirizzo da aggiungere</param>
        public void Add(DomicilioFiscale aDomicilioFiscale)
        {
            List.Add(aDomicilioFiscale);
        }
        /// <summary>
        /// rimuove un indirizzo dalla lista
        /// </summary>
        /// <param name="index">indice base 0 dell'elemento da rimuovere</param>
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
        /// Restituisce un elemento della lista
        /// </summary>
        /// <param name="Index">Posizione base 0 delle'elemento da recuperare</param>
        public DomicilioFiscale Item(int Index)
        {
            return (DomicilioFiscale)List[Index];
        }
        /*
        internal CollOfDomicilioFiscale(XPathNavigator SianData)
        {
            XPathNodeIterator elementi = SianData.Select("./domiciliFiscaliVariati/elements/i");
            for (int i = 1; i <= elementi.Count; i = 1 + i)
            {
                elementi.MoveNext();
                DomicilioFiscale newItem = new DomicilioFiscale();
                newItem.cap = elementi.Current.SelectSingleNode("capDomicilioFiscale").Value;
                newItem.comune = elementi.Current.SelectSingleNode("comuneDomicilioFiscale").Value;
                DataSIAN dtFine = new DataSIAN(elementi.Current.SelectSingleNode("dataFine").Value);
                newItem.dataFine = dtFine.getDatetimeNT();
                newItem.indirizzo = elementi.Current.SelectSingleNode("indirizzoDomicilioFiscale").Value;
                newItem.provincia = elementi.Current.SelectSingleNode("provinciaDomicilioFiscale").Value;
                this.Add(newItem);
            }
        }*/
        internal CollOfDomicilioFiscale(SIANGateway.SianResult SianData)
        {
            XPathNodeIterator Lista = SianData.getIterator(SIANGateway.XPathAT.rispostaDett.ISATDomicilioFiscaleVariato.Root);

            for (int i = 1; i <= Lista.Count; ++i)
            {
                Lista.MoveNext();
                DomicilioFiscale newItem = new DomicilioFiscale();
                newItem.cap = SianData.getValue(SIANGateway.XPathAT.rispostaDett.ISATDomicilioFiscaleVariato.capDomicilioFiscale
                                                , Lista, false);
                newItem.comune = SianData.getValue(SIANGateway.XPathAT.rispostaDett.ISATDomicilioFiscaleVariato.comuneDomicilioFiscale
                                                , Lista, false);
                newItem.indirizzo = SianData.getValue(SIANGateway.XPathAT.rispostaDett.ISATDomicilioFiscaleVariato.indirizzoDomicilioFiscale
                                                , Lista, false);
                newItem.provincia = SianData.getValue(SIANGateway.XPathAT.rispostaDett.ISATDomicilioFiscaleVariato.provinciaDomicilioFiscale
                                                , Lista, false);
                string DataInXML = SianData.getValue(SIANGateway.XPathAT.rispostaDett.ISATDomicilioFiscaleVariato.dataFine
                                                , Lista, false);
                if (DataInXML != "01/01/1001 - 00:00:00")
                {
                    newItem.dataFine = new DatetimeNT(DataInXML.Substring(0, 10));
                }
                else
                {
                    newItem.dataFine = new DatetimeNT();
                }

                this.Add(newItem);
            }
        }
    }

    /// <summary>
    /// Attributi gestiti delle P. IVA attribuiti al soggetto
    /// </summary>
    public struct PartitaIvaAttribuita
    {
        /// Data fine validità P. IVA
        public DatetimeNT dataFine;
        /// Non documentato da AGRISIAN
        public string decoModFine;
        /// Non documentato da AGRISIAN
        public string decoTipoFine;
        /// Non documentato da AGRISIAN
        public string decoTipoFinePf;
        /// Non documentato da AGRISIAN
        public string decoTipoFinePnf;
        /// Non documentato da AGRISIAN
        public string modelloFine;
        /// Non documentato da AGRISIAN
        public string modelloFineDesc;
        /// P. IVA attribuita al soggetto, 11 caratteri
        public string partitaIva;
        /// Non documentato da AGRISIAN
        public string partitaIvaConfluenza;
        /// Non documentato da AGRISIAN
        public string tipoFine;
        /// Non documentato da AGRISIAN
        public string tipoFineDesc;
    }
    /// <summary>
    /// Lista P. IVA attribuite al soggetto
    /// </summary>
    public class CollOfPartitaIvaAttribuita : System.Collections.CollectionBase
    {
        /// <summary>
        /// Aggiunge un nuovo elemento in coda alla lista
        /// </summary>
        /// <param name="aPartitaIvaAttribuita">Elemento da aggiungere alla lista</param>
        public void Add(PartitaIvaAttribuita aPartitaIvaAttribuita)
        {
            List.Add(aPartitaIvaAttribuita);
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
        /// Recupera un elemento dalla lista
        /// </summary>
        /// <param name="Index">Posizione base 0 dell'elemento da recuperare</param>
        public PartitaIvaAttribuita Item(int Index)
        {
            return (PartitaIvaAttribuita)List[Index];
        }
        /*internal CollOfPartitaIvaAttribuita(XPathNavigator SianData)
        {
            XPathNodeIterator elementi = SianData.Select("./partiteIvaAttribuite/elements/i");
            for (int i = 1; i <= elementi.Count; i = 1 + i)
            {
                elementi.MoveNext();
                PartitaIvaAttribuita newItem = new PartitaIvaAttribuita();
                DataSIAN dtFine = new DataSIAN(elementi.Current.SelectSingleNode("dataFine").Value);
                newItem.dataFine = dtFine.getDatetimeNT();
                newItem.decoModFine = elementi.Current.SelectSingleNode("decoModFine").Value;
                newItem.decoTipoFine = elementi.Current.SelectSingleNode("decoTipoFine").Value;
                newItem.decoTipoFinePf = elementi.Current.SelectSingleNode("decoTipoFinePf").Value;
                newItem.decoTipoFinePnf = elementi.Current.SelectSingleNode("decoTipoFinePnf").Value;
                newItem.modelloFine = elementi.Current.SelectSingleNode("modelloFine").Value;
                newItem.modelloFineDesc = elementi.Current.SelectSingleNode("modelloFineDesc").Value;
                newItem.partitaIva = elementi.Current.SelectSingleNode("partitaIva").Value;
                newItem.partitaIvaConfluenza = elementi.Current.SelectSingleNode("partitaIvaConfluenza").Value;
                newItem.tipoFine = elementi.Current.SelectSingleNode("tipoFine").Value;
                newItem.tipoFineDesc = elementi.Current.SelectSingleNode("tipoFineDesc").Value;
                this.Add(newItem);
            }
        }*/
        internal CollOfPartitaIvaAttribuita(SIANGateway.SianResult SianData)
        {
            XPathNodeIterator Lista = SianData.getIterator(SIANGateway.XPathAT.rispostaDett.ISATPartitaIvaAttribuita.Root);
            string DataInXML;

            for (int i = 1; i <= Lista.Count; ++i)
            {
                Lista.MoveNext();
                PartitaIvaAttribuita newItem = new PartitaIvaAttribuita();
                DataInXML = SianData.getValue(SIANGateway.XPathAT.rispostaDett.ISATPartitaIvaAttribuita.dataFine
                                                , Lista, false);
                if (DataInXML != "01/01/1001 - 00:00:00")
                {
                    newItem.dataFine = new DatetimeNT(DataInXML.Substring(0, 10));
                }
                else
                {
                    newItem.dataFine = new DatetimeNT();
                }
                newItem.decoModFine = SianData.getValue(SIANGateway.XPathAT.rispostaDett.ISATPartitaIvaAttribuita.decoModFine
                                                , Lista, false);
                newItem.decoTipoFine = SianData.getValue(SIANGateway.XPathAT.rispostaDett.ISATPartitaIvaAttribuita.decoTipoFine
                                                , Lista, false);
                newItem.decoTipoFinePf = SianData.getValue(SIANGateway.XPathAT.rispostaDett.ISATPartitaIvaAttribuita.decoTipoFinePf
                                                , Lista, false);
                newItem.decoTipoFinePnf = SianData.getValue(SIANGateway.XPathAT.rispostaDett.ISATPartitaIvaAttribuita.decoTipoFinePnf
                                                , Lista, false);
                newItem.modelloFine = SianData.getValue(SIANGateway.XPathAT.rispostaDett.ISATPartitaIvaAttribuita.modelloFine
                                                , Lista, false);
                newItem.modelloFineDesc = SianData.getValue(SIANGateway.XPathAT.rispostaDett.ISATPartitaIvaAttribuita.modelloFineDesc
                                                , Lista, false);
                newItem.partitaIva = SianData.getValue(SIANGateway.XPathAT.rispostaDett.ISATPartitaIvaAttribuita.partitaIva
                                                , Lista, false);
                newItem.partitaIvaConfluenza = SianData.getValue(SIANGateway.XPathAT.rispostaDett.ISATPartitaIvaAttribuita.partitaIvaConfluenza
                                                , Lista, false);
                newItem.tipoFine = SianData.getValue(SIANGateway.XPathAT.rispostaDett.ISATPartitaIvaAttribuita.tipoFine
                                                , Lista, false);
                newItem.tipoFineDesc = SianData.getValue(SIANGateway.XPathAT.rispostaDett.ISATPartitaIvaAttribuita.tipoFineDesc
                                                , Lista, false);
                this.Add(newItem);
            }
        }
    }

    /// <summary>
    /// Attributi gestiti dei rappresentanti legali del soggetto persona giuridica
    /// </summary>
    public struct RappresentanteSocieta
    {
        /// Codice fiscale rappresentante legale
        public string codiceFiscale;
        /// Data fine carica
        public DatetimeNT dataFine;
        /// Data inizio carica
        public DatetimeNT dataInizio;
        /// Non documentato da AGRISIAN
        public string decoTipoCari;
        /// Non documentato da AGRISIAN
        public string decoTipoCariPf;
        /// Non documentato da AGRISIAN
        public string decoTipoCariPnf;
        /// Non documentato da AGRISIAN e non restituito dal Web Service
        public string tipoFineDesc;
        /// Non documentato da AGRISIAN
        public string tipoCarica;
        /// Non documentato da AGRISIAN
        public string tipoCaricaDesc;
    }
    /// <summary>
    /// Lista rappresentanti legali soggetto persona giuridica
    /// </summary>
    public class CollOfRappresentanteSocieta : System.Collections.CollectionBase
    {
        /// <summary>
        /// Aggiunge un elemento in coda alla lista
        /// </summary>
        /// <param name="aRappresentanteSocieta">Elemento da aggiungere</param>
        public void Add(RappresentanteSocieta aRappresentanteSocieta)
        {
            List.Add(aRappresentanteSocieta);
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
        /// Restituisce un elemento della lista
        /// </summary>
        /// <param name="Index">Posizione base 0 dell'elemento recuperare</param>
        /// <returns></returns>
        public RappresentanteSocieta Item(int Index)
        {
            return (RappresentanteSocieta)List[Index];
        }
        /*internal CollOfRappresentanteSocieta(XPathNavigator SianData)
        {
            XPathNodeIterator elementi = SianData.Select("./rappresentantiSocieta/elements/i");
            for (int i = 1; i <= elementi.Count; i = 1 + i)
            {
                elementi.MoveNext();
                RappresentanteSocieta newItem = new RappresentanteSocieta();
                newItem.codiceFiscale = elementi.Current.SelectSingleNode("codiceFiscale").Value;
                DataSIAN dtFine = new DataSIAN(elementi.Current.SelectSingleNode("dataFine").Value);
                newItem.dataFine = dtFine.getDatetimeNT();
                DataSIAN dtInizio = new DataSIAN(elementi.Current.SelectSingleNode("dataInizio").Value);
                newItem.dataInizio = dtInizio.getDatetimeNT();
                newItem.decoTipoCari = elementi.Current.SelectSingleNode("decoTipoCari").Value;
                newItem.decoTipoCariPf = elementi.Current.SelectSingleNode("decoTipoCariPf").Value;
                newItem.decoTipoCariPnf = elementi.Current.SelectSingleNode("decoTipoCariPnf").Value;
                newItem.tipoCarica = elementi.Current.SelectSingleNode("tipoCarica").Value;
                newItem.tipoCaricaDesc = elementi.Current.SelectSingleNode("tipoCaricaDesc").Value;
                this.Add(newItem);
            }
        }*/
        internal CollOfRappresentanteSocieta(SIANGateway.SianResult SianData)
        {
            XPathNodeIterator Lista = SianData.getIterator(SIANGateway.XPathAT.rispostaDett.ISATRappresentanteSocieta.Root);
            string DataInXML;

            for (int i = 1; i <= Lista.Count; ++i)
            {
                Lista.MoveNext();
                RappresentanteSocieta newItem = new RappresentanteSocieta();
                newItem.codiceFiscale = SianData.getValue(SIANGateway.XPathAT.rispostaDett.ISATRappresentanteSocieta.codiceFiscale
                                                , Lista, false);
                DataInXML = SianData.getValue(SIANGateway.XPathAT.rispostaDett.ISATRappresentanteSocieta.dataFine
                                                , Lista, false);
                if (DataInXML != "31/12/9999 - 00:00:00")
                {
                    newItem.dataFine = new DatetimeNT(DataInXML.Substring(0, 10));
                }
                else
                {
                    newItem.dataFine = new DatetimeNT();
                }
                DataInXML = SianData.getValue(SIANGateway.XPathAT.rispostaDett.ISATRappresentanteSocieta.dataInizio
                                                , Lista, false);
                if (DataInXML != "01/01/1001 - 00:00:00")
                {
                    newItem.dataInizio = new DatetimeNT(DataInXML.Substring(0, 10));
                }
                else
                {
                    newItem.dataInizio = new DatetimeNT();
                }
                newItem.decoTipoCari = SianData.getValue(SIANGateway.XPathAT.rispostaDett.ISATRappresentanteSocieta.decoTipoCari
                                                , Lista, false);
                newItem.decoTipoCariPf = SianData.getValue(SIANGateway.XPathAT.rispostaDett.ISATRappresentanteSocieta.decoTipoCariPf
                                                , Lista, false);
                newItem.decoTipoCariPnf = SianData.getValue(SIANGateway.XPathAT.rispostaDett.ISATRappresentanteSocieta.decoTipoCariPnf
                                                , Lista, false);
                newItem.tipoCarica = SianData.getValue(SIANGateway.XPathAT.rispostaDett.ISATRappresentanteSocieta.tipoCarica
                                                , Lista, false);
                newItem.tipoCaricaDesc = SianData.getValue(SIANGateway.XPathAT.rispostaDett.ISATRappresentanteSocieta.tipoCaricaDesc
                                                , Lista, false);

                this.Add(newItem);
            }
        }
    }

    /// <summary>
    /// Attributi gestiti delle residenze variate del soggetto
    /// </summary>
    public struct ResidenzaVariata
    {
        /// CAP
        public string capResidenza;
        /// Descrizione del comune
        public string comuneResidenza;
        /// Data fine validità residenza
        public DatetimeNT dataFine;
        /// Data inizio validità residenza
        public DatetimeNT dataInizio;
        /// Indirizzo comprensivo di n. civico e toponimo
        public string indirizzoResidenza;
        /// Sigla provincia residenza
        public string provinciaResidenza;
    }
    /// <summary>
    /// Lista residenze variate del soggetto
    /// </summary>
    public class CollOfResidenzaVariata : System.Collections.CollectionBase
    {
        /// <summary>
        /// Aggiunge un elemento in coda alla lista
        /// </summary>
        /// <param name="aResidenzaVariata">Elemento da aggiungere</param>
        public void Add(ResidenzaVariata aResidenzaVariata)
        {
            List.Add(aResidenzaVariata);
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
        public ResidenzaVariata Item(int Index)
        {
            return (ResidenzaVariata)List[Index];
        }
        /*internal CollOfResidenzaVariata(XPathNavigator SianData)
        {
            XPathNodeIterator elementi = SianData.Select("./residenzeVariate/elements/i");
            for (int i = 1; i <= elementi.Count; i = 1 + i)
            {
                elementi.MoveNext();
                ResidenzaVariata newItem = new ResidenzaVariata();
                newItem.capResidenza = elementi.Current.SelectSingleNode("capResidenza").Value;
                newItem.comuneResidenza = elementi.Current.SelectSingleNode("comuneResidenza").Value;
                DataSIAN dtFine = new DataSIAN(elementi.Current.SelectSingleNode("dataFine").Value);
                newItem.dataFine = dtFine.getDatetimeNT();
                DataSIAN dtInizio = new DataSIAN(elementi.Current.SelectSingleNode("dataInizio").Value);
                newItem.dataInizio = dtInizio.getDatetimeNT();
                newItem.indirizzoResidenza = elementi.Current.SelectSingleNode("indirizzoResidenza").Value;
                newItem.provinciaResidenza = elementi.Current.SelectSingleNode("provinciaResidenza").Value;
                this.Add(newItem);
            }
        }*/
        internal CollOfResidenzaVariata(SIANGateway.SianResult SianData)
        {
            XPathNodeIterator Lista = SianData.getIterator(SIANGateway.XPathAT.rispostaDett.ISATResidenzaVariata.Root);
            string DataInXML;

            for (int i = 1; i <= Lista.Count; ++i)
            {
                Lista.MoveNext();
                ResidenzaVariata newItem = new ResidenzaVariata();
                newItem.capResidenza = SianData.getValue(SIANGateway.XPathAT.rispostaDett.ISATResidenzaVariata.capResidenza
                                                , Lista, false);
                newItem.comuneResidenza = SianData.getValue(SIANGateway.XPathAT.rispostaDett.ISATResidenzaVariata.comuneResidenza
                                                , Lista, false);

                DataInXML = SianData.getValue(SIANGateway.XPathAT.rispostaDett.ISATResidenzaVariata.dataFine
                                                , Lista, false);
                if (DataInXML != "01/01/1001 - 00:00:00")
                {
                    newItem.dataFine = new DatetimeNT(DataInXML.Substring(0, 10));
                }
                else
                {
                    newItem.dataFine = new DatetimeNT();
                }
                DataInXML = SianData.getValue(SIANGateway.XPathAT.rispostaDett.ISATResidenzaVariata.dataInizio
                                                , Lista, false);
                if (DataInXML != "01/01/1001 - 00:00:00")
                {
                    newItem.dataInizio = new DatetimeNT(DataInXML.Substring(0, 10));
                }
                else
                {
                    newItem.dataInizio = new DatetimeNT();
                }
                newItem.indirizzoResidenza = SianData.getValue(SIANGateway.XPathAT.rispostaDett.ISATResidenzaVariata.indirizzoResidenza
                                                , Lista, false);
                newItem.provinciaResidenza = SianData.getValue(SIANGateway.XPathAT.rispostaDett.ISATResidenzaVariata.provinciaResidenza
                                                , Lista, false);

                this.Add(newItem);
            }
        }
    }

    /// <summary>
    /// Attributi gestiti di altre aziende rappresentate dal soggetto
    /// </summary>
    public struct SocietaRappresentata
    {
        /// Codice fiscale altro soggetto rappresentato
        public string codiceFiscaleRappresentato;
        /// Data fine validità rappresentanza
        public DatetimeNT dataFine;
        /// Data inizio validità rappresentanza
        public DatetimeNT dataInizio;
        /// Non documentato da AGRISIAN
        public string decoTipoRapp;
        /// Non documentato da AGRISIAN
        public string tipoRappresentanza;
        /// Non documentato da AGRISIAN
        public string tipoRappresentanzaDesc;
    }
    /// <summary>
    /// Lista aziende rappresentate dal soggetto
    /// </summary>
    public class CollOfSocietaRappresentata : System.Collections.CollectionBase
    {
        /// <summary>
        /// Aggiunge un elemento in coda alla lista
        /// </summary>
        /// <param name="aSocietaRappresentata">Elemento d aggiungere</param>
        public void Add(SocietaRappresentata aSocietaRappresentata)
        {
            List.Add(aSocietaRappresentata);
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
        /// <param name="Index">Posizione base  dell'elemento da recuperare</param>
        public SocietaRappresentata Item(int Index)
        {
            return (SocietaRappresentata)List[Index];
        }
        /*internal CollOfSocietaRappresentata(XPathNavigator SianData)
        {
            XPathNodeIterator elementi = SianData.Select("./societaRappresentate/elements/i");
            for (int i = 1; i <= elementi.Count; i = 1 + i)
            {
                elementi.MoveNext();
                SocietaRappresentata newItem = new SocietaRappresentata();
                newItem.codiceFiscaleRappresentato = elementi.Current.SelectSingleNode("codiceFiscaleRappresentato").Value;
                DataSIAN dtFine = new DataSIAN(elementi.Current.SelectSingleNode("dataFine").Value);
                newItem.dataFine = dtFine.getDatetimeNT();
                DataSIAN dtInizio = new DataSIAN(elementi.Current.SelectSingleNode("dataInizio").Value);
                newItem.dataInizio = dtInizio.getDatetimeNT();
                newItem.decoTipoRapp = elementi.Current.SelectSingleNode("decoTipoRapp").Value;
                newItem.tipoRappresentanza = elementi.Current.SelectSingleNode("tipoRappresentanza").Value;
                newItem.tipoRappresentanzaDesc = elementi.Current.SelectSingleNode("tipoRappresentanzaDesc").Value;
                this.Add(newItem);
            }
        }*/
        internal CollOfSocietaRappresentata(SIANGateway.SianResult SianData)
        {
            XPathNodeIterator Lista = SianData.getIterator(SIANGateway.XPathAT.rispostaDett.ISATSocietaRappresentata.Root);
            string DataInXML;

            for (int i = 1; i <= Lista.Count; ++i)
            {
                Lista.MoveNext();
                SocietaRappresentata newItem = new SocietaRappresentata();
                newItem.codiceFiscaleRappresentato = SianData.getValue(SIANGateway.XPathAT.rispostaDett.ISATSocietaRappresentata.codiceFiscaleRappresentato
                                                , Lista, false);
                newItem.decoTipoRapp = SianData.getValue(SIANGateway.XPathAT.rispostaDett.ISATSocietaRappresentata.decoTipoRapp
                                                , Lista, false);
                newItem.tipoRappresentanza = SianData.getValue(SIANGateway.XPathAT.rispostaDett.ISATSocietaRappresentata.tipoRappresentanza
                                                , Lista, false);
                newItem.tipoRappresentanzaDesc = SianData.getValue(SIANGateway.XPathAT.rispostaDett.ISATSocietaRappresentata.tipoRappresentanzaDesc
                                                , Lista, false);

                DataInXML = SianData.getValue(SIANGateway.XPathAT.rispostaDett.ISATSocietaRappresentata.dataFine
                                                , Lista, false);
                if (DataInXML != "01/01/1001 - 00:00:00")
                {
                    newItem.dataFine = new DatetimeNT(DataInXML.Substring(0, 10));
                }
                else
                {
                    newItem.dataFine = new DatetimeNT();
                }
                DataInXML = SianData.getValue(SIANGateway.XPathAT.rispostaDett.ISATSocietaRappresentata.dataInizio
                                                , Lista, false);
                if (DataInXML != "01/01/1001 - 00:00:00")
                {
                    newItem.dataInizio = new DatetimeNT(DataInXML.Substring(0, 10));
                }
                else
                {
                    newItem.dataInizio = new DatetimeNT();
                }

                this.Add(newItem);
            }
        }
    }

    /// <summary>
    /// Classe su cui viene mappato l'oggetto ISATDett esposto dal
    /// web service AnagrafeAT. Contiene tutti i dati anagrafici
    /// identificativi di un'azienda per il ministero delle finanze.
    /// </summary>
    public class AnagrafeDettagliata : AnagrafeSintetica
    {
        private StringCollection _CfCollegati;
        /// Lista codici fiscali collegati al soggetto
        public StringCollection CfCollegati
        {
            get { return _CfCollegati; }
            set { _CfCollegati = value; }
        }

        private string _codiceFiscaleRappresentante;
        /// Codice fiscale del rappresentante legale del soggetto, presente se soggetto persona giuridica
        public string codiceFiscaleRappresentante
        {
            get { return _codiceFiscaleRappresentante; }
            set { _codiceFiscaleRappresentante = value; }
        }

        private string _cognomeRappresentante;
        /// Cognome del rappresentante legale del soggetto, presente se soggetto persona giuridica
        public string cognomeRappresentante
        {
            get { return _cognomeRappresentante; }
            set { _cognomeRappresentante = value; }
        }

        private DatetimeNT _dataInizioAttivita;
        /// Data inizio attività, se 01/01/1001 probabilmente il dato non è valido
        public DatetimeNT dataInizioAttivita
        {
            get { return _dataInizioAttivita; }
            set { _dataInizioAttivita = value; }
        }

        private string _denominazioneRappresentante;
        /// Ragione sociale  del rappresentante legale del soggetto,presente se il soggetto è persona giuridica e lo è anche il suo rappresentante
        public string denominazioneRappresentante
        {
            get { return _denominazioneRappresentante; }
            set { _denominazioneRappresentante = value; }
        }

        private CollOfDomicilioFiscale _domiciliFiscaliVariati;
        /// Lista dei domicili fiscali variati del soggetto
        public CollOfDomicilioFiscale domiciliFiscaliVariati
        {
            get { return _domiciliFiscaliVariati; }
            set { _domiciliFiscaliVariati = value; }
        }

        private string _nomeRappresentante;
        /// Nome rappresentante legale del soggetto, presente se il soggetto è persona giuridica
        public string nomeRappresentante
        {
            get { return _nomeRappresentante; }
            set { _nomeRappresentante = value; }
        }

        private CollOfPartitaIvaAttribuita _partiteIvaAttribuite;
        /// Lista delle P. IVA attribuite al soggetto
        public CollOfPartitaIvaAttribuita partiteIvaAttribuite
        {
            get { return _partiteIvaAttribuite; }
            set { _partiteIvaAttribuite = value; }
        }

        private CollOfRappresentanteSocieta _rappresentantiSocieta;
        /// Lista dei rappresentanti legali avuti dal soggetto, se persona giuridica
        public CollOfRappresentanteSocieta rappresentantiSocieta
        {
            get { return _rappresentantiSocieta; }
            set { _rappresentantiSocieta = value; }
        }

        private CollOfResidenzaVariata _residenzeVariate;
        /// Lista delle residenze del soggetto
        public CollOfResidenzaVariata residenzeVariate
        {
            get { return _residenzeVariate; }
            set { _residenzeVariate = value; }
        }

        private CollOfSocietaRappresentata _societaRappresentate;
        /// Lista delle società rappresentate dal soggetto
        public CollOfSocietaRappresentata societaRappresentate
        {
            get { return _societaRappresentate; }
            set { _societaRappresentate = value; }
        }

        private string _statoAttivita;
        /// Non documentato da AGRISIAN
        public string statoAttivita
        {
            get { return _statoAttivita; }
            set { _statoAttivita = value; }
        }

        private string _statoAttvitaDesc;
        /// Non documentato da AGRISIAN
        public string statoAttvitaDesc
        {
            get { return _statoAttvitaDesc; }
            set { _statoAttvitaDesc = value; }
        }

        private string _tipoAttivita;
        /// Non documentato da AGRISIAN
        public string tipoAttivita
        {
            get { return _tipoAttivita; }
            set { _tipoAttivita = value; }
        }

        private string _tipoCarica;
        /// Non documentato da AGRISIAN
        public string tipoCarica
        {
            get { return _tipoCarica; }
            set { _tipoCarica = value; }
        }

        private string _tipoCaricaDesc;
        /// Non documentato da AGRISIAN
        public string tipoCaricaDesc
        {
            get { return _tipoCaricaDesc; }
            set { _tipoCaricaDesc = value; }
        }

        /// <summary>
        /// Istanzia la classe leggendone i campi dal SOAP Envelope estratto
        /// dalla risposta del WebService
        /// </summary>
        /// <param name="SianData">
        /// Soap Envelope estratto dalla risposta SOAP.
        /// Vedi metodo getAnagraficaDettagliata della classe SianGateway
        /// </param>
        /* 
        internal new void LoadFromSianData(XPathNavigator SianData)
        {
            base.LoadFromSianData(SianData);
            DataSIAN dataInizio = new DataSIAN(SianData.SelectSingleNode("dataInizioAttivita").Value);
            DateTime milleuno = new DateTime(1001, 1, 1);
            if (dataInizio.getDateTime.CompareTo(milleuno) != 0)
            {
                this.dataInizioAttivita = dataInizio.getDatetimeNT();
            }else {
                this.dataInizioAttivita = new DatetimeNT();
            }
            this.denominazioneRappresentante = SianData.SelectSingleNode("denominazioneRappresentante").Value;
            this.nomeRappresentante = SianData.SelectSingleNode("nomeRappresentante").Value;
            this.cognomeRappresentante = SianData.SelectSingleNode("cognomeRappresentante").Value;
            this.codiceFiscaleRappresentante = SianData.SelectSingleNode("codiceFiscaleRappresentante").Value;
            this.statoAttivita = SianData.SelectSingleNode("statoAttivita").Value;
            this.statoAttvitaDesc = SianData.SelectSingleNode("statoAttvitaDesc").Value;
            this.tipoAttivita = SianData.SelectSingleNode("tipoAttivita").Value;
            this.tipoCarica = SianData.SelectSingleNode("tipoCarica").Value;
            this.tipoCaricaDesc = SianData.SelectSingleNode("tipoCaricaDesc").Value;
            this.CfCollegati = new CollOfCfCollegati(SianData);
            this.domiciliFiscaliVariati = new CollOfDomicilioFiscale(SianData);
            this.partiteIvaAttribuite = new CollOfPartitaIvaAttribuita(SianData);
            this.rappresentantiSocieta = new CollOfRappresentanteSocieta(SianData);
            this.residenzeVariate = new CollOfResidenzaVariata(SianData);
            this.societaRappresentate = new CollOfSocietaRappresentata(SianData);
        }*/

        internal void LoadFromDatiSian(SIANGateway.SianResult DatiSian)
        {
            DatiSian.RootXPath = SIANGateway.XPathAT.RootDett +
                                 SIANGateway.XPathAT.rispostaDett.Root;

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

            DataInXML = DatiSian.getValue(SIANGateway.XPathAT.rispostaDett.dataInizioAttivita, false);
            if (DataInXML != "01/01/1001 - 00:00:00")
            {
                try
                {
                    dataInizioAttivita = new DatetimeNT(DataInXML.Substring(0, 10));
                }
                catch (Exception e)
                {
                    // non hanno rispettato il wsdl o hanno iserito la data in cinese
                    dataInizioAttivita = new DatetimeNT();
                }
            }
            else
            {
                dataInizioAttivita = new DatetimeNT();
            }

            denominazioneRappresentante = DatiSian.getValue(SIANGateway.XPathAT.rispostaDett.denominazioneRappresentante, false);
            nomeRappresentante = DatiSian.getValue(SIANGateway.XPathAT.rispostaDett.nomeRappresentante, false);
            cognomeRappresentante = DatiSian.getValue(SIANGateway.XPathAT.rispostaDett.cognomeRappresentante, false);
            codiceFiscaleRappresentante = DatiSian.getValue(SIANGateway.XPathAT.rispostaDett.codiceFiscaleRappresentante, false);
            statoAttivita = DatiSian.getValue(SIANGateway.XPathAT.rispostaDett.statoAttivita, false);
            statoAttvitaDesc = DatiSian.getValue(SIANGateway.XPathAT.rispostaDett.statoAttvitaDesc, false);
            tipoAttivita = DatiSian.getValue(SIANGateway.XPathAT.rispostaDett.tipoAttivita, false);
            tipoCarica = DatiSian.getValue(SIANGateway.XPathAT.rispostaDett.tipoCarica, false);
            tipoCaricaDesc = DatiSian.getValue(SIANGateway.XPathAT.rispostaDett.tipoCaricaDesc, false);

            CfCollegati = new CollOfCfCollegati(DatiSian);
            domiciliFiscaliVariati = new CollOfDomicilioFiscale(DatiSian);
            partiteIvaAttribuite = new CollOfPartitaIvaAttribuita(DatiSian);
            rappresentantiSocieta = new CollOfRappresentanteSocieta(DatiSian);
            residenzeVariate = new CollOfResidenzaVariata(DatiSian);
            societaRappresentate = new CollOfSocietaRappresentata(DatiSian);
        }
    }
}
