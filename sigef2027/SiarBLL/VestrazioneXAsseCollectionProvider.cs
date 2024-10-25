using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VestrazioneXAsse
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class VestrazioneXAsse: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdAsse;
		private NullTypes.StringNT _CodAsse;
		private NullTypes.StringNT _DescrizioneAsse;
		private NullTypes.IntNT _IdAzione;
		private NullTypes.StringNT _CodAzione;
		private NullTypes.StringNT _DescrizioneAzione;
		private NullTypes.IntNT _IdIntervento;
		private NullTypes.StringNT _CodIntervento;
		private NullTypes.StringNT _DescrizioneIntervento;
		private NullTypes.DecimalNT _ImportoDotazione;
		private NullTypes.IntNT _NumeroBando;
		private NullTypes.DecimalNT _ImportoBandi;
		private NullTypes.DecimalNT _PercDiAttuazione;
		private NullTypes.DecimalNT _PercNonAttuata;
		private NullTypes.IntNT _NumeroProgetti;
		private NullTypes.DecimalNT _CostoComplessivoProgetti;
		private NullTypes.DecimalNT _ContributoComplessivoProgetti;


		//Costruttore
		public VestrazioneXAsse()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_ASSE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdAsse
		{
			get { return _IdAsse; }
			set {
				if (IdAsse != value)
				{
					_IdAsse = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_ASSE
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT CodAsse
		{
			get { return _CodAsse; }
			set {
				if (CodAsse != value)
				{
					_CodAsse = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_ASSE
		/// Tipo sul db:VARCHAR(2000)
		/// </summary>
		public NullTypes.StringNT DescrizioneAsse
		{
			get { return _DescrizioneAsse; }
			set {
				if (DescrizioneAsse != value)
				{
					_DescrizioneAsse = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_AZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdAzione
		{
			get { return _IdAzione; }
			set {
				if (IdAzione != value)
				{
					_IdAzione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_AZIONE
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT CodAzione
		{
			get { return _CodAzione; }
			set {
				if (CodAzione != value)
				{
					_CodAzione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_AZIONE
		/// Tipo sul db:VARCHAR(2000)
		/// </summary>
		public NullTypes.StringNT DescrizioneAzione
		{
			get { return _DescrizioneAzione; }
			set {
				if (DescrizioneAzione != value)
				{
					_DescrizioneAzione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_INTERVENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdIntervento
		{
			get { return _IdIntervento; }
			set {
				if (IdIntervento != value)
				{
					_IdIntervento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_INTERVENTO
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT CodIntervento
		{
			get { return _CodIntervento; }
			set {
				if (CodIntervento != value)
				{
					_CodIntervento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_INTERVENTO
		/// Tipo sul db:VARCHAR(2000)
		/// </summary>
		public NullTypes.StringNT DescrizioneIntervento
		{
			get { return _DescrizioneIntervento; }
			set {
				if (DescrizioneIntervento != value)
				{
					_DescrizioneIntervento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_DOTAZIONE
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoDotazione
		{
			get { return _ImportoDotazione; }
			set {
				if (ImportoDotazione != value)
				{
					_ImportoDotazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NUMERO_BANDO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT NumeroBando
		{
			get { return _NumeroBando; }
			set {
				if (NumeroBando != value)
				{
					_NumeroBando = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_BANDI
		/// Tipo sul db:DECIMAL(38,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoBandi
		{
			get { return _ImportoBandi; }
			set {
				if (ImportoBandi != value)
				{
					_ImportoBandi = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PERC_DI_ATTUAZIONE
		/// Tipo sul db:NUMERIC
		/// </summary>
		public NullTypes.DecimalNT PercDiAttuazione
		{
			get { return _PercDiAttuazione; }
			set {
				if (PercDiAttuazione != value)
				{
					_PercDiAttuazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PERC_NON_ATTUATA
		/// Tipo sul db:NUMERIC
		/// </summary>
		public NullTypes.DecimalNT PercNonAttuata
		{
			get { return _PercNonAttuata; }
			set {
				if (PercNonAttuata != value)
				{
					_PercNonAttuata = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NUMERO_PROGETTI
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT NumeroProgetti
		{
			get { return _NumeroProgetti; }
			set {
				if (NumeroProgetti != value)
				{
					_NumeroProgetti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COSTO_COMPLESSIVO_PROGETTI
		/// Tipo sul db:DECIMAL(38,2)
		/// </summary>
		public NullTypes.DecimalNT CostoComplessivoProgetti
		{
			get { return _CostoComplessivoProgetti; }
			set {
				if (CostoComplessivoProgetti != value)
				{
					_CostoComplessivoProgetti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTRIBUTO_COMPLESSIVO_PROGETTI
		/// Tipo sul db:DECIMAL(38,2)
		/// </summary>
		public NullTypes.DecimalNT ContributoComplessivoProgetti
		{
			get { return _ContributoComplessivoProgetti; }
			set {
				if (ContributoComplessivoProgetti != value)
				{
					_ContributoComplessivoProgetti = value;
					SetDirtyFlag();
				}
			}
		}




	}
}

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VestrazioneXAsseCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VestrazioneXAsseCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private VestrazioneXAsseCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((VestrazioneXAsse) info.GetValue(i.ToString(),typeof(VestrazioneXAsse)));
			}
		}

		//Costruttore
		public VestrazioneXAsseCollection()
		{
			this.ItemType = typeof(VestrazioneXAsse);
		}

		//Get e Set
		public new VestrazioneXAsse this[int index]
		{
			get { return (VestrazioneXAsse)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VestrazioneXAsseCollection GetChanges()
		{
			return (VestrazioneXAsseCollection) base.GetChanges();
		}

		//Add
		public int Add(VestrazioneXAsse VestrazioneXAsseObj)
		{
			return base.Add(VestrazioneXAsseObj);
		}

		//AddCollection
		public void AddCollection(VestrazioneXAsseCollection VestrazioneXAsseCollectionObj)
		{
			foreach (VestrazioneXAsse VestrazioneXAsseObj in VestrazioneXAsseCollectionObj)
				this.Add(VestrazioneXAsseObj);
		}

		//Insert
		public void Insert(int index, VestrazioneXAsse VestrazioneXAsseObj)
		{
			base.Insert(index, VestrazioneXAsseObj);
		}

		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VestrazioneXAsseCollection SubSelect(NullTypes.IntNT IdAsseEqualThis, NullTypes.StringNT CodAsseEqualThis, NullTypes.StringNT DescrizioneAsseEqualThis, 
NullTypes.IntNT IdAzioneEqualThis, NullTypes.StringNT CodAzioneEqualThis, NullTypes.StringNT DescrizioneAzioneEqualThis, 
NullTypes.IntNT IdInterventoEqualThis, NullTypes.StringNT CodInterventoEqualThis, NullTypes.StringNT DescrizioneInterventoEqualThis, 
NullTypes.DecimalNT ImportoDotazioneEqualThis, NullTypes.IntNT NumeroBandoEqualThis, NullTypes.DecimalNT ImportoBandiEqualThis, 
NullTypes.DecimalNT PercDiAttuazioneEqualThis, NullTypes.DecimalNT PercNonAttuataEqualThis, NullTypes.IntNT NumeroProgettiEqualThis, 
NullTypes.DecimalNT CostoComplessivoProgettiEqualThis, NullTypes.DecimalNT ContributoComplessivoProgettiEqualThis)
		{
			VestrazioneXAsseCollection VestrazioneXAsseCollectionTemp = new VestrazioneXAsseCollection();
			foreach (VestrazioneXAsse VestrazioneXAsseItem in this)
			{
				if (((IdAsseEqualThis == null) || ((VestrazioneXAsseItem.IdAsse != null) && (VestrazioneXAsseItem.IdAsse.Value == IdAsseEqualThis.Value))) && ((CodAsseEqualThis == null) || ((VestrazioneXAsseItem.CodAsse != null) && (VestrazioneXAsseItem.CodAsse.Value == CodAsseEqualThis.Value))) && ((DescrizioneAsseEqualThis == null) || ((VestrazioneXAsseItem.DescrizioneAsse != null) && (VestrazioneXAsseItem.DescrizioneAsse.Value == DescrizioneAsseEqualThis.Value))) && 
((IdAzioneEqualThis == null) || ((VestrazioneXAsseItem.IdAzione != null) && (VestrazioneXAsseItem.IdAzione.Value == IdAzioneEqualThis.Value))) && ((CodAzioneEqualThis == null) || ((VestrazioneXAsseItem.CodAzione != null) && (VestrazioneXAsseItem.CodAzione.Value == CodAzioneEqualThis.Value))) && ((DescrizioneAzioneEqualThis == null) || ((VestrazioneXAsseItem.DescrizioneAzione != null) && (VestrazioneXAsseItem.DescrizioneAzione.Value == DescrizioneAzioneEqualThis.Value))) && 
((IdInterventoEqualThis == null) || ((VestrazioneXAsseItem.IdIntervento != null) && (VestrazioneXAsseItem.IdIntervento.Value == IdInterventoEqualThis.Value))) && ((CodInterventoEqualThis == null) || ((VestrazioneXAsseItem.CodIntervento != null) && (VestrazioneXAsseItem.CodIntervento.Value == CodInterventoEqualThis.Value))) && ((DescrizioneInterventoEqualThis == null) || ((VestrazioneXAsseItem.DescrizioneIntervento != null) && (VestrazioneXAsseItem.DescrizioneIntervento.Value == DescrizioneInterventoEqualThis.Value))) && 
((ImportoDotazioneEqualThis == null) || ((VestrazioneXAsseItem.ImportoDotazione != null) && (VestrazioneXAsseItem.ImportoDotazione.Value == ImportoDotazioneEqualThis.Value))) && ((NumeroBandoEqualThis == null) || ((VestrazioneXAsseItem.NumeroBando != null) && (VestrazioneXAsseItem.NumeroBando.Value == NumeroBandoEqualThis.Value))) && ((ImportoBandiEqualThis == null) || ((VestrazioneXAsseItem.ImportoBandi != null) && (VestrazioneXAsseItem.ImportoBandi.Value == ImportoBandiEqualThis.Value))) && 
((PercDiAttuazioneEqualThis == null) || ((VestrazioneXAsseItem.PercDiAttuazione != null) && (VestrazioneXAsseItem.PercDiAttuazione.Value == PercDiAttuazioneEqualThis.Value))) && ((PercNonAttuataEqualThis == null) || ((VestrazioneXAsseItem.PercNonAttuata != null) && (VestrazioneXAsseItem.PercNonAttuata.Value == PercNonAttuataEqualThis.Value))) && ((NumeroProgettiEqualThis == null) || ((VestrazioneXAsseItem.NumeroProgetti != null) && (VestrazioneXAsseItem.NumeroProgetti.Value == NumeroProgettiEqualThis.Value))) && 
((CostoComplessivoProgettiEqualThis == null) || ((VestrazioneXAsseItem.CostoComplessivoProgetti != null) && (VestrazioneXAsseItem.CostoComplessivoProgetti.Value == CostoComplessivoProgettiEqualThis.Value))) && ((ContributoComplessivoProgettiEqualThis == null) || ((VestrazioneXAsseItem.ContributoComplessivoProgetti != null) && (VestrazioneXAsseItem.ContributoComplessivoProgetti.Value == ContributoComplessivoProgettiEqualThis.Value))))
				{
					VestrazioneXAsseCollectionTemp.Add(VestrazioneXAsseItem);
				}
			}
			return VestrazioneXAsseCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for VestrazioneXAsseDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class VestrazioneXAsseDAL
	{

		//Operazioni

		//getFromDatareader
		public static VestrazioneXAsse GetFromDatareader(DbProvider db)
		{
			VestrazioneXAsse VestrazioneXAsseObj = new VestrazioneXAsse();
			VestrazioneXAsseObj.IdAsse = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ASSE"]);
			VestrazioneXAsseObj.CodAsse = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ASSE"]);
			VestrazioneXAsseObj.DescrizioneAsse = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_ASSE"]);
			VestrazioneXAsseObj.IdAzione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_AZIONE"]);
			VestrazioneXAsseObj.CodAzione = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_AZIONE"]);
			VestrazioneXAsseObj.DescrizioneAzione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_AZIONE"]);
			VestrazioneXAsseObj.IdIntervento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INTERVENTO"]);
			VestrazioneXAsseObj.CodIntervento = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_INTERVENTO"]);
			VestrazioneXAsseObj.DescrizioneIntervento = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_INTERVENTO"]);
			VestrazioneXAsseObj.ImportoDotazione = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_DOTAZIONE"]);
			VestrazioneXAsseObj.NumeroBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMERO_BANDO"]);
			VestrazioneXAsseObj.ImportoBandi = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_BANDI"]);
			VestrazioneXAsseObj.PercDiAttuazione = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PERC_DI_ATTUAZIONE"]);
			VestrazioneXAsseObj.PercNonAttuata = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PERC_NON_ATTUATA"]);
			VestrazioneXAsseObj.NumeroProgetti = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMERO_PROGETTI"]);
			VestrazioneXAsseObj.CostoComplessivoProgetti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["COSTO_COMPLESSIVO_PROGETTI"]);
			VestrazioneXAsseObj.ContributoComplessivoProgetti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_COMPLESSIVO_PROGETTI"]);
			VestrazioneXAsseObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			VestrazioneXAsseObj.IsDirty = false;
			VestrazioneXAsseObj.IsPersistent = true;
			return VestrazioneXAsseObj;
		}

		//Find Select

		public static VestrazioneXAsseCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdAsseEqualThis, SiarLibrary.NullTypes.StringNT CodAsseEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneAsseEqualThis, 
SiarLibrary.NullTypes.IntNT IdAzioneEqualThis, SiarLibrary.NullTypes.StringNT CodAzioneEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneAzioneEqualThis, 
SiarLibrary.NullTypes.IntNT IdInterventoEqualThis, SiarLibrary.NullTypes.StringNT CodInterventoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneInterventoEqualThis, 
SiarLibrary.NullTypes.DecimalNT ImportoDotazioneEqualThis, SiarLibrary.NullTypes.IntNT NumeroBandoEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoBandiEqualThis, 
SiarLibrary.NullTypes.DecimalNT PercDiAttuazioneEqualThis, SiarLibrary.NullTypes.DecimalNT PercNonAttuataEqualThis, SiarLibrary.NullTypes.IntNT NumeroProgettiEqualThis, 
SiarLibrary.NullTypes.DecimalNT CostoComplessivoProgettiEqualThis, SiarLibrary.NullTypes.DecimalNT ContributoComplessivoProgettiEqualThis)

		{

			VestrazioneXAsseCollection VestrazioneXAsseCollectionObj = new VestrazioneXAsseCollection();

			IDbCommand findCmd = db.InitCmd("Zvestrazionexassefindselect", new string[] {"IdAsseequalthis", "CodAsseequalthis", "DescrizioneAsseequalthis", 
"IdAzioneequalthis", "CodAzioneequalthis", "DescrizioneAzioneequalthis", 
"IdInterventoequalthis", "CodInterventoequalthis", "DescrizioneInterventoequalthis", 
"ImportoDotazioneequalthis", "NumeroBandoequalthis", "ImportoBandiequalthis", 
"PercDiAttuazioneequalthis", "PercNonAttuataequalthis", "NumeroProgettiequalthis", 
"CostoComplessivoProgettiequalthis", "ContributoComplessivoProgettiequalthis"}, new string[] {"int", "string", "string", 
"int", "string", "string", 
"int", "string", "string", 
"decimal", "int", "decimal", 
"decimal", "decimal", "int", 
"decimal", "decimal"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAsseequalthis", IdAsseEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodAsseequalthis", CodAsseEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneAsseequalthis", DescrizioneAsseEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAzioneequalthis", IdAzioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodAzioneequalthis", CodAzioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneAzioneequalthis", DescrizioneAzioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdInterventoequalthis", IdInterventoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodInterventoequalthis", CodInterventoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneInterventoequalthis", DescrizioneInterventoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoDotazioneequalthis", ImportoDotazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NumeroBandoequalthis", NumeroBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoBandiequalthis", ImportoBandiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PercDiAttuazioneequalthis", PercDiAttuazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PercNonAttuataequalthis", PercNonAttuataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NumeroProgettiequalthis", NumeroProgettiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CostoComplessivoProgettiequalthis", CostoComplessivoProgettiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ContributoComplessivoProgettiequalthis", ContributoComplessivoProgettiEqualThis);
			VestrazioneXAsse VestrazioneXAsseObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VestrazioneXAsseObj = GetFromDatareader(db);
				VestrazioneXAsseObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VestrazioneXAsseObj.IsDirty = false;
				VestrazioneXAsseObj.IsPersistent = true;
				VestrazioneXAsseCollectionObj.Add(VestrazioneXAsseObj);
			}
			db.Close();
			return VestrazioneXAsseCollectionObj;
		}

		//Find Find

		public static VestrazioneXAsseCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdAsseEqualThis)

		{

			VestrazioneXAsseCollection VestrazioneXAsseCollectionObj = new VestrazioneXAsseCollection();

			IDbCommand findCmd = db.InitCmd("Zvestrazionexassefindfind", new string[] {"IdAsseequalthis"}, new string[] {"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAsseequalthis", IdAsseEqualThis);
			VestrazioneXAsse VestrazioneXAsseObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VestrazioneXAsseObj = GetFromDatareader(db);
				VestrazioneXAsseObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VestrazioneXAsseObj.IsDirty = false;
				VestrazioneXAsseObj.IsPersistent = true;
				VestrazioneXAsseCollectionObj.Add(VestrazioneXAsseObj);
			}
			db.Close();
			return VestrazioneXAsseCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for VestrazioneXAsseCollectionProvider:IVestrazioneXAsseProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VestrazioneXAsseCollectionProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di VestrazioneXAsse
		protected VestrazioneXAsseCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public VestrazioneXAsseCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new VestrazioneXAsseCollection();
		}

		//Costruttore 2: popola la collection
		public VestrazioneXAsseCollectionProvider(IntNT IdasseEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdasseEqualThis);
		}

		//Costruttore3: ha in input vestrazionexasseCollectionObj - non popola la collection
		public VestrazioneXAsseCollectionProvider(VestrazioneXAsseCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public VestrazioneXAsseCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new VestrazioneXAsseCollection();
		}

		//Get e Set
		public VestrazioneXAsseCollection CollectionObj
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
		public VestrazioneXAsseCollection Select(IntNT IdasseEqualThis, StringNT CodasseEqualThis, StringNT DescrizioneasseEqualThis, 
IntNT IdazioneEqualThis, StringNT CodazioneEqualThis, StringNT DescrizioneazioneEqualThis, 
IntNT IdinterventoEqualThis, StringNT CodinterventoEqualThis, StringNT DescrizioneinterventoEqualThis, 
DecimalNT ImportodotazioneEqualThis, IntNT NumerobandoEqualThis, DecimalNT ImportobandiEqualThis, 
DecimalNT PercdiattuazioneEqualThis, DecimalNT PercnonattuataEqualThis, IntNT NumeroprogettiEqualThis, 
DecimalNT CostocomplessivoprogettiEqualThis, DecimalNT ContributocomplessivoprogettiEqualThis)
		{
			VestrazioneXAsseCollection VestrazioneXAsseCollectionTemp = VestrazioneXAsseDAL.Select(_dbProviderObj, IdasseEqualThis, CodasseEqualThis, DescrizioneasseEqualThis, 
IdazioneEqualThis, CodazioneEqualThis, DescrizioneazioneEqualThis, 
IdinterventoEqualThis, CodinterventoEqualThis, DescrizioneinterventoEqualThis, 
ImportodotazioneEqualThis, NumerobandoEqualThis, ImportobandiEqualThis, 
PercdiattuazioneEqualThis, PercnonattuataEqualThis, NumeroprogettiEqualThis, 
CostocomplessivoprogettiEqualThis, ContributocomplessivoprogettiEqualThis);
			return VestrazioneXAsseCollectionTemp;
		}

		//Find: popola la collection
		public VestrazioneXAsseCollection Find(IntNT IdasseEqualThis)
		{
			VestrazioneXAsseCollection VestrazioneXAsseCollectionTemp = VestrazioneXAsseDAL.Find(_dbProviderObj, IdasseEqualThis);
			return VestrazioneXAsseCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<vESTRAZIONE_X_ASSE>
  <ViewName>vESTRAZIONE_X_ASSE</ViewName>
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
    <Find OrderBy="ORDER BY COD_ASSE,COD_INTERVENTO">
      <ID_ASSE>Equal</ID_ASSE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</vESTRAZIONE_X_ASSE>
*/
