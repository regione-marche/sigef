using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ErogazioneLiquidazioni
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IErogazioneLiquidazioniProvider
	{
		int Save(ErogazioneLiquidazioni ErogazioneLiquidazioniObj);
		int SaveCollection(ErogazioneLiquidazioniCollection collectionObj);
		int Delete(ErogazioneLiquidazioni ErogazioneLiquidazioniObj);
		int DeleteCollection(ErogazioneLiquidazioniCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ErogazioneLiquidazioni
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ErogazioneLiquidazioni: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdLiquidazione;
		private NullTypes.IntNT _OperatoreCreazione;
		private NullTypes.DatetimeNT _DataCreazione;
		private NullTypes.IntNT _OperatoreModifica;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.IntNT _IdErogazioneXDecreti;
		private NullTypes.IntNT _IdImpresaBeneficiaria;
		private NullTypes.StringNT _MandatoNumero;
		private NullTypes.DatetimeNT _MandatoData;
		private NullTypes.DecimalNT _MandatoImporto;
		private NullTypes.IntNT _MandatoIdFile;
		private NullTypes.DatetimeNT _QuietanzaData;
		private NullTypes.DecimalNT _QuietanzaImporto;
		private NullTypes.BoolNT _Liquidato;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdDomandaPagamento;
		private NullTypes.IntNT _Numero;
		private NullTypes.BoolNT _Anticipo;
		private NullTypes.DecimalNT _SogliaContributi;
		private NullTypes.IntNT _IdErogazione;
		private NullTypes.IntNT _IdDecreto;
		private NullTypes.DecimalNT _Importo;
		private NullTypes.DecimalNT _ImportoAmmesso;
		[NonSerialized] private IErogazioneLiquidazioniProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IErogazioneLiquidazioniProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ErogazioneLiquidazioni()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_LIQUIDAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdLiquidazione
		{
			get { return _IdLiquidazione; }
			set {
				if (IdLiquidazione != value)
				{
					_IdLiquidazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE_CREAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OperatoreCreazione
		{
			get { return _OperatoreCreazione; }
			set {
				if (OperatoreCreazione != value)
				{
					_OperatoreCreazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_CREAZIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataCreazione
		{
			get { return _DataCreazione; }
			set {
				if (DataCreazione != value)
				{
					_DataCreazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE_MODIFICA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OperatoreModifica
		{
			get { return _OperatoreModifica; }
			set {
				if (OperatoreModifica != value)
				{
					_OperatoreModifica = value;
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
		/// Corrisponde al campo:ID_EROGAZIONE_X_DECRETI
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdErogazioneXDecreti
		{
			get { return _IdErogazioneXDecreti; }
			set {
				if (IdErogazioneXDecreti != value)
				{
					_IdErogazioneXDecreti = value;
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
		/// Corrisponde al campo:MANDATO_NUMERO
		/// Tipo sul db:VARCHAR(100)
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
		/// Corrisponde al campo:NUMERO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Numero
		{
			get { return _Numero; }
			set {
				if (Numero != value)
				{
					_Numero = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ANTICIPO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Anticipo
		{
			get { return _Anticipo; }
			set {
				if (Anticipo != value)
				{
					_Anticipo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SOGLIA_CONTRIBUTI
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT SogliaContributi
		{
			get { return _SogliaContributi; }
			set {
				if (SogliaContributi != value)
				{
					_SogliaContributi = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_EROGAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdErogazione
		{
			get { return _IdErogazione; }
			set {
				if (IdErogazione != value)
				{
					_IdErogazione = value;
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
		/// Corrisponde al campo:IMPORTO
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT Importo
		{
			get { return _Importo; }
			set {
				if (Importo != value)
				{
					_Importo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_AMMESSO
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoAmmesso
		{
			get { return _ImportoAmmesso; }
			set {
				if (ImportoAmmesso != value)
				{
					_ImportoAmmesso = value;
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
	/// Summary description for ErogazioneLiquidazioniCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ErogazioneLiquidazioniCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ErogazioneLiquidazioniCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ErogazioneLiquidazioni) info.GetValue(i.ToString(),typeof(ErogazioneLiquidazioni)));
			}
		}

		//Costruttore
		public ErogazioneLiquidazioniCollection()
		{
			this.ItemType = typeof(ErogazioneLiquidazioni);
		}

		//Costruttore con provider
		public ErogazioneLiquidazioniCollection(IErogazioneLiquidazioniProvider providerObj)
		{
			this.ItemType = typeof(ErogazioneLiquidazioni);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ErogazioneLiquidazioni this[int index]
		{
			get { return (ErogazioneLiquidazioni)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ErogazioneLiquidazioniCollection GetChanges()
		{
			return (ErogazioneLiquidazioniCollection) base.GetChanges();
		}

		[NonSerialized] private IErogazioneLiquidazioniProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IErogazioneLiquidazioniProvider Provider
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
		public int Add(ErogazioneLiquidazioni ErogazioneLiquidazioniObj)
		{
			if (ErogazioneLiquidazioniObj.Provider == null) ErogazioneLiquidazioniObj.Provider = this.Provider;
			return base.Add(ErogazioneLiquidazioniObj);
		}

		//AddCollection
		public void AddCollection(ErogazioneLiquidazioniCollection ErogazioneLiquidazioniCollectionObj)
		{
			foreach (ErogazioneLiquidazioni ErogazioneLiquidazioniObj in ErogazioneLiquidazioniCollectionObj)
				this.Add(ErogazioneLiquidazioniObj);
		}

		//Insert
		public void Insert(int index, ErogazioneLiquidazioni ErogazioneLiquidazioniObj)
		{
			if (ErogazioneLiquidazioniObj.Provider == null) ErogazioneLiquidazioniObj.Provider = this.Provider;
			base.Insert(index, ErogazioneLiquidazioniObj);
		}

		//CollectionGetById
		public ErogazioneLiquidazioni CollectionGetById(NullTypes.IntNT IdLiquidazioneValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdLiquidazione == IdLiquidazioneValue))
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
		public ErogazioneLiquidazioniCollection SubSelect(NullTypes.IntNT IdLiquidazioneEqualThis, NullTypes.IntNT OperatoreCreazioneEqualThis, NullTypes.DatetimeNT DataCreazioneEqualThis, 
NullTypes.IntNT OperatoreModificaEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.IntNT IdErogazioneXDecretiEqualThis, 
NullTypes.IntNT IdImpresaBeneficiariaEqualThis, NullTypes.StringNT MandatoNumeroEqualThis, NullTypes.DatetimeNT MandatoDataEqualThis, 
NullTypes.DecimalNT MandatoImportoEqualThis, NullTypes.IntNT MandatoIdFileEqualThis, NullTypes.DatetimeNT QuietanzaDataEqualThis, 
NullTypes.DecimalNT QuietanzaImportoEqualThis, NullTypes.BoolNT LiquidatoEqualThis)
		{
			ErogazioneLiquidazioniCollection ErogazioneLiquidazioniCollectionTemp = new ErogazioneLiquidazioniCollection();
			foreach (ErogazioneLiquidazioni ErogazioneLiquidazioniItem in this)
			{
				if (((IdLiquidazioneEqualThis == null) || ((ErogazioneLiquidazioniItem.IdLiquidazione != null) && (ErogazioneLiquidazioniItem.IdLiquidazione.Value == IdLiquidazioneEqualThis.Value))) && ((OperatoreCreazioneEqualThis == null) || ((ErogazioneLiquidazioniItem.OperatoreCreazione != null) && (ErogazioneLiquidazioniItem.OperatoreCreazione.Value == OperatoreCreazioneEqualThis.Value))) && ((DataCreazioneEqualThis == null) || ((ErogazioneLiquidazioniItem.DataCreazione != null) && (ErogazioneLiquidazioniItem.DataCreazione.Value == DataCreazioneEqualThis.Value))) && 
((OperatoreModificaEqualThis == null) || ((ErogazioneLiquidazioniItem.OperatoreModifica != null) && (ErogazioneLiquidazioniItem.OperatoreModifica.Value == OperatoreModificaEqualThis.Value))) && ((DataModificaEqualThis == null) || ((ErogazioneLiquidazioniItem.DataModifica != null) && (ErogazioneLiquidazioniItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((IdErogazioneXDecretiEqualThis == null) || ((ErogazioneLiquidazioniItem.IdErogazioneXDecreti != null) && (ErogazioneLiquidazioniItem.IdErogazioneXDecreti.Value == IdErogazioneXDecretiEqualThis.Value))) && 
((IdImpresaBeneficiariaEqualThis == null) || ((ErogazioneLiquidazioniItem.IdImpresaBeneficiaria != null) && (ErogazioneLiquidazioniItem.IdImpresaBeneficiaria.Value == IdImpresaBeneficiariaEqualThis.Value))) && ((MandatoNumeroEqualThis == null) || ((ErogazioneLiquidazioniItem.MandatoNumero != null) && (ErogazioneLiquidazioniItem.MandatoNumero.Value == MandatoNumeroEqualThis.Value))) && ((MandatoDataEqualThis == null) || ((ErogazioneLiquidazioniItem.MandatoData != null) && (ErogazioneLiquidazioniItem.MandatoData.Value == MandatoDataEqualThis.Value))) && 
((MandatoImportoEqualThis == null) || ((ErogazioneLiquidazioniItem.MandatoImporto != null) && (ErogazioneLiquidazioniItem.MandatoImporto.Value == MandatoImportoEqualThis.Value))) && ((MandatoIdFileEqualThis == null) || ((ErogazioneLiquidazioniItem.MandatoIdFile != null) && (ErogazioneLiquidazioniItem.MandatoIdFile.Value == MandatoIdFileEqualThis.Value))) && ((QuietanzaDataEqualThis == null) || ((ErogazioneLiquidazioniItem.QuietanzaData != null) && (ErogazioneLiquidazioniItem.QuietanzaData.Value == QuietanzaDataEqualThis.Value))) && 
((QuietanzaImportoEqualThis == null) || ((ErogazioneLiquidazioniItem.QuietanzaImporto != null) && (ErogazioneLiquidazioniItem.QuietanzaImporto.Value == QuietanzaImportoEqualThis.Value))) && ((LiquidatoEqualThis == null) || ((ErogazioneLiquidazioniItem.Liquidato != null) && (ErogazioneLiquidazioniItem.Liquidato.Value == LiquidatoEqualThis.Value))))
				{
					ErogazioneLiquidazioniCollectionTemp.Add(ErogazioneLiquidazioniItem);
				}
			}
			return ErogazioneLiquidazioniCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ErogazioneLiquidazioniDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ErogazioneLiquidazioniDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ErogazioneLiquidazioni ErogazioneLiquidazioniObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdLiquidazione", ErogazioneLiquidazioniObj.IdLiquidazione);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreCreazione", ErogazioneLiquidazioniObj.OperatoreCreazione);
			DbProvider.SetCmdParam(cmd,firstChar + "DataCreazione", ErogazioneLiquidazioniObj.DataCreazione);
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreModifica", ErogazioneLiquidazioniObj.OperatoreModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", ErogazioneLiquidazioniObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "IdErogazioneXDecreti", ErogazioneLiquidazioniObj.IdErogazioneXDecreti);
			DbProvider.SetCmdParam(cmd,firstChar + "IdImpresaBeneficiaria", ErogazioneLiquidazioniObj.IdImpresaBeneficiaria);
			DbProvider.SetCmdParam(cmd,firstChar + "MandatoNumero", ErogazioneLiquidazioniObj.MandatoNumero);
			DbProvider.SetCmdParam(cmd,firstChar + "MandatoData", ErogazioneLiquidazioniObj.MandatoData);
			DbProvider.SetCmdParam(cmd,firstChar + "MandatoImporto", ErogazioneLiquidazioniObj.MandatoImporto);
			DbProvider.SetCmdParam(cmd,firstChar + "MandatoIdFile", ErogazioneLiquidazioniObj.MandatoIdFile);
			DbProvider.SetCmdParam(cmd,firstChar + "QuietanzaData", ErogazioneLiquidazioniObj.QuietanzaData);
			DbProvider.SetCmdParam(cmd,firstChar + "QuietanzaImporto", ErogazioneLiquidazioniObj.QuietanzaImporto);
			DbProvider.SetCmdParam(cmd,firstChar + "Liquidato", ErogazioneLiquidazioniObj.Liquidato);
		}
		//Insert
		private static int Insert(DbProvider db, ErogazioneLiquidazioni ErogazioneLiquidazioniObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZErogazioneLiquidazioniInsert", new string[] {"OperatoreCreazione", "DataCreazione", 
"OperatoreModifica", "DataModifica", "IdErogazioneXDecreti", 
"IdImpresaBeneficiaria", "MandatoNumero", "MandatoData", 
"MandatoImporto", "MandatoIdFile", "QuietanzaData", 
"QuietanzaImporto", "Liquidato", 

}, new string[] {"int", "DateTime", 
"int", "DateTime", "int", 
"int", "string", "DateTime", 
"decimal", "int", "DateTime", 
"decimal", "bool", 

},"");
				CompileIUCmd(false, insertCmd,ErogazioneLiquidazioniObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ErogazioneLiquidazioniObj.IdLiquidazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LIQUIDAZIONE"]);
				}
				ErogazioneLiquidazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ErogazioneLiquidazioniObj.IsDirty = false;
				ErogazioneLiquidazioniObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ErogazioneLiquidazioni ErogazioneLiquidazioniObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZErogazioneLiquidazioniUpdate", new string[] {"IdLiquidazione", "OperatoreCreazione", "DataCreazione", 
"OperatoreModifica", "DataModifica", "IdErogazioneXDecreti", 
"IdImpresaBeneficiaria", "MandatoNumero", "MandatoData", 
"MandatoImporto", "MandatoIdFile", "QuietanzaData", 
"QuietanzaImporto", "Liquidato", 

}, new string[] {"int", "int", "DateTime", 
"int", "DateTime", "int", 
"int", "string", "DateTime", 
"decimal", "int", "DateTime", 
"decimal", "bool", 

},"");
				CompileIUCmd(true, updateCmd,ErogazioneLiquidazioniObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					ErogazioneLiquidazioniObj.DataModifica = d;
				}
				ErogazioneLiquidazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ErogazioneLiquidazioniObj.IsDirty = false;
				ErogazioneLiquidazioniObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ErogazioneLiquidazioni ErogazioneLiquidazioniObj)
		{
			switch (ErogazioneLiquidazioniObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ErogazioneLiquidazioniObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ErogazioneLiquidazioniObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ErogazioneLiquidazioniObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ErogazioneLiquidazioniCollection ErogazioneLiquidazioniCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZErogazioneLiquidazioniUpdate", new string[] {"IdLiquidazione", "OperatoreCreazione", "DataCreazione", 
"OperatoreModifica", "DataModifica", "IdErogazioneXDecreti", 
"IdImpresaBeneficiaria", "MandatoNumero", "MandatoData", 
"MandatoImporto", "MandatoIdFile", "QuietanzaData", 
"QuietanzaImporto", "Liquidato", 

}, new string[] {"int", "int", "DateTime", 
"int", "DateTime", "int", 
"int", "string", "DateTime", 
"decimal", "int", "DateTime", 
"decimal", "bool", 

},"");
				IDbCommand insertCmd = db.InitCmd( "ZErogazioneLiquidazioniInsert", new string[] {"OperatoreCreazione", "DataCreazione", 
"OperatoreModifica", "DataModifica", "IdErogazioneXDecreti", 
"IdImpresaBeneficiaria", "MandatoNumero", "MandatoData", 
"MandatoImporto", "MandatoIdFile", "QuietanzaData", 
"QuietanzaImporto", "Liquidato", 

}, new string[] {"int", "DateTime", 
"int", "DateTime", "int", 
"int", "string", "DateTime", 
"decimal", "int", "DateTime", 
"decimal", "bool", 

},"");
				IDbCommand deleteCmd = db.InitCmd( "ZErogazioneLiquidazioniDelete", new string[] {"IdLiquidazione"}, new string[] {"int"},"");
				for (int i = 0; i < ErogazioneLiquidazioniCollectionObj.Count; i++)
				{
					switch (ErogazioneLiquidazioniCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ErogazioneLiquidazioniCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ErogazioneLiquidazioniCollectionObj[i].IdLiquidazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LIQUIDAZIONE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ErogazioneLiquidazioniCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									ErogazioneLiquidazioniCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ErogazioneLiquidazioniCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdLiquidazione", (SiarLibrary.NullTypes.IntNT)ErogazioneLiquidazioniCollectionObj[i].IdLiquidazione);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ErogazioneLiquidazioniCollectionObj.Count; i++)
				{
					if ((ErogazioneLiquidazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ErogazioneLiquidazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ErogazioneLiquidazioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ErogazioneLiquidazioniCollectionObj[i].IsDirty = false;
						ErogazioneLiquidazioniCollectionObj[i].IsPersistent = true;
					}
					if ((ErogazioneLiquidazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ErogazioneLiquidazioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ErogazioneLiquidazioniCollectionObj[i].IsDirty = false;
						ErogazioneLiquidazioniCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ErogazioneLiquidazioni ErogazioneLiquidazioniObj)
		{
			int returnValue = 0;
			if (ErogazioneLiquidazioniObj.IsPersistent) 
			{
				returnValue = Delete(db, ErogazioneLiquidazioniObj.IdLiquidazione);
			}
			ErogazioneLiquidazioniObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ErogazioneLiquidazioniObj.IsDirty = false;
			ErogazioneLiquidazioniObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdLiquidazioneValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZErogazioneLiquidazioniDelete", new string[] {"IdLiquidazione"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdLiquidazione", (SiarLibrary.NullTypes.IntNT)IdLiquidazioneValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ErogazioneLiquidazioniCollection ErogazioneLiquidazioniCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZErogazioneLiquidazioniDelete", new string[] {"IdLiquidazione"}, new string[] {"int"},"");
				for (int i = 0; i < ErogazioneLiquidazioniCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdLiquidazione", ErogazioneLiquidazioniCollectionObj[i].IdLiquidazione);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ErogazioneLiquidazioniCollectionObj.Count; i++)
				{
					if ((ErogazioneLiquidazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ErogazioneLiquidazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ErogazioneLiquidazioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ErogazioneLiquidazioniCollectionObj[i].IsDirty = false;
						ErogazioneLiquidazioniCollectionObj[i].IsPersistent = false;
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
		public static ErogazioneLiquidazioni GetById(DbProvider db, int IdLiquidazioneValue)
		{
			ErogazioneLiquidazioni ErogazioneLiquidazioniObj = null;
			IDbCommand readCmd = db.InitCmd( "ZErogazioneLiquidazioniGetById", new string[] {"IdLiquidazione"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdLiquidazione", (SiarLibrary.NullTypes.IntNT)IdLiquidazioneValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ErogazioneLiquidazioniObj = GetFromDatareader(db);
				ErogazioneLiquidazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ErogazioneLiquidazioniObj.IsDirty = false;
				ErogazioneLiquidazioniObj.IsPersistent = true;
			}
			db.Close();
			return ErogazioneLiquidazioniObj;
		}

		//getFromDatareader
		public static ErogazioneLiquidazioni GetFromDatareader(DbProvider db)
		{
			ErogazioneLiquidazioni ErogazioneLiquidazioniObj = new ErogazioneLiquidazioni();
			ErogazioneLiquidazioniObj.IdLiquidazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LIQUIDAZIONE"]);
			ErogazioneLiquidazioniObj.OperatoreCreazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_CREAZIONE"]);
			ErogazioneLiquidazioniObj.DataCreazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CREAZIONE"]);
			ErogazioneLiquidazioniObj.OperatoreModifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_MODIFICA"]);
			ErogazioneLiquidazioniObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			ErogazioneLiquidazioniObj.IdErogazioneXDecreti = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_EROGAZIONE_X_DECRETI"]);
			ErogazioneLiquidazioniObj.IdImpresaBeneficiaria = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA_BENEFICIARIA"]);
			ErogazioneLiquidazioniObj.MandatoNumero = new SiarLibrary.NullTypes.StringNT(db.DataReader["MANDATO_NUMERO"]);
			ErogazioneLiquidazioniObj.MandatoData = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["MANDATO_DATA"]);
			ErogazioneLiquidazioniObj.MandatoImporto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["MANDATO_IMPORTO"]);
			ErogazioneLiquidazioniObj.MandatoIdFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["MANDATO_ID_FILE"]);
			ErogazioneLiquidazioniObj.QuietanzaData = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["QUIETANZA_DATA"]);
			ErogazioneLiquidazioniObj.QuietanzaImporto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUIETANZA_IMPORTO"]);
			ErogazioneLiquidazioniObj.Liquidato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["LIQUIDATO"]);
			ErogazioneLiquidazioniObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			ErogazioneLiquidazioniObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
			ErogazioneLiquidazioniObj.Numero = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMERO"]);
			ErogazioneLiquidazioniObj.Anticipo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ANTICIPO"]);
			ErogazioneLiquidazioniObj.SogliaContributi = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SOGLIA_CONTRIBUTI"]);
			ErogazioneLiquidazioniObj.IdErogazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_EROGAZIONE"]);
			ErogazioneLiquidazioniObj.IdDecreto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DECRETO"]);
			ErogazioneLiquidazioniObj.Importo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO"]);
			ErogazioneLiquidazioniObj.ImportoAmmesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_AMMESSO"]);
			ErogazioneLiquidazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ErogazioneLiquidazioniObj.IsDirty = false;
			ErogazioneLiquidazioniObj.IsPersistent = true;
			return ErogazioneLiquidazioniObj;
		}

		//Find Select

		public static ErogazioneLiquidazioniCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdLiquidazioneEqualThis, SiarLibrary.NullTypes.IntNT OperatoreCreazioneEqualThis, SiarLibrary.NullTypes.DatetimeNT DataCreazioneEqualThis, 
SiarLibrary.NullTypes.IntNT OperatoreModificaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.IntNT IdErogazioneXDecretiEqualThis, 
SiarLibrary.NullTypes.IntNT IdImpresaBeneficiariaEqualThis, SiarLibrary.NullTypes.StringNT MandatoNumeroEqualThis, SiarLibrary.NullTypes.DatetimeNT MandatoDataEqualThis, 
SiarLibrary.NullTypes.DecimalNT MandatoImportoEqualThis, SiarLibrary.NullTypes.IntNT MandatoIdFileEqualThis, SiarLibrary.NullTypes.DatetimeNT QuietanzaDataEqualThis, 
SiarLibrary.NullTypes.DecimalNT QuietanzaImportoEqualThis, SiarLibrary.NullTypes.BoolNT LiquidatoEqualThis)

		{

			ErogazioneLiquidazioniCollection ErogazioneLiquidazioniCollectionObj = new ErogazioneLiquidazioniCollection();

			IDbCommand findCmd = db.InitCmd("Zerogazioneliquidazionifindselect", new string[] {"IdLiquidazioneequalthis", "OperatoreCreazioneequalthis", "DataCreazioneequalthis", 
"OperatoreModificaequalthis", "DataModificaequalthis", "IdErogazioneXDecretiequalthis", 
"IdImpresaBeneficiariaequalthis", "MandatoNumeroequalthis", "MandatoDataequalthis", 
"MandatoImportoequalthis", "MandatoIdFileequalthis", "QuietanzaDataequalthis", 
"QuietanzaImportoequalthis", "Liquidatoequalthis"}, new string[] {"int", "int", "DateTime", 
"int", "DateTime", "int", 
"int", "string", "DateTime", 
"decimal", "int", "DateTime", 
"decimal", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdLiquidazioneequalthis", IdLiquidazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreCreazioneequalthis", OperatoreCreazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataCreazioneequalthis", DataCreazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreModificaequalthis", OperatoreModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdErogazioneXDecretiequalthis", IdErogazioneXDecretiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaBeneficiariaequalthis", IdImpresaBeneficiariaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "MandatoNumeroequalthis", MandatoNumeroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "MandatoDataequalthis", MandatoDataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "MandatoImportoequalthis", MandatoImportoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "MandatoIdFileequalthis", MandatoIdFileEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "QuietanzaDataequalthis", QuietanzaDataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "QuietanzaImportoequalthis", QuietanzaImportoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Liquidatoequalthis", LiquidatoEqualThis);
			ErogazioneLiquidazioni ErogazioneLiquidazioniObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ErogazioneLiquidazioniObj = GetFromDatareader(db);
				ErogazioneLiquidazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ErogazioneLiquidazioniObj.IsDirty = false;
				ErogazioneLiquidazioniObj.IsPersistent = true;
				ErogazioneLiquidazioniCollectionObj.Add(ErogazioneLiquidazioniObj);
			}
			db.Close();
			return ErogazioneLiquidazioniCollectionObj;
		}

		//Find FindLiquidazione

		public static ErogazioneLiquidazioniCollection FindLiquidazione(DbProvider db, SiarLibrary.NullTypes.IntNT IdLiquidazioneEqualThis, SiarLibrary.NullTypes.IntNT IdErogazioneXDecretiEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, 
SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdErogazioneEqualThis, SiarLibrary.NullTypes.IntNT IdDecretoEqualThis)

		{

			ErogazioneLiquidazioniCollection ErogazioneLiquidazioniCollectionObj = new ErogazioneLiquidazioniCollection();

			IDbCommand findCmd = db.InitCmd("Zerogazioneliquidazionifindfindliquidazione", new string[] {"IdLiquidazioneequalthis", "IdErogazioneXDecretiequalthis", "IdProgettoequalthis", 
"IdDomandaPagamentoequalthis", "IdErogazioneequalthis", "IdDecretoequalthis"}, new string[] {"int", "int", "int", 
"int", "int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdLiquidazioneequalthis", IdLiquidazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdErogazioneXDecretiequalthis", IdErogazioneXDecretiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdErogazioneequalthis", IdErogazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDecretoequalthis", IdDecretoEqualThis);
			ErogazioneLiquidazioni ErogazioneLiquidazioniObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ErogazioneLiquidazioniObj = GetFromDatareader(db);
				ErogazioneLiquidazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ErogazioneLiquidazioniObj.IsDirty = false;
				ErogazioneLiquidazioniObj.IsPersistent = true;
				ErogazioneLiquidazioniCollectionObj.Add(ErogazioneLiquidazioniObj);
			}
			db.Close();
			return ErogazioneLiquidazioniCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ErogazioneLiquidazioniCollectionProvider:IErogazioneLiquidazioniProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ErogazioneLiquidazioniCollectionProvider : IErogazioneLiquidazioniProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ErogazioneLiquidazioni
		protected ErogazioneLiquidazioniCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ErogazioneLiquidazioniCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ErogazioneLiquidazioniCollection(this);
		}

		//Costruttore 2: popola la collection
		public ErogazioneLiquidazioniCollectionProvider(IntNT IdliquidazioneEqualThis, IntNT IderogazionexdecretiEqualThis, IntNT IdprogettoEqualThis, 
IntNT IddomandapagamentoEqualThis, IntNT IderogazioneEqualThis, IntNT IddecretoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = FindLiquidazione(IdliquidazioneEqualThis, IderogazionexdecretiEqualThis, IdprogettoEqualThis, 
IddomandapagamentoEqualThis, IderogazioneEqualThis, IddecretoEqualThis);
		}

		//Costruttore3: ha in input erogazioneliquidazioniCollectionObj - non popola la collection
		public ErogazioneLiquidazioniCollectionProvider(ErogazioneLiquidazioniCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ErogazioneLiquidazioniCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ErogazioneLiquidazioniCollection(this);
		}

		//Get e Set
		public ErogazioneLiquidazioniCollection CollectionObj
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
		public int SaveCollection(ErogazioneLiquidazioniCollection collectionObj)
		{
			return ErogazioneLiquidazioniDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ErogazioneLiquidazioni erogazioneliquidazioniObj)
		{
			return ErogazioneLiquidazioniDAL.Save(_dbProviderObj, erogazioneliquidazioniObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ErogazioneLiquidazioniCollection collectionObj)
		{
			return ErogazioneLiquidazioniDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ErogazioneLiquidazioni erogazioneliquidazioniObj)
		{
			return ErogazioneLiquidazioniDAL.Delete(_dbProviderObj, erogazioneliquidazioniObj);
		}

		//getById
		public ErogazioneLiquidazioni GetById(IntNT IdLiquidazioneValue)
		{
			ErogazioneLiquidazioni ErogazioneLiquidazioniTemp = ErogazioneLiquidazioniDAL.GetById(_dbProviderObj, IdLiquidazioneValue);
			if (ErogazioneLiquidazioniTemp!=null) ErogazioneLiquidazioniTemp.Provider = this;
			return ErogazioneLiquidazioniTemp;
		}

		//Select: popola la collection
		public ErogazioneLiquidazioniCollection Select(IntNT IdliquidazioneEqualThis, IntNT OperatorecreazioneEqualThis, DatetimeNT DatacreazioneEqualThis, 
IntNT OperatoremodificaEqualThis, DatetimeNT DatamodificaEqualThis, IntNT IderogazionexdecretiEqualThis, 
IntNT IdimpresabeneficiariaEqualThis, StringNT MandatonumeroEqualThis, DatetimeNT MandatodataEqualThis, 
DecimalNT MandatoimportoEqualThis, IntNT MandatoidfileEqualThis, DatetimeNT QuietanzadataEqualThis, 
DecimalNT QuietanzaimportoEqualThis, BoolNT LiquidatoEqualThis)
		{
			ErogazioneLiquidazioniCollection ErogazioneLiquidazioniCollectionTemp = ErogazioneLiquidazioniDAL.Select(_dbProviderObj, IdliquidazioneEqualThis, OperatorecreazioneEqualThis, DatacreazioneEqualThis, 
OperatoremodificaEqualThis, DatamodificaEqualThis, IderogazionexdecretiEqualThis, 
IdimpresabeneficiariaEqualThis, MandatonumeroEqualThis, MandatodataEqualThis, 
MandatoimportoEqualThis, MandatoidfileEqualThis, QuietanzadataEqualThis, 
QuietanzaimportoEqualThis, LiquidatoEqualThis);
			ErogazioneLiquidazioniCollectionTemp.Provider = this;
			return ErogazioneLiquidazioniCollectionTemp;
		}

		//FindLiquidazione: popola la collection
		public ErogazioneLiquidazioniCollection FindLiquidazione(IntNT IdliquidazioneEqualThis, IntNT IderogazionexdecretiEqualThis, IntNT IdprogettoEqualThis, 
IntNT IddomandapagamentoEqualThis, IntNT IderogazioneEqualThis, IntNT IddecretoEqualThis)
		{
			ErogazioneLiquidazioniCollection ErogazioneLiquidazioniCollectionTemp = ErogazioneLiquidazioniDAL.FindLiquidazione(_dbProviderObj, IdliquidazioneEqualThis, IderogazionexdecretiEqualThis, IdprogettoEqualThis, 
IddomandapagamentoEqualThis, IderogazioneEqualThis, IddecretoEqualThis);
			ErogazioneLiquidazioniCollectionTemp.Provider = this;
			return ErogazioneLiquidazioniCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<EROGAZIONE_LIQUIDAZIONI>
  <ViewName>VEROGAZIONE_LIQUIDAZIONI</ViewName>
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
    <FindLiquidazione OrderBy="ORDER BY ">
      <ID_LIQUIDAZIONE>Equal</ID_LIQUIDAZIONE>
      <ID_EROGAZIONE_X_DECRETI>Equal</ID_EROGAZIONE_X_DECRETI>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_EROGAZIONE>Equal</ID_EROGAZIONE>
      <ID_DECRETO>Equal</ID_DECRETO>
    </FindLiquidazione>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</EROGAZIONE_LIQUIDAZIONI>
*/
