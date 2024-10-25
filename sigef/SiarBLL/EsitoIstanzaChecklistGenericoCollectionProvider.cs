using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per EsitoIstanzaChecklistGenerico
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IEsitoIstanzaChecklistGenericoProvider
    {
        int Save(EsitoIstanzaChecklistGenerico EsitoIstanzaChecklistGenericoObj);
        int SaveCollection(EsitoIstanzaChecklistGenericoCollection collectionObj);
        int Delete(EsitoIstanzaChecklistGenerico EsitoIstanzaChecklistGenericoObj);
        int DeleteCollection(EsitoIstanzaChecklistGenericoCollection collectionObj);
    }
    /// <summary>
    /// Summary description for EsitoIstanzaChecklistGenerico
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class EsitoIstanzaChecklistGenerico : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdEsitoGenerico;
        private NullTypes.IntNT _IdVoceGenerica;
        private NullTypes.IntNT _IdIstanzaGenerica;
        private NullTypes.StringNT _CodEsito;
        private NullTypes.DatetimeNT _DataInserimento;
        private NullTypes.StringNT _CfInserimento;
        private NullTypes.DatetimeNT _DataModifica;
        private NullTypes.StringNT _CfModifica;
        private NullTypes.StringNT _Note;
        private NullTypes.StringNT _CodEsitoRevisore;
        private NullTypes.DatetimeNT _DataRevisore;
        private NullTypes.StringNT _Revisore;
        private NullTypes.StringNT _NoteRevisore;
        private NullTypes.BoolNT _EscludiDaComunicazione;
        private NullTypes.StringNT _Descrizione;
        private NullTypes.BoolNT _EsitoPositivo;
        private NullTypes.StringNT _DescrizioneEsitoRevisore;
        private NullTypes.BoolNT _EsitoPositivoRevisore;
        private NullTypes.StringNT _DescrizioneVoceGenerica;
        private NullTypes.BoolNT _Automatico;
        private NullTypes.StringNT _QuerySql;
        private NullTypes.StringNT _QuerySqlPost;
        private NullTypes.StringNT _CodeMethod;
        private NullTypes.StringNT _Url;
        private NullTypes.StringNT _ValMinimo;
        private NullTypes.StringNT _ValMassimo;
        private NullTypes.IntNT _Ordine;
        private NullTypes.BoolNT _Obbligatorio;
        private NullTypes.DecimalNT _Peso;
        private NullTypes.IntNT _IdChecklistGenerica;
        private NullTypes.StringNT _DescrizioneChecklistGenerica;
        private NullTypes.StringNT _Valore;
        private NullTypes.BoolNT _ValEsitoNegativo;
        private NullTypes.StringNT _Misura;
        private NullTypes.IntNT _IdVoceXChecklistGenerica;
        [NonSerialized]
        private IEsitoIstanzaChecklistGenericoProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IEsitoIstanzaChecklistGenericoProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public EsitoIstanzaChecklistGenerico()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:ID_ESITO_GENERICO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdEsitoGenerico
        {
            get { return _IdEsitoGenerico; }
            set
            {
                if (IdEsitoGenerico != value)
                {
                    _IdEsitoGenerico = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_VOCE_GENERICA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdVoceGenerica
        {
            get { return _IdVoceGenerica; }
            set
            {
                if (IdVoceGenerica != value)
                {
                    _IdVoceGenerica = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_ISTANZA_GENERICA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdIstanzaGenerica
        {
            get { return _IdIstanzaGenerica; }
            set
            {
                if (IdIstanzaGenerica != value)
                {
                    _IdIstanzaGenerica = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COD_ESITO
        /// Tipo sul db:CHAR(2)
        /// </summary>
        public NullTypes.StringNT CodEsito
        {
            get { return _CodEsito; }
            set
            {
                if (CodEsito != value)
                {
                    _CodEsito = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_INSERIMENTO
        /// Tipo sul db:DATETIME
        /// Default:(getdate())
        /// </summary>
        public NullTypes.DatetimeNT DataInserimento
        {
            get { return _DataInserimento; }
            set
            {
                if (DataInserimento != value)
                {
                    _DataInserimento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CF_INSERIMENTO
        /// Tipo sul db:CHAR(16)
        /// </summary>
        public NullTypes.StringNT CfInserimento
        {
            get { return _CfInserimento; }
            set
            {
                if (CfInserimento != value)
                {
                    _CfInserimento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_MODIFICA
        /// Tipo sul db:DATETIME
        /// Default:(getdate())
        /// </summary>
        public NullTypes.DatetimeNT DataModifica
        {
            get { return _DataModifica; }
            set
            {
                if (DataModifica != value)
                {
                    _DataModifica = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CF_MODIFICA
        /// Tipo sul db:CHAR(16)
        /// </summary>
        public NullTypes.StringNT CfModifica
        {
            get { return _CfModifica; }
            set
            {
                if (CfModifica != value)
                {
                    _CfModifica = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NOTE
        /// Tipo sul db:NTEXT
        /// </summary>
        public NullTypes.StringNT Note
        {
            get { return _Note; }
            set
            {
                if (Note != value)
                {
                    _Note = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COD_ESITO_REVISORE
        /// Tipo sul db:CHAR(2)
        /// </summary>
        public NullTypes.StringNT CodEsitoRevisore
        {
            get { return _CodEsitoRevisore; }
            set
            {
                if (CodEsitoRevisore != value)
                {
                    _CodEsitoRevisore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_REVISORE
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataRevisore
        {
            get { return _DataRevisore; }
            set
            {
                if (DataRevisore != value)
                {
                    _DataRevisore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:REVISORE
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT Revisore
        {
            get { return _Revisore; }
            set
            {
                if (Revisore != value)
                {
                    _Revisore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NOTE_REVISORE
        /// Tipo sul db:NTEXT
        /// </summary>
        public NullTypes.StringNT NoteRevisore
        {
            get { return _NoteRevisore; }
            set
            {
                if (NoteRevisore != value)
                {
                    _NoteRevisore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ESCLUDI_DA_COMUNICAZIONE
        /// Tipo sul db:BIT
        /// Default:((0))
        /// </summary>
        public NullTypes.BoolNT EscludiDaComunicazione
        {
            get { return _EscludiDaComunicazione; }
            set
            {
                if (EscludiDaComunicazione != value)
                {
                    _EscludiDaComunicazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DESCRIZIONE
        /// Tipo sul db:VARCHAR(50)
        /// </summary>
        public NullTypes.StringNT Descrizione
        {
            get { return _Descrizione; }
            set
            {
                if (Descrizione != value)
                {
                    _Descrizione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ESITO_POSITIVO
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT EsitoPositivo
        {
            get { return _EsitoPositivo; }
            set
            {
                if (EsitoPositivo != value)
                {
                    _EsitoPositivo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DESCRIZIONE_ESITO_REVISORE
        /// Tipo sul db:VARCHAR(50)
        /// </summary>
        public NullTypes.StringNT DescrizioneEsitoRevisore
        {
            get { return _DescrizioneEsitoRevisore; }
            set
            {
                if (DescrizioneEsitoRevisore != value)
                {
                    _DescrizioneEsitoRevisore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ESITO_POSITIVO_REVISORE
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT EsitoPositivoRevisore
        {
            get { return _EsitoPositivoRevisore; }
            set
            {
                if (EsitoPositivoRevisore != value)
                {
                    _EsitoPositivoRevisore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DESCRIZIONE_VOCE_GENERICA
        /// Tipo sul db:VARCHAR(8000)
        /// </summary>
        public NullTypes.StringNT DescrizioneVoceGenerica
        {
            get { return _DescrizioneVoceGenerica; }
            set
            {
                if (DescrizioneVoceGenerica != value)
                {
                    _DescrizioneVoceGenerica = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:AUTOMATICO
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT Automatico
        {
            get { return _Automatico; }
            set
            {
                if (Automatico != value)
                {
                    _Automatico = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:QUERY_SQL
        /// Tipo sul db:VARCHAR(8000)
        /// </summary>
        public NullTypes.StringNT QuerySql
        {
            get { return _QuerySql; }
            set
            {
                if (QuerySql != value)
                {
                    _QuerySql = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:QUERY_SQL_POST
        /// Tipo sul db:VARCHAR(300)
        /// </summary>
        public NullTypes.StringNT QuerySqlPost
        {
            get { return _QuerySqlPost; }
            set
            {
                if (QuerySqlPost != value)
                {
                    _QuerySqlPost = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CODE_METHOD
        /// Tipo sul db:VARCHAR(30)
        /// </summary>
        public NullTypes.StringNT CodeMethod
        {
            get { return _CodeMethod; }
            set
            {
                if (CodeMethod != value)
                {
                    _CodeMethod = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:URL
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT Url
        {
            get { return _Url; }
            set
            {
                if (Url != value)
                {
                    _Url = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:VAL_MINIMO
        /// Tipo sul db:VARCHAR(20)
        /// </summary>
        public NullTypes.StringNT ValMinimo
        {
            get { return _ValMinimo; }
            set
            {
                if (ValMinimo != value)
                {
                    _ValMinimo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:VAL_MASSIMO
        /// Tipo sul db:VARCHAR(20)
        /// </summary>
        public NullTypes.StringNT ValMassimo
        {
            get { return _ValMassimo; }
            set
            {
                if (ValMassimo != value)
                {
                    _ValMassimo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ORDINE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT Ordine
        {
            get { return _Ordine; }
            set
            {
                if (Ordine != value)
                {
                    _Ordine = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:OBBLIGATORIO
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT Obbligatorio
        {
            get { return _Obbligatorio; }
            set
            {
                if (Obbligatorio != value)
                {
                    _Obbligatorio = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:PESO
        /// Tipo sul db:DECIMAL(10,2)
        /// </summary>
        public NullTypes.DecimalNT Peso
        {
            get { return _Peso; }
            set
            {
                if (Peso != value)
                {
                    _Peso = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_CHECKLIST_GENERICA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdChecklistGenerica
        {
            get { return _IdChecklistGenerica; }
            set
            {
                if (IdChecklistGenerica != value)
                {
                    _IdChecklistGenerica = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DESCRIZIONE_CHECKLIST_GENERICA
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT DescrizioneChecklistGenerica
        {
            get { return _DescrizioneChecklistGenerica; }
            set
            {
                if (DescrizioneChecklistGenerica != value)
                {
                    _DescrizioneChecklistGenerica = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:VALORE
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT Valore
        {
            get { return _Valore; }
            set
            {
                if (Valore != value)
                {
                    _Valore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:VAL_ESITO_NEGATIVO
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT ValEsitoNegativo
        {
            get { return _ValEsitoNegativo; }
            set
            {
                if (ValEsitoNegativo != value)
                {
                    _ValEsitoNegativo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:MISURA
        /// Tipo sul db:VARCHAR(20)
        /// </summary>
        public NullTypes.StringNT Misura
        {
            get { return _Misura; }
            set
            {
                if (Misura != value)
                {
                    _Misura = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_VOCE_X_CHECKLIST_GENERICA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdVoceXChecklistGenerica
        {
            get { return _IdVoceXChecklistGenerica; }
            set
            {
                if (IdVoceXChecklistGenerica != value)
                {
                    _IdVoceXChecklistGenerica = value;
                    SetDirtyFlag();
                }
            }
        }


        //Get e Set dei campi 'ForeignKey'

        public int Save()
        {
            if (this.IsDirty)
            {
                return _provider.Save(this);
            }
            else
            {
                return 0;
            }
        }

        public int Delete()
        {
            return _provider.Delete(this);
        }

        //Get e Set dei campi 'aggiuntivi'

    }
}

namespace SiarLibrary
{

    /// <summary>
    /// Summary description for EsitoIstanzaChecklistGenericoCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class EsitoIstanzaChecklistGenericoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
    {

        //Serializzazione xml
        public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            info.AddValue("_count", this.Count);
            for (int i = 0; i < this.Count; i++)
            {
                info.AddValue(i.ToString(), this[i]);
            }
        }
        private EsitoIstanzaChecklistGenericoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((EsitoIstanzaChecklistGenerico)info.GetValue(i.ToString(), typeof(EsitoIstanzaChecklistGenerico)));
            }
        }

        //Costruttore
        public EsitoIstanzaChecklistGenericoCollection()
        {
            this.ItemType = typeof(EsitoIstanzaChecklistGenerico);
        }

        //Costruttore con provider
        public EsitoIstanzaChecklistGenericoCollection(IEsitoIstanzaChecklistGenericoProvider providerObj)
        {
            this.ItemType = typeof(EsitoIstanzaChecklistGenerico);
            this.Provider = providerObj;
        }

        //Get e Set
        public new EsitoIstanzaChecklistGenerico this[int index]
        {
            get { return (EsitoIstanzaChecklistGenerico)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new EsitoIstanzaChecklistGenericoCollection GetChanges()
        {
            return (EsitoIstanzaChecklistGenericoCollection)base.GetChanges();
        }

        [NonSerialized]
        private IEsitoIstanzaChecklistGenericoProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IEsitoIstanzaChecklistGenericoProvider Provider
        {
            get { return _provider; }
            set
            {
                _provider = value;
                for (int i = 0; i < this.Count; i++)
                {
                    this[i].Provider = value;
                }
            }
        }

        public int SaveCollection()
        {
            return _provider.SaveCollection(this);
        }
        public int DeleteCollection()
        {
            return _provider.DeleteCollection(this);
        }
        //Add
        public int Add(EsitoIstanzaChecklistGenerico EsitoIstanzaChecklistGenericoObj)
        {
            if (EsitoIstanzaChecklistGenericoObj.Provider == null) EsitoIstanzaChecklistGenericoObj.Provider = this.Provider;
            return base.Add(EsitoIstanzaChecklistGenericoObj);
        }

        //AddCollection
        public void AddCollection(EsitoIstanzaChecklistGenericoCollection EsitoIstanzaChecklistGenericoCollectionObj)
        {
            foreach (EsitoIstanzaChecklistGenerico EsitoIstanzaChecklistGenericoObj in EsitoIstanzaChecklistGenericoCollectionObj)
                this.Add(EsitoIstanzaChecklistGenericoObj);
        }

        //Insert
        public void Insert(int index, EsitoIstanzaChecklistGenerico EsitoIstanzaChecklistGenericoObj)
        {
            if (EsitoIstanzaChecklistGenericoObj.Provider == null) EsitoIstanzaChecklistGenericoObj.Provider = this.Provider;
            base.Insert(index, EsitoIstanzaChecklistGenericoObj);
        }

        //CollectionGetById
        public EsitoIstanzaChecklistGenerico CollectionGetById(NullTypes.IntNT IdEsitoGenericoValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdEsitoGenerico == IdEsitoGenericoValue))
                    find = true;
                else
                    i++;
            }
            if (find)
                return this[i];
            else
                return null;
        }
        //filter: effettua una ricerca all'interno della collection
        // se il parametro di ricerca è null, prende tutto,
        // anche i record che hanno quel campo null
        // altrimenti scarta i record che hanno quel campo null ...
        // ...e confronta gli altri
        public EsitoIstanzaChecklistGenericoCollection SubSelect(NullTypes.IntNT IdEsitoGenericoEqualThis, NullTypes.IntNT IdVoceGenericaEqualThis, NullTypes.IntNT IdIstanzaGenericaEqualThis,
NullTypes.StringNT CodEsitoEqualThis, NullTypes.StringNT ValoreEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis,
NullTypes.StringNT CfInserimentoEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.StringNT CfModificaEqualThis,
NullTypes.StringNT CodEsitoRevisoreEqualThis, NullTypes.DatetimeNT DataRevisoreEqualThis, NullTypes.StringNT RevisoreEqualThis,
NullTypes.BoolNT EscludiDaComunicazioneEqualThis)
        {
            EsitoIstanzaChecklistGenericoCollection EsitoIstanzaChecklistGenericoCollectionTemp = new EsitoIstanzaChecklistGenericoCollection();
            foreach (EsitoIstanzaChecklistGenerico EsitoIstanzaChecklistGenericoItem in this)
            {
                if (((IdEsitoGenericoEqualThis == null) || ((EsitoIstanzaChecklistGenericoItem.IdEsitoGenerico != null) && (EsitoIstanzaChecklistGenericoItem.IdEsitoGenerico.Value == IdEsitoGenericoEqualThis.Value))) && ((IdVoceGenericaEqualThis == null) || ((EsitoIstanzaChecklistGenericoItem.IdVoceGenerica != null) && (EsitoIstanzaChecklistGenericoItem.IdVoceGenerica.Value == IdVoceGenericaEqualThis.Value))) && ((IdIstanzaGenericaEqualThis == null) || ((EsitoIstanzaChecklistGenericoItem.IdIstanzaGenerica != null) && (EsitoIstanzaChecklistGenericoItem.IdIstanzaGenerica.Value == IdIstanzaGenericaEqualThis.Value))) &&
((CodEsitoEqualThis == null) || ((EsitoIstanzaChecklistGenericoItem.CodEsito != null) && (EsitoIstanzaChecklistGenericoItem.CodEsito.Value == CodEsitoEqualThis.Value))) && ((ValoreEqualThis == null) || ((EsitoIstanzaChecklistGenericoItem.Valore != null) && (EsitoIstanzaChecklistGenericoItem.Valore.Value == ValoreEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((EsitoIstanzaChecklistGenericoItem.DataInserimento != null) && (EsitoIstanzaChecklistGenericoItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) &&
((CfInserimentoEqualThis == null) || ((EsitoIstanzaChecklistGenericoItem.CfInserimento != null) && (EsitoIstanzaChecklistGenericoItem.CfInserimento.Value == CfInserimentoEqualThis.Value))) && ((DataModificaEqualThis == null) || ((EsitoIstanzaChecklistGenericoItem.DataModifica != null) && (EsitoIstanzaChecklistGenericoItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((CfModificaEqualThis == null) || ((EsitoIstanzaChecklistGenericoItem.CfModifica != null) && (EsitoIstanzaChecklistGenericoItem.CfModifica.Value == CfModificaEqualThis.Value))) &&
((CodEsitoRevisoreEqualThis == null) || ((EsitoIstanzaChecklistGenericoItem.CodEsitoRevisore != null) && (EsitoIstanzaChecklistGenericoItem.CodEsitoRevisore.Value == CodEsitoRevisoreEqualThis.Value))) && ((DataRevisoreEqualThis == null) || ((EsitoIstanzaChecklistGenericoItem.DataRevisore != null) && (EsitoIstanzaChecklistGenericoItem.DataRevisore.Value == DataRevisoreEqualThis.Value))) && ((RevisoreEqualThis == null) || ((EsitoIstanzaChecklistGenericoItem.Revisore != null) && (EsitoIstanzaChecklistGenericoItem.Revisore.Value == RevisoreEqualThis.Value))) &&
((EscludiDaComunicazioneEqualThis == null) || ((EsitoIstanzaChecklistGenericoItem.EscludiDaComunicazione != null) && (EsitoIstanzaChecklistGenericoItem.EscludiDaComunicazione.Value == EscludiDaComunicazioneEqualThis.Value))))
                {
                    EsitoIstanzaChecklistGenericoCollectionTemp.Add(EsitoIstanzaChecklistGenericoItem);
                }
            }
            return EsitoIstanzaChecklistGenericoCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for EsitoIstanzaChecklistGenericoDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class EsitoIstanzaChecklistGenericoDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, EsitoIstanzaChecklistGenerico EsitoIstanzaChecklistGenericoObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdEsitoGenerico", EsitoIstanzaChecklistGenericoObj.IdEsitoGenerico);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "IdVoceGenerica", EsitoIstanzaChecklistGenericoObj.IdVoceGenerica);
            DbProvider.SetCmdParam(cmd, firstChar + "IdIstanzaGenerica", EsitoIstanzaChecklistGenericoObj.IdIstanzaGenerica);
            DbProvider.SetCmdParam(cmd, firstChar + "CodEsito", EsitoIstanzaChecklistGenericoObj.CodEsito);
            DbProvider.SetCmdParam(cmd, firstChar + "DataInserimento", EsitoIstanzaChecklistGenericoObj.DataInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "CfInserimento", EsitoIstanzaChecklistGenericoObj.CfInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", EsitoIstanzaChecklistGenericoObj.DataModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "CfModifica", EsitoIstanzaChecklistGenericoObj.CfModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "Note", EsitoIstanzaChecklistGenericoObj.Note);
            DbProvider.SetCmdParam(cmd, firstChar + "CodEsitoRevisore", EsitoIstanzaChecklistGenericoObj.CodEsitoRevisore);
            DbProvider.SetCmdParam(cmd, firstChar + "DataRevisore", EsitoIstanzaChecklistGenericoObj.DataRevisore);
            DbProvider.SetCmdParam(cmd, firstChar + "Revisore", EsitoIstanzaChecklistGenericoObj.Revisore);
            DbProvider.SetCmdParam(cmd, firstChar + "NoteRevisore", EsitoIstanzaChecklistGenericoObj.NoteRevisore);
            DbProvider.SetCmdParam(cmd, firstChar + "EscludiDaComunicazione", EsitoIstanzaChecklistGenericoObj.EscludiDaComunicazione);
            DbProvider.SetCmdParam(cmd, firstChar + "Valore", EsitoIstanzaChecklistGenericoObj.Valore);
        }
        //Insert
        private static int Insert(DbProvider db, EsitoIstanzaChecklistGenerico EsitoIstanzaChecklistGenericoObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZEsitoIstanzaChecklistGenericoInsert", new string[] {"IdVoceGenerica", "IdIstanzaGenerica", 
"CodEsito", "DataInserimento", "CfInserimento", 
"DataModifica", "CfModifica", "Note", 
"CodEsitoRevisore", "DataRevisore", "Revisore", 
"NoteRevisore", "EscludiDaComunicazione", 





"Valore", }, new string[] {"int", "int", 
"string", "DateTime", "string", 
"DateTime", "string", "string", 
"string", "DateTime", "string", 
"string", "bool", 





"string", }, "");
                CompileIUCmd(false, insertCmd, EsitoIstanzaChecklistGenericoObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    EsitoIstanzaChecklistGenericoObj.IdEsitoGenerico = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ESITO_GENERICO"]);
                    EsitoIstanzaChecklistGenericoObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
                    EsitoIstanzaChecklistGenericoObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
                    EsitoIstanzaChecklistGenericoObj.EscludiDaComunicazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ESCLUDI_DA_COMUNICAZIONE"]);
                }
                EsitoIstanzaChecklistGenericoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                EsitoIstanzaChecklistGenericoObj.IsDirty = false;
                EsitoIstanzaChecklistGenericoObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, EsitoIstanzaChecklistGenerico EsitoIstanzaChecklistGenericoObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZEsitoIstanzaChecklistGenericoUpdate", new string[] {"IdEsitoGenerico", "IdVoceGenerica", "IdIstanzaGenerica", 
"CodEsito", "DataInserimento", "CfInserimento", 
"DataModifica", "CfModifica", "Note", 
"CodEsitoRevisore", "DataRevisore", "Revisore", 
"NoteRevisore", "EscludiDaComunicazione", 





"Valore", }, new string[] {"int", "int", "int", 
"string", "DateTime", "string", 
"DateTime", "string", "string", 
"string", "DateTime", "string", 
"string", "bool", 





"string", }, "");
                CompileIUCmd(true, updateCmd, EsitoIstanzaChecklistGenericoObj, db.CommandFirstChar);
                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                if (d != null)
                {
                    i = 1;
                    EsitoIstanzaChecklistGenericoObj.DataModifica = d;
                }
                EsitoIstanzaChecklistGenericoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                EsitoIstanzaChecklistGenericoObj.IsDirty = false;
                EsitoIstanzaChecklistGenericoObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, EsitoIstanzaChecklistGenerico EsitoIstanzaChecklistGenericoObj)
        {
            switch (EsitoIstanzaChecklistGenericoObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, EsitoIstanzaChecklistGenericoObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, EsitoIstanzaChecklistGenericoObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, EsitoIstanzaChecklistGenericoObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, EsitoIstanzaChecklistGenericoCollection EsitoIstanzaChecklistGenericoCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZEsitoIstanzaChecklistGenericoUpdate", new string[] {"IdEsitoGenerico", "IdVoceGenerica", "IdIstanzaGenerica", 
"CodEsito", "DataInserimento", "CfInserimento", 
"DataModifica", "CfModifica", "Note", 
"CodEsitoRevisore", "DataRevisore", "Revisore", 
"NoteRevisore", "EscludiDaComunicazione", 





"Valore", }, new string[] {"int", "int", "int", 
"string", "DateTime", "string", 
"DateTime", "string", "string", 
"string", "DateTime", "string", 
"string", "bool", 





"string", }, "");
                IDbCommand insertCmd = db.InitCmd("ZEsitoIstanzaChecklistGenericoInsert", new string[] {"IdVoceGenerica", "IdIstanzaGenerica", 
"CodEsito", "DataInserimento", "CfInserimento", 
"DataModifica", "CfModifica", "Note", 
"CodEsitoRevisore", "DataRevisore", "Revisore", 
"NoteRevisore", "EscludiDaComunicazione", 





"Valore", }, new string[] {"int", "int", 
"string", "DateTime", "string", 
"DateTime", "string", "string", 
"string", "DateTime", "string", 
"string", "bool", 





"string", }, "");
                IDbCommand deleteCmd = db.InitCmd("ZEsitoIstanzaChecklistGenericoDelete", new string[] { "IdEsitoGenerico" }, new string[] { "int" }, "");
                for (int i = 0; i < EsitoIstanzaChecklistGenericoCollectionObj.Count; i++)
                {
                    switch (EsitoIstanzaChecklistGenericoCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, EsitoIstanzaChecklistGenericoCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    EsitoIstanzaChecklistGenericoCollectionObj[i].IdEsitoGenerico = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ESITO_GENERICO"]);
                                    EsitoIstanzaChecklistGenericoCollectionObj[i].DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
                                    EsitoIstanzaChecklistGenericoCollectionObj[i].DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
                                    EsitoIstanzaChecklistGenericoCollectionObj[i].EscludiDaComunicazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ESCLUDI_DA_COMUNICAZIONE"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, EsitoIstanzaChecklistGenericoCollectionObj[i], db.CommandFirstChar);
                                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                                if (d != null)
                                {
                                    returnValue++;
                                    EsitoIstanzaChecklistGenericoCollectionObj[i].DataModifica = d;
                                }
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (EsitoIstanzaChecklistGenericoCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdEsitoGenerico", (SiarLibrary.NullTypes.IntNT)EsitoIstanzaChecklistGenericoCollectionObj[i].IdEsitoGenerico);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < EsitoIstanzaChecklistGenericoCollectionObj.Count; i++)
                {
                    if ((EsitoIstanzaChecklistGenericoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (EsitoIstanzaChecklistGenericoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        EsitoIstanzaChecklistGenericoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        EsitoIstanzaChecklistGenericoCollectionObj[i].IsDirty = false;
                        EsitoIstanzaChecklistGenericoCollectionObj[i].IsPersistent = true;
                    }
                    if ((EsitoIstanzaChecklistGenericoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        EsitoIstanzaChecklistGenericoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        EsitoIstanzaChecklistGenericoCollectionObj[i].IsDirty = false;
                        EsitoIstanzaChecklistGenericoCollectionObj[i].IsPersistent = false;
                    }
                }
            }
            catch
            {
                db.Rollback();
                throw;
            }
            finally
            {
                db.Close();
            }
            return returnValue;
        }

        //Delete
        public static int Delete(DbProvider db, EsitoIstanzaChecklistGenerico EsitoIstanzaChecklistGenericoObj)
        {
            int returnValue = 0;
            if (EsitoIstanzaChecklistGenericoObj.IsPersistent)
            {
                returnValue = Delete(db, EsitoIstanzaChecklistGenericoObj.IdEsitoGenerico);
            }
            EsitoIstanzaChecklistGenericoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            EsitoIstanzaChecklistGenericoObj.IsDirty = false;
            EsitoIstanzaChecklistGenericoObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdEsitoGenericoValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZEsitoIstanzaChecklistGenericoDelete", new string[] { "IdEsitoGenerico" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdEsitoGenerico", (SiarLibrary.NullTypes.IntNT)IdEsitoGenericoValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, EsitoIstanzaChecklistGenericoCollection EsitoIstanzaChecklistGenericoCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZEsitoIstanzaChecklistGenericoDelete", new string[] { "IdEsitoGenerico" }, new string[] { "int" }, "");
                for (int i = 0; i < EsitoIstanzaChecklistGenericoCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdEsitoGenerico", EsitoIstanzaChecklistGenericoCollectionObj[i].IdEsitoGenerico);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < EsitoIstanzaChecklistGenericoCollectionObj.Count; i++)
                {
                    if ((EsitoIstanzaChecklistGenericoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (EsitoIstanzaChecklistGenericoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        EsitoIstanzaChecklistGenericoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        EsitoIstanzaChecklistGenericoCollectionObj[i].IsDirty = false;
                        EsitoIstanzaChecklistGenericoCollectionObj[i].IsPersistent = false;
                    }
                }
            }
            catch
            {
                db.Rollback();
                throw;
            }
            finally
            {
                db.Close();
            }
            return returnValue;
        }

        //getById
        public static EsitoIstanzaChecklistGenerico GetById(DbProvider db, int IdEsitoGenericoValue)
        {
            EsitoIstanzaChecklistGenerico EsitoIstanzaChecklistGenericoObj = null;
            IDbCommand readCmd = db.InitCmd("ZEsitoIstanzaChecklistGenericoGetById", new string[] { "IdEsitoGenerico" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdEsitoGenerico", (SiarLibrary.NullTypes.IntNT)IdEsitoGenericoValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                EsitoIstanzaChecklistGenericoObj = GetFromDatareader(db);
                EsitoIstanzaChecklistGenericoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                EsitoIstanzaChecklistGenericoObj.IsDirty = false;
                EsitoIstanzaChecklistGenericoObj.IsPersistent = true;
            }
            db.Close();
            return EsitoIstanzaChecklistGenericoObj;
        }

        //getFromDatareader
        public static EsitoIstanzaChecklistGenerico GetFromDatareader(DbProvider db)
        {
            EsitoIstanzaChecklistGenerico EsitoIstanzaChecklistGenericoObj = new EsitoIstanzaChecklistGenerico();
            EsitoIstanzaChecklistGenericoObj.IdEsitoGenerico = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ESITO_GENERICO"]);
            EsitoIstanzaChecklistGenericoObj.IdVoceGenerica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VOCE_GENERICA"]);
            EsitoIstanzaChecklistGenericoObj.IdIstanzaGenerica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ISTANZA_GENERICA"]);
            EsitoIstanzaChecklistGenericoObj.CodEsito = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ESITO"]);
            EsitoIstanzaChecklistGenericoObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
            EsitoIstanzaChecklistGenericoObj.CfInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_INSERIMENTO"]);
            EsitoIstanzaChecklistGenericoObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
            EsitoIstanzaChecklistGenericoObj.CfModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_MODIFICA"]);
            EsitoIstanzaChecklistGenericoObj.Note = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE"]);
            EsitoIstanzaChecklistGenericoObj.CodEsitoRevisore = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ESITO_REVISORE"]);
            EsitoIstanzaChecklistGenericoObj.DataRevisore = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_REVISORE"]);
            EsitoIstanzaChecklistGenericoObj.Revisore = new SiarLibrary.NullTypes.StringNT(db.DataReader["REVISORE"]);
            EsitoIstanzaChecklistGenericoObj.NoteRevisore = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE_REVISORE"]);
            EsitoIstanzaChecklistGenericoObj.EscludiDaComunicazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ESCLUDI_DA_COMUNICAZIONE"]);
            EsitoIstanzaChecklistGenericoObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
            EsitoIstanzaChecklistGenericoObj.EsitoPositivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ESITO_POSITIVO"]);
            EsitoIstanzaChecklistGenericoObj.DescrizioneEsitoRevisore = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_ESITO_REVISORE"]);
            EsitoIstanzaChecklistGenericoObj.EsitoPositivoRevisore = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ESITO_POSITIVO_REVISORE"]);
            EsitoIstanzaChecklistGenericoObj.DescrizioneVoceGenerica = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_VOCE_GENERICA"]);
            EsitoIstanzaChecklistGenericoObj.Automatico = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AUTOMATICO"]);
            EsitoIstanzaChecklistGenericoObj.QuerySql = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_SQL"]);
            EsitoIstanzaChecklistGenericoObj.QuerySqlPost = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_SQL_POST"]);
            EsitoIstanzaChecklistGenericoObj.CodeMethod = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODE_METHOD"]);
            EsitoIstanzaChecklistGenericoObj.Url = new SiarLibrary.NullTypes.StringNT(db.DataReader["URL"]);
            EsitoIstanzaChecklistGenericoObj.ValMinimo = new SiarLibrary.NullTypes.StringNT(db.DataReader["VAL_MINIMO"]);
            EsitoIstanzaChecklistGenericoObj.ValMassimo = new SiarLibrary.NullTypes.StringNT(db.DataReader["VAL_MASSIMO"]);
            EsitoIstanzaChecklistGenericoObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
            EsitoIstanzaChecklistGenericoObj.Obbligatorio = new SiarLibrary.NullTypes.BoolNT(db.DataReader["OBBLIGATORIO"]);
            EsitoIstanzaChecklistGenericoObj.Peso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PESO"]);
            EsitoIstanzaChecklistGenericoObj.IdChecklistGenerica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CHECKLIST_GENERICA"]);
            EsitoIstanzaChecklistGenericoObj.DescrizioneChecklistGenerica = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_CHECKLIST_GENERICA"]);
            EsitoIstanzaChecklistGenericoObj.Valore = new SiarLibrary.NullTypes.StringNT(db.DataReader["VALORE"]);
            EsitoIstanzaChecklistGenericoObj.ValEsitoNegativo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["VAL_ESITO_NEGATIVO"]);
            EsitoIstanzaChecklistGenericoObj.Misura = new SiarLibrary.NullTypes.StringNT(db.DataReader["MISURA"]);
            EsitoIstanzaChecklistGenericoObj.IdVoceXChecklistGenerica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VOCE_X_CHECKLIST_GENERICA"]);
            EsitoIstanzaChecklistGenericoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            EsitoIstanzaChecklistGenericoObj.IsDirty = false;
            EsitoIstanzaChecklistGenericoObj.IsPersistent = true;
            return EsitoIstanzaChecklistGenericoObj;
        }

        //Find Select

        public static EsitoIstanzaChecklistGenericoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEsitoGenericoEqualThis, SiarLibrary.NullTypes.IntNT IdVoceGenericaEqualThis, SiarLibrary.NullTypes.IntNT IdIstanzaGenericaEqualThis,
SiarLibrary.NullTypes.StringNT CodEsitoEqualThis, SiarLibrary.NullTypes.StringNT ValoreEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis,
SiarLibrary.NullTypes.StringNT CfInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.StringNT CfModificaEqualThis,
SiarLibrary.NullTypes.StringNT CodEsitoRevisoreEqualThis, SiarLibrary.NullTypes.DatetimeNT DataRevisoreEqualThis, SiarLibrary.NullTypes.StringNT RevisoreEqualThis,
SiarLibrary.NullTypes.BoolNT EscludiDaComunicazioneEqualThis)
        {

            EsitoIstanzaChecklistGenericoCollection EsitoIstanzaChecklistGenericoCollectionObj = new EsitoIstanzaChecklistGenericoCollection();

            IDbCommand findCmd = db.InitCmd("Zesitoistanzachecklistgenericofindselect", new string[] {"IdEsitoGenericoequalthis", "IdVoceGenericaequalthis", "IdIstanzaGenericaequalthis", 
"CodEsitoequalthis", "Valoreequalthis", "DataInserimentoequalthis", 
"CfInserimentoequalthis", "DataModificaequalthis", "CfModificaequalthis", 
"CodEsitoRevisoreequalthis", "DataRevisoreequalthis", "Revisoreequalthis", 
"EscludiDaComunicazioneequalthis"}, new string[] {"int", "int", "int", 
"string", "string", "DateTime", 
"string", "DateTime", "string", 
"string", "DateTime", "string", 
"bool"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdEsitoGenericoequalthis", IdEsitoGenericoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdVoceGenericaequalthis", IdVoceGenericaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdIstanzaGenericaequalthis", IdIstanzaGenericaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodEsitoequalthis", CodEsitoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Valoreequalthis", ValoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfInserimentoequalthis", CfInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfModificaequalthis", CfModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodEsitoRevisoreequalthis", CodEsitoRevisoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataRevisoreequalthis", DataRevisoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Revisoreequalthis", RevisoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "EscludiDaComunicazioneequalthis", EscludiDaComunicazioneEqualThis);
            EsitoIstanzaChecklistGenerico EsitoIstanzaChecklistGenericoObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                EsitoIstanzaChecklistGenericoObj = GetFromDatareader(db);
                EsitoIstanzaChecklistGenericoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                EsitoIstanzaChecklistGenericoObj.IsDirty = false;
                EsitoIstanzaChecklistGenericoObj.IsPersistent = true;
                EsitoIstanzaChecklistGenericoCollectionObj.Add(EsitoIstanzaChecklistGenericoObj);
            }
            db.Close();
            return EsitoIstanzaChecklistGenericoCollectionObj;
        }

        //Find Find

        public static EsitoIstanzaChecklistGenericoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdIstanzaGenericaEqualThis, SiarLibrary.NullTypes.IntNT IdVoceGenericaEqualThis, SiarLibrary.NullTypes.StringNT CodEsitoEqualThis,
SiarLibrary.NullTypes.StringNT CodEsitoRevisoreEqualThis, SiarLibrary.NullTypes.IntNT IdChecklistGenericaEqualThis)
        {

            EsitoIstanzaChecklistGenericoCollection EsitoIstanzaChecklistGenericoCollectionObj = new EsitoIstanzaChecklistGenericoCollection();

            IDbCommand findCmd = db.InitCmd("Zesitoistanzachecklistgenericofindfind", new string[] {"IdIstanzaGenericaequalthis", "IdVoceGenericaequalthis", "CodEsitoequalthis", 
"CodEsitoRevisoreequalthis", "IdChecklistGenericaequalthis"}, new string[] {"int", "int", "string", 
"string", "int"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdIstanzaGenericaequalthis", IdIstanzaGenericaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdVoceGenericaequalthis", IdVoceGenericaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodEsitoequalthis", CodEsitoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodEsitoRevisoreequalthis", CodEsitoRevisoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdChecklistGenericaequalthis", IdChecklistGenericaEqualThis);
            EsitoIstanzaChecklistGenerico EsitoIstanzaChecklistGenericoObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                EsitoIstanzaChecklistGenericoObj = GetFromDatareader(db);
                EsitoIstanzaChecklistGenericoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                EsitoIstanzaChecklistGenericoObj.IsDirty = false;
                EsitoIstanzaChecklistGenericoObj.IsPersistent = true;
                EsitoIstanzaChecklistGenericoCollectionObj.Add(EsitoIstanzaChecklistGenericoObj);
            }
            db.Close();
            return EsitoIstanzaChecklistGenericoCollectionObj;
        }

        //Find GetByIstanzaAndVoce

        public static EsitoIstanzaChecklistGenericoCollection GetByIstanzaAndVoce(DbProvider db, SiarLibrary.NullTypes.IntNT IdIstanzaGenericaEqualThis, SiarLibrary.NullTypes.IntNT IdVoceGenericaEqualThis)
        {

            EsitoIstanzaChecklistGenericoCollection EsitoIstanzaChecklistGenericoCollectionObj = new EsitoIstanzaChecklistGenericoCollection();

            IDbCommand findCmd = db.InitCmd("Zesitoistanzachecklistgenericofindgetbyistanzaandvoce", new string[] { "IdIstanzaGenericaequalthis", "IdVoceGenericaequalthis" }, new string[] { "int", "int" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdIstanzaGenericaequalthis", IdIstanzaGenericaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdVoceGenericaequalthis", IdVoceGenericaEqualThis);
            EsitoIstanzaChecklistGenerico EsitoIstanzaChecklistGenericoObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                EsitoIstanzaChecklistGenericoObj = GetFromDatareader(db);
                EsitoIstanzaChecklistGenericoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                EsitoIstanzaChecklistGenericoObj.IsDirty = false;
                EsitoIstanzaChecklistGenericoObj.IsPersistent = true;
                EsitoIstanzaChecklistGenericoCollectionObj.Add(EsitoIstanzaChecklistGenericoObj);
            }
            db.Close();
            return EsitoIstanzaChecklistGenericoCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for EsitoIstanzaChecklistGenericoCollectionProvider:IEsitoIstanzaChecklistGenericoProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class EsitoIstanzaChecklistGenericoCollectionProvider : IEsitoIstanzaChecklistGenericoProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di EsitoIstanzaChecklistGenerico
        protected EsitoIstanzaChecklistGenericoCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public EsitoIstanzaChecklistGenericoCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new EsitoIstanzaChecklistGenericoCollection(this);
        }

        //Costruttore 2: popola la collection
        public EsitoIstanzaChecklistGenericoCollectionProvider(IntNT IdistanzagenericaEqualThis, IntNT IdvocegenericaEqualThis, StringNT CodesitoEqualThis,
StringNT CodesitorevisoreEqualThis, IntNT IdchecklistgenericaEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IdistanzagenericaEqualThis, IdvocegenericaEqualThis, CodesitoEqualThis,
CodesitorevisoreEqualThis, IdchecklistgenericaEqualThis);
        }

        //Costruttore3: ha in input esitoistanzachecklistgenericoCollectionObj - non popola la collection
        public EsitoIstanzaChecklistGenericoCollectionProvider(EsitoIstanzaChecklistGenericoCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public EsitoIstanzaChecklistGenericoCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new EsitoIstanzaChecklistGenericoCollection(this);
        }

        //Get e Set
        public EsitoIstanzaChecklistGenericoCollection CollectionObj
        {
            get
            {
                return _CollectionObj;
            }
            set
            {
                _CollectionObj = value;
            }
        }

        public DbProvider DbProviderObj
        {
            get
            {
                return _dbProviderObj;
            }
            set
            {
                _dbProviderObj = value;
            }
        }

        //Operazioni

        //Save1: registra l'intera collection
        public int SaveCollection()
        {
            return SaveCollection(_CollectionObj);
        }

        //Save2: registra una collection
        public int SaveCollection(EsitoIstanzaChecklistGenericoCollection collectionObj)
        {
            return EsitoIstanzaChecklistGenericoDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(EsitoIstanzaChecklistGenerico esitoistanzachecklistgenericoObj)
        {
            return EsitoIstanzaChecklistGenericoDAL.Save(_dbProviderObj, esitoistanzachecklistgenericoObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(EsitoIstanzaChecklistGenericoCollection collectionObj)
        {
            return EsitoIstanzaChecklistGenericoDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(EsitoIstanzaChecklistGenerico esitoistanzachecklistgenericoObj)
        {
            return EsitoIstanzaChecklistGenericoDAL.Delete(_dbProviderObj, esitoistanzachecklistgenericoObj);
        }

        //getById
        public EsitoIstanzaChecklistGenerico GetById(IntNT IdEsitoGenericoValue)
        {
            EsitoIstanzaChecklistGenerico EsitoIstanzaChecklistGenericoTemp = EsitoIstanzaChecklistGenericoDAL.GetById(_dbProviderObj, IdEsitoGenericoValue);
            if (EsitoIstanzaChecklistGenericoTemp != null) EsitoIstanzaChecklistGenericoTemp.Provider = this;
            return EsitoIstanzaChecklistGenericoTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public EsitoIstanzaChecklistGenericoCollection Select(IntNT IdesitogenericoEqualThis, IntNT IdvocegenericaEqualThis, IntNT IdistanzagenericaEqualThis,
StringNT CodesitoEqualThis, StringNT ValoreEqualThis, DatetimeNT DatainserimentoEqualThis,
StringNT CfinserimentoEqualThis, DatetimeNT DatamodificaEqualThis, StringNT CfmodificaEqualThis,
StringNT CodesitorevisoreEqualThis, DatetimeNT DatarevisoreEqualThis, StringNT RevisoreEqualThis,
BoolNT EscludidacomunicazioneEqualThis)
        {
            EsitoIstanzaChecklistGenericoCollection EsitoIstanzaChecklistGenericoCollectionTemp = EsitoIstanzaChecklistGenericoDAL.Select(_dbProviderObj, IdesitogenericoEqualThis, IdvocegenericaEqualThis, IdistanzagenericaEqualThis,
CodesitoEqualThis, ValoreEqualThis, DatainserimentoEqualThis,
CfinserimentoEqualThis, DatamodificaEqualThis, CfmodificaEqualThis,
CodesitorevisoreEqualThis, DatarevisoreEqualThis, RevisoreEqualThis,
EscludidacomunicazioneEqualThis);
            EsitoIstanzaChecklistGenericoCollectionTemp.Provider = this;
            return EsitoIstanzaChecklistGenericoCollectionTemp;
        }

        //Find: popola la collection
        public EsitoIstanzaChecklistGenericoCollection Find(IntNT IdistanzagenericaEqualThis, IntNT IdvocegenericaEqualThis, StringNT CodesitoEqualThis,
StringNT CodesitorevisoreEqualThis, IntNT IdchecklistgenericaEqualThis)
        {
            EsitoIstanzaChecklistGenericoCollection EsitoIstanzaChecklistGenericoCollectionTemp = EsitoIstanzaChecklistGenericoDAL.Find(_dbProviderObj, IdistanzagenericaEqualThis, IdvocegenericaEqualThis, CodesitoEqualThis,
CodesitorevisoreEqualThis, IdchecklistgenericaEqualThis);
            EsitoIstanzaChecklistGenericoCollectionTemp.Provider = this;
            return EsitoIstanzaChecklistGenericoCollectionTemp;
        }

        //GetByIstanzaAndVoce: popola la collection
        public EsitoIstanzaChecklistGenericoCollection GetByIstanzaAndVoce(IntNT IdistanzagenericaEqualThis, IntNT IdvocegenericaEqualThis)
        {
            EsitoIstanzaChecklistGenericoCollection EsitoIstanzaChecklistGenericoCollectionTemp = EsitoIstanzaChecklistGenericoDAL.GetByIstanzaAndVoce(_dbProviderObj, IdistanzagenericaEqualThis, IdvocegenericaEqualThis);
            EsitoIstanzaChecklistGenericoCollectionTemp.Provider = this;
            return EsitoIstanzaChecklistGenericoCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<ESITO_ISTANZA_CHECKLIST_GENERICO>
  <ViewName>VESITO_ISTANZA_CHECKLIST_GENERICO</ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>True</chkDataModifica>
  <txtNomeCampoDataModifica>DATA_MODIFICA</txtNomeCampoDataModifica>
  <chkOptimisticCouncurrency>False</chkOptimisticCouncurrency>
  <chkShortNames>False</chkShortNames>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds>
    <Find OrderBy="ORDER BY ">
      <ID_ISTANZA_GENERICA>Equal</ID_ISTANZA_GENERICA>
      <ID_VOCE_GENERICA>Equal</ID_VOCE_GENERICA>
      <COD_ESITO>Equal</COD_ESITO>
      <COD_ESITO_REVISORE>Equal</COD_ESITO_REVISORE>
      <ID_CHECKLIST_GENERICA>Equal</ID_CHECKLIST_GENERICA>
    </Find>
    <GetByIstanzaAndVoce OrderBy="ORDER BY ">
      <ID_ISTANZA_GENERICA>Equal</ID_ISTANZA_GENERICA>
      <ID_VOCE_GENERICA>Equal</ID_VOCE_GENERICA>
    </GetByIstanzaAndVoce>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</ESITO_ISTANZA_CHECKLIST_GENERICO>
*/
