using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per Sanzioni
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ISanzioniProvider
	{
		int Save(Sanzioni SanzioniObj);
		int SaveCollection(SanzioniCollection collectionObj);
		int Delete(Sanzioni SanzioniObj);
		int DeleteCollection(SanzioniCollection collectionObj);
	}
	/// <summary>
	/// Summary description for Sanzioni
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class Sanzioni: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdSanzione;
		private NullTypes.StringNT _CodTipo;
		private NullTypes.IntNT _IdDomandaPagamento;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.DatetimeNT _DataApplicazione;
		private NullTypes.StringNT _Operatore;
		private NullTypes.DecimalNT _Ammontare;
		private NullTypes.IntNT _IdInvestimento;
		private NullTypes.IntNT _Durata;
		private NullTypes.DecimalNT _ValoreDurata;
		private NullTypes.IntNT _Gravita;
		private NullTypes.DecimalNT _ValoreGravita;
		private NullTypes.IntNT _Entita;
		private NullTypes.DecimalNT _ValoreEntita;
		private NullTypes.StringNT _Titolo;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.StringNT _QuerySql;
		private NullTypes.StringNT _Livello;
		private NullTypes.BoolNT _Istruttoria;
		private NullTypes.BoolNT _ControlloInLoco;
		private NullTypes.BoolNT _ExPost;
		private NullTypes.StringNT _DescrizioneEntita;
		private NullTypes.StringNT _DescrizioneGravita;
		private NullTypes.StringNT _DescrizioneDurata;
		private NullTypes.BoolNT _DurataSelezionato;
		private NullTypes.BoolNT _DurataNumerico;
		private NullTypes.StringNT _DurataTooltip;
		private NullTypes.BoolNT _GravitaSelezionato;
		private NullTypes.BoolNT _GravitaNumerico;
		private NullTypes.StringNT _GravitaTooltip;
		private NullTypes.BoolNT _EntitaSelezionato;
		private NullTypes.BoolNT _EntitaNumerico;
		private NullTypes.StringNT _EntitaTooltip;
		private NullTypes.BoolNT _Automatico;
		private NullTypes.StringNT _Motivazione;
		[NonSerialized] private ISanzioniProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ISanzioniProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public Sanzioni()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_SANZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdSanzione
		{
			get { return _IdSanzione; }
			set {
				if (IdSanzione != value)
				{
					_IdSanzione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_TIPO
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT CodTipo
		{
			get { return _CodTipo; }
			set {
				if (CodTipo != value)
				{
					_CodTipo = value;
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
			set {
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
			set {
				if (IdProgetto != value)
				{
					_IdProgetto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_APPLICAZIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataApplicazione
		{
			get { return _DataApplicazione; }
			set {
				if (DataApplicazione != value)
				{
					_DataApplicazione = value;
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
		/// Corrisponde al campo:AMMONTARE
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT Ammontare
		{
			get { return _Ammontare; }
			set {
				if (Ammontare != value)
				{
					_Ammontare = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_INVESTIMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdInvestimento
		{
			get { return _IdInvestimento; }
			set {
				if (IdInvestimento != value)
				{
					_IdInvestimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DURATA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Durata
		{
			get { return _Durata; }
			set {
				if (Durata != value)
				{
					_Durata = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VALORE_DURATA
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ValoreDurata
		{
			get { return _ValoreDurata; }
			set {
				if (ValoreDurata != value)
				{
					_ValoreDurata = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:GRAVITA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Gravita
		{
			get { return _Gravita; }
			set {
				if (Gravita != value)
				{
					_Gravita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VALORE_GRAVITA
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ValoreGravita
		{
			get { return _ValoreGravita; }
			set {
				if (ValoreGravita != value)
				{
					_ValoreGravita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ENTITA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Entita
		{
			get { return _Entita; }
			set {
				if (Entita != value)
				{
					_Entita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VALORE_ENTITA
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ValoreEntita
		{
			get { return _ValoreEntita; }
			set {
				if (ValoreEntita != value)
				{
					_ValoreEntita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TITOLO
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Titolo
		{
			get { return _Titolo; }
			set {
				if (Titolo != value)
				{
					_Titolo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:NTEXT
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
		/// Corrisponde al campo:QUERY_SQL
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT QuerySql
		{
			get { return _QuerySql; }
			set {
				if (QuerySql != value)
				{
					_QuerySql = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:LIVELLO
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT Livello
		{
			get { return _Livello; }
			set {
				if (Livello != value)
				{
					_Livello = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ISTRUTTORIA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Istruttoria
		{
			get { return _Istruttoria; }
			set {
				if (Istruttoria != value)
				{
					_Istruttoria = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTROLLO_IN_LOCO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT ControlloInLoco
		{
			get { return _ControlloInLoco; }
			set {
				if (ControlloInLoco != value)
				{
					_ControlloInLoco = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:EX_POST
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT ExPost
		{
			get { return _ExPost; }
			set {
				if (ExPost != value)
				{
					_ExPost = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_ENTITA
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT DescrizioneEntita
		{
			get { return _DescrizioneEntita; }
			set {
				if (DescrizioneEntita != value)
				{
					_DescrizioneEntita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_GRAVITA
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT DescrizioneGravita
		{
			get { return _DescrizioneGravita; }
			set {
				if (DescrizioneGravita != value)
				{
					_DescrizioneGravita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_DURATA
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT DescrizioneDurata
		{
			get { return _DescrizioneDurata; }
			set {
				if (DescrizioneDurata != value)
				{
					_DescrizioneDurata = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DURATA_SELEZIONATO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT DurataSelezionato
		{
			get { return _DurataSelezionato; }
			set {
				if (DurataSelezionato != value)
				{
					_DurataSelezionato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DURATA_NUMERICO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT DurataNumerico
		{
			get { return _DurataNumerico; }
			set {
				if (DurataNumerico != value)
				{
					_DurataNumerico = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DURATA_TOOLTIP
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT DurataTooltip
		{
			get { return _DurataTooltip; }
			set {
				if (DurataTooltip != value)
				{
					_DurataTooltip = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:GRAVITA_SELEZIONATO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT GravitaSelezionato
		{
			get { return _GravitaSelezionato; }
			set {
				if (GravitaSelezionato != value)
				{
					_GravitaSelezionato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:GRAVITA_NUMERICO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT GravitaNumerico
		{
			get { return _GravitaNumerico; }
			set {
				if (GravitaNumerico != value)
				{
					_GravitaNumerico = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:GRAVITA_TOOLTIP
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT GravitaTooltip
		{
			get { return _GravitaTooltip; }
			set {
				if (GravitaTooltip != value)
				{
					_GravitaTooltip = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ENTITA_SELEZIONATO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT EntitaSelezionato
		{
			get { return _EntitaSelezionato; }
			set {
				if (EntitaSelezionato != value)
				{
					_EntitaSelezionato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ENTITA_NUMERICO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT EntitaNumerico
		{
			get { return _EntitaNumerico; }
			set {
				if (EntitaNumerico != value)
				{
					_EntitaNumerico = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ENTITA_TOOLTIP
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT EntitaTooltip
		{
			get { return _EntitaTooltip; }
			set {
				if (EntitaTooltip != value)
				{
					_EntitaTooltip = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:AUTOMATICO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Automatico
		{
			get { return _Automatico; }
			set {
				if (Automatico != value)
				{
					_Automatico = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MOTIVAZIONE
		/// Tipo sul db:NTEXT
		/// </summary>
		public NullTypes.StringNT Motivazione
		{
			get { return _Motivazione; }
			set {
				if (Motivazione != value)
				{
					_Motivazione = value;
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
	/// Summary description for SanzioniCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class SanzioniCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private SanzioniCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((Sanzioni) info.GetValue(i.ToString(),typeof(Sanzioni)));
			}
		}

		//Costruttore
		public SanzioniCollection()
		{
			this.ItemType = typeof(Sanzioni);
		}

		//Costruttore con provider
		public SanzioniCollection(ISanzioniProvider providerObj)
		{
			this.ItemType = typeof(Sanzioni);
			this.Provider = providerObj;
		}

		//Get e Set
		public new Sanzioni this[int index]
		{
			get { return (Sanzioni)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new SanzioniCollection GetChanges()
		{
			return (SanzioniCollection) base.GetChanges();
		}

		[NonSerialized] private ISanzioniProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ISanzioniProvider Provider
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
		public int Add(Sanzioni SanzioniObj)
		{
			if (SanzioniObj.Provider == null) SanzioniObj.Provider = this.Provider;
			return base.Add(SanzioniObj);
		}

		//AddCollection
		public void AddCollection(SanzioniCollection SanzioniCollectionObj)
		{
			foreach (Sanzioni SanzioniObj in SanzioniCollectionObj)
				this.Add(SanzioniObj);
		}

		//Insert
		public void Insert(int index, Sanzioni SanzioniObj)
		{
			if (SanzioniObj.Provider == null) SanzioniObj.Provider = this.Provider;
			base.Insert(index, SanzioniObj);
		}

		//CollectionGetById
		public Sanzioni CollectionGetById(NullTypes.IntNT IdSanzioneValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdSanzione == IdSanzioneValue))
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
		public SanzioniCollection SubSelect(NullTypes.IntNT IdSanzioneEqualThis, NullTypes.StringNT CodTipoEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, 
NullTypes.IntNT IdProgettoEqualThis, NullTypes.DatetimeNT DataApplicazioneEqualThis, NullTypes.StringNT OperatoreEqualThis, 
NullTypes.DecimalNT AmmontareEqualThis, NullTypes.IntNT IdInvestimentoEqualThis, NullTypes.IntNT DurataEqualThis, 
NullTypes.DecimalNT ValoreDurataEqualThis, NullTypes.IntNT GravitaEqualThis, NullTypes.DecimalNT ValoreGravitaEqualThis, 
NullTypes.IntNT EntitaEqualThis, NullTypes.DecimalNT ValoreEntitaEqualThis)
		{
			SanzioniCollection SanzioniCollectionTemp = new SanzioniCollection();
			foreach (Sanzioni SanzioniItem in this)
			{
				if (((IdSanzioneEqualThis == null) || ((SanzioniItem.IdSanzione != null) && (SanzioniItem.IdSanzione.Value == IdSanzioneEqualThis.Value))) && ((CodTipoEqualThis == null) || ((SanzioniItem.CodTipo != null) && (SanzioniItem.CodTipo.Value == CodTipoEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((SanzioniItem.IdDomandaPagamento != null) && (SanzioniItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && 
((IdProgettoEqualThis == null) || ((SanzioniItem.IdProgetto != null) && (SanzioniItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((DataApplicazioneEqualThis == null) || ((SanzioniItem.DataApplicazione != null) && (SanzioniItem.DataApplicazione.Value == DataApplicazioneEqualThis.Value))) && ((OperatoreEqualThis == null) || ((SanzioniItem.Operatore != null) && (SanzioniItem.Operatore.Value == OperatoreEqualThis.Value))) && 
((AmmontareEqualThis == null) || ((SanzioniItem.Ammontare != null) && (SanzioniItem.Ammontare.Value == AmmontareEqualThis.Value))) && ((IdInvestimentoEqualThis == null) || ((SanzioniItem.IdInvestimento != null) && (SanzioniItem.IdInvestimento.Value == IdInvestimentoEqualThis.Value))) && ((DurataEqualThis == null) || ((SanzioniItem.Durata != null) && (SanzioniItem.Durata.Value == DurataEqualThis.Value))) && 
((ValoreDurataEqualThis == null) || ((SanzioniItem.ValoreDurata != null) && (SanzioniItem.ValoreDurata.Value == ValoreDurataEqualThis.Value))) && ((GravitaEqualThis == null) || ((SanzioniItem.Gravita != null) && (SanzioniItem.Gravita.Value == GravitaEqualThis.Value))) && ((ValoreGravitaEqualThis == null) || ((SanzioniItem.ValoreGravita != null) && (SanzioniItem.ValoreGravita.Value == ValoreGravitaEqualThis.Value))) && 
((EntitaEqualThis == null) || ((SanzioniItem.Entita != null) && (SanzioniItem.Entita.Value == EntitaEqualThis.Value))) && ((ValoreEntitaEqualThis == null) || ((SanzioniItem.ValoreEntita != null) && (SanzioniItem.ValoreEntita.Value == ValoreEntitaEqualThis.Value))))
				{
					SanzioniCollectionTemp.Add(SanzioniItem);
				}
			}
			return SanzioniCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for SanzioniDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class SanzioniDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, Sanzioni SanzioniObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdSanzione", SanzioniObj.IdSanzione);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipo", SanzioniObj.CodTipo);
			DbProvider.SetCmdParam(cmd,firstChar + "IdDomandaPagamento", SanzioniObj.IdDomandaPagamento);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", SanzioniObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "DataApplicazione", SanzioniObj.DataApplicazione);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", SanzioniObj.Operatore);
			DbProvider.SetCmdParam(cmd,firstChar + "Ammontare", SanzioniObj.Ammontare);
			DbProvider.SetCmdParam(cmd,firstChar + "IdInvestimento", SanzioniObj.IdInvestimento);
			DbProvider.SetCmdParam(cmd,firstChar + "Durata", SanzioniObj.Durata);
			DbProvider.SetCmdParam(cmd,firstChar + "ValoreDurata", SanzioniObj.ValoreDurata);
			DbProvider.SetCmdParam(cmd,firstChar + "Gravita", SanzioniObj.Gravita);
			DbProvider.SetCmdParam(cmd,firstChar + "ValoreGravita", SanzioniObj.ValoreGravita);
			DbProvider.SetCmdParam(cmd,firstChar + "Entita", SanzioniObj.Entita);
			DbProvider.SetCmdParam(cmd,firstChar + "ValoreEntita", SanzioniObj.ValoreEntita);
			DbProvider.SetCmdParam(cmd,firstChar + "Motivazione", SanzioniObj.Motivazione);
		}
		//Insert
		private static int Insert(DbProvider db, Sanzioni SanzioniObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZSanzioniInsert", new string[] {"CodTipo", "IdDomandaPagamento", 
"IdProgetto", "DataApplicazione", "Operatore", 
"Ammontare", "IdInvestimento", "Durata", 
"ValoreDurata", "Gravita", "ValoreGravita", 
"Entita", "ValoreEntita", 






"Motivazione"}, new string[] {"string", "int", 
"int", "DateTime", "string", 
"decimal", "int", "int", 
"decimal", "int", "decimal", 
"int", "decimal", 






"string"},"");
				CompileIUCmd(false, insertCmd,SanzioniObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				SanzioniObj.IdSanzione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SANZIONE"]);
				}
				SanzioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SanzioniObj.IsDirty = false;
				SanzioniObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, Sanzioni SanzioniObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZSanzioniUpdate", new string[] {"IdSanzione", "CodTipo", "IdDomandaPagamento", 
"IdProgetto", "DataApplicazione", "Operatore", 
"Ammontare", "IdInvestimento", "Durata", 
"ValoreDurata", "Gravita", "ValoreGravita", 
"Entita", "ValoreEntita", 






"Motivazione"}, new string[] {"int", "string", "int", 
"int", "DateTime", "string", 
"decimal", "int", "int", 
"decimal", "int", "decimal", 
"int", "decimal", 






"string"},"");
				CompileIUCmd(true, updateCmd,SanzioniObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				SanzioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SanzioniObj.IsDirty = false;
				SanzioniObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, Sanzioni SanzioniObj)
		{
			switch (SanzioniObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, SanzioniObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, SanzioniObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,SanzioniObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, SanzioniCollection SanzioniCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZSanzioniUpdate", new string[] {"IdSanzione", "CodTipo", "IdDomandaPagamento", 
"IdProgetto", "DataApplicazione", "Operatore", 
"Ammontare", "IdInvestimento", "Durata", 
"ValoreDurata", "Gravita", "ValoreGravita", 
"Entita", "ValoreEntita", 






"Motivazione"}, new string[] {"int", "string", "int", 
"int", "DateTime", "string", 
"decimal", "int", "int", 
"decimal", "int", "decimal", 
"int", "decimal", 






"string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZSanzioniInsert", new string[] {"CodTipo", "IdDomandaPagamento", 
"IdProgetto", "DataApplicazione", "Operatore", 
"Ammontare", "IdInvestimento", "Durata", 
"ValoreDurata", "Gravita", "ValoreGravita", 
"Entita", "ValoreEntita", 






"Motivazione"}, new string[] {"string", "int", 
"int", "DateTime", "string", 
"decimal", "int", "int", 
"decimal", "int", "decimal", 
"int", "decimal", 






"string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZSanzioniDelete", new string[] {"IdSanzione"}, new string[] {"int"},"");
				for (int i = 0; i < SanzioniCollectionObj.Count; i++)
				{
					switch (SanzioniCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,SanzioniCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									SanzioniCollectionObj[i].IdSanzione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SANZIONE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,SanzioniCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (SanzioniCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdSanzione", (SiarLibrary.NullTypes.IntNT)SanzioniCollectionObj[i].IdSanzione);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < SanzioniCollectionObj.Count; i++)
				{
					if ((SanzioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (SanzioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						SanzioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						SanzioniCollectionObj[i].IsDirty = false;
						SanzioniCollectionObj[i].IsPersistent = true;
					}
					if ((SanzioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						SanzioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						SanzioniCollectionObj[i].IsDirty = false;
						SanzioniCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, Sanzioni SanzioniObj)
		{
			int returnValue = 0;
			if (SanzioniObj.IsPersistent) 
			{
				returnValue = Delete(db, SanzioniObj.IdSanzione);
			}
			SanzioniObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			SanzioniObj.IsDirty = false;
			SanzioniObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdSanzioneValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZSanzioniDelete", new string[] {"IdSanzione"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdSanzione", (SiarLibrary.NullTypes.IntNT)IdSanzioneValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, SanzioniCollection SanzioniCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZSanzioniDelete", new string[] {"IdSanzione"}, new string[] {"int"},"");
				for (int i = 0; i < SanzioniCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdSanzione", SanzioniCollectionObj[i].IdSanzione);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < SanzioniCollectionObj.Count; i++)
				{
					if ((SanzioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (SanzioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						SanzioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						SanzioniCollectionObj[i].IsDirty = false;
						SanzioniCollectionObj[i].IsPersistent = false;
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
		public static Sanzioni GetById(DbProvider db, int IdSanzioneValue)
		{
			Sanzioni SanzioniObj = null;
			IDbCommand readCmd = db.InitCmd( "ZSanzioniGetById", new string[] {"IdSanzione"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdSanzione", (SiarLibrary.NullTypes.IntNT)IdSanzioneValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				SanzioniObj = GetFromDatareader(db);
				SanzioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SanzioniObj.IsDirty = false;
				SanzioniObj.IsPersistent = true;
			}
			db.Close();
			return SanzioniObj;
		}

		//getFromDatareader
		public static Sanzioni GetFromDatareader(DbProvider db)
		{
			Sanzioni SanzioniObj = new Sanzioni();
			SanzioniObj.IdSanzione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SANZIONE"]);
			SanzioniObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
			SanzioniObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
			SanzioniObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			SanzioniObj.DataApplicazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_APPLICAZIONE"]);
			SanzioniObj.Operatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE"]);
			SanzioniObj.Ammontare = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["AMMONTARE"]);
			SanzioniObj.IdInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INVESTIMENTO"]);
			SanzioniObj.Durata = new SiarLibrary.NullTypes.IntNT(db.DataReader["DURATA"]);
			SanzioniObj.ValoreDurata = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VALORE_DURATA"]);
			SanzioniObj.Gravita = new SiarLibrary.NullTypes.IntNT(db.DataReader["GRAVITA"]);
			SanzioniObj.ValoreGravita = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VALORE_GRAVITA"]);
			SanzioniObj.Entita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ENTITA"]);
			SanzioniObj.ValoreEntita = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VALORE_ENTITA"]);
			SanzioniObj.Titolo = new SiarLibrary.NullTypes.StringNT(db.DataReader["TITOLO"]);
			SanzioniObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			SanzioniObj.QuerySql = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_SQL"]);
			SanzioniObj.Livello = new SiarLibrary.NullTypes.StringNT(db.DataReader["LIVELLO"]);
			SanzioniObj.Istruttoria = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ISTRUTTORIA"]);
			SanzioniObj.ControlloInLoco = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CONTROLLO_IN_LOCO"]);
			SanzioniObj.ExPost = new SiarLibrary.NullTypes.BoolNT(db.DataReader["EX_POST"]);
			SanzioniObj.DescrizioneEntita = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_ENTITA"]);
			SanzioniObj.DescrizioneGravita = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_GRAVITA"]);
			SanzioniObj.DescrizioneDurata = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_DURATA"]);
			SanzioniObj.DurataSelezionato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DURATA_SELEZIONATO"]);
			SanzioniObj.DurataNumerico = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DURATA_NUMERICO"]);
			SanzioniObj.DurataTooltip = new SiarLibrary.NullTypes.StringNT(db.DataReader["DURATA_TOOLTIP"]);
			SanzioniObj.GravitaSelezionato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["GRAVITA_SELEZIONATO"]);
			SanzioniObj.GravitaNumerico = new SiarLibrary.NullTypes.BoolNT(db.DataReader["GRAVITA_NUMERICO"]);
			SanzioniObj.GravitaTooltip = new SiarLibrary.NullTypes.StringNT(db.DataReader["GRAVITA_TOOLTIP"]);
			SanzioniObj.EntitaSelezionato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ENTITA_SELEZIONATO"]);
			SanzioniObj.EntitaNumerico = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ENTITA_NUMERICO"]);
			SanzioniObj.EntitaTooltip = new SiarLibrary.NullTypes.StringNT(db.DataReader["ENTITA_TOOLTIP"]);
			SanzioniObj.Automatico = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AUTOMATICO"]);
			SanzioniObj.Motivazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["MOTIVAZIONE"]);
			SanzioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			SanzioniObj.IsDirty = false;
			SanzioniObj.IsPersistent = true;
			return SanzioniObj;
		}

		//Find Select

		public static SanzioniCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdSanzioneEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, 
SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataApplicazioneEqualThis, SiarLibrary.NullTypes.StringNT OperatoreEqualThis, 
SiarLibrary.NullTypes.DecimalNT AmmontareEqualThis, SiarLibrary.NullTypes.IntNT IdInvestimentoEqualThis, SiarLibrary.NullTypes.IntNT DurataEqualThis, 
SiarLibrary.NullTypes.DecimalNT ValoreDurataEqualThis, SiarLibrary.NullTypes.IntNT GravitaEqualThis, SiarLibrary.NullTypes.DecimalNT ValoreGravitaEqualThis, 
SiarLibrary.NullTypes.IntNT EntitaEqualThis, SiarLibrary.NullTypes.DecimalNT ValoreEntitaEqualThis)

		{

			SanzioniCollection SanzioniCollectionObj = new SanzioniCollection();

			IDbCommand findCmd = db.InitCmd("Zsanzionifindselect", new string[] {"IdSanzioneequalthis", "CodTipoequalthis", "IdDomandaPagamentoequalthis", 
"IdProgettoequalthis", "DataApplicazioneequalthis", "Operatoreequalthis", 
"Ammontareequalthis", "IdInvestimentoequalthis", "Durataequalthis", 
"ValoreDurataequalthis", "Gravitaequalthis", "ValoreGravitaequalthis", 
"Entitaequalthis", "ValoreEntitaequalthis"}, new string[] {"int", "string", "int", 
"int", "DateTime", "string", 
"decimal", "int", "int", 
"decimal", "int", "decimal", 
"int", "decimal"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdSanzioneequalthis", IdSanzioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataApplicazioneequalthis", DataApplicazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ammontareequalthis", AmmontareEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdInvestimentoequalthis", IdInvestimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Durataequalthis", DurataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ValoreDurataequalthis", ValoreDurataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Gravitaequalthis", GravitaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ValoreGravitaequalthis", ValoreGravitaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Entitaequalthis", EntitaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ValoreEntitaequalthis", ValoreEntitaEqualThis);
			Sanzioni SanzioniObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				SanzioniObj = GetFromDatareader(db);
				SanzioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SanzioniObj.IsDirty = false;
				SanzioniObj.IsPersistent = true;
				SanzioniCollectionObj.Add(SanzioniObj);
			}
			db.Close();
			return SanzioniCollectionObj;
		}

		//Find Find

		public static SanzioniCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdSanzioneEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, 
SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdInvestimentoEqualThis, SiarLibrary.NullTypes.StringNT LivelloEqualThis)

		{

			SanzioniCollection SanzioniCollectionObj = new SanzioniCollection();

			IDbCommand findCmd = db.InitCmd("Zsanzionifindfind", new string[] {"IdSanzioneequalthis", "CodTipoequalthis", "IdDomandaPagamentoequalthis", 
"IdProgettoequalthis", "IdInvestimentoequalthis", "Livelloequalthis"}, new string[] {"int", "string", "int", 
"int", "int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdSanzioneequalthis", IdSanzioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdInvestimentoequalthis", IdInvestimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Livelloequalthis", LivelloEqualThis);
			Sanzioni SanzioniObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				SanzioniObj = GetFromDatareader(db);
				SanzioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SanzioniObj.IsDirty = false;
				SanzioniObj.IsPersistent = true;
				SanzioniCollectionObj.Add(SanzioniObj);
			}
			db.Close();
			return SanzioniCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for SanzioniCollectionProvider:ISanzioniProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class SanzioniCollectionProvider : ISanzioniProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di Sanzioni
		protected SanzioniCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public SanzioniCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new SanzioniCollection(this);
		}

		//Costruttore 2: popola la collection
		public SanzioniCollectionProvider(IntNT IdsanzioneEqualThis, StringNT CodtipoEqualThis, IntNT IddomandapagamentoEqualThis, 
IntNT IdprogettoEqualThis, IntNT IdinvestimentoEqualThis, StringNT LivelloEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdsanzioneEqualThis, CodtipoEqualThis, IddomandapagamentoEqualThis, 
IdprogettoEqualThis, IdinvestimentoEqualThis, LivelloEqualThis);
		}

		//Costruttore3: ha in input sanzioniCollectionObj - non popola la collection
		public SanzioniCollectionProvider(SanzioniCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public SanzioniCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new SanzioniCollection(this);
		}

		//Get e Set
		public SanzioniCollection CollectionObj
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
		public int SaveCollection(SanzioniCollection collectionObj)
		{
			return SanzioniDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(Sanzioni sanzioniObj)
		{
			return SanzioniDAL.Save(_dbProviderObj, sanzioniObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(SanzioniCollection collectionObj)
		{
			return SanzioniDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(Sanzioni sanzioniObj)
		{
			return SanzioniDAL.Delete(_dbProviderObj, sanzioniObj);
		}

		//getById
		public Sanzioni GetById(IntNT IdSanzioneValue)
		{
			Sanzioni SanzioniTemp = SanzioniDAL.GetById(_dbProviderObj, IdSanzioneValue);
			if (SanzioniTemp!=null) SanzioniTemp.Provider = this;
			return SanzioniTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public SanzioniCollection Select(IntNT IdsanzioneEqualThis, StringNT CodtipoEqualThis, IntNT IddomandapagamentoEqualThis, 
IntNT IdprogettoEqualThis, DatetimeNT DataapplicazioneEqualThis, StringNT OperatoreEqualThis, 
DecimalNT AmmontareEqualThis, IntNT IdinvestimentoEqualThis, IntNT DurataEqualThis, 
DecimalNT ValoredurataEqualThis, IntNT GravitaEqualThis, DecimalNT ValoregravitaEqualThis, 
IntNT EntitaEqualThis, DecimalNT ValoreentitaEqualThis)
		{
			SanzioniCollection SanzioniCollectionTemp = SanzioniDAL.Select(_dbProviderObj, IdsanzioneEqualThis, CodtipoEqualThis, IddomandapagamentoEqualThis, 
IdprogettoEqualThis, DataapplicazioneEqualThis, OperatoreEqualThis, 
AmmontareEqualThis, IdinvestimentoEqualThis, DurataEqualThis, 
ValoredurataEqualThis, GravitaEqualThis, ValoregravitaEqualThis, 
EntitaEqualThis, ValoreentitaEqualThis);
			SanzioniCollectionTemp.Provider = this;
			return SanzioniCollectionTemp;
		}

		//Find: popola la collection
		public SanzioniCollection Find(IntNT IdsanzioneEqualThis, StringNT CodtipoEqualThis, IntNT IddomandapagamentoEqualThis, 
IntNT IdprogettoEqualThis, IntNT IdinvestimentoEqualThis, StringNT LivelloEqualThis)
		{
			SanzioniCollection SanzioniCollectionTemp = SanzioniDAL.Find(_dbProviderObj, IdsanzioneEqualThis, CodtipoEqualThis, IddomandapagamentoEqualThis, 
IdprogettoEqualThis, IdinvestimentoEqualThis, LivelloEqualThis);
			SanzioniCollectionTemp.Provider = this;
			return SanzioniCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<SANZIONI>
  <ViewName>vSANZIONI</ViewName>
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
    <Find OrderBy="ORDER BY ID_SANZIONE">
      <ID_SANZIONE>Equal</ID_SANZIONE>
      <COD_TIPO>Equal</COD_TIPO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_INVESTIMENTO>Equal</ID_INVESTIMENTO>
      <LIVELLO>Equal</LIVELLO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</SANZIONI>
*/
