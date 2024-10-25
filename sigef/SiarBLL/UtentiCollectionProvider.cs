using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per Utenti
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IUtentiProvider
	{
		int Save(Utenti UtentiObj);
		int SaveCollection(UtentiCollection collectionObj);
		int Delete(Utenti UtentiObj);
		int DeleteCollection(UtentiCollection collectionObj);
	}
	/// <summary>
	/// Summary description for Utenti
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class Utenti: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdUtente;
		private NullTypes.IntNT _IdPersonaFisica;
		private NullTypes.StringNT _CodTipoEnte;
		private NullTypes.IntNT _IdStoricoUltimo;
		private NullTypes.DatetimeNT _UltimoAccesso;
		private NullTypes.StringNT _CfUtente;
		private NullTypes.StringNT _Profilo;
		private NullTypes.StringNT _Ente;
		private NullTypes.StringNT _Nominativo;
		private NullTypes.IntNT _IdProfilo;
		private NullTypes.StringNT _CodEnte;
		private NullTypes.StringNT _Provincia;
		private NullTypes.StringNT _Email;
		private NullTypes.BoolNT _Attivo;
		private NullTypes.DatetimeNT _Data;
		private NullTypes.IntNT _Operatore;
		[NonSerialized] private IUtentiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IUtentiProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public Utenti()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
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
		/// Corrisponde al campo:ULTIMO_ACCESSO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT UltimoAccesso
		{
			get { return _UltimoAccesso; }
			set {
				if (UltimoAccesso != value)
				{
					_UltimoAccesso = value;
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
		/// Corrisponde al campo:PROFILO
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Profilo
		{
			get { return _Profilo; }
			set {
				if (Profilo != value)
				{
					_Profilo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ENTE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Ente
		{
			get { return _Ente; }
			set {
				if (Ente != value)
				{
					_Ente = value;
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
		/// Corrisponde al campo:ID_PROFILO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProfilo
		{
			get { return _IdProfilo; }
			set {
				if (IdProfilo != value)
				{
					_IdProfilo = value;
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
		/// Corrisponde al campo:PROVINCIA
		/// Tipo sul db:CHAR(2)
		/// </summary>
		public NullTypes.StringNT Provincia
		{
			get { return _Provincia; }
			set {
				if (Provincia != value)
				{
					_Provincia = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:EMAIL
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT Email
		{
			get { return _Email; }
			set {
				if (Email != value)
				{
					_Email = value;
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
	/// Summary description for UtentiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class UtentiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private UtentiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((Utenti) info.GetValue(i.ToString(),typeof(Utenti)));
			}
		}

		//Costruttore
		public UtentiCollection()
		{
			this.ItemType = typeof(Utenti);
		}

		//Costruttore con provider
		public UtentiCollection(IUtentiProvider providerObj)
		{
			this.ItemType = typeof(Utenti);
			this.Provider = providerObj;
		}

		//Get e Set
		public new Utenti this[int index]
		{
			get { return (Utenti)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new UtentiCollection GetChanges()
		{
			return (UtentiCollection) base.GetChanges();
		}

		[NonSerialized] private IUtentiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IUtentiProvider Provider
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
		public int Add(Utenti UtentiObj)
		{
			if (UtentiObj.Provider == null) UtentiObj.Provider = this.Provider;
			return base.Add(UtentiObj);
		}

		//AddCollection
		public void AddCollection(UtentiCollection UtentiCollectionObj)
		{
			foreach (Utenti UtentiObj in UtentiCollectionObj)
				this.Add(UtentiObj);
		}

		//Insert
		public void Insert(int index, Utenti UtentiObj)
		{
			if (UtentiObj.Provider == null) UtentiObj.Provider = this.Provider;
			base.Insert(index, UtentiObj);
		}

		//CollectionGetById
		public Utenti CollectionGetById(NullTypes.IntNT IdUtenteValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdUtente == IdUtenteValue))
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
		public UtentiCollection SubSelect(NullTypes.IntNT IdUtenteEqualThis, NullTypes.IntNT IdPersonaFisicaEqualThis, NullTypes.IntNT IdStoricoUltimoEqualThis, 
NullTypes.DatetimeNT UltimoAccessoEqualThis)
		{
			UtentiCollection UtentiCollectionTemp = new UtentiCollection();
			foreach (Utenti UtentiItem in this)
			{
				if (((IdUtenteEqualThis == null) || ((UtentiItem.IdUtente != null) && (UtentiItem.IdUtente.Value == IdUtenteEqualThis.Value))) && ((IdPersonaFisicaEqualThis == null) || ((UtentiItem.IdPersonaFisica != null) && (UtentiItem.IdPersonaFisica.Value == IdPersonaFisicaEqualThis.Value))) && ((IdStoricoUltimoEqualThis == null) || ((UtentiItem.IdStoricoUltimo != null) && (UtentiItem.IdStoricoUltimo.Value == IdStoricoUltimoEqualThis.Value))) && 
((UltimoAccessoEqualThis == null) || ((UtentiItem.UltimoAccesso != null) && (UtentiItem.UltimoAccesso.Value == UltimoAccessoEqualThis.Value))))
				{
					UtentiCollectionTemp.Add(UtentiItem);
				}
			}
			return UtentiCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public UtentiCollection FiltroProvincia(NullTypes.StringNT ProvinciaEqualThis, NullTypes.BoolNT ProvinciaIsNull, NullTypes.StringNT ProvinciaNotEqualThis)
		{
			UtentiCollection UtentiCollectionTemp = new UtentiCollection();
			foreach (Utenti UtentiItem in this)
			{
				if (((ProvinciaEqualThis == null) || ((UtentiItem.Provincia != null) && (UtentiItem.Provincia.Value == ProvinciaEqualThis.Value))) && ((ProvinciaIsNull == null) || ((UtentiItem.Provincia == null) ==  ProvinciaIsNull.Value)) && ((ProvinciaNotEqualThis == null) || ((UtentiItem.Provincia != null) && (UtentiItem.Provincia.Value != ProvinciaNotEqualThis.Value))))
				{
					UtentiCollectionTemp.Add(UtentiItem);
				}
			}
			return UtentiCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public UtentiCollection FiltroCFNominativo(NullTypes.StringNT CfUtenteLike, NullTypes.StringNT NominativoLike)
		{
			UtentiCollection UtentiCollectionTemp = new UtentiCollection();
			foreach (Utenti UtentiItem in this)
			{
				if (((CfUtenteLike == null) || ((UtentiItem.CfUtente !=null) &&(UtentiItem.CfUtente.Like(CfUtenteLike.Value)))) && ((NominativoLike == null) || ((UtentiItem.Nominativo !=null) &&(UtentiItem.Nominativo.Like(NominativoLike.Value)))))
				{
					UtentiCollectionTemp.Add(UtentiItem);
				}
			}
			return UtentiCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for UtentiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class UtentiDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, Utenti UtentiObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdUtente", UtentiObj.IdUtente);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdPersonaFisica", UtentiObj.IdPersonaFisica);
			DbProvider.SetCmdParam(cmd,firstChar + "IdStoricoUltimo", UtentiObj.IdStoricoUltimo);
			DbProvider.SetCmdParam(cmd,firstChar + "UltimoAccesso", UtentiObj.UltimoAccesso);
		}
		//Insert
		private static int Insert(DbProvider db, Utenti UtentiObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZUtentiInsert", new string[] {"IdPersonaFisica", 
"IdStoricoUltimo", "UltimoAccesso", 


}, new string[] {"int", 
"int", "DateTime", 


},"");
				CompileIUCmd(false, insertCmd,UtentiObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				UtentiObj.IdUtente = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_UTENTE"]);
				}
				UtentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				UtentiObj.IsDirty = false;
				UtentiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, Utenti UtentiObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZUtentiUpdate", new string[] {"IdUtente", "IdPersonaFisica", 
"IdStoricoUltimo", "UltimoAccesso", 


}, new string[] {"int", "int", 
"int", "DateTime", 


},"");
				CompileIUCmd(true, updateCmd,UtentiObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				UtentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				UtentiObj.IsDirty = false;
				UtentiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, Utenti UtentiObj)
		{
			switch (UtentiObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, UtentiObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, UtentiObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,UtentiObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, UtentiCollection UtentiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZUtentiUpdate", new string[] {"IdUtente", "IdPersonaFisica", 
"IdStoricoUltimo", "UltimoAccesso", 


}, new string[] {"int", "int", 
"int", "DateTime", 


},"");
				IDbCommand insertCmd = db.InitCmd( "ZUtentiInsert", new string[] {"IdPersonaFisica", 
"IdStoricoUltimo", "UltimoAccesso", 


}, new string[] {"int", 
"int", "DateTime", 


},"");
				IDbCommand deleteCmd = db.InitCmd( "ZUtentiDelete", new string[] {"IdUtente"}, new string[] {"int"},"");
				for (int i = 0; i < UtentiCollectionObj.Count; i++)
				{
					switch (UtentiCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,UtentiCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									UtentiCollectionObj[i].IdUtente = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_UTENTE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,UtentiCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (UtentiCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdUtente", (SiarLibrary.NullTypes.IntNT)UtentiCollectionObj[i].IdUtente);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < UtentiCollectionObj.Count; i++)
				{
					if ((UtentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (UtentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						UtentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						UtentiCollectionObj[i].IsDirty = false;
						UtentiCollectionObj[i].IsPersistent = true;
					}
					if ((UtentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						UtentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						UtentiCollectionObj[i].IsDirty = false;
						UtentiCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, Utenti UtentiObj)
		{
			int returnValue = 0;
			if (UtentiObj.IsPersistent) 
			{
				returnValue = Delete(db, UtentiObj.IdUtente);
			}
			UtentiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			UtentiObj.IsDirty = false;
			UtentiObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdUtenteValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZUtentiDelete", new string[] {"IdUtente"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdUtente", (SiarLibrary.NullTypes.IntNT)IdUtenteValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, UtentiCollection UtentiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZUtentiDelete", new string[] {"IdUtente"}, new string[] {"int"},"");
				for (int i = 0; i < UtentiCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdUtente", UtentiCollectionObj[i].IdUtente);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < UtentiCollectionObj.Count; i++)
				{
					if ((UtentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (UtentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						UtentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						UtentiCollectionObj[i].IsDirty = false;
						UtentiCollectionObj[i].IsPersistent = false;
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
		public static Utenti GetById(DbProvider db, int IdUtenteValue)
		{
			Utenti UtentiObj = null;
			IDbCommand readCmd = db.InitCmd( "ZUtentiGetById", new string[] {"IdUtente"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdUtente", (SiarLibrary.NullTypes.IntNT)IdUtenteValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				UtentiObj = GetFromDatareader(db);
				UtentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				UtentiObj.IsDirty = false;
				UtentiObj.IsPersistent = true;
			}
			db.Close();
			return UtentiObj;
		}

		//getFromDatareader
		public static Utenti GetFromDatareader(DbProvider db)
		{
			Utenti UtentiObj = new Utenti();
			UtentiObj.IdUtente = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_UTENTE"]);
			UtentiObj.IdPersonaFisica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PERSONA_FISICA"]);
			UtentiObj.CodTipoEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_ENTE"]);
			UtentiObj.IdStoricoUltimo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_STORICO_ULTIMO"]);
			UtentiObj.UltimoAccesso = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["ULTIMO_ACCESSO"]);
			UtentiObj.CfUtente = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_UTENTE"]);
			UtentiObj.Profilo = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROFILO"]);
			UtentiObj.Ente = new SiarLibrary.NullTypes.StringNT(db.DataReader["ENTE"]);
			UtentiObj.Nominativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO"]);
			UtentiObj.IdProfilo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROFILO"]);
			UtentiObj.CodEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE"]);
			UtentiObj.Provincia = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROVINCIA"]);
			UtentiObj.Email = new SiarLibrary.NullTypes.StringNT(db.DataReader["EMAIL"]);
			UtentiObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
			UtentiObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
			UtentiObj.Operatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE"]);
			UtentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			UtentiObj.IsDirty = false;
			UtentiObj.IsPersistent = true;
			return UtentiObj;
		}

		//Find Select

		public static UtentiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdUtenteEqualThis, SiarLibrary.NullTypes.IntNT IdPersonaFisicaEqualThis, SiarLibrary.NullTypes.IntNT IdStoricoUltimoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT UltimoAccessoEqualThis)

		{

			UtentiCollection UtentiCollectionObj = new UtentiCollection();

			IDbCommand findCmd = db.InitCmd("Zutentifindselect", new string[] {"IdUtenteequalthis", "IdPersonaFisicaequalthis", "IdStoricoUltimoequalthis", 
"UltimoAccessoequalthis"}, new string[] {"int", "int", "int", 
"DateTime"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdUtenteequalthis", IdUtenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPersonaFisicaequalthis", IdPersonaFisicaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdStoricoUltimoequalthis", IdStoricoUltimoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "UltimoAccessoequalthis", UltimoAccessoEqualThis);
			Utenti UtentiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				UtentiObj = GetFromDatareader(db);
				UtentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				UtentiObj.IsDirty = false;
				UtentiObj.IsPersistent = true;
				UtentiCollectionObj.Add(UtentiObj);
			}
			db.Close();
			return UtentiCollectionObj;
		}

		//Find Find

		public static UtentiCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT CfUtenteEqualThis, SiarLibrary.NullTypes.IntNT IdPersonaFisicaEqualThis, SiarLibrary.NullTypes.StringNT NominativoLikeThis, 
SiarLibrary.NullTypes.StringNT CodEnteEqualThis, SiarLibrary.NullTypes.IntNT IdProfiloEqualThis, SiarLibrary.NullTypes.StringNT ProvinciaEqualThis, 
SiarLibrary.NullTypes.BoolNT AttivoEqualThis)

		{

			UtentiCollection UtentiCollectionObj = new UtentiCollection();

			IDbCommand findCmd = db.InitCmd("Zutentifindfind", new string[] {"CfUtenteequalthis", "IdPersonaFisicaequalthis", "Nominativolikethis", 
"CodEnteequalthis", "IdProfiloequalthis", "Provinciaequalthis", 
"Attivoequalthis"}, new string[] {"string", "int", "string", 
"string", "int", "string", 
"bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfUtenteequalthis", CfUtenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPersonaFisicaequalthis", IdPersonaFisicaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Nominativolikethis", NominativoLikeThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodEnteequalthis", CodEnteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProfiloequalthis", IdProfiloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Provinciaequalthis", ProvinciaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			Utenti UtentiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				UtentiObj = GetFromDatareader(db);
				UtentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				UtentiObj.IsDirty = false;
				UtentiObj.IsPersistent = true;
				UtentiCollectionObj.Add(UtentiObj);
			}
			db.Close();
			return UtentiCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for UtentiCollectionProvider:IUtentiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class UtentiCollectionProvider : IUtentiProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di Utenti
		protected UtentiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public UtentiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new UtentiCollection(this);
		}

		//Costruttore 2: popola la collection
		public UtentiCollectionProvider(StringNT CfutenteEqualThis, IntNT IdpersonafisicaEqualThis, StringNT NominativoLikeThis, 
StringNT CodenteEqualThis, IntNT IdprofiloEqualThis, StringNT ProvinciaEqualThis, 
BoolNT AttivoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(CfutenteEqualThis, IdpersonafisicaEqualThis, NominativoLikeThis, 
CodenteEqualThis, IdprofiloEqualThis, ProvinciaEqualThis, 
AttivoEqualThis);
		}

		//Costruttore3: ha in input utentiCollectionObj - non popola la collection
		public UtentiCollectionProvider(UtentiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public UtentiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new UtentiCollection(this);
		}

		//Get e Set
		public UtentiCollection CollectionObj
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
		public int SaveCollection(UtentiCollection collectionObj)
		{
			return UtentiDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(Utenti utentiObj)
		{
			return UtentiDAL.Save(_dbProviderObj, utentiObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(UtentiCollection collectionObj)
		{
			return UtentiDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(Utenti utentiObj)
		{
			return UtentiDAL.Delete(_dbProviderObj, utentiObj);
		}

		//getById
		public Utenti GetById(IntNT IdUtenteValue)
		{
			Utenti UtentiTemp = UtentiDAL.GetById(_dbProviderObj, IdUtenteValue);
			if (UtentiTemp!=null) UtentiTemp.Provider = this;
			return UtentiTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public UtentiCollection Select(IntNT IdutenteEqualThis, IntNT IdpersonafisicaEqualThis, IntNT IdstoricoultimoEqualThis, 
DatetimeNT UltimoaccessoEqualThis)
		{
			UtentiCollection UtentiCollectionTemp = UtentiDAL.Select(_dbProviderObj, IdutenteEqualThis, IdpersonafisicaEqualThis, IdstoricoultimoEqualThis, 
UltimoaccessoEqualThis);
			UtentiCollectionTemp.Provider = this;
			return UtentiCollectionTemp;
		}

		//Find: popola la collection
		public UtentiCollection Find(StringNT CfutenteEqualThis, IntNT IdpersonafisicaEqualThis, StringNT NominativoLikeThis, 
StringNT CodenteEqualThis, IntNT IdprofiloEqualThis, StringNT ProvinciaEqualThis, 
BoolNT AttivoEqualThis)
		{
			UtentiCollection UtentiCollectionTemp = UtentiDAL.Find(_dbProviderObj, CfutenteEqualThis, IdpersonafisicaEqualThis, NominativoLikeThis, 
CodenteEqualThis, IdprofiloEqualThis, ProvinciaEqualThis, 
AttivoEqualThis);
			UtentiCollectionTemp.Provider = this;
			return UtentiCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<UTENTI>
  <ViewName>vUTENTI</ViewName>
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
    <Find OrderBy="ORDER BY ATTIVO DESC, NOMINATIVO">
      <CF_UTENTE>Equal</CF_UTENTE>
      <ID_PERSONA_FISICA>Equal</ID_PERSONA_FISICA>
      <NOMINATIVO>Like</NOMINATIVO>
      <COD_ENTE>Equal</COD_ENTE>
      <ID_PROFILO>Equal</ID_PROFILO>
      <PROVINCIA>Equal</PROVINCIA>
      <ATTIVO>Equal</ATTIVO>
    </Find>
  </Finds>
  <Filters>
    <FiltroProvincia>
      <PROVINCIA>Equal</PROVINCIA>
      <PROVINCIA>IsNull</PROVINCIA>
      <PROVINCIA>NotEqual</PROVINCIA>
    </FiltroProvincia>
    <FiltroCFNominativo>
      <CF_UTENTE>Like</CF_UTENTE>
      <NOMINATIVO>Like</NOMINATIVO>
    </FiltroCFNominativo>
  </Filters>
  <externalFields />
  <AddedFkFields />
</UTENTI>
*/
