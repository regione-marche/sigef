using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per DomandaPagamentoFidejussioneImpresa
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IDomandaPagamentoFidejussioneImpresaProvider
	{
		int Save(DomandaPagamentoFidejussioneImpresa DomandaPagamentoFidejussioneImpresaObj);
		int SaveCollection(DomandaPagamentoFidejussioneImpresaCollection collectionObj);
		int Delete(DomandaPagamentoFidejussioneImpresa DomandaPagamentoFidejussioneImpresaObj);
		int DeleteCollection(DomandaPagamentoFidejussioneImpresaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for DomandaPagamentoFidejussioneImpresa
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class DomandaPagamentoFidejussioneImpresa : BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdDomandaPagamentoFidejussioneImpresa;
		private NullTypes.IntNT _IdDomandaPagamentoFidejussione;
		private NullTypes.IntNT _IdDomandaPagamento;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.DecimalNT _Importo;
		private NullTypes.DecimalNT _AmmontareRichiesto;
		private NullTypes.DatetimeNT _DataFineLavori;
		private NullTypes.DatetimeNT _DataScadenza;
		private NullTypes.BoolNT _Stampato;
		private NullTypes.StringNT _Numero;
		private NullTypes.DatetimeNT _DataSottoscrizione;
		private NullTypes.StringNT _LuogoSottoscrizione;
		private NullTypes.StringNT _PivaGarante;
		private NullTypes.StringNT _RagioneSocialeGarante;
		private NullTypes.StringNT _LocalitaGarante;
		private NullTypes.StringNT _NumeroRegistroImprese;
		private NullTypes.StringNT _CognomeRapplegale;
		private NullTypes.StringNT _NomeRapplegale;
		private NullTypes.StringNT _CfRapplegale;
		private NullTypes.DatetimeNT _DataNascitaRapplegale;
		private NullTypes.BoolNT _StampaEffettuata;
		private NullTypes.DatetimeNT _DataRichiestaValidita;
		private NullTypes.DatetimeNT _DataRicevimentoValidita;
		private NullTypes.StringNT _ProtocolloFaxValidita;
		private NullTypes.DatetimeNT _DataDecorrenzaGaranzia;
		private NullTypes.StringNT _CodiceAbiEnteGarante;
		private NullTypes.StringNT _CodiceCabEnteGarante;
		private NullTypes.StringNT _CodTipo;
		private NullTypes.StringNT _UfficioApprovazione;
		private NullTypes.IntNT _NumDecretoApprovazione;
		private NullTypes.DatetimeNT _DataDecretoApprovazione;
		private NullTypes.BoolNT _Esente;
		private NullTypes.BoolNT _NoAnticipo;
		[NonSerialized] private IDomandaPagamentoFidejussioneImpresaProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public IDomandaPagamentoFidejussioneImpresaProvider Provider
		{
			get { return _provider; }
			set { _provider = value; }
		}


		//Costruttore
		public DomandaPagamentoFidejussioneImpresa()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_DOMANDA_PAGAMENTO_FIDEJUSSIONE_IMPRESA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDomandaPagamentoFidejussioneImpresa
		{
			get { return _IdDomandaPagamentoFidejussioneImpresa; }
			set
			{
				if (IdDomandaPagamentoFidejussioneImpresa != value)
				{
					_IdDomandaPagamentoFidejussioneImpresa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_DOMANDA_PAGAMENTO_FIDEJUSSIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDomandaPagamentoFidejussione
		{
			get { return _IdDomandaPagamentoFidejussione; }
			set
			{
				if (IdDomandaPagamentoFidejussione != value)
				{
					_IdDomandaPagamentoFidejussione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_DOMANDA_PAGAMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDomandaPagamento
		{
			get { return _IdDomandaPagamento; }
			set
			{
				if (IdDomandaPagamento != value)
				{
					_IdDomandaPagamento = value;
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
			set
			{
				if (IdProgetto != value)
				{
					_IdProgetto = value;
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
			set
			{
				if (IdImpresa != value)
				{
					_IdImpresa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT Importo
		{
			get { return _Importo; }
			set
			{
				if (Importo != value)
				{
					_Importo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:AMMONTARE_RICHIESTO
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT AmmontareRichiesto
		{
			get { return _AmmontareRichiesto; }
			set
			{
				if (AmmontareRichiesto != value)
				{
					_AmmontareRichiesto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_FINE_LAVORI
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataFineLavori
		{
			get { return _DataFineLavori; }
			set
			{
				if (DataFineLavori != value)
				{
					_DataFineLavori = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_SCADENZA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataScadenza
		{
			get { return _DataScadenza; }
			set
			{
				if (DataScadenza != value)
				{
					_DataScadenza = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:STAMPATO
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT Stampato
		{
			get { return _Stampato; }
			set
			{
				if (Stampato != value)
				{
					_Stampato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NUMERO
		/// Tipo sul db:VARCHAR(25)
		/// </summary>
		public NullTypes.StringNT Numero
		{
			get { return _Numero; }
			set
			{
				if (Numero != value)
				{
					_Numero = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_SOTTOSCRIZIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataSottoscrizione
		{
			get { return _DataSottoscrizione; }
			set
			{
				if (DataSottoscrizione != value)
				{
					_DataSottoscrizione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:LUOGO_SOTTOSCRIZIONE
		/// Tipo sul db:VARCHAR(128)
		/// </summary>
		public NullTypes.StringNT LuogoSottoscrizione
		{
			get { return _LuogoSottoscrizione; }
			set
			{
				if (LuogoSottoscrizione != value)
				{
					_LuogoSottoscrizione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PIVA_GARANTE
		/// Tipo sul db:VARCHAR(11)
		/// </summary>
		public NullTypes.StringNT PivaGarante
		{
			get { return _PivaGarante; }
			set
			{
				if (PivaGarante != value)
				{
					_PivaGarante = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RAGIONE_SOCIALE_GARANTE
		/// Tipo sul db:VARCHAR(150)
		/// </summary>
		public NullTypes.StringNT RagioneSocialeGarante
		{
			get { return _RagioneSocialeGarante; }
			set
			{
				if (RagioneSocialeGarante != value)
				{
					_RagioneSocialeGarante = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:LOCALITA_GARANTE
		/// Tipo sul db:VARCHAR(128)
		/// </summary>
		public NullTypes.StringNT LocalitaGarante
		{
			get { return _LocalitaGarante; }
			set
			{
				if (LocalitaGarante != value)
				{
					_LocalitaGarante = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NUMERO_REGISTRO_IMPRESE
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT NumeroRegistroImprese
		{
			get { return _NumeroRegistroImprese; }
			set
			{
				if (NumeroRegistroImprese != value)
				{
					_NumeroRegistroImprese = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COGNOME_RAPPLEGALE
		/// Tipo sul db:VARCHAR(30)
		/// </summary>
		public NullTypes.StringNT CognomeRapplegale
		{
			get { return _CognomeRapplegale; }
			set
			{
				if (CognomeRapplegale != value)
				{
					_CognomeRapplegale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOME_RAPPLEGALE
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT NomeRapplegale
		{
			get { return _NomeRapplegale; }
			set
			{
				if (NomeRapplegale != value)
				{
					_NomeRapplegale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_RAPPLEGALE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CfRapplegale
		{
			get { return _CfRapplegale; }
			set
			{
				if (CfRapplegale != value)
				{
					_CfRapplegale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_NASCITA_RAPPLEGALE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataNascitaRapplegale
		{
			get { return _DataNascitaRapplegale; }
			set
			{
				if (DataNascitaRapplegale != value)
				{
					_DataNascitaRapplegale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:STAMPA_EFFETTUATA
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT StampaEffettuata
		{
			get { return _StampaEffettuata; }
			set
			{
				if (StampaEffettuata != value)
				{
					_StampaEffettuata = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_RICHIESTA_VALIDITA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataRichiestaValidita
		{
			get { return _DataRichiestaValidita; }
			set
			{
				if (DataRichiestaValidita != value)
				{
					_DataRichiestaValidita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_RICEVIMENTO_VALIDITA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataRicevimentoValidita
		{
			get { return _DataRicevimentoValidita; }
			set
			{
				if (DataRicevimentoValidita != value)
				{
					_DataRicevimentoValidita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PROTOCOLLO_FAX_VALIDITA
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT ProtocolloFaxValidita
		{
			get { return _ProtocolloFaxValidita; }
			set
			{
				if (ProtocolloFaxValidita != value)
				{
					_ProtocolloFaxValidita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_DECORRENZA_GARANZIA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataDecorrenzaGaranzia
		{
			get { return _DataDecorrenzaGaranzia; }
			set
			{
				if (DataDecorrenzaGaranzia != value)
				{
					_DataDecorrenzaGaranzia = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE_ABI_ENTE_GARANTE
		/// Tipo sul db:VARCHAR(5)
		/// </summary>
		public NullTypes.StringNT CodiceAbiEnteGarante
		{
			get { return _CodiceAbiEnteGarante; }
			set
			{
				if (CodiceAbiEnteGarante != value)
				{
					_CodiceAbiEnteGarante = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE_CAB_ENTE_GARANTE
		/// Tipo sul db:VARCHAR(5)
		/// </summary>
		public NullTypes.StringNT CodiceCabEnteGarante
		{
			get { return _CodiceCabEnteGarante; }
			set
			{
				if (CodiceCabEnteGarante != value)
				{
					_CodiceCabEnteGarante = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_TIPO
		/// Tipo sul db:CHAR(3)
		/// </summary>
		public NullTypes.StringNT CodTipo
		{
			get { return _CodTipo; }
			set
			{
				if (CodTipo != value)
				{
					_CodTipo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:UFFICIO_APPROVAZIONE
		/// Tipo sul db:VARCHAR(120)
		/// </summary>
		public NullTypes.StringNT UfficioApprovazione
		{
			get { return _UfficioApprovazione; }
			set
			{
				if (UfficioApprovazione != value)
				{
					_UfficioApprovazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NUM_DECRETO_APPROVAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT NumDecretoApprovazione
		{
			get { return _NumDecretoApprovazione; }
			set
			{
				if (NumDecretoApprovazione != value)
				{
					_NumDecretoApprovazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_DECRETO_APPROVAZIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataDecretoApprovazione
		{
			get { return _DataDecretoApprovazione; }
			set
			{
				if (DataDecretoApprovazione != value)
				{
					_DataDecretoApprovazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ESENTE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Esente
		{
			get { return _Esente; }
			set
			{
				if (Esente != value)
				{
					_Esente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NO_ANTICIPO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT NoAnticipo
		{
			get { return _NoAnticipo; }
			set
			{
				if (NoAnticipo != value)
				{
					_NoAnticipo = value;
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
	/// Summary description for DomandaPagamentoFidejussioneImpresaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class DomandaPagamentoFidejussioneImpresaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
	{

		//Serializzazione xml
		public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
		{
			info.AddValue("_count", this.Count);
			for (int i = 0; i < this.Count; i++)
			{
				info.AddValue(i.ToString(), this[i]);
			}
		}
		private DomandaPagamentoFidejussioneImpresaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
		{
			int c = info.GetInt32("_count");
			for (int i = 0; i < c; i++)
			{
				this.Add((DomandaPagamentoFidejussioneImpresa)info.GetValue(i.ToString(), typeof(DomandaPagamentoFidejussioneImpresa)));
			}
		}

		//Costruttore
		public DomandaPagamentoFidejussioneImpresaCollection()
		{
			this.ItemType = typeof(DomandaPagamentoFidejussioneImpresa);
		}

		//Costruttore con provider
		public DomandaPagamentoFidejussioneImpresaCollection(IDomandaPagamentoFidejussioneImpresaProvider providerObj)
		{
			this.ItemType = typeof(DomandaPagamentoFidejussioneImpresa);
			this.Provider = providerObj;
		}

		//Get e Set
		public new DomandaPagamentoFidejussioneImpresa this[int index]
		{
			get { return (DomandaPagamentoFidejussioneImpresa)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new DomandaPagamentoFidejussioneImpresaCollection GetChanges()
		{
			return (DomandaPagamentoFidejussioneImpresaCollection)base.GetChanges();
		}

		[NonSerialized] private IDomandaPagamentoFidejussioneImpresaProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public IDomandaPagamentoFidejussioneImpresaProvider Provider
		{
			get { return _provider; }
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
		public int Add(DomandaPagamentoFidejussioneImpresa DomandaPagamentoFidejussioneImpresaObj)
		{
			if (DomandaPagamentoFidejussioneImpresaObj.Provider == null) DomandaPagamentoFidejussioneImpresaObj.Provider = this.Provider;
			return base.Add(DomandaPagamentoFidejussioneImpresaObj);
		}

		//AddCollection
		public void AddCollection(DomandaPagamentoFidejussioneImpresaCollection DomandaPagamentoFidejussioneImpresaCollectionObj)
		{
			foreach (DomandaPagamentoFidejussioneImpresa DomandaPagamentoFidejussioneImpresaObj in DomandaPagamentoFidejussioneImpresaCollectionObj)
				this.Add(DomandaPagamentoFidejussioneImpresaObj);
		}

		//Insert
		public void Insert(int index, DomandaPagamentoFidejussioneImpresa DomandaPagamentoFidejussioneImpresaObj)
		{
			if (DomandaPagamentoFidejussioneImpresaObj.Provider == null) DomandaPagamentoFidejussioneImpresaObj.Provider = this.Provider;
			base.Insert(index, DomandaPagamentoFidejussioneImpresaObj);
		}

		//CollectionGetById
		public DomandaPagamentoFidejussioneImpresa CollectionGetById(NullTypes.IntNT IdDomandaPagamentoFidejussioneImpresaValue)
		{
			int i = 0;
			bool find = false;
			while ((i < this.Count) && (!find))
			{
				if ((this[i].IdDomandaPagamentoFidejussioneImpresa == IdDomandaPagamentoFidejussioneImpresaValue))
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
		public DomandaPagamentoFidejussioneImpresaCollection SubSelect(NullTypes.IntNT IdDomandaPagamentoFidejussioneImpresaEqualThis, NullTypes.IntNT IdDomandaPagamentoFidejussioneEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis,
NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdImpresaEqualThis, NullTypes.DecimalNT ImportoEqualThis,
NullTypes.DecimalNT AmmontareRichiestoEqualThis, NullTypes.DatetimeNT DataFineLavoriEqualThis, NullTypes.DatetimeNT DataScadenzaEqualThis,
NullTypes.BoolNT StampatoEqualThis, NullTypes.StringNT NumeroEqualThis, NullTypes.DatetimeNT DataSottoscrizioneEqualThis,
NullTypes.StringNT LuogoSottoscrizioneEqualThis, NullTypes.StringNT PivaGaranteEqualThis, NullTypes.StringNT RagioneSocialeGaranteEqualThis,
NullTypes.StringNT LocalitaGaranteEqualThis, NullTypes.StringNT NumeroRegistroImpreseEqualThis, NullTypes.StringNT CognomeRapplegaleEqualThis,
NullTypes.StringNT NomeRapplegaleEqualThis, NullTypes.StringNT CfRapplegaleEqualThis, NullTypes.DatetimeNT DataNascitaRapplegaleEqualThis,
NullTypes.BoolNT StampaEffettuataEqualThis, NullTypes.DatetimeNT DataRichiestaValiditaEqualThis, NullTypes.DatetimeNT DataRicevimentoValiditaEqualThis,
NullTypes.StringNT ProtocolloFaxValiditaEqualThis, NullTypes.DatetimeNT DataDecorrenzaGaranziaEqualThis, NullTypes.StringNT CodiceAbiEnteGaranteEqualThis,
NullTypes.StringNT CodiceCabEnteGaranteEqualThis, NullTypes.StringNT CodTipoEqualThis, NullTypes.StringNT UfficioApprovazioneEqualThis,
NullTypes.IntNT NumDecretoApprovazioneEqualThis, NullTypes.DatetimeNT DataDecretoApprovazioneEqualThis, NullTypes.BoolNT EsenteEqualThis,
NullTypes.BoolNT NoAnticipoEqualThis)
		{
			DomandaPagamentoFidejussioneImpresaCollection DomandaPagamentoFidejussioneImpresaCollectionTemp = new DomandaPagamentoFidejussioneImpresaCollection();
			foreach (DomandaPagamentoFidejussioneImpresa DomandaPagamentoFidejussioneImpresaItem in this)
			{
				if (((IdDomandaPagamentoFidejussioneImpresaEqualThis == null) || ((DomandaPagamentoFidejussioneImpresaItem.IdDomandaPagamentoFidejussioneImpresa != null) && (DomandaPagamentoFidejussioneImpresaItem.IdDomandaPagamentoFidejussioneImpresa.Value == IdDomandaPagamentoFidejussioneImpresaEqualThis.Value))) && ((IdDomandaPagamentoFidejussioneEqualThis == null) || ((DomandaPagamentoFidejussioneImpresaItem.IdDomandaPagamentoFidejussione != null) && (DomandaPagamentoFidejussioneImpresaItem.IdDomandaPagamentoFidejussione.Value == IdDomandaPagamentoFidejussioneEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((DomandaPagamentoFidejussioneImpresaItem.IdDomandaPagamento != null) && (DomandaPagamentoFidejussioneImpresaItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) &&
((IdProgettoEqualThis == null) || ((DomandaPagamentoFidejussioneImpresaItem.IdProgetto != null) && (DomandaPagamentoFidejussioneImpresaItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((DomandaPagamentoFidejussioneImpresaItem.IdImpresa != null) && (DomandaPagamentoFidejussioneImpresaItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((ImportoEqualThis == null) || ((DomandaPagamentoFidejussioneImpresaItem.Importo != null) && (DomandaPagamentoFidejussioneImpresaItem.Importo.Value == ImportoEqualThis.Value))) &&
((AmmontareRichiestoEqualThis == null) || ((DomandaPagamentoFidejussioneImpresaItem.AmmontareRichiesto != null) && (DomandaPagamentoFidejussioneImpresaItem.AmmontareRichiesto.Value == AmmontareRichiestoEqualThis.Value))) && ((DataFineLavoriEqualThis == null) || ((DomandaPagamentoFidejussioneImpresaItem.DataFineLavori != null) && (DomandaPagamentoFidejussioneImpresaItem.DataFineLavori.Value == DataFineLavoriEqualThis.Value))) && ((DataScadenzaEqualThis == null) || ((DomandaPagamentoFidejussioneImpresaItem.DataScadenza != null) && (DomandaPagamentoFidejussioneImpresaItem.DataScadenza.Value == DataScadenzaEqualThis.Value))) &&
((StampatoEqualThis == null) || ((DomandaPagamentoFidejussioneImpresaItem.Stampato != null) && (DomandaPagamentoFidejussioneImpresaItem.Stampato.Value == StampatoEqualThis.Value))) && ((NumeroEqualThis == null) || ((DomandaPagamentoFidejussioneImpresaItem.Numero != null) && (DomandaPagamentoFidejussioneImpresaItem.Numero.Value == NumeroEqualThis.Value))) && ((DataSottoscrizioneEqualThis == null) || ((DomandaPagamentoFidejussioneImpresaItem.DataSottoscrizione != null) && (DomandaPagamentoFidejussioneImpresaItem.DataSottoscrizione.Value == DataSottoscrizioneEqualThis.Value))) &&
((LuogoSottoscrizioneEqualThis == null) || ((DomandaPagamentoFidejussioneImpresaItem.LuogoSottoscrizione != null) && (DomandaPagamentoFidejussioneImpresaItem.LuogoSottoscrizione.Value == LuogoSottoscrizioneEqualThis.Value))) && ((PivaGaranteEqualThis == null) || ((DomandaPagamentoFidejussioneImpresaItem.PivaGarante != null) && (DomandaPagamentoFidejussioneImpresaItem.PivaGarante.Value == PivaGaranteEqualThis.Value))) && ((RagioneSocialeGaranteEqualThis == null) || ((DomandaPagamentoFidejussioneImpresaItem.RagioneSocialeGarante != null) && (DomandaPagamentoFidejussioneImpresaItem.RagioneSocialeGarante.Value == RagioneSocialeGaranteEqualThis.Value))) &&
((LocalitaGaranteEqualThis == null) || ((DomandaPagamentoFidejussioneImpresaItem.LocalitaGarante != null) && (DomandaPagamentoFidejussioneImpresaItem.LocalitaGarante.Value == LocalitaGaranteEqualThis.Value))) && ((NumeroRegistroImpreseEqualThis == null) || ((DomandaPagamentoFidejussioneImpresaItem.NumeroRegistroImprese != null) && (DomandaPagamentoFidejussioneImpresaItem.NumeroRegistroImprese.Value == NumeroRegistroImpreseEqualThis.Value))) && ((CognomeRapplegaleEqualThis == null) || ((DomandaPagamentoFidejussioneImpresaItem.CognomeRapplegale != null) && (DomandaPagamentoFidejussioneImpresaItem.CognomeRapplegale.Value == CognomeRapplegaleEqualThis.Value))) &&
((NomeRapplegaleEqualThis == null) || ((DomandaPagamentoFidejussioneImpresaItem.NomeRapplegale != null) && (DomandaPagamentoFidejussioneImpresaItem.NomeRapplegale.Value == NomeRapplegaleEqualThis.Value))) && ((CfRapplegaleEqualThis == null) || ((DomandaPagamentoFidejussioneImpresaItem.CfRapplegale != null) && (DomandaPagamentoFidejussioneImpresaItem.CfRapplegale.Value == CfRapplegaleEqualThis.Value))) && ((DataNascitaRapplegaleEqualThis == null) || ((DomandaPagamentoFidejussioneImpresaItem.DataNascitaRapplegale != null) && (DomandaPagamentoFidejussioneImpresaItem.DataNascitaRapplegale.Value == DataNascitaRapplegaleEqualThis.Value))) &&
((StampaEffettuataEqualThis == null) || ((DomandaPagamentoFidejussioneImpresaItem.StampaEffettuata != null) && (DomandaPagamentoFidejussioneImpresaItem.StampaEffettuata.Value == StampaEffettuataEqualThis.Value))) && ((DataRichiestaValiditaEqualThis == null) || ((DomandaPagamentoFidejussioneImpresaItem.DataRichiestaValidita != null) && (DomandaPagamentoFidejussioneImpresaItem.DataRichiestaValidita.Value == DataRichiestaValiditaEqualThis.Value))) && ((DataRicevimentoValiditaEqualThis == null) || ((DomandaPagamentoFidejussioneImpresaItem.DataRicevimentoValidita != null) && (DomandaPagamentoFidejussioneImpresaItem.DataRicevimentoValidita.Value == DataRicevimentoValiditaEqualThis.Value))) &&
((ProtocolloFaxValiditaEqualThis == null) || ((DomandaPagamentoFidejussioneImpresaItem.ProtocolloFaxValidita != null) && (DomandaPagamentoFidejussioneImpresaItem.ProtocolloFaxValidita.Value == ProtocolloFaxValiditaEqualThis.Value))) && ((DataDecorrenzaGaranziaEqualThis == null) || ((DomandaPagamentoFidejussioneImpresaItem.DataDecorrenzaGaranzia != null) && (DomandaPagamentoFidejussioneImpresaItem.DataDecorrenzaGaranzia.Value == DataDecorrenzaGaranziaEqualThis.Value))) && ((CodiceAbiEnteGaranteEqualThis == null) || ((DomandaPagamentoFidejussioneImpresaItem.CodiceAbiEnteGarante != null) && (DomandaPagamentoFidejussioneImpresaItem.CodiceAbiEnteGarante.Value == CodiceAbiEnteGaranteEqualThis.Value))) &&
((CodiceCabEnteGaranteEqualThis == null) || ((DomandaPagamentoFidejussioneImpresaItem.CodiceCabEnteGarante != null) && (DomandaPagamentoFidejussioneImpresaItem.CodiceCabEnteGarante.Value == CodiceCabEnteGaranteEqualThis.Value))) && ((CodTipoEqualThis == null) || ((DomandaPagamentoFidejussioneImpresaItem.CodTipo != null) && (DomandaPagamentoFidejussioneImpresaItem.CodTipo.Value == CodTipoEqualThis.Value))) && ((UfficioApprovazioneEqualThis == null) || ((DomandaPagamentoFidejussioneImpresaItem.UfficioApprovazione != null) && (DomandaPagamentoFidejussioneImpresaItem.UfficioApprovazione.Value == UfficioApprovazioneEqualThis.Value))) &&
((NumDecretoApprovazioneEqualThis == null) || ((DomandaPagamentoFidejussioneImpresaItem.NumDecretoApprovazione != null) && (DomandaPagamentoFidejussioneImpresaItem.NumDecretoApprovazione.Value == NumDecretoApprovazioneEqualThis.Value))) && ((DataDecretoApprovazioneEqualThis == null) || ((DomandaPagamentoFidejussioneImpresaItem.DataDecretoApprovazione != null) && (DomandaPagamentoFidejussioneImpresaItem.DataDecretoApprovazione.Value == DataDecretoApprovazioneEqualThis.Value))) && ((EsenteEqualThis == null) || ((DomandaPagamentoFidejussioneImpresaItem.Esente != null) && (DomandaPagamentoFidejussioneImpresaItem.Esente.Value == EsenteEqualThis.Value))) &&
((NoAnticipoEqualThis == null) || ((DomandaPagamentoFidejussioneImpresaItem.NoAnticipo != null) && (DomandaPagamentoFidejussioneImpresaItem.NoAnticipo.Value == NoAnticipoEqualThis.Value))))
				{
					DomandaPagamentoFidejussioneImpresaCollectionTemp.Add(DomandaPagamentoFidejussioneImpresaItem);
				}
			}
			return DomandaPagamentoFidejussioneImpresaCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for DomandaPagamentoFidejussioneImpresaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class DomandaPagamentoFidejussioneImpresaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, DomandaPagamentoFidejussioneImpresa DomandaPagamentoFidejussioneImpresaObj, string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd, firstChar + "IdDomandaPagamentoFidejussioneImpresa", DomandaPagamentoFidejussioneImpresaObj.IdDomandaPagamentoFidejussioneImpresa);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd, firstChar + "IdDomandaPagamentoFidejussione", DomandaPagamentoFidejussioneImpresaObj.IdDomandaPagamentoFidejussione);
			DbProvider.SetCmdParam(cmd, firstChar + "IdDomandaPagamento", DomandaPagamentoFidejussioneImpresaObj.IdDomandaPagamento);
			DbProvider.SetCmdParam(cmd, firstChar + "IdProgetto", DomandaPagamentoFidejussioneImpresaObj.IdProgetto);
			DbProvider.SetCmdParam(cmd, firstChar + "IdImpresa", DomandaPagamentoFidejussioneImpresaObj.IdImpresa);
			DbProvider.SetCmdParam(cmd, firstChar + "Importo", DomandaPagamentoFidejussioneImpresaObj.Importo);
			DbProvider.SetCmdParam(cmd, firstChar + "AmmontareRichiesto", DomandaPagamentoFidejussioneImpresaObj.AmmontareRichiesto);
			DbProvider.SetCmdParam(cmd, firstChar + "DataFineLavori", DomandaPagamentoFidejussioneImpresaObj.DataFineLavori);
			DbProvider.SetCmdParam(cmd, firstChar + "DataScadenza", DomandaPagamentoFidejussioneImpresaObj.DataScadenza);
			DbProvider.SetCmdParam(cmd, firstChar + "Stampato", DomandaPagamentoFidejussioneImpresaObj.Stampato);
			DbProvider.SetCmdParam(cmd, firstChar + "Numero", DomandaPagamentoFidejussioneImpresaObj.Numero);
			DbProvider.SetCmdParam(cmd, firstChar + "DataSottoscrizione", DomandaPagamentoFidejussioneImpresaObj.DataSottoscrizione);
			DbProvider.SetCmdParam(cmd, firstChar + "LuogoSottoscrizione", DomandaPagamentoFidejussioneImpresaObj.LuogoSottoscrizione);
			DbProvider.SetCmdParam(cmd, firstChar + "PivaGarante", DomandaPagamentoFidejussioneImpresaObj.PivaGarante);
			DbProvider.SetCmdParam(cmd, firstChar + "RagioneSocialeGarante", DomandaPagamentoFidejussioneImpresaObj.RagioneSocialeGarante);
			DbProvider.SetCmdParam(cmd, firstChar + "LocalitaGarante", DomandaPagamentoFidejussioneImpresaObj.LocalitaGarante);
			DbProvider.SetCmdParam(cmd, firstChar + "NumeroRegistroImprese", DomandaPagamentoFidejussioneImpresaObj.NumeroRegistroImprese);
			DbProvider.SetCmdParam(cmd, firstChar + "CognomeRapplegale", DomandaPagamentoFidejussioneImpresaObj.CognomeRapplegale);
			DbProvider.SetCmdParam(cmd, firstChar + "NomeRapplegale", DomandaPagamentoFidejussioneImpresaObj.NomeRapplegale);
			DbProvider.SetCmdParam(cmd, firstChar + "CfRapplegale", DomandaPagamentoFidejussioneImpresaObj.CfRapplegale);
			DbProvider.SetCmdParam(cmd, firstChar + "DataNascitaRapplegale", DomandaPagamentoFidejussioneImpresaObj.DataNascitaRapplegale);
			DbProvider.SetCmdParam(cmd, firstChar + "StampaEffettuata", DomandaPagamentoFidejussioneImpresaObj.StampaEffettuata);
			DbProvider.SetCmdParam(cmd, firstChar + "DataRichiestaValidita", DomandaPagamentoFidejussioneImpresaObj.DataRichiestaValidita);
			DbProvider.SetCmdParam(cmd, firstChar + "DataRicevimentoValidita", DomandaPagamentoFidejussioneImpresaObj.DataRicevimentoValidita);
			DbProvider.SetCmdParam(cmd, firstChar + "ProtocolloFaxValidita", DomandaPagamentoFidejussioneImpresaObj.ProtocolloFaxValidita);
			DbProvider.SetCmdParam(cmd, firstChar + "DataDecorrenzaGaranzia", DomandaPagamentoFidejussioneImpresaObj.DataDecorrenzaGaranzia);
			DbProvider.SetCmdParam(cmd, firstChar + "CodiceAbiEnteGarante", DomandaPagamentoFidejussioneImpresaObj.CodiceAbiEnteGarante);
			DbProvider.SetCmdParam(cmd, firstChar + "CodiceCabEnteGarante", DomandaPagamentoFidejussioneImpresaObj.CodiceCabEnteGarante);
			DbProvider.SetCmdParam(cmd, firstChar + "CodTipo", DomandaPagamentoFidejussioneImpresaObj.CodTipo);
			DbProvider.SetCmdParam(cmd, firstChar + "UfficioApprovazione", DomandaPagamentoFidejussioneImpresaObj.UfficioApprovazione);
			DbProvider.SetCmdParam(cmd, firstChar + "NumDecretoApprovazione", DomandaPagamentoFidejussioneImpresaObj.NumDecretoApprovazione);
			DbProvider.SetCmdParam(cmd, firstChar + "DataDecretoApprovazione", DomandaPagamentoFidejussioneImpresaObj.DataDecretoApprovazione);
			DbProvider.SetCmdParam(cmd, firstChar + "Esente", DomandaPagamentoFidejussioneImpresaObj.Esente);
			DbProvider.SetCmdParam(cmd, firstChar + "NoAnticipo", DomandaPagamentoFidejussioneImpresaObj.NoAnticipo);
		}
		//Insert
		private static int Insert(DbProvider db, DomandaPagamentoFidejussioneImpresa DomandaPagamentoFidejussioneImpresaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd("ZDomandaPagamentoFidejussioneImpresaInsert", new string[] {"IdDomandaPagamentoFidejussione", "IdDomandaPagamento",
"IdProgetto", "IdImpresa", "Importo",
"AmmontareRichiesto", "DataFineLavori", "DataScadenza",
"Stampato", "Numero", "DataSottoscrizione",
"LuogoSottoscrizione", "PivaGarante", "RagioneSocialeGarante",
"LocalitaGarante", "NumeroRegistroImprese", "CognomeRapplegale",
"NomeRapplegale", "CfRapplegale", "DataNascitaRapplegale",
"StampaEffettuata", "DataRichiestaValidita", "DataRicevimentoValidita",
"ProtocolloFaxValidita", "DataDecorrenzaGaranzia", "CodiceAbiEnteGarante",
"CodiceCabEnteGarante", "CodTipo", "UfficioApprovazione",
"NumDecretoApprovazione", "DataDecretoApprovazione", "Esente",
"NoAnticipo"}, new string[] {"int", "int",
"int", "int", "decimal",
"decimal", "DateTime", "DateTime",
"bool", "string", "DateTime",
"string", "string", "string",
"string", "string", "string",
"string", "string", "DateTime",
"bool", "DateTime", "DateTime",
"string", "DateTime", "string",
"string", "string", "string",
"int", "DateTime", "bool",
"bool"}, "");
				CompileIUCmd(false, insertCmd, DomandaPagamentoFidejussioneImpresaObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
				{
					DomandaPagamentoFidejussioneImpresaObj.IdDomandaPagamentoFidejussioneImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO_FIDEJUSSIONE_IMPRESA"]);
					DomandaPagamentoFidejussioneImpresaObj.Stampato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["STAMPATO"]);
					DomandaPagamentoFidejussioneImpresaObj.StampaEffettuata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["STAMPA_EFFETTUATA"]);
				}
				DomandaPagamentoFidejussioneImpresaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DomandaPagamentoFidejussioneImpresaObj.IsDirty = false;
				DomandaPagamentoFidejussioneImpresaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, DomandaPagamentoFidejussioneImpresa DomandaPagamentoFidejussioneImpresaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZDomandaPagamentoFidejussioneImpresaUpdate", new string[] {"IdDomandaPagamentoFidejussioneImpresa", "IdDomandaPagamentoFidejussione", "IdDomandaPagamento",
"IdProgetto", "IdImpresa", "Importo",
"AmmontareRichiesto", "DataFineLavori", "DataScadenza",
"Stampato", "Numero", "DataSottoscrizione",
"LuogoSottoscrizione", "PivaGarante", "RagioneSocialeGarante",
"LocalitaGarante", "NumeroRegistroImprese", "CognomeRapplegale",
"NomeRapplegale", "CfRapplegale", "DataNascitaRapplegale",
"StampaEffettuata", "DataRichiestaValidita", "DataRicevimentoValidita",
"ProtocolloFaxValidita", "DataDecorrenzaGaranzia", "CodiceAbiEnteGarante",
"CodiceCabEnteGarante", "CodTipo", "UfficioApprovazione",
"NumDecretoApprovazione", "DataDecretoApprovazione", "Esente",
"NoAnticipo"}, new string[] {"int", "int", "int",
"int", "int", "decimal",
"decimal", "DateTime", "DateTime",
"bool", "string", "DateTime",
"string", "string", "string",
"string", "string", "string",
"string", "string", "DateTime",
"bool", "DateTime", "DateTime",
"string", "DateTime", "string",
"string", "string", "string",
"int", "DateTime", "bool",
"bool"}, "");
				CompileIUCmd(true, updateCmd, DomandaPagamentoFidejussioneImpresaObj, db.CommandFirstChar);
				i = db.Execute(updateCmd);
				DomandaPagamentoFidejussioneImpresaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DomandaPagamentoFidejussioneImpresaObj.IsDirty = false;
				DomandaPagamentoFidejussioneImpresaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, DomandaPagamentoFidejussioneImpresa DomandaPagamentoFidejussioneImpresaObj)
		{
			switch (DomandaPagamentoFidejussioneImpresaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added: return Insert(db, DomandaPagamentoFidejussioneImpresaObj);
				case BaseObject.ObjectStateType.Changed: return Update(db, DomandaPagamentoFidejussioneImpresaObj);
				case BaseObject.ObjectStateType.Deleted: return Delete(db, DomandaPagamentoFidejussioneImpresaObj);
				default: return 0;
			}
		}

		public static int SaveCollection(DbProvider db, DomandaPagamentoFidejussioneImpresaCollection DomandaPagamentoFidejussioneImpresaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZDomandaPagamentoFidejussioneImpresaUpdate", new string[] {"IdDomandaPagamentoFidejussioneImpresa", "IdDomandaPagamentoFidejussione", "IdDomandaPagamento",
"IdProgetto", "IdImpresa", "Importo",
"AmmontareRichiesto", "DataFineLavori", "DataScadenza",
"Stampato", "Numero", "DataSottoscrizione",
"LuogoSottoscrizione", "PivaGarante", "RagioneSocialeGarante",
"LocalitaGarante", "NumeroRegistroImprese", "CognomeRapplegale",
"NomeRapplegale", "CfRapplegale", "DataNascitaRapplegale",
"StampaEffettuata", "DataRichiestaValidita", "DataRicevimentoValidita",
"ProtocolloFaxValidita", "DataDecorrenzaGaranzia", "CodiceAbiEnteGarante",
"CodiceCabEnteGarante", "CodTipo", "UfficioApprovazione",
"NumDecretoApprovazione", "DataDecretoApprovazione", "Esente",
"NoAnticipo"}, new string[] {"int", "int", "int",
"int", "int", "decimal",
"decimal", "DateTime", "DateTime",
"bool", "string", "DateTime",
"string", "string", "string",
"string", "string", "string",
"string", "string", "DateTime",
"bool", "DateTime", "DateTime",
"string", "DateTime", "string",
"string", "string", "string",
"int", "DateTime", "bool",
"bool"}, "");
				IDbCommand insertCmd = db.InitCmd("ZDomandaPagamentoFidejussioneImpresaInsert", new string[] {"IdDomandaPagamentoFidejussione", "IdDomandaPagamento",
"IdProgetto", "IdImpresa", "Importo",
"AmmontareRichiesto", "DataFineLavori", "DataScadenza",
"Stampato", "Numero", "DataSottoscrizione",
"LuogoSottoscrizione", "PivaGarante", "RagioneSocialeGarante",
"LocalitaGarante", "NumeroRegistroImprese", "CognomeRapplegale",
"NomeRapplegale", "CfRapplegale", "DataNascitaRapplegale",
"StampaEffettuata", "DataRichiestaValidita", "DataRicevimentoValidita",
"ProtocolloFaxValidita", "DataDecorrenzaGaranzia", "CodiceAbiEnteGarante",
"CodiceCabEnteGarante", "CodTipo", "UfficioApprovazione",
"NumDecretoApprovazione", "DataDecretoApprovazione", "Esente",
"NoAnticipo"}, new string[] {"int", "int",
"int", "int", "decimal",
"decimal", "DateTime", "DateTime",
"bool", "string", "DateTime",
"string", "string", "string",
"string", "string", "string",
"string", "string", "DateTime",
"bool", "DateTime", "DateTime",
"string", "DateTime", "string",
"string", "string", "string",
"int", "DateTime", "bool",
"bool"}, "");
				IDbCommand deleteCmd = db.InitCmd("ZDomandaPagamentoFidejussioneImpresaDelete", new string[] { "IdDomandaPagamentoFidejussioneImpresa" }, new string[] { "int" }, "");
				for (int i = 0; i < DomandaPagamentoFidejussioneImpresaCollectionObj.Count; i++)
				{
					switch (DomandaPagamentoFidejussioneImpresaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added:
							{
								CompileIUCmd(false, insertCmd, DomandaPagamentoFidejussioneImpresaCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									DomandaPagamentoFidejussioneImpresaCollectionObj[i].IdDomandaPagamentoFidejussioneImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO_FIDEJUSSIONE_IMPRESA"]);
									DomandaPagamentoFidejussioneImpresaCollectionObj[i].Stampato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["STAMPATO"]);
									DomandaPagamentoFidejussioneImpresaCollectionObj[i].StampaEffettuata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["STAMPA_EFFETTUATA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed:
							{
								CompileIUCmd(true, updateCmd, DomandaPagamentoFidejussioneImpresaCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted:
							{
								if (DomandaPagamentoFidejussioneImpresaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdDomandaPagamentoFidejussioneImpresa", (SiarLibrary.NullTypes.IntNT)DomandaPagamentoFidejussioneImpresaCollectionObj[i].IdDomandaPagamentoFidejussioneImpresa);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < DomandaPagamentoFidejussioneImpresaCollectionObj.Count; i++)
				{
					if ((DomandaPagamentoFidejussioneImpresaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (DomandaPagamentoFidejussioneImpresaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						DomandaPagamentoFidejussioneImpresaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						DomandaPagamentoFidejussioneImpresaCollectionObj[i].IsDirty = false;
						DomandaPagamentoFidejussioneImpresaCollectionObj[i].IsPersistent = true;
					}
					if ((DomandaPagamentoFidejussioneImpresaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						DomandaPagamentoFidejussioneImpresaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						DomandaPagamentoFidejussioneImpresaCollectionObj[i].IsDirty = false;
						DomandaPagamentoFidejussioneImpresaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, DomandaPagamentoFidejussioneImpresa DomandaPagamentoFidejussioneImpresaObj)
		{
			int returnValue = 0;
			if (DomandaPagamentoFidejussioneImpresaObj.IsPersistent)
			{
				returnValue = Delete(db, DomandaPagamentoFidejussioneImpresaObj.IdDomandaPagamentoFidejussioneImpresa);
			}
			DomandaPagamentoFidejussioneImpresaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			DomandaPagamentoFidejussioneImpresaObj.IsDirty = false;
			DomandaPagamentoFidejussioneImpresaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdDomandaPagamentoFidejussioneImpresaValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZDomandaPagamentoFidejussioneImpresaDelete", new string[] { "IdDomandaPagamentoFidejussioneImpresa" }, new string[] { "int" }, "");
				DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdDomandaPagamentoFidejussioneImpresa", (SiarLibrary.NullTypes.IntNT)IdDomandaPagamentoFidejussioneImpresaValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, DomandaPagamentoFidejussioneImpresaCollection DomandaPagamentoFidejussioneImpresaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZDomandaPagamentoFidejussioneImpresaDelete", new string[] { "IdDomandaPagamentoFidejussioneImpresa" }, new string[] { "int" }, "");
				for (int i = 0; i < DomandaPagamentoFidejussioneImpresaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdDomandaPagamentoFidejussioneImpresa", DomandaPagamentoFidejussioneImpresaCollectionObj[i].IdDomandaPagamentoFidejussioneImpresa);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < DomandaPagamentoFidejussioneImpresaCollectionObj.Count; i++)
				{
					if ((DomandaPagamentoFidejussioneImpresaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (DomandaPagamentoFidejussioneImpresaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						DomandaPagamentoFidejussioneImpresaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						DomandaPagamentoFidejussioneImpresaCollectionObj[i].IsDirty = false;
						DomandaPagamentoFidejussioneImpresaCollectionObj[i].IsPersistent = false;
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
		public static DomandaPagamentoFidejussioneImpresa GetById(DbProvider db, int IdDomandaPagamentoFidejussioneImpresaValue)
		{
			DomandaPagamentoFidejussioneImpresa DomandaPagamentoFidejussioneImpresaObj = null;
			IDbCommand readCmd = db.InitCmd("ZDomandaPagamentoFidejussioneImpresaGetById", new string[] { "IdDomandaPagamentoFidejussioneImpresa" }, new string[] { "int" }, "");
			DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdDomandaPagamentoFidejussioneImpresa", (SiarLibrary.NullTypes.IntNT)IdDomandaPagamentoFidejussioneImpresaValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				DomandaPagamentoFidejussioneImpresaObj = GetFromDatareader(db);
				DomandaPagamentoFidejussioneImpresaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DomandaPagamentoFidejussioneImpresaObj.IsDirty = false;
				DomandaPagamentoFidejussioneImpresaObj.IsPersistent = true;
			}
			db.Close();
			return DomandaPagamentoFidejussioneImpresaObj;
		}

		//getFromDatareader
		public static DomandaPagamentoFidejussioneImpresa GetFromDatareader(DbProvider db)
		{
			DomandaPagamentoFidejussioneImpresa DomandaPagamentoFidejussioneImpresaObj = new DomandaPagamentoFidejussioneImpresa();
			DomandaPagamentoFidejussioneImpresaObj.IdDomandaPagamentoFidejussioneImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO_FIDEJUSSIONE_IMPRESA"]);
			DomandaPagamentoFidejussioneImpresaObj.IdDomandaPagamentoFidejussione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO_FIDEJUSSIONE"]);
			DomandaPagamentoFidejussioneImpresaObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
			DomandaPagamentoFidejussioneImpresaObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			DomandaPagamentoFidejussioneImpresaObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			DomandaPagamentoFidejussioneImpresaObj.Importo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO"]);
			DomandaPagamentoFidejussioneImpresaObj.AmmontareRichiesto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["AMMONTARE_RICHIESTO"]);
			DomandaPagamentoFidejussioneImpresaObj.DataFineLavori = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE_LAVORI"]);
			DomandaPagamentoFidejussioneImpresaObj.DataScadenza = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_SCADENZA"]);
			DomandaPagamentoFidejussioneImpresaObj.Stampato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["STAMPATO"]);
			DomandaPagamentoFidejussioneImpresaObj.Numero = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO"]);
			DomandaPagamentoFidejussioneImpresaObj.DataSottoscrizione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_SOTTOSCRIZIONE"]);
			DomandaPagamentoFidejussioneImpresaObj.LuogoSottoscrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["LUOGO_SOTTOSCRIZIONE"]);
			DomandaPagamentoFidejussioneImpresaObj.PivaGarante = new SiarLibrary.NullTypes.StringNT(db.DataReader["PIVA_GARANTE"]);
			DomandaPagamentoFidejussioneImpresaObj.RagioneSocialeGarante = new SiarLibrary.NullTypes.StringNT(db.DataReader["RAGIONE_SOCIALE_GARANTE"]);
			DomandaPagamentoFidejussioneImpresaObj.LocalitaGarante = new SiarLibrary.NullTypes.StringNT(db.DataReader["LOCALITA_GARANTE"]);
			DomandaPagamentoFidejussioneImpresaObj.NumeroRegistroImprese = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO_REGISTRO_IMPRESE"]);
			DomandaPagamentoFidejussioneImpresaObj.CognomeRapplegale = new SiarLibrary.NullTypes.StringNT(db.DataReader["COGNOME_RAPPLEGALE"]);
			DomandaPagamentoFidejussioneImpresaObj.NomeRapplegale = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOME_RAPPLEGALE"]);
			DomandaPagamentoFidejussioneImpresaObj.CfRapplegale = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_RAPPLEGALE"]);
			DomandaPagamentoFidejussioneImpresaObj.DataNascitaRapplegale = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_NASCITA_RAPPLEGALE"]);
			DomandaPagamentoFidejussioneImpresaObj.StampaEffettuata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["STAMPA_EFFETTUATA"]);
			DomandaPagamentoFidejussioneImpresaObj.DataRichiestaValidita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_RICHIESTA_VALIDITA"]);
			DomandaPagamentoFidejussioneImpresaObj.DataRicevimentoValidita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_RICEVIMENTO_VALIDITA"]);
			DomandaPagamentoFidejussioneImpresaObj.ProtocolloFaxValidita = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROTOCOLLO_FAX_VALIDITA"]);
			DomandaPagamentoFidejussioneImpresaObj.DataDecorrenzaGaranzia = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_DECORRENZA_GARANZIA"]);
			DomandaPagamentoFidejussioneImpresaObj.CodiceAbiEnteGarante = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_ABI_ENTE_GARANTE"]);
			DomandaPagamentoFidejussioneImpresaObj.CodiceCabEnteGarante = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_CAB_ENTE_GARANTE"]);
			DomandaPagamentoFidejussioneImpresaObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
			DomandaPagamentoFidejussioneImpresaObj.UfficioApprovazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["UFFICIO_APPROVAZIONE"]);
			DomandaPagamentoFidejussioneImpresaObj.NumDecretoApprovazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUM_DECRETO_APPROVAZIONE"]);
			DomandaPagamentoFidejussioneImpresaObj.DataDecretoApprovazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_DECRETO_APPROVAZIONE"]);
			DomandaPagamentoFidejussioneImpresaObj.Esente = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ESENTE"]);
			DomandaPagamentoFidejussioneImpresaObj.NoAnticipo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["NO_ANTICIPO"]);
			DomandaPagamentoFidejussioneImpresaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			DomandaPagamentoFidejussioneImpresaObj.IsDirty = false;
			DomandaPagamentoFidejussioneImpresaObj.IsPersistent = true;
			return DomandaPagamentoFidejussioneImpresaObj;
		}

		//Find Select

		public static DomandaPagamentoFidejussioneImpresaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoFidejussioneImpresaEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoFidejussioneEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis,
SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoEqualThis,
SiarLibrary.NullTypes.DecimalNT AmmontareRichiestoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataFineLavoriEqualThis, SiarLibrary.NullTypes.DatetimeNT DataScadenzaEqualThis,
SiarLibrary.NullTypes.BoolNT StampatoEqualThis, SiarLibrary.NullTypes.StringNT NumeroEqualThis, SiarLibrary.NullTypes.DatetimeNT DataSottoscrizioneEqualThis,
SiarLibrary.NullTypes.StringNT LuogoSottoscrizioneEqualThis, SiarLibrary.NullTypes.StringNT PivaGaranteEqualThis, SiarLibrary.NullTypes.StringNT RagioneSocialeGaranteEqualThis,
SiarLibrary.NullTypes.StringNT LocalitaGaranteEqualThis, SiarLibrary.NullTypes.StringNT NumeroRegistroImpreseEqualThis, SiarLibrary.NullTypes.StringNT CognomeRapplegaleEqualThis,
SiarLibrary.NullTypes.StringNT NomeRapplegaleEqualThis, SiarLibrary.NullTypes.StringNT CfRapplegaleEqualThis, SiarLibrary.NullTypes.DatetimeNT DataNascitaRapplegaleEqualThis,
SiarLibrary.NullTypes.BoolNT StampaEffettuataEqualThis, SiarLibrary.NullTypes.DatetimeNT DataRichiestaValiditaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataRicevimentoValiditaEqualThis,
SiarLibrary.NullTypes.StringNT ProtocolloFaxValiditaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataDecorrenzaGaranziaEqualThis, SiarLibrary.NullTypes.StringNT CodiceAbiEnteGaranteEqualThis,
SiarLibrary.NullTypes.StringNT CodiceCabEnteGaranteEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.StringNT UfficioApprovazioneEqualThis,
SiarLibrary.NullTypes.IntNT NumDecretoApprovazioneEqualThis, SiarLibrary.NullTypes.DatetimeNT DataDecretoApprovazioneEqualThis, SiarLibrary.NullTypes.BoolNT EsenteEqualThis,
SiarLibrary.NullTypes.BoolNT NoAnticipoEqualThis)

		{

			DomandaPagamentoFidejussioneImpresaCollection DomandaPagamentoFidejussioneImpresaCollectionObj = new DomandaPagamentoFidejussioneImpresaCollection();

			IDbCommand findCmd = db.InitCmd("Zdomandapagamentofidejussioneimpresafindselect", new string[] {"IdDomandaPagamentoFidejussioneImpresaequalthis", "IdDomandaPagamentoFidejussioneequalthis", "IdDomandaPagamentoequalthis",
"IdProgettoequalthis", "IdImpresaequalthis", "Importoequalthis",
"AmmontareRichiestoequalthis", "DataFineLavoriequalthis", "DataScadenzaequalthis",
"Stampatoequalthis", "Numeroequalthis", "DataSottoscrizioneequalthis",
"LuogoSottoscrizioneequalthis", "PivaGaranteequalthis", "RagioneSocialeGaranteequalthis",
"LocalitaGaranteequalthis", "NumeroRegistroImpreseequalthis", "CognomeRapplegaleequalthis",
"NomeRapplegaleequalthis", "CfRapplegaleequalthis", "DataNascitaRapplegaleequalthis",
"StampaEffettuataequalthis", "DataRichiestaValiditaequalthis", "DataRicevimentoValiditaequalthis",
"ProtocolloFaxValiditaequalthis", "DataDecorrenzaGaranziaequalthis", "CodiceAbiEnteGaranteequalthis",
"CodiceCabEnteGaranteequalthis", "CodTipoequalthis", "UfficioApprovazioneequalthis",
"NumDecretoApprovazioneequalthis", "DataDecretoApprovazioneequalthis", "Esenteequalthis",
"NoAnticipoequalthis"}, new string[] {"int", "int", "int",
"int", "int", "decimal",
"decimal", "DateTime", "DateTime",
"bool", "string", "DateTime",
"string", "string", "string",
"string", "string", "string",
"string", "string", "DateTime",
"bool", "DateTime", "DateTime",
"string", "DateTime", "string",
"string", "string", "string",
"int", "DateTime", "bool",
"bool"}, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoFidejussioneImpresaequalthis", IdDomandaPagamentoFidejussioneImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoFidejussioneequalthis", IdDomandaPagamentoFidejussioneEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Importoequalthis", ImportoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "AmmontareRichiestoequalthis", AmmontareRichiestoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataFineLavoriequalthis", DataFineLavoriEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataScadenzaequalthis", DataScadenzaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Stampatoequalthis", StampatoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Numeroequalthis", NumeroEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataSottoscrizioneequalthis", DataSottoscrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "LuogoSottoscrizioneequalthis", LuogoSottoscrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "PivaGaranteequalthis", PivaGaranteEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "RagioneSocialeGaranteequalthis", RagioneSocialeGaranteEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "LocalitaGaranteequalthis", LocalitaGaranteEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "NumeroRegistroImpreseequalthis", NumeroRegistroImpreseEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CognomeRapplegaleequalthis", CognomeRapplegaleEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "NomeRapplegaleequalthis", NomeRapplegaleEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfRapplegaleequalthis", CfRapplegaleEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataNascitaRapplegaleequalthis", DataNascitaRapplegaleEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "StampaEffettuataequalthis", StampaEffettuataEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataRichiestaValiditaequalthis", DataRichiestaValiditaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataRicevimentoValiditaequalthis", DataRicevimentoValiditaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ProtocolloFaxValiditaequalthis", ProtocolloFaxValiditaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataDecorrenzaGaranziaequalthis", DataDecorrenzaGaranziaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodiceAbiEnteGaranteequalthis", CodiceAbiEnteGaranteEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodiceCabEnteGaranteequalthis", CodiceCabEnteGaranteEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "UfficioApprovazioneequalthis", UfficioApprovazioneEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "NumDecretoApprovazioneequalthis", NumDecretoApprovazioneEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataDecretoApprovazioneequalthis", DataDecretoApprovazioneEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Esenteequalthis", EsenteEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "NoAnticipoequalthis", NoAnticipoEqualThis);
			DomandaPagamentoFidejussioneImpresa DomandaPagamentoFidejussioneImpresaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				DomandaPagamentoFidejussioneImpresaObj = GetFromDatareader(db);
				DomandaPagamentoFidejussioneImpresaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DomandaPagamentoFidejussioneImpresaObj.IsDirty = false;
				DomandaPagamentoFidejussioneImpresaObj.IsPersistent = true;
				DomandaPagamentoFidejussioneImpresaCollectionObj.Add(DomandaPagamentoFidejussioneImpresaObj);
			}
			db.Close();
			return DomandaPagamentoFidejussioneImpresaCollectionObj;
		}

		//Find Find

		public static DomandaPagamentoFidejussioneImpresaCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoFidejussioneEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis,
SiarLibrary.NullTypes.IntNT IdImpresaEqualThis)

		{

			DomandaPagamentoFidejussioneImpresaCollection DomandaPagamentoFidejussioneImpresaCollectionObj = new DomandaPagamentoFidejussioneImpresaCollection();

			IDbCommand findCmd = db.InitCmd("Zdomandapagamentofidejussioneimpresafindfind", new string[] {"IdDomandaPagamentoFidejussioneequalthis", "IdDomandaPagamentoequalthis", "IdProgettoequalthis",
"IdImpresaequalthis"}, new string[] {"int", "int", "int",
"int"}, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoFidejussioneequalthis", IdDomandaPagamentoFidejussioneEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DomandaPagamentoFidejussioneImpresa DomandaPagamentoFidejussioneImpresaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				DomandaPagamentoFidejussioneImpresaObj = GetFromDatareader(db);
				DomandaPagamentoFidejussioneImpresaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DomandaPagamentoFidejussioneImpresaObj.IsDirty = false;
				DomandaPagamentoFidejussioneImpresaObj.IsPersistent = true;
				DomandaPagamentoFidejussioneImpresaCollectionObj.Add(DomandaPagamentoFidejussioneImpresaObj);
			}
			db.Close();
			return DomandaPagamentoFidejussioneImpresaCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for DomandaPagamentoFidejussioneImpresaCollectionProvider:IDomandaPagamentoFidejussioneImpresaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class DomandaPagamentoFidejussioneImpresaCollectionProvider : IDomandaPagamentoFidejussioneImpresaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di DomandaPagamentoFidejussioneImpresa
		protected DomandaPagamentoFidejussioneImpresaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public DomandaPagamentoFidejussioneImpresaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new DomandaPagamentoFidejussioneImpresaCollection(this);
		}

		//Costruttore 2: popola la collection
		public DomandaPagamentoFidejussioneImpresaCollectionProvider(IntNT IddomandapagamentofidejussioneEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdprogettoEqualThis,
IntNT IdimpresaEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IddomandapagamentofidejussioneEqualThis, IddomandapagamentoEqualThis, IdprogettoEqualThis,
IdimpresaEqualThis);
		}

		//Costruttore3: ha in input domandapagamentofidejussioneimpresaCollectionObj - non popola la collection
		public DomandaPagamentoFidejussioneImpresaCollectionProvider(DomandaPagamentoFidejussioneImpresaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public DomandaPagamentoFidejussioneImpresaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new DomandaPagamentoFidejussioneImpresaCollection(this);
		}

		//Get e Set
		public DomandaPagamentoFidejussioneImpresaCollection CollectionObj
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
		public int SaveCollection(DomandaPagamentoFidejussioneImpresaCollection collectionObj)
		{
			return DomandaPagamentoFidejussioneImpresaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(DomandaPagamentoFidejussioneImpresa domandapagamentofidejussioneimpresaObj)
		{
			return DomandaPagamentoFidejussioneImpresaDAL.Save(_dbProviderObj, domandapagamentofidejussioneimpresaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(DomandaPagamentoFidejussioneImpresaCollection collectionObj)
		{
			return DomandaPagamentoFidejussioneImpresaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(DomandaPagamentoFidejussioneImpresa domandapagamentofidejussioneimpresaObj)
		{
			return DomandaPagamentoFidejussioneImpresaDAL.Delete(_dbProviderObj, domandapagamentofidejussioneimpresaObj);
		}

		//getById
		public DomandaPagamentoFidejussioneImpresa GetById(IntNT IdDomandaPagamentoFidejussioneImpresaValue)
		{
			DomandaPagamentoFidejussioneImpresa DomandaPagamentoFidejussioneImpresaTemp = DomandaPagamentoFidejussioneImpresaDAL.GetById(_dbProviderObj, IdDomandaPagamentoFidejussioneImpresaValue);
			if (DomandaPagamentoFidejussioneImpresaTemp != null) DomandaPagamentoFidejussioneImpresaTemp.Provider = this;
			return DomandaPagamentoFidejussioneImpresaTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public DomandaPagamentoFidejussioneImpresaCollection Select(IntNT IddomandapagamentofidejussioneimpresaEqualThis, IntNT IddomandapagamentofidejussioneEqualThis, IntNT IddomandapagamentoEqualThis,
IntNT IdprogettoEqualThis, IntNT IdimpresaEqualThis, DecimalNT ImportoEqualThis,
DecimalNT AmmontarerichiestoEqualThis, DatetimeNT DatafinelavoriEqualThis, DatetimeNT DatascadenzaEqualThis,
BoolNT StampatoEqualThis, StringNT NumeroEqualThis, DatetimeNT DatasottoscrizioneEqualThis,
StringNT LuogosottoscrizioneEqualThis, StringNT PivagaranteEqualThis, StringNT RagionesocialegaranteEqualThis,
StringNT LocalitagaranteEqualThis, StringNT NumeroregistroimpreseEqualThis, StringNT CognomerapplegaleEqualThis,
StringNT NomerapplegaleEqualThis, StringNT CfrapplegaleEqualThis, DatetimeNT DatanascitarapplegaleEqualThis,
BoolNT StampaeffettuataEqualThis, DatetimeNT DatarichiestavaliditaEqualThis, DatetimeNT DataricevimentovaliditaEqualThis,
StringNT ProtocollofaxvaliditaEqualThis, DatetimeNT DatadecorrenzagaranziaEqualThis, StringNT CodiceabientegaranteEqualThis,
StringNT CodicecabentegaranteEqualThis, StringNT CodtipoEqualThis, StringNT UfficioapprovazioneEqualThis,
IntNT NumdecretoapprovazioneEqualThis, DatetimeNT DatadecretoapprovazioneEqualThis, BoolNT EsenteEqualThis,
BoolNT NoanticipoEqualThis)
		{
			DomandaPagamentoFidejussioneImpresaCollection DomandaPagamentoFidejussioneImpresaCollectionTemp = DomandaPagamentoFidejussioneImpresaDAL.Select(_dbProviderObj, IddomandapagamentofidejussioneimpresaEqualThis, IddomandapagamentofidejussioneEqualThis, IddomandapagamentoEqualThis,
IdprogettoEqualThis, IdimpresaEqualThis, ImportoEqualThis,
AmmontarerichiestoEqualThis, DatafinelavoriEqualThis, DatascadenzaEqualThis,
StampatoEqualThis, NumeroEqualThis, DatasottoscrizioneEqualThis,
LuogosottoscrizioneEqualThis, PivagaranteEqualThis, RagionesocialegaranteEqualThis,
LocalitagaranteEqualThis, NumeroregistroimpreseEqualThis, CognomerapplegaleEqualThis,
NomerapplegaleEqualThis, CfrapplegaleEqualThis, DatanascitarapplegaleEqualThis,
StampaeffettuataEqualThis, DatarichiestavaliditaEqualThis, DataricevimentovaliditaEqualThis,
ProtocollofaxvaliditaEqualThis, DatadecorrenzagaranziaEqualThis, CodiceabientegaranteEqualThis,
CodicecabentegaranteEqualThis, CodtipoEqualThis, UfficioapprovazioneEqualThis,
NumdecretoapprovazioneEqualThis, DatadecretoapprovazioneEqualThis, EsenteEqualThis,
NoanticipoEqualThis);
			DomandaPagamentoFidejussioneImpresaCollectionTemp.Provider = this;
			return DomandaPagamentoFidejussioneImpresaCollectionTemp;
		}

		//Find: popola la collection
		public DomandaPagamentoFidejussioneImpresaCollection Find(IntNT IddomandapagamentofidejussioneEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdprogettoEqualThis,
IntNT IdimpresaEqualThis)
		{
			DomandaPagamentoFidejussioneImpresaCollection DomandaPagamentoFidejussioneImpresaCollectionTemp = DomandaPagamentoFidejussioneImpresaDAL.Find(_dbProviderObj, IddomandapagamentofidejussioneEqualThis, IddomandapagamentoEqualThis, IdprogettoEqualThis,
IdimpresaEqualThis);
			DomandaPagamentoFidejussioneImpresaCollectionTemp.Provider = this;
			return DomandaPagamentoFidejussioneImpresaCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<DOMANDA_PAGAMENTO_FIDEJUSSIONE_IMPRESA>
  <ViewName>
  </ViewName>
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
      <ID_DOMANDA_PAGAMENTO_FIDEJUSSIONE>Equal</ID_DOMANDA_PAGAMENTO_FIDEJUSSIONE>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</DOMANDA_PAGAMENTO_FIDEJUSSIONE_IMPRESA>
*/
