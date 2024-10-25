using System;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Collections;
using System.Xml.Schema;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Xml;
using System.Collections.Generic;
using SiarLibrary;

namespace SiarBLL
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class IstanzaPrioritaXProgetto
    {
        private static XmlSerializer serializer;

        public LISTXML_PRIORITAXPROGETTO PRIORITAXPROGETTO { get; set; }

        public IstanzaPrioritaXProgetto()
        {
            this.PRIORITAXPROGETTO = new LISTXML_PRIORITAXPROGETTO();
        }

        public IstanzaPrioritaXProgetto(PrioritaXProgettoCollection priorita_x_progetto_coll)
        {
            this.PRIORITAXPROGETTO = new LISTXML_PRIORITAXPROGETTO();

            foreach (PrioritaXProgetto pxp in priorita_x_progetto_coll)
            {
                PRIORITA_X_PROGETTOType prio_type = new PRIORITA_X_PROGETTOType();
                prio_type.carica(pxp);
                PRIORITAXPROGETTO.PRIORITA_X_PROGETTO_LIST.Add(prio_type);
            }
        }

        public IstanzaPrioritaXProgetto(List<PrioritaXProgetto> priorita_x_progetto_list)
        {
            this.PRIORITAXPROGETTO = new LISTXML_PRIORITAXPROGETTO();

            foreach (PrioritaXProgetto pxp in priorita_x_progetto_list)
            {
                PRIORITA_X_PROGETTOType prio_type = new PRIORITA_X_PROGETTOType();
                prio_type.carica(pxp);
                PRIORITAXPROGETTO.PRIORITA_X_PROGETTO_LIST.Add(prio_type);
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(IstanzaPrioritaXProgetto));
                }
                return serializer;
            }
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current IstanzaPrioritaXProgetto object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                xmlWriterSettings.OmitXmlDeclaration = true;
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an IstanzaPrioritaXProgetto object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output IstanzaPrioritaXProgetto object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out IstanzaPrioritaXProgetto obj, out System.Exception exception)
        {
            exception = null;
            obj = default(IstanzaPrioritaXProgetto);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out IstanzaPrioritaXProgetto obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static IstanzaPrioritaXProgetto Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((IstanzaPrioritaXProgetto)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static IstanzaPrioritaXProgetto Deserialize(System.IO.Stream s)
        {
            return ((IstanzaPrioritaXProgetto)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current IstanzaPrioritaXProgetto object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an IstanzaPrioritaXProgetto object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output IstanzaPrioritaXProgetto object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out IstanzaPrioritaXProgetto obj, out System.Exception exception)
        {
            exception = null;
            obj = default(IstanzaPrioritaXProgetto);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out IstanzaPrioritaXProgetto obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static IstanzaPrioritaXProgetto LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }

        #region Clone method
        /// <summary>
        /// Create a clone of this IstanzaPrioritaXProgetto object
        /// </summary>
        public virtual IstanzaPrioritaXProgetto Clone()
        {
            return ((IstanzaPrioritaXProgetto)(this.MemberwiseClone()));
        }
        #endregion
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public class PRIORITA_X_PROGETTOType
    {

        private static XmlSerializer serializer;

        public int ID_PROGETTO { get; set; }

        public int ID_PRIORITA { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<decimal> VALORE { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> DATA_VALUTAZIONE { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string OPERATORE_VALUTAZIONE { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<bool> MODIFICA_MANUALE { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string PRIORITA { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string COD_LIVELLO { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<bool> PLURI_VALORE { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string EVAL { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<bool> FLAG_MANUALE { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string VALORE_DESC { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<int> ID_VALORE { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<decimal> PUNTEGGIO { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<bool> INPUT_NUMERICO { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string MISURA { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<bool> DATETIME { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<bool> TESTO_SEMPLICE { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<bool> TESTO_AREA { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<bool> PLURI_VALORE_SQL { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string QUERY_PLURIVALORE { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> VAL_DATA { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string VAL_TESTO { get; set; }

        public void carica(SiarLibrary.PrioritaXProgetto prio_x_prog)
        {
            ID_PROGETTO = prio_x_prog.IdProgetto;
            ID_PRIORITA = prio_x_prog.IdPriorita;
            VALORE = prio_x_prog.Valore;
            DATA_VALUTAZIONE = prio_x_prog.DataValutazione;
            OPERATORE_VALUTAZIONE = prio_x_prog.OperatoreValutazione;
            MODIFICA_MANUALE = prio_x_prog.ModificaManuale;
            PRIORITA = prio_x_prog.Priorita;
            COD_LIVELLO = prio_x_prog.CodLivello;
            PLURI_VALORE = prio_x_prog.PluriValore;
            EVAL = prio_x_prog.Eval;
            FLAG_MANUALE = prio_x_prog.FlagManuale;
            VALORE_DESC = prio_x_prog.ValoreDesc;
            ID_VALORE = prio_x_prog.IdValore;
            PUNTEGGIO = prio_x_prog.Punteggio;
            INPUT_NUMERICO = prio_x_prog.InputNumerico;
            MISURA = prio_x_prog.Misura;
            DATETIME = prio_x_prog.Datetime;
            TESTO_SEMPLICE = prio_x_prog.TestoSemplice;
            TESTO_AREA = prio_x_prog.TestoArea;
            PLURI_VALORE_SQL = prio_x_prog.PluriValoreSql;
            QUERY_PLURIVALORE = prio_x_prog.QueryPlurivalore;
            VAL_DATA = prio_x_prog.ValData;
            VAL_TESTO = prio_x_prog.ValTesto;
        }

        public SiarLibrary.PrioritaXProgetto scarica()
        {
            var prio_x_prog = new PrioritaXProgetto();

            prio_x_prog.IdProgetto = ID_PROGETTO;
            prio_x_prog.IdPriorita = ID_PRIORITA;
            prio_x_prog.Valore = VALORE;
            prio_x_prog.DataValutazione = DATA_VALUTAZIONE;
            prio_x_prog.OperatoreValutazione = OPERATORE_VALUTAZIONE;
            prio_x_prog.ModificaManuale = MODIFICA_MANUALE;
            prio_x_prog.Priorita = PRIORITA;
            prio_x_prog.CodLivello = COD_LIVELLO;
            prio_x_prog.PluriValore = PLURI_VALORE;
            prio_x_prog.Eval = EVAL;
            prio_x_prog.FlagManuale = FLAG_MANUALE;
            prio_x_prog.ValoreDesc = VALORE_DESC;
            prio_x_prog.IdValore = ID_VALORE;
            prio_x_prog.Punteggio = PUNTEGGIO;
            prio_x_prog.InputNumerico = INPUT_NUMERICO;
            prio_x_prog.Misura = MISURA;
            prio_x_prog.Datetime = DATETIME;
            prio_x_prog.TestoSemplice = TESTO_SEMPLICE;
            prio_x_prog.TestoArea = TESTO_AREA;
            prio_x_prog.PluriValoreSql = PLURI_VALORE_SQL;
            prio_x_prog.QueryPlurivalore = QUERY_PLURIVALORE;
            prio_x_prog.ValData = VAL_DATA;
            prio_x_prog.ValTesto = VAL_TESTO;

            return prio_x_prog;
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(PRIORITA_X_PROGETTOType));
                }
                return serializer;
            }
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current PRIORITA_X_PROGETTOType object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                xmlWriterSettings.OmitXmlDeclaration = true;
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an PRIORITA_X_PROGETTOType object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output PRIORITA_X_PROGETTOType object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out PRIORITA_X_PROGETTOType obj, out System.Exception exception)
        {
            exception = null;
            obj = default(PRIORITA_X_PROGETTOType);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out PRIORITA_X_PROGETTOType obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static PRIORITA_X_PROGETTOType Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((PRIORITA_X_PROGETTOType)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static PRIORITA_X_PROGETTOType Deserialize(System.IO.Stream s)
        {
            return ((PRIORITA_X_PROGETTOType)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current PRIORITA_X_PROGETTOType object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an PRIORITA_X_PROGETTOType object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output PRIORITA_X_PROGETTOType object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out PRIORITA_X_PROGETTOType obj, out System.Exception exception)
        {
            exception = null;
            obj = default(PRIORITA_X_PROGETTOType);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out PRIORITA_X_PROGETTOType obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static PRIORITA_X_PROGETTOType LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }

        #region Clone method
        /// <summary>
        /// Create a clone of this PRIORITA_X_PROGETTOType object
        /// </summary>
        public virtual PRIORITA_X_PROGETTOType Clone()
        {
            return ((PRIORITA_X_PROGETTOType)(this.MemberwiseClone()));
        }
        #endregion
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class LISTXML_PRIORITAXPROGETTO
    {

        private static XmlSerializer serializer;

        [System.Xml.Serialization.XmlElementAttribute("PRIORITA_X_PROGETTO")]
        public List<PRIORITA_X_PROGETTOType> PRIORITA_X_PROGETTO_LIST { get; set; }

        public LISTXML_PRIORITAXPROGETTO()
        {
            this.PRIORITA_X_PROGETTO_LIST = new List<PRIORITA_X_PROGETTOType>();
        }

        public PrioritaXProgettoCollection scaricaCollection()
        {
            var priorita_coll = new PrioritaXProgettoCollection();

            foreach (PRIORITA_X_PROGETTOType p in this.PRIORITA_X_PROGETTO_LIST)
            {
                var priorita = p.scarica();
                priorita_coll.Add(priorita);
            }

            return priorita_coll;
        }

        public List<PrioritaXProgetto> scaricaList()
        {
            var priorita_list = scaricaCollection().ToArrayList<PrioritaXProgetto>();

            return priorita_list;
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(LISTXML_PRIORITAXPROGETTO));
                }
                return serializer;
            }
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current LISTXML_PRIORITAXPROGETTO object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                xmlWriterSettings.OmitXmlDeclaration = true;
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an LISTXML_PRIORITAXPROGETTO object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output LISTXML_PRIORITAXPROGETTO object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out LISTXML_PRIORITAXPROGETTO obj, out System.Exception exception)
        {
            exception = null;
            obj = default(LISTXML_PRIORITAXPROGETTO);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out LISTXML_PRIORITAXPROGETTO obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static LISTXML_PRIORITAXPROGETTO Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((LISTXML_PRIORITAXPROGETTO)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static LISTXML_PRIORITAXPROGETTO Deserialize(System.IO.Stream s)
        {
            return ((LISTXML_PRIORITAXPROGETTO)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current LISTXML_PRIORITAXPROGETTO object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an LISTXML_PRIORITAXPROGETTO object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output LISTXML_PRIORITAXPROGETTO object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out LISTXML_PRIORITAXPROGETTO obj, out System.Exception exception)
        {
            exception = null;
            obj = default(LISTXML_PRIORITAXPROGETTO);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out LISTXML_PRIORITAXPROGETTO obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static LISTXML_PRIORITAXPROGETTO LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }

        #region Clone method
        /// <summary>
        /// Create a clone of this LISTXML_PRIORITAXPROGETTO object
        /// </summary>
        public virtual LISTXML_PRIORITAXPROGETTO Clone()
        {
            return ((LISTXML_PRIORITAXPROGETTO)(this.MemberwiseClone()));
        }
        #endregion
    }
}
