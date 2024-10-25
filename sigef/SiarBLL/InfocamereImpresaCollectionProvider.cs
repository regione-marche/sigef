using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per InfocamereImpresa
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IInfocamereImpresaProvider
	{
		int Save(InfocamereImpresa InfocamereImpresaObj);
		int SaveCollection(InfocamereImpresaCollection collectionObj);
		int Delete(InfocamereImpresa InfocamereImpresaObj);
		int DeleteCollection(InfocamereImpresaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for InfocamereImpresa
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class InfocamereImpresa: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdInfocamereImpresa;
		private NullTypes.StringNT _Cuaa;
		private NullTypes.StringNT _CodiceFiscale;
		private NullTypes.DatetimeNT _DataInizioAttivita;
		private NullTypes.StringNT _RagioneSociale;
		private NullTypes.StringNT _Comune;
		private NullTypes.StringNT _Via;
		private NullTypes.StringNT _Nome;
		private NullTypes.StringNT _Cognome;
		private NullTypes.StringNT _CodiceFiscaleRappr;
		private NullTypes.StringNT _Sesso;
		private NullTypes.DatetimeNT _DataNascita;
		private NullTypes.StringNT _ComuneNascita;
		[NonSerialized] private IInfocamereImpresaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IInfocamereImpresaProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public InfocamereImpresa()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_INFOCAMERE_IMPRESA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdInfocamereImpresa
		{
			get { return _IdInfocamereImpresa; }
			set {
				if (IdInfocamereImpresa != value)
				{
					_IdInfocamereImpresa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CUAA
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT Cuaa
		{
			get { return _Cuaa; }
			set {
				if (Cuaa != value)
				{
					_Cuaa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE_FISCALE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CodiceFiscale
		{
			get { return _CodiceFiscale; }
			set {
				if (CodiceFiscale != value)
				{
					_CodiceFiscale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_INIZIO_ATTIVITA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataInizioAttivita
		{
			get { return _DataInizioAttivita; }
			set {
				if (DataInizioAttivita != value)
				{
					_DataInizioAttivita = value;
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
		/// Corrisponde al campo:COMUNE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Comune
		{
			get { return _Comune; }
			set {
				if (Comune != value)
				{
					_Comune = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VIA
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT Via
		{
			get { return _Via; }
			set {
				if (Via != value)
				{
					_Via = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOME
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Nome
		{
			get { return _Nome; }
			set {
				if (Nome != value)
				{
					_Nome = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COGNOME
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Cognome
		{
			get { return _Cognome; }
			set {
				if (Cognome != value)
				{
					_Cognome = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE_FISCALE_RAPPR
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CodiceFiscaleRappr
		{
			get { return _CodiceFiscaleRappr; }
			set {
				if (CodiceFiscaleRappr != value)
				{
					_CodiceFiscaleRappr = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SESSO
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT Sesso
		{
			get { return _Sesso; }
			set {
				if (Sesso != value)
				{
					_Sesso = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_NASCITA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataNascita
		{
			get { return _DataNascita; }
			set {
				if (DataNascita != value)
				{
					_DataNascita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COMUNE_NASCITA
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT ComuneNascita
		{
			get { return _ComuneNascita; }
			set {
				if (ComuneNascita != value)
				{
					_ComuneNascita = value;
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
	/// Summary description for InfocamereImpresaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class InfocamereImpresaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private InfocamereImpresaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((InfocamereImpresa) info.GetValue(i.ToString(),typeof(InfocamereImpresa)));
			}
		}

		//Costruttore
		public InfocamereImpresaCollection()
		{
			this.ItemType = typeof(InfocamereImpresa);
		}

		//Costruttore con provider
		public InfocamereImpresaCollection(IInfocamereImpresaProvider providerObj)
		{
			this.ItemType = typeof(InfocamereImpresa);
			this.Provider = providerObj;
		}

		//Get e Set
		public new InfocamereImpresa this[int index]
		{
			get { return (InfocamereImpresa)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new InfocamereImpresaCollection GetChanges()
		{
			return (InfocamereImpresaCollection) base.GetChanges();
		}

		[NonSerialized] private IInfocamereImpresaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IInfocamereImpresaProvider Provider
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
		public int Add(InfocamereImpresa InfocamereImpresaObj)
		{
			if (InfocamereImpresaObj.Provider == null) InfocamereImpresaObj.Provider = this.Provider;
			return base.Add(InfocamereImpresaObj);
		}

		//AddCollection
		public void AddCollection(InfocamereImpresaCollection InfocamereImpresaCollectionObj)
		{
			foreach (InfocamereImpresa InfocamereImpresaObj in InfocamereImpresaCollectionObj)
				this.Add(InfocamereImpresaObj);
		}

		//Insert
		public void Insert(int index, InfocamereImpresa InfocamereImpresaObj)
		{
			if (InfocamereImpresaObj.Provider == null) InfocamereImpresaObj.Provider = this.Provider;
			base.Insert(index, InfocamereImpresaObj);
		}

		//CollectionGetById
		public InfocamereImpresa CollectionGetById(NullTypes.IntNT IdInfocamereImpresaValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdInfocamereImpresa == IdInfocamereImpresaValue))
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
		public InfocamereImpresaCollection SubSelect(NullTypes.IntNT IdInfocamereImpresaEqualThis, NullTypes.StringNT CuaaEqualThis, NullTypes.StringNT CodiceFiscaleEqualThis, 
NullTypes.DatetimeNT DataInizioAttivitaEqualThis, NullTypes.StringNT RagioneSocialeEqualThis, NullTypes.StringNT ComuneEqualThis, 
NullTypes.StringNT ViaEqualThis, NullTypes.StringNT NomeEqualThis, NullTypes.StringNT CognomeEqualThis, 
NullTypes.StringNT CodiceFiscaleRapprEqualThis, NullTypes.StringNT SessoEqualThis, NullTypes.DatetimeNT DataNascitaEqualThis, 
NullTypes.StringNT ComuneNascitaEqualThis)
		{
			InfocamereImpresaCollection InfocamereImpresaCollectionTemp = new InfocamereImpresaCollection();
			foreach (InfocamereImpresa InfocamereImpresaItem in this)
			{
				if (((IdInfocamereImpresaEqualThis == null) || ((InfocamereImpresaItem.IdInfocamereImpresa != null) && (InfocamereImpresaItem.IdInfocamereImpresa.Value == IdInfocamereImpresaEqualThis.Value))) && ((CuaaEqualThis == null) || ((InfocamereImpresaItem.Cuaa != null) && (InfocamereImpresaItem.Cuaa.Value == CuaaEqualThis.Value))) && ((CodiceFiscaleEqualThis == null) || ((InfocamereImpresaItem.CodiceFiscale != null) && (InfocamereImpresaItem.CodiceFiscale.Value == CodiceFiscaleEqualThis.Value))) && 
((DataInizioAttivitaEqualThis == null) || ((InfocamereImpresaItem.DataInizioAttivita != null) && (InfocamereImpresaItem.DataInizioAttivita.Value == DataInizioAttivitaEqualThis.Value))) && ((RagioneSocialeEqualThis == null) || ((InfocamereImpresaItem.RagioneSociale != null) && (InfocamereImpresaItem.RagioneSociale.Value == RagioneSocialeEqualThis.Value))) && ((ComuneEqualThis == null) || ((InfocamereImpresaItem.Comune != null) && (InfocamereImpresaItem.Comune.Value == ComuneEqualThis.Value))) && 
((ViaEqualThis == null) || ((InfocamereImpresaItem.Via != null) && (InfocamereImpresaItem.Via.Value == ViaEqualThis.Value))) && ((NomeEqualThis == null) || ((InfocamereImpresaItem.Nome != null) && (InfocamereImpresaItem.Nome.Value == NomeEqualThis.Value))) && ((CognomeEqualThis == null) || ((InfocamereImpresaItem.Cognome != null) && (InfocamereImpresaItem.Cognome.Value == CognomeEqualThis.Value))) && 
((CodiceFiscaleRapprEqualThis == null) || ((InfocamereImpresaItem.CodiceFiscaleRappr != null) && (InfocamereImpresaItem.CodiceFiscaleRappr.Value == CodiceFiscaleRapprEqualThis.Value))) && ((SessoEqualThis == null) || ((InfocamereImpresaItem.Sesso != null) && (InfocamereImpresaItem.Sesso.Value == SessoEqualThis.Value))) && ((DataNascitaEqualThis == null) || ((InfocamereImpresaItem.DataNascita != null) && (InfocamereImpresaItem.DataNascita.Value == DataNascitaEqualThis.Value))) && 
((ComuneNascitaEqualThis == null) || ((InfocamereImpresaItem.ComuneNascita != null) && (InfocamereImpresaItem.ComuneNascita.Value == ComuneNascitaEqualThis.Value))))
				{
					InfocamereImpresaCollectionTemp.Add(InfocamereImpresaItem);
				}
			}
			return InfocamereImpresaCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for InfocamereImpresaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class InfocamereImpresaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, InfocamereImpresa InfocamereImpresaObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdInfocamereImpresa", InfocamereImpresaObj.IdInfocamereImpresa);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Cuaa", InfocamereImpresaObj.Cuaa);
			DbProvider.SetCmdParam(cmd,firstChar + "CodiceFiscale", InfocamereImpresaObj.CodiceFiscale);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInizioAttivita", InfocamereImpresaObj.DataInizioAttivita);
			DbProvider.SetCmdParam(cmd,firstChar + "RagioneSociale", InfocamereImpresaObj.RagioneSociale);
			DbProvider.SetCmdParam(cmd,firstChar + "Comune", InfocamereImpresaObj.Comune);
			DbProvider.SetCmdParam(cmd,firstChar + "Via", InfocamereImpresaObj.Via);
			DbProvider.SetCmdParam(cmd,firstChar + "Nome", InfocamereImpresaObj.Nome);
			DbProvider.SetCmdParam(cmd,firstChar + "Cognome", InfocamereImpresaObj.Cognome);
			DbProvider.SetCmdParam(cmd,firstChar + "CodiceFiscaleRappr", InfocamereImpresaObj.CodiceFiscaleRappr);
			DbProvider.SetCmdParam(cmd,firstChar + "Sesso", InfocamereImpresaObj.Sesso);
			DbProvider.SetCmdParam(cmd,firstChar + "DataNascita", InfocamereImpresaObj.DataNascita);
			DbProvider.SetCmdParam(cmd,firstChar + "ComuneNascita", InfocamereImpresaObj.ComuneNascita);
		}
		//Insert
		private static int Insert(DbProvider db, InfocamereImpresa InfocamereImpresaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZInfocamereImpresaInsert", new string[] {"Cuaa", "CodiceFiscale", 
"DataInizioAttivita", "RagioneSociale", "Comune", 
"Via", "Nome", "Cognome", 
"CodiceFiscaleRappr", "Sesso", "DataNascita", 
"ComuneNascita"}, new string[] {"string", "string", 
"DateTime", "string", "string", 
"string", "string", "string", 
"string", "string", "DateTime", 
"string"},"");
				CompileIUCmd(false, insertCmd,InfocamereImpresaObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				InfocamereImpresaObj.IdInfocamereImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INFOCAMERE_IMPRESA"]);
				}
				InfocamereImpresaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				InfocamereImpresaObj.IsDirty = false;
				InfocamereImpresaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, InfocamereImpresa InfocamereImpresaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZInfocamereImpresaUpdate", new string[] {"IdInfocamereImpresa", "Cuaa", "CodiceFiscale", 
"DataInizioAttivita", "RagioneSociale", "Comune", 
"Via", "Nome", "Cognome", 
"CodiceFiscaleRappr", "Sesso", "DataNascita", 
"ComuneNascita"}, new string[] {"int", "string", "string", 
"DateTime", "string", "string", 
"string", "string", "string", 
"string", "string", "DateTime", 
"string"},"");
				CompileIUCmd(true, updateCmd,InfocamereImpresaObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				InfocamereImpresaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				InfocamereImpresaObj.IsDirty = false;
				InfocamereImpresaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, InfocamereImpresa InfocamereImpresaObj)
		{
			switch (InfocamereImpresaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, InfocamereImpresaObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, InfocamereImpresaObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,InfocamereImpresaObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, InfocamereImpresaCollection InfocamereImpresaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZInfocamereImpresaUpdate", new string[] {"IdInfocamereImpresa", "Cuaa", "CodiceFiscale", 
"DataInizioAttivita", "RagioneSociale", "Comune", 
"Via", "Nome", "Cognome", 
"CodiceFiscaleRappr", "Sesso", "DataNascita", 
"ComuneNascita"}, new string[] {"int", "string", "string", 
"DateTime", "string", "string", 
"string", "string", "string", 
"string", "string", "DateTime", 
"string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZInfocamereImpresaInsert", new string[] {"Cuaa", "CodiceFiscale", 
"DataInizioAttivita", "RagioneSociale", "Comune", 
"Via", "Nome", "Cognome", 
"CodiceFiscaleRappr", "Sesso", "DataNascita", 
"ComuneNascita"}, new string[] {"string", "string", 
"DateTime", "string", "string", 
"string", "string", "string", 
"string", "string", "DateTime", 
"string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZInfocamereImpresaDelete", new string[] {"IdInfocamereImpresa"}, new string[] {"int"},"");
				for (int i = 0; i < InfocamereImpresaCollectionObj.Count; i++)
				{
					switch (InfocamereImpresaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,InfocamereImpresaCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									InfocamereImpresaCollectionObj[i].IdInfocamereImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INFOCAMERE_IMPRESA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,InfocamereImpresaCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (InfocamereImpresaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdInfocamereImpresa", (SiarLibrary.NullTypes.IntNT)InfocamereImpresaCollectionObj[i].IdInfocamereImpresa);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < InfocamereImpresaCollectionObj.Count; i++)
				{
					if ((InfocamereImpresaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (InfocamereImpresaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						InfocamereImpresaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						InfocamereImpresaCollectionObj[i].IsDirty = false;
						InfocamereImpresaCollectionObj[i].IsPersistent = true;
					}
					if ((InfocamereImpresaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						InfocamereImpresaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						InfocamereImpresaCollectionObj[i].IsDirty = false;
						InfocamereImpresaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, InfocamereImpresa InfocamereImpresaObj)
		{
			int returnValue = 0;
			if (InfocamereImpresaObj.IsPersistent) 
			{
				returnValue = Delete(db, InfocamereImpresaObj.IdInfocamereImpresa);
			}
			InfocamereImpresaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			InfocamereImpresaObj.IsDirty = false;
			InfocamereImpresaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdInfocamereImpresaValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZInfocamereImpresaDelete", new string[] {"IdInfocamereImpresa"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdInfocamereImpresa", (SiarLibrary.NullTypes.IntNT)IdInfocamereImpresaValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, InfocamereImpresaCollection InfocamereImpresaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZInfocamereImpresaDelete", new string[] {"IdInfocamereImpresa"}, new string[] {"int"},"");
				for (int i = 0; i < InfocamereImpresaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdInfocamereImpresa", InfocamereImpresaCollectionObj[i].IdInfocamereImpresa);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < InfocamereImpresaCollectionObj.Count; i++)
				{
					if ((InfocamereImpresaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (InfocamereImpresaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						InfocamereImpresaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						InfocamereImpresaCollectionObj[i].IsDirty = false;
						InfocamereImpresaCollectionObj[i].IsPersistent = false;
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
		public static InfocamereImpresa GetById(DbProvider db, int IdInfocamereImpresaValue)
		{
			InfocamereImpresa InfocamereImpresaObj = null;
			IDbCommand readCmd = db.InitCmd( "ZInfocamereImpresaGetById", new string[] {"IdInfocamereImpresa"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdInfocamereImpresa", (SiarLibrary.NullTypes.IntNT)IdInfocamereImpresaValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				InfocamereImpresaObj = GetFromDatareader(db);
				InfocamereImpresaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				InfocamereImpresaObj.IsDirty = false;
				InfocamereImpresaObj.IsPersistent = true;
			}
			db.Close();
			return InfocamereImpresaObj;
		}

		//getFromDatareader
		public static InfocamereImpresa GetFromDatareader(DbProvider db)
		{
			InfocamereImpresa InfocamereImpresaObj = new InfocamereImpresa();
			InfocamereImpresaObj.IdInfocamereImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INFOCAMERE_IMPRESA"]);
			InfocamereImpresaObj.Cuaa = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUAA"]);
			InfocamereImpresaObj.CodiceFiscale = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_FISCALE"]);
			InfocamereImpresaObj.DataInizioAttivita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO_ATTIVITA"]);
			InfocamereImpresaObj.RagioneSociale = new SiarLibrary.NullTypes.StringNT(db.DataReader["RAGIONE_SOCIALE"]);
			InfocamereImpresaObj.Comune = new SiarLibrary.NullTypes.StringNT(db.DataReader["COMUNE"]);
			InfocamereImpresaObj.Via = new SiarLibrary.NullTypes.StringNT(db.DataReader["VIA"]);
			InfocamereImpresaObj.Nome = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOME"]);
			InfocamereImpresaObj.Cognome = new SiarLibrary.NullTypes.StringNT(db.DataReader["COGNOME"]);
			InfocamereImpresaObj.CodiceFiscaleRappr = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_FISCALE_RAPPR"]);
			InfocamereImpresaObj.Sesso = new SiarLibrary.NullTypes.StringNT(db.DataReader["SESSO"]);
			InfocamereImpresaObj.DataNascita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_NASCITA"]);
			InfocamereImpresaObj.ComuneNascita = new SiarLibrary.NullTypes.StringNT(db.DataReader["COMUNE_NASCITA"]);
			InfocamereImpresaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			InfocamereImpresaObj.IsDirty = false;
			InfocamereImpresaObj.IsPersistent = true;
			return InfocamereImpresaObj;
		}

		//Find Select

		public static InfocamereImpresaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdInfocamereImpresaEqualThis, SiarLibrary.NullTypes.StringNT CuaaEqualThis, SiarLibrary.NullTypes.StringNT CodiceFiscaleEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataInizioAttivitaEqualThis, SiarLibrary.NullTypes.StringNT RagioneSocialeEqualThis, SiarLibrary.NullTypes.StringNT ComuneEqualThis, 
SiarLibrary.NullTypes.StringNT ViaEqualThis, SiarLibrary.NullTypes.StringNT NomeEqualThis, SiarLibrary.NullTypes.StringNT CognomeEqualThis, 
SiarLibrary.NullTypes.StringNT CodiceFiscaleRapprEqualThis, SiarLibrary.NullTypes.StringNT SessoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataNascitaEqualThis, 
SiarLibrary.NullTypes.StringNT ComuneNascitaEqualThis)

		{

			InfocamereImpresaCollection InfocamereImpresaCollectionObj = new InfocamereImpresaCollection();

			IDbCommand findCmd = db.InitCmd("Zinfocamereimpresafindselect", new string[] {"IdInfocamereImpresaequalthis", "Cuaaequalthis", "CodiceFiscaleequalthis", 
"DataInizioAttivitaequalthis", "RagioneSocialeequalthis", "Comuneequalthis", 
"Viaequalthis", "Nomeequalthis", "Cognomeequalthis", 
"CodiceFiscaleRapprequalthis", "Sessoequalthis", "DataNascitaequalthis", 
"ComuneNascitaequalthis"}, new string[] {"int", "string", "string", 
"DateTime", "string", "string", 
"string", "string", "string", 
"string", "string", "DateTime", 
"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdInfocamereImpresaequalthis", IdInfocamereImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Cuaaequalthis", CuaaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceFiscaleequalthis", CodiceFiscaleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInizioAttivitaequalthis", DataInizioAttivitaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RagioneSocialeequalthis", RagioneSocialeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Comuneequalthis", ComuneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Viaequalthis", ViaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Nomeequalthis", NomeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Cognomeequalthis", CognomeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceFiscaleRapprequalthis", CodiceFiscaleRapprEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Sessoequalthis", SessoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataNascitaequalthis", DataNascitaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ComuneNascitaequalthis", ComuneNascitaEqualThis);
			InfocamereImpresa InfocamereImpresaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				InfocamereImpresaObj = GetFromDatareader(db);
				InfocamereImpresaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				InfocamereImpresaObj.IsDirty = false;
				InfocamereImpresaObj.IsPersistent = true;
				InfocamereImpresaCollectionObj.Add(InfocamereImpresaObj);
			}
			db.Close();
			return InfocamereImpresaCollectionObj;
		}

		//Find Find

		public static InfocamereImpresaCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdInfocamereImpresaEqualThis, SiarLibrary.NullTypes.StringNT CuaaEqualThis, SiarLibrary.NullTypes.StringNT CodiceFiscaleEqualThis)

		{

			InfocamereImpresaCollection InfocamereImpresaCollectionObj = new InfocamereImpresaCollection();

			IDbCommand findCmd = db.InitCmd("Zinfocamereimpresafindfind", new string[] {"IdInfocamereImpresaequalthis", "Cuaaequalthis", "CodiceFiscaleequalthis"}, new string[] {"int", "string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdInfocamereImpresaequalthis", IdInfocamereImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Cuaaequalthis", CuaaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceFiscaleequalthis", CodiceFiscaleEqualThis);
			InfocamereImpresa InfocamereImpresaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				InfocamereImpresaObj = GetFromDatareader(db);
				InfocamereImpresaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				InfocamereImpresaObj.IsDirty = false;
				InfocamereImpresaObj.IsPersistent = true;
				InfocamereImpresaCollectionObj.Add(InfocamereImpresaObj);
			}
			db.Close();
			return InfocamereImpresaCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for InfocamereImpresaCollectionProvider:IInfocamereImpresaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class InfocamereImpresaCollectionProvider : IInfocamereImpresaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di InfocamereImpresa
		protected InfocamereImpresaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public InfocamereImpresaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new InfocamereImpresaCollection(this);
		}

		//Costruttore 2: popola la collection
		public InfocamereImpresaCollectionProvider(IntNT IdinfocamereimpresaEqualThis, StringNT CuaaEqualThis, StringNT CodicefiscaleEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdinfocamereimpresaEqualThis, CuaaEqualThis, CodicefiscaleEqualThis);
		}

		//Costruttore3: ha in input infocamereimpresaCollectionObj - non popola la collection
		public InfocamereImpresaCollectionProvider(InfocamereImpresaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public InfocamereImpresaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new InfocamereImpresaCollection(this);
		}

		//Get e Set
		public InfocamereImpresaCollection CollectionObj
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
		public int SaveCollection(InfocamereImpresaCollection collectionObj)
		{
			return InfocamereImpresaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(InfocamereImpresa infocamereimpresaObj)
		{
			return InfocamereImpresaDAL.Save(_dbProviderObj, infocamereimpresaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(InfocamereImpresaCollection collectionObj)
		{
			return InfocamereImpresaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(InfocamereImpresa infocamereimpresaObj)
		{
			return InfocamereImpresaDAL.Delete(_dbProviderObj, infocamereimpresaObj);
		}

		//getById
		public InfocamereImpresa GetById(IntNT IdInfocamereImpresaValue)
		{
			InfocamereImpresa InfocamereImpresaTemp = InfocamereImpresaDAL.GetById(_dbProviderObj, IdInfocamereImpresaValue);
			if (InfocamereImpresaTemp!=null) InfocamereImpresaTemp.Provider = this;
			return InfocamereImpresaTemp;
		}

		//Select: popola la collection
		public InfocamereImpresaCollection Select(IntNT IdinfocamereimpresaEqualThis, StringNT CuaaEqualThis, StringNT CodicefiscaleEqualThis, 
DatetimeNT DatainizioattivitaEqualThis, StringNT RagionesocialeEqualThis, StringNT ComuneEqualThis, 
StringNT ViaEqualThis, StringNT NomeEqualThis, StringNT CognomeEqualThis, 
StringNT CodicefiscalerapprEqualThis, StringNT SessoEqualThis, DatetimeNT DatanascitaEqualThis, 
StringNT ComunenascitaEqualThis)
		{
			InfocamereImpresaCollection InfocamereImpresaCollectionTemp = InfocamereImpresaDAL.Select(_dbProviderObj, IdinfocamereimpresaEqualThis, CuaaEqualThis, CodicefiscaleEqualThis, 
DatainizioattivitaEqualThis, RagionesocialeEqualThis, ComuneEqualThis, 
ViaEqualThis, NomeEqualThis, CognomeEqualThis, 
CodicefiscalerapprEqualThis, SessoEqualThis, DatanascitaEqualThis, 
ComunenascitaEqualThis);
			InfocamereImpresaCollectionTemp.Provider = this;
			return InfocamereImpresaCollectionTemp;
		}

		//Find: popola la collection
		public InfocamereImpresaCollection Find(IntNT IdinfocamereimpresaEqualThis, StringNT CuaaEqualThis, StringNT CodicefiscaleEqualThis)
		{
			InfocamereImpresaCollection InfocamereImpresaCollectionTemp = InfocamereImpresaDAL.Find(_dbProviderObj, IdinfocamereimpresaEqualThis, CuaaEqualThis, CodicefiscaleEqualThis);
			InfocamereImpresaCollectionTemp.Provider = this;
			return InfocamereImpresaCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<INFOCAMERE_IMPRESA>
  <ViewName>
  </ViewName>
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
      <ID_INFOCAMERE_IMPRESA>Equal</ID_INFOCAMERE_IMPRESA>
      <CUAA>Equal</CUAA>
      <CODICE_FISCALE>Equal</CODICE_FISCALE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</INFOCAMERE_IMPRESA>
*/
