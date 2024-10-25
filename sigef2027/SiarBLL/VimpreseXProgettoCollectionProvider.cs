using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VimpreseXProgetto
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class VimpreseXProgetto: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.StringNT _Cuaa;
		private NullTypes.StringNT _CodiceFiscale;
		private NullTypes.StringNT _RagioneSociale;


		//Costruttore
		public VimpreseXProgetto()
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
		/// Corrisponde al campo:ID_IMPRESA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdImpresa
		{
			get { return _IdImpresa; }
			set {
				if (IdImpresa != value)
				{
					_IdImpresa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CUAA
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT Cuaa
		{
			get { return _Cuaa; }
			set {
				if (Cuaa != value)
				{
					_Cuaa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE_FISCALE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CodiceFiscale
		{
			get { return _CodiceFiscale; }
			set {
				if (CodiceFiscale != value)
				{
					_CodiceFiscale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RAGIONE_SOCIALE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT RagioneSociale
		{
			get { return _RagioneSociale; }
			set {
				if (RagioneSociale != value)
				{
					_RagioneSociale = value;
					SetDirtyFlag();
				}
			}
		}




	}
}

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VimpreseXProgettoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VimpreseXProgettoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private VimpreseXProgettoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((VimpreseXProgetto) info.GetValue(i.ToString(),typeof(VimpreseXProgetto)));
			}
		}

		//Costruttore
		public VimpreseXProgettoCollection()
		{
			this.ItemType = typeof(VimpreseXProgetto);
		}

		//Get e Set
		public new VimpreseXProgetto this[int index]
		{
			get { return (VimpreseXProgetto)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VimpreseXProgettoCollection GetChanges()
		{
			return (VimpreseXProgettoCollection) base.GetChanges();
		}

		//Add
		public int Add(VimpreseXProgetto VimpreseXProgettoObj)
		{
			return base.Add(VimpreseXProgettoObj);
		}

		//AddCollection
		public void AddCollection(VimpreseXProgettoCollection VimpreseXProgettoCollectionObj)
		{
			foreach (VimpreseXProgetto VimpreseXProgettoObj in VimpreseXProgettoCollectionObj)
				this.Add(VimpreseXProgettoObj);
		}

		//Insert
		public void Insert(int index, VimpreseXProgetto VimpreseXProgettoObj)
		{
			base.Insert(index, VimpreseXProgettoObj);
		}

		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VimpreseXProgettoCollection SubSelect(NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdImpresaEqualThis, NullTypes.StringNT CuaaEqualThis, 
NullTypes.StringNT CodiceFiscaleEqualThis, NullTypes.StringNT RagioneSocialeEqualThis)
		{
			VimpreseXProgettoCollection VimpreseXProgettoCollectionTemp = new VimpreseXProgettoCollection();
			foreach (VimpreseXProgetto VimpreseXProgettoItem in this)
			{
				if (((IdProgettoEqualThis == null) || ((VimpreseXProgettoItem.IdProgetto != null) && (VimpreseXProgettoItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((VimpreseXProgettoItem.IdImpresa != null) && (VimpreseXProgettoItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((CuaaEqualThis == null) || ((VimpreseXProgettoItem.Cuaa != null) && (VimpreseXProgettoItem.Cuaa.Value == CuaaEqualThis.Value))) && 
((CodiceFiscaleEqualThis == null) || ((VimpreseXProgettoItem.CodiceFiscale != null) && (VimpreseXProgettoItem.CodiceFiscale.Value == CodiceFiscaleEqualThis.Value))) && ((RagioneSocialeEqualThis == null) || ((VimpreseXProgettoItem.RagioneSociale != null) && (VimpreseXProgettoItem.RagioneSociale.Value == RagioneSocialeEqualThis.Value))))
				{
					VimpreseXProgettoCollectionTemp.Add(VimpreseXProgettoItem);
				}
			}
			return VimpreseXProgettoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for VimpreseXProgettoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class VimpreseXProgettoDAL
	{

		//Operazioni

		//getFromDatareader
		public static VimpreseXProgetto GetFromDatareader(DbProvider db)
		{
			VimpreseXProgetto VimpreseXProgettoObj = new VimpreseXProgetto();
			VimpreseXProgettoObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			VimpreseXProgettoObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			VimpreseXProgettoObj.Cuaa = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUAA"]);
			VimpreseXProgettoObj.CodiceFiscale = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_FISCALE"]);
			VimpreseXProgettoObj.RagioneSociale = new SiarLibrary.NullTypes.StringNT(db.DataReader["RAGIONE_SOCIALE"]);
			VimpreseXProgettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			VimpreseXProgettoObj.IsDirty = false;
			VimpreseXProgettoObj.IsPersistent = true;
			return VimpreseXProgettoObj;
		}

		//Find Select

		public static VimpreseXProgettoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.StringNT CuaaEqualThis, 
SiarLibrary.NullTypes.StringNT CodiceFiscaleEqualThis, SiarLibrary.NullTypes.StringNT RagioneSocialeEqualThis)

		{

			VimpreseXProgettoCollection VimpreseXProgettoCollectionObj = new VimpreseXProgettoCollection();

			IDbCommand findCmd = db.InitCmd("Zvimpresexprogettofindselect", new string[] {"IdProgettoequalthis", "IdImpresaequalthis", "Cuaaequalthis", 
"CodiceFiscaleequalthis", "RagioneSocialeequalthis"}, new string[] {"int", "int", "string", 
"string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Cuaaequalthis", CuaaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceFiscaleequalthis", CodiceFiscaleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RagioneSocialeequalthis", RagioneSocialeEqualThis);
			VimpreseXProgetto VimpreseXProgettoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VimpreseXProgettoObj = GetFromDatareader(db);
				VimpreseXProgettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VimpreseXProgettoObj.IsDirty = false;
				VimpreseXProgettoObj.IsPersistent = true;
				VimpreseXProgettoCollectionObj.Add(VimpreseXProgettoObj);
			}
			db.Close();
			return VimpreseXProgettoCollectionObj;
		}

		//Find Find

		public static VimpreseXProgettoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis)

		{

			VimpreseXProgettoCollection VimpreseXProgettoCollectionObj = new VimpreseXProgettoCollection();

			IDbCommand findCmd = db.InitCmd("Zvimpresexprogettofindfind", new string[] {"IdProgettoequalthis"}, new string[] {"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			VimpreseXProgetto VimpreseXProgettoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VimpreseXProgettoObj = GetFromDatareader(db);
				VimpreseXProgettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VimpreseXProgettoObj.IsDirty = false;
				VimpreseXProgettoObj.IsPersistent = true;
				VimpreseXProgettoCollectionObj.Add(VimpreseXProgettoObj);
			}
			db.Close();
			return VimpreseXProgettoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for VimpreseXProgettoCollectionProvider:IVimpreseXProgettoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VimpreseXProgettoCollectionProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di VimpreseXProgetto
		protected VimpreseXProgettoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public VimpreseXProgettoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new VimpreseXProgettoCollection();
		}

		//Costruttore 2: popola la collection
		public VimpreseXProgettoCollectionProvider(IntNT IdprogettoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdprogettoEqualThis);
		}

		//Costruttore3: ha in input vimpresexprogettoCollectionObj - non popola la collection
		public VimpreseXProgettoCollectionProvider(VimpreseXProgettoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public VimpreseXProgettoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new VimpreseXProgettoCollection();
		}

		//Get e Set
		public VimpreseXProgettoCollection CollectionObj
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
		public VimpreseXProgettoCollection Select(IntNT IdprogettoEqualThis, IntNT IdimpresaEqualThis, StringNT CuaaEqualThis, 
StringNT CodicefiscaleEqualThis, StringNT RagionesocialeEqualThis)
		{
			VimpreseXProgettoCollection VimpreseXProgettoCollectionTemp = VimpreseXProgettoDAL.Select(_dbProviderObj, IdprogettoEqualThis, IdimpresaEqualThis, CuaaEqualThis, 
CodicefiscaleEqualThis, RagionesocialeEqualThis);
			return VimpreseXProgettoCollectionTemp;
		}

		//Find: popola la collection
		public VimpreseXProgettoCollection Find(IntNT IdprogettoEqualThis)
		{
			VimpreseXProgettoCollection VimpreseXProgettoCollectionTemp = VimpreseXProgettoDAL.Find(_dbProviderObj, IdprogettoEqualThis);
			return VimpreseXProgettoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<vIMPRESE_X_PROGETTO>
  <ViewName>vIMPRESE_X_PROGETTO</ViewName>
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
      <ID_PROGETTO>Equal</ID_PROGETTO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</vIMPRESE_X_PROGETTO>
*/
