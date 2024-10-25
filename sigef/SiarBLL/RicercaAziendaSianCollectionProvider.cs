using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per RicercaAziendaSian
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IRicercaAziendaSianProvider
	{
		int Save(RicercaAziendaSian RicercaAziendaSianObj);
		int SaveCollection(RicercaAziendaSianCollection collectionObj);
		int Delete(RicercaAziendaSian RicercaAziendaSianObj);
		int DeleteCollection(RicercaAziendaSianCollection collectionObj);
	}
	/// <summary>
	/// Summary description for RicercaAziendaSian
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class RicercaAziendaSian: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdRicerca;
		private NullTypes.IntNT _OperatoreInserimento;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.StringNT _PivaControllo;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.DatetimeNT _DataUltimoControllo;
		private NullTypes.IntNT _IdBloccoControllo;
		private NullTypes.BoolNT _DaControllare;
		private NullTypes.StringNT _Esito;
		private NullTypes.StringNT _RagioneSociale;
		private NullTypes.StringNT _CuaaImpresa;
		private NullTypes.StringNT _CodiceFiscaleImpresa;
		[NonSerialized] private IRicercaAziendaSianProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRicercaAziendaSianProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public RicercaAziendaSian()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_RICERCA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdRicerca
		{
			get { return _IdRicerca; }
			set {
				if (IdRicerca != value)
				{
					_IdRicerca = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE_INSERIMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OperatoreInserimento
		{
			get { return _OperatoreInserimento; }
			set {
				if (OperatoreInserimento != value)
				{
					_OperatoreInserimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_INSERIMENTO
		/// Tipo sul db:DATETIME
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
		/// Corrisponde al campo:PIVA_CONTROLLO
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT PivaControllo
		{
			get { return _PivaControllo; }
			set {
				if (PivaControllo != value)
				{
					_PivaControllo = value;
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
		/// Corrisponde al campo:DATA_ULTIMO_CONTROLLO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataUltimoControllo
		{
			get { return _DataUltimoControllo; }
			set {
				if (DataUltimoControllo != value)
				{
					_DataUltimoControllo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_BLOCCO_CONTROLLO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdBloccoControllo
		{
			get { return _IdBloccoControllo; }
			set {
				if (IdBloccoControllo != value)
				{
					_IdBloccoControllo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DA_CONTROLLARE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT DaControllare
		{
			get { return _DaControllare; }
			set {
				if (DaControllare != value)
				{
					_DaControllare = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ESITO
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT Esito
		{
			get { return _Esito; }
			set {
				if (Esito != value)
				{
					_Esito = value;
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
		/// Corrisponde al campo:CUAA_IMPRESA
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CuaaImpresa
		{
			get { return _CuaaImpresa; }
			set {
				if (CuaaImpresa != value)
				{
					_CuaaImpresa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE_FISCALE_IMPRESA
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CodiceFiscaleImpresa
		{
			get { return _CodiceFiscaleImpresa; }
			set {
				if (CodiceFiscaleImpresa != value)
				{
					_CodiceFiscaleImpresa = value;
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
	/// Summary description for RicercaAziendaSianCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RicercaAziendaSianCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private RicercaAziendaSianCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((RicercaAziendaSian) info.GetValue(i.ToString(),typeof(RicercaAziendaSian)));
			}
		}

		//Costruttore
		public RicercaAziendaSianCollection()
		{
			this.ItemType = typeof(RicercaAziendaSian);
		}

		//Costruttore con provider
		public RicercaAziendaSianCollection(IRicercaAziendaSianProvider providerObj)
		{
			this.ItemType = typeof(RicercaAziendaSian);
			this.Provider = providerObj;
		}

		//Get e Set
		public new RicercaAziendaSian this[int index]
		{
			get { return (RicercaAziendaSian)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new RicercaAziendaSianCollection GetChanges()
		{
			return (RicercaAziendaSianCollection) base.GetChanges();
		}

		[NonSerialized] private IRicercaAziendaSianProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRicercaAziendaSianProvider Provider
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
		public int Add(RicercaAziendaSian RicercaAziendaSianObj)
		{
			if (RicercaAziendaSianObj.Provider == null) RicercaAziendaSianObj.Provider = this.Provider;
			return base.Add(RicercaAziendaSianObj);
		}

		//AddCollection
		public void AddCollection(RicercaAziendaSianCollection RicercaAziendaSianCollectionObj)
		{
			foreach (RicercaAziendaSian RicercaAziendaSianObj in RicercaAziendaSianCollectionObj)
				this.Add(RicercaAziendaSianObj);
		}

		//Insert
		public void Insert(int index, RicercaAziendaSian RicercaAziendaSianObj)
		{
			if (RicercaAziendaSianObj.Provider == null) RicercaAziendaSianObj.Provider = this.Provider;
			base.Insert(index, RicercaAziendaSianObj);
		}

		//CollectionGetById
		public RicercaAziendaSian CollectionGetById(NullTypes.IntNT IdRicercaValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdRicerca == IdRicercaValue))
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
		public RicercaAziendaSianCollection SubSelect(NullTypes.IntNT IdRicercaEqualThis, NullTypes.IntNT OperatoreInserimentoEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, 
NullTypes.StringNT PivaControlloEqualThis, NullTypes.IntNT IdImpresaEqualThis, NullTypes.DatetimeNT DataUltimoControlloEqualThis, 
NullTypes.IntNT IdBloccoControlloEqualThis, NullTypes.BoolNT DaControllareEqualThis, NullTypes.StringNT EsitoEqualThis)
		{
			RicercaAziendaSianCollection RicercaAziendaSianCollectionTemp = new RicercaAziendaSianCollection();
			foreach (RicercaAziendaSian RicercaAziendaSianItem in this)
			{
				if (((IdRicercaEqualThis == null) || ((RicercaAziendaSianItem.IdRicerca != null) && (RicercaAziendaSianItem.IdRicerca.Value == IdRicercaEqualThis.Value))) && ((OperatoreInserimentoEqualThis == null) || ((RicercaAziendaSianItem.OperatoreInserimento != null) && (RicercaAziendaSianItem.OperatoreInserimento.Value == OperatoreInserimentoEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((RicercaAziendaSianItem.DataInserimento != null) && (RicercaAziendaSianItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && 
((PivaControlloEqualThis == null) || ((RicercaAziendaSianItem.PivaControllo != null) && (RicercaAziendaSianItem.PivaControllo.Value == PivaControlloEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((RicercaAziendaSianItem.IdImpresa != null) && (RicercaAziendaSianItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((DataUltimoControlloEqualThis == null) || ((RicercaAziendaSianItem.DataUltimoControllo != null) && (RicercaAziendaSianItem.DataUltimoControllo.Value == DataUltimoControlloEqualThis.Value))) && 
((IdBloccoControlloEqualThis == null) || ((RicercaAziendaSianItem.IdBloccoControllo != null) && (RicercaAziendaSianItem.IdBloccoControllo.Value == IdBloccoControlloEqualThis.Value))) && ((DaControllareEqualThis == null) || ((RicercaAziendaSianItem.DaControllare != null) && (RicercaAziendaSianItem.DaControllare.Value == DaControllareEqualThis.Value))) && ((EsitoEqualThis == null) || ((RicercaAziendaSianItem.Esito != null) && (RicercaAziendaSianItem.Esito.Value == EsitoEqualThis.Value))))
				{
					RicercaAziendaSianCollectionTemp.Add(RicercaAziendaSianItem);
				}
			}
			return RicercaAziendaSianCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for RicercaAziendaSianDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class RicercaAziendaSianDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, RicercaAziendaSian RicercaAziendaSianObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdRicerca", RicercaAziendaSianObj.IdRicerca);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreInserimento", RicercaAziendaSianObj.OperatoreInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", RicercaAziendaSianObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "PivaControllo", RicercaAziendaSianObj.PivaControllo);
			DbProvider.SetCmdParam(cmd,firstChar + "IdImpresa", RicercaAziendaSianObj.IdImpresa);
			DbProvider.SetCmdParam(cmd,firstChar + "DataUltimoControllo", RicercaAziendaSianObj.DataUltimoControllo);
			DbProvider.SetCmdParam(cmd,firstChar + "IdBloccoControllo", RicercaAziendaSianObj.IdBloccoControllo);
			DbProvider.SetCmdParam(cmd,firstChar + "DaControllare", RicercaAziendaSianObj.DaControllare);
			DbProvider.SetCmdParam(cmd,firstChar + "Esito", RicercaAziendaSianObj.Esito);
		}
		//Insert
		private static int Insert(DbProvider db, RicercaAziendaSian RicercaAziendaSianObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZRicercaAziendaSianInsert", new string[] {"OperatoreInserimento", "DataInserimento", 
"PivaControllo", "IdImpresa", "DataUltimoControllo", 
"IdBloccoControllo", "DaControllare", "Esito", }, new string[] {"int", "DateTime", 
"string", "int", "DateTime", 
"int", "bool", "string", },"");
				CompileIUCmd(false, insertCmd,RicercaAziendaSianObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				RicercaAziendaSianObj.IdRicerca = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RICERCA"]);
				}
				RicercaAziendaSianObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RicercaAziendaSianObj.IsDirty = false;
				RicercaAziendaSianObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, RicercaAziendaSian RicercaAziendaSianObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRicercaAziendaSianUpdate", new string[] {"IdRicerca", "OperatoreInserimento", "DataInserimento", 
"PivaControllo", "IdImpresa", "DataUltimoControllo", 
"IdBloccoControllo", "DaControllare", "Esito", }, new string[] {"int", "int", "DateTime", 
"string", "int", "DateTime", 
"int", "bool", "string", },"");
				CompileIUCmd(true, updateCmd,RicercaAziendaSianObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				RicercaAziendaSianObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RicercaAziendaSianObj.IsDirty = false;
				RicercaAziendaSianObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, RicercaAziendaSian RicercaAziendaSianObj)
		{
			switch (RicercaAziendaSianObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, RicercaAziendaSianObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, RicercaAziendaSianObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,RicercaAziendaSianObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, RicercaAziendaSianCollection RicercaAziendaSianCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRicercaAziendaSianUpdate", new string[] {"IdRicerca", "OperatoreInserimento", "DataInserimento", 
"PivaControllo", "IdImpresa", "DataUltimoControllo", 
"IdBloccoControllo", "DaControllare", "Esito", }, new string[] {"int", "int", "DateTime", 
"string", "int", "DateTime", 
"int", "bool", "string", },"");
				IDbCommand insertCmd = db.InitCmd( "ZRicercaAziendaSianInsert", new string[] {"OperatoreInserimento", "DataInserimento", 
"PivaControllo", "IdImpresa", "DataUltimoControllo", 
"IdBloccoControllo", "DaControllare", "Esito", }, new string[] {"int", "DateTime", 
"string", "int", "DateTime", 
"int", "bool", "string", },"");
				IDbCommand deleteCmd = db.InitCmd( "ZRicercaAziendaSianDelete", new string[] {"IdRicerca"}, new string[] {"int"},"");
				for (int i = 0; i < RicercaAziendaSianCollectionObj.Count; i++)
				{
					switch (RicercaAziendaSianCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,RicercaAziendaSianCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									RicercaAziendaSianCollectionObj[i].IdRicerca = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RICERCA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,RicercaAziendaSianCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (RicercaAziendaSianCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRicerca", (SiarLibrary.NullTypes.IntNT)RicercaAziendaSianCollectionObj[i].IdRicerca);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < RicercaAziendaSianCollectionObj.Count; i++)
				{
					if ((RicercaAziendaSianCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RicercaAziendaSianCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RicercaAziendaSianCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						RicercaAziendaSianCollectionObj[i].IsDirty = false;
						RicercaAziendaSianCollectionObj[i].IsPersistent = true;
					}
					if ((RicercaAziendaSianCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						RicercaAziendaSianCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RicercaAziendaSianCollectionObj[i].IsDirty = false;
						RicercaAziendaSianCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, RicercaAziendaSian RicercaAziendaSianObj)
		{
			int returnValue = 0;
			if (RicercaAziendaSianObj.IsPersistent) 
			{
				returnValue = Delete(db, RicercaAziendaSianObj.IdRicerca);
			}
			RicercaAziendaSianObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			RicercaAziendaSianObj.IsDirty = false;
			RicercaAziendaSianObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdRicercaValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRicercaAziendaSianDelete", new string[] {"IdRicerca"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRicerca", (SiarLibrary.NullTypes.IntNT)IdRicercaValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, RicercaAziendaSianCollection RicercaAziendaSianCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRicercaAziendaSianDelete", new string[] {"IdRicerca"}, new string[] {"int"},"");
				for (int i = 0; i < RicercaAziendaSianCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRicerca", RicercaAziendaSianCollectionObj[i].IdRicerca);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < RicercaAziendaSianCollectionObj.Count; i++)
				{
					if ((RicercaAziendaSianCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RicercaAziendaSianCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RicercaAziendaSianCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RicercaAziendaSianCollectionObj[i].IsDirty = false;
						RicercaAziendaSianCollectionObj[i].IsPersistent = false;
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
		public static RicercaAziendaSian GetById(DbProvider db, int IdRicercaValue)
		{
			RicercaAziendaSian RicercaAziendaSianObj = null;
			IDbCommand readCmd = db.InitCmd( "ZRicercaAziendaSianGetById", new string[] {"IdRicerca"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdRicerca", (SiarLibrary.NullTypes.IntNT)IdRicercaValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				RicercaAziendaSianObj = GetFromDatareader(db);
				RicercaAziendaSianObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RicercaAziendaSianObj.IsDirty = false;
				RicercaAziendaSianObj.IsPersistent = true;
			}
			db.Close();
			return RicercaAziendaSianObj;
		}

		//getFromDatareader
		public static RicercaAziendaSian GetFromDatareader(DbProvider db)
		{
			RicercaAziendaSian RicercaAziendaSianObj = new RicercaAziendaSian();
			RicercaAziendaSianObj.IdRicerca = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RICERCA"]);
			RicercaAziendaSianObj.OperatoreInserimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_INSERIMENTO"]);
			RicercaAziendaSianObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			RicercaAziendaSianObj.PivaControllo = new SiarLibrary.NullTypes.StringNT(db.DataReader["PIVA_CONTROLLO"]);
			RicercaAziendaSianObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			RicercaAziendaSianObj.DataUltimoControllo = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_ULTIMO_CONTROLLO"]);
			RicercaAziendaSianObj.IdBloccoControllo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BLOCCO_CONTROLLO"]);
			RicercaAziendaSianObj.DaControllare = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DA_CONTROLLARE"]);
			RicercaAziendaSianObj.Esito = new SiarLibrary.NullTypes.StringNT(db.DataReader["ESITO"]);
			RicercaAziendaSianObj.RagioneSociale = new SiarLibrary.NullTypes.StringNT(db.DataReader["RAGIONE_SOCIALE"]);
			RicercaAziendaSianObj.CuaaImpresa = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUAA_IMPRESA"]);
			RicercaAziendaSianObj.CodiceFiscaleImpresa = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_FISCALE_IMPRESA"]);
			RicercaAziendaSianObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			RicercaAziendaSianObj.IsDirty = false;
			RicercaAziendaSianObj.IsPersistent = true;
			return RicercaAziendaSianObj;
		}

		//Find Select

		public static RicercaAziendaSianCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdRicercaEqualThis, SiarLibrary.NullTypes.IntNT OperatoreInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, 
SiarLibrary.NullTypes.StringNT PivaControlloEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataUltimoControlloEqualThis, 
SiarLibrary.NullTypes.IntNT IdBloccoControlloEqualThis, SiarLibrary.NullTypes.BoolNT DaControllareEqualThis, SiarLibrary.NullTypes.StringNT EsitoEqualThis)

		{

			RicercaAziendaSianCollection RicercaAziendaSianCollectionObj = new RicercaAziendaSianCollection();

			IDbCommand findCmd = db.InitCmd("Zricercaaziendasianfindselect", new string[] {"IdRicercaequalthis", "OperatoreInserimentoequalthis", "DataInserimentoequalthis", 
"PivaControlloequalthis", "IdImpresaequalthis", "DataUltimoControlloequalthis", 
"IdBloccoControlloequalthis", "DaControllareequalthis", "Esitoequalthis"}, new string[] {"int", "int", "DateTime", 
"string", "int", "DateTime", 
"int", "bool", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRicercaequalthis", IdRicercaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreInserimentoequalthis", OperatoreInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PivaControlloequalthis", PivaControlloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataUltimoControlloequalthis", DataUltimoControlloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBloccoControlloequalthis", IdBloccoControlloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DaControllareequalthis", DaControllareEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Esitoequalthis", EsitoEqualThis);
			RicercaAziendaSian RicercaAziendaSianObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RicercaAziendaSianObj = GetFromDatareader(db);
				RicercaAziendaSianObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RicercaAziendaSianObj.IsDirty = false;
				RicercaAziendaSianObj.IsPersistent = true;
				RicercaAziendaSianCollectionObj.Add(RicercaAziendaSianObj);
			}
			db.Close();
			return RicercaAziendaSianCollectionObj;
		}

		//Find FindDaControllare

		public static RicercaAziendaSianCollection FindDaControllare(DbProvider db, SiarLibrary.NullTypes.StringNT PivaControlloEqualThis, SiarLibrary.NullTypes.BoolNT DaControllareEqualThis)

		{

			RicercaAziendaSianCollection RicercaAziendaSianCollectionObj = new RicercaAziendaSianCollection();

			IDbCommand findCmd = db.InitCmd("Zricercaaziendasianfindfinddacontrollare", new string[] {"PivaControlloequalthis", "DaControllareequalthis"}, new string[] {"string", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PivaControlloequalthis", PivaControlloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DaControllareequalthis", DaControllareEqualThis);
			RicercaAziendaSian RicercaAziendaSianObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RicercaAziendaSianObj = GetFromDatareader(db);
				RicercaAziendaSianObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RicercaAziendaSianObj.IsDirty = false;
				RicercaAziendaSianObj.IsPersistent = true;
				RicercaAziendaSianCollectionObj.Add(RicercaAziendaSianObj);
			}
			db.Close();
			return RicercaAziendaSianCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for RicercaAziendaSianCollectionProvider:IRicercaAziendaSianProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RicercaAziendaSianCollectionProvider : IRicercaAziendaSianProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di RicercaAziendaSian
		protected RicercaAziendaSianCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public RicercaAziendaSianCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new RicercaAziendaSianCollection(this);
		}

		//Costruttore 2: popola la collection
		public RicercaAziendaSianCollectionProvider(StringNT PivacontrolloEqualThis, BoolNT DacontrollareEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = FindDaControllare(PivacontrolloEqualThis, DacontrollareEqualThis);
		}

		//Costruttore3: ha in input ricercaaziendasianCollectionObj - non popola la collection
		public RicercaAziendaSianCollectionProvider(RicercaAziendaSianCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public RicercaAziendaSianCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new RicercaAziendaSianCollection(this);
		}

		//Get e Set
		public RicercaAziendaSianCollection CollectionObj
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
		public int SaveCollection(RicercaAziendaSianCollection collectionObj)
		{
			return RicercaAziendaSianDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(RicercaAziendaSian ricercaaziendasianObj)
		{
			return RicercaAziendaSianDAL.Save(_dbProviderObj, ricercaaziendasianObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(RicercaAziendaSianCollection collectionObj)
		{
			return RicercaAziendaSianDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(RicercaAziendaSian ricercaaziendasianObj)
		{
			return RicercaAziendaSianDAL.Delete(_dbProviderObj, ricercaaziendasianObj);
		}

		//getById
		public RicercaAziendaSian GetById(IntNT IdRicercaValue)
		{
			RicercaAziendaSian RicercaAziendaSianTemp = RicercaAziendaSianDAL.GetById(_dbProviderObj, IdRicercaValue);
			if (RicercaAziendaSianTemp!=null) RicercaAziendaSianTemp.Provider = this;
			return RicercaAziendaSianTemp;
		}

		//Select: popola la collection
		public RicercaAziendaSianCollection Select(IntNT IdricercaEqualThis, IntNT OperatoreinserimentoEqualThis, DatetimeNT DatainserimentoEqualThis, 
StringNT PivacontrolloEqualThis, IntNT IdimpresaEqualThis, DatetimeNT DataultimocontrolloEqualThis, 
IntNT IdbloccocontrolloEqualThis, BoolNT DacontrollareEqualThis, StringNT EsitoEqualThis)
		{
			RicercaAziendaSianCollection RicercaAziendaSianCollectionTemp = RicercaAziendaSianDAL.Select(_dbProviderObj, IdricercaEqualThis, OperatoreinserimentoEqualThis, DatainserimentoEqualThis, 
PivacontrolloEqualThis, IdimpresaEqualThis, DataultimocontrolloEqualThis, 
IdbloccocontrolloEqualThis, DacontrollareEqualThis, EsitoEqualThis);
			RicercaAziendaSianCollectionTemp.Provider = this;
			return RicercaAziendaSianCollectionTemp;
		}

		//FindDaControllare: popola la collection
		public RicercaAziendaSianCollection FindDaControllare(StringNT PivacontrolloEqualThis, BoolNT DacontrollareEqualThis)
		{
			RicercaAziendaSianCollection RicercaAziendaSianCollectionTemp = RicercaAziendaSianDAL.FindDaControllare(_dbProviderObj, PivacontrolloEqualThis, DacontrollareEqualThis);
			RicercaAziendaSianCollectionTemp.Provider = this;
			return RicercaAziendaSianCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<RICERCA_AZIENDA_SIAN>
  <ViewName>VRICERCA_AZIENDA_SIAN</ViewName>
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
    <FindDaControllare OrderBy="ORDER BY ">
      <PIVA_CONTROLLO>Equal</PIVA_CONTROLLO>
      <DA_CONTROLLARE>Equal</DA_CONTROLLARE>
    </FindDaControllare>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</RICERCA_AZIENDA_SIAN>
*/
