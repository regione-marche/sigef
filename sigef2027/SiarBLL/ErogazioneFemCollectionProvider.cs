using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ErogazioneFem
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IErogazioneFemProvider
	{
		int Save(ErogazioneFem ErogazioneFemObj);
		int SaveCollection(ErogazioneFemCollection collectionObj);
		int Delete(ErogazioneFem ErogazioneFemObj);
		int DeleteCollection(ErogazioneFemCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ErogazioneFem
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ErogazioneFem: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdErogazione;
		private NullTypes.IntNT _OperatoreCreazione;
		private NullTypes.DatetimeNT _DataCreazione;
		private NullTypes.IntNT _OperatoreModifica;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdDomandaPagamento;
		private NullTypes.IntNT _Numero;
		private NullTypes.BoolNT _Anticipo;
		private NullTypes.DecimalNT _SogliaContributi;
		private NullTypes.BoolNT _Definitivo;
		private NullTypes.StringNT _Segnatura;
		private NullTypes.DecimalNT _SommaContratti;
		private NullTypes.DecimalNT _SommaPagamenti;
		private NullTypes.DecimalNT _SommaPagamentiAmmessi;
		private NullTypes.DecimalNT _SommaDecreti;
		private NullTypes.DecimalNT _SommaDecretiAmmessi;
		private NullTypes.DecimalNT _SommaMandati;
		private NullTypes.DecimalNT _SommaQuietanza;
		[NonSerialized] private IErogazioneFemProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IErogazioneFemProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ErogazioneFem()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
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
		/// Corrisponde al campo:DEFINITIVO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Definitivo
		{
			get { return _Definitivo; }
			set {
				if (Definitivo != value)
				{
					_Definitivo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SEGNATURA
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT Segnatura
		{
			get { return _Segnatura; }
			set {
				if (Segnatura != value)
				{
					_Segnatura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SOMMA_CONTRATTI
		/// Tipo sul db:DECIMAL(38,2)
		/// </summary>
		public NullTypes.DecimalNT SommaContratti
		{
			get { return _SommaContratti; }
			set {
				if (SommaContratti != value)
				{
					_SommaContratti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SOMMA_PAGAMENTI
		/// Tipo sul db:DECIMAL(38,2)
		/// </summary>
		public NullTypes.DecimalNT SommaPagamenti
		{
			get { return _SommaPagamenti; }
			set {
				if (SommaPagamenti != value)
				{
					_SommaPagamenti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SOMMA_PAGAMENTI_AMMESSI
		/// Tipo sul db:DECIMAL(38,2)
		/// </summary>
		public NullTypes.DecimalNT SommaPagamentiAmmessi
		{
			get { return _SommaPagamentiAmmessi; }
			set {
				if (SommaPagamentiAmmessi != value)
				{
					_SommaPagamentiAmmessi = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SOMMA_DECRETI
		/// Tipo sul db:DECIMAL(38,2)
		/// </summary>
		public NullTypes.DecimalNT SommaDecreti
		{
			get { return _SommaDecreti; }
			set {
				if (SommaDecreti != value)
				{
					_SommaDecreti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SOMMA_DECRETI_AMMESSI
		/// Tipo sul db:DECIMAL(38,2)
		/// </summary>
		public NullTypes.DecimalNT SommaDecretiAmmessi
		{
			get { return _SommaDecretiAmmessi; }
			set {
				if (SommaDecretiAmmessi != value)
				{
					_SommaDecretiAmmessi = value;
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
	/// Summary description for ErogazioneFemCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ErogazioneFemCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ErogazioneFemCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ErogazioneFem) info.GetValue(i.ToString(),typeof(ErogazioneFem)));
			}
		}

		//Costruttore
		public ErogazioneFemCollection()
		{
			this.ItemType = typeof(ErogazioneFem);
		}

		//Costruttore con provider
		public ErogazioneFemCollection(IErogazioneFemProvider providerObj)
		{
			this.ItemType = typeof(ErogazioneFem);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ErogazioneFem this[int index]
		{
			get { return (ErogazioneFem)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ErogazioneFemCollection GetChanges()
		{
			return (ErogazioneFemCollection) base.GetChanges();
		}

		[NonSerialized] private IErogazioneFemProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IErogazioneFemProvider Provider
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
		public int Add(ErogazioneFem ErogazioneFemObj)
		{
			if (ErogazioneFemObj.Provider == null) ErogazioneFemObj.Provider = this.Provider;
			return base.Add(ErogazioneFemObj);
		}

		//AddCollection
		public void AddCollection(ErogazioneFemCollection ErogazioneFemCollectionObj)
		{
			foreach (ErogazioneFem ErogazioneFemObj in ErogazioneFemCollectionObj)
				this.Add(ErogazioneFemObj);
		}

		//Insert
		public void Insert(int index, ErogazioneFem ErogazioneFemObj)
		{
			if (ErogazioneFemObj.Provider == null) ErogazioneFemObj.Provider = this.Provider;
			base.Insert(index, ErogazioneFemObj);
		}

		//CollectionGetById
		public ErogazioneFem CollectionGetById(NullTypes.IntNT IdErogazioneValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdErogazione == IdErogazioneValue))
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
		public ErogazioneFemCollection SubSelect(NullTypes.IntNT IdErogazioneEqualThis, NullTypes.IntNT OperatoreCreazioneEqualThis, NullTypes.DatetimeNT DataCreazioneEqualThis, 
NullTypes.IntNT OperatoreModificaEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.IntNT IdProgettoEqualThis, 
NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.IntNT NumeroEqualThis, NullTypes.BoolNT AnticipoEqualThis, 
NullTypes.DecimalNT SogliaContributiEqualThis, NullTypes.BoolNT DefinitivoEqualThis, NullTypes.StringNT SegnaturaEqualThis)
		{
			ErogazioneFemCollection ErogazioneFemCollectionTemp = new ErogazioneFemCollection();
			foreach (ErogazioneFem ErogazioneFemItem in this)
			{
				if (((IdErogazioneEqualThis == null) || ((ErogazioneFemItem.IdErogazione != null) && (ErogazioneFemItem.IdErogazione.Value == IdErogazioneEqualThis.Value))) && ((OperatoreCreazioneEqualThis == null) || ((ErogazioneFemItem.OperatoreCreazione != null) && (ErogazioneFemItem.OperatoreCreazione.Value == OperatoreCreazioneEqualThis.Value))) && ((DataCreazioneEqualThis == null) || ((ErogazioneFemItem.DataCreazione != null) && (ErogazioneFemItem.DataCreazione.Value == DataCreazioneEqualThis.Value))) && 
((OperatoreModificaEqualThis == null) || ((ErogazioneFemItem.OperatoreModifica != null) && (ErogazioneFemItem.OperatoreModifica.Value == OperatoreModificaEqualThis.Value))) && ((DataModificaEqualThis == null) || ((ErogazioneFemItem.DataModifica != null) && (ErogazioneFemItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((ErogazioneFemItem.IdProgetto != null) && (ErogazioneFemItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && 
((IdDomandaPagamentoEqualThis == null) || ((ErogazioneFemItem.IdDomandaPagamento != null) && (ErogazioneFemItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((NumeroEqualThis == null) || ((ErogazioneFemItem.Numero != null) && (ErogazioneFemItem.Numero.Value == NumeroEqualThis.Value))) && ((AnticipoEqualThis == null) || ((ErogazioneFemItem.Anticipo != null) && (ErogazioneFemItem.Anticipo.Value == AnticipoEqualThis.Value))) && 
((SogliaContributiEqualThis == null) || ((ErogazioneFemItem.SogliaContributi != null) && (ErogazioneFemItem.SogliaContributi.Value == SogliaContributiEqualThis.Value))) && ((DefinitivoEqualThis == null) || ((ErogazioneFemItem.Definitivo != null) && (ErogazioneFemItem.Definitivo.Value == DefinitivoEqualThis.Value))) && ((SegnaturaEqualThis == null) || ((ErogazioneFemItem.Segnatura != null) && (ErogazioneFemItem.Segnatura.Value == SegnaturaEqualThis.Value))))
				{
					ErogazioneFemCollectionTemp.Add(ErogazioneFemItem);
				}
			}
			return ErogazioneFemCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ErogazioneFemDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ErogazioneFemDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ErogazioneFem ErogazioneFemObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdErogazione", ErogazioneFemObj.IdErogazione);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreCreazione", ErogazioneFemObj.OperatoreCreazione);
			DbProvider.SetCmdParam(cmd,firstChar + "DataCreazione", ErogazioneFemObj.DataCreazione);
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreModifica", ErogazioneFemObj.OperatoreModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", ErogazioneFemObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", ErogazioneFemObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdDomandaPagamento", ErogazioneFemObj.IdDomandaPagamento);
			DbProvider.SetCmdParam(cmd,firstChar + "Numero", ErogazioneFemObj.Numero);
			DbProvider.SetCmdParam(cmd,firstChar + "Anticipo", ErogazioneFemObj.Anticipo);
			DbProvider.SetCmdParam(cmd,firstChar + "SogliaContributi", ErogazioneFemObj.SogliaContributi);
			DbProvider.SetCmdParam(cmd,firstChar + "Definitivo", ErogazioneFemObj.Definitivo);
			DbProvider.SetCmdParam(cmd,firstChar + "Segnatura", ErogazioneFemObj.Segnatura);
		}
		//Insert
		private static int Insert(DbProvider db, ErogazioneFem ErogazioneFemObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZErogazioneFemInsert", new string[] {"OperatoreCreazione", "DataCreazione", 
"OperatoreModifica", "DataModifica", "IdProgetto", 
"IdDomandaPagamento", "Numero", "Anticipo", 
"SogliaContributi", "Definitivo", "Segnatura", 

}, new string[] {"int", "DateTime", 
"int", "DateTime", "int", 
"int", "int", "bool", 
"decimal", "bool", "string", 

},"");
				CompileIUCmd(false, insertCmd,ErogazioneFemObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ErogazioneFemObj.IdErogazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_EROGAZIONE"]);
				}
				ErogazioneFemObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ErogazioneFemObj.IsDirty = false;
				ErogazioneFemObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ErogazioneFem ErogazioneFemObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZErogazioneFemUpdate", new string[] {"IdErogazione", "OperatoreCreazione", "DataCreazione", 
"OperatoreModifica", "DataModifica", "IdProgetto", 
"IdDomandaPagamento", "Numero", "Anticipo", 
"SogliaContributi", "Definitivo", "Segnatura", 

}, new string[] {"int", "int", "DateTime", 
"int", "DateTime", "int", 
"int", "int", "bool", 
"decimal", "bool", "string", 

},"");
				CompileIUCmd(true, updateCmd,ErogazioneFemObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					ErogazioneFemObj.DataModifica = d;
				}
				ErogazioneFemObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ErogazioneFemObj.IsDirty = false;
				ErogazioneFemObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ErogazioneFem ErogazioneFemObj)
		{
			switch (ErogazioneFemObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ErogazioneFemObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ErogazioneFemObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ErogazioneFemObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ErogazioneFemCollection ErogazioneFemCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZErogazioneFemUpdate", new string[] {"IdErogazione", "OperatoreCreazione", "DataCreazione", 
"OperatoreModifica", "DataModifica", "IdProgetto", 
"IdDomandaPagamento", "Numero", "Anticipo", 
"SogliaContributi", "Definitivo", "Segnatura", 

}, new string[] {"int", "int", "DateTime", 
"int", "DateTime", "int", 
"int", "int", "bool", 
"decimal", "bool", "string", 

},"");
				IDbCommand insertCmd = db.InitCmd( "ZErogazioneFemInsert", new string[] {"OperatoreCreazione", "DataCreazione", 
"OperatoreModifica", "DataModifica", "IdProgetto", 
"IdDomandaPagamento", "Numero", "Anticipo", 
"SogliaContributi", "Definitivo", "Segnatura", 

}, new string[] {"int", "DateTime", 
"int", "DateTime", "int", 
"int", "int", "bool", 
"decimal", "bool", "string", 

},"");
				IDbCommand deleteCmd = db.InitCmd( "ZErogazioneFemDelete", new string[] {"IdErogazione"}, new string[] {"int"},"");
				for (int i = 0; i < ErogazioneFemCollectionObj.Count; i++)
				{
					switch (ErogazioneFemCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ErogazioneFemCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ErogazioneFemCollectionObj[i].IdErogazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_EROGAZIONE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ErogazioneFemCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									ErogazioneFemCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ErogazioneFemCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdErogazione", (SiarLibrary.NullTypes.IntNT)ErogazioneFemCollectionObj[i].IdErogazione);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ErogazioneFemCollectionObj.Count; i++)
				{
					if ((ErogazioneFemCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ErogazioneFemCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ErogazioneFemCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ErogazioneFemCollectionObj[i].IsDirty = false;
						ErogazioneFemCollectionObj[i].IsPersistent = true;
					}
					if ((ErogazioneFemCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ErogazioneFemCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ErogazioneFemCollectionObj[i].IsDirty = false;
						ErogazioneFemCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ErogazioneFem ErogazioneFemObj)
		{
			int returnValue = 0;
			if (ErogazioneFemObj.IsPersistent) 
			{
				returnValue = Delete(db, ErogazioneFemObj.IdErogazione);
			}
			ErogazioneFemObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ErogazioneFemObj.IsDirty = false;
			ErogazioneFemObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdErogazioneValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZErogazioneFemDelete", new string[] {"IdErogazione"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdErogazione", (SiarLibrary.NullTypes.IntNT)IdErogazioneValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ErogazioneFemCollection ErogazioneFemCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZErogazioneFemDelete", new string[] {"IdErogazione"}, new string[] {"int"},"");
				for (int i = 0; i < ErogazioneFemCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdErogazione", ErogazioneFemCollectionObj[i].IdErogazione);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ErogazioneFemCollectionObj.Count; i++)
				{
					if ((ErogazioneFemCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ErogazioneFemCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ErogazioneFemCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ErogazioneFemCollectionObj[i].IsDirty = false;
						ErogazioneFemCollectionObj[i].IsPersistent = false;
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
		public static ErogazioneFem GetById(DbProvider db, int IdErogazioneValue)
		{
			ErogazioneFem ErogazioneFemObj = null;
			IDbCommand readCmd = db.InitCmd( "ZErogazioneFemGetById", new string[] {"IdErogazione"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdErogazione", (SiarLibrary.NullTypes.IntNT)IdErogazioneValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ErogazioneFemObj = GetFromDatareader(db);
				ErogazioneFemObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ErogazioneFemObj.IsDirty = false;
				ErogazioneFemObj.IsPersistent = true;
			}
			db.Close();
			return ErogazioneFemObj;
		}

		//getFromDatareader
		public static ErogazioneFem GetFromDatareader(DbProvider db)
		{
			ErogazioneFem ErogazioneFemObj = new ErogazioneFem();
			ErogazioneFemObj.IdErogazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_EROGAZIONE"]);
			ErogazioneFemObj.OperatoreCreazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_CREAZIONE"]);
			ErogazioneFemObj.DataCreazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CREAZIONE"]);
			ErogazioneFemObj.OperatoreModifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_MODIFICA"]);
			ErogazioneFemObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			ErogazioneFemObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			ErogazioneFemObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
			ErogazioneFemObj.Numero = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMERO"]);
			ErogazioneFemObj.Anticipo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ANTICIPO"]);
			ErogazioneFemObj.SogliaContributi = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SOGLIA_CONTRIBUTI"]);
			ErogazioneFemObj.Definitivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DEFINITIVO"]);
			ErogazioneFemObj.Segnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA"]);
			ErogazioneFemObj.SommaContratti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SOMMA_CONTRATTI"]);
			ErogazioneFemObj.SommaPagamenti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SOMMA_PAGAMENTI"]);
			ErogazioneFemObj.SommaPagamentiAmmessi = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SOMMA_PAGAMENTI_AMMESSI"]);
			ErogazioneFemObj.SommaDecreti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SOMMA_DECRETI"]);
			ErogazioneFemObj.SommaDecretiAmmessi = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SOMMA_DECRETI_AMMESSI"]);
			ErogazioneFemObj.SommaMandati = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SOMMA_MANDATI"]);
			ErogazioneFemObj.SommaQuietanza = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SOMMA_QUIETANZA"]);
			ErogazioneFemObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ErogazioneFemObj.IsDirty = false;
			ErogazioneFemObj.IsPersistent = true;
			return ErogazioneFemObj;
		}

		//Find Select

		public static ErogazioneFemCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdErogazioneEqualThis, SiarLibrary.NullTypes.IntNT OperatoreCreazioneEqualThis, SiarLibrary.NullTypes.DatetimeNT DataCreazioneEqualThis, 
SiarLibrary.NullTypes.IntNT OperatoreModificaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, 
SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT NumeroEqualThis, SiarLibrary.NullTypes.BoolNT AnticipoEqualThis, 
SiarLibrary.NullTypes.DecimalNT SogliaContributiEqualThis, SiarLibrary.NullTypes.BoolNT DefinitivoEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaEqualThis)

		{

			ErogazioneFemCollection ErogazioneFemCollectionObj = new ErogazioneFemCollection();

			IDbCommand findCmd = db.InitCmd("Zerogazionefemfindselect", new string[] {"IdErogazioneequalthis", "OperatoreCreazioneequalthis", "DataCreazioneequalthis", 
"OperatoreModificaequalthis", "DataModificaequalthis", "IdProgettoequalthis", 
"IdDomandaPagamentoequalthis", "Numeroequalthis", "Anticipoequalthis", 
"SogliaContributiequalthis", "Definitivoequalthis", "Segnaturaequalthis"}, new string[] {"int", "int", "DateTime", 
"int", "DateTime", "int", 
"int", "int", "bool", 
"decimal", "bool", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdErogazioneequalthis", IdErogazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreCreazioneequalthis", OperatoreCreazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataCreazioneequalthis", DataCreazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreModificaequalthis", OperatoreModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Numeroequalthis", NumeroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Anticipoequalthis", AnticipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SogliaContributiequalthis", SogliaContributiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Definitivoequalthis", DefinitivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Segnaturaequalthis", SegnaturaEqualThis);
			ErogazioneFem ErogazioneFemObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ErogazioneFemObj = GetFromDatareader(db);
				ErogazioneFemObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ErogazioneFemObj.IsDirty = false;
				ErogazioneFemObj.IsPersistent = true;
				ErogazioneFemCollectionObj.Add(ErogazioneFemObj);
			}
			db.Close();
			return ErogazioneFemCollectionObj;
		}

		//Find FindErogazioni

		public static ErogazioneFemCollection FindErogazioni(DbProvider db, SiarLibrary.NullTypes.IntNT IdErogazioneEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, 
SiarLibrary.NullTypes.IntNT NumeroEqualThis, SiarLibrary.NullTypes.BoolNT AnticipoEqualThis, SiarLibrary.NullTypes.BoolNT DefinitivoEqualThis)

		{

			ErogazioneFemCollection ErogazioneFemCollectionObj = new ErogazioneFemCollection();

			IDbCommand findCmd = db.InitCmd("Zerogazionefemfindfinderogazioni", new string[] {"IdErogazioneequalthis", "IdProgettoequalthis", "IdDomandaPagamentoequalthis", 
"Numeroequalthis", "Anticipoequalthis", "Definitivoequalthis"}, new string[] {"int", "int", "int", 
"int", "bool", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdErogazioneequalthis", IdErogazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Numeroequalthis", NumeroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Anticipoequalthis", AnticipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Definitivoequalthis", DefinitivoEqualThis);
			ErogazioneFem ErogazioneFemObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ErogazioneFemObj = GetFromDatareader(db);
				ErogazioneFemObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ErogazioneFemObj.IsDirty = false;
				ErogazioneFemObj.IsPersistent = true;
				ErogazioneFemCollectionObj.Add(ErogazioneFemObj);
			}
			db.Close();
			return ErogazioneFemCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ErogazioneFemCollectionProvider:IErogazioneFemProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ErogazioneFemCollectionProvider : IErogazioneFemProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ErogazioneFem
		protected ErogazioneFemCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ErogazioneFemCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ErogazioneFemCollection(this);
		}

		//Costruttore 2: popola la collection
		public ErogazioneFemCollectionProvider(IntNT IderogazioneEqualThis, IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis, 
IntNT NumeroEqualThis, BoolNT AnticipoEqualThis, BoolNT DefinitivoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = FindErogazioni(IderogazioneEqualThis, IdprogettoEqualThis, IddomandapagamentoEqualThis, 
NumeroEqualThis, AnticipoEqualThis, DefinitivoEqualThis);
		}

		//Costruttore3: ha in input erogazionefemCollectionObj - non popola la collection
		public ErogazioneFemCollectionProvider(ErogazioneFemCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ErogazioneFemCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ErogazioneFemCollection(this);
		}

		//Get e Set
		public ErogazioneFemCollection CollectionObj
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
		public int SaveCollection(ErogazioneFemCollection collectionObj)
		{
			return ErogazioneFemDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ErogazioneFem erogazionefemObj)
		{
			return ErogazioneFemDAL.Save(_dbProviderObj, erogazionefemObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ErogazioneFemCollection collectionObj)
		{
			return ErogazioneFemDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ErogazioneFem erogazionefemObj)
		{
			return ErogazioneFemDAL.Delete(_dbProviderObj, erogazionefemObj);
		}

		//getById
		public ErogazioneFem GetById(IntNT IdErogazioneValue)
		{
			ErogazioneFem ErogazioneFemTemp = ErogazioneFemDAL.GetById(_dbProviderObj, IdErogazioneValue);
			if (ErogazioneFemTemp!=null) ErogazioneFemTemp.Provider = this;
			return ErogazioneFemTemp;
		}

		//Select: popola la collection
		public ErogazioneFemCollection Select(IntNT IderogazioneEqualThis, IntNT OperatorecreazioneEqualThis, DatetimeNT DatacreazioneEqualThis, 
IntNT OperatoremodificaEqualThis, DatetimeNT DatamodificaEqualThis, IntNT IdprogettoEqualThis, 
IntNT IddomandapagamentoEqualThis, IntNT NumeroEqualThis, BoolNT AnticipoEqualThis, 
DecimalNT SogliacontributiEqualThis, BoolNT DefinitivoEqualThis, StringNT SegnaturaEqualThis)
		{
			ErogazioneFemCollection ErogazioneFemCollectionTemp = ErogazioneFemDAL.Select(_dbProviderObj, IderogazioneEqualThis, OperatorecreazioneEqualThis, DatacreazioneEqualThis, 
OperatoremodificaEqualThis, DatamodificaEqualThis, IdprogettoEqualThis, 
IddomandapagamentoEqualThis, NumeroEqualThis, AnticipoEqualThis, 
SogliacontributiEqualThis, DefinitivoEqualThis, SegnaturaEqualThis);
			ErogazioneFemCollectionTemp.Provider = this;
			return ErogazioneFemCollectionTemp;
		}

		//FindErogazioni: popola la collection
		public ErogazioneFemCollection FindErogazioni(IntNT IderogazioneEqualThis, IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis, 
IntNT NumeroEqualThis, BoolNT AnticipoEqualThis, BoolNT DefinitivoEqualThis)
		{
			ErogazioneFemCollection ErogazioneFemCollectionTemp = ErogazioneFemDAL.FindErogazioni(_dbProviderObj, IderogazioneEqualThis, IdprogettoEqualThis, IddomandapagamentoEqualThis, 
NumeroEqualThis, AnticipoEqualThis, DefinitivoEqualThis);
			ErogazioneFemCollectionTemp.Provider = this;
			return ErogazioneFemCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<EROGAZIONE_FEM>
  <ViewName>VEROGAZIONE_FEM</ViewName>
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
    <FindErogazioni OrderBy="ORDER BY NUMERO ">
      <ID_EROGAZIONE>Equal</ID_EROGAZIONE>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <NUMERO>Equal</NUMERO>
      <ANTICIPO>Equal</ANTICIPO>
      <DEFINITIVO>Equal</DEFINITIVO>
    </FindErogazioni>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</EROGAZIONE_FEM>
*/
