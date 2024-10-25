using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ErogazioneFemXDecreti
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IErogazioneFemXDecretiProvider
	{
		int Save(ErogazioneFemXDecreti ErogazioneFemXDecretiObj);
		int SaveCollection(ErogazioneFemXDecretiCollection collectionObj);
		int Delete(ErogazioneFemXDecreti ErogazioneFemXDecretiObj);
		int DeleteCollection(ErogazioneFemXDecretiCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ErogazioneFemXDecreti
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ErogazioneFemXDecreti: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdErogazioneXDecreti;
		private NullTypes.IntNT _OperatoreCreazione;
		private NullTypes.DatetimeNT _DataCreazione;
		private NullTypes.IntNT _OperatoreModifica;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.IntNT _IdErogazione;
		private NullTypes.IntNT _IdDecreto;
		private NullTypes.DecimalNT _Importo;
		private NullTypes.DecimalNT _ImportoAmmesso;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdDomandaPagamento;
		private NullTypes.IntNT _Numero;
		private NullTypes.BoolNT _Anticipo;
		private NullTypes.DecimalNT _SogliaContributi;
		private NullTypes.DecimalNT _SommaMandati;
		private NullTypes.DecimalNT _SommaQuietanza;
		[NonSerialized] private IErogazioneFemXDecretiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IErogazioneFemXDecretiProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ErogazioneFemXDecreti()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_EROGAZIONE_X_DECRETI
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdErogazioneXDecreti
		{
			get { return _IdErogazioneXDecreti; }
			set {
				if (IdErogazioneXDecreti != value)
				{
					_IdErogazioneXDecreti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE_CREAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OperatoreCreazione
		{
			get { return _OperatoreCreazione; }
			set {
				if (OperatoreCreazione != value)
				{
					_OperatoreCreazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_CREAZIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataCreazione
		{
			get { return _DataCreazione; }
			set {
				if (DataCreazione != value)
				{
					_DataCreazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE_MODIFICA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OperatoreModifica
		{
			get { return _OperatoreModifica; }
			set {
				if (OperatoreModifica != value)
				{
					_OperatoreModifica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_MODIFICA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataModifica
		{
			get { return _DataModifica; }
			set {
				if (DataModifica != value)
				{
					_DataModifica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_EROGAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdErogazione
		{
			get { return _IdErogazione; }
			set {
				if (IdErogazione != value)
				{
					_IdErogazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_DECRETO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDecreto
		{
			get { return _IdDecreto; }
			set {
				if (IdDecreto != value)
				{
					_IdDecreto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT Importo
		{
			get { return _Importo; }
			set {
				if (Importo != value)
				{
					_Importo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_AMMESSO
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoAmmesso
		{
			get { return _ImportoAmmesso; }
			set {
				if (ImportoAmmesso != value)
				{
					_ImportoAmmesso = value;
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
		/// Corrisponde al campo:NUMERO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Numero
		{
			get { return _Numero; }
			set {
				if (Numero != value)
				{
					_Numero = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ANTICIPO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Anticipo
		{
			get { return _Anticipo; }
			set {
				if (Anticipo != value)
				{
					_Anticipo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SOGLIA_CONTRIBUTI
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT SogliaContributi
		{
			get { return _SogliaContributi; }
			set {
				if (SogliaContributi != value)
				{
					_SogliaContributi = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SOMMA_MANDATI
		/// Tipo sul db:DECIMAL(38,2)
		/// </summary>
		public NullTypes.DecimalNT SommaMandati
		{
			get { return _SommaMandati; }
			set {
				if (SommaMandati != value)
				{
					_SommaMandati = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SOMMA_QUIETANZA
		/// Tipo sul db:DECIMAL(38,2)
		/// </summary>
		public NullTypes.DecimalNT SommaQuietanza
		{
			get { return _SommaQuietanza; }
			set {
				if (SommaQuietanza != value)
				{
					_SommaQuietanza = value;
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
	/// Summary description for ErogazioneFemXDecretiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ErogazioneFemXDecretiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ErogazioneFemXDecretiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ErogazioneFemXDecreti) info.GetValue(i.ToString(),typeof(ErogazioneFemXDecreti)));
			}
		}

		//Costruttore
		public ErogazioneFemXDecretiCollection()
		{
			this.ItemType = typeof(ErogazioneFemXDecreti);
		}

		//Costruttore con provider
		public ErogazioneFemXDecretiCollection(IErogazioneFemXDecretiProvider providerObj)
		{
			this.ItemType = typeof(ErogazioneFemXDecreti);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ErogazioneFemXDecreti this[int index]
		{
			get { return (ErogazioneFemXDecreti)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ErogazioneFemXDecretiCollection GetChanges()
		{
			return (ErogazioneFemXDecretiCollection) base.GetChanges();
		}

		[NonSerialized] private IErogazioneFemXDecretiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IErogazioneFemXDecretiProvider Provider
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
		public int Add(ErogazioneFemXDecreti ErogazioneFemXDecretiObj)
		{
			if (ErogazioneFemXDecretiObj.Provider == null) ErogazioneFemXDecretiObj.Provider = this.Provider;
			return base.Add(ErogazioneFemXDecretiObj);
		}

		//AddCollection
		public void AddCollection(ErogazioneFemXDecretiCollection ErogazioneFemXDecretiCollectionObj)
		{
			foreach (ErogazioneFemXDecreti ErogazioneFemXDecretiObj in ErogazioneFemXDecretiCollectionObj)
				this.Add(ErogazioneFemXDecretiObj);
		}

		//Insert
		public void Insert(int index, ErogazioneFemXDecreti ErogazioneFemXDecretiObj)
		{
			if (ErogazioneFemXDecretiObj.Provider == null) ErogazioneFemXDecretiObj.Provider = this.Provider;
			base.Insert(index, ErogazioneFemXDecretiObj);
		}

		//CollectionGetById
		public ErogazioneFemXDecreti CollectionGetById(NullTypes.IntNT IdErogazioneXDecretiValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdErogazioneXDecreti == IdErogazioneXDecretiValue))
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
		public ErogazioneFemXDecretiCollection SubSelect(NullTypes.IntNT IdErogazioneXDecretiEqualThis, NullTypes.IntNT OperatoreCreazioneEqualThis, NullTypes.DatetimeNT DataCreazioneEqualThis, 
NullTypes.IntNT OperatoreModificaEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.IntNT IdErogazioneEqualThis, 
NullTypes.IntNT IdDecretoEqualThis, NullTypes.DecimalNT ImportoEqualThis, NullTypes.DecimalNT ImportoAmmessoEqualThis)
		{
			ErogazioneFemXDecretiCollection ErogazioneFemXDecretiCollectionTemp = new ErogazioneFemXDecretiCollection();
			foreach (ErogazioneFemXDecreti ErogazioneFemXDecretiItem in this)
			{
				if (((IdErogazioneXDecretiEqualThis == null) || ((ErogazioneFemXDecretiItem.IdErogazioneXDecreti != null) && (ErogazioneFemXDecretiItem.IdErogazioneXDecreti.Value == IdErogazioneXDecretiEqualThis.Value))) && ((OperatoreCreazioneEqualThis == null) || ((ErogazioneFemXDecretiItem.OperatoreCreazione != null) && (ErogazioneFemXDecretiItem.OperatoreCreazione.Value == OperatoreCreazioneEqualThis.Value))) && ((DataCreazioneEqualThis == null) || ((ErogazioneFemXDecretiItem.DataCreazione != null) && (ErogazioneFemXDecretiItem.DataCreazione.Value == DataCreazioneEqualThis.Value))) && 
((OperatoreModificaEqualThis == null) || ((ErogazioneFemXDecretiItem.OperatoreModifica != null) && (ErogazioneFemXDecretiItem.OperatoreModifica.Value == OperatoreModificaEqualThis.Value))) && ((DataModificaEqualThis == null) || ((ErogazioneFemXDecretiItem.DataModifica != null) && (ErogazioneFemXDecretiItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((IdErogazioneEqualThis == null) || ((ErogazioneFemXDecretiItem.IdErogazione != null) && (ErogazioneFemXDecretiItem.IdErogazione.Value == IdErogazioneEqualThis.Value))) && 
((IdDecretoEqualThis == null) || ((ErogazioneFemXDecretiItem.IdDecreto != null) && (ErogazioneFemXDecretiItem.IdDecreto.Value == IdDecretoEqualThis.Value))) && ((ImportoEqualThis == null) || ((ErogazioneFemXDecretiItem.Importo != null) && (ErogazioneFemXDecretiItem.Importo.Value == ImportoEqualThis.Value))) && ((ImportoAmmessoEqualThis == null) || ((ErogazioneFemXDecretiItem.ImportoAmmesso != null) && (ErogazioneFemXDecretiItem.ImportoAmmesso.Value == ImportoAmmessoEqualThis.Value))))
				{
					ErogazioneFemXDecretiCollectionTemp.Add(ErogazioneFemXDecretiItem);
				}
			}
			return ErogazioneFemXDecretiCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ErogazioneFemXDecretiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ErogazioneFemXDecretiDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ErogazioneFemXDecreti ErogazioneFemXDecretiObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdErogazioneXDecreti", ErogazioneFemXDecretiObj.IdErogazioneXDecreti);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreCreazione", ErogazioneFemXDecretiObj.OperatoreCreazione);
			DbProvider.SetCmdParam(cmd,firstChar + "DataCreazione", ErogazioneFemXDecretiObj.DataCreazione);
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreModifica", ErogazioneFemXDecretiObj.OperatoreModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", ErogazioneFemXDecretiObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "IdErogazione", ErogazioneFemXDecretiObj.IdErogazione);
			DbProvider.SetCmdParam(cmd,firstChar + "IdDecreto", ErogazioneFemXDecretiObj.IdDecreto);
			DbProvider.SetCmdParam(cmd,firstChar + "Importo", ErogazioneFemXDecretiObj.Importo);
			DbProvider.SetCmdParam(cmd,firstChar + "ImportoAmmesso", ErogazioneFemXDecretiObj.ImportoAmmesso);
		}
		//Insert
		private static int Insert(DbProvider db, ErogazioneFemXDecreti ErogazioneFemXDecretiObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZErogazioneFemXDecretiInsert", new string[] {"OperatoreCreazione", "DataCreazione", 
"OperatoreModifica", "DataModifica", "IdErogazione", 
"IdDecreto", "Importo", "ImportoAmmesso", 

}, new string[] {"int", "DateTime", 
"int", "DateTime", "int", 
"int", "decimal", "decimal", 

},"");
				CompileIUCmd(false, insertCmd,ErogazioneFemXDecretiObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ErogazioneFemXDecretiObj.IdErogazioneXDecreti = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_EROGAZIONE_X_DECRETI"]);
				}
				ErogazioneFemXDecretiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ErogazioneFemXDecretiObj.IsDirty = false;
				ErogazioneFemXDecretiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ErogazioneFemXDecreti ErogazioneFemXDecretiObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZErogazioneFemXDecretiUpdate", new string[] {"IdErogazioneXDecreti", "OperatoreCreazione", "DataCreazione", 
"OperatoreModifica", "DataModifica", "IdErogazione", 
"IdDecreto", "Importo", "ImportoAmmesso", 

}, new string[] {"int", "int", "DateTime", 
"int", "DateTime", "int", 
"int", "decimal", "decimal", 

},"");
				CompileIUCmd(true, updateCmd,ErogazioneFemXDecretiObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					ErogazioneFemXDecretiObj.DataModifica = d;
				}
				ErogazioneFemXDecretiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ErogazioneFemXDecretiObj.IsDirty = false;
				ErogazioneFemXDecretiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ErogazioneFemXDecreti ErogazioneFemXDecretiObj)
		{
			switch (ErogazioneFemXDecretiObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ErogazioneFemXDecretiObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ErogazioneFemXDecretiObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ErogazioneFemXDecretiObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ErogazioneFemXDecretiCollection ErogazioneFemXDecretiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZErogazioneFemXDecretiUpdate", new string[] {"IdErogazioneXDecreti", "OperatoreCreazione", "DataCreazione", 
"OperatoreModifica", "DataModifica", "IdErogazione", 
"IdDecreto", "Importo", "ImportoAmmesso", 

}, new string[] {"int", "int", "DateTime", 
"int", "DateTime", "int", 
"int", "decimal", "decimal", 

},"");
				IDbCommand insertCmd = db.InitCmd( "ZErogazioneFemXDecretiInsert", new string[] {"OperatoreCreazione", "DataCreazione", 
"OperatoreModifica", "DataModifica", "IdErogazione", 
"IdDecreto", "Importo", "ImportoAmmesso", 

}, new string[] {"int", "DateTime", 
"int", "DateTime", "int", 
"int", "decimal", "decimal", 

},"");
				IDbCommand deleteCmd = db.InitCmd( "ZErogazioneFemXDecretiDelete", new string[] {"IdErogazioneXDecreti"}, new string[] {"int"},"");
				for (int i = 0; i < ErogazioneFemXDecretiCollectionObj.Count; i++)
				{
					switch (ErogazioneFemXDecretiCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ErogazioneFemXDecretiCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ErogazioneFemXDecretiCollectionObj[i].IdErogazioneXDecreti = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_EROGAZIONE_X_DECRETI"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ErogazioneFemXDecretiCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									ErogazioneFemXDecretiCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ErogazioneFemXDecretiCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdErogazioneXDecreti", (SiarLibrary.NullTypes.IntNT)ErogazioneFemXDecretiCollectionObj[i].IdErogazioneXDecreti);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ErogazioneFemXDecretiCollectionObj.Count; i++)
				{
					if ((ErogazioneFemXDecretiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ErogazioneFemXDecretiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ErogazioneFemXDecretiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ErogazioneFemXDecretiCollectionObj[i].IsDirty = false;
						ErogazioneFemXDecretiCollectionObj[i].IsPersistent = true;
					}
					if ((ErogazioneFemXDecretiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ErogazioneFemXDecretiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ErogazioneFemXDecretiCollectionObj[i].IsDirty = false;
						ErogazioneFemXDecretiCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ErogazioneFemXDecreti ErogazioneFemXDecretiObj)
		{
			int returnValue = 0;
			if (ErogazioneFemXDecretiObj.IsPersistent) 
			{
				returnValue = Delete(db, ErogazioneFemXDecretiObj.IdErogazioneXDecreti);
			}
			ErogazioneFemXDecretiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ErogazioneFemXDecretiObj.IsDirty = false;
			ErogazioneFemXDecretiObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdErogazioneXDecretiValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZErogazioneFemXDecretiDelete", new string[] {"IdErogazioneXDecreti"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdErogazioneXDecreti", (SiarLibrary.NullTypes.IntNT)IdErogazioneXDecretiValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ErogazioneFemXDecretiCollection ErogazioneFemXDecretiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZErogazioneFemXDecretiDelete", new string[] {"IdErogazioneXDecreti"}, new string[] {"int"},"");
				for (int i = 0; i < ErogazioneFemXDecretiCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdErogazioneXDecreti", ErogazioneFemXDecretiCollectionObj[i].IdErogazioneXDecreti);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ErogazioneFemXDecretiCollectionObj.Count; i++)
				{
					if ((ErogazioneFemXDecretiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ErogazioneFemXDecretiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ErogazioneFemXDecretiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ErogazioneFemXDecretiCollectionObj[i].IsDirty = false;
						ErogazioneFemXDecretiCollectionObj[i].IsPersistent = false;
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
		public static ErogazioneFemXDecreti GetById(DbProvider db, int IdErogazioneXDecretiValue)
		{
			ErogazioneFemXDecreti ErogazioneFemXDecretiObj = null;
			IDbCommand readCmd = db.InitCmd( "ZErogazioneFemXDecretiGetById", new string[] {"IdErogazioneXDecreti"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdErogazioneXDecreti", (SiarLibrary.NullTypes.IntNT)IdErogazioneXDecretiValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ErogazioneFemXDecretiObj = GetFromDatareader(db);
				ErogazioneFemXDecretiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ErogazioneFemXDecretiObj.IsDirty = false;
				ErogazioneFemXDecretiObj.IsPersistent = true;
			}
			db.Close();
			return ErogazioneFemXDecretiObj;
		}

		//getFromDatareader
		public static ErogazioneFemXDecreti GetFromDatareader(DbProvider db)
		{
			ErogazioneFemXDecreti ErogazioneFemXDecretiObj = new ErogazioneFemXDecreti();
			ErogazioneFemXDecretiObj.IdErogazioneXDecreti = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_EROGAZIONE_X_DECRETI"]);
			ErogazioneFemXDecretiObj.OperatoreCreazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_CREAZIONE"]);
			ErogazioneFemXDecretiObj.DataCreazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CREAZIONE"]);
			ErogazioneFemXDecretiObj.OperatoreModifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_MODIFICA"]);
			ErogazioneFemXDecretiObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			ErogazioneFemXDecretiObj.IdErogazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_EROGAZIONE"]);
			ErogazioneFemXDecretiObj.IdDecreto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DECRETO"]);
			ErogazioneFemXDecretiObj.Importo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO"]);
			ErogazioneFemXDecretiObj.ImportoAmmesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_AMMESSO"]);
			ErogazioneFemXDecretiObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			ErogazioneFemXDecretiObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
			ErogazioneFemXDecretiObj.Numero = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMERO"]);
			ErogazioneFemXDecretiObj.Anticipo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ANTICIPO"]);
			ErogazioneFemXDecretiObj.SogliaContributi = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SOGLIA_CONTRIBUTI"]);
			ErogazioneFemXDecretiObj.SommaMandati = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SOMMA_MANDATI"]);
			ErogazioneFemXDecretiObj.SommaQuietanza = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SOMMA_QUIETANZA"]);
			ErogazioneFemXDecretiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ErogazioneFemXDecretiObj.IsDirty = false;
			ErogazioneFemXDecretiObj.IsPersistent = true;
			return ErogazioneFemXDecretiObj;
		}

		//Find Select

		public static ErogazioneFemXDecretiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdErogazioneXDecretiEqualThis, SiarLibrary.NullTypes.IntNT OperatoreCreazioneEqualThis, SiarLibrary.NullTypes.DatetimeNT DataCreazioneEqualThis, 
SiarLibrary.NullTypes.IntNT OperatoreModificaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.IntNT IdErogazioneEqualThis, 
SiarLibrary.NullTypes.IntNT IdDecretoEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoAmmessoEqualThis)

		{

			ErogazioneFemXDecretiCollection ErogazioneFemXDecretiCollectionObj = new ErogazioneFemXDecretiCollection();

			IDbCommand findCmd = db.InitCmd("Zerogazionefemxdecretifindselect", new string[] {"IdErogazioneXDecretiequalthis", "OperatoreCreazioneequalthis", "DataCreazioneequalthis", 
"OperatoreModificaequalthis", "DataModificaequalthis", "IdErogazioneequalthis", 
"IdDecretoequalthis", "Importoequalthis", "ImportoAmmessoequalthis"}, new string[] {"int", "int", "DateTime", 
"int", "DateTime", "int", 
"int", "decimal", "decimal"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdErogazioneXDecretiequalthis", IdErogazioneXDecretiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreCreazioneequalthis", OperatoreCreazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataCreazioneequalthis", DataCreazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreModificaequalthis", OperatoreModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdErogazioneequalthis", IdErogazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDecretoequalthis", IdDecretoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Importoequalthis", ImportoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoAmmessoequalthis", ImportoAmmessoEqualThis);
			ErogazioneFemXDecreti ErogazioneFemXDecretiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ErogazioneFemXDecretiObj = GetFromDatareader(db);
				ErogazioneFemXDecretiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ErogazioneFemXDecretiObj.IsDirty = false;
				ErogazioneFemXDecretiObj.IsPersistent = true;
				ErogazioneFemXDecretiCollectionObj.Add(ErogazioneFemXDecretiObj);
			}
			db.Close();
			return ErogazioneFemXDecretiCollectionObj;
		}

		//Find FindDecretiErogazione

		public static ErogazioneFemXDecretiCollection FindDecretiErogazione(DbProvider db, SiarLibrary.NullTypes.IntNT IdErogazioneXDecretiEqualThis, SiarLibrary.NullTypes.IntNT IdErogazioneEqualThis, SiarLibrary.NullTypes.IntNT IdDecretoEqualThis, 
SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis)

		{

			ErogazioneFemXDecretiCollection ErogazioneFemXDecretiCollectionObj = new ErogazioneFemXDecretiCollection();

			IDbCommand findCmd = db.InitCmd("Zerogazionefemxdecretifindfinddecretierogazione", new string[] {"IdErogazioneXDecretiequalthis", "IdErogazioneequalthis", "IdDecretoequalthis", 
"IdProgettoequalthis", "IdDomandaPagamentoequalthis"}, new string[] {"int", "int", "int", 
"int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdErogazioneXDecretiequalthis", IdErogazioneXDecretiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdErogazioneequalthis", IdErogazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDecretoequalthis", IdDecretoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			ErogazioneFemXDecreti ErogazioneFemXDecretiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ErogazioneFemXDecretiObj = GetFromDatareader(db);
				ErogazioneFemXDecretiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ErogazioneFemXDecretiObj.IsDirty = false;
				ErogazioneFemXDecretiObj.IsPersistent = true;
				ErogazioneFemXDecretiCollectionObj.Add(ErogazioneFemXDecretiObj);
			}
			db.Close();
			return ErogazioneFemXDecretiCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ErogazioneFemXDecretiCollectionProvider:IErogazioneFemXDecretiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ErogazioneFemXDecretiCollectionProvider : IErogazioneFemXDecretiProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ErogazioneFemXDecreti
		protected ErogazioneFemXDecretiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ErogazioneFemXDecretiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ErogazioneFemXDecretiCollection(this);
		}

		//Costruttore 2: popola la collection
		public ErogazioneFemXDecretiCollectionProvider(IntNT IderogazionexdecretiEqualThis, IntNT IderogazioneEqualThis, IntNT IddecretoEqualThis, 
IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = FindDecretiErogazione(IderogazionexdecretiEqualThis, IderogazioneEqualThis, IddecretoEqualThis, 
IdprogettoEqualThis, IddomandapagamentoEqualThis);
		}

		//Costruttore3: ha in input erogazionefemxdecretiCollectionObj - non popola la collection
		public ErogazioneFemXDecretiCollectionProvider(ErogazioneFemXDecretiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ErogazioneFemXDecretiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ErogazioneFemXDecretiCollection(this);
		}

		//Get e Set
		public ErogazioneFemXDecretiCollection CollectionObj
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
		public int SaveCollection(ErogazioneFemXDecretiCollection collectionObj)
		{
			return ErogazioneFemXDecretiDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ErogazioneFemXDecreti erogazionefemxdecretiObj)
		{
			return ErogazioneFemXDecretiDAL.Save(_dbProviderObj, erogazionefemxdecretiObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ErogazioneFemXDecretiCollection collectionObj)
		{
			return ErogazioneFemXDecretiDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ErogazioneFemXDecreti erogazionefemxdecretiObj)
		{
			return ErogazioneFemXDecretiDAL.Delete(_dbProviderObj, erogazionefemxdecretiObj);
		}

		//getById
		public ErogazioneFemXDecreti GetById(IntNT IdErogazioneXDecretiValue)
		{
			ErogazioneFemXDecreti ErogazioneFemXDecretiTemp = ErogazioneFemXDecretiDAL.GetById(_dbProviderObj, IdErogazioneXDecretiValue);
			if (ErogazioneFemXDecretiTemp!=null) ErogazioneFemXDecretiTemp.Provider = this;
			return ErogazioneFemXDecretiTemp;
		}

		//Select: popola la collection
		public ErogazioneFemXDecretiCollection Select(IntNT IderogazionexdecretiEqualThis, IntNT OperatorecreazioneEqualThis, DatetimeNT DatacreazioneEqualThis, 
IntNT OperatoremodificaEqualThis, DatetimeNT DatamodificaEqualThis, IntNT IderogazioneEqualThis, 
IntNT IddecretoEqualThis, DecimalNT ImportoEqualThis, DecimalNT ImportoammessoEqualThis)
		{
			ErogazioneFemXDecretiCollection ErogazioneFemXDecretiCollectionTemp = ErogazioneFemXDecretiDAL.Select(_dbProviderObj, IderogazionexdecretiEqualThis, OperatorecreazioneEqualThis, DatacreazioneEqualThis, 
OperatoremodificaEqualThis, DatamodificaEqualThis, IderogazioneEqualThis, 
IddecretoEqualThis, ImportoEqualThis, ImportoammessoEqualThis);
			ErogazioneFemXDecretiCollectionTemp.Provider = this;
			return ErogazioneFemXDecretiCollectionTemp;
		}

		//FindDecretiErogazione: popola la collection
		public ErogazioneFemXDecretiCollection FindDecretiErogazione(IntNT IderogazionexdecretiEqualThis, IntNT IderogazioneEqualThis, IntNT IddecretoEqualThis, 
IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis)
		{
			ErogazioneFemXDecretiCollection ErogazioneFemXDecretiCollectionTemp = ErogazioneFemXDecretiDAL.FindDecretiErogazione(_dbProviderObj, IderogazionexdecretiEqualThis, IderogazioneEqualThis, IddecretoEqualThis, 
IdprogettoEqualThis, IddomandapagamentoEqualThis);
			ErogazioneFemXDecretiCollectionTemp.Provider = this;
			return ErogazioneFemXDecretiCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<EROGAZIONE_FEM_X_DECRETI>
  <ViewName>VEROGAZIONE_FEM_X_DECRETI</ViewName>
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
    <FindDecretiErogazione OrderBy="ORDER BY ">
      <ID_EROGAZIONE_X_DECRETI>Equal</ID_EROGAZIONE_X_DECRETI>
      <ID_EROGAZIONE>Equal</ID_EROGAZIONE>
      <ID_DECRETO>Equal</ID_DECRETO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
    </FindDecretiErogazione>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</EROGAZIONE_FEM_X_DECRETI>
*/
