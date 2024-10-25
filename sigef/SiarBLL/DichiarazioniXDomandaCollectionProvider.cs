using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per DichiarazioniXDomanda
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IDichiarazioniXDomandaProvider
	{
		int Save(DichiarazioniXDomanda DichiarazioniXDomandaObj);
		int SaveCollection(DichiarazioniXDomandaCollection collectionObj);
		int Delete(DichiarazioniXDomanda DichiarazioniXDomandaObj);
		int DeleteCollection(DichiarazioniXDomandaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for DichiarazioniXDomanda
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class DichiarazioniXDomanda: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdDichiarazione;
		private NullTypes.IntNT _IdDomanda;
		private NullTypes.IntNT _Ordine;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.StringNT _Misura;
		private NullTypes.BoolNT _Obbligatorio;
		[NonSerialized] private IDichiarazioniXDomandaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IDichiarazioniXDomandaProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public DichiarazioniXDomanda()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_DICHIARAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDichiarazione
		{
			get { return _IdDichiarazione; }
			set {
				if (IdDichiarazione != value)
				{
					_IdDichiarazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_DOMANDA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDomanda
		{
			get { return _IdDomanda; }
			set {
				if (IdDomanda != value)
				{
					_IdDomanda = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORDINE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Ordine
		{
			get { return _Ordine; }
			set {
				if (Ordine != value)
				{
					_Ordine = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(1000)
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
		/// Corrisponde al campo:MISURA
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT Misura
		{
			get { return _Misura; }
			set {
				if (Misura != value)
				{
					_Misura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OBBLIGATORIO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Obbligatorio
		{
			get { return _Obbligatorio; }
			set {
				if (Obbligatorio != value)
				{
					_Obbligatorio = value;
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
	/// Summary description for DichiarazioniXDomandaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class DichiarazioniXDomandaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private DichiarazioniXDomandaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((DichiarazioniXDomanda) info.GetValue(i.ToString(),typeof(DichiarazioniXDomanda)));
			}
		}

		//Costruttore
		public DichiarazioniXDomandaCollection()
		{
			this.ItemType = typeof(DichiarazioniXDomanda);
		}

		//Costruttore con provider
		public DichiarazioniXDomandaCollection(IDichiarazioniXDomandaProvider providerObj)
		{
			this.ItemType = typeof(DichiarazioniXDomanda);
			this.Provider = providerObj;
		}

		//Get e Set
		public new DichiarazioniXDomanda this[int index]
		{
			get { return (DichiarazioniXDomanda)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new DichiarazioniXDomandaCollection GetChanges()
		{
			return (DichiarazioniXDomandaCollection) base.GetChanges();
		}

		[NonSerialized] private IDichiarazioniXDomandaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IDichiarazioniXDomandaProvider Provider
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
		public int Add(DichiarazioniXDomanda DichiarazioniXDomandaObj)
		{
			if (DichiarazioniXDomandaObj.Provider == null) DichiarazioniXDomandaObj.Provider = this.Provider;
			return base.Add(DichiarazioniXDomandaObj);
		}

		//AddCollection
		public void AddCollection(DichiarazioniXDomandaCollection DichiarazioniXDomandaCollectionObj)
		{
			foreach (DichiarazioniXDomanda DichiarazioniXDomandaObj in DichiarazioniXDomandaCollectionObj)
				this.Add(DichiarazioniXDomandaObj);
		}

		//Insert
		public void Insert(int index, DichiarazioniXDomanda DichiarazioniXDomandaObj)
		{
			if (DichiarazioniXDomandaObj.Provider == null) DichiarazioniXDomandaObj.Provider = this.Provider;
			base.Insert(index, DichiarazioniXDomandaObj);
		}

		//CollectionGetById
		public DichiarazioniXDomanda CollectionGetById(NullTypes.IntNT IdDichiarazioneValue, NullTypes.IntNT IdDomandaValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdDichiarazione == IdDichiarazioneValue) && (this[i].IdDomanda == IdDomandaValue))
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
		// se il parametro di ricerca Ã¨ null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public DichiarazioniXDomandaCollection SubSelect(NullTypes.IntNT IdDichiarazioneEqualThis, NullTypes.IntNT IdDomandaEqualThis, NullTypes.IntNT OrdineEqualThis, 
NullTypes.BoolNT ObbligatorioEqualThis)
		{
			DichiarazioniXDomandaCollection DichiarazioniXDomandaCollectionTemp = new DichiarazioniXDomandaCollection();
			foreach (DichiarazioniXDomanda DichiarazioniXDomandaItem in this)
			{
				if (((IdDichiarazioneEqualThis == null) || ((DichiarazioniXDomandaItem.IdDichiarazione != null) && (DichiarazioniXDomandaItem.IdDichiarazione.Value == IdDichiarazioneEqualThis.Value))) && ((IdDomandaEqualThis == null) || ((DichiarazioniXDomandaItem.IdDomanda != null) && (DichiarazioniXDomandaItem.IdDomanda.Value == IdDomandaEqualThis.Value))) && ((OrdineEqualThis == null) || ((DichiarazioniXDomandaItem.Ordine != null) && (DichiarazioniXDomandaItem.Ordine.Value == OrdineEqualThis.Value))) && 
((ObbligatorioEqualThis == null) || ((DichiarazioniXDomandaItem.Obbligatorio != null) && (DichiarazioniXDomandaItem.Obbligatorio.Value == ObbligatorioEqualThis.Value))))
				{
					DichiarazioniXDomandaCollectionTemp.Add(DichiarazioniXDomandaItem);
				}
			}
			return DichiarazioniXDomandaCollectionTemp;
		}

        //filter: effettua una ricerca all'interno della collection
        // se il parametro di ricerca è null, prende tutto,
        // anche i record che hanno quel campo null
        // altrimenti scarta i record che hanno quel campo null ...
        // ...e confronta gli altri
        public DichiarazioniXDomandaCollection FiltroObbligatorio(NullTypes.BoolNT ObbligatorioEqualThis)
        {
            DichiarazioniXDomandaCollection DichiarazioniXDomandaCollectionTemp = new DichiarazioniXDomandaCollection();
            foreach (DichiarazioniXDomanda DichiarazioniXDomandaItem in this)
            {
                if (((ObbligatorioEqualThis == null) || ((DichiarazioniXDomandaItem.Obbligatorio != null) && (DichiarazioniXDomandaItem.Obbligatorio.Value == ObbligatorioEqualThis.Value))))
                {
                    DichiarazioniXDomandaCollectionTemp.Add(DichiarazioniXDomandaItem);
                }
            }
            return DichiarazioniXDomandaCollectionTemp;
        }
	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for DichiarazioniXDomandaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class DichiarazioniXDomandaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, DichiarazioniXDomanda DichiarazioniXDomandaObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdDichiarazione", DichiarazioniXDomandaObj.IdDichiarazione);
			DbProvider.SetCmdParam(cmd,firstChar + "IdDomanda", DichiarazioniXDomandaObj.IdDomanda);
			DbProvider.SetCmdParam(cmd,firstChar + "Ordine", DichiarazioniXDomandaObj.Ordine);
			DbProvider.SetCmdParam(cmd,firstChar + "Obbligatorio", DichiarazioniXDomandaObj.Obbligatorio);
		}
		//Insert
		private static int Insert(DbProvider db, DichiarazioniXDomanda DichiarazioniXDomandaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZDichiarazioniXDomandaInsert", new string[] {"IdDichiarazione", "IdDomanda", "Ordine", 
"Obbligatorio"}, new string[] {"int", "int", "int", 
"bool"},"");
				CompileIUCmd(false, insertCmd,DichiarazioniXDomandaObj, db.CommandFirstChar);
				i = db.Execute(insertCmd);
				DichiarazioniXDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DichiarazioniXDomandaObj.IsDirty = false;
				DichiarazioniXDomandaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, DichiarazioniXDomanda DichiarazioniXDomandaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZDichiarazioniXDomandaUpdate", new string[] {"IdDichiarazione", "IdDomanda", "Ordine", 
"Obbligatorio"}, new string[] {"int", "int", "int", 
"bool"},"");
				CompileIUCmd(true, updateCmd,DichiarazioniXDomandaObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				DichiarazioniXDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DichiarazioniXDomandaObj.IsDirty = false;
				DichiarazioniXDomandaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, DichiarazioniXDomanda DichiarazioniXDomandaObj)
		{
			switch (DichiarazioniXDomandaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, DichiarazioniXDomandaObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, DichiarazioniXDomandaObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,DichiarazioniXDomandaObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, DichiarazioniXDomandaCollection DichiarazioniXDomandaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZDichiarazioniXDomandaUpdate", new string[] {"IdDichiarazione", "IdDomanda", "Ordine", 
"Obbligatorio"}, new string[] {"int", "int", "int", 
"bool"},"");
				IDbCommand insertCmd = db.InitCmd( "ZDichiarazioniXDomandaInsert", new string[] {"IdDichiarazione", "IdDomanda", "Ordine", 
"Obbligatorio"}, new string[] {"int", "int", "int", 
"bool"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZDichiarazioniXDomandaDelete", new string[] {"IdDichiarazione", "IdDomanda"}, new string[] {"int", "int"},"");
				for (int i = 0; i < DichiarazioniXDomandaCollectionObj.Count; i++)
				{
					switch (DichiarazioniXDomandaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,DichiarazioniXDomandaCollectionObj[i], db.CommandFirstChar);
								returnValue += db.Execute(insertCmd);
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,DichiarazioniXDomandaCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (DichiarazioniXDomandaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDichiarazione", (SiarLibrary.NullTypes.IntNT)DichiarazioniXDomandaCollectionObj[i].IdDichiarazione);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDomanda", (SiarLibrary.NullTypes.IntNT)DichiarazioniXDomandaCollectionObj[i].IdDomanda);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < DichiarazioniXDomandaCollectionObj.Count; i++)
				{
					if ((DichiarazioniXDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (DichiarazioniXDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						DichiarazioniXDomandaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						DichiarazioniXDomandaCollectionObj[i].IsDirty = false;
						DichiarazioniXDomandaCollectionObj[i].IsPersistent = true;
					}
					if ((DichiarazioniXDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						DichiarazioniXDomandaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						DichiarazioniXDomandaCollectionObj[i].IsDirty = false;
						DichiarazioniXDomandaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, DichiarazioniXDomanda DichiarazioniXDomandaObj)
		{
			int returnValue = 0;
			if (DichiarazioniXDomandaObj.IsPersistent) 
			{
				returnValue = Delete(db, DichiarazioniXDomandaObj.IdDichiarazione, DichiarazioniXDomandaObj.IdDomanda);
			}
			DichiarazioniXDomandaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			DichiarazioniXDomandaObj.IsDirty = false;
			DichiarazioniXDomandaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdDichiarazioneValue, int IdDomandaValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZDichiarazioniXDomandaDelete", new string[] {"IdDichiarazione", "IdDomanda"}, new string[] {"int", "int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDichiarazione", (SiarLibrary.NullTypes.IntNT)IdDichiarazioneValue);
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDomanda", (SiarLibrary.NullTypes.IntNT)IdDomandaValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, DichiarazioniXDomandaCollection DichiarazioniXDomandaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZDichiarazioniXDomandaDelete", new string[] {"IdDichiarazione", "IdDomanda"}, new string[] {"int", "int"},"");
				for (int i = 0; i < DichiarazioniXDomandaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDichiarazione", DichiarazioniXDomandaCollectionObj[i].IdDichiarazione);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDomanda", DichiarazioniXDomandaCollectionObj[i].IdDomanda);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < DichiarazioniXDomandaCollectionObj.Count; i++)
				{
					if ((DichiarazioniXDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (DichiarazioniXDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						DichiarazioniXDomandaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						DichiarazioniXDomandaCollectionObj[i].IsDirty = false;
						DichiarazioniXDomandaCollectionObj[i].IsPersistent = false;
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
		public static DichiarazioniXDomanda GetById(DbProvider db, int IdDichiarazioneValue, int IdDomandaValue)
		{
			DichiarazioniXDomanda DichiarazioniXDomandaObj = null;
			IDbCommand readCmd = db.InitCmd( "ZDichiarazioniXDomandaGetById", new string[] {"IdDichiarazione", "IdDomanda"}, new string[] {"int", "int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdDichiarazione", (SiarLibrary.NullTypes.IntNT)IdDichiarazioneValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdDomanda", (SiarLibrary.NullTypes.IntNT)IdDomandaValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				DichiarazioniXDomandaObj = GetFromDatareader(db);
				DichiarazioniXDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DichiarazioniXDomandaObj.IsDirty = false;
				DichiarazioniXDomandaObj.IsPersistent = true;
			}
			db.Close();
			return DichiarazioniXDomandaObj;
		}

		//getFromDatareader
		public static DichiarazioniXDomanda GetFromDatareader(DbProvider db)
		{
			DichiarazioniXDomanda DichiarazioniXDomandaObj = new DichiarazioniXDomanda();
			DichiarazioniXDomandaObj.IdDichiarazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DICHIARAZIONE"]);
			DichiarazioniXDomandaObj.IdDomanda = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA"]);
			DichiarazioniXDomandaObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
			DichiarazioniXDomandaObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			DichiarazioniXDomandaObj.Misura = new SiarLibrary.NullTypes.StringNT(db.DataReader["MISURA"]);
			DichiarazioniXDomandaObj.Obbligatorio = new SiarLibrary.NullTypes.BoolNT(db.DataReader["OBBLIGATORIO"]);
			DichiarazioniXDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			DichiarazioniXDomandaObj.IsDirty = false;
			DichiarazioniXDomandaObj.IsPersistent = true;
			return DichiarazioniXDomandaObj;
		}

		//Find Select

		public static DichiarazioniXDomandaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdDichiarazioneEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaEqualThis, SiarLibrary.NullTypes.IntNT OrdineEqualThis, 
SiarLibrary.NullTypes.BoolNT ObbligatorioEqualThis)

		{

			DichiarazioniXDomandaCollection DichiarazioniXDomandaCollectionObj = new DichiarazioniXDomandaCollection();

			IDbCommand findCmd = db.InitCmd("Zdichiarazionixdomandafindselect", new string[] {"IdDichiarazioneequalthis", "IdDomandaequalthis", "Ordineequalthis", 
"Obbligatorioequalthis"}, new string[] {"int", "int", "int", 
"bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDichiarazioneequalthis", IdDichiarazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaequalthis", IdDomandaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Obbligatorioequalthis", ObbligatorioEqualThis);
			DichiarazioniXDomanda DichiarazioniXDomandaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				DichiarazioniXDomandaObj = GetFromDatareader(db);
				DichiarazioniXDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DichiarazioniXDomandaObj.IsDirty = false;
				DichiarazioniXDomandaObj.IsPersistent = true;
				DichiarazioniXDomandaCollectionObj.Add(DichiarazioniXDomandaObj);
			}
			db.Close();
			return DichiarazioniXDomandaCollectionObj;
		}

		//Find Find

		public static DichiarazioniXDomandaCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdDichiarazioneEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaEqualThis)

		{

			DichiarazioniXDomandaCollection DichiarazioniXDomandaCollectionObj = new DichiarazioniXDomandaCollection();

			IDbCommand findCmd = db.InitCmd("Zdichiarazionixdomandafindfind", new string[] {"IdDichiarazioneequalthis", "IdDomandaequalthis"}, new string[] {"int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDichiarazioneequalthis", IdDichiarazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaequalthis", IdDomandaEqualThis);
			DichiarazioniXDomanda DichiarazioniXDomandaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				DichiarazioniXDomandaObj = GetFromDatareader(db);
				DichiarazioniXDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DichiarazioniXDomandaObj.IsDirty = false;
				DichiarazioniXDomandaObj.IsPersistent = true;
				DichiarazioniXDomandaCollectionObj.Add(DichiarazioniXDomandaObj);
			}
			db.Close();
			return DichiarazioniXDomandaCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for DichiarazioniXDomandaCollectionProvider:IDichiarazioniXDomandaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class DichiarazioniXDomandaCollectionProvider : IDichiarazioniXDomandaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di DichiarazioniXDomanda
		protected DichiarazioniXDomandaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public DichiarazioniXDomandaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new DichiarazioniXDomandaCollection(this);
		}

		//Costruttore 2: popola la collection
		public DichiarazioniXDomandaCollectionProvider(IntNT IddichiarazioneEqualThis, IntNT IddomandaEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IddichiarazioneEqualThis, IddomandaEqualThis);
		}

		//Costruttore3: ha in input dichiarazionixdomandaCollectionObj - non popola la collection
		public DichiarazioniXDomandaCollectionProvider(DichiarazioniXDomandaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public DichiarazioniXDomandaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new DichiarazioniXDomandaCollection(this);
		}

		//Get e Set
		public DichiarazioniXDomandaCollection CollectionObj
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
		public int SaveCollection(DichiarazioniXDomandaCollection collectionObj)
		{
			return DichiarazioniXDomandaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(DichiarazioniXDomanda dichiarazionixdomandaObj)
		{
			return DichiarazioniXDomandaDAL.Save(_dbProviderObj, dichiarazionixdomandaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(DichiarazioniXDomandaCollection collectionObj)
		{
			return DichiarazioniXDomandaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(DichiarazioniXDomanda dichiarazionixdomandaObj)
		{
			return DichiarazioniXDomandaDAL.Delete(_dbProviderObj, dichiarazionixdomandaObj);
		}

		//getById
		public DichiarazioniXDomanda GetById(IntNT IdDichiarazioneValue, IntNT IdDomandaValue)
		{
			DichiarazioniXDomanda DichiarazioniXDomandaTemp = DichiarazioniXDomandaDAL.GetById(_dbProviderObj, IdDichiarazioneValue, IdDomandaValue);
			if (DichiarazioniXDomandaTemp!=null) DichiarazioniXDomandaTemp.Provider = this;
			return DichiarazioniXDomandaTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public DichiarazioniXDomandaCollection Select(IntNT IddichiarazioneEqualThis, IntNT IddomandaEqualThis, IntNT OrdineEqualThis, 
BoolNT ObbligatorioEqualThis)
		{
			DichiarazioniXDomandaCollection DichiarazioniXDomandaCollectionTemp = DichiarazioniXDomandaDAL.Select(_dbProviderObj, IddichiarazioneEqualThis, IddomandaEqualThis, OrdineEqualThis, 
ObbligatorioEqualThis);
			DichiarazioniXDomandaCollectionTemp.Provider = this;
			return DichiarazioniXDomandaCollectionTemp;
		}

		//Find: popola la collection
		public DichiarazioniXDomandaCollection Find(IntNT IddichiarazioneEqualThis, IntNT IddomandaEqualThis)
		{
			DichiarazioniXDomandaCollection DichiarazioniXDomandaCollectionTemp = DichiarazioniXDomandaDAL.Find(_dbProviderObj, IddichiarazioneEqualThis, IddomandaEqualThis);
			DichiarazioniXDomandaCollectionTemp.Provider = this;
			return DichiarazioniXDomandaCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<DICHIARAZIONI_X_DOMANDA>
  <ViewName>vDICHIARAZIONI</ViewName>
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
      <ID_DICHIARAZIONE>Equal</ID_DICHIARAZIONE>
      <ID_DOMANDA>Equal</ID_DOMANDA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</DICHIARAZIONI_X_DOMANDA>
*/
