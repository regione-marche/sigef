using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per FiltroChecklistVoce
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IFiltroChecklistVoceProvider
	{
		int Save(FiltroChecklistVoce FiltroChecklistVoceObj);
		int SaveCollection(FiltroChecklistVoceCollection collectionObj);
		int Delete(FiltroChecklistVoce FiltroChecklistVoceObj);
		int DeleteCollection(FiltroChecklistVoceCollection collectionObj);
	}
	/// <summary>
	/// Summary description for FiltroChecklistVoce
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class FiltroChecklistVoce: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.StringNT _IdFiltro;
		private NullTypes.StringNT _CfInserimento;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.StringNT _CfModifica;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.IntNT _Ordine;
		[NonSerialized] private IFiltroChecklistVoceProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IFiltroChecklistVoceProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public FiltroChecklistVoce()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_FILTRO
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT IdFiltro
		{
			get { return _IdFiltro; }
			set {
				if (IdFiltro != value)
				{
					_IdFiltro = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_INSERIMENTO
		/// Tipo sul db:VARCHAR(16)
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
		/// Corrisponde al campo:CF_MODIFICA
		/// Tipo sul db:VARCHAR(16)
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
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(-1)
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
	/// Summary description for FiltroChecklistVoceCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class FiltroChecklistVoceCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private FiltroChecklistVoceCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((FiltroChecklistVoce) info.GetValue(i.ToString(),typeof(FiltroChecklistVoce)));
			}
		}

		//Costruttore
		public FiltroChecklistVoceCollection()
		{
			this.ItemType = typeof(FiltroChecklistVoce);
		}

		//Costruttore con provider
		public FiltroChecklistVoceCollection(IFiltroChecklistVoceProvider providerObj)
		{
			this.ItemType = typeof(FiltroChecklistVoce);
			this.Provider = providerObj;
		}

		//Get e Set
		public new FiltroChecklistVoce this[int index]
		{
			get { return (FiltroChecklistVoce)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new FiltroChecklistVoceCollection GetChanges()
		{
			return (FiltroChecklistVoceCollection) base.GetChanges();
		}

		[NonSerialized] private IFiltroChecklistVoceProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IFiltroChecklistVoceProvider Provider
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
		public int Add(FiltroChecklistVoce FiltroChecklistVoceObj)
		{
			if (FiltroChecklistVoceObj.Provider == null) FiltroChecklistVoceObj.Provider = this.Provider;
			return base.Add(FiltroChecklistVoceObj);
		}

		//AddCollection
		public void AddCollection(FiltroChecklistVoceCollection FiltroChecklistVoceCollectionObj)
		{
			foreach (FiltroChecklistVoce FiltroChecklistVoceObj in FiltroChecklistVoceCollectionObj)
				this.Add(FiltroChecklistVoceObj);
		}

		//Insert
		public void Insert(int index, FiltroChecklistVoce FiltroChecklistVoceObj)
		{
			if (FiltroChecklistVoceObj.Provider == null) FiltroChecklistVoceObj.Provider = this.Provider;
			base.Insert(index, FiltroChecklistVoceObj);
		}

		//CollectionGetById
		public FiltroChecklistVoce CollectionGetById(NullTypes.StringNT IdFiltroValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdFiltro == IdFiltroValue))
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
		public FiltroChecklistVoceCollection SubSelect(NullTypes.StringNT IdFiltroEqualThis, NullTypes.StringNT CfInserimentoEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, 
NullTypes.StringNT CfModificaEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.StringNT DescrizioneEqualThis, 
NullTypes.IntNT OrdineEqualThis)
		{
			FiltroChecklistVoceCollection FiltroChecklistVoceCollectionTemp = new FiltroChecklistVoceCollection();
			foreach (FiltroChecklistVoce FiltroChecklistVoceItem in this)
			{
				if (((IdFiltroEqualThis == null) || ((FiltroChecklistVoceItem.IdFiltro != null) && (FiltroChecklistVoceItem.IdFiltro.Value == IdFiltroEqualThis.Value))) && ((CfInserimentoEqualThis == null) || ((FiltroChecklistVoceItem.CfInserimento != null) && (FiltroChecklistVoceItem.CfInserimento.Value == CfInserimentoEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((FiltroChecklistVoceItem.DataInserimento != null) && (FiltroChecklistVoceItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && 
((CfModificaEqualThis == null) || ((FiltroChecklistVoceItem.CfModifica != null) && (FiltroChecklistVoceItem.CfModifica.Value == CfModificaEqualThis.Value))) && ((DataModificaEqualThis == null) || ((FiltroChecklistVoceItem.DataModifica != null) && (FiltroChecklistVoceItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((FiltroChecklistVoceItem.Descrizione != null) && (FiltroChecklistVoceItem.Descrizione.Value == DescrizioneEqualThis.Value))) && 
((OrdineEqualThis == null) || ((FiltroChecklistVoceItem.Ordine != null) && (FiltroChecklistVoceItem.Ordine.Value == OrdineEqualThis.Value))))
				{
					FiltroChecklistVoceCollectionTemp.Add(FiltroChecklistVoceItem);
				}
			}
			return FiltroChecklistVoceCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for FiltroChecklistVoceDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class FiltroChecklistVoceDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, FiltroChecklistVoce FiltroChecklistVoceObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdFiltro", FiltroChecklistVoceObj.IdFiltro);
			DbProvider.SetCmdParam(cmd,firstChar + "CfInserimento", FiltroChecklistVoceObj.CfInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", FiltroChecklistVoceObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "CfModifica", FiltroChecklistVoceObj.CfModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", FiltroChecklistVoceObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", FiltroChecklistVoceObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "Ordine", FiltroChecklistVoceObj.Ordine);
		}
		//Insert
		private static int Insert(DbProvider db, FiltroChecklistVoce FiltroChecklistVoceObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZFiltroChecklistVoceInsert", new string[] {"IdFiltro", "CfInserimento", "DataInserimento", 
"CfModifica", "DataModifica", "Descrizione", 
"Ordine"}, new string[] {"string", "string", "DateTime", 
"string", "DateTime", "string", 
"int"},"");
				CompileIUCmd(false, insertCmd,FiltroChecklistVoceObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				FiltroChecklistVoceObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
				}
				FiltroChecklistVoceObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				FiltroChecklistVoceObj.IsDirty = false;
				FiltroChecklistVoceObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, FiltroChecklistVoce FiltroChecklistVoceObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZFiltroChecklistVoceUpdate", new string[] {"IdFiltro", "CfInserimento", "DataInserimento", 
"CfModifica", "DataModifica", "Descrizione", 
"Ordine"}, new string[] {"string", "string", "DateTime", 
"string", "DateTime", "string", 
"int"},"");
				CompileIUCmd(true, updateCmd,FiltroChecklistVoceObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					FiltroChecklistVoceObj.DataModifica = d;
				}
				FiltroChecklistVoceObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				FiltroChecklistVoceObj.IsDirty = false;
				FiltroChecklistVoceObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, FiltroChecklistVoce FiltroChecklistVoceObj)
		{
			switch (FiltroChecklistVoceObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, FiltroChecklistVoceObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, FiltroChecklistVoceObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,FiltroChecklistVoceObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, FiltroChecklistVoceCollection FiltroChecklistVoceCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZFiltroChecklistVoceUpdate", new string[] {"IdFiltro", "CfInserimento", "DataInserimento", 
"CfModifica", "DataModifica", "Descrizione", 
"Ordine"}, new string[] {"string", "string", "DateTime", 
"string", "DateTime", "string", 
"int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZFiltroChecklistVoceInsert", new string[] {"IdFiltro", "CfInserimento", "DataInserimento", 
"CfModifica", "DataModifica", "Descrizione", 
"Ordine"}, new string[] {"string", "string", "DateTime", 
"string", "DateTime", "string", 
"int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZFiltroChecklistVoceDelete", new string[] {"IdFiltro"}, new string[] {"string"},"");
				for (int i = 0; i < FiltroChecklistVoceCollectionObj.Count; i++)
				{
					switch (FiltroChecklistVoceCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,FiltroChecklistVoceCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									FiltroChecklistVoceCollectionObj[i].DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,FiltroChecklistVoceCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									FiltroChecklistVoceCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (FiltroChecklistVoceCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdFiltro", (SiarLibrary.NullTypes.StringNT)FiltroChecklistVoceCollectionObj[i].IdFiltro);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < FiltroChecklistVoceCollectionObj.Count; i++)
				{
					if ((FiltroChecklistVoceCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (FiltroChecklistVoceCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						FiltroChecklistVoceCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						FiltroChecklistVoceCollectionObj[i].IsDirty = false;
						FiltroChecklistVoceCollectionObj[i].IsPersistent = true;
					}
					if ((FiltroChecklistVoceCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						FiltroChecklistVoceCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						FiltroChecklistVoceCollectionObj[i].IsDirty = false;
						FiltroChecklistVoceCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, FiltroChecklistVoce FiltroChecklistVoceObj)
		{
			int returnValue = 0;
			if (FiltroChecklistVoceObj.IsPersistent) 
			{
				returnValue = Delete(db, FiltroChecklistVoceObj.IdFiltro);
			}
			FiltroChecklistVoceObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			FiltroChecklistVoceObj.IsDirty = false;
			FiltroChecklistVoceObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, string IdFiltroValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZFiltroChecklistVoceDelete", new string[] {"IdFiltro"}, new string[] {"string"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdFiltro", (SiarLibrary.NullTypes.StringNT)IdFiltroValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, FiltroChecklistVoceCollection FiltroChecklistVoceCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZFiltroChecklistVoceDelete", new string[] {"IdFiltro"}, new string[] {"string"},"");
				for (int i = 0; i < FiltroChecklistVoceCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdFiltro", FiltroChecklistVoceCollectionObj[i].IdFiltro);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < FiltroChecklistVoceCollectionObj.Count; i++)
				{
					if ((FiltroChecklistVoceCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (FiltroChecklistVoceCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						FiltroChecklistVoceCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						FiltroChecklistVoceCollectionObj[i].IsDirty = false;
						FiltroChecklistVoceCollectionObj[i].IsPersistent = false;
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
		public static FiltroChecklistVoce GetById(DbProvider db, string IdFiltroValue)
		{
			FiltroChecklistVoce FiltroChecklistVoceObj = null;
			IDbCommand readCmd = db.InitCmd( "ZFiltroChecklistVoceGetById", new string[] {"IdFiltro"}, new string[] {"string"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdFiltro", (SiarLibrary.NullTypes.StringNT)IdFiltroValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				FiltroChecklistVoceObj = GetFromDatareader(db);
				FiltroChecklistVoceObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				FiltroChecklistVoceObj.IsDirty = false;
				FiltroChecklistVoceObj.IsPersistent = true;
			}
			db.Close();
			return FiltroChecklistVoceObj;
		}

		//getFromDatareader
		public static FiltroChecklistVoce GetFromDatareader(DbProvider db)
		{
			FiltroChecklistVoce FiltroChecklistVoceObj = new FiltroChecklistVoce();
			FiltroChecklistVoceObj.IdFiltro = new SiarLibrary.NullTypes.StringNT(db.DataReader["ID_FILTRO"]);
			FiltroChecklistVoceObj.CfInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_INSERIMENTO"]);
			FiltroChecklistVoceObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			FiltroChecklistVoceObj.CfModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_MODIFICA"]);
			FiltroChecklistVoceObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			FiltroChecklistVoceObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			FiltroChecklistVoceObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
			FiltroChecklistVoceObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			FiltroChecklistVoceObj.IsDirty = false;
			FiltroChecklistVoceObj.IsPersistent = true;
			return FiltroChecklistVoceObj;
		}

		//Find Select

		public static FiltroChecklistVoceCollection Select(DbProvider db, SiarLibrary.NullTypes.StringNT IdFiltroEqualThis, SiarLibrary.NullTypes.StringNT CfInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, 
SiarLibrary.NullTypes.StringNT CfModificaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, 
SiarLibrary.NullTypes.IntNT OrdineEqualThis)

		{

			FiltroChecklistVoceCollection FiltroChecklistVoceCollectionObj = new FiltroChecklistVoceCollection();

			IDbCommand findCmd = db.InitCmd("Zfiltrochecklistvocefindselect", new string[] {"IdFiltroequalthis", "CfInserimentoequalthis", "DataInserimentoequalthis", 
"CfModificaequalthis", "DataModificaequalthis", "Descrizioneequalthis", 
"Ordineequalthis"}, new string[] {"string", "string", "DateTime", 
"string", "DateTime", "string", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFiltroequalthis", IdFiltroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfInserimentoequalthis", CfInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfModificaequalthis", CfModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
			FiltroChecklistVoce FiltroChecklistVoceObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				FiltroChecklistVoceObj = GetFromDatareader(db);
				FiltroChecklistVoceObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				FiltroChecklistVoceObj.IsDirty = false;
				FiltroChecklistVoceObj.IsPersistent = true;
				FiltroChecklistVoceCollectionObj.Add(FiltroChecklistVoceObj);
			}
			db.Close();
			return FiltroChecklistVoceCollectionObj;
		}

		//Find FindFiltro

		public static FiltroChecklistVoceCollection FindFiltro(DbProvider db, SiarLibrary.NullTypes.StringNT IdFiltroEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.IntNT OrdineEqualThis)

		{

			FiltroChecklistVoceCollection FiltroChecklistVoceCollectionObj = new FiltroChecklistVoceCollection();

			IDbCommand findCmd = db.InitCmd("Zfiltrochecklistvocefindfindfiltro", new string[] {"IdFiltroequalthis", "Descrizioneequalthis", "Ordineequalthis"}, new string[] {"string", "string", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFiltroequalthis", IdFiltroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
			FiltroChecklistVoce FiltroChecklistVoceObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				FiltroChecklistVoceObj = GetFromDatareader(db);
				FiltroChecklistVoceObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				FiltroChecklistVoceObj.IsDirty = false;
				FiltroChecklistVoceObj.IsPersistent = true;
				FiltroChecklistVoceCollectionObj.Add(FiltroChecklistVoceObj);
			}
			db.Close();
			return FiltroChecklistVoceCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for FiltroChecklistVoceCollectionProvider:IFiltroChecklistVoceProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class FiltroChecklistVoceCollectionProvider : IFiltroChecklistVoceProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di FiltroChecklistVoce
		protected FiltroChecklistVoceCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public FiltroChecklistVoceCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new FiltroChecklistVoceCollection(this);
		}

		//Costruttore 2: popola la collection
		public FiltroChecklistVoceCollectionProvider(StringNT IdfiltroEqualThis, StringNT DescrizioneEqualThis, IntNT OrdineEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = FindFiltro(IdfiltroEqualThis, DescrizioneEqualThis, OrdineEqualThis);
		}

		//Costruttore3: ha in input filtrochecklistvoceCollectionObj - non popola la collection
		public FiltroChecklistVoceCollectionProvider(FiltroChecklistVoceCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public FiltroChecklistVoceCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new FiltroChecklistVoceCollection(this);
		}

		//Get e Set
		public FiltroChecklistVoceCollection CollectionObj
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
		public int SaveCollection(FiltroChecklistVoceCollection collectionObj)
		{
			return FiltroChecklistVoceDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(FiltroChecklistVoce filtrochecklistvoceObj)
		{
			return FiltroChecklistVoceDAL.Save(_dbProviderObj, filtrochecklistvoceObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(FiltroChecklistVoceCollection collectionObj)
		{
			return FiltroChecklistVoceDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(FiltroChecklistVoce filtrochecklistvoceObj)
		{
			return FiltroChecklistVoceDAL.Delete(_dbProviderObj, filtrochecklistvoceObj);
		}

		//getById
		public FiltroChecklistVoce GetById(StringNT IdFiltroValue)
		{
			FiltroChecklistVoce FiltroChecklistVoceTemp = FiltroChecklistVoceDAL.GetById(_dbProviderObj, IdFiltroValue);
			if (FiltroChecklistVoceTemp!=null) FiltroChecklistVoceTemp.Provider = this;
			return FiltroChecklistVoceTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public FiltroChecklistVoceCollection Select(StringNT IdfiltroEqualThis, StringNT CfinserimentoEqualThis, DatetimeNT DatainserimentoEqualThis, 
StringNT CfmodificaEqualThis, DatetimeNT DatamodificaEqualThis, StringNT DescrizioneEqualThis, 
IntNT OrdineEqualThis)
		{
			FiltroChecklistVoceCollection FiltroChecklistVoceCollectionTemp = FiltroChecklistVoceDAL.Select(_dbProviderObj, IdfiltroEqualThis, CfinserimentoEqualThis, DatainserimentoEqualThis, 
CfmodificaEqualThis, DatamodificaEqualThis, DescrizioneEqualThis, 
OrdineEqualThis);
			FiltroChecklistVoceCollectionTemp.Provider = this;
			return FiltroChecklistVoceCollectionTemp;
		}

		//FindFiltro: popola la collection
		public FiltroChecklistVoceCollection FindFiltro(StringNT IdfiltroEqualThis, StringNT DescrizioneEqualThis, IntNT OrdineEqualThis)
		{
			FiltroChecklistVoceCollection FiltroChecklistVoceCollectionTemp = FiltroChecklistVoceDAL.FindFiltro(_dbProviderObj, IdfiltroEqualThis, DescrizioneEqualThis, OrdineEqualThis);
			FiltroChecklistVoceCollectionTemp.Provider = this;
			return FiltroChecklistVoceCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<FILTRO_CHECKLIST_VOCE>
  <ViewName>VFILTRO_CHECKLIST_VOCE</ViewName>
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
    <FindFiltro OrderBy="ORDER BY ORDINE">
      <ID_FILTRO>Equal</ID_FILTRO>
      <DESCRIZIONE>Equal</DESCRIZIONE>
      <ORDINE>Equal</ORDINE>
    </FindFiltro>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</FILTRO_CHECKLIST_VOCE>
*/
