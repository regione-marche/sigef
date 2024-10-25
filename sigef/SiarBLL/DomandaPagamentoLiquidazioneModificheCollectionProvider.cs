using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per DomandaPagamentoLiquidazioneModifiche
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IDomandaPagamentoLiquidazioneModificheProvider
	{
		int Save(DomandaPagamentoLiquidazioneModifiche DomandaPagamentoLiquidazioneModificheObj);
		int SaveCollection(DomandaPagamentoLiquidazioneModificheCollection collectionObj);
		int Delete(DomandaPagamentoLiquidazioneModifiche DomandaPagamentoLiquidazioneModificheObj);
		int DeleteCollection(DomandaPagamentoLiquidazioneModificheCollection collectionObj);
	}
	/// <summary>
	/// Summary description for DomandaPagamentoLiquidazioneModifiche
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class DomandaPagamentoLiquidazioneModifiche: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdDomandaPagamentoLiquidazioneModifiche;
		private NullTypes.IntNT _IdModifica;
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdDomandaPagamento;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdImpresaBeneficiaria;
		private NullTypes.IntNT _IdDecreto;
		private NullTypes.DecimalNT _RichiestaMandatoImporto;
		private NullTypes.StringNT _RichiestaMandatoSegnatura;
		private NullTypes.DatetimeNT _RichiestaMandatoData;
		private NullTypes.StringNT _MandatoNumero;
		private NullTypes.DatetimeNT _MandatoData;
		private NullTypes.DecimalNT _MandatoImporto;
		private NullTypes.IntNT _MandatoIdFile;
		private NullTypes.DatetimeNT _QuietanzaData;
		private NullTypes.DecimalNT _QuietanzaImporto;
		private NullTypes.BoolNT _Liquidato;
		[NonSerialized] private IDomandaPagamentoLiquidazioneModificheProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IDomandaPagamentoLiquidazioneModificheProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public DomandaPagamentoLiquidazioneModifiche()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_DOMANDA_PAGAMENTO_LIQUIDAZIONE_MODIFICHE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDomandaPagamentoLiquidazioneModifiche
		{
			get { return _IdDomandaPagamentoLiquidazioneModifiche; }
			set {
				if (IdDomandaPagamentoLiquidazioneModifiche != value)
				{
					_IdDomandaPagamentoLiquidazioneModifiche = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_MODIFICA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdModifica
		{
			get { return _IdModifica; }
			set {
				if (IdModifica != value)
				{
					_IdModifica = value;
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
		/// Corrisponde al campo:ID_IMPRESA_BENEFICIARIA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdImpresaBeneficiaria
		{
			get { return _IdImpresaBeneficiaria; }
			set {
				if (IdImpresaBeneficiaria != value)
				{
					_IdImpresaBeneficiaria = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_DECRETO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDecreto
		{
			get { return _IdDecreto; }
			set {
				if (IdDecreto != value)
				{
					_IdDecreto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RICHIESTA_MANDATO_IMPORTO
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT RichiestaMandatoImporto
		{
			get { return _RichiestaMandatoImporto; }
			set {
				if (RichiestaMandatoImporto != value)
				{
					_RichiestaMandatoImporto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RICHIESTA_MANDATO_SEGNATURA
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT RichiestaMandatoSegnatura
		{
			get { return _RichiestaMandatoSegnatura; }
			set {
				if (RichiestaMandatoSegnatura != value)
				{
					_RichiestaMandatoSegnatura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RICHIESTA_MANDATO_DATA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT RichiestaMandatoData
		{
			get { return _RichiestaMandatoData; }
			set {
				if (RichiestaMandatoData != value)
				{
					_RichiestaMandatoData = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MANDATO_NUMERO
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT MandatoNumero
		{
			get { return _MandatoNumero; }
			set {
				if (MandatoNumero != value)
				{
					_MandatoNumero = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MANDATO_DATA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT MandatoData
		{
			get { return _MandatoData; }
			set {
				if (MandatoData != value)
				{
					_MandatoData = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MANDATO_IMPORTO
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT MandatoImporto
		{
			get { return _MandatoImporto; }
			set {
				if (MandatoImporto != value)
				{
					_MandatoImporto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MANDATO_ID_FILE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT MandatoIdFile
		{
			get { return _MandatoIdFile; }
			set {
				if (MandatoIdFile != value)
				{
					_MandatoIdFile = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUIETANZA_DATA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT QuietanzaData
		{
			get { return _QuietanzaData; }
			set {
				if (QuietanzaData != value)
				{
					_QuietanzaData = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUIETANZA_IMPORTO
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT QuietanzaImporto
		{
			get { return _QuietanzaImporto; }
			set {
				if (QuietanzaImporto != value)
				{
					_QuietanzaImporto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:LIQUIDATO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Liquidato
		{
			get { return _Liquidato; }
			set {
				if (Liquidato != value)
				{
					_Liquidato = value;
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
	/// Summary description for DomandaPagamentoLiquidazioneModificheCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class DomandaPagamentoLiquidazioneModificheCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private DomandaPagamentoLiquidazioneModificheCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((DomandaPagamentoLiquidazioneModifiche) info.GetValue(i.ToString(),typeof(DomandaPagamentoLiquidazioneModifiche)));
			}
		}

		//Costruttore
		public DomandaPagamentoLiquidazioneModificheCollection()
		{
			this.ItemType = typeof(DomandaPagamentoLiquidazioneModifiche);
		}

		//Costruttore con provider
		public DomandaPagamentoLiquidazioneModificheCollection(IDomandaPagamentoLiquidazioneModificheProvider providerObj)
		{
			this.ItemType = typeof(DomandaPagamentoLiquidazioneModifiche);
			this.Provider = providerObj;
		}

		//Get e Set
		public new DomandaPagamentoLiquidazioneModifiche this[int index]
		{
			get { return (DomandaPagamentoLiquidazioneModifiche)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new DomandaPagamentoLiquidazioneModificheCollection GetChanges()
		{
			return (DomandaPagamentoLiquidazioneModificheCollection) base.GetChanges();
		}

		[NonSerialized] private IDomandaPagamentoLiquidazioneModificheProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IDomandaPagamentoLiquidazioneModificheProvider Provider
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
		public int Add(DomandaPagamentoLiquidazioneModifiche DomandaPagamentoLiquidazioneModificheObj)
		{
			if (DomandaPagamentoLiquidazioneModificheObj.Provider == null) DomandaPagamentoLiquidazioneModificheObj.Provider = this.Provider;
			return base.Add(DomandaPagamentoLiquidazioneModificheObj);
		}

		//AddCollection
		public void AddCollection(DomandaPagamentoLiquidazioneModificheCollection DomandaPagamentoLiquidazioneModificheCollectionObj)
		{
			foreach (DomandaPagamentoLiquidazioneModifiche DomandaPagamentoLiquidazioneModificheObj in DomandaPagamentoLiquidazioneModificheCollectionObj)
				this.Add(DomandaPagamentoLiquidazioneModificheObj);
		}

		//Insert
		public void Insert(int index, DomandaPagamentoLiquidazioneModifiche DomandaPagamentoLiquidazioneModificheObj)
		{
			if (DomandaPagamentoLiquidazioneModificheObj.Provider == null) DomandaPagamentoLiquidazioneModificheObj.Provider = this.Provider;
			base.Insert(index, DomandaPagamentoLiquidazioneModificheObj);
		}

		//CollectionGetById
		public DomandaPagamentoLiquidazioneModifiche CollectionGetById(NullTypes.IntNT IdDomandaPagamentoLiquidazioneModificheValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdDomandaPagamentoLiquidazioneModifiche == IdDomandaPagamentoLiquidazioneModificheValue))
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
		public DomandaPagamentoLiquidazioneModificheCollection SubSelect(NullTypes.IntNT IdDomandaPagamentoLiquidazioneModificheEqualThis, NullTypes.IntNT IdModificaEqualThis, NullTypes.IntNT IdEqualThis, 
NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdImpresaBeneficiariaEqualThis, 
NullTypes.IntNT IdDecretoEqualThis, NullTypes.DecimalNT RichiestaMandatoImportoEqualThis, NullTypes.StringNT RichiestaMandatoSegnaturaEqualThis, 
NullTypes.DatetimeNT RichiestaMandatoDataEqualThis, NullTypes.StringNT MandatoNumeroEqualThis, NullTypes.DatetimeNT MandatoDataEqualThis, 
NullTypes.DecimalNT MandatoImportoEqualThis, NullTypes.IntNT MandatoIdFileEqualThis, NullTypes.DatetimeNT QuietanzaDataEqualThis, 
NullTypes.DecimalNT QuietanzaImportoEqualThis, NullTypes.BoolNT LiquidatoEqualThis)
		{
			DomandaPagamentoLiquidazioneModificheCollection DomandaPagamentoLiquidazioneModificheCollectionTemp = new DomandaPagamentoLiquidazioneModificheCollection();
			foreach (DomandaPagamentoLiquidazioneModifiche DomandaPagamentoLiquidazioneModificheItem in this)
			{
				if (((IdDomandaPagamentoLiquidazioneModificheEqualThis == null) || ((DomandaPagamentoLiquidazioneModificheItem.IdDomandaPagamentoLiquidazioneModifiche != null) && (DomandaPagamentoLiquidazioneModificheItem.IdDomandaPagamentoLiquidazioneModifiche.Value == IdDomandaPagamentoLiquidazioneModificheEqualThis.Value))) && ((IdModificaEqualThis == null) || ((DomandaPagamentoLiquidazioneModificheItem.IdModifica != null) && (DomandaPagamentoLiquidazioneModificheItem.IdModifica.Value == IdModificaEqualThis.Value))) && ((IdEqualThis == null) || ((DomandaPagamentoLiquidazioneModificheItem.Id != null) && (DomandaPagamentoLiquidazioneModificheItem.Id.Value == IdEqualThis.Value))) && 
((IdDomandaPagamentoEqualThis == null) || ((DomandaPagamentoLiquidazioneModificheItem.IdDomandaPagamento != null) && (DomandaPagamentoLiquidazioneModificheItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((DomandaPagamentoLiquidazioneModificheItem.IdProgetto != null) && (DomandaPagamentoLiquidazioneModificheItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdImpresaBeneficiariaEqualThis == null) || ((DomandaPagamentoLiquidazioneModificheItem.IdImpresaBeneficiaria != null) && (DomandaPagamentoLiquidazioneModificheItem.IdImpresaBeneficiaria.Value == IdImpresaBeneficiariaEqualThis.Value))) && 
((IdDecretoEqualThis == null) || ((DomandaPagamentoLiquidazioneModificheItem.IdDecreto != null) && (DomandaPagamentoLiquidazioneModificheItem.IdDecreto.Value == IdDecretoEqualThis.Value))) && ((RichiestaMandatoImportoEqualThis == null) || ((DomandaPagamentoLiquidazioneModificheItem.RichiestaMandatoImporto != null) && (DomandaPagamentoLiquidazioneModificheItem.RichiestaMandatoImporto.Value == RichiestaMandatoImportoEqualThis.Value))) && ((RichiestaMandatoSegnaturaEqualThis == null) || ((DomandaPagamentoLiquidazioneModificheItem.RichiestaMandatoSegnatura != null) && (DomandaPagamentoLiquidazioneModificheItem.RichiestaMandatoSegnatura.Value == RichiestaMandatoSegnaturaEqualThis.Value))) && 
((RichiestaMandatoDataEqualThis == null) || ((DomandaPagamentoLiquidazioneModificheItem.RichiestaMandatoData != null) && (DomandaPagamentoLiquidazioneModificheItem.RichiestaMandatoData.Value == RichiestaMandatoDataEqualThis.Value))) && ((MandatoNumeroEqualThis == null) || ((DomandaPagamentoLiquidazioneModificheItem.MandatoNumero != null) && (DomandaPagamentoLiquidazioneModificheItem.MandatoNumero.Value == MandatoNumeroEqualThis.Value))) && ((MandatoDataEqualThis == null) || ((DomandaPagamentoLiquidazioneModificheItem.MandatoData != null) && (DomandaPagamentoLiquidazioneModificheItem.MandatoData.Value == MandatoDataEqualThis.Value))) && 
((MandatoImportoEqualThis == null) || ((DomandaPagamentoLiquidazioneModificheItem.MandatoImporto != null) && (DomandaPagamentoLiquidazioneModificheItem.MandatoImporto.Value == MandatoImportoEqualThis.Value))) && ((MandatoIdFileEqualThis == null) || ((DomandaPagamentoLiquidazioneModificheItem.MandatoIdFile != null) && (DomandaPagamentoLiquidazioneModificheItem.MandatoIdFile.Value == MandatoIdFileEqualThis.Value))) && ((QuietanzaDataEqualThis == null) || ((DomandaPagamentoLiquidazioneModificheItem.QuietanzaData != null) && (DomandaPagamentoLiquidazioneModificheItem.QuietanzaData.Value == QuietanzaDataEqualThis.Value))) && 
((QuietanzaImportoEqualThis == null) || ((DomandaPagamentoLiquidazioneModificheItem.QuietanzaImporto != null) && (DomandaPagamentoLiquidazioneModificheItem.QuietanzaImporto.Value == QuietanzaImportoEqualThis.Value))) && ((LiquidatoEqualThis == null) || ((DomandaPagamentoLiquidazioneModificheItem.Liquidato != null) && (DomandaPagamentoLiquidazioneModificheItem.Liquidato.Value == LiquidatoEqualThis.Value))))
				{
					DomandaPagamentoLiquidazioneModificheCollectionTemp.Add(DomandaPagamentoLiquidazioneModificheItem);
				}
			}
			return DomandaPagamentoLiquidazioneModificheCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for DomandaPagamentoLiquidazioneModificheDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class DomandaPagamentoLiquidazioneModificheDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, DomandaPagamentoLiquidazioneModifiche DomandaPagamentoLiquidazioneModificheObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdDomandaPagamentoLiquidazioneModifiche", DomandaPagamentoLiquidazioneModificheObj.IdDomandaPagamentoLiquidazioneModifiche);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdModifica", DomandaPagamentoLiquidazioneModificheObj.IdModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "Id", DomandaPagamentoLiquidazioneModificheObj.Id);
			DbProvider.SetCmdParam(cmd,firstChar + "IdDomandaPagamento", DomandaPagamentoLiquidazioneModificheObj.IdDomandaPagamento);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", DomandaPagamentoLiquidazioneModificheObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdImpresaBeneficiaria", DomandaPagamentoLiquidazioneModificheObj.IdImpresaBeneficiaria);
			DbProvider.SetCmdParam(cmd,firstChar + "IdDecreto", DomandaPagamentoLiquidazioneModificheObj.IdDecreto);
			DbProvider.SetCmdParam(cmd,firstChar + "RichiestaMandatoImporto", DomandaPagamentoLiquidazioneModificheObj.RichiestaMandatoImporto);
			DbProvider.SetCmdParam(cmd,firstChar + "RichiestaMandatoSegnatura", DomandaPagamentoLiquidazioneModificheObj.RichiestaMandatoSegnatura);
			DbProvider.SetCmdParam(cmd,firstChar + "RichiestaMandatoData", DomandaPagamentoLiquidazioneModificheObj.RichiestaMandatoData);
			DbProvider.SetCmdParam(cmd,firstChar + "MandatoNumero", DomandaPagamentoLiquidazioneModificheObj.MandatoNumero);
			DbProvider.SetCmdParam(cmd,firstChar + "MandatoData", DomandaPagamentoLiquidazioneModificheObj.MandatoData);
			DbProvider.SetCmdParam(cmd,firstChar + "MandatoImporto", DomandaPagamentoLiquidazioneModificheObj.MandatoImporto);
			DbProvider.SetCmdParam(cmd,firstChar + "MandatoIdFile", DomandaPagamentoLiquidazioneModificheObj.MandatoIdFile);
			DbProvider.SetCmdParam(cmd,firstChar + "QuietanzaData", DomandaPagamentoLiquidazioneModificheObj.QuietanzaData);
			DbProvider.SetCmdParam(cmd,firstChar + "QuietanzaImporto", DomandaPagamentoLiquidazioneModificheObj.QuietanzaImporto);
			DbProvider.SetCmdParam(cmd,firstChar + "Liquidato", DomandaPagamentoLiquidazioneModificheObj.Liquidato);
		}
		//Insert
		private static int Insert(DbProvider db, DomandaPagamentoLiquidazioneModifiche DomandaPagamentoLiquidazioneModificheObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZDomandaPagamentoLiquidazioneModificheInsert", new string[] {"IdModifica", "Id", 
"IdDomandaPagamento", "IdProgetto", "IdImpresaBeneficiaria", 
"IdDecreto", "RichiestaMandatoImporto", "RichiestaMandatoSegnatura", 
"RichiestaMandatoData", "MandatoNumero", "MandatoData", 
"MandatoImporto", "MandatoIdFile", "QuietanzaData", 
"QuietanzaImporto", "Liquidato"}, new string[] {"int", "int", 
"int", "int", "int", 
"int", "decimal", "string", 
"DateTime", "string", "DateTime", 
"decimal", "int", "DateTime", 
"decimal", "bool"},"");
				CompileIUCmd(false, insertCmd,DomandaPagamentoLiquidazioneModificheObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				DomandaPagamentoLiquidazioneModificheObj.IdDomandaPagamentoLiquidazioneModifiche = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO_LIQUIDAZIONE_MODIFICHE"]);
				}
				DomandaPagamentoLiquidazioneModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DomandaPagamentoLiquidazioneModificheObj.IsDirty = false;
				DomandaPagamentoLiquidazioneModificheObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, DomandaPagamentoLiquidazioneModifiche DomandaPagamentoLiquidazioneModificheObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZDomandaPagamentoLiquidazioneModificheUpdate", new string[] {"IdDomandaPagamentoLiquidazioneModifiche", "IdModifica", "Id", 
"IdDomandaPagamento", "IdProgetto", "IdImpresaBeneficiaria", 
"IdDecreto", "RichiestaMandatoImporto", "RichiestaMandatoSegnatura", 
"RichiestaMandatoData", "MandatoNumero", "MandatoData", 
"MandatoImporto", "MandatoIdFile", "QuietanzaData", 
"QuietanzaImporto", "Liquidato"}, new string[] {"int", "int", "int", 
"int", "int", "int", 
"int", "decimal", "string", 
"DateTime", "string", "DateTime", 
"decimal", "int", "DateTime", 
"decimal", "bool"},"");
				CompileIUCmd(true, updateCmd,DomandaPagamentoLiquidazioneModificheObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				DomandaPagamentoLiquidazioneModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DomandaPagamentoLiquidazioneModificheObj.IsDirty = false;
				DomandaPagamentoLiquidazioneModificheObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, DomandaPagamentoLiquidazioneModifiche DomandaPagamentoLiquidazioneModificheObj)
		{
			switch (DomandaPagamentoLiquidazioneModificheObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, DomandaPagamentoLiquidazioneModificheObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, DomandaPagamentoLiquidazioneModificheObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,DomandaPagamentoLiquidazioneModificheObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, DomandaPagamentoLiquidazioneModificheCollection DomandaPagamentoLiquidazioneModificheCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZDomandaPagamentoLiquidazioneModificheUpdate", new string[] {"IdDomandaPagamentoLiquidazioneModifiche", "IdModifica", "Id", 
"IdDomandaPagamento", "IdProgetto", "IdImpresaBeneficiaria", 
"IdDecreto", "RichiestaMandatoImporto", "RichiestaMandatoSegnatura", 
"RichiestaMandatoData", "MandatoNumero", "MandatoData", 
"MandatoImporto", "MandatoIdFile", "QuietanzaData", 
"QuietanzaImporto", "Liquidato"}, new string[] {"int", "int", "int", 
"int", "int", "int", 
"int", "decimal", "string", 
"DateTime", "string", "DateTime", 
"decimal", "int", "DateTime", 
"decimal", "bool"},"");
				IDbCommand insertCmd = db.InitCmd( "ZDomandaPagamentoLiquidazioneModificheInsert", new string[] {"IdModifica", "Id", 
"IdDomandaPagamento", "IdProgetto", "IdImpresaBeneficiaria", 
"IdDecreto", "RichiestaMandatoImporto", "RichiestaMandatoSegnatura", 
"RichiestaMandatoData", "MandatoNumero", "MandatoData", 
"MandatoImporto", "MandatoIdFile", "QuietanzaData", 
"QuietanzaImporto", "Liquidato"}, new string[] {"int", "int", 
"int", "int", "int", 
"int", "decimal", "string", 
"DateTime", "string", "DateTime", 
"decimal", "int", "DateTime", 
"decimal", "bool"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZDomandaPagamentoLiquidazioneModificheDelete", new string[] {"IdDomandaPagamentoLiquidazioneModifiche"}, new string[] {"int"},"");
				for (int i = 0; i < DomandaPagamentoLiquidazioneModificheCollectionObj.Count; i++)
				{
					switch (DomandaPagamentoLiquidazioneModificheCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,DomandaPagamentoLiquidazioneModificheCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									DomandaPagamentoLiquidazioneModificheCollectionObj[i].IdDomandaPagamentoLiquidazioneModifiche = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO_LIQUIDAZIONE_MODIFICHE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,DomandaPagamentoLiquidazioneModificheCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (DomandaPagamentoLiquidazioneModificheCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDomandaPagamentoLiquidazioneModifiche", (SiarLibrary.NullTypes.IntNT)DomandaPagamentoLiquidazioneModificheCollectionObj[i].IdDomandaPagamentoLiquidazioneModifiche);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < DomandaPagamentoLiquidazioneModificheCollectionObj.Count; i++)
				{
					if ((DomandaPagamentoLiquidazioneModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (DomandaPagamentoLiquidazioneModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						DomandaPagamentoLiquidazioneModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						DomandaPagamentoLiquidazioneModificheCollectionObj[i].IsDirty = false;
						DomandaPagamentoLiquidazioneModificheCollectionObj[i].IsPersistent = true;
					}
					if ((DomandaPagamentoLiquidazioneModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						DomandaPagamentoLiquidazioneModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						DomandaPagamentoLiquidazioneModificheCollectionObj[i].IsDirty = false;
						DomandaPagamentoLiquidazioneModificheCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, DomandaPagamentoLiquidazioneModifiche DomandaPagamentoLiquidazioneModificheObj)
		{
			int returnValue = 0;
			if (DomandaPagamentoLiquidazioneModificheObj.IsPersistent) 
			{
				returnValue = Delete(db, DomandaPagamentoLiquidazioneModificheObj.IdDomandaPagamentoLiquidazioneModifiche);
			}
			DomandaPagamentoLiquidazioneModificheObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			DomandaPagamentoLiquidazioneModificheObj.IsDirty = false;
			DomandaPagamentoLiquidazioneModificheObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdDomandaPagamentoLiquidazioneModificheValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZDomandaPagamentoLiquidazioneModificheDelete", new string[] {"IdDomandaPagamentoLiquidazioneModifiche"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDomandaPagamentoLiquidazioneModifiche", (SiarLibrary.NullTypes.IntNT)IdDomandaPagamentoLiquidazioneModificheValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, DomandaPagamentoLiquidazioneModificheCollection DomandaPagamentoLiquidazioneModificheCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZDomandaPagamentoLiquidazioneModificheDelete", new string[] {"IdDomandaPagamentoLiquidazioneModifiche"}, new string[] {"int"},"");
				for (int i = 0; i < DomandaPagamentoLiquidazioneModificheCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDomandaPagamentoLiquidazioneModifiche", DomandaPagamentoLiquidazioneModificheCollectionObj[i].IdDomandaPagamentoLiquidazioneModifiche);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < DomandaPagamentoLiquidazioneModificheCollectionObj.Count; i++)
				{
					if ((DomandaPagamentoLiquidazioneModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (DomandaPagamentoLiquidazioneModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						DomandaPagamentoLiquidazioneModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						DomandaPagamentoLiquidazioneModificheCollectionObj[i].IsDirty = false;
						DomandaPagamentoLiquidazioneModificheCollectionObj[i].IsPersistent = false;
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
		public static DomandaPagamentoLiquidazioneModifiche GetById(DbProvider db, int IdDomandaPagamentoLiquidazioneModificheValue)
		{
			DomandaPagamentoLiquidazioneModifiche DomandaPagamentoLiquidazioneModificheObj = null;
			IDbCommand readCmd = db.InitCmd( "ZDomandaPagamentoLiquidazioneModificheGetById", new string[] {"IdDomandaPagamentoLiquidazioneModifiche"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdDomandaPagamentoLiquidazioneModifiche", (SiarLibrary.NullTypes.IntNT)IdDomandaPagamentoLiquidazioneModificheValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				DomandaPagamentoLiquidazioneModificheObj = GetFromDatareader(db);
				DomandaPagamentoLiquidazioneModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DomandaPagamentoLiquidazioneModificheObj.IsDirty = false;
				DomandaPagamentoLiquidazioneModificheObj.IsPersistent = true;
			}
			db.Close();
			return DomandaPagamentoLiquidazioneModificheObj;
		}

		//getFromDatareader
		public static DomandaPagamentoLiquidazioneModifiche GetFromDatareader(DbProvider db)
		{
			DomandaPagamentoLiquidazioneModifiche DomandaPagamentoLiquidazioneModificheObj = new DomandaPagamentoLiquidazioneModifiche();
			DomandaPagamentoLiquidazioneModificheObj.IdDomandaPagamentoLiquidazioneModifiche = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO_LIQUIDAZIONE_MODIFICHE"]);
			DomandaPagamentoLiquidazioneModificheObj.IdModifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_MODIFICA"]);
			DomandaPagamentoLiquidazioneModificheObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			DomandaPagamentoLiquidazioneModificheObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
			DomandaPagamentoLiquidazioneModificheObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			DomandaPagamentoLiquidazioneModificheObj.IdImpresaBeneficiaria = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA_BENEFICIARIA"]);
			DomandaPagamentoLiquidazioneModificheObj.IdDecreto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DECRETO"]);
			DomandaPagamentoLiquidazioneModificheObj.RichiestaMandatoImporto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["RICHIESTA_MANDATO_IMPORTO"]);
			DomandaPagamentoLiquidazioneModificheObj.RichiestaMandatoSegnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["RICHIESTA_MANDATO_SEGNATURA"]);
			DomandaPagamentoLiquidazioneModificheObj.RichiestaMandatoData = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["RICHIESTA_MANDATO_DATA"]);
			DomandaPagamentoLiquidazioneModificheObj.MandatoNumero = new SiarLibrary.NullTypes.StringNT(db.DataReader["MANDATO_NUMERO"]);
			DomandaPagamentoLiquidazioneModificheObj.MandatoData = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["MANDATO_DATA"]);
			DomandaPagamentoLiquidazioneModificheObj.MandatoImporto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["MANDATO_IMPORTO"]);
			DomandaPagamentoLiquidazioneModificheObj.MandatoIdFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["MANDATO_ID_FILE"]);
			DomandaPagamentoLiquidazioneModificheObj.QuietanzaData = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["QUIETANZA_DATA"]);
			DomandaPagamentoLiquidazioneModificheObj.QuietanzaImporto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUIETANZA_IMPORTO"]);
			DomandaPagamentoLiquidazioneModificheObj.Liquidato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["LIQUIDATO"]);
			DomandaPagamentoLiquidazioneModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			DomandaPagamentoLiquidazioneModificheObj.IsDirty = false;
			DomandaPagamentoLiquidazioneModificheObj.IsPersistent = true;
			return DomandaPagamentoLiquidazioneModificheObj;
		}

		//Find Select

		public static DomandaPagamentoLiquidazioneModificheCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoLiquidazioneModificheEqualThis, SiarLibrary.NullTypes.IntNT IdModificaEqualThis, SiarLibrary.NullTypes.IntNT IdEqualThis, 
SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaBeneficiariaEqualThis, 
SiarLibrary.NullTypes.IntNT IdDecretoEqualThis, SiarLibrary.NullTypes.DecimalNT RichiestaMandatoImportoEqualThis, SiarLibrary.NullTypes.StringNT RichiestaMandatoSegnaturaEqualThis, 
SiarLibrary.NullTypes.DatetimeNT RichiestaMandatoDataEqualThis, SiarLibrary.NullTypes.StringNT MandatoNumeroEqualThis, SiarLibrary.NullTypes.DatetimeNT MandatoDataEqualThis, 
SiarLibrary.NullTypes.DecimalNT MandatoImportoEqualThis, SiarLibrary.NullTypes.IntNT MandatoIdFileEqualThis, SiarLibrary.NullTypes.DatetimeNT QuietanzaDataEqualThis, 
SiarLibrary.NullTypes.DecimalNT QuietanzaImportoEqualThis, SiarLibrary.NullTypes.BoolNT LiquidatoEqualThis)

		{

			DomandaPagamentoLiquidazioneModificheCollection DomandaPagamentoLiquidazioneModificheCollectionObj = new DomandaPagamentoLiquidazioneModificheCollection();

			IDbCommand findCmd = db.InitCmd("Zdomandapagamentoliquidazionemodifichefindselect", new string[] {"IdDomandaPagamentoLiquidazioneModificheequalthis", "IdModificaequalthis", "Idequalthis", 
"IdDomandaPagamentoequalthis", "IdProgettoequalthis", "IdImpresaBeneficiariaequalthis", 
"IdDecretoequalthis", "RichiestaMandatoImportoequalthis", "RichiestaMandatoSegnaturaequalthis", 
"RichiestaMandatoDataequalthis", "MandatoNumeroequalthis", "MandatoDataequalthis", 
"MandatoImportoequalthis", "MandatoIdFileequalthis", "QuietanzaDataequalthis", 
"QuietanzaImportoequalthis", "Liquidatoequalthis"}, new string[] {"int", "int", "int", 
"int", "int", "int", 
"int", "decimal", "string", 
"DateTime", "string", "DateTime", 
"decimal", "int", "DateTime", 
"decimal", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoLiquidazioneModificheequalthis", IdDomandaPagamentoLiquidazioneModificheEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdModificaequalthis", IdModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaBeneficiariaequalthis", IdImpresaBeneficiariaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDecretoequalthis", IdDecretoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RichiestaMandatoImportoequalthis", RichiestaMandatoImportoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RichiestaMandatoSegnaturaequalthis", RichiestaMandatoSegnaturaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RichiestaMandatoDataequalthis", RichiestaMandatoDataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "MandatoNumeroequalthis", MandatoNumeroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "MandatoDataequalthis", MandatoDataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "MandatoImportoequalthis", MandatoImportoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "MandatoIdFileequalthis", MandatoIdFileEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "QuietanzaDataequalthis", QuietanzaDataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "QuietanzaImportoequalthis", QuietanzaImportoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Liquidatoequalthis", LiquidatoEqualThis);
			DomandaPagamentoLiquidazioneModifiche DomandaPagamentoLiquidazioneModificheObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				DomandaPagamentoLiquidazioneModificheObj = GetFromDatareader(db);
				DomandaPagamentoLiquidazioneModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DomandaPagamentoLiquidazioneModificheObj.IsDirty = false;
				DomandaPagamentoLiquidazioneModificheObj.IsPersistent = true;
				DomandaPagamentoLiquidazioneModificheCollectionObj.Add(DomandaPagamentoLiquidazioneModificheObj);
			}
			db.Close();
			return DomandaPagamentoLiquidazioneModificheCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for DomandaPagamentoLiquidazioneModificheCollectionProvider:IDomandaPagamentoLiquidazioneModificheProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class DomandaPagamentoLiquidazioneModificheCollectionProvider : IDomandaPagamentoLiquidazioneModificheProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di DomandaPagamentoLiquidazioneModifiche
		protected DomandaPagamentoLiquidazioneModificheCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public DomandaPagamentoLiquidazioneModificheCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new DomandaPagamentoLiquidazioneModificheCollection(this);
		}

		//Costruttore3: ha in input domandapagamentoliquidazionemodificheCollectionObj - non popola la collection
		public DomandaPagamentoLiquidazioneModificheCollectionProvider(DomandaPagamentoLiquidazioneModificheCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public DomandaPagamentoLiquidazioneModificheCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new DomandaPagamentoLiquidazioneModificheCollection(this);
		}

		//Get e Set
		public DomandaPagamentoLiquidazioneModificheCollection CollectionObj
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
		public int SaveCollection(DomandaPagamentoLiquidazioneModificheCollection collectionObj)
		{
			return DomandaPagamentoLiquidazioneModificheDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(DomandaPagamentoLiquidazioneModifiche domandapagamentoliquidazionemodificheObj)
		{
			return DomandaPagamentoLiquidazioneModificheDAL.Save(_dbProviderObj, domandapagamentoliquidazionemodificheObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(DomandaPagamentoLiquidazioneModificheCollection collectionObj)
		{
			return DomandaPagamentoLiquidazioneModificheDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(DomandaPagamentoLiquidazioneModifiche domandapagamentoliquidazionemodificheObj)
		{
			return DomandaPagamentoLiquidazioneModificheDAL.Delete(_dbProviderObj, domandapagamentoliquidazionemodificheObj);
		}

		//getById
		public DomandaPagamentoLiquidazioneModifiche GetById(IntNT IdDomandaPagamentoLiquidazioneModificheValue)
		{
			DomandaPagamentoLiquidazioneModifiche DomandaPagamentoLiquidazioneModificheTemp = DomandaPagamentoLiquidazioneModificheDAL.GetById(_dbProviderObj, IdDomandaPagamentoLiquidazioneModificheValue);
			if (DomandaPagamentoLiquidazioneModificheTemp!=null) DomandaPagamentoLiquidazioneModificheTemp.Provider = this;
			return DomandaPagamentoLiquidazioneModificheTemp;
		}

		//Select: popola la collection
		public DomandaPagamentoLiquidazioneModificheCollection Select(IntNT IddomandapagamentoliquidazionemodificheEqualThis, IntNT IdmodificaEqualThis, IntNT IdEqualThis, 
IntNT IddomandapagamentoEqualThis, IntNT IdprogettoEqualThis, IntNT IdimpresabeneficiariaEqualThis, 
IntNT IddecretoEqualThis, DecimalNT RichiestamandatoimportoEqualThis, StringNT RichiestamandatosegnaturaEqualThis, 
DatetimeNT RichiestamandatodataEqualThis, StringNT MandatonumeroEqualThis, DatetimeNT MandatodataEqualThis, 
DecimalNT MandatoimportoEqualThis, IntNT MandatoidfileEqualThis, DatetimeNT QuietanzadataEqualThis, 
DecimalNT QuietanzaimportoEqualThis, BoolNT LiquidatoEqualThis)
		{
			DomandaPagamentoLiquidazioneModificheCollection DomandaPagamentoLiquidazioneModificheCollectionTemp = DomandaPagamentoLiquidazioneModificheDAL.Select(_dbProviderObj, IddomandapagamentoliquidazionemodificheEqualThis, IdmodificaEqualThis, IdEqualThis, 
IddomandapagamentoEqualThis, IdprogettoEqualThis, IdimpresabeneficiariaEqualThis, 
IddecretoEqualThis, RichiestamandatoimportoEqualThis, RichiestamandatosegnaturaEqualThis, 
RichiestamandatodataEqualThis, MandatonumeroEqualThis, MandatodataEqualThis, 
MandatoimportoEqualThis, MandatoidfileEqualThis, QuietanzadataEqualThis, 
QuietanzaimportoEqualThis, LiquidatoEqualThis);
			DomandaPagamentoLiquidazioneModificheCollectionTemp.Provider = this;
			return DomandaPagamentoLiquidazioneModificheCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<DOMANDA_PAGAMENTO_LIQUIDAZIONE_MODIFICHE>
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
  <Finds />
  <Filters />
  <externalFields />
  <AddedFkFields />
</DOMANDA_PAGAMENTO_LIQUIDAZIONE_MODIFICHE>
*/
