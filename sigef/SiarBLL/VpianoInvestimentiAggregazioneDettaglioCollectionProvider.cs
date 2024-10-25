using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    /// <summary>
    /// Summary description for VpianoInvestimentiAggregazioneDettaglio
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class VpianoInvestimentiAggregazioneDettaglio : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdProgetto;
        private NullTypes.IntNT _Id;
        private NullTypes.StringNT _Descrizioneriga;
        private NullTypes.DecimalNT _Costo;
        private NullTypes.DecimalNT _Contributo;
        private NullTypes.DecimalNT _ImpRichiestosum;
        private NullTypes.DecimalNT _ContrRichiestosum;
        private NullTypes.DecimalNT _ImpAmmessosum;
        private NullTypes.DecimalNT _ContrAmmessosum;
        private NullTypes.IntNT _Livello;
        private NullTypes.StringNT _Pathlabel;


        //Costruttore
        public VpianoInvestimentiAggregazioneDettaglio()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
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
        /// Corrisponde al campo:DescrizioneRiga
        /// Tipo sul db:VARCHAR(274)
        /// </summary>
        public NullTypes.StringNT Descrizioneriga
        {
            get { return _Descrizioneriga; }
            set
            {
                if (Descrizioneriga != value)
                {
                    _Descrizioneriga = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Costo
        /// Tipo sul db:DECIMAL(38,2)
        /// </summary>
        public NullTypes.DecimalNT Costo
        {
            get { return _Costo; }
            set
            {
                if (Costo != value)
                {
                    _Costo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Contributo
        /// Tipo sul db:DECIMAL(38,2)
        /// </summary>
        public NullTypes.DecimalNT Contributo
        {
            get { return _Contributo; }
            set
            {
                if (Contributo != value)
                {
                    _Contributo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:imp_richiestoSum
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImpRichiestosum
        {
            get { return _ImpRichiestosum; }
            set
            {
                if (ImpRichiestosum != value)
                {
                    _ImpRichiestosum = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:contr_richiestoSum
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ContrRichiestosum
        {
            get { return _ContrRichiestosum; }
            set
            {
                if (ContrRichiestosum != value)
                {
                    _ContrRichiestosum = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:imp_ammessoSum
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImpAmmessosum
        {
            get { return _ImpAmmessosum; }
            set
            {
                if (ImpAmmessosum != value)
                {
                    _ImpAmmessosum = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:contr_ammessoSum
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ContrAmmessosum
        {
            get { return _ContrAmmessosum; }
            set
            {
                if (ContrAmmessosum != value)
                {
                    _ContrAmmessosum = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Livello
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT Livello
        {
            get { return _Livello; }
            set
            {
                if (Livello != value)
                {
                    _Livello = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:PathLabel
        /// Tipo sul db:VARCHAR(-1)
        /// </summary>
        public NullTypes.StringNT Pathlabel
        {
            get { return _Pathlabel; }
            set
            {
                if (Pathlabel != value)
                {
                    _Pathlabel = value;
                    SetDirtyFlag();
                }
            }
        }




    }
}

namespace SiarLibrary
{

    /// <summary>
    /// Summary description for VpianoInvestimentiAggregazioneDettaglioCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class VpianoInvestimentiAggregazioneDettaglioCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private VpianoInvestimentiAggregazioneDettaglioCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((VpianoInvestimentiAggregazioneDettaglio)info.GetValue(i.ToString(), typeof(VpianoInvestimentiAggregazioneDettaglio)));
            }
        }

        //Costruttore
        public VpianoInvestimentiAggregazioneDettaglioCollection()
        {
            this.ItemType = typeof(VpianoInvestimentiAggregazioneDettaglio);
        }

        //Get e Set
        public new VpianoInvestimentiAggregazioneDettaglio this[int index]
        {
            get { return (VpianoInvestimentiAggregazioneDettaglio)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new VpianoInvestimentiAggregazioneDettaglioCollection GetChanges()
        {
            return (VpianoInvestimentiAggregazioneDettaglioCollection)base.GetChanges();
        }

        //Add
        public int Add(VpianoInvestimentiAggregazioneDettaglio VpianoInvestimentiAggregazioneDettaglioObj)
        {
            return base.Add(VpianoInvestimentiAggregazioneDettaglioObj);
        }

        //AddCollection
        public void AddCollection(VpianoInvestimentiAggregazioneDettaglioCollection VpianoInvestimentiAggregazioneDettaglioCollectionObj)
        {
            foreach (VpianoInvestimentiAggregazioneDettaglio VpianoInvestimentiAggregazioneDettaglioObj in VpianoInvestimentiAggregazioneDettaglioCollectionObj)
                this.Add(VpianoInvestimentiAggregazioneDettaglioObj);
        }

        //Insert
        public void Insert(int index, VpianoInvestimentiAggregazioneDettaglio VpianoInvestimentiAggregazioneDettaglioObj)
        {
            base.Insert(index, VpianoInvestimentiAggregazioneDettaglioObj);
        }

        //filter: effettua una ricerca all'interno della collection
        // se il parametro di ricerca è null, prende tutto,
        // anche i record che hanno quel campo null
        // altrimenti scarta i record che hanno quel campo null ...
        // ...e confronta gli altri
        public VpianoInvestimentiAggregazioneDettaglioCollection SubSelect(NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdEqualThis, NullTypes.StringNT DescrizionerigaEqualThis,
NullTypes.DecimalNT CostoEqualThis, NullTypes.DecimalNT ContributoEqualThis, NullTypes.DecimalNT ImpRichiestosumEqualThis,
NullTypes.DecimalNT ContrRichiestosumEqualThis, NullTypes.DecimalNT ImpAmmessosumEqualThis, NullTypes.DecimalNT ContrAmmessosumEqualThis,
NullTypes.IntNT LivelloEqualThis, NullTypes.StringNT PathlabelEqualThis)
        {
            VpianoInvestimentiAggregazioneDettaglioCollection VpianoInvestimentiAggregazioneDettaglioCollectionTemp = new VpianoInvestimentiAggregazioneDettaglioCollection();
            foreach (VpianoInvestimentiAggregazioneDettaglio VpianoInvestimentiAggregazioneDettaglioItem in this)
            {
                if (((IdProgettoEqualThis == null) || ((VpianoInvestimentiAggregazioneDettaglioItem.IdProgetto != null) && (VpianoInvestimentiAggregazioneDettaglioItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdEqualThis == null) || ((VpianoInvestimentiAggregazioneDettaglioItem.Id != null) && (VpianoInvestimentiAggregazioneDettaglioItem.Id.Value == IdEqualThis.Value))) && ((DescrizionerigaEqualThis == null) || ((VpianoInvestimentiAggregazioneDettaglioItem.Descrizioneriga != null) && (VpianoInvestimentiAggregazioneDettaglioItem.Descrizioneriga.Value == DescrizionerigaEqualThis.Value))) &&
((CostoEqualThis == null) || ((VpianoInvestimentiAggregazioneDettaglioItem.Costo != null) && (VpianoInvestimentiAggregazioneDettaglioItem.Costo.Value == CostoEqualThis.Value))) && ((ContributoEqualThis == null) || ((VpianoInvestimentiAggregazioneDettaglioItem.Contributo != null) && (VpianoInvestimentiAggregazioneDettaglioItem.Contributo.Value == ContributoEqualThis.Value))) && ((ImpRichiestosumEqualThis == null) || ((VpianoInvestimentiAggregazioneDettaglioItem.ImpRichiestosum != null) && (VpianoInvestimentiAggregazioneDettaglioItem.ImpRichiestosum.Value == ImpRichiestosumEqualThis.Value))) &&
((ContrRichiestosumEqualThis == null) || ((VpianoInvestimentiAggregazioneDettaglioItem.ContrRichiestosum != null) && (VpianoInvestimentiAggregazioneDettaglioItem.ContrRichiestosum.Value == ContrRichiestosumEqualThis.Value))) && ((ImpAmmessosumEqualThis == null) || ((VpianoInvestimentiAggregazioneDettaglioItem.ImpAmmessosum != null) && (VpianoInvestimentiAggregazioneDettaglioItem.ImpAmmessosum.Value == ImpAmmessosumEqualThis.Value))) && ((ContrAmmessosumEqualThis == null) || ((VpianoInvestimentiAggregazioneDettaglioItem.ContrAmmessosum != null) && (VpianoInvestimentiAggregazioneDettaglioItem.ContrAmmessosum.Value == ContrAmmessosumEqualThis.Value))) &&
((LivelloEqualThis == null) || ((VpianoInvestimentiAggregazioneDettaglioItem.Livello != null) && (VpianoInvestimentiAggregazioneDettaglioItem.Livello.Value == LivelloEqualThis.Value))) && ((PathlabelEqualThis == null) || ((VpianoInvestimentiAggregazioneDettaglioItem.Pathlabel != null) && (VpianoInvestimentiAggregazioneDettaglioItem.Pathlabel.Value == PathlabelEqualThis.Value))))
                {
                    VpianoInvestimentiAggregazioneDettaglioCollectionTemp.Add(VpianoInvestimentiAggregazioneDettaglioItem);
                }
            }
            return VpianoInvestimentiAggregazioneDettaglioCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for VpianoInvestimentiAggregazioneDettaglioDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class VpianoInvestimentiAggregazioneDettaglioDAL
    {

        //Operazioni

        //getFromDatareader
        public static VpianoInvestimentiAggregazioneDettaglio GetFromDatareader(DbProvider db)
        {
            VpianoInvestimentiAggregazioneDettaglio VpianoInvestimentiAggregazioneDettaglioObj = new VpianoInvestimentiAggregazioneDettaglio();
            VpianoInvestimentiAggregazioneDettaglioObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
            VpianoInvestimentiAggregazioneDettaglioObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
            VpianoInvestimentiAggregazioneDettaglioObj.Descrizioneriga = new SiarLibrary.NullTypes.StringNT(db.DataReader["DescrizioneRiga"]);
            VpianoInvestimentiAggregazioneDettaglioObj.Costo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["Costo"]);
            VpianoInvestimentiAggregazioneDettaglioObj.Contributo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["Contributo"]);
            VpianoInvestimentiAggregazioneDettaglioObj.ImpRichiestosum = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["imp_richiestoSum"]);
            VpianoInvestimentiAggregazioneDettaglioObj.ContrRichiestosum = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["contr_richiestoSum"]);
            VpianoInvestimentiAggregazioneDettaglioObj.ImpAmmessosum = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["imp_ammessoSum"]);
            VpianoInvestimentiAggregazioneDettaglioObj.ContrAmmessosum = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["contr_ammessoSum"]);
            VpianoInvestimentiAggregazioneDettaglioObj.Livello = new SiarLibrary.NullTypes.IntNT(db.DataReader["Livello"]);
            VpianoInvestimentiAggregazioneDettaglioObj.Pathlabel = new SiarLibrary.NullTypes.StringNT(db.DataReader["PathLabel"]);
            VpianoInvestimentiAggregazioneDettaglioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            VpianoInvestimentiAggregazioneDettaglioObj.IsDirty = false;
            VpianoInvestimentiAggregazioneDettaglioObj.IsPersistent = true;
            return VpianoInvestimentiAggregazioneDettaglioObj;
        }

        //Find Select

        public static VpianoInvestimentiAggregazioneDettaglioCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.StringNT DescrizionerigaEqualThis,
SiarLibrary.NullTypes.DecimalNT CostoEqualThis, SiarLibrary.NullTypes.DecimalNT ContributoEqualThis, SiarLibrary.NullTypes.DecimalNT ImpRichiestosumEqualThis,
SiarLibrary.NullTypes.DecimalNT ContrRichiestosumEqualThis, SiarLibrary.NullTypes.DecimalNT ImpAmmessosumEqualThis, SiarLibrary.NullTypes.DecimalNT ContrAmmessosumEqualThis,
SiarLibrary.NullTypes.IntNT LivelloEqualThis, SiarLibrary.NullTypes.StringNT PathlabelEqualThis)

        {

            VpianoInvestimentiAggregazioneDettaglioCollection VpianoInvestimentiAggregazioneDettaglioCollectionObj = new VpianoInvestimentiAggregazioneDettaglioCollection();

            IDbCommand findCmd = db.InitCmd("Zvpianoinvestimentiaggregazionedettagliofindselect", new string[] {"IdProgettoequalthis", "Idequalthis", "Descrizionerigaequalthis",
"Costoequalthis", "Contributoequalthis", "ImpRichiestosumequalthis",
"ContrRichiestosumequalthis", "ImpAmmessosumequalthis", "ContrAmmessosumequalthis",
"Livelloequalthis", "Pathlabelequalthis"}, new string[] {"int", "int", "string",
"decimal", "decimal", "decimal",
"decimal", "decimal", "decimal",
"int", "string"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Idequalthis", IdEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Descrizionerigaequalthis", DescrizionerigaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Costoequalthis", CostoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Contributoequalthis", ContributoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImpRichiestosumequalthis", ImpRichiestosumEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ContrRichiestosumequalthis", ContrRichiestosumEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImpAmmessosumequalthis", ImpAmmessosumEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ContrAmmessosumequalthis", ContrAmmessosumEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Livelloequalthis", LivelloEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Pathlabelequalthis", PathlabelEqualThis);
            VpianoInvestimentiAggregazioneDettaglio VpianoInvestimentiAggregazioneDettaglioObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                VpianoInvestimentiAggregazioneDettaglioObj = GetFromDatareader(db);
                VpianoInvestimentiAggregazioneDettaglioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VpianoInvestimentiAggregazioneDettaglioObj.IsDirty = false;
                VpianoInvestimentiAggregazioneDettaglioObj.IsPersistent = true;
                VpianoInvestimentiAggregazioneDettaglioCollectionObj.Add(VpianoInvestimentiAggregazioneDettaglioObj);
            }
            db.Close();
            return VpianoInvestimentiAggregazioneDettaglioCollectionObj;
        }

        //Find Find

        public static VpianoInvestimentiAggregazioneDettaglioCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis)

        {

            VpianoInvestimentiAggregazioneDettaglioCollection VpianoInvestimentiAggregazioneDettaglioCollectionObj = new VpianoInvestimentiAggregazioneDettaglioCollection();

            IDbCommand findCmd = db.InitCmd("Zvpianoinvestimentiaggregazionedettagliofindfind", new string[] { "IdProgettoequalthis" }, new string[] { "int" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            VpianoInvestimentiAggregazioneDettaglio VpianoInvestimentiAggregazioneDettaglioObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                VpianoInvestimentiAggregazioneDettaglioObj = GetFromDatareader(db);
                VpianoInvestimentiAggregazioneDettaglioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VpianoInvestimentiAggregazioneDettaglioObj.IsDirty = false;
                VpianoInvestimentiAggregazioneDettaglioObj.IsPersistent = true;
                VpianoInvestimentiAggregazioneDettaglioCollectionObj.Add(VpianoInvestimentiAggregazioneDettaglioObj);
            }
            db.Close();
            return VpianoInvestimentiAggregazioneDettaglioCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for VpianoInvestimentiAggregazioneDettaglioCollectionProvider:IVpianoInvestimentiAggregazioneDettaglioProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class VpianoInvestimentiAggregazioneDettaglioCollectionProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di VpianoInvestimentiAggregazioneDettaglio
        protected VpianoInvestimentiAggregazioneDettaglioCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public VpianoInvestimentiAggregazioneDettaglioCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new VpianoInvestimentiAggregazioneDettaglioCollection();
        }

        //Costruttore 2: popola la collection
        public VpianoInvestimentiAggregazioneDettaglioCollectionProvider(IntNT IdprogettoEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IdprogettoEqualThis);
        }

        //Costruttore3: ha in input vpianoinvestimentiaggregazionedettaglioCollectionObj - non popola la collection
        public VpianoInvestimentiAggregazioneDettaglioCollectionProvider(VpianoInvestimentiAggregazioneDettaglioCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public VpianoInvestimentiAggregazioneDettaglioCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new VpianoInvestimentiAggregazioneDettaglioCollection();
        }

        //Get e Set
        public VpianoInvestimentiAggregazioneDettaglioCollection CollectionObj
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
        public VpianoInvestimentiAggregazioneDettaglioCollection Select(IntNT IdprogettoEqualThis, IntNT IdEqualThis, StringNT DescrizionerigaEqualThis,
DecimalNT CostoEqualThis, DecimalNT ContributoEqualThis, DecimalNT ImprichiestosumEqualThis,
DecimalNT ContrrichiestosumEqualThis, DecimalNT ImpammessosumEqualThis, DecimalNT ContrammessosumEqualThis,
IntNT LivelloEqualThis, StringNT PathlabelEqualThis)
        {
            VpianoInvestimentiAggregazioneDettaglioCollection VpianoInvestimentiAggregazioneDettaglioCollectionTemp = VpianoInvestimentiAggregazioneDettaglioDAL.Select(_dbProviderObj, IdprogettoEqualThis, IdEqualThis, DescrizionerigaEqualThis,
CostoEqualThis, ContributoEqualThis, ImprichiestosumEqualThis,
ContrrichiestosumEqualThis, ImpammessosumEqualThis, ContrammessosumEqualThis,
LivelloEqualThis, PathlabelEqualThis);
            return VpianoInvestimentiAggregazioneDettaglioCollectionTemp;
        }

        //Find: popola la collection
        public VpianoInvestimentiAggregazioneDettaglioCollection Find(IntNT IdprogettoEqualThis)
        {
            VpianoInvestimentiAggregazioneDettaglioCollection VpianoInvestimentiAggregazioneDettaglioCollectionTemp = VpianoInvestimentiAggregazioneDettaglioDAL.Find(_dbProviderObj, IdprogettoEqualThis);
            return VpianoInvestimentiAggregazioneDettaglioCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<vPIANO_INVESTIMENTI_AGGREGAZIONE_DETTAGLIO>
  <ViewName>vPIANO_INVESTIMENTI_AGGREGAZIONE_DETTAGLIO</ViewName>
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
    <Find OrderBy="ORDER BY PathLabel">
      <ID_PROGETTO>Equal</ID_PROGETTO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</vPIANO_INVESTIMENTI_AGGREGAZIONE_DETTAGLIO>
*/
