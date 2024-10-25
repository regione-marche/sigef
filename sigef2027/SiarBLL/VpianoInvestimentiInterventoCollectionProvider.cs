using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VpianoInvestimentiIntervento
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class VpianoInvestimentiIntervento: BaseObject
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
		public VpianoInvestimentiIntervento()
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
			set {
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
			set {
				if (Id != value)
				{
					_Id = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DescrizioneRiga
		/// Tipo sul db:VARCHAR(2034)
		/// </summary>
		public NullTypes.StringNT Descrizioneriga
		{
			get { return _Descrizioneriga; }
			set {
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
			set {
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
			set {
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
			set {
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
			set {
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
			set {
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
			set {
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
			set {
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
			set {
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
	/// Summary description for VpianoInvestimentiInterventoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VpianoInvestimentiInterventoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
	{

		//Serializzazione xml
		public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
		{
			info.AddValue("_count",this.Count);
			for(int i=0;i<this.Count;i++)
			{
				info.AddValue(i.ToString(),this[i]);
			}
		}
		private VpianoInvestimentiInterventoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((VpianoInvestimentiIntervento) info.GetValue(i.ToString(),typeof(VpianoInvestimentiIntervento)));
			}
		}

		//Costruttore
		public VpianoInvestimentiInterventoCollection()
		{
			this.ItemType = typeof(VpianoInvestimentiIntervento);
		}

		//Get e Set
		public new VpianoInvestimentiIntervento this[int index]
		{
			get { return (VpianoInvestimentiIntervento)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VpianoInvestimentiInterventoCollection GetChanges()
		{
			return (VpianoInvestimentiInterventoCollection) base.GetChanges();
		}

		//Add
		public int Add(VpianoInvestimentiIntervento VpianoInvestimentiInterventoObj)
		{
			return base.Add(VpianoInvestimentiInterventoObj);
		}

		//AddCollection
		public void AddCollection(VpianoInvestimentiInterventoCollection VpianoInvestimentiInterventoCollectionObj)
		{
			foreach (VpianoInvestimentiIntervento VpianoInvestimentiInterventoObj in VpianoInvestimentiInterventoCollectionObj)
				this.Add(VpianoInvestimentiInterventoObj);
		}

		//Insert
		public void Insert(int index, VpianoInvestimentiIntervento VpianoInvestimentiInterventoObj)
		{
			base.Insert(index, VpianoInvestimentiInterventoObj);
		}

		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VpianoInvestimentiInterventoCollection SubSelect(NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdEqualThis, NullTypes.StringNT DescrizionerigaEqualThis, 
NullTypes.DecimalNT CostoEqualThis, NullTypes.DecimalNT ContributoEqualThis, NullTypes.DecimalNT ImpRichiestosumEqualThis, 
NullTypes.DecimalNT ContrRichiestosumEqualThis, NullTypes.DecimalNT ImpAmmessosumEqualThis, NullTypes.DecimalNT ContrAmmessosumEqualThis, 
NullTypes.IntNT LivelloEqualThis, NullTypes.StringNT PathlabelEqualThis)
		{
			VpianoInvestimentiInterventoCollection VpianoInvestimentiInterventoCollectionTemp = new VpianoInvestimentiInterventoCollection();
			foreach (VpianoInvestimentiIntervento VpianoInvestimentiInterventoItem in this)
			{
				if (((IdProgettoEqualThis == null) || ((VpianoInvestimentiInterventoItem.IdProgetto != null) && (VpianoInvestimentiInterventoItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdEqualThis == null) || ((VpianoInvestimentiInterventoItem.Id != null) && (VpianoInvestimentiInterventoItem.Id.Value == IdEqualThis.Value))) && ((DescrizionerigaEqualThis == null) || ((VpianoInvestimentiInterventoItem.Descrizioneriga != null) && (VpianoInvestimentiInterventoItem.Descrizioneriga.Value == DescrizionerigaEqualThis.Value))) && 
((CostoEqualThis == null) || ((VpianoInvestimentiInterventoItem.Costo != null) && (VpianoInvestimentiInterventoItem.Costo.Value == CostoEqualThis.Value))) && ((ContributoEqualThis == null) || ((VpianoInvestimentiInterventoItem.Contributo != null) && (VpianoInvestimentiInterventoItem.Contributo.Value == ContributoEqualThis.Value))) && ((ImpRichiestosumEqualThis == null) || ((VpianoInvestimentiInterventoItem.ImpRichiestosum != null) && (VpianoInvestimentiInterventoItem.ImpRichiestosum.Value == ImpRichiestosumEqualThis.Value))) && 
((ContrRichiestosumEqualThis == null) || ((VpianoInvestimentiInterventoItem.ContrRichiestosum != null) && (VpianoInvestimentiInterventoItem.ContrRichiestosum.Value == ContrRichiestosumEqualThis.Value))) && ((ImpAmmessosumEqualThis == null) || ((VpianoInvestimentiInterventoItem.ImpAmmessosum != null) && (VpianoInvestimentiInterventoItem.ImpAmmessosum.Value == ImpAmmessosumEqualThis.Value))) && ((ContrAmmessosumEqualThis == null) || ((VpianoInvestimentiInterventoItem.ContrAmmessosum != null) && (VpianoInvestimentiInterventoItem.ContrAmmessosum.Value == ContrAmmessosumEqualThis.Value))) && 
((LivelloEqualThis == null) || ((VpianoInvestimentiInterventoItem.Livello != null) && (VpianoInvestimentiInterventoItem.Livello.Value == LivelloEqualThis.Value))) && ((PathlabelEqualThis == null) || ((VpianoInvestimentiInterventoItem.Pathlabel != null) && (VpianoInvestimentiInterventoItem.Pathlabel.Value == PathlabelEqualThis.Value))))
				{
					VpianoInvestimentiInterventoCollectionTemp.Add(VpianoInvestimentiInterventoItem);
				}
			}
			return VpianoInvestimentiInterventoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for VpianoInvestimentiInterventoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class VpianoInvestimentiInterventoDAL
	{

		//Operazioni

		//getFromDatareader
		public static VpianoInvestimentiIntervento GetFromDatareader(DbProvider db)
		{
			VpianoInvestimentiIntervento VpianoInvestimentiInterventoObj = new VpianoInvestimentiIntervento();
			VpianoInvestimentiInterventoObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			VpianoInvestimentiInterventoObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			VpianoInvestimentiInterventoObj.Descrizioneriga = new SiarLibrary.NullTypes.StringNT(db.DataReader["DescrizioneRiga"]);
			VpianoInvestimentiInterventoObj.Costo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["Costo"]);
			VpianoInvestimentiInterventoObj.Contributo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["Contributo"]);
			VpianoInvestimentiInterventoObj.ImpRichiestosum = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["imp_richiestoSum"]);
			VpianoInvestimentiInterventoObj.ContrRichiestosum = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["contr_richiestoSum"]);
			VpianoInvestimentiInterventoObj.ImpAmmessosum = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["imp_ammessoSum"]);
			VpianoInvestimentiInterventoObj.ContrAmmessosum = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["contr_ammessoSum"]);
			VpianoInvestimentiInterventoObj.Livello = new SiarLibrary.NullTypes.IntNT(db.DataReader["Livello"]);
			VpianoInvestimentiInterventoObj.Pathlabel = new SiarLibrary.NullTypes.StringNT(db.DataReader["PathLabel"]);
			VpianoInvestimentiInterventoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			VpianoInvestimentiInterventoObj.IsDirty = false;
			VpianoInvestimentiInterventoObj.IsPersistent = true;
			return VpianoInvestimentiInterventoObj;
		}

		//Find Select

		public static VpianoInvestimentiInterventoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.StringNT DescrizionerigaEqualThis, 
SiarLibrary.NullTypes.DecimalNT CostoEqualThis, SiarLibrary.NullTypes.DecimalNT ContributoEqualThis, SiarLibrary.NullTypes.DecimalNT ImpRichiestosumEqualThis, 
SiarLibrary.NullTypes.DecimalNT ContrRichiestosumEqualThis, SiarLibrary.NullTypes.DecimalNT ImpAmmessosumEqualThis, SiarLibrary.NullTypes.DecimalNT ContrAmmessosumEqualThis, 
SiarLibrary.NullTypes.IntNT LivelloEqualThis, SiarLibrary.NullTypes.StringNT PathlabelEqualThis)

		{

			VpianoInvestimentiInterventoCollection VpianoInvestimentiInterventoCollectionObj = new VpianoInvestimentiInterventoCollection();

			IDbCommand findCmd = db.InitCmd("Zvpianoinvestimentiinterventofindselect", new string[] {"IdProgettoequalthis", "Idequalthis", "Descrizionerigaequalthis", 
"Costoequalthis", "Contributoequalthis", "ImpRichiestosumequalthis", 
"ContrRichiestosumequalthis", "ImpAmmessosumequalthis", "ContrAmmessosumequalthis", 
"Livelloequalthis", "Pathlabelequalthis"}, new string[] {"int", "int", "string", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizionerigaequalthis", DescrizionerigaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Costoequalthis", CostoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Contributoequalthis", ContributoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImpRichiestosumequalthis", ImpRichiestosumEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ContrRichiestosumequalthis", ContrRichiestosumEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImpAmmessosumequalthis", ImpAmmessosumEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ContrAmmessosumequalthis", ContrAmmessosumEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Livelloequalthis", LivelloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Pathlabelequalthis", PathlabelEqualThis);
			VpianoInvestimentiIntervento VpianoInvestimentiInterventoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VpianoInvestimentiInterventoObj = GetFromDatareader(db);
				VpianoInvestimentiInterventoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VpianoInvestimentiInterventoObj.IsDirty = false;
				VpianoInvestimentiInterventoObj.IsPersistent = true;
				VpianoInvestimentiInterventoCollectionObj.Add(VpianoInvestimentiInterventoObj);
			}
			db.Close();
			return VpianoInvestimentiInterventoCollectionObj;
		}

		//Find Find

		public static VpianoInvestimentiInterventoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis)

		{

			VpianoInvestimentiInterventoCollection VpianoInvestimentiInterventoCollectionObj = new VpianoInvestimentiInterventoCollection();

			IDbCommand findCmd = db.InitCmd("Zvpianoinvestimentiinterventofindfind", new string[] {"IdProgettoequalthis"}, new string[] {"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			VpianoInvestimentiIntervento VpianoInvestimentiInterventoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VpianoInvestimentiInterventoObj = GetFromDatareader(db);
				VpianoInvestimentiInterventoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VpianoInvestimentiInterventoObj.IsDirty = false;
				VpianoInvestimentiInterventoObj.IsPersistent = true;
				VpianoInvestimentiInterventoCollectionObj.Add(VpianoInvestimentiInterventoObj);
			}
			db.Close();
			return VpianoInvestimentiInterventoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for VpianoInvestimentiInterventoCollectionProvider:IVpianoInvestimentiInterventoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VpianoInvestimentiInterventoCollectionProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di VpianoInvestimentiIntervento
		protected VpianoInvestimentiInterventoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public VpianoInvestimentiInterventoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new VpianoInvestimentiInterventoCollection();
		}

		//Costruttore 2: popola la collection
		public VpianoInvestimentiInterventoCollectionProvider(IntNT IdprogettoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdprogettoEqualThis);
		}

		//Costruttore3: ha in input vpianoinvestimentiinterventoCollectionObj - non popola la collection
		public VpianoInvestimentiInterventoCollectionProvider(VpianoInvestimentiInterventoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public VpianoInvestimentiInterventoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new VpianoInvestimentiInterventoCollection();
		}

		//Get e Set
		public VpianoInvestimentiInterventoCollection CollectionObj
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
		public VpianoInvestimentiInterventoCollection Select(IntNT IdprogettoEqualThis, IntNT IdEqualThis, StringNT DescrizionerigaEqualThis, 
DecimalNT CostoEqualThis, DecimalNT ContributoEqualThis, DecimalNT ImprichiestosumEqualThis, 
DecimalNT ContrrichiestosumEqualThis, DecimalNT ImpammessosumEqualThis, DecimalNT ContrammessosumEqualThis, 
IntNT LivelloEqualThis, StringNT PathlabelEqualThis)
		{
			VpianoInvestimentiInterventoCollection VpianoInvestimentiInterventoCollectionTemp = VpianoInvestimentiInterventoDAL.Select(_dbProviderObj, IdprogettoEqualThis, IdEqualThis, DescrizionerigaEqualThis, 
CostoEqualThis, ContributoEqualThis, ImprichiestosumEqualThis, 
ContrrichiestosumEqualThis, ImpammessosumEqualThis, ContrammessosumEqualThis, 
LivelloEqualThis, PathlabelEqualThis);
			return VpianoInvestimentiInterventoCollectionTemp;
		}

		//Find: popola la collection
		public VpianoInvestimentiInterventoCollection Find(IntNT IdprogettoEqualThis)
		{
			VpianoInvestimentiInterventoCollection VpianoInvestimentiInterventoCollectionTemp = VpianoInvestimentiInterventoDAL.Find(_dbProviderObj, IdprogettoEqualThis);
			return VpianoInvestimentiInterventoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<vPIANO_INVESTIMENTI_INTERVENTO>
  <ViewName>vPIANO_INVESTIMENTI_INTERVENTO</ViewName>
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
</vPIANO_INVESTIMENTI_INTERVENTO>
*/
