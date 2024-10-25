using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    /// <summary>
    /// Summary description for VelencoControlliLoco
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class VelencoControlliLoco : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdProgetto;
        private NullTypes.IntNT _IdDomandaPagamento;
        private NullTypes.IntNT _Idloco;
        private NullTypes.IntNT _IdlocoDettaglio;
        private NullTypes.StringNT _LocoDefinitivo;
        private NullTypes.DecimalNT _ImportoAmmessoLoco;
        private NullTypes.DecimalNT _ContributoAmmessoLoco;
        private NullTypes.StringNT _SelezionataControllo;
        private NullTypes.StringNT _EsitoChecklist;
        private NullTypes.DatetimeNT _DataSopralluogo;


        //Costruttore
        public VelencoControlliLoco()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:Id_Progetto
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
        /// Corrisponde al campo:Id_Domanda_Pagamento
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdDomandaPagamento
        {
            get { return _IdDomandaPagamento; }
            set
            {
                if (IdDomandaPagamento != value)
                {
                    _IdDomandaPagamento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IdLoco
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT Idloco
        {
            get { return _Idloco; }
            set
            {
                if (Idloco != value)
                {
                    _Idloco = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IdLoco_Dettaglio
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdlocoDettaglio
        {
            get { return _IdlocoDettaglio; }
            set
            {
                if (IdlocoDettaglio != value)
                {
                    _IdlocoDettaglio = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:LOCO_DEFINITIVO
        /// Tipo sul db:VARCHAR(2)
        /// </summary>
        public NullTypes.StringNT LocoDefinitivo
        {
            get { return _LocoDefinitivo; }
            set
            {
                if (LocoDefinitivo != value)
                {
                    _LocoDefinitivo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_AMMESSO_LOCO
        /// Tipo sul db:DECIMAL(38,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoAmmessoLoco
        {
            get { return _ImportoAmmessoLoco; }
            set
            {
                if (ImportoAmmessoLoco != value)
                {
                    _ImportoAmmessoLoco = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CONTRIBUTO_AMMESSO_LOCO
        /// Tipo sul db:DECIMAL(38,2)
        /// </summary>
        public NullTypes.DecimalNT ContributoAmmessoLoco
        {
            get { return _ContributoAmmessoLoco; }
            set
            {
                if (ContributoAmmessoLoco != value)
                {
                    _ContributoAmmessoLoco = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SELEZIONATA_CONTROLLO
        /// Tipo sul db:VARCHAR(2)
        /// </summary>
        public NullTypes.StringNT SelezionataControllo
        {
            get { return _SelezionataControllo; }
            set
            {
                if (SelezionataControllo != value)
                {
                    _SelezionataControllo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ESITO_CHECKLIST
        /// Tipo sul db:VARCHAR(21)
        /// </summary>
        public NullTypes.StringNT EsitoChecklist
        {
            get { return _EsitoChecklist; }
            set
            {
                if (EsitoChecklist != value)
                {
                    _EsitoChecklist = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_SOPRALLUOGO
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataSopralluogo
        {
            get { return _DataSopralluogo; }
            set
            {
                if (DataSopralluogo != value)
                {
                    _DataSopralluogo = value;
                    SetDirtyFlag();
                }
            }
        }




    }
}

namespace SiarLibrary
{

    /// <summary>
    /// Summary description for VelencoControlliLocoCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class VelencoControlliLocoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private VelencoControlliLocoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((VelencoControlliLoco)info.GetValue(i.ToString(), typeof(VelencoControlliLoco)));
            }
        }

        //Costruttore
        public VelencoControlliLocoCollection()
        {
            this.ItemType = typeof(VelencoControlliLoco);
        }

        //Get e Set
        public new VelencoControlliLoco this[int index]
        {
            get { return (VelencoControlliLoco)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new VelencoControlliLocoCollection GetChanges()
        {
            return (VelencoControlliLocoCollection)base.GetChanges();
        }

        //Add
        public int Add(VelencoControlliLoco VelencoControlliLocoObj)
        {
            return base.Add(VelencoControlliLocoObj);
        }

        //AddCollection
        public void AddCollection(VelencoControlliLocoCollection VelencoControlliLocoCollectionObj)
        {
            foreach (VelencoControlliLoco VelencoControlliLocoObj in VelencoControlliLocoCollectionObj)
                this.Add(VelencoControlliLocoObj);
        }

        //Insert
        public void Insert(int index, VelencoControlliLoco VelencoControlliLocoObj)
        {
            base.Insert(index, VelencoControlliLocoObj);
        }

        //filter: effettua una ricerca all'interno della collection
        // se il parametro di ricerca è null, prende tutto,
        // anche i record che hanno quel campo null
        // altrimenti scarta i record che hanno quel campo null ...
        // ...e confronta gli altri
        public VelencoControlliLocoCollection SubSelect(NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.IntNT IdlocoEqualThis,
NullTypes.IntNT IdlocoDettaglioEqualThis, NullTypes.StringNT LocoDefinitivoEqualThis, NullTypes.DecimalNT ImportoAmmessoLocoEqualThis,
NullTypes.DecimalNT ContributoAmmessoLocoEqualThis, NullTypes.StringNT SelezionataControlloEqualThis, NullTypes.StringNT EsitoChecklistEqualThis,
NullTypes.DatetimeNT DataSopralluogoEqualThis)
        {
            VelencoControlliLocoCollection VelencoControlliLocoCollectionTemp = new VelencoControlliLocoCollection();
            foreach (VelencoControlliLoco VelencoControlliLocoItem in this)
            {
                if (((IdProgettoEqualThis == null) || ((VelencoControlliLocoItem.IdProgetto != null) && (VelencoControlliLocoItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((VelencoControlliLocoItem.IdDomandaPagamento != null) && (VelencoControlliLocoItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((IdlocoEqualThis == null) || ((VelencoControlliLocoItem.Idloco != null) && (VelencoControlliLocoItem.Idloco.Value == IdlocoEqualThis.Value))) &&
((IdlocoDettaglioEqualThis == null) || ((VelencoControlliLocoItem.IdlocoDettaglio != null) && (VelencoControlliLocoItem.IdlocoDettaglio.Value == IdlocoDettaglioEqualThis.Value))) && ((LocoDefinitivoEqualThis == null) || ((VelencoControlliLocoItem.LocoDefinitivo != null) && (VelencoControlliLocoItem.LocoDefinitivo.Value == LocoDefinitivoEqualThis.Value))) && ((ImportoAmmessoLocoEqualThis == null) || ((VelencoControlliLocoItem.ImportoAmmessoLoco != null) && (VelencoControlliLocoItem.ImportoAmmessoLoco.Value == ImportoAmmessoLocoEqualThis.Value))) &&
((ContributoAmmessoLocoEqualThis == null) || ((VelencoControlliLocoItem.ContributoAmmessoLoco != null) && (VelencoControlliLocoItem.ContributoAmmessoLoco.Value == ContributoAmmessoLocoEqualThis.Value))) && ((SelezionataControlloEqualThis == null) || ((VelencoControlliLocoItem.SelezionataControllo != null) && (VelencoControlliLocoItem.SelezionataControllo.Value == SelezionataControlloEqualThis.Value))) && ((EsitoChecklistEqualThis == null) || ((VelencoControlliLocoItem.EsitoChecklist != null) && (VelencoControlliLocoItem.EsitoChecklist.Value == EsitoChecklistEqualThis.Value))) &&
((DataSopralluogoEqualThis == null) || ((VelencoControlliLocoItem.DataSopralluogo != null) && (VelencoControlliLocoItem.DataSopralluogo.Value == DataSopralluogoEqualThis.Value))))
                {
                    VelencoControlliLocoCollectionTemp.Add(VelencoControlliLocoItem);
                }
            }
            return VelencoControlliLocoCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for VelencoControlliLocoDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class VelencoControlliLocoDAL
    {

        //Operazioni

        //getFromDatareader
        public static VelencoControlliLoco GetFromDatareader(DbProvider db)
        {
            VelencoControlliLoco VelencoControlliLocoObj = new VelencoControlliLoco();
            VelencoControlliLocoObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["Id_Progetto"]);
            VelencoControlliLocoObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["Id_Domanda_Pagamento"]);
            VelencoControlliLocoObj.Idloco = new SiarLibrary.NullTypes.IntNT(db.DataReader["IdLoco"]);
            VelencoControlliLocoObj.IdlocoDettaglio = new SiarLibrary.NullTypes.IntNT(db.DataReader["IdLoco_Dettaglio"]);
            VelencoControlliLocoObj.LocoDefinitivo = new SiarLibrary.NullTypes.StringNT(db.DataReader["LOCO_DEFINITIVO"]);
            VelencoControlliLocoObj.ImportoAmmessoLoco = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_AMMESSO_LOCO"]);
            VelencoControlliLocoObj.ContributoAmmessoLoco = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_AMMESSO_LOCO"]);
            VelencoControlliLocoObj.SelezionataControllo = new SiarLibrary.NullTypes.StringNT(db.DataReader["SELEZIONATA_CONTROLLO"]);
            VelencoControlliLocoObj.EsitoChecklist = new SiarLibrary.NullTypes.StringNT(db.DataReader["ESITO_CHECKLIST"]);
            VelencoControlliLocoObj.DataSopralluogo = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_SOPRALLUOGO"]);
            VelencoControlliLocoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            VelencoControlliLocoObj.IsDirty = false;
            VelencoControlliLocoObj.IsPersistent = true;
            return VelencoControlliLocoObj;
        }

        //Find Select

        public static VelencoControlliLocoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdlocoEqualThis,
SiarLibrary.NullTypes.IntNT IdlocoDettaglioEqualThis, SiarLibrary.NullTypes.StringNT LocoDefinitivoEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoAmmessoLocoEqualThis,
SiarLibrary.NullTypes.DecimalNT ContributoAmmessoLocoEqualThis, SiarLibrary.NullTypes.StringNT SelezionataControlloEqualThis, SiarLibrary.NullTypes.StringNT EsitoChecklistEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataSopralluogoEqualThis)

        {

            VelencoControlliLocoCollection VelencoControlliLocoCollectionObj = new VelencoControlliLocoCollection();

            IDbCommand findCmd = db.InitCmd("Zvelencocontrollilocofindselect", new string[] {"IdProgettoequalthis", "IdDomandaPagamentoequalthis", "Idlocoequalthis",
"IdlocoDettaglioequalthis", "LocoDefinitivoequalthis", "ImportoAmmessoLocoequalthis",
"ContributoAmmessoLocoequalthis", "SelezionataControlloequalthis", "EsitoChecklistequalthis",
"DataSopralluogoequalthis"}, new string[] {"int", "int", "int",
"int", "string", "decimal",
"decimal", "string", "string",
"DateTime"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Idlocoequalthis", IdlocoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdlocoDettaglioequalthis", IdlocoDettaglioEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "LocoDefinitivoequalthis", LocoDefinitivoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoAmmessoLocoequalthis", ImportoAmmessoLocoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ContributoAmmessoLocoequalthis", ContributoAmmessoLocoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SelezionataControlloequalthis", SelezionataControlloEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "EsitoChecklistequalthis", EsitoChecklistEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataSopralluogoequalthis", DataSopralluogoEqualThis);
            VelencoControlliLoco VelencoControlliLocoObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                VelencoControlliLocoObj = GetFromDatareader(db);
                VelencoControlliLocoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VelencoControlliLocoObj.IsDirty = false;
                VelencoControlliLocoObj.IsPersistent = true;
                VelencoControlliLocoCollectionObj.Add(VelencoControlliLocoObj);
            }
            db.Close();
            return VelencoControlliLocoCollectionObj;
        }

        //Find FindGestioneLavori

        public static VelencoControlliLocoCollection FindGestioneLavori(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.StringNT LocoDefinitivoEqualThis,
SiarLibrary.NullTypes.StringNT SelezionataControlloEqualThis)

        {

            VelencoControlliLocoCollection VelencoControlliLocoCollectionObj = new VelencoControlliLocoCollection();

            IDbCommand findCmd = db.InitCmd("Zvelencocontrollilocofindfindgestionelavori", new string[] {"IdProgettoequalthis", "IdDomandaPagamentoequalthis", "LocoDefinitivoequalthis",
"SelezionataControlloequalthis"}, new string[] {"int", "int", "string",
"string"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "LocoDefinitivoequalthis", LocoDefinitivoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SelezionataControlloequalthis", SelezionataControlloEqualThis);
            VelencoControlliLoco VelencoControlliLocoObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                VelencoControlliLocoObj = GetFromDatareader(db);
                VelencoControlliLocoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VelencoControlliLocoObj.IsDirty = false;
                VelencoControlliLocoObj.IsPersistent = true;
                VelencoControlliLocoCollectionObj.Add(VelencoControlliLocoObj);
            }
            db.Close();
            return VelencoControlliLocoCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for VelencoControlliLocoCollectionProvider:IVelencoControlliLocoProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class VelencoControlliLocoCollectionProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di VelencoControlliLoco
        protected VelencoControlliLocoCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public VelencoControlliLocoCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new VelencoControlliLocoCollection();
        }

        //Costruttore 2: popola la collection
        public VelencoControlliLocoCollectionProvider(IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis, StringNT LocodefinitivoEqualThis,
StringNT SelezionatacontrolloEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = FindGestioneLavori(IdprogettoEqualThis, IddomandapagamentoEqualThis, LocodefinitivoEqualThis,
SelezionatacontrolloEqualThis);
        }

        //Costruttore3: ha in input velencocontrollilocoCollectionObj - non popola la collection
        public VelencoControlliLocoCollectionProvider(VelencoControlliLocoCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public VelencoControlliLocoCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new VelencoControlliLocoCollection();
        }

        //Get e Set
        public VelencoControlliLocoCollection CollectionObj
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
        public VelencoControlliLocoCollection Select(IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdlocoEqualThis,
IntNT IdlocodettaglioEqualThis, StringNT LocodefinitivoEqualThis, DecimalNT ImportoammessolocoEqualThis,
DecimalNT ContributoammessolocoEqualThis, StringNT SelezionatacontrolloEqualThis, StringNT EsitochecklistEqualThis,
DatetimeNT DatasopralluogoEqualThis)
        {
            VelencoControlliLocoCollection VelencoControlliLocoCollectionTemp = VelencoControlliLocoDAL.Select(_dbProviderObj, IdprogettoEqualThis, IddomandapagamentoEqualThis, IdlocoEqualThis,
IdlocodettaglioEqualThis, LocodefinitivoEqualThis, ImportoammessolocoEqualThis,
ContributoammessolocoEqualThis, SelezionatacontrolloEqualThis, EsitochecklistEqualThis,
DatasopralluogoEqualThis);
            return VelencoControlliLocoCollectionTemp;
        }

        //FindGestioneLavori: popola la collection
        public VelencoControlliLocoCollection FindGestioneLavori(IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis, StringNT LocodefinitivoEqualThis,
StringNT SelezionatacontrolloEqualThis)
        {
            VelencoControlliLocoCollection VelencoControlliLocoCollectionTemp = VelencoControlliLocoDAL.FindGestioneLavori(_dbProviderObj, IdprogettoEqualThis, IddomandapagamentoEqualThis, LocodefinitivoEqualThis,
SelezionatacontrolloEqualThis);
            return VelencoControlliLocoCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<VELENCO_CONTROLLI_LOCO>
  <ViewName>VELENCO_CONTROLLI_LOCO</ViewName>
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
    <FindGestioneLavori OrderBy="ORDER BY Id_Progetto, Id_Domanda_Pagamento, IdLoco, IdLoco_Dettaglio">
      <Id_Progetto>Equal</Id_Progetto>
      <Id_Domanda_Pagamento>Equal</Id_Domanda_Pagamento>
      <LOCO_DEFINITIVO>Equal</LOCO_DEFINITIVO>
      <SELEZIONATA_CONTROLLO>Equal</SELEZIONATA_CONTROLLO>
    </FindGestioneLavori>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</VELENCO_CONTROLLI_LOCO>
*/
