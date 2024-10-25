using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VrnaStrumentiXComponenti
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class VrnaStrumentiXComponenti: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdCodificaInvestimento;
		private NullTypes.IntNT _IdComponentiXCodifica;
		private NullTypes.IntNT _IdRnaObiettivo;
		private NullTypes.IntNT _IdRnaProcedimentiERegolamenti;
		private NullTypes.IntNT _CodTipoStrumentoAiuto;
		private NullTypes.IntNT _IdStrumentiXComponenti;
		private NullTypes.StringNT _Strumento;
		private NullTypes.DecimalNT _IntensitaStrumento;
		private NullTypes.StringNT _Obiettivo;
		private NullTypes.StringNT _CodiceRegolamento;
		private NullTypes.StringNT _Settore;
		private NullTypes.StringNT _Investimento;


		//Costruttore
		public VrnaStrumentiXComponenti()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
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
		/// Corrisponde al campo:ID_RNA_OBIETTIVO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdRnaObiettivo
		{
			get { return _IdRnaObiettivo; }
			set {
				if (IdRnaObiettivo != value)
				{
					_IdRnaObiettivo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_RNA_PROCEDIMENTI_E_REGOLAMENTI
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdRnaProcedimentiERegolamenti
		{
			get { return _IdRnaProcedimentiERegolamenti; }
			set {
				if (IdRnaProcedimentiERegolamenti != value)
				{
					_IdRnaProcedimentiERegolamenti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_TIPO_STRUMENTO_AIUTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT CodTipoStrumentoAiuto
		{
			get { return _CodTipoStrumentoAiuto; }
			set {
				if (CodTipoStrumentoAiuto != value)
				{
					_CodTipoStrumentoAiuto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_STRUMENTI_X_COMPONENTI
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdStrumentiXComponenti
		{
			get { return _IdStrumentiXComponenti; }
			set {
				if (IdStrumentiXComponenti != value)
				{
					_IdStrumentiXComponenti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:STRUMENTO
		/// Tipo sul db:VARCHAR(300)
		/// </summary>
		public NullTypes.StringNT Strumento
		{
			get { return _Strumento; }
			set {
				if (Strumento != value)
				{
					_Strumento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:INTENSITA_STRUMENTO
		/// Tipo sul db:DECIMAL(15,12)
		/// </summary>
		public NullTypes.DecimalNT IntensitaStrumento
		{
			get { return _IntensitaStrumento; }
			set {
				if (IntensitaStrumento != value)
				{
					_IntensitaStrumento = value;
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
		/// Corrisponde al campo:INVESTIMENTO
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Investimento
		{
			get { return _Investimento; }
			set {
				if (Investimento != value)
				{
					_Investimento = value;
					SetDirtyFlag();
				}
			}
		}




	}
}

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VrnaStrumentiXComponentiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VrnaStrumentiXComponentiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private VrnaStrumentiXComponentiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((VrnaStrumentiXComponenti) info.GetValue(i.ToString(),typeof(VrnaStrumentiXComponenti)));
			}
		}

		//Costruttore
		public VrnaStrumentiXComponentiCollection()
		{
			this.ItemType = typeof(VrnaStrumentiXComponenti);
		}

		//Get e Set
		public new VrnaStrumentiXComponenti this[int index]
		{
			get { return (VrnaStrumentiXComponenti)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VrnaStrumentiXComponentiCollection GetChanges()
		{
			return (VrnaStrumentiXComponentiCollection) base.GetChanges();
		}

		//Add
		public int Add(VrnaStrumentiXComponenti VrnaStrumentiXComponentiObj)
		{
			return base.Add(VrnaStrumentiXComponentiObj);
		}

		//AddCollection
		public void AddCollection(VrnaStrumentiXComponentiCollection VrnaStrumentiXComponentiCollectionObj)
		{
			foreach (VrnaStrumentiXComponenti VrnaStrumentiXComponentiObj in VrnaStrumentiXComponentiCollectionObj)
				this.Add(VrnaStrumentiXComponentiObj);
		}

		//Insert
		public void Insert(int index, VrnaStrumentiXComponenti VrnaStrumentiXComponentiObj)
		{
			base.Insert(index, VrnaStrumentiXComponentiObj);
		}

		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VrnaStrumentiXComponentiCollection SubSelect(NullTypes.IntNT IdCodificaInvestimentoEqualThis, NullTypes.IntNT IdComponentiXCodificaEqualThis, NullTypes.IntNT IdRnaObiettivoEqualThis, 
NullTypes.IntNT IdRnaProcedimentiERegolamentiEqualThis, NullTypes.IntNT CodTipoStrumentoAiutoEqualThis, NullTypes.IntNT IdStrumentiXComponentiEqualThis, 
NullTypes.StringNT StrumentoEqualThis, NullTypes.DecimalNT IntensitaStrumentoEqualThis, NullTypes.StringNT ObiettivoEqualThis, 
NullTypes.StringNT CodiceRegolamentoEqualThis, NullTypes.StringNT SettoreEqualThis, NullTypes.StringNT InvestimentoEqualThis)
		{
			VrnaStrumentiXComponentiCollection VrnaStrumentiXComponentiCollectionTemp = new VrnaStrumentiXComponentiCollection();
			foreach (VrnaStrumentiXComponenti VrnaStrumentiXComponentiItem in this)
			{
				if (((IdCodificaInvestimentoEqualThis == null) || ((VrnaStrumentiXComponentiItem.IdCodificaInvestimento != null) && (VrnaStrumentiXComponentiItem.IdCodificaInvestimento.Value == IdCodificaInvestimentoEqualThis.Value))) && ((IdComponentiXCodificaEqualThis == null) || ((VrnaStrumentiXComponentiItem.IdComponentiXCodifica != null) && (VrnaStrumentiXComponentiItem.IdComponentiXCodifica.Value == IdComponentiXCodificaEqualThis.Value))) && ((IdRnaObiettivoEqualThis == null) || ((VrnaStrumentiXComponentiItem.IdRnaObiettivo != null) && (VrnaStrumentiXComponentiItem.IdRnaObiettivo.Value == IdRnaObiettivoEqualThis.Value))) && 
((IdRnaProcedimentiERegolamentiEqualThis == null) || ((VrnaStrumentiXComponentiItem.IdRnaProcedimentiERegolamenti != null) && (VrnaStrumentiXComponentiItem.IdRnaProcedimentiERegolamenti.Value == IdRnaProcedimentiERegolamentiEqualThis.Value))) && ((CodTipoStrumentoAiutoEqualThis == null) || ((VrnaStrumentiXComponentiItem.CodTipoStrumentoAiuto != null) && (VrnaStrumentiXComponentiItem.CodTipoStrumentoAiuto.Value == CodTipoStrumentoAiutoEqualThis.Value))) && ((IdStrumentiXComponentiEqualThis == null) || ((VrnaStrumentiXComponentiItem.IdStrumentiXComponenti != null) && (VrnaStrumentiXComponentiItem.IdStrumentiXComponenti.Value == IdStrumentiXComponentiEqualThis.Value))) && 
((StrumentoEqualThis == null) || ((VrnaStrumentiXComponentiItem.Strumento != null) && (VrnaStrumentiXComponentiItem.Strumento.Value == StrumentoEqualThis.Value))) && ((IntensitaStrumentoEqualThis == null) || ((VrnaStrumentiXComponentiItem.IntensitaStrumento != null) && (VrnaStrumentiXComponentiItem.IntensitaStrumento.Value == IntensitaStrumentoEqualThis.Value))) && ((ObiettivoEqualThis == null) || ((VrnaStrumentiXComponentiItem.Obiettivo != null) && (VrnaStrumentiXComponentiItem.Obiettivo.Value == ObiettivoEqualThis.Value))) && 
((CodiceRegolamentoEqualThis == null) || ((VrnaStrumentiXComponentiItem.CodiceRegolamento != null) && (VrnaStrumentiXComponentiItem.CodiceRegolamento.Value == CodiceRegolamentoEqualThis.Value))) && ((SettoreEqualThis == null) || ((VrnaStrumentiXComponentiItem.Settore != null) && (VrnaStrumentiXComponentiItem.Settore.Value == SettoreEqualThis.Value))) && ((InvestimentoEqualThis == null) || ((VrnaStrumentiXComponentiItem.Investimento != null) && (VrnaStrumentiXComponentiItem.Investimento.Value == InvestimentoEqualThis.Value))))
				{
					VrnaStrumentiXComponentiCollectionTemp.Add(VrnaStrumentiXComponentiItem);
				}
			}
			return VrnaStrumentiXComponentiCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for VrnaStrumentiXComponentiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class VrnaStrumentiXComponentiDAL
	{

		//Operazioni

		//getFromDatareader
		public static VrnaStrumentiXComponenti GetFromDatareader(DbProvider db)
		{
			VrnaStrumentiXComponenti VrnaStrumentiXComponentiObj = new VrnaStrumentiXComponenti();
			VrnaStrumentiXComponentiObj.IdCodificaInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CODIFICA_INVESTIMENTO"]);
			VrnaStrumentiXComponentiObj.IdComponentiXCodifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COMPONENTI_X_CODIFICA"]);
			VrnaStrumentiXComponentiObj.IdRnaObiettivo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RNA_OBIETTIVO"]);
			VrnaStrumentiXComponentiObj.IdRnaProcedimentiERegolamenti = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RNA_PROCEDIMENTI_E_REGOLAMENTI"]);
			VrnaStrumentiXComponentiObj.CodTipoStrumentoAiuto = new SiarLibrary.NullTypes.IntNT(db.DataReader["COD_TIPO_STRUMENTO_AIUTO"]);
			VrnaStrumentiXComponentiObj.IdStrumentiXComponenti = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_STRUMENTI_X_COMPONENTI"]);
			VrnaStrumentiXComponentiObj.Strumento = new SiarLibrary.NullTypes.StringNT(db.DataReader["STRUMENTO"]);
			VrnaStrumentiXComponentiObj.IntensitaStrumento = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["INTENSITA_STRUMENTO"]);
			VrnaStrumentiXComponentiObj.Obiettivo = new SiarLibrary.NullTypes.StringNT(db.DataReader["OBIETTIVO"]);
			VrnaStrumentiXComponentiObj.CodiceRegolamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_REGOLAMENTO"]);
			VrnaStrumentiXComponentiObj.Settore = new SiarLibrary.NullTypes.StringNT(db.DataReader["SETTORE"]);
			VrnaStrumentiXComponentiObj.Investimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["INVESTIMENTO"]);
			VrnaStrumentiXComponentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			VrnaStrumentiXComponentiObj.IsDirty = false;
			VrnaStrumentiXComponentiObj.IsPersistent = true;
			return VrnaStrumentiXComponentiObj;
		}

		//Find Select

		public static VrnaStrumentiXComponentiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdCodificaInvestimentoEqualThis, SiarLibrary.NullTypes.IntNT IdComponentiXCodificaEqualThis, SiarLibrary.NullTypes.IntNT IdRnaObiettivoEqualThis, 
SiarLibrary.NullTypes.IntNT IdRnaProcedimentiERegolamentiEqualThis, SiarLibrary.NullTypes.IntNT CodTipoStrumentoAiutoEqualThis, SiarLibrary.NullTypes.IntNT IdStrumentiXComponentiEqualThis, 
SiarLibrary.NullTypes.StringNT StrumentoEqualThis, SiarLibrary.NullTypes.DecimalNT IntensitaStrumentoEqualThis, SiarLibrary.NullTypes.StringNT ObiettivoEqualThis, 
SiarLibrary.NullTypes.StringNT CodiceRegolamentoEqualThis, SiarLibrary.NullTypes.StringNT SettoreEqualThis, SiarLibrary.NullTypes.StringNT InvestimentoEqualThis)

		{

			VrnaStrumentiXComponentiCollection VrnaStrumentiXComponentiCollectionObj = new VrnaStrumentiXComponentiCollection();

			IDbCommand findCmd = db.InitCmd("Zvrnastrumentixcomponentifindselect", new string[] {"IdCodificaInvestimentoequalthis", "IdComponentiXCodificaequalthis", "IdRnaObiettivoequalthis", 
"IdRnaProcedimentiERegolamentiequalthis", "CodTipoStrumentoAiutoequalthis", "IdStrumentiXComponentiequalthis", 
"Strumentoequalthis", "IntensitaStrumentoequalthis", "Obiettivoequalthis", 
"CodiceRegolamentoequalthis", "Settoreequalthis", "Investimentoequalthis"}, new string[] {"int", "int", "int", 
"int", "int", "int", 
"string", "decimal", "string", 
"string", "string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCodificaInvestimentoequalthis", IdCodificaInvestimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdComponentiXCodificaequalthis", IdComponentiXCodificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRnaObiettivoequalthis", IdRnaObiettivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRnaProcedimentiERegolamentiequalthis", IdRnaProcedimentiERegolamentiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoStrumentoAiutoequalthis", CodTipoStrumentoAiutoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdStrumentiXComponentiequalthis", IdStrumentiXComponentiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Strumentoequalthis", StrumentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IntensitaStrumentoequalthis", IntensitaStrumentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Obiettivoequalthis", ObiettivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceRegolamentoequalthis", CodiceRegolamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Settoreequalthis", SettoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Investimentoequalthis", InvestimentoEqualThis);
			VrnaStrumentiXComponenti VrnaStrumentiXComponentiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VrnaStrumentiXComponentiObj = GetFromDatareader(db);
				VrnaStrumentiXComponentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VrnaStrumentiXComponentiObj.IsDirty = false;
				VrnaStrumentiXComponentiObj.IsPersistent = true;
				VrnaStrumentiXComponentiCollectionObj.Add(VrnaStrumentiXComponentiObj);
			}
			db.Close();
			return VrnaStrumentiXComponentiCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for VrnaStrumentiXComponentiCollectionProvider:IVrnaStrumentiXComponentiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VrnaStrumentiXComponentiCollectionProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di VrnaStrumentiXComponenti
		protected VrnaStrumentiXComponentiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public VrnaStrumentiXComponentiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new VrnaStrumentiXComponentiCollection();
		}

		//Costruttore3: ha in input vrnastrumentixcomponentiCollectionObj - non popola la collection
		public VrnaStrumentiXComponentiCollectionProvider(VrnaStrumentiXComponentiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public VrnaStrumentiXComponentiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new VrnaStrumentiXComponentiCollection();
		}

		//Get e Set
		public VrnaStrumentiXComponentiCollection CollectionObj
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
		public VrnaStrumentiXComponentiCollection Select(IntNT IdcodificainvestimentoEqualThis, IntNT IdcomponentixcodificaEqualThis, IntNT IdrnaobiettivoEqualThis, 
IntNT IdrnaprocedimentieregolamentiEqualThis, IntNT CodtipostrumentoaiutoEqualThis, IntNT IdstrumentixcomponentiEqualThis, 
StringNT StrumentoEqualThis, DecimalNT IntensitastrumentoEqualThis, StringNT ObiettivoEqualThis, 
StringNT CodiceregolamentoEqualThis, StringNT SettoreEqualThis, StringNT InvestimentoEqualThis)
		{
			VrnaStrumentiXComponentiCollection VrnaStrumentiXComponentiCollectionTemp = VrnaStrumentiXComponentiDAL.Select(_dbProviderObj, IdcodificainvestimentoEqualThis, IdcomponentixcodificaEqualThis, IdrnaobiettivoEqualThis, 
IdrnaprocedimentieregolamentiEqualThis, CodtipostrumentoaiutoEqualThis, IdstrumentixcomponentiEqualThis, 
StrumentoEqualThis, IntensitastrumentoEqualThis, ObiettivoEqualThis, 
CodiceregolamentoEqualThis, SettoreEqualThis, InvestimentoEqualThis);
			return VrnaStrumentiXComponentiCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<vRNA_STRUMENTI_X_COMPONENTI>
  <ViewName>vRNA_STRUMENTI_X_COMPONENTI</ViewName>
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
</vRNA_STRUMENTI_X_COMPONENTI>
*/
