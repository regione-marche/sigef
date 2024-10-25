using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per GiustificativoXRegistroIrregolarita
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IGiustificativoXRegistroIrregolaritaProvider
    {
        int Save(GiustificativoXRegistroIrregolarita GiustificativoXRegistroIrregolaritaObj);
        int SaveCollection(GiustificativoXRegistroIrregolaritaCollection collectionObj);
        int Delete(GiustificativoXRegistroIrregolarita GiustificativoXRegistroIrregolaritaObj);
        int DeleteCollection(GiustificativoXRegistroIrregolaritaCollection collectionObj);
    }
    /// <summary>
    /// Summary description for GiustificativoXRegistroIrregolarita
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class GiustificativoXRegistroIrregolarita : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdGiustificativoXIrregolarita;
        private NullTypes.IntNT _IdGiustificativo;
        private NullTypes.IntNT _IdRegistroIrregolarita;
        private NullTypes.DatetimeNT _DataInserimento;
        private NullTypes.StringNT _CfInserimento;
        private NullTypes.DatetimeNT _DataModifica;
        private NullTypes.StringNT _CfModifica;
        private NullTypes.IntNT _IdProgetto;
        private NullTypes.StringNT _Numero;
        private NullTypes.StringNT _CodTipo;
        private NullTypes.DatetimeNT _Data;
        private NullTypes.StringNT _NumeroDoctrasporto;
        private NullTypes.DatetimeNT _DataDoctrasporto;
        private NullTypes.DecimalNT _Imponibile;
        private NullTypes.DecimalNT _Iva;
        private NullTypes.DecimalNT _AltriOneri;
        private NullTypes.StringNT _Descrizione;
        private NullTypes.StringNT _CfFornitore;
        private NullTypes.StringNT _DescrizioneFornitore;
        private NullTypes.BoolNT _IvaNonRecuperabile;
        private NullTypes.IntNT _IdFile;
        private NullTypes.BoolNT _InIntegrazione;
        private NullTypes.BoolNT _IdFileModificatoIntegrazione;
        [NonSerialized]
        private IGiustificativoXRegistroIrregolaritaProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IGiustificativoXRegistroIrregolaritaProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public GiustificativoXRegistroIrregolarita()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:ID_GIUSTIFICATIVO_X_IRREGOLARITA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdGiustificativoXIrregolarita
        {
            get { return _IdGiustificativoXIrregolarita; }
            set
            {
                if (IdGiustificativoXIrregolarita != value)
                {
                    _IdGiustificativoXIrregolarita = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_GIUSTIFICATIVO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdGiustificativo
        {
            get { return _IdGiustificativo; }
            set
            {
                if (IdGiustificativo != value)
                {
                    _IdGiustificativo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_REGISTRO_IRREGOLARITA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdRegistroIrregolarita
        {
            get { return _IdRegistroIrregolarita; }
            set
            {
                if (IdRegistroIrregolarita != value)
                {
                    _IdRegistroIrregolarita = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_INSERIMENTO
        /// Tipo sul db:DATETIME
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
        /// Tipo sul db:VARCHAR(16)
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
        /// Tipo sul db:VARCHAR(16)
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
        /// Corrisponde al campo:ID_PROGETTO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdProgetto
        {
            get { return _IdProgetto; }
            set
            {
                if (IdProgetto != value)
                {
                    _IdProgetto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NUMERO
        /// Tipo sul db:VARCHAR(30)
        /// </summary>
        public NullTypes.StringNT Numero
        {
            get { return _Numero; }
            set
            {
                if (Numero != value)
                {
                    _Numero = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COD_TIPO
        /// Tipo sul db:CHAR(3)
        /// </summary>
        public NullTypes.StringNT CodTipo
        {
            get { return _CodTipo; }
            set
            {
                if (CodTipo != value)
                {
                    _CodTipo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT Data
        {
            get { return _Data; }
            set
            {
                if (Data != value)
                {
                    _Data = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NUMERO_DOCTRASPORTO
        /// Tipo sul db:VARCHAR(30)
        /// </summary>
        public NullTypes.StringNT NumeroDoctrasporto
        {
            get { return _NumeroDoctrasporto; }
            set
            {
                if (NumeroDoctrasporto != value)
                {
                    _NumeroDoctrasporto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_DOCTRASPORTO
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataDoctrasporto
        {
            get { return _DataDoctrasporto; }
            set
            {
                if (DataDoctrasporto != value)
                {
                    _DataDoctrasporto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPONIBILE
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT Imponibile
        {
            get { return _Imponibile; }
            set
            {
                if (Imponibile != value)
                {
                    _Imponibile = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IVA
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT Iva
        {
            get { return _Iva; }
            set
            {
                if (Iva != value)
                {
                    _Iva = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ALTRI_ONERI
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT AltriOneri
        {
            get { return _AltriOneri; }
            set
            {
                if (AltriOneri != value)
                {
                    _AltriOneri = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DESCRIZIONE
        /// Tipo sul db:VARCHAR(255)
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
        /// Corrisponde al campo:CF_FORNITORE
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT CfFornitore
        {
            get { return _CfFornitore; }
            set
            {
                if (CfFornitore != value)
                {
                    _CfFornitore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DESCRIZIONE_FORNITORE
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT DescrizioneFornitore
        {
            get { return _DescrizioneFornitore; }
            set
            {
                if (DescrizioneFornitore != value)
                {
                    _DescrizioneFornitore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IVA_NON_RECUPERABILE
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT IvaNonRecuperabile
        {
            get { return _IvaNonRecuperabile; }
            set
            {
                if (IvaNonRecuperabile != value)
                {
                    _IvaNonRecuperabile = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_FILE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdFile
        {
            get { return _IdFile; }
            set
            {
                if (IdFile != value)
                {
                    _IdFile = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IN_INTEGRAZIONE
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT InIntegrazione
        {
            get { return _InIntegrazione; }
            set
            {
                if (InIntegrazione != value)
                {
                    _InIntegrazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_FILE_MODIFICATO_INTEGRAZIONE
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT IdFileModificatoIntegrazione
        {
            get { return _IdFileModificatoIntegrazione; }
            set
            {
                if (IdFileModificatoIntegrazione != value)
                {
                    _IdFileModificatoIntegrazione = value;
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
    /// Summary description for GiustificativoXRegistroIrregolaritaCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class GiustificativoXRegistroIrregolaritaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private GiustificativoXRegistroIrregolaritaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((GiustificativoXRegistroIrregolarita)info.GetValue(i.ToString(), typeof(GiustificativoXRegistroIrregolarita)));
            }
        }

        //Costruttore
        public GiustificativoXRegistroIrregolaritaCollection()
        {
            this.ItemType = typeof(GiustificativoXRegistroIrregolarita);
        }

        //Costruttore con provider
        public GiustificativoXRegistroIrregolaritaCollection(IGiustificativoXRegistroIrregolaritaProvider providerObj)
        {
            this.ItemType = typeof(GiustificativoXRegistroIrregolarita);
            this.Provider = providerObj;
        }

        //Get e Set
        public new GiustificativoXRegistroIrregolarita this[int index]
        {
            get { return (GiustificativoXRegistroIrregolarita)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new GiustificativoXRegistroIrregolaritaCollection GetChanges()
        {
            return (GiustificativoXRegistroIrregolaritaCollection)base.GetChanges();
        }

        [NonSerialized]
        private IGiustificativoXRegistroIrregolaritaProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IGiustificativoXRegistroIrregolaritaProvider Provider
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
        public int Add(GiustificativoXRegistroIrregolarita GiustificativoXRegistroIrregolaritaObj)
        {
            if (GiustificativoXRegistroIrregolaritaObj.Provider == null) GiustificativoXRegistroIrregolaritaObj.Provider = this.Provider;
            return base.Add(GiustificativoXRegistroIrregolaritaObj);
        }

        //AddCollection
        public void AddCollection(GiustificativoXRegistroIrregolaritaCollection GiustificativoXRegistroIrregolaritaCollectionObj)
        {
            foreach (GiustificativoXRegistroIrregolarita GiustificativoXRegistroIrregolaritaObj in GiustificativoXRegistroIrregolaritaCollectionObj)
                this.Add(GiustificativoXRegistroIrregolaritaObj);
        }

        //Insert
        public void Insert(int index, GiustificativoXRegistroIrregolarita GiustificativoXRegistroIrregolaritaObj)
        {
            if (GiustificativoXRegistroIrregolaritaObj.Provider == null) GiustificativoXRegistroIrregolaritaObj.Provider = this.Provider;
            base.Insert(index, GiustificativoXRegistroIrregolaritaObj);
        }

        //CollectionGetById
        public GiustificativoXRegistroIrregolarita CollectionGetById(NullTypes.IntNT IdGiustificativoXIrregolaritaValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdGiustificativoXIrregolarita == IdGiustificativoXIrregolaritaValue))
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
        public GiustificativoXRegistroIrregolaritaCollection SubSelect(NullTypes.IntNT IdGiustificativoXIrregolaritaEqualThis, NullTypes.IntNT IdGiustificativoEqualThis, NullTypes.IntNT IdRegistroIrregolaritaEqualThis,
NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.StringNT CfInserimentoEqualThis, NullTypes.DatetimeNT DataModificaEqualThis,
NullTypes.StringNT CfModificaEqualThis)
        {
            GiustificativoXRegistroIrregolaritaCollection GiustificativoXRegistroIrregolaritaCollectionTemp = new GiustificativoXRegistroIrregolaritaCollection();
            foreach (GiustificativoXRegistroIrregolarita GiustificativoXRegistroIrregolaritaItem in this)
            {
                if (((IdGiustificativoXIrregolaritaEqualThis == null) || ((GiustificativoXRegistroIrregolaritaItem.IdGiustificativoXIrregolarita != null) && (GiustificativoXRegistroIrregolaritaItem.IdGiustificativoXIrregolarita.Value == IdGiustificativoXIrregolaritaEqualThis.Value))) && ((IdGiustificativoEqualThis == null) || ((GiustificativoXRegistroIrregolaritaItem.IdGiustificativo != null) && (GiustificativoXRegistroIrregolaritaItem.IdGiustificativo.Value == IdGiustificativoEqualThis.Value))) && ((IdRegistroIrregolaritaEqualThis == null) || ((GiustificativoXRegistroIrregolaritaItem.IdRegistroIrregolarita != null) && (GiustificativoXRegistroIrregolaritaItem.IdRegistroIrregolarita.Value == IdRegistroIrregolaritaEqualThis.Value))) &&
((DataInserimentoEqualThis == null) || ((GiustificativoXRegistroIrregolaritaItem.DataInserimento != null) && (GiustificativoXRegistroIrregolaritaItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((CfInserimentoEqualThis == null) || ((GiustificativoXRegistroIrregolaritaItem.CfInserimento != null) && (GiustificativoXRegistroIrregolaritaItem.CfInserimento.Value == CfInserimentoEqualThis.Value))) && ((DataModificaEqualThis == null) || ((GiustificativoXRegistroIrregolaritaItem.DataModifica != null) && (GiustificativoXRegistroIrregolaritaItem.DataModifica.Value == DataModificaEqualThis.Value))) &&
((CfModificaEqualThis == null) || ((GiustificativoXRegistroIrregolaritaItem.CfModifica != null) && (GiustificativoXRegistroIrregolaritaItem.CfModifica.Value == CfModificaEqualThis.Value))))
                {
                    GiustificativoXRegistroIrregolaritaCollectionTemp.Add(GiustificativoXRegistroIrregolaritaItem);
                }
            }
            return GiustificativoXRegistroIrregolaritaCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for GiustificativoXRegistroIrregolaritaDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class GiustificativoXRegistroIrregolaritaDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, GiustificativoXRegistroIrregolarita GiustificativoXRegistroIrregolaritaObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdGiustificativoXIrregolarita", GiustificativoXRegistroIrregolaritaObj.IdGiustificativoXIrregolarita);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "IdGiustificativo", GiustificativoXRegistroIrregolaritaObj.IdGiustificativo);
            DbProvider.SetCmdParam(cmd, firstChar + "IdRegistroIrregolarita", GiustificativoXRegistroIrregolaritaObj.IdRegistroIrregolarita);
            DbProvider.SetCmdParam(cmd, firstChar + "DataInserimento", GiustificativoXRegistroIrregolaritaObj.DataInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "CfInserimento", GiustificativoXRegistroIrregolaritaObj.CfInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", GiustificativoXRegistroIrregolaritaObj.DataModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "CfModifica", GiustificativoXRegistroIrregolaritaObj.CfModifica);
        }
        //Insert
        private static int Insert(DbProvider db, GiustificativoXRegistroIrregolarita GiustificativoXRegistroIrregolaritaObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZGiustificativoXRegistroIrregolaritaInsert", new string[] {"IdGiustificativo", "IdRegistroIrregolarita", 
"DataInserimento", "CfInserimento", "DataModifica", 
"CfModifica", 



}, new string[] {"int", "int", 
"DateTime", "string", "DateTime", 
"string", 



}, "");
                CompileIUCmd(false, insertCmd, GiustificativoXRegistroIrregolaritaObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    GiustificativoXRegistroIrregolaritaObj.IdGiustificativoXIrregolarita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_GIUSTIFICATIVO_X_IRREGOLARITA"]);
                }
                GiustificativoXRegistroIrregolaritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                GiustificativoXRegistroIrregolaritaObj.IsDirty = false;
                GiustificativoXRegistroIrregolaritaObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, GiustificativoXRegistroIrregolarita GiustificativoXRegistroIrregolaritaObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZGiustificativoXRegistroIrregolaritaUpdate", new string[] {"IdGiustificativoXIrregolarita", "IdGiustificativo", "IdRegistroIrregolarita", 
"DataInserimento", "CfInserimento", "DataModifica", 
"CfModifica", 



}, new string[] {"int", "int", "int", 
"DateTime", "string", "DateTime", 
"string", 



}, "");
                CompileIUCmd(true, updateCmd, GiustificativoXRegistroIrregolaritaObj, db.CommandFirstChar);
                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                if (d != null)
                {
                    i = 1;
                    GiustificativoXRegistroIrregolaritaObj.DataModifica = d;
                }
                GiustificativoXRegistroIrregolaritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                GiustificativoXRegistroIrregolaritaObj.IsDirty = false;
                GiustificativoXRegistroIrregolaritaObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, GiustificativoXRegistroIrregolarita GiustificativoXRegistroIrregolaritaObj)
        {
            switch (GiustificativoXRegistroIrregolaritaObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, GiustificativoXRegistroIrregolaritaObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, GiustificativoXRegistroIrregolaritaObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, GiustificativoXRegistroIrregolaritaObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, GiustificativoXRegistroIrregolaritaCollection GiustificativoXRegistroIrregolaritaCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZGiustificativoXRegistroIrregolaritaUpdate", new string[] {"IdGiustificativoXIrregolarita", "IdGiustificativo", "IdRegistroIrregolarita", 
"DataInserimento", "CfInserimento", "DataModifica", 
"CfModifica", 



}, new string[] {"int", "int", "int", 
"DateTime", "string", "DateTime", 
"string", 



}, "");
                IDbCommand insertCmd = db.InitCmd("ZGiustificativoXRegistroIrregolaritaInsert", new string[] {"IdGiustificativo", "IdRegistroIrregolarita", 
"DataInserimento", "CfInserimento", "DataModifica", 
"CfModifica", 



}, new string[] {"int", "int", 
"DateTime", "string", "DateTime", 
"string", 



}, "");
                IDbCommand deleteCmd = db.InitCmd("ZGiustificativoXRegistroIrregolaritaDelete", new string[] { "IdGiustificativoXIrregolarita" }, new string[] { "int" }, "");
                for (int i = 0; i < GiustificativoXRegistroIrregolaritaCollectionObj.Count; i++)
                {
                    switch (GiustificativoXRegistroIrregolaritaCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, GiustificativoXRegistroIrregolaritaCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    GiustificativoXRegistroIrregolaritaCollectionObj[i].IdGiustificativoXIrregolarita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_GIUSTIFICATIVO_X_IRREGOLARITA"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, GiustificativoXRegistroIrregolaritaCollectionObj[i], db.CommandFirstChar);
                                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                                if (d != null)
                                {
                                    returnValue++;
                                    GiustificativoXRegistroIrregolaritaCollectionObj[i].DataModifica = d;
                                }
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (GiustificativoXRegistroIrregolaritaCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdGiustificativoXIrregolarita", (SiarLibrary.NullTypes.IntNT)GiustificativoXRegistroIrregolaritaCollectionObj[i].IdGiustificativoXIrregolarita);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < GiustificativoXRegistroIrregolaritaCollectionObj.Count; i++)
                {
                    if ((GiustificativoXRegistroIrregolaritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (GiustificativoXRegistroIrregolaritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        GiustificativoXRegistroIrregolaritaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        GiustificativoXRegistroIrregolaritaCollectionObj[i].IsDirty = false;
                        GiustificativoXRegistroIrregolaritaCollectionObj[i].IsPersistent = true;
                    }
                    if ((GiustificativoXRegistroIrregolaritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        GiustificativoXRegistroIrregolaritaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        GiustificativoXRegistroIrregolaritaCollectionObj[i].IsDirty = false;
                        GiustificativoXRegistroIrregolaritaCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, GiustificativoXRegistroIrregolarita GiustificativoXRegistroIrregolaritaObj)
        {
            int returnValue = 0;
            if (GiustificativoXRegistroIrregolaritaObj.IsPersistent)
            {
                returnValue = Delete(db, GiustificativoXRegistroIrregolaritaObj.IdGiustificativoXIrregolarita);
            }
            GiustificativoXRegistroIrregolaritaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            GiustificativoXRegistroIrregolaritaObj.IsDirty = false;
            GiustificativoXRegistroIrregolaritaObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdGiustificativoXIrregolaritaValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZGiustificativoXRegistroIrregolaritaDelete", new string[] { "IdGiustificativoXIrregolarita" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdGiustificativoXIrregolarita", (SiarLibrary.NullTypes.IntNT)IdGiustificativoXIrregolaritaValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, GiustificativoXRegistroIrregolaritaCollection GiustificativoXRegistroIrregolaritaCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZGiustificativoXRegistroIrregolaritaDelete", new string[] { "IdGiustificativoXIrregolarita" }, new string[] { "int" }, "");
                for (int i = 0; i < GiustificativoXRegistroIrregolaritaCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdGiustificativoXIrregolarita", GiustificativoXRegistroIrregolaritaCollectionObj[i].IdGiustificativoXIrregolarita);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < GiustificativoXRegistroIrregolaritaCollectionObj.Count; i++)
                {
                    if ((GiustificativoXRegistroIrregolaritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (GiustificativoXRegistroIrregolaritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        GiustificativoXRegistroIrregolaritaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        GiustificativoXRegistroIrregolaritaCollectionObj[i].IsDirty = false;
                        GiustificativoXRegistroIrregolaritaCollectionObj[i].IsPersistent = false;
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
        public static GiustificativoXRegistroIrregolarita GetById(DbProvider db, int IdGiustificativoXIrregolaritaValue)
        {
            GiustificativoXRegistroIrregolarita GiustificativoXRegistroIrregolaritaObj = null;
            IDbCommand readCmd = db.InitCmd("ZGiustificativoXRegistroIrregolaritaGetById", new string[] { "IdGiustificativoXIrregolarita" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdGiustificativoXIrregolarita", (SiarLibrary.NullTypes.IntNT)IdGiustificativoXIrregolaritaValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                GiustificativoXRegistroIrregolaritaObj = GetFromDatareader(db);
                GiustificativoXRegistroIrregolaritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                GiustificativoXRegistroIrregolaritaObj.IsDirty = false;
                GiustificativoXRegistroIrregolaritaObj.IsPersistent = true;
            }
            db.Close();
            return GiustificativoXRegistroIrregolaritaObj;
        }

        //getFromDatareader
        public static GiustificativoXRegistroIrregolarita GetFromDatareader(DbProvider db)
        {
            GiustificativoXRegistroIrregolarita GiustificativoXRegistroIrregolaritaObj = new GiustificativoXRegistroIrregolarita();
            GiustificativoXRegistroIrregolaritaObj.IdGiustificativoXIrregolarita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_GIUSTIFICATIVO_X_IRREGOLARITA"]);
            GiustificativoXRegistroIrregolaritaObj.IdGiustificativo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_GIUSTIFICATIVO"]);
            GiustificativoXRegistroIrregolaritaObj.IdRegistroIrregolarita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_REGISTRO_IRREGOLARITA"]);
            GiustificativoXRegistroIrregolaritaObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
            GiustificativoXRegistroIrregolaritaObj.CfInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_INSERIMENTO"]);
            GiustificativoXRegistroIrregolaritaObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
            GiustificativoXRegistroIrregolaritaObj.CfModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_MODIFICA"]);
            GiustificativoXRegistroIrregolaritaObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
            GiustificativoXRegistroIrregolaritaObj.Numero = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO"]);
            GiustificativoXRegistroIrregolaritaObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
            GiustificativoXRegistroIrregolaritaObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
            GiustificativoXRegistroIrregolaritaObj.NumeroDoctrasporto = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO_DOCTRASPORTO"]);
            GiustificativoXRegistroIrregolaritaObj.DataDoctrasporto = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_DOCTRASPORTO"]);
            GiustificativoXRegistroIrregolaritaObj.Imponibile = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPONIBILE"]);
            GiustificativoXRegistroIrregolaritaObj.Iva = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IVA"]);
            GiustificativoXRegistroIrregolaritaObj.AltriOneri = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["ALTRI_ONERI"]);
            GiustificativoXRegistroIrregolaritaObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
            GiustificativoXRegistroIrregolaritaObj.CfFornitore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_FORNITORE"]);
            GiustificativoXRegistroIrregolaritaObj.DescrizioneFornitore = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_FORNITORE"]);
            GiustificativoXRegistroIrregolaritaObj.IvaNonRecuperabile = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IVA_NON_RECUPERABILE"]);
            GiustificativoXRegistroIrregolaritaObj.IdFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILE"]);
            GiustificativoXRegistroIrregolaritaObj.InIntegrazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IN_INTEGRAZIONE"]);
            GiustificativoXRegistroIrregolaritaObj.IdFileModificatoIntegrazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ID_FILE_MODIFICATO_INTEGRAZIONE"]);
            GiustificativoXRegistroIrregolaritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            GiustificativoXRegistroIrregolaritaObj.IsDirty = false;
            GiustificativoXRegistroIrregolaritaObj.IsPersistent = true;
            return GiustificativoXRegistroIrregolaritaObj;
        }

        //Find Select

        public static GiustificativoXRegistroIrregolaritaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdGiustificativoXIrregolaritaEqualThis, SiarLibrary.NullTypes.IntNT IdGiustificativoEqualThis, SiarLibrary.NullTypes.IntNT IdRegistroIrregolaritaEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.StringNT CfInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis,
SiarLibrary.NullTypes.StringNT CfModificaEqualThis)
        {

            GiustificativoXRegistroIrregolaritaCollection GiustificativoXRegistroIrregolaritaCollectionObj = new GiustificativoXRegistroIrregolaritaCollection();

            IDbCommand findCmd = db.InitCmd("Zgiustificativoxregistroirregolaritafindselect", new string[] {"IdGiustificativoXIrregolaritaequalthis", "IdGiustificativoequalthis", "IdRegistroIrregolaritaequalthis", 
"DataInserimentoequalthis", "CfInserimentoequalthis", "DataModificaequalthis", 
"CfModificaequalthis"}, new string[] {"int", "int", "int", 
"DateTime", "string", "DateTime", 
"string"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdGiustificativoXIrregolaritaequalthis", IdGiustificativoXIrregolaritaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdGiustificativoequalthis", IdGiustificativoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdRegistroIrregolaritaequalthis", IdRegistroIrregolaritaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfInserimentoequalthis", CfInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfModificaequalthis", CfModificaEqualThis);
            GiustificativoXRegistroIrregolarita GiustificativoXRegistroIrregolaritaObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                GiustificativoXRegistroIrregolaritaObj = GetFromDatareader(db);
                GiustificativoXRegistroIrregolaritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                GiustificativoXRegistroIrregolaritaObj.IsDirty = false;
                GiustificativoXRegistroIrregolaritaObj.IsPersistent = true;
                GiustificativoXRegistroIrregolaritaCollectionObj.Add(GiustificativoXRegistroIrregolaritaObj);
            }
            db.Close();
            return GiustificativoXRegistroIrregolaritaCollectionObj;
        }

        //Find Find

        public static GiustificativoXRegistroIrregolaritaCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdGiustificativoXIrregolaritaEqualThis, SiarLibrary.NullTypes.IntNT IdGiustificativoEqualThis, SiarLibrary.NullTypes.IntNT IdRegistroIrregolaritaEqualThis,
SiarLibrary.NullTypes.IntNT IdProgettoEqualThis)
        {

            GiustificativoXRegistroIrregolaritaCollection GiustificativoXRegistroIrregolaritaCollectionObj = new GiustificativoXRegistroIrregolaritaCollection();

            IDbCommand findCmd = db.InitCmd("Zgiustificativoxregistroirregolaritafindfind", new string[] {"IdGiustificativoXIrregolaritaequalthis", "IdGiustificativoequalthis", "IdRegistroIrregolaritaequalthis", 
"IdProgettoequalthis"}, new string[] {"int", "int", "int", 
"int"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdGiustificativoXIrregolaritaequalthis", IdGiustificativoXIrregolaritaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdGiustificativoequalthis", IdGiustificativoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdRegistroIrregolaritaequalthis", IdRegistroIrregolaritaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            GiustificativoXRegistroIrregolarita GiustificativoXRegistroIrregolaritaObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                GiustificativoXRegistroIrregolaritaObj = GetFromDatareader(db);
                GiustificativoXRegistroIrregolaritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                GiustificativoXRegistroIrregolaritaObj.IsDirty = false;
                GiustificativoXRegistroIrregolaritaObj.IsPersistent = true;
                GiustificativoXRegistroIrregolaritaCollectionObj.Add(GiustificativoXRegistroIrregolaritaObj);
            }
            db.Close();
            return GiustificativoXRegistroIrregolaritaCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for GiustificativoXRegistroIrregolaritaCollectionProvider:IGiustificativoXRegistroIrregolaritaProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class GiustificativoXRegistroIrregolaritaCollectionProvider : IGiustificativoXRegistroIrregolaritaProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di GiustificativoXRegistroIrregolarita
        protected GiustificativoXRegistroIrregolaritaCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public GiustificativoXRegistroIrregolaritaCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new GiustificativoXRegistroIrregolaritaCollection(this);
        }

        //Costruttore 2: popola la collection
        public GiustificativoXRegistroIrregolaritaCollectionProvider(IntNT IdgiustificativoxirregolaritaEqualThis, IntNT IdgiustificativoEqualThis, IntNT IdregistroirregolaritaEqualThis,
IntNT IdprogettoEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IdgiustificativoxirregolaritaEqualThis, IdgiustificativoEqualThis, IdregistroirregolaritaEqualThis,
IdprogettoEqualThis);
        }

        //Costruttore3: ha in input giustificativoxregistroirregolaritaCollectionObj - non popola la collection
        public GiustificativoXRegistroIrregolaritaCollectionProvider(GiustificativoXRegistroIrregolaritaCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public GiustificativoXRegistroIrregolaritaCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new GiustificativoXRegistroIrregolaritaCollection(this);
        }

        //Get e Set
        public GiustificativoXRegistroIrregolaritaCollection CollectionObj
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
        public int SaveCollection(GiustificativoXRegistroIrregolaritaCollection collectionObj)
        {
            return GiustificativoXRegistroIrregolaritaDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(GiustificativoXRegistroIrregolarita giustificativoxregistroirregolaritaObj)
        {
            return GiustificativoXRegistroIrregolaritaDAL.Save(_dbProviderObj, giustificativoxregistroirregolaritaObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(GiustificativoXRegistroIrregolaritaCollection collectionObj)
        {
            return GiustificativoXRegistroIrregolaritaDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(GiustificativoXRegistroIrregolarita giustificativoxregistroirregolaritaObj)
        {
            return GiustificativoXRegistroIrregolaritaDAL.Delete(_dbProviderObj, giustificativoxregistroirregolaritaObj);
        }

        //getById
        public GiustificativoXRegistroIrregolarita GetById(IntNT IdGiustificativoXIrregolaritaValue)
        {
            GiustificativoXRegistroIrregolarita GiustificativoXRegistroIrregolaritaTemp = GiustificativoXRegistroIrregolaritaDAL.GetById(_dbProviderObj, IdGiustificativoXIrregolaritaValue);
            if (GiustificativoXRegistroIrregolaritaTemp != null) GiustificativoXRegistroIrregolaritaTemp.Provider = this;
            return GiustificativoXRegistroIrregolaritaTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public GiustificativoXRegistroIrregolaritaCollection Select(IntNT IdgiustificativoxirregolaritaEqualThis, IntNT IdgiustificativoEqualThis, IntNT IdregistroirregolaritaEqualThis,
DatetimeNT DatainserimentoEqualThis, StringNT CfinserimentoEqualThis, DatetimeNT DatamodificaEqualThis,
StringNT CfmodificaEqualThis)
        {
            GiustificativoXRegistroIrregolaritaCollection GiustificativoXRegistroIrregolaritaCollectionTemp = GiustificativoXRegistroIrregolaritaDAL.Select(_dbProviderObj, IdgiustificativoxirregolaritaEqualThis, IdgiustificativoEqualThis, IdregistroirregolaritaEqualThis,
DatainserimentoEqualThis, CfinserimentoEqualThis, DatamodificaEqualThis,
CfmodificaEqualThis);
            GiustificativoXRegistroIrregolaritaCollectionTemp.Provider = this;
            return GiustificativoXRegistroIrregolaritaCollectionTemp;
        }

        //Find: popola la collection
        public GiustificativoXRegistroIrregolaritaCollection Find(IntNT IdgiustificativoxirregolaritaEqualThis, IntNT IdgiustificativoEqualThis, IntNT IdregistroirregolaritaEqualThis,
IntNT IdprogettoEqualThis)
        {
            GiustificativoXRegistroIrregolaritaCollection GiustificativoXRegistroIrregolaritaCollectionTemp = GiustificativoXRegistroIrregolaritaDAL.Find(_dbProviderObj, IdgiustificativoxirregolaritaEqualThis, IdgiustificativoEqualThis, IdregistroirregolaritaEqualThis,
IdprogettoEqualThis);
            GiustificativoXRegistroIrregolaritaCollectionTemp.Provider = this;
            return GiustificativoXRegistroIrregolaritaCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<GIUSTIFICATIVO_X_REGISTRO_IRREGOLARITA>
  <ViewName>VGIUSTIFICATIVO_X_REGISTRO_IRREGOLARITA</ViewName>
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
      <ID_GIUSTIFICATIVO_X_IRREGOLARITA>Equal</ID_GIUSTIFICATIVO_X_IRREGOLARITA>
      <ID_GIUSTIFICATIVO>Equal</ID_GIUSTIFICATIVO>
      <ID_REGISTRO_IRREGOLARITA>Equal</ID_REGISTRO_IRREGOLARITA>
      <ID_PROGETTO>Equal</ID_PROGETTO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</GIUSTIFICATIVO_X_REGISTRO_IRREGOLARITA>
*/
