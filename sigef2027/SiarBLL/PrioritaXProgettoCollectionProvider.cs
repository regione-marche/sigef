using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per PrioritaXProgetto
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IPrioritaXProgettoProvider
	{
		int Save(PrioritaXProgetto PrioritaXProgettoObj);
		int SaveCollection(PrioritaXProgettoCollection collectionObj);
		int Delete(PrioritaXProgetto PrioritaXProgettoObj);
		int DeleteCollection(PrioritaXProgettoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for PrioritaXProgetto
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class PrioritaXProgetto: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdPriorita;
		private NullTypes.DecimalNT _Valore;
		private NullTypes.DatetimeNT _DataValutazione;
		private NullTypes.StringNT _OperatoreValutazione;
		private NullTypes.BoolNT _ModificaManuale;
		private NullTypes.StringNT _Priorita;
		private NullTypes.StringNT _CodLivello;
		private NullTypes.BoolNT _PluriValore;
		private NullTypes.StringNT _Eval;
		private NullTypes.BoolNT _FlagManuale;
		private NullTypes.StringNT _ValoreDesc;
		private NullTypes.IntNT _IdValore;
		private NullTypes.DecimalNT _Punteggio;
		private NullTypes.BoolNT _InputNumerico;
		private NullTypes.StringNT _Misura;
		private NullTypes.BoolNT _Datetime;
		private NullTypes.BoolNT _TestoSemplice;
		private NullTypes.BoolNT _TestoArea;
		private NullTypes.BoolNT _PluriValoreSql;
		private NullTypes.StringNT _QueryPlurivalore;
		private NullTypes.DatetimeNT _ValData;
		private NullTypes.StringNT _ValTesto;
		[NonSerialized] private IPrioritaXProgettoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IPrioritaXProgettoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public PrioritaXProgetto()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
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
		/// Corrisponde al campo:VALORE
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT Valore
		{
			get { return _Valore; }
			set {
				if (Valore != value)
				{
					_Valore = value;
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
		/// Corrisponde al campo:OPERATORE_VALUTAZIONE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT OperatoreValutazione
		{
			get { return _OperatoreValutazione; }
			set {
				if (OperatoreValutazione != value)
				{
					_OperatoreValutazione = value;
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
		/// Corrisponde al campo:PRIORITA
		/// Tipo sul db:VARCHAR(1000)
		/// </summary>
		public NullTypes.StringNT Priorita
		{
			get { return _Priorita; }
			set {
				if (Priorita != value)
				{
					_Priorita = value;
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
		/// Corrisponde al campo:VALORE_DESC
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT ValoreDesc
		{
			get { return _ValoreDesc; }
			set {
				if (ValoreDesc != value)
				{
					_ValoreDesc = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_VALORE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdValore
		{
			get { return _IdValore; }
			set {
				if (IdValore != value)
				{
					_IdValore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PUNTEGGIO
		/// Tipo sul db:DECIMAL(18,6)
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

		/// <summary>
		/// Corrisponde al campo:DATETIME
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Datetime
		{
			get { return _Datetime; }
			set {
				if (Datetime != value)
				{
					_Datetime = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TESTO_SEMPLICE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT TestoSemplice
		{
			get { return _TestoSemplice; }
			set {
				if (TestoSemplice != value)
				{
					_TestoSemplice = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TESTO_AREA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT TestoArea
		{
			get { return _TestoArea; }
			set {
				if (TestoArea != value)
				{
					_TestoArea = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PLURI_VALORE_SQL
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT PluriValoreSql
		{
			get { return _PluriValoreSql; }
			set {
				if (PluriValoreSql != value)
				{
					_PluriValoreSql = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUERY_PLURIVALORE
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT QueryPlurivalore
		{
			get { return _QueryPlurivalore; }
			set {
				if (QueryPlurivalore != value)
				{
					_QueryPlurivalore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VAL_DATA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT ValData
		{
			get { return _ValData; }
			set {
				if (ValData != value)
				{
					_ValData = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VAL_TESTO
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT ValTesto
		{
			get { return _ValTesto; }
			set {
				if (ValTesto != value)
				{
					_ValTesto = value;
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
	/// Summary description for PrioritaXProgettoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class PrioritaXProgettoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private PrioritaXProgettoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((PrioritaXProgetto) info.GetValue(i.ToString(),typeof(PrioritaXProgetto)));
			}
		}

		//Costruttore
		public PrioritaXProgettoCollection()
		{
			this.ItemType = typeof(PrioritaXProgetto);
		}

		//Costruttore con provider
		public PrioritaXProgettoCollection(IPrioritaXProgettoProvider providerObj)
		{
			this.ItemType = typeof(PrioritaXProgetto);
			this.Provider = providerObj;
		}

		//Get e Set
		public new PrioritaXProgetto this[int index]
		{
			get { return (PrioritaXProgetto)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new PrioritaXProgettoCollection GetChanges()
		{
			return (PrioritaXProgettoCollection) base.GetChanges();
		}

		[NonSerialized] private IPrioritaXProgettoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IPrioritaXProgettoProvider Provider
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
		public int Add(PrioritaXProgetto PrioritaXProgettoObj)
		{
			if (PrioritaXProgettoObj.Provider == null) PrioritaXProgettoObj.Provider = this.Provider;
			return base.Add(PrioritaXProgettoObj);
		}

		//AddCollection
		public void AddCollection(PrioritaXProgettoCollection PrioritaXProgettoCollectionObj)
		{
			foreach (PrioritaXProgetto PrioritaXProgettoObj in PrioritaXProgettoCollectionObj)
				this.Add(PrioritaXProgettoObj);
		}

		//Insert
		public void Insert(int index, PrioritaXProgetto PrioritaXProgettoObj)
		{
			if (PrioritaXProgettoObj.Provider == null) PrioritaXProgettoObj.Provider = this.Provider;
			base.Insert(index, PrioritaXProgettoObj);
		}

		//CollectionGetById
		public PrioritaXProgetto CollectionGetById(NullTypes.IntNT IdProgettoValue, NullTypes.IntNT IdPrioritaValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdProgetto == IdProgettoValue) && (this[i].IdPriorita == IdPrioritaValue))
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
		public PrioritaXProgettoCollection SubSelect(NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdPrioritaEqualThis, NullTypes.IntNT IdValoreEqualThis, 
NullTypes.DecimalNT ValoreEqualThis, NullTypes.DatetimeNT DataValutazioneEqualThis, NullTypes.StringNT OperatoreValutazioneEqualThis, 
NullTypes.BoolNT ModificaManualeEqualThis, NullTypes.DecimalNT PunteggioEqualThis, NullTypes.DatetimeNT ValDataEqualThis, 
NullTypes.StringNT ValTestoEqualThis)
		{
			PrioritaXProgettoCollection PrioritaXProgettoCollectionTemp = new PrioritaXProgettoCollection();
			foreach (PrioritaXProgetto PrioritaXProgettoItem in this)
			{
				if (((IdProgettoEqualThis == null) || ((PrioritaXProgettoItem.IdProgetto != null) && (PrioritaXProgettoItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdPrioritaEqualThis == null) || ((PrioritaXProgettoItem.IdPriorita != null) && (PrioritaXProgettoItem.IdPriorita.Value == IdPrioritaEqualThis.Value))) && ((IdValoreEqualThis == null) || ((PrioritaXProgettoItem.IdValore != null) && (PrioritaXProgettoItem.IdValore.Value == IdValoreEqualThis.Value))) && 
((ValoreEqualThis == null) || ((PrioritaXProgettoItem.Valore != null) && (PrioritaXProgettoItem.Valore.Value == ValoreEqualThis.Value))) && ((DataValutazioneEqualThis == null) || ((PrioritaXProgettoItem.DataValutazione != null) && (PrioritaXProgettoItem.DataValutazione.Value == DataValutazioneEqualThis.Value))) && ((OperatoreValutazioneEqualThis == null) || ((PrioritaXProgettoItem.OperatoreValutazione != null) && (PrioritaXProgettoItem.OperatoreValutazione.Value == OperatoreValutazioneEqualThis.Value))) && 
((ModificaManualeEqualThis == null) || ((PrioritaXProgettoItem.ModificaManuale != null) && (PrioritaXProgettoItem.ModificaManuale.Value == ModificaManualeEqualThis.Value))) && ((PunteggioEqualThis == null) || ((PrioritaXProgettoItem.Punteggio != null) && (PrioritaXProgettoItem.Punteggio.Value == PunteggioEqualThis.Value))) && ((ValDataEqualThis == null) || ((PrioritaXProgettoItem.ValData != null) && (PrioritaXProgettoItem.ValData.Value == ValDataEqualThis.Value))) && 
((ValTestoEqualThis == null) || ((PrioritaXProgettoItem.ValTesto != null) && (PrioritaXProgettoItem.ValTesto.Value == ValTestoEqualThis.Value))))
				{
					PrioritaXProgettoCollectionTemp.Add(PrioritaXProgettoItem);
				}
			}
			return PrioritaXProgettoCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public PrioritaXProgettoCollection FiltroPluriValore(NullTypes.BoolNT PluriValoreEqualThis, NullTypes.IntNT IdValoreEqualThis)
		{
			PrioritaXProgettoCollection PrioritaXProgettoCollectionTemp = new PrioritaXProgettoCollection();
			foreach (PrioritaXProgetto PrioritaXProgettoItem in this)
			{
				if (((PluriValoreEqualThis == null) || ((PrioritaXProgettoItem.PluriValore != null) && (PrioritaXProgettoItem.PluriValore.Value == PluriValoreEqualThis.Value))) && ((IdValoreEqualThis == null) || ((PrioritaXProgettoItem.IdValore != null) && (PrioritaXProgettoItem.IdValore.Value == IdValoreEqualThis.Value))))
				{
					PrioritaXProgettoCollectionTemp.Add(PrioritaXProgettoItem);
				}
			}
			return PrioritaXProgettoCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public PrioritaXProgettoCollection FiltroMisura(NullTypes.StringNT MisuraLike)
		{
			PrioritaXProgettoCollection PrioritaXProgettoCollectionTemp = new PrioritaXProgettoCollection();
			foreach (PrioritaXProgetto PrioritaXProgettoItem in this)
			{
				if (((MisuraLike == null) || ((PrioritaXProgettoItem.Misura !=null) &&(PrioritaXProgettoItem.Misura.Like(MisuraLike.Value)))))
				{
					PrioritaXProgettoCollectionTemp.Add(PrioritaXProgettoItem);
				}
			}
			return PrioritaXProgettoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for PrioritaXProgettoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class PrioritaXProgettoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, PrioritaXProgetto PrioritaXProgettoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", PrioritaXProgettoObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdPriorita", PrioritaXProgettoObj.IdPriorita);
			DbProvider.SetCmdParam(cmd,firstChar + "Valore", PrioritaXProgettoObj.Valore);
			DbProvider.SetCmdParam(cmd,firstChar + "DataValutazione", PrioritaXProgettoObj.DataValutazione);
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreValutazione", PrioritaXProgettoObj.OperatoreValutazione);
			DbProvider.SetCmdParam(cmd,firstChar + "ModificaManuale", PrioritaXProgettoObj.ModificaManuale);
			DbProvider.SetCmdParam(cmd,firstChar + "IdValore", PrioritaXProgettoObj.IdValore);
			DbProvider.SetCmdParam(cmd,firstChar + "Punteggio", PrioritaXProgettoObj.Punteggio);
			DbProvider.SetCmdParam(cmd,firstChar + "ValData", PrioritaXProgettoObj.ValData);
			DbProvider.SetCmdParam(cmd,firstChar + "ValTesto", PrioritaXProgettoObj.ValTesto);
		}
		//Insert
		private static int Insert(DbProvider db, PrioritaXProgetto PrioritaXProgettoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZPrioritaXProgettoInsert", new string[] {"IdProgetto", "IdPriorita", "Valore", 
"DataValutazione", "OperatoreValutazione", "ModificaManuale", 


"IdValore", "Punteggio", 

"ValData", "ValTesto"}, new string[] {"int", "int", "decimal", 
"DateTime", "string", "bool", 


"int", "decimal", 

"DateTime", "string"},"");
				CompileIUCmd(false, insertCmd,PrioritaXProgettoObj, db.CommandFirstChar);
				i = db.Execute(insertCmd);
				PrioritaXProgettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PrioritaXProgettoObj.IsDirty = false;
				PrioritaXProgettoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, PrioritaXProgetto PrioritaXProgettoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPrioritaXProgettoUpdate", new string[] {"IdProgetto", "IdPriorita", "Valore", 
"DataValutazione", "OperatoreValutazione", "ModificaManuale", 


"IdValore", "Punteggio", 

"ValData", "ValTesto"}, new string[] {"int", "int", "decimal", 
"DateTime", "string", "bool", 


"int", "decimal", 

"DateTime", "string"},"");
				CompileIUCmd(true, updateCmd,PrioritaXProgettoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				PrioritaXProgettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PrioritaXProgettoObj.IsDirty = false;
				PrioritaXProgettoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, PrioritaXProgetto PrioritaXProgettoObj)
		{
			switch (PrioritaXProgettoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, PrioritaXProgettoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, PrioritaXProgettoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,PrioritaXProgettoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, PrioritaXProgettoCollection PrioritaXProgettoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPrioritaXProgettoUpdate", new string[] {"IdProgetto", "IdPriorita", "Valore", 
"DataValutazione", "OperatoreValutazione", "ModificaManuale", 


"IdValore", "Punteggio", 

"ValData", "ValTesto"}, new string[] {"int", "int", "decimal", 
"DateTime", "string", "bool", 


"int", "decimal", 

"DateTime", "string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZPrioritaXProgettoInsert", new string[] {"IdProgetto", "IdPriorita", "Valore", 
"DataValutazione", "OperatoreValutazione", "ModificaManuale", 


"IdValore", "Punteggio", 

"ValData", "ValTesto"}, new string[] {"int", "int", "decimal", 
"DateTime", "string", "bool", 


"int", "decimal", 

"DateTime", "string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZPrioritaXProgettoDelete", new string[] {"IdProgetto", "IdPriorita"}, new string[] {"int", "int"},"");
				for (int i = 0; i < PrioritaXProgettoCollectionObj.Count; i++)
				{
					switch (PrioritaXProgettoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,PrioritaXProgettoCollectionObj[i], db.CommandFirstChar);
								returnValue += db.Execute(insertCmd);
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,PrioritaXProgettoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (PrioritaXProgettoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProgetto", (SiarLibrary.NullTypes.IntNT)PrioritaXProgettoCollectionObj[i].IdProgetto);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPriorita", (SiarLibrary.NullTypes.IntNT)PrioritaXProgettoCollectionObj[i].IdPriorita);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < PrioritaXProgettoCollectionObj.Count; i++)
				{
					if ((PrioritaXProgettoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PrioritaXProgettoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PrioritaXProgettoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						PrioritaXProgettoCollectionObj[i].IsDirty = false;
						PrioritaXProgettoCollectionObj[i].IsPersistent = true;
					}
					if ((PrioritaXProgettoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						PrioritaXProgettoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PrioritaXProgettoCollectionObj[i].IsDirty = false;
						PrioritaXProgettoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, PrioritaXProgetto PrioritaXProgettoObj)
		{
			int returnValue = 0;
			if (PrioritaXProgettoObj.IsPersistent) 
			{
				returnValue = Delete(db, PrioritaXProgettoObj.IdProgetto, PrioritaXProgettoObj.IdPriorita);
			}
			PrioritaXProgettoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			PrioritaXProgettoObj.IsDirty = false;
			PrioritaXProgettoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdProgettoValue, int IdPrioritaValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPrioritaXProgettoDelete", new string[] {"IdProgetto", "IdPriorita"}, new string[] {"int", "int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProgetto", (SiarLibrary.NullTypes.IntNT)IdProgettoValue);
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPriorita", (SiarLibrary.NullTypes.IntNT)IdPrioritaValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, PrioritaXProgettoCollection PrioritaXProgettoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPrioritaXProgettoDelete", new string[] {"IdProgetto", "IdPriorita"}, new string[] {"int", "int"},"");
				for (int i = 0; i < PrioritaXProgettoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProgetto", PrioritaXProgettoCollectionObj[i].IdProgetto);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPriorita", PrioritaXProgettoCollectionObj[i].IdPriorita);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < PrioritaXProgettoCollectionObj.Count; i++)
				{
					if ((PrioritaXProgettoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PrioritaXProgettoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PrioritaXProgettoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PrioritaXProgettoCollectionObj[i].IsDirty = false;
						PrioritaXProgettoCollectionObj[i].IsPersistent = false;
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
		public static PrioritaXProgetto GetById(DbProvider db, int IdProgettoValue, int IdPrioritaValue)
		{
			PrioritaXProgetto PrioritaXProgettoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZPrioritaXProgettoGetById", new string[] {"IdProgetto", "IdPriorita"}, new string[] {"int", "int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdProgetto", (SiarLibrary.NullTypes.IntNT)IdProgettoValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdPriorita", (SiarLibrary.NullTypes.IntNT)IdPrioritaValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				PrioritaXProgettoObj = GetFromDatareader(db);
				PrioritaXProgettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PrioritaXProgettoObj.IsDirty = false;
				PrioritaXProgettoObj.IsPersistent = true;
			}
			db.Close();
			return PrioritaXProgettoObj;
		}

		//getFromDatareader
		public static PrioritaXProgetto GetFromDatareader(DbProvider db)
		{
			PrioritaXProgetto PrioritaXProgettoObj = new PrioritaXProgetto();
			PrioritaXProgettoObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			PrioritaXProgettoObj.IdPriorita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PRIORITA"]);
			PrioritaXProgettoObj.Valore = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VALORE"]);
			PrioritaXProgettoObj.DataValutazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_VALUTAZIONE"]);
			PrioritaXProgettoObj.OperatoreValutazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE_VALUTAZIONE"]);
			PrioritaXProgettoObj.ModificaManuale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["MODIFICA_MANUALE"]);
			PrioritaXProgettoObj.Priorita = new SiarLibrary.NullTypes.StringNT(db.DataReader["PRIORITA"]);
			PrioritaXProgettoObj.CodLivello = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_LIVELLO"]);
			PrioritaXProgettoObj.PluriValore = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PLURI_VALORE"]);
			PrioritaXProgettoObj.Eval = new SiarLibrary.NullTypes.StringNT(db.DataReader["EVAL"]);
			PrioritaXProgettoObj.FlagManuale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_MANUALE"]);
			PrioritaXProgettoObj.ValoreDesc = new SiarLibrary.NullTypes.StringNT(db.DataReader["VALORE_DESC"]);
			PrioritaXProgettoObj.IdValore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VALORE"]);
			PrioritaXProgettoObj.Punteggio = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PUNTEGGIO"]);
			PrioritaXProgettoObj.InputNumerico = new SiarLibrary.NullTypes.BoolNT(db.DataReader["INPUT_NUMERICO"]);
			PrioritaXProgettoObj.Misura = new SiarLibrary.NullTypes.StringNT(db.DataReader["MISURA"]);
			PrioritaXProgettoObj.Datetime = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DATETIME"]);
			PrioritaXProgettoObj.TestoSemplice = new SiarLibrary.NullTypes.BoolNT(db.DataReader["TESTO_SEMPLICE"]);
			PrioritaXProgettoObj.TestoArea = new SiarLibrary.NullTypes.BoolNT(db.DataReader["TESTO_AREA"]);
			PrioritaXProgettoObj.PluriValoreSql = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PLURI_VALORE_SQL"]);
			PrioritaXProgettoObj.QueryPlurivalore = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_PLURIVALORE"]);
			PrioritaXProgettoObj.ValData = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["VAL_DATA"]);
			PrioritaXProgettoObj.ValTesto = new SiarLibrary.NullTypes.StringNT(db.DataReader["VAL_TESTO"]);
			PrioritaXProgettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			PrioritaXProgettoObj.IsDirty = false;
			PrioritaXProgettoObj.IsPersistent = true;
			return PrioritaXProgettoObj;
		}

		//Find Select

		public static PrioritaXProgettoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdPrioritaEqualThis, SiarLibrary.NullTypes.IntNT IdValoreEqualThis, 
SiarLibrary.NullTypes.DecimalNT ValoreEqualThis, SiarLibrary.NullTypes.DatetimeNT DataValutazioneEqualThis, SiarLibrary.NullTypes.StringNT OperatoreValutazioneEqualThis, 
SiarLibrary.NullTypes.BoolNT ModificaManualeEqualThis, SiarLibrary.NullTypes.DecimalNT PunteggioEqualThis, SiarLibrary.NullTypes.DatetimeNT ValDataEqualThis, 
SiarLibrary.NullTypes.StringNT ValTestoEqualThis)

		{

			PrioritaXProgettoCollection PrioritaXProgettoCollectionObj = new PrioritaXProgettoCollection();

			IDbCommand findCmd = db.InitCmd("Zprioritaxprogettofindselect", new string[] {"IdProgettoequalthis", "IdPrioritaequalthis", "IdValoreequalthis", 
"Valoreequalthis", "DataValutazioneequalthis", "OperatoreValutazioneequalthis", 
"ModificaManualeequalthis", "Punteggioequalthis", "ValDataequalthis", 
"ValTestoequalthis"}, new string[] {"int", "int", "int", 
"decimal", "DateTime", "string", 
"bool", "decimal", "DateTime", 
"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPrioritaequalthis", IdPrioritaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdValoreequalthis", IdValoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Valoreequalthis", ValoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataValutazioneequalthis", DataValutazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreValutazioneequalthis", OperatoreValutazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ModificaManualeequalthis", ModificaManualeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Punteggioequalthis", PunteggioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ValDataequalthis", ValDataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ValTestoequalthis", ValTestoEqualThis);
			PrioritaXProgetto PrioritaXProgettoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				PrioritaXProgettoObj = GetFromDatareader(db);
				PrioritaXProgettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PrioritaXProgettoObj.IsDirty = false;
				PrioritaXProgettoObj.IsPersistent = true;
				PrioritaXProgettoCollectionObj.Add(PrioritaXProgettoObj);
			}
			db.Close();
			return PrioritaXProgettoCollectionObj;
		}

		//Find Find

		public static PrioritaXProgettoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdPrioritaEqualThis, SiarLibrary.NullTypes.StringNT CodLivelloEqualThis)

		{

			PrioritaXProgettoCollection PrioritaXProgettoCollectionObj = new PrioritaXProgettoCollection();

			IDbCommand findCmd = db.InitCmd("Zprioritaxprogettofindfind", new string[] {"IdProgettoequalthis", "IdPrioritaequalthis", "CodLivelloequalthis"}, new string[] {"int", "int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPrioritaequalthis", IdPrioritaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodLivelloequalthis", CodLivelloEqualThis);
			PrioritaXProgetto PrioritaXProgettoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				PrioritaXProgettoObj = GetFromDatareader(db);
				PrioritaXProgettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PrioritaXProgettoObj.IsDirty = false;
				PrioritaXProgettoObj.IsPersistent = true;
				PrioritaXProgettoCollectionObj.Add(PrioritaXProgettoObj);
			}
			db.Close();
			return PrioritaXProgettoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for PrioritaXProgettoCollectionProvider:IPrioritaXProgettoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class PrioritaXProgettoCollectionProvider : IPrioritaXProgettoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di PrioritaXProgetto
		protected PrioritaXProgettoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public PrioritaXProgettoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new PrioritaXProgettoCollection(this);
		}

		//Costruttore 2: popola la collection
		public PrioritaXProgettoCollectionProvider(IntNT IdprogettoEqualThis, IntNT IdprioritaEqualThis, StringNT CodlivelloEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdprogettoEqualThis, IdprioritaEqualThis, CodlivelloEqualThis);
		}

		//Costruttore3: ha in input prioritaxprogettoCollectionObj - non popola la collection
		public PrioritaXProgettoCollectionProvider(PrioritaXProgettoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public PrioritaXProgettoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new PrioritaXProgettoCollection(this);
		}

		//Get e Set
		public PrioritaXProgettoCollection CollectionObj
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
		public int SaveCollection(PrioritaXProgettoCollection collectionObj)
		{
			return PrioritaXProgettoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(PrioritaXProgetto prioritaxprogettoObj)
		{
			return PrioritaXProgettoDAL.Save(_dbProviderObj, prioritaxprogettoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(PrioritaXProgettoCollection collectionObj)
		{
			return PrioritaXProgettoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(PrioritaXProgetto prioritaxprogettoObj)
		{
			return PrioritaXProgettoDAL.Delete(_dbProviderObj, prioritaxprogettoObj);
		}

		//getById
		public PrioritaXProgetto GetById(IntNT IdProgettoValue, IntNT IdPrioritaValue)
		{
			PrioritaXProgetto PrioritaXProgettoTemp = PrioritaXProgettoDAL.GetById(_dbProviderObj, IdProgettoValue, IdPrioritaValue);
			if (PrioritaXProgettoTemp!=null) PrioritaXProgettoTemp.Provider = this;
			return PrioritaXProgettoTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public PrioritaXProgettoCollection Select(IntNT IdprogettoEqualThis, IntNT IdprioritaEqualThis, IntNT IdvaloreEqualThis, 
DecimalNT ValoreEqualThis, DatetimeNT DatavalutazioneEqualThis, StringNT OperatorevalutazioneEqualThis, 
BoolNT ModificamanualeEqualThis, DecimalNT PunteggioEqualThis, DatetimeNT ValdataEqualThis, 
StringNT ValtestoEqualThis)
		{
			PrioritaXProgettoCollection PrioritaXProgettoCollectionTemp = PrioritaXProgettoDAL.Select(_dbProviderObj, IdprogettoEqualThis, IdprioritaEqualThis, IdvaloreEqualThis, 
ValoreEqualThis, DatavalutazioneEqualThis, OperatorevalutazioneEqualThis, 
ModificamanualeEqualThis, PunteggioEqualThis, ValdataEqualThis, 
ValtestoEqualThis);
			PrioritaXProgettoCollectionTemp.Provider = this;
			return PrioritaXProgettoCollectionTemp;
		}

		//Find: popola la collection
		public PrioritaXProgettoCollection Find(IntNT IdprogettoEqualThis, IntNT IdprioritaEqualThis, StringNT CodlivelloEqualThis)
		{
			PrioritaXProgettoCollection PrioritaXProgettoCollectionTemp = PrioritaXProgettoDAL.Find(_dbProviderObj, IdprogettoEqualThis, IdprioritaEqualThis, CodlivelloEqualThis);
			PrioritaXProgettoCollectionTemp.Provider = this;
			return PrioritaXProgettoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PRIORITA_X_PROGETTO>
  <ViewName>vPRIORITA_X_PROGETTO</ViewName>
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
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_PRIORITA>Equal</ID_PRIORITA>
      <COD_LIVELLO>Equal</COD_LIVELLO>
    </Find>
  </Finds>
  <Filters>
    <FiltroPluriValore>
      <PLURI_VALORE>Equal</PLURI_VALORE>
      <ID_VALORE>Equal</ID_VALORE>
    </FiltroPluriValore>
    <FiltroMisura>
      <MISURA>Like</MISURA>
    </FiltroMisura>
  </Filters>
  <externalFields />
  <AddedFkFields />
</PRIORITA_X_PROGETTO>
*/
