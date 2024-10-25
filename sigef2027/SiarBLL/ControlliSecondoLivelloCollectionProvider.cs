using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ControlliSecondoLivello
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IControlliSecondoLivelloProvider
	{
		int Save(ControlliSecondoLivello ControlliSecondoLivelloObj);
		int SaveCollection(ControlliSecondoLivelloCollection collectionObj);
		int Delete(ControlliSecondoLivello ControlliSecondoLivelloObj);
		int DeleteCollection(ControlliSecondoLivelloCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ControlliSecondoLivello
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ControlliSecondoLivello: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.StringNT _Asse;
		private NullTypes.StringNT _Azione;
		private NullTypes.StringNT _Intervento;
		private NullTypes.StringNT _DescrizioneIntervento;
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdLotto;
		private NullTypes.DecimalNT _TotaleSpesaAmmessa;
		private NullTypes.DecimalNT _TotaleContributiRendicontati;
		private NullTypes.DecimalNT _SpesaAmmessaIrregolare;
		private NullTypes.DecimalNT _ContributoAmmessoIrregolare;
		private NullTypes.IntNT _Controllore;
		private NullTypes.DatetimeNT _DataControllo;
		private NullTypes.IntNT _Esito;
		private NullTypes.StringNT _SegnaturaVerbale;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.DatetimeNT _DataAggiornamento;
		private NullTypes.StringNT _Nominativo;
		private NullTypes.StringNT _LottoCert;
		private NullTypes.StringNT _DataLottoCert;
		private NullTypes.IntNT _IdLottoCert;
		[NonSerialized] private IControlliSecondoLivelloProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IControlliSecondoLivelloProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ControlliSecondoLivello()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ASSE
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT Asse
		{
			get { return _Asse; }
			set {
				if (Asse != value)
				{
					_Asse = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:AZIONE
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT Azione
		{
			get { return _Azione; }
			set {
				if (Azione != value)
				{
					_Azione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:INTERVENTO
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT Intervento
		{
			get { return _Intervento; }
			set {
				if (Intervento != value)
				{
					_Intervento = value;
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
		/// Corrisponde al campo:ID
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Id
		{
			get { return _Id; }
			set {
				if (Id != value)
				{
					_Id = value;
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
		/// Corrisponde al campo:ID_LOTTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdLotto
		{
			get { return _IdLotto; }
			set {
				if (IdLotto != value)
				{
					_IdLotto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TOTALE_SPESA_AMMESSA
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT TotaleSpesaAmmessa
		{
			get { return _TotaleSpesaAmmessa; }
			set {
				if (TotaleSpesaAmmessa != value)
				{
					_TotaleSpesaAmmessa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TOTALE_CONTRIBUTI_RENDICONTATI
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT TotaleContributiRendicontati
		{
			get { return _TotaleContributiRendicontati; }
			set {
				if (TotaleContributiRendicontati != value)
				{
					_TotaleContributiRendicontati = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SPESA_AMMESSA_IRREGOLARE
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT SpesaAmmessaIrregolare
		{
			get { return _SpesaAmmessaIrregolare; }
			set {
				if (SpesaAmmessaIrregolare != value)
				{
					_SpesaAmmessaIrregolare = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTRIBUTO_AMMESSO_IRREGOLARE
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ContributoAmmessoIrregolare
		{
			get { return _ContributoAmmessoIrregolare; }
			set {
				if (ContributoAmmessoIrregolare != value)
				{
					_ContributoAmmessoIrregolare = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTROLLORE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Controllore
		{
			get { return _Controllore; }
			set {
				if (Controllore != value)
				{
					_Controllore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_CONTROLLO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataControllo
		{
			get { return _DataControllo; }
			set {
				if (DataControllo != value)
				{
					_DataControllo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ESITO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Esito
		{
			get { return _Esito; }
			set {
				if (Esito != value)
				{
					_Esito = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SEGNATURA_VERBALE
		/// Tipo sul db:VARCHAR(250)
		/// </summary>
		public NullTypes.StringNT SegnaturaVerbale
		{
			get { return _SegnaturaVerbale; }
			set {
				if (SegnaturaVerbale != value)
				{
					_SegnaturaVerbale = value;
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
		/// Corrisponde al campo:DATA_AGGIORNAMENTO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataAggiornamento
		{
			get { return _DataAggiornamento; }
			set {
				if (DataAggiornamento != value)
				{
					_DataAggiornamento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOMINATIVO
		/// Tipo sul db:VARCHAR(511)
		/// </summary>
		public NullTypes.StringNT Nominativo
		{
			get { return _Nominativo; }
			set {
				if (Nominativo != value)
				{
					_Nominativo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:LOTTO_CERT
		/// Tipo sul db:VARCHAR(81)
		/// </summary>
		public NullTypes.StringNT LottoCert
		{
			get { return _LottoCert; }
			set {
				if (LottoCert != value)
				{
					_LottoCert = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_LOTTO_CERT
		/// Tipo sul db:VARCHAR(53)
		/// </summary>
		public NullTypes.StringNT DataLottoCert
		{
			get { return _DataLottoCert; }
			set {
				if (DataLottoCert != value)
				{
					_DataLottoCert = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_LOTTO_CERT
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdLottoCert
		{
			get { return _IdLottoCert; }
			set {
				if (IdLottoCert != value)
				{
					_IdLottoCert = value;
					SetDirtyFlag();
				}
			}
		}



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
	/// Summary description for ControlliSecondoLivelloCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ControlliSecondoLivelloCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ControlliSecondoLivelloCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ControlliSecondoLivello) info.GetValue(i.ToString(),typeof(ControlliSecondoLivello)));
			}
		}

		//Costruttore
		public ControlliSecondoLivelloCollection()
		{
			this.ItemType = typeof(ControlliSecondoLivello);
		}

		//Costruttore con provider
		public ControlliSecondoLivelloCollection(IControlliSecondoLivelloProvider providerObj)
		{
			this.ItemType = typeof(ControlliSecondoLivello);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ControlliSecondoLivello this[int index]
		{
			get { return (ControlliSecondoLivello)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ControlliSecondoLivelloCollection GetChanges()
		{
			return (ControlliSecondoLivelloCollection) base.GetChanges();
		}

		[NonSerialized] private IControlliSecondoLivelloProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IControlliSecondoLivelloProvider Provider
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
		public int Add(ControlliSecondoLivello ControlliSecondoLivelloObj)
		{
			if (ControlliSecondoLivelloObj.Provider == null) ControlliSecondoLivelloObj.Provider = this.Provider;
			return base.Add(ControlliSecondoLivelloObj);
		}

		//AddCollection
		public void AddCollection(ControlliSecondoLivelloCollection ControlliSecondoLivelloCollectionObj)
		{
			foreach (ControlliSecondoLivello ControlliSecondoLivelloObj in ControlliSecondoLivelloCollectionObj)
				this.Add(ControlliSecondoLivelloObj);
		}

		//Insert
		public void Insert(int index, ControlliSecondoLivello ControlliSecondoLivelloObj)
		{
			if (ControlliSecondoLivelloObj.Provider == null) ControlliSecondoLivelloObj.Provider = this.Provider;
			base.Insert(index, ControlliSecondoLivelloObj);
		}

		//CollectionGetById
		public ControlliSecondoLivello CollectionGetById(NullTypes.IntNT IdValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].Id == IdValue))
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
		public ControlliSecondoLivelloCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdLottoEqualThis, 
NullTypes.DecimalNT TotaleSpesaAmmessaEqualThis, NullTypes.DecimalNT TotaleContributiRendicontatiEqualThis, NullTypes.DecimalNT SpesaAmmessaIrregolareEqualThis, 
NullTypes.DecimalNT ContributoAmmessoIrregolareEqualThis, NullTypes.IntNT ControlloreEqualThis, NullTypes.DatetimeNT DataControlloEqualThis, 
NullTypes.IntNT EsitoEqualThis, NullTypes.StringNT SegnaturaVerbaleEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, 
NullTypes.DatetimeNT DataAggiornamentoEqualThis)
		{
			ControlliSecondoLivelloCollection ControlliSecondoLivelloCollectionTemp = new ControlliSecondoLivelloCollection();
			foreach (ControlliSecondoLivello ControlliSecondoLivelloItem in this)
			{
				if (((IdEqualThis == null) || ((ControlliSecondoLivelloItem.Id != null) && (ControlliSecondoLivelloItem.Id.Value == IdEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((ControlliSecondoLivelloItem.IdProgetto != null) && (ControlliSecondoLivelloItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdLottoEqualThis == null) || ((ControlliSecondoLivelloItem.IdLotto != null) && (ControlliSecondoLivelloItem.IdLotto.Value == IdLottoEqualThis.Value))) && 
((TotaleSpesaAmmessaEqualThis == null) || ((ControlliSecondoLivelloItem.TotaleSpesaAmmessa != null) && (ControlliSecondoLivelloItem.TotaleSpesaAmmessa.Value == TotaleSpesaAmmessaEqualThis.Value))) && ((TotaleContributiRendicontatiEqualThis == null) || ((ControlliSecondoLivelloItem.TotaleContributiRendicontati != null) && (ControlliSecondoLivelloItem.TotaleContributiRendicontati.Value == TotaleContributiRendicontatiEqualThis.Value))) && ((SpesaAmmessaIrregolareEqualThis == null) || ((ControlliSecondoLivelloItem.SpesaAmmessaIrregolare != null) && (ControlliSecondoLivelloItem.SpesaAmmessaIrregolare.Value == SpesaAmmessaIrregolareEqualThis.Value))) && 
((ContributoAmmessoIrregolareEqualThis == null) || ((ControlliSecondoLivelloItem.ContributoAmmessoIrregolare != null) && (ControlliSecondoLivelloItem.ContributoAmmessoIrregolare.Value == ContributoAmmessoIrregolareEqualThis.Value))) && ((ControlloreEqualThis == null) || ((ControlliSecondoLivelloItem.Controllore != null) && (ControlliSecondoLivelloItem.Controllore.Value == ControlloreEqualThis.Value))) && ((DataControlloEqualThis == null) || ((ControlliSecondoLivelloItem.DataControllo != null) && (ControlliSecondoLivelloItem.DataControllo.Value == DataControlloEqualThis.Value))) && 
((EsitoEqualThis == null) || ((ControlliSecondoLivelloItem.Esito != null) && (ControlliSecondoLivelloItem.Esito.Value == EsitoEqualThis.Value))) && ((SegnaturaVerbaleEqualThis == null) || ((ControlliSecondoLivelloItem.SegnaturaVerbale != null) && (ControlliSecondoLivelloItem.SegnaturaVerbale.Value == SegnaturaVerbaleEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((ControlliSecondoLivelloItem.DataInserimento != null) && (ControlliSecondoLivelloItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && 
((DataAggiornamentoEqualThis == null) || ((ControlliSecondoLivelloItem.DataAggiornamento != null) && (ControlliSecondoLivelloItem.DataAggiornamento.Value == DataAggiornamentoEqualThis.Value))))
				{
					ControlliSecondoLivelloCollectionTemp.Add(ControlliSecondoLivelloItem);
				}
			}
			return ControlliSecondoLivelloCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public ControlliSecondoLivelloCollection Filter(NullTypes.StringNT InterventoEqualThis, NullTypes.IntNT ControlloreEqualThis, NullTypes.IntNT EsitoEqualThis)
		{
			ControlliSecondoLivelloCollection ControlliSecondoLivelloCollectionTemp = new ControlliSecondoLivelloCollection();
			foreach (ControlliSecondoLivello ControlliSecondoLivelloItem in this)
			{
				if (((InterventoEqualThis == null) || ((ControlliSecondoLivelloItem.Intervento != null) && (ControlliSecondoLivelloItem.Intervento.Value == InterventoEqualThis.Value))) && ((ControlloreEqualThis == null) || ((ControlliSecondoLivelloItem.Controllore != null) && (ControlliSecondoLivelloItem.Controllore.Value == ControlloreEqualThis.Value))) && ((EsitoEqualThis == null) || ((ControlliSecondoLivelloItem.Esito != null) && (ControlliSecondoLivelloItem.Esito.Value == EsitoEqualThis.Value))))
				{
					ControlliSecondoLivelloCollectionTemp.Add(ControlliSecondoLivelloItem);
				}
			}
			return ControlliSecondoLivelloCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ControlliSecondoLivelloDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ControlliSecondoLivelloDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ControlliSecondoLivello ControlliSecondoLivelloObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", ControlliSecondoLivelloObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", ControlliSecondoLivelloObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdLotto", ControlliSecondoLivelloObj.IdLotto);
			DbProvider.SetCmdParam(cmd,firstChar + "TotaleSpesaAmmessa", ControlliSecondoLivelloObj.TotaleSpesaAmmessa);
			DbProvider.SetCmdParam(cmd,firstChar + "TotaleContributiRendicontati", ControlliSecondoLivelloObj.TotaleContributiRendicontati);
			DbProvider.SetCmdParam(cmd,firstChar + "SpesaAmmessaIrregolare", ControlliSecondoLivelloObj.SpesaAmmessaIrregolare);
			DbProvider.SetCmdParam(cmd,firstChar + "ContributoAmmessoIrregolare", ControlliSecondoLivelloObj.ContributoAmmessoIrregolare);
			DbProvider.SetCmdParam(cmd,firstChar + "Controllore", ControlliSecondoLivelloObj.Controllore);
			DbProvider.SetCmdParam(cmd,firstChar + "DataControllo", ControlliSecondoLivelloObj.DataControllo);
			DbProvider.SetCmdParam(cmd,firstChar + "Esito", ControlliSecondoLivelloObj.Esito);
			DbProvider.SetCmdParam(cmd,firstChar + "SegnaturaVerbale", ControlliSecondoLivelloObj.SegnaturaVerbale);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", ControlliSecondoLivelloObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataAggiornamento", ControlliSecondoLivelloObj.DataAggiornamento);
		}
		//Insert
		private static int Insert(DbProvider db, ControlliSecondoLivello ControlliSecondoLivelloObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZControlliSecondoLivelloInsert", new string[] {
"IdProgetto", 
"IdLotto", "TotaleSpesaAmmessa", "TotaleContributiRendicontati", 
"SpesaAmmessaIrregolare", "ContributoAmmessoIrregolare", "Controllore", 
"DataControllo", "Esito", "SegnaturaVerbale", 
"DataInserimento", "DataAggiornamento", }, new string[] {
"int", 
"int", "decimal", "decimal", 
"decimal", "decimal", "int", 
"DateTime", "int", "string", 
"DateTime", "DateTime", },"");
				CompileIUCmd(false, insertCmd,ControlliSecondoLivelloObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ControlliSecondoLivelloObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				ControlliSecondoLivelloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliSecondoLivelloObj.IsDirty = false;
				ControlliSecondoLivelloObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ControlliSecondoLivello ControlliSecondoLivelloObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZControlliSecondoLivelloUpdate", new string[] {
"Id", "IdProgetto", 
"IdLotto", "TotaleSpesaAmmessa", "TotaleContributiRendicontati", 
"SpesaAmmessaIrregolare", "ContributoAmmessoIrregolare", "Controllore", 
"DataControllo", "Esito", "SegnaturaVerbale", 
"DataInserimento", "DataAggiornamento", }, new string[] {
"int", "int", 
"int", "decimal", "decimal", 
"decimal", "decimal", "int", 
"DateTime", "int", "string", 
"DateTime", "DateTime", },"");
				CompileIUCmd(true, updateCmd,ControlliSecondoLivelloObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ControlliSecondoLivelloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliSecondoLivelloObj.IsDirty = false;
				ControlliSecondoLivelloObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ControlliSecondoLivello ControlliSecondoLivelloObj)
		{
			switch (ControlliSecondoLivelloObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ControlliSecondoLivelloObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ControlliSecondoLivelloObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ControlliSecondoLivelloObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ControlliSecondoLivelloCollection ControlliSecondoLivelloCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZControlliSecondoLivelloUpdate", new string[] {
"Id", "IdProgetto", 
"IdLotto", "TotaleSpesaAmmessa", "TotaleContributiRendicontati", 
"SpesaAmmessaIrregolare", "ContributoAmmessoIrregolare", "Controllore", 
"DataControllo", "Esito", "SegnaturaVerbale", 
"DataInserimento", "DataAggiornamento", }, new string[] {
"int", "int", 
"int", "decimal", "decimal", 
"decimal", "decimal", "int", 
"DateTime", "int", "string", 
"DateTime", "DateTime", },"");
				IDbCommand insertCmd = db.InitCmd( "ZControlliSecondoLivelloInsert", new string[] {
"IdProgetto", 
"IdLotto", "TotaleSpesaAmmessa", "TotaleContributiRendicontati", 
"SpesaAmmessaIrregolare", "ContributoAmmessoIrregolare", "Controllore", 
"DataControllo", "Esito", "SegnaturaVerbale", 
"DataInserimento", "DataAggiornamento", }, new string[] {
"int", 
"int", "decimal", "decimal", 
"decimal", "decimal", "int", 
"DateTime", "int", "string", 
"DateTime", "DateTime", },"");
				IDbCommand deleteCmd = db.InitCmd( "ZControlliSecondoLivelloDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ControlliSecondoLivelloCollectionObj.Count; i++)
				{
					switch (ControlliSecondoLivelloCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ControlliSecondoLivelloCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ControlliSecondoLivelloCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ControlliSecondoLivelloCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ControlliSecondoLivelloCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)ControlliSecondoLivelloCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ControlliSecondoLivelloCollectionObj.Count; i++)
				{
					if ((ControlliSecondoLivelloCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ControlliSecondoLivelloCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ControlliSecondoLivelloCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ControlliSecondoLivelloCollectionObj[i].IsDirty = false;
						ControlliSecondoLivelloCollectionObj[i].IsPersistent = true;
					}
					if ((ControlliSecondoLivelloCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ControlliSecondoLivelloCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ControlliSecondoLivelloCollectionObj[i].IsDirty = false;
						ControlliSecondoLivelloCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ControlliSecondoLivello ControlliSecondoLivelloObj)
		{
			int returnValue = 0;
			if (ControlliSecondoLivelloObj.IsPersistent) 
			{
				returnValue = Delete(db, ControlliSecondoLivelloObj.Id);
			}
			ControlliSecondoLivelloObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ControlliSecondoLivelloObj.IsDirty = false;
			ControlliSecondoLivelloObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZControlliSecondoLivelloDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ControlliSecondoLivelloCollection ControlliSecondoLivelloCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZControlliSecondoLivelloDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ControlliSecondoLivelloCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", ControlliSecondoLivelloCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ControlliSecondoLivelloCollectionObj.Count; i++)
				{
					if ((ControlliSecondoLivelloCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ControlliSecondoLivelloCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ControlliSecondoLivelloCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ControlliSecondoLivelloCollectionObj[i].IsDirty = false;
						ControlliSecondoLivelloCollectionObj[i].IsPersistent = false;
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
		public static ControlliSecondoLivello GetById(DbProvider db, int IdValue)
		{
			ControlliSecondoLivello ControlliSecondoLivelloObj = null;
			IDbCommand readCmd = db.InitCmd( "ZControlliSecondoLivelloGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ControlliSecondoLivelloObj = GetFromDatareader(db);
				ControlliSecondoLivelloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliSecondoLivelloObj.IsDirty = false;
				ControlliSecondoLivelloObj.IsPersistent = true;
			}
			db.Close();
			return ControlliSecondoLivelloObj;
		}

		//getFromDatareader
		public static ControlliSecondoLivello GetFromDatareader(DbProvider db)
		{
			ControlliSecondoLivello ControlliSecondoLivelloObj = new ControlliSecondoLivello();
			ControlliSecondoLivelloObj.Asse = new SiarLibrary.NullTypes.StringNT(db.DataReader["ASSE"]);
			ControlliSecondoLivelloObj.Azione = new SiarLibrary.NullTypes.StringNT(db.DataReader["AZIONE"]);
			ControlliSecondoLivelloObj.Intervento = new SiarLibrary.NullTypes.StringNT(db.DataReader["INTERVENTO"]);
			ControlliSecondoLivelloObj.DescrizioneIntervento = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_INTERVENTO"]);
			ControlliSecondoLivelloObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			ControlliSecondoLivelloObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			ControlliSecondoLivelloObj.IdLotto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOTTO"]);
			ControlliSecondoLivelloObj.TotaleSpesaAmmessa = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TOTALE_SPESA_AMMESSA"]);
			ControlliSecondoLivelloObj.TotaleContributiRendicontati = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TOTALE_CONTRIBUTI_RENDICONTATI"]);
			ControlliSecondoLivelloObj.SpesaAmmessaIrregolare = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SPESA_AMMESSA_IRREGOLARE"]);
			ControlliSecondoLivelloObj.ContributoAmmessoIrregolare = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_AMMESSO_IRREGOLARE"]);
			ControlliSecondoLivelloObj.Controllore = new SiarLibrary.NullTypes.IntNT(db.DataReader["CONTROLLORE"]);
			ControlliSecondoLivelloObj.DataControllo = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CONTROLLO"]);
			ControlliSecondoLivelloObj.Esito = new SiarLibrary.NullTypes.IntNT(db.DataReader["ESITO"]);
			ControlliSecondoLivelloObj.SegnaturaVerbale = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_VERBALE"]);
			ControlliSecondoLivelloObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			ControlliSecondoLivelloObj.DataAggiornamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_AGGIORNAMENTO"]);
			ControlliSecondoLivelloObj.Nominativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO"]);
			ControlliSecondoLivelloObj.LottoCert = new SiarLibrary.NullTypes.StringNT(db.DataReader["LOTTO_CERT"]);
			ControlliSecondoLivelloObj.DataLottoCert = new SiarLibrary.NullTypes.StringNT(db.DataReader["DATA_LOTTO_CERT"]);
			ControlliSecondoLivelloObj.IdLottoCert = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOTTO_CERT"]);
			ControlliSecondoLivelloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ControlliSecondoLivelloObj.IsDirty = false;
			ControlliSecondoLivelloObj.IsPersistent = true;
			return ControlliSecondoLivelloObj;
		}

		//Find Select

		public static ControlliSecondoLivelloCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdLottoEqualThis, 
SiarLibrary.NullTypes.DecimalNT TotaleSpesaAmmessaEqualThis, SiarLibrary.NullTypes.DecimalNT TotaleContributiRendicontatiEqualThis, SiarLibrary.NullTypes.DecimalNT SpesaAmmessaIrregolareEqualThis, 
SiarLibrary.NullTypes.DecimalNT ContributoAmmessoIrregolareEqualThis, SiarLibrary.NullTypes.IntNT ControlloreEqualThis, SiarLibrary.NullTypes.DatetimeNT DataControlloEqualThis, 
SiarLibrary.NullTypes.IntNT EsitoEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaVerbaleEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataAggiornamentoEqualThis)

		{

			ControlliSecondoLivelloCollection ControlliSecondoLivelloCollectionObj = new ControlliSecondoLivelloCollection();

			IDbCommand findCmd = db.InitCmd("Zcontrollisecondolivellofindselect", new string[] {"Idequalthis", "IdProgettoequalthis", "IdLottoequalthis", 
"TotaleSpesaAmmessaequalthis", "TotaleContributiRendicontatiequalthis", "SpesaAmmessaIrregolareequalthis", 
"ContributoAmmessoIrregolareequalthis", "Controlloreequalthis", "DataControlloequalthis", 
"Esitoequalthis", "SegnaturaVerbaleequalthis", "DataInserimentoequalthis", 
"DataAggiornamentoequalthis"}, new string[] {"int", "int", "int", 
"decimal", "decimal", "decimal", 
"decimal", "int", "DateTime", 
"int", "string", "DateTime", 
"DateTime"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdLottoequalthis", IdLottoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TotaleSpesaAmmessaequalthis", TotaleSpesaAmmessaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TotaleContributiRendicontatiequalthis", TotaleContributiRendicontatiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SpesaAmmessaIrregolareequalthis", SpesaAmmessaIrregolareEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ContributoAmmessoIrregolareequalthis", ContributoAmmessoIrregolareEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Controlloreequalthis", ControlloreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataControlloequalthis", DataControlloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Esitoequalthis", EsitoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SegnaturaVerbaleequalthis", SegnaturaVerbaleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataAggiornamentoequalthis", DataAggiornamentoEqualThis);
			ControlliSecondoLivello ControlliSecondoLivelloObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ControlliSecondoLivelloObj = GetFromDatareader(db);
				ControlliSecondoLivelloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliSecondoLivelloObj.IsDirty = false;
				ControlliSecondoLivelloObj.IsPersistent = true;
				ControlliSecondoLivelloCollectionObj.Add(ControlliSecondoLivelloObj);
			}
			db.Close();
			return ControlliSecondoLivelloCollectionObj;
		}

		//Find Find

		public static ControlliSecondoLivelloCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT InterventoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdLottoEqualThis, 
SiarLibrary.NullTypes.IntNT ControlloreEqualThis, SiarLibrary.NullTypes.IntNT EsitoEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaVerbaleEqualThis)

		{

			ControlliSecondoLivelloCollection ControlliSecondoLivelloCollectionObj = new ControlliSecondoLivelloCollection();

			IDbCommand findCmd = db.InitCmd("Zcontrollisecondolivellofindfind", new string[] {"Interventoequalthis", "IdProgettoequalthis", "IdLottoequalthis", 
"Controlloreequalthis", "Esitoequalthis", "SegnaturaVerbaleequalthis"}, new string[] {"string", "int", "int", 
"int", "int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Interventoequalthis", InterventoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdLottoequalthis", IdLottoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Controlloreequalthis", ControlloreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Esitoequalthis", EsitoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SegnaturaVerbaleequalthis", SegnaturaVerbaleEqualThis);
			ControlliSecondoLivello ControlliSecondoLivelloObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ControlliSecondoLivelloObj = GetFromDatareader(db);
				ControlliSecondoLivelloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliSecondoLivelloObj.IsDirty = false;
				ControlliSecondoLivelloObj.IsPersistent = true;
				ControlliSecondoLivelloCollectionObj.Add(ControlliSecondoLivelloObj);
			}
			db.Close();
			return ControlliSecondoLivelloCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ControlliSecondoLivelloCollectionProvider:IControlliSecondoLivelloProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ControlliSecondoLivelloCollectionProvider : IControlliSecondoLivelloProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ControlliSecondoLivello
		protected ControlliSecondoLivelloCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ControlliSecondoLivelloCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ControlliSecondoLivelloCollection(this);
		}

		//Costruttore 2: popola la collection
		public ControlliSecondoLivelloCollectionProvider(StringNT InterventoEqualThis, IntNT IdprogettoEqualThis, IntNT IdlottoEqualThis, 
IntNT ControlloreEqualThis, IntNT EsitoEqualThis, StringNT SegnaturaverbaleEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(InterventoEqualThis, IdprogettoEqualThis, IdlottoEqualThis, 
ControlloreEqualThis, EsitoEqualThis, SegnaturaverbaleEqualThis);
		}

		//Costruttore3: ha in input controllisecondolivelloCollectionObj - non popola la collection
		public ControlliSecondoLivelloCollectionProvider(ControlliSecondoLivelloCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ControlliSecondoLivelloCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ControlliSecondoLivelloCollection(this);
		}

		//Get e Set
		public ControlliSecondoLivelloCollection CollectionObj
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
		public int SaveCollection(ControlliSecondoLivelloCollection collectionObj)
		{
			return ControlliSecondoLivelloDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ControlliSecondoLivello controllisecondolivelloObj)
		{
			return ControlliSecondoLivelloDAL.Save(_dbProviderObj, controllisecondolivelloObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ControlliSecondoLivelloCollection collectionObj)
		{
			return ControlliSecondoLivelloDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ControlliSecondoLivello controllisecondolivelloObj)
		{
			return ControlliSecondoLivelloDAL.Delete(_dbProviderObj, controllisecondolivelloObj);
		}

		//getById
		public ControlliSecondoLivello GetById(IntNT IdValue)
		{
			ControlliSecondoLivello ControlliSecondoLivelloTemp = ControlliSecondoLivelloDAL.GetById(_dbProviderObj, IdValue);
			if (ControlliSecondoLivelloTemp!=null) ControlliSecondoLivelloTemp.Provider = this;
			return ControlliSecondoLivelloTemp;
		}

		//Select: popola la collection
		public ControlliSecondoLivelloCollection Select(IntNT IdEqualThis, IntNT IdprogettoEqualThis, IntNT IdlottoEqualThis, 
DecimalNT TotalespesaammessaEqualThis, DecimalNT TotalecontributirendicontatiEqualThis, DecimalNT SpesaammessairregolareEqualThis, 
DecimalNT ContributoammessoirregolareEqualThis, IntNT ControlloreEqualThis, DatetimeNT DatacontrolloEqualThis, 
IntNT EsitoEqualThis, StringNT SegnaturaverbaleEqualThis, DatetimeNT DatainserimentoEqualThis, 
DatetimeNT DataaggiornamentoEqualThis)
		{
			ControlliSecondoLivelloCollection ControlliSecondoLivelloCollectionTemp = ControlliSecondoLivelloDAL.Select(_dbProviderObj, IdEqualThis, IdprogettoEqualThis, IdlottoEqualThis, 
TotalespesaammessaEqualThis, TotalecontributirendicontatiEqualThis, SpesaammessairregolareEqualThis, 
ContributoammessoirregolareEqualThis, ControlloreEqualThis, DatacontrolloEqualThis, 
EsitoEqualThis, SegnaturaverbaleEqualThis, DatainserimentoEqualThis, 
DataaggiornamentoEqualThis);
			ControlliSecondoLivelloCollectionTemp.Provider = this;
			return ControlliSecondoLivelloCollectionTemp;
		}

		//Find: popola la collection
		public ControlliSecondoLivelloCollection Find(StringNT InterventoEqualThis, IntNT IdprogettoEqualThis, IntNT IdlottoEqualThis, 
IntNT ControlloreEqualThis, IntNT EsitoEqualThis, StringNT SegnaturaverbaleEqualThis)
		{
			ControlliSecondoLivelloCollection ControlliSecondoLivelloCollectionTemp = ControlliSecondoLivelloDAL.Find(_dbProviderObj, InterventoEqualThis, IdprogettoEqualThis, IdlottoEqualThis, 
ControlloreEqualThis, EsitoEqualThis, SegnaturaverbaleEqualThis);
			ControlliSecondoLivelloCollectionTemp.Provider = this;
			return ControlliSecondoLivelloCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CONTROLLI_SECONDO_LIVELLO>
  <ViewName>vCONTROLLI_SECONDO_LIVELLO</ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>True</chkDataModifica>
  <txtNomeCampoDataModifica>DATA_AGGIORNAMENTO</txtNomeCampoDataModifica>
  <chkOptimisticCouncurrency>False</chkOptimisticCouncurrency>
  <chkShortNames>False</chkShortNames>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds>
    <Find OrderBy="ORDER BY ID_PROGETTO">
      <INTERVENTO>Equal</INTERVENTO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_LOTTO>Equal</ID_LOTTO>
      <CONTROLLORE>Equal</CONTROLLORE>
      <ESITO>Equal</ESITO>
      <SEGNATURA_VERBALE>Equal</SEGNATURA_VERBALE>
    </Find>
  </Finds>
  <Filters>
    <Filter>
      <INTERVENTO>Equal</INTERVENTO>
      <CONTROLLORE>Equal</CONTROLLORE>
      <ESITO>Equal</ESITO>
    </Filter>
  </Filters>
  <externalFields />
  <AddedFkFields />
</CONTROLLI_SECONDO_LIVELLO>
*/
