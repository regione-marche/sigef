using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VistruttoriaDomandeAiuto
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class VistruttoriaDomandeAiuto: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdBando;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.DatetimeNT _DataScadenza;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.DatetimeNT _Data;
		private NullTypes.StringNT _Stato;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.StringNT _CodiceFiscale;
		private NullTypes.StringNT _RagioneSociale;
		private NullTypes.IntNT _IdUtente;
		private NullTypes.StringNT _CodStato;


		//Costruttore
		public VistruttoriaDomandeAiuto()
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
		/// Corrisponde al campo:DATA_SCADENZA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataScadenza
		{
			get { return _DataScadenza; }
			set {
				if (DataScadenza != value)
				{
					_DataScadenza = value;
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
			set {
				if (IdProgetto != value)
				{
					_IdProgetto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT Data
		{
			get { return _Data; }
			set {
				if (Data != value)
				{
					_Data = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:STATO
		/// Tipo sul db:VARCHAR(80)
		/// </summary>
		public NullTypes.StringNT Stato
		{
			get { return _Stato; }
			set {
				if (Stato != value)
				{
					_Stato = value;
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

		/// <summary>
		/// Corrisponde al campo:ID_UTENTE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdUtente
		{
			get { return _IdUtente; }
			set {
				if (IdUtente != value)
				{
					_IdUtente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_STATO
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT CodStato
		{
			get { return _CodStato; }
			set {
				if (CodStato != value)
				{
					_CodStato = value;
					SetDirtyFlag();
				}
			}
		}




	}
}

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VistruttoriaDomandeAiutoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VistruttoriaDomandeAiutoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private VistruttoriaDomandeAiutoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((VistruttoriaDomandeAiuto) info.GetValue(i.ToString(),typeof(VistruttoriaDomandeAiuto)));
			}
		}

		//Costruttore
		public VistruttoriaDomandeAiutoCollection()
		{
			this.ItemType = typeof(VistruttoriaDomandeAiuto);
		}

		//Get e Set
		public new VistruttoriaDomandeAiuto this[int index]
		{
			get { return (VistruttoriaDomandeAiuto)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VistruttoriaDomandeAiutoCollection GetChanges()
		{
			return (VistruttoriaDomandeAiutoCollection) base.GetChanges();
		}

		//Add
		public int Add(VistruttoriaDomandeAiuto VistruttoriaDomandeAiutoObj)
		{
			return base.Add(VistruttoriaDomandeAiutoObj);
		}

		//AddCollection
		public void AddCollection(VistruttoriaDomandeAiutoCollection VistruttoriaDomandeAiutoCollectionObj)
		{
			foreach (VistruttoriaDomandeAiuto VistruttoriaDomandeAiutoObj in VistruttoriaDomandeAiutoCollectionObj)
				this.Add(VistruttoriaDomandeAiutoObj);
		}

		//Insert
		public void Insert(int index, VistruttoriaDomandeAiuto VistruttoriaDomandeAiutoObj)
		{
			base.Insert(index, VistruttoriaDomandeAiutoObj);
		}

		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VistruttoriaDomandeAiutoCollection SubSelect(NullTypes.IntNT IdBandoEqualThis, NullTypes.StringNT DescrizioneEqualThis, NullTypes.DatetimeNT DataScadenzaEqualThis, 
NullTypes.IntNT IdProgettoEqualThis, NullTypes.DatetimeNT DataEqualThis, NullTypes.StringNT StatoEqualThis, 
NullTypes.IntNT IdImpresaEqualThis, NullTypes.StringNT CodiceFiscaleEqualThis, NullTypes.StringNT RagioneSocialeEqualThis, 
NullTypes.IntNT IdUtenteEqualThis, NullTypes.StringNT CodStatoEqualThis)
		{
			VistruttoriaDomandeAiutoCollection VistruttoriaDomandeAiutoCollectionTemp = new VistruttoriaDomandeAiutoCollection();
			foreach (VistruttoriaDomandeAiuto VistruttoriaDomandeAiutoItem in this)
			{
				if (((IdBandoEqualThis == null) || ((VistruttoriaDomandeAiutoItem.IdBando != null) && (VistruttoriaDomandeAiutoItem.IdBando.Value == IdBandoEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((VistruttoriaDomandeAiutoItem.Descrizione != null) && (VistruttoriaDomandeAiutoItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((DataScadenzaEqualThis == null) || ((VistruttoriaDomandeAiutoItem.DataScadenza != null) && (VistruttoriaDomandeAiutoItem.DataScadenza.Value == DataScadenzaEqualThis.Value))) && 
((IdProgettoEqualThis == null) || ((VistruttoriaDomandeAiutoItem.IdProgetto != null) && (VistruttoriaDomandeAiutoItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((DataEqualThis == null) || ((VistruttoriaDomandeAiutoItem.Data != null) && (VistruttoriaDomandeAiutoItem.Data.Value == DataEqualThis.Value))) && ((StatoEqualThis == null) || ((VistruttoriaDomandeAiutoItem.Stato != null) && (VistruttoriaDomandeAiutoItem.Stato.Value == StatoEqualThis.Value))) && 
((IdImpresaEqualThis == null) || ((VistruttoriaDomandeAiutoItem.IdImpresa != null) && (VistruttoriaDomandeAiutoItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((CodiceFiscaleEqualThis == null) || ((VistruttoriaDomandeAiutoItem.CodiceFiscale != null) && (VistruttoriaDomandeAiutoItem.CodiceFiscale.Value == CodiceFiscaleEqualThis.Value))) && ((RagioneSocialeEqualThis == null) || ((VistruttoriaDomandeAiutoItem.RagioneSociale != null) && (VistruttoriaDomandeAiutoItem.RagioneSociale.Value == RagioneSocialeEqualThis.Value))) && 
((IdUtenteEqualThis == null) || ((VistruttoriaDomandeAiutoItem.IdUtente != null) && (VistruttoriaDomandeAiutoItem.IdUtente.Value == IdUtenteEqualThis.Value))) && ((CodStatoEqualThis == null) || ((VistruttoriaDomandeAiutoItem.CodStato != null) && (VistruttoriaDomandeAiutoItem.CodStato.Value == CodStatoEqualThis.Value))))
				{
					VistruttoriaDomandeAiutoCollectionTemp.Add(VistruttoriaDomandeAiutoItem);
				}
			}
			return VistruttoriaDomandeAiutoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for VistruttoriaDomandeAiutoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class VistruttoriaDomandeAiutoDAL
	{

		//Operazioni

		//getFromDatareader
		public static VistruttoriaDomandeAiuto GetFromDatareader(DbProvider db)
		{
			VistruttoriaDomandeAiuto VistruttoriaDomandeAiutoObj = new VistruttoriaDomandeAiuto();
			VistruttoriaDomandeAiutoObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			VistruttoriaDomandeAiutoObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			VistruttoriaDomandeAiutoObj.DataScadenza = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_SCADENZA"]);
			VistruttoriaDomandeAiutoObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			VistruttoriaDomandeAiutoObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
			VistruttoriaDomandeAiutoObj.Stato = new SiarLibrary.NullTypes.StringNT(db.DataReader["STATO"]);
			VistruttoriaDomandeAiutoObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			VistruttoriaDomandeAiutoObj.CodiceFiscale = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_FISCALE"]);
			VistruttoriaDomandeAiutoObj.RagioneSociale = new SiarLibrary.NullTypes.StringNT(db.DataReader["RAGIONE_SOCIALE"]);
			VistruttoriaDomandeAiutoObj.IdUtente = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_UTENTE"]);
			VistruttoriaDomandeAiutoObj.CodStato = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_STATO"]);
			VistruttoriaDomandeAiutoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			VistruttoriaDomandeAiutoObj.IsDirty = false;
			VistruttoriaDomandeAiutoObj.IsPersistent = true;
			return VistruttoriaDomandeAiutoObj;
		}

		//Find Select

		public static VistruttoriaDomandeAiutoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.DatetimeNT DataScadenzaEqualThis, 
SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataEqualThis, SiarLibrary.NullTypes.StringNT StatoEqualThis, 
SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.StringNT CodiceFiscaleEqualThis, SiarLibrary.NullTypes.StringNT RagioneSocialeEqualThis, 
SiarLibrary.NullTypes.IntNT IdUtenteEqualThis, SiarLibrary.NullTypes.StringNT CodStatoEqualThis)

		{

			VistruttoriaDomandeAiutoCollection VistruttoriaDomandeAiutoCollectionObj = new VistruttoriaDomandeAiutoCollection();

			IDbCommand findCmd = db.InitCmd("Zvistruttoriadomandeaiutofselect", new string[] {"IdBandoE", "DescrizioneE", "DataScadenzaE", 
"IdProgettoE", "DataE", "StatoE", 
"IdImpresaE", "CodiceFiscaleE", "RagioneSocialeE", 
"IdUtenteE", "CodStatoE"}, new string[] {"int", "string", "DateTime", 
"int", "DateTime", "string", 
"int", "string", "string", 
"int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoE", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneE", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataScadenzaE", DataScadenzaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoE", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataE", DataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "StatoE", StatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaE", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceFiscaleE", CodiceFiscaleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RagioneSocialeE", RagioneSocialeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdUtenteE", IdUtenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodStatoE", CodStatoEqualThis);
			VistruttoriaDomandeAiuto VistruttoriaDomandeAiutoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VistruttoriaDomandeAiutoObj = GetFromDatareader(db);
				VistruttoriaDomandeAiutoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VistruttoriaDomandeAiutoObj.IsDirty = false;
				VistruttoriaDomandeAiutoObj.IsPersistent = true;
				VistruttoriaDomandeAiutoCollectionObj.Add(VistruttoriaDomandeAiutoObj);
			}
			db.Close();
			return VistruttoriaDomandeAiutoCollectionObj;
		}

		//Find FindDomandeIstruttoria

		public static VistruttoriaDomandeAiutoCollection FindDomandeIstruttoria(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdUtenteEqualThis, 
SiarLibrary.NullTypes.StringNT CodStatoEqualThis)

		{

			VistruttoriaDomandeAiutoCollection VistruttoriaDomandeAiutoCollectionObj = new VistruttoriaDomandeAiutoCollection();

			IDbCommand findCmd = db.InitCmd("Zvistruttoriadomandeaiutoffdomandeistruttoria", new string[] {"IdBandoE", "IdProgettoE", "IdUtenteE", 
"CodStatoE"}, new string[] {"int", "int", "int", 
"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoE", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoE", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdUtenteE", IdUtenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodStatoE", CodStatoEqualThis);
			VistruttoriaDomandeAiuto VistruttoriaDomandeAiutoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VistruttoriaDomandeAiutoObj = GetFromDatareader(db);
				VistruttoriaDomandeAiutoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VistruttoriaDomandeAiutoObj.IsDirty = false;
				VistruttoriaDomandeAiutoObj.IsPersistent = true;
				VistruttoriaDomandeAiutoCollectionObj.Add(VistruttoriaDomandeAiutoObj);
			}
			db.Close();
			return VistruttoriaDomandeAiutoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for VistruttoriaDomandeAiutoCollectionProvider:IVistruttoriaDomandeAiutoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VistruttoriaDomandeAiutoCollectionProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di VistruttoriaDomandeAiuto
		protected VistruttoriaDomandeAiutoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public VistruttoriaDomandeAiutoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new VistruttoriaDomandeAiutoCollection();
		}

		//Costruttore 2: popola la collection
		public VistruttoriaDomandeAiutoCollectionProvider(IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis, IntNT IdutenteEqualThis, 
StringNT CodstatoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = FindDomandeIstruttoria(IdbandoEqualThis, IdprogettoEqualThis, IdutenteEqualThis, 
CodstatoEqualThis);
		}

		//Costruttore3: ha in input vistruttoriadomandeaiutoCollectionObj - non popola la collection
		public VistruttoriaDomandeAiutoCollectionProvider(VistruttoriaDomandeAiutoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public VistruttoriaDomandeAiutoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new VistruttoriaDomandeAiutoCollection();
		}

		//Get e Set
		public VistruttoriaDomandeAiutoCollection CollectionObj
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
		public VistruttoriaDomandeAiutoCollection Select(IntNT IdbandoEqualThis, StringNT DescrizioneEqualThis, DatetimeNT DatascadenzaEqualThis, 
IntNT IdprogettoEqualThis, DatetimeNT DataEqualThis, StringNT StatoEqualThis, 
IntNT IdimpresaEqualThis, StringNT CodicefiscaleEqualThis, StringNT RagionesocialeEqualThis, 
IntNT IdutenteEqualThis, StringNT CodstatoEqualThis)
		{
			VistruttoriaDomandeAiutoCollection VistruttoriaDomandeAiutoCollectionTemp = VistruttoriaDomandeAiutoDAL.Select(_dbProviderObj, IdbandoEqualThis, DescrizioneEqualThis, DatascadenzaEqualThis, 
IdprogettoEqualThis, DataEqualThis, StatoEqualThis, 
IdimpresaEqualThis, CodicefiscaleEqualThis, RagionesocialeEqualThis, 
IdutenteEqualThis, CodstatoEqualThis);
			return VistruttoriaDomandeAiutoCollectionTemp;
		}

		//FindDomandeIstruttoria: popola la collection
		public VistruttoriaDomandeAiutoCollection FindDomandeIstruttoria(IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis, IntNT IdutenteEqualThis, 
StringNT CodstatoEqualThis)
		{
			VistruttoriaDomandeAiutoCollection VistruttoriaDomandeAiutoCollectionTemp = VistruttoriaDomandeAiutoDAL.FindDomandeIstruttoria(_dbProviderObj, IdbandoEqualThis, IdprogettoEqualThis, IdutenteEqualThis, 
CodstatoEqualThis);
			return VistruttoriaDomandeAiutoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<vIstruttoria_Domande_Aiuto>
  <ViewName>vIstruttoria_Domande_Aiuto</ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>True</chkDataModifica>
  <txtNomeCampoDataModifica>DATA_MODIFICA</txtNomeCampoDataModifica>
  <chkOptimisticCouncurrency>False</chkOptimisticCouncurrency>
  <chkShortNames>True</chkShortNames>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds>
    <FindDomandeIstruttoria OrderBy="ORDER BY ">
      <ID_BANDO>Equal</ID_BANDO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_UTENTE>Equal</ID_UTENTE>
      <COD_STATO>Equal</COD_STATO>
    </FindDomandeIstruttoria>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</vIstruttoria_Domande_Aiuto>
*/
