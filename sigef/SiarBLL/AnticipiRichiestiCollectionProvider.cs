using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per AnticipiRichiesti
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IAnticipiRichiestiProvider
	{
		int Save(AnticipiRichiesti AnticipiRichiestiObj);
		int SaveCollection(AnticipiRichiestiCollection collectionObj);
		int Delete(AnticipiRichiesti AnticipiRichiestiObj);
		int DeleteCollection(AnticipiRichiestiCollection collectionObj);
	}
	/// <summary>
	/// Summary description for AnticipiRichiesti
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class AnticipiRichiesti: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdAnticipo;
		private NullTypes.IntNT _IdDomandaPagamento;
		private NullTypes.IntNT _IdBando;
		private NullTypes.DatetimeNT _DataRichiesta;
		private NullTypes.DecimalNT _ContributoRichiesto;
		private NullTypes.DecimalNT _ContributoAmmesso;
		private NullTypes.BoolNT _Ammesso;
		private NullTypes.StringNT _Istruttore;
		private NullTypes.DatetimeNT _DataValutazione;
		[NonSerialized] private IAnticipiRichiestiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IAnticipiRichiestiProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public AnticipiRichiesti()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_ANTICIPO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdAnticipo
		{
			get { return _IdAnticipo; }
			set {
				if (IdAnticipo != value)
				{
					_IdAnticipo = value;
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
		/// Corrisponde al campo:DATA_RICHIESTA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataRichiesta
		{
			get { return _DataRichiesta; }
			set {
				if (DataRichiesta != value)
				{
					_DataRichiesta = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTRIBUTO_RICHIESTO
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ContributoRichiesto
		{
			get { return _ContributoRichiesto; }
			set {
				if (ContributoRichiesto != value)
				{
					_ContributoRichiesto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTRIBUTO_AMMESSO
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ContributoAmmesso
		{
			get { return _ContributoAmmesso; }
			set {
				if (ContributoAmmesso != value)
				{
					_ContributoAmmesso = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:AMMESSO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Ammesso
		{
			get { return _Ammesso; }
			set {
				if (Ammesso != value)
				{
					_Ammesso = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ISTRUTTORE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT Istruttore
		{
			get { return _Istruttore; }
			set {
				if (Istruttore != value)
				{
					_Istruttore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_VALUTAZIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataValutazione
		{
			get { return _DataValutazione; }
			set {
				if (DataValutazione != value)
				{
					_DataValutazione = value;
					SetDirtyFlag();
				}
			}
		}


		//Get e Set dei campi 'ForeignKey'

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
	/// Summary description for AnticipiRichiestiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class AnticipiRichiestiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private AnticipiRichiestiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((AnticipiRichiesti) info.GetValue(i.ToString(),typeof(AnticipiRichiesti)));
			}
		}

		//Costruttore
		public AnticipiRichiestiCollection()
		{
			this.ItemType = typeof(AnticipiRichiesti);
		}

		//Costruttore con provider
		public AnticipiRichiestiCollection(IAnticipiRichiestiProvider providerObj)
		{
			this.ItemType = typeof(AnticipiRichiesti);
			this.Provider = providerObj;
		}

		//Get e Set
		public new AnticipiRichiesti this[int index]
		{
			get { return (AnticipiRichiesti)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new AnticipiRichiestiCollection GetChanges()
		{
			return (AnticipiRichiestiCollection) base.GetChanges();
		}

		[NonSerialized] private IAnticipiRichiestiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IAnticipiRichiestiProvider Provider
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
		public int Add(AnticipiRichiesti AnticipiRichiestiObj)
		{
			if (AnticipiRichiestiObj.Provider == null) AnticipiRichiestiObj.Provider = this.Provider;
			return base.Add(AnticipiRichiestiObj);
		}

		//AddCollection
		public void AddCollection(AnticipiRichiestiCollection AnticipiRichiestiCollectionObj)
		{
			foreach (AnticipiRichiesti AnticipiRichiestiObj in AnticipiRichiestiCollectionObj)
				this.Add(AnticipiRichiestiObj);
		}

		//Insert
		public void Insert(int index, AnticipiRichiesti AnticipiRichiestiObj)
		{
			if (AnticipiRichiestiObj.Provider == null) AnticipiRichiestiObj.Provider = this.Provider;
			base.Insert(index, AnticipiRichiestiObj);
		}

		//CollectionGetById
		public AnticipiRichiesti CollectionGetById(NullTypes.IntNT IdAnticipoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdAnticipo == IdAnticipoValue))
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
		public AnticipiRichiestiCollection SubSelect(NullTypes.IntNT IdAnticipoEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.IntNT IdBandoEqualThis, 
NullTypes.DatetimeNT DataRichiestaEqualThis, NullTypes.DecimalNT ContributoRichiestoEqualThis, NullTypes.DecimalNT ContributoAmmessoEqualThis, 
NullTypes.BoolNT AmmessoEqualThis, NullTypes.StringNT IstruttoreEqualThis, NullTypes.DatetimeNT DataValutazioneEqualThis)
		{
			AnticipiRichiestiCollection AnticipiRichiestiCollectionTemp = new AnticipiRichiestiCollection();
			foreach (AnticipiRichiesti AnticipiRichiestiItem in this)
			{
				if (((IdAnticipoEqualThis == null) || ((AnticipiRichiestiItem.IdAnticipo != null) && (AnticipiRichiestiItem.IdAnticipo.Value == IdAnticipoEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((AnticipiRichiestiItem.IdDomandaPagamento != null) && (AnticipiRichiestiItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((IdBandoEqualThis == null) || ((AnticipiRichiestiItem.IdBando != null) && (AnticipiRichiestiItem.IdBando.Value == IdBandoEqualThis.Value))) && 
((DataRichiestaEqualThis == null) || ((AnticipiRichiestiItem.DataRichiesta != null) && (AnticipiRichiestiItem.DataRichiesta.Value == DataRichiestaEqualThis.Value))) && ((ContributoRichiestoEqualThis == null) || ((AnticipiRichiestiItem.ContributoRichiesto != null) && (AnticipiRichiestiItem.ContributoRichiesto.Value == ContributoRichiestoEqualThis.Value))) && ((ContributoAmmessoEqualThis == null) || ((AnticipiRichiestiItem.ContributoAmmesso != null) && (AnticipiRichiestiItem.ContributoAmmesso.Value == ContributoAmmessoEqualThis.Value))) && 
((AmmessoEqualThis == null) || ((AnticipiRichiestiItem.Ammesso != null) && (AnticipiRichiestiItem.Ammesso.Value == AmmessoEqualThis.Value))) && ((IstruttoreEqualThis == null) || ((AnticipiRichiestiItem.Istruttore != null) && (AnticipiRichiestiItem.Istruttore.Value == IstruttoreEqualThis.Value))) && ((DataValutazioneEqualThis == null) || ((AnticipiRichiestiItem.DataValutazione != null) && (AnticipiRichiestiItem.DataValutazione.Value == DataValutazioneEqualThis.Value))))
				{
					AnticipiRichiestiCollectionTemp.Add(AnticipiRichiestiItem);
				}
			}
			return AnticipiRichiestiCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for AnticipiRichiestiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class AnticipiRichiestiDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, AnticipiRichiesti AnticipiRichiestiObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdAnticipo", AnticipiRichiestiObj.IdAnticipo);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdDomandaPagamento", AnticipiRichiestiObj.IdDomandaPagamento);
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", AnticipiRichiestiObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "DataRichiesta", AnticipiRichiestiObj.DataRichiesta);
			DbProvider.SetCmdParam(cmd,firstChar + "ContributoRichiesto", AnticipiRichiestiObj.ContributoRichiesto);
			DbProvider.SetCmdParam(cmd,firstChar + "ContributoAmmesso", AnticipiRichiestiObj.ContributoAmmesso);
			DbProvider.SetCmdParam(cmd,firstChar + "Ammesso", AnticipiRichiestiObj.Ammesso);
			DbProvider.SetCmdParam(cmd,firstChar + "Istruttore", AnticipiRichiestiObj.Istruttore);
			DbProvider.SetCmdParam(cmd,firstChar + "DataValutazione", AnticipiRichiestiObj.DataValutazione);
		}
		//Insert
		private static int Insert(DbProvider db, AnticipiRichiesti AnticipiRichiestiObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZAnticipiRichiestiInsert", new string[] {"IdDomandaPagamento", "IdBando", 
"DataRichiesta", "ContributoRichiesto", "ContributoAmmesso", 
"Ammesso", "Istruttore", "DataValutazione"}, new string[] {"int", "int", 
"DateTime", "decimal", "decimal", 
"bool", "string", "DateTime"},"");
				CompileIUCmd(false, insertCmd,AnticipiRichiestiObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				AnticipiRichiestiObj.IdAnticipo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ANTICIPO"]);
				}
				AnticipiRichiestiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AnticipiRichiestiObj.IsDirty = false;
				AnticipiRichiestiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, AnticipiRichiesti AnticipiRichiestiObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZAnticipiRichiestiUpdate", new string[] {"IdAnticipo", "IdDomandaPagamento", "IdBando", 
"DataRichiesta", "ContributoRichiesto", "ContributoAmmesso", 
"Ammesso", "Istruttore", "DataValutazione"}, new string[] {"int", "int", "int", 
"DateTime", "decimal", "decimal", 
"bool", "string", "DateTime"},"");
				CompileIUCmd(true, updateCmd,AnticipiRichiestiObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				AnticipiRichiestiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AnticipiRichiestiObj.IsDirty = false;
				AnticipiRichiestiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, AnticipiRichiesti AnticipiRichiestiObj)
		{
			switch (AnticipiRichiestiObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, AnticipiRichiestiObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, AnticipiRichiestiObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,AnticipiRichiestiObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, AnticipiRichiestiCollection AnticipiRichiestiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZAnticipiRichiestiUpdate", new string[] {"IdAnticipo", "IdDomandaPagamento", "IdBando", 
"DataRichiesta", "ContributoRichiesto", "ContributoAmmesso", 
"Ammesso", "Istruttore", "DataValutazione"}, new string[] {"int", "int", "int", 
"DateTime", "decimal", "decimal", 
"bool", "string", "DateTime"},"");
				IDbCommand insertCmd = db.InitCmd( "ZAnticipiRichiestiInsert", new string[] {"IdDomandaPagamento", "IdBando", 
"DataRichiesta", "ContributoRichiesto", "ContributoAmmesso", 
"Ammesso", "Istruttore", "DataValutazione"}, new string[] {"int", "int", 
"DateTime", "decimal", "decimal", 
"bool", "string", "DateTime"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZAnticipiRichiestiDelete", new string[] {"IdAnticipo"}, new string[] {"int"},"");
				for (int i = 0; i < AnticipiRichiestiCollectionObj.Count; i++)
				{
					switch (AnticipiRichiestiCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,AnticipiRichiestiCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									AnticipiRichiestiCollectionObj[i].IdAnticipo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ANTICIPO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,AnticipiRichiestiCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (AnticipiRichiestiCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdAnticipo", (SiarLibrary.NullTypes.IntNT)AnticipiRichiestiCollectionObj[i].IdAnticipo);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < AnticipiRichiestiCollectionObj.Count; i++)
				{
					if ((AnticipiRichiestiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (AnticipiRichiestiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						AnticipiRichiestiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						AnticipiRichiestiCollectionObj[i].IsDirty = false;
						AnticipiRichiestiCollectionObj[i].IsPersistent = true;
					}
					if ((AnticipiRichiestiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						AnticipiRichiestiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						AnticipiRichiestiCollectionObj[i].IsDirty = false;
						AnticipiRichiestiCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, AnticipiRichiesti AnticipiRichiestiObj)
		{
			int returnValue = 0;
			if (AnticipiRichiestiObj.IsPersistent) 
			{
				returnValue = Delete(db, AnticipiRichiestiObj.IdAnticipo);
			}
			AnticipiRichiestiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			AnticipiRichiestiObj.IsDirty = false;
			AnticipiRichiestiObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdAnticipoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZAnticipiRichiestiDelete", new string[] {"IdAnticipo"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdAnticipo", (SiarLibrary.NullTypes.IntNT)IdAnticipoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, AnticipiRichiestiCollection AnticipiRichiestiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZAnticipiRichiestiDelete", new string[] {"IdAnticipo"}, new string[] {"int"},"");
				for (int i = 0; i < AnticipiRichiestiCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdAnticipo", AnticipiRichiestiCollectionObj[i].IdAnticipo);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < AnticipiRichiestiCollectionObj.Count; i++)
				{
					if ((AnticipiRichiestiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (AnticipiRichiestiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						AnticipiRichiestiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						AnticipiRichiestiCollectionObj[i].IsDirty = false;
						AnticipiRichiestiCollectionObj[i].IsPersistent = false;
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
		public static AnticipiRichiesti GetById(DbProvider db, int IdAnticipoValue)
		{
			AnticipiRichiesti AnticipiRichiestiObj = null;
			IDbCommand readCmd = db.InitCmd( "ZAnticipiRichiestiGetById", new string[] {"IdAnticipo"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdAnticipo", (SiarLibrary.NullTypes.IntNT)IdAnticipoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				AnticipiRichiestiObj = GetFromDatareader(db);
				AnticipiRichiestiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AnticipiRichiestiObj.IsDirty = false;
				AnticipiRichiestiObj.IsPersistent = true;
			}
			db.Close();
			return AnticipiRichiestiObj;
		}

		//getFromDatareader
		public static AnticipiRichiesti GetFromDatareader(DbProvider db)
		{
			AnticipiRichiesti AnticipiRichiestiObj = new AnticipiRichiesti();
			AnticipiRichiestiObj.IdAnticipo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ANTICIPO"]);
			AnticipiRichiestiObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
			AnticipiRichiestiObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			AnticipiRichiestiObj.DataRichiesta = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_RICHIESTA"]);
			AnticipiRichiestiObj.ContributoRichiesto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_RICHIESTO"]);
			AnticipiRichiestiObj.ContributoAmmesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_AMMESSO"]);
			AnticipiRichiestiObj.Ammesso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AMMESSO"]);
			AnticipiRichiestiObj.Istruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["ISTRUTTORE"]);
			AnticipiRichiestiObj.DataValutazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_VALUTAZIONE"]);
			AnticipiRichiestiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			AnticipiRichiestiObj.IsDirty = false;
			AnticipiRichiestiObj.IsPersistent = true;
			return AnticipiRichiestiObj;
		}

		//Find Select

		public static AnticipiRichiestiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdAnticipoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataRichiestaEqualThis, SiarLibrary.NullTypes.DecimalNT ContributoRichiestoEqualThis, SiarLibrary.NullTypes.DecimalNT ContributoAmmessoEqualThis, 
SiarLibrary.NullTypes.BoolNT AmmessoEqualThis, SiarLibrary.NullTypes.StringNT IstruttoreEqualThis, SiarLibrary.NullTypes.DatetimeNT DataValutazioneEqualThis)

		{

			AnticipiRichiestiCollection AnticipiRichiestiCollectionObj = new AnticipiRichiestiCollection();

			IDbCommand findCmd = db.InitCmd("Zanticipirichiestifindselect", new string[] {"IdAnticipoequalthis", "IdDomandaPagamentoequalthis", "IdBandoequalthis", 
"DataRichiestaequalthis", "ContributoRichiestoequalthis", "ContributoAmmessoequalthis", 
"Ammessoequalthis", "Istruttoreequalthis", "DataValutazioneequalthis"}, new string[] {"int", "int", "int", 
"DateTime", "decimal", "decimal", 
"bool", "string", "DateTime"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAnticipoequalthis", IdAnticipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataRichiestaequalthis", DataRichiestaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ContributoRichiestoequalthis", ContributoRichiestoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ContributoAmmessoequalthis", ContributoAmmessoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ammessoequalthis", AmmessoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Istruttoreequalthis", IstruttoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataValutazioneequalthis", DataValutazioneEqualThis);
			AnticipiRichiesti AnticipiRichiestiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				AnticipiRichiestiObj = GetFromDatareader(db);
				AnticipiRichiestiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AnticipiRichiestiObj.IsDirty = false;
				AnticipiRichiestiObj.IsPersistent = true;
				AnticipiRichiestiCollectionObj.Add(AnticipiRichiestiObj);
			}
			db.Close();
			return AnticipiRichiestiCollectionObj;
		}

		//Find Find

		public static AnticipiRichiestiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdAnticipoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis)

		{

			AnticipiRichiestiCollection AnticipiRichiestiCollectionObj = new AnticipiRichiestiCollection();

			IDbCommand findCmd = db.InitCmd("Zanticipirichiestifindfind", new string[] {"IdAnticipoequalthis", "IdDomandaPagamentoequalthis", "IdBandoequalthis"}, new string[] {"int", "int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAnticipoequalthis", IdAnticipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			AnticipiRichiesti AnticipiRichiestiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				AnticipiRichiestiObj = GetFromDatareader(db);
				AnticipiRichiestiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AnticipiRichiestiObj.IsDirty = false;
				AnticipiRichiestiObj.IsPersistent = true;
				AnticipiRichiestiCollectionObj.Add(AnticipiRichiestiObj);
			}
			db.Close();
			return AnticipiRichiestiCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for AnticipiRichiestiCollectionProvider:IAnticipiRichiestiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class AnticipiRichiestiCollectionProvider : IAnticipiRichiestiProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di AnticipiRichiesti
		protected AnticipiRichiestiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public AnticipiRichiestiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new AnticipiRichiestiCollection(this);
		}

		//Costruttore 2: popola la collection
		public AnticipiRichiestiCollectionProvider(IntNT IdanticipoEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdbandoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdanticipoEqualThis, IddomandapagamentoEqualThis, IdbandoEqualThis);
		}

		//Costruttore3: ha in input anticipirichiestiCollectionObj - non popola la collection
		public AnticipiRichiestiCollectionProvider(AnticipiRichiestiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public AnticipiRichiestiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new AnticipiRichiestiCollection(this);
		}

		//Get e Set
		public AnticipiRichiestiCollection CollectionObj
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
		public int SaveCollection(AnticipiRichiestiCollection collectionObj)
		{
			return AnticipiRichiestiDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(AnticipiRichiesti anticipirichiestiObj)
		{
			return AnticipiRichiestiDAL.Save(_dbProviderObj, anticipirichiestiObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(AnticipiRichiestiCollection collectionObj)
		{
			return AnticipiRichiestiDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(AnticipiRichiesti anticipirichiestiObj)
		{
			return AnticipiRichiestiDAL.Delete(_dbProviderObj, anticipirichiestiObj);
		}

		//getById
		public AnticipiRichiesti GetById(IntNT IdAnticipoValue)
		{
			AnticipiRichiesti AnticipiRichiestiTemp = AnticipiRichiestiDAL.GetById(_dbProviderObj, IdAnticipoValue);
			if (AnticipiRichiestiTemp!=null) AnticipiRichiestiTemp.Provider = this;
			return AnticipiRichiestiTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public AnticipiRichiestiCollection Select(IntNT IdanticipoEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdbandoEqualThis, 
DatetimeNT DatarichiestaEqualThis, DecimalNT ContributorichiestoEqualThis, DecimalNT ContributoammessoEqualThis, 
BoolNT AmmessoEqualThis, StringNT IstruttoreEqualThis, DatetimeNT DatavalutazioneEqualThis)
		{
			AnticipiRichiestiCollection AnticipiRichiestiCollectionTemp = AnticipiRichiestiDAL.Select(_dbProviderObj, IdanticipoEqualThis, IddomandapagamentoEqualThis, IdbandoEqualThis, 
DatarichiestaEqualThis, ContributorichiestoEqualThis, ContributoammessoEqualThis, 
AmmessoEqualThis, IstruttoreEqualThis, DatavalutazioneEqualThis);
			AnticipiRichiestiCollectionTemp.Provider = this;
			return AnticipiRichiestiCollectionTemp;
		}

		//Find: popola la collection
		public AnticipiRichiestiCollection Find(IntNT IdanticipoEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdbandoEqualThis)
		{
			AnticipiRichiestiCollection AnticipiRichiestiCollectionTemp = AnticipiRichiestiDAL.Find(_dbProviderObj, IdanticipoEqualThis, IddomandapagamentoEqualThis, IdbandoEqualThis);
			AnticipiRichiestiCollectionTemp.Provider = this;
			return AnticipiRichiestiCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<ANTICIPI_RICHIESTI>
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
      <ID_ANTICIPO>Equal</ID_ANTICIPO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_BANDO>Equal</ID_BANDO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</ANTICIPI_RICHIESTI>
*/
