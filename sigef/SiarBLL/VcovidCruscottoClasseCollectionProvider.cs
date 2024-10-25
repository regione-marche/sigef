using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VcovidCruscottoClasse
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class VcovidCruscottoClasse: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdBando;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.IntNT _TotDefinitive;
		private NullTypes.IntNT _DefNonProtocollate;
		private NullTypes.IntNT _DefProtocollate;
		private NullTypes.IntNT _Provvisorie;


		//Costruttore
		public VcovidCruscottoClasse()
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
			set {
				if (IdBando != value)
				{
					_IdBando = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(2000)
		/// </summary>
		public NullTypes.StringNT Descrizione
		{
			get { return _Descrizione; }
			set {
				if (Descrizione != value)
				{
					_Descrizione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TOT_DEFINITIVE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT TotDefinitive
		{
			get { return _TotDefinitive; }
			set {
				if (TotDefinitive != value)
				{
					_TotDefinitive = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DEF_NON_PROTOCOLLATE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT DefNonProtocollate
		{
			get { return _DefNonProtocollate; }
			set {
				if (DefNonProtocollate != value)
				{
					_DefNonProtocollate = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DEF_PROTOCOLLATE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT DefProtocollate
		{
			get { return _DefProtocollate; }
			set {
				if (DefProtocollate != value)
				{
					_DefProtocollate = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PROVVISORIE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Provvisorie
		{
			get { return _Provvisorie; }
			set {
				if (Provvisorie != value)
				{
					_Provvisorie = value;
					SetDirtyFlag();
				}
			}
		}




	}
}

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VcovidCruscottoClasseCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VcovidCruscottoClasseCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private VcovidCruscottoClasseCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((VcovidCruscottoClasse) info.GetValue(i.ToString(),typeof(VcovidCruscottoClasse)));
			}
		}

		//Costruttore
		public VcovidCruscottoClasseCollection()
		{
			this.ItemType = typeof(VcovidCruscottoClasse);
		}

		//Get e Set
		public new VcovidCruscottoClasse this[int index]
		{
			get { return (VcovidCruscottoClasse)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VcovidCruscottoClasseCollection GetChanges()
		{
			return (VcovidCruscottoClasseCollection) base.GetChanges();
		}

		//Add
		public int Add(VcovidCruscottoClasse VcovidCruscottoClasseObj)
		{
			return base.Add(VcovidCruscottoClasseObj);
		}

		//AddCollection
		public void AddCollection(VcovidCruscottoClasseCollection VcovidCruscottoClasseCollectionObj)
		{
			foreach (VcovidCruscottoClasse VcovidCruscottoClasseObj in VcovidCruscottoClasseCollectionObj)
				this.Add(VcovidCruscottoClasseObj);
		}

		//Insert
		public void Insert(int index, VcovidCruscottoClasse VcovidCruscottoClasseObj)
		{
			base.Insert(index, VcovidCruscottoClasseObj);
		}

		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VcovidCruscottoClasseCollection SubSelect(NullTypes.IntNT IdBandoEqualThis, NullTypes.StringNT DescrizioneEqualThis, NullTypes.IntNT TotDefinitiveEqualThis, 
NullTypes.IntNT DefNonProtocollateEqualThis, NullTypes.IntNT DefProtocollateEqualThis, NullTypes.IntNT ProvvisorieEqualThis)
		{
			VcovidCruscottoClasseCollection VcovidCruscottoClasseCollectionTemp = new VcovidCruscottoClasseCollection();
			foreach (VcovidCruscottoClasse VcovidCruscottoClasseItem in this)
			{
				if (((IdBandoEqualThis == null) || ((VcovidCruscottoClasseItem.IdBando != null) && (VcovidCruscottoClasseItem.IdBando.Value == IdBandoEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((VcovidCruscottoClasseItem.Descrizione != null) && (VcovidCruscottoClasseItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((TotDefinitiveEqualThis == null) || ((VcovidCruscottoClasseItem.TotDefinitive != null) && (VcovidCruscottoClasseItem.TotDefinitive.Value == TotDefinitiveEqualThis.Value))) && 
((DefNonProtocollateEqualThis == null) || ((VcovidCruscottoClasseItem.DefNonProtocollate != null) && (VcovidCruscottoClasseItem.DefNonProtocollate.Value == DefNonProtocollateEqualThis.Value))) && ((DefProtocollateEqualThis == null) || ((VcovidCruscottoClasseItem.DefProtocollate != null) && (VcovidCruscottoClasseItem.DefProtocollate.Value == DefProtocollateEqualThis.Value))) && ((ProvvisorieEqualThis == null) || ((VcovidCruscottoClasseItem.Provvisorie != null) && (VcovidCruscottoClasseItem.Provvisorie.Value == ProvvisorieEqualThis.Value))))
				{
					VcovidCruscottoClasseCollectionTemp.Add(VcovidCruscottoClasseItem);
				}
			}
			return VcovidCruscottoClasseCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for VcovidCruscottoClasseDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class VcovidCruscottoClasseDAL
	{

		//Operazioni

		//getFromDatareader
		public static VcovidCruscottoClasse GetFromDatareader(DbProvider db)
		{
			VcovidCruscottoClasse VcovidCruscottoClasseObj = new VcovidCruscottoClasse();
			VcovidCruscottoClasseObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			VcovidCruscottoClasseObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			VcovidCruscottoClasseObj.TotDefinitive = new SiarLibrary.NullTypes.IntNT(db.DataReader["TOT_DEFINITIVE"]);
			VcovidCruscottoClasseObj.DefNonProtocollate = new SiarLibrary.NullTypes.IntNT(db.DataReader["DEF_NON_PROTOCOLLATE"]);
			VcovidCruscottoClasseObj.DefProtocollate = new SiarLibrary.NullTypes.IntNT(db.DataReader["DEF_PROTOCOLLATE"]);
			VcovidCruscottoClasseObj.Provvisorie = new SiarLibrary.NullTypes.IntNT(db.DataReader["PROVVISORIE"]);
			VcovidCruscottoClasseObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			VcovidCruscottoClasseObj.IsDirty = false;
			VcovidCruscottoClasseObj.IsPersistent = true;
			return VcovidCruscottoClasseObj;
		}

		//Find Select

		public static VcovidCruscottoClasseCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.IntNT TotDefinitiveEqualThis, 
SiarLibrary.NullTypes.IntNT DefNonProtocollateEqualThis, SiarLibrary.NullTypes.IntNT DefProtocollateEqualThis, SiarLibrary.NullTypes.IntNT ProvvisorieEqualThis)

		{

			VcovidCruscottoClasseCollection VcovidCruscottoClasseCollectionObj = new VcovidCruscottoClasseCollection();

			IDbCommand findCmd = db.InitCmd("Zvcovidcruscottoclassefindselect", new string[] {"IdBandoequalthis", "Descrizioneequalthis", "TotDefinitiveequalthis", 
"DefNonProtocollateequalthis", "DefProtocollateequalthis", "Provvisorieequalthis"}, new string[] {"int", "string", "int", 
"int", "int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TotDefinitiveequalthis", TotDefinitiveEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DefNonProtocollateequalthis", DefNonProtocollateEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DefProtocollateequalthis", DefProtocollateEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Provvisorieequalthis", ProvvisorieEqualThis);
			VcovidCruscottoClasse VcovidCruscottoClasseObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VcovidCruscottoClasseObj = GetFromDatareader(db);
				VcovidCruscottoClasseObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VcovidCruscottoClasseObj.IsDirty = false;
				VcovidCruscottoClasseObj.IsPersistent = true;
				VcovidCruscottoClasseCollectionObj.Add(VcovidCruscottoClasseObj);
			}
			db.Close();
			return VcovidCruscottoClasseCollectionObj;
		}

		//Find FindOrdinato

		public static VcovidCruscottoClasseCollection FindOrdinato(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.IntNT TotDefinitiveEqualThis, 
SiarLibrary.NullTypes.IntNT DefNonProtocollateEqualThis, SiarLibrary.NullTypes.IntNT DefProtocollateEqualThis, SiarLibrary.NullTypes.IntNT ProvvisorieEqualThis)

		{

			VcovidCruscottoClasseCollection VcovidCruscottoClasseCollectionObj = new VcovidCruscottoClasseCollection();

			IDbCommand findCmd = db.InitCmd("Zvcovidcruscottoclassefindfindordinato", new string[] {"IdBandoequalthis", "Descrizioneequalthis", "TotDefinitiveequalthis", 
"DefNonProtocollateequalthis", "DefProtocollateequalthis", "Provvisorieequalthis"}, new string[] {"int", "string", "int", 
"int", "int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TotDefinitiveequalthis", TotDefinitiveEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DefNonProtocollateequalthis", DefNonProtocollateEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DefProtocollateequalthis", DefProtocollateEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Provvisorieequalthis", ProvvisorieEqualThis);
			VcovidCruscottoClasse VcovidCruscottoClasseObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VcovidCruscottoClasseObj = GetFromDatareader(db);
				VcovidCruscottoClasseObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VcovidCruscottoClasseObj.IsDirty = false;
				VcovidCruscottoClasseObj.IsPersistent = true;
				VcovidCruscottoClasseCollectionObj.Add(VcovidCruscottoClasseObj);
			}
			db.Close();
			return VcovidCruscottoClasseCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for VcovidCruscottoClasseCollectionProvider:IVcovidCruscottoClasseProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VcovidCruscottoClasseCollectionProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di VcovidCruscottoClasse
		protected VcovidCruscottoClasseCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public VcovidCruscottoClasseCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new VcovidCruscottoClasseCollection();
		}

		//Costruttore 2: popola la collection
		public VcovidCruscottoClasseCollectionProvider(IntNT IdbandoEqualThis, StringNT DescrizioneEqualThis, IntNT TotdefinitiveEqualThis, 
IntNT DefnonprotocollateEqualThis, IntNT DefprotocollateEqualThis, IntNT ProvvisorieEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = FindOrdinato(IdbandoEqualThis, DescrizioneEqualThis, TotdefinitiveEqualThis, 
DefnonprotocollateEqualThis, DefprotocollateEqualThis, ProvvisorieEqualThis);
		}

		//Costruttore3: ha in input vcovidcruscottoclasseCollectionObj - non popola la collection
		public VcovidCruscottoClasseCollectionProvider(VcovidCruscottoClasseCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public VcovidCruscottoClasseCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new VcovidCruscottoClasseCollection();
		}

		//Get e Set
		public VcovidCruscottoClasseCollection CollectionObj
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
		public VcovidCruscottoClasseCollection Select(IntNT IdbandoEqualThis, StringNT DescrizioneEqualThis, IntNT TotdefinitiveEqualThis, 
IntNT DefnonprotocollateEqualThis, IntNT DefprotocollateEqualThis, IntNT ProvvisorieEqualThis)
		{
			VcovidCruscottoClasseCollection VcovidCruscottoClasseCollectionTemp = VcovidCruscottoClasseDAL.Select(_dbProviderObj, IdbandoEqualThis, DescrizioneEqualThis, TotdefinitiveEqualThis, 
DefnonprotocollateEqualThis, DefprotocollateEqualThis, ProvvisorieEqualThis);
			return VcovidCruscottoClasseCollectionTemp;
		}

		//FindOrdinato: popola la collection
		public VcovidCruscottoClasseCollection FindOrdinato(IntNT IdbandoEqualThis, StringNT DescrizioneEqualThis, IntNT TotdefinitiveEqualThis, 
IntNT DefnonprotocollateEqualThis, IntNT DefprotocollateEqualThis, IntNT ProvvisorieEqualThis)
		{
			VcovidCruscottoClasseCollection VcovidCruscottoClasseCollectionTemp = VcovidCruscottoClasseDAL.FindOrdinato(_dbProviderObj, IdbandoEqualThis, DescrizioneEqualThis, TotdefinitiveEqualThis, 
DefnonprotocollateEqualThis, DefprotocollateEqualThis, ProvvisorieEqualThis);
			return VcovidCruscottoClasseCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<vCOVID_CRUSCOTTO_CLASSE>
  <ViewName>vCOVID_CRUSCOTTO_CLASSE</ViewName>
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
    <FindOrdinato OrderBy="ORDER BY ID_BANDO">
      <ID_BANDO>Equal</ID_BANDO>
      <DESCRIZIONE>Equal</DESCRIZIONE>
      <TOT_DEFINITIVE>Equal</TOT_DEFINITIVE>
      <DEF_NON_PROTOCOLLATE>Equal</DEF_NON_PROTOCOLLATE>
      <DEF_PROTOCOLLATE>Equal</DEF_PROTOCOLLATE>
      <PROVVISORIE>Equal</PROVVISORIE>
    </FindOrdinato>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</vCOVID_CRUSCOTTO_CLASSE>
*/
