using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per TipoAteco2007
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ITipoAteco2007Provider
	{
		int Save(TipoAteco2007 TipoAteco2007Obj);
		int SaveCollection(TipoAteco2007Collection collectionObj);
		int Delete(TipoAteco2007 TipoAteco2007Obj);
		int DeleteCollection(TipoAteco2007Collection collectionObj);
	}
	/// <summary>
	/// Summary description for TipoAteco2007
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class TipoAteco2007: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.StringNT _CodTipoAteco2007;
		private NullTypes.StringNT _Sezione;
		private NullTypes.StringNT _Divisione;
		private NullTypes.StringNT _Classe;
		private NullTypes.StringNT _Gruppo;
		private NullTypes.StringNT _Categoria;
		private NullTypes.StringNT _Sottocategoria;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.BoolNT _Eliminato;
		[NonSerialized] private ITipoAteco2007Provider _provider;
		[System.Xml.Serialization.XmlIgnore] public ITipoAteco2007Provider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public TipoAteco2007()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:COD_TIPO_ATECO2007
		/// Tipo sul db:CHAR(9)
		/// </summary>
		public NullTypes.StringNT CodTipoAteco2007
		{
			get { return _CodTipoAteco2007; }
			set {
				if (CodTipoAteco2007 != value)
				{
					_CodTipoAteco2007 = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Sezione
		/// Tipo sul db:VARCHAR(8)
		/// </summary>
		public NullTypes.StringNT Sezione
		{
			get { return _Sezione; }
			set {
				if (Sezione != value)
				{
					_Sezione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Divisione
		/// Tipo sul db:VARCHAR(8)
		/// </summary>
		public NullTypes.StringNT Divisione
		{
			get { return _Divisione; }
			set {
				if (Divisione != value)
				{
					_Divisione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Classe
		/// Tipo sul db:VARCHAR(8)
		/// </summary>
		public NullTypes.StringNT Classe
		{
			get { return _Classe; }
			set {
				if (Classe != value)
				{
					_Classe = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Gruppo
		/// Tipo sul db:VARCHAR(8)
		/// </summary>
		public NullTypes.StringNT Gruppo
		{
			get { return _Gruppo; }
			set {
				if (Gruppo != value)
				{
					_Gruppo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Categoria
		/// Tipo sul db:VARCHAR(8)
		/// </summary>
		public NullTypes.StringNT Categoria
		{
			get { return _Categoria; }
			set {
				if (Categoria != value)
				{
					_Categoria = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Sottocategoria
		/// Tipo sul db:VARCHAR(8)
		/// </summary>
		public NullTypes.StringNT Sottocategoria
		{
			get { return _Sottocategoria; }
			set {
				if (Sottocategoria != value)
				{
					_Sottocategoria = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Descrizione
		/// Tipo sul db:NVARCHAR(255)
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
		/// Corrisponde al campo:ELIMINATO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Eliminato
		{
			get { return _Eliminato; }
			set {
				if (Eliminato != value)
				{
					_Eliminato = value;
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
	/// Summary description for TipoAteco2007Collection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class TipoAteco2007Collection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private TipoAteco2007Collection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((TipoAteco2007) info.GetValue(i.ToString(),typeof(TipoAteco2007)));
			}
		}

		//Costruttore
		public TipoAteco2007Collection()
		{
			this.ItemType = typeof(TipoAteco2007);
		}

		//Costruttore con provider
		public TipoAteco2007Collection(ITipoAteco2007Provider providerObj)
		{
			this.ItemType = typeof(TipoAteco2007);
			this.Provider = providerObj;
		}

		//Get e Set
		public new TipoAteco2007 this[int index]
		{
			get { return (TipoAteco2007)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new TipoAteco2007Collection GetChanges()
		{
			return (TipoAteco2007Collection) base.GetChanges();
		}

		[NonSerialized] private ITipoAteco2007Provider _provider;
		[System.Xml.Serialization.XmlIgnore] public ITipoAteco2007Provider Provider
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
		public int Add(TipoAteco2007 TipoAteco2007Obj)
		{
			if (TipoAteco2007Obj.Provider == null) TipoAteco2007Obj.Provider = this.Provider;
			return base.Add(TipoAteco2007Obj);
		}

		//AddCollection
		public void AddCollection(TipoAteco2007Collection TipoAteco2007CollectionObj)
		{
			foreach (TipoAteco2007 TipoAteco2007Obj in TipoAteco2007CollectionObj)
				this.Add(TipoAteco2007Obj);
		}

		//Insert
		public void Insert(int index, TipoAteco2007 TipoAteco2007Obj)
		{
			if (TipoAteco2007Obj.Provider == null) TipoAteco2007Obj.Provider = this.Provider;
			base.Insert(index, TipoAteco2007Obj);
		}

		//CollectionGetById
		public TipoAteco2007 CollectionGetById(NullTypes.StringNT CodTipoAteco2007Value)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].CodTipoAteco2007 == CodTipoAteco2007Value))
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
		public TipoAteco2007Collection SubSelect(NullTypes.StringNT CodTipoAteco2007EqualThis, NullTypes.StringNT SezioneEqualThis, NullTypes.StringNT DivisioneEqualThis, 
NullTypes.StringNT GruppoEqualThis, NullTypes.StringNT ClasseEqualThis, NullTypes.StringNT CategoriaEqualThis, 
NullTypes.StringNT SottocategoriaEqualThis, NullTypes.StringNT DescrizioneEqualThis, NullTypes.BoolNT EliminatoEqualThis)
		{
			TipoAteco2007Collection TipoAteco2007CollectionTemp = new TipoAteco2007Collection();
			foreach (TipoAteco2007 TipoAteco2007Item in this)
			{
				if (((CodTipoAteco2007EqualThis == null) || ((TipoAteco2007Item.CodTipoAteco2007 != null) && (TipoAteco2007Item.CodTipoAteco2007.Value == CodTipoAteco2007EqualThis.Value))) && ((SezioneEqualThis == null) || ((TipoAteco2007Item.Sezione != null) && (TipoAteco2007Item.Sezione.Value == SezioneEqualThis.Value))) && ((DivisioneEqualThis == null) || ((TipoAteco2007Item.Divisione != null) && (TipoAteco2007Item.Divisione.Value == DivisioneEqualThis.Value))) && 
((GruppoEqualThis == null) || ((TipoAteco2007Item.Gruppo != null) && (TipoAteco2007Item.Gruppo.Value == GruppoEqualThis.Value))) && ((ClasseEqualThis == null) || ((TipoAteco2007Item.Classe != null) && (TipoAteco2007Item.Classe.Value == ClasseEqualThis.Value))) && ((CategoriaEqualThis == null) || ((TipoAteco2007Item.Categoria != null) && (TipoAteco2007Item.Categoria.Value == CategoriaEqualThis.Value))) && 
((SottocategoriaEqualThis == null) || ((TipoAteco2007Item.Sottocategoria != null) && (TipoAteco2007Item.Sottocategoria.Value == SottocategoriaEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((TipoAteco2007Item.Descrizione != null) && (TipoAteco2007Item.Descrizione.Value == DescrizioneEqualThis.Value))) && ((EliminatoEqualThis == null) || ((TipoAteco2007Item.Eliminato != null) && (TipoAteco2007Item.Eliminato.Value == EliminatoEqualThis.Value))))
				{
					TipoAteco2007CollectionTemp.Add(TipoAteco2007Item);
				}
			}
			return TipoAteco2007CollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for TipoAteco2007DAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class TipoAteco2007DAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, TipoAteco2007 TipoAteco2007Obj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipoAteco2007", TipoAteco2007Obj.CodTipoAteco2007);
			DbProvider.SetCmdParam(cmd,firstChar + "Sezione", TipoAteco2007Obj.Sezione);
			DbProvider.SetCmdParam(cmd,firstChar + "Divisione", TipoAteco2007Obj.Divisione);
			DbProvider.SetCmdParam(cmd,firstChar + "Classe", TipoAteco2007Obj.Classe);
			DbProvider.SetCmdParam(cmd,firstChar + "Gruppo", TipoAteco2007Obj.Gruppo);
			DbProvider.SetCmdParam(cmd,firstChar + "Categoria", TipoAteco2007Obj.Categoria);
			DbProvider.SetCmdParam(cmd,firstChar + "Sottocategoria", TipoAteco2007Obj.Sottocategoria);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", TipoAteco2007Obj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "Eliminato", TipoAteco2007Obj.Eliminato);
		}
		//Insert
		private static int Insert(DbProvider db, TipoAteco2007 TipoAteco2007Obj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZTipoAteco2007Insert", new string[] {"CodTipoAteco2007", "Sezione", "Divisione", 
"Classe", "Gruppo", "Categoria", 
"Sottocategoria", "Descrizione", "Eliminato"}, new string[] {"string", "string", "string", 
"string", "string", "string", 
"string", "string", "bool"},"");
				CompileIUCmd(false, insertCmd,TipoAteco2007Obj, db.CommandFirstChar);
				i = db.Execute(insertCmd);
				TipoAteco2007Obj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TipoAteco2007Obj.IsDirty = false;
				TipoAteco2007Obj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, TipoAteco2007 TipoAteco2007Obj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZTipoAteco2007Update", new string[] {"CodTipoAteco2007", "Sezione", "Divisione", 
"Classe", "Gruppo", "Categoria", 
"Sottocategoria", "Descrizione", "Eliminato"}, new string[] {"string", "string", "string", 
"string", "string", "string", 
"string", "string", "bool"},"");
				CompileIUCmd(true, updateCmd,TipoAteco2007Obj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				TipoAteco2007Obj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TipoAteco2007Obj.IsDirty = false;
				TipoAteco2007Obj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, TipoAteco2007 TipoAteco2007Obj)
		{
			switch (TipoAteco2007Obj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, TipoAteco2007Obj);
				case BaseObject.ObjectStateType.Changed : return Update(db, TipoAteco2007Obj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,TipoAteco2007Obj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, TipoAteco2007Collection TipoAteco2007CollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZTipoAteco2007Update", new string[] {"CodTipoAteco2007", "Sezione", "Divisione", 
"Classe", "Gruppo", "Categoria", 
"Sottocategoria", "Descrizione", "Eliminato"}, new string[] {"string", "string", "string", 
"string", "string", "string", 
"string", "string", "bool"},"");
				IDbCommand insertCmd = db.InitCmd( "ZTipoAteco2007Insert", new string[] {"CodTipoAteco2007", "Sezione", "Divisione", 
"Classe", "Gruppo", "Categoria", 
"Sottocategoria", "Descrizione", "Eliminato"}, new string[] {"string", "string", "string", 
"string", "string", "string", 
"string", "string", "bool"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZTipoAteco2007Delete", new string[] {"CodTipoAteco2007"}, new string[] {"string"},"");
				for (int i = 0; i < TipoAteco2007CollectionObj.Count; i++)
				{
					switch (TipoAteco2007CollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,TipoAteco2007CollectionObj[i], db.CommandFirstChar);
								returnValue += db.Execute(insertCmd);
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,TipoAteco2007CollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (TipoAteco2007CollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodTipoAteco2007", (SiarLibrary.NullTypes.StringNT)TipoAteco2007CollectionObj[i].CodTipoAteco2007);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < TipoAteco2007CollectionObj.Count; i++)
				{
					if ((TipoAteco2007CollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (TipoAteco2007CollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						TipoAteco2007CollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						TipoAteco2007CollectionObj[i].IsDirty = false;
						TipoAteco2007CollectionObj[i].IsPersistent = true;
					}
					if ((TipoAteco2007CollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						TipoAteco2007CollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						TipoAteco2007CollectionObj[i].IsDirty = false;
						TipoAteco2007CollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, TipoAteco2007 TipoAteco2007Obj)
		{
			int returnValue = 0;
			if (TipoAteco2007Obj.IsPersistent) 
			{
				returnValue = Delete(db, TipoAteco2007Obj.CodTipoAteco2007);
			}
			TipoAteco2007Obj.ObjectState = BaseObject.ObjectStateType.Deleted;
			TipoAteco2007Obj.IsDirty = false;
			TipoAteco2007Obj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, string CodTipoAteco2007Value)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZTipoAteco2007Delete", new string[] {"CodTipoAteco2007"}, new string[] {"string"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodTipoAteco2007", (SiarLibrary.NullTypes.StringNT)CodTipoAteco2007Value);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, TipoAteco2007Collection TipoAteco2007CollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZTipoAteco2007Delete", new string[] {"CodTipoAteco2007"}, new string[] {"string"},"");
				for (int i = 0; i < TipoAteco2007CollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodTipoAteco2007", TipoAteco2007CollectionObj[i].CodTipoAteco2007);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < TipoAteco2007CollectionObj.Count; i++)
				{
					if ((TipoAteco2007CollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (TipoAteco2007CollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						TipoAteco2007CollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						TipoAteco2007CollectionObj[i].IsDirty = false;
						TipoAteco2007CollectionObj[i].IsPersistent = false;
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
		public static TipoAteco2007 GetById(DbProvider db, string CodTipoAteco2007Value)
		{
			TipoAteco2007 TipoAteco2007Obj = null;
			IDbCommand readCmd = db.InitCmd( "ZTipoAteco2007GetById", new string[] {"CodTipoAteco2007"}, new string[] {"string"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "CodTipoAteco2007", (SiarLibrary.NullTypes.StringNT)CodTipoAteco2007Value);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				TipoAteco2007Obj = GetFromDatareader(db);
				TipoAteco2007Obj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TipoAteco2007Obj.IsDirty = false;
				TipoAteco2007Obj.IsPersistent = true;
			}
			db.Close();
			return TipoAteco2007Obj;
		}

		//getFromDatareader
		public static TipoAteco2007 GetFromDatareader(DbProvider db)
		{
			TipoAteco2007 TipoAteco2007Obj = new TipoAteco2007();
			TipoAteco2007Obj.CodTipoAteco2007 = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_ATECO2007"]);
			TipoAteco2007Obj.Sezione = new SiarLibrary.NullTypes.StringNT(db.DataReader["Sezione"]);
			TipoAteco2007Obj.Divisione = new SiarLibrary.NullTypes.StringNT(db.DataReader["Divisione"]);
			TipoAteco2007Obj.Classe = new SiarLibrary.NullTypes.StringNT(db.DataReader["Classe"]);
			TipoAteco2007Obj.Gruppo = new SiarLibrary.NullTypes.StringNT(db.DataReader["Gruppo"]);
			TipoAteco2007Obj.Categoria = new SiarLibrary.NullTypes.StringNT(db.DataReader["Categoria"]);
			TipoAteco2007Obj.Sottocategoria = new SiarLibrary.NullTypes.StringNT(db.DataReader["Sottocategoria"]);
			TipoAteco2007Obj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["Descrizione"]);
			TipoAteco2007Obj.Eliminato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ELIMINATO"]);
			TipoAteco2007Obj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			TipoAteco2007Obj.IsDirty = false;
			TipoAteco2007Obj.IsPersistent = true;
			return TipoAteco2007Obj;
		}

		//Find Select

		public static TipoAteco2007Collection Select(DbProvider db, SiarLibrary.NullTypes.StringNT CodTipoAteco2007EqualThis, SiarLibrary.NullTypes.StringNT SezioneEqualThis, SiarLibrary.NullTypes.StringNT DivisioneEqualThis, 
SiarLibrary.NullTypes.StringNT GruppoEqualThis, SiarLibrary.NullTypes.StringNT ClasseEqualThis, SiarLibrary.NullTypes.StringNT CategoriaEqualThis, 
SiarLibrary.NullTypes.StringNT SottocategoriaEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.BoolNT EliminatoEqualThis)

		{

			TipoAteco2007Collection TipoAteco2007CollectionObj = new TipoAteco2007Collection();

			IDbCommand findCmd = db.InitCmd("Ztipoateco2007findselect", new string[] {"CodTipoAteco2007equalthis", "Sezioneequalthis", "Divisioneequalthis", 
"Gruppoequalthis", "Classeequalthis", "Categoriaequalthis", 
"Sottocategoriaequalthis", "Descrizioneequalthis", "Eliminatoequalthis"}, new string[] {"string", "string", "string", 
"string", "string", "string", 
"string", "string", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoAteco2007equalthis", CodTipoAteco2007EqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Sezioneequalthis", SezioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Divisioneequalthis", DivisioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Gruppoequalthis", GruppoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Classeequalthis", ClasseEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Categoriaequalthis", CategoriaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Sottocategoriaequalthis", SottocategoriaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Eliminatoequalthis", EliminatoEqualThis);
			TipoAteco2007 TipoAteco2007Obj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				TipoAteco2007Obj = GetFromDatareader(db);
				TipoAteco2007Obj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TipoAteco2007Obj.IsDirty = false;
				TipoAteco2007Obj.IsPersistent = true;
				TipoAteco2007CollectionObj.Add(TipoAteco2007Obj);
			}
			db.Close();
			return TipoAteco2007CollectionObj;
		}

		//Find Find

		public static TipoAteco2007Collection Find(DbProvider db, SiarLibrary.NullTypes.StringNT SottocategoriaLikeThis)

		{

			TipoAteco2007Collection TipoAteco2007CollectionObj = new TipoAteco2007Collection();

			IDbCommand findCmd = db.InitCmd("Ztipoateco2007findfind", new string[] {"Sottocategorialikethis"}, new string[] {"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Sottocategorialikethis", SottocategoriaLikeThis);
			TipoAteco2007 TipoAteco2007Obj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				TipoAteco2007Obj = GetFromDatareader(db);
				TipoAteco2007Obj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TipoAteco2007Obj.IsDirty = false;
				TipoAteco2007Obj.IsPersistent = true;
				TipoAteco2007CollectionObj.Add(TipoAteco2007Obj);
			}
			db.Close();
			return TipoAteco2007CollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for TipoAteco2007CollectionProvider:ITipoAteco2007Provider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class TipoAteco2007CollectionProvider : ITipoAteco2007Provider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di TipoAteco2007
		protected TipoAteco2007Collection _CollectionObj;

		//Costruttore 1: non popola la collection
		public TipoAteco2007CollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new TipoAteco2007Collection(this);
		}

		//Costruttore 2: popola la collection
		public TipoAteco2007CollectionProvider(StringNT SottocategoriaLikeThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(SottocategoriaLikeThis);
		}

		//Costruttore3: ha in input tipoateco2007CollectionObj - non popola la collection
		public TipoAteco2007CollectionProvider(TipoAteco2007Collection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public TipoAteco2007CollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new TipoAteco2007Collection(this);
		}

		//Get e Set
		public TipoAteco2007Collection CollectionObj
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
		public int SaveCollection(TipoAteco2007Collection collectionObj)
		{
			return TipoAteco2007DAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(TipoAteco2007 tipoateco2007Obj)
		{
			return TipoAteco2007DAL.Save(_dbProviderObj, tipoateco2007Obj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(TipoAteco2007Collection collectionObj)
		{
			return TipoAteco2007DAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(TipoAteco2007 tipoateco2007Obj)
		{
			return TipoAteco2007DAL.Delete(_dbProviderObj, tipoateco2007Obj);
		}

		//getById
		public TipoAteco2007 GetById(StringNT CodTipoAteco2007Value)
		{
			TipoAteco2007 TipoAteco2007Temp = TipoAteco2007DAL.GetById(_dbProviderObj, CodTipoAteco2007Value);
			if (TipoAteco2007Temp!=null) TipoAteco2007Temp.Provider = this;
			return TipoAteco2007Temp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public TipoAteco2007Collection Select(StringNT Codtipoateco2007EqualThis, StringNT SezioneEqualThis, StringNT DivisioneEqualThis, 
StringNT GruppoEqualThis, StringNT ClasseEqualThis, StringNT CategoriaEqualThis, 
StringNT SottocategoriaEqualThis, StringNT DescrizioneEqualThis, BoolNT EliminatoEqualThis)
		{
			TipoAteco2007Collection TipoAteco2007CollectionTemp = TipoAteco2007DAL.Select(_dbProviderObj, Codtipoateco2007EqualThis, SezioneEqualThis, DivisioneEqualThis, 
GruppoEqualThis, ClasseEqualThis, CategoriaEqualThis, 
SottocategoriaEqualThis, DescrizioneEqualThis, EliminatoEqualThis);
			TipoAteco2007CollectionTemp.Provider = this;
			return TipoAteco2007CollectionTemp;
		}

		//Find: popola la collection
		public TipoAteco2007Collection Find(StringNT SottocategoriaLikeThis)
		{
			TipoAteco2007Collection TipoAteco2007CollectionTemp = TipoAteco2007DAL.Find(_dbProviderObj, SottocategoriaLikeThis);
			TipoAteco2007CollectionTemp.Provider = this;
			return TipoAteco2007CollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<TIPO_ATECO2007>
  <ViewName>vTIPO_ATECO2007</ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
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
    <Find OrderBy="ORDER BY Sottocategoria">
      <Sottocategoria>Like</Sottocategoria>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</TIPO_ATECO2007>
*/
