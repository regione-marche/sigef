using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per LocalizzazioneProgettoStorico
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ILocalizzazioneProgettoStoricoProvider
	{
		int Save(LocalizzazioneProgettoStorico LocalizzazioneProgettoStoricoObj);
		int SaveCollection(LocalizzazioneProgettoStoricoCollection collectionObj);
		int Delete(LocalizzazioneProgettoStorico LocalizzazioneProgettoStoricoObj);
		int DeleteCollection(LocalizzazioneProgettoStoricoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for LocalizzazioneProgettoStorico
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class LocalizzazioneProgettoStorico : BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdLocalizzazioneStorico;
		private NullTypes.IntNT _IdLocalizzazione;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.IntNT _IdComune;
		private NullTypes.StringNT _Cap;
		private NullTypes.IntNT _Dug;
		private NullTypes.StringNT _Via;
		private NullTypes.StringNT _Num;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.IntNT _OperatoreModifica;
		private NullTypes.IntNT _IdVariante;
		private NullTypes.IntNT _CatastoId;
		private NullTypes.StringNT _CatastoFoglio;
		private NullTypes.StringNT _CatastoParticella;
		private NullTypes.StringNT _CatastoSezione;
		private NullTypes.StringNT _CatastoSubalterno;
		private NullTypes.IntNT _CatastoSuperficie;
		private NullTypes.DecimalNT _Quota;
		private NullTypes.StringNT _DugDescrizione;
		private NullTypes.StringNT _ComuneBelfiore;
		private NullTypes.StringNT _ComuneDenominazione;
		private NullTypes.StringNT _ComuneProvCode;
		private NullTypes.StringNT _ComuneProvSigla;
		private NullTypes.StringNT _ComuneIstat;
		[NonSerialized] private ILocalizzazioneProgettoStoricoProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public ILocalizzazioneProgettoStoricoProvider Provider
		{
			get { return _provider; }
			set { _provider = value; }
		}


		//Costruttore
		public LocalizzazioneProgettoStorico()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_LOCALIZZAZIONE_STORICO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdLocalizzazioneStorico
		{
			get { return _IdLocalizzazioneStorico; }
			set
			{
				if (IdLocalizzazioneStorico != value)
				{
					_IdLocalizzazioneStorico = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_LOCALIZZAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdLocalizzazione
		{
			get { return _IdLocalizzazione; }
			set
			{
				if (IdLocalizzazione != value)
				{
					_IdLocalizzazione = value;
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
		/// Corrisponde al campo:ID_COMUNE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdComune
		{
			get { return _IdComune; }
			set
			{
				if (IdComune != value)
				{
					_IdComune = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CAP
		/// Tipo sul db:CHAR(5)
		/// </summary>
		public NullTypes.StringNT Cap
		{
			get { return _Cap; }
			set
			{
				if (Cap != value)
				{
					_Cap = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DUG
		/// Tipo sul db:SMALLINT
		/// </summary>
		public NullTypes.IntNT Dug
		{
			get { return _Dug; }
			set
			{
				if (Dug != value)
				{
					_Dug = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VIA
		/// Tipo sul db:VARCHAR(200)
		/// </summary>
		public NullTypes.StringNT Via
		{
			get { return _Via; }
			set
			{
				if (Via != value)
				{
					_Via = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NUM
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT Num
		{
			get { return _Num; }
			set
			{
				if (Num != value)
				{
					_Num = value;
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
			set
			{
				if (DataModifica != value)
				{
					_DataModifica = value;
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
			set
			{
				if (OperatoreModifica != value)
				{
					_OperatoreModifica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_VARIANTE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdVariante
		{
			get { return _IdVariante; }
			set
			{
				if (IdVariante != value)
				{
					_IdVariante = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CATASTO_ID
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT CatastoId
		{
			get { return _CatastoId; }
			set
			{
				if (CatastoId != value)
				{
					_CatastoId = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CATASTO_FOGLIO
		/// Tipo sul db:VARCHAR(6)
		/// </summary>
		public NullTypes.StringNT CatastoFoglio
		{
			get { return _CatastoFoglio; }
			set
			{
				if (CatastoFoglio != value)
				{
					_CatastoFoglio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CATASTO_PARTICELLA
		/// Tipo sul db:VARCHAR(6)
		/// </summary>
		public NullTypes.StringNT CatastoParticella
		{
			get { return _CatastoParticella; }
			set
			{
				if (CatastoParticella != value)
				{
					_CatastoParticella = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CATASTO_SEZIONE
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT CatastoSezione
		{
			get { return _CatastoSezione; }
			set
			{
				if (CatastoSezione != value)
				{
					_CatastoSezione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CATASTO_SUBALTERNO
		/// Tipo sul db:VARCHAR(3)
		/// </summary>
		public NullTypes.StringNT CatastoSubalterno
		{
			get { return _CatastoSubalterno; }
			set
			{
				if (CatastoSubalterno != value)
				{
					_CatastoSubalterno = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CATASTO_SUPERFICIE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT CatastoSuperficie
		{
			get { return _CatastoSuperficie; }
			set
			{
				if (CatastoSuperficie != value)
				{
					_CatastoSuperficie = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUOTA
		/// Tipo sul db:DECIMAL(5,2)
		/// Default:((100.00))
		/// </summary>
		public NullTypes.DecimalNT Quota
		{
			get { return _Quota; }
			set
			{
				if (Quota != value)
				{
					_Quota = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DUG_DESCRIZIONE
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT DugDescrizione
		{
			get { return _DugDescrizione; }
			set
			{
				if (DugDescrizione != value)
				{
					_DugDescrizione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COMUNE_BELFIORE
		/// Tipo sul db:CHAR(4)
		/// </summary>
		public NullTypes.StringNT ComuneBelfiore
		{
			get { return _ComuneBelfiore; }
			set
			{
				if (ComuneBelfiore != value)
				{
					_ComuneBelfiore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COMUNE_DENOMINAZIONE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT ComuneDenominazione
		{
			get { return _ComuneDenominazione; }
			set
			{
				if (ComuneDenominazione != value)
				{
					_ComuneDenominazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COMUNE_PROV_CODE
		/// Tipo sul db:CHAR(3)
		/// </summary>
		public NullTypes.StringNT ComuneProvCode
		{
			get { return _ComuneProvCode; }
			set
			{
				if (ComuneProvCode != value)
				{
					_ComuneProvCode = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COMUNE_PROV_SIGLA
		/// Tipo sul db:CHAR(2)
		/// </summary>
		public NullTypes.StringNT ComuneProvSigla
		{
			get { return _ComuneProvSigla; }
			set
			{
				if (ComuneProvSigla != value)
				{
					_ComuneProvSigla = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COMUNE_ISTAT
		/// Tipo sul db:CHAR(3)
		/// </summary>
		public NullTypes.StringNT ComuneIstat
		{
			get { return _ComuneIstat; }
			set
			{
				if (ComuneIstat != value)
				{
					_ComuneIstat = value;
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
	/// Summary description for LocalizzazioneProgettoStoricoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class LocalizzazioneProgettoStoricoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private LocalizzazioneProgettoStoricoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
		{
			int c = info.GetInt32("_count");
			for (int i = 0; i < c; i++)
			{
				this.Add((LocalizzazioneProgettoStorico)info.GetValue(i.ToString(), typeof(LocalizzazioneProgettoStorico)));
			}
		}

		//Costruttore
		public LocalizzazioneProgettoStoricoCollection()
		{
			this.ItemType = typeof(LocalizzazioneProgettoStorico);
		}

		//Costruttore con provider
		public LocalizzazioneProgettoStoricoCollection(ILocalizzazioneProgettoStoricoProvider providerObj)
		{
			this.ItemType = typeof(LocalizzazioneProgettoStorico);
			this.Provider = providerObj;
		}

		//Get e Set
		public new LocalizzazioneProgettoStorico this[int index]
		{
			get { return (LocalizzazioneProgettoStorico)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new LocalizzazioneProgettoStoricoCollection GetChanges()
		{
			return (LocalizzazioneProgettoStoricoCollection)base.GetChanges();
		}

		[NonSerialized] private ILocalizzazioneProgettoStoricoProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public ILocalizzazioneProgettoStoricoProvider Provider
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
		public int Add(LocalizzazioneProgettoStorico LocalizzazioneProgettoStoricoObj)
		{
			if (LocalizzazioneProgettoStoricoObj.Provider == null) LocalizzazioneProgettoStoricoObj.Provider = this.Provider;
			return base.Add(LocalizzazioneProgettoStoricoObj);
		}

		//AddCollection
		public void AddCollection(LocalizzazioneProgettoStoricoCollection LocalizzazioneProgettoStoricoCollectionObj)
		{
			foreach (LocalizzazioneProgettoStorico LocalizzazioneProgettoStoricoObj in LocalizzazioneProgettoStoricoCollectionObj)
				this.Add(LocalizzazioneProgettoStoricoObj);
		}

		//Insert
		public void Insert(int index, LocalizzazioneProgettoStorico LocalizzazioneProgettoStoricoObj)
		{
			if (LocalizzazioneProgettoStoricoObj.Provider == null) LocalizzazioneProgettoStoricoObj.Provider = this.Provider;
			base.Insert(index, LocalizzazioneProgettoStoricoObj);
		}

		//CollectionGetById
		public LocalizzazioneProgettoStorico CollectionGetById(NullTypes.IntNT IdLocalizzazioneStoricoValue)
		{
			int i = 0;
			bool find = false;
			while ((i < this.Count) && (!find))
			{
				if ((this[i].IdLocalizzazioneStorico == IdLocalizzazioneStoricoValue))
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
		public LocalizzazioneProgettoStoricoCollection SubSelect(NullTypes.IntNT IdLocalizzazioneStoricoEqualThis, NullTypes.IntNT IdLocalizzazioneEqualThis, NullTypes.IntNT IdProgettoEqualThis,
NullTypes.IntNT IdImpresaEqualThis, NullTypes.IntNT IdComuneEqualThis, NullTypes.StringNT CapEqualThis,
NullTypes.IntNT DugEqualThis, NullTypes.StringNT ViaEqualThis, NullTypes.StringNT NumEqualThis,
NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.IntNT OperatoreModificaEqualThis, NullTypes.IntNT IdVarianteEqualThis,
NullTypes.IntNT CatastoIdEqualThis, NullTypes.StringNT CatastoFoglioEqualThis, NullTypes.StringNT CatastoParticellaEqualThis,
NullTypes.StringNT CatastoSezioneEqualThis, NullTypes.StringNT CatastoSubalternoEqualThis, NullTypes.IntNT CatastoSuperficieEqualThis,
NullTypes.DecimalNT QuotaEqualThis)
		{
			LocalizzazioneProgettoStoricoCollection LocalizzazioneProgettoStoricoCollectionTemp = new LocalizzazioneProgettoStoricoCollection();
			foreach (LocalizzazioneProgettoStorico LocalizzazioneProgettoStoricoItem in this)
			{
				if (((IdLocalizzazioneStoricoEqualThis == null) || ((LocalizzazioneProgettoStoricoItem.IdLocalizzazioneStorico != null) && (LocalizzazioneProgettoStoricoItem.IdLocalizzazioneStorico.Value == IdLocalizzazioneStoricoEqualThis.Value))) && ((IdLocalizzazioneEqualThis == null) || ((LocalizzazioneProgettoStoricoItem.IdLocalizzazione != null) && (LocalizzazioneProgettoStoricoItem.IdLocalizzazione.Value == IdLocalizzazioneEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((LocalizzazioneProgettoStoricoItem.IdProgetto != null) && (LocalizzazioneProgettoStoricoItem.IdProgetto.Value == IdProgettoEqualThis.Value))) &&
((IdImpresaEqualThis == null) || ((LocalizzazioneProgettoStoricoItem.IdImpresa != null) && (LocalizzazioneProgettoStoricoItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((IdComuneEqualThis == null) || ((LocalizzazioneProgettoStoricoItem.IdComune != null) && (LocalizzazioneProgettoStoricoItem.IdComune.Value == IdComuneEqualThis.Value))) && ((CapEqualThis == null) || ((LocalizzazioneProgettoStoricoItem.Cap != null) && (LocalizzazioneProgettoStoricoItem.Cap.Value == CapEqualThis.Value))) &&
((DugEqualThis == null) || ((LocalizzazioneProgettoStoricoItem.Dug != null) && (LocalizzazioneProgettoStoricoItem.Dug.Value == DugEqualThis.Value))) && ((ViaEqualThis == null) || ((LocalizzazioneProgettoStoricoItem.Via != null) && (LocalizzazioneProgettoStoricoItem.Via.Value == ViaEqualThis.Value))) && ((NumEqualThis == null) || ((LocalizzazioneProgettoStoricoItem.Num != null) && (LocalizzazioneProgettoStoricoItem.Num.Value == NumEqualThis.Value))) &&
((DataModificaEqualThis == null) || ((LocalizzazioneProgettoStoricoItem.DataModifica != null) && (LocalizzazioneProgettoStoricoItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((OperatoreModificaEqualThis == null) || ((LocalizzazioneProgettoStoricoItem.OperatoreModifica != null) && (LocalizzazioneProgettoStoricoItem.OperatoreModifica.Value == OperatoreModificaEqualThis.Value))) && ((IdVarianteEqualThis == null) || ((LocalizzazioneProgettoStoricoItem.IdVariante != null) && (LocalizzazioneProgettoStoricoItem.IdVariante.Value == IdVarianteEqualThis.Value))) &&
((CatastoIdEqualThis == null) || ((LocalizzazioneProgettoStoricoItem.CatastoId != null) && (LocalizzazioneProgettoStoricoItem.CatastoId.Value == CatastoIdEqualThis.Value))) && ((CatastoFoglioEqualThis == null) || ((LocalizzazioneProgettoStoricoItem.CatastoFoglio != null) && (LocalizzazioneProgettoStoricoItem.CatastoFoglio.Value == CatastoFoglioEqualThis.Value))) && ((CatastoParticellaEqualThis == null) || ((LocalizzazioneProgettoStoricoItem.CatastoParticella != null) && (LocalizzazioneProgettoStoricoItem.CatastoParticella.Value == CatastoParticellaEqualThis.Value))) &&
((CatastoSezioneEqualThis == null) || ((LocalizzazioneProgettoStoricoItem.CatastoSezione != null) && (LocalizzazioneProgettoStoricoItem.CatastoSezione.Value == CatastoSezioneEqualThis.Value))) && ((CatastoSubalternoEqualThis == null) || ((LocalizzazioneProgettoStoricoItem.CatastoSubalterno != null) && (LocalizzazioneProgettoStoricoItem.CatastoSubalterno.Value == CatastoSubalternoEqualThis.Value))) && ((CatastoSuperficieEqualThis == null) || ((LocalizzazioneProgettoStoricoItem.CatastoSuperficie != null) && (LocalizzazioneProgettoStoricoItem.CatastoSuperficie.Value == CatastoSuperficieEqualThis.Value))) &&
((QuotaEqualThis == null) || ((LocalizzazioneProgettoStoricoItem.Quota != null) && (LocalizzazioneProgettoStoricoItem.Quota.Value == QuotaEqualThis.Value))))
				{
					LocalizzazioneProgettoStoricoCollectionTemp.Add(LocalizzazioneProgettoStoricoItem);
				}
			}
			return LocalizzazioneProgettoStoricoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for LocalizzazioneProgettoStoricoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class LocalizzazioneProgettoStoricoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, LocalizzazioneProgettoStorico LocalizzazioneProgettoStoricoObj, string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd, firstChar + "IdLocalizzazioneStorico", LocalizzazioneProgettoStoricoObj.IdLocalizzazioneStorico);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd, firstChar + "IdLocalizzazione", LocalizzazioneProgettoStoricoObj.IdLocalizzazione);
			DbProvider.SetCmdParam(cmd, firstChar + "IdProgetto", LocalizzazioneProgettoStoricoObj.IdProgetto);
			DbProvider.SetCmdParam(cmd, firstChar + "IdImpresa", LocalizzazioneProgettoStoricoObj.IdImpresa);
			DbProvider.SetCmdParam(cmd, firstChar + "IdComune", LocalizzazioneProgettoStoricoObj.IdComune);
			DbProvider.SetCmdParam(cmd, firstChar + "Cap", LocalizzazioneProgettoStoricoObj.Cap);
			DbProvider.SetCmdParam(cmd, firstChar + "Dug", LocalizzazioneProgettoStoricoObj.Dug);
			DbProvider.SetCmdParam(cmd, firstChar + "Via", LocalizzazioneProgettoStoricoObj.Via);
			DbProvider.SetCmdParam(cmd, firstChar + "Num", LocalizzazioneProgettoStoricoObj.Num);
			DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", LocalizzazioneProgettoStoricoObj.DataModifica);
			DbProvider.SetCmdParam(cmd, firstChar + "OperatoreModifica", LocalizzazioneProgettoStoricoObj.OperatoreModifica);
			DbProvider.SetCmdParam(cmd, firstChar + "IdVariante", LocalizzazioneProgettoStoricoObj.IdVariante);
			DbProvider.SetCmdParam(cmd, firstChar + "CatastoId", LocalizzazioneProgettoStoricoObj.CatastoId);
			DbProvider.SetCmdParam(cmd, firstChar + "CatastoFoglio", LocalizzazioneProgettoStoricoObj.CatastoFoglio);
			DbProvider.SetCmdParam(cmd, firstChar + "CatastoParticella", LocalizzazioneProgettoStoricoObj.CatastoParticella);
			DbProvider.SetCmdParam(cmd, firstChar + "CatastoSezione", LocalizzazioneProgettoStoricoObj.CatastoSezione);
			DbProvider.SetCmdParam(cmd, firstChar + "CatastoSubalterno", LocalizzazioneProgettoStoricoObj.CatastoSubalterno);
			DbProvider.SetCmdParam(cmd, firstChar + "CatastoSuperficie", LocalizzazioneProgettoStoricoObj.CatastoSuperficie);
			DbProvider.SetCmdParam(cmd, firstChar + "Quota", LocalizzazioneProgettoStoricoObj.Quota);
		}
		//Insert
		private static int Insert(DbProvider db, LocalizzazioneProgettoStorico LocalizzazioneProgettoStoricoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd("ZLocalizzazioneProgettoStoricoInsert", new string[] {"IdLocalizzazione", "IdProgetto",
"IdImpresa", "IdComune", "Cap",
"Dug", "Via", "Num",
"DataModifica", "OperatoreModifica", "IdVariante",
"CatastoId", "CatastoFoglio", "CatastoParticella",
"CatastoSezione", "CatastoSubalterno", "CatastoSuperficie",
"Quota",
}, new string[] {"int", "int",
"int", "int", "string",
"int", "string", "string",
"DateTime", "int", "int",
"int", "string", "string",
"string", "string", "int",
"decimal",
}, "");
				CompileIUCmd(false, insertCmd, LocalizzazioneProgettoStoricoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
				{
					LocalizzazioneProgettoStoricoObj.IdLocalizzazioneStorico = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOCALIZZAZIONE_STORICO"]);
					LocalizzazioneProgettoStoricoObj.Quota = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUOTA"]);
				}
				LocalizzazioneProgettoStoricoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				LocalizzazioneProgettoStoricoObj.IsDirty = false;
				LocalizzazioneProgettoStoricoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, LocalizzazioneProgettoStorico LocalizzazioneProgettoStoricoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZLocalizzazioneProgettoStoricoUpdate", new string[] {"IdLocalizzazioneStorico", "IdLocalizzazione", "IdProgetto",
"IdImpresa", "IdComune", "Cap",
"Dug", "Via", "Num",
"DataModifica", "OperatoreModifica", "IdVariante",
"CatastoId", "CatastoFoglio", "CatastoParticella",
"CatastoSezione", "CatastoSubalterno", "CatastoSuperficie",
"Quota",
}, new string[] {"int", "int", "int",
"int", "int", "string",
"int", "string", "string",
"DateTime", "int", "int",
"int", "string", "string",
"string", "string", "int",
"decimal",
}, "");
				CompileIUCmd(true, updateCmd, LocalizzazioneProgettoStoricoObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d != null)
				{
					i = 1;
					LocalizzazioneProgettoStoricoObj.DataModifica = d;
				}
				LocalizzazioneProgettoStoricoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				LocalizzazioneProgettoStoricoObj.IsDirty = false;
				LocalizzazioneProgettoStoricoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, LocalizzazioneProgettoStorico LocalizzazioneProgettoStoricoObj)
		{
			switch (LocalizzazioneProgettoStoricoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added: return Insert(db, LocalizzazioneProgettoStoricoObj);
				case BaseObject.ObjectStateType.Changed: return Update(db, LocalizzazioneProgettoStoricoObj);
				case BaseObject.ObjectStateType.Deleted: return Delete(db, LocalizzazioneProgettoStoricoObj);
				default: return 0;
			}
		}

		public static int SaveCollection(DbProvider db, LocalizzazioneProgettoStoricoCollection LocalizzazioneProgettoStoricoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZLocalizzazioneProgettoStoricoUpdate", new string[] {"IdLocalizzazioneStorico", "IdLocalizzazione", "IdProgetto",
"IdImpresa", "IdComune", "Cap",
"Dug", "Via", "Num",
"DataModifica", "OperatoreModifica", "IdVariante",
"CatastoId", "CatastoFoglio", "CatastoParticella",
"CatastoSezione", "CatastoSubalterno", "CatastoSuperficie",
"Quota",
}, new string[] {"int", "int", "int",
"int", "int", "string",
"int", "string", "string",
"DateTime", "int", "int",
"int", "string", "string",
"string", "string", "int",
"decimal",
}, "");
				IDbCommand insertCmd = db.InitCmd("ZLocalizzazioneProgettoStoricoInsert", new string[] {"IdLocalizzazione", "IdProgetto",
"IdImpresa", "IdComune", "Cap",
"Dug", "Via", "Num",
"DataModifica", "OperatoreModifica", "IdVariante",
"CatastoId", "CatastoFoglio", "CatastoParticella",
"CatastoSezione", "CatastoSubalterno", "CatastoSuperficie",
"Quota",
}, new string[] {"int", "int",
"int", "int", "string",
"int", "string", "string",
"DateTime", "int", "int",
"int", "string", "string",
"string", "string", "int",
"decimal",
}, "");
				IDbCommand deleteCmd = db.InitCmd("ZLocalizzazioneProgettoStoricoDelete", new string[] { "IdLocalizzazioneStorico" }, new string[] { "int" }, "");
				for (int i = 0; i < LocalizzazioneProgettoStoricoCollectionObj.Count; i++)
				{
					switch (LocalizzazioneProgettoStoricoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added:
							{
								CompileIUCmd(false, insertCmd, LocalizzazioneProgettoStoricoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									LocalizzazioneProgettoStoricoCollectionObj[i].IdLocalizzazioneStorico = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOCALIZZAZIONE_STORICO"]);
									LocalizzazioneProgettoStoricoCollectionObj[i].Quota = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUOTA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed:
							{
								CompileIUCmd(true, updateCmd, LocalizzazioneProgettoStoricoCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d != null)
								{
									returnValue++;
									LocalizzazioneProgettoStoricoCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted:
							{
								if (LocalizzazioneProgettoStoricoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdLocalizzazioneStorico", (SiarLibrary.NullTypes.IntNT)LocalizzazioneProgettoStoricoCollectionObj[i].IdLocalizzazioneStorico);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < LocalizzazioneProgettoStoricoCollectionObj.Count; i++)
				{
					if ((LocalizzazioneProgettoStoricoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (LocalizzazioneProgettoStoricoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						LocalizzazioneProgettoStoricoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						LocalizzazioneProgettoStoricoCollectionObj[i].IsDirty = false;
						LocalizzazioneProgettoStoricoCollectionObj[i].IsPersistent = true;
					}
					if ((LocalizzazioneProgettoStoricoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						LocalizzazioneProgettoStoricoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						LocalizzazioneProgettoStoricoCollectionObj[i].IsDirty = false;
						LocalizzazioneProgettoStoricoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, LocalizzazioneProgettoStorico LocalizzazioneProgettoStoricoObj)
		{
			int returnValue = 0;
			if (LocalizzazioneProgettoStoricoObj.IsPersistent)
			{
				returnValue = Delete(db, LocalizzazioneProgettoStoricoObj.IdLocalizzazioneStorico);
			}
			LocalizzazioneProgettoStoricoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			LocalizzazioneProgettoStoricoObj.IsDirty = false;
			LocalizzazioneProgettoStoricoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdLocalizzazioneStoricoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZLocalizzazioneProgettoStoricoDelete", new string[] { "IdLocalizzazioneStorico" }, new string[] { "int" }, "");
				DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdLocalizzazioneStorico", (SiarLibrary.NullTypes.IntNT)IdLocalizzazioneStoricoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, LocalizzazioneProgettoStoricoCollection LocalizzazioneProgettoStoricoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZLocalizzazioneProgettoStoricoDelete", new string[] { "IdLocalizzazioneStorico" }, new string[] { "int" }, "");
				for (int i = 0; i < LocalizzazioneProgettoStoricoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdLocalizzazioneStorico", LocalizzazioneProgettoStoricoCollectionObj[i].IdLocalizzazioneStorico);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < LocalizzazioneProgettoStoricoCollectionObj.Count; i++)
				{
					if ((LocalizzazioneProgettoStoricoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (LocalizzazioneProgettoStoricoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						LocalizzazioneProgettoStoricoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						LocalizzazioneProgettoStoricoCollectionObj[i].IsDirty = false;
						LocalizzazioneProgettoStoricoCollectionObj[i].IsPersistent = false;
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
		public static LocalizzazioneProgettoStorico GetById(DbProvider db, int IdLocalizzazioneStoricoValue)
		{
			LocalizzazioneProgettoStorico LocalizzazioneProgettoStoricoObj = null;
			IDbCommand readCmd = db.InitCmd("ZLocalizzazioneProgettoStoricoGetById", new string[] { "IdLocalizzazioneStorico" }, new string[] { "int" }, "");
			DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdLocalizzazioneStorico", (SiarLibrary.NullTypes.IntNT)IdLocalizzazioneStoricoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				LocalizzazioneProgettoStoricoObj = GetFromDatareader(db);
				LocalizzazioneProgettoStoricoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				LocalizzazioneProgettoStoricoObj.IsDirty = false;
				LocalizzazioneProgettoStoricoObj.IsPersistent = true;
			}
			db.Close();
			return LocalizzazioneProgettoStoricoObj;
		}

		//getFromDatareader
		public static LocalizzazioneProgettoStorico GetFromDatareader(DbProvider db)
		{
			LocalizzazioneProgettoStorico LocalizzazioneProgettoStoricoObj = new LocalizzazioneProgettoStorico();
			LocalizzazioneProgettoStoricoObj.IdLocalizzazioneStorico = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOCALIZZAZIONE_STORICO"]);
			LocalizzazioneProgettoStoricoObj.IdLocalizzazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOCALIZZAZIONE"]);
			LocalizzazioneProgettoStoricoObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			LocalizzazioneProgettoStoricoObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			LocalizzazioneProgettoStoricoObj.IdComune = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COMUNE"]);
			LocalizzazioneProgettoStoricoObj.Cap = new SiarLibrary.NullTypes.StringNT(db.DataReader["CAP"]);
			LocalizzazioneProgettoStoricoObj.Dug = new SiarLibrary.NullTypes.IntNT(db.DataReader["DUG"]);
			LocalizzazioneProgettoStoricoObj.Via = new SiarLibrary.NullTypes.StringNT(db.DataReader["VIA"]);
			LocalizzazioneProgettoStoricoObj.Num = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUM"]);
			LocalizzazioneProgettoStoricoObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			LocalizzazioneProgettoStoricoObj.OperatoreModifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_MODIFICA"]);
			LocalizzazioneProgettoStoricoObj.IdVariante = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VARIANTE"]);
			LocalizzazioneProgettoStoricoObj.CatastoId = new SiarLibrary.NullTypes.IntNT(db.DataReader["CATASTO_ID"]);
			LocalizzazioneProgettoStoricoObj.CatastoFoglio = new SiarLibrary.NullTypes.StringNT(db.DataReader["CATASTO_FOGLIO"]);
			LocalizzazioneProgettoStoricoObj.CatastoParticella = new SiarLibrary.NullTypes.StringNT(db.DataReader["CATASTO_PARTICELLA"]);
			LocalizzazioneProgettoStoricoObj.CatastoSezione = new SiarLibrary.NullTypes.StringNT(db.DataReader["CATASTO_SEZIONE"]);
			LocalizzazioneProgettoStoricoObj.CatastoSubalterno = new SiarLibrary.NullTypes.StringNT(db.DataReader["CATASTO_SUBALTERNO"]);
			LocalizzazioneProgettoStoricoObj.CatastoSuperficie = new SiarLibrary.NullTypes.IntNT(db.DataReader["CATASTO_SUPERFICIE"]);
			LocalizzazioneProgettoStoricoObj.Quota = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUOTA"]);
			LocalizzazioneProgettoStoricoObj.DugDescrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DUG_DESCRIZIONE"]);
			LocalizzazioneProgettoStoricoObj.ComuneBelfiore = new SiarLibrary.NullTypes.StringNT(db.DataReader["COMUNE_BELFIORE"]);
			LocalizzazioneProgettoStoricoObj.ComuneDenominazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["COMUNE_DENOMINAZIONE"]);
			LocalizzazioneProgettoStoricoObj.ComuneProvCode = new SiarLibrary.NullTypes.StringNT(db.DataReader["COMUNE_PROV_CODE"]);
			LocalizzazioneProgettoStoricoObj.ComuneProvSigla = new SiarLibrary.NullTypes.StringNT(db.DataReader["COMUNE_PROV_SIGLA"]);
			LocalizzazioneProgettoStoricoObj.ComuneIstat = new SiarLibrary.NullTypes.StringNT(db.DataReader["COMUNE_ISTAT"]);
			LocalizzazioneProgettoStoricoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			LocalizzazioneProgettoStoricoObj.IsDirty = false;
			LocalizzazioneProgettoStoricoObj.IsPersistent = true;
			return LocalizzazioneProgettoStoricoObj;
		}

		//Find Select

		public static LocalizzazioneProgettoStoricoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdLocalizzazioneStoricoEqualThis, SiarLibrary.NullTypes.IntNT IdLocalizzazioneEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis,
SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.IntNT IdComuneEqualThis, SiarLibrary.NullTypes.StringNT CapEqualThis,
SiarLibrary.NullTypes.IntNT DugEqualThis, SiarLibrary.NullTypes.StringNT ViaEqualThis, SiarLibrary.NullTypes.StringNT NumEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.IntNT OperatoreModificaEqualThis, SiarLibrary.NullTypes.IntNT IdVarianteEqualThis,
SiarLibrary.NullTypes.IntNT CatastoIdEqualThis, SiarLibrary.NullTypes.StringNT CatastoFoglioEqualThis, SiarLibrary.NullTypes.StringNT CatastoParticellaEqualThis,
SiarLibrary.NullTypes.StringNT CatastoSezioneEqualThis, SiarLibrary.NullTypes.StringNT CatastoSubalternoEqualThis, SiarLibrary.NullTypes.IntNT CatastoSuperficieEqualThis,
SiarLibrary.NullTypes.DecimalNT QuotaEqualThis)

		{

			LocalizzazioneProgettoStoricoCollection LocalizzazioneProgettoStoricoCollectionObj = new LocalizzazioneProgettoStoricoCollection();

			IDbCommand findCmd = db.InitCmd("Zlocalizzazioneprogettostoricofindselect", new string[] {"IdLocalizzazioneStoricoequalthis", "IdLocalizzazioneequalthis", "IdProgettoequalthis",
"IdImpresaequalthis", "IdComuneequalthis", "Capequalthis",
"Dugequalthis", "Viaequalthis", "Numequalthis",
"DataModificaequalthis", "OperatoreModificaequalthis", "IdVarianteequalthis",
"CatastoIdequalthis", "CatastoFoglioequalthis", "CatastoParticellaequalthis",
"CatastoSezioneequalthis", "CatastoSubalternoequalthis", "CatastoSuperficieequalthis",
"Quotaequalthis"}, new string[] {"int", "int", "int",
"int", "int", "string",
"int", "string", "string",
"DateTime", "int", "int",
"int", "string", "string",
"string", "string", "int",
"decimal"}, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdLocalizzazioneStoricoequalthis", IdLocalizzazioneStoricoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdLocalizzazioneequalthis", IdLocalizzazioneEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdComuneequalthis", IdComuneEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Capequalthis", CapEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Dugequalthis", DugEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Viaequalthis", ViaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Numequalthis", NumEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperatoreModificaequalthis", OperatoreModificaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdVarianteequalthis", IdVarianteEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CatastoIdequalthis", CatastoIdEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CatastoFoglioequalthis", CatastoFoglioEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CatastoParticellaequalthis", CatastoParticellaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CatastoSezioneequalthis", CatastoSezioneEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CatastoSubalternoequalthis", CatastoSubalternoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CatastoSuperficieequalthis", CatastoSuperficieEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Quotaequalthis", QuotaEqualThis);
			LocalizzazioneProgettoStorico LocalizzazioneProgettoStoricoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				LocalizzazioneProgettoStoricoObj = GetFromDatareader(db);
				LocalizzazioneProgettoStoricoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				LocalizzazioneProgettoStoricoObj.IsDirty = false;
				LocalizzazioneProgettoStoricoObj.IsPersistent = true;
				LocalizzazioneProgettoStoricoCollectionObj.Add(LocalizzazioneProgettoStoricoObj);
			}
			db.Close();
			return LocalizzazioneProgettoStoricoCollectionObj;
		}

		//Find Find

		public static LocalizzazioneProgettoStoricoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdLocalizzazioneEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis,
SiarLibrary.NullTypes.IntNT IdComuneEqualThis)

		{

			LocalizzazioneProgettoStoricoCollection LocalizzazioneProgettoStoricoCollectionObj = new LocalizzazioneProgettoStoricoCollection();

			IDbCommand findCmd = db.InitCmd("Zlocalizzazioneprogettostoricofindfind", new string[] {"IdLocalizzazioneequalthis", "IdProgettoequalthis", "IdImpresaequalthis",
"IdComuneequalthis"}, new string[] {"int", "int", "int",
"int"}, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdLocalizzazioneequalthis", IdLocalizzazioneEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdComuneequalthis", IdComuneEqualThis);
			LocalizzazioneProgettoStorico LocalizzazioneProgettoStoricoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				LocalizzazioneProgettoStoricoObj = GetFromDatareader(db);
				LocalizzazioneProgettoStoricoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				LocalizzazioneProgettoStoricoObj.IsDirty = false;
				LocalizzazioneProgettoStoricoObj.IsPersistent = true;
				LocalizzazioneProgettoStoricoCollectionObj.Add(LocalizzazioneProgettoStoricoObj);
			}
			db.Close();
			return LocalizzazioneProgettoStoricoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for LocalizzazioneProgettoStoricoCollectionProvider:ILocalizzazioneProgettoStoricoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class LocalizzazioneProgettoStoricoCollectionProvider : ILocalizzazioneProgettoStoricoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di LocalizzazioneProgettoStorico
		protected LocalizzazioneProgettoStoricoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public LocalizzazioneProgettoStoricoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new LocalizzazioneProgettoStoricoCollection(this);
		}

		//Costruttore 2: popola la collection
		public LocalizzazioneProgettoStoricoCollectionProvider(IntNT IdlocalizzazioneEqualThis, IntNT IdprogettoEqualThis, IntNT IdimpresaEqualThis,
IntNT IdcomuneEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdlocalizzazioneEqualThis, IdprogettoEqualThis, IdimpresaEqualThis,
IdcomuneEqualThis);
		}

		//Costruttore3: ha in input localizzazioneprogettostoricoCollectionObj - non popola la collection
		public LocalizzazioneProgettoStoricoCollectionProvider(LocalizzazioneProgettoStoricoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public LocalizzazioneProgettoStoricoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new LocalizzazioneProgettoStoricoCollection(this);
		}

		//Get e Set
		public LocalizzazioneProgettoStoricoCollection CollectionObj
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
		public int SaveCollection(LocalizzazioneProgettoStoricoCollection collectionObj)
		{
			return LocalizzazioneProgettoStoricoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(LocalizzazioneProgettoStorico localizzazioneprogettostoricoObj)
		{
			return LocalizzazioneProgettoStoricoDAL.Save(_dbProviderObj, localizzazioneprogettostoricoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(LocalizzazioneProgettoStoricoCollection collectionObj)
		{
			return LocalizzazioneProgettoStoricoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(LocalizzazioneProgettoStorico localizzazioneprogettostoricoObj)
		{
			return LocalizzazioneProgettoStoricoDAL.Delete(_dbProviderObj, localizzazioneprogettostoricoObj);
		}

		//getById
		public LocalizzazioneProgettoStorico GetById(IntNT IdLocalizzazioneStoricoValue)
		{
			LocalizzazioneProgettoStorico LocalizzazioneProgettoStoricoTemp = LocalizzazioneProgettoStoricoDAL.GetById(_dbProviderObj, IdLocalizzazioneStoricoValue);
			if (LocalizzazioneProgettoStoricoTemp != null) LocalizzazioneProgettoStoricoTemp.Provider = this;
			return LocalizzazioneProgettoStoricoTemp;
		}

		//Select: popola la collection
		public LocalizzazioneProgettoStoricoCollection Select(IntNT IdlocalizzazionestoricoEqualThis, IntNT IdlocalizzazioneEqualThis, IntNT IdprogettoEqualThis,
IntNT IdimpresaEqualThis, IntNT IdcomuneEqualThis, StringNT CapEqualThis,
IntNT DugEqualThis, StringNT ViaEqualThis, StringNT NumEqualThis,
DatetimeNT DatamodificaEqualThis, IntNT OperatoremodificaEqualThis, IntNT IdvarianteEqualThis,
IntNT CatastoidEqualThis, StringNT CatastofoglioEqualThis, StringNT CatastoparticellaEqualThis,
StringNT CatastosezioneEqualThis, StringNT CatastosubalternoEqualThis, IntNT CatastosuperficieEqualThis,
DecimalNT QuotaEqualThis)
		{
			LocalizzazioneProgettoStoricoCollection LocalizzazioneProgettoStoricoCollectionTemp = LocalizzazioneProgettoStoricoDAL.Select(_dbProviderObj, IdlocalizzazionestoricoEqualThis, IdlocalizzazioneEqualThis, IdprogettoEqualThis,
IdimpresaEqualThis, IdcomuneEqualThis, CapEqualThis,
DugEqualThis, ViaEqualThis, NumEqualThis,
DatamodificaEqualThis, OperatoremodificaEqualThis, IdvarianteEqualThis,
CatastoidEqualThis, CatastofoglioEqualThis, CatastoparticellaEqualThis,
CatastosezioneEqualThis, CatastosubalternoEqualThis, CatastosuperficieEqualThis,
QuotaEqualThis);
			LocalizzazioneProgettoStoricoCollectionTemp.Provider = this;
			return LocalizzazioneProgettoStoricoCollectionTemp;
		}

		//Find: popola la collection
		public LocalizzazioneProgettoStoricoCollection Find(IntNT IdlocalizzazioneEqualThis, IntNT IdprogettoEqualThis, IntNT IdimpresaEqualThis,
IntNT IdcomuneEqualThis)
		{
			LocalizzazioneProgettoStoricoCollection LocalizzazioneProgettoStoricoCollectionTemp = LocalizzazioneProgettoStoricoDAL.Find(_dbProviderObj, IdlocalizzazioneEqualThis, IdprogettoEqualThis, IdimpresaEqualThis,
IdcomuneEqualThis);
			LocalizzazioneProgettoStoricoCollectionTemp.Provider = this;
			return LocalizzazioneProgettoStoricoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<LOCALIZZAZIONE_PROGETTO_STORICO>
  <ViewName>vLOCALIZZAZIONE_PROGETTO_STORICO</ViewName>
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
      <ID_LOCALIZZAZIONE>Equal</ID_LOCALIZZAZIONE>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <ID_COMUNE>Equal</ID_COMUNE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</LOCALIZZAZIONE_PROGETTO_STORICO>
*/
