using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    /// <summary>
    /// Summary description for VpianoInvestimentiCodifica
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class VpianoInvestimentiCodifica : BaseObject
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
        public VpianoInvestimentiCodifica()
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
        /// Tipo sul db:VARCHAR(2000)
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
    /// Summary description for VpianoInvestimentiCodificaCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class VpianoInvestimentiCodificaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private VpianoInvestimentiCodificaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((VpianoInvestimentiCodifica)info.GetValue(i.ToString(), typeof(VpianoInvestimentiCodifica)));
            }
        }

        //Costruttore
        public VpianoInvestimentiCodificaCollection()
        {
            this.ItemType = typeof(VpianoInvestimentiCodifica);
        }

        //Get e Set
        public new VpianoInvestimentiCodifica this[int index]
        {
            get { return (VpianoInvestimentiCodifica)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new VpianoInvestimentiCodificaCollection GetChanges()
        {
            return (VpianoInvestimentiCodificaCollection)base.GetChanges();
        }

        //Add
        public int Add(VpianoInvestimentiCodifica VpianoInvestimentiCodificaObj)
        {
            return base.Add(VpianoInvestimentiCodificaObj);
        }

        //AddCollection
        public void AddCollection(VpianoInvestimentiCodificaCollection VpianoInvestimentiCodificaCollectionObj)
        {
            foreach (VpianoInvestimentiCodifica VpianoInvestimentiCodificaObj in VpianoInvestimentiCodificaCollectionObj)
                this.Add(VpianoInvestimentiCodificaObj);
        }

        //Insert
        public void Insert(int index, VpianoInvestimentiCodifica VpianoInvestimentiCodificaObj)
        {
            base.Insert(index, VpianoInvestimentiCodificaObj);
        }

        //filter: effettua una ricerca all'interno della collection
        // se il parametro di ricerca è null, prende tutto,
        // anche i record che hanno quel campo null
        // altrimenti scarta i record che hanno quel campo null ...
        // ...e confronta gli altri
        public VpianoInvestimentiCodificaCollection SubSelect(NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdEqualThis, NullTypes.StringNT DescrizionerigaEqualThis,
NullTypes.DecimalNT CostoEqualThis, NullTypes.DecimalNT ContributoEqualThis, NullTypes.DecimalNT ImpRichiestosumEqualThis,
NullTypes.DecimalNT ContrRichiestosumEqualThis, NullTypes.DecimalNT ImpAmmessosumEqualThis, NullTypes.DecimalNT ContrAmmessosumEqualThis,
NullTypes.IntNT LivelloEqualThis, NullTypes.StringNT PathlabelEqualThis)
        {
            VpianoInvestimentiCodificaCollection VpianoInvestimentiCodificaCollectionTemp = new VpianoInvestimentiCodificaCollection();
            foreach (VpianoInvestimentiCodifica VpianoInvestimentiCodificaItem in this)
            {
                if (((IdProgettoEqualThis == null) || ((VpianoInvestimentiCodificaItem.IdProgetto != null) && (VpianoInvestimentiCodificaItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdEqualThis == null) || ((VpianoInvestimentiCodificaItem.Id != null) && (VpianoInvestimentiCodificaItem.Id.Value == IdEqualThis.Value))) && ((DescrizionerigaEqualThis == null) || ((VpianoInvestimentiCodificaItem.Descrizioneriga != null) && (VpianoInvestimentiCodificaItem.Descrizioneriga.Value == DescrizionerigaEqualThis.Value))) &&
((CostoEqualThis == null) || ((VpianoInvestimentiCodificaItem.Costo != null) && (VpianoInvestimentiCodificaItem.Costo.Value == CostoEqualThis.Value))) && ((ContributoEqualThis == null) || ((VpianoInvestimentiCodificaItem.Contributo != null) && (VpianoInvestimentiCodificaItem.Contributo.Value == ContributoEqualThis.Value))) && ((ImpRichiestosumEqualThis == null) || ((VpianoInvestimentiCodificaItem.ImpRichiestosum != null) && (VpianoInvestimentiCodificaItem.ImpRichiestosum.Value == ImpRichiestosumEqualThis.Value))) &&
((ContrRichiestosumEqualThis == null) || ((VpianoInvestimentiCodificaItem.ContrRichiestosum != null) && (VpianoInvestimentiCodificaItem.ContrRichiestosum.Value == ContrRichiestosumEqualThis.Value))) && ((ImpAmmessosumEqualThis == null) || ((VpianoInvestimentiCodificaItem.ImpAmmessosum != null) && (VpianoInvestimentiCodificaItem.ImpAmmessosum.Value == ImpAmmessosumEqualThis.Value))) && ((ContrAmmessosumEqualThis == null) || ((VpianoInvestimentiCodificaItem.ContrAmmessosum != null) && (VpianoInvestimentiCodificaItem.ContrAmmessosum.Value == ContrAmmessosumEqualThis.Value))) &&
((LivelloEqualThis == null) || ((VpianoInvestimentiCodificaItem.Livello != null) && (VpianoInvestimentiCodificaItem.Livello.Value == LivelloEqualThis.Value))) && ((PathlabelEqualThis == null) || ((VpianoInvestimentiCodificaItem.Pathlabel != null) && (VpianoInvestimentiCodificaItem.Pathlabel.Value == PathlabelEqualThis.Value))))
                {
                    VpianoInvestimentiCodificaCollectionTemp.Add(VpianoInvestimentiCodificaItem);
                }
            }
            return VpianoInvestimentiCodificaCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for VpianoInvestimentiCodificaDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class VpianoInvestimentiCodificaDAL
    {

        //Operazioni

        //getFromDatareader
        public static VpianoInvestimentiCodifica GetFromDatareader(DbProvider db)
        {
            VpianoInvestimentiCodifica VpianoInvestimentiCodificaObj = new VpianoInvestimentiCodifica();
            VpianoInvestimentiCodificaObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
            VpianoInvestimentiCodificaObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
            VpianoInvestimentiCodificaObj.Descrizioneriga = new SiarLibrary.NullTypes.StringNT(db.DataReader["DescrizioneRiga"]);
            VpianoInvestimentiCodificaObj.Costo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["Costo"]);
            VpianoInvestimentiCodificaObj.Contributo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["Contributo"]);
            VpianoInvestimentiCodificaObj.ImpRichiestosum = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["imp_richiestoSum"]);
            VpianoInvestimentiCodificaObj.ContrRichiestosum = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["contr_richiestoSum"]);
            VpianoInvestimentiCodificaObj.ImpAmmessosum = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["imp_ammessoSum"]);
            VpianoInvestimentiCodificaObj.ContrAmmessosum = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["contr_ammessoSum"]);
            VpianoInvestimentiCodificaObj.Livello = new SiarLibrary.NullTypes.IntNT(db.DataReader["Livello"]);
            VpianoInvestimentiCodificaObj.Pathlabel = new SiarLibrary.NullTypes.StringNT(db.DataReader["PathLabel"]);
            VpianoInvestimentiCodificaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            VpianoInvestimentiCodificaObj.IsDirty = false;
            VpianoInvestimentiCodificaObj.IsPersistent = true;
            return VpianoInvestimentiCodificaObj;
        }

        //Find Select

        public static VpianoInvestimentiCodificaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.StringNT DescrizionerigaEqualThis,
