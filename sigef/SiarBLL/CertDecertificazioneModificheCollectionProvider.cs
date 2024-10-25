using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per CertDecertificazioneModifiche
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ICertDecertificazioneModificheProvider
	{
		int Save(CertDecertificazioneModifiche CertDecertificazioneModificheObj);
		int SaveCollection(CertDecertificazioneModificheCollection collectionObj);
		int Delete(CertDecertificazioneModifiche CertDecertificazioneModificheObj);
		int DeleteCollection(CertDecertificazioneModificheCollection collectionObj);
	}
	/// <summary>
	/// Summary description for CertDecertificazioneModifiche
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class CertDecertificazioneModifiche: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdModifica;
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
		[NonSerialized] private ICertDecertificazioneModificheProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICertDecertificazioneModificheProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public CertDecertificazioneModifiche()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
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
		/// Corrisponde al campo:ID_MODIFICA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdModifica
		{
			get { return _IdModifica; }
			set {
				if (IdModifica != value)
				{
					_IdModifica = value;
					SetDirtyFlag();
				}
			}
		}

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
	/// Summary description for CertDecertificazioneModificheCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CertDecertificazioneModificheCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private CertDecertificazioneModificheCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((CertDecertificazioneModifiche) info.GetValue(i.ToString(),typeof(CertDecertificazioneModifiche)));
			}
		}

		//Costruttore
		public CertDecertificazioneModificheCollection()
		{
			this.ItemType = typeof(CertDecertificazioneModifiche);
		}

		//Costruttore con provider
		public CertDecertificazioneModificheCollection(ICertDecertificazioneModificheProvider providerObj)
		{
			this.ItemType = typeof(CertDecertificazioneModifiche);
			this.Provider = providerObj;
		}

		//Get e Set
		public new CertDecertificazioneModifiche this[int index]
		{
			get { return (CertDecertificazioneModifiche)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new CertDecertificazioneModificheCollection GetChanges()
		{
			return (CertDecertificazioneModificheCollection) base.GetChanges();
		}

		[NonSerialized] private ICertDecertificazioneModificheProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICertDecertificazioneModificheProvider Provider
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
		public int Add(CertDecertificazioneModifiche CertDecertificazioneModificheObj)
		{
			if (CertDecertificazioneModificheObj.Provider == null) CertDecertificazioneModificheObj.Provider = this.Provider;
			return base.Add(CertDecertificazioneModificheObj);
		}

		//AddCollection
		public void AddCollection(CertDecertificazioneModificheCollection CertDecertificazioneModificheCollectionObj)
		{
			foreach (CertDecertificazioneModifiche CertDecertificazioneModificheObj in CertDecertificazioneModificheCollectionObj)
				this.Add(CertDecertificazioneModificheObj);
		}

		//Insert
		public void Insert(int index, CertDecertificazioneModifiche CertDecertificazioneModificheObj)
		{
			if (CertDecertificazioneModificheObj.Provider == null) CertDecertificazioneModificheObj.Provider = this.Provider;
			base.Insert(index, CertDecertificazioneModificheObj);
		}

		//CollectionGetById
		public CertDecertificazioneModifiche CollectionGetById(NullTypes.IntNT IdValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].Id == IdValue))
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
		public CertDecertificazioneModificheCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdModificaEqualThis, NullTypes.IntNT IdCertDecertificazioneEqualThis, 
NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.IntNT IdDecertificazioneEqualThis, 
NullTypes.StringNT TipoDecertificazioneEqualThis, NullTypes.DecimalNT ImportoDecertificazioneAmmessoEqualThis, NullTypes.DecimalNT ImportoDecertificazioneConcessoEqualThis, 
NullTypes.DatetimeNT DataConstatazioneAmministrativaEqualThis, NullTypes.IntNT IdCertificazioneSpesaEqualThis, NullTypes.IntNT IdCertificazioneContiEqualThis, 
NullTypes.BoolNT AssegnataEqualThis, NullTypes.BoolNT DefinitivaEqualThis, NullTypes.IntNT IdCertificazioneSpesaEffettivaEqualThis)
		{
			CertDecertificazioneModificheCollection CertDecertificazioneModificheCollectionTemp = new CertDecertificazioneModificheCollection();
			foreach (CertDecertificazioneModifiche CertDecertificazioneModificheItem in this)
			{
				if (((IdEqualThis == null) || ((CertDecertificazioneModificheItem.Id != null) && (CertDecertificazioneModificheItem.Id.Value == IdEqualThis.Value))) && ((IdModificaEqualThis == null) || ((CertDecertificazioneModificheItem.IdModifica != null) && (CertDecertificazioneModificheItem.IdModifica.Value == IdModificaEqualThis.Value))) && ((IdCertDecertificazioneEqualThis == null) || ((CertDecertificazioneModificheItem.IdCertDecertificazione != null) && (CertDecertificazioneModificheItem.IdCertDecertificazione.Value == IdCertDecertificazioneEqualThis.Value))) && 
((IdProgettoEqualThis == null) || ((CertDecertificazioneModificheItem.IdProgetto != null) && (CertDecertificazioneModificheItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((CertDecertificazioneModificheItem.IdDomandaPagamento != null) && (CertDecertificazioneModificheItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((IdDecertificazioneEqualThis == null) || ((CertDecertificazioneModificheItem.IdDecertificazione != null) && (CertDecertificazioneModificheItem.IdDecertificazione.Value == IdDecertificazioneEqualThis.Value))) && 
((TipoDecertificazioneEqualThis == null) || ((CertDecertificazioneModificheItem.TipoDecertificazione != null) && (CertDecertificazioneModificheItem.TipoDecertificazione.Value == TipoDecertificazioneEqualThis.Value))) && ((ImportoDecertificazioneAmmessoEqualThis == null) || ((CertDecertificazioneModificheItem.ImportoDecertificazioneAmmesso != null) && (CertDecertificazioneModificheItem.ImportoDecertificazioneAmmesso.Value == ImportoDecertificazioneAmmessoEqualThis.Value))) && ((ImportoDecertificazioneConcessoEqualThis == null) || ((CertDecertificazioneModificheItem.ImportoDecertificazioneConcesso != null) && (CertDecertificazioneModificheItem.ImportoDecertificazioneConcesso.Value == ImportoDecertificazioneConcessoEqualThis.Value))) && 
((DataConstatazioneAmministrativaEqualThis == null) || ((CertDecertificazioneModificheItem.DataConstatazioneAmministrativa != null) && (CertDecertificazioneModificheItem.DataConstatazioneAmministrativa.Value == DataConstatazioneAmministrativaEqualThis.Value))) && ((IdCertificazioneSpesaEqualThis == null) || ((CertDecertificazioneModificheItem.IdCertificazioneSpesa != null) && (CertDecertificazioneModificheItem.IdCertificazioneSpesa.Value == IdCertificazioneSpesaEqualThis.Value))) && ((IdCertificazioneContiEqualThis == null) || ((CertDecertificazioneModificheItem.IdCertificazioneConti != null) && (CertDecertificazioneModificheItem.IdCertificazioneConti.Value == IdCertificazioneContiEqualThis.Value))) && 
((AssegnataEqualThis == null) || ((CertDecertificazioneModificheItem.Assegnata != null) && (CertDecertificazioneModificheItem.Assegnata.Value == AssegnataEqualThis.Value))) && ((DefinitivaEqualThis == null) || ((CertDecertificazioneModificheItem.Definitiva != null) && (CertDecertificazioneModificheItem.Definitiva.Value == DefinitivaEqualThis.Value))) && ((IdCertificazioneSpesaEffettivaEqualThis == null) || ((CertDecertificazioneModificheItem.IdCertificazioneSpesaEffettiva != null) && (CertDecertificazioneModificheItem.IdCertificazioneSpesaEffettiva.Value == IdCertificazioneSpesaEffettivaEqualThis.Value))))
				{
					CertDecertificazioneModificheCollectionTemp.Add(CertDecertificazioneModificheItem);
				}
			}
			return CertDecertificazioneModificheCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for CertDecertificazioneModificheDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class CertDecertificazioneModificheDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CertDecertificazioneModifiche CertDecertificazioneModificheObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", CertDecertificazioneModificheObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdModifica", CertDecertificazioneModificheObj.IdModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "IdCertDecertificazione", CertDecertificazioneModificheObj.IdCertDecertificazione);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", CertDecertificazioneModificheObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdDomandaPagamento", CertDecertificazioneModificheObj.IdDomandaPagamento);
			DbProvider.SetCmdParam(cmd,firstChar + "IdDecertificazione", CertDecertificazioneModificheObj.IdDecertificazione);
			DbProvider.SetCmdParam(cmd,firstChar + "TipoDecertificazione", CertDecertificazioneModificheObj.TipoDecertificazione);
			DbProvider.SetCmdParam(cmd,firstChar + "ImportoDecertificazioneAmmesso", CertDecertificazioneModificheObj.ImportoDecertificazioneAmmesso);
			DbProvider.SetCmdParam(cmd,firstChar + "ImportoDecertificazioneConcesso", CertDecertificazioneModificheObj.ImportoDecertificazioneConcesso);
			DbProvider.SetCmdParam(cmd,firstChar + "DataConstatazioneAmministrativa", CertDecertificazioneModificheObj.DataConstatazioneAmministrativa);
			DbProvider.SetCmdParam(cmd,firstChar + "IdCertificazioneSpesa", CertDecertificazioneModificheObj.IdCertificazioneSpesa);
			DbProvider.SetCmdParam(cmd,firstChar + "IdCertificazioneConti", CertDecertificazioneModificheObj.IdCertificazioneConti);
			DbProvider.SetCmdParam(cmd,firstChar + "Assegnata", CertDecertificazioneModificheObj.Assegnata);
			DbProvider.SetCmdParam(cmd,firstChar + "Definitiva", CertDecertificazioneModificheObj.Definitiva);
			DbProvider.SetCmdParam(cmd,firstChar + "IdCertificazioneSpesaEffettiva", CertDecertificazioneModificheObj.IdCertificazioneSpesaEffettiva);
		}
		//Insert
		private static int Insert(DbProvider db, CertDecertificazioneModifiche CertDecertificazioneModificheObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZCertDecertificazioneModificheInsert", new string[] {"IdModifica", "IdCertDecertificazione", 
"IdProgetto", "IdDomandaPagamento", "IdDecertificazione", 
"TipoDecertificazione", "ImportoDecertificazioneAmmesso", "ImportoDecertificazioneConcesso", 
"DataConstatazioneAmministrativa", "IdCertificazioneSpesa", "IdCertificazioneConti", 
"Assegnata", "Definitiva", "IdCertificazioneSpesaEffettiva"}, new string[] {"int", "int", 
"int", "int", "int", 
"string", "decimal", "decimal", 
"DateTime", "int", "int", 
"bool", "bool", "int"},"");
				CompileIUCmd(false, insertCmd,CertDecertificazioneModificheObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				CertDecertificazioneModificheObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				CertDecertificazioneModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertDecertificazioneModificheObj.IsDirty = false;
				CertDecertificazioneModificheObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, CertDecertificazioneModifiche CertDecertificazioneModificheObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCertDecertificazioneModificheUpdate", new string[] {"Id", "IdModifica", "IdCertDecertificazione", 
"IdProgetto", "IdDomandaPagamento", "IdDecertificazione", 
"TipoDecertificazione", "ImportoDecertificazioneAmmesso", "ImportoDecertificazioneConcesso", 
"DataConstatazioneAmministrativa", "IdCertificazioneSpesa", "IdCertificazioneConti", 
"Assegnata", "Definitiva", "IdCertificazioneSpesaEffettiva"}, new string[] {"int", "int", "int", 
"int", "int", "int", 
"string", "decimal", "decimal", 
"DateTime", "int", "int", 
"bool", "bool", "int"},"");
				CompileIUCmd(true, updateCmd,CertDecertificazioneModificheObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				CertDecertificazioneModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertDecertificazioneModificheObj.IsDirty = false;
				CertDecertificazioneModificheObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, CertDecertificazioneModifiche CertDecertificazioneModificheObj)
		{
			switch (CertDecertificazioneModificheObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, CertDecertificazioneModificheObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, CertDecertificazioneModificheObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,CertDecertificazioneModificheObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, CertDecertificazioneModificheCollection CertDecertificazioneModificheCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCertDecertificazioneModificheUpdate", new string[] {"Id", "IdModifica", "IdCertDecertificazione", 
"IdProgetto", "IdDomandaPagamento", "IdDecertificazione", 
"TipoDecertificazione", "ImportoDecertificazioneAmmesso", "ImportoDecertificazioneConcesso", 
"DataConstatazioneAmministrativa", "IdCertificazioneSpesa", "IdCertificazioneConti", 
"Assegnata", "Definitiva", "IdCertificazioneSpesaEffettiva"}, new string[] {"int", "int", "int", 
"int", "int", "int", 
"string", "decimal", "decimal", 
"DateTime", "int", "int", 
"bool", "bool", "int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZCertDecertificazioneModificheInsert", new string[] {"IdModifica", "IdCertDecertificazione", 
"IdProgetto", "IdDomandaPagamento", "IdDecertificazione", 
"TipoDecertificazione", "ImportoDecertificazioneAmmesso", "ImportoDecertificazioneConcesso", 
"DataConstatazioneAmministrativa", "IdCertificazioneSpesa", "IdCertificazioneConti", 
"Assegnata", "Definitiva", "IdCertificazioneSpesaEffettiva"}, new string[] {"int", "int", 
"int", "int", "int", 
"string", "decimal", "decimal", 
"DateTime", "int", "int", 
"bool", "bool", "int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZCertDecertificazioneModificheDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < CertDecertificazioneModificheCollectionObj.Count; i++)
				{
					switch (CertDecertificazioneModificheCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,CertDecertificazioneModificheCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									CertDecertificazioneModificheCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,CertDecertificazioneModificheCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (CertDecertificazioneModificheCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)CertDecertificazioneModificheCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < CertDecertificazioneModificheCollectionObj.Count; i++)
				{
					if ((CertDecertificazioneModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CertDecertificazioneModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CertDecertificazioneModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						CertDecertificazioneModificheCollectionObj[i].IsDirty = false;
						CertDecertificazioneModificheCollectionObj[i].IsPersistent = true;
					}
					if ((CertDecertificazioneModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						CertDecertificazioneModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CertDecertificazioneModificheCollectionObj[i].IsDirty = false;
						CertDecertificazioneModificheCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, CertDecertificazioneModifiche CertDecertificazioneModificheObj)
		{
			int returnValue = 0;
			if (CertDecertificazioneModificheObj.IsPersistent) 
			{
				returnValue = Delete(db, CertDecertificazioneModificheObj.Id);
			}
			CertDecertificazioneModificheObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			CertDecertificazioneModificheObj.IsDirty = false;
			CertDecertificazioneModificheObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCertDecertificazioneModificheDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, CertDecertificazioneModificheCollection CertDecertificazioneModificheCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCertDecertificazioneModificheDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < CertDecertificazioneModificheCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", CertDecertificazioneModificheCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < CertDecertificazioneModificheCollectionObj.Count; i++)
				{
					if ((CertDecertificazioneModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CertDecertificazioneModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CertDecertificazioneModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CertDecertificazioneModificheCollectionObj[i].IsDirty = false;
						CertDecertificazioneModificheCollectionObj[i].IsPersistent = false;
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
		public static CertDecertificazioneModifiche GetById(DbProvider db, int IdValue)
		{
			CertDecertificazioneModifiche CertDecertificazioneModificheObj = null;
			IDbCommand readCmd = db.InitCmd( "ZCertDecertificazioneModificheGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				CertDecertificazioneModificheObj = GetFromDatareader(db);
				CertDecertificazioneModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertDecertificazioneModificheObj.IsDirty = false;
				CertDecertificazioneModificheObj.IsPersistent = true;
			}
			db.Close();
			return CertDecertificazioneModificheObj;
		}

		//getFromDatareader
		public static CertDecertificazioneModifiche GetFromDatareader(DbProvider db)
		{
			CertDecertificazioneModifiche CertDecertificazioneModificheObj = new CertDecertificazioneModifiche();
			CertDecertificazioneModificheObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			CertDecertificazioneModificheObj.IdModifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_MODIFICA"]);
			CertDecertificazioneModificheObj.IdCertDecertificazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CERT_DECERTIFICAZIONE"]);
			CertDecertificazioneModificheObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			CertDecertificazioneModificheObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
			CertDecertificazioneModificheObj.IdDecertificazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DECERTIFICAZIONE"]);
			CertDecertificazioneModificheObj.TipoDecertificazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_DECERTIFICAZIONE"]);
			CertDecertificazioneModificheObj.ImportoDecertificazioneAmmesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_DECERTIFICAZIONE_AMMESSO"]);
			CertDecertificazioneModificheObj.ImportoDecertificazioneConcesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_DECERTIFICAZIONE_CONCESSO"]);
			CertDecertificazioneModificheObj.DataConstatazioneAmministrativa = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CONSTATAZIONE_AMMINISTRATIVA"]);
			CertDecertificazioneModificheObj.IdCertificazioneSpesa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CERTIFICAZIONE_SPESA"]);
			CertDecertificazioneModificheObj.IdCertificazioneConti = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CERTIFICAZIONE_CONTI"]);
			CertDecertificazioneModificheObj.Assegnata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ASSEGNATA"]);
			CertDecertificazioneModificheObj.Definitiva = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DEFINITIVA"]);
			CertDecertificazioneModificheObj.IdCertificazioneSpesaEffettiva = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CERTIFICAZIONE_SPESA_EFFETTIVA"]);
			CertDecertificazioneModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			CertDecertificazioneModificheObj.IsDirty = false;
			CertDecertificazioneModificheObj.IsPersistent = true;
			return CertDecertificazioneModificheObj;
		}

		//Find Select

		public static CertDecertificazioneModificheCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdModificaEqualThis, SiarLibrary.NullTypes.IntNT IdCertDecertificazioneEqualThis, 
SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdDecertificazioneEqualThis, 
SiarLibrary.NullTypes.StringNT TipoDecertificazioneEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoDecertificazioneAmmessoEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoDecertificazioneConcessoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataConstatazioneAmministrativaEqualThis, SiarLibrary.NullTypes.IntNT IdCertificazioneSpesaEqualThis, SiarLibrary.NullTypes.IntNT IdCertificazioneContiEqualThis, 
SiarLibrary.NullTypes.BoolNT AssegnataEqualThis, SiarLibrary.NullTypes.BoolNT DefinitivaEqualThis, SiarLibrary.NullTypes.IntNT IdCertificazioneSpesaEffettivaEqualThis)

		{

			CertDecertificazioneModificheCollection CertDecertificazioneModificheCollectionObj = new CertDecertificazioneModificheCollection();

			IDbCommand findCmd = db.InitCmd("Zcertdecertificazionemodifichefindselect", new string[] {"Idequalthis", "IdModificaequalthis", "IdCertDecertificazioneequalthis", 
"IdProgettoequalthis", "IdDomandaPagamentoequalthis", "IdDecertificazioneequalthis", 
"TipoDecertificazioneequalthis", "ImportoDecertificazioneAmmessoequalthis", "ImportoDecertificazioneConcessoequalthis", 
"DataConstatazioneAmministrativaequalthis", "IdCertificazioneSpesaequalthis", "IdCertificazioneContiequalthis", 
"Assegnataequalthis", "Definitivaequalthis", "IdCertificazioneSpesaEffettivaequalthis"}, new string[] {"int", "int", "int", 
"int", "int", "int", 
"string", "decimal", "decimal", 
"DateTime", "int", "int", 
"bool", "bool", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdModificaequalthis", IdModificaEqualThis);
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
			CertDecertificazioneModifiche CertDecertificazioneModificheObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CertDecertificazioneModificheObj = GetFromDatareader(db);
				CertDecertificazioneModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertDecertificazioneModificheObj.IsDirty = false;
				CertDecertificazioneModificheObj.IsPersistent = true;
				CertDecertificazioneModificheCollectionObj.Add(CertDecertificazioneModificheObj);
			}
			db.Close();
			return CertDecertificazioneModificheCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for CertDecertificazioneModificheCollectionProvider:ICertDecertificazioneModificheProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CertDecertificazioneModificheCollectionProvider : ICertDecertificazioneModificheProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di CertDecertificazioneModifiche
		protected CertDecertificazioneModificheCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public CertDecertificazioneModificheCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new CertDecertificazioneModificheCollection(this);
		}

		//Costruttore3: ha in input certdecertificazionemodificheCollectionObj - non popola la collection
		public CertDecertificazioneModificheCollectionProvider(CertDecertificazioneModificheCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public CertDecertificazioneModificheCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new CertDecertificazioneModificheCollection(this);
		}

		//Get e Set
		public CertDecertificazioneModificheCollection CollectionObj
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
		public int SaveCollection(CertDecertificazioneModificheCollection collectionObj)
		{
			return CertDecertificazioneModificheDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(CertDecertificazioneModifiche certdecertificazionemodificheObj)
		{
			return CertDecertificazioneModificheDAL.Save(_dbProviderObj, certdecertificazionemodificheObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(CertDecertificazioneModificheCollection collectionObj)
		{
			return CertDecertificazioneModificheDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(CertDecertificazioneModifiche certdecertificazionemodificheObj)
		{
			return CertDecertificazioneModificheDAL.Delete(_dbProviderObj, certdecertificazionemodificheObj);
		}

		//getById
		public CertDecertificazioneModifiche GetById(IntNT IdValue)
		{
			CertDecertificazioneModifiche CertDecertificazioneModificheTemp = CertDecertificazioneModificheDAL.GetById(_dbProviderObj, IdValue);
			if (CertDecertificazioneModificheTemp!=null) CertDecertificazioneModificheTemp.Provider = this;
			return CertDecertificazioneModificheTemp;
		}

		//Select: popola la collection
		public CertDecertificazioneModificheCollection Select(IntNT IdEqualThis, IntNT IdmodificaEqualThis, IntNT IdcertdecertificazioneEqualThis, 
IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IddecertificazioneEqualThis, 
StringNT TipodecertificazioneEqualThis, DecimalNT ImportodecertificazioneammessoEqualThis, DecimalNT ImportodecertificazioneconcessoEqualThis, 
DatetimeNT DataconstatazioneamministrativaEqualThis, IntNT IdcertificazionespesaEqualThis, IntNT IdcertificazionecontiEqualThis, 
BoolNT AssegnataEqualThis, BoolNT DefinitivaEqualThis, IntNT IdcertificazionespesaeffettivaEqualThis)
		{
			CertDecertificazioneModificheCollection CertDecertificazioneModificheCollectionTemp = CertDecertificazioneModificheDAL.Select(_dbProviderObj, IdEqualThis, IdmodificaEqualThis, IdcertdecertificazioneEqualThis, 
IdprogettoEqualThis, IddomandapagamentoEqualThis, IddecertificazioneEqualThis, 
TipodecertificazioneEqualThis, ImportodecertificazioneammessoEqualThis, ImportodecertificazioneconcessoEqualThis, 
DataconstatazioneamministrativaEqualThis, IdcertificazionespesaEqualThis, IdcertificazionecontiEqualThis, 
AssegnataEqualThis, DefinitivaEqualThis, IdcertificazionespesaeffettivaEqualThis);
			CertDecertificazioneModificheCollectionTemp.Provider = this;
			return CertDecertificazioneModificheCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CERT_DECERTIFICAZIONE_MODIFICHE>
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
  <Finds />
  <Filters />
  <externalFields />
  <AddedFkFields />
</CERT_DECERTIFICAZIONE_MODIFICHE>
*/
