using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per LocalizzazioneProgetto
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ILocalizzazioneProgettoProvider
	{
		int Save(LocalizzazioneProgetto LocalizzazioneProgettoObj);
		int SaveCollection(LocalizzazioneProgettoCollection collectionObj);
		int Delete(LocalizzazioneProgetto LocalizzazioneProgettoObj);
		int DeleteCollection(LocalizzazioneProgettoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for LocalizzazioneProgetto
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class LocalizzazioneProgetto : BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdLocalizzazione;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.IntNT _IdComune;
		private NullTypes.StringNT _Cap;
		private NullTypes.IntNT _Dug;
		private NullTypes.StringNT _DugDescrizione;
		private NullTypes.StringNT _Via;
		private NullTypes.StringNT _Num;
		private NullTypes.IntNT _EffettoSuContributo;
		private NullTypes.StringNT _ComuneBelfiore;
		private NullTypes.StringNT _ComuneDenominazione;
		private NullTypes.StringNT _ComuneProvCode;
		private NullTypes.StringNT _ComuneProvSigla;
		private NullTypes.StringNT _ComuneIstat;
		private NullTypes.IntNT _CatastoId;
		private NullTypes.StringNT _CatastoFoglio;
		private NullTypes.StringNT _CatastoParticella;
		private NullTypes.StringNT _CatastoSezione;
		private NullTypes.StringNT _CatastoSubalterno;
		private NullTypes.IntNT _CatastoSuperficie;
		private NullTypes.DecimalNT _Quota;
		[NonSerialized] private ILocalizzazioneProgettoProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public ILocalizzazioneProgettoProvider Provider
		{
			get { return _provider; }
			set { _provider = value; }
		}


		//Costruttore
		public LocalizzazioneProgetto()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
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
		/// Corrisponde al campo:EFFETTO_SU_CONTRIBUTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT EffettoSuContributo
		{
			get { return _EffettoSuContributo; }
			set
			{
				if (EffettoSuContributo != value)
				{
					_EffettoSuContributo = value;
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
	/// Summary description for LocalizzazioneProgettoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class LocalizzazioneProgettoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private LocalizzazioneProgettoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
		{
			int c = info.GetInt32("_count");
			for (int i = 0; i < c; i++)
			{
				this.Add((LocalizzazioneProgetto)info.GetValue(i.ToString(), typeof(LocalizzazioneProgetto)));
			}
		}

		//Costruttore
		public LocalizzazioneProgettoCollection()
		{
			this.ItemType = typeof(LocalizzazioneProgetto);
		}

		//Costruttore con provider
		public LocalizzazioneProgettoCollection(ILocalizzazioneProgettoProvider providerObj)
		{
			this.ItemType = typeof(LocalizzazioneProgetto);
			this.Provider = providerObj;
		}

		//Get e Set
		public new LocalizzazioneProgetto this[int index]
		{
			get { return (LocalizzazioneProgetto)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new LocalizzazioneProgettoCollection GetChanges()
		{
			return (LocalizzazioneProgettoCollection)base.GetChanges();
		}

		[NonSerialized] private ILocalizzazioneProgettoProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public ILocalizzazioneProgettoProvider Provider
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
		public int Add(LocalizzazioneProgetto LocalizzazioneProgettoObj)
		{
			if (LocalizzazioneProgettoObj.Provider == null) LocalizzazioneProgettoObj.Provider = this.Provider;
			return base.Add(LocalizzazioneProgettoObj);
		}

		//AddCollection
		public void AddCollection(LocalizzazioneProgettoCollection LocalizzazioneProgettoCollectionObj)
		{
			foreach (LocalizzazioneProgetto LocalizzazioneProgettoObj in LocalizzazioneProgettoCollectionObj)
				this.Add(LocalizzazioneProgettoObj);
		}

		//Insert
		public void Insert(int index, LocalizzazioneProgetto LocalizzazioneProgettoObj)
		{
			if (LocalizzazioneProgettoObj.Provider == null) LocalizzazioneProgettoObj.Provider = this.Provider;
			base.Insert(index, LocalizzazioneProgettoObj);
		}

		//CollectionGetById
		public LocalizzazioneProgetto CollectionGetById(NullTypes.IntNT IdLocalizzazioneValue)
		{
			int i = 0;
			bool find = false;
			while ((i < this.Count) && (!find))
			{
				if ((this[i].IdLocalizzazione == IdLocalizzazioneValue))
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
		public LocalizzazioneProgettoCollection SubSelect(NullTypes.IntNT IdLocalizzazioneEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdImpresaEqualThis,
NullTypes.IntNT IdComuneEqualThis, NullTypes.StringNT CapEqualThis, NullTypes.IntNT DugEqualThis,
NullTypes.StringNT ViaEqualThis, NullTypes.StringNT NumEqualThis, NullTypes.IntNT CatastoIdEqualThis,
NullTypes.StringNT CatastoFoglioEqualThis, NullTypes.StringNT CatastoParticellaEqualThis, NullTypes.StringNT CatastoSezioneEqualThis,
NullTypes.StringNT CatastoSubalternoEqualThis, NullTypes.IntNT CatastoSuperficieEqualThis, NullTypes.DecimalNT QuotaEqualThis)
		{
			LocalizzazioneProgettoCollection LocalizzazioneProgettoCollectionTemp = new LocalizzazioneProgettoCollection();
			foreach (LocalizzazioneProgetto LocalizzazioneProgettoItem in this)
			{
				if (((IdLocalizzazioneEqualThis == null) || ((LocalizzazioneProgettoItem.IdLocalizzazione != null) && (LocalizzazioneProgettoItem.IdLocalizzazione.Value == IdLocalizzazioneEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((LocalizzazioneProgettoItem.IdProgetto != null) && (LocalizzazioneProgettoItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((LocalizzazioneProgettoItem.IdImpresa != null) && (LocalizzazioneProgettoItem.IdImpresa.Value == IdImpresaEqualThis.Value))) &&
((IdComuneEqualThis == null) || ((LocalizzazioneProgettoItem.IdComune != null) && (LocalizzazioneProgettoItem.IdComune.Value == IdComuneEqualThis.Value))) && ((CapEqualThis == null) || ((LocalizzazioneProgettoItem.Cap != null) && (LocalizzazioneProgettoItem.Cap.Value == CapEqualThis.Value))) && ((DugEqualThis == null) || ((LocalizzazioneProgettoItem.Dug != null) && (LocalizzazioneProgettoItem.Dug.Value == DugEqualThis.Value))) &&
((ViaEqualThis == null) || ((LocalizzazioneProgettoItem.Via != null) && (LocalizzazioneProgettoItem.Via.Value == ViaEqualThis.Value))) && ((NumEqualThis == null) || ((LocalizzazioneProgettoItem.Num != null) && (LocalizzazioneProgettoItem.Num.Value == NumEqualThis.Value))) && ((CatastoIdEqualThis == null) || ((LocalizzazioneProgettoItem.CatastoId != null) && (LocalizzazioneProgettoItem.CatastoId.Value == CatastoIdEqualThis.Value))) &&
((CatastoFoglioEqualThis == null) || ((LocalizzazioneProgettoItem.CatastoFoglio != null) && (LocalizzazioneProgettoItem.CatastoFoglio.Value == CatastoFoglioEqualThis.Value))) && ((CatastoParticellaEqualThis == null) || ((LocalizzazioneProgettoItem.CatastoParticella != null) && (LocalizzazioneProgettoItem.CatastoParticella.Value == CatastoParticellaEqualThis.Value))) && ((CatastoSezioneEqualThis == null) || ((LocalizzazioneProgettoItem.CatastoSezione != null) && (LocalizzazioneProgettoItem.CatastoSezione.Value == CatastoSezioneEqualThis.Value))) &&
((CatastoSubalternoEqualThis == null) || ((LocalizzazioneProgettoItem.CatastoSubalterno != null) && (LocalizzazioneProgettoItem.CatastoSubalterno.Value == CatastoSubalternoEqualThis.Value))) && ((CatastoSuperficieEqualThis == null) || ((LocalizzazioneProgettoItem.CatastoSuperficie != null) && (LocalizzazioneProgettoItem.CatastoSuperficie.Value == CatastoSuperficieEqualThis.Value))) && ((QuotaEqualThis == null) || ((LocalizzazioneProgettoItem.Quota != null) && (LocalizzazioneProgettoItem.Quota.Value == QuotaEqualThis.Value))))
				{
					LocalizzazioneProgettoCollectionTemp.Add(LocalizzazioneProgettoItem);
				}
			}
			return LocalizzazioneProgettoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for LocalizzazioneProgettoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class LocalizzazioneProgettoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, LocalizzazioneProgetto LocalizzazioneProgettoObj, string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd, firstChar + "IdLocalizzazione", LocalizzazioneProgettoObj.IdLocalizzazione);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd, firstChar + "IdProgetto", LocalizzazioneProgettoObj.IdProgetto);
			DbProvider.SetCmdParam(cmd, firstChar + "IdImpresa", LocalizzazioneProgettoObj.IdImpresa);
			DbProvider.SetCmdParam(cmd, firstChar + "IdComune", LocalizzazioneProgettoObj.IdComune);
			DbProvider.SetCmdParam(cmd, firstChar + "Cap", LocalizzazioneProgettoObj.Cap);
			DbProvider.SetCmdParam(cmd, firstChar + "Dug", LocalizzazioneProgettoObj.Dug);
			DbProvider.SetCmdParam(cmd, firstChar + "Via", LocalizzazioneProgettoObj.Via);
			DbProvider.SetCmdParam(cmd, firstChar + "Num", LocalizzazioneProgettoObj.Num);
			DbProvider.SetCmdParam(cmd, firstChar + "CatastoId", LocalizzazioneProgettoObj.CatastoId);
			DbProvider.SetCmdParam(cmd, firstChar + "CatastoFoglio", LocalizzazioneProgettoObj.CatastoFoglio);
			DbProvider.SetCmdParam(cmd, firstChar + "CatastoParticella", LocalizzazioneProgettoObj.CatastoParticella);
			DbProvider.SetCmdParam(cmd, firstChar + "CatastoSezione", LocalizzazioneProgettoObj.CatastoSezione);
			DbProvider.SetCmdParam(cmd, firstChar + "CatastoSubalterno", LocalizzazioneProgettoObj.CatastoSubalterno);
			DbProvider.SetCmdParam(cmd, firstChar + "CatastoSuperficie", LocalizzazioneProgettoObj.CatastoSuperficie);
			DbProvider.SetCmdParam(cmd, firstChar + "Quota", LocalizzazioneProgettoObj.Quota);
		}
		//Insert
		private static int Insert(DbProvider db, LocalizzazioneProgetto LocalizzazioneProgettoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd("ZLocalizzazioneProgettoInsert", new string[] {"IdProgetto", "IdImpresa",
"IdComune", "Cap", "Dug",
"Via", "Num",


"CatastoId", "CatastoFoglio", "CatastoParticella",
"CatastoSezione", "CatastoSubalterno", "CatastoSuperficie",
"Quota"}, new string[] {"int", "int",
"int", "string", "int",
"string", "string",


"int", "string", "string",
"string", "string", "int",
"decimal"}, "");
				CompileIUCmd(false, insertCmd, LocalizzazioneProgettoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
				{
					LocalizzazioneProgettoObj.IdLocalizzazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOCALIZZAZIONE"]);
					LocalizzazioneProgettoObj.Quota = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUOTA"]);
				}
				LocalizzazioneProgettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				LocalizzazioneProgettoObj.IsDirty = false;
				LocalizzazioneProgettoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, LocalizzazioneProgetto LocalizzazioneProgettoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZLocalizzazioneProgettoUpdate", new string[] {"IdLocalizzazione", "IdProgetto", "IdImpresa",
"IdComune", "Cap", "Dug",
"Via", "Num",


"CatastoId", "CatastoFoglio", "CatastoParticella",
"CatastoSezione", "CatastoSubalterno", "CatastoSuperficie",
"Quota"}, new string[] {"int", "int", "int",
"int", "string", "int",
"string", "string",


"int", "string", "string",
"string", "string", "int",
"decimal"}, "");
				CompileIUCmd(true, updateCmd, LocalizzazioneProgettoObj, db.CommandFirstChar);
				i = db.Execute(updateCmd);
				LocalizzazioneProgettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				LocalizzazioneProgettoObj.IsDirty = false;
				LocalizzazioneProgettoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, LocalizzazioneProgetto LocalizzazioneProgettoObj)
		{
			switch (LocalizzazioneProgettoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added: return Insert(db, LocalizzazioneProgettoObj);
				case BaseObject.ObjectStateType.Changed: return Update(db, LocalizzazioneProgettoObj);
				case BaseObject.ObjectStateType.Deleted: return Delete(db, LocalizzazioneProgettoObj);
				default: return 0;
			}
		}

		public static int SaveCollection(DbProvider db, LocalizzazioneProgettoCollection LocalizzazioneProgettoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZLocalizzazioneProgettoUpdate", new string[] {"IdLocalizzazione", "IdProgetto", "IdImpresa",
"IdComune", "Cap", "Dug",
"Via", "Num",


"CatastoId", "CatastoFoglio", "CatastoParticella",
"CatastoSezione", "CatastoSubalterno", "CatastoSuperficie",
"Quota"}, new string[] {"int", "int", "int",
"int", "string", "int",
"string", "string",


"int", "string", "string",
"string", "string", "int",
"decimal"}, "");
				IDbCommand insertCmd = db.InitCmd("ZLocalizzazioneProgettoInsert", new string[] {"IdProgetto", "IdImpresa",
"IdComune", "Cap", "Dug",
"Via", "Num",


"CatastoId", "CatastoFoglio", "CatastoParticella",
"CatastoSezione", "CatastoSubalterno", "CatastoSuperficie",
"Quota"}, new string[] {"int", "int",
"int", "string", "int",
"string", "string",


"int", "string", "string",
"string", "string", "int",
"decimal"}, "");
				IDbCommand deleteCmd = db.InitCmd("ZLocalizzazioneProgettoDelete", new string[] { "IdLocalizzazione" }, new string[] { "int" }, "");
				for (int i = 0; i < LocalizzazioneProgettoCollectionObj.Count; i++)
				{
					switch (LocalizzazioneProgettoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added:
							{
								CompileIUCmd(false, insertCmd, LocalizzazioneProgettoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									LocalizzazioneProgettoCollectionObj[i].IdLocalizzazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOCALIZZAZIONE"]);
									LocalizzazioneProgettoCollectionObj[i].Quota = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUOTA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed:
							{
								CompileIUCmd(true, updateCmd, LocalizzazioneProgettoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted:
							{
								if (LocalizzazioneProgettoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdLocalizzazione", (SiarLibrary.NullTypes.IntNT)LocalizzazioneProgettoCollectionObj[i].IdLocalizzazione);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < LocalizzazioneProgettoCollectionObj.Count; i++)
				{
					if ((LocalizzazioneProgettoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (LocalizzazioneProgettoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						LocalizzazioneProgettoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						LocalizzazioneProgettoCollectionObj[i].IsDirty = false;
						LocalizzazioneProgettoCollectionObj[i].IsPersistent = true;
					}
					if ((LocalizzazioneProgettoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						LocalizzazioneProgettoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						LocalizzazioneProgettoCollectionObj[i].IsDirty = false;
						LocalizzazioneProgettoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, LocalizzazioneProgetto LocalizzazioneProgettoObj)
		{
			int returnValue = 0;
			if (LocalizzazioneProgettoObj.IsPersistent)
			{
				returnValue = Delete(db, LocalizzazioneProgettoObj.IdLocalizzazione);
			}
			LocalizzazioneProgettoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			LocalizzazioneProgettoObj.IsDirty = false;
			LocalizzazioneProgettoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdLocalizzazioneValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZLocalizzazioneProgettoDelete", new string[] { "IdLocalizzazione" }, new string[] { "int" }, "");
				DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdLocalizzazione", (SiarLibrary.NullTypes.IntNT)IdLocalizzazioneValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, LocalizzazioneProgettoCollection LocalizzazioneProgettoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZLocalizzazioneProgettoDelete", new string[] { "IdLocalizzazione" }, new string[] { "int" }, "");
				for (int i = 0; i < LocalizzazioneProgettoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdLocalizzazione", LocalizzazioneProgettoCollectionObj[i].IdLocalizzazione);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < LocalizzazioneProgettoCollectionObj.Count; i++)
				{
					if ((LocalizzazioneProgettoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (LocalizzazioneProgettoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						LocalizzazioneProgettoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						LocalizzazioneProgettoCollectionObj[i].IsDirty = false;
						LocalizzazioneProgettoCollectionObj[i].IsPersistent = false;
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
		public static LocalizzazioneProgetto GetById(DbProvider db, int IdLocalizzazioneValue)
		{
			LocalizzazioneProgetto LocalizzazioneProgettoObj = null;
			IDbCommand readCmd = db.InitCmd("ZLocalizzazioneProgettoGetById", new string[] { "IdLocalizzazione" }, new string[] { "int" }, "");
			DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdLocalizzazione", (SiarLibrary.NullTypes.IntNT)IdLocalizzazioneValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				LocalizzazioneProgettoObj = GetFromDatareader(db);
				LocalizzazioneProgettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				LocalizzazioneProgettoObj.IsDirty = false;
				LocalizzazioneProgettoObj.IsPersistent = true;
			}
			db.Close();
			return LocalizzazioneProgettoObj;
		}

		//getFromDatareader
		public static LocalizzazioneProgetto GetFromDatareader(DbProvider db)
		{
			LocalizzazioneProgetto LocalizzazioneProgettoObj = new LocalizzazioneProgetto();
			LocalizzazioneProgettoObj.IdLocalizzazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOCALIZZAZIONE"]);
			LocalizzazioneProgettoObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			LocalizzazioneProgettoObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			LocalizzazioneProgettoObj.IdComune = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COMUNE"]);
			LocalizzazioneProgettoObj.Cap = new SiarLibrary.NullTypes.StringNT(db.DataReader["CAP"]);
			LocalizzazioneProgettoObj.Dug = new SiarLibrary.NullTypes.IntNT(db.DataReader["DUG"]);
			LocalizzazioneProgettoObj.DugDescrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DUG_DESCRIZIONE"]);
			LocalizzazioneProgettoObj.Via = new SiarLibrary.NullTypes.StringNT(db.DataReader["VIA"]);
			LocalizzazioneProgettoObj.Num = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUM"]);
			LocalizzazioneProgettoObj.EffettoSuContributo = new SiarLibrary.NullTypes.IntNT(db.DataReader["EFFETTO_SU_CONTRIBUTO"]);
			LocalizzazioneProgettoObj.ComuneBelfiore = new SiarLibrary.NullTypes.StringNT(db.DataReader["COMUNE_BELFIORE"]);
			LocalizzazioneProgettoObj.ComuneDenominazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["COMUNE_DENOMINAZIONE"]);
			LocalizzazioneProgettoObj.ComuneProvCode = new SiarLibrary.NullTypes.StringNT(db.DataReader["COMUNE_PROV_CODE"]);
			LocalizzazioneProgettoObj.ComuneProvSigla = new SiarLibrary.NullTypes.StringNT(db.DataReader["COMUNE_PROV_SIGLA"]);
			LocalizzazioneProgettoObj.ComuneIstat = new SiarLibrary.NullTypes.StringNT(db.DataReader["COMUNE_ISTAT"]);
			LocalizzazioneProgettoObj.CatastoId = new SiarLibrary.NullTypes.IntNT(db.DataReader["CATASTO_ID"]);
			LocalizzazioneProgettoObj.CatastoFoglio = new SiarLibrary.NullTypes.StringNT(db.DataReader["CATASTO_FOGLIO"]);
			LocalizzazioneProgettoObj.CatastoParticella = new SiarLibrary.NullTypes.StringNT(db.DataReader["CATASTO_PARTICELLA"]);
			LocalizzazioneProgettoObj.CatastoSezione = new SiarLibrary.NullTypes.StringNT(db.DataReader["CATASTO_SEZIONE"]);
			LocalizzazioneProgettoObj.CatastoSubalterno = new SiarLibrary.NullTypes.StringNT(db.DataReader["CATASTO_SUBALTERNO"]);
			LocalizzazioneProgettoObj.CatastoSuperficie = new SiarLibrary.NullTypes.IntNT(db.DataReader["CATASTO_SUPERFICIE"]);
			LocalizzazioneProgettoObj.Quota = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUOTA"]);
			LocalizzazioneProgettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			LocalizzazioneProgettoObj.IsDirty = false;
			LocalizzazioneProgettoObj.IsPersistent = true;
			return LocalizzazioneProgettoObj;
		}

		//Find Select

		public static LocalizzazioneProgettoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdLocalizzazioneEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis,
SiarLibrary.NullTypes.IntNT IdComuneEqualThis, SiarLibrary.NullTypes.StringNT CapEqualThis, SiarLibrary.NullTypes.IntNT DugEqualThis,
SiarLibrary.NullTypes.StringNT ViaEqualThis, SiarLibrary.NullTypes.StringNT NumEqualThis, SiarLibrary.NullTypes.IntNT CatastoIdEqualThis,
SiarLibrary.NullTypes.StringNT CatastoFoglioEqualThis, SiarLibrary.NullTypes.StringNT CatastoParticellaEqualThis, SiarLibrary.NullTypes.StringNT CatastoSezioneEqualThis,
SiarLibrary.NullTypes.StringNT CatastoSubalternoEqualThis, SiarLibrary.NullTypes.IntNT CatastoSuperficieEqualThis, SiarLibrary.NullTypes.DecimalNT QuotaEqualThis)

		{

			LocalizzazioneProgettoCollection LocalizzazioneProgettoCollectionObj = new LocalizzazioneProgettoCollection();

			IDbCommand findCmd = db.InitCmd("Zlocalizzazioneprogettofindselect", new string[] {"IdLocalizzazioneequalthis", "IdProgettoequalthis", "IdImpresaequalthis",
"IdComuneequalthis", "Capequalthis", "Dugequalthis",
"Viaequalthis", "Numequalthis", "CatastoIdequalthis",
"CatastoFoglioequalthis", "CatastoParticellaequalthis", "CatastoSezioneequalthis",
"CatastoSubalternoequalthis", "CatastoSuperficieequalthis", "Quotaequalthis"}, new string[] {"int", "int", "int",
"int", "string", "int",
"string", "string", "int",
"string", "string", "string",
"string", "int", "decimal"}, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdLocalizzazioneequalthis", IdLocalizzazioneEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdComuneequalthis", IdComuneEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Capequalthis", CapEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Dugequalthis", DugEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Viaequalthis", ViaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Numequalthis", NumEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CatastoIdequalthis", CatastoIdEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CatastoFoglioequalthis", CatastoFoglioEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CatastoParticellaequalthis", CatastoParticellaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CatastoSezioneequalthis", CatastoSezioneEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CatastoSubalternoequalthis", CatastoSubalternoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CatastoSuperficieequalthis", CatastoSuperficieEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Quotaequalthis", QuotaEqualThis);
			LocalizzazioneProgetto LocalizzazioneProgettoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				LocalizzazioneProgettoObj = GetFromDatareader(db);
				LocalizzazioneProgettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				LocalizzazioneProgettoObj.IsDirty = false;
				LocalizzazioneProgettoObj.IsPersistent = true;
				LocalizzazioneProgettoCollectionObj.Add(LocalizzazioneProgettoObj);
			}
			db.Close();
			return LocalizzazioneProgettoCollectionObj;
		}

		//Find Find

		public static LocalizzazioneProgettoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdLocalizzazioneEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis,
SiarLibrary.NullTypes.IntNT IdComuneEqualThis)

		{

			LocalizzazioneProgettoCollection LocalizzazioneProgettoCollectionObj = new LocalizzazioneProgettoCollection();

			IDbCommand findCmd = db.InitCmd("Zlocalizzazioneprogettofindfind", new string[] {"IdLocalizzazioneequalthis", "IdProgettoequalthis", "IdImpresaequalthis",
"IdComuneequalthis"}, new string[] {"int", "int", "int",
"int"}, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdLocalizzazioneequalthis", IdLocalizzazioneEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdComuneequalthis", IdComuneEqualThis);
			LocalizzazioneProgetto LocalizzazioneProgettoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				LocalizzazioneProgettoObj = GetFromDatareader(db);
				LocalizzazioneProgettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				LocalizzazioneProgettoObj.IsDirty = false;
				LocalizzazioneProgettoObj.IsPersistent = true;
				LocalizzazioneProgettoCollectionObj.Add(LocalizzazioneProgettoObj);
			}
			db.Close();
			return LocalizzazioneProgettoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for LocalizzazioneProgettoCollectionProvider:ILocalizzazioneProgettoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class LocalizzazioneProgettoCollectionProvider : ILocalizzazioneProgettoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di LocalizzazioneProgetto
		protected LocalizzazioneProgettoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public LocalizzazioneProgettoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new LocalizzazioneProgettoCollection(this);
		}

		//Costruttore 2: popola la collection
		public LocalizzazioneProgettoCollectionProvider(IntNT IdlocalizzazioneEqualThis, IntNT IdprogettoEqualThis, IntNT IdimpresaEqualThis,
IntNT IdcomuneEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdlocalizzazioneEqualThis, IdprogettoEqualThis, IdimpresaEqualThis,
IdcomuneEqualThis);
		}

		//Costruttore3: ha in input localizzazioneprogettoCollectionObj - non popola la collection
		public LocalizzazioneProgettoCollectionProvider(LocalizzazioneProgettoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public LocalizzazioneProgettoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new LocalizzazioneProgettoCollection(this);
		}

		//Get e Set
		public LocalizzazioneProgettoCollection CollectionObj
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
		public int SaveCollection(LocalizzazioneProgettoCollection collectionObj)
		{
			return LocalizzazioneProgettoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(LocalizzazioneProgetto localizzazioneprogettoObj)
		{
			return LocalizzazioneProgettoDAL.Save(_dbProviderObj, localizzazioneprogettoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(LocalizzazioneProgettoCollection collectionObj)
		{
			return LocalizzazioneProgettoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(LocalizzazioneProgetto localizzazioneprogettoObj)
		{
			return LocalizzazioneProgettoDAL.Delete(_dbProviderObj, localizzazioneprogettoObj);
		}

		//getById
		public LocalizzazioneProgetto GetById(IntNT IdLocalizzazioneValue)
		{
			LocalizzazioneProgetto LocalizzazioneProgettoTemp = LocalizzazioneProgettoDAL.GetById(_dbProviderObj, IdLocalizzazioneValue);
			if (LocalizzazioneProgettoTemp != null) LocalizzazioneProgettoTemp.Provider = this;
			return LocalizzazioneProgettoTemp;
		}

		//Select: popola la collection
		public LocalizzazioneProgettoCollection Select(IntNT IdlocalizzazioneEqualThis, IntNT IdprogettoEqualThis, IntNT IdimpresaEqualThis,
IntNT IdcomuneEqualThis, StringNT CapEqualThis, IntNT DugEqualThis,
StringNT ViaEqualThis, StringNT NumEqualThis, IntNT CatastoidEqualThis,
StringNT CatastofoglioEqualThis, StringNT CatastoparticellaEqualThis, StringNT CatastosezioneEqualThis,
StringNT CatastosubalternoEqualThis, IntNT CatastosuperficieEqualThis, DecimalNT QuotaEqualThis)
		{
			LocalizzazioneProgettoCollection LocalizzazioneProgettoCollectionTemp = LocalizzazioneProgettoDAL.Select(_dbProviderObj, IdlocalizzazioneEqualThis, IdprogettoEqualThis, IdimpresaEqualThis,
IdcomuneEqualThis, CapEqualThis, DugEqualThis,
ViaEqualThis, NumEqualThis, CatastoidEqualThis,
CatastofoglioEqualThis, CatastoparticellaEqualThis, CatastosezioneEqualThis,
CatastosubalternoEqualThis, CatastosuperficieEqualThis, QuotaEqualThis);
			LocalizzazioneProgettoCollectionTemp.Provider = this;
			return LocalizzazioneProgettoCollectionTemp;
		}

		//Find: popola la collection
		public LocalizzazioneProgettoCollection Find(IntNT IdlocalizzazioneEqualThis, IntNT IdprogettoEqualThis, IntNT IdimpresaEqualThis,
IntNT IdcomuneEqualThis)
		{
			LocalizzazioneProgettoCollection LocalizzazioneProgettoCollectionTemp = LocalizzazioneProgettoDAL.Find(_dbProviderObj, IdlocalizzazioneEqualThis, IdprogettoEqualThis, IdimpresaEqualThis,
IdcomuneEqualThis);
			LocalizzazioneProgettoCollectionTemp.Provider = this;
			return LocalizzazioneProgettoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<LOCALIZZAZIONE_PROGETTO>
  <ViewName>vLOCALIZZAZIONE_PROGETTO</ViewName>
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
      <ID_LOCALIZZAZIONE>Equal</ID_LOCALIZZAZIONE>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <ID_COMUNE>Equal</ID_COMUNE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</LOCALIZZAZIONE_PROGETTO>
*/
