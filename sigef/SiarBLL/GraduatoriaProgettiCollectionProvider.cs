using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per GraduatoriaProgetti
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IGraduatoriaProgettiProvider
	{
		int Save(GraduatoriaProgetti GraduatoriaProgettiObj);
		int SaveCollection(GraduatoriaProgettiCollection collectionObj);
		int Delete(GraduatoriaProgetti GraduatoriaProgettiObj);
		int DeleteCollection(GraduatoriaProgettiCollection collectionObj);
	}
	/// <summary>
	/// Summary description for GraduatoriaProgetti
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class GraduatoriaProgetti: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdBando;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.DecimalNT _Punteggio;
		private NullTypes.DatetimeNT _DataValutazione;
		private NullTypes.StringNT _Operatore;
		private NullTypes.IntNT _Ordine;
		private NullTypes.DecimalNT _CostoTotale;
		private NullTypes.DecimalNT _ContributoTotale;
		private NullTypes.DecimalNT _ContributoRimanente;
		private NullTypes.StringNT _Finanziabilita;
		private NullTypes.BoolNT _UtilizzaFondiRiserva;
		private NullTypes.DecimalNT _AmmontareFondiRiservaUtilizzato;
		[NonSerialized] private IGraduatoriaProgettiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IGraduatoriaProgettiProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public GraduatoriaProgetti()
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
		/// Corrisponde al campo:ID_PROGETTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProgetto
		{
			get { return _IdProgetto; }
			set {
				if (IdProgetto != value)
				{
					_IdProgetto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PUNTEGGIO
		/// Tipo sul db:DECIMAL(10,6)
		/// Default:((0))
		/// </summary>
		public NullTypes.DecimalNT Punteggio
		{
			get { return _Punteggio; }
			set {
				if (Punteggio != value)
				{
					_Punteggio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_VALUTAZIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataValutazione
		{
			get { return _DataValutazione; }
			set {
				if (DataValutazione != value)
				{
					_DataValutazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT Operatore
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

		/// <summary>
		/// Corrisponde al campo:COSTO_TOTALE
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT CostoTotale
		{
			get { return _CostoTotale; }
			set {
				if (CostoTotale != value)
				{
					_CostoTotale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTRIBUTO_TOTALE
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ContributoTotale
		{
			get { return _ContributoTotale; }
			set {
				if (ContributoTotale != value)
				{
					_ContributoTotale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTRIBUTO_RIMANENTE
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ContributoRimanente
		{
			get { return _ContributoRimanente; }
			set {
				if (ContributoRimanente != value)
				{
					_ContributoRimanente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FINANZIABILITA
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT Finanziabilita
		{
			get { return _Finanziabilita; }
			set {
				if (Finanziabilita != value)
				{
					_Finanziabilita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:UTILIZZA_FONDI_RISERVA
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT UtilizzaFondiRiserva
		{
			get { return _UtilizzaFondiRiserva; }
			set {
				if (UtilizzaFondiRiserva != value)
				{
					_UtilizzaFondiRiserva = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:AMMONTARE_FONDI_RISERVA_UTILIZZATO
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT AmmontareFondiRiservaUtilizzato
		{
			get { return _AmmontareFondiRiservaUtilizzato; }
			set {
				if (AmmontareFondiRiservaUtilizzato != value)
				{
					_AmmontareFondiRiservaUtilizzato = value;
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
	/// Summary description for GraduatoriaProgettiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class GraduatoriaProgettiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private GraduatoriaProgettiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((GraduatoriaProgetti) info.GetValue(i.ToString(),typeof(GraduatoriaProgetti)));
			}
		}

		//Costruttore
		public GraduatoriaProgettiCollection()
		{
			this.ItemType = typeof(GraduatoriaProgetti);
		}

		//Costruttore con provider
		public GraduatoriaProgettiCollection(IGraduatoriaProgettiProvider providerObj)
		{
			this.ItemType = typeof(GraduatoriaProgetti);
			this.Provider = providerObj;
		}

		//Get e Set
		public new GraduatoriaProgetti this[int index]
		{
			get { return (GraduatoriaProgetti)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new GraduatoriaProgettiCollection GetChanges()
		{
			return (GraduatoriaProgettiCollection) base.GetChanges();
		}

		[NonSerialized] private IGraduatoriaProgettiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IGraduatoriaProgettiProvider Provider
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
		public int Add(GraduatoriaProgetti GraduatoriaProgettiObj)
		{
			if (GraduatoriaProgettiObj.Provider == null) GraduatoriaProgettiObj.Provider = this.Provider;
			return base.Add(GraduatoriaProgettiObj);
		}

		//AddCollection
		public void AddCollection(GraduatoriaProgettiCollection GraduatoriaProgettiCollectionObj)
		{
			foreach (GraduatoriaProgetti GraduatoriaProgettiObj in GraduatoriaProgettiCollectionObj)
				this.Add(GraduatoriaProgettiObj);
		}

		//Insert
		public void Insert(int index, GraduatoriaProgetti GraduatoriaProgettiObj)
		{
			if (GraduatoriaProgettiObj.Provider == null) GraduatoriaProgettiObj.Provider = this.Provider;
			base.Insert(index, GraduatoriaProgettiObj);
		}

		//CollectionGetById
		public GraduatoriaProgetti CollectionGetById(NullTypes.IntNT IdBandoValue, NullTypes.IntNT IdProgettoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdBando == IdBandoValue) && (this[i].IdProgetto == IdProgettoValue))
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
		public GraduatoriaProgettiCollection SubSelect(NullTypes.IntNT IdBandoEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.DecimalNT PunteggioEqualThis, 
NullTypes.DatetimeNT DataValutazioneEqualThis, NullTypes.StringNT OperatoreEqualThis, NullTypes.IntNT OrdineEqualThis, 
NullTypes.DecimalNT CostoTotaleEqualThis, NullTypes.DecimalNT ContributoTotaleEqualThis, NullTypes.DecimalNT ContributoRimanenteEqualThis, 
NullTypes.StringNT FinanziabilitaEqualThis, NullTypes.BoolNT UtilizzaFondiRiservaEqualThis, NullTypes.DecimalNT AmmontareFondiRiservaUtilizzatoEqualThis)
		{
			GraduatoriaProgettiCollection GraduatoriaProgettiCollectionTemp = new GraduatoriaProgettiCollection();
			foreach (GraduatoriaProgetti GraduatoriaProgettiItem in this)
			{
				if (((IdBandoEqualThis == null) || ((GraduatoriaProgettiItem.IdBando != null) && (GraduatoriaProgettiItem.IdBando.Value == IdBandoEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((GraduatoriaProgettiItem.IdProgetto != null) && (GraduatoriaProgettiItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((PunteggioEqualThis == null) || ((GraduatoriaProgettiItem.Punteggio != null) && (GraduatoriaProgettiItem.Punteggio.Value == PunteggioEqualThis.Value))) && 
((DataValutazioneEqualThis == null) || ((GraduatoriaProgettiItem.DataValutazione != null) && (GraduatoriaProgettiItem.DataValutazione.Value == DataValutazioneEqualThis.Value))) && ((OperatoreEqualThis == null) || ((GraduatoriaProgettiItem.Operatore != null) && (GraduatoriaProgettiItem.Operatore.Value == OperatoreEqualThis.Value))) && ((OrdineEqualThis == null) || ((GraduatoriaProgettiItem.Ordine != null) && (GraduatoriaProgettiItem.Ordine.Value == OrdineEqualThis.Value))) && 
((CostoTotaleEqualThis == null) || ((GraduatoriaProgettiItem.CostoTotale != null) && (GraduatoriaProgettiItem.CostoTotale.Value == CostoTotaleEqualThis.Value))) && ((ContributoTotaleEqualThis == null) || ((GraduatoriaProgettiItem.ContributoTotale != null) && (GraduatoriaProgettiItem.ContributoTotale.Value == ContributoTotaleEqualThis.Value))) && ((ContributoRimanenteEqualThis == null) || ((GraduatoriaProgettiItem.ContributoRimanente != null) && (GraduatoriaProgettiItem.ContributoRimanente.Value == ContributoRimanenteEqualThis.Value))) && 
((FinanziabilitaEqualThis == null) || ((GraduatoriaProgettiItem.Finanziabilita != null) && (GraduatoriaProgettiItem.Finanziabilita.Value == FinanziabilitaEqualThis.Value))) && ((UtilizzaFondiRiservaEqualThis == null) || ((GraduatoriaProgettiItem.UtilizzaFondiRiserva != null) && (GraduatoriaProgettiItem.UtilizzaFondiRiserva.Value == UtilizzaFondiRiservaEqualThis.Value))) && ((AmmontareFondiRiservaUtilizzatoEqualThis == null) || ((GraduatoriaProgettiItem.AmmontareFondiRiservaUtilizzato != null) && (GraduatoriaProgettiItem.AmmontareFondiRiservaUtilizzato.Value == AmmontareFondiRiservaUtilizzatoEqualThis.Value))))
				{
					GraduatoriaProgettiCollectionTemp.Add(GraduatoriaProgettiItem);
				}
			}
			return GraduatoriaProgettiCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for GraduatoriaProgettiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class GraduatoriaProgettiDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, GraduatoriaProgetti GraduatoriaProgettiObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", GraduatoriaProgettiObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", GraduatoriaProgettiObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "Punteggio", GraduatoriaProgettiObj.Punteggio);
			DbProvider.SetCmdParam(cmd,firstChar + "DataValutazione", GraduatoriaProgettiObj.DataValutazione);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", GraduatoriaProgettiObj.Operatore);
			DbProvider.SetCmdParam(cmd,firstChar + "Ordine", GraduatoriaProgettiObj.Ordine);
			DbProvider.SetCmdParam(cmd,firstChar + "CostoTotale", GraduatoriaProgettiObj.CostoTotale);
			DbProvider.SetCmdParam(cmd,firstChar + "ContributoTotale", GraduatoriaProgettiObj.ContributoTotale);
			DbProvider.SetCmdParam(cmd,firstChar + "ContributoRimanente", GraduatoriaProgettiObj.ContributoRimanente);
			DbProvider.SetCmdParam(cmd,firstChar + "Finanziabilita", GraduatoriaProgettiObj.Finanziabilita);
			DbProvider.SetCmdParam(cmd,firstChar + "UtilizzaFondiRiserva", GraduatoriaProgettiObj.UtilizzaFondiRiserva);
			DbProvider.SetCmdParam(cmd,firstChar + "AmmontareFondiRiservaUtilizzato", GraduatoriaProgettiObj.AmmontareFondiRiservaUtilizzato);
		}
		//Insert
		private static int Insert(DbProvider db, GraduatoriaProgetti GraduatoriaProgettiObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZGraduatoriaProgettiInsert", new string[] {"IdBando", "IdProgetto", "Punteggio", 
"DataValutazione", "Operatore", "Ordine", 
"CostoTotale", "ContributoTotale", "ContributoRimanente", 
"Finanziabilita", "UtilizzaFondiRiserva", "AmmontareFondiRiservaUtilizzato"}, new string[] {"int", "int", "decimal", 
"DateTime", "string", "int", 
"decimal", "decimal", "decimal", 
"string", "bool", "decimal"},"");
				CompileIUCmd(false, insertCmd,GraduatoriaProgettiObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				GraduatoriaProgettiObj.Punteggio = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PUNTEGGIO"]);
				GraduatoriaProgettiObj.UtilizzaFondiRiserva = new SiarLibrary.NullTypes.BoolNT(db.DataReader["UTILIZZA_FONDI_RISERVA"]);
				}
				GraduatoriaProgettiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				GraduatoriaProgettiObj.IsDirty = false;
				GraduatoriaProgettiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, GraduatoriaProgetti GraduatoriaProgettiObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZGraduatoriaProgettiUpdate", new string[] {"IdBando", "IdProgetto", "Punteggio", 
"DataValutazione", "Operatore", "Ordine", 
"CostoTotale", "ContributoTotale", "ContributoRimanente", 
"Finanziabilita", "UtilizzaFondiRiserva", "AmmontareFondiRiservaUtilizzato"}, new string[] {"int", "int", "decimal", 
"DateTime", "string", "int", 
"decimal", "decimal", "decimal", 
"string", "bool", "decimal"},"");
				CompileIUCmd(true, updateCmd,GraduatoriaProgettiObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				GraduatoriaProgettiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				GraduatoriaProgettiObj.IsDirty = false;
				GraduatoriaProgettiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, GraduatoriaProgetti GraduatoriaProgettiObj)
		{
			switch (GraduatoriaProgettiObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, GraduatoriaProgettiObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, GraduatoriaProgettiObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,GraduatoriaProgettiObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, GraduatoriaProgettiCollection GraduatoriaProgettiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZGraduatoriaProgettiUpdate", new string[] {"IdBando", "IdProgetto", "Punteggio", 
"DataValutazione", "Operatore", "Ordine", 
"CostoTotale", "ContributoTotale", "ContributoRimanente", 
"Finanziabilita", "UtilizzaFondiRiserva", "AmmontareFondiRiservaUtilizzato"}, new string[] {"int", "int", "decimal", 
"DateTime", "string", "int", 
"decimal", "decimal", "decimal", 
"string", "bool", "decimal"},"");
				IDbCommand insertCmd = db.InitCmd( "ZGraduatoriaProgettiInsert", new string[] {"IdBando", "IdProgetto", "Punteggio", 
"DataValutazione", "Operatore", "Ordine", 
"CostoTotale", "ContributoTotale", "ContributoRimanente", 
"Finanziabilita", "UtilizzaFondiRiserva", "AmmontareFondiRiservaUtilizzato"}, new string[] {"int", "int", "decimal", 
"DateTime", "string", "int", 
"decimal", "decimal", "decimal", 
"string", "bool", "decimal"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZGraduatoriaProgettiDelete", new string[] {"IdBando", "IdProgetto"}, new string[] {"int", "int"},"");
				for (int i = 0; i < GraduatoriaProgettiCollectionObj.Count; i++)
				{
					switch (GraduatoriaProgettiCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,GraduatoriaProgettiCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									GraduatoriaProgettiCollectionObj[i].Punteggio = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PUNTEGGIO"]);
									GraduatoriaProgettiCollectionObj[i].UtilizzaFondiRiserva = new SiarLibrary.NullTypes.BoolNT(db.DataReader["UTILIZZA_FONDI_RISERVA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,GraduatoriaProgettiCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (GraduatoriaProgettiCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBando", (SiarLibrary.NullTypes.IntNT)GraduatoriaProgettiCollectionObj[i].IdBando);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProgetto", (SiarLibrary.NullTypes.IntNT)GraduatoriaProgettiCollectionObj[i].IdProgetto);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < GraduatoriaProgettiCollectionObj.Count; i++)
				{
					if ((GraduatoriaProgettiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (GraduatoriaProgettiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						GraduatoriaProgettiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						GraduatoriaProgettiCollectionObj[i].IsDirty = false;
						GraduatoriaProgettiCollectionObj[i].IsPersistent = true;
					}
					if ((GraduatoriaProgettiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						GraduatoriaProgettiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						GraduatoriaProgettiCollectionObj[i].IsDirty = false;
						GraduatoriaProgettiCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, GraduatoriaProgetti GraduatoriaProgettiObj)
		{
			int returnValue = 0;
			if (GraduatoriaProgettiObj.IsPersistent) 
			{
				returnValue = Delete(db, GraduatoriaProgettiObj.IdBando, GraduatoriaProgettiObj.IdProgetto);
			}
			GraduatoriaProgettiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			GraduatoriaProgettiObj.IsDirty = false;
			GraduatoriaProgettiObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdBandoValue, int IdProgettoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZGraduatoriaProgettiDelete", new string[] {"IdBando", "IdProgetto"}, new string[] {"int", "int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBando", (SiarLibrary.NullTypes.IntNT)IdBandoValue);
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProgetto", (SiarLibrary.NullTypes.IntNT)IdProgettoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, GraduatoriaProgettiCollection GraduatoriaProgettiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZGraduatoriaProgettiDelete", new string[] {"IdBando", "IdProgetto"}, new string[] {"int", "int"},"");
				for (int i = 0; i < GraduatoriaProgettiCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBando", GraduatoriaProgettiCollectionObj[i].IdBando);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProgetto", GraduatoriaProgettiCollectionObj[i].IdProgetto);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < GraduatoriaProgettiCollectionObj.Count; i++)
				{
					if ((GraduatoriaProgettiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (GraduatoriaProgettiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						GraduatoriaProgettiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						GraduatoriaProgettiCollectionObj[i].IsDirty = false;
						GraduatoriaProgettiCollectionObj[i].IsPersistent = false;
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
		public static GraduatoriaProgetti GetById(DbProvider db, int IdBandoValue, int IdProgettoValue)
		{
			GraduatoriaProgetti GraduatoriaProgettiObj = null;
			IDbCommand readCmd = db.InitCmd( "ZGraduatoriaProgettiGetById", new string[] {"IdBando", "IdProgetto"}, new string[] {"int", "int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdBando", (SiarLibrary.NullTypes.IntNT)IdBandoValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdProgetto", (SiarLibrary.NullTypes.IntNT)IdProgettoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				GraduatoriaProgettiObj = GetFromDatareader(db);
				GraduatoriaProgettiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				GraduatoriaProgettiObj.IsDirty = false;
				GraduatoriaProgettiObj.IsPersistent = true;
			}
			db.Close();
			return GraduatoriaProgettiObj;
		}

		//getFromDatareader
		public static GraduatoriaProgetti GetFromDatareader(DbProvider db)
		{
			GraduatoriaProgetti GraduatoriaProgettiObj = new GraduatoriaProgetti();
			GraduatoriaProgettiObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			GraduatoriaProgettiObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			GraduatoriaProgettiObj.Punteggio = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PUNTEGGIO"]);
			GraduatoriaProgettiObj.DataValutazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_VALUTAZIONE"]);
			GraduatoriaProgettiObj.Operatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE"]);
			GraduatoriaProgettiObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
			GraduatoriaProgettiObj.CostoTotale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["COSTO_TOTALE"]);
			GraduatoriaProgettiObj.ContributoTotale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_TOTALE"]);
			GraduatoriaProgettiObj.ContributoRimanente = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_RIMANENTE"]);
			GraduatoriaProgettiObj.Finanziabilita = new SiarLibrary.NullTypes.StringNT(db.DataReader["FINANZIABILITA"]);
			GraduatoriaProgettiObj.UtilizzaFondiRiserva = new SiarLibrary.NullTypes.BoolNT(db.DataReader["UTILIZZA_FONDI_RISERVA"]);
			GraduatoriaProgettiObj.AmmontareFondiRiservaUtilizzato = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["AMMONTARE_FONDI_RISERVA_UTILIZZATO"]);
			GraduatoriaProgettiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			GraduatoriaProgettiObj.IsDirty = false;
			GraduatoriaProgettiObj.IsPersistent = true;
			return GraduatoriaProgettiObj;
		}

		//Find Select

		public static GraduatoriaProgettiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.DecimalNT PunteggioEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataValutazioneEqualThis, SiarLibrary.NullTypes.StringNT OperatoreEqualThis, SiarLibrary.NullTypes.IntNT OrdineEqualThis, 
SiarLibrary.NullTypes.DecimalNT CostoTotaleEqualThis, SiarLibrary.NullTypes.DecimalNT ContributoTotaleEqualThis, SiarLibrary.NullTypes.DecimalNT ContributoRimanenteEqualThis, 
SiarLibrary.NullTypes.StringNT FinanziabilitaEqualThis, SiarLibrary.NullTypes.BoolNT UtilizzaFondiRiservaEqualThis, SiarLibrary.NullTypes.DecimalNT AmmontareFondiRiservaUtilizzatoEqualThis)

		{

			GraduatoriaProgettiCollection GraduatoriaProgettiCollectionObj = new GraduatoriaProgettiCollection();

			IDbCommand findCmd = db.InitCmd("Zgraduatoriaprogettifindselect", new string[] {"IdBandoequalthis", "IdProgettoequalthis", "Punteggioequalthis", 
"DataValutazioneequalthis", "Operatoreequalthis", "Ordineequalthis", 
"CostoTotaleequalthis", "ContributoTotaleequalthis", "ContributoRimanenteequalthis", 
"Finanziabilitaequalthis", "UtilizzaFondiRiservaequalthis", "AmmontareFondiRiservaUtilizzatoequalthis"}, new string[] {"int", "int", "decimal", 
"DateTime", "string", "int", 
"decimal", "decimal", "decimal", 
"string", "bool", "decimal"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Punteggioequalthis", PunteggioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataValutazioneequalthis", DataValutazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CostoTotaleequalthis", CostoTotaleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ContributoTotaleequalthis", ContributoTotaleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ContributoRimanenteequalthis", ContributoRimanenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Finanziabilitaequalthis", FinanziabilitaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "UtilizzaFondiRiservaequalthis", UtilizzaFondiRiservaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AmmontareFondiRiservaUtilizzatoequalthis", AmmontareFondiRiservaUtilizzatoEqualThis);
			GraduatoriaProgetti GraduatoriaProgettiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				GraduatoriaProgettiObj = GetFromDatareader(db);
				GraduatoriaProgettiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				GraduatoriaProgettiObj.IsDirty = false;
				GraduatoriaProgettiObj.IsPersistent = true;
				GraduatoriaProgettiCollectionObj.Add(GraduatoriaProgettiObj);
			}
			db.Close();
			return GraduatoriaProgettiCollectionObj;
		}

		//Find Find

		public static GraduatoriaProgettiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.StringNT FinanziabilitaEqualThis)

		{

			GraduatoriaProgettiCollection GraduatoriaProgettiCollectionObj = new GraduatoriaProgettiCollection();

			IDbCommand findCmd = db.InitCmd("Zgraduatoriaprogettifindfind", new string[] {"IdBandoequalthis", "IdProgettoequalthis", "Finanziabilitaequalthis"}, new string[] {"int", "int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Finanziabilitaequalthis", FinanziabilitaEqualThis);
			GraduatoriaProgetti GraduatoriaProgettiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				GraduatoriaProgettiObj = GetFromDatareader(db);
				GraduatoriaProgettiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				GraduatoriaProgettiObj.IsDirty = false;
				GraduatoriaProgettiObj.IsPersistent = true;
				GraduatoriaProgettiCollectionObj.Add(GraduatoriaProgettiObj);
			}
			db.Close();
			return GraduatoriaProgettiCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for GraduatoriaProgettiCollectionProvider:IGraduatoriaProgettiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class GraduatoriaProgettiCollectionProvider : IGraduatoriaProgettiProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di GraduatoriaProgetti
		protected GraduatoriaProgettiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public GraduatoriaProgettiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new GraduatoriaProgettiCollection(this);
		}

		//Costruttore 2: popola la collection
		public GraduatoriaProgettiCollectionProvider(IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis, StringNT FinanziabilitaEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdbandoEqualThis, IdprogettoEqualThis, FinanziabilitaEqualThis);
		}

		//Costruttore3: ha in input graduatoriaprogettiCollectionObj - non popola la collection
		public GraduatoriaProgettiCollectionProvider(GraduatoriaProgettiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public GraduatoriaProgettiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new GraduatoriaProgettiCollection(this);
		}

		//Get e Set
		public GraduatoriaProgettiCollection CollectionObj
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
		public int SaveCollection(GraduatoriaProgettiCollection collectionObj)
		{
			return GraduatoriaProgettiDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(GraduatoriaProgetti graduatoriaprogettiObj)
		{
			return GraduatoriaProgettiDAL.Save(_dbProviderObj, graduatoriaprogettiObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(GraduatoriaProgettiCollection collectionObj)
		{
			return GraduatoriaProgettiDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(GraduatoriaProgetti graduatoriaprogettiObj)
		{
			return GraduatoriaProgettiDAL.Delete(_dbProviderObj, graduatoriaprogettiObj);
		}

		//getById
		public GraduatoriaProgetti GetById(IntNT IdBandoValue, IntNT IdProgettoValue)
		{
			GraduatoriaProgetti GraduatoriaProgettiTemp = GraduatoriaProgettiDAL.GetById(_dbProviderObj, IdBandoValue, IdProgettoValue);
			if (GraduatoriaProgettiTemp!=null) GraduatoriaProgettiTemp.Provider = this;
			return GraduatoriaProgettiTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public GraduatoriaProgettiCollection Select(IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis, DecimalNT PunteggioEqualThis, 
DatetimeNT DatavalutazioneEqualThis, StringNT OperatoreEqualThis, IntNT OrdineEqualThis, 
DecimalNT CostototaleEqualThis, DecimalNT ContributototaleEqualThis, DecimalNT ContributorimanenteEqualThis, 
StringNT FinanziabilitaEqualThis, BoolNT UtilizzafondiriservaEqualThis, DecimalNT AmmontarefondiriservautilizzatoEqualThis)
		{
			GraduatoriaProgettiCollection GraduatoriaProgettiCollectionTemp = GraduatoriaProgettiDAL.Select(_dbProviderObj, IdbandoEqualThis, IdprogettoEqualThis, PunteggioEqualThis, 
DatavalutazioneEqualThis, OperatoreEqualThis, OrdineEqualThis, 
CostototaleEqualThis, ContributototaleEqualThis, ContributorimanenteEqualThis, 
FinanziabilitaEqualThis, UtilizzafondiriservaEqualThis, AmmontarefondiriservautilizzatoEqualThis);
			GraduatoriaProgettiCollectionTemp.Provider = this;
			return GraduatoriaProgettiCollectionTemp;
		}

		//Find: popola la collection
		public GraduatoriaProgettiCollection Find(IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis, StringNT FinanziabilitaEqualThis)
		{
			GraduatoriaProgettiCollection GraduatoriaProgettiCollectionTemp = GraduatoriaProgettiDAL.Find(_dbProviderObj, IdbandoEqualThis, IdprogettoEqualThis, FinanziabilitaEqualThis);
			GraduatoriaProgettiCollectionTemp.Provider = this;
			return GraduatoriaProgettiCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<GRADUATORIA_PROGETTI>
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
  <Finds>
    <Find OrderBy="ORDER BY ORDINE, PUNTEGGIO DESC">
      <ID_BANDO>Equal</ID_BANDO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <FINANZIABILITA>Equal</FINANZIABILITA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</GRADUATORIA_PROGETTI>
*/
