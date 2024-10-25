using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per Indirizzario
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IIndirizzarioProvider
	{
		int Save(Indirizzario IndirizzarioObj);
		int SaveCollection(IndirizzarioCollection collectionObj);
		int Delete(Indirizzario IndirizzarioObj);
		int DeleteCollection(IndirizzarioCollection collectionObj);
	}
	/// <summary>
	/// Summary description for Indirizzario
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class Indirizzario: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdIndirizzario;
		private NullTypes.IntNT _IdIndirizzo;
		private NullTypes.IntNT _IdPersona;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.StringNT _CodTipoSede;
		private NullTypes.DatetimeNT _DataInizioValidita;
		private NullTypes.DatetimeNT _DataFineValidita;
		private NullTypes.BoolNT _FlagAttivo;
		private NullTypes.StringNT _TipoSede;
		private NullTypes.StringNT _Via;
		private NullTypes.StringNT _Localita;
		private NullTypes.IntNT _IdComune;
		private NullTypes.StringNT _Telefono;
		private NullTypes.StringNT _Fax;
		private NullTypes.StringNT _Email;
		private NullTypes.StringNT _Denominazione;
		private NullTypes.StringNT _Comune;
		private NullTypes.StringNT _Cap;
		private NullTypes.StringNT _Istat;
		private NullTypes.StringNT _Sigla;
		private NullTypes.StringNT _Provincia;
		private NullTypes.StringNT _CodRegione;
		private NullTypes.StringNT _Regione;
		private NullTypes.StringNT _TipoArea;
		private NullTypes.StringNT _Pec;
		[NonSerialized] private IIndirizzarioProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IIndirizzarioProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public Indirizzario()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_INDIRIZZARIO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdIndirizzario
		{
			get { return _IdIndirizzario; }
			set {
				if (IdIndirizzario != value)
				{
					_IdIndirizzario = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_INDIRIZZO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdIndirizzo
		{
			get { return _IdIndirizzo; }
			set {
				if (IdIndirizzo != value)
				{
					_IdIndirizzo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_PERSONA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdPersona
		{
			get { return _IdPersona; }
			set {
				if (IdPersona != value)
				{
					_IdPersona = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_IMPRESA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdImpresa
		{
			get { return _IdImpresa; }
			set {
				if (IdImpresa != value)
				{
					_IdImpresa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_TIPO_SEDE
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT CodTipoSede
		{
			get { return _CodTipoSede; }
			set {
				if (CodTipoSede != value)
				{
					_CodTipoSede = value;
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
		/// Corrisponde al campo:FLAG_ATTIVO
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT FlagAttivo
		{
			get { return _FlagAttivo; }
			set {
				if (FlagAttivo != value)
				{
					_FlagAttivo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO_SEDE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT TipoSede
		{
			get { return _TipoSede; }
			set {
				if (TipoSede != value)
				{
					_TipoSede = value;
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
		/// Corrisponde al campo:LOCALITA
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT Localita
		{
			get { return _Localita; }
			set {
				if (Localita != value)
				{
					_Localita = value;
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
		/// Tipo sul db:VARCHAR(80)
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
		/// Tipo sul db:VARCHAR(80)
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
		/// Tipo sul db:VARCHAR(80)
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
		/// Corrisponde al campo:PEC
		/// Tipo sul db:VARCHAR(200)
		/// </summary>
		public NullTypes.StringNT Pec
		{
			get { return _Pec; }
			set {
				if (Pec != value)
				{
					_Pec = value;
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
	/// Summary description for IndirizzarioCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class IndirizzarioCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private IndirizzarioCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((Indirizzario) info.GetValue(i.ToString(),typeof(Indirizzario)));
			}
		}

		//Costruttore
		public IndirizzarioCollection()
		{
			this.ItemType = typeof(Indirizzario);
		}

		//Costruttore con provider
		public IndirizzarioCollection(IIndirizzarioProvider providerObj)
		{
			this.ItemType = typeof(Indirizzario);
			this.Provider = providerObj;
		}

		//Get e Set
		public new Indirizzario this[int index]
		{
			get { return (Indirizzario)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new IndirizzarioCollection GetChanges()
		{
			return (IndirizzarioCollection) base.GetChanges();
		}

		[NonSerialized] private IIndirizzarioProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IIndirizzarioProvider Provider
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
		public int Add(Indirizzario IndirizzarioObj)
		{
			if (IndirizzarioObj.Provider == null) IndirizzarioObj.Provider = this.Provider;
			return base.Add(IndirizzarioObj);
		}

		//AddCollection
		public void AddCollection(IndirizzarioCollection IndirizzarioCollectionObj)
		{
			foreach (Indirizzario IndirizzarioObj in IndirizzarioCollectionObj)
				this.Add(IndirizzarioObj);
		}

		//Insert
		public void Insert(int index, Indirizzario IndirizzarioObj)
		{
			if (IndirizzarioObj.Provider == null) IndirizzarioObj.Provider = this.Provider;
			base.Insert(index, IndirizzarioObj);
		}

		//CollectionGetById
		public Indirizzario CollectionGetById(NullTypes.IntNT IdIndirizzarioValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdIndirizzario == IdIndirizzarioValue))
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
		public IndirizzarioCollection SubSelect(NullTypes.IntNT IdIndirizzarioEqualThis, NullTypes.IntNT IdIndirizzoEqualThis, NullTypes.IntNT IdPersonaEqualThis, 
NullTypes.IntNT IdImpresaEqualThis, NullTypes.StringNT CodTipoSedeEqualThis, NullTypes.DatetimeNT DataInizioValiditaEqualThis, 
NullTypes.DatetimeNT DataFineValiditaEqualThis, NullTypes.BoolNT FlagAttivoEqualThis, NullTypes.StringNT TelefonoEqualThis, 
NullTypes.StringNT FaxEqualThis, NullTypes.StringNT EmailEqualThis, NullTypes.StringNT PecEqualThis)
		{
			IndirizzarioCollection IndirizzarioCollectionTemp = new IndirizzarioCollection();
			foreach (Indirizzario IndirizzarioItem in this)
			{
				if (((IdIndirizzarioEqualThis == null) || ((IndirizzarioItem.IdIndirizzario != null) && (IndirizzarioItem.IdIndirizzario.Value == IdIndirizzarioEqualThis.Value))) && ((IdIndirizzoEqualThis == null) || ((IndirizzarioItem.IdIndirizzo != null) && (IndirizzarioItem.IdIndirizzo.Value == IdIndirizzoEqualThis.Value))) && ((IdPersonaEqualThis == null) || ((IndirizzarioItem.IdPersona != null) && (IndirizzarioItem.IdPersona.Value == IdPersonaEqualThis.Value))) && 
((IdImpresaEqualThis == null) || ((IndirizzarioItem.IdImpresa != null) && (IndirizzarioItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((CodTipoSedeEqualThis == null) || ((IndirizzarioItem.CodTipoSede != null) && (IndirizzarioItem.CodTipoSede.Value == CodTipoSedeEqualThis.Value))) && ((DataInizioValiditaEqualThis == null) || ((IndirizzarioItem.DataInizioValidita != null) && (IndirizzarioItem.DataInizioValidita.Value == DataInizioValiditaEqualThis.Value))) && 
((DataFineValiditaEqualThis == null) || ((IndirizzarioItem.DataFineValidita != null) && (IndirizzarioItem.DataFineValidita.Value == DataFineValiditaEqualThis.Value))) && ((FlagAttivoEqualThis == null) || ((IndirizzarioItem.FlagAttivo != null) && (IndirizzarioItem.FlagAttivo.Value == FlagAttivoEqualThis.Value))) && ((TelefonoEqualThis == null) || ((IndirizzarioItem.Telefono != null) && (IndirizzarioItem.Telefono.Value == TelefonoEqualThis.Value))) && 
((FaxEqualThis == null) || ((IndirizzarioItem.Fax != null) && (IndirizzarioItem.Fax.Value == FaxEqualThis.Value))) && ((EmailEqualThis == null) || ((IndirizzarioItem.Email != null) && (IndirizzarioItem.Email.Value == EmailEqualThis.Value))) && ((PecEqualThis == null) || ((IndirizzarioItem.Pec != null) && (IndirizzarioItem.Pec.Value == PecEqualThis.Value))))
				{
					IndirizzarioCollectionTemp.Add(IndirizzarioItem);
				}
			}
			return IndirizzarioCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public IndirizzarioCollection FiltroAttivo(NullTypes.BoolNT FlagAttivoEqualThis)
		{
			IndirizzarioCollection IndirizzarioCollectionTemp = new IndirizzarioCollection();
			foreach (Indirizzario IndirizzarioItem in this)
			{
				if (((FlagAttivoEqualThis == null) || ((IndirizzarioItem.FlagAttivo != null) && (IndirizzarioItem.FlagAttivo.Value == FlagAttivoEqualThis.Value))))
				{
					IndirizzarioCollectionTemp.Add(IndirizzarioItem);
				}
			}
			return IndirizzarioCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for IndirizzarioDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class IndirizzarioDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, Indirizzario IndirizzarioObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdIndirizzario", IndirizzarioObj.IdIndirizzario);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdIndirizzo", IndirizzarioObj.IdIndirizzo);
			DbProvider.SetCmdParam(cmd,firstChar + "IdPersona", IndirizzarioObj.IdPersona);
			DbProvider.SetCmdParam(cmd,firstChar + "IdImpresa", IndirizzarioObj.IdImpresa);
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipoSede", IndirizzarioObj.CodTipoSede);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInizioValidita", IndirizzarioObj.DataInizioValidita);
			DbProvider.SetCmdParam(cmd,firstChar + "DataFineValidita", IndirizzarioObj.DataFineValidita);
			DbProvider.SetCmdParam(cmd,firstChar + "FlagAttivo", IndirizzarioObj.FlagAttivo);
			DbProvider.SetCmdParam(cmd,firstChar + "Telefono", IndirizzarioObj.Telefono);
			DbProvider.SetCmdParam(cmd,firstChar + "Fax", IndirizzarioObj.Fax);
			DbProvider.SetCmdParam(cmd,firstChar + "Email", IndirizzarioObj.Email);
			DbProvider.SetCmdParam(cmd,firstChar + "Pec", IndirizzarioObj.Pec);
		}
		//Insert
		private static int Insert(DbProvider db, Indirizzario IndirizzarioObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZIndirizzarioInsert", new string[] {"IdIndirizzo", "IdPersona", 
"IdImpresa", "CodTipoSede", "DataInizioValidita", 
"DataFineValidita", "FlagAttivo", 

"Telefono", "Fax", "Email", 



"Pec"}, new string[] {"int", "int", 
"int", "string", "DateTime", 
"DateTime", "bool", 

"string", "string", "string", 



"string"},"");
				CompileIUCmd(false, insertCmd,IndirizzarioObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				IndirizzarioObj.IdIndirizzario = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INDIRIZZARIO"]);
				IndirizzarioObj.DataInizioValidita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO_VALIDITA"]);
				IndirizzarioObj.FlagAttivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_ATTIVO"]);
				}
				IndirizzarioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IndirizzarioObj.IsDirty = false;
				IndirizzarioObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, Indirizzario IndirizzarioObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZIndirizzarioUpdate", new string[] {"IdIndirizzario", "IdIndirizzo", "IdPersona", 
"IdImpresa", "CodTipoSede", "DataInizioValidita", 
"DataFineValidita", "FlagAttivo", 

"Telefono", "Fax", "Email", 



"Pec"}, new string[] {"int", "int", "int", 
"int", "string", "DateTime", 
"DateTime", "bool", 

"string", "string", "string", 



"string"},"");
				CompileIUCmd(true, updateCmd,IndirizzarioObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				IndirizzarioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IndirizzarioObj.IsDirty = false;
				IndirizzarioObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, Indirizzario IndirizzarioObj)
		{
			switch (IndirizzarioObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, IndirizzarioObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, IndirizzarioObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,IndirizzarioObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, IndirizzarioCollection IndirizzarioCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZIndirizzarioUpdate", new string[] {"IdIndirizzario", "IdIndirizzo", "IdPersona", 
"IdImpresa", "CodTipoSede", "DataInizioValidita", 
"DataFineValidita", "FlagAttivo", 

"Telefono", "Fax", "Email", 



"Pec"}, new string[] {"int", "int", "int", 
"int", "string", "DateTime", 
"DateTime", "bool", 

"string", "string", "string", 



"string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZIndirizzarioInsert", new string[] {"IdIndirizzo", "IdPersona", 
"IdImpresa", "CodTipoSede", "DataInizioValidita", 
"DataFineValidita", "FlagAttivo", 

"Telefono", "Fax", "Email", 



"Pec"}, new string[] {"int", "int", 
"int", "string", "DateTime", 
"DateTime", "bool", 

"string", "string", "string", 



"string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZIndirizzarioDelete", new string[] {"IdIndirizzario"}, new string[] {"int"},"");
				for (int i = 0; i < IndirizzarioCollectionObj.Count; i++)
				{
					switch (IndirizzarioCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,IndirizzarioCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									IndirizzarioCollectionObj[i].IdIndirizzario = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INDIRIZZARIO"]);
									IndirizzarioCollectionObj[i].DataInizioValidita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO_VALIDITA"]);
									IndirizzarioCollectionObj[i].FlagAttivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_ATTIVO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,IndirizzarioCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (IndirizzarioCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdIndirizzario", (SiarLibrary.NullTypes.IntNT)IndirizzarioCollectionObj[i].IdIndirizzario);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < IndirizzarioCollectionObj.Count; i++)
				{
					if ((IndirizzarioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (IndirizzarioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						IndirizzarioCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						IndirizzarioCollectionObj[i].IsDirty = false;
						IndirizzarioCollectionObj[i].IsPersistent = true;
					}
					if ((IndirizzarioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						IndirizzarioCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						IndirizzarioCollectionObj[i].IsDirty = false;
						IndirizzarioCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, Indirizzario IndirizzarioObj)
		{
			int returnValue = 0;
			if (IndirizzarioObj.IsPersistent) 
			{
				returnValue = Delete(db, IndirizzarioObj.IdIndirizzario);
			}
			IndirizzarioObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			IndirizzarioObj.IsDirty = false;
			IndirizzarioObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdIndirizzarioValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZIndirizzarioDelete", new string[] {"IdIndirizzario"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdIndirizzario", (SiarLibrary.NullTypes.IntNT)IdIndirizzarioValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, IndirizzarioCollection IndirizzarioCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZIndirizzarioDelete", new string[] {"IdIndirizzario"}, new string[] {"int"},"");
				for (int i = 0; i < IndirizzarioCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdIndirizzario", IndirizzarioCollectionObj[i].IdIndirizzario);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < IndirizzarioCollectionObj.Count; i++)
				{
					if ((IndirizzarioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (IndirizzarioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						IndirizzarioCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						IndirizzarioCollectionObj[i].IsDirty = false;
						IndirizzarioCollectionObj[i].IsPersistent = false;
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
		public static Indirizzario GetById(DbProvider db, int IdIndirizzarioValue)
		{
			Indirizzario IndirizzarioObj = null;
			IDbCommand readCmd = db.InitCmd( "ZIndirizzarioGetById", new string[] {"IdIndirizzario"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdIndirizzario", (SiarLibrary.NullTypes.IntNT)IdIndirizzarioValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				IndirizzarioObj = GetFromDatareader(db);
				IndirizzarioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IndirizzarioObj.IsDirty = false;
				IndirizzarioObj.IsPersistent = true;
			}
			db.Close();
			return IndirizzarioObj;
		}

		//getFromDatareader
		public static Indirizzario GetFromDatareader(DbProvider db)
		{
			Indirizzario IndirizzarioObj = new Indirizzario();
			IndirizzarioObj.IdIndirizzario = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INDIRIZZARIO"]);
			IndirizzarioObj.IdIndirizzo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INDIRIZZO"]);
			IndirizzarioObj.IdPersona = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PERSONA"]);
			IndirizzarioObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			IndirizzarioObj.CodTipoSede = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_SEDE"]);
			IndirizzarioObj.DataInizioValidita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO_VALIDITA"]);
			IndirizzarioObj.DataFineValidita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE_VALIDITA"]);
			IndirizzarioObj.FlagAttivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_ATTIVO"]);
			IndirizzarioObj.TipoSede = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_SEDE"]);
			IndirizzarioObj.Via = new SiarLibrary.NullTypes.StringNT(db.DataReader["VIA"]);
			IndirizzarioObj.Localita = new SiarLibrary.NullTypes.StringNT(db.DataReader["LOCALITA"]);
			IndirizzarioObj.IdComune = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COMUNE"]);
			IndirizzarioObj.Telefono = new SiarLibrary.NullTypes.StringNT(db.DataReader["TELEFONO"]);
			IndirizzarioObj.Fax = new SiarLibrary.NullTypes.StringNT(db.DataReader["FAX"]);
			IndirizzarioObj.Email = new SiarLibrary.NullTypes.StringNT(db.DataReader["EMAIL"]);
			IndirizzarioObj.Denominazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DENOMINAZIONE"]);
			IndirizzarioObj.Comune = new SiarLibrary.NullTypes.StringNT(db.DataReader["COMUNE"]);
			IndirizzarioObj.Cap = new SiarLibrary.NullTypes.StringNT(db.DataReader["CAP"]);
			IndirizzarioObj.Istat = new SiarLibrary.NullTypes.StringNT(db.DataReader["ISTAT"]);
			IndirizzarioObj.Sigla = new SiarLibrary.NullTypes.StringNT(db.DataReader["SIGLA"]);
			IndirizzarioObj.Provincia = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROVINCIA"]);
			IndirizzarioObj.CodRegione = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_REGIONE"]);
			IndirizzarioObj.Regione = new SiarLibrary.NullTypes.StringNT(db.DataReader["REGIONE"]);
			IndirizzarioObj.TipoArea = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_AREA"]);
			IndirizzarioObj.Pec = new SiarLibrary.NullTypes.StringNT(db.DataReader["PEC"]);
			IndirizzarioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			IndirizzarioObj.IsDirty = false;
			IndirizzarioObj.IsPersistent = true;
			return IndirizzarioObj;
		}

		//Find Select

		public static IndirizzarioCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdIndirizzarioEqualThis, SiarLibrary.NullTypes.IntNT IdIndirizzoEqualThis, SiarLibrary.NullTypes.IntNT IdPersonaEqualThis, 
SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.StringNT CodTipoSedeEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInizioValiditaEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataFineValiditaEqualThis, SiarLibrary.NullTypes.BoolNT FlagAttivoEqualThis, SiarLibrary.NullTypes.StringNT TelefonoEqualThis, 
SiarLibrary.NullTypes.StringNT FaxEqualThis, SiarLibrary.NullTypes.StringNT EmailEqualThis, SiarLibrary.NullTypes.StringNT PecEqualThis)

		{

			IndirizzarioCollection IndirizzarioCollectionObj = new IndirizzarioCollection();

			IDbCommand findCmd = db.InitCmd("Zindirizzariofindselect", new string[] {"IdIndirizzarioequalthis", "IdIndirizzoequalthis", "IdPersonaequalthis", 
"IdImpresaequalthis", "CodTipoSedeequalthis", "DataInizioValiditaequalthis", 
"DataFineValiditaequalthis", "FlagAttivoequalthis", "Telefonoequalthis", 
"Faxequalthis", "Emailequalthis", "Pecequalthis"}, new string[] {"int", "int", "int", 
"int", "string", "DateTime", 
"DateTime", "bool", "string", 
"string", "string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdIndirizzarioequalthis", IdIndirizzarioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdIndirizzoequalthis", IdIndirizzoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPersonaequalthis", IdPersonaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoSedeequalthis", CodTipoSedeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInizioValiditaequalthis", DataInizioValiditaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataFineValiditaequalthis", DataFineValiditaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FlagAttivoequalthis", FlagAttivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Telefonoequalthis", TelefonoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Faxequalthis", FaxEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Emailequalthis", EmailEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Pecequalthis", PecEqualThis);
			Indirizzario IndirizzarioObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				IndirizzarioObj = GetFromDatareader(db);
				IndirizzarioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IndirizzarioObj.IsDirty = false;
				IndirizzarioObj.IsPersistent = true;
				IndirizzarioCollectionObj.Add(IndirizzarioObj);
			}
			db.Close();
			return IndirizzarioCollectionObj;
		}

		//Find Find

		public static IndirizzarioCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdIndirizzoEqualThis, SiarLibrary.NullTypes.IntNT IdPersonaEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, 
SiarLibrary.NullTypes.StringNT CodTipoSedeEqualThis, SiarLibrary.NullTypes.IntNT IdComuneEqualThis, SiarLibrary.NullTypes.StringNT SiglaEqualThis)

		{

			IndirizzarioCollection IndirizzarioCollectionObj = new IndirizzarioCollection();

			IDbCommand findCmd = db.InitCmd("Zindirizzariofindfind", new string[] {"IdIndirizzoequalthis", "IdPersonaequalthis", "IdImpresaequalthis", 
"CodTipoSedeequalthis", "IdComuneequalthis", "Siglaequalthis"}, new string[] {"int", "int", "int", 
"string", "int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdIndirizzoequalthis", IdIndirizzoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPersonaequalthis", IdPersonaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoSedeequalthis", CodTipoSedeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdComuneequalthis", IdComuneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Siglaequalthis", SiglaEqualThis);
			Indirizzario IndirizzarioObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				IndirizzarioObj = GetFromDatareader(db);
				IndirizzarioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IndirizzarioObj.IsDirty = false;
				IndirizzarioObj.IsPersistent = true;
				IndirizzarioCollectionObj.Add(IndirizzarioObj);
			}
			db.Close();
			return IndirizzarioCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for IndirizzarioCollectionProvider:IIndirizzarioProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class IndirizzarioCollectionProvider : IIndirizzarioProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di Indirizzario
		protected IndirizzarioCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public IndirizzarioCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new IndirizzarioCollection(this);
		}

		//Costruttore 2: popola la collection
		public IndirizzarioCollectionProvider(IntNT IdindirizzoEqualThis, IntNT IdpersonaEqualThis, IntNT IdimpresaEqualThis, 
StringNT CodtiposedeEqualThis, IntNT IdcomuneEqualThis, StringNT SiglaEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdindirizzoEqualThis, IdpersonaEqualThis, IdimpresaEqualThis, 
CodtiposedeEqualThis, IdcomuneEqualThis, SiglaEqualThis);
		}

		//Costruttore3: ha in input indirizzarioCollectionObj - non popola la collection
		public IndirizzarioCollectionProvider(IndirizzarioCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public IndirizzarioCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new IndirizzarioCollection(this);
		}

		//Get e Set
		public IndirizzarioCollection CollectionObj
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
		public int SaveCollection(IndirizzarioCollection collectionObj)
		{
			return IndirizzarioDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(Indirizzario indirizzarioObj)
		{
			return IndirizzarioDAL.Save(_dbProviderObj, indirizzarioObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(IndirizzarioCollection collectionObj)
		{
			return IndirizzarioDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(Indirizzario indirizzarioObj)
		{
			return IndirizzarioDAL.Delete(_dbProviderObj, indirizzarioObj);
		}

		//getById
		public Indirizzario GetById(IntNT IdIndirizzarioValue)
		{
			Indirizzario IndirizzarioTemp = IndirizzarioDAL.GetById(_dbProviderObj, IdIndirizzarioValue);
			if (IndirizzarioTemp!=null) IndirizzarioTemp.Provider = this;
			return IndirizzarioTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public IndirizzarioCollection Select(IntNT IdindirizzarioEqualThis, IntNT IdindirizzoEqualThis, IntNT IdpersonaEqualThis, 
IntNT IdimpresaEqualThis, StringNT CodtiposedeEqualThis, DatetimeNT DatainiziovaliditaEqualThis, 
DatetimeNT DatafinevaliditaEqualThis, BoolNT FlagattivoEqualThis, StringNT TelefonoEqualThis, 
StringNT FaxEqualThis, StringNT EmailEqualThis, StringNT PecEqualThis)
		{
			IndirizzarioCollection IndirizzarioCollectionTemp = IndirizzarioDAL.Select(_dbProviderObj, IdindirizzarioEqualThis, IdindirizzoEqualThis, IdpersonaEqualThis, 
IdimpresaEqualThis, CodtiposedeEqualThis, DatainiziovaliditaEqualThis, 
DatafinevaliditaEqualThis, FlagattivoEqualThis, TelefonoEqualThis, 
FaxEqualThis, EmailEqualThis, PecEqualThis);
			IndirizzarioCollectionTemp.Provider = this;
			return IndirizzarioCollectionTemp;
		}

		//Find: popola la collection
		public IndirizzarioCollection Find(IntNT IdindirizzoEqualThis, IntNT IdpersonaEqualThis, IntNT IdimpresaEqualThis, 
StringNT CodtiposedeEqualThis, IntNT IdcomuneEqualThis, StringNT SiglaEqualThis)
		{
			IndirizzarioCollection IndirizzarioCollectionTemp = IndirizzarioDAL.Find(_dbProviderObj, IdindirizzoEqualThis, IdpersonaEqualThis, IdimpresaEqualThis, 
CodtiposedeEqualThis, IdcomuneEqualThis, SiglaEqualThis);
			IndirizzarioCollectionTemp.Provider = this;
			return IndirizzarioCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<INDIRIZZARIO>
  <ViewName>vINDIRIZZARIO</ViewName>
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
    <Find OrderBy="ORDER BY DATA_INIZIO_VALIDITA DESC">
      <ID_INDIRIZZO>Equal</ID_INDIRIZZO>
      <ID_PERSONA>Equal</ID_PERSONA>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <COD_TIPO_SEDE>Equal</COD_TIPO_SEDE>
      <ID_COMUNE>Equal</ID_COMUNE>
      <SIGLA>Equal</SIGLA>
    </Find>
  </Finds>
  <Filters>
    <FiltroAttivo>
      <FLAG_ATTIVO>Equal</FLAG_ATTIVO>
    </FiltroAttivo>
  </Filters>
  <externalFields />
  <AddedFkFields />
</INDIRIZZARIO>
*/
