using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per CaaOperatori
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ICaaOperatoriProvider
	{
		int Save(CaaOperatori CaaOperatoriObj);
		int SaveCollection(CaaOperatoriCollection collectionObj);
		int Delete(CaaOperatori CaaOperatoriObj);
		int DeleteCollection(CaaOperatoriCollection collectionObj);
	}
	/// <summary>
	/// Summary description for CaaOperatori
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class CaaOperatori: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.StringNT _CodiceSportello;
		private NullTypes.IntNT _IdUtente;
		private NullTypes.IntNT _IdStoricoUltimo;
		private NullTypes.BoolNT _MandatoPsr;
		private NullTypes.BoolNT _MandatoUma;
		private NullTypes.BoolNT _Responsabile;
		private NullTypes.StringNT _CodStato;
		private NullTypes.DatetimeNT _Data;
		private NullTypes.IntNT _Operatore;
		private NullTypes.IntNT _IdPersonaFisica;
		private NullTypes.StringNT _CfUtente;
		private NullTypes.StringNT _Nominativo;
		private NullTypes.StringNT _Stato;
		private NullTypes.StringNT _CodEnte;
		private NullTypes.StringNT _CodTipoEnte;
		[NonSerialized] private ICaaOperatoriProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICaaOperatoriProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public CaaOperatori()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Id
		{
			get { return _Id; }
			set {
				if (Id != value)
				{
					_Id = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE_SPORTELLO
		/// Tipo sul db:CHAR(9)
		/// </summary>
		public NullTypes.StringNT CodiceSportello
		{
			get { return _CodiceSportello; }
			set {
				if (CodiceSportello != value)
				{
					_CodiceSportello = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_UTENTE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdUtente
		{
			get { return _IdUtente; }
			set {
				if (IdUtente != value)
				{
					_IdUtente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_STORICO_ULTIMO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdStoricoUltimo
		{
			get { return _IdStoricoUltimo; }
			set {
				if (IdStoricoUltimo != value)
				{
					_IdStoricoUltimo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MANDATO_PSR
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT MandatoPsr
		{
			get { return _MandatoPsr; }
			set {
				if (MandatoPsr != value)
				{
					_MandatoPsr = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MANDATO_UMA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT MandatoUma
		{
			get { return _MandatoUma; }
			set {
				if (MandatoUma != value)
				{
					_MandatoUma = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RESPONSABILE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Responsabile
		{
			get { return _Responsabile; }
			set {
				if (Responsabile != value)
				{
					_Responsabile = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_STATO
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT CodStato
		{
			get { return _CodStato; }
			set {
				if (CodStato != value)
				{
					_CodStato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT Data
		{
			get { return _Data; }
			set {
				if (Data != value)
				{
					_Data = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Operatore
		{
			get { return _Operatore; }
			set {
				if (Operatore != value)
				{
					_Operatore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_PERSONA_FISICA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdPersonaFisica
		{
			get { return _IdPersonaFisica; }
			set {
				if (IdPersonaFisica != value)
				{
					_IdPersonaFisica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_UTENTE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CfUtente
		{
			get { return _CfUtente; }
			set {
				if (CfUtente != value)
				{
					_CfUtente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOMINATIVO
		/// Tipo sul db:VARCHAR(511)
		/// </summary>
		public NullTypes.StringNT Nominativo
		{
			get { return _Nominativo; }
			set {
				if (Nominativo != value)
				{
					_Nominativo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:STATO
		/// Tipo sul db:VARCHAR(27)
		/// </summary>
		public NullTypes.StringNT Stato
		{
			get { return _Stato; }
			set {
				if (Stato != value)
				{
					_Stato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_ENTE
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT CodEnte
		{
			get { return _CodEnte; }
			set {
				if (CodEnte != value)
				{
					_CodEnte = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_TIPO_ENTE
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT CodTipoEnte
		{
			get { return _CodTipoEnte; }
			set {
				if (CodTipoEnte != value)
				{
					_CodTipoEnte = value;
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
	/// Summary description for CaaOperatoriCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CaaOperatoriCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private CaaOperatoriCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((CaaOperatori) info.GetValue(i.ToString(),typeof(CaaOperatori)));
			}
		}

		//Costruttore
		public CaaOperatoriCollection()
		{
			this.ItemType = typeof(CaaOperatori);
		}

		//Costruttore con provider
		public CaaOperatoriCollection(ICaaOperatoriProvider providerObj)
		{
			this.ItemType = typeof(CaaOperatori);
			this.Provider = providerObj;
		}

		//Get e Set
		public new CaaOperatori this[int index]
		{
			get { return (CaaOperatori)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new CaaOperatoriCollection GetChanges()
		{
			return (CaaOperatoriCollection) base.GetChanges();
		}

		[NonSerialized] private ICaaOperatoriProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICaaOperatoriProvider Provider
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
		public int Add(CaaOperatori CaaOperatoriObj)
		{
			if (CaaOperatoriObj.Provider == null) CaaOperatoriObj.Provider = this.Provider;
			return base.Add(CaaOperatoriObj);
		}

		//AddCollection
		public void AddCollection(CaaOperatoriCollection CaaOperatoriCollectionObj)
		{
			foreach (CaaOperatori CaaOperatoriObj in CaaOperatoriCollectionObj)
				this.Add(CaaOperatoriObj);
		}

		//Insert
		public void Insert(int index, CaaOperatori CaaOperatoriObj)
		{
			if (CaaOperatoriObj.Provider == null) CaaOperatoriObj.Provider = this.Provider;
			base.Insert(index, CaaOperatoriObj);
		}

		//CollectionGetById
		public CaaOperatori CollectionGetById(NullTypes.IntNT IdValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].Id == IdValue))
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
		public CaaOperatoriCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.StringNT CodiceSportelloEqualThis, NullTypes.IntNT IdUtenteEqualThis, 
NullTypes.IntNT IdStoricoUltimoEqualThis)
		{
			CaaOperatoriCollection CaaOperatoriCollectionTemp = new CaaOperatoriCollection();
			foreach (CaaOperatori CaaOperatoriItem in this)
			{
				if (((IdEqualThis == null) || ((CaaOperatoriItem.Id != null) && (CaaOperatoriItem.Id.Value == IdEqualThis.Value))) && ((CodiceSportelloEqualThis == null) || ((CaaOperatoriItem.CodiceSportello != null) && (CaaOperatoriItem.CodiceSportello.Value == CodiceSportelloEqualThis.Value))) && ((IdUtenteEqualThis == null) || ((CaaOperatoriItem.IdUtente != null) && (CaaOperatoriItem.IdUtente.Value == IdUtenteEqualThis.Value))) && 
((IdStoricoUltimoEqualThis == null) || ((CaaOperatoriItem.IdStoricoUltimo != null) && (CaaOperatoriItem.IdStoricoUltimo.Value == IdStoricoUltimoEqualThis.Value))))
				{
					CaaOperatoriCollectionTemp.Add(CaaOperatoriItem);
				}
			}
			return CaaOperatoriCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for CaaOperatoriDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class CaaOperatoriDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CaaOperatori CaaOperatoriObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", CaaOperatoriObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "CodiceSportello", CaaOperatoriObj.CodiceSportello);
			DbProvider.SetCmdParam(cmd,firstChar + "IdUtente", CaaOperatoriObj.IdUtente);
			DbProvider.SetCmdParam(cmd,firstChar + "IdStoricoUltimo", CaaOperatoriObj.IdStoricoUltimo);
		}
		//Insert
		private static int Insert(DbProvider db, CaaOperatori CaaOperatoriObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZCaaOperatoriInsert", new string[] {"CodiceSportello", "IdUtente", 
"IdStoricoUltimo", 


}, new string[] {"string", "int", 
"int", 


},"");
				CompileIUCmd(false, insertCmd,CaaOperatoriObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				CaaOperatoriObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				CaaOperatoriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CaaOperatoriObj.IsDirty = false;
				CaaOperatoriObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, CaaOperatori CaaOperatoriObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCaaOperatoriUpdate", new string[] {"Id", "CodiceSportello", "IdUtente", 
"IdStoricoUltimo", 


}, new string[] {"int", "string", "int", 
"int", 


},"");
				CompileIUCmd(true, updateCmd,CaaOperatoriObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				CaaOperatoriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CaaOperatoriObj.IsDirty = false;
				CaaOperatoriObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, CaaOperatori CaaOperatoriObj)
		{
			switch (CaaOperatoriObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, CaaOperatoriObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, CaaOperatoriObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,CaaOperatoriObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, CaaOperatoriCollection CaaOperatoriCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCaaOperatoriUpdate", new string[] {"Id", "CodiceSportello", "IdUtente", 
"IdStoricoUltimo", 


}, new string[] {"int", "string", "int", 
"int", 


},"");
				IDbCommand insertCmd = db.InitCmd( "ZCaaOperatoriInsert", new string[] {"CodiceSportello", "IdUtente", 
"IdStoricoUltimo", 


}, new string[] {"string", "int", 
"int", 


},"");
				IDbCommand deleteCmd = db.InitCmd( "ZCaaOperatoriDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < CaaOperatoriCollectionObj.Count; i++)
				{
					switch (CaaOperatoriCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,CaaOperatoriCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									CaaOperatoriCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,CaaOperatoriCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (CaaOperatoriCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)CaaOperatoriCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < CaaOperatoriCollectionObj.Count; i++)
				{
					if ((CaaOperatoriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CaaOperatoriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CaaOperatoriCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						CaaOperatoriCollectionObj[i].IsDirty = false;
						CaaOperatoriCollectionObj[i].IsPersistent = true;
					}
					if ((CaaOperatoriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						CaaOperatoriCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CaaOperatoriCollectionObj[i].IsDirty = false;
						CaaOperatoriCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, CaaOperatori CaaOperatoriObj)
		{
			int returnValue = 0;
			if (CaaOperatoriObj.IsPersistent) 
			{
				returnValue = Delete(db, CaaOperatoriObj.Id);
			}
			CaaOperatoriObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			CaaOperatoriObj.IsDirty = false;
			CaaOperatoriObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCaaOperatoriDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, CaaOperatoriCollection CaaOperatoriCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCaaOperatoriDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < CaaOperatoriCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", CaaOperatoriCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < CaaOperatoriCollectionObj.Count; i++)
				{
					if ((CaaOperatoriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CaaOperatoriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CaaOperatoriCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CaaOperatoriCollectionObj[i].IsDirty = false;
						CaaOperatoriCollectionObj[i].IsPersistent = false;
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
		public static CaaOperatori GetById(DbProvider db, int IdValue)
		{
			CaaOperatori CaaOperatoriObj = null;
			IDbCommand readCmd = db.InitCmd( "ZCaaOperatoriGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				CaaOperatoriObj = GetFromDatareader(db);
				CaaOperatoriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CaaOperatoriObj.IsDirty = false;
				CaaOperatoriObj.IsPersistent = true;
			}
			db.Close();
			return CaaOperatoriObj;
		}

		//getFromDatareader
		public static CaaOperatori GetFromDatareader(DbProvider db)
		{
			CaaOperatori CaaOperatoriObj = new CaaOperatori();
			CaaOperatoriObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			CaaOperatoriObj.CodiceSportello = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_SPORTELLO"]);
			CaaOperatoriObj.IdUtente = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_UTENTE"]);
			CaaOperatoriObj.IdStoricoUltimo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_STORICO_ULTIMO"]);
			CaaOperatoriObj.MandatoPsr = new SiarLibrary.NullTypes.BoolNT(db.DataReader["MANDATO_PSR"]);
			CaaOperatoriObj.MandatoUma = new SiarLibrary.NullTypes.BoolNT(db.DataReader["MANDATO_UMA"]);
			CaaOperatoriObj.Responsabile = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RESPONSABILE"]);
			CaaOperatoriObj.CodStato = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_STATO"]);
			CaaOperatoriObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
			CaaOperatoriObj.Operatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE"]);
			CaaOperatoriObj.IdPersonaFisica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PERSONA_FISICA"]);
			CaaOperatoriObj.CfUtente = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_UTENTE"]);
			CaaOperatoriObj.Nominativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO"]);
			CaaOperatoriObj.Stato = new SiarLibrary.NullTypes.StringNT(db.DataReader["STATO"]);
			CaaOperatoriObj.CodEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE"]);
			CaaOperatoriObj.CodTipoEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_ENTE"]);
			CaaOperatoriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			CaaOperatoriObj.IsDirty = false;
			CaaOperatoriObj.IsPersistent = true;
			return CaaOperatoriObj;
		}

		//Find Select

		public static CaaOperatoriCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.StringNT CodiceSportelloEqualThis, SiarLibrary.NullTypes.IntNT IdUtenteEqualThis, 
SiarLibrary.NullTypes.IntNT IdStoricoUltimoEqualThis)

		{

			CaaOperatoriCollection CaaOperatoriCollectionObj = new CaaOperatoriCollection();

			IDbCommand findCmd = db.InitCmd("Zcaaoperatorifindselect", new string[] {"Idequalthis", "CodiceSportelloequalthis", "IdUtenteequalthis", 
"IdStoricoUltimoequalthis"}, new string[] {"int", "string", "int", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceSportelloequalthis", CodiceSportelloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdUtenteequalthis", IdUtenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdStoricoUltimoequalthis", IdStoricoUltimoEqualThis);
			CaaOperatori CaaOperatoriObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CaaOperatoriObj = GetFromDatareader(db);
				CaaOperatoriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CaaOperatoriObj.IsDirty = false;
				CaaOperatoriObj.IsPersistent = true;
				CaaOperatoriCollectionObj.Add(CaaOperatoriObj);
			}
			db.Close();
			return CaaOperatoriCollectionObj;
		}

		//Find Find

		public static CaaOperatoriCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT CodiceSportelloEqualThis, SiarLibrary.NullTypes.IntNT IdUtenteEqualThis, SiarLibrary.NullTypes.StringNT CfUtenteEqualThis, 
SiarLibrary.NullTypes.BoolNT ResponsabileEqualThis, SiarLibrary.NullTypes.StringNT CodStatoEqualThis)

		{

			CaaOperatoriCollection CaaOperatoriCollectionObj = new CaaOperatoriCollection();

			IDbCommand findCmd = db.InitCmd("Zcaaoperatorifindfind", new string[] {"CodiceSportelloequalthis", "IdUtenteequalthis", "CfUtenteequalthis", 
"Responsabileequalthis", "CodStatoequalthis"}, new string[] {"string", "int", "string", 
"bool", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceSportelloequalthis", CodiceSportelloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdUtenteequalthis", IdUtenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfUtenteequalthis", CfUtenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Responsabileequalthis", ResponsabileEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodStatoequalthis", CodStatoEqualThis);
			CaaOperatori CaaOperatoriObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CaaOperatoriObj = GetFromDatareader(db);
				CaaOperatoriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CaaOperatoriObj.IsDirty = false;
				CaaOperatoriObj.IsPersistent = true;
				CaaOperatoriCollectionObj.Add(CaaOperatoriObj);
			}
			db.Close();
			return CaaOperatoriCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for CaaOperatoriCollectionProvider:ICaaOperatoriProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CaaOperatoriCollectionProvider : ICaaOperatoriProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di CaaOperatori
		protected CaaOperatoriCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public CaaOperatoriCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new CaaOperatoriCollection(this);
		}

		//Costruttore 2: popola la collection
		public CaaOperatoriCollectionProvider(StringNT CodicesportelloEqualThis, IntNT IdutenteEqualThis, StringNT CfutenteEqualThis, 
BoolNT ResponsabileEqualThis, StringNT CodstatoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(CodicesportelloEqualThis, IdutenteEqualThis, CfutenteEqualThis, 
ResponsabileEqualThis, CodstatoEqualThis);
		}

		//Costruttore3: ha in input caaoperatoriCollectionObj - non popola la collection
		public CaaOperatoriCollectionProvider(CaaOperatoriCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public CaaOperatoriCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new CaaOperatoriCollection(this);
		}

		//Get e Set
		public CaaOperatoriCollection CollectionObj
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
		public int SaveCollection(CaaOperatoriCollection collectionObj)
		{
			return CaaOperatoriDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(CaaOperatori caaoperatoriObj)
		{
			return CaaOperatoriDAL.Save(_dbProviderObj, caaoperatoriObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(CaaOperatoriCollection collectionObj)
		{
			return CaaOperatoriDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(CaaOperatori caaoperatoriObj)
		{
			return CaaOperatoriDAL.Delete(_dbProviderObj, caaoperatoriObj);
		}

		//getById
		public CaaOperatori GetById(IntNT IdValue)
		{
			CaaOperatori CaaOperatoriTemp = CaaOperatoriDAL.GetById(_dbProviderObj, IdValue);
			if (CaaOperatoriTemp!=null) CaaOperatoriTemp.Provider = this;
			return CaaOperatoriTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public CaaOperatoriCollection Select(IntNT IdEqualThis, StringNT CodicesportelloEqualThis, IntNT IdutenteEqualThis, 
IntNT IdstoricoultimoEqualThis)
		{
			CaaOperatoriCollection CaaOperatoriCollectionTemp = CaaOperatoriDAL.Select(_dbProviderObj, IdEqualThis, CodicesportelloEqualThis, IdutenteEqualThis, 
IdstoricoultimoEqualThis);
			CaaOperatoriCollectionTemp.Provider = this;
			return CaaOperatoriCollectionTemp;
		}

		//Find: popola la collection
		public CaaOperatoriCollection Find(StringNT CodicesportelloEqualThis, IntNT IdutenteEqualThis, StringNT CfutenteEqualThis, 
BoolNT ResponsabileEqualThis, StringNT CodstatoEqualThis)
		{
			CaaOperatoriCollection CaaOperatoriCollectionTemp = CaaOperatoriDAL.Find(_dbProviderObj, CodicesportelloEqualThis, IdutenteEqualThis, CfutenteEqualThis, 
ResponsabileEqualThis, CodstatoEqualThis);
			CaaOperatoriCollectionTemp.Provider = this;
			return CaaOperatoriCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CAA_OPERATORI>
  <ViewName>vCAA_OPERATORI</ViewName>
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
    <Find OrderBy="ORDER BY DATA DESC">
      <CODICE_SPORTELLO>Equal</CODICE_SPORTELLO>
      <ID_UTENTE>Equal</ID_UTENTE>
      <CF_UTENTE>Equal</CF_UTENTE>
      <RESPONSABILE>Equal</RESPONSABILE>
      <COD_STATO>Equal</COD_STATO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CAA_OPERATORI>
*/
