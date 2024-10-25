using System;
using System.Collections.Generic;
using System.Text;
using SiarLibrary.NullTypes;

namespace SianWebSrv
{
    /// <summary>
    /// Contiene classi di utilità specifiche per la gestione dei web service AGEA
    /// </summary> 
    namespace Utils
    {
        /// <summary>
        /// Classe di supporto per la manipolazione delle date nei formati supportati da AGRISIAN.
        /// </summary> 
        /// <remarks>
        /// I formati AGRISIAN gestiti sono:
        /// <list type="bullet">
        /// <item>AAAAMMGG es: 15/02/2004 = 20040215</item>
        /// <item>AAAA-MM-GG es: 15/02/2004 = 2004-02-15</item>
        /// </list>
        /// La classe memorizza un valore di tipo Datetime.
        /// Può essere configurata in modo da specificare un valore di tipo
        /// DateTime e/o String speciali da considerare come Null
        /// Per default la stringa nulla e la data 1/1/1 sono considerate Null.
        /// Se si tenta di impostare l'oggetto su una stringa non compatibile 
        /// con i formati AGRISIAN o che non esprime una data valida,
        /// il valore impostato è per default null, è tuttavia possibile
        /// configurare la classe per sollevare un'eccezione.
        /// </remarks>
        public class DataSIAN
        {
            private DateTime Data;

            /// <summary>
            /// Enumerazione che elenca i formati data AGRISIAN supportati
            /// </summary>
            /// <remarks>
            /// <b>dtAAAAMMGG</b>: Formato AAAAMMGG es: 15/02/2004 = 20040215
            /// <br>
            /// <b>dtAAAA_MM_GG</b>: Formato AAAA-MM-GG es: 15/02/2004 = 2004-02-15
            /// </remarks>
            public enum dtStringFormat
            {
                dtAAAAMMGG, 
                dtAAAA_MM_GG  
            }
            private dtStringFormat CurrentFormat;

            private void SetDefault()
            {
                strNullDate = "";
                NullDate = new DateTime(1, 1, 1);
                ThrowOnInvalidValue = false;
                CurrentFormat = dtStringFormat.dtAAAAMMGG;
            }

            private void loadDataAgrisian(string StrSianData)
            {
                string _StrSianData = StrSianData.Trim();
                if (_StrSianData.Length == 10)
                {
                    _StrSianData = _StrSianData.Substring(0, 4) +
                                    _StrSianData.Substring(5, 2) +
                                    _StrSianData.Substring(8, 2);
                    CurrentFormat = dtStringFormat.dtAAAA_MM_GG;
                }
                else if (_StrSianData.Length == 8)
                {
                    //DataFormat = dfAAAAMMGG;
                    CurrentFormat = dtStringFormat.dtAAAAMMGG;
                }

                if (_StrSianData != strNullDate)
                {
                    try
                    {
                        int Year = Convert.ToInt32(_StrSianData.Substring(0, 4));
                        int Month = Convert.ToInt32(_StrSianData.Substring(4, 2));
                        int Day = Convert.ToInt32(_StrSianData.Substring(6, 2));
                        Data = new DateTime(Year, Month, Day);
                    }
                    catch (Exception e)
                    {
                        Data = NullDate;
                        // non è una data valida che facciamo???? boh!
                        if (ThrowOnInvalidValue)
                        {
                            throw new Exception("Data AGRISIAN non valida [" + StrSianData + "]: " + e.Message);
                        }
                    }
                }
            }
             
            /// <summary>
            /// Valore DateTime convenzionale per la data da considerare nulla, per default 1/1/1
            /// </summary>
            public DateTime NullDate;

            /// <summary>
            /// Valore String convenzionale per la data da considerare nulla, per default è la stringa nulla
            /// </summary>
            public string strNullDate;

            /// <summary>
            /// Stabilisce se sollevare eccezione in presenza di stringhe
            /// non convertibili in DateTime
            /// </summary><remarks>
            /// Se impostato a True la lettura di una data in formato AGRISIAN
            /// restituisce un'eccezione quando questa, non è convertibile in 
            /// una data valida, o non è conforma ai formati AGRISIAN supportati.
            /// Se impostato a false (Default) la classe si imposta sul valore Null
            /// senza sollevare nessuna eccezione.
            /// </remarks>
            public bool ThrowOnInvalidValue;

