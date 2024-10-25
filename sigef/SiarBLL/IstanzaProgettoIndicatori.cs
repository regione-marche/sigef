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
    public class IstanzaProgettoIndicatori
    {
        private static XmlSerializer serializer;

        public LISTXML_PROGETTO_INDICATORI PROGETTO_INDICATORI { get; set; }

        public IstanzaProgettoIndicatori()
        {
            this.PROGETTO_INDICATORI = new LISTXML_PROGETTO_INDICATORI();
        }

        public IstanzaProgettoIndicatori(ProgettoIndicatoriCollection progetto_indicatori_coll)
        {
            this.PROGETTO_INDICATORI = new LISTXML_PROGETTO_INDICATORI();

            foreach (ProgettoIndicatori ind in progetto_indicatori_coll)
            {
                PROGETTO_INDICATORIType ind_type = new PROGETTO_INDICATORIType();
                ind_type.carica(ind);
                PROGETTO_INDICATORI.PROGETTO_INDICATORI_LIST.Add(ind_type);
            }
        }

        public IstanzaProgettoIndicatori(List<ProgettoIndicatori> progetto_indicatori_list)
        {
            this.PROGETTO_INDICATORI = new LISTXML_PROGETTO_INDICATORI();

            foreach (ProgettoIndicatori ind in progetto_indicatori_list)
            {
                PROGETTO_INDICATORIType ind_type = new PROGETTO_INDICATORIType();
                ind_type.carica(ind);
                PROGETTO_INDICATORI.PROGETTO_INDICATORI_LIST.Add(ind_type);
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(IstanzaProgettoIndicatori));
                }
                return serializer;
            }
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current IstanzaProgettoIndicatori object into an XML string
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
        /// Deserializes workflow markup into an IstanzaProgettoIndicatori object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output IstanzaProgettoIndicatori object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out IstanzaProgettoIndicatori obj, out System.Exception exception)
        {
            exception = null;
            obj = default(IstanzaProgettoIndicatori);
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

        public static bool Deserialize(string input, out IstanzaProgettoIndicatori obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static IstanzaProgettoIndicatori Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((IstanzaProgettoIndicatori)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static IstanzaProgettoIndicatori Deserialize(System.IO.Stream s)
        {
            return ((IstanzaProgettoIndicatori)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current IstanzaProgettoIndicatori object into file
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
        /// Deserializes xml markup from file into an IstanzaProgettoIndicatori object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output IstanzaProgettoIndicatori object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out IstanzaProgettoIndicatori obj, out System.Exception exception)
        {
            exception = null;
            obj = default(IstanzaProgettoIndicatori);
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

        public static bool LoadFromFile(string fileName, out IstanzaProgettoIndicatori obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static IstanzaProgettoIndicatori LoadFromFile(string fileName)
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
        /// Create a clone of this IstanzaProgettoIndicatori object
        /// </summary>
        public virtual IstanzaProgettoIndicatori Clone()
        {
            return ((IstanzaProgettoIndicatori)(this.MemberwiseClone()));
        }
        #endregion
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public class PROGETTO_INDICATORIType
    {

        private static XmlSerializer serializer;

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<int> ID_PROGETTO_INDICATORI { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<int> ID_DIM_X_PROGRAMMAZIONE { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<int> ID_PROGETTO { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<int> ID_DOMANDA_PAGAMENTO { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<int> ID_VARIANTE { get; set; }

        public string COD_TIPO { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<decimal> VALORE_PROGRAMMATO_RICHIESTO { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<decimal> VALORE_REALIZZATO_RICHIESTO { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> DATA_REGISTRAZIONE { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<int> OPERATORE { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<decimal> VALORE_PROGRAMMATO_AMMESSO { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<decimal> VALORE_REALIZZATO_AMMESSO { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> DATA_ISTRUTTORIA { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<int> ISTRUTTORE { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string DIM_DESCRIZIONE { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string DIM_UM { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string RICHIEDIBILE { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string PROCEDURA_CALCOLO { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string DIM_CODICE { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<int> ID_PROGRAMMAZIONE { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string PROGRAMMAZIONE_CODICE { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string PROGRAMMAZIONE_DESCRIZIONE { get; set; }

        public void carica(SiarLibrary.ProgettoIndicatori progettoIndicatori)
        {
            ID_PROGETTO_INDICATORI = progettoIndicatori.IdProgettoIndicatori;
            ID_DIM_X_PROGRAMMAZIONE = progettoIndicatori.IdDimXProgrammazione;
            ID_PROGETTO = progettoIndicatori.IdProgetto;
            ID_DOMANDA_PAGAMENTO = progettoIndicatori.IdDomandaPagamento;
            ID_VARIANTE = progettoIndicatori.IdVariante;
            COD_TIPO = progettoIndicatori.CodTipo;
            VALORE_PROGRAMMATO_RICHIESTO = progettoIndicatori.ValoreProgrammatoRichiesto;
            VALORE_REALIZZATO_RICHIESTO = progettoIndicatori.ValoreRealizzatoRichiesto;
            DATA_REGISTRAZIONE = progettoIndicatori.DataRegistrazione;
            OPERATORE = progettoIndicatori.Operatore;
            VALORE_PROGRAMMATO_AMMESSO = progettoIndicatori.ValoreProgrammatoAmmesso;
            VALORE_REALIZZATO_AMMESSO = progettoIndicatori.ValoreRealizzatoAmmesso;
            DATA_ISTRUTTORIA = progettoIndicatori.DataIstruttoria;
            ISTRUTTORE = progettoIndicatori.Istruttore;
            DIM_DESCRIZIONE = progettoIndicatori.DimDescrizione;
            DIM_UM = progettoIndicatori.DimUm;
            RICHIEDIBILE = progettoIndicatori.Richiedibile;
            PROCEDURA_CALCOLO = progettoIndicatori.ProceduraCalcolo;
            DIM_CODICE = progettoIndicatori.DimCodice;
            ID_PROGRAMMAZIONE = progettoIndicatori.IdProgrammazione;
            PROGRAMMAZIONE_CODICE = progettoIndicatori.ProgrammazioneCodice;
            PROGRAMMAZIONE_DESCRIZIONE = progettoIndicatori.ProgrammazioneDescrizione;
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(PROGETTO_INDICATORIType));
                }
                return serializer;
            }
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current PROGETTO_INDICATORIType object into an XML string
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
        /// Deserializes workflow markup into an PROGETTO_INDICATORIType object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output PROGETTO_INDICATORIType object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out PROGETTO_INDICATORIType obj, out System.Exception exception)
        {
            exception = null;
            obj = default(PROGETTO_INDICATORIType);
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

        public static bool Deserialize(string input, out PROGETTO_INDICATORIType obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static PROGETTO_INDICATORIType Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((PROGETTO_INDICATORIType)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static PROGETTO_INDICATORIType Deserialize(System.IO.Stream s)
        {
            return ((PROGETTO_INDICATORIType)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current PROGETTO_INDICATORIType object into file
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
        /// Deserializes xml markup from file into an PROGETTO_INDICATORIType object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output PROGETTO_INDICATORIType object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out PROGETTO_INDICATORIType obj, out System.Exception exception)
        {
            exception = null;
            obj = default(PROGETTO_INDICATORIType);
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

        public static bool LoadFromFile(string fileName, out PROGETTO_INDICATORIType obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static PROGETTO_INDICATORIType LoadFromFile(string fileName)
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
        /// Create a clone of this PROGETTO_INDICATORIType object
        /// </summary>
        public virtual PROGETTO_INDICATORIType Clone()
        {
            return ((PROGETTO_INDICATORIType)(this.MemberwiseClone()));
        }
        #endregion
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class LISTXML_PROGETTO_INDICATORI
    {

        private static XmlSerializer serializer;

        [System.Xml.Serialization.XmlElementAttribute("PROGETTO_INDICATORI")]
        public List<PROGETTO_INDICATORIType> PROGETTO_INDICATORI_LIST { get; set; }

        public LISTXML_PROGETTO_INDICATORI()
        {
            this.PROGETTO_INDICATORI_LIST = new List<PROGETTO_INDICATORIType>();
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(LISTXML_PROGETTO_INDICATORI));
                }
                return serializer;
            }
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current LISTXML_PROGETTO_INDICATORI object into an XML string
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
        /// Deserializes workflow markup into an LISTXML_PROGETTO_INDICATORI object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output LISTXML_PROGETTO_INDICATORI object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out LISTXML_PROGETTO_INDICATORI obj, out System.Exception exception)
        {
            exception = null;
            obj = default(LISTXML_PROGETTO_INDICATORI);
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

        public static bool Deserialize(string input, out LISTXML_PROGETTO_INDICATORI obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static LISTXML_PROGETTO_INDICATORI Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((LISTXML_PROGETTO_INDICATORI)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static LISTXML_PROGETTO_INDICATORI Deserialize(System.IO.Stream s)
        {
            return ((LISTXML_PROGETTO_INDICATORI)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current LISTXML_PROGETTO_INDICATORI object into file
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
        /// Deserializes xml markup from file into an LISTXML_PROGETTO_INDICATORI object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output LISTXML_PROGETTO_INDICATORI object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out LISTXML_PROGETTO_INDICATORI obj, out System.Exception exception)
        {
            exception = null;
            obj = default(LISTXML_PROGETTO_INDICATORI);
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

        public static bool LoadFromFile(string fileName, out LISTXML_PROGETTO_INDICATORI obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static LISTXML_PROGETTO_INDICATORI LoadFromFile(string fileName)
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
        /// Create a clone of this LISTXML_PROGETTO_INDICATORI object
        /// </summary>
        public virtual LISTXML_PROGETTO_INDICATORI Clone()
        {
            return ((LISTXML_PROGETTO_INDICATORI)(this.MemberwiseClone()));
        }
        #endregion
    }
}
