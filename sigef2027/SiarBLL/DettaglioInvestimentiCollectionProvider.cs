using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per DettaglioInvestimenti
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IDettaglioInvestimentiProvider
	{
		int Save(DettaglioInvestimenti DettaglioInvestimentiObj);
		int SaveCollection(DettaglioInvestimentiCollection collectionObj);
		int Delete(DettaglioInvestimenti DettaglioInvestimentiObj);
		int DeleteCollection(DettaglioInvestimentiCollection collectionObj);
	}
	/// <summary>
	/// Summary description for DettaglioInvestimenti
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class DettaglioInvestimenti: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdDettaglioInvestimento;
		private NullTypes.IntNT _IdCodificaInvestimento;
		private NullTypes.StringNT _CodDettaglio;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.BoolNT _Mobile;
		private NullTypes.DecimalNT _QuotaSpeseGenerali;
		private NullTypes.BoolNT _RichiediParticella;
		private NullTypes.IntNT _IdUdm;
		[NonSerialized] private IDettaglioInvestimentiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IDettaglioInvestimentiProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public DettaglioInvestimenti()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_DETTAGLIO_INVESTIMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDettaglioInvestimento
		{
			get { return _IdDettaglioInvestimento; }
			set {
				if (IdDettaglioInvestimento != value)
				{
					_IdDettaglioInvestimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_CODIFICA_INVESTIMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdCodificaInvestimento
		{
			get { return _IdCodificaInvestimento; }
			set {
				if (IdCodificaInvestimento != value)
				{
					_IdCodificaInvestimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_DETTAGLIO
		/// Tipo sul db:CHAR(2)
		/// </summary>
		public NullTypes.StringNT CodDettaglio
		{
			get { return _CodDettaglio; }
			set {
				if (CodDettaglio != value)
				{
					_CodDettaglio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(255)
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
		/// Corrisponde al campo:MOBILE
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT Mobile
		{
			get { return _Mobile; }
			set {
				if (Mobile != value)
				{
					_Mobile = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUOTA_SPESE_GENERALI
		/// Tipo sul db:DECIMAL(10,2)
		/// </summary>
		public NullTypes.DecimalNT QuotaSpeseGenerali
		{
			get { return _QuotaSpeseGenerali; }
			set {
				if (QuotaSpeseGenerali != value)
				{
					_QuotaSpeseGenerali = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RICHIEDI_PARTICELLA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT RichiediParticella
		{
			get { return _RichiediParticella; }
			set {
				if (RichiediParticella != value)
				{
					_RichiediParticella = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_UDM
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdUdm
		{
			get { return _IdUdm; }
			set {
				if (IdUdm != value)
				{
					_IdUdm = value;
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
	/// Summary description for DettaglioInvestimentiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class DettaglioInvestimentiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private DettaglioInvestimentiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((DettaglioInvestimenti) info.GetValue(i.ToString(),typeof(DettaglioInvestimenti)));
			}
		}

		//Costruttore
		public DettaglioInvestimentiCollection()
		{
			this.ItemType = typeof(DettaglioInvestimenti);
		}

		//Costruttore con provider
		public DettaglioInvestimentiCollection(IDettaglioInvestimentiProvider providerObj)
		{
			this.ItemType = typeof(DettaglioInvestimenti);
			this.Provider = providerObj;
		}

		//Get e Set
		public new DettaglioInvestimenti this[int index]
		{
			get { return (DettaglioInvestimenti)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new DettaglioInvestimentiCollection GetChanges()
		{
			return (DettaglioInvestimentiCollection) base.GetChanges();
		}

		[NonSerialized] private IDettaglioInvestimentiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IDettaglioInvestimentiProvider Provider
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
		public int Add(DettaglioInvestimenti DettaglioInvestimentiObj)
		{
			if (DettaglioInvestimentiObj.Provider == null) DettaglioInvestimentiObj.Provider = this.Provider;
			return base.Add(DettaglioInvestimentiObj);
		}

		//AddCollection
		public void AddCollection(DettaglioInvestimentiCollection DettaglioInvestimentiCollectionObj)
		{
			foreach (DettaglioInvestimenti DettaglioInvestimentiObj in DettaglioInvestimentiCollectionObj)
				this.Add(DettaglioInvestimentiObj);
		}

		//Insert
		public void Insert(int index, DettaglioInvestimenti DettaglioInvestimentiObj)
		{
			if (DettaglioInvestimentiObj.Provider == null) DettaglioInvestimentiObj.Provider = this.Provider;
			base.Insert(index, DettaglioInvestimentiObj);
		}

		//CollectionGetById
		public DettaglioInvestimenti CollectionGetById(NullTypes.IntNT IdDettaglioInvestimentoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdDettaglioInvestimento == IdDettaglioInvestimentoValue))
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
		public DettaglioInvestimentiCollection SubSelect(NullTypes.IntNT IdDettaglioInvestimentoEqualThis, NullTypes.IntNT IdCodificaInvestimentoEqualThis, NullTypes.StringNT CodDettaglioEqualThis, 
NullTypes.StringNT DescrizioneEqualThis, NullTypes.BoolNT MobileEqualThis, NullTypes.DecimalNT QuotaSpeseGeneraliEqualThis, 
NullTypes.BoolNT RichiediParticellaEqualThis, NullTypes.IntNT IdUdmEqualThis)
		{
			DettaglioInvestimentiCollection DettaglioInvestimentiCollectionTemp = new DettaglioInvestimentiCollection();
			foreach (DettaglioInvestimenti DettaglioInvestimentiItem in this)
			{
				if (((IdDettaglioInvestimentoEqualThis == null) || ((DettaglioInvestimentiItem.IdDettaglioInvestimento != null) && (DettaglioInvestimentiItem.IdDettaglioInvestimento.Value == IdDettaglioInvestimentoEqualThis.Value))) && ((IdCodificaInvestimentoEqualThis == null) || ((DettaglioInvestimentiItem.IdCodificaInvestimento != null) && (DettaglioInvestimentiItem.IdCodificaInvestimento.Value == IdCodificaInvestimentoEqualThis.Value))) && ((CodDettaglioEqualThis == null) || ((DettaglioInvestimentiItem.CodDettaglio != null) && (DettaglioInvestimentiItem.CodDettaglio.Value == CodDettaglioEqualThis.Value))) && 
((DescrizioneEqualThis == null) || ((DettaglioInvestimentiItem.Descrizione != null) && (DettaglioInvestimentiItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((MobileEqualThis == null) || ((DettaglioInvestimentiItem.Mobile != null) && (DettaglioInvestimentiItem.Mobile.Value == MobileEqualThis.Value))) && ((QuotaSpeseGeneraliEqualThis == null) || ((DettaglioInvestimentiItem.QuotaSpeseGenerali != null) && (DettaglioInvestimentiItem.QuotaSpeseGenerali.Value == QuotaSpeseGeneraliEqualThis.Value))) && 
((RichiediParticellaEqualThis == null) || ((DettaglioInvestimentiItem.RichiediParticella != null) && (DettaglioInvestimentiItem.RichiediParticella.Value == RichiediParticellaEqualThis.Value))) && ((IdUdmEqualThis == null) || ((DettaglioInvestimentiItem.IdUdm != null) && (DettaglioInvestimentiItem.IdUdm.Value == IdUdmEqualThis.Value))))
				{
					DettaglioInvestimentiCollectionTemp.Add(DettaglioInvestimentiItem);
				}
			}
			return DettaglioInvestimentiCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for DettaglioInvestimentiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class DettaglioInvestimentiDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, DettaglioInvestimenti DettaglioInvestimentiObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdDettaglioInvestimento", DettaglioInvestimentiObj.IdDettaglioInvestimento);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdCodificaInvestimento", DettaglioInvestimentiObj.IdCodificaInvestimento);
			DbProvider.SetCmdParam(cmd,firstChar + "CodDettaglio", DettaglioInvestimentiObj.CodDettaglio);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", DettaglioInvestimentiObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "Mobile", DettaglioInvestimentiObj.Mobile);
			DbProvider.SetCmdParam(cmd,firstChar + "QuotaSpeseGenerali", DettaglioInvestimentiObj.QuotaSpeseGenerali);
			DbProvider.SetCmdParam(cmd,firstChar + "RichiediParticella", DettaglioInvestimentiObj.RichiediParticella);
			DbProvider.SetCmdParam(cmd,firstChar + "IdUdm", DettaglioInvestimentiObj.IdUdm);
		}
		//Insert
		private static int Insert(DbProvider db, DettaglioInvestimenti DettaglioInvestimentiObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZDettaglioInvestimentiInsert", new string[] {"IdCodificaInvestimento", "CodDettaglio", 
"Descrizione", "Mobile", "QuotaSpeseGenerali", 
"RichiediParticella", "IdUdm"}, new string[] {"int", "string", 
"string", "bool", "decimal", 
"bool", "int"},"");
				CompileIUCmd(false, insertCmd,DettaglioInvestimentiObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				DettaglioInvestimentiObj.IdDettaglioInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DETTAGLIO_INVESTIMENTO"]);
				DettaglioInvestimentiObj.Mobile = new SiarLibrary.NullTypes.BoolNT(db.DataReader["MOBILE"]);
				}
				DettaglioInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DettaglioInvestimentiObj.IsDirty = false;
				DettaglioInvestimentiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, DettaglioInvestimenti DettaglioInvestimentiObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZDettaglioInvestimentiUpdate", new string[] {"IdDettaglioInvestimento", "IdCodificaInvestimento", "CodDettaglio", 
"Descrizione", "Mobile", "QuotaSpeseGenerali", 
"RichiediParticella", "IdUdm"}, new string[] {"int", "int", "string", 
"string", "bool", "decimal", 
"bool", "int"},"");
				CompileIUCmd(true, updateCmd,DettaglioInvestimentiObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				DettaglioInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DettaglioInvestimentiObj.IsDirty = false;
				DettaglioInvestimentiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, DettaglioInvestimenti DettaglioInvestimentiObj)
		{
			switch (DettaglioInvestimentiObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, DettaglioInvestimentiObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, DettaglioInvestimentiObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,DettaglioInvestimentiObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, DettaglioInvestimentiCollection DettaglioInvestimentiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZDettaglioInvestimentiUpdate", new string[] {"IdDettaglioInvestimento", "IdCodificaInvestimento", "CodDettaglio", 
"Descrizione", "Mobile", "QuotaSpeseGenerali", 
"RichiediParticella", "IdUdm"}, new string[] {"int", "int", "string", 
"string", "bool", "decimal", 
"bool", "int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZDettaglioInvestimentiInsert", new string[] {"IdCodificaInvestimento", "CodDettaglio", 
"Descrizione", "Mobile", "QuotaSpeseGenerali", 
"RichiediParticella", "IdUdm"}, new string[] {"int", "string", 
"string", "bool", "decimal", 
"bool", "int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZDettaglioInvestimentiDelete", new string[] {"IdDettaglioInvestimento"}, new string[] {"int"},"");
				for (int i = 0; i < DettaglioInvestimentiCollectionObj.Count; i++)
				{
					switch (DettaglioInvestimentiCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,DettaglioInvestimentiCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									DettaglioInvestimentiCollectionObj[i].IdDettaglioInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DETTAGLIO_INVESTIMENTO"]);
									DettaglioInvestimentiCollectionObj[i].Mobile = new SiarLibrary.NullTypes.BoolNT(db.DataReader["MOBILE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,DettaglioInvestimentiCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (DettaglioInvestimentiCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDettaglioInvestimento", (SiarLibrary.NullTypes.IntNT)DettaglioInvestimentiCollectionObj[i].IdDettaglioInvestimento);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < DettaglioInvestimentiCollectionObj.Count; i++)
				{
					if ((DettaglioInvestimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (DettaglioInvestimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						DettaglioInvestimentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						DettaglioInvestimentiCollectionObj[i].IsDirty = false;
						DettaglioInvestimentiCollectionObj[i].IsPersistent = true;
					}
					if ((DettaglioInvestimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						DettaglioInvestimentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						DettaglioInvestimentiCollectionObj[i].IsDirty = false;
						DettaglioInvestimentiCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, DettaglioInvestimenti DettaglioInvestimentiObj)
		{
			int returnValue = 0;
			if (DettaglioInvestimentiObj.IsPersistent) 
			{
				returnValue = Delete(db, DettaglioInvestimentiObj.IdDettaglioInvestimento);
			}
			DettaglioInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			DettaglioInvestimentiObj.IsDirty = false;
			DettaglioInvestimentiObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdDettaglioInvestimentoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZDettaglioInvestimentiDelete", new string[] {"IdDettaglioInvestimento"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDettaglioInvestimento", (SiarLibrary.NullTypes.IntNT)IdDettaglioInvestimentoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, DettaglioInvestimentiCollection DettaglioInvestimentiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZDettaglioInvestimentiDelete", new string[] {"IdDettaglioInvestimento"}, new string[] {"int"},"");
				for (int i = 0; i < DettaglioInvestimentiCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDettaglioInvestimento", DettaglioInvestimentiCollectionObj[i].IdDettaglioInvestimento);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < DettaglioInvestimentiCollectionObj.Count; i++)
				{
					if ((DettaglioInvestimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (DettaglioInvestimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						DettaglioInvestimentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						DettaglioInvestimentiCollectionObj[i].IsDirty = false;
						DettaglioInvestimentiCollectionObj[i].IsPersistent = false;
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
		public static DettaglioInvestimenti GetById(DbProvider db, int IdDettaglioInvestimentoValue)
		{
			DettaglioInvestimenti DettaglioInvestimentiObj = null;
			IDbCommand readCmd = db.InitCmd( "ZDettaglioInvestimentiGetById", new string[] {"IdDettaglioInvestimento"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdDettaglioInvestimento", (SiarLibrary.NullTypes.IntNT)IdDettaglioInvestimentoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				DettaglioInvestimentiObj = GetFromDatareader(db);
				DettaglioInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DettaglioInvestimentiObj.IsDirty = false;
				DettaglioInvestimentiObj.IsPersistent = true;
			}
			db.Close();
			return DettaglioInvestimentiObj;
		}

		//getFromDatareader
		public static DettaglioInvestimenti GetFromDatareader(DbProvider db)
		{
			DettaglioInvestimenti DettaglioInvestimentiObj = new DettaglioInvestimenti();
			DettaglioInvestimentiObj.IdDettaglioInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DETTAGLIO_INVESTIMENTO"]);
			DettaglioInvestimentiObj.IdCodificaInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CODIFICA_INVESTIMENTO"]);
			DettaglioInvestimentiObj.CodDettaglio = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_DETTAGLIO"]);
			DettaglioInvestimentiObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			DettaglioInvestimentiObj.Mobile = new SiarLibrary.NullTypes.BoolNT(db.DataReader["MOBILE"]);
			DettaglioInvestimentiObj.QuotaSpeseGenerali = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUOTA_SPESE_GENERALI"]);
			DettaglioInvestimentiObj.RichiediParticella = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RICHIEDI_PARTICELLA"]);
			DettaglioInvestimentiObj.IdUdm = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_UDM"]);
			DettaglioInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			DettaglioInvestimentiObj.IsDirty = false;
			DettaglioInvestimentiObj.IsPersistent = true;
			return DettaglioInvestimentiObj;
		}

		//Find Select

		public static DettaglioInvestimentiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdDettaglioInvestimentoEqualThis, SiarLibrary.NullTypes.IntNT IdCodificaInvestimentoEqualThis, SiarLibrary.NullTypes.StringNT CodDettaglioEqualThis, 
SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.BoolNT MobileEqualThis, SiarLibrary.NullTypes.DecimalNT QuotaSpeseGeneraliEqualThis, 
SiarLibrary.NullTypes.BoolNT RichiediParticellaEqualThis, SiarLibrary.NullTypes.IntNT IdUdmEqualThis)

		{

			DettaglioInvestimentiCollection DettaglioInvestimentiCollectionObj = new DettaglioInvestimentiCollection();

			IDbCommand findCmd = db.InitCmd("Zdettaglioinvestimentifindselect", new string[] {"IdDettaglioInvestimentoequalthis", "IdCodificaInvestimentoequalthis", "CodDettaglioequalthis", 
"Descrizioneequalthis", "Mobileequalthis", "QuotaSpeseGeneraliequalthis", 
"RichiediParticellaequalthis", "IdUdmequalthis"}, new string[] {"int", "int", "string", 
"string", "bool", "decimal", 
"bool", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDettaglioInvestimentoequalthis", IdDettaglioInvestimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCodificaInvestimentoequalthis", IdCodificaInvestimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodDettaglioequalthis", CodDettaglioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Mobileequalthis", MobileEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "QuotaSpeseGeneraliequalthis", QuotaSpeseGeneraliEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RichiediParticellaequalthis", RichiediParticellaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdUdmequalthis", IdUdmEqualThis);
			DettaglioInvestimenti DettaglioInvestimentiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				DettaglioInvestimentiObj = GetFromDatareader(db);
				DettaglioInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DettaglioInvestimentiObj.IsDirty = false;
				DettaglioInvestimentiObj.IsPersistent = true;
				DettaglioInvestimentiCollectionObj.Add(DettaglioInvestimentiObj);
			}
			db.Close();
			return DettaglioInvestimentiCollectionObj;
		}

		//Find Find

		public static DettaglioInvestimentiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdCodificaInvestimentoEqualThis, SiarLibrary.NullTypes.StringNT CodDettaglioEqualThis)

		{

			DettaglioInvestimentiCollection DettaglioInvestimentiCollectionObj = new DettaglioInvestimentiCollection();

			IDbCommand findCmd = db.InitCmd("Zdettaglioinvestimentifindfind", new string[] {"IdCodificaInvestimentoequalthis", "CodDettaglioequalthis"}, new string[] {"int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCodificaInvestimentoequalthis", IdCodificaInvestimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodDettaglioequalthis", CodDettaglioEqualThis);
			DettaglioInvestimenti DettaglioInvestimentiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				DettaglioInvestimentiObj = GetFromDatareader(db);
				DettaglioInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DettaglioInvestimentiObj.IsDirty = false;
				DettaglioInvestimentiObj.IsPersistent = true;
				DettaglioInvestimentiCollectionObj.Add(DettaglioInvestimentiObj);
			}
			db.Close();
			return DettaglioInvestimentiCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for DettaglioInvestimentiCollectionProvider:IDettaglioInvestimentiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class DettaglioInvestimentiCollectionProvider : IDettaglioInvestimentiProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di DettaglioInvestimenti
		protected DettaglioInvestimentiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public DettaglioInvestimentiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new DettaglioInvestimentiCollection(this);
		}

		//Costruttore 2: popola la collection
		public DettaglioInvestimentiCollectionProvider(IntNT IdcodificainvestimentoEqualThis, StringNT CoddettaglioEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdcodificainvestimentoEqualThis, CoddettaglioEqualThis);
		}

		//Costruttore3: ha in input dettaglioinvestimentiCollectionObj - non popola la collection
		public DettaglioInvestimentiCollectionProvider(DettaglioInvestimentiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public DettaglioInvestimentiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new DettaglioInvestimentiCollection(this);
		}

		//Get e Set
		public DettaglioInvestimentiCollection CollectionObj
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
		public int SaveCollection(DettaglioInvestimentiCollection collectionObj)
		{
			return DettaglioInvestimentiDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(DettaglioInvestimenti dettaglioinvestimentiObj)
		{
			return DettaglioInvestimentiDAL.Save(_dbProviderObj, dettaglioinvestimentiObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(DettaglioInvestimentiCollection collectionObj)
		{
			return DettaglioInvestimentiDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(DettaglioInvestimenti dettaglioinvestimentiObj)
		{
			return DettaglioInvestimentiDAL.Delete(_dbProviderObj, dettaglioinvestimentiObj);
		}

		//getById
		public DettaglioInvestimenti GetById(IntNT IdDettaglioInvestimentoValue)
		{
			DettaglioInvestimenti DettaglioInvestimentiTemp = DettaglioInvestimentiDAL.GetById(_dbProviderObj, IdDettaglioInvestimentoValue);
			if (DettaglioInvestimentiTemp!=null) DettaglioInvestimentiTemp.Provider = this;
			return DettaglioInvestimentiTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public DettaglioInvestimentiCollection Select(IntNT IddettaglioinvestimentoEqualThis, IntNT IdcodificainvestimentoEqualThis, StringNT CoddettaglioEqualThis, 
StringNT DescrizioneEqualThis, BoolNT MobileEqualThis, DecimalNT QuotaspesegeneraliEqualThis, 
BoolNT RichiediparticellaEqualThis, IntNT IdudmEqualThis)
		{
			DettaglioInvestimentiCollection DettaglioInvestimentiCollectionTemp = DettaglioInvestimentiDAL.Select(_dbProviderObj, IddettaglioinvestimentoEqualThis, IdcodificainvestimentoEqualThis, CoddettaglioEqualThis, 
DescrizioneEqualThis, MobileEqualThis, QuotaspesegeneraliEqualThis, 
RichiediparticellaEqualThis, IdudmEqualThis);
			DettaglioInvestimentiCollectionTemp.Provider = this;
			return DettaglioInvestimentiCollectionTemp;
		}

		//Find: popola la collection
		public DettaglioInvestimentiCollection Find(IntNT IdcodificainvestimentoEqualThis, StringNT CoddettaglioEqualThis)
		{
			DettaglioInvestimentiCollection DettaglioInvestimentiCollectionTemp = DettaglioInvestimentiDAL.Find(_dbProviderObj, IdcodificainvestimentoEqualThis, CoddettaglioEqualThis);
			DettaglioInvestimentiCollectionTemp.Provider = this;
			return DettaglioInvestimentiCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<DETTAGLIO_INVESTIMENTI>
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
    <Find OrderBy="ORDER BY ID_DETTAGLIO_INVESTIMENTO">
      <ID_CODIFICA_INVESTIMENTO>Equal</ID_CODIFICA_INVESTIMENTO>
      <COD_DETTAGLIO>Equal</COD_DETTAGLIO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</DETTAGLIO_INVESTIMENTI>
*/
