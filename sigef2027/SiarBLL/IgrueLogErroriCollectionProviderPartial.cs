using System.Data;
using System.Data.SqlClient;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class IgrueLogErroriCollectionProvider : IIgrueLogErroriProvider
    {
        //GetByIdInvioSenzaFile: popola la collection senza file
        public IgrueLogErroriCollection GetByIdInvioSenzaFile(IntNT IdinvioEqualThis, string CodiceFondoEqualThis)
        {
            IgrueLogErroriCollection igruee_log_collection = new IgrueLogErroriCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ZIgrueLogErroriFindGetbyidinvioSenzaFile";
            
            int id_invio;
            if (IdinvioEqualThis != null)
            {
                id_invio = IdinvioEqualThis;
                cmd.Parameters.Add(new SqlParameter("@IdInvioequalthis", id_invio));
            }

            if (CodiceFondoEqualThis != null && CodiceFondoEqualThis != "")
                cmd.Parameters.Add(new SqlParameter("@CodiceFondoEqualThis", CodiceFondoEqualThis));

            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
                igruee_log_collection.Add(IgrueLogErroriDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();

            return igruee_log_collection;
        }
    }


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class LogRoot
    {

        private string idTicketField;

        private string idInvioField;

        private LogRecord[] logEntryField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string IdTicket
        {
            get
            {
                return this.idTicketField;
            }
            set
            {
                this.idTicketField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string IdInvio
        {
            get
            {
                return this.idInvioField;
            }
            set
            {
                this.idInvioField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("LogRecord", typeof(LogRecord), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public LogRecord[] LogEntry
        {
            get
            {
                return this.logEntryField;
            }
            set
            {
                this.logEntryField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class LogRecord 
    {

        private string tipoFileField;

        private string idBandoField;

        private string idProgettoField;

        private string numeroRigaField;

        private string codiceGruppoField;

        private string codiceErroreField;

        private string descrizioneErroreField;

        private string campoTracciatoField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string TipoFile
        {
            get
            {
                return this.tipoFileField;
            }
            set
            {
                this.tipoFileField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string IdBando
        {
            get
            {
                return this.idBandoField;
            }
            set
            {
                this.idBandoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string IdProgetto
        {
            get
            {
                return this.idProgettoField;
            }
            set
            {
                this.idProgettoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string NumeroRiga
        {
            get
            {
                return this.numeroRigaField;
            }
            set
            {
                this.numeroRigaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string CodiceGruppo
        {
            get
            {
                return this.codiceGruppoField;
            }
            set
            {
                this.codiceGruppoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string CodiceErrore
        {
            get
            {
                return this.codiceErroreField;
            }
            set
            {
                this.codiceErroreField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string DescrizioneErrore
        {
            get
            {
                return this.descrizioneErroreField;
            }
            set
            {
                this.descrizioneErroreField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string CampoTracciato
        {
            get
            {
                return this.campoTracciatoField;
            }
            set
            {
                this.campoTracciatoField = value;
            }
        }
    }

    public partial class LogRecordCollection : CustomCollection
    {
        //Costruttore
        public LogRecordCollection()
		{
			this.ItemType = typeof(LogRecord);
		}

        //Get e Set
        public new LogRecord this[int index]
        {
            get { return (LogRecord)(base[index]); }
            set
            {
                base[index] = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class NewDataSet
    {

        private LogRoot[] itemsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LogRoot")]
        public LogRoot[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }
    }

}
