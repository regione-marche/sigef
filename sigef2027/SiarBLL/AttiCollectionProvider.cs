using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per Atti
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IAttiProvider
    {
        int Save(Atti AttiObj);
        int SaveCollection(AttiCollection collectionObj);
        int Delete(Atti AttiObj);
        int DeleteCollection(AttiCollection collectionObj);
    }
    /// <summary>
    /// Summary description for Atti
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class Atti : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdAtto;
        private NullTypes.IntNT _Numero;
        private NullTypes.DatetimeNT _Data;
        private NullTypes.StringNT _Descrizione;
        private NullTypes.StringNT _Servizio;
        private NullTypes.StringNT _Registro;
        private NullTypes.StringNT _CodTipo;
        private NullTypes.StringNT _CodDefinizione;
        private NullTypes.StringNT _CodOrganoIstituzionale;
        private NullTypes.DatetimeNT _DataBur;
        private NullTypes.IntNT _NumeroBur;
        private NullTypes.StringNT _AwDocnumber;
        private NullTypes.IntNT _AwDocnumberNuovo;
        private NullTypes.StringNT _DefinizioneAtto;
        private NullTypes.StringNT _TipoAtto;
        private NullTypes.StringNT _OrganoIstituzionale;
        private NullTypes.StringNT _LinkEsterno;
        [NonSerialized] private IAttiProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IAttiProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public Atti()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:ID_ATTO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdAtto
        {
            get { return _IdAtto; }
            set
            {
                if (IdAtto != value)
                {
                    _IdAtto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NUMERO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT Numero
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
        /// Corrisponde al campo:DESCRIZIONE
        /// Tipo sul db:VARCHAR(3000)
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
        /// Corrisponde al campo:SERVIZIO
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT Servizio
        {
            get { return _Servizio; }
            set
            {
                if (Servizio != value)
                {
                    _Servizio = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:REGISTRO
        /// Tipo sul db:VARCHAR(10)
        /// </summary>
        public NullTypes.StringNT Registro
        {
            get { return _Registro; }
            set
            {
                if (Registro != value)
                {
                    _Registro = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COD_TIPO
        /// Tipo sul db:CHAR(1)
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
        /// Corrisponde al campo:COD_DEFINIZIONE
        /// Tipo sul db:CHAR(1)
        /// </summary>
        public NullTypes.StringNT CodDefinizione
        {
            get { return _CodDefinizione; }
            set
            {
                if (CodDefinizione != value)
                {
                    _CodDefinizione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COD_ORGANO_ISTITUZIONALE
        /// Tipo sul db:CHAR(2)
        /// </summary>
        public NullTypes.StringNT CodOrganoIstituzionale
        {
            get { return _CodOrganoIstituzionale; }
            set
            {
                if (CodOrganoIstituzionale != value)
                {
                    _CodOrganoIstituzionale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_BUR
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataBur
        {
            get { return _DataBur; }
            set
            {
                if (DataBur != value)
                {
                    _DataBur = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NUMERO_BUR
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT NumeroBur
        {
            get { return _NumeroBur; }
            set
            {
                if (NumeroBur != value)
                {
                    _NumeroBur = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:AW_DOCNUMBER
        /// Tipo sul db:VARCHAR(30)
        /// </summary>
        public NullTypes.StringNT AwDocnumber
        {
            get { return _AwDocnumber; }
            set
            {
                if (AwDocnumber != value)
                {
                    _AwDocnumber = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:AW_DOCNUMBER_NUOVO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT AwDocnumberNuovo
        {
            get { return _AwDocnumberNuovo; }
            set
            {
                if (AwDocnumberNuovo != value)
                {
                    _AwDocnumberNuovo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DEFINIZIONE_ATTO
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT DefinizioneAtto
        {
            get { return _DefinizioneAtto; }
            set
            {
                if (DefinizioneAtto != value)
                {
                    _DefinizioneAtto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:TIPO_ATTO
        /// Tipo sul db:VARCHAR(80)
        /// </summary>
        public NullTypes.StringNT TipoAtto
        {
            get { return _TipoAtto; }
            set
            {
                if (TipoAtto != value)
                {
                    _TipoAtto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ORGANO_ISTITUZIONALE
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT OrganoIstituzionale
        {
            get { return _OrganoIstituzionale; }
            set
            {
                if (OrganoIstituzionale != value)
                {
                    _OrganoIstituzionale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:LINK_ESTERNO
        /// Tipo sul db:VARCHAR(3000)
        /// </summary>
        public NullTypes.StringNT LinkEsterno
        {
            get { return _LinkEsterno; }
            set
            {
                if (LinkEsterno != value)
                {
                    _LinkEsterno = value;
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
    /// Summary description for AttiCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class AttiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private AttiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((Atti)info.GetValue(i.ToString(), typeof(Atti)));
            }
        }

        //Costruttore
        public AttiCollection()
        {
            this.ItemType = typeof(Atti);
        }

        //Costruttore con provider
        public AttiCollection(IAttiProvider providerObj)
        {
            this.ItemType = typeof(Atti);
            this.Provider = providerObj;
        }

        //Get e Set
        public new Atti this[int index]
        {
            get { return (Atti)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new AttiCollection GetChanges()
        {
            return (AttiCollection)base.GetChanges();
        }

        [NonSerialized] private IAttiProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IAttiProvider Provider
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
        public int Add(Atti AttiObj)
        {
            if (AttiObj.Provider == null) AttiObj.Provider = this.Provider;
            return base.Add(AttiObj);
        }

        //AddCollection
        public void AddCollection(AttiCollection AttiCollectionObj)
        {
            foreach (Atti AttiObj in AttiCollectionObj)
                this.Add(AttiObj);
        }

        //Insert
        public void Insert(int index, Atti AttiObj)
        {
            if (AttiObj.Provider == null) AttiObj.Provider = this.Provider;
            base.Insert(index, AttiObj);
        }

        //CollectionGetById
        public Atti CollectionGetById(NullTypes.IntNT IdAttoValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdAtto == IdAttoValue))
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
        public AttiCollection SubSelect(NullTypes.IntNT IdAttoEqualThis, NullTypes.StringNT CodTipoEqualThis, NullTypes.StringNT CodDefinizioneEqualThis,
NullTypes.StringNT CodOrganoIstituzionaleEqualThis, NullTypes.IntNT NumeroEqualThis, NullTypes.DatetimeNT DataEqualThis,
NullTypes.StringNT DescrizioneEqualThis, NullTypes.DatetimeNT DataBurEqualThis, NullTypes.IntNT NumeroBurEqualThis,
NullTypes.StringNT ServizioEqualThis, NullTypes.StringNT RegistroEqualThis, NullTypes.StringNT AwDocnumberEqualThis,
NullTypes.IntNT AwDocnumberNuovoEqualThis, NullTypes.StringNT LinkEsternoEqualThis)
        {
            AttiCollection AttiCollectionTemp = new AttiCollection();
            foreach (Atti AttiItem in this)
            {
                if (((IdAttoEqualThis == null) || ((AttiItem.IdAtto != null) && (AttiItem.IdAtto.Value == IdAttoEqualThis.Value))) && ((CodTipoEqualThis == null) || ((AttiItem.CodTipo != null) && (AttiItem.CodTipo.Value == CodTipoEqualThis.Value))) && ((CodDefinizioneEqualThis == null) || ((AttiItem.CodDefinizione != null) && (AttiItem.CodDefinizione.Value == CodDefinizioneEqualThis.Value))) &&
((CodOrganoIstituzionaleEqualThis == null) || ((AttiItem.CodOrganoIstituzionale != null) && (AttiItem.CodOrganoIstituzionale.Value == CodOrganoIstituzionaleEqualThis.Value))) && ((NumeroEqualThis == null) || ((AttiItem.Numero != null) && (AttiItem.Numero.Value == NumeroEqualThis.Value))) && ((DataEqualThis == null) || ((AttiItem.Data != null) && (AttiItem.Data.Value == DataEqualThis.Value))) &&
((DescrizioneEqualThis == null) || ((AttiItem.Descrizione != null) && (AttiItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((DataBurEqualThis == null) || ((AttiItem.DataBur != null) && (AttiItem.DataBur.Value == DataBurEqualThis.Value))) && ((NumeroBurEqualThis == null) || ((AttiItem.NumeroBur != null) && (AttiItem.NumeroBur.Value == NumeroBurEqualThis.Value))) &&
((ServizioEqualThis == null) || ((AttiItem.Servizio != null) && (AttiItem.Servizio.Value == ServizioEqualThis.Value))) && ((RegistroEqualThis == null) || ((AttiItem.Registro != null) && (AttiItem.Registro.Value == RegistroEqualThis.Value))) && ((AwDocnumberEqualThis == null) || ((AttiItem.AwDocnumber != null) && (AttiItem.AwDocnumber.Value == AwDocnumberEqualThis.Value))) &&
((AwDocnumberNuovoEqualThis == null) || ((AttiItem.AwDocnumberNuovo != null) && (AttiItem.AwDocnumberNuovo.Value == AwDocnumberNuovoEqualThis.Value))) && ((LinkEsternoEqualThis == null) || ((AttiItem.LinkEsterno != null) && (AttiItem.LinkEsterno.Value == LinkEsternoEqualThis.Value))))
                {
                    AttiCollectionTemp.Add(AttiItem);
                }
            }
            return AttiCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for AttiDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class AttiDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, Atti AttiObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdAtto", AttiObj.IdAtto);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "Numero", AttiObj.Numero);
            DbProvider.SetCmdParam(cmd, firstChar + "Data", AttiObj.Data);
            DbProvider.SetCmdParam(cmd, firstChar + "Descrizione", AttiObj.Descrizione);
            DbProvider.SetCmdParam(cmd, firstChar + "Servizio", AttiObj.Servizio);
            DbProvider.SetCmdParam(cmd, firstChar + "Registro", AttiObj.Registro);
            DbProvider.SetCmdParam(cmd, firstChar + "CodTipo", AttiObj.CodTipo);
            DbProvider.SetCmdParam(cmd, firstChar + "CodDefinizione", AttiObj.CodDefinizione);
            DbProvider.SetCmdParam(cmd, firstChar + "CodOrganoIstituzionale", AttiObj.CodOrganoIstituzionale);
            DbProvider.SetCmdParam(cmd, firstChar + "DataBur", AttiObj.DataBur);
            DbProvider.SetCmdParam(cmd, firstChar + "NumeroBur", AttiObj.NumeroBur);
            DbProvider.SetCmdParam(cmd, firstChar + "AwDocnumber", AttiObj.AwDocnumber);
            DbProvider.SetCmdParam(cmd, firstChar + "AwDocnumberNuovo", AttiObj.AwDocnumberNuovo);
            DbProvider.SetCmdParam(cmd, firstChar + "LinkEsterno", AttiObj.LinkEsterno);
        }
        //Insert
        private static int Insert(DbProvider db, Atti AttiObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZAttiInsert", new string[] {"Numero", "Data",
"Descrizione", "Servizio", "Registro",
"CodTipo", "CodDefinizione", "CodOrganoIstituzionale",
"DataBur", "NumeroBur", "AwDocnumber",
"AwDocnumberNuovo",
"LinkEsterno"}, new string[] {"int", "DateTime",
"string", "string", "string",
"string", "string", "string",
"DateTime", "int", "string",
"int",
"string"}, "");
                CompileIUCmd(false, insertCmd, AttiObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    AttiObj.IdAtto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ATTO"]);
                }
                AttiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                AttiObj.IsDirty = false;
                AttiObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, Atti AttiObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZAttiUpdate", new string[] {"IdAtto", "Numero", "Data",
"Descrizione", "Servizio", "Registro",
"CodTipo", "CodDefinizione", "CodOrganoIstituzionale",
"DataBur", "NumeroBur", "AwDocnumber",
"AwDocnumberNuovo",
"LinkEsterno"}, new string[] {"int", "int", "DateTime",
"string", "string", "string",
"string", "string", "string",
"DateTime", "int", "string",
"int",
"string"}, "");
                CompileIUCmd(true, updateCmd, AttiObj, db.CommandFirstChar);
                i = db.Execute(updateCmd);
                AttiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                AttiObj.IsDirty = false;
                AttiObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, Atti AttiObj)
        {
            switch (AttiObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, AttiObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, AttiObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, AttiObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, AttiCollection AttiCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZAttiUpdate", new string[] {"IdAtto", "Numero", "Data",
"Descrizione", "Servizio", "Registro",
"CodTipo", "CodDefinizione", "CodOrganoIstituzionale",
"DataBur", "NumeroBur", "AwDocnumber",
"AwDocnumberNuovo",
"LinkEsterno"}, new string[] {"int", "int", "DateTime",
"string", "string", "string",
"string", "string", "string",
"DateTime", "int", "string",
"int",
"string"}, "");
                IDbCommand insertCmd = db.InitCmd("ZAttiInsert", new string[] {"Numero", "Data",
"Descrizione", "Servizio", "Registro",
"CodTipo", "CodDefinizione", "CodOrganoIstituzionale",
"DataBur", "NumeroBur", "AwDocnumber",
"AwDocnumberNuovo",
"LinkEsterno"}, new string[] {"int", "DateTime",
"string", "string", "string",
"string", "string", "string",
"DateTime", "int", "string",
"int",
"string"}, "");
                IDbCommand deleteCmd = db.InitCmd("ZAttiDelete", new string[] { "IdAtto" }, new string[] { "int" }, "");
                for (int i = 0; i < AttiCollectionObj.Count; i++)
                {
                    switch (AttiCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, AttiCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    AttiCollectionObj[i].IdAtto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ATTO"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, AttiCollectionObj[i], db.CommandFirstChar);
                                returnValue = returnValue + db.Execute(updateCmd);
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (AttiCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdAtto", (SiarLibrary.NullTypes.IntNT)AttiCollectionObj[i].IdAtto);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < AttiCollectionObj.Count; i++)
                {
                    if ((AttiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (AttiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        AttiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        AttiCollectionObj[i].IsDirty = false;
                        AttiCollectionObj[i].IsPersistent = true;
                    }
                    if ((AttiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        AttiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        AttiCollectionObj[i].IsDirty = false;
                        AttiCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, Atti AttiObj)
        {
            int returnValue = 0;
            if (AttiObj.IsPersistent)
            {
                returnValue = Delete(db, AttiObj.IdAtto);
            }
            AttiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            AttiObj.IsDirty = false;
            AttiObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdAttoValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZAttiDelete", new string[] { "IdAtto" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdAtto", (SiarLibrary.NullTypes.IntNT)IdAttoValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, AttiCollection AttiCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZAttiDelete", new string[] { "IdAtto" }, new string[] { "int" }, "");
                for (int i = 0; i < AttiCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdAtto", AttiCollectionObj[i].IdAtto);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < AttiCollectionObj.Count; i++)
                {
                    if ((AttiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (AttiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        AttiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        AttiCollectionObj[i].IsDirty = false;
                        AttiCollectionObj[i].IsPersistent = false;
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
        public static Atti GetById(DbProvider db, int IdAttoValue)
        {
            Atti AttiObj = null;
            IDbCommand readCmd = db.InitCmd("ZAttiGetById", new string[] { "IdAtto" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdAtto", (SiarLibrary.NullTypes.IntNT)IdAttoValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                AttiObj = GetFromDatareader(db);
                AttiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                AttiObj.IsDirty = false;
                AttiObj.IsPersistent = true;
            }
            db.Close();
            return AttiObj;
        }

        //getFromDatareader
        public static Atti GetFromDatareader(DbProvider db)
        {
            Atti AttiObj = new Atti();
            AttiObj.IdAtto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ATTO"]);
            AttiObj.Numero = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMERO"]);
            AttiObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
            AttiObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
            AttiObj.Servizio = new SiarLibrary.NullTypes.StringNT(db.DataReader["SERVIZIO"]);
            AttiObj.Registro = new SiarLibrary.NullTypes.StringNT(db.DataReader["REGISTRO"]);
            AttiObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
            AttiObj.CodDefinizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_DEFINIZIONE"]);
            AttiObj.CodOrganoIstituzionale = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ORGANO_ISTITUZIONALE"]);
            AttiObj.DataBur = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_BUR"]);
            AttiObj.NumeroBur = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMERO_BUR"]);
            AttiObj.AwDocnumber = new SiarLibrary.NullTypes.StringNT(db.DataReader["AW_DOCNUMBER"]);
            AttiObj.AwDocnumberNuovo = new SiarLibrary.NullTypes.IntNT(db.DataReader["AW_DOCNUMBER_NUOVO"]);
            AttiObj.DefinizioneAtto = new SiarLibrary.NullTypes.StringNT(db.DataReader["DEFINIZIONE_ATTO"]);
            AttiObj.TipoAtto = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_ATTO"]);
            AttiObj.OrganoIstituzionale = new SiarLibrary.NullTypes.StringNT(db.DataReader["ORGANO_ISTITUZIONALE"]);
            AttiObj.LinkEsterno = new SiarLibrary.NullTypes.StringNT(db.DataReader["LINK_ESTERNO"]);
            AttiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            AttiObj.IsDirty = false;
            AttiObj.IsPersistent = true;
            return AttiObj;
        }

        //Find Select

        public static AttiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdAttoEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.StringNT CodDefinizioneEqualThis,
SiarLibrary.NullTypes.StringNT CodOrganoIstituzionaleEqualThis, SiarLibrary.NullTypes.IntNT NumeroEqualThis, SiarLibrary.NullTypes.DatetimeNT DataEqualThis,
SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.DatetimeNT DataBurEqualThis, SiarLibrary.NullTypes.IntNT NumeroBurEqualThis,
SiarLibrary.NullTypes.StringNT ServizioEqualThis, SiarLibrary.NullTypes.StringNT RegistroEqualThis, SiarLibrary.NullTypes.StringNT AwDocnumberEqualThis,
SiarLibrary.NullTypes.IntNT AwDocnumberNuovoEqualThis, SiarLibrary.NullTypes.StringNT LinkEsternoEqualThis)

        {

            AttiCollection AttiCollectionObj = new AttiCollection();

            IDbCommand findCmd = db.InitCmd("Zattifindselect", new string[] {"IdAttoequalthis", "CodTipoequalthis", "CodDefinizioneequalthis",
"CodOrganoIstituzionaleequalthis", "Numeroequalthis", "Dataequalthis",
"Descrizioneequalthis", "DataBurequalthis", "NumeroBurequalthis",
"Servizioequalthis", "Registroequalthis", "AwDocnumberequalthis",
"AwDocnumberNuovoequalthis", "LinkEsternoequalthis"}, new string[] {"int", "string", "string",
"string", "int", "DateTime",
"string", "DateTime", "int",
"string", "string", "string",
"int", "string"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdAttoequalthis", IdAttoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodDefinizioneequalthis", CodDefinizioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodOrganoIstituzionaleequalthis", CodOrganoIstituzionaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Numeroequalthis", NumeroEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Dataequalthis", DataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataBurequalthis", DataBurEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "NumeroBurequalthis", NumeroBurEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Servizioequalthis", ServizioEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Registroequalthis", RegistroEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "AwDocnumberequalthis", AwDocnumberEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "AwDocnumberNuovoequalthis", AwDocnumberNuovoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "LinkEsternoequalthis", LinkEsternoEqualThis);
            Atti AttiObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                AttiObj = GetFromDatareader(db);
                AttiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                AttiObj.IsDirty = false;
                AttiObj.IsPersistent = true;
                AttiCollectionObj.Add(AttiObj);
            }
            db.Close();
            return AttiCollectionObj;
        }

        //Find Find

        public static AttiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT NumeroEqualThis, SiarLibrary.NullTypes.DatetimeNT DataEqualThis, SiarLibrary.NullTypes.StringNT CodDefinizioneEqualThis,
SiarLibrary.NullTypes.StringNT RegistroEqualThis)

        {

            AttiCollection AttiCollectionObj = new AttiCollection();

            IDbCommand findCmd = db.InitCmd("Zattifindfind", new string[] {"Numeroequalthis", "Dataequalthis", "CodDefinizioneequalthis",
"Registroequalthis"}, new string[] {"int", "DateTime", "string",
"string"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Numeroequalthis", NumeroEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Dataequalthis", DataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodDefinizioneequalthis", CodDefinizioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Registroequalthis", RegistroEqualThis);
            Atti AttiObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                AttiObj = GetFromDatareader(db);
                AttiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                AttiObj.IsDirty = false;
                AttiObj.IsPersistent = true;
                AttiCollectionObj.Add(AttiObj);
            }
            db.Close();
            return AttiCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for AttiCollectionProvider:IAttiProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class AttiCollectionProvider : IAttiProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di Atti
        protected AttiCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public AttiCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new AttiCollection(this);
        }

        //Costruttore 2: popola la collection
        public AttiCollectionProvider(IntNT NumeroEqualThis, DatetimeNT DataEqualThis, StringNT CoddefinizioneEqualThis,
StringNT RegistroEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(NumeroEqualThis, DataEqualThis, CoddefinizioneEqualThis,
RegistroEqualThis);
        }

        //Costruttore3: ha in input attiCollectionObj - non popola la collection
        public AttiCollectionProvider(AttiCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public AttiCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new AttiCollection(this);
        }

        //Get e Set
        public AttiCollection CollectionObj
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
        public int SaveCollection(AttiCollection collectionObj)
        {
            return AttiDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(Atti attiObj)
        {
            return AttiDAL.Save(_dbProviderObj, attiObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(AttiCollection collectionObj)
        {
            return AttiDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(Atti attiObj)
        {
            return AttiDAL.Delete(_dbProviderObj, attiObj);
        }

        //getById
        public Atti GetById(IntNT IdAttoValue)
        {
            Atti AttiTemp = AttiDAL.GetById(_dbProviderObj, IdAttoValue);
            if (AttiTemp != null) AttiTemp.Provider = this;
            return AttiTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public AttiCollection Select(IntNT IdattoEqualThis, StringNT CodtipoEqualThis, StringNT CoddefinizioneEqualThis,
StringNT CodorganoistituzionaleEqualThis, IntNT NumeroEqualThis, DatetimeNT DataEqualThis,
StringNT DescrizioneEqualThis, DatetimeNT DataburEqualThis, IntNT NumeroburEqualThis,
StringNT ServizioEqualThis, StringNT RegistroEqualThis, StringNT AwdocnumberEqualThis,
IntNT AwdocnumbernuovoEqualThis, StringNT LinkesternoEqualThis)
        {
            AttiCollection AttiCollectionTemp = AttiDAL.Select(_dbProviderObj, IdattoEqualThis, CodtipoEqualThis, CoddefinizioneEqualThis,
CodorganoistituzionaleEqualThis, NumeroEqualThis, DataEqualThis,
DescrizioneEqualThis, DataburEqualThis, NumeroburEqualThis,
ServizioEqualThis, RegistroEqualThis, AwdocnumberEqualThis,
AwdocnumbernuovoEqualThis, LinkesternoEqualThis);
            AttiCollectionTemp.Provider = this;
            return AttiCollectionTemp;
        }

        //Find: popola la collection
        public AttiCollection Find(IntNT NumeroEqualThis, DatetimeNT DataEqualThis, StringNT CoddefinizioneEqualThis,
StringNT RegistroEqualThis)
        {
            AttiCollection AttiCollectionTemp = AttiDAL.Find(_dbProviderObj, NumeroEqualThis, DataEqualThis, CoddefinizioneEqualThis,
RegistroEqualThis);
            AttiCollectionTemp.Provider = this;
            return AttiCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<ATTI>
  <ViewName>vATTO</ViewName>
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
    <Find OrderBy="ORDER BY DATA DESC,NUMERO DESC,REGISTRO">
      <NUMERO>Equal</NUMERO>
      <DATA>Equal</DATA>
      <COD_DEFINIZIONE>Equal</COD_DEFINIZIONE>
      <REGISTRO>Equal</REGISTRO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</ATTI>
*/
