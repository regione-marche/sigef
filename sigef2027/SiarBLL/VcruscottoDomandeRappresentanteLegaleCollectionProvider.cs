using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VcruscottoDomandeRappresentanteLegale
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class VcruscottoDomandeRappresentanteLegale: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdBando;
		private NullTypes.StringNT _DescrizioneBando;
		private NullTypes.DatetimeNT _DataScadenzaBando;
		private NullTypes.StringNT _CodEnteBando;
		private NullTypes.IntNT _IdProgrammazioneBando;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.StringNT _CodStatoProgetto;
		private NullTypes.StringNT _StatoProgetto;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.StringNT _Impresa;
		private NullTypes.IntNT _IdUtenteRappresentanteLegale;
		private NullTypes.StringNT _RappresentanteLegale;


		//Costruttore
		public VcruscottoDomandeRappresentanteLegale()
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
		/// Corrisponde al campo:DESCRIZIONE_BANDO
		/// Tipo sul db:VARCHAR(2000)
		/// </summary>
		public NullTypes.StringNT DescrizioneBando
		{
			get { return _DescrizioneBando; }
			set {
				if (DescrizioneBando != value)
				{
					_DescrizioneBando = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_SCADENZA_BANDO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataScadenzaBando
		{
			get { return _DataScadenzaBando; }
			set {
				if (DataScadenzaBando != value)
				{
					_DataScadenzaBando = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_ENTE_BANDO
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT CodEnteBando
		{
			get { return _CodEnteBando; }
			set {
				if (CodEnteBando != value)
				{
					_CodEnteBando = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_PROGRAMMAZIONE_BANDO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProgrammazioneBando
		{
			get { return _IdProgrammazioneBando; }
			set {
				if (IdProgrammazioneBando != value)
				{
					_IdProgrammazioneBando = value;
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
		/// Corrisponde al campo:COD_STATO_PROGETTO
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT CodStatoProgetto
		{
			get { return _CodStatoProgetto; }
			set {
				if (CodStatoProgetto != value)
				{
					_CodStatoProgetto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:STATO_PROGETTO
		/// Tipo sul db:VARCHAR(80)
		/// </summary>
		public NullTypes.StringNT StatoProgetto
		{
			get { return _StatoProgetto; }
			set {
				if (StatoProgetto != value)
				{
					_StatoProgetto = value;
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
		/// Corrisponde al campo:IMPRESA
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Impresa
		{
			get { return _Impresa; }
			set {
				if (Impresa != value)
				{
					_Impresa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_UTENTE_RAPPRESENTANTE_LEGALE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdUtenteRappresentanteLegale
		{
			get { return _IdUtenteRappresentanteLegale; }
			set {
				if (IdUtenteRappresentanteLegale != value)
				{
					_IdUtenteRappresentanteLegale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RAPPRESENTANTE_LEGALE
		/// Tipo sul db:VARCHAR(511)
		/// </summary>
		public NullTypes.StringNT RappresentanteLegale
		{
			get { return _RappresentanteLegale; }
			set {
				if (RappresentanteLegale != value)
				{
					_RappresentanteLegale = value;
					SetDirtyFlag();
				}
			}
		}




	}
}

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VcruscottoDomandeRappresentanteLegaleCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VcruscottoDomandeRappresentanteLegaleCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private VcruscottoDomandeRappresentanteLegaleCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((VcruscottoDomandeRappresentanteLegale) info.GetValue(i.ToString(),typeof(VcruscottoDomandeRappresentanteLegale)));
			}
		}

		//Costruttore
		public VcruscottoDomandeRappresentanteLegaleCollection()
		{
			this.ItemType = typeof(VcruscottoDomandeRappresentanteLegale);
		}

		//Get e Set
		public new VcruscottoDomandeRappresentanteLegale this[int index]
		{
			get { return (VcruscottoDomandeRappresentanteLegale)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VcruscottoDomandeRappresentanteLegaleCollection GetChanges()
		{
			return (VcruscottoDomandeRappresentanteLegaleCollection) base.GetChanges();
		}

		//Add
		public int Add(VcruscottoDomandeRappresentanteLegale VcruscottoDomandeRappresentanteLegaleObj)
		{
			return base.Add(VcruscottoDomandeRappresentanteLegaleObj);
		}

		//AddCollection
		public void AddCollection(VcruscottoDomandeRappresentanteLegaleCollection VcruscottoDomandeRappresentanteLegaleCollectionObj)
		{
			foreach (VcruscottoDomandeRappresentanteLegale VcruscottoDomandeRappresentanteLegaleObj in VcruscottoDomandeRappresentanteLegaleCollectionObj)
				this.Add(VcruscottoDomandeRappresentanteLegaleObj);
		}

		//Insert
		public void Insert(int index, VcruscottoDomandeRappresentanteLegale VcruscottoDomandeRappresentanteLegaleObj)
		{
			base.Insert(index, VcruscottoDomandeRappresentanteLegaleObj);
		}

		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VcruscottoDomandeRappresentanteLegaleCollection SubSelect(NullTypes.IntNT IdBandoEqualThis, NullTypes.StringNT DescrizioneBandoEqualThis, NullTypes.DatetimeNT DataScadenzaBandoEqualThis, 
NullTypes.StringNT CodEnteBandoEqualThis, NullTypes.IntNT IdProgrammazioneBandoEqualThis, NullTypes.IntNT IdProgettoEqualThis, 
NullTypes.StringNT CodStatoProgettoEqualThis, NullTypes.StringNT StatoProgettoEqualThis, NullTypes.IntNT IdImpresaEqualThis, 
NullTypes.StringNT ImpresaEqualThis, NullTypes.IntNT IdUtenteRappresentanteLegaleEqualThis, NullTypes.StringNT RappresentanteLegaleEqualThis)
		{
			VcruscottoDomandeRappresentanteLegaleCollection VcruscottoDomandeRappresentanteLegaleCollectionTemp = new VcruscottoDomandeRappresentanteLegaleCollection();
			foreach (VcruscottoDomandeRappresentanteLegale VcruscottoDomandeRappresentanteLegaleItem in this)
			{
				if (((IdBandoEqualThis == null) || ((VcruscottoDomandeRappresentanteLegaleItem.IdBando != null) && (VcruscottoDomandeRappresentanteLegaleItem.IdBando.Value == IdBandoEqualThis.Value))) && ((DescrizioneBandoEqualThis == null) || ((VcruscottoDomandeRappresentanteLegaleItem.DescrizioneBando != null) && (VcruscottoDomandeRappresentanteLegaleItem.DescrizioneBando.Value == DescrizioneBandoEqualThis.Value))) && ((DataScadenzaBandoEqualThis == null) || ((VcruscottoDomandeRappresentanteLegaleItem.DataScadenzaBando != null) && (VcruscottoDomandeRappresentanteLegaleItem.DataScadenzaBando.Value == DataScadenzaBandoEqualThis.Value))) && 
((CodEnteBandoEqualThis == null) || ((VcruscottoDomandeRappresentanteLegaleItem.CodEnteBando != null) && (VcruscottoDomandeRappresentanteLegaleItem.CodEnteBando.Value == CodEnteBandoEqualThis.Value))) && ((IdProgrammazioneBandoEqualThis == null) || ((VcruscottoDomandeRappresentanteLegaleItem.IdProgrammazioneBando != null) && (VcruscottoDomandeRappresentanteLegaleItem.IdProgrammazioneBando.Value == IdProgrammazioneBandoEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((VcruscottoDomandeRappresentanteLegaleItem.IdProgetto != null) && (VcruscottoDomandeRappresentanteLegaleItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && 
((CodStatoProgettoEqualThis == null) || ((VcruscottoDomandeRappresentanteLegaleItem.CodStatoProgetto != null) && (VcruscottoDomandeRappresentanteLegaleItem.CodStatoProgetto.Value == CodStatoProgettoEqualThis.Value))) && ((StatoProgettoEqualThis == null) || ((VcruscottoDomandeRappresentanteLegaleItem.StatoProgetto != null) && (VcruscottoDomandeRappresentanteLegaleItem.StatoProgetto.Value == StatoProgettoEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((VcruscottoDomandeRappresentanteLegaleItem.IdImpresa != null) && (VcruscottoDomandeRappresentanteLegaleItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && 
((ImpresaEqualThis == null) || ((VcruscottoDomandeRappresentanteLegaleItem.Impresa != null) && (VcruscottoDomandeRappresentanteLegaleItem.Impresa.Value == ImpresaEqualThis.Value))) && ((IdUtenteRappresentanteLegaleEqualThis == null) || ((VcruscottoDomandeRappresentanteLegaleItem.IdUtenteRappresentanteLegale != null) && (VcruscottoDomandeRappresentanteLegaleItem.IdUtenteRappresentanteLegale.Value == IdUtenteRappresentanteLegaleEqualThis.Value))) && ((RappresentanteLegaleEqualThis == null) || ((VcruscottoDomandeRappresentanteLegaleItem.RappresentanteLegale != null) && (VcruscottoDomandeRappresentanteLegaleItem.RappresentanteLegale.Value == RappresentanteLegaleEqualThis.Value))))
				{
					VcruscottoDomandeRappresentanteLegaleCollectionTemp.Add(VcruscottoDomandeRappresentanteLegaleItem);
				}
			}
			return VcruscottoDomandeRappresentanteLegaleCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for VcruscottoDomandeRappresentanteLegaleDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class VcruscottoDomandeRappresentanteLegaleDAL
	{

		//Operazioni

		//getFromDatareader
		public static VcruscottoDomandeRappresentanteLegale GetFromDatareader(DbProvider db)
		{
			VcruscottoDomandeRappresentanteLegale VcruscottoDomandeRappresentanteLegaleObj = new VcruscottoDomandeRappresentanteLegale();
			VcruscottoDomandeRappresentanteLegaleObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			VcruscottoDomandeRappresentanteLegaleObj.DescrizioneBando = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_BANDO"]);
			VcruscottoDomandeRappresentanteLegaleObj.DataScadenzaBando = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_SCADENZA_BANDO"]);
			VcruscottoDomandeRappresentanteLegaleObj.CodEnteBando = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE_BANDO"]);
			VcruscottoDomandeRappresentanteLegaleObj.IdProgrammazioneBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGRAMMAZIONE_BANDO"]);
			VcruscottoDomandeRappresentanteLegaleObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			VcruscottoDomandeRappresentanteLegaleObj.CodStatoProgetto = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_STATO_PROGETTO"]);
			VcruscottoDomandeRappresentanteLegaleObj.StatoProgetto = new SiarLibrary.NullTypes.StringNT(db.DataReader["STATO_PROGETTO"]);
			VcruscottoDomandeRappresentanteLegaleObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			VcruscottoDomandeRappresentanteLegaleObj.Impresa = new SiarLibrary.NullTypes.StringNT(db.DataReader["IMPRESA"]);
			VcruscottoDomandeRappresentanteLegaleObj.IdUtenteRappresentanteLegale = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_UTENTE_RAPPRESENTANTE_LEGALE"]);
			VcruscottoDomandeRappresentanteLegaleObj.RappresentanteLegale = new SiarLibrary.NullTypes.StringNT(db.DataReader["RAPPRESENTANTE_LEGALE"]);
			VcruscottoDomandeRappresentanteLegaleObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			VcruscottoDomandeRappresentanteLegaleObj.IsDirty = false;
			VcruscottoDomandeRappresentanteLegaleObj.IsPersistent = true;
			return VcruscottoDomandeRappresentanteLegaleObj;
		}

		//Find Select

		public static VcruscottoDomandeRappresentanteLegaleCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneBandoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataScadenzaBandoEqualThis, 
SiarLibrary.NullTypes.StringNT CodEnteBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgrammazioneBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, 
SiarLibrary.NullTypes.StringNT CodStatoProgettoEqualThis, SiarLibrary.NullTypes.StringNT StatoProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, 
SiarLibrary.NullTypes.StringNT ImpresaEqualThis, SiarLibrary.NullTypes.IntNT IdUtenteRappresentanteLegaleEqualThis, SiarLibrary.NullTypes.StringNT RappresentanteLegaleEqualThis)

		{

			VcruscottoDomandeRappresentanteLegaleCollection VcruscottoDomandeRappresentanteLegaleCollectionObj = new VcruscottoDomandeRappresentanteLegaleCollection();

			IDbCommand findCmd = db.InitCmd("Zvcruscottodomanderappresentantelegalefindselect", new string[] {"IdBandoequalthis", "DescrizioneBandoequalthis", "DataScadenzaBandoequalthis", 
"CodEnteBandoequalthis", "IdProgrammazioneBandoequalthis", "IdProgettoequalthis", 
"CodStatoProgettoequalthis", "StatoProgettoequalthis", "IdImpresaequalthis", 
"Impresaequalthis", "IdUtenteRappresentanteLegaleequalthis", "RappresentanteLegaleequalthis"}, new string[] {"int", "string", "DateTime", 
"string", "int", "int", 
"string", "string", "int", 
"string", "int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneBandoequalthis", DescrizioneBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataScadenzaBandoequalthis", DataScadenzaBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodEnteBandoequalthis", CodEnteBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgrammazioneBandoequalthis", IdProgrammazioneBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodStatoProgettoequalthis", CodStatoProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "StatoProgettoequalthis", StatoProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Impresaequalthis", ImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdUtenteRappresentanteLegaleequalthis", IdUtenteRappresentanteLegaleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RappresentanteLegaleequalthis", RappresentanteLegaleEqualThis);
			VcruscottoDomandeRappresentanteLegale VcruscottoDomandeRappresentanteLegaleObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VcruscottoDomandeRappresentanteLegaleObj = GetFromDatareader(db);
				VcruscottoDomandeRappresentanteLegaleObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VcruscottoDomandeRappresentanteLegaleObj.IsDirty = false;
				VcruscottoDomandeRappresentanteLegaleObj.IsPersistent = true;
				VcruscottoDomandeRappresentanteLegaleCollectionObj.Add(VcruscottoDomandeRappresentanteLegaleObj);
			}
			db.Close();
			return VcruscottoDomandeRappresentanteLegaleCollectionObj;
		}

		//Find FindDomandeRappresentanteLegale

		public static VcruscottoDomandeRappresentanteLegaleCollection FindDomandeRappresentanteLegale(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, 
SiarLibrary.NullTypes.IntNT IdUtenteRappresentanteLegaleEqualThis)

		{

			VcruscottoDomandeRappresentanteLegaleCollection VcruscottoDomandeRappresentanteLegaleCollectionObj = new VcruscottoDomandeRappresentanteLegaleCollection();

			IDbCommand findCmd = db.InitCmd("Zvcruscottodomanderappresentantelegalefindfinddomanderappresentantelegale", new string[] {"IdBandoequalthis", "IdProgettoequalthis", "IdImpresaequalthis", 
"IdUtenteRappresentanteLegaleequalthis"}, new string[] {"int", "int", "int", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdUtenteRappresentanteLegaleequalthis", IdUtenteRappresentanteLegaleEqualThis);
			VcruscottoDomandeRappresentanteLegale VcruscottoDomandeRappresentanteLegaleObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VcruscottoDomandeRappresentanteLegaleObj = GetFromDatareader(db);
				VcruscottoDomandeRappresentanteLegaleObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VcruscottoDomandeRappresentanteLegaleObj.IsDirty = false;
				VcruscottoDomandeRappresentanteLegaleObj.IsPersistent = true;
				VcruscottoDomandeRappresentanteLegaleCollectionObj.Add(VcruscottoDomandeRappresentanteLegaleObj);
			}
			db.Close();
			return VcruscottoDomandeRappresentanteLegaleCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for VcruscottoDomandeRappresentanteLegaleCollectionProvider:IVcruscottoDomandeRappresentanteLegaleProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VcruscottoDomandeRappresentanteLegaleCollectionProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di VcruscottoDomandeRappresentanteLegale
		protected VcruscottoDomandeRappresentanteLegaleCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public VcruscottoDomandeRappresentanteLegaleCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new VcruscottoDomandeRappresentanteLegaleCollection();
		}

		//Costruttore 2: popola la collection
		public VcruscottoDomandeRappresentanteLegaleCollectionProvider(IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis, IntNT IdimpresaEqualThis, 
IntNT IdutenterappresentantelegaleEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = FindDomandeRappresentanteLegale(IdbandoEqualThis, IdprogettoEqualThis, IdimpresaEqualThis, 
IdutenterappresentantelegaleEqualThis);
		}

		//Costruttore3: ha in input vcruscottodomanderappresentantelegaleCollectionObj - non popola la collection
		public VcruscottoDomandeRappresentanteLegaleCollectionProvider(VcruscottoDomandeRappresentanteLegaleCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public VcruscottoDomandeRappresentanteLegaleCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new VcruscottoDomandeRappresentanteLegaleCollection();
		}

		//Get e Set
		public VcruscottoDomandeRappresentanteLegaleCollection CollectionObj
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

		//Select: popola la collection
		public VcruscottoDomandeRappresentanteLegaleCollection Select(IntNT IdbandoEqualThis, StringNT DescrizionebandoEqualThis, DatetimeNT DatascadenzabandoEqualThis, 
StringNT CodentebandoEqualThis, IntNT IdprogrammazionebandoEqualThis, IntNT IdprogettoEqualThis, 
StringNT CodstatoprogettoEqualThis, StringNT StatoprogettoEqualThis, IntNT IdimpresaEqualThis, 
StringNT ImpresaEqualThis, IntNT IdutenterappresentantelegaleEqualThis, StringNT RappresentantelegaleEqualThis)
		{
			VcruscottoDomandeRappresentanteLegaleCollection VcruscottoDomandeRappresentanteLegaleCollectionTemp = VcruscottoDomandeRappresentanteLegaleDAL.Select(_dbProviderObj, IdbandoEqualThis, DescrizionebandoEqualThis, DatascadenzabandoEqualThis, 
CodentebandoEqualThis, IdprogrammazionebandoEqualThis, IdprogettoEqualThis, 
CodstatoprogettoEqualThis, StatoprogettoEqualThis, IdimpresaEqualThis, 
ImpresaEqualThis, IdutenterappresentantelegaleEqualThis, RappresentantelegaleEqualThis);
			return VcruscottoDomandeRappresentanteLegaleCollectionTemp;
		}

		//FindDomandeRappresentanteLegale: popola la collection
		public VcruscottoDomandeRappresentanteLegaleCollection FindDomandeRappresentanteLegale(IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis, IntNT IdimpresaEqualThis, 
IntNT IdutenterappresentantelegaleEqualThis)
		{
			VcruscottoDomandeRappresentanteLegaleCollection VcruscottoDomandeRappresentanteLegaleCollectionTemp = VcruscottoDomandeRappresentanteLegaleDAL.FindDomandeRappresentanteLegale(_dbProviderObj, IdbandoEqualThis, IdprogettoEqualThis, IdimpresaEqualThis, 
IdutenterappresentantelegaleEqualThis);
			return VcruscottoDomandeRappresentanteLegaleCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<VCRUSCOTTO_DOMANDE_RAPPRESENTANTE_LEGALE>
  <ViewName>VCRUSCOTTO_DOMANDE_RAPPRESENTANTE_LEGALE</ViewName>
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
    <FindDomandeRappresentanteLegale OrderBy="ORDER BY ">
      <ID_BANDO>Equal</ID_BANDO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <ID_UTENTE_RAPPRESENTANTE_LEGALE>Equal</ID_UTENTE_RAPPRESENTANTE_LEGALE>
    </FindDomandeRappresentanteLegale>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</VCRUSCOTTO_DOMANDE_RAPPRESENTANTE_LEGALE>
*/