            /// <summary>
            /// Verifica se la data corrente è uguale al valore Null
            /// </summary>
            /// <returns> true se la data corrente è nulla, false se la data corrente è valida</returns>
            /// <seealso cref="NullDate"/>
            /// <seealso cref="strNullDate"/>
            public bool isNull()
            {
                return (Data.CompareTo(NullDate) == 0);
            }

            /// <summary>
            /// Costruttore con parametri di default
            /// </summary>
            /// <remarks>Istanzia l'oggetto sul valore 1/1/1</remarks>
            public DataSIAN()
            {
                SetDefault();
                Data = NullDate;
            }

            /// <summary>
            /// Istanzia l'oggetto sul valore data convertito da una stringa
            /// in uno dei formati AGRISIAN supportati.
            /// </summary>
            /// <remarks>
            /// Il formato AGRISIAN viene individuato automaticamente. 
            /// <seealso cref="dtStringFormat"/>
            /// </remarks>
            /// <param name="StrSianData">Data in formato SIAN</param>
            public DataSIAN(string StrSianData)
            {
                SetDefault();
                if (StrSianData == "99991231")
                {
                    loadDataAgrisian("");
                }
                else
                {
                    loadDataAgrisian(StrSianData);
                }
            }

            /// Istanzia l'oggetto ricevendo un valore DateTime
            public DataSIAN(DateTime DataDateTime)
            {
                SetDefault();
                Data = DataDateTime;
            }

            /// <summary>
            /// Restituisce/imposta la data corrente come stringa nel
            /// formato AGRISIAN correntemente impostato
            /// </summary>
            /// <seealso cref="dtStringFormat"/>
            public string AgrisianDate
            {
                get
                {
                    if (this.isNull())
                    {
                        return strNullDate;
                    }
                    else
                    {
                        string formato = "";
                        switch (CurrentFormat)
                        {
                            case dtStringFormat.dtAAAA_MM_GG:
                                formato = "yyyy-MM-dd";
                                break;
                            case dtStringFormat.dtAAAAMMGG:
                                formato = "yyyyMMdd";
                                break;
                        }
                        if (formato == "")
                        {
                            throw new Exception("Formato data non impostato.");
                        }
                        return Data.ToString(formato);
                    }
                }
                set {
                    // lascia invariato il formato per il metodo get
                    dtStringFormat OldFormat = CurrentFormat;
                    loadDataAgrisian(value);
                    CurrentFormat = OldFormat;
                }
            }

            /// <summary>
            /// Restitisce/Imposta il formato corrente per la conversione
            /// DateTime String
            /// </summary>
            public dtStringFormat SianFormat
            {
                get { return CurrentFormat; }
                set { CurrentFormat = value; }
            }

            /// <summary>
            /// Restitisce/Imposta la data corrente come tipo DateTime
            /// </summary>
            public DateTime getDateTime
            {
                get { return Data;  }
                set { Data = value; }
            }

            /// <summary>
            /// Restitisce la data corrente come tipo DatetimeNT
            /// </summary>
            public DatetimeNT getDatetimeNT()
            {
               if (this.isNull())
               {
                   return new DatetimeNT( );
               }
               else
               {
                   return new DatetimeNT( this.getDateTime );
               }
            }

        }

        public enum TipiCodFisc { PersonaFisica, PersonaGiuridica, NonSpecificato }
        public enum TipiDomanda { IndennitaCompensativa, MisureAgroambientali, NonIndicata }
        public enum TipiMisura { mE, m211, m212, m213, mF1, mF2, mF2b, mF5, m214, m215, m2078, NonIndicata }
        public enum TipiFormaGiuridica
        {
            fgPersonaGiuridica, fgCoop, fgConsorzioCoop, fgAssoProduttori, fgSocAccomandita, fgSocCapitali, 
            fgAssoImprese, fgNoLucro, fgAssoCategoria, fgRegione, fgProvincia, fgComune, 
            fgComMontana, fgConsorzioComuni, fgConsorzioForestale, fgEnteParco,
            fgConsorzioBonifica, fgAltroEntePubblico, fgConsorzioTutela, fgEnteFormazione,
            fgAltro
        }
        public enum TipiFormeConduzione { fcSolaManoFami, fcManoFamiPrev,
            fcManoExtrafamiPrev, fcNonDireConSalar, fcNonDireAltraForma, fcNonSpecificato }

        public enum ActionOnInvalidValue { acThrow, acNullValue }

