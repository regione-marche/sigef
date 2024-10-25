using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per Comuni
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IComuniProvider
	{
		int Save(Comuni ComuniObj);
		int SaveCollection(ComuniCollection collectionObj);
		int Delete(Comuni ComuniObj);
		int DeleteCollection(ComuniCollection collectionObj);
	}
	/// <summary>
	/// Summary description for Comuni
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class Comuni: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdComune;
		private NullTypes.StringNT _CodBelfiore;
		private NullTypes.StringNT _Denominazione;
		private NullTypes.StringNT _CodProvincia;
		private NullTypes.StringNT _Sigla;
		private NullTypes.StringNT _Cap;
		private NullTypes.StringNT _Istat;
		private NullTypes.StringNT _TipoArea;
		private NullTypes.StringNT _CodRubricaPaleo;
		private NullTypes.BoolNT _Attivo;
		private NullTypes.DatetimeNT _DataInizioValidita;
		private NullTypes.DatetimeNT _DataFineValidita;
		private NullTypes.IntNT _IdOperatoreInizio;
		private NullTypes.IntNT _IdOperatoreFine;
		private NullTypes.StringNT _CodCittaMetropolitana;
		private NullTypes.StringNT _Provincia;
		private NullTypes.StringNT _CodRegione;
		private NullTypes.StringNT _Regione;
		[NonSerialized] private IComuniProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IComuniProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public Comuni()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
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

		/// <summary>
		/// Corrisponde al campo:ATTIVO
		/// Tipo sul db:BIT
		/// Default:((1))
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
		/// Corrisponde al campo:DATA_INIZIO_VALIDITA
		/// Tipo sul db:DATETIME
		/// Default:(getdate())
		/// </summary>
		public NullTypes.DatetimeNT DataInizioValidita
		{
			get { return _DataInizioValidita; }
			set {
				if (DataInizioValidita != value)
				{
					_DataInizioValidita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_FINE_VALIDITA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataFineValidita
		{
			get { return _DataFineValidita; }
			set {
				if (DataFineValidita != value)
				{
					_DataFineValidita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_OPERATORE_INIZIO
		/// Tipo sul db:INT
		/// Default:((11))
		/// </summary>
		public NullTypes.IntNT IdOperatoreInizio
		{
			get { return _IdOperatoreInizio; }
			set {
				if (IdOperatoreInizio != value)
				{
					_IdOperatoreInizio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_OPERATORE_FINE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdOperatoreFine
		{
			get { return _IdOperatoreFine; }
			set {
				if (IdOperatoreFine != value)
				{
					_IdOperatoreFine = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_CITTA_METROPOLITANA
		/// Tipo sul db:CHAR(3)
		/// </summary>
		public NullTypes.StringNT CodCittaMetropolitana
		{
			get { return _CodCittaMetropolitana; }
			set {
				if (CodCittaMetropolitana != value)
				{
					_CodCittaMetropolitana = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PROVINCIA
		/// Tipo sul db:VARCHAR(50)
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
		/// Corrisponde al campo:COD_REGIONE
		/// Tipo sul db:CHAR(2)
		/// </summary>
		public NullTypes.StringNT CodRegione
		{
			get { return _CodRegione; }
			set {
				if (CodRegione != value)
				{
					_CodRegione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:REGIONE
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT Regione
		{
			get { return _Regione; }
			set {
				if (Regione != value)
				{
					_Regione = value;
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
	/// Summary description for ComuniCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ComuniCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ComuniCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((Comuni) info.GetValue(i.ToString(),typeof(Comuni)));
			}
		}

		//Costruttore
		public ComuniCollection()
		{
			this.ItemType = typeof(Comuni);
		}

		//Costruttore con provider
		public ComuniCollection(IComuniProvider providerObj)
		{
			this.ItemType = typeof(Comuni);
			this.Provider = providerObj;
		}

		//Get e Set
		public new Comuni this[int index]
		{
			get { return (Comuni)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ComuniCollection GetChanges()
		{
			return (ComuniCollection) base.GetChanges();
		}

		[NonSerialized] private IComuniProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IComuniProvider Provider
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
		public int Add(Comuni ComuniObj)
		{
			if (ComuniObj.Provider == null) ComuniObj.Provider = this.Provider;
			return base.Add(ComuniObj);
		}

		//AddCollection
		public void AddCollection(ComuniCollection ComuniCollectionObj)
		{
			foreach (Comuni ComuniObj in ComuniCollectionObj)
				this.Add(ComuniObj);
		}

		//Insert
		public void Insert(int index, Comuni ComuniObj)
		{
			if (ComuniObj.Provider == null) ComuniObj.Provider = this.Provider;
			base.Insert(index, ComuniObj);
		}

		//CollectionGetById
		public Comuni CollectionGetById(NullTypes.IntNT IdComuneValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdComune == IdComuneValue))
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
		public ComuniCollection SubSelect(NullTypes.IntNT IdComuneEqualThis, NullTypes.StringNT CodBelfioreEqualThis, NullTypes.StringNT DenominazioneEqualThis, 
NullTypes.StringNT CodProvinciaEqualThis, NullTypes.StringNT SiglaEqualThis, NullTypes.StringNT CapEqualThis, 
NullTypes.StringNT IstatEqualThis, NullTypes.StringNT TipoAreaEqualThis, NullTypes.StringNT CodRubricaPaleoEqualThis, 
NullTypes.BoolNT AttivoEqualThis, NullTypes.DatetimeNT DataInizioValiditaEqualThis, NullTypes.DatetimeNT DataFineValiditaEqualThis, 
NullTypes.IntNT IdOperatoreInizioEqualThis, NullTypes.IntNT IdOperatoreFineEqualThis)
		{
			ComuniCollection ComuniCollectionTemp = new ComuniCollection();
			foreach (Comuni ComuniItem in this)
			{
				if (((IdComuneEqualThis == null) || ((ComuniItem.IdComune != null) && (ComuniItem.IdComune.Value == IdComuneEqualThis.Value))) && ((CodBelfioreEqualThis == null) || ((ComuniItem.CodBelfiore != null) && (ComuniItem.CodBelfiore.Value == CodBelfioreEqualThis.Value))) && ((DenominazioneEqualThis == null) || ((ComuniItem.Denominazione != null) && (ComuniItem.Denominazione.Value == DenominazioneEqualThis.Value))) && 
((CodProvinciaEqualThis == null) || ((ComuniItem.CodProvincia != null) && (ComuniItem.CodProvincia.Value == CodProvinciaEqualThis.Value))) && ((SiglaEqualThis == null) || ((ComuniItem.Sigla != null) && (ComuniItem.Sigla.Value == SiglaEqualThis.Value))) && ((CapEqualThis == null) || ((ComuniItem.Cap != null) && (ComuniItem.Cap.Value == CapEqualThis.Value))) && 
((IstatEqualThis == null) || ((ComuniItem.Istat != null) && (ComuniItem.Istat.Value == IstatEqualThis.Value))) && ((TipoAreaEqualThis == null) || ((ComuniItem.TipoArea != null) && (ComuniItem.TipoArea.Value == TipoAreaEqualThis.Value))) && ((CodRubricaPaleoEqualThis == null) || ((ComuniItem.CodRubricaPaleo != null) && (ComuniItem.CodRubricaPaleo.Value == CodRubricaPaleoEqualThis.Value))) && 
((AttivoEqualThis == null) || ((ComuniItem.Attivo != null) && (ComuniItem.Attivo.Value == AttivoEqualThis.Value))) && ((DataInizioValiditaEqualThis == null) || ((ComuniItem.DataInizioValidita != null) && (ComuniItem.DataInizioValidita.Value == DataInizioValiditaEqualThis.Value))) && ((DataFineValiditaEqualThis == null) || ((ComuniItem.DataFineValidita != null) && (ComuniItem.DataFineValidita.Value == DataFineValiditaEqualThis.Value))) && 
((IdOperatoreInizioEqualThis == null) || ((ComuniItem.IdOperatoreInizio != null) && (ComuniItem.IdOperatoreInizio.Value == IdOperatoreInizioEqualThis.Value))) && ((IdOperatoreFineEqualThis == null) || ((ComuniItem.IdOperatoreFine != null) && (ComuniItem.IdOperatoreFine.Value == IdOperatoreFineEqualThis.Value))))
				{
					ComuniCollectionTemp.Add(ComuniItem);
				}
			}
			return ComuniCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public ComuniCollection FiltroAttivo(NullTypes.BoolNT AttivoEqualThis)
		{
			ComuniCollection ComuniCollectionTemp = new ComuniCollection();
			foreach (Comuni ComuniItem in this)
			{
				if (((AttivoEqualThis == null) || ((ComuniItem.Attivo != null) && (ComuniItem.Attivo.Value == AttivoEqualThis.Value))))
				{
					ComuniCollectionTemp.Add(ComuniItem);
				}
			}
			return ComuniCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ComuniDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ComuniDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, Comuni ComuniObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdComune", ComuniObj.IdComune);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "CodBelfiore", ComuniObj.CodBelfiore);
			DbProvider.SetCmdParam(cmd,firstChar + "Denominazione", ComuniObj.Denominazione);
			DbProvider.SetCmdParam(cmd,firstChar + "CodProvincia", ComuniObj.CodProvincia);
			DbProvider.SetCmdParam(cmd,firstChar + "Sigla", ComuniObj.Sigla);
			DbProvider.SetCmdParam(cmd,firstChar + "Cap", ComuniObj.Cap);
			DbProvider.SetCmdParam(cmd,firstChar + "Istat", ComuniObj.Istat);
			DbProvider.SetCmdParam(cmd,firstChar + "TipoArea", ComuniObj.TipoArea);
			DbProvider.SetCmdParam(cmd,firstChar + "CodRubricaPaleo", ComuniObj.CodRubricaPaleo);
			DbProvider.SetCmdParam(cmd,firstChar + "Attivo", ComuniObj.Attivo);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInizioValidita", ComuniObj.DataInizioValidita);
			DbProvider.SetCmdParam(cmd,firstChar + "DataFineValidita", ComuniObj.DataFineValidita);
			DbProvider.SetCmdParam(cmd,firstChar + "IdOperatoreInizio", ComuniObj.IdOperatoreInizio);
			DbProvider.SetCmdParam(cmd,firstChar + "IdOperatoreFine", ComuniObj.IdOperatoreFine);
		}
		//Insert
		private static int Insert(DbProvider db, Comuni ComuniObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZComuniInsert", new string[] {"CodBelfiore", "Denominazione", 
"CodProvincia", "Sigla", "Cap", 
"Istat", "TipoArea", "CodRubricaPaleo", 
"Attivo", "DataInizioValidita", "DataFineValidita", 
"IdOperatoreInizio", "IdOperatoreFine", }, new string[] {"string", "string", 
"string", "string", "string", 
"string", "string", "string", 
"bool", "DateTime", "DateTime", 
"int", "int", },"");
				CompileIUCmd(false, insertCmd,ComuniObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ComuniObj.IdComune = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COMUNE"]);
				ComuniObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
				ComuniObj.DataInizioValidita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO_VALIDITA"]);
				ComuniObj.IdOperatoreInizio = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_OPERATORE_INIZIO"]);
				}
				ComuniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ComuniObj.IsDirty = false;
				ComuniObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, Comuni ComuniObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZComuniUpdate", new string[] {"IdComune", "CodBelfiore", "Denominazione", 
"CodProvincia", "Sigla", "Cap", 
"Istat", "TipoArea", "CodRubricaPaleo", 
"Attivo", "DataInizioValidita", "DataFineValidita", 
"IdOperatoreInizio", "IdOperatoreFine", }, new string[] {"int", "string", "string", 
"string", "string", "string", 
"string", "string", "string", 
"bool", "DateTime", "DateTime", 
"int", "int", },"");
				CompileIUCmd(true, updateCmd,ComuniObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ComuniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ComuniObj.IsDirty = false;
				ComuniObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, Comuni ComuniObj)
		{
			switch (ComuniObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ComuniObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ComuniObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ComuniObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ComuniCollection ComuniCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZComuniUpdate", new string[] {"IdComune", "CodBelfiore", "Denominazione", 
"CodProvincia", "Sigla", "Cap", 
"Istat", "TipoArea", "CodRubricaPaleo", 
"Attivo", "DataInizioValidita", "DataFineValidita", 
"IdOperatoreInizio", "IdOperatoreFine", }, new string[] {"int", "string", "string", 
"string", "string", "string", 
"string", "string", "string", 
"bool", "DateTime", "DateTime", 
"int", "int", },"");
				IDbCommand insertCmd = db.InitCmd( "ZComuniInsert", new string[] {"CodBelfiore", "Denominazione", 
"CodProvincia", "Sigla", "Cap", 
"Istat", "TipoArea", "CodRubricaPaleo", 
"Attivo", "DataInizioValidita", "DataFineValidita", 
"IdOperatoreInizio", "IdOperatoreFine", }, new string[] {"string", "string", 
"string", "string", "string", 
"string", "string", "string", 
"bool", "DateTime", "DateTime", 
"int", "int", },"");
				IDbCommand deleteCmd = db.InitCmd( "ZComuniDelete", new string[] {"IdComune"}, new string[] {"int"},"");
				for (int i = 0; i < ComuniCollectionObj.Count; i++)
				{
					switch (ComuniCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ComuniCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ComuniCollectionObj[i].IdComune = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COMUNE"]);
									ComuniCollectionObj[i].Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
									ComuniCollectionObj[i].DataInizioValidita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO_VALIDITA"]);
									ComuniCollectionObj[i].IdOperatoreInizio = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_OPERATORE_INIZIO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ComuniCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ComuniCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdComune", (SiarLibrary.NullTypes.IntNT)ComuniCollectionObj[i].IdComune);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ComuniCollectionObj.Count; i++)
				{
					if ((ComuniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ComuniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ComuniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ComuniCollectionObj[i].IsDirty = false;
						ComuniCollectionObj[i].IsPersistent = true;
					}
					if ((ComuniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ComuniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ComuniCollectionObj[i].IsDirty = false;
						ComuniCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, Comuni ComuniObj)
		{
			int returnValue = 0;
			if (ComuniObj.IsPersistent) 
			{
				returnValue = Delete(db, ComuniObj.IdComune);
			}
			ComuniObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ComuniObj.IsDirty = false;
			ComuniObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdComuneValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZComuniDelete", new string[] {"IdComune"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdComune", (SiarLibrary.NullTypes.IntNT)IdComuneValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ComuniCollection ComuniCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZComuniDelete", new string[] {"IdComune"}, new string[] {"int"},"");
				for (int i = 0; i < ComuniCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdComune", ComuniCollectionObj[i].IdComune);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ComuniCollectionObj.Count; i++)
				{
					if ((ComuniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ComuniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ComuniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ComuniCollectionObj[i].IsDirty = false;
						ComuniCollectionObj[i].IsPersistent = false;
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
		public static Comuni GetById(DbProvider db, int IdComuneValue)
		{
			Comuni ComuniObj = null;
			IDbCommand readCmd = db.InitCmd( "ZComuniGetById", new string[] {"IdComune"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdComune", (SiarLibrary.NullTypes.IntNT)IdComuneValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ComuniObj = GetFromDatareader(db);
				ComuniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ComuniObj.IsDirty = false;
				ComuniObj.IsPersistent = true;
			}
			db.Close();
			return ComuniObj;
		}

		//getFromDatareader
		public static Comuni GetFromDatareader(DbProvider db)
		{
			Comuni ComuniObj = new Comuni();
			ComuniObj.IdComune = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COMUNE"]);
			ComuniObj.CodBelfiore = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_BELFIORE"]);
			ComuniObj.Denominazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DENOMINAZIONE"]);
			ComuniObj.CodProvincia = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_PROVINCIA"]);
			ComuniObj.Sigla = new SiarLibrary.NullTypes.StringNT(db.DataReader["SIGLA"]);
			ComuniObj.Cap = new SiarLibrary.NullTypes.StringNT(db.DataReader["CAP"]);
			ComuniObj.Istat = new SiarLibrary.NullTypes.StringNT(db.DataReader["ISTAT"]);
			ComuniObj.TipoArea = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_AREA"]);
			ComuniObj.CodRubricaPaleo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_RUBRICA_PALEO"]);
			ComuniObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
			ComuniObj.DataInizioValidita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO_VALIDITA"]);
			ComuniObj.DataFineValidita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE_VALIDITA"]);
			ComuniObj.IdOperatoreInizio = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_OPERATORE_INIZIO"]);
			ComuniObj.IdOperatoreFine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_OPERATORE_FINE"]);
			ComuniObj.CodCittaMetropolitana = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_CITTA_METROPOLITANA"]);
			ComuniObj.Provincia = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROVINCIA"]);
			ComuniObj.CodRegione = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_REGIONE"]);
			ComuniObj.Regione = new SiarLibrary.NullTypes.StringNT(db.DataReader["REGIONE"]);
			ComuniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ComuniObj.IsDirty = false;
			ComuniObj.IsPersistent = true;
			return ComuniObj;
		}

		//Find Select

		public static ComuniCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdComuneEqualThis, SiarLibrary.NullTypes.StringNT CodBelfioreEqualThis, SiarLibrary.NullTypes.StringNT DenominazioneEqualThis, 
SiarLibrary.NullTypes.StringNT CodProvinciaEqualThis, SiarLibrary.NullTypes.StringNT SiglaEqualThis, SiarLibrary.NullTypes.StringNT CapEqualThis, 
SiarLibrary.NullTypes.StringNT IstatEqualThis, SiarLibrary.NullTypes.StringNT TipoAreaEqualThis, SiarLibrary.NullTypes.StringNT CodRubricaPaleoEqualThis, 
SiarLibrary.NullTypes.BoolNT AttivoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInizioValiditaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataFineValiditaEqualThis, 
SiarLibrary.NullTypes.IntNT IdOperatoreInizioEqualThis, SiarLibrary.NullTypes.IntNT IdOperatoreFineEqualThis)

		{

			ComuniCollection ComuniCollectionObj = new ComuniCollection();

			IDbCommand findCmd = db.InitCmd("Zcomunifindselect", new string[] {"IdComuneequalthis", "CodBelfioreequalthis", "Denominazioneequalthis", 
"CodProvinciaequalthis", "Siglaequalthis", "Capequalthis", 
"Istatequalthis", "TipoAreaequalthis", "CodRubricaPaleoequalthis", 
"Attivoequalthis", "DataInizioValiditaequalthis", "DataFineValiditaequalthis", 
"IdOperatoreInizioequalthis", "IdOperatoreFineequalthis"}, new string[] {"int", "string", "string", 
"string", "string", "string", 
"string", "string", "string", 
"bool", "DateTime", "DateTime", 
"int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdComuneequalthis", IdComuneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodBelfioreequalthis", CodBelfioreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Denominazioneequalthis", DenominazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodProvinciaequalthis", CodProvinciaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Siglaequalthis", SiglaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Capequalthis", CapEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Istatequalthis", IstatEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TipoAreaequalthis", TipoAreaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodRubricaPaleoequalthis", CodRubricaPaleoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInizioValiditaequalthis", DataInizioValiditaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataFineValiditaequalthis", DataFineValiditaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdOperatoreInizioequalthis", IdOperatoreInizioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdOperatoreFineequalthis", IdOperatoreFineEqualThis);
			Comuni ComuniObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ComuniObj = GetFromDatareader(db);
				ComuniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ComuniObj.IsDirty = false;
				ComuniObj.IsPersistent = true;
				ComuniCollectionObj.Add(ComuniObj);
			}
			db.Close();
			return ComuniCollectionObj;
		}

		//Find Find

		public static ComuniCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT CodBelfioreEqualThis, SiarLibrary.NullTypes.StringNT CodProvinciaEqualThis, SiarLibrary.NullTypes.StringNT CodRegioneEqualThis, 
SiarLibrary.NullTypes.StringNT SiglaEqualThis, SiarLibrary.NullTypes.StringNT CapEqualThis, SiarLibrary.NullTypes.StringNT IstatEqualThis, 
SiarLibrary.NullTypes.BoolNT AttivoEqualThis, SiarLibrary.NullTypes.StringNT DenominazioneLikeThis)

		{

			ComuniCollection ComuniCollectionObj = new ComuniCollection();

			IDbCommand findCmd = db.InitCmd("Zcomunifindfind", new string[] {"CodBelfioreequalthis", "CodProvinciaequalthis", "CodRegioneequalthis", 
"Siglaequalthis", "Capequalthis", "Istatequalthis", 
"Attivoequalthis", "Denominazionelikethis"}, new string[] {"string", "string", "string", 
"string", "string", "string", 
"bool", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodBelfioreequalthis", CodBelfioreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodProvinciaequalthis", CodProvinciaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodRegioneequalthis", CodRegioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Siglaequalthis", SiglaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Capequalthis", CapEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Istatequalthis", IstatEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Denominazionelikethis", DenominazioneLikeThis);
			Comuni ComuniObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ComuniObj = GetFromDatareader(db);
				ComuniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ComuniObj.IsDirty = false;
				ComuniObj.IsPersistent = true;
				ComuniCollectionObj.Add(ComuniObj);
			}
			db.Close();
			return ComuniCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ComuniCollectionProvider:IComuniProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ComuniCollectionProvider : IComuniProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di Comuni
		protected ComuniCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ComuniCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ComuniCollection(this);
		}

		//Costruttore 2: popola la collection
		public ComuniCollectionProvider(StringNT CodbelfioreEqualThis, StringNT CodprovinciaEqualThis, StringNT CodregioneEqualThis, 
StringNT SiglaEqualThis, StringNT CapEqualThis, StringNT IstatEqualThis, 
BoolNT AttivoEqualThis, StringNT DenominazioneLikeThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(CodbelfioreEqualThis, CodprovinciaEqualThis, CodregioneEqualThis, 
SiglaEqualThis, CapEqualThis, IstatEqualThis, 
AttivoEqualThis, DenominazioneLikeThis);
		}

		//Costruttore3: ha in input comuniCollectionObj - non popola la collection
		public ComuniCollectionProvider(ComuniCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ComuniCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ComuniCollection(this);
		}

		//Get e Set
		public ComuniCollection CollectionObj
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
		public int SaveCollection(ComuniCollection collectionObj)
		{
			return ComuniDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(Comuni comuniObj)
		{
			return ComuniDAL.Save(_dbProviderObj, comuniObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ComuniCollection collectionObj)
		{
			return ComuniDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(Comuni comuniObj)
		{
			return ComuniDAL.Delete(_dbProviderObj, comuniObj);
		}

		//getById
		public Comuni GetById(IntNT IdComuneValue)
		{
			Comuni ComuniTemp = ComuniDAL.GetById(_dbProviderObj, IdComuneValue);
			if (ComuniTemp!=null) ComuniTemp.Provider = this;
			return ComuniTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ComuniCollection Select(IntNT IdcomuneEqualThis, StringNT CodbelfioreEqualThis, StringNT DenominazioneEqualThis, 
StringNT CodprovinciaEqualThis, StringNT SiglaEqualThis, StringNT CapEqualThis, 
StringNT IstatEqualThis, StringNT TipoareaEqualThis, StringNT CodrubricapaleoEqualThis, 
BoolNT AttivoEqualThis, DatetimeNT DatainiziovaliditaEqualThis, DatetimeNT DatafinevaliditaEqualThis, 
IntNT IdoperatoreinizioEqualThis, IntNT IdoperatorefineEqualThis)
		{
			ComuniCollection ComuniCollectionTemp = ComuniDAL.Select(_dbProviderObj, IdcomuneEqualThis, CodbelfioreEqualThis, DenominazioneEqualThis, 
CodprovinciaEqualThis, SiglaEqualThis, CapEqualThis, 
IstatEqualThis, TipoareaEqualThis, CodrubricapaleoEqualThis, 
AttivoEqualThis, DatainiziovaliditaEqualThis, DatafinevaliditaEqualThis, 
IdoperatoreinizioEqualThis, IdoperatorefineEqualThis);
			ComuniCollectionTemp.Provider = this;
			return ComuniCollectionTemp;
		}

		//Find: popola la collection
		public ComuniCollection Find(StringNT CodbelfioreEqualThis, StringNT CodprovinciaEqualThis, StringNT CodregioneEqualThis, 
StringNT SiglaEqualThis, StringNT CapEqualThis, StringNT IstatEqualThis, 
BoolNT AttivoEqualThis, StringNT DenominazioneLikeThis)
		{
			ComuniCollection ComuniCollectionTemp = ComuniDAL.Find(_dbProviderObj, CodbelfioreEqualThis, CodprovinciaEqualThis, CodregioneEqualThis, 
SiglaEqualThis, CapEqualThis, IstatEqualThis, 
AttivoEqualThis, DenominazioneLikeThis);
			ComuniCollectionTemp.Provider = this;
			return ComuniCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<COMUNI>
  <ViewName>vCOMUNI</ViewName>
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
    <Find OrderBy="ORDER BY ATTIVO DESC, DENOMINAZIONE, DATA_INIZIO_VALIDITA DESC">
      <COD_BELFIORE>Equal</COD_BELFIORE>
      <COD_PROVINCIA>Equal</COD_PROVINCIA>
      <COD_REGIONE>Equal</COD_REGIONE>
      <SIGLA>Equal</SIGLA>
      <CAP>Equal</CAP>
      <ISTAT>Equal</ISTAT>
      <ATTIVO>Equal</ATTIVO>
      <DENOMINAZIONE>Like</DENOMINAZIONE>
    </Find>
  </Finds>
  <Filters>
    <FiltroAttivo>
      <ATTIVO>Equal</ATTIVO>
    </FiltroAttivo>
  </Filters>
  <externalFields />
  <AddedFkFields />
</COMUNI>
*/
