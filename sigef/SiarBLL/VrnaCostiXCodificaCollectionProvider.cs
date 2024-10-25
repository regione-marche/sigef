using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VrnaCostiXCodifica
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class VrnaCostiXCodifica: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdCostiXCodifica;
		private NullTypes.IntNT _CodTipoSpesa;
		private NullTypes.IntNT _IdCodificaInvestimento;
		private NullTypes.IntNT _IdBando;
		private NullTypes.StringNT _Spesa;
		private NullTypes.StringNT _DescrizioneInvestimento;


		//Costruttore
		public VrnaCostiXCodifica()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_COSTI_X_CODIFICA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdCostiXCodifica
		{
			get { return _IdCostiXCodifica; }
			set {
				if (IdCostiXCodifica != value)
				{
					_IdCostiXCodifica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_TIPO_SPESA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT CodTipoSpesa
		{
			get { return _CodTipoSpesa; }
			set {
				if (CodTipoSpesa != value)
				{
					_CodTipoSpesa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_CODIFICA_INVESTIMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdCodificaInvestimento
		{
			get { return _IdCodificaInvestimento; }
			set {
				if (IdCodificaInvestimento != value)
				{
					_IdCodificaInvestimento = value;
					SetDirtyFlag();
				}
			}
		}

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
		/// Corrisponde al campo:SPESA
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT Spesa
		{
			get { return _Spesa; }
			set {
				if (Spesa != value)
				{
					_Spesa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_INVESTIMENTO
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT DescrizioneInvestimento
		{
			get { return _DescrizioneInvestimento; }
			set {
				if (DescrizioneInvestimento != value)
				{
					_DescrizioneInvestimento = value;
					SetDirtyFlag();
				}
			}
		}




	}
}

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VrnaCostiXCodificaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VrnaCostiXCodificaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private VrnaCostiXCodificaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((VrnaCostiXCodifica) info.GetValue(i.ToString(),typeof(VrnaCostiXCodifica)));
			}
		}

		//Costruttore
		public VrnaCostiXCodificaCollection()
		{
			this.ItemType = typeof(VrnaCostiXCodifica);
		}

		//Get e Set
		public new VrnaCostiXCodifica this[int index]
		{
			get { return (VrnaCostiXCodifica)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VrnaCostiXCodificaCollection GetChanges()
		{
			return (VrnaCostiXCodificaCollection) base.GetChanges();
		}

		//Add
		public int Add(VrnaCostiXCodifica VrnaCostiXCodificaObj)
		{
			return base.Add(VrnaCostiXCodificaObj);
		}

		//AddCollection
		public void AddCollection(VrnaCostiXCodificaCollection VrnaCostiXCodificaCollectionObj)
		{
			foreach (VrnaCostiXCodifica VrnaCostiXCodificaObj in VrnaCostiXCodificaCollectionObj)
				this.Add(VrnaCostiXCodificaObj);
		}

		//Insert
		public void Insert(int index, VrnaCostiXCodifica VrnaCostiXCodificaObj)
		{
			base.Insert(index, VrnaCostiXCodificaObj);
		}

		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VrnaCostiXCodificaCollection SubSelect(NullTypes.IntNT IdCostiXCodificaEqualThis, NullTypes.IntNT CodTipoSpesaEqualThis, NullTypes.IntNT IdCodificaInvestimentoEqualThis, 
NullTypes.IntNT IdBandoEqualThis, NullTypes.StringNT SpesaEqualThis, NullTypes.StringNT DescrizioneInvestimentoEqualThis)
		{
			VrnaCostiXCodificaCollection VrnaCostiXCodificaCollectionTemp = new VrnaCostiXCodificaCollection();
			foreach (VrnaCostiXCodifica VrnaCostiXCodificaItem in this)
			{
				if (((IdCostiXCodificaEqualThis == null) || ((VrnaCostiXCodificaItem.IdCostiXCodifica != null) && (VrnaCostiXCodificaItem.IdCostiXCodifica.Value == IdCostiXCodificaEqualThis.Value))) && ((CodTipoSpesaEqualThis == null) || ((VrnaCostiXCodificaItem.CodTipoSpesa != null) && (VrnaCostiXCodificaItem.CodTipoSpesa.Value == CodTipoSpesaEqualThis.Value))) && ((IdCodificaInvestimentoEqualThis == null) || ((VrnaCostiXCodificaItem.IdCodificaInvestimento != null) && (VrnaCostiXCodificaItem.IdCodificaInvestimento.Value == IdCodificaInvestimentoEqualThis.Value))) && 
((IdBandoEqualThis == null) || ((VrnaCostiXCodificaItem.IdBando != null) && (VrnaCostiXCodificaItem.IdBando.Value == IdBandoEqualThis.Value))) && ((SpesaEqualThis == null) || ((VrnaCostiXCodificaItem.Spesa != null) && (VrnaCostiXCodificaItem.Spesa.Value == SpesaEqualThis.Value))) && ((DescrizioneInvestimentoEqualThis == null) || ((VrnaCostiXCodificaItem.DescrizioneInvestimento != null) && (VrnaCostiXCodificaItem.DescrizioneInvestimento.Value == DescrizioneInvestimentoEqualThis.Value))))
				{
					VrnaCostiXCodificaCollectionTemp.Add(VrnaCostiXCodificaItem);
				}
			}
			return VrnaCostiXCodificaCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for VrnaCostiXCodificaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class VrnaCostiXCodificaDAL
	{

		//Operazioni

		//getFromDatareader
		public static VrnaCostiXCodifica GetFromDatareader(DbProvider db)
		{
			VrnaCostiXCodifica VrnaCostiXCodificaObj = new VrnaCostiXCodifica();
			VrnaCostiXCodificaObj.IdCostiXCodifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COSTI_X_CODIFICA"]);
			VrnaCostiXCodificaObj.CodTipoSpesa = new SiarLibrary.NullTypes.IntNT(db.DataReader["COD_TIPO_SPESA"]);
			VrnaCostiXCodificaObj.IdCodificaInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CODIFICA_INVESTIMENTO"]);
			VrnaCostiXCodificaObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			VrnaCostiXCodificaObj.Spesa = new SiarLibrary.NullTypes.StringNT(db.DataReader["SPESA"]);
			VrnaCostiXCodificaObj.DescrizioneInvestimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_INVESTIMENTO"]);
			VrnaCostiXCodificaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			VrnaCostiXCodificaObj.IsDirty = false;
			VrnaCostiXCodificaObj.IsPersistent = true;
			return VrnaCostiXCodificaObj;
		}

		//Find Select

		public static VrnaCostiXCodificaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdCostiXCodificaEqualThis, SiarLibrary.NullTypes.IntNT CodTipoSpesaEqualThis, SiarLibrary.NullTypes.IntNT IdCodificaInvestimentoEqualThis, 
SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT SpesaEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneInvestimentoEqualThis)

		{

			VrnaCostiXCodificaCollection VrnaCostiXCodificaCollectionObj = new VrnaCostiXCodificaCollection();

			IDbCommand findCmd = db.InitCmd("Zvrnacostixcodificafindselect", new string[] {"IdCostiXCodificaequalthis", "CodTipoSpesaequalthis", "IdCodificaInvestimentoequalthis", 
"IdBandoequalthis", "Spesaequalthis", "DescrizioneInvestimentoequalthis"}, new string[] {"int", "int", "int", 
"int", "string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCostiXCodificaequalthis", IdCostiXCodificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoSpesaequalthis", CodTipoSpesaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCodificaInvestimentoequalthis", IdCodificaInvestimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Spesaequalthis", SpesaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneInvestimentoequalthis", DescrizioneInvestimentoEqualThis);
			VrnaCostiXCodifica VrnaCostiXCodificaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VrnaCostiXCodificaObj = GetFromDatareader(db);
				VrnaCostiXCodificaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VrnaCostiXCodificaObj.IsDirty = false;
				VrnaCostiXCodificaObj.IsPersistent = true;
				VrnaCostiXCodificaCollectionObj.Add(VrnaCostiXCodificaObj);
			}
			db.Close();
			return VrnaCostiXCodificaCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for VrnaCostiXCodificaCollectionProvider:IVrnaCostiXCodificaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VrnaCostiXCodificaCollectionProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di VrnaCostiXCodifica
		protected VrnaCostiXCodificaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public VrnaCostiXCodificaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new VrnaCostiXCodificaCollection();
		}

		//Costruttore3: ha in input vrnacostixcodificaCollectionObj - non popola la collection
		public VrnaCostiXCodificaCollectionProvider(VrnaCostiXCodificaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public VrnaCostiXCodificaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new VrnaCostiXCodificaCollection();
		}

		//Get e Set
		public VrnaCostiXCodificaCollection CollectionObj
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
		public VrnaCostiXCodificaCollection Select(IntNT IdcostixcodificaEqualThis, IntNT CodtipospesaEqualThis, IntNT IdcodificainvestimentoEqualThis, 
IntNT IdbandoEqualThis, StringNT SpesaEqualThis, StringNT DescrizioneinvestimentoEqualThis)
		{
			VrnaCostiXCodificaCollection VrnaCostiXCodificaCollectionTemp = VrnaCostiXCodificaDAL.Select(_dbProviderObj, IdcostixcodificaEqualThis, CodtipospesaEqualThis, IdcodificainvestimentoEqualThis, 
IdbandoEqualThis, SpesaEqualThis, DescrizioneinvestimentoEqualThis);
			return VrnaCostiXCodificaCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<VRNA_COSTI_X_CODIFICA>
  <ViewName>VRNA_COSTI_X_CODIFICA</ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
  <txtNomeCampoDataModifica>DATA_MODIFICA</txtNomeCampoDataModifica>
  <chkOptimisticCouncurrency>False</chkOptimisticCouncurrency>
  <chkShortNames>False</chkShortNames>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds />
  <Filters />
  <externalFields />
  <AddedFkFields />
</VRNA_COSTI_X_CODIFICA>
*/
