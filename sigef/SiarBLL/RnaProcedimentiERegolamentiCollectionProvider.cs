using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per RnaProcedimentiERegolamenti
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IRnaProcedimentiERegolamentiProvider
	{
		int Save(RnaProcedimentiERegolamenti RnaProcedimentiERegolamentiObj);
		int SaveCollection(RnaProcedimentiERegolamentiCollection collectionObj);
		int Delete(RnaProcedimentiERegolamenti RnaProcedimentiERegolamentiObj);
		int DeleteCollection(RnaProcedimentiERegolamentiCollection collectionObj);
	}
	/// <summary>
	/// Summary description for RnaProcedimentiERegolamenti
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class RnaProcedimentiERegolamenti: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdProcedimentiRegolamenti;
		private NullTypes.IntNT _CodTipoProcedimento;
		private NullTypes.StringNT _DescrizioneProcedura;
		private NullTypes.StringNT _CodiceRegolamento;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.StringNT _CodiceSettore;
		private NullTypes.StringNT _Settore;
		[NonSerialized] private IRnaProcedimentiERegolamentiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRnaProcedimentiERegolamentiProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public RnaProcedimentiERegolamenti()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_PROCEDIMENTI_REGOLAMENTI
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProcedimentiRegolamenti
		{
			get { return _IdProcedimentiRegolamenti; }
			set {
				if (IdProcedimentiRegolamenti != value)
				{
					_IdProcedimentiRegolamenti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_TIPO_PROCEDIMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT CodTipoProcedimento
		{
			get { return _CodTipoProcedimento; }
			set {
				if (CodTipoProcedimento != value)
				{
					_CodTipoProcedimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_PROCEDURA
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT DescrizioneProcedura
		{
			get { return _DescrizioneProcedura; }
			set {
				if (DescrizioneProcedura != value)
				{
					_DescrizioneProcedura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE_REGOLAMENTO
		/// Tipo sul db:VARCHAR(30)
		/// </summary>
		public NullTypes.StringNT CodiceRegolamento
		{
			get { return _CodiceRegolamento; }
			set {
				if (CodiceRegolamento != value)
				{
					_CodiceRegolamento = value;
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
		/// Corrisponde al campo:CODICE_SETTORE
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT CodiceSettore
		{
			get { return _CodiceSettore; }
			set {
				if (CodiceSettore != value)
				{
					_CodiceSettore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SETTORE
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT Settore
		{
			get { return _Settore; }
			set {
				if (Settore != value)
				{
					_Settore = value;
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
	/// Summary description for RnaProcedimentiERegolamentiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RnaProcedimentiERegolamentiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private RnaProcedimentiERegolamentiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((RnaProcedimentiERegolamenti) info.GetValue(i.ToString(),typeof(RnaProcedimentiERegolamenti)));
			}
		}

		//Costruttore
		public RnaProcedimentiERegolamentiCollection()
		{
			this.ItemType = typeof(RnaProcedimentiERegolamenti);
		}

		//Costruttore con provider
		public RnaProcedimentiERegolamentiCollection(IRnaProcedimentiERegolamentiProvider providerObj)
		{
			this.ItemType = typeof(RnaProcedimentiERegolamenti);
			this.Provider = providerObj;
		}

		//Get e Set
		public new RnaProcedimentiERegolamenti this[int index]
		{
			get { return (RnaProcedimentiERegolamenti)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new RnaProcedimentiERegolamentiCollection GetChanges()
		{
			return (RnaProcedimentiERegolamentiCollection) base.GetChanges();
		}

		[NonSerialized] private IRnaProcedimentiERegolamentiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRnaProcedimentiERegolamentiProvider Provider
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
		public int Add(RnaProcedimentiERegolamenti RnaProcedimentiERegolamentiObj)
		{
			if (RnaProcedimentiERegolamentiObj.Provider == null) RnaProcedimentiERegolamentiObj.Provider = this.Provider;
			return base.Add(RnaProcedimentiERegolamentiObj);
		}

		//AddCollection
		public void AddCollection(RnaProcedimentiERegolamentiCollection RnaProcedimentiERegolamentiCollectionObj)
		{
			foreach (RnaProcedimentiERegolamenti RnaProcedimentiERegolamentiObj in RnaProcedimentiERegolamentiCollectionObj)
				this.Add(RnaProcedimentiERegolamentiObj);
		}

		//Insert
		public void Insert(int index, RnaProcedimentiERegolamenti RnaProcedimentiERegolamentiObj)
		{
			if (RnaProcedimentiERegolamentiObj.Provider == null) RnaProcedimentiERegolamentiObj.Provider = this.Provider;
			base.Insert(index, RnaProcedimentiERegolamentiObj);
		}

		//CollectionGetById
		public RnaProcedimentiERegolamenti CollectionGetById(NullTypes.IntNT IdProcedimentiRegolamentiValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdProcedimentiRegolamenti == IdProcedimentiRegolamentiValue))
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
		public RnaProcedimentiERegolamentiCollection SubSelect(NullTypes.IntNT IdProcedimentiRegolamentiEqualThis, NullTypes.IntNT CodTipoProcedimentoEqualThis, NullTypes.StringNT DescrizioneProceduraEqualThis, 
NullTypes.StringNT CodiceRegolamentoEqualThis, NullTypes.StringNT DescrizioneEqualThis, NullTypes.StringNT CodiceSettoreEqualThis, 
NullTypes.StringNT SettoreEqualThis)
		{
			RnaProcedimentiERegolamentiCollection RnaProcedimentiERegolamentiCollectionTemp = new RnaProcedimentiERegolamentiCollection();
			foreach (RnaProcedimentiERegolamenti RnaProcedimentiERegolamentiItem in this)
			{
				if (((IdProcedimentiRegolamentiEqualThis == null) || ((RnaProcedimentiERegolamentiItem.IdProcedimentiRegolamenti != null) && (RnaProcedimentiERegolamentiItem.IdProcedimentiRegolamenti.Value == IdProcedimentiRegolamentiEqualThis.Value))) && ((CodTipoProcedimentoEqualThis == null) || ((RnaProcedimentiERegolamentiItem.CodTipoProcedimento != null) && (RnaProcedimentiERegolamentiItem.CodTipoProcedimento.Value == CodTipoProcedimentoEqualThis.Value))) && ((DescrizioneProceduraEqualThis == null) || ((RnaProcedimentiERegolamentiItem.DescrizioneProcedura != null) && (RnaProcedimentiERegolamentiItem.DescrizioneProcedura.Value == DescrizioneProceduraEqualThis.Value))) && 
((CodiceRegolamentoEqualThis == null) || ((RnaProcedimentiERegolamentiItem.CodiceRegolamento != null) && (RnaProcedimentiERegolamentiItem.CodiceRegolamento.Value == CodiceRegolamentoEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((RnaProcedimentiERegolamentiItem.Descrizione != null) && (RnaProcedimentiERegolamentiItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((CodiceSettoreEqualThis == null) || ((RnaProcedimentiERegolamentiItem.CodiceSettore != null) && (RnaProcedimentiERegolamentiItem.CodiceSettore.Value == CodiceSettoreEqualThis.Value))) && 
((SettoreEqualThis == null) || ((RnaProcedimentiERegolamentiItem.Settore != null) && (RnaProcedimentiERegolamentiItem.Settore.Value == SettoreEqualThis.Value))))
				{
					RnaProcedimentiERegolamentiCollectionTemp.Add(RnaProcedimentiERegolamentiItem);
				}
			}
			return RnaProcedimentiERegolamentiCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for RnaProcedimentiERegolamentiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class RnaProcedimentiERegolamentiDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, RnaProcedimentiERegolamenti RnaProcedimentiERegolamentiObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdProcedimentiRegolamenti", RnaProcedimentiERegolamentiObj.IdProcedimentiRegolamenti);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipoProcedimento", RnaProcedimentiERegolamentiObj.CodTipoProcedimento);
			DbProvider.SetCmdParam(cmd,firstChar + "DescrizioneProcedura", RnaProcedimentiERegolamentiObj.DescrizioneProcedura);
			DbProvider.SetCmdParam(cmd,firstChar + "CodiceRegolamento", RnaProcedimentiERegolamentiObj.CodiceRegolamento);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", RnaProcedimentiERegolamentiObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "CodiceSettore", RnaProcedimentiERegolamentiObj.CodiceSettore);
			DbProvider.SetCmdParam(cmd,firstChar + "Settore", RnaProcedimentiERegolamentiObj.Settore);
		}
		//Insert
		private static int Insert(DbProvider db, RnaProcedimentiERegolamenti RnaProcedimentiERegolamentiObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZRnaProcedimentiERegolamentiInsert", new string[] {"CodTipoProcedimento", "DescrizioneProcedura", 
"CodiceRegolamento", "Descrizione", "CodiceSettore", 
"Settore"}, new string[] {"int", "string", 
"string", "string", "string", 
"string"},"");
				CompileIUCmd(false, insertCmd,RnaProcedimentiERegolamentiObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				RnaProcedimentiERegolamentiObj.IdProcedimentiRegolamenti = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROCEDIMENTI_REGOLAMENTI"]);
				}
				RnaProcedimentiERegolamentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaProcedimentiERegolamentiObj.IsDirty = false;
				RnaProcedimentiERegolamentiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, RnaProcedimentiERegolamenti RnaProcedimentiERegolamentiObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRnaProcedimentiERegolamentiUpdate", new string[] {"IdProcedimentiRegolamenti", "CodTipoProcedimento", "DescrizioneProcedura", 
"CodiceRegolamento", "Descrizione", "CodiceSettore", 
"Settore"}, new string[] {"int", "int", "string", 
"string", "string", "string", 
"string"},"");
				CompileIUCmd(true, updateCmd,RnaProcedimentiERegolamentiObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				RnaProcedimentiERegolamentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaProcedimentiERegolamentiObj.IsDirty = false;
				RnaProcedimentiERegolamentiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, RnaProcedimentiERegolamenti RnaProcedimentiERegolamentiObj)
		{
			switch (RnaProcedimentiERegolamentiObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, RnaProcedimentiERegolamentiObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, RnaProcedimentiERegolamentiObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,RnaProcedimentiERegolamentiObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, RnaProcedimentiERegolamentiCollection RnaProcedimentiERegolamentiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRnaProcedimentiERegolamentiUpdate", new string[] {"IdProcedimentiRegolamenti", "CodTipoProcedimento", "DescrizioneProcedura", 
"CodiceRegolamento", "Descrizione", "CodiceSettore", 
"Settore"}, new string[] {"int", "int", "string", 
"string", "string", "string", 
"string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZRnaProcedimentiERegolamentiInsert", new string[] {"CodTipoProcedimento", "DescrizioneProcedura", 
"CodiceRegolamento", "Descrizione", "CodiceSettore", 
"Settore"}, new string[] {"int", "string", 
"string", "string", "string", 
"string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZRnaProcedimentiERegolamentiDelete", new string[] {"IdProcedimentiRegolamenti"}, new string[] {"int"},"");
				for (int i = 0; i < RnaProcedimentiERegolamentiCollectionObj.Count; i++)
				{
					switch (RnaProcedimentiERegolamentiCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,RnaProcedimentiERegolamentiCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									RnaProcedimentiERegolamentiCollectionObj[i].IdProcedimentiRegolamenti = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROCEDIMENTI_REGOLAMENTI"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,RnaProcedimentiERegolamentiCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (RnaProcedimentiERegolamentiCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProcedimentiRegolamenti", (SiarLibrary.NullTypes.IntNT)RnaProcedimentiERegolamentiCollectionObj[i].IdProcedimentiRegolamenti);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < RnaProcedimentiERegolamentiCollectionObj.Count; i++)
				{
					if ((RnaProcedimentiERegolamentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RnaProcedimentiERegolamentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RnaProcedimentiERegolamentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						RnaProcedimentiERegolamentiCollectionObj[i].IsDirty = false;
						RnaProcedimentiERegolamentiCollectionObj[i].IsPersistent = true;
					}
					if ((RnaProcedimentiERegolamentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						RnaProcedimentiERegolamentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RnaProcedimentiERegolamentiCollectionObj[i].IsDirty = false;
						RnaProcedimentiERegolamentiCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, RnaProcedimentiERegolamenti RnaProcedimentiERegolamentiObj)
		{
			int returnValue = 0;
			if (RnaProcedimentiERegolamentiObj.IsPersistent) 
			{
				returnValue = Delete(db, RnaProcedimentiERegolamentiObj.IdProcedimentiRegolamenti);
			}
			RnaProcedimentiERegolamentiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			RnaProcedimentiERegolamentiObj.IsDirty = false;
			RnaProcedimentiERegolamentiObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdProcedimentiRegolamentiValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRnaProcedimentiERegolamentiDelete", new string[] {"IdProcedimentiRegolamenti"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProcedimentiRegolamenti", (SiarLibrary.NullTypes.IntNT)IdProcedimentiRegolamentiValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, RnaProcedimentiERegolamentiCollection RnaProcedimentiERegolamentiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRnaProcedimentiERegolamentiDelete", new string[] {"IdProcedimentiRegolamenti"}, new string[] {"int"},"");
				for (int i = 0; i < RnaProcedimentiERegolamentiCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProcedimentiRegolamenti", RnaProcedimentiERegolamentiCollectionObj[i].IdProcedimentiRegolamenti);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < RnaProcedimentiERegolamentiCollectionObj.Count; i++)
				{
					if ((RnaProcedimentiERegolamentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RnaProcedimentiERegolamentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RnaProcedimentiERegolamentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RnaProcedimentiERegolamentiCollectionObj[i].IsDirty = false;
						RnaProcedimentiERegolamentiCollectionObj[i].IsPersistent = false;
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
		public static RnaProcedimentiERegolamenti GetById(DbProvider db, int IdProcedimentiRegolamentiValue)
		{
			RnaProcedimentiERegolamenti RnaProcedimentiERegolamentiObj = null;
			IDbCommand readCmd = db.InitCmd( "ZRnaProcedimentiERegolamentiGetById", new string[] {"IdProcedimentiRegolamenti"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdProcedimentiRegolamenti", (SiarLibrary.NullTypes.IntNT)IdProcedimentiRegolamentiValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				RnaProcedimentiERegolamentiObj = GetFromDatareader(db);
				RnaProcedimentiERegolamentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaProcedimentiERegolamentiObj.IsDirty = false;
				RnaProcedimentiERegolamentiObj.IsPersistent = true;
			}
			db.Close();
			return RnaProcedimentiERegolamentiObj;
		}

		//getFromDatareader
		public static RnaProcedimentiERegolamenti GetFromDatareader(DbProvider db)
		{
			RnaProcedimentiERegolamenti RnaProcedimentiERegolamentiObj = new RnaProcedimentiERegolamenti();
			RnaProcedimentiERegolamentiObj.IdProcedimentiRegolamenti = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROCEDIMENTI_REGOLAMENTI"]);
			RnaProcedimentiERegolamentiObj.CodTipoProcedimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["COD_TIPO_PROCEDIMENTO"]);
			RnaProcedimentiERegolamentiObj.DescrizioneProcedura = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_PROCEDURA"]);
			RnaProcedimentiERegolamentiObj.CodiceRegolamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_REGOLAMENTO"]);
			RnaProcedimentiERegolamentiObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			RnaProcedimentiERegolamentiObj.CodiceSettore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_SETTORE"]);
			RnaProcedimentiERegolamentiObj.Settore = new SiarLibrary.NullTypes.StringNT(db.DataReader["SETTORE"]);
			RnaProcedimentiERegolamentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			RnaProcedimentiERegolamentiObj.IsDirty = false;
			RnaProcedimentiERegolamentiObj.IsPersistent = true;
			return RnaProcedimentiERegolamentiObj;
		}

		//Find Select

		public static RnaProcedimentiERegolamentiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdProcedimentiRegolamentiEqualThis, SiarLibrary.NullTypes.IntNT CodTipoProcedimentoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneProceduraEqualThis, 
SiarLibrary.NullTypes.StringNT CodiceRegolamentoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.StringNT CodiceSettoreEqualThis, 
SiarLibrary.NullTypes.StringNT SettoreEqualThis)

		{

			RnaProcedimentiERegolamentiCollection RnaProcedimentiERegolamentiCollectionObj = new RnaProcedimentiERegolamentiCollection();

			IDbCommand findCmd = db.InitCmd("Zrnaprocedimentieregolamentifindselect", new string[] {"IdProcedimentiRegolamentiequalthis", "CodTipoProcedimentoequalthis", "DescrizioneProceduraequalthis", 
"CodiceRegolamentoequalthis", "Descrizioneequalthis", "CodiceSettoreequalthis", 
"Settoreequalthis"}, new string[] {"int", "int", "string", 
"string", "string", "string", 
"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProcedimentiRegolamentiequalthis", IdProcedimentiRegolamentiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoProcedimentoequalthis", CodTipoProcedimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneProceduraequalthis", DescrizioneProceduraEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceRegolamentoequalthis", CodiceRegolamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceSettoreequalthis", CodiceSettoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Settoreequalthis", SettoreEqualThis);
			RnaProcedimentiERegolamenti RnaProcedimentiERegolamentiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RnaProcedimentiERegolamentiObj = GetFromDatareader(db);
				RnaProcedimentiERegolamentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaProcedimentiERegolamentiObj.IsDirty = false;
				RnaProcedimentiERegolamentiObj.IsPersistent = true;
				RnaProcedimentiERegolamentiCollectionObj.Add(RnaProcedimentiERegolamentiObj);
			}
			db.Close();
			return RnaProcedimentiERegolamentiCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for RnaProcedimentiERegolamentiCollectionProvider:IRnaProcedimentiERegolamentiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RnaProcedimentiERegolamentiCollectionProvider : IRnaProcedimentiERegolamentiProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di RnaProcedimentiERegolamenti
		protected RnaProcedimentiERegolamentiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public RnaProcedimentiERegolamentiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new RnaProcedimentiERegolamentiCollection(this);
		}

		//Costruttore3: ha in input rnaprocedimentieregolamentiCollectionObj - non popola la collection
		public RnaProcedimentiERegolamentiCollectionProvider(RnaProcedimentiERegolamentiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public RnaProcedimentiERegolamentiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new RnaProcedimentiERegolamentiCollection(this);
		}

		//Get e Set
		public RnaProcedimentiERegolamentiCollection CollectionObj
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
		public int SaveCollection(RnaProcedimentiERegolamentiCollection collectionObj)
		{
			return RnaProcedimentiERegolamentiDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(RnaProcedimentiERegolamenti rnaprocedimentieregolamentiObj)
		{
			return RnaProcedimentiERegolamentiDAL.Save(_dbProviderObj, rnaprocedimentieregolamentiObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(RnaProcedimentiERegolamentiCollection collectionObj)
		{
			return RnaProcedimentiERegolamentiDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(RnaProcedimentiERegolamenti rnaprocedimentieregolamentiObj)
		{
			return RnaProcedimentiERegolamentiDAL.Delete(_dbProviderObj, rnaprocedimentieregolamentiObj);
		}

		//getById
		public RnaProcedimentiERegolamenti GetById(IntNT IdProcedimentiRegolamentiValue)
		{
			RnaProcedimentiERegolamenti RnaProcedimentiERegolamentiTemp = RnaProcedimentiERegolamentiDAL.GetById(_dbProviderObj, IdProcedimentiRegolamentiValue);
			if (RnaProcedimentiERegolamentiTemp!=null) RnaProcedimentiERegolamentiTemp.Provider = this;
			return RnaProcedimentiERegolamentiTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public RnaProcedimentiERegolamentiCollection Select(IntNT IdprocedimentiregolamentiEqualThis, IntNT CodtipoprocedimentoEqualThis, StringNT DescrizioneproceduraEqualThis, 
StringNT CodiceregolamentoEqualThis, StringNT DescrizioneEqualThis, StringNT CodicesettoreEqualThis, 
StringNT SettoreEqualThis)
		{
			RnaProcedimentiERegolamentiCollection RnaProcedimentiERegolamentiCollectionTemp = RnaProcedimentiERegolamentiDAL.Select(_dbProviderObj, IdprocedimentiregolamentiEqualThis, CodtipoprocedimentoEqualThis, DescrizioneproceduraEqualThis, 
CodiceregolamentoEqualThis, DescrizioneEqualThis, CodicesettoreEqualThis, 
SettoreEqualThis);
			RnaProcedimentiERegolamentiCollectionTemp.Provider = this;
			return RnaProcedimentiERegolamentiCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<RNA_PROCEDIMENTI_E_REGOLAMENTI>
  <ViewName>
  </ViewName>
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
  <Finds />
  <Filters />
  <externalFields />
  <AddedFkFields />
</RNA_PROCEDIMENTI_E_REGOLAMENTI>
*/
