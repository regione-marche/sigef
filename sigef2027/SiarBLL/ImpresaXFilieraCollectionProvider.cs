using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ImpresaXFiliera
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IImpresaXFilieraProvider
	{
		int Save(ImpresaXFiliera ImpresaXFilieraObj);
		int SaveCollection(ImpresaXFilieraCollection collectionObj);
		int Delete(ImpresaXFiliera ImpresaXFilieraObj);
		int DeleteCollection(ImpresaXFilieraCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ImpresaXFiliera
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ImpresaXFiliera: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdImpresaXFiliera;
		private NullTypes.IntNT _IdFiliera;
		private NullTypes.StringNT _Cuaa;
		private NullTypes.BoolNT _FlagPartecipante;
		private NullTypes.StringNT _CodRuoloSitra;
		private NullTypes.StringNT _RuoloSitra;
		private NullTypes.StringNT _CodRuoloPartecipante;
		private NullTypes.StringNT _RuoloPartecipante;
		private NullTypes.DecimalNT _Quantita;
		private NullTypes.IntNT _UnitaMisura;
		private NullTypes.StringNT _DescrizioneUnitaMisura;
		private NullTypes.StringNT _SistemaQualita;
		private NullTypes.StringNT _DescrizioneSistemaQualita;
		private NullTypes.StringNT _CodificaInterventi;
		private NullTypes.StringNT _Operatore;
		private NullTypes.BoolNT _Ammesso;
		private NullTypes.IntNT _IdProgrammazione;
		private NullTypes.StringNT _Programmazione;
		private NullTypes.StringNT _CodProgrammazione;
		[NonSerialized] private IImpresaXFilieraProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IImpresaXFilieraProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ImpresaXFiliera()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_IMPRESA_X_FILIERA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdImpresaXFiliera
		{
			get { return _IdImpresaXFiliera; }
			set {
				if (IdImpresaXFiliera != value)
				{
					_IdImpresaXFiliera = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_FILIERA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdFiliera
		{
			get { return _IdFiliera; }
			set {
				if (IdFiliera != value)
				{
					_IdFiliera = value;
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
		/// Corrisponde al campo:FLAG_PARTECIPANTE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT FlagPartecipante
		{
			get { return _FlagPartecipante; }
			set {
				if (FlagPartecipante != value)
				{
					_FlagPartecipante = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_RUOLO_SITRA
		/// Tipo sul db:CHAR(3)
		/// </summary>
		public NullTypes.StringNT CodRuoloSitra
		{
			get { return _CodRuoloSitra; }
			set {
				if (CodRuoloSitra != value)
				{
					_CodRuoloSitra = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RUOLO_SITRA
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT RuoloSitra
		{
			get { return _RuoloSitra; }
			set {
				if (RuoloSitra != value)
				{
					_RuoloSitra = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_RUOLO_PARTECIPANTE
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT CodRuoloPartecipante
		{
			get { return _CodRuoloPartecipante; }
			set {
				if (CodRuoloPartecipante != value)
				{
					_CodRuoloPartecipante = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RUOLO_PARTECIPANTE
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT RuoloPartecipante
		{
			get { return _RuoloPartecipante; }
			set {
				if (RuoloPartecipante != value)
				{
					_RuoloPartecipante = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUANTITA
		/// Tipo sul db:DECIMAL(10,2)
		/// </summary>
		public NullTypes.DecimalNT Quantita
		{
			get { return _Quantita; }
			set {
				if (Quantita != value)
				{
					_Quantita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:UNITA_MISURA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT UnitaMisura
		{
			get { return _UnitaMisura; }
			set {
				if (UnitaMisura != value)
				{
					_UnitaMisura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_UNITA_MISURA
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT DescrizioneUnitaMisura
		{
			get { return _DescrizioneUnitaMisura; }
			set {
				if (DescrizioneUnitaMisura != value)
				{
					_DescrizioneUnitaMisura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SISTEMA_QUALITA
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT SistemaQualita
		{
			get { return _SistemaQualita; }
			set {
				if (SistemaQualita != value)
				{
					_SistemaQualita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_SISTEMA_QUALITA
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT DescrizioneSistemaQualita
		{
			get { return _DescrizioneSistemaQualita; }
			set {
				if (DescrizioneSistemaQualita != value)
				{
					_DescrizioneSistemaQualita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODIFICA_INTERVENTI
		/// Tipo sul db:NTEXT
		/// </summary>
		public NullTypes.StringNT CodificaInterventi
		{
			get { return _CodificaInterventi; }
			set {
				if (CodificaInterventi != value)
				{
					_CodificaInterventi = value;
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
		/// Corrisponde al campo:AMMESSO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Ammesso
		{
			get { return _Ammesso; }
			set {
				if (Ammesso != value)
				{
					_Ammesso = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_PROGRAMMAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProgrammazione
		{
			get { return _IdProgrammazione; }
			set {
				if (IdProgrammazione != value)
				{
					_IdProgrammazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PROGRAMMAZIONE
		/// Tipo sul db:VARCHAR(2000)
		/// </summary>
		public NullTypes.StringNT Programmazione
		{
			get { return _Programmazione; }
			set {
				if (Programmazione != value)
				{
					_Programmazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_PROGRAMMAZIONE
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT CodProgrammazione
		{
			get { return _CodProgrammazione; }
			set {
				if (CodProgrammazione != value)
				{
					_CodProgrammazione = value;
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
	/// Summary description for ImpresaXFilieraCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ImpresaXFilieraCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ImpresaXFilieraCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ImpresaXFiliera) info.GetValue(i.ToString(),typeof(ImpresaXFiliera)));
			}
		}

		//Costruttore
		public ImpresaXFilieraCollection()
		{
			this.ItemType = typeof(ImpresaXFiliera);
		}

		//Costruttore con provider
		public ImpresaXFilieraCollection(IImpresaXFilieraProvider providerObj)
		{
			this.ItemType = typeof(ImpresaXFiliera);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ImpresaXFiliera this[int index]
		{
			get { return (ImpresaXFiliera)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ImpresaXFilieraCollection GetChanges()
		{
			return (ImpresaXFilieraCollection) base.GetChanges();
		}

		[NonSerialized] private IImpresaXFilieraProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IImpresaXFilieraProvider Provider
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
		public int Add(ImpresaXFiliera ImpresaXFilieraObj)
		{
			if (ImpresaXFilieraObj.Provider == null) ImpresaXFilieraObj.Provider = this.Provider;
			return base.Add(ImpresaXFilieraObj);
		}

		//AddCollection
		public void AddCollection(ImpresaXFilieraCollection ImpresaXFilieraCollectionObj)
		{
			foreach (ImpresaXFiliera ImpresaXFilieraObj in ImpresaXFilieraCollectionObj)
				this.Add(ImpresaXFilieraObj);
		}

		//Insert
		public void Insert(int index, ImpresaXFiliera ImpresaXFilieraObj)
		{
			if (ImpresaXFilieraObj.Provider == null) ImpresaXFilieraObj.Provider = this.Provider;
			base.Insert(index, ImpresaXFilieraObj);
		}

		//CollectionGetById
		public ImpresaXFiliera CollectionGetById(NullTypes.IntNT IdImpresaXFilieraValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdImpresaXFiliera == IdImpresaXFilieraValue))
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
		public ImpresaXFilieraCollection SubSelect(NullTypes.IntNT IdImpresaXFilieraEqualThis, NullTypes.IntNT IdFilieraEqualThis, NullTypes.StringNT CuaaEqualThis, 
NullTypes.BoolNT FlagPartecipanteEqualThis, NullTypes.StringNT CodRuoloSitraEqualThis, NullTypes.StringNT CodRuoloPartecipanteEqualThis, 
NullTypes.DecimalNT QuantitaEqualThis, NullTypes.IntNT UnitaMisuraEqualThis, NullTypes.StringNT SistemaQualitaEqualThis, 
NullTypes.StringNT OperatoreEqualThis, NullTypes.BoolNT AmmessoEqualThis, NullTypes.IntNT IdProgrammazioneEqualThis)
		{
			ImpresaXFilieraCollection ImpresaXFilieraCollectionTemp = new ImpresaXFilieraCollection();
			foreach (ImpresaXFiliera ImpresaXFilieraItem in this)
			{
				if (((IdImpresaXFilieraEqualThis == null) || ((ImpresaXFilieraItem.IdImpresaXFiliera != null) && (ImpresaXFilieraItem.IdImpresaXFiliera.Value == IdImpresaXFilieraEqualThis.Value))) && ((IdFilieraEqualThis == null) || ((ImpresaXFilieraItem.IdFiliera != null) && (ImpresaXFilieraItem.IdFiliera.Value == IdFilieraEqualThis.Value))) && ((CuaaEqualThis == null) || ((ImpresaXFilieraItem.Cuaa != null) && (ImpresaXFilieraItem.Cuaa.Value == CuaaEqualThis.Value))) && 
((FlagPartecipanteEqualThis == null) || ((ImpresaXFilieraItem.FlagPartecipante != null) && (ImpresaXFilieraItem.FlagPartecipante.Value == FlagPartecipanteEqualThis.Value))) && ((CodRuoloSitraEqualThis == null) || ((ImpresaXFilieraItem.CodRuoloSitra != null) && (ImpresaXFilieraItem.CodRuoloSitra.Value == CodRuoloSitraEqualThis.Value))) && ((CodRuoloPartecipanteEqualThis == null) || ((ImpresaXFilieraItem.CodRuoloPartecipante != null) && (ImpresaXFilieraItem.CodRuoloPartecipante.Value == CodRuoloPartecipanteEqualThis.Value))) && 
((QuantitaEqualThis == null) || ((ImpresaXFilieraItem.Quantita != null) && (ImpresaXFilieraItem.Quantita.Value == QuantitaEqualThis.Value))) && ((UnitaMisuraEqualThis == null) || ((ImpresaXFilieraItem.UnitaMisura != null) && (ImpresaXFilieraItem.UnitaMisura.Value == UnitaMisuraEqualThis.Value))) && ((SistemaQualitaEqualThis == null) || ((ImpresaXFilieraItem.SistemaQualita != null) && (ImpresaXFilieraItem.SistemaQualita.Value == SistemaQualitaEqualThis.Value))) && 
((OperatoreEqualThis == null) || ((ImpresaXFilieraItem.Operatore != null) && (ImpresaXFilieraItem.Operatore.Value == OperatoreEqualThis.Value))) && ((AmmessoEqualThis == null) || ((ImpresaXFilieraItem.Ammesso != null) && (ImpresaXFilieraItem.Ammesso.Value == AmmessoEqualThis.Value))) && ((IdProgrammazioneEqualThis == null) || ((ImpresaXFilieraItem.IdProgrammazione != null) && (ImpresaXFilieraItem.IdProgrammazione.Value == IdProgrammazioneEqualThis.Value))))
				{
					ImpresaXFilieraCollectionTemp.Add(ImpresaXFilieraItem);
				}
			}
			return ImpresaXFilieraCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ImpresaXFilieraDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ImpresaXFilieraDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ImpresaXFiliera ImpresaXFilieraObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdImpresaXFiliera", ImpresaXFilieraObj.IdImpresaXFiliera);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdFiliera", ImpresaXFilieraObj.IdFiliera);
			DbProvider.SetCmdParam(cmd,firstChar + "Cuaa", ImpresaXFilieraObj.Cuaa);
			DbProvider.SetCmdParam(cmd,firstChar + "FlagPartecipante", ImpresaXFilieraObj.FlagPartecipante);
			DbProvider.SetCmdParam(cmd,firstChar + "CodRuoloSitra", ImpresaXFilieraObj.CodRuoloSitra);
			DbProvider.SetCmdParam(cmd,firstChar + "CodRuoloPartecipante", ImpresaXFilieraObj.CodRuoloPartecipante);
			DbProvider.SetCmdParam(cmd,firstChar + "Quantita", ImpresaXFilieraObj.Quantita);
			DbProvider.SetCmdParam(cmd,firstChar + "UnitaMisura", ImpresaXFilieraObj.UnitaMisura);
			DbProvider.SetCmdParam(cmd,firstChar + "SistemaQualita", ImpresaXFilieraObj.SistemaQualita);
			DbProvider.SetCmdParam(cmd,firstChar + "CodificaInterventi", ImpresaXFilieraObj.CodificaInterventi);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", ImpresaXFilieraObj.Operatore);
			DbProvider.SetCmdParam(cmd,firstChar + "Ammesso", ImpresaXFilieraObj.Ammesso);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgrammazione", ImpresaXFilieraObj.IdProgrammazione);
		}
		//Insert
		private static int Insert(DbProvider db, ImpresaXFiliera ImpresaXFilieraObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZImpresaXFilieraInsert", new string[] {"IdFiliera", "Cuaa", 
"FlagPartecipante", "CodRuoloSitra", 
"CodRuoloPartecipante", "Quantita", 
"UnitaMisura", "SistemaQualita", 
"CodificaInterventi", "Operatore", 
"Ammesso", "IdProgrammazione", }, new string[] {"int", "string", 
"bool", "string", 
"string", "decimal", 
"int", "string", 
"string", "string", 
"bool", "int", },"");
				CompileIUCmd(false, insertCmd,ImpresaXFilieraObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ImpresaXFilieraObj.IdImpresaXFiliera = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA_X_FILIERA"]);
				}
				ImpresaXFilieraObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ImpresaXFilieraObj.IsDirty = false;
				ImpresaXFilieraObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ImpresaXFiliera ImpresaXFilieraObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZImpresaXFilieraUpdate", new string[] {"IdImpresaXFiliera", "IdFiliera", "Cuaa", 
"FlagPartecipante", "CodRuoloSitra", 
"CodRuoloPartecipante", "Quantita", 
"UnitaMisura", "SistemaQualita", 
"CodificaInterventi", "Operatore", 
"Ammesso", "IdProgrammazione", }, new string[] {"int", "int", "string", 
"bool", "string", 
"string", "decimal", 
"int", "string", 
"string", "string", 
"bool", "int", },"");
				CompileIUCmd(true, updateCmd,ImpresaXFilieraObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ImpresaXFilieraObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ImpresaXFilieraObj.IsDirty = false;
				ImpresaXFilieraObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ImpresaXFiliera ImpresaXFilieraObj)
		{
			switch (ImpresaXFilieraObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ImpresaXFilieraObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ImpresaXFilieraObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ImpresaXFilieraObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ImpresaXFilieraCollection ImpresaXFilieraCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZImpresaXFilieraUpdate", new string[] {"IdImpresaXFiliera", "IdFiliera", "Cuaa", 
"FlagPartecipante", "CodRuoloSitra", 
"CodRuoloPartecipante", "Quantita", 
"UnitaMisura", "SistemaQualita", 
"CodificaInterventi", "Operatore", 
"Ammesso", "IdProgrammazione", }, new string[] {"int", "int", "string", 
"bool", "string", 
"string", "decimal", 
"int", "string", 
"string", "string", 
"bool", "int", },"");
				IDbCommand insertCmd = db.InitCmd( "ZImpresaXFilieraInsert", new string[] {"IdFiliera", "Cuaa", 
"FlagPartecipante", "CodRuoloSitra", 
"CodRuoloPartecipante", "Quantita", 
"UnitaMisura", "SistemaQualita", 
"CodificaInterventi", "Operatore", 
"Ammesso", "IdProgrammazione", }, new string[] {"int", "string", 
"bool", "string", 
"string", "decimal", 
"int", "string", 
"string", "string", 
"bool", "int", },"");
				IDbCommand deleteCmd = db.InitCmd( "ZImpresaXFilieraDelete", new string[] {"IdImpresaXFiliera"}, new string[] {"int"},"");
				for (int i = 0; i < ImpresaXFilieraCollectionObj.Count; i++)
				{
					switch (ImpresaXFilieraCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ImpresaXFilieraCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ImpresaXFilieraCollectionObj[i].IdImpresaXFiliera = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA_X_FILIERA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ImpresaXFilieraCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ImpresaXFilieraCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdImpresaXFiliera", (SiarLibrary.NullTypes.IntNT)ImpresaXFilieraCollectionObj[i].IdImpresaXFiliera);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ImpresaXFilieraCollectionObj.Count; i++)
				{
					if ((ImpresaXFilieraCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ImpresaXFilieraCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ImpresaXFilieraCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ImpresaXFilieraCollectionObj[i].IsDirty = false;
						ImpresaXFilieraCollectionObj[i].IsPersistent = true;
					}
					if ((ImpresaXFilieraCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ImpresaXFilieraCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ImpresaXFilieraCollectionObj[i].IsDirty = false;
						ImpresaXFilieraCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ImpresaXFiliera ImpresaXFilieraObj)
		{
			int returnValue = 0;
			if (ImpresaXFilieraObj.IsPersistent) 
			{
				returnValue = Delete(db, ImpresaXFilieraObj.IdImpresaXFiliera);
			}
			ImpresaXFilieraObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ImpresaXFilieraObj.IsDirty = false;
			ImpresaXFilieraObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdImpresaXFilieraValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZImpresaXFilieraDelete", new string[] {"IdImpresaXFiliera"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdImpresaXFiliera", (SiarLibrary.NullTypes.IntNT)IdImpresaXFilieraValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ImpresaXFilieraCollection ImpresaXFilieraCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZImpresaXFilieraDelete", new string[] {"IdImpresaXFiliera"}, new string[] {"int"},"");
				for (int i = 0; i < ImpresaXFilieraCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdImpresaXFiliera", ImpresaXFilieraCollectionObj[i].IdImpresaXFiliera);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ImpresaXFilieraCollectionObj.Count; i++)
				{
					if ((ImpresaXFilieraCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ImpresaXFilieraCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ImpresaXFilieraCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ImpresaXFilieraCollectionObj[i].IsDirty = false;
						ImpresaXFilieraCollectionObj[i].IsPersistent = false;
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
		public static ImpresaXFiliera GetById(DbProvider db, int IdImpresaXFilieraValue)
		{
			ImpresaXFiliera ImpresaXFilieraObj = null;
			IDbCommand readCmd = db.InitCmd( "ZImpresaXFilieraGetById", new string[] {"IdImpresaXFiliera"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdImpresaXFiliera", (SiarLibrary.NullTypes.IntNT)IdImpresaXFilieraValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ImpresaXFilieraObj = GetFromDatareader(db);
				ImpresaXFilieraObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ImpresaXFilieraObj.IsDirty = false;
				ImpresaXFilieraObj.IsPersistent = true;
			}
			db.Close();
			return ImpresaXFilieraObj;
		}

		//getFromDatareader
		public static ImpresaXFiliera GetFromDatareader(DbProvider db)
		{
			ImpresaXFiliera ImpresaXFilieraObj = new ImpresaXFiliera();
			ImpresaXFilieraObj.IdImpresaXFiliera = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA_X_FILIERA"]);
			ImpresaXFilieraObj.IdFiliera = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILIERA"]);
			ImpresaXFilieraObj.Cuaa = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUAA"]);
			ImpresaXFilieraObj.FlagPartecipante = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_PARTECIPANTE"]);
			ImpresaXFilieraObj.CodRuoloSitra = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_RUOLO_SITRA"]);
			ImpresaXFilieraObj.RuoloSitra = new SiarLibrary.NullTypes.StringNT(db.DataReader["RUOLO_SITRA"]);
			ImpresaXFilieraObj.CodRuoloPartecipante = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_RUOLO_PARTECIPANTE"]);
			ImpresaXFilieraObj.RuoloPartecipante = new SiarLibrary.NullTypes.StringNT(db.DataReader["RUOLO_PARTECIPANTE"]);
			ImpresaXFilieraObj.Quantita = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUANTITA"]);
			ImpresaXFilieraObj.UnitaMisura = new SiarLibrary.NullTypes.IntNT(db.DataReader["UNITA_MISURA"]);
			ImpresaXFilieraObj.DescrizioneUnitaMisura = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_UNITA_MISURA"]);
			ImpresaXFilieraObj.SistemaQualita = new SiarLibrary.NullTypes.StringNT(db.DataReader["SISTEMA_QUALITA"]);
			ImpresaXFilieraObj.DescrizioneSistemaQualita = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_SISTEMA_QUALITA"]);
			ImpresaXFilieraObj.CodificaInterventi = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODIFICA_INTERVENTI"]);
			ImpresaXFilieraObj.Operatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE"]);
			ImpresaXFilieraObj.Ammesso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AMMESSO"]);
			ImpresaXFilieraObj.IdProgrammazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGRAMMAZIONE"]);
			ImpresaXFilieraObj.Programmazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROGRAMMAZIONE"]);
			ImpresaXFilieraObj.CodProgrammazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_PROGRAMMAZIONE"]);
			ImpresaXFilieraObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ImpresaXFilieraObj.IsDirty = false;
			ImpresaXFilieraObj.IsPersistent = true;
			return ImpresaXFilieraObj;
		}

		//Find Select

		public static ImpresaXFilieraCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdImpresaXFilieraEqualThis, SiarLibrary.NullTypes.IntNT IdFilieraEqualThis, SiarLibrary.NullTypes.StringNT CuaaEqualThis, 
SiarLibrary.NullTypes.BoolNT FlagPartecipanteEqualThis, SiarLibrary.NullTypes.StringNT CodRuoloSitraEqualThis, SiarLibrary.NullTypes.StringNT CodRuoloPartecipanteEqualThis, 
SiarLibrary.NullTypes.DecimalNT QuantitaEqualThis, SiarLibrary.NullTypes.IntNT UnitaMisuraEqualThis, SiarLibrary.NullTypes.StringNT SistemaQualitaEqualThis, 
SiarLibrary.NullTypes.StringNT OperatoreEqualThis, SiarLibrary.NullTypes.BoolNT AmmessoEqualThis, SiarLibrary.NullTypes.IntNT IdProgrammazioneEqualThis)

		{

			ImpresaXFilieraCollection ImpresaXFilieraCollectionObj = new ImpresaXFilieraCollection();

			IDbCommand findCmd = db.InitCmd("Zimpresaxfilierafindselect", new string[] {"IdImpresaXFilieraequalthis", "IdFilieraequalthis", "Cuaaequalthis", 
"FlagPartecipanteequalthis", "CodRuoloSitraequalthis", "CodRuoloPartecipanteequalthis", 
"Quantitaequalthis", "UnitaMisuraequalthis", "SistemaQualitaequalthis", 
"Operatoreequalthis", "Ammessoequalthis", "IdProgrammazioneequalthis"}, new string[] {"int", "int", "string", 
"bool", "string", "string", 
"decimal", "int", "string", 
"string", "bool", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaXFilieraequalthis", IdImpresaXFilieraEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFilieraequalthis", IdFilieraEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Cuaaequalthis", CuaaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FlagPartecipanteequalthis", FlagPartecipanteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodRuoloSitraequalthis", CodRuoloSitraEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodRuoloPartecipanteequalthis", CodRuoloPartecipanteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Quantitaequalthis", QuantitaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "UnitaMisuraequalthis", UnitaMisuraEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SistemaQualitaequalthis", SistemaQualitaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ammessoequalthis", AmmessoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgrammazioneequalthis", IdProgrammazioneEqualThis);
			ImpresaXFiliera ImpresaXFilieraObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ImpresaXFilieraObj = GetFromDatareader(db);
				ImpresaXFilieraObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ImpresaXFilieraObj.IsDirty = false;
				ImpresaXFilieraObj.IsPersistent = true;
				ImpresaXFilieraCollectionObj.Add(ImpresaXFilieraObj);
			}
			db.Close();
			return ImpresaXFilieraCollectionObj;
		}

		//Find Find

		public static ImpresaXFilieraCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdFilieraEqualThis, SiarLibrary.NullTypes.StringNT CuaaLikeThis)

		{

			ImpresaXFilieraCollection ImpresaXFilieraCollectionObj = new ImpresaXFilieraCollection();

			IDbCommand findCmd = db.InitCmd("Zimpresaxfilierafindfind", new string[] {"IdFilieraequalthis", "Cuaalikethis"}, new string[] {"int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFilieraequalthis", IdFilieraEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Cuaalikethis", CuaaLikeThis);
			ImpresaXFiliera ImpresaXFilieraObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ImpresaXFilieraObj = GetFromDatareader(db);
				ImpresaXFilieraObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ImpresaXFilieraObj.IsDirty = false;
				ImpresaXFilieraObj.IsPersistent = true;
				ImpresaXFilieraCollectionObj.Add(ImpresaXFilieraObj);
			}
			db.Close();
			return ImpresaXFilieraCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ImpresaXFilieraCollectionProvider:IImpresaXFilieraProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ImpresaXFilieraCollectionProvider : IImpresaXFilieraProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ImpresaXFiliera
		protected ImpresaXFilieraCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ImpresaXFilieraCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ImpresaXFilieraCollection(this);
		}

		//Costruttore 2: popola la collection
		public ImpresaXFilieraCollectionProvider(IntNT IdfilieraEqualThis, StringNT CuaaLikeThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdfilieraEqualThis, CuaaLikeThis);
		}

		//Costruttore3: ha in input impresaxfilieraCollectionObj - non popola la collection
		public ImpresaXFilieraCollectionProvider(ImpresaXFilieraCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ImpresaXFilieraCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ImpresaXFilieraCollection(this);
		}

		//Get e Set
		public ImpresaXFilieraCollection CollectionObj
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
		public int SaveCollection(ImpresaXFilieraCollection collectionObj)
		{
			return ImpresaXFilieraDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ImpresaXFiliera impresaxfilieraObj)
		{
			return ImpresaXFilieraDAL.Save(_dbProviderObj, impresaxfilieraObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ImpresaXFilieraCollection collectionObj)
		{
			return ImpresaXFilieraDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ImpresaXFiliera impresaxfilieraObj)
		{
			return ImpresaXFilieraDAL.Delete(_dbProviderObj, impresaxfilieraObj);
		}

		//getById
		public ImpresaXFiliera GetById(IntNT IdImpresaXFilieraValue)
		{
			ImpresaXFiliera ImpresaXFilieraTemp = ImpresaXFilieraDAL.GetById(_dbProviderObj, IdImpresaXFilieraValue);
			if (ImpresaXFilieraTemp!=null) ImpresaXFilieraTemp.Provider = this;
			return ImpresaXFilieraTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ImpresaXFilieraCollection Select(IntNT IdimpresaxfilieraEqualThis, IntNT IdfilieraEqualThis, StringNT CuaaEqualThis, 
BoolNT FlagpartecipanteEqualThis, StringNT CodruolositraEqualThis, StringNT CodruolopartecipanteEqualThis, 
DecimalNT QuantitaEqualThis, IntNT UnitamisuraEqualThis, StringNT SistemaqualitaEqualThis, 
StringNT OperatoreEqualThis, BoolNT AmmessoEqualThis, IntNT IdprogrammazioneEqualThis)
		{
			ImpresaXFilieraCollection ImpresaXFilieraCollectionTemp = ImpresaXFilieraDAL.Select(_dbProviderObj, IdimpresaxfilieraEqualThis, IdfilieraEqualThis, CuaaEqualThis, 
FlagpartecipanteEqualThis, CodruolositraEqualThis, CodruolopartecipanteEqualThis, 
QuantitaEqualThis, UnitamisuraEqualThis, SistemaqualitaEqualThis, 
OperatoreEqualThis, AmmessoEqualThis, IdprogrammazioneEqualThis);
			ImpresaXFilieraCollectionTemp.Provider = this;
			return ImpresaXFilieraCollectionTemp;
		}

		//Find: popola la collection
		public ImpresaXFilieraCollection Find(IntNT IdfilieraEqualThis, StringNT CuaaLikeThis)
		{
			ImpresaXFilieraCollection ImpresaXFilieraCollectionTemp = ImpresaXFilieraDAL.Find(_dbProviderObj, IdfilieraEqualThis, CuaaLikeThis);
			ImpresaXFilieraCollectionTemp.Provider = this;
			return ImpresaXFilieraCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<IMPRESA_X_FILIERA>
  <ViewName>vIMPRESA_X_FILIERA</ViewName>
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
    <Find OrderBy="ORDER BY AMMESSO, CUAA">
      <ID_FILIERA>Equal</ID_FILIERA>
      <CUAA>Like</CUAA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</IMPRESA_X_FILIERA>
*/
