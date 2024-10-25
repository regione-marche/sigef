using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ProgettoAttiAffidamentoAllegati
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IProgettoAttiAffidamentoAllegatiProvider
	{
		int Save(ProgettoAttiAffidamentoAllegati ProgettoAttiAffidamentoAllegatiObj);
		int SaveCollection(ProgettoAttiAffidamentoAllegatiCollection collectionObj);
		int Delete(ProgettoAttiAffidamentoAllegati ProgettoAttiAffidamentoAllegatiObj);
		int DeleteCollection(ProgettoAttiAffidamentoAllegatiCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ProgettoAttiAffidamentoAllegati
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ProgettoAttiAffidamentoAllegati: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdProgettoAttiAffidamentoAllegati;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdFile;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.IntNT _OperatoreInserimento;
		private NullTypes.StringNT _CodTipoDocumento;
		private NullTypes.IntNT _Id;
		private NullTypes.StringNT _Tipo;
		private NullTypes.StringNT _NomeFile;
		private NullTypes.StringNT _NomeCompleto;
		private byte[] _Contenuto;
		private NullTypes.IntNT _Dimensione;
		private NullTypes.StringNT _HashCode;
		private NullTypes.StringNT _TipoAllegatoDescrizione;
		private NullTypes.StringNT _TipoDocumentoDescrizione;
		[NonSerialized] private IProgettoAttiAffidamentoAllegatiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IProgettoAttiAffidamentoAllegatiProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ProgettoAttiAffidamentoAllegati()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_PROGETTO_ATTI_AFFIDAMENTO_ALLEGATI
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProgettoAttiAffidamentoAllegati
		{
			get { return _IdProgettoAttiAffidamentoAllegati; }
			set {
				if (IdProgettoAttiAffidamentoAllegati != value)
				{
					_IdProgettoAttiAffidamentoAllegati = value;
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
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(255)
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
		/// Corrisponde al campo:COD_TIPO_DOCUMENTO
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT CodTipoDocumento
		{
			get { return _CodTipoDocumento; }
			set {
				if (CodTipoDocumento != value)
				{
					_CodTipoDocumento = value;
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
		/// Corrisponde al campo:TIPO
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT Tipo
		{
			get { return _Tipo; }
			set {
				if (Tipo != value)
				{
					_Tipo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOME_FILE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT NomeFile
		{
			get { return _NomeFile; }
			set {
				if (NomeFile != value)
				{
					_NomeFile = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOME_COMPLETO
		/// Tipo sul db:VARCHAR(510)
		/// </summary>
		public NullTypes.StringNT NomeCompleto
		{
			get { return _NomeCompleto; }
			set {
				if (NomeCompleto != value)
				{
					_NomeCompleto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTENUTO
		/// Tipo sul db:VARBINARY
		/// </summary>
		public byte[] Contenuto
		{
			get { return _Contenuto; }
			set {
				if (Contenuto != value)
				{
					_Contenuto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DIMENSIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Dimensione
		{
			get { return _Dimensione; }
			set {
				if (Dimensione != value)
				{
					_Dimensione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:HASH_CODE
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT HashCode
		{
			get { return _HashCode; }
			set {
				if (HashCode != value)
				{
					_HashCode = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO_ALLEGATO_DESCRIZIONE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT TipoAllegatoDescrizione
		{
			get { return _TipoAllegatoDescrizione; }
			set {
				if (TipoAllegatoDescrizione != value)
				{
					_TipoAllegatoDescrizione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO_DOCUMENTO_DESCRIZIONE
		/// Tipo sul db:VARCHAR(250)
		/// </summary>
		public NullTypes.StringNT TipoDocumentoDescrizione
		{
			get { return _TipoDocumentoDescrizione; }
			set {
				if (TipoDocumentoDescrizione != value)
				{
					_TipoDocumentoDescrizione = value;
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
	/// Summary description for ProgettoAttiAffidamentoAllegatiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProgettoAttiAffidamentoAllegatiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ProgettoAttiAffidamentoAllegatiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ProgettoAttiAffidamentoAllegati) info.GetValue(i.ToString(),typeof(ProgettoAttiAffidamentoAllegati)));
			}
		}

		//Costruttore
		public ProgettoAttiAffidamentoAllegatiCollection()
		{
			this.ItemType = typeof(ProgettoAttiAffidamentoAllegati);
		}

		//Costruttore con provider
		public ProgettoAttiAffidamentoAllegatiCollection(IProgettoAttiAffidamentoAllegatiProvider providerObj)
		{
			this.ItemType = typeof(ProgettoAttiAffidamentoAllegati);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ProgettoAttiAffidamentoAllegati this[int index]
		{
			get { return (ProgettoAttiAffidamentoAllegati)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ProgettoAttiAffidamentoAllegatiCollection GetChanges()
		{
			return (ProgettoAttiAffidamentoAllegatiCollection) base.GetChanges();
		}

		[NonSerialized] private IProgettoAttiAffidamentoAllegatiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IProgettoAttiAffidamentoAllegatiProvider Provider
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
		public int Add(ProgettoAttiAffidamentoAllegati ProgettoAttiAffidamentoAllegatiObj)
		{
			if (ProgettoAttiAffidamentoAllegatiObj.Provider == null) ProgettoAttiAffidamentoAllegatiObj.Provider = this.Provider;
			return base.Add(ProgettoAttiAffidamentoAllegatiObj);
		}

		//AddCollection
		public void AddCollection(ProgettoAttiAffidamentoAllegatiCollection ProgettoAttiAffidamentoAllegatiCollectionObj)
		{
			foreach (ProgettoAttiAffidamentoAllegati ProgettoAttiAffidamentoAllegatiObj in ProgettoAttiAffidamentoAllegatiCollectionObj)
				this.Add(ProgettoAttiAffidamentoAllegatiObj);
		}

		//Insert
		public void Insert(int index, ProgettoAttiAffidamentoAllegati ProgettoAttiAffidamentoAllegatiObj)
		{
			if (ProgettoAttiAffidamentoAllegatiObj.Provider == null) ProgettoAttiAffidamentoAllegatiObj.Provider = this.Provider;
			base.Insert(index, ProgettoAttiAffidamentoAllegatiObj);
		}

		//CollectionGetById
		public ProgettoAttiAffidamentoAllegati CollectionGetById(NullTypes.IntNT IdProgettoAttiAffidamentoAllegatiValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdProgettoAttiAffidamentoAllegati == IdProgettoAttiAffidamentoAllegatiValue))
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
		public ProgettoAttiAffidamentoAllegatiCollection SubSelect(NullTypes.IntNT IdProgettoAttiAffidamentoAllegatiEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdFileEqualThis, 
NullTypes.StringNT DescrizioneEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.IntNT OperatoreInserimentoEqualThis, 
NullTypes.StringNT CodTipoDocumentoEqualThis)
		{
			ProgettoAttiAffidamentoAllegatiCollection ProgettoAttiAffidamentoAllegatiCollectionTemp = new ProgettoAttiAffidamentoAllegatiCollection();
			foreach (ProgettoAttiAffidamentoAllegati ProgettoAttiAffidamentoAllegatiItem in this)
			{
				if (((IdProgettoAttiAffidamentoAllegatiEqualThis == null) || ((ProgettoAttiAffidamentoAllegatiItem.IdProgettoAttiAffidamentoAllegati != null) && (ProgettoAttiAffidamentoAllegatiItem.IdProgettoAttiAffidamentoAllegati.Value == IdProgettoAttiAffidamentoAllegatiEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((ProgettoAttiAffidamentoAllegatiItem.IdProgetto != null) && (ProgettoAttiAffidamentoAllegatiItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdFileEqualThis == null) || ((ProgettoAttiAffidamentoAllegatiItem.IdFile != null) && (ProgettoAttiAffidamentoAllegatiItem.IdFile.Value == IdFileEqualThis.Value))) && 
((DescrizioneEqualThis == null) || ((ProgettoAttiAffidamentoAllegatiItem.Descrizione != null) && (ProgettoAttiAffidamentoAllegatiItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((ProgettoAttiAffidamentoAllegatiItem.DataInserimento != null) && (ProgettoAttiAffidamentoAllegatiItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((OperatoreInserimentoEqualThis == null) || ((ProgettoAttiAffidamentoAllegatiItem.OperatoreInserimento != null) && (ProgettoAttiAffidamentoAllegatiItem.OperatoreInserimento.Value == OperatoreInserimentoEqualThis.Value))) && 
((CodTipoDocumentoEqualThis == null) || ((ProgettoAttiAffidamentoAllegatiItem.CodTipoDocumento != null) && (ProgettoAttiAffidamentoAllegatiItem.CodTipoDocumento.Value == CodTipoDocumentoEqualThis.Value))))
				{
					ProgettoAttiAffidamentoAllegatiCollectionTemp.Add(ProgettoAttiAffidamentoAllegatiItem);
				}
			}
			return ProgettoAttiAffidamentoAllegatiCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ProgettoAttiAffidamentoAllegatiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ProgettoAttiAffidamentoAllegatiDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ProgettoAttiAffidamentoAllegati ProgettoAttiAffidamentoAllegatiObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdProgettoAttiAffidamentoAllegati", ProgettoAttiAffidamentoAllegatiObj.IdProgettoAttiAffidamentoAllegati);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", ProgettoAttiAffidamentoAllegatiObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdFile", ProgettoAttiAffidamentoAllegatiObj.IdFile);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", ProgettoAttiAffidamentoAllegatiObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", ProgettoAttiAffidamentoAllegatiObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreInserimento", ProgettoAttiAffidamentoAllegatiObj.OperatoreInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipoDocumento", ProgettoAttiAffidamentoAllegatiObj.CodTipoDocumento);
		}
		//Insert
		private static int Insert(DbProvider db, ProgettoAttiAffidamentoAllegati ProgettoAttiAffidamentoAllegatiObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZProgettoAttiAffidamentoAllegatiInsert", new string[] {"IdProgetto", "IdFile", 
"Descrizione", "DataInserimento", "OperatoreInserimento", 
"CodTipoDocumento", 

}, new string[] {"int", "int", 
"string", "DateTime", "int", 
"string", 

},"");
				CompileIUCmd(false, insertCmd,ProgettoAttiAffidamentoAllegatiObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ProgettoAttiAffidamentoAllegatiObj.IdProgettoAttiAffidamentoAllegati = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO_ATTI_AFFIDAMENTO_ALLEGATI"]);
				}
				ProgettoAttiAffidamentoAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoAttiAffidamentoAllegatiObj.IsDirty = false;
				ProgettoAttiAffidamentoAllegatiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ProgettoAttiAffidamentoAllegati ProgettoAttiAffidamentoAllegatiObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZProgettoAttiAffidamentoAllegatiUpdate", new string[] {"IdProgettoAttiAffidamentoAllegati", "IdProgetto", "IdFile", 
"Descrizione", "DataInserimento", "OperatoreInserimento", 
"CodTipoDocumento", 

}, new string[] {"int", "int", "int", 
"string", "DateTime", "int", 
"string", 

},"");
				CompileIUCmd(true, updateCmd,ProgettoAttiAffidamentoAllegatiObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ProgettoAttiAffidamentoAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoAttiAffidamentoAllegatiObj.IsDirty = false;
				ProgettoAttiAffidamentoAllegatiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ProgettoAttiAffidamentoAllegati ProgettoAttiAffidamentoAllegatiObj)
		{
			switch (ProgettoAttiAffidamentoAllegatiObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ProgettoAttiAffidamentoAllegatiObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ProgettoAttiAffidamentoAllegatiObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ProgettoAttiAffidamentoAllegatiObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ProgettoAttiAffidamentoAllegatiCollection ProgettoAttiAffidamentoAllegatiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZProgettoAttiAffidamentoAllegatiUpdate", new string[] {"IdProgettoAttiAffidamentoAllegati", "IdProgetto", "IdFile", 
"Descrizione", "DataInserimento", "OperatoreInserimento", 
"CodTipoDocumento", 

}, new string[] {"int", "int", "int", 
"string", "DateTime", "int", 
"string", 

},"");
				IDbCommand insertCmd = db.InitCmd( "ZProgettoAttiAffidamentoAllegatiInsert", new string[] {"IdProgetto", "IdFile", 
"Descrizione", "DataInserimento", "OperatoreInserimento", 
"CodTipoDocumento", 

}, new string[] {"int", "int", 
"string", "DateTime", "int", 
"string", 

},"");
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoAttiAffidamentoAllegatiDelete", new string[] {"IdProgettoAttiAffidamentoAllegati"}, new string[] {"int"},"");
				for (int i = 0; i < ProgettoAttiAffidamentoAllegatiCollectionObj.Count; i++)
				{
					switch (ProgettoAttiAffidamentoAllegatiCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ProgettoAttiAffidamentoAllegatiCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ProgettoAttiAffidamentoAllegatiCollectionObj[i].IdProgettoAttiAffidamentoAllegati = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO_ATTI_AFFIDAMENTO_ALLEGATI"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ProgettoAttiAffidamentoAllegatiCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ProgettoAttiAffidamentoAllegatiCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProgettoAttiAffidamentoAllegati", (SiarLibrary.NullTypes.IntNT)ProgettoAttiAffidamentoAllegatiCollectionObj[i].IdProgettoAttiAffidamentoAllegati);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ProgettoAttiAffidamentoAllegatiCollectionObj.Count; i++)
				{
					if ((ProgettoAttiAffidamentoAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoAttiAffidamentoAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettoAttiAffidamentoAllegatiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ProgettoAttiAffidamentoAllegatiCollectionObj[i].IsDirty = false;
						ProgettoAttiAffidamentoAllegatiCollectionObj[i].IsPersistent = true;
					}
					if ((ProgettoAttiAffidamentoAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ProgettoAttiAffidamentoAllegatiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettoAttiAffidamentoAllegatiCollectionObj[i].IsDirty = false;
						ProgettoAttiAffidamentoAllegatiCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ProgettoAttiAffidamentoAllegati ProgettoAttiAffidamentoAllegatiObj)
		{
			int returnValue = 0;
			if (ProgettoAttiAffidamentoAllegatiObj.IsPersistent) 
			{
				returnValue = Delete(db, ProgettoAttiAffidamentoAllegatiObj.IdProgettoAttiAffidamentoAllegati);
			}
			ProgettoAttiAffidamentoAllegatiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ProgettoAttiAffidamentoAllegatiObj.IsDirty = false;
			ProgettoAttiAffidamentoAllegatiObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdProgettoAttiAffidamentoAllegatiValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoAttiAffidamentoAllegatiDelete", new string[] {"IdProgettoAttiAffidamentoAllegati"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProgettoAttiAffidamentoAllegati", (SiarLibrary.NullTypes.IntNT)IdProgettoAttiAffidamentoAllegatiValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ProgettoAttiAffidamentoAllegatiCollection ProgettoAttiAffidamentoAllegatiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoAttiAffidamentoAllegatiDelete", new string[] {"IdProgettoAttiAffidamentoAllegati"}, new string[] {"int"},"");
				for (int i = 0; i < ProgettoAttiAffidamentoAllegatiCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProgettoAttiAffidamentoAllegati", ProgettoAttiAffidamentoAllegatiCollectionObj[i].IdProgettoAttiAffidamentoAllegati);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ProgettoAttiAffidamentoAllegatiCollectionObj.Count; i++)
				{
					if ((ProgettoAttiAffidamentoAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoAttiAffidamentoAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettoAttiAffidamentoAllegatiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettoAttiAffidamentoAllegatiCollectionObj[i].IsDirty = false;
						ProgettoAttiAffidamentoAllegatiCollectionObj[i].IsPersistent = false;
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
		public static ProgettoAttiAffidamentoAllegati GetById(DbProvider db, int IdProgettoAttiAffidamentoAllegatiValue)
		{
			ProgettoAttiAffidamentoAllegati ProgettoAttiAffidamentoAllegatiObj = null;
			IDbCommand readCmd = db.InitCmd( "ZProgettoAttiAffidamentoAllegatiGetById", new string[] {"IdProgettoAttiAffidamentoAllegati"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdProgettoAttiAffidamentoAllegati", (SiarLibrary.NullTypes.IntNT)IdProgettoAttiAffidamentoAllegatiValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ProgettoAttiAffidamentoAllegatiObj = GetFromDatareader(db);
				ProgettoAttiAffidamentoAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoAttiAffidamentoAllegatiObj.IsDirty = false;
				ProgettoAttiAffidamentoAllegatiObj.IsPersistent = true;
			}
			db.Close();
			return ProgettoAttiAffidamentoAllegatiObj;
		}

		//getFromDatareader
		public static ProgettoAttiAffidamentoAllegati GetFromDatareader(DbProvider db)
		{
			ProgettoAttiAffidamentoAllegati ProgettoAttiAffidamentoAllegatiObj = new ProgettoAttiAffidamentoAllegati();
			ProgettoAttiAffidamentoAllegatiObj.IdProgettoAttiAffidamentoAllegati = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO_ATTI_AFFIDAMENTO_ALLEGATI"]);
			ProgettoAttiAffidamentoAllegatiObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			ProgettoAttiAffidamentoAllegatiObj.IdFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILE"]);
			ProgettoAttiAffidamentoAllegatiObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			ProgettoAttiAffidamentoAllegatiObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			ProgettoAttiAffidamentoAllegatiObj.OperatoreInserimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_INSERIMENTO"]);
			ProgettoAttiAffidamentoAllegatiObj.CodTipoDocumento = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_DOCUMENTO"]);
			ProgettoAttiAffidamentoAllegatiObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			ProgettoAttiAffidamentoAllegatiObj.Tipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO"]);
			ProgettoAttiAffidamentoAllegatiObj.NomeFile = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOME_FILE"]);
			ProgettoAttiAffidamentoAllegatiObj.NomeCompleto = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOME_COMPLETO"]);
			ProgettoAttiAffidamentoAllegatiObj.Contenuto =  Convert.IsDBNull(db.DataReader["CONTENUTO"]) ? null : (byte[])db.DataReader["CONTENUTO"];
			ProgettoAttiAffidamentoAllegatiObj.Dimensione = new SiarLibrary.NullTypes.IntNT(db.DataReader["DIMENSIONE"]);
			ProgettoAttiAffidamentoAllegatiObj.HashCode = new SiarLibrary.NullTypes.StringNT(db.DataReader["HASH_CODE"]);
			ProgettoAttiAffidamentoAllegatiObj.TipoAllegatoDescrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_ALLEGATO_DESCRIZIONE"]);
			ProgettoAttiAffidamentoAllegatiObj.TipoDocumentoDescrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_DOCUMENTO_DESCRIZIONE"]);
			ProgettoAttiAffidamentoAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ProgettoAttiAffidamentoAllegatiObj.IsDirty = false;
			ProgettoAttiAffidamentoAllegatiObj.IsPersistent = true;
			return ProgettoAttiAffidamentoAllegatiObj;
		}

		//Find Select

		public static ProgettoAttiAffidamentoAllegatiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoAttiAffidamentoAllegatiEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdFileEqualThis, 
SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.IntNT OperatoreInserimentoEqualThis, 
SiarLibrary.NullTypes.StringNT CodTipoDocumentoEqualThis)

		{

			ProgettoAttiAffidamentoAllegatiCollection ProgettoAttiAffidamentoAllegatiCollectionObj = new ProgettoAttiAffidamentoAllegatiCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettoattiaffidamentoallegatifindselect", new string[] {"IdProgettoAttiAffidamentoAllegatiequalthis", "IdProgettoequalthis", "IdFileequalthis", 
"Descrizioneequalthis", "DataInserimentoequalthis", "OperatoreInserimentoequalthis", 
"CodTipoDocumentoequalthis"}, new string[] {"int", "int", "int", 
"string", "DateTime", "int", 
"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoAttiAffidamentoAllegatiequalthis", IdProgettoAttiAffidamentoAllegatiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFileequalthis", IdFileEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreInserimentoequalthis", OperatoreInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoDocumentoequalthis", CodTipoDocumentoEqualThis);
			ProgettoAttiAffidamentoAllegati ProgettoAttiAffidamentoAllegatiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettoAttiAffidamentoAllegatiObj = GetFromDatareader(db);
				ProgettoAttiAffidamentoAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoAttiAffidamentoAllegatiObj.IsDirty = false;
				ProgettoAttiAffidamentoAllegatiObj.IsPersistent = true;
				ProgettoAttiAffidamentoAllegatiCollectionObj.Add(ProgettoAttiAffidamentoAllegatiObj);
			}
			db.Close();
			return ProgettoAttiAffidamentoAllegatiCollectionObj;
		}

		//Find Find

		public static ProgettoAttiAffidamentoAllegatiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoAttiAffidamentoAllegatiEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdFileEqualThis)

		{

			ProgettoAttiAffidamentoAllegatiCollection ProgettoAttiAffidamentoAllegatiCollectionObj = new ProgettoAttiAffidamentoAllegatiCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettoattiaffidamentoallegatifindfind", new string[] {"IdProgettoAttiAffidamentoAllegatiequalthis", "IdProgettoequalthis", "IdFileequalthis"}, new string[] {"int", "int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoAttiAffidamentoAllegatiequalthis", IdProgettoAttiAffidamentoAllegatiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFileequalthis", IdFileEqualThis);
			ProgettoAttiAffidamentoAllegati ProgettoAttiAffidamentoAllegatiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettoAttiAffidamentoAllegatiObj = GetFromDatareader(db);
				ProgettoAttiAffidamentoAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoAttiAffidamentoAllegatiObj.IsDirty = false;
				ProgettoAttiAffidamentoAllegatiObj.IsPersistent = true;
				ProgettoAttiAffidamentoAllegatiCollectionObj.Add(ProgettoAttiAffidamentoAllegatiObj);
			}
			db.Close();
			return ProgettoAttiAffidamentoAllegatiCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ProgettoAttiAffidamentoAllegatiCollectionProvider:IProgettoAttiAffidamentoAllegatiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProgettoAttiAffidamentoAllegatiCollectionProvider : IProgettoAttiAffidamentoAllegatiProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ProgettoAttiAffidamentoAllegati
		protected ProgettoAttiAffidamentoAllegatiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ProgettoAttiAffidamentoAllegatiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ProgettoAttiAffidamentoAllegatiCollection(this);
		}

		//Costruttore 2: popola la collection
		public ProgettoAttiAffidamentoAllegatiCollectionProvider(IntNT IdprogettoattiaffidamentoallegatiEqualThis, IntNT IdprogettoEqualThis, IntNT IdfileEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdprogettoattiaffidamentoallegatiEqualThis, IdprogettoEqualThis, IdfileEqualThis);
		}

		//Costruttore3: ha in input progettoattiaffidamentoallegatiCollectionObj - non popola la collection
		public ProgettoAttiAffidamentoAllegatiCollectionProvider(ProgettoAttiAffidamentoAllegatiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ProgettoAttiAffidamentoAllegatiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ProgettoAttiAffidamentoAllegatiCollection(this);
		}

		//Get e Set
		public ProgettoAttiAffidamentoAllegatiCollection CollectionObj
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
		public int SaveCollection(ProgettoAttiAffidamentoAllegatiCollection collectionObj)
		{
			return ProgettoAttiAffidamentoAllegatiDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ProgettoAttiAffidamentoAllegati progettoattiaffidamentoallegatiObj)
		{
			return ProgettoAttiAffidamentoAllegatiDAL.Save(_dbProviderObj, progettoattiaffidamentoallegatiObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ProgettoAttiAffidamentoAllegatiCollection collectionObj)
		{
			return ProgettoAttiAffidamentoAllegatiDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ProgettoAttiAffidamentoAllegati progettoattiaffidamentoallegatiObj)
		{
			return ProgettoAttiAffidamentoAllegatiDAL.Delete(_dbProviderObj, progettoattiaffidamentoallegatiObj);
		}

		//getById
		public ProgettoAttiAffidamentoAllegati GetById(IntNT IdProgettoAttiAffidamentoAllegatiValue)
		{
			ProgettoAttiAffidamentoAllegati ProgettoAttiAffidamentoAllegatiTemp = ProgettoAttiAffidamentoAllegatiDAL.GetById(_dbProviderObj, IdProgettoAttiAffidamentoAllegatiValue);
			if (ProgettoAttiAffidamentoAllegatiTemp!=null) ProgettoAttiAffidamentoAllegatiTemp.Provider = this;
			return ProgettoAttiAffidamentoAllegatiTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ProgettoAttiAffidamentoAllegatiCollection Select(IntNT IdprogettoattiaffidamentoallegatiEqualThis, IntNT IdprogettoEqualThis, IntNT IdfileEqualThis, 
StringNT DescrizioneEqualThis, DatetimeNT DatainserimentoEqualThis, IntNT OperatoreinserimentoEqualThis, 
StringNT CodtipodocumentoEqualThis)
		{
			ProgettoAttiAffidamentoAllegatiCollection ProgettoAttiAffidamentoAllegatiCollectionTemp = ProgettoAttiAffidamentoAllegatiDAL.Select(_dbProviderObj, IdprogettoattiaffidamentoallegatiEqualThis, IdprogettoEqualThis, IdfileEqualThis, 
DescrizioneEqualThis, DatainserimentoEqualThis, OperatoreinserimentoEqualThis, 
CodtipodocumentoEqualThis);
			ProgettoAttiAffidamentoAllegatiCollectionTemp.Provider = this;
			return ProgettoAttiAffidamentoAllegatiCollectionTemp;
		}

		//Find: popola la collection
		public ProgettoAttiAffidamentoAllegatiCollection Find(IntNT IdprogettoattiaffidamentoallegatiEqualThis, IntNT IdprogettoEqualThis, IntNT IdfileEqualThis)
		{
			ProgettoAttiAffidamentoAllegatiCollection ProgettoAttiAffidamentoAllegatiCollectionTemp = ProgettoAttiAffidamentoAllegatiDAL.Find(_dbProviderObj, IdprogettoattiaffidamentoallegatiEqualThis, IdprogettoEqualThis, IdfileEqualThis);
			ProgettoAttiAffidamentoAllegatiCollectionTemp.Provider = this;
			return ProgettoAttiAffidamentoAllegatiCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PROGETTO_ATTI_AFFIDAMENTO_ALLEGATI>
  <ViewName>vPROGETTO_ATTI_AFFIDAMENTO_ALLEGATI</ViewName>
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
      <ID_PROGETTO_ATTI_AFFIDAMENTO_ALLEGATI>Equal</ID_PROGETTO_ATTI_AFFIDAMENTO_ALLEGATI>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_FILE>Equal</ID_FILE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PROGETTO_ATTI_AFFIDAMENTO_ALLEGATI>
*/
