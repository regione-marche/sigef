using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.XPath;

namespace SianWebSrv.PSR
{
    public class Domanda
    {
        public struct Intervento
        {
            public string codiTipoMisu;
            public string codiAzio;
            public string codiSubbAzio;
            public string codiInte;
            public int supUtilizzata;
            public int supPremio;
        }
        public class CollOfInterventi : System.Collections.CollectionBase
        {
            /// <summary>
            /// Aggiunge un elemento alla lista
            /// </summary>
            /// <param name="aDestinazione">Elemento da aggiungere in coda alla lista</param>
            public void Add(Intervento aIntervento)
            {
                List.Add(aIntervento);
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
            public Intervento Item(int Index)
            {
                return (Intervento)List[Index];
            }
        }

        public struct Superficie
        {
            public string provinciaISTAT;
            public string comuneISTAT;
            public string sezione;
            public string foglio;
            public string particella;
            public string subalterno;
            public string prodotto;
            public string varieta;
            public string codiFascAltiDich;
            public string decoTipoAreC;
            public string decoTipoAreD;
            public bool flagColtBiol;
            public bool flagPasc;
            public int AnnoCampagna;
            public CollOfInterventi ListaInterventi;
        }
        public class CollOfSuperfici : System.Collections.CollectionBase
        {
            /// <summary>
            /// Aggiunge un elemento alla lista
            /// </summary>
            /// <param name="aDestinazione">Elemento da aggiungere in coda alla lista</param>
            public void Add(Superficie aSuperficie)
            {
                List.Add(aSuperficie);
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
            public Superficie Item(int Index)
            {
                return (Superficie)List[Index];
            }
        }

        public struct Allevamento
        {
            public string codiTipoZootecnia;
            public int numeCapi;
            public int numeCapiFemmine;
        }
        public class CollOfAllevamenti : System.Collections.CollectionBase
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
        }

        public struct TAnagrafica
        {
            public string CUAA;
            public Utils.TipiCodFisc TipoCodFisc;
            public Utils.TipiDomanda TipoDoma;
            public int annoCampagna;
            public string idDomaOP;
            public string idDomaSostituita;
            public string codiRegi;
            public string codiEnte;
            public string codiRi;
            public string codiRea;
            public string codiAsl;
            public string codiFiscRLeg;
            public string descrizione;
            public string provinciaISTAT;
            public string comuneISTAT;
            public string indirizzo;
            public string CAP;
            public string codiceStatoEstero;
        }

        public struct TFormaGiuridica
        {
            public Utils.TipiFormaGiuridica TipoFormaGiuridica;
            public int NAziende;
            public int NSociDipendenti;
            public int NGiovani;
            public int NDonne;
            public string DescrAltraForma;
        }

        public struct TAttivitaConnesse
        {
            public bool Agriturismo;
            public bool AttivRicreative;
            public bool Artigianato;
            public bool ContoTerzismo;
            public bool Trasformazione;
            public bool EnergiaRinnov;
            public bool Altro;
        }

        public struct TDettagliMisura
        {
            public string codiTipoMisu;
            public int ProgressivoAnnoImpegno;
            public int AnnoInizio;
            public string CodDomaIniziale;
            public string CodDomaAnnoPrima;
            public bool DomaIniz;
            public bool SostImpe;
            public bool TrasImpe;
            public bool CambioMisu;
            public bool AggiAnnu;
            public bool CambBene;
            public bool AmplImpe;
            public CollOfImpegni Impegni;
            public CollOfCustomField CustomFields;
        }

        public struct TImpegno
        {
            public string codiTipoMisu;
            public string codiAzio;
            public string descAzio;
            public int supeAzio;
            public int quantitaUBA;
            public SiarLibrary.NullTypes.DatetimeNT DTInizioImpe;
            public SiarLibrary.NullTypes.DatetimeNT DTFineImpe;
            public SiarLibrary.NullTypes.DatetimeNT DTInizioImpeUBA;
            public SiarLibrary.NullTypes.DatetimeNT DTFineImpeUBA;
        }
        public class CollOfImpegni : System.Collections.CollectionBase
        {
            /// <summary>
            /// Aggiunge un elemento alla lista
            /// </summary>
            /// <param name="aImpegno">Elemento da aggiungere in coda alla lista</param>
            public void Add(TImpegno aImpegno)
            {
                List.Add(aImpegno);
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
            public TImpegno Item(int Index)
            {
                return (TImpegno)List[Index];
            }
        }

        public struct TCustomField
        {
            public string name;
            public string value;
        }
        public class CollOfCustomField : System.Collections.CollectionBase
        {
            /// <summary>
            /// Aggiunge un elemento alla lista
            /// </summary>
            /// <param name="aCustomField">Elemento da aggiungere in coda alla lista</param>
            public void Add(TCustomField aCustomField)
            {
                List.Add(aCustomField);
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
            public TCustomField Item(int Index)
            {
                return (TCustomField)List[Index];
            }
        }

        public TAnagrafica Anagrafica;
        public CollOfSuperfici Superfici;
        public TAttivitaConnesse AttivitaConnesse;
        public TFormaGiuridica FormaGiuridica;
        public CollOfAllevamenti Allevamenti;
        public Utils.TipiFormeConduzione FormaConduzione;
        public TDettagliMisura DettagliMisura;
        public CollOfCustomField CampiPersonalizzati;

