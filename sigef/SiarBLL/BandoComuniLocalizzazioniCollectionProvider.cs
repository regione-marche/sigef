using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per BandoComuniLocalizzazioni
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IBandoComuniLocalizzazioniProvider
	{
		int Save(BandoComuniLocalizzazioni BandoComuniLocalizzazioniObj);
		int SaveCollection(BandoComuniLocalizzazioniCollection collectionObj);
		int Delete(BandoComuniLocalizzazioni BandoComuniLocalizzazioniObj);
		int DeleteCollection(BandoComuniLocalizzazioniCollection collectionObj);
	}
	/// <summary>
	/// Summary description for BandoComuniLocalizzazioni
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class BandoComuniLocalizzazioni: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdBando;
		private NullTypes.IntNT _IdComune;
		private NullTypes.IntNT _EffettoSuContributo;
		private NullTypes.BoolNT _IsAttivo;
		private NullTypes.StringNT _CodBelfiore;
		private NullTypes.StringNT _Denominazione;
		private NullTypes.StringNT _CodProvincia;
		private NullTypes.StringNT _Sigla;
		private NullTypes.StringNT _Cap;
		private NullTypes.StringNT _Istat;
		private NullTypes.BoolNT _Attivo;
		private NullTypes.StringNT _TipoArea;
		private NullTypes.StringNT _CodRubricaPaleo;
		[NonSerialized] private IBandoComuniLocalizzazioniProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBandoComuniLocalizzazioniProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public BandoComuniLocalizzazioni()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
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
		/// Corrisponde al campo:ID_COMUNE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdComune
		{
			get { return _IdComune; }
			set {
				if (IdComune != value)
				{
					_IdComune = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:EFFETTO_SU_CONTRIBUTO
		/// Tipo sul db:SMALLINT
		/// Default:((0))
		/// </summary>
		public NullTypes.IntNT EffettoSuContributo
		{
			get { return _EffettoSuContributo; }
			set {
				if (EffettoSuContributo != value)
				{
					_EffettoSuContributo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IS_ATTIVO
		/// Tipo sul db:BIT
		/// Default:((1))
		/// </summary>
		public NullTypes.BoolNT IsAttivo
		{
			get { return _IsAttivo; }
			set {
				if (IsAttivo != value)
				{
					_IsAttivo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_BELFIORE
		/// Tipo sul db:CHAR(4)
		/// </summary>
		public NullTypes.StringNT CodBelfiore
		{
			get { return _CodBelfiore; }
			set {
				if (CodBelfiore != value)
				{
					_CodBelfiore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DENOMINAZIONE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Denominazione
		{
			get { return _Denominazione; }
			set {
				if (Denominazione != value)
				{
					_Denominazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_PROVINCIA
		/// Tipo sul db:CHAR(3)
		/// </summary>
		public NullTypes.StringNT CodProvincia
		{
			get { return _CodProvincia; }
			set {
				if (CodProvincia != value)
				{
					_CodProvincia = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SIGLA
		/// Tipo sul db:CHAR(2)
		/// </summary>
		public NullTypes.StringNT Sigla
		{
			get { return _Sigla; }
			set {
				if (Sigla != value)
				{
					_Sigla = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CAP
		/// Tipo sul db:VARCHAR(5)
		/// </summary>
		public NullTypes.StringNT Cap
		{
			get { return _Cap; }
			set {
				if (Cap != value)
				{
					_Cap = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ISTAT
		/// Tipo sul db:CHAR(3)
		/// </summary>
		public NullTypes.StringNT Istat
		{
			get { return _Istat; }
			set {
				if (Istat != value)
				{
					_Istat = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ATTIVO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Attivo
		{
			get { return _Attivo; }
			set {
				if (Attivo != value)
				{
					_Attivo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO_AREA
		/// Tipo sul db:VARCHAR(2)
		/// </summary>
		public NullTypes.StringNT TipoArea
		{
			get { return _TipoArea; }
			set {
				if (TipoArea != value)
				{
					_TipoArea = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_RUBRICA_PALEO
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT CodRubricaPaleo
		{
			get { return _CodRubricaPaleo; }
			set {
				if (CodRubricaPaleo != value)
				{
					_CodRubricaPaleo = value;
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
	/// Summary description for BandoComuniLocalizzazioniCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class BandoComuniLocalizzazioniCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private BandoComuniLocalizzazioniCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((BandoComuniLocalizzazioni) info.GetValue(i.ToString(),typeof(BandoComuniLocalizzazioni)));
			}
		}

		//Costruttore
		public BandoComuniLocalizzazioniCollection()
		{
			this.ItemType = typeof(BandoComuniLocalizzazioni);
		}

		//Costruttore con provider
		public BandoComuniLocalizzazioniCollection(IBandoComuniLocalizzazioniProvider providerObj)
		{
			this.ItemType = typeof(BandoComuniLocalizzazioni);
			this.Provider = providerObj;
		}

		//Get e Set
		public new BandoComuniLocalizzazioni this[int index]
		{
			get { return (BandoComuniLocalizzazioni)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new BandoComuniLocalizzazioniCollection GetChanges()
		{
			return (BandoComuniLocalizzazioniCollection) base.GetChanges();
		}

		[NonSerialized] private IBandoComuniLocalizzazioniProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBandoComuniLocalizzazioniProvider Provider
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
		public int Add(BandoComuniLocalizzazioni BandoComuniLocalizzazioniObj)
		{
			if (BandoComuniLocalizzazioniObj.Provider == null) BandoComuniLocalizzazioniObj.Provider = this.Provider;
			return base.Add(BandoComuniLocalizzazioniObj);
		}

		//AddCollection
		public void AddCollection(BandoComuniLocalizzazioniCollection BandoComuniLocalizzazioniCollectionObj)
		{
			foreach (BandoComuniLocalizzazioni BandoComuniLocalizzazioniObj in BandoComuniLocalizzazioniCollectionObj)
				this.Add(BandoComuniLocalizzazioniObj);
		}

		//Insert
		public void Insert(int index, BandoComuniLocalizzazioni BandoComuniLocalizzazioniObj)
		{
			if (BandoComuniLocalizzazioniObj.Provider == null) BandoComuniLocalizzazioniObj.Provider = this.Provider;
			base.Insert(index, BandoComuniLocalizzazioniObj);
		}

		//CollectionGetById
		public BandoComuniLocalizzazioni CollectionGetById(NullTypes.IntNT IdBandoValue, NullTypes.IntNT IdComuneValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdBando == IdBandoValue) && (this[i].IdComune == IdComuneValue))
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
		public BandoComuniLocalizzazioniCollection SubSelect(NullTypes.IntNT IdBandoEqualThis, NullTypes.IntNT IdComuneEqualThis, NullTypes.IntNT EffettoSuContributoEqualThis, 
NullTypes.BoolNT IsAttivoEqualThis)
		{
			BandoComuniLocalizzazioniCollection BandoComuniLocalizzazioniCollectionTemp = new BandoComuniLocalizzazioniCollection();
			foreach (BandoComuniLocalizzazioni BandoComuniLocalizzazioniItem in this)
			{
				if (((IdBandoEqualThis == null) || ((BandoComuniLocalizzazioniItem.IdBando != null) && (BandoComuniLocalizzazioniItem.IdBando.Value == IdBandoEqualThis.Value))) && ((IdComuneEqualThis == null) || ((BandoComuniLocalizzazioniItem.IdComune != null) && (BandoComuniLocalizzazioniItem.IdComune.Value == IdComuneEqualThis.Value))) && ((EffettoSuContributoEqualThis == null) || ((BandoComuniLocalizzazioniItem.EffettoSuContributo != null) && (BandoComuniLocalizzazioniItem.EffettoSuContributo.Value == EffettoSuContributoEqualThis.Value))) && 
((IsAttivoEqualThis == null) || ((BandoComuniLocalizzazioniItem.IsAttivo != null) && (BandoComuniLocalizzazioniItem.IsAttivo.Value == IsAttivoEqualThis.Value))))
				{
					BandoComuniLocalizzazioniCollectionTemp.Add(BandoComuniLocalizzazioniItem);
				}
			}
			return BandoComuniLocalizzazioniCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for BandoComuniLocalizzazioniDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class BandoComuniLocalizzazioniDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, BandoComuniLocalizzazioni BandoComuniLocalizzazioniObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", BandoComuniLocalizzazioniObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "IdComune", BandoComuniLocalizzazioniObj.IdComune);
			DbProvider.SetCmdParam(cmd,firstChar + "EffettoSuContributo", BandoComuniLocalizzazioniObj.EffettoSuContributo);
			DbProvider.SetCmdParam(cmd,firstChar + "IsAttivo", BandoComuniLocalizzazioniObj.IsAttivo);
		}
		//Insert
		private static int Insert(DbProvider db, BandoComuniLocalizzazioni BandoComuniLocalizzazioniObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZBandoComuniLocalizzazioniInsert", new string[] {"IdBando", "IdComune", "EffettoSuContributo", 
"IsAttivo", 

}, new string[] {"int", "int", "int", 
"bool", 

},"");
				CompileIUCmd(false, insertCmd,BandoComuniLocalizzazioniObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				BandoComuniLocalizzazioniObj.EffettoSuContributo = new SiarLibrary.NullTypes.IntNT(db.DataReader["EFFETTO_SU_CONTRIBUTO"]);
				BandoComuniLocalizzazioniObj.IsAttivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IS_ATTIVO"]);
				}
				BandoComuniLocalizzazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoComuniLocalizzazioniObj.IsDirty = false;
				BandoComuniLocalizzazioniObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, BandoComuniLocalizzazioni BandoComuniLocalizzazioniObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBandoComuniLocalizzazioniUpdate", new string[] {"IdBando", "IdComune", "EffettoSuContributo", 
"IsAttivo", 

}, new string[] {"int", "int", "int", 
"bool", 

},"");
				CompileIUCmd(true, updateCmd,BandoComuniLocalizzazioniObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				BandoComuniLocalizzazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoComuniLocalizzazioniObj.IsDirty = false;
				BandoComuniLocalizzazioniObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, BandoComuniLocalizzazioni BandoComuniLocalizzazioniObj)
		{
			switch (BandoComuniLocalizzazioniObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, BandoComuniLocalizzazioniObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, BandoComuniLocalizzazioniObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,BandoComuniLocalizzazioniObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, BandoComuniLocalizzazioniCollection BandoComuniLocalizzazioniCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBandoComuniLocalizzazioniUpdate", new string[] {"IdBando", "IdComune", "EffettoSuContributo", 
"IsAttivo", 

}, new string[] {"int", "int", "int", 
"bool", 

},"");
				IDbCommand insertCmd = db.InitCmd( "ZBandoComuniLocalizzazioniInsert", new string[] {"IdBando", "IdComune", "EffettoSuContributo", 
"IsAttivo", 

}, new string[] {"int", "int", "int", 
"bool", 

},"");
				IDbCommand deleteCmd = db.InitCmd( "ZBandoComuniLocalizzazioniDelete", new string[] {"IdBando", "IdComune"}, new string[] {"int", "int"},"");
				for (int i = 0; i < BandoComuniLocalizzazioniCollectionObj.Count; i++)
				{
					switch (BandoComuniLocalizzazioniCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,BandoComuniLocalizzazioniCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									BandoComuniLocalizzazioniCollectionObj[i].EffettoSuContributo = new SiarLibrary.NullTypes.IntNT(db.DataReader["EFFETTO_SU_CONTRIBUTO"]);
									BandoComuniLocalizzazioniCollectionObj[i].IsAttivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IS_ATTIVO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,BandoComuniLocalizzazioniCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (BandoComuniLocalizzazioniCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBando", (SiarLibrary.NullTypes.IntNT)BandoComuniLocalizzazioniCollectionObj[i].IdBando);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdComune", (SiarLibrary.NullTypes.IntNT)BandoComuniLocalizzazioniCollectionObj[i].IdComune);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < BandoComuniLocalizzazioniCollectionObj.Count; i++)
				{
					if ((BandoComuniLocalizzazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoComuniLocalizzazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BandoComuniLocalizzazioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						BandoComuniLocalizzazioniCollectionObj[i].IsDirty = false;
						BandoComuniLocalizzazioniCollectionObj[i].IsPersistent = true;
					}
					if ((BandoComuniLocalizzazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						BandoComuniLocalizzazioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BandoComuniLocalizzazioniCollectionObj[i].IsDirty = false;
						BandoComuniLocalizzazioniCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, BandoComuniLocalizzazioni BandoComuniLocalizzazioniObj)
		{
			int returnValue = 0;
			if (BandoComuniLocalizzazioniObj.IsPersistent) 
			{
				returnValue = Delete(db, BandoComuniLocalizzazioniObj.IdBando, BandoComuniLocalizzazioniObj.IdComune);
			}
			BandoComuniLocalizzazioniObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			BandoComuniLocalizzazioniObj.IsDirty = false;
			BandoComuniLocalizzazioniObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdBandoValue, int IdComuneValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBandoComuniLocalizzazioniDelete", new string[] {"IdBando", "IdComune"}, new string[] {"int", "int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBando", (SiarLibrary.NullTypes.IntNT)IdBandoValue);
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdComune", (SiarLibrary.NullTypes.IntNT)IdComuneValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, BandoComuniLocalizzazioniCollection BandoComuniLocalizzazioniCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBandoComuniLocalizzazioniDelete", new string[] {"IdBando", "IdComune"}, new string[] {"int", "int"},"");
				for (int i = 0; i < BandoComuniLocalizzazioniCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBando", BandoComuniLocalizzazioniCollectionObj[i].IdBando);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdComune", BandoComuniLocalizzazioniCollectionObj[i].IdComune);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < BandoComuniLocalizzazioniCollectionObj.Count; i++)
				{
					if ((BandoComuniLocalizzazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoComuniLocalizzazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BandoComuniLocalizzazioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BandoComuniLocalizzazioniCollectionObj[i].IsDirty = false;
						BandoComuniLocalizzazioniCollectionObj[i].IsPersistent = false;
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
		public static BandoComuniLocalizzazioni GetById(DbProvider db, int IdBandoValue, int IdComuneValue)
		{
			BandoComuniLocalizzazioni BandoComuniLocalizzazioniObj = null;
			IDbCommand readCmd = db.InitCmd( "ZBandoComuniLocalizzazioniGetById", new string[] {"IdBando", "IdComune"}, new string[] {"int", "int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdBando", (SiarLibrary.NullTypes.IntNT)IdBandoValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdComune", (SiarLibrary.NullTypes.IntNT)IdComuneValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				BandoComuniLocalizzazioniObj = GetFromDatareader(db);
				BandoComuniLocalizzazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoComuniLocalizzazioniObj.IsDirty = false;
				BandoComuniLocalizzazioniObj.IsPersistent = true;
			}
			db.Close();
			return BandoComuniLocalizzazioniObj;
		}

		//getFromDatareader
		public static BandoComuniLocalizzazioni GetFromDatareader(DbProvider db)
		{
			BandoComuniLocalizzazioni BandoComuniLocalizzazioniObj = new BandoComuniLocalizzazioni();
			BandoComuniLocalizzazioniObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			BandoComuniLocalizzazioniObj.IdComune = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COMUNE"]);
			BandoComuniLocalizzazioniObj.EffettoSuContributo = new SiarLibrary.NullTypes.IntNT(db.DataReader["EFFETTO_SU_CONTRIBUTO"]);
			BandoComuniLocalizzazioniObj.IsAttivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IS_ATTIVO"]);
			BandoComuniLocalizzazioniObj.CodBelfiore = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_BELFIORE"]);
			BandoComuniLocalizzazioniObj.Denominazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DENOMINAZIONE"]);
			BandoComuniLocalizzazioniObj.CodProvincia = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_PROVINCIA"]);
			BandoComuniLocalizzazioniObj.Sigla = new SiarLibrary.NullTypes.StringNT(db.DataReader["SIGLA"]);
			BandoComuniLocalizzazioniObj.Cap = new SiarLibrary.NullTypes.StringNT(db.DataReader["CAP"]);
			BandoComuniLocalizzazioniObj.Istat = new SiarLibrary.NullTypes.StringNT(db.DataReader["ISTAT"]);
			BandoComuniLocalizzazioniObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
			BandoComuniLocalizzazioniObj.TipoArea = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_AREA"]);
			BandoComuniLocalizzazioniObj.CodRubricaPaleo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_RUBRICA_PALEO"]);
			BandoComuniLocalizzazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			BandoComuniLocalizzazioniObj.IsDirty = false;
			BandoComuniLocalizzazioniObj.IsPersistent = true;
			return BandoComuniLocalizzazioniObj;
		}

		//Find Select

		public static BandoComuniLocalizzazioniCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdComuneEqualThis, SiarLibrary.NullTypes.IntNT EffettoSuContributoEqualThis, 
SiarLibrary.NullTypes.BoolNT IsAttivoEqualThis)

		{

			BandoComuniLocalizzazioniCollection BandoComuniLocalizzazioniCollectionObj = new BandoComuniLocalizzazioniCollection();

			IDbCommand findCmd = db.InitCmd("Zbandocomunilocalizzazionifindselect", new string[] {"IdBandoequalthis", "IdComuneequalthis", "EffettoSuContributoequalthis", 
"IsAttivoequalthis"}, new string[] {"int", "int", "int", 
"bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdComuneequalthis", IdComuneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "EffettoSuContributoequalthis", EffettoSuContributoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IsAttivoequalthis", IsAttivoEqualThis);
			BandoComuniLocalizzazioni BandoComuniLocalizzazioniObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BandoComuniLocalizzazioniObj = GetFromDatareader(db);
				BandoComuniLocalizzazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoComuniLocalizzazioniObj.IsDirty = false;
				BandoComuniLocalizzazioniObj.IsPersistent = true;
				BandoComuniLocalizzazioniCollectionObj.Add(BandoComuniLocalizzazioniObj);
			}
			db.Close();
			return BandoComuniLocalizzazioniCollectionObj;
		}

		//Find Find

		public static BandoComuniLocalizzazioniCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdComuneEqualThis)

		{

			BandoComuniLocalizzazioniCollection BandoComuniLocalizzazioniCollectionObj = new BandoComuniLocalizzazioniCollection();

			IDbCommand findCmd = db.InitCmd("Zbandocomunilocalizzazionifindfind", new string[] {"IdBandoequalthis", "IdComuneequalthis"}, new string[] {"int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdComuneequalthis", IdComuneEqualThis);
			BandoComuniLocalizzazioni BandoComuniLocalizzazioniObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BandoComuniLocalizzazioniObj = GetFromDatareader(db);
				BandoComuniLocalizzazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoComuniLocalizzazioniObj.IsDirty = false;
				BandoComuniLocalizzazioniObj.IsPersistent = true;
				BandoComuniLocalizzazioniCollectionObj.Add(BandoComuniLocalizzazioniObj);
			}
			db.Close();
			return BandoComuniLocalizzazioniCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for BandoComuniLocalizzazioniCollectionProvider:IBandoComuniLocalizzazioniProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class BandoComuniLocalizzazioniCollectionProvider : IBandoComuniLocalizzazioniProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di BandoComuniLocalizzazioni
		protected BandoComuniLocalizzazioniCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public BandoComuniLocalizzazioniCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new BandoComuniLocalizzazioniCollection(this);
		}

		//Costruttore 2: popola la collection
		public BandoComuniLocalizzazioniCollectionProvider(IntNT IdbandoEqualThis, IntNT IdcomuneEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdbandoEqualThis, IdcomuneEqualThis);
		}

		//Costruttore3: ha in input bandocomunilocalizzazioniCollectionObj - non popola la collection
		public BandoComuniLocalizzazioniCollectionProvider(BandoComuniLocalizzazioniCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public BandoComuniLocalizzazioniCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new BandoComuniLocalizzazioniCollection(this);
		}

		//Get e Set
		public BandoComuniLocalizzazioniCollection CollectionObj
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
		public int SaveCollection(BandoComuniLocalizzazioniCollection collectionObj)
		{
			return BandoComuniLocalizzazioniDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(BandoComuniLocalizzazioni bandocomunilocalizzazioniObj)
		{
			return BandoComuniLocalizzazioniDAL.Save(_dbProviderObj, bandocomunilocalizzazioniObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(BandoComuniLocalizzazioniCollection collectionObj)
		{
			return BandoComuniLocalizzazioniDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(BandoComuniLocalizzazioni bandocomunilocalizzazioniObj)
		{
			return BandoComuniLocalizzazioniDAL.Delete(_dbProviderObj, bandocomunilocalizzazioniObj);
		}

		//getById
		public BandoComuniLocalizzazioni GetById(IntNT IdBandoValue, IntNT IdComuneValue)
		{
			BandoComuniLocalizzazioni BandoComuniLocalizzazioniTemp = BandoComuniLocalizzazioniDAL.GetById(_dbProviderObj, IdBandoValue, IdComuneValue);
			if (BandoComuniLocalizzazioniTemp!=null) BandoComuniLocalizzazioniTemp.Provider = this;
			return BandoComuniLocalizzazioniTemp;
		}

		//Select: popola la collection
		public BandoComuniLocalizzazioniCollection Select(IntNT IdbandoEqualThis, IntNT IdcomuneEqualThis, IntNT EffettosucontributoEqualThis, 
BoolNT IsattivoEqualThis)
		{
			BandoComuniLocalizzazioniCollection BandoComuniLocalizzazioniCollectionTemp = BandoComuniLocalizzazioniDAL.Select(_dbProviderObj, IdbandoEqualThis, IdcomuneEqualThis, EffettosucontributoEqualThis, 
IsattivoEqualThis);
			BandoComuniLocalizzazioniCollectionTemp.Provider = this;
			return BandoComuniLocalizzazioniCollectionTemp;
		}

		//Find: popola la collection
		public BandoComuniLocalizzazioniCollection Find(IntNT IdbandoEqualThis, IntNT IdcomuneEqualThis)
		{
			BandoComuniLocalizzazioniCollection BandoComuniLocalizzazioniCollectionTemp = BandoComuniLocalizzazioniDAL.Find(_dbProviderObj, IdbandoEqualThis, IdcomuneEqualThis);
			BandoComuniLocalizzazioniCollectionTemp.Provider = this;
			return BandoComuniLocalizzazioniCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<BANDO_COMUNI_LOCALIZZAZIONI>
  <ViewName>vBANDO_COMUNI_LOCALIZZAZIONI</ViewName>
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
      <ID_BANDO>Equal</ID_BANDO>
      <ID_COMUNE>Equal</ID_COMUNE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</BANDO_COMUNI_LOCALIZZAZIONI>
*/
