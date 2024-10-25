using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per GraduatoriaProgettiDettaglio
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IGraduatoriaProgettiDettaglioProvider
	{
		int Save(GraduatoriaProgettiDettaglio GraduatoriaProgettiDettaglioObj);
		int SaveCollection(GraduatoriaProgettiDettaglioCollection collectionObj);
		int Delete(GraduatoriaProgettiDettaglio GraduatoriaProgettiDettaglioObj);
		int DeleteCollection(GraduatoriaProgettiDettaglioCollection collectionObj);
	}
	/// <summary>
	/// Summary description for GraduatoriaProgettiDettaglio
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class GraduatoriaProgettiDettaglio: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdPriorita;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.DecimalNT _Punteggio;
		private NullTypes.DatetimeNT _DataValutazione;
		private NullTypes.StringNT _Operatore;
		private NullTypes.BoolNT _ModificaManuale;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.StringNT _CodLivello;
		private NullTypes.BoolNT _PluriValore;
		private NullTypes.StringNT _Eval;
		private NullTypes.BoolNT _FlagManuale;
		private NullTypes.BoolNT _InputNumerico;
		private NullTypes.StringNT _Misura;
		[NonSerialized] private IGraduatoriaProgettiDettaglioProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IGraduatoriaProgettiDettaglioProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public GraduatoriaProgettiDettaglio()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_PRIORITA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdPriorita
		{
			get { return _IdPriorita; }
			set {
				if (IdPriorita != value)
				{
					_IdPriorita = value;
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
		/// Corrisponde al campo:MODIFICA_MANUALE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT ModificaManuale
		{
			get { return _ModificaManuale; }
			set {
				if (ModificaManuale != value)
				{
					_ModificaManuale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(1000)
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
		/// Corrisponde al campo:COD_LIVELLO
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT CodLivello
		{
			get { return _CodLivello; }
			set {
				if (CodLivello != value)
				{
					_CodLivello = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PLURI_VALORE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT PluriValore
		{
			get { return _PluriValore; }
			set {
				if (PluriValore != value)
				{
					_PluriValore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:EVAL
		/// Tipo sul db:VARCHAR(3000)
		/// </summary>
		public NullTypes.StringNT Eval
		{
			get { return _Eval; }
			set {
				if (Eval != value)
				{
					_Eval = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FLAG_MANUALE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT FlagManuale
		{
			get { return _FlagManuale; }
			set {
				if (FlagManuale != value)
				{
					_FlagManuale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:INPUT_NUMERICO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT InputNumerico
		{
			get { return _InputNumerico; }
			set {
				if (InputNumerico != value)
				{
					_InputNumerico = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MISURA
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT Misura
		{
			get { return _Misura; }
			set {
				if (Misura != value)
				{
					_Misura = value;
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
	/// Summary description for GraduatoriaProgettiDettaglioCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class GraduatoriaProgettiDettaglioCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private GraduatoriaProgettiDettaglioCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((GraduatoriaProgettiDettaglio) info.GetValue(i.ToString(),typeof(GraduatoriaProgettiDettaglio)));
			}
		}

		//Costruttore
		public GraduatoriaProgettiDettaglioCollection()
		{
			this.ItemType = typeof(GraduatoriaProgettiDettaglio);
		}

		//Costruttore con provider
		public GraduatoriaProgettiDettaglioCollection(IGraduatoriaProgettiDettaglioProvider providerObj)
		{
			this.ItemType = typeof(GraduatoriaProgettiDettaglio);
			this.Provider = providerObj;
		}

		//Get e Set
		public new GraduatoriaProgettiDettaglio this[int index]
		{
			get { return (GraduatoriaProgettiDettaglio)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new GraduatoriaProgettiDettaglioCollection GetChanges()
		{
			return (GraduatoriaProgettiDettaglioCollection) base.GetChanges();
		}

		[NonSerialized] private IGraduatoriaProgettiDettaglioProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IGraduatoriaProgettiDettaglioProvider Provider
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
		public int Add(GraduatoriaProgettiDettaglio GraduatoriaProgettiDettaglioObj)
		{
			if (GraduatoriaProgettiDettaglioObj.Provider == null) GraduatoriaProgettiDettaglioObj.Provider = this.Provider;
			return base.Add(GraduatoriaProgettiDettaglioObj);
		}

		//AddCollection
		public void AddCollection(GraduatoriaProgettiDettaglioCollection GraduatoriaProgettiDettaglioCollectionObj)
		{
			foreach (GraduatoriaProgettiDettaglio GraduatoriaProgettiDettaglioObj in GraduatoriaProgettiDettaglioCollectionObj)
				this.Add(GraduatoriaProgettiDettaglioObj);
		}

		//Insert
		public void Insert(int index, GraduatoriaProgettiDettaglio GraduatoriaProgettiDettaglioObj)
		{
			if (GraduatoriaProgettiDettaglioObj.Provider == null) GraduatoriaProgettiDettaglioObj.Provider = this.Provider;
			base.Insert(index, GraduatoriaProgettiDettaglioObj);
		}

		//CollectionGetById
		public GraduatoriaProgettiDettaglio CollectionGetById(NullTypes.IntNT IdPrioritaValue, NullTypes.IntNT IdProgettoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdPriorita == IdPrioritaValue) && (this[i].IdProgetto == IdProgettoValue))
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
		public GraduatoriaProgettiDettaglioCollection SubSelect(NullTypes.IntNT IdPrioritaEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.DecimalNT PunteggioEqualThis, 
NullTypes.DatetimeNT DataValutazioneEqualThis, NullTypes.StringNT OperatoreEqualThis, NullTypes.BoolNT ModificaManualeEqualThis)
		{
			GraduatoriaProgettiDettaglioCollection GraduatoriaProgettiDettaglioCollectionTemp = new GraduatoriaProgettiDettaglioCollection();
			foreach (GraduatoriaProgettiDettaglio GraduatoriaProgettiDettaglioItem in this)
			{
				if (((IdPrioritaEqualThis == null) || ((GraduatoriaProgettiDettaglioItem.IdPriorita != null) && (GraduatoriaProgettiDettaglioItem.IdPriorita.Value == IdPrioritaEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((GraduatoriaProgettiDettaglioItem.IdProgetto != null) && (GraduatoriaProgettiDettaglioItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((PunteggioEqualThis == null) || ((GraduatoriaProgettiDettaglioItem.Punteggio != null) && (GraduatoriaProgettiDettaglioItem.Punteggio.Value == PunteggioEqualThis.Value))) && 
((DataValutazioneEqualThis == null) || ((GraduatoriaProgettiDettaglioItem.DataValutazione != null) && (GraduatoriaProgettiDettaglioItem.DataValutazione.Value == DataValutazioneEqualThis.Value))) && ((OperatoreEqualThis == null) || ((GraduatoriaProgettiDettaglioItem.Operatore != null) && (GraduatoriaProgettiDettaglioItem.Operatore.Value == OperatoreEqualThis.Value))) && ((ModificaManualeEqualThis == null) || ((GraduatoriaProgettiDettaglioItem.ModificaManuale != null) && (GraduatoriaProgettiDettaglioItem.ModificaManuale.Value == ModificaManualeEqualThis.Value))))
				{
					GraduatoriaProgettiDettaglioCollectionTemp.Add(GraduatoriaProgettiDettaglioItem);
				}
			}
			return GraduatoriaProgettiDettaglioCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public GraduatoriaProgettiDettaglioCollection FiltroTipo(NullTypes.BoolNT FlagManualeEqualThis, NullTypes.BoolNT PluriValoreEqualThis, NullTypes.BoolNT InputNumericoEqualThis)
		{
			GraduatoriaProgettiDettaglioCollection GraduatoriaProgettiDettaglioCollectionTemp = new GraduatoriaProgettiDettaglioCollection();
			foreach (GraduatoriaProgettiDettaglio GraduatoriaProgettiDettaglioItem in this)
			{
				if (((FlagManualeEqualThis == null) || ((GraduatoriaProgettiDettaglioItem.FlagManuale != null) && (GraduatoriaProgettiDettaglioItem.FlagManuale.Value == FlagManualeEqualThis.Value))) && ((PluriValoreEqualThis == null) || ((GraduatoriaProgettiDettaglioItem.PluriValore != null) && (GraduatoriaProgettiDettaglioItem.PluriValore.Value == PluriValoreEqualThis.Value))) && ((InputNumericoEqualThis == null) || ((GraduatoriaProgettiDettaglioItem.InputNumerico != null) && (GraduatoriaProgettiDettaglioItem.InputNumerico.Value == InputNumericoEqualThis.Value))))
				{
					GraduatoriaProgettiDettaglioCollectionTemp.Add(GraduatoriaProgettiDettaglioItem);
				}
			}
			return GraduatoriaProgettiDettaglioCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public GraduatoriaProgettiDettaglioCollection FiltroMisura(NullTypes.StringNT MisuraLike)
		{
			GraduatoriaProgettiDettaglioCollection GraduatoriaProgettiDettaglioCollectionTemp = new GraduatoriaProgettiDettaglioCollection();
			foreach (GraduatoriaProgettiDettaglio GraduatoriaProgettiDettaglioItem in this)
			{
				if (((MisuraLike == null) || ((GraduatoriaProgettiDettaglioItem.Misura !=null) &&(GraduatoriaProgettiDettaglioItem.Misura.Like(MisuraLike.Value)))))
				{
					GraduatoriaProgettiDettaglioCollectionTemp.Add(GraduatoriaProgettiDettaglioItem);
				}
			}
			return GraduatoriaProgettiDettaglioCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for GraduatoriaProgettiDettaglioDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class GraduatoriaProgettiDettaglioDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, GraduatoriaProgettiDettaglio GraduatoriaProgettiDettaglioObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdPriorita", GraduatoriaProgettiDettaglioObj.IdPriorita);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", GraduatoriaProgettiDettaglioObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "Punteggio", GraduatoriaProgettiDettaglioObj.Punteggio);
			DbProvider.SetCmdParam(cmd,firstChar + "DataValutazione", GraduatoriaProgettiDettaglioObj.DataValutazione);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", GraduatoriaProgettiDettaglioObj.Operatore);
			DbProvider.SetCmdParam(cmd,firstChar + "ModificaManuale", GraduatoriaProgettiDettaglioObj.ModificaManuale);
		}
		//Insert
		private static int Insert(DbProvider db, GraduatoriaProgettiDettaglio GraduatoriaProgettiDettaglioObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZGraduatoriaProgettiDettaglioInsert", new string[] {"IdPriorita", "IdProgetto", "Punteggio", 
"DataValutazione", "Operatore", "ModificaManuale", 

}, new string[] {"int", "int", "decimal", 
"DateTime", "string", "bool", 

},"");
				CompileIUCmd(false, insertCmd,GraduatoriaProgettiDettaglioObj, db.CommandFirstChar);
				i = db.Execute(insertCmd);
				GraduatoriaProgettiDettaglioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				GraduatoriaProgettiDettaglioObj.IsDirty = false;
				GraduatoriaProgettiDettaglioObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, GraduatoriaProgettiDettaglio GraduatoriaProgettiDettaglioObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZGraduatoriaProgettiDettaglioUpdate", new string[] {"IdPriorita", "IdProgetto", "Punteggio", 
"DataValutazione", "Operatore", "ModificaManuale", 

}, new string[] {"int", "int", "decimal", 
"DateTime", "string", "bool", 

},"");
				CompileIUCmd(true, updateCmd,GraduatoriaProgettiDettaglioObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				GraduatoriaProgettiDettaglioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				GraduatoriaProgettiDettaglioObj.IsDirty = false;
				GraduatoriaProgettiDettaglioObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, GraduatoriaProgettiDettaglio GraduatoriaProgettiDettaglioObj)
		{
			switch (GraduatoriaProgettiDettaglioObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, GraduatoriaProgettiDettaglioObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, GraduatoriaProgettiDettaglioObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,GraduatoriaProgettiDettaglioObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, GraduatoriaProgettiDettaglioCollection GraduatoriaProgettiDettaglioCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZGraduatoriaProgettiDettaglioUpdate", new string[] {"IdPriorita", "IdProgetto", "Punteggio", 
"DataValutazione", "Operatore", "ModificaManuale", 

}, new string[] {"int", "int", "decimal", 
"DateTime", "string", "bool", 

},"");
				IDbCommand insertCmd = db.InitCmd( "ZGraduatoriaProgettiDettaglioInsert", new string[] {"IdPriorita", "IdProgetto", "Punteggio", 
"DataValutazione", "Operatore", "ModificaManuale", 

}, new string[] {"int", "int", "decimal", 
"DateTime", "string", "bool", 

},"");
				IDbCommand deleteCmd = db.InitCmd( "ZGraduatoriaProgettiDettaglioDelete", new string[] {"IdPriorita", "IdProgetto"}, new string[] {"int", "int"},"");
				for (int i = 0; i < GraduatoriaProgettiDettaglioCollectionObj.Count; i++)
				{
					switch (GraduatoriaProgettiDettaglioCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,GraduatoriaProgettiDettaglioCollectionObj[i], db.CommandFirstChar);
								returnValue += db.Execute(insertCmd);
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,GraduatoriaProgettiDettaglioCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (GraduatoriaProgettiDettaglioCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPriorita", (SiarLibrary.NullTypes.IntNT)GraduatoriaProgettiDettaglioCollectionObj[i].IdPriorita);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProgetto", (SiarLibrary.NullTypes.IntNT)GraduatoriaProgettiDettaglioCollectionObj[i].IdProgetto);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < GraduatoriaProgettiDettaglioCollectionObj.Count; i++)
				{
					if ((GraduatoriaProgettiDettaglioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (GraduatoriaProgettiDettaglioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						GraduatoriaProgettiDettaglioCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						GraduatoriaProgettiDettaglioCollectionObj[i].IsDirty = false;
						GraduatoriaProgettiDettaglioCollectionObj[i].IsPersistent = true;
					}
					if ((GraduatoriaProgettiDettaglioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						GraduatoriaProgettiDettaglioCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						GraduatoriaProgettiDettaglioCollectionObj[i].IsDirty = false;
						GraduatoriaProgettiDettaglioCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, GraduatoriaProgettiDettaglio GraduatoriaProgettiDettaglioObj)
		{
			int returnValue = 0;
			if (GraduatoriaProgettiDettaglioObj.IsPersistent) 
			{
				returnValue = Delete(db, GraduatoriaProgettiDettaglioObj.IdPriorita, GraduatoriaProgettiDettaglioObj.IdProgetto);
			}
			GraduatoriaProgettiDettaglioObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			GraduatoriaProgettiDettaglioObj.IsDirty = false;
			GraduatoriaProgettiDettaglioObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdPrioritaValue, int IdProgettoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZGraduatoriaProgettiDettaglioDelete", new string[] {"IdPriorita", "IdProgetto"}, new string[] {"int", "int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPriorita", (SiarLibrary.NullTypes.IntNT)IdPrioritaValue);
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProgetto", (SiarLibrary.NullTypes.IntNT)IdProgettoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, GraduatoriaProgettiDettaglioCollection GraduatoriaProgettiDettaglioCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZGraduatoriaProgettiDettaglioDelete", new string[] {"IdPriorita", "IdProgetto"}, new string[] {"int", "int"},"");
				for (int i = 0; i < GraduatoriaProgettiDettaglioCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPriorita", GraduatoriaProgettiDettaglioCollectionObj[i].IdPriorita);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProgetto", GraduatoriaProgettiDettaglioCollectionObj[i].IdProgetto);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < GraduatoriaProgettiDettaglioCollectionObj.Count; i++)
				{
					if ((GraduatoriaProgettiDettaglioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (GraduatoriaProgettiDettaglioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						GraduatoriaProgettiDettaglioCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						GraduatoriaProgettiDettaglioCollectionObj[i].IsDirty = false;
						GraduatoriaProgettiDettaglioCollectionObj[i].IsPersistent = false;
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
		public static GraduatoriaProgettiDettaglio GetById(DbProvider db, int IdPrioritaValue, int IdProgettoValue)
		{
			GraduatoriaProgettiDettaglio GraduatoriaProgettiDettaglioObj = null;
			IDbCommand readCmd = db.InitCmd( "ZGraduatoriaProgettiDettaglioGetById", new string[] {"IdPriorita", "IdProgetto"}, new string[] {"int", "int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdPriorita", (SiarLibrary.NullTypes.IntNT)IdPrioritaValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdProgetto", (SiarLibrary.NullTypes.IntNT)IdProgettoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				GraduatoriaProgettiDettaglioObj = GetFromDatareader(db);
				GraduatoriaProgettiDettaglioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				GraduatoriaProgettiDettaglioObj.IsDirty = false;
				GraduatoriaProgettiDettaglioObj.IsPersistent = true;
			}
			db.Close();
			return GraduatoriaProgettiDettaglioObj;
		}

		//getFromDatareader
		public static GraduatoriaProgettiDettaglio GetFromDatareader(DbProvider db)
		{
			GraduatoriaProgettiDettaglio GraduatoriaProgettiDettaglioObj = new GraduatoriaProgettiDettaglio();
			GraduatoriaProgettiDettaglioObj.IdPriorita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PRIORITA"]);
			GraduatoriaProgettiDettaglioObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			GraduatoriaProgettiDettaglioObj.Punteggio = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PUNTEGGIO"]);
			GraduatoriaProgettiDettaglioObj.DataValutazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_VALUTAZIONE"]);
			GraduatoriaProgettiDettaglioObj.Operatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE"]);
			GraduatoriaProgettiDettaglioObj.ModificaManuale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["MODIFICA_MANUALE"]);
			GraduatoriaProgettiDettaglioObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			GraduatoriaProgettiDettaglioObj.CodLivello = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_LIVELLO"]);
			GraduatoriaProgettiDettaglioObj.PluriValore = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PLURI_VALORE"]);
			GraduatoriaProgettiDettaglioObj.Eval = new SiarLibrary.NullTypes.StringNT(db.DataReader["EVAL"]);
			GraduatoriaProgettiDettaglioObj.FlagManuale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_MANUALE"]);
			GraduatoriaProgettiDettaglioObj.InputNumerico = new SiarLibrary.NullTypes.BoolNT(db.DataReader["INPUT_NUMERICO"]);
			GraduatoriaProgettiDettaglioObj.Misura = new SiarLibrary.NullTypes.StringNT(db.DataReader["MISURA"]);
			GraduatoriaProgettiDettaglioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			GraduatoriaProgettiDettaglioObj.IsDirty = false;
			GraduatoriaProgettiDettaglioObj.IsPersistent = true;
			return GraduatoriaProgettiDettaglioObj;
		}

		//Find Select

		public static GraduatoriaProgettiDettaglioCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdPrioritaEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.DecimalNT PunteggioEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataValutazioneEqualThis, SiarLibrary.NullTypes.StringNT OperatoreEqualThis, SiarLibrary.NullTypes.BoolNT ModificaManualeEqualThis)

		{

			GraduatoriaProgettiDettaglioCollection GraduatoriaProgettiDettaglioCollectionObj = new GraduatoriaProgettiDettaglioCollection();

			IDbCommand findCmd = db.InitCmd("Zgraduatoriaprogettidettagliofindselect", new string[] {"IdPrioritaequalthis", "IdProgettoequalthis", "Punteggioequalthis", 
"DataValutazioneequalthis", "Operatoreequalthis", "ModificaManualeequalthis"}, new string[] {"int", "int", "decimal", 
"DateTime", "string", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPrioritaequalthis", IdPrioritaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Punteggioequalthis", PunteggioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataValutazioneequalthis", DataValutazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ModificaManualeequalthis", ModificaManualeEqualThis);
			GraduatoriaProgettiDettaglio GraduatoriaProgettiDettaglioObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				GraduatoriaProgettiDettaglioObj = GetFromDatareader(db);
				GraduatoriaProgettiDettaglioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				GraduatoriaProgettiDettaglioObj.IsDirty = false;
				GraduatoriaProgettiDettaglioObj.IsPersistent = true;
				GraduatoriaProgettiDettaglioCollectionObj.Add(GraduatoriaProgettiDettaglioObj);
			}
			db.Close();
			return GraduatoriaProgettiDettaglioCollectionObj;
		}

		//Find Find

		public static GraduatoriaProgettiDettaglioCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdPrioritaEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.StringNT CodLivelloEqualThis)

		{

			GraduatoriaProgettiDettaglioCollection GraduatoriaProgettiDettaglioCollectionObj = new GraduatoriaProgettiDettaglioCollection();

			IDbCommand findCmd = db.InitCmd("Zgraduatoriaprogettidettagliofindfind", new string[] {"IdPrioritaequalthis", "IdProgettoequalthis", "CodLivelloequalthis"}, new string[] {"int", "int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPrioritaequalthis", IdPrioritaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodLivelloequalthis", CodLivelloEqualThis);
			GraduatoriaProgettiDettaglio GraduatoriaProgettiDettaglioObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				GraduatoriaProgettiDettaglioObj = GetFromDatareader(db);
				GraduatoriaProgettiDettaglioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				GraduatoriaProgettiDettaglioObj.IsDirty = false;
				GraduatoriaProgettiDettaglioObj.IsPersistent = true;
				GraduatoriaProgettiDettaglioCollectionObj.Add(GraduatoriaProgettiDettaglioObj);
			}
			db.Close();
			return GraduatoriaProgettiDettaglioCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for GraduatoriaProgettiDettaglioCollectionProvider:IGraduatoriaProgettiDettaglioProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class GraduatoriaProgettiDettaglioCollectionProvider : IGraduatoriaProgettiDettaglioProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di GraduatoriaProgettiDettaglio
		protected GraduatoriaProgettiDettaglioCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public GraduatoriaProgettiDettaglioCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new GraduatoriaProgettiDettaglioCollection(this);
		}

		//Costruttore 2: popola la collection
		public GraduatoriaProgettiDettaglioCollectionProvider(IntNT IdprioritaEqualThis, IntNT IdprogettoEqualThis, StringNT CodlivelloEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdprioritaEqualThis, IdprogettoEqualThis, CodlivelloEqualThis);
		}

		//Costruttore3: ha in input graduatoriaprogettidettaglioCollectionObj - non popola la collection
		public GraduatoriaProgettiDettaglioCollectionProvider(GraduatoriaProgettiDettaglioCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public GraduatoriaProgettiDettaglioCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new GraduatoriaProgettiDettaglioCollection(this);
		}

		//Get e Set
		public GraduatoriaProgettiDettaglioCollection CollectionObj
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
		public int SaveCollection(GraduatoriaProgettiDettaglioCollection collectionObj)
		{
			return GraduatoriaProgettiDettaglioDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(GraduatoriaProgettiDettaglio graduatoriaprogettidettaglioObj)
		{
			return GraduatoriaProgettiDettaglioDAL.Save(_dbProviderObj, graduatoriaprogettidettaglioObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(GraduatoriaProgettiDettaglioCollection collectionObj)
		{
			return GraduatoriaProgettiDettaglioDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(GraduatoriaProgettiDettaglio graduatoriaprogettidettaglioObj)
		{
			return GraduatoriaProgettiDettaglioDAL.Delete(_dbProviderObj, graduatoriaprogettidettaglioObj);
		}

		//getById
		public GraduatoriaProgettiDettaglio GetById(IntNT IdPrioritaValue, IntNT IdProgettoValue)
		{
			GraduatoriaProgettiDettaglio GraduatoriaProgettiDettaglioTemp = GraduatoriaProgettiDettaglioDAL.GetById(_dbProviderObj, IdPrioritaValue, IdProgettoValue);
			if (GraduatoriaProgettiDettaglioTemp!=null) GraduatoriaProgettiDettaglioTemp.Provider = this;
			return GraduatoriaProgettiDettaglioTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public GraduatoriaProgettiDettaglioCollection Select(IntNT IdprioritaEqualThis, IntNT IdprogettoEqualThis, DecimalNT PunteggioEqualThis, 
DatetimeNT DatavalutazioneEqualThis, StringNT OperatoreEqualThis, BoolNT ModificamanualeEqualThis)
		{
			GraduatoriaProgettiDettaglioCollection GraduatoriaProgettiDettaglioCollectionTemp = GraduatoriaProgettiDettaglioDAL.Select(_dbProviderObj, IdprioritaEqualThis, IdprogettoEqualThis, PunteggioEqualThis, 
DatavalutazioneEqualThis, OperatoreEqualThis, ModificamanualeEqualThis);
			GraduatoriaProgettiDettaglioCollectionTemp.Provider = this;
			return GraduatoriaProgettiDettaglioCollectionTemp;
		}

		//Find: popola la collection
		public GraduatoriaProgettiDettaglioCollection Find(IntNT IdprioritaEqualThis, IntNT IdprogettoEqualThis, StringNT CodlivelloEqualThis)
		{
			GraduatoriaProgettiDettaglioCollection GraduatoriaProgettiDettaglioCollectionTemp = GraduatoriaProgettiDettaglioDAL.Find(_dbProviderObj, IdprioritaEqualThis, IdprogettoEqualThis, CodlivelloEqualThis);
			GraduatoriaProgettiDettaglioCollectionTemp.Provider = this;
			return GraduatoriaProgettiDettaglioCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<GRADUATORIA_PROGETTI_DETTAGLIO>
  <ViewName>vGRADUATORIA_PROGETTI_DETTAGLIO</ViewName>
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
      <ID_PRIORITA>Equal</ID_PRIORITA>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <COD_LIVELLO>Equal</COD_LIVELLO>
    </Find>
  </Finds>
  <Filters>
    <FiltroTipo>
      <FLAG_MANUALE>Equal</FLAG_MANUALE>
      <PLURI_VALORE>Equal</PLURI_VALORE>
      <INPUT_NUMERICO>Equal</INPUT_NUMERICO>
    </FiltroTipo>
    <FiltroMisura>
      <MISURA>Like</MISURA>
    </FiltroMisura>
  </Filters>
  <externalFields />
  <AddedFkFields />
</GRADUATORIA_PROGETTI_DETTAGLIO>
*/
