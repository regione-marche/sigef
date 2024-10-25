using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per RichiestaConsulenteProcuraXBando
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IRichiestaConsulenteProcuraXBandoProvider
	{
		int Save(RichiestaConsulenteProcuraXBando RichiestaConsulenteProcuraXBandoObj);
		int SaveCollection(RichiestaConsulenteProcuraXBandoCollection collectionObj);
		int Delete(RichiestaConsulenteProcuraXBando RichiestaConsulenteProcuraXBandoObj);
		int DeleteCollection(RichiestaConsulenteProcuraXBandoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for RichiestaConsulenteProcuraXBando
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class RichiestaConsulenteProcuraXBando: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdRichiestaConsulente;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.IntNT _IdConsulente;
		private NullTypes.IntNT _IdBando;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.DatetimeNT _DataIstruttoria;
		private NullTypes.DatetimeNT _DataInizio;
		private NullTypes.DatetimeNT _DataFine;
		private NullTypes.IntNT _OperatoreInserimento;
		private NullTypes.IntNT _OperatoreIstruttoria;
		private NullTypes.StringNT _MotivazioneRifiuto;
		private NullTypes.IntNT _OperatoreRevoca;
		private NullTypes.StringNT _Segnatura;
		private NullTypes.StringNT _SegnaturaIstruttoria;
		private NullTypes.BoolNT _Inviata;
		private NullTypes.BoolNT _Istruita;
		private NullTypes.BoolNT _Approvata;
		private NullTypes.BoolNT _Attivo;
		[NonSerialized] private IRichiestaConsulenteProcuraXBandoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRichiestaConsulenteProcuraXBandoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public RichiestaConsulenteProcuraXBando()
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
		/// Corrisponde al campo:ID_RICHIESTA_CONSULENTE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdRichiestaConsulente
		{
			get { return _IdRichiestaConsulente; }
			set {
				if (IdRichiestaConsulente != value)
				{
					_IdRichiestaConsulente = value;
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
		/// Corrisponde al campo:ID_CONSULENTE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdConsulente
		{
			get { return _IdConsulente; }
			set {
				if (IdConsulente != value)
				{
					_IdConsulente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_BANDO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdBando
		{
			get { return _IdBando; }
			set {
				if (IdBando != value)
				{
					_IdBando = value;
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
		/// Corrisponde al campo:DATA_ISTRUTTORIA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataIstruttoria
		{
			get { return _DataIstruttoria; }
			set {
				if (DataIstruttoria != value)
				{
					_DataIstruttoria = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_INIZIO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataInizio
		{
			get { return _DataInizio; }
			set {
				if (DataInizio != value)
				{
					_DataInizio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_FINE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataFine
		{
			get { return _DataFine; }
			set {
				if (DataFine != value)
				{
					_DataFine = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE_INSERIMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OperatoreInserimento
		{
			get { return _OperatoreInserimento; }
			set {
				if (OperatoreInserimento != value)
				{
					_OperatoreInserimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE_ISTRUTTORIA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OperatoreIstruttoria
		{
			get { return _OperatoreIstruttoria; }
			set {
				if (OperatoreIstruttoria != value)
				{
					_OperatoreIstruttoria = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MOTIVAZIONE_RIFIUTO
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT MotivazioneRifiuto
		{
			get { return _MotivazioneRifiuto; }
			set {
				if (MotivazioneRifiuto != value)
				{
					_MotivazioneRifiuto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE_REVOCA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OperatoreRevoca
		{
			get { return _OperatoreRevoca; }
			set {
				if (OperatoreRevoca != value)
				{
					_OperatoreRevoca = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SEGNATURA
		/// Tipo sul db:VARCHAR(200)
		/// </summary>
		public NullTypes.StringNT Segnatura
		{
			get { return _Segnatura; }
			set {
				if (Segnatura != value)
				{
					_Segnatura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SEGNATURA_ISTRUTTORIA
		/// Tipo sul db:VARCHAR(200)
		/// </summary>
		public NullTypes.StringNT SegnaturaIstruttoria
		{
			get { return _SegnaturaIstruttoria; }
			set {
				if (SegnaturaIstruttoria != value)
				{
					_SegnaturaIstruttoria = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:INVIATA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Inviata
		{
			get { return _Inviata; }
			set {
				if (Inviata != value)
				{
					_Inviata = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ISTRUITA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Istruita
		{
			get { return _Istruita; }
			set {
				if (Istruita != value)
				{
					_Istruita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:APPROVATA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Approvata
		{
			get { return _Approvata; }
			set {
				if (Approvata != value)
				{
					_Approvata = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ATTIVO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Attivo
		{
			get { return _Attivo; }
			set {
				if (Attivo != value)
				{
					_Attivo = value;
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
	/// Summary description for RichiestaConsulenteProcuraXBandoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RichiestaConsulenteProcuraXBandoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private RichiestaConsulenteProcuraXBandoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((RichiestaConsulenteProcuraXBando) info.GetValue(i.ToString(),typeof(RichiestaConsulenteProcuraXBando)));
			}
		}

		//Costruttore
		public RichiestaConsulenteProcuraXBandoCollection()
		{
			this.ItemType = typeof(RichiestaConsulenteProcuraXBando);
		}

		//Costruttore con provider
		public RichiestaConsulenteProcuraXBandoCollection(IRichiestaConsulenteProcuraXBandoProvider providerObj)
		{
			this.ItemType = typeof(RichiestaConsulenteProcuraXBando);
			this.Provider = providerObj;
		}

		//Get e Set
		public new RichiestaConsulenteProcuraXBando this[int index]
		{
			get { return (RichiestaConsulenteProcuraXBando)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new RichiestaConsulenteProcuraXBandoCollection GetChanges()
		{
			return (RichiestaConsulenteProcuraXBandoCollection) base.GetChanges();
		}

		[NonSerialized] private IRichiestaConsulenteProcuraXBandoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRichiestaConsulenteProcuraXBandoProvider Provider
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
		public int Add(RichiestaConsulenteProcuraXBando RichiestaConsulenteProcuraXBandoObj)
		{
			if (RichiestaConsulenteProcuraXBandoObj.Provider == null) RichiestaConsulenteProcuraXBandoObj.Provider = this.Provider;
			return base.Add(RichiestaConsulenteProcuraXBandoObj);
		}

		//AddCollection
		public void AddCollection(RichiestaConsulenteProcuraXBandoCollection RichiestaConsulenteProcuraXBandoCollectionObj)
		{
			foreach (RichiestaConsulenteProcuraXBando RichiestaConsulenteProcuraXBandoObj in RichiestaConsulenteProcuraXBandoCollectionObj)
				this.Add(RichiestaConsulenteProcuraXBandoObj);
		}

		//Insert
		public void Insert(int index, RichiestaConsulenteProcuraXBando RichiestaConsulenteProcuraXBandoObj)
		{
			if (RichiestaConsulenteProcuraXBandoObj.Provider == null) RichiestaConsulenteProcuraXBandoObj.Provider = this.Provider;
			base.Insert(index, RichiestaConsulenteProcuraXBandoObj);
		}

		//CollectionGetById
		public RichiestaConsulenteProcuraXBando CollectionGetById(NullTypes.IntNT IdValue)
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
		public RichiestaConsulenteProcuraXBandoCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdRichiestaConsulenteEqualThis, NullTypes.IntNT IdImpresaEqualThis, 
NullTypes.IntNT IdConsulenteEqualThis, NullTypes.IntNT IdBandoEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, 
NullTypes.DatetimeNT DataIstruttoriaEqualThis, NullTypes.DatetimeNT DataInizioEqualThis, NullTypes.DatetimeNT DataFineEqualThis, 
NullTypes.IntNT OperatoreInserimentoEqualThis, NullTypes.IntNT OperatoreIstruttoriaEqualThis, NullTypes.StringNT MotivazioneRifiutoEqualThis, 
NullTypes.IntNT OperatoreRevocaEqualThis, NullTypes.StringNT SegnaturaEqualThis, NullTypes.StringNT SegnaturaIstruttoriaEqualThis, 
NullTypes.BoolNT InviataEqualThis, NullTypes.BoolNT IstruitaEqualThis, NullTypes.BoolNT ApprovataEqualThis, 
NullTypes.BoolNT AttivoEqualThis)
		{
			RichiestaConsulenteProcuraXBandoCollection RichiestaConsulenteProcuraXBandoCollectionTemp = new RichiestaConsulenteProcuraXBandoCollection();
			foreach (RichiestaConsulenteProcuraXBando RichiestaConsulenteProcuraXBandoItem in this)
			{
				if (((IdEqualThis == null) || ((RichiestaConsulenteProcuraXBandoItem.Id != null) && (RichiestaConsulenteProcuraXBandoItem.Id.Value == IdEqualThis.Value))) && ((IdRichiestaConsulenteEqualThis == null) || ((RichiestaConsulenteProcuraXBandoItem.IdRichiestaConsulente != null) && (RichiestaConsulenteProcuraXBandoItem.IdRichiestaConsulente.Value == IdRichiestaConsulenteEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((RichiestaConsulenteProcuraXBandoItem.IdImpresa != null) && (RichiestaConsulenteProcuraXBandoItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && 
((IdConsulenteEqualThis == null) || ((RichiestaConsulenteProcuraXBandoItem.IdConsulente != null) && (RichiestaConsulenteProcuraXBandoItem.IdConsulente.Value == IdConsulenteEqualThis.Value))) && ((IdBandoEqualThis == null) || ((RichiestaConsulenteProcuraXBandoItem.IdBando != null) && (RichiestaConsulenteProcuraXBandoItem.IdBando.Value == IdBandoEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((RichiestaConsulenteProcuraXBandoItem.DataInserimento != null) && (RichiestaConsulenteProcuraXBandoItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && 
((DataIstruttoriaEqualThis == null) || ((RichiestaConsulenteProcuraXBandoItem.DataIstruttoria != null) && (RichiestaConsulenteProcuraXBandoItem.DataIstruttoria.Value == DataIstruttoriaEqualThis.Value))) && ((DataInizioEqualThis == null) || ((RichiestaConsulenteProcuraXBandoItem.DataInizio != null) && (RichiestaConsulenteProcuraXBandoItem.DataInizio.Value == DataInizioEqualThis.Value))) && ((DataFineEqualThis == null) || ((RichiestaConsulenteProcuraXBandoItem.DataFine != null) && (RichiestaConsulenteProcuraXBandoItem.DataFine.Value == DataFineEqualThis.Value))) && 
((OperatoreInserimentoEqualThis == null) || ((RichiestaConsulenteProcuraXBandoItem.OperatoreInserimento != null) && (RichiestaConsulenteProcuraXBandoItem.OperatoreInserimento.Value == OperatoreInserimentoEqualThis.Value))) && ((OperatoreIstruttoriaEqualThis == null) || ((RichiestaConsulenteProcuraXBandoItem.OperatoreIstruttoria != null) && (RichiestaConsulenteProcuraXBandoItem.OperatoreIstruttoria.Value == OperatoreIstruttoriaEqualThis.Value))) && ((MotivazioneRifiutoEqualThis == null) || ((RichiestaConsulenteProcuraXBandoItem.MotivazioneRifiuto != null) && (RichiestaConsulenteProcuraXBandoItem.MotivazioneRifiuto.Value == MotivazioneRifiutoEqualThis.Value))) && 
((OperatoreRevocaEqualThis == null) || ((RichiestaConsulenteProcuraXBandoItem.OperatoreRevoca != null) && (RichiestaConsulenteProcuraXBandoItem.OperatoreRevoca.Value == OperatoreRevocaEqualThis.Value))) && ((SegnaturaEqualThis == null) || ((RichiestaConsulenteProcuraXBandoItem.Segnatura != null) && (RichiestaConsulenteProcuraXBandoItem.Segnatura.Value == SegnaturaEqualThis.Value))) && ((SegnaturaIstruttoriaEqualThis == null) || ((RichiestaConsulenteProcuraXBandoItem.SegnaturaIstruttoria != null) && (RichiestaConsulenteProcuraXBandoItem.SegnaturaIstruttoria.Value == SegnaturaIstruttoriaEqualThis.Value))) && 
((InviataEqualThis == null) || ((RichiestaConsulenteProcuraXBandoItem.Inviata != null) && (RichiestaConsulenteProcuraXBandoItem.Inviata.Value == InviataEqualThis.Value))) && ((IstruitaEqualThis == null) || ((RichiestaConsulenteProcuraXBandoItem.Istruita != null) && (RichiestaConsulenteProcuraXBandoItem.Istruita.Value == IstruitaEqualThis.Value))) && ((ApprovataEqualThis == null) || ((RichiestaConsulenteProcuraXBandoItem.Approvata != null) && (RichiestaConsulenteProcuraXBandoItem.Approvata.Value == ApprovataEqualThis.Value))) && 
((AttivoEqualThis == null) || ((RichiestaConsulenteProcuraXBandoItem.Attivo != null) && (RichiestaConsulenteProcuraXBandoItem.Attivo.Value == AttivoEqualThis.Value))))
				{
					RichiestaConsulenteProcuraXBandoCollectionTemp.Add(RichiestaConsulenteProcuraXBandoItem);
				}
			}
			return RichiestaConsulenteProcuraXBandoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for RichiestaConsulenteProcuraXBandoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class RichiestaConsulenteProcuraXBandoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, RichiestaConsulenteProcuraXBando RichiestaConsulenteProcuraXBandoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", RichiestaConsulenteProcuraXBandoObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdRichiestaConsulente", RichiestaConsulenteProcuraXBandoObj.IdRichiestaConsulente);
			DbProvider.SetCmdParam(cmd,firstChar + "IdImpresa", RichiestaConsulenteProcuraXBandoObj.IdImpresa);
			DbProvider.SetCmdParam(cmd,firstChar + "IdConsulente", RichiestaConsulenteProcuraXBandoObj.IdConsulente);
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", RichiestaConsulenteProcuraXBandoObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", RichiestaConsulenteProcuraXBandoObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataIstruttoria", RichiestaConsulenteProcuraXBandoObj.DataIstruttoria);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInizio", RichiestaConsulenteProcuraXBandoObj.DataInizio);
			DbProvider.SetCmdParam(cmd,firstChar + "DataFine", RichiestaConsulenteProcuraXBandoObj.DataFine);
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreInserimento", RichiestaConsulenteProcuraXBandoObj.OperatoreInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreIstruttoria", RichiestaConsulenteProcuraXBandoObj.OperatoreIstruttoria);
			DbProvider.SetCmdParam(cmd,firstChar + "MotivazioneRifiuto", RichiestaConsulenteProcuraXBandoObj.MotivazioneRifiuto);
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreRevoca", RichiestaConsulenteProcuraXBandoObj.OperatoreRevoca);
			DbProvider.SetCmdParam(cmd,firstChar + "Segnatura", RichiestaConsulenteProcuraXBandoObj.Segnatura);
			DbProvider.SetCmdParam(cmd,firstChar + "SegnaturaIstruttoria", RichiestaConsulenteProcuraXBandoObj.SegnaturaIstruttoria);
			DbProvider.SetCmdParam(cmd,firstChar + "Inviata", RichiestaConsulenteProcuraXBandoObj.Inviata);
			DbProvider.SetCmdParam(cmd,firstChar + "Istruita", RichiestaConsulenteProcuraXBandoObj.Istruita);
			DbProvider.SetCmdParam(cmd,firstChar + "Approvata", RichiestaConsulenteProcuraXBandoObj.Approvata);
			DbProvider.SetCmdParam(cmd,firstChar + "Attivo", RichiestaConsulenteProcuraXBandoObj.Attivo);
		}
		//Insert
		private static int Insert(DbProvider db, RichiestaConsulenteProcuraXBando RichiestaConsulenteProcuraXBandoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZRichiestaConsulenteProcuraXBandoInsert", new string[] {"IdRichiestaConsulente", "IdImpresa", 
"IdConsulente", "IdBando", "DataInserimento", 
"DataIstruttoria", "DataInizio", "DataFine", 
"OperatoreInserimento", "OperatoreIstruttoria", "MotivazioneRifiuto", 
"OperatoreRevoca", "Segnatura", "SegnaturaIstruttoria", 
"Inviata", "Istruita", "Approvata", 
"Attivo"}, new string[] {"int", "int", 
"int", "int", "DateTime", 
"DateTime", "DateTime", "DateTime", 
"int", "int", "string", 
"int", "string", "string", 
"bool", "bool", "bool", 
"bool"},"");
				CompileIUCmd(false, insertCmd,RichiestaConsulenteProcuraXBandoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				RichiestaConsulenteProcuraXBandoObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				RichiestaConsulenteProcuraXBandoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RichiestaConsulenteProcuraXBandoObj.IsDirty = false;
				RichiestaConsulenteProcuraXBandoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, RichiestaConsulenteProcuraXBando RichiestaConsulenteProcuraXBandoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRichiestaConsulenteProcuraXBandoUpdate", new string[] {"Id", "IdRichiestaConsulente", "IdImpresa", 
"IdConsulente", "IdBando", "DataInserimento", 
"DataIstruttoria", "DataInizio", "DataFine", 
"OperatoreInserimento", "OperatoreIstruttoria", "MotivazioneRifiuto", 
"OperatoreRevoca", "Segnatura", "SegnaturaIstruttoria", 
"Inviata", "Istruita", "Approvata", 
"Attivo"}, new string[] {"int", "int", "int", 
"int", "int", "DateTime", 
"DateTime", "DateTime", "DateTime", 
"int", "int", "string", 
"int", "string", "string", 
"bool", "bool", "bool", 
"bool"},"");
				CompileIUCmd(true, updateCmd,RichiestaConsulenteProcuraXBandoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				RichiestaConsulenteProcuraXBandoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RichiestaConsulenteProcuraXBandoObj.IsDirty = false;
				RichiestaConsulenteProcuraXBandoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, RichiestaConsulenteProcuraXBando RichiestaConsulenteProcuraXBandoObj)
		{
			switch (RichiestaConsulenteProcuraXBandoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, RichiestaConsulenteProcuraXBandoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, RichiestaConsulenteProcuraXBandoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,RichiestaConsulenteProcuraXBandoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, RichiestaConsulenteProcuraXBandoCollection RichiestaConsulenteProcuraXBandoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRichiestaConsulenteProcuraXBandoUpdate", new string[] {"Id", "IdRichiestaConsulente", "IdImpresa", 
"IdConsulente", "IdBando", "DataInserimento", 
"DataIstruttoria", "DataInizio", "DataFine", 
"OperatoreInserimento", "OperatoreIstruttoria", "MotivazioneRifiuto", 
"OperatoreRevoca", "Segnatura", "SegnaturaIstruttoria", 
"Inviata", "Istruita", "Approvata", 
"Attivo"}, new string[] {"int", "int", "int", 
"int", "int", "DateTime", 
"DateTime", "DateTime", "DateTime", 
"int", "int", "string", 
"int", "string", "string", 
"bool", "bool", "bool", 
"bool"},"");
				IDbCommand insertCmd = db.InitCmd( "ZRichiestaConsulenteProcuraXBandoInsert", new string[] {"IdRichiestaConsulente", "IdImpresa", 
"IdConsulente", "IdBando", "DataInserimento", 
"DataIstruttoria", "DataInizio", "DataFine", 
"OperatoreInserimento", "OperatoreIstruttoria", "MotivazioneRifiuto", 
"OperatoreRevoca", "Segnatura", "SegnaturaIstruttoria", 
"Inviata", "Istruita", "Approvata", 
"Attivo"}, new string[] {"int", "int", 
"int", "int", "DateTime", 
"DateTime", "DateTime", "DateTime", 
"int", "int", "string", 
"int", "string", "string", 
"bool", "bool", "bool", 
"bool"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZRichiestaConsulenteProcuraXBandoDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < RichiestaConsulenteProcuraXBandoCollectionObj.Count; i++)
				{
					switch (RichiestaConsulenteProcuraXBandoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,RichiestaConsulenteProcuraXBandoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									RichiestaConsulenteProcuraXBandoCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,RichiestaConsulenteProcuraXBandoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (RichiestaConsulenteProcuraXBandoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)RichiestaConsulenteProcuraXBandoCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < RichiestaConsulenteProcuraXBandoCollectionObj.Count; i++)
				{
					if ((RichiestaConsulenteProcuraXBandoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RichiestaConsulenteProcuraXBandoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RichiestaConsulenteProcuraXBandoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						RichiestaConsulenteProcuraXBandoCollectionObj[i].IsDirty = false;
						RichiestaConsulenteProcuraXBandoCollectionObj[i].IsPersistent = true;
					}
					if ((RichiestaConsulenteProcuraXBandoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						RichiestaConsulenteProcuraXBandoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RichiestaConsulenteProcuraXBandoCollectionObj[i].IsDirty = false;
						RichiestaConsulenteProcuraXBandoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, RichiestaConsulenteProcuraXBando RichiestaConsulenteProcuraXBandoObj)
		{
			int returnValue = 0;
			if (RichiestaConsulenteProcuraXBandoObj.IsPersistent) 
			{
				returnValue = Delete(db, RichiestaConsulenteProcuraXBandoObj.Id);
			}
			RichiestaConsulenteProcuraXBandoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			RichiestaConsulenteProcuraXBandoObj.IsDirty = false;
			RichiestaConsulenteProcuraXBandoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRichiestaConsulenteProcuraXBandoDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, RichiestaConsulenteProcuraXBandoCollection RichiestaConsulenteProcuraXBandoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRichiestaConsulenteProcuraXBandoDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < RichiestaConsulenteProcuraXBandoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", RichiestaConsulenteProcuraXBandoCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < RichiestaConsulenteProcuraXBandoCollectionObj.Count; i++)
				{
					if ((RichiestaConsulenteProcuraXBandoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RichiestaConsulenteProcuraXBandoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RichiestaConsulenteProcuraXBandoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RichiestaConsulenteProcuraXBandoCollectionObj[i].IsDirty = false;
						RichiestaConsulenteProcuraXBandoCollectionObj[i].IsPersistent = false;
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
		public static RichiestaConsulenteProcuraXBando GetById(DbProvider db, int IdValue)
		{
			RichiestaConsulenteProcuraXBando RichiestaConsulenteProcuraXBandoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZRichiestaConsulenteProcuraXBandoGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				RichiestaConsulenteProcuraXBandoObj = GetFromDatareader(db);
				RichiestaConsulenteProcuraXBandoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RichiestaConsulenteProcuraXBandoObj.IsDirty = false;
				RichiestaConsulenteProcuraXBandoObj.IsPersistent = true;
			}
			db.Close();
			return RichiestaConsulenteProcuraXBandoObj;
		}

		//getFromDatareader
		public static RichiestaConsulenteProcuraXBando GetFromDatareader(DbProvider db)
		{
			RichiestaConsulenteProcuraXBando RichiestaConsulenteProcuraXBandoObj = new RichiestaConsulenteProcuraXBando();
			RichiestaConsulenteProcuraXBandoObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			RichiestaConsulenteProcuraXBandoObj.IdRichiestaConsulente = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RICHIESTA_CONSULENTE"]);
			RichiestaConsulenteProcuraXBandoObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			RichiestaConsulenteProcuraXBandoObj.IdConsulente = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CONSULENTE"]);
			RichiestaConsulenteProcuraXBandoObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			RichiestaConsulenteProcuraXBandoObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			RichiestaConsulenteProcuraXBandoObj.DataIstruttoria = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_ISTRUTTORIA"]);
			RichiestaConsulenteProcuraXBandoObj.DataInizio = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO"]);
			RichiestaConsulenteProcuraXBandoObj.DataFine = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE"]);
			RichiestaConsulenteProcuraXBandoObj.OperatoreInserimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_INSERIMENTO"]);
			RichiestaConsulenteProcuraXBandoObj.OperatoreIstruttoria = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_ISTRUTTORIA"]);
			RichiestaConsulenteProcuraXBandoObj.MotivazioneRifiuto = new SiarLibrary.NullTypes.StringNT(db.DataReader["MOTIVAZIONE_RIFIUTO"]);
			RichiestaConsulenteProcuraXBandoObj.OperatoreRevoca = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_REVOCA"]);
			RichiestaConsulenteProcuraXBandoObj.Segnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA"]);
			RichiestaConsulenteProcuraXBandoObj.SegnaturaIstruttoria = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_ISTRUTTORIA"]);
			RichiestaConsulenteProcuraXBandoObj.Inviata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["INVIATA"]);
			RichiestaConsulenteProcuraXBandoObj.Istruita = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ISTRUITA"]);
			RichiestaConsulenteProcuraXBandoObj.Approvata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["APPROVATA"]);
			RichiestaConsulenteProcuraXBandoObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
			RichiestaConsulenteProcuraXBandoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			RichiestaConsulenteProcuraXBandoObj.IsDirty = false;
			RichiestaConsulenteProcuraXBandoObj.IsPersistent = true;
			return RichiestaConsulenteProcuraXBandoObj;
		}

		//Find Select

		public static RichiestaConsulenteProcuraXBandoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdRichiestaConsulenteEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, 
SiarLibrary.NullTypes.IntNT IdConsulenteEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataIstruttoriaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInizioEqualThis, SiarLibrary.NullTypes.DatetimeNT DataFineEqualThis, 
SiarLibrary.NullTypes.IntNT OperatoreInserimentoEqualThis, SiarLibrary.NullTypes.IntNT OperatoreIstruttoriaEqualThis, SiarLibrary.NullTypes.StringNT MotivazioneRifiutoEqualThis, 
SiarLibrary.NullTypes.IntNT OperatoreRevocaEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaIstruttoriaEqualThis, 
SiarLibrary.NullTypes.BoolNT InviataEqualThis, SiarLibrary.NullTypes.BoolNT IstruitaEqualThis, SiarLibrary.NullTypes.BoolNT ApprovataEqualThis, 
SiarLibrary.NullTypes.BoolNT AttivoEqualThis)

		{

			RichiestaConsulenteProcuraXBandoCollection RichiestaConsulenteProcuraXBandoCollectionObj = new RichiestaConsulenteProcuraXBandoCollection();

			IDbCommand findCmd = db.InitCmd("Zrichiestaconsulenteprocuraxbandofindselect", new string[] {"Idequalthis", "IdRichiestaConsulenteequalthis", "IdImpresaequalthis", 
"IdConsulenteequalthis", "IdBandoequalthis", "DataInserimentoequalthis", 
"DataIstruttoriaequalthis", "DataInizioequalthis", "DataFineequalthis", 
"OperatoreInserimentoequalthis", "OperatoreIstruttoriaequalthis", "MotivazioneRifiutoequalthis", 
"OperatoreRevocaequalthis", "Segnaturaequalthis", "SegnaturaIstruttoriaequalthis", 
"Inviataequalthis", "Istruitaequalthis", "Approvataequalthis", 
"Attivoequalthis"}, new string[] {"int", "int", "int", 
"int", "int", "DateTime", 
"DateTime", "DateTime", "DateTime", 
"int", "int", "string", 
"int", "string", "string", 
"bool", "bool", "bool", 
"bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRichiestaConsulenteequalthis", IdRichiestaConsulenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdConsulenteequalthis", IdConsulenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataIstruttoriaequalthis", DataIstruttoriaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInizioequalthis", DataInizioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataFineequalthis", DataFineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreInserimentoequalthis", OperatoreInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreIstruttoriaequalthis", OperatoreIstruttoriaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "MotivazioneRifiutoequalthis", MotivazioneRifiutoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreRevocaequalthis", OperatoreRevocaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Segnaturaequalthis", SegnaturaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SegnaturaIstruttoriaequalthis", SegnaturaIstruttoriaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Inviataequalthis", InviataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Istruitaequalthis", IstruitaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Approvataequalthis", ApprovataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			RichiestaConsulenteProcuraXBando RichiestaConsulenteProcuraXBandoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RichiestaConsulenteProcuraXBandoObj = GetFromDatareader(db);
				RichiestaConsulenteProcuraXBandoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RichiestaConsulenteProcuraXBandoObj.IsDirty = false;
				RichiestaConsulenteProcuraXBandoObj.IsPersistent = true;
				RichiestaConsulenteProcuraXBandoCollectionObj.Add(RichiestaConsulenteProcuraXBandoObj);
			}
			db.Close();
			return RichiestaConsulenteProcuraXBandoCollectionObj;
		}

		//Find Find

		public static RichiestaConsulenteProcuraXBandoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdRichiestaConsulenteEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, 
SiarLibrary.NullTypes.IntNT IdConsulenteEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.BoolNT InviataEqualThis, 
SiarLibrary.NullTypes.BoolNT IstruitaEqualThis, SiarLibrary.NullTypes.BoolNT ApprovataEqualThis, SiarLibrary.NullTypes.BoolNT AttivoEqualThis)

		{

			RichiestaConsulenteProcuraXBandoCollection RichiestaConsulenteProcuraXBandoCollectionObj = new RichiestaConsulenteProcuraXBandoCollection();

			IDbCommand findCmd = db.InitCmd("Zrichiestaconsulenteprocuraxbandofindfind", new string[] {"Idequalthis", "IdRichiestaConsulenteequalthis", "IdImpresaequalthis", 
"IdConsulenteequalthis", "IdBandoequalthis", "Inviataequalthis", 
"Istruitaequalthis", "Approvataequalthis", "Attivoequalthis"}, new string[] {"int", "int", "int", 
"int", "int", "bool", 
"bool", "bool", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRichiestaConsulenteequalthis", IdRichiestaConsulenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdConsulenteequalthis", IdConsulenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Inviataequalthis", InviataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Istruitaequalthis", IstruitaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Approvataequalthis", ApprovataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			RichiestaConsulenteProcuraXBando RichiestaConsulenteProcuraXBandoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RichiestaConsulenteProcuraXBandoObj = GetFromDatareader(db);
				RichiestaConsulenteProcuraXBandoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RichiestaConsulenteProcuraXBandoObj.IsDirty = false;
				RichiestaConsulenteProcuraXBandoObj.IsPersistent = true;
				RichiestaConsulenteProcuraXBandoCollectionObj.Add(RichiestaConsulenteProcuraXBandoObj);
			}
			db.Close();
			return RichiestaConsulenteProcuraXBandoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for RichiestaConsulenteProcuraXBandoCollectionProvider:IRichiestaConsulenteProcuraXBandoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RichiestaConsulenteProcuraXBandoCollectionProvider : IRichiestaConsulenteProcuraXBandoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di RichiestaConsulenteProcuraXBando
		protected RichiestaConsulenteProcuraXBandoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public RichiestaConsulenteProcuraXBandoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new RichiestaConsulenteProcuraXBandoCollection(this);
		}

		//Costruttore 2: popola la collection
		public RichiestaConsulenteProcuraXBandoCollectionProvider(IntNT IdEqualThis, IntNT IdrichiestaconsulenteEqualThis, IntNT IdimpresaEqualThis, 
IntNT IdconsulenteEqualThis, IntNT IdbandoEqualThis, BoolNT InviataEqualThis, 
BoolNT IstruitaEqualThis, BoolNT ApprovataEqualThis, BoolNT AttivoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdEqualThis, IdrichiestaconsulenteEqualThis, IdimpresaEqualThis, 
IdconsulenteEqualThis, IdbandoEqualThis, InviataEqualThis, 
IstruitaEqualThis, ApprovataEqualThis, AttivoEqualThis);
		}

		//Costruttore3: ha in input richiestaconsulenteprocuraxbandoCollectionObj - non popola la collection
		public RichiestaConsulenteProcuraXBandoCollectionProvider(RichiestaConsulenteProcuraXBandoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public RichiestaConsulenteProcuraXBandoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new RichiestaConsulenteProcuraXBandoCollection(this);
		}

		//Get e Set
		public RichiestaConsulenteProcuraXBandoCollection CollectionObj
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
		public int SaveCollection(RichiestaConsulenteProcuraXBandoCollection collectionObj)
		{
			return RichiestaConsulenteProcuraXBandoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(RichiestaConsulenteProcuraXBando richiestaconsulenteprocuraxbandoObj)
		{
			return RichiestaConsulenteProcuraXBandoDAL.Save(_dbProviderObj, richiestaconsulenteprocuraxbandoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(RichiestaConsulenteProcuraXBandoCollection collectionObj)
		{
			return RichiestaConsulenteProcuraXBandoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(RichiestaConsulenteProcuraXBando richiestaconsulenteprocuraxbandoObj)
		{
			return RichiestaConsulenteProcuraXBandoDAL.Delete(_dbProviderObj, richiestaconsulenteprocuraxbandoObj);
		}

		//getById
		public RichiestaConsulenteProcuraXBando GetById(IntNT IdValue)
		{
			RichiestaConsulenteProcuraXBando RichiestaConsulenteProcuraXBandoTemp = RichiestaConsulenteProcuraXBandoDAL.GetById(_dbProviderObj, IdValue);
			if (RichiestaConsulenteProcuraXBandoTemp!=null) RichiestaConsulenteProcuraXBandoTemp.Provider = this;
			return RichiestaConsulenteProcuraXBandoTemp;
		}

		//Select: popola la collection
		public RichiestaConsulenteProcuraXBandoCollection Select(IntNT IdEqualThis, IntNT IdrichiestaconsulenteEqualThis, IntNT IdimpresaEqualThis, 
IntNT IdconsulenteEqualThis, IntNT IdbandoEqualThis, DatetimeNT DatainserimentoEqualThis, 
DatetimeNT DataistruttoriaEqualThis, DatetimeNT DatainizioEqualThis, DatetimeNT DatafineEqualThis, 
IntNT OperatoreinserimentoEqualThis, IntNT OperatoreistruttoriaEqualThis, StringNT MotivazionerifiutoEqualThis, 
IntNT OperatorerevocaEqualThis, StringNT SegnaturaEqualThis, StringNT SegnaturaistruttoriaEqualThis, 
BoolNT InviataEqualThis, BoolNT IstruitaEqualThis, BoolNT ApprovataEqualThis, 
BoolNT AttivoEqualThis)
		{
			RichiestaConsulenteProcuraXBandoCollection RichiestaConsulenteProcuraXBandoCollectionTemp = RichiestaConsulenteProcuraXBandoDAL.Select(_dbProviderObj, IdEqualThis, IdrichiestaconsulenteEqualThis, IdimpresaEqualThis, 
IdconsulenteEqualThis, IdbandoEqualThis, DatainserimentoEqualThis, 
DataistruttoriaEqualThis, DatainizioEqualThis, DatafineEqualThis, 
OperatoreinserimentoEqualThis, OperatoreistruttoriaEqualThis, MotivazionerifiutoEqualThis, 
OperatorerevocaEqualThis, SegnaturaEqualThis, SegnaturaistruttoriaEqualThis, 
InviataEqualThis, IstruitaEqualThis, ApprovataEqualThis, 
AttivoEqualThis);
			RichiestaConsulenteProcuraXBandoCollectionTemp.Provider = this;
			return RichiestaConsulenteProcuraXBandoCollectionTemp;
		}

		//Find: popola la collection
		public RichiestaConsulenteProcuraXBandoCollection Find(IntNT IdEqualThis, IntNT IdrichiestaconsulenteEqualThis, IntNT IdimpresaEqualThis, 
IntNT IdconsulenteEqualThis, IntNT IdbandoEqualThis, BoolNT InviataEqualThis, 
BoolNT IstruitaEqualThis, BoolNT ApprovataEqualThis, BoolNT AttivoEqualThis)
		{
			RichiestaConsulenteProcuraXBandoCollection RichiestaConsulenteProcuraXBandoCollectionTemp = RichiestaConsulenteProcuraXBandoDAL.Find(_dbProviderObj, IdEqualThis, IdrichiestaconsulenteEqualThis, IdimpresaEqualThis, 
IdconsulenteEqualThis, IdbandoEqualThis, InviataEqualThis, 
IstruitaEqualThis, ApprovataEqualThis, AttivoEqualThis);
			RichiestaConsulenteProcuraXBandoCollectionTemp.Provider = this;
			return RichiestaConsulenteProcuraXBandoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<RICHIESTA_CONSULENTE_PROCURA_X_BANDO>
  <ViewName>
  </ViewName>
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
    <Find OrderBy="ORDER BY ">
      <ID>Equal</ID>
      <ID_RICHIESTA_CONSULENTE>Equal</ID_RICHIESTA_CONSULENTE>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <ID_CONSULENTE>Equal</ID_CONSULENTE>
      <ID_BANDO>Equal</ID_BANDO>
      <INVIATA>Equal</INVIATA>
      <ISTRUITA>Equal</ISTRUITA>
      <APPROVATA>Equal</APPROVATA>
      <ATTIVO>Equal</ATTIVO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</RICHIESTA_CONSULENTE_PROCURA_X_BANDO>
*/
