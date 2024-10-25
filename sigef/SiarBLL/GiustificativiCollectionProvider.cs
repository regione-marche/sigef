using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per Giustificativi
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IGiustificativiProvider
    {
        int Save(Giustificativi GiustificativiObj);
        int SaveCollection(GiustificativiCollection collectionObj);
        int Delete(Giustificativi GiustificativiObj);
        int DeleteCollection(GiustificativiCollection collectionObj);
    }
    /// <summary>
    /// Summary description for Giustificativi
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class Giustificativi : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdGiustificativo;
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
        private IGiustificativiProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IGiustificativiProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public Giustificativi()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
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
        /// Default:((0))
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
        /// Default:((0))
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
        /// Default:((0))
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
    /// Summary description for GiustificativiCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class GiustificativiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private GiustificativiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((Giustificativi)info.GetValue(i.ToString(), typeof(Giustificativi)));
            }
        }

        //Costruttore
        public GiustificativiCollection()
        {
            this.ItemType = typeof(Giustificativi);
        }

        //Costruttore con provider
        public GiustificativiCollection(IGiustificativiProvider providerObj)
        {
            this.ItemType = typeof(Giustificativi);
            this.Provider = providerObj;
        }

        //Get e Set
        public new Giustificativi this[int index]
        {
            get { return (Giustificativi)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new GiustificativiCollection GetChanges()
        {
            return (GiustificativiCollection)base.GetChanges();
        }

        [NonSerialized]
        private IGiustificativiProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IGiustificativiProvider Provider
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
        public int Add(Giustificativi GiustificativiObj)
        {
            if (GiustificativiObj.Provider == null) GiustificativiObj.Provider = this.Provider;
            return base.Add(GiustificativiObj);
        }

        //AddCollection
        public void AddCollection(GiustificativiCollection GiustificativiCollectionObj)
        {
            foreach (Giustificativi GiustificativiObj in GiustificativiCollectionObj)
                this.Add(GiustificativiObj);
        }

        //Insert
        public void Insert(int index, Giustificativi GiustificativiObj)
        {
            if (GiustificativiObj.Provider == null) GiustificativiObj.Provider = this.Provider;
            base.Insert(index, GiustificativiObj);
        }

        //CollectionGetById
        public Giustificativi CollectionGetById(NullTypes.IntNT IdGiustificativoValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdGiustificativo == IdGiustificativoValue))
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
        public GiustificativiCollection SubSelect(NullTypes.IntNT IdGiustificativoEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.StringNT NumeroEqualThis,
NullTypes.StringNT CodTipoEqualThis, NullTypes.DatetimeNT DataEqualThis, NullTypes.StringNT NumeroDoctrasportoEqualThis,
NullTypes.DatetimeNT DataDoctrasportoEqualThis, NullTypes.DecimalNT ImponibileEqualThis, NullTypes.DecimalNT IvaEqualThis,
NullTypes.DecimalNT AltriOneriEqualThis, NullTypes.StringNT DescrizioneEqualThis, NullTypes.StringNT CfFornitoreEqualThis,
NullTypes.StringNT DescrizioneFornitoreEqualThis, NullTypes.BoolNT IvaNonRecuperabileEqualThis, NullTypes.IntNT IdFileEqualThis,
NullTypes.BoolNT InIntegrazioneEqualThis, NullTypes.BoolNT IdFileModificatoIntegrazioneEqualThis)
        {
            GiustificativiCollection GiustificativiCollectionTemp = new GiustificativiCollection();
            foreach (Giustificativi GiustificativiItem in this)
            {
                if (((IdGiustificativoEqualThis == null) || ((GiustificativiItem.IdGiustificativo != null) && (GiustificativiItem.IdGiustificativo.Value == IdGiustificativoEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((GiustificativiItem.IdProgetto != null) && (GiustificativiItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((NumeroEqualThis == null) || ((GiustificativiItem.Numero != null) && (GiustificativiItem.Numero.Value == NumeroEqualThis.Value))) &&
((CodTipoEqualThis == null) || ((GiustificativiItem.CodTipo != null) && (GiustificativiItem.CodTipo.Value == CodTipoEqualThis.Value))) && ((DataEqualThis == null) || ((GiustificativiItem.Data != null) && (GiustificativiItem.Data.Value == DataEqualThis.Value))) && ((NumeroDoctrasportoEqualThis == null) || ((GiustificativiItem.NumeroDoctrasporto != null) && (GiustificativiItem.NumeroDoctrasporto.Value == NumeroDoctrasportoEqualThis.Value))) &&
((DataDoctrasportoEqualThis == null) || ((GiustificativiItem.DataDoctrasporto != null) && (GiustificativiItem.DataDoctrasporto.Value == DataDoctrasportoEqualThis.Value))) && ((ImponibileEqualThis == null) || ((GiustificativiItem.Imponibile != null) && (GiustificativiItem.Imponibile.Value == ImponibileEqualThis.Value))) && ((IvaEqualThis == null) || ((GiustificativiItem.Iva != null) && (GiustificativiItem.Iva.Value == IvaEqualThis.Value))) &&
((AltriOneriEqualThis == null) || ((GiustificativiItem.AltriOneri != null) && (GiustificativiItem.AltriOneri.Value == AltriOneriEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((GiustificativiItem.Descrizione != null) && (GiustificativiItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((CfFornitoreEqualThis == null) || ((GiustificativiItem.CfFornitore != null) && (GiustificativiItem.CfFornitore.Value == CfFornitoreEqualThis.Value))) &&
((DescrizioneFornitoreEqualThis == null) || ((GiustificativiItem.DescrizioneFornitore != null) && (GiustificativiItem.DescrizioneFornitore.Value == DescrizioneFornitoreEqualThis.Value))) && ((IvaNonRecuperabileEqualThis == null) || ((GiustificativiItem.IvaNonRecuperabile != null) && (GiustificativiItem.IvaNonRecuperabile.Value == IvaNonRecuperabileEqualThis.Value))) && ((IdFileEqualThis == null) || ((GiustificativiItem.IdFile != null) && (GiustificativiItem.IdFile.Value == IdFileEqualThis.Value))) &&
((InIntegrazioneEqualThis == null) || ((GiustificativiItem.InIntegrazione != null) && (GiustificativiItem.InIntegrazione.Value == InIntegrazioneEqualThis.Value))) && ((IdFileModificatoIntegrazioneEqualThis == null) || ((GiustificativiItem.IdFileModificatoIntegrazione != null) && (GiustificativiItem.IdFileModificatoIntegrazione.Value == IdFileModificatoIntegrazioneEqualThis.Value))))
                {
                    GiustificativiCollectionTemp.Add(GiustificativiItem);
                }
            }
            return GiustificativiCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for GiustificativiDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class GiustificativiDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, Giustificativi GiustificativiObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdGiustificativo", GiustificativiObj.IdGiustificativo);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "IdProgetto", GiustificativiObj.IdProgetto);
            DbProvider.SetCmdParam(cmd, firstChar + "Numero", GiustificativiObj.Numero);
            DbProvider.SetCmdParam(cmd, firstChar + "CodTipo", GiustificativiObj.CodTipo);
            DbProvider.SetCmdParam(cmd, firstChar + "Data", GiustificativiObj.Data);
            DbProvider.SetCmdParam(cmd, firstChar + "NumeroDoctrasporto", GiustificativiObj.NumeroDoctrasporto);
            DbProvider.SetCmdParam(cmd, firstChar + "DataDoctrasporto", GiustificativiObj.DataDoctrasporto);
            DbProvider.SetCmdParam(cmd, firstChar + "Imponibile", GiustificativiObj.Imponibile);
            DbProvider.SetCmdParam(cmd, firstChar + "Iva", GiustificativiObj.Iva);
            DbProvider.SetCmdParam(cmd, firstChar + "AltriOneri", GiustificativiObj.AltriOneri);
            DbProvider.SetCmdParam(cmd, firstChar + "Descrizione", GiustificativiObj.Descrizione);
            DbProvider.SetCmdParam(cmd, firstChar + "CfFornitore", GiustificativiObj.CfFornitore);
            DbProvider.SetCmdParam(cmd, firstChar + "DescrizioneFornitore", GiustificativiObj.DescrizioneFornitore);
            DbProvider.SetCmdParam(cmd, firstChar + "IvaNonRecuperabile", GiustificativiObj.IvaNonRecuperabile);
            DbProvider.SetCmdParam(cmd, firstChar + "IdFile", GiustificativiObj.IdFile);
            DbProvider.SetCmdParam(cmd, firstChar + "InIntegrazione", GiustificativiObj.InIntegrazione);
            DbProvider.SetCmdParam(cmd, firstChar + "IdFileModificatoIntegrazione", GiustificativiObj.IdFileModificatoIntegrazione);
        }
        //Insert
        private static int Insert(DbProvider db, Giustificativi GiustificativiObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZGiustificativiInsert", new string[] {"IdProgetto", "Numero", 
"CodTipo", "Data", "NumeroDoctrasporto", 
"DataDoctrasporto", "Imponibile", "Iva", 
"AltriOneri", "Descrizione", "CfFornitore", 
"DescrizioneFornitore", "IvaNonRecuperabile", "IdFile", 
"InIntegrazione", "IdFileModificatoIntegrazione"}, new string[] {"int", "string", 
"string", "DateTime", "string", 
"DateTime", "decimal", "decimal", 
"decimal", "string", "string", 
"string", "bool", "int", 
"bool", "bool"}, "");
                CompileIUCmd(false, insertCmd, GiustificativiObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    GiustificativiObj.IdGiustificativo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_GIUSTIFICATIVO"]);
                    GiustificativiObj.Iva = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IVA"]);
                    GiustificativiObj.IvaNonRecuperabile = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IVA_NON_RECUPERABILE"]);
                    GiustificativiObj.InIntegrazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IN_INTEGRAZIONE"]);
                }
                GiustificativiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                GiustificativiObj.IsDirty = false;
                GiustificativiObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, Giustificativi GiustificativiObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZGiustificativiUpdate", new string[] {"IdGiustificativo", "IdProgetto", "Numero", 
"CodTipo", "Data", "NumeroDoctrasporto", 
"DataDoctrasporto", "Imponibile", "Iva", 
"AltriOneri", "Descrizione", "CfFornitore", 
"DescrizioneFornitore", "IvaNonRecuperabile", "IdFile", 
"InIntegrazione", "IdFileModificatoIntegrazione"}, new string[] {"int", "int", "string", 
"string", "DateTime", "string", 
"DateTime", "decimal", "decimal", 
"decimal", "string", "string", 
"string", "bool", "int", 
"bool", "bool"}, "");
                CompileIUCmd(true, updateCmd, GiustificativiObj, db.CommandFirstChar);
                i = db.Execute(updateCmd);
                GiustificativiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                GiustificativiObj.IsDirty = false;
                GiustificativiObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, Giustificativi GiustificativiObj)
        {
            switch (GiustificativiObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, GiustificativiObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, GiustificativiObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, GiustificativiObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, GiustificativiCollection GiustificativiCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZGiustificativiUpdate", new string[] {"IdGiustificativo", "IdProgetto", "Numero", 
"CodTipo", "Data", "NumeroDoctrasporto", 
"DataDoctrasporto", "Imponibile", "Iva", 
"AltriOneri", "Descrizione", "CfFornitore", 
"DescrizioneFornitore", "IvaNonRecuperabile", "IdFile", 
"InIntegrazione", "IdFileModificatoIntegrazione"}, new string[] {"int", "int", "string", 
"string", "DateTime", "string", 
"DateTime", "decimal", "decimal", 
"decimal", "string", "string", 
"string", "bool", "int", 
"bool", "bool"}, "");
                IDbCommand insertCmd = db.InitCmd("ZGiustificativiInsert", new string[] {"IdProgetto", "Numero", 
"CodTipo", "Data", "NumeroDoctrasporto", 
"DataDoctrasporto", "Imponibile", "Iva", 
"AltriOneri", "Descrizione", "CfFornitore", 
"DescrizioneFornitore", "IvaNonRecuperabile", "IdFile", 
"InIntegrazione", "IdFileModificatoIntegrazione"}, new string[] {"int", "string", 
"string", "DateTime", "string", 
"DateTime", "decimal", "decimal", 
"decimal", "string", "string", 
"string", "bool", "int", 
"bool", "bool"}, "");
                IDbCommand deleteCmd = db.InitCmd("ZGiustificativiDelete", new string[] { "IdGiustificativo" }, new string[] { "int" }, "");
                for (int i = 0; i < GiustificativiCollectionObj.Count; i++)
                {
                    switch (GiustificativiCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, GiustificativiCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    GiustificativiCollectionObj[i].IdGiustificativo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_GIUSTIFICATIVO"]);
                                    GiustificativiCollectionObj[i].Iva = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IVA"]);
                                    GiustificativiCollectionObj[i].IvaNonRecuperabile = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IVA_NON_RECUPERABILE"]);
                                    GiustificativiCollectionObj[i].InIntegrazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IN_INTEGRAZIONE"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, GiustificativiCollectionObj[i], db.CommandFirstChar);
                                returnValue = returnValue + db.Execute(updateCmd);
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (GiustificativiCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdGiustificativo", (SiarLibrary.NullTypes.IntNT)GiustificativiCollectionObj[i].IdGiustificativo);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < GiustificativiCollectionObj.Count; i++)
                {
                    if ((GiustificativiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (GiustificativiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        GiustificativiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        GiustificativiCollectionObj[i].IsDirty = false;
                        GiustificativiCollectionObj[i].IsPersistent = true;
                    }
                    if ((GiustificativiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        GiustificativiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        GiustificativiCollectionObj[i].IsDirty = false;
                        GiustificativiCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, Giustificativi GiustificativiObj)
        {
            int returnValue = 0;
            if (GiustificativiObj.IsPersistent)
            {
                returnValue = Delete(db, GiustificativiObj.IdGiustificativo);
            }
            GiustificativiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            GiustificativiObj.IsDirty = false;
            GiustificativiObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdGiustificativoValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZGiustificativiDelete", new string[] { "IdGiustificativo" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdGiustificativo", (SiarLibrary.NullTypes.IntNT)IdGiustificativoValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, GiustificativiCollection GiustificativiCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZGiustificativiDelete", new string[] { "IdGiustificativo" }, new string[] { "int" }, "");
                for (int i = 0; i < GiustificativiCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdGiustificativo", GiustificativiCollectionObj[i].IdGiustificativo);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < GiustificativiCollectionObj.Count; i++)
                {
                    if ((GiustificativiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (GiustificativiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        GiustificativiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        GiustificativiCollectionObj[i].IsDirty = false;
                        GiustificativiCollectionObj[i].IsPersistent = false;
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
        public static Giustificativi GetById(DbProvider db, int IdGiustificativoValue)
        {
            Giustificativi GiustificativiObj = null;
            IDbCommand readCmd = db.InitCmd("ZGiustificativiGetById", new string[] { "IdGiustificativo" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdGiustificativo", (SiarLibrary.NullTypes.IntNT)IdGiustificativoValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                GiustificativiObj = GetFromDatareader(db);
                GiustificativiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                GiustificativiObj.IsDirty = false;
                GiustificativiObj.IsPersistent = true;
            }
            db.Close();
            return GiustificativiObj;
        }

        //getFromDatareader
        public static Giustificativi GetFromDatareader(DbProvider db)
        {
            Giustificativi GiustificativiObj = new Giustificativi();
            GiustificativiObj.IdGiustificativo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_GIUSTIFICATIVO"]);
            GiustificativiObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
            GiustificativiObj.Numero = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO"]);
            GiustificativiObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
            GiustificativiObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
            GiustificativiObj.NumeroDoctrasporto = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO_DOCTRASPORTO"]);
            GiustificativiObj.DataDoctrasporto = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_DOCTRASPORTO"]);
            GiustificativiObj.Imponibile = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPONIBILE"]);
            GiustificativiObj.Iva = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IVA"]);
            GiustificativiObj.AltriOneri = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["ALTRI_ONERI"]);
            GiustificativiObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
            GiustificativiObj.CfFornitore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_FORNITORE"]);
            GiustificativiObj.DescrizioneFornitore = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_FORNITORE"]);
            GiustificativiObj.IvaNonRecuperabile = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IVA_NON_RECUPERABILE"]);
            GiustificativiObj.IdFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILE"]);
            GiustificativiObj.InIntegrazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IN_INTEGRAZIONE"]);
            GiustificativiObj.IdFileModificatoIntegrazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ID_FILE_MODIFICATO_INTEGRAZIONE"]);
            GiustificativiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            GiustificativiObj.IsDirty = false;
            GiustificativiObj.IsPersistent = true;
            return GiustificativiObj;
        }

        //Find Select

        public static GiustificativiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdGiustificativoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.StringNT NumeroEqualThis,
SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataEqualThis, SiarLibrary.NullTypes.StringNT NumeroDoctrasportoEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataDoctrasportoEqualThis, SiarLibrary.NullTypes.DecimalNT ImponibileEqualThis, SiarLibrary.NullTypes.DecimalNT IvaEqualThis,
SiarLibrary.NullTypes.DecimalNT AltriOneriEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.StringNT CfFornitoreEqualThis,
SiarLibrary.NullTypes.StringNT DescrizioneFornitoreEqualThis, SiarLibrary.NullTypes.BoolNT IvaNonRecuperabileEqualThis, SiarLibrary.NullTypes.IntNT IdFileEqualThis,
SiarLibrary.NullTypes.BoolNT InIntegrazioneEqualThis, SiarLibrary.NullTypes.BoolNT IdFileModificatoIntegrazioneEqualThis)
        {

            GiustificativiCollection GiustificativiCollectionObj = new GiustificativiCollection();

            IDbCommand findCmd = db.InitCmd("Zgiustificativifindselect", new string[] {"IdGiustificativoequalthis", "IdProgettoequalthis", "Numeroequalthis", 
"CodTipoequalthis", "Dataequalthis", "NumeroDoctrasportoequalthis", 
"DataDoctrasportoequalthis", "Imponibileequalthis", "Ivaequalthis", 
"AltriOneriequalthis", "Descrizioneequalthis", "CfFornitoreequalthis", 
"DescrizioneFornitoreequalthis", "IvaNonRecuperabileequalthis", "IdFileequalthis", 
"InIntegrazioneequalthis", "IdFileModificatoIntegrazioneequalthis"}, new string[] {"int", "int", "string", 
"string", "DateTime", "string", 
"DateTime", "decimal", "decimal", 
"decimal", "string", "string", 
"string", "bool", "int", 
"bool", "bool"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdGiustificativoequalthis", IdGiustificativoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Numeroequalthis", NumeroEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Dataequalthis", DataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "NumeroDoctrasportoequalthis", NumeroDoctrasportoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataDoctrasportoequalthis", DataDoctrasportoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Imponibileequalthis", ImponibileEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Ivaequalthis", IvaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "AltriOneriequalthis", AltriOneriEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfFornitoreequalthis", CfFornitoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DescrizioneFornitoreequalthis", DescrizioneFornitoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IvaNonRecuperabileequalthis", IvaNonRecuperabileEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdFileequalthis", IdFileEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "InIntegrazioneequalthis", InIntegrazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdFileModificatoIntegrazioneequalthis", IdFileModificatoIntegrazioneEqualThis);
            Giustificativi GiustificativiObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                GiustificativiObj = GetFromDatareader(db);
                GiustificativiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                GiustificativiObj.IsDirty = false;
                GiustificativiObj.IsPersistent = true;
                GiustificativiCollectionObj.Add(GiustificativiObj);
            }
            db.Close();
            return GiustificativiCollectionObj;
        }

        //Find Find

        public static GiustificativiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.StringNT NumeroEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataEqLessThanThis)
        {

            GiustificativiCollection GiustificativiCollectionObj = new GiustificativiCollection();

            IDbCommand findCmd = db.InitCmd("Zgiustificativifindfind", new string[] {"IdProgettoequalthis", "CodTipoequalthis", "Numeroequalthis", 
"Dataeqlessthanthis"}, new string[] {"int", "string", "string", 
"DateTime"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Numeroequalthis", NumeroEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Dataeqlessthanthis", DataEqLessThanThis);
            Giustificativi GiustificativiObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                GiustificativiObj = GetFromDatareader(db);
                GiustificativiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                GiustificativiObj.IsDirty = false;
                GiustificativiObj.IsPersistent = true;
                GiustificativiCollectionObj.Add(GiustificativiObj);
            }
            db.Close();
            return GiustificativiCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for GiustificativiCollectionProvider:IGiustificativiProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class GiustificativiCollectionProvider : IGiustificativiProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di Giustificativi
        protected GiustificativiCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public GiustificativiCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new GiustificativiCollection(this);
        }

        //Costruttore 2: popola la collection
        public GiustificativiCollectionProvider(IntNT IdprogettoEqualThis, StringNT CodtipoEqualThis, StringNT NumeroEqualThis,
DatetimeNT DataEqLessThanThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IdprogettoEqualThis, CodtipoEqualThis, NumeroEqualThis,
DataEqLessThanThis);
        }

        //Costruttore3: ha in input giustificativiCollectionObj - non popola la collection
        public GiustificativiCollectionProvider(GiustificativiCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public GiustificativiCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new GiustificativiCollection(this);
        }

        //Get e Set
        public GiustificativiCollection CollectionObj
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
        public int SaveCollection(GiustificativiCollection collectionObj)
        {
            return GiustificativiDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(Giustificativi giustificativiObj)
        {
            return GiustificativiDAL.Save(_dbProviderObj, giustificativiObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(GiustificativiCollection collectionObj)
        {
            return GiustificativiDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(Giustificativi giustificativiObj)
        {
            return GiustificativiDAL.Delete(_dbProviderObj, giustificativiObj);
        }

        //getById
        public Giustificativi GetById(IntNT IdGiustificativoValue)
        {
            Giustificativi GiustificativiTemp = GiustificativiDAL.GetById(_dbProviderObj, IdGiustificativoValue);
            if (GiustificativiTemp != null) GiustificativiTemp.Provider = this;
            return GiustificativiTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public GiustificativiCollection Select(IntNT IdgiustificativoEqualThis, IntNT IdprogettoEqualThis, StringNT NumeroEqualThis,
StringNT CodtipoEqualThis, DatetimeNT DataEqualThis, StringNT NumerodoctrasportoEqualThis,
DatetimeNT DatadoctrasportoEqualThis, DecimalNT ImponibileEqualThis, DecimalNT IvaEqualThis,
DecimalNT AltrioneriEqualThis, StringNT DescrizioneEqualThis, StringNT CffornitoreEqualThis,
StringNT DescrizionefornitoreEqualThis, BoolNT IvanonrecuperabileEqualThis, IntNT IdfileEqualThis,
BoolNT InintegrazioneEqualThis, BoolNT IdfilemodificatointegrazioneEqualThis)
        {
            GiustificativiCollection GiustificativiCollectionTemp = GiustificativiDAL.Select(_dbProviderObj, IdgiustificativoEqualThis, IdprogettoEqualThis, NumeroEqualThis,
CodtipoEqualThis, DataEqualThis, NumerodoctrasportoEqualThis,
DatadoctrasportoEqualThis, ImponibileEqualThis, IvaEqualThis,
AltrioneriEqualThis, DescrizioneEqualThis, CffornitoreEqualThis,
DescrizionefornitoreEqualThis, IvanonrecuperabileEqualThis, IdfileEqualThis,
InintegrazioneEqualThis, IdfilemodificatointegrazioneEqualThis);
            GiustificativiCollectionTemp.Provider = this;
            return GiustificativiCollectionTemp;
        }

        //Find: popola la collection
        public GiustificativiCollection Find(IntNT IdprogettoEqualThis, StringNT CodtipoEqualThis, StringNT NumeroEqualThis,
DatetimeNT DataEqLessThanThis)
        {
            GiustificativiCollection GiustificativiCollectionTemp = GiustificativiDAL.Find(_dbProviderObj, IdprogettoEqualThis, CodtipoEqualThis, NumeroEqualThis,
DataEqLessThanThis);
            GiustificativiCollectionTemp.Provider = this;
            return GiustificativiCollectionTemp;
        }


    }
}

/*
select ROUTINE_DEFINITION into ##old_ZGiustificativiInsert from information_schema.routines where routine_name='ZGiustificativiInsert';
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZGiustificativiInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ZGiustificativiInsert];
GO
CREATE PROCEDURE [dbo].[ZGiustificativiInsert]
(
	@IdProgetto INT, 
	@Numero VARCHAR(255), 
	@CodTipo VARCHAR(255), 
	@Data DATETIME, 
	@NumeroDoctrasporto VARCHAR(255), 
	@DataDoctrasporto DATETIME, 
	@Imponibile DECIMAL(18,2), 
	@Iva DECIMAL(18,2), 
	@AltriOneri DECIMAL(18,2), 
	@Descrizione VARCHAR(255), 
	@CfFornitore VARCHAR(255), 
	@DescrizioneFornitore VARCHAR(255), 
	@IvaNonRecuperabile BIT, 
	@IdFile INT, 
	@InIntegrazione BIT, 
	@IdFileModificatoIntegrazione BIT
)
AS
	SET @Iva = ISNULL(@Iva,((0)))
	SET @IvaNonRecuperabile = ISNULL(@IvaNonRecuperabile,((0)))
	SET @InIntegrazione = ISNULL(@InIntegrazione,((0)))
	INSERT INTO GIUSTIFICATIVI
	(
		ID_PROGETTO, 
		NUMERO, 
		COD_TIPO, 
		DATA, 
		NUMERO_DOCTRASPORTO, 
		DATA_DOCTRASPORTO, 
		IMPONIBILE, 
		IVA, 
		ALTRI_ONERI, 
		DESCRIZIONE, 
		CF_FORNITORE, 
		DESCRIZIONE_FORNITORE, 
		IVA_NON_RECUPERABILE, 
		ID_FILE, 
		IN_INTEGRAZIONE, 
		ID_FILE_MODIFICATO_INTEGRAZIONE
	)
	VALUES
	(
		@IdProgetto, 
		@Numero, 
		@CodTipo, 
		@Data, 
		@NumeroDoctrasporto, 
		@DataDoctrasporto, 
		@Imponibile, 
		@Iva, 
		@AltriOneri, 
		@Descrizione, 
		@CfFornitore, 
		@DescrizioneFornitore, 
		@IvaNonRecuperabile, 
		@IdFile, 
		@InIntegrazione, 
		@IdFileModificatoIntegrazione
	)
	SELECT SCOPE_IDENTITY() AS ID_GIUSTIFICATIVO, @Iva AS IVA, @IvaNonRecuperabile AS IVA_NON_RECUPERABILE, @InIntegrazione AS IN_INTEGRAZIONE

GO

declare @old_ZGiustificativiInsert varchar(8000);
select @old_ZGiustificativiInsert = ROUTINE_DEFINITION from ##old_ZGiustificativiInsert;
exec sp_addextendedproperty 'backup',@old_ZGiustificativiInsert,'user',dbo,'procedure','ZGiustificativiInsert';
drop table ##old_ZGiustificativiInsert
GO

select ROUTINE_DEFINITION into ##old_ZGiustificativiUpdate from information_schema.routines where routine_name='ZGiustificativiUpdate';
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZGiustificativiUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ZGiustificativiUpdate];
GO
CREATE PROCEDURE [dbo].[ZGiustificativiUpdate]
(
	@IdGiustificativo INT, 
	@IdProgetto INT, 
	@Numero VARCHAR(255), 
	@CodTipo VARCHAR(255), 
	@Data DATETIME, 
	@NumeroDoctrasporto VARCHAR(255), 
	@DataDoctrasporto DATETIME, 
	@Imponibile DECIMAL(18,2), 
	@Iva DECIMAL(18,2), 
	@AltriOneri DECIMAL(18,2), 
	@Descrizione VARCHAR(255), 
	@CfFornitore VARCHAR(255), 
	@DescrizioneFornitore VARCHAR(255), 
	@IvaNonRecuperabile BIT, 
	@IdFile INT, 
	@InIntegrazione BIT, 
	@IdFileModificatoIntegrazione BIT
)
AS
	UPDATE GIUSTIFICATIVI
	SET
		ID_PROGETTO = @IdProgetto, 
		NUMERO = @Numero, 
		COD_TIPO = @CodTipo, 
		DATA = @Data, 
		NUMERO_DOCTRASPORTO = @NumeroDoctrasporto, 
		DATA_DOCTRASPORTO = @DataDoctrasporto, 
		IMPONIBILE = @Imponibile, 
		IVA = @Iva, 
		ALTRI_ONERI = @AltriOneri, 
		DESCRIZIONE = @Descrizione, 
		CF_FORNITORE = @CfFornitore, 
		DESCRIZIONE_FORNITORE = @DescrizioneFornitore, 
		IVA_NON_RECUPERABILE = @IvaNonRecuperabile, 
		ID_FILE = @IdFile, 
		IN_INTEGRAZIONE = @InIntegrazione, 
		ID_FILE_MODIFICATO_INTEGRAZIONE = @IdFileModificatoIntegrazione
	WHERE 
		(ID_GIUSTIFICATIVO = @IdGiustificativo)

GO

declare @old_ZGiustificativiUpdate varchar(8000);
select @old_ZGiustificativiUpdate = ROUTINE_DEFINITION from ##old_ZGiustificativiUpdate;
exec sp_addextendedproperty 'backup',@old_ZGiustificativiUpdate,'user',dbo,'procedure','ZGiustificativiUpdate';
drop table ##old_ZGiustificativiUpdate
GO

select ROUTINE_DEFINITION into ##old_ZGiustificativiDelete from information_schema.routines where routine_name='ZGiustificativiDelete';
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZGiustificativiDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ZGiustificativiDelete];
GO
CREATE PROCEDURE [dbo].[ZGiustificativiDelete]
(
	@IdGiustificativo INT
)
AS
	DELETE GIUSTIFICATIVI
	WHERE 
		(ID_GIUSTIFICATIVO = @IdGiustificativo)

GO

declare @old_ZGiustificativiDelete varchar(8000);
select @old_ZGiustificativiDelete = ROUTINE_DEFINITION from ##old_ZGiustificativiDelete;
exec sp_addextendedproperty 'backup',@old_ZGiustificativiDelete,'user',dbo,'procedure','ZGiustificativiDelete';
drop table ##old_ZGiustificativiDelete
GO

select ROUTINE_DEFINITION into ##old_ZGiustificativiGetById from information_schema.routines where routine_name='ZGiustificativiGetById';
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZGiustificativiGetById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ZGiustificativiGetById];
GO
CREATE PROCEDURE [dbo].[ZGiustificativiGetById]
(
	@IdGiustificativo INT
)
AS
	SELECT *
	FROM GIUSTIFICATIVI
	WHERE 
		(ID_GIUSTIFICATIVO = @IdGiustificativo)

GO

declare @old_ZGiustificativiGetById varchar(8000);
select @old_ZGiustificativiGetById = ROUTINE_DEFINITION from ##old_ZGiustificativiGetById;
exec sp_addextendedproperty 'backup',@old_ZGiustificativiGetById,'user',dbo,'procedure','ZGiustificativiGetById';
drop table ##old_ZGiustificativiGetById
GO





select ROUTINE_DEFINITION into ##old_ZGiustificativiFindSelect from information_schema.routines where routine_name='ZGiustificativiFindSelect';
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZGiustificativiFindSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ZGiustificativiFindSelect];
GO
CREATE PROCEDURE [dbo].[ZGiustificativiFindSelect]
(
	@IdGiustificativoequalthis INT, 
	@IdProgettoequalthis INT, 
	@Numeroequalthis VARCHAR(255), 
	@CodTipoequalthis VARCHAR(255), 
	@Dataequalthis DATETIME, 
	@NumeroDoctrasportoequalthis VARCHAR(255), 
	@DataDoctrasportoequalthis DATETIME, 
	@Imponibileequalthis DECIMAL(18,2), 
	@Ivaequalthis DECIMAL(18,2), 
	@AltriOneriequalthis DECIMAL(18,2), 
	@Descrizioneequalthis VARCHAR(255), 
	@CfFornitoreequalthis VARCHAR(255), 
	@DescrizioneFornitoreequalthis VARCHAR(255), 
	@IvaNonRecuperabileequalthis BIT, 
	@IdFileequalthis INT, 
	@InIntegrazioneequalthis BIT, 
	@IdFileModificatoIntegrazioneequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_GIUSTIFICATIVO, ID_PROGETTO, NUMERO, COD_TIPO, DATA, NUMERO_DOCTRASPORTO, DATA_DOCTRASPORTO, IMPONIBILE, IVA, ALTRI_ONERI, DESCRIZIONE, CF_FORNITORE, DESCRIZIONE_FORNITORE, IVA_NON_RECUPERABILE, ID_FILE, IN_INTEGRAZIONE, ID_FILE_MODIFICATO_INTEGRAZIONE FROM GIUSTIFICATIVI WHERE 1=1';
	IF (@IdGiustificativoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_GIUSTIFICATIVO = @IdGiustificativoequalthis)'; set @lensql=@lensql+len(@IdGiustificativoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@Numeroequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERO = @Numeroequalthis)'; set @lensql=@lensql+len(@Numeroequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA = @Dataequalthis)'; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@NumeroDoctrasportoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERO_DOCTRASPORTO = @NumeroDoctrasportoequalthis)'; set @lensql=@lensql+len(@NumeroDoctrasportoequalthis);end;
	IF (@DataDoctrasportoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_DOCTRASPORTO = @DataDoctrasportoequalthis)'; set @lensql=@lensql+len(@DataDoctrasportoequalthis);end;
	IF (@Imponibileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPONIBILE = @Imponibileequalthis)'; set @lensql=@lensql+len(@Imponibileequalthis);end;
	IF (@Ivaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IVA = @Ivaequalthis)'; set @lensql=@lensql+len(@Ivaequalthis);end;
	IF (@AltriOneriequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ALTRI_ONERI = @AltriOneriequalthis)'; set @lensql=@lensql+len(@AltriOneriequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@CfFornitoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_FORNITORE = @CfFornitoreequalthis)'; set @lensql=@lensql+len(@CfFornitoreequalthis);end;
	IF (@DescrizioneFornitoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE_FORNITORE = @DescrizioneFornitoreequalthis)'; set @lensql=@lensql+len(@DescrizioneFornitoreequalthis);end;
	IF (@IvaNonRecuperabileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IVA_NON_RECUPERABILE = @IvaNonRecuperabileequalthis)'; set @lensql=@lensql+len(@IvaNonRecuperabileequalthis);end;
	IF (@IdFileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FILE = @IdFileequalthis)'; set @lensql=@lensql+len(@IdFileequalthis);end;
	IF (@InIntegrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IN_INTEGRAZIONE = @InIntegrazioneequalthis)'; set @lensql=@lensql+len(@InIntegrazioneequalthis);end;
	IF (@IdFileModificatoIntegrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FILE_MODIFICATO_INTEGRAZIONE = @IdFileModificatoIntegrazioneequalthis)'; set @lensql=@lensql+len(@IdFileModificatoIntegrazioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdGiustificativoequalthis INT, @IdProgettoequalthis INT, @Numeroequalthis VARCHAR(255), @CodTipoequalthis VARCHAR(255), @Dataequalthis DATETIME, @NumeroDoctrasportoequalthis VARCHAR(255), @DataDoctrasportoequalthis DATETIME, @Imponibileequalthis DECIMAL(18,2), @Ivaequalthis DECIMAL(18,2), @AltriOneriequalthis DECIMAL(18,2), @Descrizioneequalthis VARCHAR(255), @CfFornitoreequalthis VARCHAR(255), @DescrizioneFornitoreequalthis VARCHAR(255), @IvaNonRecuperabileequalthis BIT, @IdFileequalthis INT, @InIntegrazioneequalthis BIT, @IdFileModificatoIntegrazioneequalthis BIT',@IdGiustificativoequalthis , @IdProgettoequalthis , @Numeroequalthis , @CodTipoequalthis , @Dataequalthis , @NumeroDoctrasportoequalthis , @DataDoctrasportoequalthis , @Imponibileequalthis , @Ivaequalthis , @AltriOneriequalthis , @Descrizioneequalthis , @CfFornitoreequalthis , @DescrizioneFornitoreequalthis , @IvaNonRecuperabileequalthis , @IdFileequalthis , @InIntegrazioneequalthis , @IdFileModificatoIntegrazioneequalthis ;
	else
		SELECT ID_GIUSTIFICATIVO, ID_PROGETTO, NUMERO, COD_TIPO, DATA, NUMERO_DOCTRASPORTO, DATA_DOCTRASPORTO, IMPONIBILE, IVA, ALTRI_ONERI, DESCRIZIONE, CF_FORNITORE, DESCRIZIONE_FORNITORE, IVA_NON_RECUPERABILE, ID_FILE, IN_INTEGRAZIONE, ID_FILE_MODIFICATO_INTEGRAZIONE
		FROM GIUSTIFICATIVI
		WHERE 
			((@IdGiustificativoequalthis IS NULL) OR ID_GIUSTIFICATIVO = @IdGiustificativoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@Numeroequalthis IS NULL) OR NUMERO = @Numeroequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@NumeroDoctrasportoequalthis IS NULL) OR NUMERO_DOCTRASPORTO = @NumeroDoctrasportoequalthis) AND 
			((@DataDoctrasportoequalthis IS NULL) OR DATA_DOCTRASPORTO = @DataDoctrasportoequalthis) AND 
			((@Imponibileequalthis IS NULL) OR IMPONIBILE = @Imponibileequalthis) AND 
			((@Ivaequalthis IS NULL) OR IVA = @Ivaequalthis) AND 
			((@AltriOneriequalthis IS NULL) OR ALTRI_ONERI = @AltriOneriequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@CfFornitoreequalthis IS NULL) OR CF_FORNITORE = @CfFornitoreequalthis) AND 
			((@DescrizioneFornitoreequalthis IS NULL) OR DESCRIZIONE_FORNITORE = @DescrizioneFornitoreequalthis) AND 
			((@IvaNonRecuperabileequalthis IS NULL) OR IVA_NON_RECUPERABILE = @IvaNonRecuperabileequalthis) AND 
			((@IdFileequalthis IS NULL) OR ID_FILE = @IdFileequalthis) AND 
			((@InIntegrazioneequalthis IS NULL) OR IN_INTEGRAZIONE = @InIntegrazioneequalthis) AND 
			((@IdFileModificatoIntegrazioneequalthis IS NULL) OR ID_FILE_MODIFICATO_INTEGRAZIONE = @IdFileModificatoIntegrazioneequalthis)
		

GO

declare @old_ZGiustificativiFindSelect varchar(8000);
select @old_ZGiustificativiFindSelect = ROUTINE_DEFINITION from ##old_ZGiustificativiFindSelect;
exec sp_addextendedproperty 'backup',@old_ZGiustificativiFindSelect,'user',dbo,'procedure','ZGiustificativiFindSelect';
drop table ##old_ZGiustificativiFindSelect
GO

select ROUTINE_DEFINITION into ##old_ZGiustificativiFindFind from information_schema.routines where routine_name='ZGiustificativiFindFind';
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZGiustificativiFindFind]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ZGiustificativiFindFind];
GO
CREATE PROCEDURE [dbo].[ZGiustificativiFindFind]
(
	@IdProgettoequalthis INT, 
	@CodTipoequalthis VARCHAR(255), 
	@Numeroequalthis VARCHAR(255), 
	@Dataeqlessthanthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_GIUSTIFICATIVO, ID_PROGETTO, NUMERO, COD_TIPO, DATA, NUMERO_DOCTRASPORTO, DATA_DOCTRASPORTO, IMPONIBILE, IVA, ALTRI_ONERI, DESCRIZIONE, CF_FORNITORE, DESCRIZIONE_FORNITORE, IVA_NON_RECUPERABILE, ID_FILE, IN_INTEGRAZIONE, ID_FILE_MODIFICATO_INTEGRAZIONE FROM GIUSTIFICATIVI WHERE 1=1';
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@Numeroequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERO = @Numeroequalthis)'; set @lensql=@lensql+len(@Numeroequalthis);end;
	IF (@Dataeqlessthanthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA <= @Dataeqlessthanthis)'; set @lensql=@lensql+len(@Dataeqlessthanthis);end;
	set @sql = @sql + 'ORDER BY DATA, NUMERO';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdProgettoequalthis INT, @CodTipoequalthis VARCHAR(255), @Numeroequalthis VARCHAR(255), @Dataeqlessthanthis DATETIME',@IdProgettoequalthis , @CodTipoequalthis , @Numeroequalthis , @Dataeqlessthanthis ;
	else
		SELECT ID_GIUSTIFICATIVO, ID_PROGETTO, NUMERO, COD_TIPO, DATA, NUMERO_DOCTRASPORTO, DATA_DOCTRASPORTO, IMPONIBILE, IVA, ALTRI_ONERI, DESCRIZIONE, CF_FORNITORE, DESCRIZIONE_FORNITORE, IVA_NON_RECUPERABILE, ID_FILE, IN_INTEGRAZIONE, ID_FILE_MODIFICATO_INTEGRAZIONE
		FROM GIUSTIFICATIVI
		WHERE 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@Numeroequalthis IS NULL) OR NUMERO = @Numeroequalthis) AND 
			((@Dataeqlessthanthis IS NULL) OR DATA <= @Dataeqlessthanthis)
		ORDER BY DATA, NUMERO

GO

declare @old_ZGiustificativiFindFind varchar(8000);
select @old_ZGiustificativiFindFind = ROUTINE_DEFINITION from ##old_ZGiustificativiFindFind;
exec sp_addextendedproperty 'backup',@old_ZGiustificativiFindFind,'user',dbo,'procedure','ZGiustificativiFindFind';
drop table ##old_ZGiustificativiFindFind
GO
*/

/*Config
<?xml version="1.0" encoding="utf-16"?>
<GIUSTIFICATIVI>
  <ViewName>
  </ViewName>
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
    <Find OrderBy="ORDER BY DATA, NUMERO">
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <COD_TIPO>Equal</COD_TIPO>
      <NUMERO>Equal</NUMERO>
      <DATA>EqLessThan</DATA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</GIUSTIFICATIVI>
*/
