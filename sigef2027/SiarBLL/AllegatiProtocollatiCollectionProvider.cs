using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per AllegatiProtocollati
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IAllegatiProtocollatiProvider
	{
		int Save(AllegatiProtocollati AllegatiProtocollatiObj);
		int SaveCollection(AllegatiProtocollatiCollection collectionObj);
		int Delete(AllegatiProtocollati AllegatiProtocollatiObj);
		int DeleteCollection(AllegatiProtocollatiCollection collectionObj);
	}
	/// <summary>
	/// Summary description for AllegatiProtocollati
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class AllegatiProtocollati: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdAllegatoProtocollato;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdDomandaPagamento;
		private NullTypes.IntNT _IdVariante;
		private NullTypes.IntNT _IdIntegrazione;
		private NullTypes.IntNT _IdComunicazione;
		private NullTypes.IntNT _IdFile;
		private NullTypes.BoolNT _Protocollato;
		private NullTypes.StringNT _Protocollo;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.DatetimeNT _DataModifica;
		[NonSerialized] private IAllegatiProtocollatiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IAllegatiProtocollatiProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public AllegatiProtocollati()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_ALLEGATO_PROTOCOLLATO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdAllegatoProtocollato
		{
			get { return _IdAllegatoProtocollato; }
			set {
				if (IdAllegatoProtocollato != value)
				{
					_IdAllegatoProtocollato = value;
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
		/// Corrisponde al campo:ID_VARIANTE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdVariante
		{
			get { return _IdVariante; }
			set {
				if (IdVariante != value)
				{
					_IdVariante = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_INTEGRAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdIntegrazione
		{
			get { return _IdIntegrazione; }
			set {
				if (IdIntegrazione != value)
				{
					_IdIntegrazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_COMUNICAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdComunicazione
		{
			get { return _IdComunicazione; }
			set {
				if (IdComunicazione != value)
				{
					_IdComunicazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_FILE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdFile
		{
			get { return _IdFile; }
			set {
				if (IdFile != value)
				{
					_IdFile = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PROTOCOLLATO
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT Protocollato
		{
			get { return _Protocollato; }
			set {
				if (Protocollato != value)
				{
					_Protocollato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PROTOCOLLO
		/// Tipo sul db:NVARCHAR(100)
		/// </summary>
		public NullTypes.StringNT Protocollo
		{
			get { return _Protocollo; }
			set {
				if (Protocollo != value)
				{
					_Protocollo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_INSERIMENTO
		/// Tipo sul db:DATETIME
		/// Default:(getdate())
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
		/// Corrisponde al campo:DATA_MODIFICA
		/// Tipo sul db:DATETIME
		/// Default:(getdate())
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
	/// Summary description for AllegatiProtocollatiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class AllegatiProtocollatiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private AllegatiProtocollatiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((AllegatiProtocollati) info.GetValue(i.ToString(),typeof(AllegatiProtocollati)));
			}
		}

		//Costruttore
		public AllegatiProtocollatiCollection()
		{
			this.ItemType = typeof(AllegatiProtocollati);
		}

		//Costruttore con provider
		public AllegatiProtocollatiCollection(IAllegatiProtocollatiProvider providerObj)
		{
			this.ItemType = typeof(AllegatiProtocollati);
			this.Provider = providerObj;
		}

		//Get e Set
		public new AllegatiProtocollati this[int index]
		{
			get { return (AllegatiProtocollati)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new AllegatiProtocollatiCollection GetChanges()
		{
			return (AllegatiProtocollatiCollection) base.GetChanges();
		}

		[NonSerialized] private IAllegatiProtocollatiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IAllegatiProtocollatiProvider Provider
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
		public int Add(AllegatiProtocollati AllegatiProtocollatiObj)
		{
			if (AllegatiProtocollatiObj.Provider == null) AllegatiProtocollatiObj.Provider = this.Provider;
			return base.Add(AllegatiProtocollatiObj);
		}

		//AddCollection
		public void AddCollection(AllegatiProtocollatiCollection AllegatiProtocollatiCollectionObj)
		{
			foreach (AllegatiProtocollati AllegatiProtocollatiObj in AllegatiProtocollatiCollectionObj)
				this.Add(AllegatiProtocollatiObj);
		}

		//Insert
		public void Insert(int index, AllegatiProtocollati AllegatiProtocollatiObj)
		{
			if (AllegatiProtocollatiObj.Provider == null) AllegatiProtocollatiObj.Provider = this.Provider;
			base.Insert(index, AllegatiProtocollatiObj);
		}

		//CollectionGetById
		public AllegatiProtocollati CollectionGetById(NullTypes.IntNT IdAllegatoProtocollatoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdAllegatoProtocollato == IdAllegatoProtocollatoValue))
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
		public AllegatiProtocollatiCollection SubSelect(NullTypes.IntNT IdAllegatoProtocollatoEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, 
NullTypes.IntNT IdVarianteEqualThis, NullTypes.IntNT IdIntegrazioneEqualThis, NullTypes.IntNT IdComunicazioneEqualThis, 
NullTypes.IntNT IdFileEqualThis, NullTypes.BoolNT ProtocollatoEqualThis, NullTypes.StringNT ProtocolloEqualThis, 
NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.DatetimeNT DataModificaEqualThis)
		{
			AllegatiProtocollatiCollection AllegatiProtocollatiCollectionTemp = new AllegatiProtocollatiCollection();
			foreach (AllegatiProtocollati AllegatiProtocollatiItem in this)
			{
				if (((IdAllegatoProtocollatoEqualThis == null) || ((AllegatiProtocollatiItem.IdAllegatoProtocollato != null) && (AllegatiProtocollatiItem.IdAllegatoProtocollato.Value == IdAllegatoProtocollatoEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((AllegatiProtocollatiItem.IdProgetto != null) && (AllegatiProtocollatiItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((AllegatiProtocollatiItem.IdDomandaPagamento != null) && (AllegatiProtocollatiItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && 
((IdVarianteEqualThis == null) || ((AllegatiProtocollatiItem.IdVariante != null) && (AllegatiProtocollatiItem.IdVariante.Value == IdVarianteEqualThis.Value))) && ((IdIntegrazioneEqualThis == null) || ((AllegatiProtocollatiItem.IdIntegrazione != null) && (AllegatiProtocollatiItem.IdIntegrazione.Value == IdIntegrazioneEqualThis.Value))) && ((IdComunicazioneEqualThis == null) || ((AllegatiProtocollatiItem.IdComunicazione != null) && (AllegatiProtocollatiItem.IdComunicazione.Value == IdComunicazioneEqualThis.Value))) && 
((IdFileEqualThis == null) || ((AllegatiProtocollatiItem.IdFile != null) && (AllegatiProtocollatiItem.IdFile.Value == IdFileEqualThis.Value))) && ((ProtocollatoEqualThis == null) || ((AllegatiProtocollatiItem.Protocollato != null) && (AllegatiProtocollatiItem.Protocollato.Value == ProtocollatoEqualThis.Value))) && ((ProtocolloEqualThis == null) || ((AllegatiProtocollatiItem.Protocollo != null) && (AllegatiProtocollatiItem.Protocollo.Value == ProtocolloEqualThis.Value))) && 
((DataInserimentoEqualThis == null) || ((AllegatiProtocollatiItem.DataInserimento != null) && (AllegatiProtocollatiItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((DataModificaEqualThis == null) || ((AllegatiProtocollatiItem.DataModifica != null) && (AllegatiProtocollatiItem.DataModifica.Value == DataModificaEqualThis.Value))))
				{
					AllegatiProtocollatiCollectionTemp.Add(AllegatiProtocollatiItem);
				}
			}
			return AllegatiProtocollatiCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public AllegatiProtocollatiCollection Filter(NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.IntNT IdVarianteEqualThis, 
NullTypes.IntNT IdIntegrazioneEqualThis, NullTypes.IntNT IdComunicazioneEqualThis, NullTypes.IntNT IdFileEqualThis, 
NullTypes.BoolNT ProtocollatoEqualThis, NullTypes.StringNT ProtocolloEqualThis)
		{
			AllegatiProtocollatiCollection AllegatiProtocollatiCollectionTemp = new AllegatiProtocollatiCollection();
			foreach (AllegatiProtocollati AllegatiProtocollatiItem in this)
			{
				if (((IdProgettoEqualThis == null) || ((AllegatiProtocollatiItem.IdProgetto != null) && (AllegatiProtocollatiItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((AllegatiProtocollatiItem.IdDomandaPagamento != null) && (AllegatiProtocollatiItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((IdVarianteEqualThis == null) || ((AllegatiProtocollatiItem.IdVariante != null) && (AllegatiProtocollatiItem.IdVariante.Value == IdVarianteEqualThis.Value))) && 
((IdIntegrazioneEqualThis == null) || ((AllegatiProtocollatiItem.IdIntegrazione != null) && (AllegatiProtocollatiItem.IdIntegrazione.Value == IdIntegrazioneEqualThis.Value))) && ((IdComunicazioneEqualThis == null) || ((AllegatiProtocollatiItem.IdComunicazione != null) && (AllegatiProtocollatiItem.IdComunicazione.Value == IdComunicazioneEqualThis.Value))) && ((IdFileEqualThis == null) || ((AllegatiProtocollatiItem.IdFile != null) && (AllegatiProtocollatiItem.IdFile.Value == IdFileEqualThis.Value))) && 
((ProtocollatoEqualThis == null) || ((AllegatiProtocollatiItem.Protocollato != null) && (AllegatiProtocollatiItem.Protocollato.Value == ProtocollatoEqualThis.Value))) && ((ProtocolloEqualThis == null) || ((AllegatiProtocollatiItem.Protocollo != null) && (AllegatiProtocollatiItem.Protocollo.Value == ProtocolloEqualThis.Value))))
				{
					AllegatiProtocollatiCollectionTemp.Add(AllegatiProtocollatiItem);
				}
			}
			return AllegatiProtocollatiCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for AllegatiProtocollatiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class AllegatiProtocollatiDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, AllegatiProtocollati AllegatiProtocollatiObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdAllegatoProtocollato", AllegatiProtocollatiObj.IdAllegatoProtocollato);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", AllegatiProtocollatiObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdDomandaPagamento", AllegatiProtocollatiObj.IdDomandaPagamento);
			DbProvider.SetCmdParam(cmd,firstChar + "IdVariante", AllegatiProtocollatiObj.IdVariante);
			DbProvider.SetCmdParam(cmd,firstChar + "IdIntegrazione", AllegatiProtocollatiObj.IdIntegrazione);
			DbProvider.SetCmdParam(cmd,firstChar + "IdComunicazione", AllegatiProtocollatiObj.IdComunicazione);
			DbProvider.SetCmdParam(cmd,firstChar + "IdFile", AllegatiProtocollatiObj.IdFile);
			DbProvider.SetCmdParam(cmd,firstChar + "Protocollato", AllegatiProtocollatiObj.Protocollato);
			DbProvider.SetCmdParam(cmd,firstChar + "Protocollo", AllegatiProtocollatiObj.Protocollo);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", AllegatiProtocollatiObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", AllegatiProtocollatiObj.DataModifica);
		}
		//Insert
		private static int Insert(DbProvider db, AllegatiProtocollati AllegatiProtocollatiObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZAllegatiProtocollatiInsert", new string[] {"IdProgetto", "IdDomandaPagamento", 
"IdVariante", "IdIntegrazione", "IdComunicazione", 
"IdFile", "Protocollato", "Protocollo", 
"DataInserimento", "DataModifica"}, new string[] {"int", "int", 
"int", "int", "int", 
"int", "bool", "string", 
"DateTime", "DateTime"},"");
				CompileIUCmd(false, insertCmd,AllegatiProtocollatiObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				AllegatiProtocollatiObj.IdAllegatoProtocollato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ALLEGATO_PROTOCOLLATO"]);
				AllegatiProtocollatiObj.Protocollato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PROTOCOLLATO"]);
				AllegatiProtocollatiObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
				AllegatiProtocollatiObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
				}
				AllegatiProtocollatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AllegatiProtocollatiObj.IsDirty = false;
				AllegatiProtocollatiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, AllegatiProtocollati AllegatiProtocollatiObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZAllegatiProtocollatiUpdate", new string[] {"IdAllegatoProtocollato", "IdProgetto", "IdDomandaPagamento", 
"IdVariante", "IdIntegrazione", "IdComunicazione", 
"IdFile", "Protocollato", "Protocollo", 
"DataInserimento", "DataModifica"}, new string[] {"int", "int", "int", 
"int", "int", "int", 
"int", "bool", "string", 
"DateTime", "DateTime"},"");
				CompileIUCmd(true, updateCmd,AllegatiProtocollatiObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				AllegatiProtocollatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AllegatiProtocollatiObj.IsDirty = false;
				AllegatiProtocollatiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, AllegatiProtocollati AllegatiProtocollatiObj)
		{
			switch (AllegatiProtocollatiObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, AllegatiProtocollatiObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, AllegatiProtocollatiObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,AllegatiProtocollatiObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, AllegatiProtocollatiCollection AllegatiProtocollatiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZAllegatiProtocollatiUpdate", new string[] {"IdAllegatoProtocollato", "IdProgetto", "IdDomandaPagamento", 
"IdVariante", "IdIntegrazione", "IdComunicazione", 
"IdFile", "Protocollato", "Protocollo", 
"DataInserimento", "DataModifica"}, new string[] {"int", "int", "int", 
"int", "int", "int", 
"int", "bool", "string", 
"DateTime", "DateTime"},"");
				IDbCommand insertCmd = db.InitCmd( "ZAllegatiProtocollatiInsert", new string[] {"IdProgetto", "IdDomandaPagamento", 
"IdVariante", "IdIntegrazione", "IdComunicazione", 
"IdFile", "Protocollato", "Protocollo", 
"DataInserimento", "DataModifica"}, new string[] {"int", "int", 
"int", "int", "int", 
"int", "bool", "string", 
"DateTime", "DateTime"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZAllegatiProtocollatiDelete", new string[] {"IdAllegatoProtocollato"}, new string[] {"int"},"");
				for (int i = 0; i < AllegatiProtocollatiCollectionObj.Count; i++)
				{
					switch (AllegatiProtocollatiCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,AllegatiProtocollatiCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									AllegatiProtocollatiCollectionObj[i].IdAllegatoProtocollato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ALLEGATO_PROTOCOLLATO"]);
									AllegatiProtocollatiCollectionObj[i].Protocollato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PROTOCOLLATO"]);
									AllegatiProtocollatiCollectionObj[i].DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
									AllegatiProtocollatiCollectionObj[i].DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,AllegatiProtocollatiCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (AllegatiProtocollatiCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdAllegatoProtocollato", (SiarLibrary.NullTypes.IntNT)AllegatiProtocollatiCollectionObj[i].IdAllegatoProtocollato);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < AllegatiProtocollatiCollectionObj.Count; i++)
				{
					if ((AllegatiProtocollatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (AllegatiProtocollatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						AllegatiProtocollatiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						AllegatiProtocollatiCollectionObj[i].IsDirty = false;
						AllegatiProtocollatiCollectionObj[i].IsPersistent = true;
					}
					if ((AllegatiProtocollatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						AllegatiProtocollatiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						AllegatiProtocollatiCollectionObj[i].IsDirty = false;
						AllegatiProtocollatiCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, AllegatiProtocollati AllegatiProtocollatiObj)
		{
			int returnValue = 0;
			if (AllegatiProtocollatiObj.IsPersistent) 
			{
				returnValue = Delete(db, AllegatiProtocollatiObj.IdAllegatoProtocollato);
			}
			AllegatiProtocollatiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			AllegatiProtocollatiObj.IsDirty = false;
			AllegatiProtocollatiObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdAllegatoProtocollatoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZAllegatiProtocollatiDelete", new string[] {"IdAllegatoProtocollato"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdAllegatoProtocollato", (SiarLibrary.NullTypes.IntNT)IdAllegatoProtocollatoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, AllegatiProtocollatiCollection AllegatiProtocollatiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZAllegatiProtocollatiDelete", new string[] {"IdAllegatoProtocollato"}, new string[] {"int"},"");
				for (int i = 0; i < AllegatiProtocollatiCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdAllegatoProtocollato", AllegatiProtocollatiCollectionObj[i].IdAllegatoProtocollato);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < AllegatiProtocollatiCollectionObj.Count; i++)
				{
					if ((AllegatiProtocollatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (AllegatiProtocollatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						AllegatiProtocollatiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						AllegatiProtocollatiCollectionObj[i].IsDirty = false;
						AllegatiProtocollatiCollectionObj[i].IsPersistent = false;
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
		public static AllegatiProtocollati GetById(DbProvider db, int IdAllegatoProtocollatoValue)
		{
			AllegatiProtocollati AllegatiProtocollatiObj = null;
			IDbCommand readCmd = db.InitCmd( "ZAllegatiProtocollatiGetById", new string[] {"IdAllegatoProtocollato"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdAllegatoProtocollato", (SiarLibrary.NullTypes.IntNT)IdAllegatoProtocollatoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				AllegatiProtocollatiObj = GetFromDatareader(db);
				AllegatiProtocollatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AllegatiProtocollatiObj.IsDirty = false;
				AllegatiProtocollatiObj.IsPersistent = true;
			}
			db.Close();
			return AllegatiProtocollatiObj;
		}

		//getFromDatareader
		public static AllegatiProtocollati GetFromDatareader(DbProvider db)
		{
			AllegatiProtocollati AllegatiProtocollatiObj = new AllegatiProtocollati();
			AllegatiProtocollatiObj.IdAllegatoProtocollato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ALLEGATO_PROTOCOLLATO"]);
			AllegatiProtocollatiObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			AllegatiProtocollatiObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
			AllegatiProtocollatiObj.IdVariante = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VARIANTE"]);
			AllegatiProtocollatiObj.IdIntegrazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INTEGRAZIONE"]);
			AllegatiProtocollatiObj.IdComunicazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COMUNICAZIONE"]);
			AllegatiProtocollatiObj.IdFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILE"]);
			AllegatiProtocollatiObj.Protocollato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PROTOCOLLATO"]);
			AllegatiProtocollatiObj.Protocollo = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROTOCOLLO"]);
			AllegatiProtocollatiObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			AllegatiProtocollatiObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			AllegatiProtocollatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			AllegatiProtocollatiObj.IsDirty = false;
			AllegatiProtocollatiObj.IsPersistent = true;
			return AllegatiProtocollatiObj;
		}

		//Find Select

		public static AllegatiProtocollatiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdAllegatoProtocollatoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, 
SiarLibrary.NullTypes.IntNT IdVarianteEqualThis, SiarLibrary.NullTypes.IntNT IdIntegrazioneEqualThis, SiarLibrary.NullTypes.IntNT IdComunicazioneEqualThis, 
SiarLibrary.NullTypes.IntNT IdFileEqualThis, SiarLibrary.NullTypes.BoolNT ProtocollatoEqualThis, SiarLibrary.NullTypes.StringNT ProtocolloEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis)

		{

			AllegatiProtocollatiCollection AllegatiProtocollatiCollectionObj = new AllegatiProtocollatiCollection();

			IDbCommand findCmd = db.InitCmd("Zallegatiprotocollatifindselect", new string[] {"IdAllegatoProtocollatoequalthis", "IdProgettoequalthis", "IdDomandaPagamentoequalthis", 
"IdVarianteequalthis", "IdIntegrazioneequalthis", "IdComunicazioneequalthis", 
"IdFileequalthis", "Protocollatoequalthis", "Protocolloequalthis", 
"DataInserimentoequalthis", "DataModificaequalthis"}, new string[] {"int", "int", "int", 
"int", "int", "int", 
"int", "bool", "string", 
"DateTime", "DateTime"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAllegatoProtocollatoequalthis", IdAllegatoProtocollatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdVarianteequalthis", IdVarianteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdIntegrazioneequalthis", IdIntegrazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdComunicazioneequalthis", IdComunicazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFileequalthis", IdFileEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Protocollatoequalthis", ProtocollatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Protocolloequalthis", ProtocolloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			AllegatiProtocollati AllegatiProtocollatiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				AllegatiProtocollatiObj = GetFromDatareader(db);
				AllegatiProtocollatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AllegatiProtocollatiObj.IsDirty = false;
				AllegatiProtocollatiObj.IsPersistent = true;
				AllegatiProtocollatiCollectionObj.Add(AllegatiProtocollatiObj);
			}
			db.Close();
			return AllegatiProtocollatiCollectionObj;
		}

		//Find Find

		public static AllegatiProtocollatiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdVarianteEqualThis, 
SiarLibrary.NullTypes.IntNT IdIntegrazioneEqualThis, SiarLibrary.NullTypes.IntNT IdComunicazioneEqualThis, SiarLibrary.NullTypes.IntNT IdFileEqualThis, 
SiarLibrary.NullTypes.BoolNT ProtocollatoEqualThis, SiarLibrary.NullTypes.StringNT ProtocolloEqualThis)

		{

			AllegatiProtocollatiCollection AllegatiProtocollatiCollectionObj = new AllegatiProtocollatiCollection();

			IDbCommand findCmd = db.InitCmd("Zallegatiprotocollatifindfind", new string[] {"IdProgettoequalthis", "IdDomandaPagamentoequalthis", "IdVarianteequalthis", 
"IdIntegrazioneequalthis", "IdComunicazioneequalthis", "IdFileequalthis", 
"Protocollatoequalthis", "Protocolloequalthis"}, new string[] {"int", "int", "int", 
"int", "int", "int", 
"bool", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdVarianteequalthis", IdVarianteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdIntegrazioneequalthis", IdIntegrazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdComunicazioneequalthis", IdComunicazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFileequalthis", IdFileEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Protocollatoequalthis", ProtocollatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Protocolloequalthis", ProtocolloEqualThis);
			AllegatiProtocollati AllegatiProtocollatiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				AllegatiProtocollatiObj = GetFromDatareader(db);
				AllegatiProtocollatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AllegatiProtocollatiObj.IsDirty = false;
				AllegatiProtocollatiObj.IsPersistent = true;
				AllegatiProtocollatiCollectionObj.Add(AllegatiProtocollatiObj);
			}
			db.Close();
			return AllegatiProtocollatiCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for AllegatiProtocollatiCollectionProvider:IAllegatiProtocollatiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class AllegatiProtocollatiCollectionProvider : IAllegatiProtocollatiProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di AllegatiProtocollati
		protected AllegatiProtocollatiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public AllegatiProtocollatiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new AllegatiProtocollatiCollection(this);
		}

		//Costruttore 2: popola la collection
		public AllegatiProtocollatiCollectionProvider(IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdvarianteEqualThis, 
IntNT IdintegrazioneEqualThis, IntNT IdcomunicazioneEqualThis, IntNT IdfileEqualThis, 
BoolNT ProtocollatoEqualThis, StringNT ProtocolloEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdprogettoEqualThis, IddomandapagamentoEqualThis, IdvarianteEqualThis, 
IdintegrazioneEqualThis, IdcomunicazioneEqualThis, IdfileEqualThis, 
ProtocollatoEqualThis, ProtocolloEqualThis);
		}

		//Costruttore3: ha in input allegatiprotocollatiCollectionObj - non popola la collection
		public AllegatiProtocollatiCollectionProvider(AllegatiProtocollatiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public AllegatiProtocollatiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new AllegatiProtocollatiCollection(this);
		}

		//Get e Set
		public AllegatiProtocollatiCollection CollectionObj
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
		public int SaveCollection(AllegatiProtocollatiCollection collectionObj)
		{
			return AllegatiProtocollatiDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(AllegatiProtocollati allegatiprotocollatiObj)
		{
			return AllegatiProtocollatiDAL.Save(_dbProviderObj, allegatiprotocollatiObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(AllegatiProtocollatiCollection collectionObj)
		{
			return AllegatiProtocollatiDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(AllegatiProtocollati allegatiprotocollatiObj)
		{
			return AllegatiProtocollatiDAL.Delete(_dbProviderObj, allegatiprotocollatiObj);
		}

		//getById
		public AllegatiProtocollati GetById(IntNT IdAllegatoProtocollatoValue)
		{
			AllegatiProtocollati AllegatiProtocollatiTemp = AllegatiProtocollatiDAL.GetById(_dbProviderObj, IdAllegatoProtocollatoValue);
			if (AllegatiProtocollatiTemp!=null) AllegatiProtocollatiTemp.Provider = this;
			return AllegatiProtocollatiTemp;
		}

		//Select: popola la collection
		public AllegatiProtocollatiCollection Select(IntNT IdallegatoprotocollatoEqualThis, IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis, 
IntNT IdvarianteEqualThis, IntNT IdintegrazioneEqualThis, IntNT IdcomunicazioneEqualThis, 
IntNT IdfileEqualThis, BoolNT ProtocollatoEqualThis, StringNT ProtocolloEqualThis, 
DatetimeNT DatainserimentoEqualThis, DatetimeNT DatamodificaEqualThis)
		{
			AllegatiProtocollatiCollection AllegatiProtocollatiCollectionTemp = AllegatiProtocollatiDAL.Select(_dbProviderObj, IdallegatoprotocollatoEqualThis, IdprogettoEqualThis, IddomandapagamentoEqualThis, 
IdvarianteEqualThis, IdintegrazioneEqualThis, IdcomunicazioneEqualThis, 
IdfileEqualThis, ProtocollatoEqualThis, ProtocolloEqualThis, 
DatainserimentoEqualThis, DatamodificaEqualThis);
			AllegatiProtocollatiCollectionTemp.Provider = this;
			return AllegatiProtocollatiCollectionTemp;
		}

		//Find: popola la collection
		public AllegatiProtocollatiCollection Find(IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdvarianteEqualThis, 
IntNT IdintegrazioneEqualThis, IntNT IdcomunicazioneEqualThis, IntNT IdfileEqualThis, 
BoolNT ProtocollatoEqualThis, StringNT ProtocolloEqualThis)
		{
			AllegatiProtocollatiCollection AllegatiProtocollatiCollectionTemp = AllegatiProtocollatiDAL.Find(_dbProviderObj, IdprogettoEqualThis, IddomandapagamentoEqualThis, IdvarianteEqualThis, 
IdintegrazioneEqualThis, IdcomunicazioneEqualThis, IdfileEqualThis, 
ProtocollatoEqualThis, ProtocolloEqualThis);
			AllegatiProtocollatiCollectionTemp.Provider = this;
			return AllegatiProtocollatiCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<ALLEGATI_PROTOCOLLATI>
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
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_VARIANTE>Equal</ID_VARIANTE>
      <ID_INTEGRAZIONE>Equal</ID_INTEGRAZIONE>
      <ID_COMUNICAZIONE>Equal</ID_COMUNICAZIONE>
      <ID_FILE>Equal</ID_FILE>
      <PROTOCOLLATO>Equal</PROTOCOLLATO>
      <PROTOCOLLO>Equal</PROTOCOLLO>
    </Find>
  </Finds>
  <Filters>
    <Filter>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_VARIANTE>Equal</ID_VARIANTE>
      <ID_INTEGRAZIONE>Equal</ID_INTEGRAZIONE>
      <ID_COMUNICAZIONE>Equal</ID_COMUNICAZIONE>
      <ID_FILE>Equal</ID_FILE>
      <PROTOCOLLATO>Equal</PROTOCOLLATO>
      <PROTOCOLLO>Equal</PROTOCOLLO>
    </Filter>
  </Filters>
  <externalFields />
  <AddedFkFields />
</ALLEGATI_PROTOCOLLATI>
*/
