using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VrnaComponentiXCodifica
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class VrnaComponentiXCodifica: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdComponentiXCodifica;
		private NullTypes.IntNT _IdProcedimentiRegolamenti;
		private NullTypes.IntNT _IdObiettivo;
		private NullTypes.IntNT _IdCodificaInvestimento;
		private NullTypes.StringNT _CodiceRegolamento;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.StringNT _Settore;
		private NullTypes.StringNT _Obiettivo;


		//Costruttore
		public VrnaComponentiXCodifica()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_COMPONENTI_X_CODIFICA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdComponentiXCodifica
		{
			get { return _IdComponentiXCodifica; }
			set {
				if (IdComponentiXCodifica != value)
				{
					_IdComponentiXCodifica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_PROCEDIMENTI_REGOLAMENTI
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProcedimentiRegolamenti
		{
			get { return _IdProcedimentiRegolamenti; }
			set {
				if (IdProcedimentiRegolamenti != value)
				{
					_IdProcedimentiRegolamenti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_OBIETTIVO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdObiettivo
		{
			get { return _IdObiettivo; }
			set {
				if (IdObiettivo != value)
				{
					_IdObiettivo = value;
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
		/// Corrisponde al campo:CODICE_REGOLAMENTO
		/// Tipo sul db:VARCHAR(30)
		/// </summary>
		public NullTypes.StringNT CodiceRegolamento
		{
			get { return _CodiceRegolamento; }
			set {
				if (CodiceRegolamento != value)
				{
					_CodiceRegolamento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(-1)
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
		/// Corrisponde al campo:SETTORE
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT Settore
		{
			get { return _Settore; }
			set {
				if (Settore != value)
				{
					_Settore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OBIETTIVO
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT Obiettivo
		{
			get { return _Obiettivo; }
			set {
				if (Obiettivo != value)
				{
					_Obiettivo = value;
					SetDirtyFlag();
				}
			}
		}




	}
}

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VrnaComponentiXCodificaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VrnaComponentiXCodificaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private VrnaComponentiXCodificaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((VrnaComponentiXCodifica) info.GetValue(i.ToString(),typeof(VrnaComponentiXCodifica)));
			}
		}

		//Costruttore
		public VrnaComponentiXCodificaCollection()
		{
			this.ItemType = typeof(VrnaComponentiXCodifica);
		}

		//Get e Set
		public new VrnaComponentiXCodifica this[int index]
		{
			get { return (VrnaComponentiXCodifica)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VrnaComponentiXCodificaCollection GetChanges()
		{
			return (VrnaComponentiXCodificaCollection) base.GetChanges();
		}

		//Add
		public int Add(VrnaComponentiXCodifica VrnaComponentiXCodificaObj)
		{
			return base.Add(VrnaComponentiXCodificaObj);
		}

		//AddCollection
		public void AddCollection(VrnaComponentiXCodificaCollection VrnaComponentiXCodificaCollectionObj)
		{
			foreach (VrnaComponentiXCodifica VrnaComponentiXCodificaObj in VrnaComponentiXCodificaCollectionObj)
				this.Add(VrnaComponentiXCodificaObj);
		}

		//Insert
		public void Insert(int index, VrnaComponentiXCodifica VrnaComponentiXCodificaObj)
		{
			base.Insert(index, VrnaComponentiXCodificaObj);
		}

		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VrnaComponentiXCodificaCollection SubSelect(NullTypes.IntNT IdComponentiXCodificaEqualThis, NullTypes.IntNT IdProcedimentiRegolamentiEqualThis, NullTypes.IntNT IdObiettivoEqualThis, 
NullTypes.IntNT IdCodificaInvestimentoEqualThis, NullTypes.StringNT CodiceRegolamentoEqualThis, NullTypes.StringNT DescrizioneEqualThis, 
NullTypes.StringNT SettoreEqualThis, NullTypes.StringNT ObiettivoEqualThis)
		{
			VrnaComponentiXCodificaCollection VrnaComponentiXCodificaCollectionTemp = new VrnaComponentiXCodificaCollection();
			foreach (VrnaComponentiXCodifica VrnaComponentiXCodificaItem in this)
			{
				if (((IdComponentiXCodificaEqualThis == null) || ((VrnaComponentiXCodificaItem.IdComponentiXCodifica != null) && (VrnaComponentiXCodificaItem.IdComponentiXCodifica.Value == IdComponentiXCodificaEqualThis.Value))) && ((IdProcedimentiRegolamentiEqualThis == null) || ((VrnaComponentiXCodificaItem.IdProcedimentiRegolamenti != null) && (VrnaComponentiXCodificaItem.IdProcedimentiRegolamenti.Value == IdProcedimentiRegolamentiEqualThis.Value))) && ((IdObiettivoEqualThis == null) || ((VrnaComponentiXCodificaItem.IdObiettivo != null) && (VrnaComponentiXCodificaItem.IdObiettivo.Value == IdObiettivoEqualThis.Value))) && 
((IdCodificaInvestimentoEqualThis == null) || ((VrnaComponentiXCodificaItem.IdCodificaInvestimento != null) && (VrnaComponentiXCodificaItem.IdCodificaInvestimento.Value == IdCodificaInvestimentoEqualThis.Value))) && ((CodiceRegolamentoEqualThis == null) || ((VrnaComponentiXCodificaItem.CodiceRegolamento != null) && (VrnaComponentiXCodificaItem.CodiceRegolamento.Value == CodiceRegolamentoEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((VrnaComponentiXCodificaItem.Descrizione != null) && (VrnaComponentiXCodificaItem.Descrizione.Value == DescrizioneEqualThis.Value))) && 
((SettoreEqualThis == null) || ((VrnaComponentiXCodificaItem.Settore != null) && (VrnaComponentiXCodificaItem.Settore.Value == SettoreEqualThis.Value))) && ((ObiettivoEqualThis == null) || ((VrnaComponentiXCodificaItem.Obiettivo != null) && (VrnaComponentiXCodificaItem.Obiettivo.Value == ObiettivoEqualThis.Value))))
				{
					VrnaComponentiXCodificaCollectionTemp.Add(VrnaComponentiXCodificaItem);
				}
			}
			return VrnaComponentiXCodificaCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for VrnaComponentiXCodificaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class VrnaComponentiXCodificaDAL
	{

		//Operazioni

		//getFromDatareader
		public static VrnaComponentiXCodifica GetFromDatareader(DbProvider db)
		{
			VrnaComponentiXCodifica VrnaComponentiXCodificaObj = new VrnaComponentiXCodifica();
			VrnaComponentiXCodificaObj.IdComponentiXCodifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COMPONENTI_X_CODIFICA"]);
			VrnaComponentiXCodificaObj.IdProcedimentiRegolamenti = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROCEDIMENTI_REGOLAMENTI"]);
			VrnaComponentiXCodificaObj.IdObiettivo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_OBIETTIVO"]);
			VrnaComponentiXCodificaObj.IdCodificaInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CODIFICA_INVESTIMENTO"]);
			VrnaComponentiXCodificaObj.CodiceRegolamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_REGOLAMENTO"]);
			VrnaComponentiXCodificaObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			VrnaComponentiXCodificaObj.Settore = new SiarLibrary.NullTypes.StringNT(db.DataReader["SETTORE"]);
			VrnaComponentiXCodificaObj.Obiettivo = new SiarLibrary.NullTypes.StringNT(db.DataReader["OBIETTIVO"]);
			VrnaComponentiXCodificaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			VrnaComponentiXCodificaObj.IsDirty = false;
			VrnaComponentiXCodificaObj.IsPersistent = true;
			return VrnaComponentiXCodificaObj;
		}

		//Find Select

		public static VrnaComponentiXCodificaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdComponentiXCodificaEqualThis, SiarLibrary.NullTypes.IntNT IdProcedimentiRegolamentiEqualThis, SiarLibrary.NullTypes.IntNT IdObiettivoEqualThis, 
SiarLibrary.NullTypes.IntNT IdCodificaInvestimentoEqualThis, SiarLibrary.NullTypes.StringNT CodiceRegolamentoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, 
SiarLibrary.NullTypes.StringNT SettoreEqualThis, SiarLibrary.NullTypes.StringNT ObiettivoEqualThis)

		{

			VrnaComponentiXCodificaCollection VrnaComponentiXCodificaCollectionObj = new VrnaComponentiXCodificaCollection();

			IDbCommand findCmd = db.InitCmd("Zvrnacomponentixcodificafindselect", new string[] {"IdComponentiXCodificaequalthis", "IdProcedimentiRegolamentiequalthis", "IdObiettivoequalthis", 
"IdCodificaInvestimentoequalthis", "CodiceRegolamentoequalthis", "Descrizioneequalthis", 
"Settoreequalthis", "Obiettivoequalthis"}, new string[] {"int", "int", "int", 
"int", "string", "string", 
"string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdComponentiXCodificaequalthis", IdComponentiXCodificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProcedimentiRegolamentiequalthis", IdProcedimentiRegolamentiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdObiettivoequalthis", IdObiettivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCodificaInvestimentoequalthis", IdCodificaInvestimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceRegolamentoequalthis", CodiceRegolamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Settoreequalthis", SettoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Obiettivoequalthis", ObiettivoEqualThis);
			VrnaComponentiXCodifica VrnaComponentiXCodificaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VrnaComponentiXCodificaObj = GetFromDatareader(db);
				VrnaComponentiXCodificaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VrnaComponentiXCodificaObj.IsDirty = false;
				VrnaComponentiXCodificaObj.IsPersistent = true;
				VrnaComponentiXCodificaCollectionObj.Add(VrnaComponentiXCodificaObj);
			}
			db.Close();
			return VrnaComponentiXCodificaCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for VrnaComponentiXCodificaCollectionProvider:IVrnaComponentiXCodificaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VrnaComponentiXCodificaCollectionProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di VrnaComponentiXCodifica
		protected VrnaComponentiXCodificaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public VrnaComponentiXCodificaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new VrnaComponentiXCodificaCollection();
		}

		//Costruttore3: ha in input vrnacomponentixcodificaCollectionObj - non popola la collection
		public VrnaComponentiXCodificaCollectionProvider(VrnaComponentiXCodificaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public VrnaComponentiXCodificaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new VrnaComponentiXCodificaCollection();
		}

		//Get e Set
		public VrnaComponentiXCodificaCollection CollectionObj
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
		public VrnaComponentiXCodificaCollection Select(IntNT IdcomponentixcodificaEqualThis, IntNT IdprocedimentiregolamentiEqualThis, IntNT IdobiettivoEqualThis, 
IntNT IdcodificainvestimentoEqualThis, StringNT CodiceregolamentoEqualThis, StringNT DescrizioneEqualThis, 
StringNT SettoreEqualThis, StringNT ObiettivoEqualThis)
		{
			VrnaComponentiXCodificaCollection VrnaComponentiXCodificaCollectionTemp = VrnaComponentiXCodificaDAL.Select(_dbProviderObj, IdcomponentixcodificaEqualThis, IdprocedimentiregolamentiEqualThis, IdobiettivoEqualThis, 
IdcodificainvestimentoEqualThis, CodiceregolamentoEqualThis, DescrizioneEqualThis, 
SettoreEqualThis, ObiettivoEqualThis);
			return VrnaComponentiXCodificaCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<vRNA_COMPONENTI_X_CODIFICA>
  <ViewName>vRNA_COMPONENTI_X_CODIFICA</ViewName>
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
</vRNA_COMPONENTI_X_CODIFICA>
*/
