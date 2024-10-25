using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per CertDecertificazione
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ICertDecertificazioneProvider
	{
		int Save(CertDecertificazione CertDecertificazioneObj);
		int SaveCollection(CertDecertificazioneCollection collectionObj);
		int Delete(CertDecertificazione CertDecertificazioneObj);
		int DeleteCollection(CertDecertificazioneCollection collectionObj);
	}
	/// <summary>
	/// Summary description for CertDecertificazione
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class CertDecertificazione: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdCertDecertificazione;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdDomandaPagamento;
		private NullTypes.IntNT _IdDecertificazione;
		private NullTypes.StringNT _TipoDecertificazione;
		private NullTypes.DecimalNT _ImportoDecertificazioneAmmesso;
		private NullTypes.DecimalNT _ImportoDecertificazioneConcesso;
		private NullTypes.DatetimeNT _DataConstatazioneAmministrativa;
		private NullTypes.IntNT _IdCertificazioneSpesa;
		private NullTypes.IntNT _IdCertificazioneConti;
		private NullTypes.BoolNT _Assegnata;
		private NullTypes.BoolNT _Definitiva;
		private NullTypes.IntNT _IdCertificazioneSpesaEffettiva;
		[NonSerialized] private ICertDecertificazioneProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICertDecertificazioneProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public CertDecertificazione()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_CERT_DECERTIFICAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdCertDecertificazione
		{
			get { return _IdCertDecertificazione; }
			set {
				if (IdCertDecertificazione != value)
				{
					_IdCertDecertificazione = value;
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
		/// Corrisponde al campo:ID_DOMANDA_PAGAMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDomandaPagamento
		{
			get { return _IdDomandaPagamento; }
			set {
				if (IdDomandaPagamento != value)
				{
					_IdDomandaPagamento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_DECERTIFICAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDecertificazione
		{
			get { return _IdDecertificazione; }
			set {
				if (IdDecertificazione != value)
				{
					_IdDecertificazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO_DECERTIFICAZIONE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT TipoDecertificazione
		{
			get { return _TipoDecertificazione; }
			set {
				if (TipoDecertificazione != value)
				{
					_TipoDecertificazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_DECERTIFICAZIONE_AMMESSO
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoDecertificazioneAmmesso
		{
			get { return _ImportoDecertificazioneAmmesso; }
			set {
				if (ImportoDecertificazioneAmmesso != value)
				{
					_ImportoDecertificazioneAmmesso = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_DECERTIFICAZIONE_CONCESSO
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoDecertificazioneConcesso
		{
			get { return _ImportoDecertificazioneConcesso; }
			set {
				if (ImportoDecertificazioneConcesso != value)
				{
					_ImportoDecertificazioneConcesso = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_CONSTATAZIONE_AMMINISTRATIVA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataConstatazioneAmministrativa
		{
			get { return _DataConstatazioneAmministrativa; }
			set {
				if (DataConstatazioneAmministrativa != value)
				{
					_DataConstatazioneAmministrativa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_CERTIFICAZIONE_SPESA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdCertificazioneSpesa
		{
			get { return _IdCertificazioneSpesa; }
			set {
				if (IdCertificazioneSpesa != value)
				{
					_IdCertificazioneSpesa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_CERTIFICAZIONE_CONTI
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdCertificazioneConti
		{
			get { return _IdCertificazioneConti; }
			set {
				if (IdCertificazioneConti != value)
				{
					_IdCertificazioneConti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ASSEGNATA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Assegnata
		{
			get { return _Assegnata; }
			set {
				if (Assegnata != value)
				{
					_Assegnata = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DEFINITIVA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Definitiva
		{
			get { return _Definitiva; }
			set {
				if (Definitiva != value)
				{
					_Definitiva = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_CERTIFICAZIONE_SPESA_EFFETTIVA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdCertificazioneSpesaEffettiva
		{
			get { return _IdCertificazioneSpesaEffettiva; }
			set {
				if (IdCertificazioneSpesaEffettiva != value)
				{
					_IdCertificazioneSpesaEffettiva = value;
					SetDirtyFlag();
				}
			}
		}



		public int Save()
		{
			if (this.IsDirty)
			{
				return _provider.Save(this);
			}
			else
			{
				return 0;
			}
		}

		public int Delete()
		{
			return _provider.Delete(this);
		}

		//Get e Set dei campi 'aggiuntivi'

	}
}

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for CertDecertificazioneCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CertDecertificazioneCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private CertDecertificazioneCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((CertDecertificazione) info.GetValue(i.ToString(),typeof(CertDecertificazione)));
			}
		}

		//Costruttore
		public CertDecertificazioneCollection()
		{
			this.ItemType = typeof(CertDecertificazione);
		}

		//Costruttore con provider
		public CertDecertificazioneCollection(ICertDecertificazioneProvider providerObj)
		{
			this.ItemType = typeof(CertDecertificazione);
			this.Provider = providerObj;
		}

		//Get e Set
		public new CertDecertificazione this[int index]
		{
			get { return (CertDecertificazione)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new CertDecertificazioneCollection GetChanges()
		{
			return (CertDecertificazioneCollection) base.GetChanges();
		}

		[NonSerialized] private ICertDecertificazioneProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICertDecertificazioneProvider Provider
		{
			get {return _provider;}
			set 
			{ 
				_provider = value;
				for (int i = 0; i < this.Count; i++)
				{
					this[i].Provider = value;
				}
			} 
		}

		public int SaveCollection()
		{
			return _provider.SaveCollection(this);
		}
		public int DeleteCollection()
		{
			return _provider.DeleteCollection(this);
		}
		//Add
		public int Add(CertDecertificazione CertDecertificazioneObj)
		{
			if (CertDecertificazioneObj.Provider == null) CertDecertificazioneObj.Provider = this.Provider;
			return base.Add(CertDecertificazioneObj);
		}

		//AddCollection
		public void AddCollection(CertDecertificazioneCollection CertDecertificazioneCollectionObj)
		{
			foreach (CertDecertificazione CertDecertificazioneObj in CertDecertificazioneCollectionObj)
				this.Add(CertDecertificazioneObj);
		}

		//Insert
		public void Insert(int index, CertDecertificazione CertDecertificazioneObj)
		{
			if (CertDecertificazioneObj.Provider == null) CertDecertificazioneObj.Provider = this.Provider;
			base.Insert(index, CertDecertificazioneObj);
		}

		//CollectionGetById
		public CertDecertificazione CollectionGetById(NullTypes.IntNT IdCertDecertificazioneValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdCertDecertificazione == IdCertDecertificazioneValue))
					find = true;
				else
					i++;
			}
			if (find)
				return this[i];
			else
				return null;
		}
		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public CertDecertificazioneCollection SubSelect(NullTypes.IntNT IdCertDecertificazioneEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, 
NullTypes.IntNT IdDecertificazioneEqualThis, NullTypes.StringNT TipoDecertificazioneEqualThis, NullTypes.DecimalNT ImportoDecertificazioneAmmessoEqualThis, 
NullTypes.DecimalNT ImportoDecertificazioneConcessoEqualThis, NullTypes.DatetimeNT DataConstatazioneAmministrativaEqualThis, NullTypes.IntNT IdCertificazioneSpesaEqualThis, 
NullTypes.IntNT IdCertificazioneContiEqualThis, NullTypes.BoolNT AssegnataEqualThis, NullTypes.BoolNT DefinitivaEqualThis, 
NullTypes.IntNT IdCertificazioneSpesaEffettivaEqualThis)
		{
			CertDecertificazioneCollection CertDecertificazioneCollectionTemp = new CertDecertificazioneCollection();
			foreach (CertDecertificazione CertDecertificazioneItem in this)
			{
				if (((IdCertDecertificazioneEqualThis == null) || ((CertDecertificazioneItem.IdCertDecertificazione != null) && (CertDecertificazioneItem.IdCertDecertificazione.Value == IdCertDecertificazioneEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((CertDecertificazioneItem.IdProgetto != null) && (CertDecertificazioneItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((CertDecertificazioneItem.IdDomandaPagamento != null) && (CertDecertificazioneItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && 
((IdDecertificazioneEqualThis == null) || ((CertDecertificazioneItem.IdDecertificazione != null) && (CertDecertificazioneItem.IdDecertificazione.Value == IdDecertificazioneEqualThis.Value))) && ((TipoDecertificazioneEqualThis == null) || ((CertDecertificazioneItem.TipoDecertificazione != null) && (CertDecertificazioneItem.TipoDecertificazione.Value == TipoDecertificazioneEqualThis.Value))) && ((ImportoDecertificazioneAmmessoEqualThis == null) || ((CertDecertificazioneItem.ImportoDecertificazioneAmmesso != null) && (CertDecertificazioneItem.ImportoDecertificazioneAmmesso.Value == ImportoDecertificazioneAmmessoEqualThis.Value))) && 
((ImportoDecertificazioneConcessoEqualThis == null) || ((CertDecertificazioneItem.ImportoDecertificazioneConcesso != null) && (CertDecertificazioneItem.ImportoDecertificazioneConcesso.Value == ImportoDecertificazioneConcessoEqualThis.Value))) && ((DataConstatazioneAmministrativaEqualThis == null) || ((CertDecertificazioneItem.DataConstatazioneAmministrativa != null) && (CertDecertificazioneItem.DataConstatazioneAmministrativa.Value == DataConstatazioneAmministrativaEqualThis.Value))) && ((IdCertificazioneSpesaEqualThis == null) || ((CertDecertificazioneItem.IdCertificazioneSpesa != null) && (CertDecertificazioneItem.IdCertificazioneSpesa.Value == IdCertificazioneSpesaEqualThis.Value))) && 
((IdCertificazioneContiEqualThis == null) || ((CertDecertificazioneItem.IdCertificazioneConti != null) && (CertDecertificazioneItem.IdCertificazioneConti.Value == IdCertificazioneContiEqualThis.Value))) && ((AssegnataEqualThis == null) || ((CertDecertificazioneItem.Assegnata != null) && (CertDecertificazioneItem.Assegnata.Value == AssegnataEqualThis.Value))) && ((DefinitivaEqualThis == null) || ((CertDecertificazioneItem.Definitiva != null) && (CertDecertificazioneItem.Definitiva.Value == DefinitivaEqualThis.Value))) && 
((IdCertificazioneSpesaEffettivaEqualThis == null) || ((CertDecertificazioneItem.IdCertificazioneSpesaEffettiva != null) && (CertDecertificazioneItem.IdCertificazioneSpesaEffettiva.Value == IdCertificazioneSpesaEffettivaEqualThis.Value))))
				{
					CertDecertificazioneCollectionTemp.Add(CertDecertificazioneItem);
				}
			}
			return CertDecertificazioneCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for CertDecertificazioneDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class CertDecertificazioneDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CertDecertificazione CertDecertificazioneObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdCertDecertificazione", CertDecertificazioneObj.IdCertDecertificazione);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", CertDecertificazioneObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdDomandaPagamento", CertDecertificazioneObj.IdDomandaPagamento);
			DbProvider.SetCmdParam(cmd,firstChar + "IdDecertificazione", CertDecertificazioneObj.IdDecertificazione);
			DbProvider.SetCmdParam(cmd,firstChar + "TipoDecertificazione", CertDecertificazioneObj.TipoDecertificazione);
			DbProvider.SetCmdParam(cmd,firstChar + "ImportoDecertificazioneAmmesso", CertDecertificazioneObj.ImportoDecertificazioneAmmesso);
			DbProvider.SetCmdParam(cmd,firstChar + "ImportoDecertificazioneConcesso", CertDecertificazioneObj.ImportoDecertificazioneConcesso);
			DbProvider.SetCmdParam(cmd,firstChar + "DataConstatazioneAmministrativa", CertDecertificazioneObj.DataConstatazioneAmministrativa);
			DbProvider.SetCmdParam(cmd,firstChar + "IdCertificazioneSpesa", CertDecertificazioneObj.IdCertificazioneSpesa);
			DbProvider.SetCmdParam(cmd,firstChar + "IdCertificazioneConti", CertDecertificazioneObj.IdCertificazioneConti);
			DbProvider.SetCmdParam(cmd,firstChar + "Assegnata", CertDecertificazioneObj.Assegnata);
			DbProvider.SetCmdParam(cmd,firstChar + "Definitiva", CertDecertificazioneObj.Definitiva);
			DbProvider.SetCmdParam(cmd,firstChar + "IdCertificazioneSpesaEffettiva", CertDecertificazioneObj.IdCertificazioneSpesaEffettiva);
		}
		//Insert
		private static int Insert(DbProvider db, CertDecertificazione CertDecertificazioneObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZCertDecertificazioneInsert", new string[] {"IdProgetto", "IdDomandaPagamento", 
"IdDecertificazione", "TipoDecertificazione", "ImportoDecertificazioneAmmesso", 
"ImportoDecertificazioneConcesso", "DataConstatazioneAmministrativa", "IdCertificazioneSpesa", 
"IdCertificazioneConti", "Assegnata", "Definitiva", 
"IdCertificazioneSpesaEffettiva"}, new string[] {"int", "int", 
"int", "string", "decimal", 
"decimal", "DateTime", "int", 
"int", "bool", "bool", 
"int"},"");
				CompileIUCmd(false, insertCmd,CertDecertificazioneObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				CertDecertificazioneObj.IdCertDecertificazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CERT_DECERTIFICAZIONE"]);
				}
				CertDecertificazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertDecertificazioneObj.IsDirty = false;
				CertDecertificazioneObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, CertDecertificazione CertDecertificazioneObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCertDecertificazioneUpdate", new string[] {"IdCertDecertificazione", "IdProgetto", "IdDomandaPagamento", 
"IdDecertificazione", "TipoDecertificazione", "ImportoDecertificazioneAmmesso", 
"ImportoDecertificazioneConcesso", "DataConstatazioneAmministrativa", "IdCertificazioneSpesa", 
"IdCertificazioneConti", "Assegnata", "Definitiva", 
"IdCertificazioneSpesaEffettiva"}, new string[] {"int", "int", "int", 
"int", "string", "decimal", 
"decimal", "DateTime", "int", 
"int", "bool", "bool", 
"int"},"");
				CompileIUCmd(true, updateCmd,CertDecertificazioneObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				CertDecertificazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertDecertificazioneObj.IsDirty = false;
				CertDecertificazioneObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, CertDecertificazione CertDecertificazioneObj)
		{
			switch (CertDecertificazioneObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, CertDecertificazioneObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, CertDecertificazioneObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,CertDecertificazioneObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, CertDecertificazioneCollection CertDecertificazioneCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCertDecertificazioneUpdate", new string[] {"IdCertDecertificazione", "IdProgetto", "IdDomandaPagamento", 
"IdDecertificazione", "TipoDecertificazione", "ImportoDecertificazioneAmmesso", 
"ImportoDecertificazioneConcesso", "DataConstatazioneAmministrativa", "IdCertificazioneSpesa", 
"IdCertificazioneConti", "Assegnata", "Definitiva", 
"IdCertificazioneSpesaEffettiva"}, new string[] {"int", "int", "int", 
"int", "string", "decimal", 
"decimal", "DateTime", "int", 
"int", "bool", "bool", 
"int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZCertDecertificazioneInsert", new string[] {"IdProgetto", "IdDomandaPagamento", 
"IdDecertificazione", "TipoDecertificazione", "ImportoDecertificazioneAmmesso", 
"ImportoDecertificazioneConcesso", "DataConstatazioneAmministrativa", "IdCertificazioneSpesa", 
"IdCertificazioneConti", "Assegnata", "Definitiva", 
"IdCertificazioneSpesaEffettiva"}, new string[] {"int", "int", 
"int", "string", "decimal", 
"decimal", "DateTime", "int", 
"int", "bool", "bool", 
"int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZCertDecertificazioneDelete", new string[] {"IdCertDecertificazione"}, new string[] {"int"},"");
				for (int i = 0; i < CertDecertificazioneCollectionObj.Count; i++)
				{
					switch (CertDecertificazioneCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,CertDecertificazioneCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									CertDecertificazioneCollectionObj[i].IdCertDecertificazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CERT_DECERTIFICAZIONE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,CertDecertificazioneCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (CertDecertificazioneCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdCertDecertificazione", (SiarLibrary.NullTypes.IntNT)CertDecertificazioneCollectionObj[i].IdCertDecertificazione);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < CertDecertificazioneCollectionObj.Count; i++)
				{
					if ((CertDecertificazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CertDecertificazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CertDecertificazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						CertDecertificazioneCollectionObj[i].IsDirty = false;
						CertDecertificazioneCollectionObj[i].IsPersistent = true;
					}
					if ((CertDecertificazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						CertDecertificazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CertDecertificazioneCollectionObj[i].IsDirty = false;
						CertDecertificazioneCollectionObj[i].IsPersistent = false;
					}
				}
			}
			catch 
			{
				db.Rollback();
				throw;
			}
			finally
			{
				db.Close();
			}
			return returnValue;
		}

		//Delete
		public static int Delete(DbProvider db, CertDecertificazione CertDecertificazioneObj)
		{
			int returnValue = 0;
			if (CertDecertificazioneObj.IsPersistent) 
			{
				returnValue = Delete(db, CertDecertificazioneObj.IdCertDecertificazione);
			}
			CertDecertificazioneObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			CertDecertificazioneObj.IsDirty = false;
			CertDecertificazioneObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdCertDecertificazioneValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCertDecertificazioneDelete", new string[] {"IdCertDecertificazione"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdCertDecertificazione", (SiarLibrary.NullTypes.IntNT)IdCertDecertificazioneValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, CertDecertificazioneCollection CertDecertificazioneCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCertDecertificazioneDelete", new string[] {"IdCertDecertificazione"}, new string[] {"int"},"");
				for (int i = 0; i < CertDecertificazioneCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdCertDecertificazione", CertDecertificazioneCollectionObj[i].IdCertDecertificazione);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < CertDecertificazioneCollectionObj.Count; i++)
				{
					if ((CertDecertificazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CertDecertificazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CertDecertificazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CertDecertificazioneCollectionObj[i].IsDirty = false;
						CertDecertificazioneCollectionObj[i].IsPersistent = false;
					}
				}
			}
			catch 
			{
				db.Rollback();
				throw;
			}
			finally
			{
				db.Close();
			}
			return returnValue;
		}

		//getById
		public static CertDecertificazione GetById(DbProvider db, int IdCertDecertificazioneValue)
		{
			CertDecertificazione CertDecertificazioneObj = null;
			IDbCommand readCmd = db.InitCmd( "ZCertDecertificazioneGetById", new string[] {"IdCertDecertificazione"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdCertDecertificazione", (SiarLibrary.NullTypes.IntNT)IdCertDecertificazioneValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				CertDecertificazioneObj = GetFromDatareader(db);
				CertDecertificazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertDecertificazioneObj.IsDirty = false;
				CertDecertificazioneObj.IsPersistent = true;
			}
			db.Close();
			return CertDecertificazioneObj;
		}

		//getFromDatareader
		public static CertDecertificazione GetFromDatareader(DbProvider db)
		{
			CertDecertificazione CertDecertificazioneObj = new CertDecertificazione();
			CertDecertificazioneObj.IdCertDecertificazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CERT_DECERTIFICAZIONE"]);
			CertDecertificazioneObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			CertDecertificazioneObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
			CertDecertificazioneObj.IdDecertificazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DECERTIFICAZIONE"]);
			CertDecertificazioneObj.TipoDecertificazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_DECERTIFICAZIONE"]);
			CertDecertificazioneObj.ImportoDecertificazioneAmmesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_DECERTIFICAZIONE_AMMESSO"]);
			CertDecertificazioneObj.ImportoDecertificazioneConcesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_DECERTIFICAZIONE_CONCESSO"]);
			CertDecertificazioneObj.DataConstatazioneAmministrativa = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CONSTATAZIONE_AMMINISTRATIVA"]);
			CertDecertificazioneObj.IdCertificazioneSpesa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CERTIFICAZIONE_SPESA"]);
			CertDecertificazioneObj.IdCertificazioneConti = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CERTIFICAZIONE_CONTI"]);
			CertDecertificazioneObj.Assegnata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ASSEGNATA"]);
			CertDecertificazioneObj.Definitiva = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DEFINITIVA"]);
			CertDecertificazioneObj.IdCertificazioneSpesaEffettiva = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CERTIFICAZIONE_SPESA_EFFETTIVA"]);
			CertDecertificazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			CertDecertificazioneObj.IsDirty = false;
			CertDecertificazioneObj.IsPersistent = true;
			return CertDecertificazioneObj;
		}

		//Find Select

		public static CertDecertificazioneCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdCertDecertificazioneEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, 
SiarLibrary.NullTypes.IntNT IdDecertificazioneEqualThis, SiarLibrary.NullTypes.StringNT TipoDecertificazioneEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoDecertificazioneAmmessoEqualThis, 
SiarLibrary.NullTypes.DecimalNT ImportoDecertificazioneConcessoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataConstatazioneAmministrativaEqualThis, SiarLibrary.NullTypes.IntNT IdCertificazioneSpesaEqualThis, 
SiarLibrary.NullTypes.IntNT IdCertificazioneContiEqualThis, SiarLibrary.NullTypes.BoolNT AssegnataEqualThis, SiarLibrary.NullTypes.BoolNT DefinitivaEqualThis, 
SiarLibrary.NullTypes.IntNT IdCertificazioneSpesaEffettivaEqualThis)

		{

			CertDecertificazioneCollection CertDecertificazioneCollectionObj = new CertDecertificazioneCollection();

			IDbCommand findCmd = db.InitCmd("Zcertdecertificazionefindselect", new string[] {"IdCertDecertificazioneequalthis", "IdProgettoequalthis", "IdDomandaPagamentoequalthis", 
"IdDecertificazioneequalthis", "TipoDecertificazioneequalthis", "ImportoDecertificazioneAmmessoequalthis", 
"ImportoDecertificazioneConcessoequalthis", "DataConstatazioneAmministrativaequalthis", "IdCertificazioneSpesaequalthis", 
"IdCertificazioneContiequalthis", "Assegnataequalthis", "Definitivaequalthis", 
"IdCertificazioneSpesaEffettivaequalthis"}, new string[] {"int", "int", "int", 
"int", "string", "decimal", 
"decimal", "DateTime", "int", 
"int", "bool", "bool", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCertDecertificazioneequalthis", IdCertDecertificazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDecertificazioneequalthis", IdDecertificazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TipoDecertificazioneequalthis", TipoDecertificazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoDecertificazioneAmmessoequalthis", ImportoDecertificazioneAmmessoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoDecertificazioneConcessoequalthis", ImportoDecertificazioneConcessoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataConstatazioneAmministrativaequalthis", DataConstatazioneAmministrativaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCertificazioneSpesaequalthis", IdCertificazioneSpesaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCertificazioneContiequalthis", IdCertificazioneContiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Assegnataequalthis", AssegnataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Definitivaequalthis", DefinitivaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCertificazioneSpesaEffettivaequalthis", IdCertificazioneSpesaEffettivaEqualThis);
			CertDecertificazione CertDecertificazioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CertDecertificazioneObj = GetFromDatareader(db);
				CertDecertificazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertDecertificazioneObj.IsDirty = false;
				CertDecertificazioneObj.IsPersistent = true;
				CertDecertificazioneCollectionObj.Add(CertDecertificazioneObj);
			}
			db.Close();
			return CertDecertificazioneCollectionObj;
		}

		//Find Find

		public static CertDecertificazioneCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdCertDecertificazioneEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, 
SiarLibrary.NullTypes.IntNT IdDecertificazioneEqualThis, SiarLibrary.NullTypes.StringNT TipoDecertificazioneEqualThis, SiarLibrary.NullTypes.IntNT IdCertificazioneSpesaEqualThis, 
SiarLibrary.NullTypes.IntNT IdCertificazioneContiEqualThis, SiarLibrary.NullTypes.BoolNT AssegnataEqualThis, SiarLibrary.NullTypes.BoolNT DefinitivaEqualThis, 
SiarLibrary.NullTypes.BoolNT IdCertificazioneSpesaIsNull, SiarLibrary.NullTypes.BoolNT IdCertificazioneContiIsNull, SiarLibrary.NullTypes.IntNT IdCertificazioneSpesaEffettivaEqualThis)

		{

			CertDecertificazioneCollection CertDecertificazioneCollectionObj = new CertDecertificazioneCollection();

			IDbCommand findCmd = db.InitCmd("Zcertdecertificazionefindfind", new string[] {"IdCertDecertificazioneequalthis", "IdProgettoequalthis", "IdDomandaPagamentoequalthis", 
"IdDecertificazioneequalthis", "TipoDecertificazioneequalthis", "IdCertificazioneSpesaequalthis", 
"IdCertificazioneContiequalthis", "Assegnataequalthis", "Definitivaequalthis", 
"IdCertificazioneSpesaisnull", "IdCertificazioneContiisnull", "IdCertificazioneSpesaEffettivaequalthis"}, new string[] {"int", "int", "int", 
"int", "string", "int", 
"int", "bool", "bool", 
"bool", "bool", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCertDecertificazioneequalthis", IdCertDecertificazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDecertificazioneequalthis", IdDecertificazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TipoDecertificazioneequalthis", TipoDecertificazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCertificazioneSpesaequalthis", IdCertificazioneSpesaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCertificazioneContiequalthis", IdCertificazioneContiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Assegnataequalthis", AssegnataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Definitivaequalthis", DefinitivaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCertificazioneSpesaisnull", IdCertificazioneSpesaIsNull);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCertificazioneContiisnull", IdCertificazioneContiIsNull);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCertificazioneSpesaEffettivaequalthis", IdCertificazioneSpesaEffettivaEqualThis);
			CertDecertificazione CertDecertificazioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CertDecertificazioneObj = GetFromDatareader(db);
				CertDecertificazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertDecertificazioneObj.IsDirty = false;
				CertDecertificazioneObj.IsPersistent = true;
				CertDecertificazioneCollectionObj.Add(CertDecertificazioneObj);
			}
			db.Close();
			return CertDecertificazioneCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for CertDecertificazioneCollectionProvider:ICertDecertificazioneProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CertDecertificazioneCollectionProvider : ICertDecertificazioneProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di CertDecertificazione
		protected CertDecertificazioneCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public CertDecertificazioneCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new CertDecertificazioneCollection(this);
		}

		//Costruttore 2: popola la collection
		public CertDecertificazioneCollectionProvider(IntNT IdcertdecertificazioneEqualThis, IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis, 
IntNT IddecertificazioneEqualThis, StringNT TipodecertificazioneEqualThis, IntNT IdcertificazionespesaEqualThis, 
IntNT IdcertificazionecontiEqualThis, BoolNT AssegnataEqualThis, BoolNT DefinitivaEqualThis, 
BoolNT IdcertificazionespesaIsNull, BoolNT IdcertificazionecontiIsNull, IntNT IdcertificazionespesaeffettivaEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdcertdecertificazioneEqualThis, IdprogettoEqualThis, IddomandapagamentoEqualThis, 
IddecertificazioneEqualThis, TipodecertificazioneEqualThis, IdcertificazionespesaEqualThis, 
IdcertificazionecontiEqualThis, AssegnataEqualThis, DefinitivaEqualThis, 
IdcertificazionespesaIsNull, IdcertificazionecontiIsNull, IdcertificazionespesaeffettivaEqualThis);
		}

		//Costruttore3: ha in input certdecertificazioneCollectionObj - non popola la collection
		public CertDecertificazioneCollectionProvider(CertDecertificazioneCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public CertDecertificazioneCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new CertDecertificazioneCollection(this);
		}

		//Get e Set
		public CertDecertificazioneCollection CollectionObj
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

		//Save1: registra l'intera collection
		public int SaveCollection()
		{
			return SaveCollection(_CollectionObj);
		}

		//Save2: registra una collection
		public int SaveCollection(CertDecertificazioneCollection collectionObj)
		{
			return CertDecertificazioneDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(CertDecertificazione certdecertificazioneObj)
		{
			return CertDecertificazioneDAL.Save(_dbProviderObj, certdecertificazioneObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(CertDecertificazioneCollection collectionObj)
		{
			return CertDecertificazioneDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(CertDecertificazione certdecertificazioneObj)
		{
			return CertDecertificazioneDAL.Delete(_dbProviderObj, certdecertificazioneObj);
		}

		//getById
		public CertDecertificazione GetById(IntNT IdCertDecertificazioneValue)
		{
			CertDecertificazione CertDecertificazioneTemp = CertDecertificazioneDAL.GetById(_dbProviderObj, IdCertDecertificazioneValue);
			if (CertDecertificazioneTemp!=null) CertDecertificazioneTemp.Provider = this;
			return CertDecertificazioneTemp;
		}

		//Select: popola la collection
		public CertDecertificazioneCollection Select(IntNT IdcertdecertificazioneEqualThis, IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis, 
IntNT IddecertificazioneEqualThis, StringNT TipodecertificazioneEqualThis, DecimalNT ImportodecertificazioneammessoEqualThis, 
DecimalNT ImportodecertificazioneconcessoEqualThis, DatetimeNT DataconstatazioneamministrativaEqualThis, IntNT IdcertificazionespesaEqualThis, 
IntNT IdcertificazionecontiEqualThis, BoolNT AssegnataEqualThis, BoolNT DefinitivaEqualThis, 
IntNT IdcertificazionespesaeffettivaEqualThis)
		{
			CertDecertificazioneCollection CertDecertificazioneCollectionTemp = CertDecertificazioneDAL.Select(_dbProviderObj, IdcertdecertificazioneEqualThis, IdprogettoEqualThis, IddomandapagamentoEqualThis, 
IddecertificazioneEqualThis, TipodecertificazioneEqualThis, ImportodecertificazioneammessoEqualThis, 
ImportodecertificazioneconcessoEqualThis, DataconstatazioneamministrativaEqualThis, IdcertificazionespesaEqualThis, 
IdcertificazionecontiEqualThis, AssegnataEqualThis, DefinitivaEqualThis, 
IdcertificazionespesaeffettivaEqualThis);
			CertDecertificazioneCollectionTemp.Provider = this;
			return CertDecertificazioneCollectionTemp;
		}

		//Find: popola la collection
		public CertDecertificazioneCollection Find(IntNT IdcertdecertificazioneEqualThis, IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis, 
IntNT IddecertificazioneEqualThis, StringNT TipodecertificazioneEqualThis, IntNT IdcertificazionespesaEqualThis, 
IntNT IdcertificazionecontiEqualThis, BoolNT AssegnataEqualThis, BoolNT DefinitivaEqualThis, 
BoolNT IdcertificazionespesaIsNull, BoolNT IdcertificazionecontiIsNull, IntNT IdcertificazionespesaeffettivaEqualThis)
		{
			CertDecertificazioneCollection CertDecertificazioneCollectionTemp = CertDecertificazioneDAL.Find(_dbProviderObj, IdcertdecertificazioneEqualThis, IdprogettoEqualThis, IddomandapagamentoEqualThis, 
IddecertificazioneEqualThis, TipodecertificazioneEqualThis, IdcertificazionespesaEqualThis, 
IdcertificazionecontiEqualThis, AssegnataEqualThis, DefinitivaEqualThis, 
IdcertificazionespesaIsNull, IdcertificazionecontiIsNull, IdcertificazionespesaeffettivaEqualThis);
			CertDecertificazioneCollectionTemp.Provider = this;
			return CertDecertificazioneCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CERT_DECERTIFICAZIONE>
  <ViewName>
  </ViewName>
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
      <ID_CERT_DECERTIFICAZIONE>Equal</ID_CERT_DECERTIFICAZIONE>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_DECERTIFICAZIONE>Equal</ID_DECERTIFICAZIONE>
      <TIPO_DECERTIFICAZIONE>Equal</TIPO_DECERTIFICAZIONE>
      <ID_CERTIFICAZIONE_SPESA>Equal</ID_CERTIFICAZIONE_SPESA>
      <ID_CERTIFICAZIONE_CONTI>Equal</ID_CERTIFICAZIONE_CONTI>
      <ASSEGNATA>Equal</ASSEGNATA>
      <DEFINITIVA>Equal</DEFINITIVA>
      <ID_CERTIFICAZIONE_SPESA>IsNull</ID_CERTIFICAZIONE_SPESA>
      <ID_CERTIFICAZIONE_CONTI>IsNull</ID_CERTIFICAZIONE_CONTI>
      <ID_CERTIFICAZIONE_SPESA_EFFETTIVA>Equal</ID_CERTIFICAZIONE_SPESA_EFFETTIVA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CERT_DECERTIFICAZIONE>
*/
