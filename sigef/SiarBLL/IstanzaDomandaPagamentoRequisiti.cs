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
    public class IstanzaDomandaPagamentoRequisiti
    {
        private static XmlSerializer serializer;

        public LISTXML_DOMANDAPAGAMENTOREQUISITI DOMANDAPAGAMENTOREQUISITI { get; set; }

        public IstanzaDomandaPagamentoRequisiti()
        {
            this.DOMANDAPAGAMENTOREQUISITI = new LISTXML_DOMANDAPAGAMENTOREQUISITI();
        }

        public IstanzaDomandaPagamentoRequisiti(DomandaPagamentoRequisitiCollection requisiti_coll)
        {
            this.DOMANDAPAGAMENTOREQUISITI = new LISTXML_DOMANDAPAGAMENTOREQUISITI();

            foreach (DomandaPagamentoRequisiti req in requisiti_coll)
            {
                DOMANDA_PAGAMENTO_REQUISITIType req_type = new DOMANDA_PAGAMENTO_REQUISITIType();
                req_type.carica(req);
                DOMANDAPAGAMENTOREQUISITI.DOMANDA_PAGAMENTO_REQUISITI_LIST.Add(req_type);
            }
        }

        public IstanzaDomandaPagamentoRequisiti(List<DomandaPagamentoRequisiti> requisiti_list)
        {
            this.DOMANDAPAGAMENTOREQUISITI = new LISTXML_DOMANDAPAGAMENTOREQUISITI();

            foreach (DomandaPagamentoRequisiti req in requisiti_list)
            {
                DOMANDA_PAGAMENTO_REQUISITIType req_type = new DOMANDA_PAGAMENTO_REQUISITIType();
                req_type.carica(req);
                DOMANDAPAGAMENTOREQUISITI.DOMANDA_PAGAMENTO_REQUISITI_LIST.Add(req_type);
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(IstanzaDomandaPagamentoRequisiti));
                }
                return serializer;
            }
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current IstanzaDomandaPagamentoRequisiti object into an XML string
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
        /// Deserializes workflow markup into an IstanzaDomandaPagamentoRequisiti object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output IstanzaDomandaPagamentoRequisiti object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out IstanzaDomandaPagamentoRequisiti obj, out System.Exception exception)
        {
            exception = null;
            obj = default(IstanzaDomandaPagamentoRequisiti);
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

        public static bool Deserialize(string input, out IstanzaDomandaPagamentoRequisiti obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static IstanzaDomandaPagamentoRequisiti Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((IstanzaDomandaPagamentoRequisiti)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static IstanzaDomandaPagamentoRequisiti Deserialize(System.IO.Stream s)
        {
            return ((IstanzaDomandaPagamentoRequisiti)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current IstanzaDomandaPagamentoRequisiti object into file
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
        /// Deserializes xml markup from file into an IstanzaDomandaPagamentoRequisiti object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output IstanzaDomandaPagamentoRequisiti object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out IstanzaDomandaPagamentoRequisiti obj, out System.Exception exception)
        {
            exception = null;
            obj = default(IstanzaDomandaPagamentoRequisiti);
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

        public static bool LoadFromFile(string fileName, out IstanzaDomandaPagamentoRequisiti obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static IstanzaDomandaPagamentoRequisiti LoadFromFile(string fileName)
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
        /// Create a clone of this IstanzaDomandaPagamentoRequisiti object
        /// </summary>
        public virtual IstanzaDomandaPagamentoRequisiti Clone()
        {
            return ((IstanzaDomandaPagamentoRequisiti)(this.MemberwiseClone()));
        }
        #endregion
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public class DOMANDA_PAGAMENTO_REQUISITIType
    {

        private static XmlSerializer serializer;

        public int ID_DOMANDA_PAGAMENTO { get; set; }

        public int ID_REQUISITO { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<int> ID_VALORE { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<decimal> VAL_NUMERICO { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> VAL_DATA { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string VAL_TESTO { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string ESITO { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> DATA_ESITO { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string DESCRIZIONE { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<bool> PLURIVALORE { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<bool> NUMERICO { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<bool> DATETIME { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<bool> TESTO_SEMPLICE { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<bool> TESTO_AREA { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string URL { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string QUERY_EVAL { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string QUERY_INSERT { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string MISURA { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string CODICE_VALORE { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string DESCRIZIONE_VALORE { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<bool> SELEZIONATO { get; set; }

        public void carica(SiarLibrary.DomandaPagamentoRequisiti requisito)
        {
            ID_DOMANDA_PAGAMENTO = requisito.IdDomandaPagamento;
            ID_REQUISITO = requisito.IdRequisito;
            ID_VALORE = requisito.IdValore;
            VAL_NUMERICO = requisito.ValNumerico;
            VAL_DATA = requisito.ValData;
            VAL_TESTO = requisito.ValTesto;
            ESITO = requisito.Esito;
            DATA_ESITO = requisito.DataEsito;
            DESCRIZIONE = requisito.Descrizione;
            PLURIVALORE = requisito.Plurivalore;
            NUMERICO = requisito.Numerico;
            DATETIME = requisito.Datetime;
            TESTO_SEMPLICE = requisito.TestoSemplice;
            TESTO_AREA = requisito.TestoArea;
            URL = requisito.Url;
            QUERY_EVAL = requisito.QueryEval;
            QUERY_INSERT = requisito.QueryInsert;
            MISURA = requisito.Misura;
            CODICE_VALORE = requisito.CodiceValore;
            DESCRIZIONE_VALORE = requisito.DescrizioneValore;
            SELEZIONATO = requisito.Selezionato;
        }

        public SiarLibrary.DomandaPagamentoRequisiti scarica()
        {
            var requisito = new SiarLibrary.DomandaPagamentoRequisiti();

            requisito.IdDomandaPagamento = ID_DOMANDA_PAGAMENTO;
            requisito.IdRequisito = ID_REQUISITO;
            requisito.IdValore = ID_VALORE;
            requisito.ValNumerico = VAL_NUMERICO;
            requisito.ValData = VAL_DATA;
            requisito.ValTesto = VAL_TESTO;
            requisito.Esito = ESITO;
            requisito.DataEsito = DATA_ESITO;
            requisito.Descrizione = DESCRIZIONE;
            requisito.Plurivalore = PLURIVALORE;
            requisito.Numerico = NUMERICO;
            requisito.Datetime = DATETIME;
            requisito.TestoSemplice = TESTO_SEMPLICE;
            requisito.TestoArea = TESTO_AREA;
            requisito.Url = URL;
            requisito.QueryEval = QUERY_EVAL;
            requisito.QueryInsert = QUERY_INSERT;
            requisito.Misura = MISURA;
            requisito.CodiceValore = CODICE_VALORE;
            requisito.DescrizioneValore = DESCRIZIONE_VALORE;
            requisito.Selezionato = SELEZIONATO;

            return requisito;
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(DOMANDA_PAGAMENTO_REQUISITIType));
                }
                return serializer;
            }
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current DOMANDA_PAGAMENTO_REQUISITIType object into an XML string
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
        /// Deserializes workflow markup into an DOMANDA_PAGAMENTO_REQUISITIType object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output DOMANDA_PAGAMENTO_REQUISITIType object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out DOMANDA_PAGAMENTO_REQUISITIType obj, out System.Exception exception)
        {
            exception = null;
            obj = default(DOMANDA_PAGAMENTO_REQUISITIType);
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

        public static bool Deserialize(string input, out DOMANDA_PAGAMENTO_REQUISITIType obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static DOMANDA_PAGAMENTO_REQUISITIType Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((DOMANDA_PAGAMENTO_REQUISITIType)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static DOMANDA_PAGAMENTO_REQUISITIType Deserialize(System.IO.Stream s)
        {
            return ((DOMANDA_PAGAMENTO_REQUISITIType)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current DOMANDA_PAGAMENTO_REQUISITIType object into file
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
        /// Deserializes xml markup from file into an DOMANDA_PAGAMENTO_REQUISITIType object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output DOMANDA_PAGAMENTO_REQUISITIType object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out DOMANDA_PAGAMENTO_REQUISITIType obj, out System.Exception exception)
        {
            exception = null;
            obj = default(DOMANDA_PAGAMENTO_REQUISITIType);
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

        public static bool LoadFromFile(string fileName, out DOMANDA_PAGAMENTO_REQUISITIType obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static DOMANDA_PAGAMENTO_REQUISITIType LoadFromFile(string fileName)
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
        /// Create a clone of this DOMANDA_PAGAMENTO_REQUISITIType object
        /// </summary>
        public virtual DOMANDA_PAGAMENTO_REQUISITIType Clone()
        {
            return ((DOMANDA_PAGAMENTO_REQUISITIType)(this.MemberwiseClone()));
        }
        #endregion
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class LISTXML_DOMANDAPAGAMENTOREQUISITI
    {

        private static XmlSerializer serializer;

        [System.Xml.Serialization.XmlElementAttribute("DOMANDA_PAGAMENTO_REQUISITI")]
        public List<DOMANDA_PAGAMENTO_REQUISITIType> DOMANDA_PAGAMENTO_REQUISITI_LIST { get; set; }

        public LISTXML_DOMANDAPAGAMENTOREQUISITI()
        {
            this.DOMANDA_PAGAMENTO_REQUISITI_LIST = new List<DOMANDA_PAGAMENTO_REQUISITIType>();
        }

        public DomandaPagamentoRequisitiCollection scaricaCollection()
        {
            var requisiti_coll = new DomandaPagamentoRequisitiCollection();

            foreach (DOMANDA_PAGAMENTO_REQUISITIType r in this.DOMANDA_PAGAMENTO_REQUISITI_LIST)
            {
                var requisito = r.scarica();
                requisiti_coll.Add(requisito);
            }

            return requisiti_coll;
        }

        public List<DomandaPagamentoRequisiti> scaricaList()
        {
            var requisiti_list = scaricaCollection().ToArrayList<DomandaPagamentoRequisiti>();

            return requisiti_list;
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(LISTXML_DOMANDAPAGAMENTOREQUISITI));
                }
                return serializer;
            }
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current LISTXML_DOMANDAPAGAMENTOREQUISITI object into an XML string
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
        /// Deserializes workflow markup into an LISTXML_DOMANDAPAGAMENTOREQUISITI object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output LISTXML_DOMANDAPAGAMENTOREQUISITI object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out LISTXML_DOMANDAPAGAMENTOREQUISITI obj, out System.Exception exception)
        {
            exception = null;
            obj = default(LISTXML_DOMANDAPAGAMENTOREQUISITI);
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

        public static bool Deserialize(string input, out LISTXML_DOMANDAPAGAMENTOREQUISITI obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static LISTXML_DOMANDAPAGAMENTOREQUISITI Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((LISTXML_DOMANDAPAGAMENTOREQUISITI)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static LISTXML_DOMANDAPAGAMENTOREQUISITI Deserialize(System.IO.Stream s)
        {
            return ((LISTXML_DOMANDAPAGAMENTOREQUISITI)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current LISTXML_DOMANDAPAGAMENTOREQUISITI object into file
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
        /// Deserializes xml markup from file into an LISTXML_DOMANDAPAGAMENTOREQUISITI object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output LISTXML_DOMANDAPAGAMENTOREQUISITI object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out LISTXML_DOMANDAPAGAMENTOREQUISITI obj, out System.Exception exception)
        {
            exception = null;
            obj = default(LISTXML_DOMANDAPAGAMENTOREQUISITI);
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

        public static bool LoadFromFile(string fileName, out LISTXML_DOMANDAPAGAMENTOREQUISITI obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static LISTXML_DOMANDAPAGAMENTOREQUISITI LoadFromFile(string fileName)
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
        /// Create a clone of this LISTXML_DOMANDAPAGAMENTOREQUISITI object
        /// </summary>
        public virtual LISTXML_DOMANDAPAGAMENTOREQUISITI Clone()
        {
            return ((LISTXML_DOMANDAPAGAMENTOREQUISITI)(this.MemberwiseClone()));
        }
        #endregion
    }
}
