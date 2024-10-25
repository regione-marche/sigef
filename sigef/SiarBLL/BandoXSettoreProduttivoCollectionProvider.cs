using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per BandoXSettoreProduttivo
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IBandoXSettoreProduttivoProvider
	{
		int Save(BandoXSettoreProduttivo BandoXSettoreProduttivoObj);
		int SaveCollection(BandoXSettoreProduttivoCollection collectionObj);
		int Delete(BandoXSettoreProduttivo BandoXSettoreProduttivoObj);
		int DeleteCollection(BandoXSettoreProduttivoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for BandoXSettoreProduttivo
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class BandoXSettoreProduttivo: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdBandoXSettoreProduttivo;
		private NullTypes.IntNT _IdBando;
		private NullTypes.IntNT _IdSettoreProduttivo;
		private NullTypes.IntNT _IdPrioritaSettoriale;
		private NullTypes.StringNT _SettoreProduttivo;
		private NullTypes.StringNT _PrioritaSettoriale;
		[NonSerialized] private IBandoXSettoreProduttivoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBandoXSettoreProduttivoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public BandoXSettoreProduttivo()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_BANDO_X_SETTORE_PRODUTTIVO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdBandoXSettoreProduttivo
		{
			get { return _IdBandoXSettoreProduttivo; }
			set {
				if (IdBandoXSettoreProduttivo != value)
				{
					_IdBandoXSettoreProduttivo = value;
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
		/// Corrisponde al campo:ID_SETTORE_PRODUTTIVO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdSettoreProduttivo
		{
			get { return _IdSettoreProduttivo; }
			set {
				if (IdSettoreProduttivo != value)
				{
					_IdSettoreProduttivo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_PRIORITA_SETTORIALE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdPrioritaSettoriale
		{
			get { return _IdPrioritaSettoriale; }
			set {
				if (IdPrioritaSettoriale != value)
				{
					_IdPrioritaSettoriale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SETTORE_PRODUTTIVO
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT SettoreProduttivo
		{
			get { return _SettoreProduttivo; }
			set {
				if (SettoreProduttivo != value)
				{
					_SettoreProduttivo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PRIORITA_SETTORIALE
		/// Tipo sul db:VARCHAR(1000)
		/// </summary>
		public NullTypes.StringNT PrioritaSettoriale
		{
			get { return _PrioritaSettoriale; }
			set {
				if (PrioritaSettoriale != value)
				{
					_PrioritaSettoriale = value;
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
	/// Summary description for BandoXSettoreProduttivoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class BandoXSettoreProduttivoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private BandoXSettoreProduttivoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((BandoXSettoreProduttivo) info.GetValue(i.ToString(),typeof(BandoXSettoreProduttivo)));
			}
		}

		//Costruttore
		public BandoXSettoreProduttivoCollection()
		{
			this.ItemType = typeof(BandoXSettoreProduttivo);
		}

		//Costruttore con provider
		public BandoXSettoreProduttivoCollection(IBandoXSettoreProduttivoProvider providerObj)
		{
			this.ItemType = typeof(BandoXSettoreProduttivo);
			this.Provider = providerObj;
		}

		//Get e Set
		public new BandoXSettoreProduttivo this[int index]
		{
			get { return (BandoXSettoreProduttivo)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new BandoXSettoreProduttivoCollection GetChanges()
		{
			return (BandoXSettoreProduttivoCollection) base.GetChanges();
		}

		[NonSerialized] private IBandoXSettoreProduttivoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBandoXSettoreProduttivoProvider Provider
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
		public int Add(BandoXSettoreProduttivo BandoXSettoreProduttivoObj)
		{
			if (BandoXSettoreProduttivoObj.Provider == null) BandoXSettoreProduttivoObj.Provider = this.Provider;
			return base.Add(BandoXSettoreProduttivoObj);
		}

		//AddCollection
		public void AddCollection(BandoXSettoreProduttivoCollection BandoXSettoreProduttivoCollectionObj)
		{
			foreach (BandoXSettoreProduttivo BandoXSettoreProduttivoObj in BandoXSettoreProduttivoCollectionObj)
				this.Add(BandoXSettoreProduttivoObj);
		}

		//Insert
		public void Insert(int index, BandoXSettoreProduttivo BandoXSettoreProduttivoObj)
		{
			if (BandoXSettoreProduttivoObj.Provider == null) BandoXSettoreProduttivoObj.Provider = this.Provider;
			base.Insert(index, BandoXSettoreProduttivoObj);
		}

		//CollectionGetById
		public BandoXSettoreProduttivo CollectionGetById(NullTypes.IntNT IdBandoXSettoreProduttivoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdBandoXSettoreProduttivo == IdBandoXSettoreProduttivoValue))
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
		public BandoXSettoreProduttivoCollection SubSelect(NullTypes.IntNT IdBandoXSettoreProduttivoEqualThis, NullTypes.IntNT IdBandoEqualThis, NullTypes.IntNT IdSettoreProduttivoEqualThis, 
NullTypes.IntNT IdPrioritaSettorialeEqualThis)
		{
			BandoXSettoreProduttivoCollection BandoXSettoreProduttivoCollectionTemp = new BandoXSettoreProduttivoCollection();
			foreach (BandoXSettoreProduttivo BandoXSettoreProduttivoItem in this)
			{
				if (((IdBandoXSettoreProduttivoEqualThis == null) || ((BandoXSettoreProduttivoItem.IdBandoXSettoreProduttivo != null) && (BandoXSettoreProduttivoItem.IdBandoXSettoreProduttivo.Value == IdBandoXSettoreProduttivoEqualThis.Value))) && ((IdBandoEqualThis == null) || ((BandoXSettoreProduttivoItem.IdBando != null) && (BandoXSettoreProduttivoItem.IdBando.Value == IdBandoEqualThis.Value))) && ((IdSettoreProduttivoEqualThis == null) || ((BandoXSettoreProduttivoItem.IdSettoreProduttivo != null) && (BandoXSettoreProduttivoItem.IdSettoreProduttivo.Value == IdSettoreProduttivoEqualThis.Value))) && 
((IdPrioritaSettorialeEqualThis == null) || ((BandoXSettoreProduttivoItem.IdPrioritaSettoriale != null) && (BandoXSettoreProduttivoItem.IdPrioritaSettoriale.Value == IdPrioritaSettorialeEqualThis.Value))))
				{
					BandoXSettoreProduttivoCollectionTemp.Add(BandoXSettoreProduttivoItem);
				}
			}
			return BandoXSettoreProduttivoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for BandoXSettoreProduttivoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class BandoXSettoreProduttivoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, BandoXSettoreProduttivo BandoXSettoreProduttivoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdBandoXSettoreProduttivo", BandoXSettoreProduttivoObj.IdBandoXSettoreProduttivo);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", BandoXSettoreProduttivoObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "IdSettoreProduttivo", BandoXSettoreProduttivoObj.IdSettoreProduttivo);
			DbProvider.SetCmdParam(cmd,firstChar + "IdPrioritaSettoriale", BandoXSettoreProduttivoObj.IdPrioritaSettoriale);
		}
		//Insert
		private static int Insert(DbProvider db, BandoXSettoreProduttivo BandoXSettoreProduttivoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZBandoXSettoreProduttivoInsert", new string[] {"IdBando", "IdSettoreProduttivo", 
"IdPrioritaSettoriale"}, new string[] {"int", "int", 
"int"},"");
				CompileIUCmd(false, insertCmd,BandoXSettoreProduttivoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				BandoXSettoreProduttivoObj.IdBandoXSettoreProduttivo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO_X_SETTORE_PRODUTTIVO"]);
				}
				BandoXSettoreProduttivoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoXSettoreProduttivoObj.IsDirty = false;
				BandoXSettoreProduttivoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, BandoXSettoreProduttivo BandoXSettoreProduttivoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBandoXSettoreProduttivoUpdate", new string[] {"IdBandoXSettoreProduttivo", "IdBando", "IdSettoreProduttivo", 
"IdPrioritaSettoriale"}, new string[] {"int", "int", "int", 
"int"},"");
				CompileIUCmd(true, updateCmd,BandoXSettoreProduttivoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				BandoXSettoreProduttivoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoXSettoreProduttivoObj.IsDirty = false;
				BandoXSettoreProduttivoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, BandoXSettoreProduttivo BandoXSettoreProduttivoObj)
		{
			switch (BandoXSettoreProduttivoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, BandoXSettoreProduttivoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, BandoXSettoreProduttivoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,BandoXSettoreProduttivoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, BandoXSettoreProduttivoCollection BandoXSettoreProduttivoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBandoXSettoreProduttivoUpdate", new string[] {"IdBandoXSettoreProduttivo", "IdBando", "IdSettoreProduttivo", 
"IdPrioritaSettoriale"}, new string[] {"int", "int", "int", 
"int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZBandoXSettoreProduttivoInsert", new string[] {"IdBando", "IdSettoreProduttivo", 
"IdPrioritaSettoriale"}, new string[] {"int", "int", 
"int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZBandoXSettoreProduttivoDelete", new string[] {"IdBandoXSettoreProduttivo"}, new string[] {"int"},"");
				for (int i = 0; i < BandoXSettoreProduttivoCollectionObj.Count; i++)
				{
					switch (BandoXSettoreProduttivoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,BandoXSettoreProduttivoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									BandoXSettoreProduttivoCollectionObj[i].IdBandoXSettoreProduttivo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO_X_SETTORE_PRODUTTIVO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,BandoXSettoreProduttivoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (BandoXSettoreProduttivoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBandoXSettoreProduttivo", (SiarLibrary.NullTypes.IntNT)BandoXSettoreProduttivoCollectionObj[i].IdBandoXSettoreProduttivo);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < BandoXSettoreProduttivoCollectionObj.Count; i++)
				{
					if ((BandoXSettoreProduttivoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoXSettoreProduttivoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BandoXSettoreProduttivoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						BandoXSettoreProduttivoCollectionObj[i].IsDirty = false;
						BandoXSettoreProduttivoCollectionObj[i].IsPersistent = true;
					}
					if ((BandoXSettoreProduttivoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						BandoXSettoreProduttivoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BandoXSettoreProduttivoCollectionObj[i].IsDirty = false;
						BandoXSettoreProduttivoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, BandoXSettoreProduttivo BandoXSettoreProduttivoObj)
		{
			int returnValue = 0;
			if (BandoXSettoreProduttivoObj.IsPersistent) 
			{
				returnValue = Delete(db, BandoXSettoreProduttivoObj.IdBandoXSettoreProduttivo);
			}
			BandoXSettoreProduttivoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			BandoXSettoreProduttivoObj.IsDirty = false;
			BandoXSettoreProduttivoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdBandoXSettoreProduttivoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBandoXSettoreProduttivoDelete", new string[] {"IdBandoXSettoreProduttivo"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBandoXSettoreProduttivo", (SiarLibrary.NullTypes.IntNT)IdBandoXSettoreProduttivoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, BandoXSettoreProduttivoCollection BandoXSettoreProduttivoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBandoXSettoreProduttivoDelete", new string[] {"IdBandoXSettoreProduttivo"}, new string[] {"int"},"");
				for (int i = 0; i < BandoXSettoreProduttivoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBandoXSettoreProduttivo", BandoXSettoreProduttivoCollectionObj[i].IdBandoXSettoreProduttivo);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < BandoXSettoreProduttivoCollectionObj.Count; i++)
				{
					if ((BandoXSettoreProduttivoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoXSettoreProduttivoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BandoXSettoreProduttivoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BandoXSettoreProduttivoCollectionObj[i].IsDirty = false;
						BandoXSettoreProduttivoCollectionObj[i].IsPersistent = false;
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
		public static BandoXSettoreProduttivo GetById(DbProvider db, int IdBandoXSettoreProduttivoValue)
		{
			BandoXSettoreProduttivo BandoXSettoreProduttivoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZBandoXSettoreProduttivoGetById", new string[] {"IdBandoXSettoreProduttivo"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdBandoXSettoreProduttivo", (SiarLibrary.NullTypes.IntNT)IdBandoXSettoreProduttivoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				BandoXSettoreProduttivoObj = GetFromDatareader(db);
				BandoXSettoreProduttivoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoXSettoreProduttivoObj.IsDirty = false;
				BandoXSettoreProduttivoObj.IsPersistent = true;
			}
			db.Close();
			return BandoXSettoreProduttivoObj;
		}

		//getFromDatareader
		public static BandoXSettoreProduttivo GetFromDatareader(DbProvider db)
		{
			BandoXSettoreProduttivo BandoXSettoreProduttivoObj = new BandoXSettoreProduttivo();
			BandoXSettoreProduttivoObj.IdBandoXSettoreProduttivo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO_X_SETTORE_PRODUTTIVO"]);
			BandoXSettoreProduttivoObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			BandoXSettoreProduttivoObj.IdSettoreProduttivo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SETTORE_PRODUTTIVO"]);
			BandoXSettoreProduttivoObj.IdPrioritaSettoriale = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PRIORITA_SETTORIALE"]);
			BandoXSettoreProduttivoObj.SettoreProduttivo = new SiarLibrary.NullTypes.StringNT(db.DataReader["SETTORE_PRODUTTIVO"]);
			BandoXSettoreProduttivoObj.PrioritaSettoriale = new SiarLibrary.NullTypes.StringNT(db.DataReader["PRIORITA_SETTORIALE"]);
			BandoXSettoreProduttivoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			BandoXSettoreProduttivoObj.IsDirty = false;
			BandoXSettoreProduttivoObj.IsPersistent = true;
			return BandoXSettoreProduttivoObj;
		}

		//Find Select

		public static BandoXSettoreProduttivoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoXSettoreProduttivoEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdSettoreProduttivoEqualThis, 
SiarLibrary.NullTypes.IntNT IdPrioritaSettorialeEqualThis)

		{

			BandoXSettoreProduttivoCollection BandoXSettoreProduttivoCollectionObj = new BandoXSettoreProduttivoCollection();

			IDbCommand findCmd = db.InitCmd("Zbandoxsettoreproduttivofindselect", new string[] {"IdBandoXSettoreProduttivoequalthis", "IdBandoequalthis", "IdSettoreProduttivoequalthis", 
"IdPrioritaSettorialeequalthis"}, new string[] {"int", "int", "int", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoXSettoreProduttivoequalthis", IdBandoXSettoreProduttivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdSettoreProduttivoequalthis", IdSettoreProduttivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPrioritaSettorialeequalthis", IdPrioritaSettorialeEqualThis);
			BandoXSettoreProduttivo BandoXSettoreProduttivoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BandoXSettoreProduttivoObj = GetFromDatareader(db);
				BandoXSettoreProduttivoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoXSettoreProduttivoObj.IsDirty = false;
				BandoXSettoreProduttivoObj.IsPersistent = true;
				BandoXSettoreProduttivoCollectionObj.Add(BandoXSettoreProduttivoObj);
			}
			db.Close();
			return BandoXSettoreProduttivoCollectionObj;
		}

		//Find Find

		public static BandoXSettoreProduttivoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdSettoreProduttivoEqualThis, SiarLibrary.NullTypes.IntNT IdPrioritaSettorialeEqualThis)

		{

			BandoXSettoreProduttivoCollection BandoXSettoreProduttivoCollectionObj = new BandoXSettoreProduttivoCollection();

			IDbCommand findCmd = db.InitCmd("Zbandoxsettoreproduttivofindfind", new string[] {"IdBandoequalthis", "IdSettoreProduttivoequalthis", "IdPrioritaSettorialeequalthis"}, new string[] {"int", "int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdSettoreProduttivoequalthis", IdSettoreProduttivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPrioritaSettorialeequalthis", IdPrioritaSettorialeEqualThis);
			BandoXSettoreProduttivo BandoXSettoreProduttivoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BandoXSettoreProduttivoObj = GetFromDatareader(db);
				BandoXSettoreProduttivoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoXSettoreProduttivoObj.IsDirty = false;
				BandoXSettoreProduttivoObj.IsPersistent = true;
				BandoXSettoreProduttivoCollectionObj.Add(BandoXSettoreProduttivoObj);
			}
			db.Close();
			return BandoXSettoreProduttivoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for BandoXSettoreProduttivoCollectionProvider:IBandoXSettoreProduttivoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class BandoXSettoreProduttivoCollectionProvider : IBandoXSettoreProduttivoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di BandoXSettoreProduttivo
		protected BandoXSettoreProduttivoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public BandoXSettoreProduttivoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new BandoXSettoreProduttivoCollection(this);
		}

		//Costruttore 2: popola la collection
		public BandoXSettoreProduttivoCollectionProvider(IntNT IdbandoEqualThis, IntNT IdsettoreproduttivoEqualThis, IntNT IdprioritasettorialeEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdbandoEqualThis, IdsettoreproduttivoEqualThis, IdprioritasettorialeEqualThis);
		}

		//Costruttore3: ha in input bandoxsettoreproduttivoCollectionObj - non popola la collection
		public BandoXSettoreProduttivoCollectionProvider(BandoXSettoreProduttivoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public BandoXSettoreProduttivoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new BandoXSettoreProduttivoCollection(this);
		}

		//Get e Set
		public BandoXSettoreProduttivoCollection CollectionObj
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
		public int SaveCollection(BandoXSettoreProduttivoCollection collectionObj)
		{
			return BandoXSettoreProduttivoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(BandoXSettoreProduttivo bandoxsettoreproduttivoObj)
		{
			return BandoXSettoreProduttivoDAL.Save(_dbProviderObj, bandoxsettoreproduttivoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(BandoXSettoreProduttivoCollection collectionObj)
		{
			return BandoXSettoreProduttivoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(BandoXSettoreProduttivo bandoxsettoreproduttivoObj)
		{
			return BandoXSettoreProduttivoDAL.Delete(_dbProviderObj, bandoxsettoreproduttivoObj);
		}

		//getById
		public BandoXSettoreProduttivo GetById(IntNT IdBandoXSettoreProduttivoValue)
		{
			BandoXSettoreProduttivo BandoXSettoreProduttivoTemp = BandoXSettoreProduttivoDAL.GetById(_dbProviderObj, IdBandoXSettoreProduttivoValue);
			if (BandoXSettoreProduttivoTemp!=null) BandoXSettoreProduttivoTemp.Provider = this;
			return BandoXSettoreProduttivoTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public BandoXSettoreProduttivoCollection Select(IntNT IdbandoxsettoreproduttivoEqualThis, IntNT IdbandoEqualThis, IntNT IdsettoreproduttivoEqualThis, 
IntNT IdprioritasettorialeEqualThis)
		{
			BandoXSettoreProduttivoCollection BandoXSettoreProduttivoCollectionTemp = BandoXSettoreProduttivoDAL.Select(_dbProviderObj, IdbandoxsettoreproduttivoEqualThis, IdbandoEqualThis, IdsettoreproduttivoEqualThis, 
IdprioritasettorialeEqualThis);
			BandoXSettoreProduttivoCollectionTemp.Provider = this;
			return BandoXSettoreProduttivoCollectionTemp;
		}

		//Find: popola la collection
		public BandoXSettoreProduttivoCollection Find(IntNT IdbandoEqualThis, IntNT IdsettoreproduttivoEqualThis, IntNT IdprioritasettorialeEqualThis)
		{
			BandoXSettoreProduttivoCollection BandoXSettoreProduttivoCollectionTemp = BandoXSettoreProduttivoDAL.Find(_dbProviderObj, IdbandoEqualThis, IdsettoreproduttivoEqualThis, IdprioritasettorialeEqualThis);
			BandoXSettoreProduttivoCollectionTemp.Provider = this;
			return BandoXSettoreProduttivoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<BANDO_X_SETTORE_PRODUTTIVO>
  <ViewName>vBANDO_X_SETTORE_PRODUTTIVO</ViewName>
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
    <Find OrderBy="ORDER BY SETTORE_PRODUTTIVO, PRIORITA_SETTORIALE">
      <ID_BANDO>Equal</ID_BANDO>
      <ID_SETTORE_PRODUTTIVO>Equal</ID_SETTORE_PRODUTTIVO>
      <ID_PRIORITA_SETTORIALE>Equal</ID_PRIORITA_SETTORIALE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</BANDO_X_SETTORE_PRODUTTIVO>
*/
