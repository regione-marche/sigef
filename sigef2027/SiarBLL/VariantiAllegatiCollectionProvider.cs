using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per VariantiAllegati
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IVariantiAllegatiProvider
	{
		int Save(VariantiAllegati VariantiAllegatiObj);
		int SaveCollection(VariantiAllegatiCollection collectionObj);
		int Delete(VariantiAllegati VariantiAllegatiObj);
		int DeleteCollection(VariantiAllegatiCollection collectionObj);
	}
	/// <summary>
	/// Summary description for VariantiAllegati
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class VariantiAllegati: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdAllegato;
		private NullTypes.IntNT _IdVariante;
		private NullTypes.StringNT _CodTipoDocumento;
		private NullTypes.IntNT _IdFile;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.StringNT _CodEnteEmettitore;
		private NullTypes.IntNT _IdComune;
		private NullTypes.StringNT _Numero;
		private NullTypes.DatetimeNT _Data;
		private NullTypes.StringNT _CodEsito;
		private NullTypes.StringNT _NoteIstruttore;
		private NullTypes.StringNT _Esito;
		private NullTypes.BoolNT _EsitoPositivo;
		private NullTypes.StringNT _Formato;
		private NullTypes.StringNT _TipoAllegato;
		private NullTypes.StringNT _TipologiaDocumento;
		private NullTypes.StringNT _Ente;
		private NullTypes.IntNT _DimensioneFile;
		[NonSerialized] private IVariantiAllegatiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IVariantiAllegatiProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public VariantiAllegati()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_ALLEGATO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdAllegato
		{
			get { return _IdAllegato; }
			set {
				if (IdAllegato != value)
				{
					_IdAllegato = value;
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
		/// Corrisponde al campo:COD_ENTE_EMETTITORE
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT CodEnteEmettitore
		{
			get { return _CodEnteEmettitore; }
			set {
				if (CodEnteEmettitore != value)
				{
					_CodEnteEmettitore = value;
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
			set {
				if (IdComune != value)
				{
					_IdComune = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NUMERO
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT Numero
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
		/// Corrisponde al campo:DATA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT Data
		{
			get { return _Data; }
			set {
				if (Data != value)
				{
					_Data = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_ESITO
		/// Tipo sul db:CHAR(2)
		/// </summary>
		public NullTypes.StringNT CodEsito
		{
			get { return _CodEsito; }
			set {
				if (CodEsito != value)
				{
					_CodEsito = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOTE_ISTRUTTORE
		/// Tipo sul db:NTEXT
		/// </summary>
		public NullTypes.StringNT NoteIstruttore
		{
			get { return _NoteIstruttore; }
			set {
				if (NoteIstruttore != value)
				{
					_NoteIstruttore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ESITO
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT Esito
		{
			get { return _Esito; }
			set {
				if (Esito != value)
				{
					_Esito = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ESITO_POSITIVO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT EsitoPositivo
		{
			get { return _EsitoPositivo; }
			set {
				if (EsitoPositivo != value)
				{
					_EsitoPositivo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FORMATO
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT Formato
		{
			get { return _Formato; }
			set {
				if (Formato != value)
				{
					_Formato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO_ALLEGATO
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT TipoAllegato
		{
			get { return _TipoAllegato; }
			set {
				if (TipoAllegato != value)
				{
					_TipoAllegato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPOLOGIA_DOCUMENTO
		/// Tipo sul db:VARCHAR(250)
		/// </summary>
		public NullTypes.StringNT TipologiaDocumento
		{
			get { return _TipologiaDocumento; }
			set {
				if (TipologiaDocumento != value)
				{
					_TipologiaDocumento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ENTE
		/// Tipo sul db:VARCHAR(270)
		/// </summary>
		public NullTypes.StringNT Ente
		{
			get { return _Ente; }
			set {
				if (Ente != value)
				{
					_Ente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DIMENSIONE_FILE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT DimensioneFile
		{
			get { return _DimensioneFile; }
			set {
				if (DimensioneFile != value)
				{
					_DimensioneFile = value;
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
	/// Summary description for VariantiAllegatiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VariantiAllegatiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private VariantiAllegatiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((VariantiAllegati) info.GetValue(i.ToString(),typeof(VariantiAllegati)));
			}
		}

		//Costruttore
		public VariantiAllegatiCollection()
		{
			this.ItemType = typeof(VariantiAllegati);
		}

		//Costruttore con provider
		public VariantiAllegatiCollection(IVariantiAllegatiProvider providerObj)
		{
			this.ItemType = typeof(VariantiAllegati);
			this.Provider = providerObj;
		}

		//Get e Set
		public new VariantiAllegati this[int index]
		{
			get { return (VariantiAllegati)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VariantiAllegatiCollection GetChanges()
		{
			return (VariantiAllegatiCollection) base.GetChanges();
		}

		[NonSerialized] private IVariantiAllegatiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IVariantiAllegatiProvider Provider
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
		public int Add(VariantiAllegati VariantiAllegatiObj)
		{
			if (VariantiAllegatiObj.Provider == null) VariantiAllegatiObj.Provider = this.Provider;
			return base.Add(VariantiAllegatiObj);
		}

		//AddCollection
		public void AddCollection(VariantiAllegatiCollection VariantiAllegatiCollectionObj)
		{
			foreach (VariantiAllegati VariantiAllegatiObj in VariantiAllegatiCollectionObj)
				this.Add(VariantiAllegatiObj);
		}

		//Insert
		public void Insert(int index, VariantiAllegati VariantiAllegatiObj)
		{
			if (VariantiAllegatiObj.Provider == null) VariantiAllegatiObj.Provider = this.Provider;
			base.Insert(index, VariantiAllegatiObj);
		}

		//CollectionGetById
		public VariantiAllegati CollectionGetById(NullTypes.IntNT IdAllegatoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdAllegato == IdAllegatoValue))
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
		public VariantiAllegatiCollection SubSelect(NullTypes.IntNT IdAllegatoEqualThis, NullTypes.IntNT IdVarianteEqualThis, NullTypes.StringNT DescrizioneEqualThis, 
NullTypes.StringNT CodTipoDocumentoEqualThis, NullTypes.IntNT IdFileEqualThis, NullTypes.StringNT CodEnteEmettitoreEqualThis, 
NullTypes.IntNT IdComuneEqualThis, NullTypes.StringNT NumeroEqualThis, NullTypes.DatetimeNT DataEqualThis, 
NullTypes.StringNT CodEsitoEqualThis)
		{
			VariantiAllegatiCollection VariantiAllegatiCollectionTemp = new VariantiAllegatiCollection();
			foreach (VariantiAllegati VariantiAllegatiItem in this)
			{
				if (((IdAllegatoEqualThis == null) || ((VariantiAllegatiItem.IdAllegato != null) && (VariantiAllegatiItem.IdAllegato.Value == IdAllegatoEqualThis.Value))) && ((IdVarianteEqualThis == null) || ((VariantiAllegatiItem.IdVariante != null) && (VariantiAllegatiItem.IdVariante.Value == IdVarianteEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((VariantiAllegatiItem.Descrizione != null) && (VariantiAllegatiItem.Descrizione.Value == DescrizioneEqualThis.Value))) && 
((CodTipoDocumentoEqualThis == null) || ((VariantiAllegatiItem.CodTipoDocumento != null) && (VariantiAllegatiItem.CodTipoDocumento.Value == CodTipoDocumentoEqualThis.Value))) && ((IdFileEqualThis == null) || ((VariantiAllegatiItem.IdFile != null) && (VariantiAllegatiItem.IdFile.Value == IdFileEqualThis.Value))) && ((CodEnteEmettitoreEqualThis == null) || ((VariantiAllegatiItem.CodEnteEmettitore != null) && (VariantiAllegatiItem.CodEnteEmettitore.Value == CodEnteEmettitoreEqualThis.Value))) && 
((IdComuneEqualThis == null) || ((VariantiAllegatiItem.IdComune != null) && (VariantiAllegatiItem.IdComune.Value == IdComuneEqualThis.Value))) && ((NumeroEqualThis == null) || ((VariantiAllegatiItem.Numero != null) && (VariantiAllegatiItem.Numero.Value == NumeroEqualThis.Value))) && ((DataEqualThis == null) || ((VariantiAllegatiItem.Data != null) && (VariantiAllegatiItem.Data.Value == DataEqualThis.Value))) && 
((CodEsitoEqualThis == null) || ((VariantiAllegatiItem.CodEsito != null) && (VariantiAllegatiItem.CodEsito.Value == CodEsitoEqualThis.Value))))
				{
					VariantiAllegatiCollectionTemp.Add(VariantiAllegatiItem);
				}
			}
			return VariantiAllegatiCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for VariantiAllegatiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class VariantiAllegatiDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, VariantiAllegati VariantiAllegatiObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdAllegato", VariantiAllegatiObj.IdAllegato);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdVariante", VariantiAllegatiObj.IdVariante);
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipoDocumento", VariantiAllegatiObj.CodTipoDocumento);
			DbProvider.SetCmdParam(cmd,firstChar + "IdFile", VariantiAllegatiObj.IdFile);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", VariantiAllegatiObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "CodEnteEmettitore", VariantiAllegatiObj.CodEnteEmettitore);
			DbProvider.SetCmdParam(cmd,firstChar + "IdComune", VariantiAllegatiObj.IdComune);
			DbProvider.SetCmdParam(cmd,firstChar + "Numero", VariantiAllegatiObj.Numero);
			DbProvider.SetCmdParam(cmd,firstChar + "Data", VariantiAllegatiObj.Data);
			DbProvider.SetCmdParam(cmd,firstChar + "CodEsito", VariantiAllegatiObj.CodEsito);
			DbProvider.SetCmdParam(cmd,firstChar + "NoteIstruttore", VariantiAllegatiObj.NoteIstruttore);
		}
		//Insert
		private static int Insert(DbProvider db, VariantiAllegati VariantiAllegatiObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZVariantiAllegatiInsert", new string[] {"IdVariante", "CodTipoDocumento", 
"IdFile", "Descrizione", "CodEnteEmettitore", 
"IdComune", "Numero", "Data", 
"CodEsito", "NoteIstruttore", 
}, new string[] {"int", "string", 
"int", "string", "string", 
"int", "string", "DateTime", 
"string", "string", 
},"");
				CompileIUCmd(false, insertCmd,VariantiAllegatiObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				VariantiAllegatiObj.IdAllegato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ALLEGATO"]);
				}
				VariantiAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VariantiAllegatiObj.IsDirty = false;
				VariantiAllegatiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, VariantiAllegati VariantiAllegatiObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZVariantiAllegatiUpdate", new string[] {"IdAllegato", "IdVariante", "CodTipoDocumento", 
"IdFile", "Descrizione", "CodEnteEmettitore", 
"IdComune", "Numero", "Data", 
"CodEsito", "NoteIstruttore", 
}, new string[] {"int", "int", "string", 
"int", "string", "string", 
"int", "string", "DateTime", 
"string", "string", 
},"");
				CompileIUCmd(true, updateCmd,VariantiAllegatiObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				VariantiAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VariantiAllegatiObj.IsDirty = false;
				VariantiAllegatiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, VariantiAllegati VariantiAllegatiObj)
		{
			switch (VariantiAllegatiObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, VariantiAllegatiObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, VariantiAllegatiObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,VariantiAllegatiObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, VariantiAllegatiCollection VariantiAllegatiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZVariantiAllegatiUpdate", new string[] {"IdAllegato", "IdVariante", "CodTipoDocumento", 
"IdFile", "Descrizione", "CodEnteEmettitore", 
"IdComune", "Numero", "Data", 
"CodEsito", "NoteIstruttore", 
}, new string[] {"int", "int", "string", 
"int", "string", "string", 
"int", "string", "DateTime", 
"string", "string", 
},"");
				IDbCommand insertCmd = db.InitCmd( "ZVariantiAllegatiInsert", new string[] {"IdVariante", "CodTipoDocumento", 
"IdFile", "Descrizione", "CodEnteEmettitore", 
"IdComune", "Numero", "Data", 
"CodEsito", "NoteIstruttore", 
}, new string[] {"int", "string", 
"int", "string", "string", 
"int", "string", "DateTime", 
"string", "string", 
},"");
				IDbCommand deleteCmd = db.InitCmd( "ZVariantiAllegatiDelete", new string[] {"IdAllegato"}, new string[] {"int"},"");
				for (int i = 0; i < VariantiAllegatiCollectionObj.Count; i++)
				{
					switch (VariantiAllegatiCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,VariantiAllegatiCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									VariantiAllegatiCollectionObj[i].IdAllegato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ALLEGATO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,VariantiAllegatiCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (VariantiAllegatiCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdAllegato", (SiarLibrary.NullTypes.IntNT)VariantiAllegatiCollectionObj[i].IdAllegato);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < VariantiAllegatiCollectionObj.Count; i++)
				{
					if ((VariantiAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (VariantiAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						VariantiAllegatiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						VariantiAllegatiCollectionObj[i].IsDirty = false;
						VariantiAllegatiCollectionObj[i].IsPersistent = true;
					}
					if ((VariantiAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						VariantiAllegatiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						VariantiAllegatiCollectionObj[i].IsDirty = false;
						VariantiAllegatiCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, VariantiAllegati VariantiAllegatiObj)
		{
			int returnValue = 0;
			if (VariantiAllegatiObj.IsPersistent) 
			{
				returnValue = Delete(db, VariantiAllegatiObj.IdAllegato);
			}
			VariantiAllegatiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			VariantiAllegatiObj.IsDirty = false;
			VariantiAllegatiObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdAllegatoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZVariantiAllegatiDelete", new string[] {"IdAllegato"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdAllegato", (SiarLibrary.NullTypes.IntNT)IdAllegatoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, VariantiAllegatiCollection VariantiAllegatiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZVariantiAllegatiDelete", new string[] {"IdAllegato"}, new string[] {"int"},"");
				for (int i = 0; i < VariantiAllegatiCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdAllegato", VariantiAllegatiCollectionObj[i].IdAllegato);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < VariantiAllegatiCollectionObj.Count; i++)
				{
					if ((VariantiAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (VariantiAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						VariantiAllegatiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						VariantiAllegatiCollectionObj[i].IsDirty = false;
						VariantiAllegatiCollectionObj[i].IsPersistent = false;
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
		public static VariantiAllegati GetById(DbProvider db, int IdAllegatoValue)
		{
			VariantiAllegati VariantiAllegatiObj = null;
			IDbCommand readCmd = db.InitCmd( "ZVariantiAllegatiGetById", new string[] {"IdAllegato"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdAllegato", (SiarLibrary.NullTypes.IntNT)IdAllegatoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				VariantiAllegatiObj = GetFromDatareader(db);
				VariantiAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VariantiAllegatiObj.IsDirty = false;
				VariantiAllegatiObj.IsPersistent = true;
			}
			db.Close();
			return VariantiAllegatiObj;
		}

		//getFromDatareader
		public static VariantiAllegati GetFromDatareader(DbProvider db)
		{
			VariantiAllegati VariantiAllegatiObj = new VariantiAllegati();
			VariantiAllegatiObj.IdAllegato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ALLEGATO"]);
			VariantiAllegatiObj.IdVariante = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VARIANTE"]);
			VariantiAllegatiObj.CodTipoDocumento = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_DOCUMENTO"]);
			VariantiAllegatiObj.IdFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILE"]);
			VariantiAllegatiObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			VariantiAllegatiObj.CodEnteEmettitore = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE_EMETTITORE"]);
			VariantiAllegatiObj.IdComune = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COMUNE"]);
			VariantiAllegatiObj.Numero = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO"]);
			VariantiAllegatiObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
			VariantiAllegatiObj.CodEsito = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ESITO"]);
			VariantiAllegatiObj.NoteIstruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE_ISTRUTTORE"]);
			VariantiAllegatiObj.Esito = new SiarLibrary.NullTypes.StringNT(db.DataReader["ESITO"]);
			VariantiAllegatiObj.EsitoPositivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ESITO_POSITIVO"]);
			VariantiAllegatiObj.Formato = new SiarLibrary.NullTypes.StringNT(db.DataReader["FORMATO"]);
			VariantiAllegatiObj.TipoAllegato = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_ALLEGATO"]);
			VariantiAllegatiObj.TipologiaDocumento = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPOLOGIA_DOCUMENTO"]);
			VariantiAllegatiObj.Ente = new SiarLibrary.NullTypes.StringNT(db.DataReader["ENTE"]);
			VariantiAllegatiObj.DimensioneFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["DIMENSIONE_FILE"]);
			VariantiAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			VariantiAllegatiObj.IsDirty = false;
			VariantiAllegatiObj.IsPersistent = true;
			return VariantiAllegatiObj;
		}

		//Find Select

		public static VariantiAllegatiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdAllegatoEqualThis, SiarLibrary.NullTypes.IntNT IdVarianteEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, 
SiarLibrary.NullTypes.StringNT CodTipoDocumentoEqualThis, SiarLibrary.NullTypes.IntNT IdFileEqualThis, SiarLibrary.NullTypes.StringNT CodEnteEmettitoreEqualThis, 
SiarLibrary.NullTypes.IntNT IdComuneEqualThis, SiarLibrary.NullTypes.StringNT NumeroEqualThis, SiarLibrary.NullTypes.DatetimeNT DataEqualThis, 
SiarLibrary.NullTypes.StringNT CodEsitoEqualThis)

		{

			VariantiAllegatiCollection VariantiAllegatiCollectionObj = new VariantiAllegatiCollection();

			IDbCommand findCmd = db.InitCmd("Zvariantiallegatifindselect", new string[] {"IdAllegatoequalthis", "IdVarianteequalthis", "Descrizioneequalthis", 
"CodTipoDocumentoequalthis", "IdFileequalthis", "CodEnteEmettitoreequalthis", 
"IdComuneequalthis", "Numeroequalthis", "Dataequalthis", 
"CodEsitoequalthis"}, new string[] {"int", "int", "string", 
"string", "int", "string", 
"int", "string", "DateTime", 
"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAllegatoequalthis", IdAllegatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdVarianteequalthis", IdVarianteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoDocumentoequalthis", CodTipoDocumentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFileequalthis", IdFileEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodEnteEmettitoreequalthis", CodEnteEmettitoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdComuneequalthis", IdComuneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Numeroequalthis", NumeroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Dataequalthis", DataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodEsitoequalthis", CodEsitoEqualThis);
			VariantiAllegati VariantiAllegatiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VariantiAllegatiObj = GetFromDatareader(db);
				VariantiAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VariantiAllegatiObj.IsDirty = false;
				VariantiAllegatiObj.IsPersistent = true;
				VariantiAllegatiCollectionObj.Add(VariantiAllegatiObj);
			}
			db.Close();
			return VariantiAllegatiCollectionObj;
		}

		//Find Find

		public static VariantiAllegatiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdVarianteEqualThis, SiarLibrary.NullTypes.StringNT CodTipoDocumentoEqualThis, SiarLibrary.NullTypes.StringNT FormatoEqualThis)

		{

			VariantiAllegatiCollection VariantiAllegatiCollectionObj = new VariantiAllegatiCollection();

			IDbCommand findCmd = db.InitCmd("Zvariantiallegatifindfind", new string[] {"IdVarianteequalthis", "CodTipoDocumentoequalthis", "Formatoequalthis"}, new string[] {"int", "string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdVarianteequalthis", IdVarianteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoDocumentoequalthis", CodTipoDocumentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Formatoequalthis", FormatoEqualThis);
			VariantiAllegati VariantiAllegatiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VariantiAllegatiObj = GetFromDatareader(db);
				VariantiAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VariantiAllegatiObj.IsDirty = false;
				VariantiAllegatiObj.IsPersistent = true;
				VariantiAllegatiCollectionObj.Add(VariantiAllegatiObj);
			}
			db.Close();
			return VariantiAllegatiCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for VariantiAllegatiCollectionProvider:IVariantiAllegatiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VariantiAllegatiCollectionProvider : IVariantiAllegatiProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di VariantiAllegati
		protected VariantiAllegatiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public VariantiAllegatiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new VariantiAllegatiCollection(this);
		}

		//Costruttore 2: popola la collection
		public VariantiAllegatiCollectionProvider(IntNT IdvarianteEqualThis, StringNT CodtipodocumentoEqualThis, StringNT FormatoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdvarianteEqualThis, CodtipodocumentoEqualThis, FormatoEqualThis);
		}

		//Costruttore3: ha in input variantiallegatiCollectionObj - non popola la collection
		public VariantiAllegatiCollectionProvider(VariantiAllegatiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public VariantiAllegatiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new VariantiAllegatiCollection(this);
		}

		//Get e Set
		public VariantiAllegatiCollection CollectionObj
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
		public int SaveCollection(VariantiAllegatiCollection collectionObj)
		{
			return VariantiAllegatiDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(VariantiAllegati variantiallegatiObj)
		{
			return VariantiAllegatiDAL.Save(_dbProviderObj, variantiallegatiObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(VariantiAllegatiCollection collectionObj)
		{
			return VariantiAllegatiDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(VariantiAllegati variantiallegatiObj)
		{
			return VariantiAllegatiDAL.Delete(_dbProviderObj, variantiallegatiObj);
		}

		//getById
		public VariantiAllegati GetById(IntNT IdAllegatoValue)
		{
			VariantiAllegati VariantiAllegatiTemp = VariantiAllegatiDAL.GetById(_dbProviderObj, IdAllegatoValue);
			if (VariantiAllegatiTemp!=null) VariantiAllegatiTemp.Provider = this;
			return VariantiAllegatiTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public VariantiAllegatiCollection Select(IntNT IdallegatoEqualThis, IntNT IdvarianteEqualThis, StringNT DescrizioneEqualThis, 
StringNT CodtipodocumentoEqualThis, IntNT IdfileEqualThis, StringNT CodenteemettitoreEqualThis, 
IntNT IdcomuneEqualThis, StringNT NumeroEqualThis, DatetimeNT DataEqualThis, 
StringNT CodesitoEqualThis)
		{
			VariantiAllegatiCollection VariantiAllegatiCollectionTemp = VariantiAllegatiDAL.Select(_dbProviderObj, IdallegatoEqualThis, IdvarianteEqualThis, DescrizioneEqualThis, 
CodtipodocumentoEqualThis, IdfileEqualThis, CodenteemettitoreEqualThis, 
IdcomuneEqualThis, NumeroEqualThis, DataEqualThis, 
CodesitoEqualThis);
			VariantiAllegatiCollectionTemp.Provider = this;
			return VariantiAllegatiCollectionTemp;
		}

		//Find: popola la collection
		public VariantiAllegatiCollection Find(IntNT IdvarianteEqualThis, StringNT CodtipodocumentoEqualThis, StringNT FormatoEqualThis)
		{
			VariantiAllegatiCollection VariantiAllegatiCollectionTemp = VariantiAllegatiDAL.Find(_dbProviderObj, IdvarianteEqualThis, CodtipodocumentoEqualThis, FormatoEqualThis);
			VariantiAllegatiCollectionTemp.Provider = this;
			return VariantiAllegatiCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<VARIANTI_ALLEGATI>
  <ViewName>vVARIANTI_ALLEGATI</ViewName>
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
      <ID_VARIANTE>Equal</ID_VARIANTE>
      <COD_TIPO_DOCUMENTO>Equal</COD_TIPO_DOCUMENTO>
      <FORMATO>Equal</FORMATO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</VARIANTI_ALLEGATI>
*/
