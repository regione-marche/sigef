using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per AssociazioneDecertificazioniCertificazioneSpesaFittizie
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IAssociazioneDecertificazioniCertificazioneSpesaFittizieProvider
	{
		int Save(AssociazioneDecertificazioniCertificazioneSpesaFittizie AssociazioneDecertificazioniCertificazioneSpesaFittizieObj);
		int SaveCollection(AssociazioneDecertificazioniCertificazioneSpesaFittizieCollection collectionObj);
		int Delete(AssociazioneDecertificazioniCertificazioneSpesaFittizie AssociazioneDecertificazioniCertificazioneSpesaFittizieObj);
		int DeleteCollection(AssociazioneDecertificazioniCertificazioneSpesaFittizieCollection collectionObj);
	}
	/// <summary>
	/// Summary description for AssociazioneDecertificazioniCertificazioneSpesaFittizie
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class AssociazioneDecertificazioniCertificazioneSpesaFittizie: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdAssociazioneDecertificazioniCertificazioneSpesaFittizie;
		private NullTypes.IntNT _IdcertspDettaglio;
		private NullTypes.IntNT _IdCertDecertificazione;
		private NullTypes.StringNT _OperatoreInserimento;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.StringNT _OperatoreModifica;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.IntNT _Idcertsp;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdDomandaPagamento;
		[NonSerialized] private IAssociazioneDecertificazioniCertificazioneSpesaFittizieProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IAssociazioneDecertificazioniCertificazioneSpesaFittizieProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public AssociazioneDecertificazioniCertificazioneSpesaFittizie()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_ASSOCIAZIONE_DECERTIFICAZIONI_CERTIFICAZIONE_SPESA_FITTIZIE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdAssociazioneDecertificazioniCertificazioneSpesaFittizie
		{
			get { return _IdAssociazioneDecertificazioniCertificazioneSpesaFittizie; }
			set {
				if (IdAssociazioneDecertificazioniCertificazioneSpesaFittizie != value)
				{
					_IdAssociazioneDecertificazioniCertificazioneSpesaFittizie = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IdCertSp_Dettaglio
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdcertspDettaglio
		{
			get { return _IdcertspDettaglio; }
			set {
				if (IdcertspDettaglio != value)
				{
					_IdcertspDettaglio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_CERT_DECERTIFICAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdCertDecertificazione
		{
			get { return _IdCertDecertificazione; }
			set {
				if (IdCertDecertificazione != value)
				{
					_IdCertDecertificazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE_INSERIMENTO
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT OperatoreInserimento
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
		/// Corrisponde al campo:OPERATORE_MODIFICA
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT OperatoreModifica
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
		/// Corrisponde al campo:IdCertSp
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Idcertsp
		{
			get { return _Idcertsp; }
			set {
				if (Idcertsp != value)
				{
					_Idcertsp = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Id_Progetto
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
		/// Corrisponde al campo:Id_Domanda_Pagamento
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
	/// Summary description for AssociazioneDecertificazioniCertificazioneSpesaFittizieCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class AssociazioneDecertificazioniCertificazioneSpesaFittizieCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private AssociazioneDecertificazioniCertificazioneSpesaFittizieCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((AssociazioneDecertificazioniCertificazioneSpesaFittizie) info.GetValue(i.ToString(),typeof(AssociazioneDecertificazioniCertificazioneSpesaFittizie)));
			}
		}

		//Costruttore
		public AssociazioneDecertificazioniCertificazioneSpesaFittizieCollection()
		{
			this.ItemType = typeof(AssociazioneDecertificazioniCertificazioneSpesaFittizie);
		}

		//Costruttore con provider
		public AssociazioneDecertificazioniCertificazioneSpesaFittizieCollection(IAssociazioneDecertificazioniCertificazioneSpesaFittizieProvider providerObj)
		{
			this.ItemType = typeof(AssociazioneDecertificazioniCertificazioneSpesaFittizie);
			this.Provider = providerObj;
		}

		//Get e Set
		public new AssociazioneDecertificazioniCertificazioneSpesaFittizie this[int index]
		{
			get { return (AssociazioneDecertificazioniCertificazioneSpesaFittizie)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new AssociazioneDecertificazioniCertificazioneSpesaFittizieCollection GetChanges()
		{
			return (AssociazioneDecertificazioniCertificazioneSpesaFittizieCollection) base.GetChanges();
		}

		[NonSerialized] private IAssociazioneDecertificazioniCertificazioneSpesaFittizieProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IAssociazioneDecertificazioniCertificazioneSpesaFittizieProvider Provider
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
		public int Add(AssociazioneDecertificazioniCertificazioneSpesaFittizie AssociazioneDecertificazioniCertificazioneSpesaFittizieObj)
		{
			if (AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.Provider == null) AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.Provider = this.Provider;
			return base.Add(AssociazioneDecertificazioniCertificazioneSpesaFittizieObj);
		}

		//AddCollection
		public void AddCollection(AssociazioneDecertificazioniCertificazioneSpesaFittizieCollection AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionObj)
		{
			foreach (AssociazioneDecertificazioniCertificazioneSpesaFittizie AssociazioneDecertificazioniCertificazioneSpesaFittizieObj in AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionObj)
				this.Add(AssociazioneDecertificazioniCertificazioneSpesaFittizieObj);
		}

		//Insert
		public void Insert(int index, AssociazioneDecertificazioniCertificazioneSpesaFittizie AssociazioneDecertificazioniCertificazioneSpesaFittizieObj)
		{
			if (AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.Provider == null) AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.Provider = this.Provider;
			base.Insert(index, AssociazioneDecertificazioniCertificazioneSpesaFittizieObj);
		}

		//CollectionGetById
		public AssociazioneDecertificazioniCertificazioneSpesaFittizie CollectionGetById(NullTypes.IntNT IdAssociazioneDecertificazioniCertificazioneSpesaFittizieValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdAssociazioneDecertificazioniCertificazioneSpesaFittizie == IdAssociazioneDecertificazioniCertificazioneSpesaFittizieValue))
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
		public AssociazioneDecertificazioniCertificazioneSpesaFittizieCollection SubSelect(NullTypes.IntNT IdAssociazioneDecertificazioniCertificazioneSpesaFittizieEqualThis, NullTypes.IntNT IdcertspDettaglioEqualThis, NullTypes.IntNT IdCertDecertificazioneEqualThis, 
NullTypes.StringNT OperatoreInserimentoEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.StringNT OperatoreModificaEqualThis, 
NullTypes.DatetimeNT DataModificaEqualThis)
		{
			AssociazioneDecertificazioniCertificazioneSpesaFittizieCollection AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionTemp = new AssociazioneDecertificazioniCertificazioneSpesaFittizieCollection();
			foreach (AssociazioneDecertificazioniCertificazioneSpesaFittizie AssociazioneDecertificazioniCertificazioneSpesaFittizieItem in this)
			{
				if (((IdAssociazioneDecertificazioniCertificazioneSpesaFittizieEqualThis == null) || ((AssociazioneDecertificazioniCertificazioneSpesaFittizieItem.IdAssociazioneDecertificazioniCertificazioneSpesaFittizie != null) && (AssociazioneDecertificazioniCertificazioneSpesaFittizieItem.IdAssociazioneDecertificazioniCertificazioneSpesaFittizie.Value == IdAssociazioneDecertificazioniCertificazioneSpesaFittizieEqualThis.Value))) && ((IdcertspDettaglioEqualThis == null) || ((AssociazioneDecertificazioniCertificazioneSpesaFittizieItem.IdcertspDettaglio != null) && (AssociazioneDecertificazioniCertificazioneSpesaFittizieItem.IdcertspDettaglio.Value == IdcertspDettaglioEqualThis.Value))) && ((IdCertDecertificazioneEqualThis == null) || ((AssociazioneDecertificazioniCertificazioneSpesaFittizieItem.IdCertDecertificazione != null) && (AssociazioneDecertificazioniCertificazioneSpesaFittizieItem.IdCertDecertificazione.Value == IdCertDecertificazioneEqualThis.Value))) && 
((OperatoreInserimentoEqualThis == null) || ((AssociazioneDecertificazioniCertificazioneSpesaFittizieItem.OperatoreInserimento != null) && (AssociazioneDecertificazioniCertificazioneSpesaFittizieItem.OperatoreInserimento.Value == OperatoreInserimentoEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((AssociazioneDecertificazioniCertificazioneSpesaFittizieItem.DataInserimento != null) && (AssociazioneDecertificazioniCertificazioneSpesaFittizieItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((OperatoreModificaEqualThis == null) || ((AssociazioneDecertificazioniCertificazioneSpesaFittizieItem.OperatoreModifica != null) && (AssociazioneDecertificazioniCertificazioneSpesaFittizieItem.OperatoreModifica.Value == OperatoreModificaEqualThis.Value))) && 
((DataModificaEqualThis == null) || ((AssociazioneDecertificazioniCertificazioneSpesaFittizieItem.DataModifica != null) && (AssociazioneDecertificazioniCertificazioneSpesaFittizieItem.DataModifica.Value == DataModificaEqualThis.Value))))
				{
					AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionTemp.Add(AssociazioneDecertificazioniCertificazioneSpesaFittizieItem);
				}
			}
			return AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for AssociazioneDecertificazioniCertificazioneSpesaFittizieDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class AssociazioneDecertificazioniCertificazioneSpesaFittizieDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, AssociazioneDecertificazioniCertificazioneSpesaFittizie AssociazioneDecertificazioniCertificazioneSpesaFittizieObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdAssociazioneDecertificazioniCertificazioneSpesaFittizie", AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.IdAssociazioneDecertificazioniCertificazioneSpesaFittizie);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdcertspDettaglio", AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.IdcertspDettaglio);
			DbProvider.SetCmdParam(cmd,firstChar + "IdCertDecertificazione", AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.IdCertDecertificazione);
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreInserimento", AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.OperatoreInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreModifica", AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.OperatoreModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.DataModifica);
		}
		//Insert
		private static int Insert(DbProvider db, AssociazioneDecertificazioniCertificazioneSpesaFittizie AssociazioneDecertificazioniCertificazioneSpesaFittizieObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZAssociazioneDecertificazioniCertificazioneSpesaFittizieInsert", new string[] {"IdcertspDettaglio", "IdCertDecertificazione", 
"OperatoreInserimento", "DataInserimento", "OperatoreModifica", 
"DataModifica", }, new string[] {"int", "int", 
"string", "DateTime", "string", 
"DateTime", },"");
				CompileIUCmd(false, insertCmd,AssociazioneDecertificazioniCertificazioneSpesaFittizieObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.IdAssociazioneDecertificazioniCertificazioneSpesaFittizie = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ASSOCIAZIONE_DECERTIFICAZIONI_CERTIFICAZIONE_SPESA_FITTIZIE"]);
				}
				AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.IsDirty = false;
				AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, AssociazioneDecertificazioniCertificazioneSpesaFittizie AssociazioneDecertificazioniCertificazioneSpesaFittizieObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZAssociazioneDecertificazioniCertificazioneSpesaFittizieUpdate", new string[] {"IdAssociazioneDecertificazioniCertificazioneSpesaFittizie", "IdcertspDettaglio", "IdCertDecertificazione", 
"OperatoreInserimento", "DataInserimento", "OperatoreModifica", 
"DataModifica", }, new string[] {"int", "int", "int", 
"string", "DateTime", "string", 
"DateTime", },"");
				CompileIUCmd(true, updateCmd,AssociazioneDecertificazioniCertificazioneSpesaFittizieObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.DataModifica = d;
				}
				AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.IsDirty = false;
				AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, AssociazioneDecertificazioniCertificazioneSpesaFittizie AssociazioneDecertificazioniCertificazioneSpesaFittizieObj)
		{
			switch (AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, AssociazioneDecertificazioniCertificazioneSpesaFittizieObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, AssociazioneDecertificazioniCertificazioneSpesaFittizieObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,AssociazioneDecertificazioniCertificazioneSpesaFittizieObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, AssociazioneDecertificazioniCertificazioneSpesaFittizieCollection AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZAssociazioneDecertificazioniCertificazioneSpesaFittizieUpdate", new string[] {"IdAssociazioneDecertificazioniCertificazioneSpesaFittizie", "IdcertspDettaglio", "IdCertDecertificazione", 
"OperatoreInserimento", "DataInserimento", "OperatoreModifica", 
"DataModifica", }, new string[] {"int", "int", "int", 
"string", "DateTime", "string", 
"DateTime", },"");
				IDbCommand insertCmd = db.InitCmd( "ZAssociazioneDecertificazioniCertificazioneSpesaFittizieInsert", new string[] {"IdcertspDettaglio", "IdCertDecertificazione", 
"OperatoreInserimento", "DataInserimento", "OperatoreModifica", 
"DataModifica", }, new string[] {"int", "int", 
"string", "DateTime", "string", 
"DateTime", },"");
				IDbCommand deleteCmd = db.InitCmd( "ZAssociazioneDecertificazioniCertificazioneSpesaFittizieDelete", new string[] {"IdAssociazioneDecertificazioniCertificazioneSpesaFittizie"}, new string[] {"int"},"");
				for (int i = 0; i < AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionObj.Count; i++)
				{
					switch (AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionObj[i].IdAssociazioneDecertificazioniCertificazioneSpesaFittizie = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ASSOCIAZIONE_DECERTIFICAZIONI_CERTIFICAZIONE_SPESA_FITTIZIE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdAssociazioneDecertificazioniCertificazioneSpesaFittizie", (SiarLibrary.NullTypes.IntNT)AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionObj[i].IdAssociazioneDecertificazioniCertificazioneSpesaFittizie);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionObj.Count; i++)
				{
					if ((AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionObj[i].IsDirty = false;
						AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionObj[i].IsPersistent = true;
					}
					if ((AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionObj[i].IsDirty = false;
						AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, AssociazioneDecertificazioniCertificazioneSpesaFittizie AssociazioneDecertificazioniCertificazioneSpesaFittizieObj)
		{
			int returnValue = 0;
			if (AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.IsPersistent) 
			{
				returnValue = Delete(db, AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.IdAssociazioneDecertificazioniCertificazioneSpesaFittizie);
			}
			AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.IsDirty = false;
			AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdAssociazioneDecertificazioniCertificazioneSpesaFittizieValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZAssociazioneDecertificazioniCertificazioneSpesaFittizieDelete", new string[] {"IdAssociazioneDecertificazioniCertificazioneSpesaFittizie"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdAssociazioneDecertificazioniCertificazioneSpesaFittizie", (SiarLibrary.NullTypes.IntNT)IdAssociazioneDecertificazioniCertificazioneSpesaFittizieValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, AssociazioneDecertificazioniCertificazioneSpesaFittizieCollection AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZAssociazioneDecertificazioniCertificazioneSpesaFittizieDelete", new string[] {"IdAssociazioneDecertificazioniCertificazioneSpesaFittizie"}, new string[] {"int"},"");
				for (int i = 0; i < AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdAssociazioneDecertificazioniCertificazioneSpesaFittizie", AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionObj[i].IdAssociazioneDecertificazioniCertificazioneSpesaFittizie);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionObj.Count; i++)
				{
					if ((AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionObj[i].IsDirty = false;
						AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionObj[i].IsPersistent = false;
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
		public static AssociazioneDecertificazioniCertificazioneSpesaFittizie GetById(DbProvider db, int IdAssociazioneDecertificazioniCertificazioneSpesaFittizieValue)
		{
			AssociazioneDecertificazioniCertificazioneSpesaFittizie AssociazioneDecertificazioniCertificazioneSpesaFittizieObj = null;
			IDbCommand readCmd = db.InitCmd( "ZAssociazioneDecertificazioniCertificazioneSpesaFittizieGetById", new string[] {"IdAssociazioneDecertificazioniCertificazioneSpesaFittizie"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdAssociazioneDecertificazioniCertificazioneSpesaFittizie", (SiarLibrary.NullTypes.IntNT)IdAssociazioneDecertificazioniCertificazioneSpesaFittizieValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				AssociazioneDecertificazioniCertificazioneSpesaFittizieObj = GetFromDatareader(db);
				AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.IsDirty = false;
				AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.IsPersistent = true;
			}
			db.Close();
			return AssociazioneDecertificazioniCertificazioneSpesaFittizieObj;
		}

		//getFromDatareader
		public static AssociazioneDecertificazioniCertificazioneSpesaFittizie GetFromDatareader(DbProvider db)
		{
			AssociazioneDecertificazioniCertificazioneSpesaFittizie AssociazioneDecertificazioniCertificazioneSpesaFittizieObj = new AssociazioneDecertificazioniCertificazioneSpesaFittizie();
			AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.IdAssociazioneDecertificazioniCertificazioneSpesaFittizie = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ASSOCIAZIONE_DECERTIFICAZIONI_CERTIFICAZIONE_SPESA_FITTIZIE"]);
			AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.IdcertspDettaglio = new SiarLibrary.NullTypes.IntNT(db.DataReader["IdCertSp_Dettaglio"]);
			AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.IdCertDecertificazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CERT_DECERTIFICAZIONE"]);
			AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.OperatoreInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE_INSERIMENTO"]);
			AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.OperatoreModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE_MODIFICA"]);
			AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.Idcertsp = new SiarLibrary.NullTypes.IntNT(db.DataReader["IdCertSp"]);
			AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["Id_Progetto"]);
			AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["Id_Domanda_Pagamento"]);
			AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.IsDirty = false;
			AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.IsPersistent = true;
			return AssociazioneDecertificazioniCertificazioneSpesaFittizieObj;
		}

		//Find Select

		public static AssociazioneDecertificazioniCertificazioneSpesaFittizieCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdAssociazioneDecertificazioniCertificazioneSpesaFittizieEqualThis, SiarLibrary.NullTypes.IntNT IdcertspDettaglioEqualThis, SiarLibrary.NullTypes.IntNT IdCertDecertificazioneEqualThis, 
SiarLibrary.NullTypes.StringNT OperatoreInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.StringNT OperatoreModificaEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis)

		{

			AssociazioneDecertificazioniCertificazioneSpesaFittizieCollection AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionObj = new AssociazioneDecertificazioniCertificazioneSpesaFittizieCollection();

			IDbCommand findCmd = db.InitCmd("Zassociazionedecertificazionicertificazionespesafittiziefindselect", new string[] {"IdAssociazioneDecertificazioniCertificazioneSpesaFittizieequalthis", "IdcertspDettaglioequalthis", "IdCertDecertificazioneequalthis", 
"OperatoreInserimentoequalthis", "DataInserimentoequalthis", "OperatoreModificaequalthis", 
"DataModificaequalthis"}, new string[] {"int", "int", "int", 
"string", "DateTime", "string", 
"DateTime"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAssociazioneDecertificazioniCertificazioneSpesaFittizieequalthis", IdAssociazioneDecertificazioniCertificazioneSpesaFittizieEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdcertspDettaglioequalthis", IdcertspDettaglioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCertDecertificazioneequalthis", IdCertDecertificazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreInserimentoequalthis", OperatoreInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreModificaequalthis", OperatoreModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			AssociazioneDecertificazioniCertificazioneSpesaFittizie AssociazioneDecertificazioniCertificazioneSpesaFittizieObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				AssociazioneDecertificazioniCertificazioneSpesaFittizieObj = GetFromDatareader(db);
				AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.IsDirty = false;
				AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.IsPersistent = true;
				AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionObj.Add(AssociazioneDecertificazioniCertificazioneSpesaFittizieObj);
			}
			db.Close();
			return AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionObj;
		}

		//Find FindByLottoCertificazioneSpesa

		public static AssociazioneDecertificazioniCertificazioneSpesaFittizieCollection FindByLottoCertificazioneSpesa(DbProvider db, SiarLibrary.NullTypes.IntNT IdcertspEqualThis, SiarLibrary.NullTypes.IntNT IdcertspDettaglioEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, 
SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis)

		{

			AssociazioneDecertificazioniCertificazioneSpesaFittizieCollection AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionObj = new AssociazioneDecertificazioniCertificazioneSpesaFittizieCollection();

			IDbCommand findCmd = db.InitCmd("Zassociazionedecertificazionicertificazionespesafittiziefindfindbylottocertificazionespesa", new string[] {"Idcertspequalthis", "IdcertspDettaglioequalthis", "IdProgettoequalthis", 
"IdDomandaPagamentoequalthis"}, new string[] {"int", "int", "int", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idcertspequalthis", IdcertspEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdcertspDettaglioequalthis", IdcertspDettaglioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			AssociazioneDecertificazioniCertificazioneSpesaFittizie AssociazioneDecertificazioniCertificazioneSpesaFittizieObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				AssociazioneDecertificazioniCertificazioneSpesaFittizieObj = GetFromDatareader(db);
				AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.IsDirty = false;
				AssociazioneDecertificazioniCertificazioneSpesaFittizieObj.IsPersistent = true;
				AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionObj.Add(AssociazioneDecertificazioniCertificazioneSpesaFittizieObj);
			}
			db.Close();
			return AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionProvider:IAssociazioneDecertificazioniCertificazioneSpesaFittizieProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionProvider : IAssociazioneDecertificazioniCertificazioneSpesaFittizieProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di AssociazioneDecertificazioniCertificazioneSpesaFittizie
		protected AssociazioneDecertificazioniCertificazioneSpesaFittizieCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new AssociazioneDecertificazioniCertificazioneSpesaFittizieCollection(this);
		}

		//Costruttore 2: popola la collection
		public AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionProvider(IntNT IdcertspEqualThis, IntNT IdcertspdettaglioEqualThis, IntNT IdprogettoEqualThis, 
IntNT IddomandapagamentoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = FindByLottoCertificazioneSpesa(IdcertspEqualThis, IdcertspdettaglioEqualThis, IdprogettoEqualThis, 
IddomandapagamentoEqualThis);
		}

		//Costruttore3: ha in input associazionedecertificazionicertificazionespesafittizieCollectionObj - non popola la collection
		public AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionProvider(AssociazioneDecertificazioniCertificazioneSpesaFittizieCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new AssociazioneDecertificazioniCertificazioneSpesaFittizieCollection(this);
		}

		//Get e Set
		public AssociazioneDecertificazioniCertificazioneSpesaFittizieCollection CollectionObj
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
		public int SaveCollection(AssociazioneDecertificazioniCertificazioneSpesaFittizieCollection collectionObj)
		{
			return AssociazioneDecertificazioniCertificazioneSpesaFittizieDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(AssociazioneDecertificazioniCertificazioneSpesaFittizie associazionedecertificazionicertificazionespesafittizieObj)
		{
			return AssociazioneDecertificazioniCertificazioneSpesaFittizieDAL.Save(_dbProviderObj, associazionedecertificazionicertificazionespesafittizieObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(AssociazioneDecertificazioniCertificazioneSpesaFittizieCollection collectionObj)
		{
			return AssociazioneDecertificazioniCertificazioneSpesaFittizieDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(AssociazioneDecertificazioniCertificazioneSpesaFittizie associazionedecertificazionicertificazionespesafittizieObj)
		{
			return AssociazioneDecertificazioniCertificazioneSpesaFittizieDAL.Delete(_dbProviderObj, associazionedecertificazionicertificazionespesafittizieObj);
		}

		//getById
		public AssociazioneDecertificazioniCertificazioneSpesaFittizie GetById(IntNT IdAssociazioneDecertificazioniCertificazioneSpesaFittizieValue)
		{
			AssociazioneDecertificazioniCertificazioneSpesaFittizie AssociazioneDecertificazioniCertificazioneSpesaFittizieTemp = AssociazioneDecertificazioniCertificazioneSpesaFittizieDAL.GetById(_dbProviderObj, IdAssociazioneDecertificazioniCertificazioneSpesaFittizieValue);
			if (AssociazioneDecertificazioniCertificazioneSpesaFittizieTemp!=null) AssociazioneDecertificazioniCertificazioneSpesaFittizieTemp.Provider = this;
			return AssociazioneDecertificazioniCertificazioneSpesaFittizieTemp;
		}

		//Select: popola la collection
		public AssociazioneDecertificazioniCertificazioneSpesaFittizieCollection Select(IntNT IdassociazionedecertificazionicertificazionespesafittizieEqualThis, IntNT IdcertspdettaglioEqualThis, IntNT IdcertdecertificazioneEqualThis, 
StringNT OperatoreinserimentoEqualThis, DatetimeNT DatainserimentoEqualThis, StringNT OperatoremodificaEqualThis, 
DatetimeNT DatamodificaEqualThis)
		{
			AssociazioneDecertificazioniCertificazioneSpesaFittizieCollection AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionTemp = AssociazioneDecertificazioniCertificazioneSpesaFittizieDAL.Select(_dbProviderObj, IdassociazionedecertificazionicertificazionespesafittizieEqualThis, IdcertspdettaglioEqualThis, IdcertdecertificazioneEqualThis, 
OperatoreinserimentoEqualThis, DatainserimentoEqualThis, OperatoremodificaEqualThis, 
DatamodificaEqualThis);
			AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionTemp.Provider = this;
			return AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionTemp;
		}

		//FindByLottoCertificazioneSpesa: popola la collection
		public AssociazioneDecertificazioniCertificazioneSpesaFittizieCollection FindByLottoCertificazioneSpesa(IntNT IdcertspEqualThis, IntNT IdcertspdettaglioEqualThis, IntNT IdprogettoEqualThis, 
IntNT IddomandapagamentoEqualThis)
		{
			AssociazioneDecertificazioniCertificazioneSpesaFittizieCollection AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionTemp = AssociazioneDecertificazioniCertificazioneSpesaFittizieDAL.FindByLottoCertificazioneSpesa(_dbProviderObj, IdcertspEqualThis, IdcertspdettaglioEqualThis, IdprogettoEqualThis, 
IddomandapagamentoEqualThis);
			AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionTemp.Provider = this;
			return AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<ASSOCIAZIONE_DECERTIFICAZIONI_CERTIFICAZIONE_SPESA_FITTIZIE>
  <ViewName>VASSOCIAZIONE_DECERTIFICAZIONI_CERTIFICAZIONE_SPESA_FITTIZIE</ViewName>
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
    <FindByLottoCertificazioneSpesa OrderBy="ORDER BY ">
      <IdCertSp>Equal</IdCertSp>
      <IdCertSp_Dettaglio>Equal</IdCertSp_Dettaglio>
      <Id_Progetto>Equal</Id_Progetto>
      <Id_Domanda_Pagamento>Equal</Id_Domanda_Pagamento>
    </FindByLottoCertificazioneSpesa>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</ASSOCIAZIONE_DECERTIFICAZIONI_CERTIFICAZIONE_SPESA_FITTIZIE>
*/
