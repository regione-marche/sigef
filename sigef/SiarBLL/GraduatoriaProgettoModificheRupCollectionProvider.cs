using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per GraduatoriaProgettoModificheRup
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IGraduatoriaProgettoModificheRupProvider
	{
		int Save(GraduatoriaProgettoModificheRup GraduatoriaProgettoModificheRupObj);
		int SaveCollection(GraduatoriaProgettoModificheRupCollection collectionObj);
		int Delete(GraduatoriaProgettoModificheRup GraduatoriaProgettoModificheRupObj);
		int DeleteCollection(GraduatoriaProgettoModificheRupCollection collectionObj);
	}
	/// <summary>
	/// Summary description for GraduatoriaProgettoModificheRup
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class GraduatoriaProgettoModificheRup: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdGraduatoriaProgettiModificheRup;
		private NullTypes.StringNT _CfInserimento;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.StringNT _CfModifica;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.IntNT _IdBando;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdAtto;
		private NullTypes.StringNT _Note;
		private NullTypes.DecimalNT _CostoTotalePrecedente;
		private NullTypes.DecimalNT _CostoTotaleNuovo;
		private NullTypes.DecimalNT _ContributoTotalePrecedente;
		private NullTypes.DecimalNT _ContributoTotaleNuovo;
		private NullTypes.IntNT _NumeroAtto;
		private NullTypes.DatetimeNT _DataAttoRecupero;
		private NullTypes.StringNT _RegistroAttoRecupero;
		private NullTypes.DecimalNT _DifferenzaCostoTotale;
		private NullTypes.DecimalNT _DifferenzaContributoTotale;
		[NonSerialized] private IGraduatoriaProgettoModificheRupProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IGraduatoriaProgettoModificheRupProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public GraduatoriaProgettoModificheRup()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_GRADUATORIA_PROGETTI_MODIFICHE_RUP
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdGraduatoriaProgettiModificheRup
		{
			get { return _IdGraduatoriaProgettiModificheRup; }
			set {
				if (IdGraduatoriaProgettiModificheRup != value)
				{
					_IdGraduatoriaProgettiModificheRup = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_INSERIMENTO
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT CfInserimento
		{
			get { return _CfInserimento; }
			set {
				if (CfInserimento != value)
				{
					_CfInserimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_INSERIMENTO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataInserimento
		{
			get { return _DataInserimento; }
			set {
				if (DataInserimento != value)
				{
					_DataInserimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_MODIFICA
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT CfModifica
		{
			get { return _CfModifica; }
			set {
				if (CfModifica != value)
				{
					_CfModifica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_MODIFICA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataModifica
		{
			get { return _DataModifica; }
			set {
				if (DataModifica != value)
				{
					_DataModifica = value;
					SetDirtyFlag();
				}
			}
		}

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
		/// Corrisponde al campo:ID_ATTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdAtto
		{
			get { return _IdAtto; }
			set {
				if (IdAtto != value)
				{
					_IdAtto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOTE
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT Note
		{
			get { return _Note; }
			set {
				if (Note != value)
				{
					_Note = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COSTO_TOTALE_PRECEDENTE
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT CostoTotalePrecedente
		{
			get { return _CostoTotalePrecedente; }
			set {
				if (CostoTotalePrecedente != value)
				{
					_CostoTotalePrecedente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COSTO_TOTALE_NUOVO
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT CostoTotaleNuovo
		{
			get { return _CostoTotaleNuovo; }
			set {
				if (CostoTotaleNuovo != value)
				{
					_CostoTotaleNuovo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTRIBUTO_TOTALE_PRECEDENTE
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ContributoTotalePrecedente
		{
			get { return _ContributoTotalePrecedente; }
			set {
				if (ContributoTotalePrecedente != value)
				{
					_ContributoTotalePrecedente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTRIBUTO_TOTALE_NUOVO
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ContributoTotaleNuovo
		{
			get { return _ContributoTotaleNuovo; }
			set {
				if (ContributoTotaleNuovo != value)
				{
					_ContributoTotaleNuovo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NUMERO_ATTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT NumeroAtto
		{
			get { return _NumeroAtto; }
			set {
				if (NumeroAtto != value)
				{
					_NumeroAtto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_ATTO_RECUPERO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataAttoRecupero
		{
			get { return _DataAttoRecupero; }
			set {
				if (DataAttoRecupero != value)
				{
					_DataAttoRecupero = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:REGISTRO_ATTO_RECUPERO
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT RegistroAttoRecupero
		{
			get { return _RegistroAttoRecupero; }
			set {
				if (RegistroAttoRecupero != value)
				{
					_RegistroAttoRecupero = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DIFFERENZA_COSTO_TOTALE
		/// Tipo sul db:DECIMAL(19,2)
		/// </summary>
		public NullTypes.DecimalNT DifferenzaCostoTotale
		{
			get { return _DifferenzaCostoTotale; }
			set {
				if (DifferenzaCostoTotale != value)
				{
					_DifferenzaCostoTotale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DIFFERENZA_CONTRIBUTO_TOTALE
		/// Tipo sul db:DECIMAL(19,2)
		/// </summary>
		public NullTypes.DecimalNT DifferenzaContributoTotale
		{
			get { return _DifferenzaContributoTotale; }
			set {
				if (DifferenzaContributoTotale != value)
				{
					_DifferenzaContributoTotale = value;
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
	/// Summary description for GraduatoriaProgettoModificheRupCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class GraduatoriaProgettoModificheRupCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private GraduatoriaProgettoModificheRupCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((GraduatoriaProgettoModificheRup) info.GetValue(i.ToString(),typeof(GraduatoriaProgettoModificheRup)));
			}
		}

		//Costruttore
		public GraduatoriaProgettoModificheRupCollection()
		{
			this.ItemType = typeof(GraduatoriaProgettoModificheRup);
		}

		//Costruttore con provider
		public GraduatoriaProgettoModificheRupCollection(IGraduatoriaProgettoModificheRupProvider providerObj)
		{
			this.ItemType = typeof(GraduatoriaProgettoModificheRup);
			this.Provider = providerObj;
		}

		//Get e Set
		public new GraduatoriaProgettoModificheRup this[int index]
		{
			get { return (GraduatoriaProgettoModificheRup)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new GraduatoriaProgettoModificheRupCollection GetChanges()
		{
			return (GraduatoriaProgettoModificheRupCollection) base.GetChanges();
		}

		[NonSerialized] private IGraduatoriaProgettoModificheRupProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IGraduatoriaProgettoModificheRupProvider Provider
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
		public int Add(GraduatoriaProgettoModificheRup GraduatoriaProgettoModificheRupObj)
		{
			if (GraduatoriaProgettoModificheRupObj.Provider == null) GraduatoriaProgettoModificheRupObj.Provider = this.Provider;
			return base.Add(GraduatoriaProgettoModificheRupObj);
		}

		//AddCollection
		public void AddCollection(GraduatoriaProgettoModificheRupCollection GraduatoriaProgettoModificheRupCollectionObj)
		{
			foreach (GraduatoriaProgettoModificheRup GraduatoriaProgettoModificheRupObj in GraduatoriaProgettoModificheRupCollectionObj)
				this.Add(GraduatoriaProgettoModificheRupObj);
		}

		//Insert
		public void Insert(int index, GraduatoriaProgettoModificheRup GraduatoriaProgettoModificheRupObj)
		{
			if (GraduatoriaProgettoModificheRupObj.Provider == null) GraduatoriaProgettoModificheRupObj.Provider = this.Provider;
			base.Insert(index, GraduatoriaProgettoModificheRupObj);
		}

		//CollectionGetById
		public GraduatoriaProgettoModificheRup CollectionGetById(NullTypes.IntNT IdGraduatoriaProgettiModificheRupValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdGraduatoriaProgettiModificheRup == IdGraduatoriaProgettiModificheRupValue))
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
		public GraduatoriaProgettoModificheRupCollection SubSelect(NullTypes.IntNT IdGraduatoriaProgettiModificheRupEqualThis, NullTypes.StringNT CfInserimentoEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, 
NullTypes.StringNT CfModificaEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.IntNT IdBandoEqualThis, 
NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdAttoEqualThis, NullTypes.StringNT NoteEqualThis, 
NullTypes.DecimalNT CostoTotalePrecedenteEqualThis, NullTypes.DecimalNT CostoTotaleNuovoEqualThis, NullTypes.DecimalNT ContributoTotalePrecedenteEqualThis, 
NullTypes.DecimalNT ContributoTotaleNuovoEqualThis)
		{
			GraduatoriaProgettoModificheRupCollection GraduatoriaProgettoModificheRupCollectionTemp = new GraduatoriaProgettoModificheRupCollection();
			foreach (GraduatoriaProgettoModificheRup GraduatoriaProgettoModificheRupItem in this)
			{
				if (((IdGraduatoriaProgettiModificheRupEqualThis == null) || ((GraduatoriaProgettoModificheRupItem.IdGraduatoriaProgettiModificheRup != null) && (GraduatoriaProgettoModificheRupItem.IdGraduatoriaProgettiModificheRup.Value == IdGraduatoriaProgettiModificheRupEqualThis.Value))) && ((CfInserimentoEqualThis == null) || ((GraduatoriaProgettoModificheRupItem.CfInserimento != null) && (GraduatoriaProgettoModificheRupItem.CfInserimento.Value == CfInserimentoEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((GraduatoriaProgettoModificheRupItem.DataInserimento != null) && (GraduatoriaProgettoModificheRupItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && 
((CfModificaEqualThis == null) || ((GraduatoriaProgettoModificheRupItem.CfModifica != null) && (GraduatoriaProgettoModificheRupItem.CfModifica.Value == CfModificaEqualThis.Value))) && ((DataModificaEqualThis == null) || ((GraduatoriaProgettoModificheRupItem.DataModifica != null) && (GraduatoriaProgettoModificheRupItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((IdBandoEqualThis == null) || ((GraduatoriaProgettoModificheRupItem.IdBando != null) && (GraduatoriaProgettoModificheRupItem.IdBando.Value == IdBandoEqualThis.Value))) && 
((IdProgettoEqualThis == null) || ((GraduatoriaProgettoModificheRupItem.IdProgetto != null) && (GraduatoriaProgettoModificheRupItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdAttoEqualThis == null) || ((GraduatoriaProgettoModificheRupItem.IdAtto != null) && (GraduatoriaProgettoModificheRupItem.IdAtto.Value == IdAttoEqualThis.Value))) && ((NoteEqualThis == null) || ((GraduatoriaProgettoModificheRupItem.Note != null) && (GraduatoriaProgettoModificheRupItem.Note.Value == NoteEqualThis.Value))) && 
((CostoTotalePrecedenteEqualThis == null) || ((GraduatoriaProgettoModificheRupItem.CostoTotalePrecedente != null) && (GraduatoriaProgettoModificheRupItem.CostoTotalePrecedente.Value == CostoTotalePrecedenteEqualThis.Value))) && ((CostoTotaleNuovoEqualThis == null) || ((GraduatoriaProgettoModificheRupItem.CostoTotaleNuovo != null) && (GraduatoriaProgettoModificheRupItem.CostoTotaleNuovo.Value == CostoTotaleNuovoEqualThis.Value))) && ((ContributoTotalePrecedenteEqualThis == null) || ((GraduatoriaProgettoModificheRupItem.ContributoTotalePrecedente != null) && (GraduatoriaProgettoModificheRupItem.ContributoTotalePrecedente.Value == ContributoTotalePrecedenteEqualThis.Value))) && 
((ContributoTotaleNuovoEqualThis == null) || ((GraduatoriaProgettoModificheRupItem.ContributoTotaleNuovo != null) && (GraduatoriaProgettoModificheRupItem.ContributoTotaleNuovo.Value == ContributoTotaleNuovoEqualThis.Value))))
				{
					GraduatoriaProgettoModificheRupCollectionTemp.Add(GraduatoriaProgettoModificheRupItem);
				}
			}
			return GraduatoriaProgettoModificheRupCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for GraduatoriaProgettoModificheRupDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class GraduatoriaProgettoModificheRupDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, GraduatoriaProgettoModificheRup GraduatoriaProgettoModificheRupObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdGraduatoriaProgettiModificheRup", GraduatoriaProgettoModificheRupObj.IdGraduatoriaProgettiModificheRup);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "CfInserimento", GraduatoriaProgettoModificheRupObj.CfInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", GraduatoriaProgettoModificheRupObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "CfModifica", GraduatoriaProgettoModificheRupObj.CfModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", GraduatoriaProgettoModificheRupObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", GraduatoriaProgettoModificheRupObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", GraduatoriaProgettoModificheRupObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdAtto", GraduatoriaProgettoModificheRupObj.IdAtto);
			DbProvider.SetCmdParam(cmd,firstChar + "Note", GraduatoriaProgettoModificheRupObj.Note);
			DbProvider.SetCmdParam(cmd,firstChar + "CostoTotalePrecedente", GraduatoriaProgettoModificheRupObj.CostoTotalePrecedente);
			DbProvider.SetCmdParam(cmd,firstChar + "CostoTotaleNuovo", GraduatoriaProgettoModificheRupObj.CostoTotaleNuovo);
			DbProvider.SetCmdParam(cmd,firstChar + "ContributoTotalePrecedente", GraduatoriaProgettoModificheRupObj.ContributoTotalePrecedente);
			DbProvider.SetCmdParam(cmd,firstChar + "ContributoTotaleNuovo", GraduatoriaProgettoModificheRupObj.ContributoTotaleNuovo);
		}
		//Insert
		private static int Insert(DbProvider db, GraduatoriaProgettoModificheRup GraduatoriaProgettoModificheRupObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZGraduatoriaProgettoModificheRupInsert", new string[] {"CfInserimento", "DataInserimento", 
"CfModifica", "DataModifica", "IdBando", 
"IdProgetto", "IdAtto", "Note", 
"CostoTotalePrecedente", "CostoTotaleNuovo", "ContributoTotalePrecedente", 
"ContributoTotaleNuovo", }, new string[] {"string", "DateTime", 
"string", "DateTime", "int", 
"int", "int", "string", 
"decimal", "decimal", "decimal", 
"decimal", },"");
				CompileIUCmd(false, insertCmd,GraduatoriaProgettoModificheRupObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				GraduatoriaProgettoModificheRupObj.IdGraduatoriaProgettiModificheRup = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_GRADUATORIA_PROGETTI_MODIFICHE_RUP"]);
				}
				GraduatoriaProgettoModificheRupObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				GraduatoriaProgettoModificheRupObj.IsDirty = false;
				GraduatoriaProgettoModificheRupObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, GraduatoriaProgettoModificheRup GraduatoriaProgettoModificheRupObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZGraduatoriaProgettoModificheRupUpdate", new string[] {"IdGraduatoriaProgettiModificheRup", "CfInserimento", "DataInserimento", 
"CfModifica", "DataModifica", "IdBando", 
"IdProgetto", "IdAtto", "Note", 
"CostoTotalePrecedente", "CostoTotaleNuovo", "ContributoTotalePrecedente", 
"ContributoTotaleNuovo", }, new string[] {"int", "string", "DateTime", 
"string", "DateTime", "int", 
"int", "int", "string", 
"decimal", "decimal", "decimal", 
"decimal", },"");
				CompileIUCmd(true, updateCmd,GraduatoriaProgettoModificheRupObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					GraduatoriaProgettoModificheRupObj.DataModifica = d;
				}
				GraduatoriaProgettoModificheRupObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				GraduatoriaProgettoModificheRupObj.IsDirty = false;
				GraduatoriaProgettoModificheRupObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, GraduatoriaProgettoModificheRup GraduatoriaProgettoModificheRupObj)
		{
			switch (GraduatoriaProgettoModificheRupObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, GraduatoriaProgettoModificheRupObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, GraduatoriaProgettoModificheRupObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,GraduatoriaProgettoModificheRupObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, GraduatoriaProgettoModificheRupCollection GraduatoriaProgettoModificheRupCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZGraduatoriaProgettoModificheRupUpdate", new string[] {"IdGraduatoriaProgettiModificheRup", "CfInserimento", "DataInserimento", 
"CfModifica", "DataModifica", "IdBando", 
"IdProgetto", "IdAtto", "Note", 
"CostoTotalePrecedente", "CostoTotaleNuovo", "ContributoTotalePrecedente", 
"ContributoTotaleNuovo", }, new string[] {"int", "string", "DateTime", 
"string", "DateTime", "int", 
"int", "int", "string", 
"decimal", "decimal", "decimal", 
"decimal", },"");
				IDbCommand insertCmd = db.InitCmd( "ZGraduatoriaProgettoModificheRupInsert", new string[] {"CfInserimento", "DataInserimento", 
"CfModifica", "DataModifica", "IdBando", 
"IdProgetto", "IdAtto", "Note", 
"CostoTotalePrecedente", "CostoTotaleNuovo", "ContributoTotalePrecedente", 
"ContributoTotaleNuovo", }, new string[] {"string", "DateTime", 
"string", "DateTime", "int", 
"int", "int", "string", 
"decimal", "decimal", "decimal", 
"decimal", },"");
				IDbCommand deleteCmd = db.InitCmd( "ZGraduatoriaProgettoModificheRupDelete", new string[] {"IdGraduatoriaProgettiModificheRup"}, new string[] {"int"},"");
				for (int i = 0; i < GraduatoriaProgettoModificheRupCollectionObj.Count; i++)
				{
					switch (GraduatoriaProgettoModificheRupCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,GraduatoriaProgettoModificheRupCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									GraduatoriaProgettoModificheRupCollectionObj[i].IdGraduatoriaProgettiModificheRup = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_GRADUATORIA_PROGETTI_MODIFICHE_RUP"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,GraduatoriaProgettoModificheRupCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									GraduatoriaProgettoModificheRupCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (GraduatoriaProgettoModificheRupCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdGraduatoriaProgettiModificheRup", (SiarLibrary.NullTypes.IntNT)GraduatoriaProgettoModificheRupCollectionObj[i].IdGraduatoriaProgettiModificheRup);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < GraduatoriaProgettoModificheRupCollectionObj.Count; i++)
				{
					if ((GraduatoriaProgettoModificheRupCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (GraduatoriaProgettoModificheRupCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						GraduatoriaProgettoModificheRupCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						GraduatoriaProgettoModificheRupCollectionObj[i].IsDirty = false;
						GraduatoriaProgettoModificheRupCollectionObj[i].IsPersistent = true;
					}
					if ((GraduatoriaProgettoModificheRupCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						GraduatoriaProgettoModificheRupCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						GraduatoriaProgettoModificheRupCollectionObj[i].IsDirty = false;
						GraduatoriaProgettoModificheRupCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, GraduatoriaProgettoModificheRup GraduatoriaProgettoModificheRupObj)
		{
			int returnValue = 0;
			if (GraduatoriaProgettoModificheRupObj.IsPersistent) 
			{
				returnValue = Delete(db, GraduatoriaProgettoModificheRupObj.IdGraduatoriaProgettiModificheRup);
			}
			GraduatoriaProgettoModificheRupObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			GraduatoriaProgettoModificheRupObj.IsDirty = false;
			GraduatoriaProgettoModificheRupObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdGraduatoriaProgettiModificheRupValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZGraduatoriaProgettoModificheRupDelete", new string[] {"IdGraduatoriaProgettiModificheRup"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdGraduatoriaProgettiModificheRup", (SiarLibrary.NullTypes.IntNT)IdGraduatoriaProgettiModificheRupValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, GraduatoriaProgettoModificheRupCollection GraduatoriaProgettoModificheRupCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZGraduatoriaProgettoModificheRupDelete", new string[] {"IdGraduatoriaProgettiModificheRup"}, new string[] {"int"},"");
				for (int i = 0; i < GraduatoriaProgettoModificheRupCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdGraduatoriaProgettiModificheRup", GraduatoriaProgettoModificheRupCollectionObj[i].IdGraduatoriaProgettiModificheRup);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < GraduatoriaProgettoModificheRupCollectionObj.Count; i++)
				{
					if ((GraduatoriaProgettoModificheRupCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (GraduatoriaProgettoModificheRupCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						GraduatoriaProgettoModificheRupCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						GraduatoriaProgettoModificheRupCollectionObj[i].IsDirty = false;
						GraduatoriaProgettoModificheRupCollectionObj[i].IsPersistent = false;
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
		public static GraduatoriaProgettoModificheRup GetById(DbProvider db, int IdGraduatoriaProgettiModificheRupValue)
		{
			GraduatoriaProgettoModificheRup GraduatoriaProgettoModificheRupObj = null;
			IDbCommand readCmd = db.InitCmd( "ZGraduatoriaProgettoModificheRupGetById", new string[] {"IdGraduatoriaProgettiModificheRup"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdGraduatoriaProgettiModificheRup", (SiarLibrary.NullTypes.IntNT)IdGraduatoriaProgettiModificheRupValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				GraduatoriaProgettoModificheRupObj = GetFromDatareader(db);
				GraduatoriaProgettoModificheRupObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				GraduatoriaProgettoModificheRupObj.IsDirty = false;
				GraduatoriaProgettoModificheRupObj.IsPersistent = true;
			}
			db.Close();
			return GraduatoriaProgettoModificheRupObj;
		}

		//getFromDatareader
		public static GraduatoriaProgettoModificheRup GetFromDatareader(DbProvider db)
		{
			GraduatoriaProgettoModificheRup GraduatoriaProgettoModificheRupObj = new GraduatoriaProgettoModificheRup();
			GraduatoriaProgettoModificheRupObj.IdGraduatoriaProgettiModificheRup = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_GRADUATORIA_PROGETTI_MODIFICHE_RUP"]);
			GraduatoriaProgettoModificheRupObj.CfInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_INSERIMENTO"]);
			GraduatoriaProgettoModificheRupObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			GraduatoriaProgettoModificheRupObj.CfModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_MODIFICA"]);
			GraduatoriaProgettoModificheRupObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			GraduatoriaProgettoModificheRupObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			GraduatoriaProgettoModificheRupObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			GraduatoriaProgettoModificheRupObj.IdAtto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ATTO"]);
			GraduatoriaProgettoModificheRupObj.Note = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE"]);
			GraduatoriaProgettoModificheRupObj.CostoTotalePrecedente = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["COSTO_TOTALE_PRECEDENTE"]);
			GraduatoriaProgettoModificheRupObj.CostoTotaleNuovo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["COSTO_TOTALE_NUOVO"]);
			GraduatoriaProgettoModificheRupObj.ContributoTotalePrecedente = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_TOTALE_PRECEDENTE"]);
			GraduatoriaProgettoModificheRupObj.ContributoTotaleNuovo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_TOTALE_NUOVO"]);
			GraduatoriaProgettoModificheRupObj.NumeroAtto = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMERO_ATTO"]);
			GraduatoriaProgettoModificheRupObj.DataAttoRecupero = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_ATTO_RECUPERO"]);
			GraduatoriaProgettoModificheRupObj.RegistroAttoRecupero = new SiarLibrary.NullTypes.StringNT(db.DataReader["REGISTRO_ATTO_RECUPERO"]);
			GraduatoriaProgettoModificheRupObj.DifferenzaCostoTotale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["DIFFERENZA_COSTO_TOTALE"]);
			GraduatoriaProgettoModificheRupObj.DifferenzaContributoTotale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["DIFFERENZA_CONTRIBUTO_TOTALE"]);
			GraduatoriaProgettoModificheRupObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			GraduatoriaProgettoModificheRupObj.IsDirty = false;
			GraduatoriaProgettoModificheRupObj.IsPersistent = true;
			return GraduatoriaProgettoModificheRupObj;
		}

		//Find Select

		public static GraduatoriaProgettoModificheRupCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdGraduatoriaProgettiModificheRupEqualThis, SiarLibrary.NullTypes.StringNT CfInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, 
SiarLibrary.NullTypes.StringNT CfModificaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, 
SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdAttoEqualThis, SiarLibrary.NullTypes.StringNT NoteEqualThis, 
SiarLibrary.NullTypes.DecimalNT CostoTotalePrecedenteEqualThis, SiarLibrary.NullTypes.DecimalNT CostoTotaleNuovoEqualThis, SiarLibrary.NullTypes.DecimalNT ContributoTotalePrecedenteEqualThis, 
SiarLibrary.NullTypes.DecimalNT ContributoTotaleNuovoEqualThis)

		{

			GraduatoriaProgettoModificheRupCollection GraduatoriaProgettoModificheRupCollectionObj = new GraduatoriaProgettoModificheRupCollection();

			IDbCommand findCmd = db.InitCmd("Zgraduatoriaprogettomodificherupfindselect", new string[] {"IdGraduatoriaProgettiModificheRupequalthis", "CfInserimentoequalthis", "DataInserimentoequalthis", 
"CfModificaequalthis", "DataModificaequalthis", "IdBandoequalthis", 
"IdProgettoequalthis", "IdAttoequalthis", "Noteequalthis", 
"CostoTotalePrecedenteequalthis", "CostoTotaleNuovoequalthis", "ContributoTotalePrecedenteequalthis", 
"ContributoTotaleNuovoequalthis"}, new string[] {"int", "string", "DateTime", 
"string", "DateTime", "int", 
"int", "int", "string", 
"decimal", "decimal", "decimal", 
"decimal"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdGraduatoriaProgettiModificheRupequalthis", IdGraduatoriaProgettiModificheRupEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfInserimentoequalthis", CfInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfModificaequalthis", CfModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAttoequalthis", IdAttoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Noteequalthis", NoteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CostoTotalePrecedenteequalthis", CostoTotalePrecedenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CostoTotaleNuovoequalthis", CostoTotaleNuovoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ContributoTotalePrecedenteequalthis", ContributoTotalePrecedenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ContributoTotaleNuovoequalthis", ContributoTotaleNuovoEqualThis);
			GraduatoriaProgettoModificheRup GraduatoriaProgettoModificheRupObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				GraduatoriaProgettoModificheRupObj = GetFromDatareader(db);
				GraduatoriaProgettoModificheRupObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				GraduatoriaProgettoModificheRupObj.IsDirty = false;
				GraduatoriaProgettoModificheRupObj.IsPersistent = true;
				GraduatoriaProgettoModificheRupCollectionObj.Add(GraduatoriaProgettoModificheRupObj);
			}
			db.Close();
			return GraduatoriaProgettoModificheRupCollectionObj;
		}

		//Find Find

		public static GraduatoriaProgettoModificheRupCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdGraduatoriaProgettiModificheRupEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, 
SiarLibrary.NullTypes.IntNT IdAttoEqualThis)

		{

			GraduatoriaProgettoModificheRupCollection GraduatoriaProgettoModificheRupCollectionObj = new GraduatoriaProgettoModificheRupCollection();

			IDbCommand findCmd = db.InitCmd("Zgraduatoriaprogettomodificherupfindfind", new string[] {"IdGraduatoriaProgettiModificheRupequalthis", "IdBandoequalthis", "IdProgettoequalthis", 
"IdAttoequalthis"}, new string[] {"int", "int", "int", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdGraduatoriaProgettiModificheRupequalthis", IdGraduatoriaProgettiModificheRupEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAttoequalthis", IdAttoEqualThis);
			GraduatoriaProgettoModificheRup GraduatoriaProgettoModificheRupObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				GraduatoriaProgettoModificheRupObj = GetFromDatareader(db);
				GraduatoriaProgettoModificheRupObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				GraduatoriaProgettoModificheRupObj.IsDirty = false;
				GraduatoriaProgettoModificheRupObj.IsPersistent = true;
				GraduatoriaProgettoModificheRupCollectionObj.Add(GraduatoriaProgettoModificheRupObj);
			}
			db.Close();
			return GraduatoriaProgettoModificheRupCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for GraduatoriaProgettoModificheRupCollectionProvider:IGraduatoriaProgettoModificheRupProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class GraduatoriaProgettoModificheRupCollectionProvider : IGraduatoriaProgettoModificheRupProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di GraduatoriaProgettoModificheRup
		protected GraduatoriaProgettoModificheRupCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public GraduatoriaProgettoModificheRupCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new GraduatoriaProgettoModificheRupCollection(this);
		}

		//Costruttore 2: popola la collection
		public GraduatoriaProgettoModificheRupCollectionProvider(IntNT IdgraduatoriaprogettimodificherupEqualThis, IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis, 
IntNT IdattoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdgraduatoriaprogettimodificherupEqualThis, IdbandoEqualThis, IdprogettoEqualThis, 
IdattoEqualThis);
		}

		//Costruttore3: ha in input graduatoriaprogettomodificherupCollectionObj - non popola la collection
		public GraduatoriaProgettoModificheRupCollectionProvider(GraduatoriaProgettoModificheRupCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public GraduatoriaProgettoModificheRupCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new GraduatoriaProgettoModificheRupCollection(this);
		}

		//Get e Set
		public GraduatoriaProgettoModificheRupCollection CollectionObj
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
		public int SaveCollection(GraduatoriaProgettoModificheRupCollection collectionObj)
		{
			return GraduatoriaProgettoModificheRupDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(GraduatoriaProgettoModificheRup graduatoriaprogettomodificherupObj)
		{
			return GraduatoriaProgettoModificheRupDAL.Save(_dbProviderObj, graduatoriaprogettomodificherupObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(GraduatoriaProgettoModificheRupCollection collectionObj)
		{
			return GraduatoriaProgettoModificheRupDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(GraduatoriaProgettoModificheRup graduatoriaprogettomodificherupObj)
		{
			return GraduatoriaProgettoModificheRupDAL.Delete(_dbProviderObj, graduatoriaprogettomodificherupObj);
		}

		//getById
		public GraduatoriaProgettoModificheRup GetById(IntNT IdGraduatoriaProgettiModificheRupValue)
		{
			GraduatoriaProgettoModificheRup GraduatoriaProgettoModificheRupTemp = GraduatoriaProgettoModificheRupDAL.GetById(_dbProviderObj, IdGraduatoriaProgettiModificheRupValue);
			if (GraduatoriaProgettoModificheRupTemp!=null) GraduatoriaProgettoModificheRupTemp.Provider = this;
			return GraduatoriaProgettoModificheRupTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public GraduatoriaProgettoModificheRupCollection Select(IntNT IdgraduatoriaprogettimodificherupEqualThis, StringNT CfinserimentoEqualThis, DatetimeNT DatainserimentoEqualThis, 
StringNT CfmodificaEqualThis, DatetimeNT DatamodificaEqualThis, IntNT IdbandoEqualThis, 
IntNT IdprogettoEqualThis, IntNT IdattoEqualThis, StringNT NoteEqualThis, 
DecimalNT CostototaleprecedenteEqualThis, DecimalNT CostototalenuovoEqualThis, DecimalNT ContributototaleprecedenteEqualThis, 
DecimalNT ContributototalenuovoEqualThis)
		{
			GraduatoriaProgettoModificheRupCollection GraduatoriaProgettoModificheRupCollectionTemp = GraduatoriaProgettoModificheRupDAL.Select(_dbProviderObj, IdgraduatoriaprogettimodificherupEqualThis, CfinserimentoEqualThis, DatainserimentoEqualThis, 
CfmodificaEqualThis, DatamodificaEqualThis, IdbandoEqualThis, 
IdprogettoEqualThis, IdattoEqualThis, NoteEqualThis, 
CostototaleprecedenteEqualThis, CostototalenuovoEqualThis, ContributototaleprecedenteEqualThis, 
ContributototalenuovoEqualThis);
			GraduatoriaProgettoModificheRupCollectionTemp.Provider = this;
			return GraduatoriaProgettoModificheRupCollectionTemp;
		}

		//Find: popola la collection
		public GraduatoriaProgettoModificheRupCollection Find(IntNT IdgraduatoriaprogettimodificherupEqualThis, IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis, 
IntNT IdattoEqualThis)
		{
			GraduatoriaProgettoModificheRupCollection GraduatoriaProgettoModificheRupCollectionTemp = GraduatoriaProgettoModificheRupDAL.Find(_dbProviderObj, IdgraduatoriaprogettimodificherupEqualThis, IdbandoEqualThis, IdprogettoEqualThis, 
IdattoEqualThis);
			GraduatoriaProgettoModificheRupCollectionTemp.Provider = this;
			return GraduatoriaProgettoModificheRupCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<GRADUATORIA_PROGETTO_MODIFICHE_RUP>
  <ViewName>VGRADUATORIA_PROGETTO_MODIFICHE_RUP</ViewName>
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
      <ID_GRADUATORIA_PROGETTI_MODIFICHE_RUP>Equal</ID_GRADUATORIA_PROGETTI_MODIFICHE_RUP>
      <ID_BANDO>Equal</ID_BANDO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_ATTO>Equal</ID_ATTO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</GRADUATORIA_PROGETTO_MODIFICHE_RUP>
*/
