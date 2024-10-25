using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per AutModificaPercAiuto
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IAutModificaPercAiutoProvider
	{
		int Save(AutModificaPercAiuto AutModificaPercAiutoObj);
		int SaveCollection(AutModificaPercAiutoCollection collectionObj);
		int Delete(AutModificaPercAiuto AutModificaPercAiutoObj);
		int DeleteCollection(AutModificaPercAiutoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for AutModificaPercAiuto
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class AutModificaPercAiuto: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdAutorizzazione;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.StringNT _CfInserimento;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.StringNT _CfModifica;
		private NullTypes.IntNT _IdInvestimento;
		private NullTypes.DecimalNT _CostoInvestimentoPrecedente;
		private NullTypes.DecimalNT _CostoInvestimentoAutorizzato;
		private NullTypes.DecimalNT _QuantitaPrecedente;
		private NullTypes.DecimalNT _QuantitaAutorizzata;
		private NullTypes.DecimalNT _PercPrecedente;
		private NullTypes.DecimalNT _PercAutorizzata;
		[NonSerialized] private IAutModificaPercAiutoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IAutModificaPercAiutoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public AutModificaPercAiuto()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_AUTORIZZAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdAutorizzazione
		{
			get { return _IdAutorizzazione; }
			set {
				if (IdAutorizzazione != value)
				{
					_IdAutorizzazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_INSERIMENTO
		/// Tipo sul db:DATETIME
		/// Default:(getdate())
		/// </summary>
		public NullTypes.DatetimeNT DataInserimento
		{
			get { return _DataInserimento; }
			set {
				if (DataInserimento != value)
				{
					_DataInserimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_INSERIMENTO
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT CfInserimento
		{
			get { return _CfInserimento; }
			set {
				if (CfInserimento != value)
				{
					_CfInserimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_MODIFICA
		/// Tipo sul db:DATETIME
		/// Default:(getdate())
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
		/// Corrisponde al campo:CF_MODIFICA
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT CfModifica
		{
			get { return _CfModifica; }
			set {
				if (CfModifica != value)
				{
					_CfModifica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_INVESTIMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdInvestimento
		{
			get { return _IdInvestimento; }
			set {
				if (IdInvestimento != value)
				{
					_IdInvestimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COSTO_INVESTIMENTO_PRECEDENTE
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT CostoInvestimentoPrecedente
		{
			get { return _CostoInvestimentoPrecedente; }
			set {
				if (CostoInvestimentoPrecedente != value)
				{
					_CostoInvestimentoPrecedente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COSTO_INVESTIMENTO_AUTORIZZATO
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT CostoInvestimentoAutorizzato
		{
			get { return _CostoInvestimentoAutorizzato; }
			set {
				if (CostoInvestimentoAutorizzato != value)
				{
					_CostoInvestimentoAutorizzato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUANTITA_PRECEDENTE
		/// Tipo sul db:DECIMAL(10,2)
		/// </summary>
		public NullTypes.DecimalNT QuantitaPrecedente
		{
			get { return _QuantitaPrecedente; }
			set {
				if (QuantitaPrecedente != value)
				{
					_QuantitaPrecedente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUANTITA_AUTORIZZATA
		/// Tipo sul db:DECIMAL(10,2)
		/// </summary>
		public NullTypes.DecimalNT QuantitaAutorizzata
		{
			get { return _QuantitaAutorizzata; }
			set {
				if (QuantitaAutorizzata != value)
				{
					_QuantitaAutorizzata = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PERC_PRECEDENTE
		/// Tipo sul db:DECIMAL(15,12)
		/// </summary>
		public NullTypes.DecimalNT PercPrecedente
		{
			get { return _PercPrecedente; }
			set {
				if (PercPrecedente != value)
				{
					_PercPrecedente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PERC_AUTORIZZATA
		/// Tipo sul db:DECIMAL(15,12)
		/// </summary>
		public NullTypes.DecimalNT PercAutorizzata
		{
			get { return _PercAutorizzata; }
			set {
				if (PercAutorizzata != value)
				{
					_PercAutorizzata = value;
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
	/// Summary description for AutModificaPercAiutoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class AutModificaPercAiutoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private AutModificaPercAiutoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((AutModificaPercAiuto) info.GetValue(i.ToString(),typeof(AutModificaPercAiuto)));
			}
		}

		//Costruttore
		public AutModificaPercAiutoCollection()
		{
			this.ItemType = typeof(AutModificaPercAiuto);
		}

		//Costruttore con provider
		public AutModificaPercAiutoCollection(IAutModificaPercAiutoProvider providerObj)
		{
			this.ItemType = typeof(AutModificaPercAiuto);
			this.Provider = providerObj;
		}

		//Get e Set
		public new AutModificaPercAiuto this[int index]
		{
			get { return (AutModificaPercAiuto)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new AutModificaPercAiutoCollection GetChanges()
		{
			return (AutModificaPercAiutoCollection) base.GetChanges();
		}

		[NonSerialized] private IAutModificaPercAiutoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IAutModificaPercAiutoProvider Provider
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
		public int Add(AutModificaPercAiuto AutModificaPercAiutoObj)
		{
			if (AutModificaPercAiutoObj.Provider == null) AutModificaPercAiutoObj.Provider = this.Provider;
			return base.Add(AutModificaPercAiutoObj);
		}

		//AddCollection
		public void AddCollection(AutModificaPercAiutoCollection AutModificaPercAiutoCollectionObj)
		{
			foreach (AutModificaPercAiuto AutModificaPercAiutoObj in AutModificaPercAiutoCollectionObj)
				this.Add(AutModificaPercAiutoObj);
		}

		//Insert
		public void Insert(int index, AutModificaPercAiuto AutModificaPercAiutoObj)
		{
			if (AutModificaPercAiutoObj.Provider == null) AutModificaPercAiutoObj.Provider = this.Provider;
			base.Insert(index, AutModificaPercAiutoObj);
		}

		//CollectionGetById
		public AutModificaPercAiuto CollectionGetById(NullTypes.IntNT IdAutorizzazioneValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdAutorizzazione == IdAutorizzazioneValue))
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
		public AutModificaPercAiutoCollection SubSelect(NullTypes.IntNT IdAutorizzazioneEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.StringNT CfInserimentoEqualThis, 
NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.StringNT CfModificaEqualThis, NullTypes.IntNT IdInvestimentoEqualThis, 
NullTypes.DecimalNT CostoInvestimentoPrecedenteEqualThis, NullTypes.DecimalNT CostoInvestimentoAutorizzatoEqualThis, NullTypes.DecimalNT QuantitaPrecedenteEqualThis, 
NullTypes.DecimalNT QuantitaAutorizzataEqualThis, NullTypes.DecimalNT PercPrecedenteEqualThis, NullTypes.DecimalNT PercAutorizzataEqualThis)
		{
			AutModificaPercAiutoCollection AutModificaPercAiutoCollectionTemp = new AutModificaPercAiutoCollection();
			foreach (AutModificaPercAiuto AutModificaPercAiutoItem in this)
			{
				if (((IdAutorizzazioneEqualThis == null) || ((AutModificaPercAiutoItem.IdAutorizzazione != null) && (AutModificaPercAiutoItem.IdAutorizzazione.Value == IdAutorizzazioneEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((AutModificaPercAiutoItem.DataInserimento != null) && (AutModificaPercAiutoItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((CfInserimentoEqualThis == null) || ((AutModificaPercAiutoItem.CfInserimento != null) && (AutModificaPercAiutoItem.CfInserimento.Value == CfInserimentoEqualThis.Value))) && 
((DataModificaEqualThis == null) || ((AutModificaPercAiutoItem.DataModifica != null) && (AutModificaPercAiutoItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((CfModificaEqualThis == null) || ((AutModificaPercAiutoItem.CfModifica != null) && (AutModificaPercAiutoItem.CfModifica.Value == CfModificaEqualThis.Value))) && ((IdInvestimentoEqualThis == null) || ((AutModificaPercAiutoItem.IdInvestimento != null) && (AutModificaPercAiutoItem.IdInvestimento.Value == IdInvestimentoEqualThis.Value))) && 
((CostoInvestimentoPrecedenteEqualThis == null) || ((AutModificaPercAiutoItem.CostoInvestimentoPrecedente != null) && (AutModificaPercAiutoItem.CostoInvestimentoPrecedente.Value == CostoInvestimentoPrecedenteEqualThis.Value))) && ((CostoInvestimentoAutorizzatoEqualThis == null) || ((AutModificaPercAiutoItem.CostoInvestimentoAutorizzato != null) && (AutModificaPercAiutoItem.CostoInvestimentoAutorizzato.Value == CostoInvestimentoAutorizzatoEqualThis.Value))) && ((QuantitaPrecedenteEqualThis == null) || ((AutModificaPercAiutoItem.QuantitaPrecedente != null) && (AutModificaPercAiutoItem.QuantitaPrecedente.Value == QuantitaPrecedenteEqualThis.Value))) && 
((QuantitaAutorizzataEqualThis == null) || ((AutModificaPercAiutoItem.QuantitaAutorizzata != null) && (AutModificaPercAiutoItem.QuantitaAutorizzata.Value == QuantitaAutorizzataEqualThis.Value))) && ((PercPrecedenteEqualThis == null) || ((AutModificaPercAiutoItem.PercPrecedente != null) && (AutModificaPercAiutoItem.PercPrecedente.Value == PercPrecedenteEqualThis.Value))) && ((PercAutorizzataEqualThis == null) || ((AutModificaPercAiutoItem.PercAutorizzata != null) && (AutModificaPercAiutoItem.PercAutorizzata.Value == PercAutorizzataEqualThis.Value))))
				{
					AutModificaPercAiutoCollectionTemp.Add(AutModificaPercAiutoItem);
				}
			}
			return AutModificaPercAiutoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for AutModificaPercAiutoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class AutModificaPercAiutoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, AutModificaPercAiuto AutModificaPercAiutoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdAutorizzazione", AutModificaPercAiutoObj.IdAutorizzazione);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", AutModificaPercAiutoObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "CfInserimento", AutModificaPercAiutoObj.CfInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", AutModificaPercAiutoObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "CfModifica", AutModificaPercAiutoObj.CfModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "IdInvestimento", AutModificaPercAiutoObj.IdInvestimento);
			DbProvider.SetCmdParam(cmd,firstChar + "CostoInvestimentoPrecedente", AutModificaPercAiutoObj.CostoInvestimentoPrecedente);
			DbProvider.SetCmdParam(cmd,firstChar + "CostoInvestimentoAutorizzato", AutModificaPercAiutoObj.CostoInvestimentoAutorizzato);
			DbProvider.SetCmdParam(cmd,firstChar + "QuantitaPrecedente", AutModificaPercAiutoObj.QuantitaPrecedente);
			DbProvider.SetCmdParam(cmd,firstChar + "QuantitaAutorizzata", AutModificaPercAiutoObj.QuantitaAutorizzata);
			DbProvider.SetCmdParam(cmd,firstChar + "PercPrecedente", AutModificaPercAiutoObj.PercPrecedente);
			DbProvider.SetCmdParam(cmd,firstChar + "PercAutorizzata", AutModificaPercAiutoObj.PercAutorizzata);
		}
		//Insert
		private static int Insert(DbProvider db, AutModificaPercAiuto AutModificaPercAiutoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZAutModificaPercAiutoInsert", new string[] {"DataInserimento", "CfInserimento", 
"DataModifica", "CfModifica", "IdInvestimento", 
"CostoInvestimentoPrecedente", "CostoInvestimentoAutorizzato", "QuantitaPrecedente", 
"QuantitaAutorizzata", "PercPrecedente", "PercAutorizzata"}, new string[] {"DateTime", "string", 
"DateTime", "string", "int", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal"},"");
				CompileIUCmd(false, insertCmd,AutModificaPercAiutoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				AutModificaPercAiutoObj.IdAutorizzazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_AUTORIZZAZIONE"]);
				AutModificaPercAiutoObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
				AutModificaPercAiutoObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
				}
				AutModificaPercAiutoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AutModificaPercAiutoObj.IsDirty = false;
				AutModificaPercAiutoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, AutModificaPercAiuto AutModificaPercAiutoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZAutModificaPercAiutoUpdate", new string[] {"IdAutorizzazione", "DataInserimento", "CfInserimento", 
"DataModifica", "CfModifica", "IdInvestimento", 
"CostoInvestimentoPrecedente", "CostoInvestimentoAutorizzato", "QuantitaPrecedente", 
"QuantitaAutorizzata", "PercPrecedente", "PercAutorizzata"}, new string[] {"int", "DateTime", "string", 
"DateTime", "string", "int", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal"},"");
				CompileIUCmd(true, updateCmd,AutModificaPercAiutoObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					AutModificaPercAiutoObj.DataModifica = d;
				}
				AutModificaPercAiutoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AutModificaPercAiutoObj.IsDirty = false;
				AutModificaPercAiutoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, AutModificaPercAiuto AutModificaPercAiutoObj)
		{
			switch (AutModificaPercAiutoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, AutModificaPercAiutoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, AutModificaPercAiutoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,AutModificaPercAiutoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, AutModificaPercAiutoCollection AutModificaPercAiutoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZAutModificaPercAiutoUpdate", new string[] {"IdAutorizzazione", "DataInserimento", "CfInserimento", 
"DataModifica", "CfModifica", "IdInvestimento", 
"CostoInvestimentoPrecedente", "CostoInvestimentoAutorizzato", "QuantitaPrecedente", 
"QuantitaAutorizzata", "PercPrecedente", "PercAutorizzata"}, new string[] {"int", "DateTime", "string", 
"DateTime", "string", "int", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal"},"");
				IDbCommand insertCmd = db.InitCmd( "ZAutModificaPercAiutoInsert", new string[] {"DataInserimento", "CfInserimento", 
"DataModifica", "CfModifica", "IdInvestimento", 
"CostoInvestimentoPrecedente", "CostoInvestimentoAutorizzato", "QuantitaPrecedente", 
"QuantitaAutorizzata", "PercPrecedente", "PercAutorizzata"}, new string[] {"DateTime", "string", 
"DateTime", "string", "int", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZAutModificaPercAiutoDelete", new string[] {"IdAutorizzazione"}, new string[] {"int"},"");
				for (int i = 0; i < AutModificaPercAiutoCollectionObj.Count; i++)
				{
					switch (AutModificaPercAiutoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,AutModificaPercAiutoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									AutModificaPercAiutoCollectionObj[i].IdAutorizzazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_AUTORIZZAZIONE"]);
									AutModificaPercAiutoCollectionObj[i].DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
									AutModificaPercAiutoCollectionObj[i].DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,AutModificaPercAiutoCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									AutModificaPercAiutoCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (AutModificaPercAiutoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdAutorizzazione", (SiarLibrary.NullTypes.IntNT)AutModificaPercAiutoCollectionObj[i].IdAutorizzazione);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < AutModificaPercAiutoCollectionObj.Count; i++)
				{
					if ((AutModificaPercAiutoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (AutModificaPercAiutoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						AutModificaPercAiutoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						AutModificaPercAiutoCollectionObj[i].IsDirty = false;
						AutModificaPercAiutoCollectionObj[i].IsPersistent = true;
					}
					if ((AutModificaPercAiutoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						AutModificaPercAiutoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						AutModificaPercAiutoCollectionObj[i].IsDirty = false;
						AutModificaPercAiutoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, AutModificaPercAiuto AutModificaPercAiutoObj)
		{
			int returnValue = 0;
			if (AutModificaPercAiutoObj.IsPersistent) 
			{
				returnValue = Delete(db, AutModificaPercAiutoObj.IdAutorizzazione);
			}
			AutModificaPercAiutoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			AutModificaPercAiutoObj.IsDirty = false;
			AutModificaPercAiutoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdAutorizzazioneValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZAutModificaPercAiutoDelete", new string[] {"IdAutorizzazione"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdAutorizzazione", (SiarLibrary.NullTypes.IntNT)IdAutorizzazioneValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, AutModificaPercAiutoCollection AutModificaPercAiutoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZAutModificaPercAiutoDelete", new string[] {"IdAutorizzazione"}, new string[] {"int"},"");
				for (int i = 0; i < AutModificaPercAiutoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdAutorizzazione", AutModificaPercAiutoCollectionObj[i].IdAutorizzazione);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < AutModificaPercAiutoCollectionObj.Count; i++)
				{
					if ((AutModificaPercAiutoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (AutModificaPercAiutoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						AutModificaPercAiutoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						AutModificaPercAiutoCollectionObj[i].IsDirty = false;
						AutModificaPercAiutoCollectionObj[i].IsPersistent = false;
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
		public static AutModificaPercAiuto GetById(DbProvider db, int IdAutorizzazioneValue)
		{
			AutModificaPercAiuto AutModificaPercAiutoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZAutModificaPercAiutoGetById", new string[] {"IdAutorizzazione"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdAutorizzazione", (SiarLibrary.NullTypes.IntNT)IdAutorizzazioneValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				AutModificaPercAiutoObj = GetFromDatareader(db);
				AutModificaPercAiutoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AutModificaPercAiutoObj.IsDirty = false;
				AutModificaPercAiutoObj.IsPersistent = true;
			}
			db.Close();
			return AutModificaPercAiutoObj;
		}

		//getFromDatareader
		public static AutModificaPercAiuto GetFromDatareader(DbProvider db)
		{
			AutModificaPercAiuto AutModificaPercAiutoObj = new AutModificaPercAiuto();
			AutModificaPercAiutoObj.IdAutorizzazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_AUTORIZZAZIONE"]);
			AutModificaPercAiutoObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			AutModificaPercAiutoObj.CfInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_INSERIMENTO"]);
			AutModificaPercAiutoObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			AutModificaPercAiutoObj.CfModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_MODIFICA"]);
			AutModificaPercAiutoObj.IdInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INVESTIMENTO"]);
			AutModificaPercAiutoObj.CostoInvestimentoPrecedente = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["COSTO_INVESTIMENTO_PRECEDENTE"]);
			AutModificaPercAiutoObj.CostoInvestimentoAutorizzato = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["COSTO_INVESTIMENTO_AUTORIZZATO"]);
			AutModificaPercAiutoObj.QuantitaPrecedente = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUANTITA_PRECEDENTE"]);
			AutModificaPercAiutoObj.QuantitaAutorizzata = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUANTITA_AUTORIZZATA"]);
			AutModificaPercAiutoObj.PercPrecedente = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PERC_PRECEDENTE"]);
			AutModificaPercAiutoObj.PercAutorizzata = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PERC_AUTORIZZATA"]);
			AutModificaPercAiutoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			AutModificaPercAiutoObj.IsDirty = false;
			AutModificaPercAiutoObj.IsPersistent = true;
			return AutModificaPercAiutoObj;
		}

		//Find Select

		public static AutModificaPercAiutoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdAutorizzazioneEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.StringNT CfInserimentoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.StringNT CfModificaEqualThis, SiarLibrary.NullTypes.IntNT IdInvestimentoEqualThis, 
SiarLibrary.NullTypes.DecimalNT CostoInvestimentoPrecedenteEqualThis, SiarLibrary.NullTypes.DecimalNT CostoInvestimentoAutorizzatoEqualThis, SiarLibrary.NullTypes.DecimalNT QuantitaPrecedenteEqualThis, 
SiarLibrary.NullTypes.DecimalNT QuantitaAutorizzataEqualThis, SiarLibrary.NullTypes.DecimalNT PercPrecedenteEqualThis, SiarLibrary.NullTypes.DecimalNT PercAutorizzataEqualThis)

		{

			AutModificaPercAiutoCollection AutModificaPercAiutoCollectionObj = new AutModificaPercAiutoCollection();

			IDbCommand findCmd = db.InitCmd("Zautmodificapercaiutofindselect", new string[] {"IdAutorizzazioneequalthis", "DataInserimentoequalthis", "CfInserimentoequalthis", 
"DataModificaequalthis", "CfModificaequalthis", "IdInvestimentoequalthis", 
"CostoInvestimentoPrecedenteequalthis", "CostoInvestimentoAutorizzatoequalthis", "QuantitaPrecedenteequalthis", 
"QuantitaAutorizzataequalthis", "PercPrecedenteequalthis", "PercAutorizzataequalthis"}, new string[] {"int", "DateTime", "string", 
"DateTime", "string", "int", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAutorizzazioneequalthis", IdAutorizzazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfInserimentoequalthis", CfInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfModificaequalthis", CfModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdInvestimentoequalthis", IdInvestimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CostoInvestimentoPrecedenteequalthis", CostoInvestimentoPrecedenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CostoInvestimentoAutorizzatoequalthis", CostoInvestimentoAutorizzatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "QuantitaPrecedenteequalthis", QuantitaPrecedenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "QuantitaAutorizzataequalthis", QuantitaAutorizzataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PercPrecedenteequalthis", PercPrecedenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PercAutorizzataequalthis", PercAutorizzataEqualThis);
			AutModificaPercAiuto AutModificaPercAiutoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				AutModificaPercAiutoObj = GetFromDatareader(db);
				AutModificaPercAiutoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AutModificaPercAiutoObj.IsDirty = false;
				AutModificaPercAiutoObj.IsPersistent = true;
				AutModificaPercAiutoCollectionObj.Add(AutModificaPercAiutoObj);
			}
			db.Close();
			return AutModificaPercAiutoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for AutModificaPercAiutoCollectionProvider:IAutModificaPercAiutoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class AutModificaPercAiutoCollectionProvider : IAutModificaPercAiutoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di AutModificaPercAiuto
		protected AutModificaPercAiutoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public AutModificaPercAiutoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new AutModificaPercAiutoCollection(this);
		}

		//Costruttore3: ha in input autmodificapercaiutoCollectionObj - non popola la collection
		public AutModificaPercAiutoCollectionProvider(AutModificaPercAiutoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public AutModificaPercAiutoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new AutModificaPercAiutoCollection(this);
		}

		//Get e Set
		public AutModificaPercAiutoCollection CollectionObj
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
		public int SaveCollection(AutModificaPercAiutoCollection collectionObj)
		{
			return AutModificaPercAiutoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(AutModificaPercAiuto autmodificapercaiutoObj)
		{
			return AutModificaPercAiutoDAL.Save(_dbProviderObj, autmodificapercaiutoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(AutModificaPercAiutoCollection collectionObj)
		{
			return AutModificaPercAiutoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(AutModificaPercAiuto autmodificapercaiutoObj)
		{
			return AutModificaPercAiutoDAL.Delete(_dbProviderObj, autmodificapercaiutoObj);
		}

		//getById
		public AutModificaPercAiuto GetById(IntNT IdAutorizzazioneValue)
		{
			AutModificaPercAiuto AutModificaPercAiutoTemp = AutModificaPercAiutoDAL.GetById(_dbProviderObj, IdAutorizzazioneValue);
			if (AutModificaPercAiutoTemp!=null) AutModificaPercAiutoTemp.Provider = this;
			return AutModificaPercAiutoTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public AutModificaPercAiutoCollection Select(IntNT IdautorizzazioneEqualThis, DatetimeNT DatainserimentoEqualThis, StringNT CfinserimentoEqualThis, 
DatetimeNT DatamodificaEqualThis, StringNT CfmodificaEqualThis, IntNT IdinvestimentoEqualThis, 
DecimalNT CostoinvestimentoprecedenteEqualThis, DecimalNT CostoinvestimentoautorizzatoEqualThis, DecimalNT QuantitaprecedenteEqualThis, 
DecimalNT QuantitaautorizzataEqualThis, DecimalNT PercprecedenteEqualThis, DecimalNT PercautorizzataEqualThis)
		{
			AutModificaPercAiutoCollection AutModificaPercAiutoCollectionTemp = AutModificaPercAiutoDAL.Select(_dbProviderObj, IdautorizzazioneEqualThis, DatainserimentoEqualThis, CfinserimentoEqualThis, 
DatamodificaEqualThis, CfmodificaEqualThis, IdinvestimentoEqualThis, 
CostoinvestimentoprecedenteEqualThis, CostoinvestimentoautorizzatoEqualThis, QuantitaprecedenteEqualThis, 
QuantitaautorizzataEqualThis, PercprecedenteEqualThis, PercautorizzataEqualThis);
			AutModificaPercAiutoCollectionTemp.Provider = this;
			return AutModificaPercAiutoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<AUT_MODIFICA_PERC_AIUTO>
  <ViewName>VAUT_MODIFICA_PERC_AUTO</ViewName>
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
</AUT_MODIFICA_PERC_AIUTO>
*/