        public static class SianConvert
        {
            public static TipiCodFisc SianValueToTipiCodFisc(string SianValue, ActionOnInvalidValue InvalidValueAction)
            {
                switch (SianValue)
                {
                    case "PF":
                        return TipiCodFisc.PersonaFisica;
                    case "PG":
                        return TipiCodFisc.PersonaGiuridica;
                }
                switch (InvalidValueAction)
                {
                    case ActionOnInvalidValue.acNullValue: return TipiCodFisc.NonSpecificato;
                    default: throw new System.Exception("Tipo forma giuridica [" + SianValue + "] non codificata."); 
                }
            }

            public static TipiDomanda SianValueToTipiDomanda(string SianValue, ActionOnInvalidValue InvalidValueAction)
            {
                switch (SianValue)
                {
                    case "1": return TipiDomanda.IndennitaCompensativa;
                    case "2": return TipiDomanda.MisureAgroambientali;
                }
                switch (InvalidValueAction)
                {
                    case ActionOnInvalidValue.acNullValue: return TipiDomanda.NonIndicata;
                    default: throw new System.Exception("Tipo domanda [" + SianValue + "] non codificata.");
                }
            }

            public static TipiMisura SianValueToTipiMisura(
                string codiTipoMisu, string codiAzio, int numeAnnoDomaIniz,
                ActionOnInvalidValue InvalidValueAction)
            {
                switch (codiTipoMisu)
                {
                    case "E":
                        return TipiMisura.mE;
                    case "2078":
                        return TipiMisura.m2078;
                    case "2.1.1":
                        return TipiMisura.m211;
                    case "2.1.2":
                        return TipiMisura.m212;
                    case "2.1.3":
                        return TipiMisura.m213;
                    case "2.1.4":
                        return TipiMisura.m214;
                    case "2.1.5":
                        return TipiMisura.m215;
                }
                if (codiTipoMisu=="F")
                {
                    if (codiAzio == "F1") { return TipiMisura.mF1; }
                    if (codiAzio == "F5") { return TipiMisura.mF5; }
                    if (codiAzio == "F2")
                    {
                        if (numeAnnoDomaIniz <= 2003)
                        {
                            return TipiMisura.mF2;
                        }
                        else
                        {
                            return TipiMisura.mF2b;
                        }
                    }
                }
                switch (InvalidValueAction)
                {
                    case ActionOnInvalidValue.acNullValue: return TipiMisura.NonIndicata;
                    default: throw new System.Exception(
                        "Misura non codificata: "+
                        "codiAzio="+codiAzio+
                        "codiTipoMisu="+codiTipoMisu
                        );
                }
            }

            public static int SianValueToID_INTERVENTO(
                string codiTipoMisu, string codiAzio, int numeAnnoDomaIniz,
                ActionOnInvalidValue InvalidValueAction)
            {
                switch (codiTipoMisu)
                {
                    case "E":
                        return 8;
                    case "2078":
                        return 50;
                    case "2.1.1":
                        return 65;
                    case "2.1.2":
                        return 66;
                    case "2.1.3":
                        return 67;
                    case "2.1.4":
                        return 68;
                    case "2.1.5":
                        return 69;
                }
                if (codiTipoMisu == "F")
                {
                    if (codiAzio == "F1") { return 9; }
                    if (codiAzio == "F5") { return 12; }
                    if (codiAzio == "F2")
                    {
                        if (numeAnnoDomaIniz <= 2003)
                        {
                            return 10;
                        }
                        else
                        {
                            return 49;
                        }
                    }
                }
                return 0;
                /*
                switch (InvalidValueAction)
                {
                    case ActionOnInvalidValue.acNullValue: return 0;
                    default: throw new System.Exception("Tipo misura [" + codiTipoMisu + "] non codificata.");
                }
                */ 
            }

