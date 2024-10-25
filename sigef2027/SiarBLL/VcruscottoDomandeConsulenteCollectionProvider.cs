using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    /// <summary>
    /// Summary description for VcruscottoDomandeConsulente
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class VcruscottoDomandeConsulente : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdBando;
        private NullTypes.StringNT _DescrizioneBando;
        private NullTypes.DatetimeNT _DataScadenzaBando;
        private NullTypes.StringNT _CodEnteBando;
        private NullTypes.IntNT _IdProgrammazioneBando;
        private NullTypes.IntNT _IdProgetto;
        private NullTypes.StringNT _CodStatoProgetto;
        private NullTypes.StringNT _StatoProgetto;
        private NullTypes.IntNT _IdImpresa;
        private NullTypes.StringNT _RagioneSocialeImpresa;
        private NullTypes.IntNT _IdUtente;
        private NullTypes.StringNT _NominativoUtenteImpresa;
        private NullTypes.StringNT _CfUtenteImpresa;
        private NullTypes.BoolNT _UtenteAttivo;


        //Costruttore
        public VcruscottoDomandeConsulente()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:ID_BANDO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdBando
        {
            get { return _IdBando; }
            set
            {
                if (IdBando != value)
                {
                    _IdBando = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DESCRIZIONE_BANDO
        /// Tipo sul db:VARCHAR(2000)
        /// </summary>
        public NullTypes.StringNT DescrizioneBando
        {
            get { return _DescrizioneBando; }
            set
            {
                if (DescrizioneBando != value)
                {
                    _DescrizioneBando = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_SCADENZA_BANDO
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataScadenzaBando
        {
            get { return _DataScadenzaBando; }
            set
            {
                if (DataScadenzaBando != value)
                {
                    _DataScadenzaBando = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COD_ENTE_BANDO
        /// Tipo sul db:VARCHAR(10)
        /// </summary>
        public NullTypes.StringNT CodEnteBando
        {
            get { return _CodEnteBando; }
            set
            {
                if (CodEnteBando != value)
                {
                    _CodEnteBando = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_PROGRAMMAZIONE_BANDO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdProgrammazioneBando
        {
            get { return _IdProgrammazioneBando; }
            set
            {
                if (IdProgrammazioneBando != value)
                {
                    _IdProgrammazioneBando = value;
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
        /// Corrisponde al campo:COD_STATO_PROGETTO
        /// Tipo sul db:CHAR(1)
        /// </summary>
        public NullTypes.StringNT CodStatoProgetto
        {
            get { return _CodStatoProgetto; }
            set
            {
                if (CodStatoProgetto != value)
                {
                    _CodStatoProgetto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:STATO_PROGETTO
        /// Tipo sul db:VARCHAR(80)
        /// </summary>
        public NullTypes.StringNT StatoProgetto
        {
            get { return _StatoProgetto; }
            set
            {
                if (StatoProgetto != value)
                {
                    _StatoProgetto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_IMPRESA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdImpresa
        {
            get { return _IdImpresa; }
            set
            {
                if (IdImpresa != value)
                {
                    _IdImpresa = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:RAGIONE_SOCIALE_IMPRESA
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT RagioneSocialeImpresa
        {
            get { return _RagioneSocialeImpresa; }
            set
            {
                if (RagioneSocialeImpresa != value)
                {
                    _RagioneSocialeImpresa = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_UTENTE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdUtente
        {
            get { return _IdUtente; }
            set
            {
                if (IdUtente != value)
                {
                    _IdUtente = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NOMINATIVO_UTENTE_IMPRESA
        /// Tipo sul db:VARCHAR(511)
        /// </summary>
        public NullTypes.StringNT NominativoUtenteImpresa
        {
            get { return _NominativoUtenteImpresa; }
            set
            {
                if (NominativoUtenteImpresa != value)
                {
                    _NominativoUtenteImpresa = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CF_UTENTE_IMPRESA
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT CfUtenteImpresa
        {
            get { return _CfUtenteImpresa; }
            set
            {
                if (CfUtenteImpresa != value)
                {
                    _CfUtenteImpresa = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:UTENTE_ATTIVO
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT UtenteAttivo
        {
            get { return _UtenteAttivo; }
            set
            {
                if (UtenteAttivo != value)
                {
                    _UtenteAttivo = value;
                    SetDirtyFlag();
                }
            }
        }




    }
}

namespace SiarLibrary
{

    /// <summary>
    /// Summary description for VcruscottoDomandeConsulenteCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class VcruscottoDomandeConsulenteCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private VcruscottoDomandeConsulenteCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((VcruscottoDomandeConsulente)info.GetValue(i.ToString(), typeof(VcruscottoDomandeConsulente)));
            }
        }

        //Costruttore
        public VcruscottoDomandeConsulenteCollection()
        {
            this.ItemType = typeof(VcruscottoDomandeConsulente);
        }

        //Get e Set
        public new VcruscottoDomandeConsulente this[int index]
        {
            get { return (VcruscottoDomandeConsulente)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new VcruscottoDomandeConsulenteCollection GetChanges()
        {
            return (VcruscottoDomandeConsulenteCollection)base.GetChanges();
        }

        //Add
        public int Add(VcruscottoDomandeConsulente VcruscottoDomandeConsulenteObj)
        {
            return base.Add(VcruscottoDomandeConsulenteObj);
        }

        //AddCollection
        public void AddCollection(VcruscottoDomandeConsulenteCollection VcruscottoDomandeConsulenteCollectionObj)
        {
            foreach (VcruscottoDomandeConsulente VcruscottoDomandeConsulenteObj in VcruscottoDomandeConsulenteCollectionObj)
                this.Add(VcruscottoDomandeConsulenteObj);
        }

        //Insert
        public void Insert(int index, VcruscottoDomandeConsulente VcruscottoDomandeConsulenteObj)
        {
            base.Insert(index, VcruscottoDomandeConsulenteObj);
        }

        //filter: effettua una ricerca all'interno della collection
        // se il parametro di ricerca è null, prende tutto,
        // anche i record che hanno quel campo null
        // altrimenti scarta i record che hanno quel campo null ...
        // ...e confronta gli altri
        public VcruscottoDomandeConsulenteCollection SubSelect(NullTypes.IntNT IdBandoEqualThis, NullTypes.StringNT DescrizioneBandoEqualThis, NullTypes.DatetimeNT DataScadenzaBandoEqualThis,
NullTypes.StringNT CodEnteBandoEqualThis, NullTypes.IntNT IdProgrammazioneBandoEqualThis, NullTypes.IntNT IdProgettoEqualThis,
NullTypes.StringNT CodStatoProgettoEqualThis, NullTypes.StringNT StatoProgettoEqualThis, NullTypes.IntNT IdImpresaEqualThis,
NullTypes.StringNT RagioneSocialeImpresaEqualThis, NullTypes.IntNT IdUtenteEqualThis, NullTypes.StringNT NominativoUtenteImpresaEqualThis,
NullTypes.StringNT CfUtenteImpresaEqualThis, NullTypes.BoolNT UtenteAttivoEqualThis)
        {
            VcruscottoDomandeConsulenteCollection VcruscottoDomandeConsulenteCollectionTemp = new VcruscottoDomandeConsulenteCollection();
            foreach (VcruscottoDomandeConsulente VcruscottoDomandeConsulenteItem in this)
            {
                if (((IdBandoEqualThis == null) || ((VcruscottoDomandeConsulenteItem.IdBando != null) && (VcruscottoDomandeConsulenteItem.IdBando.Value == IdBandoEqualThis.Value))) && ((DescrizioneBandoEqualThis == null) || ((VcruscottoDomandeConsulenteItem.DescrizioneBando != null) && (VcruscottoDomandeConsulenteItem.DescrizioneBando.Value == DescrizioneBandoEqualThis.Value))) && ((DataScadenzaBandoEqualThis == null) || ((VcruscottoDomandeConsulenteItem.DataScadenzaBando != null) && (VcruscottoDomandeConsulenteItem.DataScadenzaBando.Value == DataScadenzaBandoEqualThis.Value))) &&
((CodEnteBandoEqualThis == null) || ((VcruscottoDomandeConsulenteItem.CodEnteBando != null) && (VcruscottoDomandeConsulenteItem.CodEnteBando.Value == CodEnteBandoEqualThis.Value))) && ((IdProgrammazioneBandoEqualThis == null) || ((VcruscottoDomandeConsulenteItem.IdProgrammazioneBando != null) && (VcruscottoDomandeConsulenteItem.IdProgrammazioneBando.Value == IdProgrammazioneBandoEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((VcruscottoDomandeConsulenteItem.IdProgetto != null) && (VcruscottoDomandeConsulenteItem.IdProgetto.Value == IdProgettoEqualThis.Value))) &&
((CodStatoProgettoEqualThis == null) || ((VcruscottoDomandeConsulenteItem.CodStatoProgetto != null) && (VcruscottoDomandeConsulenteItem.CodStatoProgetto.Value == CodStatoProgettoEqualThis.Value))) && ((StatoProgettoEqualThis == null) || ((VcruscottoDomandeConsulenteItem.StatoProgetto != null) && (VcruscottoDomandeConsulenteItem.StatoProgetto.Value == StatoProgettoEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((VcruscottoDomandeConsulenteItem.IdImpresa != null) && (VcruscottoDomandeConsulenteItem.IdImpresa.Value == IdImpresaEqualThis.Value))) &&
((RagioneSocialeImpresaEqualThis == null) || ((VcruscottoDomandeConsulenteItem.RagioneSocialeImpresa != null) && (VcruscottoDomandeConsulenteItem.RagioneSocialeImpresa.Value == RagioneSocialeImpresaEqualThis.Value))) && ((IdUtenteEqualThis == null) || ((VcruscottoDomandeConsulenteItem.IdUtente != null) && (VcruscottoDomandeConsulenteItem.IdUtente.Value == IdUtenteEqualThis.Value))) && ((NominativoUtenteImpresaEqualThis == null) || ((VcruscottoDomandeConsulenteItem.NominativoUtenteImpresa != null) && (VcruscottoDomandeConsulenteItem.NominativoUtenteImpresa.Value == NominativoUtenteImpresaEqualThis.Value))) &&
((CfUtenteImpresaEqualThis == null) || ((VcruscottoDomandeConsulenteItem.CfUtenteImpresa != null) && (VcruscottoDomandeConsulenteItem.CfUtenteImpresa.Value == CfUtenteImpresaEqualThis.Value))) && ((UtenteAttivoEqualThis == null) || ((VcruscottoDomandeConsulenteItem.UtenteAttivo != null) && (VcruscottoDomandeConsulenteItem.UtenteAttivo.Value == UtenteAttivoEqualThis.Value))))
                {
                    VcruscottoDomandeConsulenteCollectionTemp.Add(VcruscottoDomandeConsulenteItem);
                }
            }
            return VcruscottoDomandeConsulenteCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for VcruscottoDomandeConsulenteDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class VcruscottoDomandeConsulenteDAL
    {

        //Operazioni

        //getFromDatareader
        public static VcruscottoDomandeConsulente GetFromDatareader(DbProvider db)
        {
            VcruscottoDomandeConsulente VcruscottoDomandeConsulenteObj = new VcruscottoDomandeConsulente();
            VcruscottoDomandeConsulenteObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
            VcruscottoDomandeConsulenteObj.DescrizioneBando = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_BANDO"]);
            VcruscottoDomandeConsulenteObj.DataScadenzaBando = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_SCADENZA_BANDO"]);
            VcruscottoDomandeConsulenteObj.CodEnteBando = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE_BANDO"]);
            VcruscottoDomandeConsulenteObj.IdProgrammazioneBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGRAMMAZIONE_BANDO"]);
            VcruscottoDomandeConsulenteObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
            VcruscottoDomandeConsulenteObj.CodStatoProgetto = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_STATO_PROGETTO"]);
            VcruscottoDomandeConsulenteObj.StatoProgetto = new SiarLibrary.NullTypes.StringNT(db.DataReader["STATO_PROGETTO"]);
            VcruscottoDomandeConsulenteObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
            VcruscottoDomandeConsulenteObj.RagioneSocialeImpresa = new SiarLibrary.NullTypes.StringNT(db.DataReader["RAGIONE_SOCIALE_IMPRESA"]);
            VcruscottoDomandeConsulenteObj.IdUtente = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_UTENTE"]);
            VcruscottoDomandeConsulenteObj.NominativoUtenteImpresa = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO_UTENTE_IMPRESA"]);
            VcruscottoDomandeConsulenteObj.CfUtenteImpresa = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_UTENTE_IMPRESA"]);
            VcruscottoDomandeConsulenteObj.UtenteAttivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["UTENTE_ATTIVO"]);
            VcruscottoDomandeConsulenteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            VcruscottoDomandeConsulenteObj.IsDirty = false;
            VcruscottoDomandeConsulenteObj.IsPersistent = true;
            return VcruscottoDomandeConsulenteObj;
        }

        //Find Select

        public static VcruscottoDomandeConsulenteCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneBandoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataScadenzaBandoEqualThis,
SiarLibrary.NullTypes.StringNT CodEnteBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgrammazioneBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis,
SiarLibrary.NullTypes.StringNT CodStatoProgettoEqualThis, SiarLibrary.NullTypes.StringNT StatoProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis,
SiarLibrary.NullTypes.StringNT RagioneSocialeImpresaEqualThis, SiarLibrary.NullTypes.IntNT IdUtenteEqualThis, SiarLibrary.NullTypes.StringNT NominativoUtenteImpresaEqualThis,
SiarLibrary.NullTypes.StringNT CfUtenteImpresaEqualThis, SiarLibrary.NullTypes.BoolNT UtenteAttivoEqualThis)

        {

            VcruscottoDomandeConsulenteCollection VcruscottoDomandeConsulenteCollectionObj = new VcruscottoDomandeConsulenteCollection();

            IDbCommand findCmd = db.InitCmd("Zvcruscottodomandeconsulentefindselect", new string[] {"IdBandoequalthis", "DescrizioneBandoequalthis", "DataScadenzaBandoequalthis",
"CodEnteBandoequalthis", "IdProgrammazioneBandoequalthis", "IdProgettoequalthis",
"CodStatoProgettoequalthis", "StatoProgettoequalthis", "IdImpresaequalthis",
"RagioneSocialeImpresaequalthis", "IdUtenteequalthis", "NominativoUtenteImpresaequalthis",
"CfUtenteImpresaequalthis", "UtenteAttivoequalthis"}, new string[] {"int", "string", "DateTime",
"string", "int", "int",
"string", "string", "int",
"string", "int", "string",
"string", "bool"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DescrizioneBandoequalthis", DescrizioneBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataScadenzaBandoequalthis", DataScadenzaBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodEnteBandoequalthis", CodEnteBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgrammazioneBandoequalthis", IdProgrammazioneBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodStatoProgettoequalthis", CodStatoProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "StatoProgettoequalthis", StatoProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "RagioneSocialeImpresaequalthis", RagioneSocialeImpresaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdUtenteequalthis", IdUtenteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "NominativoUtenteImpresaequalthis", NominativoUtenteImpresaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfUtenteImpresaequalthis", CfUtenteImpresaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "UtenteAttivoequalthis", UtenteAttivoEqualThis);
            VcruscottoDomandeConsulente VcruscottoDomandeConsulenteObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                VcruscottoDomandeConsulenteObj = GetFromDatareader(db);
                VcruscottoDomandeConsulenteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VcruscottoDomandeConsulenteObj.IsDirty = false;
                VcruscottoDomandeConsulenteObj.IsPersistent = true;
                VcruscottoDomandeConsulenteCollectionObj.Add(VcruscottoDomandeConsulenteObj);
            }
            db.Close();
            return VcruscottoDomandeConsulenteCollectionObj;
        }

        //Find FindProgettiConsulente

        public static VcruscottoDomandeConsulenteCollection FindProgettiConsulente(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.StringNT CodStatoProgettoEqualThis,
SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.IntNT IdUtenteEqualThis)

        {

            VcruscottoDomandeConsulenteCollection VcruscottoDomandeConsulenteCollectionObj = new VcruscottoDomandeConsulenteCollection();

            IDbCommand findCmd = db.InitCmd("Zvcruscottodomandeconsulentefindfindprogetticonsulente", new string[] {"IdBandoequalthis", "IdProgettoequalthis", "CodStatoProgettoequalthis",
"IdImpresaequalthis", "IdUtenteequalthis"}, new string[] {"int", "int", "string",
"int", "int"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodStatoProgettoequalthis", CodStatoProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdUtenteequalthis", IdUtenteEqualThis);
            VcruscottoDomandeConsulente VcruscottoDomandeConsulenteObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                VcruscottoDomandeConsulenteObj = GetFromDatareader(db);
                VcruscottoDomandeConsulenteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VcruscottoDomandeConsulenteObj.IsDirty = false;
                VcruscottoDomandeConsulenteObj.IsPersistent = true;
                VcruscottoDomandeConsulenteCollectionObj.Add(VcruscottoDomandeConsulenteObj);
            }
            db.Close();
            return VcruscottoDomandeConsulenteCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for VcruscottoDomandeConsulenteCollectionProvider:IVcruscottoDomandeConsulenteProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class VcruscottoDomandeConsulenteCollectionProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di VcruscottoDomandeConsulente
        protected VcruscottoDomandeConsulenteCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public VcruscottoDomandeConsulenteCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new VcruscottoDomandeConsulenteCollection();
        }

        //Costruttore 2: popola la collection
        public VcruscottoDomandeConsulenteCollectionProvider(IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis, StringNT CodstatoprogettoEqualThis,
IntNT IdimpresaEqualThis, IntNT IdutenteEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = FindProgettiConsulente(IdbandoEqualThis, IdprogettoEqualThis, CodstatoprogettoEqualThis,
IdimpresaEqualThis, IdutenteEqualThis);
        }

        //Costruttore3: ha in input vcruscottodomandeconsulenteCollectionObj - non popola la collection
        public VcruscottoDomandeConsulenteCollectionProvider(VcruscottoDomandeConsulenteCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public VcruscottoDomandeConsulenteCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new VcruscottoDomandeConsulenteCollection();
        }

        //Get e Set
        public VcruscottoDomandeConsulenteCollection CollectionObj
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

        //Select: popola la collection
        public VcruscottoDomandeConsulenteCollection Select(IntNT IdbandoEqualThis, StringNT DescrizionebandoEqualThis, DatetimeNT DatascadenzabandoEqualThis,
StringNT CodentebandoEqualThis, IntNT IdprogrammazionebandoEqualThis, IntNT IdprogettoEqualThis,
StringNT CodstatoprogettoEqualThis, StringNT StatoprogettoEqualThis, IntNT IdimpresaEqualThis,
StringNT RagionesocialeimpresaEqualThis, IntNT IdutenteEqualThis, StringNT NominativoutenteimpresaEqualThis,
StringNT CfutenteimpresaEqualThis, BoolNT UtenteattivoEqualThis)
        {
            VcruscottoDomandeConsulenteCollection VcruscottoDomandeConsulenteCollectionTemp = VcruscottoDomandeConsulenteDAL.Select(_dbProviderObj, IdbandoEqualThis, DescrizionebandoEqualThis, DatascadenzabandoEqualThis,
CodentebandoEqualThis, IdprogrammazionebandoEqualThis, IdprogettoEqualThis,
CodstatoprogettoEqualThis, StatoprogettoEqualThis, IdimpresaEqualThis,
RagionesocialeimpresaEqualThis, IdutenteEqualThis, NominativoutenteimpresaEqualThis,
CfutenteimpresaEqualThis, UtenteattivoEqualThis);
            return VcruscottoDomandeConsulenteCollectionTemp;
        }

        //FindProgettiConsulente: popola la collection
        public VcruscottoDomandeConsulenteCollection FindProgettiConsulente(IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis, StringNT CodstatoprogettoEqualThis,
IntNT IdimpresaEqualThis, IntNT IdutenteEqualThis)
        {
            VcruscottoDomandeConsulenteCollection VcruscottoDomandeConsulenteCollectionTemp = VcruscottoDomandeConsulenteDAL.FindProgettiConsulente(_dbProviderObj, IdbandoEqualThis, IdprogettoEqualThis, CodstatoprogettoEqualThis,
IdimpresaEqualThis, IdutenteEqualThis);
            return VcruscottoDomandeConsulenteCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<VCRUSCOTTO_DOMANDE_CONSULENTE>
  <ViewName>VCRUSCOTTO_DOMANDE_CONSULENTE</ViewName>
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
    <FindProgettiConsulente OrderBy="ORDER BY DATA_SCADENZA_BANDO ASC, ID_PROGETTO DESC, ID_IMPRESA">
      <ID_BANDO>Equal</ID_BANDO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <COD_STATO_PROGETTO>Equal</COD_STATO_PROGETTO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <ID_UTENTE>Equal</ID_UTENTE>
    </FindProgettiConsulente>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</VCRUSCOTTO_DOMANDE_CONSULENTE>
*/
