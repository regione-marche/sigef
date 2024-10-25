using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per CodificaGenerica
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface ICodificaGenericaProvider
    {
        int Save(CodificaGenerica CodificaGenericaObj);
        int SaveCollection(CodificaGenericaCollection collectionObj);
        int Delete(CodificaGenerica CodificaGenericaObj);
        int DeleteCollection(CodificaGenericaCollection collectionObj);
    }
    /// <summary>
    /// Summary description for CodificaGenerica
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class CodificaGenerica : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _Id;
        private NullTypes.IntNT _IdTipoCodifica;
        private NullTypes.StringNT _Descrizione;
        private NullTypes.StringNT _ValoreTxt;
        private NullTypes.StringNT _CodiceTxt;
        private NullTypes.IntNT _ValoreInt1;
        private NullTypes.IntNT _ValoreInt2;
        private NullTypes.DecimalNT _ValoreDec1;
        private NullTypes.DecimalNT _ValoreDec2;
        private NullTypes.StringNT _Flag;
        private NullTypes.DatetimeNT _DataInizioValidita;
        private NullTypes.DatetimeNT _DataFineValidita;
        private NullTypes.IntNT _IdPadre;
        private NullTypes.StringNT _ValoreTxt2;
        private NullTypes.StringNT _ValoreTxt3;
        [NonSerialized]
        private ICodificaGenericaProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public ICodificaGenericaProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public CodificaGenerica()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:ID
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT Id
        {
            get { return _Id; }
            set
            {
                if (Id != value)
                {
                    _Id = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_TIPO_CODIFICA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdTipoCodifica
        {
            get { return _IdTipoCodifica; }
            set
            {
                if (IdTipoCodifica != value)
                {
                    _IdTipoCodifica = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DESCRIZIONE
        /// Tipo sul db:NVARCHAR(4000)
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
        /// Corrisponde al campo:VALORE_TXT
        /// Tipo sul db:NTEXT
        /// </summary>
        public NullTypes.StringNT ValoreTxt
        {
            get { return _ValoreTxt; }
            set
            {
                if (ValoreTxt != value)
                {
                    _ValoreTxt = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CODICE_TXT
        /// Tipo sul db:NVARCHAR(50)
        /// </summary>
        public NullTypes.StringNT CodiceTxt
        {
            get { return _CodiceTxt; }
            set
            {
                if (CodiceTxt != value)
                {
                    _CodiceTxt = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:VALORE_INT1
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT ValoreInt1
        {
            get { return _ValoreInt1; }
            set
            {
                if (ValoreInt1 != value)
                {
                    _ValoreInt1 = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:VALORE_INT2
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT ValoreInt2
        {
            get { return _ValoreInt2; }
            set
            {
                if (ValoreInt2 != value)
                {
                    _ValoreInt2 = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:VALORE_DEC1
        /// Tipo sul db:DECIMAL(20,2)
        /// </summary>
        public NullTypes.DecimalNT ValoreDec1
        {
            get { return _ValoreDec1; }
            set
            {
                if (ValoreDec1 != value)
                {
                    _ValoreDec1 = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:VALORE_DEC2
        /// Tipo sul db:DECIMAL(20,2)
        /// </summary>
        public NullTypes.DecimalNT ValoreDec2
        {
            get { return _ValoreDec2; }
            set
            {
                if (ValoreDec2 != value)
                {
                    _ValoreDec2 = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:FLAG
        /// Tipo sul db:CHAR(1)
        /// </summary>
        public NullTypes.StringNT Flag
        {
            get { return _Flag; }
            set
            {
                if (Flag != value)
                {
                    _Flag = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_INIZIO_VALIDITA
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataInizioValidita
        {
            get { return _DataInizioValidita; }
            set
            {
                if (DataInizioValidita != value)
                {
                    _DataInizioValidita = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_FINE_VALIDITA
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataFineValidita
        {
            get { return _DataFineValidita; }
            set
            {
                if (DataFineValidita != value)
                {
                    _DataFineValidita = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_PADRE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdPadre
        {
            get { return _IdPadre; }
            set
            {
                if (IdPadre != value)
                {
                    _IdPadre = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:VALORE_TXT2
        /// Tipo sul db:NTEXT
        /// </summary>
        public NullTypes.StringNT ValoreTxt2
        {
            get { return _ValoreTxt2; }
            set
            {
                if (ValoreTxt2 != value)
                {
                    _ValoreTxt2 = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:VALORE_TXT3
        /// Tipo sul db:NTEXT
        /// </summary>
        public NullTypes.StringNT ValoreTxt3
        {
            get { return _ValoreTxt3; }
            set
            {
                if (ValoreTxt3 != value)
                {
                    _ValoreTxt3 = value;
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
    /// Summary description for CodificaGenericaCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class CodificaGenericaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private CodificaGenericaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((CodificaGenerica)info.GetValue(i.ToString(), typeof(CodificaGenerica)));
            }
        }

        //Costruttore
        public CodificaGenericaCollection()
        {
            this.ItemType = typeof(CodificaGenerica);
        }

        //Costruttore con provider
        public CodificaGenericaCollection(ICodificaGenericaProvider providerObj)
        {
            this.ItemType = typeof(CodificaGenerica);
            this.Provider = providerObj;
        }

        //Get e Set
        public new CodificaGenerica this[int index]
        {
            get { return (CodificaGenerica)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new CodificaGenericaCollection GetChanges()
        {
            return (CodificaGenericaCollection)base.GetChanges();
        }

        [NonSerialized]
        private ICodificaGenericaProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public ICodificaGenericaProvider Provider
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
        public int Add(CodificaGenerica CodificaGenericaObj)
        {
            if (CodificaGenericaObj.Provider == null) CodificaGenericaObj.Provider = this.Provider;
            return base.Add(CodificaGenericaObj);
        }

        //AddCollection
        public void AddCollection(CodificaGenericaCollection CodificaGenericaCollectionObj)
        {
            foreach (CodificaGenerica CodificaGenericaObj in CodificaGenericaCollectionObj)
                this.Add(CodificaGenericaObj);
        }

        //Insert
        public void Insert(int index, CodificaGenerica CodificaGenericaObj)
        {
            if (CodificaGenericaObj.Provider == null) CodificaGenericaObj.Provider = this.Provider;
            base.Insert(index, CodificaGenericaObj);
        }

        //CollectionGetById
        public CodificaGenerica CollectionGetById(NullTypes.IntNT IdValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].Id == IdValue))
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
        public CodificaGenericaCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdTipoCodificaEqualThis, NullTypes.StringNT DescrizioneEqualThis,
NullTypes.StringNT CodiceTxtEqualThis, NullTypes.IntNT ValoreInt1EqualThis, NullTypes.IntNT ValoreInt2EqualThis,
NullTypes.DecimalNT ValoreDec1EqualThis, NullTypes.DecimalNT ValoreDec2EqualThis, NullTypes.StringNT FlagEqualThis,
NullTypes.DatetimeNT DataInizioValiditaEqualThis, NullTypes.DatetimeNT DataFineValiditaEqualThis, NullTypes.IntNT IdPadreEqualThis)
        {
            CodificaGenericaCollection CodificaGenericaCollectionTemp = new CodificaGenericaCollection();
            foreach (CodificaGenerica CodificaGenericaItem in this)
            {
                if (((IdEqualThis == null) || ((CodificaGenericaItem.Id != null) && (CodificaGenericaItem.Id.Value == IdEqualThis.Value))) && ((IdTipoCodificaEqualThis == null) || ((CodificaGenericaItem.IdTipoCodifica != null) && (CodificaGenericaItem.IdTipoCodifica.Value == IdTipoCodificaEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((CodificaGenericaItem.Descrizione != null) && (CodificaGenericaItem.Descrizione.Value == DescrizioneEqualThis.Value))) &&
((CodiceTxtEqualThis == null) || ((CodificaGenericaItem.CodiceTxt != null) && (CodificaGenericaItem.CodiceTxt.Value == CodiceTxtEqualThis.Value))) && ((ValoreInt1EqualThis == null) || ((CodificaGenericaItem.ValoreInt1 != null) && (CodificaGenericaItem.ValoreInt1.Value == ValoreInt1EqualThis.Value))) && ((ValoreInt2EqualThis == null) || ((CodificaGenericaItem.ValoreInt2 != null) && (CodificaGenericaItem.ValoreInt2.Value == ValoreInt2EqualThis.Value))) &&
((ValoreDec1EqualThis == null) || ((CodificaGenericaItem.ValoreDec1 != null) && (CodificaGenericaItem.ValoreDec1.Value == ValoreDec1EqualThis.Value))) && ((ValoreDec2EqualThis == null) || ((CodificaGenericaItem.ValoreDec2 != null) && (CodificaGenericaItem.ValoreDec2.Value == ValoreDec2EqualThis.Value))) && ((FlagEqualThis == null) || ((CodificaGenericaItem.Flag != null) && (CodificaGenericaItem.Flag.Value == FlagEqualThis.Value))) &&
((DataInizioValiditaEqualThis == null) || ((CodificaGenericaItem.DataInizioValidita != null) && (CodificaGenericaItem.DataInizioValidita.Value == DataInizioValiditaEqualThis.Value))) && ((DataFineValiditaEqualThis == null) || ((CodificaGenericaItem.DataFineValidita != null) && (CodificaGenericaItem.DataFineValidita.Value == DataFineValiditaEqualThis.Value))) && ((IdPadreEqualThis == null) || ((CodificaGenericaItem.IdPadre != null) && (CodificaGenericaItem.IdPadre.Value == IdPadreEqualThis.Value))))
                {
                    CodificaGenericaCollectionTemp.Add(CodificaGenericaItem);
                }
            }
            return CodificaGenericaCollectionTemp;
        }


        //filter: effettua una ricerca all'interno della collection
        // se il parametro di ricerca è null, prende tutto,
        // anche i record che hanno quel campo null
        // altrimenti scarta i record che hanno quel campo null ...
        // ...e confronta gli altri
        public CodificaGenericaCollection Filter(NullTypes.StringNT FlagLike, NullTypes.IntNT ValoreInt1EqualThis, NullTypes.IntNT ValoreInt2EqualThis,
NullTypes.DecimalNT ValoreDec1EqualThis, NullTypes.DecimalNT ValoreDec2EqualThis)
        {
            CodificaGenericaCollection CodificaGenericaCollectionTemp = new CodificaGenericaCollection();
            foreach (CodificaGenerica CodificaGenericaItem in this)
            {
                if (((FlagLike == null) || ((CodificaGenericaItem.Flag != null) && (CodificaGenericaItem.Flag.Like(FlagLike.Value)))) && ((ValoreInt1EqualThis == null) || ((CodificaGenericaItem.ValoreInt1 != null) && (CodificaGenericaItem.ValoreInt1.Value == ValoreInt1EqualThis.Value))) && ((ValoreInt2EqualThis == null) || ((CodificaGenericaItem.ValoreInt2 != null) && (CodificaGenericaItem.ValoreInt2.Value == ValoreInt2EqualThis.Value))) &&
((ValoreDec1EqualThis == null) || ((CodificaGenericaItem.ValoreDec1 != null) && (CodificaGenericaItem.ValoreDec1.Value == ValoreDec1EqualThis.Value))) && ((ValoreDec2EqualThis == null) || ((CodificaGenericaItem.ValoreDec2 != null) && (CodificaGenericaItem.ValoreDec2.Value == ValoreDec2EqualThis.Value))))
                {
                    CodificaGenericaCollectionTemp.Add(CodificaGenericaItem);
                }
            }
            return CodificaGenericaCollectionTemp;
        }


        //filter: effettua una ricerca all'interno della collection
        // se il parametro di ricerca è null, prende tutto,
        // anche i record che hanno quel campo null
        // altrimenti scarta i record che hanno quel campo null ...
        // ...e confronta gli altri
        public CodificaGenericaCollection FTipo(NullTypes.IntNT IdTipoCodificaEqualThis)
        {
            CodificaGenericaCollection CodificaGenericaCollectionTemp = new CodificaGenericaCollection();
            foreach (CodificaGenerica CodificaGenericaItem in this)
            {
                if (((IdTipoCodificaEqualThis == null) || ((CodificaGenericaItem.IdTipoCodifica != null) && (CodificaGenericaItem.IdTipoCodifica.Value == IdTipoCodificaEqualThis.Value))))
                {
                    CodificaGenericaCollectionTemp.Add(CodificaGenericaItem);
                }
            }
            return CodificaGenericaCollectionTemp;
        }


        //filter: effettua una ricerca all'interno della collection
        // se il parametro di ricerca è null, prende tutto,
        // anche i record che hanno quel campo null
        // altrimenti scarta i record che hanno quel campo null ...
        // ...e confronta gli altri
        public CodificaGenericaCollection FPadre(NullTypes.IntNT IdPadreEqualThis)
        {
            CodificaGenericaCollection CodificaGenericaCollectionTemp = new CodificaGenericaCollection();
            foreach (CodificaGenerica CodificaGenericaItem in this)
            {
                if (((IdPadreEqualThis == null) || ((CodificaGenericaItem.IdPadre != null) && (CodificaGenericaItem.IdPadre.Value == IdPadreEqualThis.Value))))
                {
                    CodificaGenericaCollectionTemp.Add(CodificaGenericaItem);
                }
            }
            return CodificaGenericaCollectionTemp;
        }



    }
}

namespace SiarLibrary
{

    /// <summary>
    /// Summary description for CodificaGenericaDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class CodificaGenericaDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CodificaGenerica CodificaGenericaObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "ID", CodificaGenericaObj.Id);
            DbProvider.SetCmdParam(cmd, firstChar + "ID_TIPO_CODIFICA", CodificaGenericaObj.IdTipoCodifica);
            DbProvider.SetCmdParam(cmd, firstChar + "DESCRIZIONE", CodificaGenericaObj.Descrizione);
            DbProvider.SetCmdParam(cmd, firstChar + "VALORE_TXT", CodificaGenericaObj.ValoreTxt);
            DbProvider.SetCmdParam(cmd, firstChar + "CODICE_TXT", CodificaGenericaObj.CodiceTxt);
            DbProvider.SetCmdParam(cmd, firstChar + "VALORE_INT1", CodificaGenericaObj.ValoreInt1);
            DbProvider.SetCmdParam(cmd, firstChar + "VALORE_INT2", CodificaGenericaObj.ValoreInt2);
            DbProvider.SetCmdParam(cmd, firstChar + "VALORE_DEC1", CodificaGenericaObj.ValoreDec1);
            DbProvider.SetCmdParam(cmd, firstChar + "VALORE_DEC2", CodificaGenericaObj.ValoreDec2);
            DbProvider.SetCmdParam(cmd, firstChar + "FLAG", CodificaGenericaObj.Flag);
            DbProvider.SetCmdParam(cmd, firstChar + "DATA_INIZIO_VALIDITA", CodificaGenericaObj.DataInizioValidita);
            DbProvider.SetCmdParam(cmd, firstChar + "DATA_FINE_VALIDITA", CodificaGenericaObj.DataFineValidita);
            DbProvider.SetCmdParam(cmd, firstChar + "ID_PADRE", CodificaGenericaObj.IdPadre);
            DbProvider.SetCmdParam(cmd, firstChar + "VALORE_TXT2", CodificaGenericaObj.ValoreTxt2);
            DbProvider.SetCmdParam(cmd, firstChar + "VALORE_TXT3", CodificaGenericaObj.ValoreTxt3);
        }
        //Insert
        private static int Insert(DbProvider db, CodificaGenerica CodificaGenericaObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("Z_CODIFICA_GENERICA_INSERT", new string[] {"ID", "ID_TIPO_CODIFICA", "DESCRIZIONE", 
"VALORE_TXT", "CODICE_TXT", "VALORE_INT1", 
"VALORE_INT2", "VALORE_DEC1", "VALORE_DEC2", 
"FLAG", "DATA_INIZIO_VALIDITA", "DATA_FINE_VALIDITA", 
"ID_PADRE", "VALORE_TXT2", "VALORE_TXT3"}, new string[] {"int", "int", "string", 
"string", "string", "int", 
"int", "decimal", "decimal", 
"string", "DateTime", "DateTime", 
"int", "string", "string"}, "");
                CompileIUCmd(false, insertCmd, CodificaGenericaObj, db.CommandFirstChar);
                i = db.Execute(insertCmd);
                CodificaGenericaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                CodificaGenericaObj.IsDirty = false;
                CodificaGenericaObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, CodificaGenerica CodificaGenericaObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("Z_CODIFICA_GENERICA_UPDATE", new string[] {"ID", "ID_TIPO_CODIFICA", "DESCRIZIONE", 
"VALORE_TXT", "CODICE_TXT", "VALORE_INT1", 
"VALORE_INT2", "VALORE_DEC1", "VALORE_DEC2", 
"FLAG", "DATA_INIZIO_VALIDITA", "DATA_FINE_VALIDITA", 
"ID_PADRE", "VALORE_TXT2", "VALORE_TXT3"}, new string[] {"int", "int", "string", 
"string", "string", "int", 
"int", "decimal", "decimal", 
"string", "DateTime", "DateTime", 
"int", "string", "string"}, "");
                CompileIUCmd(true, updateCmd, CodificaGenericaObj, db.CommandFirstChar);
                i = db.Execute(updateCmd);
                CodificaGenericaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                CodificaGenericaObj.IsDirty = false;
                CodificaGenericaObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, CodificaGenerica CodificaGenericaObj)
        {
            switch (CodificaGenericaObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, CodificaGenericaObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, CodificaGenericaObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, CodificaGenericaObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, CodificaGenericaCollection CodificaGenericaCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("Z_CODIFICA_GENERICA_UPDATE", new string[] {"ID", "ID_TIPO_CODIFICA", "DESCRIZIONE", 
"VALORE_TXT", "CODICE_TXT", "VALORE_INT1", 
"VALORE_INT2", "VALORE_DEC1", "VALORE_DEC2", 
"FLAG", "DATA_INIZIO_VALIDITA", "DATA_FINE_VALIDITA", 
"ID_PADRE", "VALORE_TXT2", "VALORE_TXT3"}, new string[] {"int", "int", "string", 
"string", "string", "int", 
"int", "decimal", "decimal", 
"string", "DateTime", "DateTime", 
"int", "string", "string"}, "");
                IDbCommand insertCmd = db.InitCmd("Z_CODIFICA_GENERICA_INSERT", new string[] {"ID", "ID_TIPO_CODIFICA", "DESCRIZIONE", 
"VALORE_TXT", "CODICE_TXT", "VALORE_INT1", 
"VALORE_INT2", "VALORE_DEC1", "VALORE_DEC2", 
"FLAG", "DATA_INIZIO_VALIDITA", "DATA_FINE_VALIDITA", 
"ID_PADRE", "VALORE_TXT2", "VALORE_TXT3"}, new string[] {"int", "int", "string", 
"string", "string", "int", 
"int", "decimal", "decimal", 
"string", "DateTime", "DateTime", 
"int", "string", "string"}, "");
                IDbCommand deleteCmd = db.InitCmd("Z_CODIFICA_GENERICA_DELETE", new string[] { "ID" }, new string[] { "int" }, "");
                for (int i = 0; i < CodificaGenericaCollectionObj.Count; i++)
                {
                    switch (CodificaGenericaCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, CodificaGenericaCollectionObj[i], db.CommandFirstChar);
                                returnValue += db.Execute(insertCmd);
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, CodificaGenericaCollectionObj[i], db.CommandFirstChar);
                                returnValue = returnValue + db.Execute(updateCmd);
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (CodificaGenericaCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "ID", (NullTypes.IntNT)CodificaGenericaCollectionObj[i].Id);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < CodificaGenericaCollectionObj.Count; i++)
                {
                    if ((CodificaGenericaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CodificaGenericaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        CodificaGenericaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        CodificaGenericaCollectionObj[i].IsDirty = false;
                        CodificaGenericaCollectionObj[i].IsPersistent = true;
                    }
                    if ((CodificaGenericaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        CodificaGenericaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        CodificaGenericaCollectionObj[i].IsDirty = false;
                        CodificaGenericaCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, CodificaGenerica CodificaGenericaObj)
        {
            int returnValue = 0;
            if (CodificaGenericaObj.IsPersistent)
            {
                returnValue = Delete(db, CodificaGenericaObj.Id);
            }
            CodificaGenericaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            CodificaGenericaObj.IsDirty = false;
            CodificaGenericaObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("Z_CODIFICA_GENERICA_DELETE", new string[] { "ID" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "ID", (NullTypes.IntNT)IdValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, CodificaGenericaCollection CodificaGenericaCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("Z_CODIFICA_GENERICA_DELETE", new string[] { "ID" }, new string[] { "int" }, "");
                for (int i = 0; i < CodificaGenericaCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "ID", CodificaGenericaCollectionObj[i].Id);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < CodificaGenericaCollectionObj.Count; i++)
                {
                    if ((CodificaGenericaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CodificaGenericaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        CodificaGenericaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        CodificaGenericaCollectionObj[i].IsDirty = false;
                        CodificaGenericaCollectionObj[i].IsPersistent = false;
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
        public static CodificaGenerica GetById(DbProvider db, int IdValue)
        {
            CodificaGenerica CodificaGenericaObj = null;
            IDbCommand readCmd = db.InitCmd("Z_CODIFICA_GENERICA_GET_BY_ID", new string[] { "ID" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "ID", (NullTypes.IntNT)IdValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                CodificaGenericaObj = GetFromDatareader(db);
                CodificaGenericaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                CodificaGenericaObj.IsDirty = false;
                CodificaGenericaObj.IsPersistent = true;
            }
            db.Close();
            return CodificaGenericaObj;
        }

        //getFromDatareader
        public static CodificaGenerica GetFromDatareader(DbProvider db)
        {
            CodificaGenerica CodificaGenericaObj = new CodificaGenerica();
            CodificaGenericaObj.Id = new NullTypes.IntNT(db.DataReader["ID"]);
            CodificaGenericaObj.IdTipoCodifica = new NullTypes.IntNT(db.DataReader["ID_TIPO_CODIFICA"]);
            CodificaGenericaObj.Descrizione = new NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
            CodificaGenericaObj.ValoreTxt = new NullTypes.StringNT(db.DataReader["VALORE_TXT"]);
            CodificaGenericaObj.CodiceTxt = new NullTypes.StringNT(db.DataReader["CODICE_TXT"]);
            CodificaGenericaObj.ValoreInt1 = new NullTypes.IntNT(db.DataReader["VALORE_INT1"]);
            CodificaGenericaObj.ValoreInt2 = new NullTypes.IntNT(db.DataReader["VALORE_INT2"]);
            CodificaGenericaObj.ValoreDec1 = new NullTypes.DecimalNT(db.DataReader["VALORE_DEC1"]);
            CodificaGenericaObj.ValoreDec2 = new NullTypes.DecimalNT(db.DataReader["VALORE_DEC2"]);
            CodificaGenericaObj.Flag = new NullTypes.StringNT(db.DataReader["FLAG"]);
            CodificaGenericaObj.DataInizioValidita = new NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO_VALIDITA"]);
            CodificaGenericaObj.DataFineValidita = new NullTypes.DatetimeNT(db.DataReader["DATA_FINE_VALIDITA"]);
            CodificaGenericaObj.IdPadre = new NullTypes.IntNT(db.DataReader["ID_PADRE"]);
            CodificaGenericaObj.ValoreTxt2 = new NullTypes.StringNT(db.DataReader["VALORE_TXT2"]);
            CodificaGenericaObj.ValoreTxt3 = new NullTypes.StringNT(db.DataReader["VALORE_TXT3"]);
            CodificaGenericaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            CodificaGenericaObj.IsDirty = false;
            CodificaGenericaObj.IsPersistent = true;
            return CodificaGenericaObj;
        }

        //Find Select

        public static CodificaGenericaCollection Select(DbProvider db, NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdTipoCodificaEqualThis, NullTypes.StringNT DescrizioneEqualThis,
NullTypes.StringNT CodiceTxtEqualThis, NullTypes.IntNT ValoreInt1EqualThis, NullTypes.IntNT ValoreInt2EqualThis,
NullTypes.DecimalNT ValoreDec1EqualThis, NullTypes.DecimalNT ValoreDec2EqualThis, NullTypes.StringNT FlagEqualThis,
NullTypes.DatetimeNT DataInizioValiditaEqualThis, NullTypes.DatetimeNT DataFineValiditaEqualThis, NullTypes.IntNT IdPadreEqualThis)
        {

            CodificaGenericaCollection CodificaGenericaCollectionObj = new CodificaGenericaCollection();

            IDbCommand findCmd = db.InitCmd("Z_CODIFICA_GENERICA_FIND_SELECT", new string[] {"IDEQUALTHIS", "ID_TIPO_CODIFICAEQUALTHIS", "DESCRIZIONEEQUALTHIS", 
"CODICE_TXTEQUALTHIS", "VALORE_INT1EQUALTHIS", "VALORE_INT2EQUALTHIS", 
"VALORE_DEC1EQUALTHIS", "VALORE_DEC2EQUALTHIS", "FLAGEQUALTHIS", 
"DATA_INIZIO_VALIDITAEQUALTHIS", "DATA_FINE_VALIDITAEQUALTHIS", "ID_PADREEQUALTHIS"}, new string[] {"int", "int", "string", 
"string", "int", "int", 
"decimal", "decimal", "string", 
"DateTime", "DateTime", "int"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IDEQUALTHIS", IdEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ID_TIPO_CODIFICAEQUALTHIS", IdTipoCodificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DESCRIZIONEEQUALTHIS", DescrizioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CODICE_TXTEQUALTHIS", CodiceTxtEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "VALORE_INT1EQUALTHIS", ValoreInt1EqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "VALORE_INT2EQUALTHIS", ValoreInt2EqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "VALORE_DEC1EQUALTHIS", ValoreDec1EqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "VALORE_DEC2EQUALTHIS", ValoreDec2EqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "FLAGEQUALTHIS", FlagEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DATA_INIZIO_VALIDITAEQUALTHIS", DataInizioValiditaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DATA_FINE_VALIDITAEQUALTHIS", DataFineValiditaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ID_PADREEQUALTHIS", IdPadreEqualThis);
            CodificaGenerica CodificaGenericaObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                CodificaGenericaObj = GetFromDatareader(db);
                CodificaGenericaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                CodificaGenericaObj.IsDirty = false;
                CodificaGenericaObj.IsPersistent = true;
                CodificaGenericaCollectionObj.Add(CodificaGenericaObj);
            }
            db.Close();
            return CodificaGenericaCollectionObj;
        }

        //Find Find

        public static CodificaGenericaCollection Find(DbProvider db, NullTypes.IntNT IdTipoCodificaEqualThis, NullTypes.IntNT IdEqGreaterThanThis, NullTypes.IntNT IdEqLessThanThis,
NullTypes.StringNT DescrizioneLikeThis, NullTypes.StringNT FlagLikeThis)
        {

            CodificaGenericaCollection CodificaGenericaCollectionObj = new CodificaGenericaCollection();

            IDbCommand findCmd = db.InitCmd("Z_CODIFICA_GENERICA_FIND_FIND", new string[] {"ID_TIPO_CODIFICAEQUALTHIS", "IDEQGREATERTHANTHIS", "IDEQLESSTHANTHIS", 
"DESCRIZIONELIKETHIS", "FLAGLIKETHIS"}, new string[] {"int", "int", "int", 
"string", "string"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ID_TIPO_CODIFICAEQUALTHIS", IdTipoCodificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IDEQGREATERTHANTHIS", IdEqGreaterThanThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IDEQLESSTHANTHIS", IdEqLessThanThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DESCRIZIONELIKETHIS", DescrizioneLikeThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "FLAGLIKETHIS", FlagLikeThis);
            CodificaGenerica CodificaGenericaObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                CodificaGenericaObj = GetFromDatareader(db);
                CodificaGenericaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                CodificaGenericaObj.IsDirty = false;
                CodificaGenericaObj.IsPersistent = true;
                CodificaGenericaCollectionObj.Add(CodificaGenericaObj);
            }
            db.Close();
            return CodificaGenericaCollectionObj;
        }

        //Find FTipo

        public static CodificaGenericaCollection FTipo(DbProvider db, NullTypes.IntNT IdTipoCodificaEqualThis)
        {

            CodificaGenericaCollection CodificaGenericaCollectionObj = new CodificaGenericaCollection();

            IDbCommand findCmd = db.InitCmd("Z_CODIFICA_GENERICA_FIND_FTIPO", new string[] { "ID_TIPO_CODIFICAEQUALTHIS" }, new string[] { "int" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ID_TIPO_CODIFICAEQUALTHIS", IdTipoCodificaEqualThis);
            CodificaGenerica CodificaGenericaObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                CodificaGenericaObj = GetFromDatareader(db);
                CodificaGenericaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                CodificaGenericaObj.IsDirty = false;
                CodificaGenericaObj.IsPersistent = true;
                CodificaGenericaCollectionObj.Add(CodificaGenericaObj);
            }
            db.Close();
            return CodificaGenericaCollectionObj;
        }

        //Find FPadre

        public static CodificaGenericaCollection FPadre(DbProvider db, NullTypes.IntNT IdPadreEqualThis)
        {

            CodificaGenericaCollection CodificaGenericaCollectionObj = new CodificaGenericaCollection();

            IDbCommand findCmd = db.InitCmd("Z_CODIFICA_GENERICA_FIND_FPADRE", new string[] { "ID_PADREEQUALTHIS" }, new string[] { "int" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ID_PADREEQUALTHIS", IdPadreEqualThis);
            CodificaGenerica CodificaGenericaObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                CodificaGenericaObj = GetFromDatareader(db);
                CodificaGenericaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                CodificaGenericaObj.IsDirty = false;
                CodificaGenericaObj.IsPersistent = true;
                CodificaGenericaCollectionObj.Add(CodificaGenericaObj);
            }
            db.Close();
            return CodificaGenericaCollectionObj;
        }

    }
}


namespace SiarLibrary
{

    /// <summary>
    /// Summary description for CodificaGenericaCollectionProvider:ICodificaGenericaProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class CodificaGenericaCollectionProvider : ICodificaGenericaProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di CodificaGenerica
        protected CodificaGenericaCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public CodificaGenericaCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new CodificaGenericaCollection(this);
        }

        //Costruttore 2: popola la collection
        public CodificaGenericaCollectionProvider(IntNT IdtipocodificaEqualThis, IntNT IdEqGreaterThanThis, IntNT IdEqLessThanThis,
StringNT DescrizioneLikeThis, StringNT FlagLikeThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IdtipocodificaEqualThis, IdEqGreaterThanThis, IdEqLessThanThis,
DescrizioneLikeThis, FlagLikeThis);
        }

        //Costruttore3: ha in input codificagenericaCollectionObj - non popola la collection
        public CodificaGenericaCollectionProvider(CodificaGenericaCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public CodificaGenericaCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new CodificaGenericaCollection(this);
        }

        //Get e Set
        public CodificaGenericaCollection CollectionObj
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
        public int SaveCollection(CodificaGenericaCollection collectionObj)
        {
            _cache = null;
            return CodificaGenericaDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(CodificaGenerica codificagenericaObj)
        {
            _cache = null;
            return CodificaGenericaDAL.Save(_dbProviderObj, codificagenericaObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(CodificaGenericaCollection collectionObj)
        {
            _cache = null;
            return CodificaGenericaDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(CodificaGenerica codificagenericaObj)
        {
            _cache = null;
            return CodificaGenericaDAL.Delete(_dbProviderObj, codificagenericaObj);
        }

        //getById
        public CodificaGenerica GetById(IntNT IdValue)
        {
            CodificaGenerica CodificaGenericaTemp = CodificaGenericaDAL.GetById(_dbProviderObj, IdValue);
            if (CodificaGenericaTemp != null) CodificaGenericaTemp.Provider = this;
            return CodificaGenericaTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        private static CodificaGenericaCollection _cache;
        public static CodificaGenericaCollection CacheCodificaGenerica
        {
            get
            {
                if (_cache != null) return _cache;
                _cache = CodificaGenericaDAL.Find(new DbProvider(), null, null, null, null, null);
                return _cache;
            }
        }

        //Select: popola la collection
        public CodificaGenericaCollection Select(IntNT IdEqualThis, IntNT IdtipocodificaEqualThis, StringNT DescrizioneEqualThis,
StringNT CodicetxtEqualThis, IntNT Valoreint1EqualThis, IntNT Valoreint2EqualThis,
DecimalNT Valoredec1EqualThis, DecimalNT Valoredec2EqualThis, StringNT FlagEqualThis,
DatetimeNT DatainiziovaliditaEqualThis, DatetimeNT DatafinevaliditaEqualThis, IntNT IdpadreEqualThis)
        {
            CodificaGenericaCollection CodificaGenericaCollectionTemp = CodificaGenericaDAL.Select(_dbProviderObj, IdEqualThis, IdtipocodificaEqualThis, DescrizioneEqualThis,
CodicetxtEqualThis, Valoreint1EqualThis, Valoreint2EqualThis,
Valoredec1EqualThis, Valoredec2EqualThis, FlagEqualThis,
DatainiziovaliditaEqualThis, DatafinevaliditaEqualThis, IdpadreEqualThis);
            CodificaGenericaCollectionTemp.Provider = this;
            return CodificaGenericaCollectionTemp;
        }

        //Find: popola la collection
        public CodificaGenericaCollection Find(IntNT IdtipocodificaEqualThis, IntNT IdEqGreaterThanThis, IntNT IdEqLessThanThis,
StringNT DescrizioneLikeThis, StringNT FlagLikeThis)
        {
            CodificaGenericaCollection CodificaGenericaCollectionTemp = CodificaGenericaDAL.Find(_dbProviderObj, IdtipocodificaEqualThis, IdEqGreaterThanThis, IdEqLessThanThis,
DescrizioneLikeThis, FlagLikeThis);
            CodificaGenericaCollectionTemp.Provider = this;
            return CodificaGenericaCollectionTemp;
        }

        //FTipo: popola la collection
        public CodificaGenericaCollection FTipo(IntNT IdtipocodificaEqualThis)
        {
            CodificaGenericaCollection CodificaGenericaCollectionTemp = CodificaGenericaDAL.FTipo(_dbProviderObj, IdtipocodificaEqualThis);
            CodificaGenericaCollectionTemp.Provider = this;
            return CodificaGenericaCollectionTemp;
        }

        //FPadre: popola la collection
        public CodificaGenericaCollection FPadre(IntNT IdpadreEqualThis)
        {
            CodificaGenericaCollection CodificaGenericaCollectionTemp = CodificaGenericaDAL.FPadre(_dbProviderObj, IdpadreEqualThis);
            CodificaGenericaCollectionTemp.Provider = this;
            return CodificaGenericaCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CODIFICA_GENERICA>
  <ViewName>VCODIFICA_GENERICA</ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>True</chkDataModifica>
  <txtNomeCampoDataModifica>DATA_MODIFICA</txtNomeCampoDataModifica>
  <chkOptimisticCouncurrency>False</chkOptimisticCouncurrency>
  <chkShortNames>False</chkShortNames>
  <chkCase>True</chkCase>
  <chkCache>True</chkCache>
  <PLName>PLLibrary</PLName>
  <DALName>xDLayer</DALName>
  <BLLName>xBLayer</BLLName>
  <TypeNameSpaceName>xTLayer</TypeNameSpaceName>
  <Finds>
    <Find OrderBy="ORDER BY ID">
      <ID_TIPO_CODIFICA>Equal</ID_TIPO_CODIFICA>
      <ID>EqGreaterThan</ID>
      <ID>EqLessThan</ID>
      <DESCRIZIONE>Like</DESCRIZIONE>
      <FLAG>Like</FLAG>
    </Find>
    <FTipo OrderBy="ORDER BY ID">
      <ID_TIPO_CODIFICA>Equal</ID_TIPO_CODIFICA>
    </FTipo>
    <FPadre OrderBy="ORDER BY ID">
      <ID_PADRE>Equal</ID_PADRE>
    </FPadre>
  </Finds>
  <Filters>
    <Filter>
      <FLAG>Like</FLAG>
      <VALORE_INT1>Equal</VALORE_INT1>
      <VALORE_INT2>Equal</VALORE_INT2>
      <VALORE_DEC1>Equal</VALORE_DEC1>
      <VALORE_DEC2>Equal</VALORE_DEC2>
    </Filter>
    <FTipo>
      <ID_TIPO_CODIFICA>Equal</ID_TIPO_CODIFICA>
    </FTipo>
    <FPadre>
      <ID_PADRE>Equal</ID_PADRE>
    </FPadre>
  </Filters>
  <externalFields />
  <AddedFkFields />
</CODIFICA_GENERICA>
*/