SiarLibrary.NullTypes.DecimalNT CostoEqualThis, SiarLibrary.NullTypes.DecimalNT ContributoEqualThis, SiarLibrary.NullTypes.DecimalNT ImpRichiestosumEqualThis,
SiarLibrary.NullTypes.DecimalNT ContrRichiestosumEqualThis, SiarLibrary.NullTypes.DecimalNT ImpAmmessosumEqualThis, SiarLibrary.NullTypes.DecimalNT ContrAmmessosumEqualThis,
SiarLibrary.NullTypes.IntNT LivelloEqualThis, SiarLibrary.NullTypes.StringNT PathlabelEqualThis)

        {

            VpianoInvestimentiCodificaCollection VpianoInvestimentiCodificaCollectionObj = new VpianoInvestimentiCodificaCollection();

            IDbCommand findCmd = db.InitCmd("Zvpianoinvestimenticodificafindselect", new string[] {"IdProgettoequalthis", "Idequalthis", "Descrizionerigaequalthis",
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
            VpianoInvestimentiCodifica VpianoInvestimentiCodificaObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                VpianoInvestimentiCodificaObj = GetFromDatareader(db);
                VpianoInvestimentiCodificaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VpianoInvestimentiCodificaObj.IsDirty = false;
                VpianoInvestimentiCodificaObj.IsPersistent = true;
                VpianoInvestimentiCodificaCollectionObj.Add(VpianoInvestimentiCodificaObj);
            }
            db.Close();
            return VpianoInvestimentiCodificaCollectionObj;
        }

        //Find Find

        public static VpianoInvestimentiCodificaCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis)

        {

            VpianoInvestimentiCodificaCollection VpianoInvestimentiCodificaCollectionObj = new VpianoInvestimentiCodificaCollection();

            IDbCommand findCmd = db.InitCmd("Zvpianoinvestimenticodificafindfind", new string[] { "IdProgettoequalthis" }, new string[] { "int" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            VpianoInvestimentiCodifica VpianoInvestimentiCodificaObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                VpianoInvestimentiCodificaObj = GetFromDatareader(db);
                VpianoInvestimentiCodificaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VpianoInvestimentiCodificaObj.IsDirty = false;
                VpianoInvestimentiCodificaObj.IsPersistent = true;
                VpianoInvestimentiCodificaCollectionObj.Add(VpianoInvestimentiCodificaObj);
            }
            db.Close();
            return VpianoInvestimentiCodificaCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for VpianoInvestimentiCodificaCollectionProvider:IVpianoInvestimentiCodificaProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class VpianoInvestimentiCodificaCollectionProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di VpianoInvestimentiCodifica
        protected VpianoInvestimentiCodificaCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public VpianoInvestimentiCodificaCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new VpianoInvestimentiCodificaCollection();
        }

        //Costruttore 2: popola la collection
        public VpianoInvestimentiCodificaCollectionProvider(IntNT IdprogettoEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IdprogettoEqualThis);
        }

        //Costruttore3: ha in input vpianoinvestimenticodificaCollectionObj - non popola la collection
        public VpianoInvestimentiCodificaCollectionProvider(VpianoInvestimentiCodificaCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public VpianoInvestimentiCodificaCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new VpianoInvestimentiCodificaCollection();
        }

        //Get e Set
        public VpianoInvestimentiCodificaCollection CollectionObj
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
        public VpianoInvestimentiCodificaCollection Select(IntNT IdprogettoEqualThis, IntNT IdEqualThis, StringNT DescrizionerigaEqualThis,
DecimalNT CostoEqualThis, DecimalNT ContributoEqualThis, DecimalNT ImprichiestosumEqualThis,
DecimalNT ContrrichiestosumEqualThis, DecimalNT ImpammessosumEqualThis, DecimalNT ContrammessosumEqualThis,
IntNT LivelloEqualThis, StringNT PathlabelEqualThis)
        {
            VpianoInvestimentiCodificaCollection VpianoInvestimentiCodificaCollectionTemp = VpianoInvestimentiCodificaDAL.Select(_dbProviderObj, IdprogettoEqualThis, IdEqualThis, DescrizionerigaEqualThis,
CostoEqualThis, ContributoEqualThis, ImprichiestosumEqualThis,
ContrrichiestosumEqualThis, ImpammessosumEqualThis, ContrammessosumEqualThis,
LivelloEqualThis, PathlabelEqualThis);
            return VpianoInvestimentiCodificaCollectionTemp;
        }

        //Find: popola la collection
        public VpianoInvestimentiCodificaCollection Find(IntNT IdprogettoEqualThis)
        {
            VpianoInvestimentiCodificaCollection VpianoInvestimentiCodificaCollectionTemp = VpianoInvestimentiCodificaDAL.Find(_dbProviderObj, IdprogettoEqualThis);
            return VpianoInvestimentiCodificaCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<vPIANO_INVESTIMENTI_CODIFICA>
  <ViewName>vPIANO_INVESTIMENTI_CODIFICA</ViewName>
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
</vPIANO_INVESTIMENTI_CODIFICA>
*/
