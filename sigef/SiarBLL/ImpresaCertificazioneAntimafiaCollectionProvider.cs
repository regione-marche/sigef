using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ImpresaCertificazioneAntimafia
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IImpresaCertificazioneAntimafiaProvider
	{
		int Save(ImpresaCertificazioneAntimafia ImpresaCertificazioneAntimafiaObj);
		int SaveCollection(ImpresaCertificazioneAntimafiaCollection collectionObj);
		int Delete(ImpresaCertificazioneAntimafia ImpresaCertificazioneAntimafiaObj);
		int DeleteCollection(ImpresaCertificazioneAntimafiaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ImpresaCertificazioneAntimafia
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ImpresaCertificazioneAntimafia: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.BoolNT _EsenzioneCertificazione;
		private NullTypes.DatetimeNT _DataInizioValidita;
		private NullTypes.DatetimeNT _DataFineValidita;
		private NullTypes.StringNT _NumeroProtocolloRichiesta;
		private NullTypes.DatetimeNT _DataProtocolloRichiesta;
		private NullTypes.StringNT _NumeroProtocolloCamerale;
		private NullTypes.DatetimeNT _DataCertificatoCamerale;
		private NullTypes.BoolNT _EsitoCertificatoCamerale;
		private NullTypes.StringNT _NumeroProtocolloPrefettizio;
		private NullTypes.DatetimeNT _DataCertificatoPrefettizio;
		private NullTypes.BoolNT _EsitoCertificatoPrefettizio;
		private NullTypes.StringNT _NumeroProtocolloComunicazione;
		private NullTypes.DatetimeNT _DataProtocolloComunicazione;
		private NullTypes.DatetimeNT _DataAcquisizioneAntimafia;
		private NullTypes.StringNT _NumeroProtocolloAcquisizioneAntimafia;
		[NonSerialized] private IImpresaCertificazioneAntimafiaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IImpresaCertificazioneAntimafiaProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ImpresaCertificazioneAntimafia()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
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
		/// Corrisponde al campo:ESENZIONE_CERTIFICAZIONE
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT EsenzioneCertificazione
		{
			get { return _EsenzioneCertificazione; }
			set {
				if (EsenzioneCertificazione != value)
				{
					_EsenzioneCertificazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_INIZIO_VALIDITA
		/// Tipo sul db:DATETIME
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
		/// Corrisponde al campo:NUMERO_PROTOCOLLO_RICHIESTA
		/// Tipo sul db:VARCHAR(30)
		/// </summary>
		public NullTypes.StringNT NumeroProtocolloRichiesta
		{
			get { return _NumeroProtocolloRichiesta; }
			set {
				if (NumeroProtocolloRichiesta != value)
				{
					_NumeroProtocolloRichiesta = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_PROTOCOLLO_RICHIESTA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataProtocolloRichiesta
		{
			get { return _DataProtocolloRichiesta; }
			set {
				if (DataProtocolloRichiesta != value)
				{
					_DataProtocolloRichiesta = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NUMERO_PROTOCOLLO_CAMERALE
		/// Tipo sul db:VARCHAR(30)
		/// </summary>
		public NullTypes.StringNT NumeroProtocolloCamerale
		{
			get { return _NumeroProtocolloCamerale; }
			set {
				if (NumeroProtocolloCamerale != value)
				{
					_NumeroProtocolloCamerale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_CERTIFICATO_CAMERALE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataCertificatoCamerale
		{
			get { return _DataCertificatoCamerale; }
			set {
				if (DataCertificatoCamerale != value)
				{
					_DataCertificatoCamerale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ESITO_CERTIFICATO_CAMERALE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT EsitoCertificatoCamerale
		{
			get { return _EsitoCertificatoCamerale; }
			set {
				if (EsitoCertificatoCamerale != value)
				{
					_EsitoCertificatoCamerale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NUMERO_PROTOCOLLO_PREFETTIZIO
		/// Tipo sul db:VARCHAR(30)
		/// </summary>
		public NullTypes.StringNT NumeroProtocolloPrefettizio
		{
			get { return _NumeroProtocolloPrefettizio; }
			set {
				if (NumeroProtocolloPrefettizio != value)
				{
					_NumeroProtocolloPrefettizio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_CERTIFICATO_PREFETTIZIO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataCertificatoPrefettizio
		{
			get { return _DataCertificatoPrefettizio; }
			set {
				if (DataCertificatoPrefettizio != value)
				{
					_DataCertificatoPrefettizio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ESITO_CERTIFICATO_PREFETTIZIO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT EsitoCertificatoPrefettizio
		{
			get { return _EsitoCertificatoPrefettizio; }
			set {
				if (EsitoCertificatoPrefettizio != value)
				{
					_EsitoCertificatoPrefettizio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NUMERO_PROTOCOLLO_COMUNICAZIONE
		/// Tipo sul db:VARCHAR(30)
		/// </summary>
		public NullTypes.StringNT NumeroProtocolloComunicazione
		{
			get { return _NumeroProtocolloComunicazione; }
			set {
				if (NumeroProtocolloComunicazione != value)
				{
					_NumeroProtocolloComunicazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_PROTOCOLLO_COMUNICAZIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataProtocolloComunicazione
		{
			get { return _DataProtocolloComunicazione; }
			set {
				if (DataProtocolloComunicazione != value)
				{
					_DataProtocolloComunicazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_ACQUISIZIONE_ANTIMAFIA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataAcquisizioneAntimafia
		{
			get { return _DataAcquisizioneAntimafia; }
			set {
				if (DataAcquisizioneAntimafia != value)
				{
					_DataAcquisizioneAntimafia = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NUMERO_PROTOCOLLO_ACQUISIZIONE_ANTIMAFIA
		/// Tipo sul db:VARCHAR(30)
		/// </summary>
		public NullTypes.StringNT NumeroProtocolloAcquisizioneAntimafia
		{
			get { return _NumeroProtocolloAcquisizioneAntimafia; }
			set {
				if (NumeroProtocolloAcquisizioneAntimafia != value)
				{
					_NumeroProtocolloAcquisizioneAntimafia = value;
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
	/// Summary description for ImpresaCertificazioneAntimafiaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ImpresaCertificazioneAntimafiaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ImpresaCertificazioneAntimafiaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ImpresaCertificazioneAntimafia) info.GetValue(i.ToString(),typeof(ImpresaCertificazioneAntimafia)));
			}
		}

		//Costruttore
		public ImpresaCertificazioneAntimafiaCollection()
		{
			this.ItemType = typeof(ImpresaCertificazioneAntimafia);
		}

		//Costruttore con provider
		public ImpresaCertificazioneAntimafiaCollection(IImpresaCertificazioneAntimafiaProvider providerObj)
		{
			this.ItemType = typeof(ImpresaCertificazioneAntimafia);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ImpresaCertificazioneAntimafia this[int index]
		{
			get { return (ImpresaCertificazioneAntimafia)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ImpresaCertificazioneAntimafiaCollection GetChanges()
		{
			return (ImpresaCertificazioneAntimafiaCollection) base.GetChanges();
		}

		[NonSerialized] private IImpresaCertificazioneAntimafiaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IImpresaCertificazioneAntimafiaProvider Provider
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
		public int Add(ImpresaCertificazioneAntimafia ImpresaCertificazioneAntimafiaObj)
		{
			if (ImpresaCertificazioneAntimafiaObj.Provider == null) ImpresaCertificazioneAntimafiaObj.Provider = this.Provider;
			return base.Add(ImpresaCertificazioneAntimafiaObj);
		}

		//AddCollection
		public void AddCollection(ImpresaCertificazioneAntimafiaCollection ImpresaCertificazioneAntimafiaCollectionObj)
		{
			foreach (ImpresaCertificazioneAntimafia ImpresaCertificazioneAntimafiaObj in ImpresaCertificazioneAntimafiaCollectionObj)
				this.Add(ImpresaCertificazioneAntimafiaObj);
		}

		//Insert
		public void Insert(int index, ImpresaCertificazioneAntimafia ImpresaCertificazioneAntimafiaObj)
		{
			if (ImpresaCertificazioneAntimafiaObj.Provider == null) ImpresaCertificazioneAntimafiaObj.Provider = this.Provider;
			base.Insert(index, ImpresaCertificazioneAntimafiaObj);
		}

		//CollectionGetById
		public ImpresaCertificazioneAntimafia CollectionGetById(NullTypes.IntNT IdValue)
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
		public ImpresaCertificazioneAntimafiaCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdImpresaEqualThis, NullTypes.BoolNT EsenzioneCertificazioneEqualThis, 
NullTypes.DatetimeNT DataInizioValiditaEqualThis, NullTypes.DatetimeNT DataFineValiditaEqualThis, NullTypes.StringNT NumeroProtocolloRichiestaEqualThis, 
NullTypes.DatetimeNT DataProtocolloRichiestaEqualThis, NullTypes.StringNT NumeroProtocolloCameraleEqualThis, NullTypes.DatetimeNT DataCertificatoCameraleEqualThis, 
NullTypes.BoolNT EsitoCertificatoCameraleEqualThis, NullTypes.StringNT NumeroProtocolloPrefettizioEqualThis, NullTypes.DatetimeNT DataCertificatoPrefettizioEqualThis, 
NullTypes.BoolNT EsitoCertificatoPrefettizioEqualThis, NullTypes.StringNT NumeroProtocolloComunicazioneEqualThis, NullTypes.DatetimeNT DataProtocolloComunicazioneEqualThis, 
NullTypes.DatetimeNT DataAcquisizioneAntimafiaEqualThis, NullTypes.StringNT NumeroProtocolloAcquisizioneAntimafiaEqualThis)
		{
			ImpresaCertificazioneAntimafiaCollection ImpresaCertificazioneAntimafiaCollectionTemp = new ImpresaCertificazioneAntimafiaCollection();
			foreach (ImpresaCertificazioneAntimafia ImpresaCertificazioneAntimafiaItem in this)
			{
				if (((IdEqualThis == null) || ((ImpresaCertificazioneAntimafiaItem.Id != null) && (ImpresaCertificazioneAntimafiaItem.Id.Value == IdEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((ImpresaCertificazioneAntimafiaItem.IdImpresa != null) && (ImpresaCertificazioneAntimafiaItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((EsenzioneCertificazioneEqualThis == null) || ((ImpresaCertificazioneAntimafiaItem.EsenzioneCertificazione != null) && (ImpresaCertificazioneAntimafiaItem.EsenzioneCertificazione.Value == EsenzioneCertificazioneEqualThis.Value))) && 
((DataInizioValiditaEqualThis == null) || ((ImpresaCertificazioneAntimafiaItem.DataInizioValidita != null) && (ImpresaCertificazioneAntimafiaItem.DataInizioValidita.Value == DataInizioValiditaEqualThis.Value))) && ((DataFineValiditaEqualThis == null) || ((ImpresaCertificazioneAntimafiaItem.DataFineValidita != null) && (ImpresaCertificazioneAntimafiaItem.DataFineValidita.Value == DataFineValiditaEqualThis.Value))) && ((NumeroProtocolloRichiestaEqualThis == null) || ((ImpresaCertificazioneAntimafiaItem.NumeroProtocolloRichiesta != null) && (ImpresaCertificazioneAntimafiaItem.NumeroProtocolloRichiesta.Value == NumeroProtocolloRichiestaEqualThis.Value))) && 
((DataProtocolloRichiestaEqualThis == null) || ((ImpresaCertificazioneAntimafiaItem.DataProtocolloRichiesta != null) && (ImpresaCertificazioneAntimafiaItem.DataProtocolloRichiesta.Value == DataProtocolloRichiestaEqualThis.Value))) && ((NumeroProtocolloCameraleEqualThis == null) || ((ImpresaCertificazioneAntimafiaItem.NumeroProtocolloCamerale != null) && (ImpresaCertificazioneAntimafiaItem.NumeroProtocolloCamerale.Value == NumeroProtocolloCameraleEqualThis.Value))) && ((DataCertificatoCameraleEqualThis == null) || ((ImpresaCertificazioneAntimafiaItem.DataCertificatoCamerale != null) && (ImpresaCertificazioneAntimafiaItem.DataCertificatoCamerale.Value == DataCertificatoCameraleEqualThis.Value))) && 
((EsitoCertificatoCameraleEqualThis == null) || ((ImpresaCertificazioneAntimafiaItem.EsitoCertificatoCamerale != null) && (ImpresaCertificazioneAntimafiaItem.EsitoCertificatoCamerale.Value == EsitoCertificatoCameraleEqualThis.Value))) && ((NumeroProtocolloPrefettizioEqualThis == null) || ((ImpresaCertificazioneAntimafiaItem.NumeroProtocolloPrefettizio != null) && (ImpresaCertificazioneAntimafiaItem.NumeroProtocolloPrefettizio.Value == NumeroProtocolloPrefettizioEqualThis.Value))) && ((DataCertificatoPrefettizioEqualThis == null) || ((ImpresaCertificazioneAntimafiaItem.DataCertificatoPrefettizio != null) && (ImpresaCertificazioneAntimafiaItem.DataCertificatoPrefettizio.Value == DataCertificatoPrefettizioEqualThis.Value))) && 
((EsitoCertificatoPrefettizioEqualThis == null) || ((ImpresaCertificazioneAntimafiaItem.EsitoCertificatoPrefettizio != null) && (ImpresaCertificazioneAntimafiaItem.EsitoCertificatoPrefettizio.Value == EsitoCertificatoPrefettizioEqualThis.Value))) && ((NumeroProtocolloComunicazioneEqualThis == null) || ((ImpresaCertificazioneAntimafiaItem.NumeroProtocolloComunicazione != null) && (ImpresaCertificazioneAntimafiaItem.NumeroProtocolloComunicazione.Value == NumeroProtocolloComunicazioneEqualThis.Value))) && ((DataProtocolloComunicazioneEqualThis == null) || ((ImpresaCertificazioneAntimafiaItem.DataProtocolloComunicazione != null) && (ImpresaCertificazioneAntimafiaItem.DataProtocolloComunicazione.Value == DataProtocolloComunicazioneEqualThis.Value))) && 
((DataAcquisizioneAntimafiaEqualThis == null) || ((ImpresaCertificazioneAntimafiaItem.DataAcquisizioneAntimafia != null) && (ImpresaCertificazioneAntimafiaItem.DataAcquisizioneAntimafia.Value == DataAcquisizioneAntimafiaEqualThis.Value))) && ((NumeroProtocolloAcquisizioneAntimafiaEqualThis == null) || ((ImpresaCertificazioneAntimafiaItem.NumeroProtocolloAcquisizioneAntimafia != null) && (ImpresaCertificazioneAntimafiaItem.NumeroProtocolloAcquisizioneAntimafia.Value == NumeroProtocolloAcquisizioneAntimafiaEqualThis.Value))))
				{
					ImpresaCertificazioneAntimafiaCollectionTemp.Add(ImpresaCertificazioneAntimafiaItem);
				}
			}
			return ImpresaCertificazioneAntimafiaCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ImpresaCertificazioneAntimafiaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ImpresaCertificazioneAntimafiaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ImpresaCertificazioneAntimafia ImpresaCertificazioneAntimafiaObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", ImpresaCertificazioneAntimafiaObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdImpresa", ImpresaCertificazioneAntimafiaObj.IdImpresa);
			DbProvider.SetCmdParam(cmd,firstChar + "EsenzioneCertificazione", ImpresaCertificazioneAntimafiaObj.EsenzioneCertificazione);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInizioValidita", ImpresaCertificazioneAntimafiaObj.DataInizioValidita);
			DbProvider.SetCmdParam(cmd,firstChar + "DataFineValidita", ImpresaCertificazioneAntimafiaObj.DataFineValidita);
			DbProvider.SetCmdParam(cmd,firstChar + "NumeroProtocolloRichiesta", ImpresaCertificazioneAntimafiaObj.NumeroProtocolloRichiesta);
			DbProvider.SetCmdParam(cmd,firstChar + "DataProtocolloRichiesta", ImpresaCertificazioneAntimafiaObj.DataProtocolloRichiesta);
			DbProvider.SetCmdParam(cmd,firstChar + "NumeroProtocolloCamerale", ImpresaCertificazioneAntimafiaObj.NumeroProtocolloCamerale);
			DbProvider.SetCmdParam(cmd,firstChar + "DataCertificatoCamerale", ImpresaCertificazioneAntimafiaObj.DataCertificatoCamerale);
			DbProvider.SetCmdParam(cmd,firstChar + "EsitoCertificatoCamerale", ImpresaCertificazioneAntimafiaObj.EsitoCertificatoCamerale);
			DbProvider.SetCmdParam(cmd,firstChar + "NumeroProtocolloPrefettizio", ImpresaCertificazioneAntimafiaObj.NumeroProtocolloPrefettizio);
			DbProvider.SetCmdParam(cmd,firstChar + "DataCertificatoPrefettizio", ImpresaCertificazioneAntimafiaObj.DataCertificatoPrefettizio);
			DbProvider.SetCmdParam(cmd,firstChar + "EsitoCertificatoPrefettizio", ImpresaCertificazioneAntimafiaObj.EsitoCertificatoPrefettizio);
			DbProvider.SetCmdParam(cmd,firstChar + "NumeroProtocolloComunicazione", ImpresaCertificazioneAntimafiaObj.NumeroProtocolloComunicazione);
			DbProvider.SetCmdParam(cmd,firstChar + "DataProtocolloComunicazione", ImpresaCertificazioneAntimafiaObj.DataProtocolloComunicazione);
			DbProvider.SetCmdParam(cmd,firstChar + "DataAcquisizioneAntimafia", ImpresaCertificazioneAntimafiaObj.DataAcquisizioneAntimafia);
			DbProvider.SetCmdParam(cmd,firstChar + "NumeroProtocolloAcquisizioneAntimafia", ImpresaCertificazioneAntimafiaObj.NumeroProtocolloAcquisizioneAntimafia);
		}
		//Insert
		private static int Insert(DbProvider db, ImpresaCertificazioneAntimafia ImpresaCertificazioneAntimafiaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZImpresaCertificazioneAntimafiaInsert", new string[] {"IdImpresa", "EsenzioneCertificazione", 
"DataInizioValidita", "DataFineValidita", "NumeroProtocolloRichiesta", 
"DataProtocolloRichiesta", "NumeroProtocolloCamerale", "DataCertificatoCamerale", 
"EsitoCertificatoCamerale", "NumeroProtocolloPrefettizio", "DataCertificatoPrefettizio", 
"EsitoCertificatoPrefettizio", "NumeroProtocolloComunicazione", "DataProtocolloComunicazione", 
"DataAcquisizioneAntimafia", "NumeroProtocolloAcquisizioneAntimafia"}, new string[] {"int", "bool", 
"DateTime", "DateTime", "string", 
"DateTime", "string", "DateTime", 
"bool", "string", "DateTime", 
"bool", "string", "DateTime", 
"DateTime", "string"},"");
				CompileIUCmd(false, insertCmd,ImpresaCertificazioneAntimafiaObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ImpresaCertificazioneAntimafiaObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				ImpresaCertificazioneAntimafiaObj.EsenzioneCertificazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ESENZIONE_CERTIFICAZIONE"]);
				}
				ImpresaCertificazioneAntimafiaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ImpresaCertificazioneAntimafiaObj.IsDirty = false;
				ImpresaCertificazioneAntimafiaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ImpresaCertificazioneAntimafia ImpresaCertificazioneAntimafiaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZImpresaCertificazioneAntimafiaUpdate", new string[] {"Id", "IdImpresa", "EsenzioneCertificazione", 
"DataInizioValidita", "DataFineValidita", "NumeroProtocolloRichiesta", 
"DataProtocolloRichiesta", "NumeroProtocolloCamerale", "DataCertificatoCamerale", 
"EsitoCertificatoCamerale", "NumeroProtocolloPrefettizio", "DataCertificatoPrefettizio", 
"EsitoCertificatoPrefettizio", "NumeroProtocolloComunicazione", "DataProtocolloComunicazione", 
"DataAcquisizioneAntimafia", "NumeroProtocolloAcquisizioneAntimafia"}, new string[] {"int", "int", "bool", 
"DateTime", "DateTime", "string", 
"DateTime", "string", "DateTime", 
"bool", "string", "DateTime", 
"bool", "string", "DateTime", 
"DateTime", "string"},"");
				CompileIUCmd(true, updateCmd,ImpresaCertificazioneAntimafiaObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ImpresaCertificazioneAntimafiaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ImpresaCertificazioneAntimafiaObj.IsDirty = false;
				ImpresaCertificazioneAntimafiaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ImpresaCertificazioneAntimafia ImpresaCertificazioneAntimafiaObj)
		{
			switch (ImpresaCertificazioneAntimafiaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ImpresaCertificazioneAntimafiaObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ImpresaCertificazioneAntimafiaObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ImpresaCertificazioneAntimafiaObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ImpresaCertificazioneAntimafiaCollection ImpresaCertificazioneAntimafiaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZImpresaCertificazioneAntimafiaUpdate", new string[] {"Id", "IdImpresa", "EsenzioneCertificazione", 
"DataInizioValidita", "DataFineValidita", "NumeroProtocolloRichiesta", 
"DataProtocolloRichiesta", "NumeroProtocolloCamerale", "DataCertificatoCamerale", 
"EsitoCertificatoCamerale", "NumeroProtocolloPrefettizio", "DataCertificatoPrefettizio", 
"EsitoCertificatoPrefettizio", "NumeroProtocolloComunicazione", "DataProtocolloComunicazione", 
"DataAcquisizioneAntimafia", "NumeroProtocolloAcquisizioneAntimafia"}, new string[] {"int", "int", "bool", 
"DateTime", "DateTime", "string", 
"DateTime", "string", "DateTime", 
"bool", "string", "DateTime", 
"bool", "string", "DateTime", 
"DateTime", "string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZImpresaCertificazioneAntimafiaInsert", new string[] {"IdImpresa", "EsenzioneCertificazione", 
"DataInizioValidita", "DataFineValidita", "NumeroProtocolloRichiesta", 
"DataProtocolloRichiesta", "NumeroProtocolloCamerale", "DataCertificatoCamerale", 
"EsitoCertificatoCamerale", "NumeroProtocolloPrefettizio", "DataCertificatoPrefettizio", 
"EsitoCertificatoPrefettizio", "NumeroProtocolloComunicazione", "DataProtocolloComunicazione", 
"DataAcquisizioneAntimafia", "NumeroProtocolloAcquisizioneAntimafia"}, new string[] {"int", "bool", 
"DateTime", "DateTime", "string", 
"DateTime", "string", "DateTime", 
"bool", "string", "DateTime", 
"bool", "string", "DateTime", 
"DateTime", "string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZImpresaCertificazioneAntimafiaDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ImpresaCertificazioneAntimafiaCollectionObj.Count; i++)
				{
					switch (ImpresaCertificazioneAntimafiaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ImpresaCertificazioneAntimafiaCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ImpresaCertificazioneAntimafiaCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
									ImpresaCertificazioneAntimafiaCollectionObj[i].EsenzioneCertificazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ESENZIONE_CERTIFICAZIONE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ImpresaCertificazioneAntimafiaCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ImpresaCertificazioneAntimafiaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)ImpresaCertificazioneAntimafiaCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ImpresaCertificazioneAntimafiaCollectionObj.Count; i++)
				{
					if ((ImpresaCertificazioneAntimafiaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ImpresaCertificazioneAntimafiaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ImpresaCertificazioneAntimafiaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ImpresaCertificazioneAntimafiaCollectionObj[i].IsDirty = false;
						ImpresaCertificazioneAntimafiaCollectionObj[i].IsPersistent = true;
					}
					if ((ImpresaCertificazioneAntimafiaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ImpresaCertificazioneAntimafiaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ImpresaCertificazioneAntimafiaCollectionObj[i].IsDirty = false;
						ImpresaCertificazioneAntimafiaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ImpresaCertificazioneAntimafia ImpresaCertificazioneAntimafiaObj)
		{
			int returnValue = 0;
			if (ImpresaCertificazioneAntimafiaObj.IsPersistent) 
			{
				returnValue = Delete(db, ImpresaCertificazioneAntimafiaObj.Id);
			}
			ImpresaCertificazioneAntimafiaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ImpresaCertificazioneAntimafiaObj.IsDirty = false;
			ImpresaCertificazioneAntimafiaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZImpresaCertificazioneAntimafiaDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ImpresaCertificazioneAntimafiaCollection ImpresaCertificazioneAntimafiaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZImpresaCertificazioneAntimafiaDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ImpresaCertificazioneAntimafiaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", ImpresaCertificazioneAntimafiaCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ImpresaCertificazioneAntimafiaCollectionObj.Count; i++)
				{
					if ((ImpresaCertificazioneAntimafiaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ImpresaCertificazioneAntimafiaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ImpresaCertificazioneAntimafiaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ImpresaCertificazioneAntimafiaCollectionObj[i].IsDirty = false;
						ImpresaCertificazioneAntimafiaCollectionObj[i].IsPersistent = false;
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
		public static ImpresaCertificazioneAntimafia GetById(DbProvider db, int IdValue)
		{
			ImpresaCertificazioneAntimafia ImpresaCertificazioneAntimafiaObj = null;
			IDbCommand readCmd = db.InitCmd( "ZImpresaCertificazioneAntimafiaGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ImpresaCertificazioneAntimafiaObj = GetFromDatareader(db);
				ImpresaCertificazioneAntimafiaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ImpresaCertificazioneAntimafiaObj.IsDirty = false;
				ImpresaCertificazioneAntimafiaObj.IsPersistent = true;
			}
			db.Close();
			return ImpresaCertificazioneAntimafiaObj;
		}

		//getFromDatareader
		public static ImpresaCertificazioneAntimafia GetFromDatareader(DbProvider db)
		{
			ImpresaCertificazioneAntimafia ImpresaCertificazioneAntimafiaObj = new ImpresaCertificazioneAntimafia();
			ImpresaCertificazioneAntimafiaObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			ImpresaCertificazioneAntimafiaObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			ImpresaCertificazioneAntimafiaObj.EsenzioneCertificazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ESENZIONE_CERTIFICAZIONE"]);
			ImpresaCertificazioneAntimafiaObj.DataInizioValidita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO_VALIDITA"]);
			ImpresaCertificazioneAntimafiaObj.DataFineValidita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE_VALIDITA"]);
			ImpresaCertificazioneAntimafiaObj.NumeroProtocolloRichiesta = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO_PROTOCOLLO_RICHIESTA"]);
			ImpresaCertificazioneAntimafiaObj.DataProtocolloRichiesta = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_PROTOCOLLO_RICHIESTA"]);
			ImpresaCertificazioneAntimafiaObj.NumeroProtocolloCamerale = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO_PROTOCOLLO_CAMERALE"]);
			ImpresaCertificazioneAntimafiaObj.DataCertificatoCamerale = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CERTIFICATO_CAMERALE"]);
			ImpresaCertificazioneAntimafiaObj.EsitoCertificatoCamerale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ESITO_CERTIFICATO_CAMERALE"]);
			ImpresaCertificazioneAntimafiaObj.NumeroProtocolloPrefettizio = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO_PROTOCOLLO_PREFETTIZIO"]);
			ImpresaCertificazioneAntimafiaObj.DataCertificatoPrefettizio = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CERTIFICATO_PREFETTIZIO"]);
			ImpresaCertificazioneAntimafiaObj.EsitoCertificatoPrefettizio = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ESITO_CERTIFICATO_PREFETTIZIO"]);
			ImpresaCertificazioneAntimafiaObj.NumeroProtocolloComunicazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO_PROTOCOLLO_COMUNICAZIONE"]);
			ImpresaCertificazioneAntimafiaObj.DataProtocolloComunicazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_PROTOCOLLO_COMUNICAZIONE"]);
			ImpresaCertificazioneAntimafiaObj.DataAcquisizioneAntimafia = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_ACQUISIZIONE_ANTIMAFIA"]);
			ImpresaCertificazioneAntimafiaObj.NumeroProtocolloAcquisizioneAntimafia = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO_PROTOCOLLO_ACQUISIZIONE_ANTIMAFIA"]);
			ImpresaCertificazioneAntimafiaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ImpresaCertificazioneAntimafiaObj.IsDirty = false;
			ImpresaCertificazioneAntimafiaObj.IsPersistent = true;
			return ImpresaCertificazioneAntimafiaObj;
		}

		//Find Select

		public static ImpresaCertificazioneAntimafiaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.BoolNT EsenzioneCertificazioneEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataInizioValiditaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataFineValiditaEqualThis, SiarLibrary.NullTypes.StringNT NumeroProtocolloRichiestaEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataProtocolloRichiestaEqualThis, SiarLibrary.NullTypes.StringNT NumeroProtocolloCameraleEqualThis, SiarLibrary.NullTypes.DatetimeNT DataCertificatoCameraleEqualThis, 
SiarLibrary.NullTypes.BoolNT EsitoCertificatoCameraleEqualThis, SiarLibrary.NullTypes.StringNT NumeroProtocolloPrefettizioEqualThis, SiarLibrary.NullTypes.DatetimeNT DataCertificatoPrefettizioEqualThis, 
SiarLibrary.NullTypes.BoolNT EsitoCertificatoPrefettizioEqualThis, SiarLibrary.NullTypes.StringNT NumeroProtocolloComunicazioneEqualThis, SiarLibrary.NullTypes.DatetimeNT DataProtocolloComunicazioneEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataAcquisizioneAntimafiaEqualThis, SiarLibrary.NullTypes.StringNT NumeroProtocolloAcquisizioneAntimafiaEqualThis)

		{

			ImpresaCertificazioneAntimafiaCollection ImpresaCertificazioneAntimafiaCollectionObj = new ImpresaCertificazioneAntimafiaCollection();

			IDbCommand findCmd = db.InitCmd("Zimpresacertificazioneantimafiafindselect", new string[] {"Idequalthis", "IdImpresaequalthis", "EsenzioneCertificazioneequalthis", 
"DataInizioValiditaequalthis", "DataFineValiditaequalthis", "NumeroProtocolloRichiestaequalthis", 
"DataProtocolloRichiestaequalthis", "NumeroProtocolloCameraleequalthis", "DataCertificatoCameraleequalthis", 
"EsitoCertificatoCameraleequalthis", "NumeroProtocolloPrefettizioequalthis", "DataCertificatoPrefettizioequalthis", 
"EsitoCertificatoPrefettizioequalthis", "NumeroProtocolloComunicazioneequalthis", "DataProtocolloComunicazioneequalthis", 
"DataAcquisizioneAntimafiaequalthis", "NumeroProtocolloAcquisizioneAntimafiaequalthis"}, new string[] {"int", "int", "bool", 
"DateTime", "DateTime", "string", 
"DateTime", "string", "DateTime", 
"bool", "string", "DateTime", 
"bool", "string", "DateTime", 
"DateTime", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "EsenzioneCertificazioneequalthis", EsenzioneCertificazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInizioValiditaequalthis", DataInizioValiditaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataFineValiditaequalthis", DataFineValiditaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NumeroProtocolloRichiestaequalthis", NumeroProtocolloRichiestaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataProtocolloRichiestaequalthis", DataProtocolloRichiestaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NumeroProtocolloCameraleequalthis", NumeroProtocolloCameraleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataCertificatoCameraleequalthis", DataCertificatoCameraleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "EsitoCertificatoCameraleequalthis", EsitoCertificatoCameraleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NumeroProtocolloPrefettizioequalthis", NumeroProtocolloPrefettizioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataCertificatoPrefettizioequalthis", DataCertificatoPrefettizioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "EsitoCertificatoPrefettizioequalthis", EsitoCertificatoPrefettizioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NumeroProtocolloComunicazioneequalthis", NumeroProtocolloComunicazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataProtocolloComunicazioneequalthis", DataProtocolloComunicazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataAcquisizioneAntimafiaequalthis", DataAcquisizioneAntimafiaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NumeroProtocolloAcquisizioneAntimafiaequalthis", NumeroProtocolloAcquisizioneAntimafiaEqualThis);
			ImpresaCertificazioneAntimafia ImpresaCertificazioneAntimafiaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ImpresaCertificazioneAntimafiaObj = GetFromDatareader(db);
				ImpresaCertificazioneAntimafiaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ImpresaCertificazioneAntimafiaObj.IsDirty = false;
				ImpresaCertificazioneAntimafiaObj.IsPersistent = true;
				ImpresaCertificazioneAntimafiaCollectionObj.Add(ImpresaCertificazioneAntimafiaObj);
			}
			db.Close();
			return ImpresaCertificazioneAntimafiaCollectionObj;
		}

		//Find Find

		public static ImpresaCertificazioneAntimafiaCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis)

		{

			ImpresaCertificazioneAntimafiaCollection ImpresaCertificazioneAntimafiaCollectionObj = new ImpresaCertificazioneAntimafiaCollection();

			IDbCommand findCmd = db.InitCmd("Zimpresacertificazioneantimafiafindfind", new string[] {"IdImpresaequalthis"}, new string[] {"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			ImpresaCertificazioneAntimafia ImpresaCertificazioneAntimafiaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ImpresaCertificazioneAntimafiaObj = GetFromDatareader(db);
				ImpresaCertificazioneAntimafiaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ImpresaCertificazioneAntimafiaObj.IsDirty = false;
				ImpresaCertificazioneAntimafiaObj.IsPersistent = true;
				ImpresaCertificazioneAntimafiaCollectionObj.Add(ImpresaCertificazioneAntimafiaObj);
			}
			db.Close();
			return ImpresaCertificazioneAntimafiaCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ImpresaCertificazioneAntimafiaCollectionProvider:IImpresaCertificazioneAntimafiaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ImpresaCertificazioneAntimafiaCollectionProvider : IImpresaCertificazioneAntimafiaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ImpresaCertificazioneAntimafia
		protected ImpresaCertificazioneAntimafiaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ImpresaCertificazioneAntimafiaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ImpresaCertificazioneAntimafiaCollection(this);
		}

		//Costruttore 2: popola la collection
		public ImpresaCertificazioneAntimafiaCollectionProvider(IntNT IdimpresaEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdimpresaEqualThis);
		}

		//Costruttore3: ha in input impresacertificazioneantimafiaCollectionObj - non popola la collection
		public ImpresaCertificazioneAntimafiaCollectionProvider(ImpresaCertificazioneAntimafiaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ImpresaCertificazioneAntimafiaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ImpresaCertificazioneAntimafiaCollection(this);
		}

		//Get e Set
		public ImpresaCertificazioneAntimafiaCollection CollectionObj
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
		public int SaveCollection(ImpresaCertificazioneAntimafiaCollection collectionObj)
		{
			return ImpresaCertificazioneAntimafiaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ImpresaCertificazioneAntimafia impresacertificazioneantimafiaObj)
		{
			return ImpresaCertificazioneAntimafiaDAL.Save(_dbProviderObj, impresacertificazioneantimafiaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ImpresaCertificazioneAntimafiaCollection collectionObj)
		{
			return ImpresaCertificazioneAntimafiaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ImpresaCertificazioneAntimafia impresacertificazioneantimafiaObj)
		{
			return ImpresaCertificazioneAntimafiaDAL.Delete(_dbProviderObj, impresacertificazioneantimafiaObj);
		}

		//getById
		public ImpresaCertificazioneAntimafia GetById(IntNT IdValue)
		{
			ImpresaCertificazioneAntimafia ImpresaCertificazioneAntimafiaTemp = ImpresaCertificazioneAntimafiaDAL.GetById(_dbProviderObj, IdValue);
			if (ImpresaCertificazioneAntimafiaTemp!=null) ImpresaCertificazioneAntimafiaTemp.Provider = this;
			return ImpresaCertificazioneAntimafiaTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ImpresaCertificazioneAntimafiaCollection Select(IntNT IdEqualThis, IntNT IdimpresaEqualThis, BoolNT EsenzionecertificazioneEqualThis, 
DatetimeNT DatainiziovaliditaEqualThis, DatetimeNT DatafinevaliditaEqualThis, StringNT NumeroprotocollorichiestaEqualThis, 
DatetimeNT DataprotocollorichiestaEqualThis, StringNT NumeroprotocollocameraleEqualThis, DatetimeNT DatacertificatocameraleEqualThis, 
BoolNT EsitocertificatocameraleEqualThis, StringNT NumeroprotocolloprefettizioEqualThis, DatetimeNT DatacertificatoprefettizioEqualThis, 
BoolNT EsitocertificatoprefettizioEqualThis, StringNT NumeroprotocollocomunicazioneEqualThis, DatetimeNT DataprotocollocomunicazioneEqualThis, 
DatetimeNT DataacquisizioneantimafiaEqualThis, StringNT NumeroprotocolloacquisizioneantimafiaEqualThis)
		{
			ImpresaCertificazioneAntimafiaCollection ImpresaCertificazioneAntimafiaCollectionTemp = ImpresaCertificazioneAntimafiaDAL.Select(_dbProviderObj, IdEqualThis, IdimpresaEqualThis, EsenzionecertificazioneEqualThis, 
DatainiziovaliditaEqualThis, DatafinevaliditaEqualThis, NumeroprotocollorichiestaEqualThis, 
DataprotocollorichiestaEqualThis, NumeroprotocollocameraleEqualThis, DatacertificatocameraleEqualThis, 
EsitocertificatocameraleEqualThis, NumeroprotocolloprefettizioEqualThis, DatacertificatoprefettizioEqualThis, 
EsitocertificatoprefettizioEqualThis, NumeroprotocollocomunicazioneEqualThis, DataprotocollocomunicazioneEqualThis, 
DataacquisizioneantimafiaEqualThis, NumeroprotocolloacquisizioneantimafiaEqualThis);
			ImpresaCertificazioneAntimafiaCollectionTemp.Provider = this;
			return ImpresaCertificazioneAntimafiaCollectionTemp;
		}

		//Find: popola la collection
		public ImpresaCertificazioneAntimafiaCollection Find(IntNT IdimpresaEqualThis)
		{
			ImpresaCertificazioneAntimafiaCollection ImpresaCertificazioneAntimafiaCollectionTemp = ImpresaCertificazioneAntimafiaDAL.Find(_dbProviderObj, IdimpresaEqualThis);
			ImpresaCertificazioneAntimafiaCollectionTemp.Provider = this;
			return ImpresaCertificazioneAntimafiaCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<IMPRESA_CERTIFICAZIONE_ANTIMAFIA>
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
    <Find OrderBy="ORDER BY ">
      <ID_IMPRESA>Equal</ID_IMPRESA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</IMPRESA_CERTIFICAZIONE_ANTIMAFIA>
*/