        internal Domanda(SIANGateway.SianResult DatiSian)
        {
            # region Decodifica sezione anagrafica
            Anagrafica = new TAnagrafica();
            XPathNodeIterator AnagraficaIterator = DatiSian.getIterator(SIANGateway.XpathPSR.ISWSAnagraficaASR.Root);
            if (AnagraficaIterator.Count == 0 )
            {
                throw new System.Exception("La risposta SIAN non contiene la sezione ISWSAnagraficaASR");
            }
            if (AnagraficaIterator.Count > 1)
            {
                throw new System.Exception("La risposta SIAN contiene più di una sezione ISWSAnagraficaASR");
            }
            AnagraficaIterator.MoveNext();

            XPathNodeIterator CuaTypeIterator = DatiSian.getIterator(SIANGateway.XpathPSR.ISWSAnagraficaASR.CUAAType.Root, AnagraficaIterator, true);
            CuaTypeIterator.MoveNext();
            XPathNodeIterator CuaTypeChilds = CuaTypeIterator.Current.SelectDescendants(XPathNodeType.Element, false);
            if (CuaTypeChilds.Count != 1)
            {
                throw new Exception("Impossibile recuperare il CUAA dai dati scaricati dal SIAN.");
            }
            else
            {
                CuaTypeChilds.MoveNext();
                switch (CuaTypeChilds.Current.LocalName)
                {
                    case SIANGateway.XpathPSR.ISWSAnagraficaASR.CUAAType.PersonaFisicaTagName:
                        this.Anagrafica.TipoCodFisc = Utils.TipiCodFisc.PersonaFisica;
                        break;
                    case SIANGateway.XpathPSR.ISWSAnagraficaASR.CUAAType.PersonaGiuridicaTagName:
                        this.Anagrafica.TipoCodFisc = Utils.TipiCodFisc.PersonaGiuridica;
                        break;
                    default:
                        throw new Exception("Valore CUAA nei dati SIAN incongruente.");
                }
                this.Anagrafica.CUAA = CuaTypeChilds.Current.Value;
            }

            string strAnno = DatiSian.getValue(SIANGateway.XpathPSR.ISWSAnagraficaASR.AnnoCampagna, AnagraficaIterator);
            this.Anagrafica.annoCampagna = Utils.SianConvert.SianValueToInt(strAnno, Utils.ActionOnInvalidValue.acThrow);
            this.Anagrafica.codiEnte = DatiSian.getValue(SIANGateway.XpathPSR.ISWSAnagraficaASR.CodiEnte, AnagraficaIterator, false);
            this.Anagrafica.codiRegi = DatiSian.getValue(SIANGateway.XpathPSR.ISWSAnagraficaASR.CodiRegi, AnagraficaIterator, false);
            this.Anagrafica.codiRi = DatiSian.getValue(SIANGateway.XpathPSR.ISWSAnagraficaASR.CodiRi, AnagraficaIterator, false);
            this.Anagrafica.codiRea = DatiSian.getValue(SIANGateway.XpathPSR.ISWSAnagraficaASR.codiRea, AnagraficaIterator, false);
            this.Anagrafica.codiAsl = DatiSian.getValue(SIANGateway.XpathPSR.ISWSAnagraficaASR.codiAsl, AnagraficaIterator, false);
            this.Anagrafica.descrizione = DatiSian.getValue(SIANGateway.XpathPSR.ISWSAnagraficaASR.Descrizione, AnagraficaIterator, false);
            this.Anagrafica.idDomaOP = DatiSian.getValue(SIANGateway.XpathPSR.ISWSAnagraficaASR.IdDomaOP, AnagraficaIterator);
            this.Anagrafica.codiFiscRLeg = DatiSian.getValue(SIANGateway.XpathPSR.ISWSAnagraficaASR.codiFiscRLeg, AnagraficaIterator,false);
            this.Anagrafica.idDomaSostituita = DatiSian.getValue(SIANGateway.XpathPSR.ISWSAnagraficaASR.IdDomaSostituita, AnagraficaIterator, false);
            string StrTipoDoma = DatiSian.getValue(SIANGateway.XpathPSR.ISWSAnagraficaASR.TipoDoma, AnagraficaIterator);
            this.Anagrafica.TipoDoma = Utils.SianConvert.SianValueToTipiDomanda(StrTipoDoma, Utils.ActionOnInvalidValue.acNullValue);

            XPathNodeIterator IndirizzoIterator = DatiSian.getIterator(SIANGateway.XpathPSR.ISWSAnagraficaASR.ISWSIndirizzoASR.Root, AnagraficaIterator,true);
            IndirizzoIterator.MoveNext();

            this.Anagrafica.provinciaISTAT = DatiSian.getValue(SIANGateway.XpathPSR.ISWSAnagraficaASR.ISWSIndirizzoASR.Provincia, IndirizzoIterator);
            this.Anagrafica.comuneISTAT = DatiSian.getValue(SIANGateway.XpathPSR.ISWSAnagraficaASR.ISWSIndirizzoASR.Comune, IndirizzoIterator);
            this.Anagrafica.CAP = DatiSian.getValue(SIANGateway.XpathPSR.ISWSAnagraficaASR.ISWSIndirizzoASR.CAP, IndirizzoIterator);
            this.Anagrafica.indirizzo = DatiSian.getValue(SIANGateway.XpathPSR.ISWSAnagraficaASR.ISWSIndirizzoASR.Indirizzo, IndirizzoIterator);
            this.Anagrafica.codiceStatoEstero = DatiSian.getValue(SIANGateway.XpathPSR.ISWSAnagraficaASR.ISWSIndirizzoASR.CodiceStatoEstero, IndirizzoIterator);
            #endregion

            #region decodifica impegni misura

            #region controlli correttezza dati misura
            DettagliMisura = new TDettagliMisura();
            XPathNodeIterator DettagliIterator;
            Utils.TipiDomanda TipoDomanda = SianWebSrv.Utils.TipiDomanda.NonIndicata;
            DettagliIterator = DatiSian.getIterator(SIANGateway.XpathPSR.AdesioneMisura.Compensativa.Root);
            if (DettagliIterator.Count == 1)
            {
                // è una misura indennità compensativa
                TipoDomanda = SianWebSrv.Utils.TipiDomanda.IndennitaCompensativa;
            }
            if (DettagliIterator.Count > 1)
            {
                throw new System.Exception("La risposta SIAN contiene più di una sezione ISWSAdesioneMisuraCompensativaASR");
            }
            if (DettagliIterator.Count == 0)
            {
                DettagliIterator = DatiSian.getIterator(SIANGateway.XpathPSR.AdesioneMisura.Agroambientali.Root);
                if (DettagliIterator.Count == 0)
                {
                    throw new System.Exception("La risposta SIAN non contiene né una sezione ISWSAdesioneMisuraAgroASR né una sezione ISWSAdesioneMisuraAgroASR");
                }
                if (DettagliIterator.Count > 1)
                {
                    throw new System.Exception("La risposta SIAN contiene più di una sezione ISWSAdesioneMisuraAgroASR");
                }
                if (DettagliIterator.Count == 1)
                {
                    // è una misura agroambientale
                    TipoDomanda = SianWebSrv.Utils.TipiDomanda.MisureAgroambientali;
                }
            }
            #endregion

            this.Anagrafica.TipoDoma = TipoDomanda;

            DettagliIterator.MoveNext();

            #region flagVari
            string flagAnno;
            flagAnno = DatiSian.getValue(SIANGateway.XpathPSR.AdesioneMisura.flagAnnoImp1, DettagliIterator, false);
            if (Utils.SianConvert.SianValueToBool(flagAnno, SianWebSrv.Utils.ActionOnInvalidValue.acNullValue))
            {
                this.DettagliMisura.ProgressivoAnnoImpegno = 1;
            }
            flagAnno = DatiSian.getValue(SIANGateway.XpathPSR.AdesioneMisura.flagAnnoImp2, DettagliIterator, false);
            if (Utils.SianConvert.SianValueToBool(flagAnno, SianWebSrv.Utils.ActionOnInvalidValue.acNullValue))
            {
                this.DettagliMisura.ProgressivoAnnoImpegno = 2;
            }
            flagAnno = DatiSian.getValue(SIANGateway.XpathPSR.AdesioneMisura.flagAnnoImp3, DettagliIterator, false);
            if (Utils.SianConvert.SianValueToBool(flagAnno, SianWebSrv.Utils.ActionOnInvalidValue.acNullValue))
            {
                this.DettagliMisura.ProgressivoAnnoImpegno = 3;
            }
            flagAnno = DatiSian.getValue(SIANGateway.XpathPSR.AdesioneMisura.flagAnnoImp4, DettagliIterator, false);
            if (Utils.SianConvert.SianValueToBool(flagAnno, SianWebSrv.Utils.ActionOnInvalidValue.acNullValue))
            {
                this.DettagliMisura.ProgressivoAnnoImpegno = 4;
            }
            flagAnno = DatiSian.getValue(SIANGateway.XpathPSR.AdesioneMisura.flagAnnoImp5, DettagliIterator, false);
            if (Utils.SianConvert.SianValueToBool(flagAnno, SianWebSrv.Utils.ActionOnInvalidValue.acNullValue))
            {
                this.DettagliMisura.ProgressivoAnnoImpegno = 5;
            }
            string Oltre5Anni = DatiSian.getValue(SIANGateway.XpathPSR.AdesioneMisura.numeAnnoImpeInco, DettagliIterator, false);
            int Oltre5Annii = Utils.SianConvert.SianValueToInt(Oltre5Anni, SianWebSrv.Utils.ActionOnInvalidValue.acNullValue);
            if ((Oltre5Annii > 5) && (Oltre5Annii <= 20))
            {
                this.DettagliMisura.ProgressivoAnnoImpegno = Oltre5Annii;
            }
            #endregion

            string AnnoIniziale = DatiSian.getValue(SIANGateway.XpathPSR.AdesioneMisura.numeAnnoDomaIniz, DettagliIterator, true);
            this.DettagliMisura.AnnoInizio = Utils.SianConvert.SianValueToInt(AnnoIniziale);

            this.DettagliMisura.CodDomaIniziale = DatiSian.getValue(SIANGateway.XpathPSR.AdesioneMisura.numeDomaAnnoIniz, DettagliIterator, false);
            this.DettagliMisura.CodDomaAnnoPrima = DatiSian.getValue(SIANGateway.XpathPSR.AdesioneMisura.numeDomaAnnoPrec, DettagliIterator, false);

            this.DettagliMisura.codiTipoMisu = DatiSian.getValue(SIANGateway.XpathPSR.AdesioneMisura.codiTipoMisu, DettagliIterator, false);

            this.DettagliMisura.Impegni = new CollOfImpegni();

            #region Ipegno misura E
            if (TipoDomanda == SianWebSrv.Utils.TipiDomanda.IndennitaCompensativa)
            {
                TImpegno impegno;
                impegno = new TImpegno();
                impegno.codiTipoMisu = "E";
                impegno.codiAzio = "";
                impegno.descAzio = "";
                impegno.supeAzio = 0;
                impegno.quantitaUBA = 0;

                string dtStr;
                dtStr = DatiSian.getValue(SIANGateway.XpathPSR.AdesioneMisura.Compensativa.dataInizImp, DettagliIterator, false);
                Utils.DataSIAN DTini = new SianWebSrv.Utils.DataSIAN(dtStr);
                dtStr = DatiSian.getValue(SIANGateway.XpathPSR.AdesioneMisura.Compensativa.dataFineImpe, DettagliIterator, false);
                Utils.DataSIAN DTfine = new SianWebSrv.Utils.DataSIAN(dtStr);

                impegno.DTInizioImpe = DTini.getDatetimeNT();
                impegno.DTFineImpe = DTfine.getDatetimeNT();
                impegno.DTFineImpeUBA = new SiarLibrary.NullTypes.DatetimeNT();
                impegno.DTInizioImpeUBA = new SiarLibrary.NullTypes.DatetimeNT();

                this.DettagliMisura.Impegni.Add(impegno);
            }
            #endregion

            #region Impegno misura F
            if (TipoDomanda == SianWebSrv.Utils.TipiDomanda.MisureAgroambientali)
            {
                string strFlag;
                strFlag = DatiSian.getValue(SIANGateway.XpathPSR.AdesioneMisura.Agroambientali.AggiAnnu, DettagliIterator, false);
                this.DettagliMisura.AggiAnnu = Utils.SianConvert.SianValueToBool(strFlag, SianWebSrv.Utils.ActionOnInvalidValue.acNullValue);
                strFlag = DatiSian.getValue(SIANGateway.XpathPSR.AdesioneMisura.Agroambientali.AmplImpe, DettagliIterator, false);
                this.DettagliMisura.AmplImpe = Utils.SianConvert.SianValueToBool(strFlag, SianWebSrv.Utils.ActionOnInvalidValue.acNullValue);
                strFlag = DatiSian.getValue(SIANGateway.XpathPSR.AdesioneMisura.Agroambientali.CambBene, DettagliIterator, false);
                this.DettagliMisura.CambBene = Utils.SianConvert.SianValueToBool(strFlag, SianWebSrv.Utils.ActionOnInvalidValue.acNullValue);
                strFlag = DatiSian.getValue(SIANGateway.XpathPSR.AdesioneMisura.Agroambientali.DomaIniz, DettagliIterator, false);
                this.DettagliMisura.DomaIniz = Utils.SianConvert.SianValueToBool(strFlag, SianWebSrv.Utils.ActionOnInvalidValue.acNullValue);
                strFlag = DatiSian.getValue(SIANGateway.XpathPSR.AdesioneMisura.Agroambientali.CambMisuAzio, DettagliIterator, false);
                this.DettagliMisura.CambioMisu = Utils.SianConvert.SianValueToBool(strFlag, SianWebSrv.Utils.ActionOnInvalidValue.acNullValue);
                strFlag = DatiSian.getValue(SIANGateway.XpathPSR.AdesioneMisura.Agroambientali.SostImpe, DettagliIterator, false);
                this.DettagliMisura.SostImpe = Utils.SianConvert.SianValueToBool(strFlag, SianWebSrv.Utils.ActionOnInvalidValue.acNullValue);
                strFlag = DatiSian.getValue(SIANGateway.XpathPSR.AdesioneMisura.Agroambientali.TrasImpe, DettagliIterator, false);
                this.DettagliMisura.TrasImpe = Utils.SianConvert.SianValueToBool(strFlag, SianWebSrv.Utils.ActionOnInvalidValue.acNullValue);

                TImpegno Impegno;
                XPathNodeIterator ImpegnoIterator;
                string XpathImpegni = SIANGateway.XpathPSR.AdesioneMisura.Agroambientali.ISWSImpegniAdesioneMisuraAgroASR.Root;
                ImpegnoIterator = DatiSian.getIterator(XpathImpegni, DettagliIterator, false);
                int numImpe = ImpegnoIterator.Count;
                for (int impeItem = 1; impeItem <= numImpe; impeItem++)
                {
                    ImpegnoIterator.MoveNext();
                    Impegno = new TImpegno();

                    string StrVal, StrXPath;
                    StrXPath = SIANGateway.XpathPSR.AdesioneMisura.Agroambientali.ISWSImpegniAdesioneMisuraAgroASR.codiTipoMisu;
                    Impegno.codiTipoMisu = DatiSian.getValue(StrXPath, ImpegnoIterator, false);
                    StrXPath = SIANGateway.XpathPSR.AdesioneMisura.Agroambientali.ISWSImpegniAdesioneMisuraAgroASR.codiAzio;
                    Impegno.codiAzio = DatiSian.getValue(StrXPath, ImpegnoIterator, false);
                    StrXPath = SIANGateway.XpathPSR.AdesioneMisura.Agroambientali.ISWSImpegniAdesioneMisuraAgroASR.descAzio;
                    Impegno.descAzio = DatiSian.getValue(StrXPath, ImpegnoIterator, false);

                    StrVal = DatiSian.getValue(SIANGateway.XpathPSR.AdesioneMisura.Agroambientali.ISWSImpegniAdesioneMisuraAgroASR.dataFineImpe, ImpegnoIterator, false);
                    Impegno.DTFineImpe = new SiarLibrary.NullTypes.DatetimeNT(StrVal);

                    StrVal = DatiSian.getValue(SIANGateway.XpathPSR.AdesioneMisura.Agroambientali.ISWSImpegniAdesioneMisuraAgroASR.dataFineImpeUBAA, ImpegnoIterator, false);
                    Impegno.DTFineImpeUBA = new SiarLibrary.NullTypes.DatetimeNT(StrVal);

                    StrVal = DatiSian.getValue(SIANGateway.XpathPSR.AdesioneMisura.Agroambientali.ISWSImpegniAdesioneMisuraAgroASR.dataInizImp, ImpegnoIterator, false);
                    Impegno.DTInizioImpe = new SiarLibrary.NullTypes.DatetimeNT(StrVal);

                    StrVal = DatiSian.getValue(SIANGateway.XpathPSR.AdesioneMisura.Agroambientali.ISWSImpegniAdesioneMisuraAgroASR.dataInizImpeUBAA, ImpegnoIterator, false);
                    Impegno.DTInizioImpeUBA = new SiarLibrary.NullTypes.DatetimeNT(StrVal);

                    this.DettagliMisura.Impegni.Add(Impegno);
                }
            }
            #endregion

            #endregion

            #region Decodifica superfici
            this.Superfici = new CollOfSuperfici();
            Superficie Sup;
            XPathNodeIterator InterventiIter;
            int NumInterventi;
            Intervento Inte;

            XPathNodeIterator SuperficiIterator = DatiSian.getIterator(SIANGateway.XpathPSR.ISWSSuperficiASR.Root);
            int NumSuperfici = SuperficiIterator.Count;

            for (int itemSup = 1; itemSup <= NumSuperfici; itemSup++)
            {
                SuperficiIterator.MoveNext();
                Sup = new Superficie();
                Sup.codiFascAltiDich = DatiSian.getValue(SIANGateway.XpathPSR.ISWSSuperficiASR.codiFascAltiDich, SuperficiIterator, false);
                Sup.comuneISTAT = DatiSian.getValue(SIANGateway.XpathPSR.ISWSSuperficiASR.comuneISTAT, SuperficiIterator);
                Sup.decoTipoAreC = DatiSian.getValue(SIANGateway.XpathPSR.ISWSSuperficiASR.decoTipoAreC, SuperficiIterator, false);
                Sup.decoTipoAreD = DatiSian.getValue(SIANGateway.XpathPSR.ISWSSuperficiASR.decoTipoAreD, SuperficiIterator, false);
                Sup.flagColtBiol = (DatiSian.getValue(SIANGateway.XpathPSR.ISWSSuperficiASR.flagColtBiol, SuperficiIterator, false) == "1");
                Sup.flagPasc = (DatiSian.getValue(SIANGateway.XpathPSR.ISWSSuperficiASR.flagPasc, SuperficiIterator, false) == "1");
                Sup.foglio = DatiSian.getValue(SIANGateway.XpathPSR.ISWSSuperficiASR.foglio, SuperficiIterator);
                Sup.particella = DatiSian.getValue(SIANGateway.XpathPSR.ISWSSuperficiASR.particella, SuperficiIterator);
                Sup.prodotto = DatiSian.getValue(SIANGateway.XpathPSR.ISWSSuperficiASR.prodotto, SuperficiIterator);
                Sup.provinciaISTAT = DatiSian.getValue(SIANGateway.XpathPSR.ISWSSuperficiASR.provinciaISTAT, SuperficiIterator);
                Sup.sezione = DatiSian.getValue(SIANGateway.XpathPSR.ISWSSuperficiASR.sezione, SuperficiIterator, false);
                Sup.subalterno = DatiSian.getValue(SIANGateway.XpathPSR.ISWSSuperficiASR.subalterno, SuperficiIterator, false);
                Sup.varieta = DatiSian.getValue(SIANGateway.XpathPSR.ISWSSuperficiASR.varieta, SuperficiIterator);
                Sup.AnnoCampagna = SianWebSrv.Utils.SianConvert.SianValueToInt(
                        DatiSian.getValue(SIANGateway.XpathPSR.ISWSSuperficiASR.annoCampagna, SuperficiIterator)
                    );
                Sup.ListaInterventi = new CollOfInterventi();

                InterventiIter = DatiSian.getIterator(SIANGateway.XpathPSR.ISWSSuperficiASR.ISWSInterventiASR.Root, SuperficiIterator, false);
                NumInterventi = InterventiIter.Count;
                //string misu;
                for (int itemInte = 1; itemInte<= NumInterventi; itemInte++)
                {
                    Inte = new Intervento();
                    InterventiIter.MoveNext();

                    Inte.codiTipoMisu = DatiSian.getValue(SIANGateway.XpathPSR.ISWSSuperficiASR.ISWSInterventiASR.codiTipoMisu, InterventiIter, false);
                    Inte.codiAzio = DatiSian.getValue(SIANGateway.XpathPSR.ISWSSuperficiASR.ISWSInterventiASR.codiAzio, InterventiIter, false);
                    Inte.codiSubbAzio = DatiSian.getValue(SIANGateway.XpathPSR.ISWSSuperficiASR.ISWSInterventiASR.codiSubbAzio, InterventiIter, false);
                    Inte.codiInte = DatiSian.getValue(SIANGateway.XpathPSR.ISWSSuperficiASR.ISWSInterventiASR.codiInte, InterventiIter, false);
                    Inte.supUtilizzata = Utils.SianConvert.SianValueToInt(DatiSian.getValue(SIANGateway.XpathPSR.ISWSSuperficiASR.ISWSInterventiASR.supUtilizzata, InterventiIter, false), Utils.ActionOnInvalidValue.acNullValue);
                    Inte.supPremio = Utils.SianConvert.SianValueToInt(DatiSian.getValue(SIANGateway.XpathPSR.ISWSSuperficiASR.ISWSInterventiASR.supPremio, InterventiIter, false), Utils.ActionOnInvalidValue.acNullValue);

                    Sup.ListaInterventi.Add(Inte);
                }
                this.Superfici.Add(Sup);
            }
            #endregion

            #region Decodifica Forma giuridica
            FormaGiuridica = new TFormaGiuridica();
            XPathNodeIterator FgiuIterator = DatiSian.getIterator(SIANGateway.XpathPSR.ISWSFormaGiuridicaASR.Root);
            if (FgiuIterator.Count == 0 )
            {
                throw new System.Exception("La risposta SIAN non contiene la sezione ISWSFormaGiuridicaASR");
            }
            if (FgiuIterator.Count > 1)
            {
                throw new System.Exception("La risposta SIAN contiene più di una sezione ISWSFormaGiuridicaASR");
            }
            FgiuIterator.MoveNext();

            string SianTipo = "";
            string SianAziende ="0";
            string SianSociDipe = "0";
            string SianGiovani = "0";
            string SianDonne ="0";

            SianTipo = DatiSian.getValue(SIANGateway.XpathPSR.ISWSFormaGiuridicaASR.codiPersGiur, FgiuIterator, false);
            if (Utils.SianConvert.SianValueToBool(SianTipo, SianWebSrv.Utils.ActionOnInvalidValue.acNullValue))
            {
                FormaGiuridica.TipoFormaGiuridica = Utils.TipiFormaGiuridica.fgPersonaGiuridica;
                SianAziende = "1";
                SianSociDipe = DatiSian.getValue(SIANGateway.XpathPSR.ISWSFormaGiuridicaASR.numePersGiur, FgiuIterator, false);
                SianGiovani = DatiSian.getValue(SIANGateway.XpathPSR.ISWSFormaGiuridicaASR.numePersGiurGiov, FgiuIterator, false);
                SianDonne = DatiSian.getValue(SIANGateway.XpathPSR.ISWSFormaGiuridicaASR.numePersGiurDonne, FgiuIterator, false);
            }
            SianTipo = DatiSian.getValue(SIANGateway.XpathPSR.ISWSFormaGiuridicaASR.codiSociCoop, FgiuIterator, false);
            if (Utils.SianConvert.SianValueToBool(SianTipo, Utils.ActionOnInvalidValue.acNullValue))
            {
                FormaGiuridica.TipoFormaGiuridica = Utils.TipiFormaGiuridica.fgCoop;
                SianAziende = "1";
                SianSociDipe = DatiSian.getValue(SIANGateway.XpathPSR.ISWSFormaGiuridicaASR.numeSociCoop, FgiuIterator, false);
                SianGiovani = DatiSian.getValue(SIANGateway.XpathPSR.ISWSFormaGiuridicaASR.numeSociGiov, FgiuIterator, false);
                SianDonne = DatiSian.getValue(SIANGateway.XpathPSR.ISWSFormaGiuridicaASR.numeSociDonne, FgiuIterator, false);
            }
            SianTipo = DatiSian.getValue(SIANGateway.XpathPSR.ISWSFormaGiuridicaASR.codiConsCoop, FgiuIterator, false);
            if (Utils.SianConvert.SianValueToBool(SianTipo, Utils.ActionOnInvalidValue.acNullValue))
            {
                FormaGiuridica.TipoFormaGiuridica = Utils.TipiFormaGiuridica.fgConsorzioCoop;
                SianAziende = DatiSian.getValue(SIANGateway.XpathPSR.ISWSFormaGiuridicaASR.numeConsCoop, FgiuIterator, false);
                SianSociDipe = DatiSian.getValue(SIANGateway.XpathPSR.ISWSFormaGiuridicaASR.numeConsSoci, FgiuIterator, false);
                SianGiovani = "0";
                SianDonne = "0";
            }
            SianTipo = DatiSian.getValue(SIANGateway.XpathPSR.ISWSFormaGiuridicaASR.codiAssoProd, FgiuIterator, false);
            if (Utils.SianConvert.SianValueToBool(SianTipo, Utils.ActionOnInvalidValue.acNullValue))
            {
                FormaGiuridica.TipoFormaGiuridica = Utils.TipiFormaGiuridica.fgAssoProduttori;
                SianAziende = DatiSian.getValue(SIANGateway.XpathPSR.ISWSFormaGiuridicaASR.numeAssoProd, FgiuIterator, false);
                SianSociDipe = "0";
                SianGiovani = "0";
                SianDonne = "0";
            }
            SianTipo = DatiSian.getValue(SIANGateway.XpathPSR.ISWSFormaGiuridicaASR.codiSociAccomandita, FgiuIterator, false);
            if (Utils.SianConvert.SianValueToBool(SianTipo, Utils.ActionOnInvalidValue.acNullValue))
            {
                FormaGiuridica.TipoFormaGiuridica = Utils.TipiFormaGiuridica.fgSocAccomandita;
                SianAziende = "1";
                SianSociDipe = DatiSian.getValue(SIANGateway.XpathPSR.ISWSFormaGiuridicaASR.numeSociAccomandita, FgiuIterator, false);
                SianGiovani = "0";
                SianDonne = "0";
            }
            SianTipo = DatiSian.getValue(SIANGateway.XpathPSR.ISWSFormaGiuridicaASR.codiSociCapi, FgiuIterator, false);
            if (Utils.SianConvert.SianValueToBool(SianTipo, Utils.ActionOnInvalidValue.acNullValue))
            {
                FormaGiuridica.TipoFormaGiuridica = Utils.TipiFormaGiuridica.fgSocCapitali;
                SianAziende = "1";
                SianSociDipe = DatiSian.getValue(SIANGateway.XpathPSR.ISWSFormaGiuridicaASR.numedipendenti, FgiuIterator, false);
                SianGiovani = "0";
                SianDonne = "0";
            }
            SianTipo = DatiSian.getValue(SIANGateway.XpathPSR.ISWSFormaGiuridicaASR.assoImprese, FgiuIterator, false);
            if (Utils.SianConvert.SianValueToBool(SianTipo, Utils.ActionOnInvalidValue.acNullValue))
            {
                FormaGiuridica.TipoFormaGiuridica = Utils.TipiFormaGiuridica.fgAssoImprese;
                SianAziende = "0";
                SianSociDipe = "0";
                SianGiovani = "0";
                SianDonne = "0";
            }
            SianTipo = DatiSian.getValue(SIANGateway.XpathPSR.ISWSFormaGiuridicaASR.assoNoLucro, FgiuIterator, false);
            if (Utils.SianConvert.SianValueToBool(SianTipo, Utils.ActionOnInvalidValue.acNullValue))
            {
                FormaGiuridica.TipoFormaGiuridica = Utils.TipiFormaGiuridica.fgNoLucro;
                SianAziende = "0";
                SianSociDipe = "0";
                SianGiovani = "0";
                SianDonne = "0";
            }
            SianTipo = DatiSian.getValue(SIANGateway.XpathPSR.ISWSFormaGiuridicaASR.assoCategorie, FgiuIterator, false);
            if (Utils.SianConvert.SianValueToBool(SianTipo, Utils.ActionOnInvalidValue.acNullValue))
            {
                FormaGiuridica.TipoFormaGiuridica = Utils.TipiFormaGiuridica.fgAssoCategoria;
                SianAziende = "0";
                SianSociDipe = "0";
                SianGiovani = "0";
                SianDonne = "0";
            }
            SianTipo = DatiSian.getValue(SIANGateway.XpathPSR.ISWSFormaGiuridicaASR.formRegi, FgiuIterator, false);
            if (Utils.SianConvert.SianValueToBool(SianTipo, Utils.ActionOnInvalidValue.acNullValue))
            {
                FormaGiuridica.TipoFormaGiuridica = Utils.TipiFormaGiuridica.fgRegione;
                SianAziende = "0";
                SianSociDipe = "0";
                SianGiovani = "0";
                SianDonne = "0";
            }
            SianTipo = DatiSian.getValue(SIANGateway.XpathPSR.ISWSFormaGiuridicaASR.formProv, FgiuIterator, false);
            if (Utils.SianConvert.SianValueToBool(SianTipo, Utils.ActionOnInvalidValue.acNullValue))
            {
                FormaGiuridica.TipoFormaGiuridica = Utils.TipiFormaGiuridica.fgProvincia;
                SianAziende = "0";
                SianSociDipe = "0";
                SianGiovani = "0";
                SianDonne = "0";
            }
            SianTipo = DatiSian.getValue(SIANGateway.XpathPSR.ISWSFormaGiuridicaASR.formComune, FgiuIterator, false);
            if (Utils.SianConvert.SianValueToBool(SianTipo, Utils.ActionOnInvalidValue.acNullValue))
            {
                FormaGiuridica.TipoFormaGiuridica = Utils.TipiFormaGiuridica.fgComune;
                SianAziende = "0";
                SianSociDipe = "0";
                SianGiovani = "0";
                SianDonne = "0";
            }
            SianTipo = DatiSian.getValue(SIANGateway.XpathPSR.ISWSFormaGiuridicaASR.comunMontan, FgiuIterator, false);
            if (Utils.SianConvert.SianValueToBool(SianTipo, Utils.ActionOnInvalidValue.acNullValue))
            {
                FormaGiuridica.TipoFormaGiuridica = Utils.TipiFormaGiuridica.fgComMontana;
                SianAziende = "0";
                SianSociDipe = "0";
                SianGiovani = "0";
                SianDonne = "0";
            }
            SianTipo = DatiSian.getValue(SIANGateway.XpathPSR.ISWSFormaGiuridicaASR.consComuni, FgiuIterator, false);
            if (Utils.SianConvert.SianValueToBool(SianTipo, Utils.ActionOnInvalidValue.acNullValue))
            {
                FormaGiuridica.TipoFormaGiuridica = Utils.TipiFormaGiuridica.fgConsorzioComuni;
                SianAziende = "0";
                SianSociDipe = "0";
                SianGiovani = "0";
                SianDonne = "0";
            }
            SianTipo = DatiSian.getValue(SIANGateway.XpathPSR.ISWSFormaGiuridicaASR.consForestale, FgiuIterator, false);
            if (Utils.SianConvert.SianValueToBool(SianTipo, Utils.ActionOnInvalidValue.acNullValue))
            {
                FormaGiuridica.TipoFormaGiuridica = Utils.TipiFormaGiuridica.fgConsorzioForestale;
                SianAziende = "0";
                SianSociDipe = "0";
                SianGiovani = "0";
                SianDonne = "0";
            }
            SianTipo = DatiSian.getValue(SIANGateway.XpathPSR.ISWSFormaGiuridicaASR.enteParco, FgiuIterator, false);
            if (Utils.SianConvert.SianValueToBool(SianTipo, Utils.ActionOnInvalidValue.acNullValue))
            {
                FormaGiuridica.TipoFormaGiuridica = Utils.TipiFormaGiuridica.fgEnteParco;
                SianAziende = "0";
                SianSociDipe = "0";
                SianGiovani = "0";
                SianDonne = "0";
            }
            SianTipo = DatiSian.getValue(SIANGateway.XpathPSR.ISWSFormaGiuridicaASR.consBoniIrriga, FgiuIterator, false);
            if (Utils.SianConvert.SianValueToBool(SianTipo, Utils.ActionOnInvalidValue.acNullValue))
            {
                FormaGiuridica.TipoFormaGiuridica = Utils.TipiFormaGiuridica.fgConsorzioBonifica;
                SianAziende = "0";
                SianSociDipe = "0";
                SianGiovani = "0";
                SianDonne = "0";
            }
            SianTipo = DatiSian.getValue(SIANGateway.XpathPSR.ISWSFormaGiuridicaASR.altroEntePubb, FgiuIterator, false);
            if (Utils.SianConvert.SianValueToBool(SianTipo, Utils.ActionOnInvalidValue.acNullValue))
            {
                FormaGiuridica.TipoFormaGiuridica = Utils.TipiFormaGiuridica.fgAltroEntePubblico;
                SianAziende = "0";
                SianSociDipe = "0";
                SianGiovani = "0";
                SianDonne = "0";
            }
            SianTipo = DatiSian.getValue(SIANGateway.XpathPSR.ISWSFormaGiuridicaASR.consTutela, FgiuIterator, false);
            if (Utils.SianConvert.SianValueToBool(SianTipo, Utils.ActionOnInvalidValue.acNullValue))
            {
                FormaGiuridica.TipoFormaGiuridica = Utils.TipiFormaGiuridica.fgConsorzioTutela;
                SianAziende = "0";
                SianSociDipe = "0";
                SianGiovani = "0";
                SianDonne = "0";
            }
            SianTipo = DatiSian.getValue(SIANGateway.XpathPSR.ISWSFormaGiuridicaASR.flagEnteForm, FgiuIterator, false);
            if (Utils.SianConvert.SianValueToBool(SianTipo, Utils.ActionOnInvalidValue.acNullValue))
            {
                FormaGiuridica.TipoFormaGiuridica = Utils.TipiFormaGiuridica.fgEnteFormazione;
                SianAziende = "0";
                SianSociDipe = "0";
                SianGiovani = "0";
                SianDonne = "0";
            }
            FormaGiuridica.DescrAltraForma = DatiSian.getValue(SIANGateway.XpathPSR.ISWSFormaGiuridicaASR.descAltro, FgiuIterator, false);
            if (FormaGiuridica.DescrAltraForma != "")
            {
                FormaGiuridica.TipoFormaGiuridica = Utils.TipiFormaGiuridica.fgAltro;
                SianAziende = "0";
                SianSociDipe = "0";
                SianGiovani = "0";
                SianDonne = "0";
            }
            FormaGiuridica.NAziende = Utils.SianConvert.SianValueToInt(SianAziende);
            FormaGiuridica.NSociDipendenti = Utils.SianConvert.SianValueToInt(SianSociDipe);
            FormaGiuridica.NGiovani = Utils.SianConvert.SianValueToInt(SianGiovani);
            FormaGiuridica.NDonne = Utils.SianConvert.SianValueToInt(SianDonne);
            #endregion

            #region Decodifica attvità connesse
            AttivitaConnesse = new TAttivitaConnesse();
            XPathNodeIterator AttivIterator = DatiSian.getIterator(SIANGateway.XpathPSR.ISWSAttivitaSvolteASR.Root);
            if (AttivIterator.Count == 0)
            {
                throw new System.Exception("La risposta SIAN non contiene la sezione ISWSAttivitaSvolteASR.");
            }
            if (AttivIterator.Count > 1)
            {
                throw new System.Exception("La risposta SIAN contiene più di una sezione ISWSAttivitaSvolteASR.");
            }
            AttivIterator.MoveNext();

            string SianFlagAttiv;
            SianFlagAttiv = DatiSian.getValue(SIANGateway.XpathPSR.ISWSAttivitaSvolteASR.Agriturismo,AttivIterator,true);
            AttivitaConnesse.Agriturismo = Utils.SianConvert.SianValueToBool(SianFlagAttiv, SianWebSrv.Utils.ActionOnInvalidValue.acNullValue);
            SianFlagAttiv = DatiSian.getValue(SIANGateway.XpathPSR.ISWSAttivitaSvolteASR.Altro, AttivIterator, true);
            AttivitaConnesse.Altro = Utils.SianConvert.SianValueToBool(SianFlagAttiv, SianWebSrv.Utils.ActionOnInvalidValue.acNullValue);
            SianFlagAttiv = DatiSian.getValue(SIANGateway.XpathPSR.ISWSAttivitaSvolteASR.Artigianato, AttivIterator, true);
            AttivitaConnesse.Artigianato = Utils.SianConvert.SianValueToBool(SianFlagAttiv, SianWebSrv.Utils.ActionOnInvalidValue.acNullValue);
            SianFlagAttiv = DatiSian.getValue(SIANGateway.XpathPSR.ISWSAttivitaSvolteASR.AttivRicreative, AttivIterator, true);
            AttivitaConnesse.AttivRicreative = Utils.SianConvert.SianValueToBool(SianFlagAttiv, SianWebSrv.Utils.ActionOnInvalidValue.acNullValue);
            SianFlagAttiv = DatiSian.getValue(SIANGateway.XpathPSR.ISWSAttivitaSvolteASR.ContoTerzismo, AttivIterator, true);
            AttivitaConnesse.ContoTerzismo = Utils.SianConvert.SianValueToBool(SianFlagAttiv, SianWebSrv.Utils.ActionOnInvalidValue.acNullValue);
            SianFlagAttiv = DatiSian.getValue(SIANGateway.XpathPSR.ISWSAttivitaSvolteASR.EnergiaRinnov, AttivIterator, true);
            AttivitaConnesse.EnergiaRinnov = Utils.SianConvert.SianValueToBool(SianFlagAttiv, SianWebSrv.Utils.ActionOnInvalidValue.acNullValue);
            SianFlagAttiv = DatiSian.getValue(SIANGateway.XpathPSR.ISWSAttivitaSvolteASR.Trasformazione, AttivIterator, true);
            AttivitaConnesse.Trasformazione = Utils.SianConvert.SianValueToBool(SianFlagAttiv, SianWebSrv.Utils.ActionOnInvalidValue.acNullValue);
            #endregion

            #region Decodifica allevamenti
            this.Allevamenti = new CollOfAllevamenti();
            Allevamento Allev;
            string StrNumCapi;

            XPathNodeIterator AllevIterator = DatiSian.getIterator(SIANGateway.XpathPSR.ISWSConsistenzaZooTecnicaASR.Root);
            int NumAllev = AllevIterator.Count;

            for (int itemAllev = 1; itemAllev <= NumAllev; itemAllev++)
            {
                AllevIterator.MoveNext();
                Allev = new Allevamento();
                Allev.codiTipoZootecnia = DatiSian.getValue(SIANGateway.XpathPSR.ISWSConsistenzaZooTecnicaASR.codiTipoZootecnia, AllevIterator, true);
                StrNumCapi = DatiSian.getValue(SIANGateway.XpathPSR.ISWSConsistenzaZooTecnicaASR.numeCapi, AllevIterator, false);
                Allev.numeCapi = Utils.SianConvert.SianValueToInt(StrNumCapi, SianWebSrv.Utils.ActionOnInvalidValue.acNullValue);
                StrNumCapi = DatiSian.getValue(SIANGateway.XpathPSR.ISWSConsistenzaZooTecnicaASR.numeCapiFemmine, AllevIterator, false);
                Allev.numeCapiFemmine = Utils.SianConvert.SianValueToInt(StrNumCapi, SianWebSrv.Utils.ActionOnInvalidValue.acNullValue);

                this.Allevamenti.Add(Allev);
            }
            #endregion

            #region Decodifica forma conduzione
            XPathNodeIterator FormaConduzIterator = DatiSian.getIterator(SIANGateway.XpathPSR.ISWSFormaConduzioneAziendaleASR.Root);
            if (FormaConduzIterator.Count == 0)
            {
                throw new System.Exception("La risposta SIAN non contiene la sezione ISWSFormaConduzioneAziendaleASR");
            }
            if (FormaConduzIterator.Count > 1)
            {
                throw new System.Exception("La risposta SIAN contiene più di una sezione ISWSFormaConduzioneAziendaleASR");
            }
            FormaConduzIterator.MoveNext();

            string condAltro, condSalariati, condExtraFami, condFamiPrev, condSoloFami ;
            condAltro = DatiSian.getValue(SIANGateway.XpathPSR.ISWSFormaConduzioneAziendaleASR.AltraForma, FormaConduzIterator, false);
            condSalariati = DatiSian.getValue(SIANGateway.XpathPSR.ISWSFormaConduzioneAziendaleASR.ConSalar, FormaConduzIterator, false);
            condExtraFami = DatiSian.getValue(SIANGateway.XpathPSR.ISWSFormaConduzioneAziendaleASR.ManoExtrafamiPrev, FormaConduzIterator, false);
            condFamiPrev = DatiSian.getValue(SIANGateway.XpathPSR.ISWSFormaConduzioneAziendaleASR.ManoFamiPrev, FormaConduzIterator, false);
            condSoloFami = DatiSian.getValue(SIANGateway.XpathPSR.ISWSFormaConduzioneAziendaleASR.SolaManoFam, FormaConduzIterator, false);

            int condAltroi, condSalariatii, condExtraFamii, condFamiPrevi, condSoloFamii;
            condAltroi = Utils.SianConvert.SianValueToInt(condAltro, SianWebSrv.Utils.ActionOnInvalidValue.acNullValue);
            condSalariatii = Utils.SianConvert.SianValueToInt(condSalariati, SianWebSrv.Utils.ActionOnInvalidValue.acNullValue);
            condExtraFamii = Utils.SianConvert.SianValueToInt(condExtraFami, SianWebSrv.Utils.ActionOnInvalidValue.acNullValue);
            condFamiPrevi = Utils.SianConvert.SianValueToInt(condFamiPrev, SianWebSrv.Utils.ActionOnInvalidValue.acNullValue);
            condSoloFamii = Utils.SianConvert.SianValueToInt(condSoloFami, SianWebSrv.Utils.ActionOnInvalidValue.acNullValue);

            this.FormaConduzione = SianWebSrv.Utils.TipiFormeConduzione.fcNonSpecificato;
            if ((condAltroi == 1) && ( condSalariatii ==0 ) && (condExtraFamii==0) &&
                (condFamiPrevi == 0) && (condSoloFamii == 0))
            {
                this.FormaConduzione = SianWebSrv.Utils.TipiFormeConduzione.fcNonDireAltraForma;
            }
            if ((condAltroi == 0) && (condSalariatii == 1) && (condExtraFamii == 0) &&
                (condFamiPrevi == 0) && (condSoloFamii == 0))
            {
                this.FormaConduzione = SianWebSrv.Utils.TipiFormeConduzione.fcNonDireConSalar;
            }
            if ((condAltroi == 0) && ( condSalariatii ==0 ) && (condExtraFamii==1) &&
                (condFamiPrevi == 0) && (condSoloFamii == 0))
            {
                this.FormaConduzione = SianWebSrv.Utils.TipiFormeConduzione.fcManoExtrafamiPrev;
            }
            if ((condAltroi == 0) && ( condSalariatii ==0 ) && (condExtraFamii==0) &&
                (condFamiPrevi == 1) && (condSoloFamii == 0))
            {
                this.FormaConduzione = SianWebSrv.Utils.TipiFormeConduzione.fcManoFamiPrev;
            }
            if ((condAltroi == 0) && ( condSalariatii ==0 ) && (condExtraFamii==0) &&
                (condFamiPrevi == 0) && (condSoloFamii == 1))
            {
                this.FormaConduzione = SianWebSrv.Utils.TipiFormeConduzione.fcSolaManoFami;
            }
            #endregion

            #region CustomField
            XPathNodeIterator CustomFieldIterator;

            string xPathCustomField;

            if (this.Anagrafica.TipoDoma == SianWebSrv.Utils.TipiDomanda.MisureAgroambientali){
                xPathCustomField = 
                    SIANGateway.XpathPSR.AdesioneMisura.Agroambientali.Root + "/" +
                    SIANGateway.XpathPSR.AdesioneMisura.ISWSCampiPersonalizzatiASR.Root;
                CustomFieldIterator = DatiSian.getIterator(xPathCustomField);
            }else{
                xPathCustomField =
                    SIANGateway.XpathPSR.AdesioneMisura.Compensativa.Root + "/" +
                    SIANGateway.XpathPSR.AdesioneMisura.ISWSCampiPersonalizzatiASR.Root;
                CustomFieldIterator = DatiSian.getIterator(xPathCustomField);
            }

            this.CampiPersonalizzati = new CollOfCustomField();

            for (int nCampi = 1; nCampi<=CustomFieldIterator.Count; ++nCampi)
            {
                TCustomField CustomField = new TCustomField();
                CustomFieldIterator.MoveNext();
                CustomField.name = DatiSian.getValue(SIANGateway.XpathPSR.AdesioneMisura.ISWSCampiPersonalizzatiASR.descrizione, CustomFieldIterator, true);
                CustomField.value = DatiSian.getValue(SIANGateway.XpathPSR.AdesioneMisura.ISWSCampiPersonalizzatiASR.valore, CustomFieldIterator, false);
                this.CampiPersonalizzati.Add(CustomField);
            }
            #endregion

        }
    }

}
