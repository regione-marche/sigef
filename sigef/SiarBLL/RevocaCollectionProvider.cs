using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per Revoca
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IRevocaProvider
	{
		int Save(Revoca RevocaObj);
		int SaveCollection(RevocaCollection collectionObj);
		int Delete(Revoca RevocaObj);
		int DeleteCollection(RevocaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for Revoca
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class Revoca : BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdRevoca;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.StringNT _Origine;
		private NullTypes.StringNT _Note;
		private NullTypes.DecimalNT _ImportoRevoca;
		private NullTypes.IntNT _IdAtto;
		private NullTypes.StringNT _NumeroAtto;
		private NullTypes.DatetimeNT _DataAtto;
		private NullTypes.BoolNT _RecuperoBeneficiario;
		private NullTypes.BoolNT _RevocaContributo;
		private NullTypes.DecimalNT _ImportoDaRecuperare;
		private NullTypes.DecimalNT _InteressiLegali;
		private NullTypes.DecimalNT _SpeseNotifica;
		private NullTypes.DecimalNT _Sanzioni;
		private NullTypes.DecimalNT _Totale;
		private NullTypes.DecimalNT _ImportoRecuperato;
		private NullTypes.BoolNT _Irrecuperabile;
		private NullTypes.DatetimeNT _DataIrrecuperabile;
		private NullTypes.DecimalNT _ImportoIrrecuperabile;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.BoolNT _Recuperato;
		private NullTypes.BoolNT _Stabilita;
		[NonSerialized] private IRevocaProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public IRevocaProvider Provider
		{
			get { return _provider; }
			set { _provider = value; }
		}


		//Costruttore
		public Revoca()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_REVOCA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdRevoca
		{
			get { return _IdRevoca; }
			set
			{
				if (IdRevoca != value)
				{
					_IdRevoca = value;
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
		/// Corrisponde al campo:ORIGINE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Origine
		{
			get { return _Origine; }
			set
			{
				if (Origine != value)
				{
					_Origine = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOTE
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT Note
		{
			get { return _Note; }
			set
			{
				if (Note != value)
				{
					_Note = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_REVOCA
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoRevoca
		{
			get { return _ImportoRevoca; }
			set
			{
				if (ImportoRevoca != value)
				{
					_ImportoRevoca = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_ATTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdAtto
		{
			get { return _IdAtto; }
			set
			{
				if (IdAtto != value)
				{
					_IdAtto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NUMERO_ATTO
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT NumeroAtto
		{
			get { return _NumeroAtto; }
			set
			{
				if (NumeroAtto != value)
				{
					_NumeroAtto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_ATTO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataAtto
		{
			get { return _DataAtto; }
			set
			{
				if (DataAtto != value)
				{
					_DataAtto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RECUPERO_BENEFICIARIO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT RecuperoBeneficiario
		{
			get { return _RecuperoBeneficiario; }
			set
			{
				if (RecuperoBeneficiario != value)
				{
					_RecuperoBeneficiario = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:REVOCA_CONTRIBUTO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT RevocaContributo
		{
			get { return _RevocaContributo; }
			set
			{
				if (RevocaContributo != value)
				{
					_RevocaContributo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_DA_RECUPERARE
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoDaRecuperare
		{
			get { return _ImportoDaRecuperare; }
			set
			{
				if (ImportoDaRecuperare != value)
				{
					_ImportoDaRecuperare = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:INTERESSI_LEGALI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT InteressiLegali
		{
			get { return _InteressiLegali; }
			set
			{
				if (InteressiLegali != value)
				{
					_InteressiLegali = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SPESE_NOTIFICA
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT SpeseNotifica
		{
			get { return _SpeseNotifica; }
			set
			{
				if (SpeseNotifica != value)
				{
					_SpeseNotifica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SANZIONI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT Sanzioni
		{
			get { return _Sanzioni; }
			set
			{
				if (Sanzioni != value)
				{
					_Sanzioni = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TOTALE
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT Totale
		{
			get { return _Totale; }
			set
			{
				if (Totale != value)
				{
					_Totale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_RECUPERATO
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoRecuperato
		{
			get { return _ImportoRecuperato; }
			set
			{
				if (ImportoRecuperato != value)
				{
					_ImportoRecuperato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IRRECUPERABILE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Irrecuperabile
		{
			get { return _Irrecuperabile; }
			set
			{
				if (Irrecuperabile != value)
				{
					_Irrecuperabile = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_IRRECUPERABILE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataIrrecuperabile
		{
			get { return _DataIrrecuperabile; }
			set
			{
				if (DataIrrecuperabile != value)
				{
					_DataIrrecuperabile = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_IRRECUPERABILE
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoIrrecuperabile
		{
			get { return _ImportoIrrecuperabile; }
			set
			{
				if (ImportoIrrecuperabile != value)
				{
					_ImportoIrrecuperabile = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_MODIFICA
		/// Tipo sul db:DATETIME
		/// Default:(getdate())
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
		/// Corrisponde al campo:RECUPERATO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Recuperato
		{
			get { return _Recuperato; }
			set
			{
				if (Recuperato != value)
				{
					_Recuperato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:STABILITA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Stabilita
		{
			get { return _Stabilita; }
			set
			{
				if (Stabilita != value)
				{
					_Stabilita = value;
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
	/// Summary description for RevocaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RevocaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private RevocaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
		{
			int c = info.GetInt32("_count");
			for (int i = 0; i < c; i++)
			{
				this.Add((Revoca)info.GetValue(i.ToString(), typeof(Revoca)));
			}
		}

		//Costruttore
		public RevocaCollection()
		{
			this.ItemType = typeof(Revoca);
		}

		//Costruttore con provider
		public RevocaCollection(IRevocaProvider providerObj)
		{
			this.ItemType = typeof(Revoca);
			this.Provider = providerObj;
		}

		//Get e Set
		public new Revoca this[int index]
		{
			get { return (Revoca)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new RevocaCollection GetChanges()
		{
			return (RevocaCollection)base.GetChanges();
		}

		[NonSerialized] private IRevocaProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public IRevocaProvider Provider
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
		public int Add(Revoca RevocaObj)
		{
			if (RevocaObj.Provider == null) RevocaObj.Provider = this.Provider;
			return base.Add(RevocaObj);
		}

		//AddCollection
		public void AddCollection(RevocaCollection RevocaCollectionObj)
		{
			foreach (Revoca RevocaObj in RevocaCollectionObj)
				this.Add(RevocaObj);
		}

		//Insert
		public void Insert(int index, Revoca RevocaObj)
		{
			if (RevocaObj.Provider == null) RevocaObj.Provider = this.Provider;
			base.Insert(index, RevocaObj);
		}

		//CollectionGetById
		public Revoca CollectionGetById(NullTypes.IntNT IdRevocaValue)
		{
			int i = 0;
			bool find = false;
			while ((i < this.Count) && (!find))
			{
				if ((this[i].IdRevoca == IdRevocaValue))
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
		public RevocaCollection SubSelect(NullTypes.IntNT IdRevocaEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdImpresaEqualThis,
NullTypes.StringNT OrigineEqualThis, NullTypes.StringNT NoteEqualThis, NullTypes.DecimalNT ImportoRevocaEqualThis,
NullTypes.IntNT IdAttoEqualThis, NullTypes.StringNT NumeroAttoEqualThis, NullTypes.DatetimeNT DataAttoEqualThis,
NullTypes.BoolNT RecuperoBeneficiarioEqualThis, NullTypes.BoolNT RevocaContributoEqualThis, NullTypes.DecimalNT ImportoDaRecuperareEqualThis,
NullTypes.DecimalNT InteressiLegaliEqualThis, NullTypes.DecimalNT SpeseNotificaEqualThis, NullTypes.DecimalNT SanzioniEqualThis,
NullTypes.DecimalNT TotaleEqualThis, NullTypes.DecimalNT ImportoRecuperatoEqualThis, NullTypes.BoolNT IrrecuperabileEqualThis,
NullTypes.DatetimeNT DataIrrecuperabileEqualThis, NullTypes.DecimalNT ImportoIrrecuperabileEqualThis, NullTypes.DatetimeNT DataModificaEqualThis,
NullTypes.BoolNT RecuperatoEqualThis, NullTypes.BoolNT StabilitaEqualThis)
		{
			RevocaCollection RevocaCollectionTemp = new RevocaCollection();
			foreach (Revoca RevocaItem in this)
			{
				if (((IdRevocaEqualThis == null) || ((RevocaItem.IdRevoca != null) && (RevocaItem.IdRevoca.Value == IdRevocaEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((RevocaItem.IdProgetto != null) && (RevocaItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((RevocaItem.IdImpresa != null) && (RevocaItem.IdImpresa.Value == IdImpresaEqualThis.Value))) &&
((OrigineEqualThis == null) || ((RevocaItem.Origine != null) && (RevocaItem.Origine.Value == OrigineEqualThis.Value))) && ((NoteEqualThis == null) || ((RevocaItem.Note != null) && (RevocaItem.Note.Value == NoteEqualThis.Value))) && ((ImportoRevocaEqualThis == null) || ((RevocaItem.ImportoRevoca != null) && (RevocaItem.ImportoRevoca.Value == ImportoRevocaEqualThis.Value))) &&
((IdAttoEqualThis == null) || ((RevocaItem.IdAtto != null) && (RevocaItem.IdAtto.Value == IdAttoEqualThis.Value))) && ((NumeroAttoEqualThis == null) || ((RevocaItem.NumeroAtto != null) && (RevocaItem.NumeroAtto.Value == NumeroAttoEqualThis.Value))) && ((DataAttoEqualThis == null) || ((RevocaItem.DataAtto != null) && (RevocaItem.DataAtto.Value == DataAttoEqualThis.Value))) &&
((RecuperoBeneficiarioEqualThis == null) || ((RevocaItem.RecuperoBeneficiario != null) && (RevocaItem.RecuperoBeneficiario.Value == RecuperoBeneficiarioEqualThis.Value))) && ((RevocaContributoEqualThis == null) || ((RevocaItem.RevocaContributo != null) && (RevocaItem.RevocaContributo.Value == RevocaContributoEqualThis.Value))) && ((ImportoDaRecuperareEqualThis == null) || ((RevocaItem.ImportoDaRecuperare != null) && (RevocaItem.ImportoDaRecuperare.Value == ImportoDaRecuperareEqualThis.Value))) &&
((InteressiLegaliEqualThis == null) || ((RevocaItem.InteressiLegali != null) && (RevocaItem.InteressiLegali.Value == InteressiLegaliEqualThis.Value))) && ((SpeseNotificaEqualThis == null) || ((RevocaItem.SpeseNotifica != null) && (RevocaItem.SpeseNotifica.Value == SpeseNotificaEqualThis.Value))) && ((SanzioniEqualThis == null) || ((RevocaItem.Sanzioni != null) && (RevocaItem.Sanzioni.Value == SanzioniEqualThis.Value))) &&
((TotaleEqualThis == null) || ((RevocaItem.Totale != null) && (RevocaItem.Totale.Value == TotaleEqualThis.Value))) && ((ImportoRecuperatoEqualThis == null) || ((RevocaItem.ImportoRecuperato != null) && (RevocaItem.ImportoRecuperato.Value == ImportoRecuperatoEqualThis.Value))) && ((IrrecuperabileEqualThis == null) || ((RevocaItem.Irrecuperabile != null) && (RevocaItem.Irrecuperabile.Value == IrrecuperabileEqualThis.Value))) &&
((DataIrrecuperabileEqualThis == null) || ((RevocaItem.DataIrrecuperabile != null) && (RevocaItem.DataIrrecuperabile.Value == DataIrrecuperabileEqualThis.Value))) && ((ImportoIrrecuperabileEqualThis == null) || ((RevocaItem.ImportoIrrecuperabile != null) && (RevocaItem.ImportoIrrecuperabile.Value == ImportoIrrecuperabileEqualThis.Value))) && ((DataModificaEqualThis == null) || ((RevocaItem.DataModifica != null) && (RevocaItem.DataModifica.Value == DataModificaEqualThis.Value))) &&
((RecuperatoEqualThis == null) || ((RevocaItem.Recuperato != null) && (RevocaItem.Recuperato.Value == RecuperatoEqualThis.Value))) && ((StabilitaEqualThis == null) || ((RevocaItem.Stabilita != null) && (RevocaItem.Stabilita.Value == StabilitaEqualThis.Value))))
				{
					RevocaCollectionTemp.Add(RevocaItem);
				}
			}
			return RevocaCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for RevocaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class RevocaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, Revoca RevocaObj, string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd, firstChar + "IdRevoca", RevocaObj.IdRevoca);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd, firstChar + "IdProgetto", RevocaObj.IdProgetto);
			DbProvider.SetCmdParam(cmd, firstChar + "IdImpresa", RevocaObj.IdImpresa);
			DbProvider.SetCmdParam(cmd, firstChar + "Origine", RevocaObj.Origine);
			DbProvider.SetCmdParam(cmd, firstChar + "Note", RevocaObj.Note);
			DbProvider.SetCmdParam(cmd, firstChar + "ImportoRevoca", RevocaObj.ImportoRevoca);
			DbProvider.SetCmdParam(cmd, firstChar + "IdAtto", RevocaObj.IdAtto);
			DbProvider.SetCmdParam(cmd, firstChar + "NumeroAtto", RevocaObj.NumeroAtto);
			DbProvider.SetCmdParam(cmd, firstChar + "DataAtto", RevocaObj.DataAtto);
			DbProvider.SetCmdParam(cmd, firstChar + "RecuperoBeneficiario", RevocaObj.RecuperoBeneficiario);
			DbProvider.SetCmdParam(cmd, firstChar + "RevocaContributo", RevocaObj.RevocaContributo);
			DbProvider.SetCmdParam(cmd, firstChar + "ImportoDaRecuperare", RevocaObj.ImportoDaRecuperare);
			DbProvider.SetCmdParam(cmd, firstChar + "InteressiLegali", RevocaObj.InteressiLegali);
			DbProvider.SetCmdParam(cmd, firstChar + "SpeseNotifica", RevocaObj.SpeseNotifica);
			DbProvider.SetCmdParam(cmd, firstChar + "Sanzioni", RevocaObj.Sanzioni);
			DbProvider.SetCmdParam(cmd, firstChar + "Totale", RevocaObj.Totale);
			DbProvider.SetCmdParam(cmd, firstChar + "ImportoRecuperato", RevocaObj.ImportoRecuperato);
			DbProvider.SetCmdParam(cmd, firstChar + "Irrecuperabile", RevocaObj.Irrecuperabile);
			DbProvider.SetCmdParam(cmd, firstChar + "DataIrrecuperabile", RevocaObj.DataIrrecuperabile);
			DbProvider.SetCmdParam(cmd, firstChar + "ImportoIrrecuperabile", RevocaObj.ImportoIrrecuperabile);
			DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", RevocaObj.DataModifica);
			DbProvider.SetCmdParam(cmd, firstChar + "Recuperato", RevocaObj.Recuperato);
			DbProvider.SetCmdParam(cmd, firstChar + "Stabilita", RevocaObj.Stabilita);
		}
		//Insert
		private static int Insert(DbProvider db, Revoca RevocaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd("ZRevocaInsert", new string[] {"IdProgetto", "IdImpresa",
"Origine", "Note", "ImportoRevoca",
"IdAtto", "NumeroAtto", "DataAtto",
"RecuperoBeneficiario", "RevocaContributo", "ImportoDaRecuperare",
"InteressiLegali", "SpeseNotifica", "Sanzioni",
"Totale", "ImportoRecuperato", "Irrecuperabile",
"DataIrrecuperabile", "ImportoIrrecuperabile", "DataModifica",
"Recuperato", "Stabilita"}, new string[] {"int", "int",
"string", "string", "decimal",
"int", "string", "DateTime",
"bool", "bool", "decimal",
"decimal", "decimal", "decimal",
"decimal", "decimal", "bool",
"DateTime", "decimal", "DateTime",
"bool", "bool"}, "");
				CompileIUCmd(false, insertCmd, RevocaObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
				{
					RevocaObj.IdRevoca = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_REVOCA"]);
					RevocaObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
				}
				RevocaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RevocaObj.IsDirty = false;
				RevocaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, Revoca RevocaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZRevocaUpdate", new string[] {"IdRevoca", "IdProgetto", "IdImpresa",
"Origine", "Note", "ImportoRevoca",
"IdAtto", "NumeroAtto", "DataAtto",
"RecuperoBeneficiario", "RevocaContributo", "ImportoDaRecuperare",
"InteressiLegali", "SpeseNotifica", "Sanzioni",
"Totale", "ImportoRecuperato", "Irrecuperabile",
"DataIrrecuperabile", "ImportoIrrecuperabile", "DataModifica",
"Recuperato", "Stabilita"}, new string[] {"int", "int", "int",
"string", "string", "decimal",
"int", "string", "DateTime",
"bool", "bool", "decimal",
"decimal", "decimal", "decimal",
"decimal", "decimal", "bool",
"DateTime", "decimal", "DateTime",
"bool", "bool"}, "");
				CompileIUCmd(true, updateCmd, RevocaObj, db.CommandFirstChar);
				i = db.Execute(updateCmd);
				RevocaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RevocaObj.IsDirty = false;
				RevocaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, Revoca RevocaObj)
		{
			switch (RevocaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added: return Insert(db, RevocaObj);
				case BaseObject.ObjectStateType.Changed: return Update(db, RevocaObj);
				case BaseObject.ObjectStateType.Deleted: return Delete(db, RevocaObj);
				default: return 0;
			}
		}

		public static int SaveCollection(DbProvider db, RevocaCollection RevocaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZRevocaUpdate", new string[] {"IdRevoca", "IdProgetto", "IdImpresa",
"Origine", "Note", "ImportoRevoca",
"IdAtto", "NumeroAtto", "DataAtto",
"RecuperoBeneficiario", "RevocaContributo", "ImportoDaRecuperare",
"InteressiLegali", "SpeseNotifica", "Sanzioni",
"Totale", "ImportoRecuperato", "Irrecuperabile",
"DataIrrecuperabile", "ImportoIrrecuperabile", "DataModifica",
"Recuperato", "Stabilita"}, new string[] {"int", "int", "int",
"string", "string", "decimal",
"int", "string", "DateTime",
"bool", "bool", "decimal",
"decimal", "decimal", "decimal",
"decimal", "decimal", "bool",
"DateTime", "decimal", "DateTime",
"bool", "bool"}, "");
				IDbCommand insertCmd = db.InitCmd("ZRevocaInsert", new string[] {"IdProgetto", "IdImpresa",
"Origine", "Note", "ImportoRevoca",
"IdAtto", "NumeroAtto", "DataAtto",
"RecuperoBeneficiario", "RevocaContributo", "ImportoDaRecuperare",
"InteressiLegali", "SpeseNotifica", "Sanzioni",
"Totale", "ImportoRecuperato", "Irrecuperabile",
"DataIrrecuperabile", "ImportoIrrecuperabile", "DataModifica",
"Recuperato", "Stabilita"}, new string[] {"int", "int",
"string", "string", "decimal",
"int", "string", "DateTime",
"bool", "bool", "decimal",
"decimal", "decimal", "decimal",
"decimal", "decimal", "bool",
"DateTime", "decimal", "DateTime",
"bool", "bool"}, "");
				IDbCommand deleteCmd = db.InitCmd("ZRevocaDelete", new string[] { "IdRevoca" }, new string[] { "int" }, "");
				for (int i = 0; i < RevocaCollectionObj.Count; i++)
				{
					switch (RevocaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added:
							{
								CompileIUCmd(false, insertCmd, RevocaCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									RevocaCollectionObj[i].IdRevoca = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_REVOCA"]);
									RevocaCollectionObj[i].DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed:
							{
								CompileIUCmd(true, updateCmd, RevocaCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted:
							{
								if (RevocaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdRevoca", (SiarLibrary.NullTypes.IntNT)RevocaCollectionObj[i].IdRevoca);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < RevocaCollectionObj.Count; i++)
				{
					if ((RevocaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RevocaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RevocaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						RevocaCollectionObj[i].IsDirty = false;
						RevocaCollectionObj[i].IsPersistent = true;
					}
					if ((RevocaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						RevocaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RevocaCollectionObj[i].IsDirty = false;
						RevocaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, Revoca RevocaObj)
		{
			int returnValue = 0;
			if (RevocaObj.IsPersistent)
			{
				returnValue = Delete(db, RevocaObj.IdRevoca);
			}
			RevocaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			RevocaObj.IsDirty = false;
			RevocaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdRevocaValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZRevocaDelete", new string[] { "IdRevoca" }, new string[] { "int" }, "");
				DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdRevoca", (SiarLibrary.NullTypes.IntNT)IdRevocaValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, RevocaCollection RevocaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZRevocaDelete", new string[] { "IdRevoca" }, new string[] { "int" }, "");
				for (int i = 0; i < RevocaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdRevoca", RevocaCollectionObj[i].IdRevoca);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < RevocaCollectionObj.Count; i++)
				{
					if ((RevocaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RevocaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RevocaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RevocaCollectionObj[i].IsDirty = false;
						RevocaCollectionObj[i].IsPersistent = false;
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
		public static Revoca GetById(DbProvider db, int IdRevocaValue)
		{
			Revoca RevocaObj = null;
			IDbCommand readCmd = db.InitCmd("ZRevocaGetById", new string[] { "IdRevoca" }, new string[] { "int" }, "");
			DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdRevoca", (SiarLibrary.NullTypes.IntNT)IdRevocaValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				RevocaObj = GetFromDatareader(db);
				RevocaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RevocaObj.IsDirty = false;
				RevocaObj.IsPersistent = true;
			}
			db.Close();
			return RevocaObj;
		}

		//getFromDatareader
		public static Revoca GetFromDatareader(DbProvider db)
		{
			Revoca RevocaObj = new Revoca();
			RevocaObj.IdRevoca = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_REVOCA"]);
			RevocaObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			RevocaObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			RevocaObj.Origine = new SiarLibrary.NullTypes.StringNT(db.DataReader["ORIGINE"]);
			RevocaObj.Note = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE"]);
			RevocaObj.ImportoRevoca = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_REVOCA"]);
			RevocaObj.IdAtto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ATTO"]);
			RevocaObj.NumeroAtto = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO_ATTO"]);
			RevocaObj.DataAtto = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_ATTO"]);
			RevocaObj.RecuperoBeneficiario = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RECUPERO_BENEFICIARIO"]);
			RevocaObj.RevocaContributo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["REVOCA_CONTRIBUTO"]);
			RevocaObj.ImportoDaRecuperare = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_DA_RECUPERARE"]);
			RevocaObj.InteressiLegali = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["INTERESSI_LEGALI"]);
			RevocaObj.SpeseNotifica = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SPESE_NOTIFICA"]);
			RevocaObj.Sanzioni = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SANZIONI"]);
			RevocaObj.Totale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TOTALE"]);
			RevocaObj.ImportoRecuperato = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_RECUPERATO"]);
			RevocaObj.Irrecuperabile = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IRRECUPERABILE"]);
			RevocaObj.DataIrrecuperabile = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_IRRECUPERABILE"]);
			RevocaObj.ImportoIrrecuperabile = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_IRRECUPERABILE"]);
			RevocaObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			RevocaObj.Recuperato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RECUPERATO"]);
			RevocaObj.Stabilita = new SiarLibrary.NullTypes.BoolNT(db.DataReader["STABILITA"]);
			RevocaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			RevocaObj.IsDirty = false;
			RevocaObj.IsPersistent = true;
			return RevocaObj;
		}

		//Find Select

		public static RevocaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdRevocaEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis,
SiarLibrary.NullTypes.StringNT OrigineEqualThis, SiarLibrary.NullTypes.StringNT NoteEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoRevocaEqualThis,
SiarLibrary.NullTypes.IntNT IdAttoEqualThis, SiarLibrary.NullTypes.StringNT NumeroAttoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataAttoEqualThis,
SiarLibrary.NullTypes.BoolNT RecuperoBeneficiarioEqualThis, SiarLibrary.NullTypes.BoolNT RevocaContributoEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoDaRecuperareEqualThis,
SiarLibrary.NullTypes.DecimalNT InteressiLegaliEqualThis, SiarLibrary.NullTypes.DecimalNT SpeseNotificaEqualThis, SiarLibrary.NullTypes.DecimalNT SanzioniEqualThis,
SiarLibrary.NullTypes.DecimalNT TotaleEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoRecuperatoEqualThis, SiarLibrary.NullTypes.BoolNT IrrecuperabileEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataIrrecuperabileEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoIrrecuperabileEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis,
SiarLibrary.NullTypes.BoolNT RecuperatoEqualThis, SiarLibrary.NullTypes.BoolNT StabilitaEqualThis)

		{

			RevocaCollection RevocaCollectionObj = new RevocaCollection();

			IDbCommand findCmd = db.InitCmd("Zrevocafindselect", new string[] {"IdRevocaequalthis", "IdProgettoequalthis", "IdImpresaequalthis",
"Origineequalthis", "Noteequalthis", "ImportoRevocaequalthis",
"IdAttoequalthis", "NumeroAttoequalthis", "DataAttoequalthis",
"RecuperoBeneficiarioequalthis", "RevocaContributoequalthis", "ImportoDaRecuperareequalthis",
"InteressiLegaliequalthis", "SpeseNotificaequalthis", "Sanzioniequalthis",
"Totaleequalthis", "ImportoRecuperatoequalthis", "Irrecuperabileequalthis",
"DataIrrecuperabileequalthis", "ImportoIrrecuperabileequalthis", "DataModificaequalthis",
"Recuperatoequalthis", "Stabilitaequalthis"}, new string[] {"int", "int", "int",
"string", "string", "decimal",
"int", "string", "DateTime",
"bool", "bool", "decimal",
"decimal", "decimal", "decimal",
"decimal", "decimal", "bool",
"DateTime", "decimal", "DateTime",
"bool", "bool"}, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdRevocaequalthis", IdRevocaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Origineequalthis", OrigineEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Noteequalthis", NoteEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoRevocaequalthis", ImportoRevocaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdAttoequalthis", IdAttoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "NumeroAttoequalthis", NumeroAttoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataAttoequalthis", DataAttoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "RecuperoBeneficiarioequalthis", RecuperoBeneficiarioEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "RevocaContributoequalthis", RevocaContributoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoDaRecuperareequalthis", ImportoDaRecuperareEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "InteressiLegaliequalthis", InteressiLegaliEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SpeseNotificaequalthis", SpeseNotificaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Sanzioniequalthis", SanzioniEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Totaleequalthis", TotaleEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoRecuperatoequalthis", ImportoRecuperatoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Irrecuperabileequalthis", IrrecuperabileEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataIrrecuperabileequalthis", DataIrrecuperabileEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoIrrecuperabileequalthis", ImportoIrrecuperabileEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Recuperatoequalthis", RecuperatoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Stabilitaequalthis", StabilitaEqualThis);
			Revoca RevocaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RevocaObj = GetFromDatareader(db);
				RevocaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RevocaObj.IsDirty = false;
				RevocaObj.IsPersistent = true;
				RevocaCollectionObj.Add(RevocaObj);
			}
			db.Close();
			return RevocaCollectionObj;
		}

		//Find Find

		public static RevocaCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdRevocaEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis)

		{

			RevocaCollection RevocaCollectionObj = new RevocaCollection();

			IDbCommand findCmd = db.InitCmd("Zrevocafindfind", new string[] { "IdRevocaequalthis", "IdProgettoequalthis", "IdImpresaequalthis" }, new string[] { "int", "int", "int" }, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdRevocaequalthis", IdRevocaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			Revoca RevocaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RevocaObj = GetFromDatareader(db);
				RevocaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RevocaObj.IsDirty = false;
				RevocaObj.IsPersistent = true;
				RevocaCollectionObj.Add(RevocaObj);
			}
			db.Close();
			return RevocaCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for RevocaCollectionProvider:IRevocaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RevocaCollectionProvider : IRevocaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di Revoca
		protected RevocaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public RevocaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new RevocaCollection(this);
		}

		//Costruttore 2: popola la collection
		public RevocaCollectionProvider(IntNT IdrevocaEqualThis, IntNT IdprogettoEqualThis, IntNT IdimpresaEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdrevocaEqualThis, IdprogettoEqualThis, IdimpresaEqualThis);
		}

		//Costruttore3: ha in input revocaCollectionObj - non popola la collection
		public RevocaCollectionProvider(RevocaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public RevocaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new RevocaCollection(this);
		}

		//Get e Set
		public RevocaCollection CollectionObj
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
		public int SaveCollection(RevocaCollection collectionObj)
		{
			return RevocaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(Revoca revocaObj)
		{
			return RevocaDAL.Save(_dbProviderObj, revocaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(RevocaCollection collectionObj)
		{
			return RevocaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(Revoca revocaObj)
		{
			return RevocaDAL.Delete(_dbProviderObj, revocaObj);
		}

		//getById
		public Revoca GetById(IntNT IdRevocaValue)
		{
			Revoca RevocaTemp = RevocaDAL.GetById(_dbProviderObj, IdRevocaValue);
			if (RevocaTemp != null) RevocaTemp.Provider = this;
			return RevocaTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public RevocaCollection Select(IntNT IdrevocaEqualThis, IntNT IdprogettoEqualThis, IntNT IdimpresaEqualThis,
StringNT OrigineEqualThis, StringNT NoteEqualThis, DecimalNT ImportorevocaEqualThis,
IntNT IdattoEqualThis, StringNT NumeroattoEqualThis, DatetimeNT DataattoEqualThis,
BoolNT RecuperobeneficiarioEqualThis, BoolNT RevocacontributoEqualThis, DecimalNT ImportodarecuperareEqualThis,
DecimalNT InteressilegaliEqualThis, DecimalNT SpesenotificaEqualThis, DecimalNT SanzioniEqualThis,
DecimalNT TotaleEqualThis, DecimalNT ImportorecuperatoEqualThis, BoolNT IrrecuperabileEqualThis,
DatetimeNT DatairrecuperabileEqualThis, DecimalNT ImportoirrecuperabileEqualThis, DatetimeNT DatamodificaEqualThis,
BoolNT RecuperatoEqualThis, BoolNT StabilitaEqualThis)
		{
			RevocaCollection RevocaCollectionTemp = RevocaDAL.Select(_dbProviderObj, IdrevocaEqualThis, IdprogettoEqualThis, IdimpresaEqualThis,
OrigineEqualThis, NoteEqualThis, ImportorevocaEqualThis,
IdattoEqualThis, NumeroattoEqualThis, DataattoEqualThis,
RecuperobeneficiarioEqualThis, RevocacontributoEqualThis, ImportodarecuperareEqualThis,
InteressilegaliEqualThis, SpesenotificaEqualThis, SanzioniEqualThis,
TotaleEqualThis, ImportorecuperatoEqualThis, IrrecuperabileEqualThis,
DatairrecuperabileEqualThis, ImportoirrecuperabileEqualThis, DatamodificaEqualThis,
RecuperatoEqualThis, StabilitaEqualThis);
			RevocaCollectionTemp.Provider = this;
			return RevocaCollectionTemp;
		}

		//Find: popola la collection
		public RevocaCollection Find(IntNT IdrevocaEqualThis, IntNT IdprogettoEqualThis, IntNT IdimpresaEqualThis)
		{
			RevocaCollection RevocaCollectionTemp = RevocaDAL.Find(_dbProviderObj, IdrevocaEqualThis, IdprogettoEqualThis, IdimpresaEqualThis);
			RevocaCollectionTemp.Provider = this;
			return RevocaCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<REVOCA>
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
      <ID_REVOCA>Equal</ID_REVOCA>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</REVOCA>
*/
