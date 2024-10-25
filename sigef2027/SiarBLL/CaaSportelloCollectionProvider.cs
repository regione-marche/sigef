using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per CaaSportello
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ICaaSportelloProvider
	{
		int Save(CaaSportello CaaSportelloObj);
		int SaveCollection(CaaSportelloCollection collectionObj);
		int Delete(CaaSportello CaaSportelloObj);
		int DeleteCollection(CaaSportelloCollection collectionObj);
	}
	/// <summary>
	/// Summary description for CaaSportello
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class CaaSportello: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.StringNT _Codice;
		private NullTypes.StringNT _CodiceCaa;
		private NullTypes.StringNT _CodiceProvincia;
		private NullTypes.StringNT _CodiceUfficio;
		private NullTypes.StringNT _CodEnte;
		private NullTypes.IntNT _IdStoricoUltimo;
		private NullTypes.StringNT _Stato;
		private NullTypes.StringNT _Denominazione;
		private NullTypes.BoolNT _UfficioProvinciale;
		private NullTypes.BoolNT _UfficioRegionale;
		private NullTypes.StringNT _Indirizzo;
		private NullTypes.IntNT _IdComune;
		private NullTypes.StringNT _Telefono;
		private NullTypes.StringNT _Fax;
		private NullTypes.StringNT _Email;
		private NullTypes.StringNT _CodStato;
		private NullTypes.DatetimeNT _Data;
		private NullTypes.IntNT _Operatore;
		private NullTypes.StringNT _Comune;
		private NullTypes.StringNT _Provincia;
		private NullTypes.StringNT _Cap;
		[NonSerialized] private ICaaSportelloProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICaaSportelloProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public CaaSportello()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:CODICE
		/// Tipo sul db:CHAR(9)
		/// </summary>
		public NullTypes.StringNT Codice
		{
			get { return _Codice; }
			set {
				if (Codice != value)
				{
					_Codice = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE_CAA
		/// Tipo sul db:CHAR(3)
		/// </summary>
		public NullTypes.StringNT CodiceCaa
		{
			get { return _CodiceCaa; }
			set {
				if (CodiceCaa != value)
				{
					_CodiceCaa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE_PROVINCIA
		/// Tipo sul db:CHAR(3)
		/// </summary>
		public NullTypes.StringNT CodiceProvincia
		{
			get { return _CodiceProvincia; }
			set {
				if (CodiceProvincia != value)
				{
					_CodiceProvincia = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE_UFFICIO
		/// Tipo sul db:CHAR(3)
		/// </summary>
		public NullTypes.StringNT CodiceUfficio
		{
			get { return _CodiceUfficio; }
			set {
				if (CodiceUfficio != value)
				{
					_CodiceUfficio = value;
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
		/// Corrisponde al campo:DENOMINAZIONE
		/// Tipo sul db:VARCHAR(60)
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
		/// Corrisponde al campo:UFFICIO_PROVINCIALE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT UfficioProvinciale
		{
			get { return _UfficioProvinciale; }
			set {
				if (UfficioProvinciale != value)
				{
					_UfficioProvinciale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:UFFICIO_REGIONALE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT UfficioRegionale
		{
			get { return _UfficioRegionale; }
			set {
				if (UfficioRegionale != value)
				{
					_UfficioRegionale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:INDIRIZZO
		/// Tipo sul db:VARCHAR(150)
		/// </summary>
		public NullTypes.StringNT Indirizzo
		{
			get { return _Indirizzo; }
			set {
				if (Indirizzo != value)
				{
					_Indirizzo = value;
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
		/// Corrisponde al campo:TELEFONO
		/// Tipo sul db:VARCHAR(15)
		/// </summary>
		public NullTypes.StringNT Telefono
		{
			get { return _Telefono; }
			set {
				if (Telefono != value)
				{
					_Telefono = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FAX
		/// Tipo sul db:VARCHAR(15)
		/// </summary>
		public NullTypes.StringNT Fax
		{
			get { return _Fax; }
			set {
				if (Fax != value)
				{
					_Fax = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:EMAIL
		/// Tipo sul db:VARCHAR(50)
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
	/// Summary description for CaaSportelloCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CaaSportelloCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private CaaSportelloCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((CaaSportello) info.GetValue(i.ToString(),typeof(CaaSportello)));
			}
		}

		//Costruttore
		public CaaSportelloCollection()
		{
			this.ItemType = typeof(CaaSportello);
		}

		//Costruttore con provider
		public CaaSportelloCollection(ICaaSportelloProvider providerObj)
		{
			this.ItemType = typeof(CaaSportello);
			this.Provider = providerObj;
		}

		//Get e Set
		public new CaaSportello this[int index]
		{
			get { return (CaaSportello)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new CaaSportelloCollection GetChanges()
		{
			return (CaaSportelloCollection) base.GetChanges();
		}

		[NonSerialized] private ICaaSportelloProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICaaSportelloProvider Provider
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
		public int Add(CaaSportello CaaSportelloObj)
		{
			if (CaaSportelloObj.Provider == null) CaaSportelloObj.Provider = this.Provider;
			return base.Add(CaaSportelloObj);
		}

		//AddCollection
		public void AddCollection(CaaSportelloCollection CaaSportelloCollectionObj)
		{
			foreach (CaaSportello CaaSportelloObj in CaaSportelloCollectionObj)
				this.Add(CaaSportelloObj);
		}

		//Insert
		public void Insert(int index, CaaSportello CaaSportelloObj)
		{
			if (CaaSportelloObj.Provider == null) CaaSportelloObj.Provider = this.Provider;
			base.Insert(index, CaaSportelloObj);
		}

		//CollectionGetById
		public CaaSportello CollectionGetById(NullTypes.StringNT CodiceValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].Codice == CodiceValue))
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
		public CaaSportelloCollection SubSelect(NullTypes.StringNT CodiceEqualThis, NullTypes.StringNT CodiceCaaEqualThis, NullTypes.StringNT CodiceProvinciaEqualThis, 
NullTypes.StringNT CodiceUfficioEqualThis, NullTypes.StringNT CodEnteEqualThis, NullTypes.IntNT IdStoricoUltimoEqualThis)
		{
			CaaSportelloCollection CaaSportelloCollectionTemp = new CaaSportelloCollection();
			foreach (CaaSportello CaaSportelloItem in this)
			{
				if (((CodiceEqualThis == null) || ((CaaSportelloItem.Codice != null) && (CaaSportelloItem.Codice.Value == CodiceEqualThis.Value))) && ((CodiceCaaEqualThis == null) || ((CaaSportelloItem.CodiceCaa != null) && (CaaSportelloItem.CodiceCaa.Value == CodiceCaaEqualThis.Value))) && ((CodiceProvinciaEqualThis == null) || ((CaaSportelloItem.CodiceProvincia != null) && (CaaSportelloItem.CodiceProvincia.Value == CodiceProvinciaEqualThis.Value))) && 
((CodiceUfficioEqualThis == null) || ((CaaSportelloItem.CodiceUfficio != null) && (CaaSportelloItem.CodiceUfficio.Value == CodiceUfficioEqualThis.Value))) && ((CodEnteEqualThis == null) || ((CaaSportelloItem.CodEnte != null) && (CaaSportelloItem.CodEnte.Value == CodEnteEqualThis.Value))) && ((IdStoricoUltimoEqualThis == null) || ((CaaSportelloItem.IdStoricoUltimo != null) && (CaaSportelloItem.IdStoricoUltimo.Value == IdStoricoUltimoEqualThis.Value))))
				{
					CaaSportelloCollectionTemp.Add(CaaSportelloItem);
				}
			}
			return CaaSportelloCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public CaaSportelloCollection FiltroUfficioRegionale(NullTypes.BoolNT UfficioProvincialeEqualThis, NullTypes.BoolNT UfficioRegionaleEqualThis)
		{
			CaaSportelloCollection CaaSportelloCollectionTemp = new CaaSportelloCollection();
			foreach (CaaSportello CaaSportelloItem in this)
			{
				if (((UfficioProvincialeEqualThis == null) || ((CaaSportelloItem.UfficioProvinciale != null) && (CaaSportelloItem.UfficioProvinciale.Value == UfficioProvincialeEqualThis.Value))) && ((UfficioRegionaleEqualThis == null) || ((CaaSportelloItem.UfficioRegionale != null) && (CaaSportelloItem.UfficioRegionale.Value == UfficioRegionaleEqualThis.Value))))
				{
					CaaSportelloCollectionTemp.Add(CaaSportelloItem);
				}
			}
			return CaaSportelloCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for CaaSportelloDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class CaaSportelloDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CaaSportello CaaSportelloObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Codice", CaaSportelloObj.Codice);
			DbProvider.SetCmdParam(cmd,firstChar + "CodiceCaa", CaaSportelloObj.CodiceCaa);
			DbProvider.SetCmdParam(cmd,firstChar + "CodiceProvincia", CaaSportelloObj.CodiceProvincia);
			DbProvider.SetCmdParam(cmd,firstChar + "CodiceUfficio", CaaSportelloObj.CodiceUfficio);
			DbProvider.SetCmdParam(cmd,firstChar + "CodEnte", CaaSportelloObj.CodEnte);
			DbProvider.SetCmdParam(cmd,firstChar + "IdStoricoUltimo", CaaSportelloObj.IdStoricoUltimo);
		}
		//Insert
		private static int Insert(DbProvider db, CaaSportello CaaSportelloObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZCaaSportelloInsert", new string[] {"Codice", "CodiceCaa", "CodiceProvincia", 
"CodiceUfficio", "CodEnte", "IdStoricoUltimo", 



}, new string[] {"string", "string", "string", 
"string", "string", "int", 



},"");
				CompileIUCmd(false, insertCmd,CaaSportelloObj, db.CommandFirstChar);
				i = db.Execute(insertCmd);
				CaaSportelloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CaaSportelloObj.IsDirty = false;
				CaaSportelloObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, CaaSportello CaaSportelloObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCaaSportelloUpdate", new string[] {"Codice", "CodiceCaa", "CodiceProvincia", 
"CodiceUfficio", "CodEnte", "IdStoricoUltimo", 



}, new string[] {"string", "string", "string", 
"string", "string", "int", 



},"");
				CompileIUCmd(true, updateCmd,CaaSportelloObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				CaaSportelloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CaaSportelloObj.IsDirty = false;
				CaaSportelloObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, CaaSportello CaaSportelloObj)
		{
			switch (CaaSportelloObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, CaaSportelloObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, CaaSportelloObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,CaaSportelloObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, CaaSportelloCollection CaaSportelloCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCaaSportelloUpdate", new string[] {"Codice", "CodiceCaa", "CodiceProvincia", 
"CodiceUfficio", "CodEnte", "IdStoricoUltimo", 



}, new string[] {"string", "string", "string", 
"string", "string", "int", 



},"");
				IDbCommand insertCmd = db.InitCmd( "ZCaaSportelloInsert", new string[] {"Codice", "CodiceCaa", "CodiceProvincia", 
"CodiceUfficio", "CodEnte", "IdStoricoUltimo", 



}, new string[] {"string", "string", "string", 
"string", "string", "int", 



},"");
				IDbCommand deleteCmd = db.InitCmd( "ZCaaSportelloDelete", new string[] {"Codice"}, new string[] {"string"},"");
				for (int i = 0; i < CaaSportelloCollectionObj.Count; i++)
				{
					switch (CaaSportelloCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,CaaSportelloCollectionObj[i], db.CommandFirstChar);
								returnValue += db.Execute(insertCmd);
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,CaaSportelloCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (CaaSportelloCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Codice", (SiarLibrary.NullTypes.StringNT)CaaSportelloCollectionObj[i].Codice);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < CaaSportelloCollectionObj.Count; i++)
				{
					if ((CaaSportelloCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CaaSportelloCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CaaSportelloCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						CaaSportelloCollectionObj[i].IsDirty = false;
						CaaSportelloCollectionObj[i].IsPersistent = true;
					}
					if ((CaaSportelloCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						CaaSportelloCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CaaSportelloCollectionObj[i].IsDirty = false;
						CaaSportelloCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, CaaSportello CaaSportelloObj)
		{
			int returnValue = 0;
			if (CaaSportelloObj.IsPersistent) 
			{
				returnValue = Delete(db, CaaSportelloObj.Codice);
			}
			CaaSportelloObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			CaaSportelloObj.IsDirty = false;
			CaaSportelloObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, string CodiceValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCaaSportelloDelete", new string[] {"Codice"}, new string[] {"string"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Codice", (SiarLibrary.NullTypes.StringNT)CodiceValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, CaaSportelloCollection CaaSportelloCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCaaSportelloDelete", new string[] {"Codice"}, new string[] {"string"},"");
				for (int i = 0; i < CaaSportelloCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Codice", CaaSportelloCollectionObj[i].Codice);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < CaaSportelloCollectionObj.Count; i++)
				{
					if ((CaaSportelloCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CaaSportelloCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CaaSportelloCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CaaSportelloCollectionObj[i].IsDirty = false;
						CaaSportelloCollectionObj[i].IsPersistent = false;
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
		public static CaaSportello GetById(DbProvider db, string CodiceValue)
		{
			CaaSportello CaaSportelloObj = null;
			IDbCommand readCmd = db.InitCmd( "ZCaaSportelloGetById", new string[] {"Codice"}, new string[] {"string"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Codice", (SiarLibrary.NullTypes.StringNT)CodiceValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				CaaSportelloObj = GetFromDatareader(db);
				CaaSportelloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CaaSportelloObj.IsDirty = false;
				CaaSportelloObj.IsPersistent = true;
			}
			db.Close();
			return CaaSportelloObj;
		}

		//getFromDatareader
		public static CaaSportello GetFromDatareader(DbProvider db)
		{
			CaaSportello CaaSportelloObj = new CaaSportello();
			CaaSportelloObj.Codice = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE"]);
			CaaSportelloObj.CodiceCaa = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_CAA"]);
			CaaSportelloObj.CodiceProvincia = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_PROVINCIA"]);
			CaaSportelloObj.CodiceUfficio = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_UFFICIO"]);
			CaaSportelloObj.CodEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE"]);
			CaaSportelloObj.IdStoricoUltimo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_STORICO_ULTIMO"]);
			CaaSportelloObj.Stato = new SiarLibrary.NullTypes.StringNT(db.DataReader["STATO"]);
			CaaSportelloObj.Denominazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DENOMINAZIONE"]);
			CaaSportelloObj.UfficioProvinciale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["UFFICIO_PROVINCIALE"]);
			CaaSportelloObj.UfficioRegionale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["UFFICIO_REGIONALE"]);
			CaaSportelloObj.Indirizzo = new SiarLibrary.NullTypes.StringNT(db.DataReader["INDIRIZZO"]);
			CaaSportelloObj.IdComune = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COMUNE"]);
			CaaSportelloObj.Telefono = new SiarLibrary.NullTypes.StringNT(db.DataReader["TELEFONO"]);
			CaaSportelloObj.Fax = new SiarLibrary.NullTypes.StringNT(db.DataReader["FAX"]);
			CaaSportelloObj.Email = new SiarLibrary.NullTypes.StringNT(db.DataReader["EMAIL"]);
			CaaSportelloObj.CodStato = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_STATO"]);
			CaaSportelloObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
			CaaSportelloObj.Operatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE"]);
			CaaSportelloObj.Comune = new SiarLibrary.NullTypes.StringNT(db.DataReader["COMUNE"]);
			CaaSportelloObj.Provincia = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROVINCIA"]);
			CaaSportelloObj.Cap = new SiarLibrary.NullTypes.StringNT(db.DataReader["CAP"]);
			CaaSportelloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			CaaSportelloObj.IsDirty = false;
			CaaSportelloObj.IsPersistent = true;
			return CaaSportelloObj;
		}

		//Find Select

		public static CaaSportelloCollection Select(DbProvider db, SiarLibrary.NullTypes.StringNT CodiceEqualThis, SiarLibrary.NullTypes.StringNT CodiceCaaEqualThis, SiarLibrary.NullTypes.StringNT CodiceProvinciaEqualThis, 
SiarLibrary.NullTypes.StringNT CodiceUfficioEqualThis, SiarLibrary.NullTypes.StringNT CodEnteEqualThis, SiarLibrary.NullTypes.IntNT IdStoricoUltimoEqualThis)

		{

			CaaSportelloCollection CaaSportelloCollectionObj = new CaaSportelloCollection();

			IDbCommand findCmd = db.InitCmd("Zcaasportellofindselect", new string[] {"Codiceequalthis", "CodiceCaaequalthis", "CodiceProvinciaequalthis", 
"CodiceUfficioequalthis", "CodEnteequalthis", "IdStoricoUltimoequalthis"}, new string[] {"string", "string", "string", 
"string", "string", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Codiceequalthis", CodiceEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceCaaequalthis", CodiceCaaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceProvinciaequalthis", CodiceProvinciaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceUfficioequalthis", CodiceUfficioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodEnteequalthis", CodEnteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdStoricoUltimoequalthis", IdStoricoUltimoEqualThis);
			CaaSportello CaaSportelloObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CaaSportelloObj = GetFromDatareader(db);
				CaaSportelloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CaaSportelloObj.IsDirty = false;
				CaaSportelloObj.IsPersistent = true;
				CaaSportelloCollectionObj.Add(CaaSportelloObj);
			}
			db.Close();
			return CaaSportelloCollectionObj;
		}

		//Find Find

		public static CaaSportelloCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT CodiceEqualThis, SiarLibrary.NullTypes.StringNT CodEnteEqualThis, SiarLibrary.NullTypes.IntNT IdComuneEqualThis, 
SiarLibrary.NullTypes.StringNT ProvinciaEqualThis, SiarLibrary.NullTypes.StringNT CodStatoEqualThis)

		{

			CaaSportelloCollection CaaSportelloCollectionObj = new CaaSportelloCollection();

			IDbCommand findCmd = db.InitCmd("Zcaasportellofindfind", new string[] {"Codiceequalthis", "CodEnteequalthis", "IdComuneequalthis", 
"Provinciaequalthis", "CodStatoequalthis"}, new string[] {"string", "string", "int", 
"string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Codiceequalthis", CodiceEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodEnteequalthis", CodEnteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdComuneequalthis", IdComuneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Provinciaequalthis", ProvinciaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodStatoequalthis", CodStatoEqualThis);
			CaaSportello CaaSportelloObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CaaSportelloObj = GetFromDatareader(db);
				CaaSportelloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CaaSportelloObj.IsDirty = false;
				CaaSportelloObj.IsPersistent = true;
				CaaSportelloCollectionObj.Add(CaaSportelloObj);
			}
			db.Close();
			return CaaSportelloCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for CaaSportelloCollectionProvider:ICaaSportelloProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CaaSportelloCollectionProvider : ICaaSportelloProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di CaaSportello
		protected CaaSportelloCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public CaaSportelloCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new CaaSportelloCollection(this);
		}

		//Costruttore 2: popola la collection
		public CaaSportelloCollectionProvider(StringNT CodiceEqualThis, StringNT CodenteEqualThis, IntNT IdcomuneEqualThis, 
StringNT ProvinciaEqualThis, StringNT CodstatoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(CodiceEqualThis, CodenteEqualThis, IdcomuneEqualThis, 
ProvinciaEqualThis, CodstatoEqualThis);
		}

		//Costruttore3: ha in input caasportelloCollectionObj - non popola la collection
		public CaaSportelloCollectionProvider(CaaSportelloCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public CaaSportelloCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new CaaSportelloCollection(this);
		}

		//Get e Set
		public CaaSportelloCollection CollectionObj
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
		public int SaveCollection(CaaSportelloCollection collectionObj)
		{
			return CaaSportelloDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(CaaSportello caasportelloObj)
		{
			return CaaSportelloDAL.Save(_dbProviderObj, caasportelloObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(CaaSportelloCollection collectionObj)
		{
			return CaaSportelloDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(CaaSportello caasportelloObj)
		{
			return CaaSportelloDAL.Delete(_dbProviderObj, caasportelloObj);
		}

		//getById
		public CaaSportello GetById(StringNT CodiceValue)
		{
			CaaSportello CaaSportelloTemp = CaaSportelloDAL.GetById(_dbProviderObj, CodiceValue);
			if (CaaSportelloTemp!=null) CaaSportelloTemp.Provider = this;
			return CaaSportelloTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public CaaSportelloCollection Select(StringNT CodiceEqualThis, StringNT CodicecaaEqualThis, StringNT CodiceprovinciaEqualThis, 
StringNT CodiceufficioEqualThis, StringNT CodenteEqualThis, IntNT IdstoricoultimoEqualThis)
		{
			CaaSportelloCollection CaaSportelloCollectionTemp = CaaSportelloDAL.Select(_dbProviderObj, CodiceEqualThis, CodicecaaEqualThis, CodiceprovinciaEqualThis, 
CodiceufficioEqualThis, CodenteEqualThis, IdstoricoultimoEqualThis);
			CaaSportelloCollectionTemp.Provider = this;
			return CaaSportelloCollectionTemp;
		}

		//Find: popola la collection
		public CaaSportelloCollection Find(StringNT CodiceEqualThis, StringNT CodenteEqualThis, IntNT IdcomuneEqualThis, 
StringNT ProvinciaEqualThis, StringNT CodstatoEqualThis)
		{
			CaaSportelloCollection CaaSportelloCollectionTemp = CaaSportelloDAL.Find(_dbProviderObj, CodiceEqualThis, CodenteEqualThis, IdcomuneEqualThis, 
ProvinciaEqualThis, CodstatoEqualThis);
			CaaSportelloCollectionTemp.Provider = this;
			return CaaSportelloCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CAA_SPORTELLO>
  <ViewName>vCAA_SPORTELLO</ViewName>
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
    <Find OrderBy="ORDER BY CODICE">
      <CODICE>Equal</CODICE>
      <COD_ENTE>Equal</COD_ENTE>
      <ID_COMUNE>Equal</ID_COMUNE>
      <PROVINCIA>Equal</PROVINCIA>
      <COD_STATO>Equal</COD_STATO>
    </Find>
  </Finds>
  <Filters>
    <FiltroUfficioRegionale>
      <UFFICIO_PROVINCIALE>Equal</UFFICIO_PROVINCIALE>
      <UFFICIO_REGIONALE>Equal</UFFICIO_REGIONALE>
    </FiltroUfficioRegionale>
  </Filters>
  <externalFields />
  <AddedFkFields />
</CAA_SPORTELLO>
*/