            public static int SianFormaGiuToSiarm(TipiFormaGiuridica FormaGiurSian)
            {
                switch (FormaGiurSian)
                {
                    case SianWebSrv.Utils.TipiFormaGiuridica.fgAltro:
                        return 1;
                    case SianWebSrv.Utils.TipiFormaGiuridica.fgAltroEntePubblico:
                        return 2;
                    case SianWebSrv.Utils.TipiFormaGiuridica.fgAssoCategoria:
                        return 5;
                    case SianWebSrv.Utils.TipiFormaGiuridica.fgAssoImprese:
                        return 6;
                    case SianWebSrv.Utils.TipiFormaGiuridica.fgAssoProduttori:
                        return 7;
                    case SianWebSrv.Utils.TipiFormaGiuridica.fgComMontana:
                        return 9;
                    case SianWebSrv.Utils.TipiFormaGiuridica.fgComune:
                        return 8;
                    case SianWebSrv.Utils.TipiFormaGiuridica.fgConsorzioBonifica:
                        return 10;
                    case SianWebSrv.Utils.TipiFormaGiuridica.fgConsorzioComuni:
                        return 11;
                    case SianWebSrv.Utils.TipiFormaGiuridica.fgConsorzioCoop:
                        return 12;
                    case SianWebSrv.Utils.TipiFormaGiuridica.fgConsorzioForestale:
                        return 14;
                    case SianWebSrv.Utils.TipiFormaGiuridica.fgConsorzioTutela:
                        return 13;
                    case SianWebSrv.Utils.TipiFormaGiuridica.fgCoop:
                        return 21;
                    case SianWebSrv.Utils.TipiFormaGiuridica.fgEnteFormazione:
                        return 16;
                    case SianWebSrv.Utils.TipiFormaGiuridica.fgEnteParco:
                        return 17;
                    case SianWebSrv.Utils.TipiFormaGiuridica.fgNoLucro:
                        return 27;
                    case SianWebSrv.Utils.TipiFormaGiuridica.fgPersonaGiuridica:
                        return 15;
                    case SianWebSrv.Utils.TipiFormaGiuridica.fgProvincia:
                        return 18;
                    case SianWebSrv.Utils.TipiFormaGiuridica.fgRegione:
                        return 19;
                    case SianWebSrv.Utils.TipiFormaGiuridica.fgSocAccomandita:
                        return 23;
                    case SianWebSrv.Utils.TipiFormaGiuridica.fgSocCapitali:
                        return 3;
                    default:
                        return 1;
                }
            }

            public static int SianFormaCondToSiarm(TipiFormeConduzione FormaCondSian)
            {
                switch (FormaCondSian)
                {
                    case SianWebSrv.Utils.TipiFormeConduzione.fcManoExtrafamiPrev:
                        return 3;
                    case SianWebSrv.Utils.TipiFormeConduzione.fcManoFamiPrev:
                        return 2;
                    case SianWebSrv.Utils.TipiFormeConduzione.fcNonDireAltraForma:
                        return 6;
                    case SianWebSrv.Utils.TipiFormeConduzione.fcNonDireConSalar:
                        return 4;
                    case SianWebSrv.Utils.TipiFormeConduzione.fcNonSpecificato:
                        return 1;
                    case SianWebSrv.Utils.TipiFormeConduzione.fcSolaManoFami:
                        return 6;
                    default:
                        return 1;
                }
            }

            public static int SianMisuToSiarm(TipiMisura MisuraSian)
            {
                switch (MisuraSian)
                {
                    case TipiMisura.m2078:
                        return 50;
                    case TipiMisura.m211:
                        return 65;
                    case TipiMisura.m212:
                        return 66;
                    case TipiMisura.m213:
                        return 67;
                    case TipiMisura.m214:
                        return 68;
                    case TipiMisura.m215:
                        return 69;
                    case TipiMisura.mE:
                        return 8;
                    case TipiMisura.mF1:
                        return 9;
                    case TipiMisura.mF2:
                        return 10;
                    case TipiMisura.mF2b:
                        return 49;
                    case TipiMisura.mF5:
                        return 12;
                    default:
                        return 0;
                }
            }

            public static int SianValueToInt(string SianValue, ActionOnInvalidValue InvalidValueAction)
            {
                try
                {
                    return System.Convert.ToInt32(SianValue);
                }
                catch (System.Exception e)
                {
                    switch (InvalidValueAction)
                    {
                        case ActionOnInvalidValue.acNullValue: return 0;
                        default :
                            throw new System.Exception("Sian ha restituito il valore [" + SianValue + "] in campo che dovrebbe essere un numero intero: " + e.Message);
                    }
                }
            }
            public static int SianValueToInt(string SianValue){
                return SianValueToInt(SianValue, ActionOnInvalidValue.acNullValue); 
            }


            public static bool SianValueToBool(string SianValue, ActionOnInvalidValue InvalidValueAction)
            {
                    switch (SianValue.Trim().ToUpper())
                    {
                        case "0": return false;
                        case "1": return true;
                        case "TRUE": return true;
                        case "FALSE": return false;
                    }
                    switch (InvalidValueAction)
                    {
                        case ActionOnInvalidValue.acNullValue: return false;
                        default:
                            throw new System.Exception("Sian ha restituito il valore [" + SianValue + "] in campo che dovrebbe contenere 0/1 True/False");
                    }
            }


        }



    }
}
