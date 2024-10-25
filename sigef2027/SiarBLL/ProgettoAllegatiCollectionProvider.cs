using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ProgettoAllegati
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IProgettoAllegatiProvider
	{
		int Save(ProgettoAllegati ProgettoAllegatiObj);
		int SaveCollection(ProgettoAllegatiCollection collectionObj);
		int Delete(ProgettoAllegati ProgettoAllegatiObj);
		int DeleteCollection(ProgettoAllegatiCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ProgettoAllegati
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ProgettoAllegati: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdAllegato;
		private NullTypes.IntNT _IdFile;
		private NullTypes.StringNT _DescrizioneBreve;
		private NullTypes.StringNT _CodEnteEmettitore;
		private NullTypes.IntNT _IdComune;
		private NullTypes.StringNT _Numero;
		private NullTypes.DatetimeNT _Data;
		private NullTypes.BoolNT _GiaPresentato;
		private NullTypes.StringNT _CodEsitoIstruttoria;
		private NullTypes.StringNT _NoteIstruttoria;
		private NullTypes.StringNT _Allegato;
		private NullTypes.StringNT _Misura;
		private NullTypes.StringNT _CodTipoEnteEmettitore;
		private NullTypes.StringNT _Esito;
		private NullTypes.BoolNT _EsitoPositivo;
		private NullTypes.StringNT _CodTipo;
		private NullTypes.StringNT _TipoAllegato;
		private NullTypes.StringNT _Ente;
		private NullTypes.IntNT _DimensioneFile;
		[NonSerialized] private IProgettoAllegatiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IProgettoAllegatiProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ProgettoAllegati()
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
		/// Corrisponde al campo:DESCRIZIONE_BREVE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT DescrizioneBreve
		{
			get { return _DescrizioneBreve; }
			set {
				if (DescrizioneBreve != value)
				{
					_DescrizioneBreve = value;
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
		/// Corrisponde al campo:GIA_PRESENTATO
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT GiaPresentato
		{
			get { return _GiaPresentato; }
			set {
				if (GiaPresentato != value)
				{
					_GiaPresentato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_ESITO_ISTRUTTORIA
		/// Tipo sul db:CHAR(2)
		/// </summary>
		public NullTypes.StringNT CodEsitoIstruttoria
		{
			get { return _CodEsitoIstruttoria; }
			set {
				if (CodEsitoIstruttoria != value)
				{
					_CodEsitoIstruttoria = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOTE_ISTRUTTORIA
		/// Tipo sul db:VARCHAR(1000)
		/// </summary>
		public NullTypes.StringNT NoteIstruttoria
		{
			get { return _NoteIstruttoria; }
			set {
				if (NoteIstruttoria != value)
				{
					_NoteIstruttoria = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ALLEGATO
		/// Tipo sul db:VARCHAR(1000)
		/// </summary>
		public NullTypes.StringNT Allegato
		{
			get { return _Allegato; }
			set {
				if (Allegato != value)
				{
					_Allegato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MISURA
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT Misura
		{
			get { return _Misura; }
			set {
				if (Misura != value)
				{
					_Misura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_TIPO_ENTE_EMETTITORE
		/// Tipo sul db:CHAR(2)
		/// </summary>
		public NullTypes.StringNT CodTipoEnteEmettitore
		{
			get { return _CodTipoEnteEmettitore; }
			set {
				if (CodTipoEnteEmettitore != value)
				{
					_CodTipoEnteEmettitore = value;
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
		/// Corrisponde al campo:COD_TIPO
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT CodTipo
		{
			get { return _CodTipo; }
			set {
				if (CodTipo != value)
				{
					_CodTipo = value;
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
	/// Summary description for ProgettoAllegatiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProgettoAllegatiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ProgettoAllegatiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ProgettoAllegati) info.GetValue(i.ToString(),typeof(ProgettoAllegati)));
			}
		}

		//Costruttore
		public ProgettoAllegatiCollection()
		{
			this.ItemType = typeof(ProgettoAllegati);
		}

		//Costruttore con provider
		public ProgettoAllegatiCollection(IProgettoAllegatiProvider providerObj)
		{
			this.ItemType = typeof(ProgettoAllegati);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ProgettoAllegati this[int index]
		{
			get { return (ProgettoAllegati)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ProgettoAllegatiCollection GetChanges()
		{
			return (ProgettoAllegatiCollection) base.GetChanges();
		}

		[NonSerialized] private IProgettoAllegatiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IProgettoAllegatiProvider Provider
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
		public int Add(ProgettoAllegati ProgettoAllegatiObj)
		{
			if (ProgettoAllegatiObj.Provider == null) ProgettoAllegatiObj.Provider = this.Provider;
			return base.Add(ProgettoAllegatiObj);
		}

		//AddCollection
		public void AddCollection(ProgettoAllegatiCollection ProgettoAllegatiCollectionObj)
		{
			foreach (ProgettoAllegati ProgettoAllegatiObj in ProgettoAllegatiCollectionObj)
				this.Add(ProgettoAllegatiObj);
		}

		//Insert
		public void Insert(int index, ProgettoAllegati ProgettoAllegatiObj)
		{
			if (ProgettoAllegatiObj.Provider == null) ProgettoAllegatiObj.Provider = this.Provider;
			base.Insert(index, ProgettoAllegatiObj);
		}

		//CollectionGetById
		public ProgettoAllegati CollectionGetById(NullTypes.IntNT IdValue)
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
		public ProgettoAllegatiCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdAllegatoEqualThis, 
NullTypes.IntNT IdFileEqualThis, NullTypes.StringNT DescrizioneBreveEqualThis, NullTypes.StringNT CodEnteEmettitoreEqualThis, 
NullTypes.IntNT IdComuneEqualThis, NullTypes.StringNT NumeroEqualThis, NullTypes.DatetimeNT DataEqualThis, 
NullTypes.BoolNT GiaPresentatoEqualThis, NullTypes.StringNT CodEsitoIstruttoriaEqualThis, NullTypes.StringNT NoteIstruttoriaEqualThis)
		{
			ProgettoAllegatiCollection ProgettoAllegatiCollectionTemp = new ProgettoAllegatiCollection();
			foreach (ProgettoAllegati ProgettoAllegatiItem in this)
			{
				if (((IdEqualThis == null) || ((ProgettoAllegatiItem.Id != null) && (ProgettoAllegatiItem.Id.Value == IdEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((ProgettoAllegatiItem.IdProgetto != null) && (ProgettoAllegatiItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdAllegatoEqualThis == null) || ((ProgettoAllegatiItem.IdAllegato != null) && (ProgettoAllegatiItem.IdAllegato.Value == IdAllegatoEqualThis.Value))) && 
((IdFileEqualThis == null) || ((ProgettoAllegatiItem.IdFile != null) && (ProgettoAllegatiItem.IdFile.Value == IdFileEqualThis.Value))) && ((DescrizioneBreveEqualThis == null) || ((ProgettoAllegatiItem.DescrizioneBreve != null) && (ProgettoAllegatiItem.DescrizioneBreve.Value == DescrizioneBreveEqualThis.Value))) && ((CodEnteEmettitoreEqualThis == null) || ((ProgettoAllegatiItem.CodEnteEmettitore != null) && (ProgettoAllegatiItem.CodEnteEmettitore.Value == CodEnteEmettitoreEqualThis.Value))) && 
((IdComuneEqualThis == null) || ((ProgettoAllegatiItem.IdComune != null) && (ProgettoAllegatiItem.IdComune.Value == IdComuneEqualThis.Value))) && ((NumeroEqualThis == null) || ((ProgettoAllegatiItem.Numero != null) && (ProgettoAllegatiItem.Numero.Value == NumeroEqualThis.Value))) && ((DataEqualThis == null) || ((ProgettoAllegatiItem.Data != null) && (ProgettoAllegatiItem.Data.Value == DataEqualThis.Value))) && 
((GiaPresentatoEqualThis == null) || ((ProgettoAllegatiItem.GiaPresentato != null) && (ProgettoAllegatiItem.GiaPresentato.Value == GiaPresentatoEqualThis.Value))) && ((CodEsitoIstruttoriaEqualThis == null) || ((ProgettoAllegatiItem.CodEsitoIstruttoria != null) && (ProgettoAllegatiItem.CodEsitoIstruttoria.Value == CodEsitoIstruttoriaEqualThis.Value))) && ((NoteIstruttoriaEqualThis == null) || ((ProgettoAllegatiItem.NoteIstruttoria != null) && (ProgettoAllegatiItem.NoteIstruttoria.Value == NoteIstruttoriaEqualThis.Value))))
				{
					ProgettoAllegatiCollectionTemp.Add(ProgettoAllegatiItem);
				}
			}
			return ProgettoAllegatiCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ProgettoAllegatiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ProgettoAllegatiDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ProgettoAllegati ProgettoAllegatiObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", ProgettoAllegatiObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", ProgettoAllegatiObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdAllegato", ProgettoAllegatiObj.IdAllegato);
			DbProvider.SetCmdParam(cmd,firstChar + "IdFile", ProgettoAllegatiObj.IdFile);
			DbProvider.SetCmdParam(cmd,firstChar + "DescrizioneBreve", ProgettoAllegatiObj.DescrizioneBreve);
			DbProvider.SetCmdParam(cmd,firstChar + "CodEnteEmettitore", ProgettoAllegatiObj.CodEnteEmettitore);
			DbProvider.SetCmdParam(cmd,firstChar + "IdComune", ProgettoAllegatiObj.IdComune);
			DbProvider.SetCmdParam(cmd,firstChar + "Numero", ProgettoAllegatiObj.Numero);
			DbProvider.SetCmdParam(cmd,firstChar + "Data", ProgettoAllegatiObj.Data);
			DbProvider.SetCmdParam(cmd,firstChar + "GiaPresentato", ProgettoAllegatiObj.GiaPresentato);
			DbProvider.SetCmdParam(cmd,firstChar + "CodEsitoIstruttoria", ProgettoAllegatiObj.CodEsitoIstruttoria);
			DbProvider.SetCmdParam(cmd,firstChar + "NoteIstruttoria", ProgettoAllegatiObj.NoteIstruttoria);
		}
		//Insert
		private static int Insert(DbProvider db, ProgettoAllegati ProgettoAllegatiObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZProgettoAllegatiInsert", new string[] {"IdProgetto", "IdAllegato", 
"IdFile", "DescrizioneBreve", "CodEnteEmettitore", 
"IdComune", "Numero", "Data", 
"GiaPresentato", "CodEsitoIstruttoria", "NoteIstruttoria", 

}, new string[] {"int", "int", 
"int", "string", "string", 
"int", "string", "DateTime", 
"bool", "string", "string", 

},"");
				CompileIUCmd(false, insertCmd,ProgettoAllegatiObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ProgettoAllegatiObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				ProgettoAllegatiObj.GiaPresentato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["GIA_PRESENTATO"]);
				}
				ProgettoAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoAllegatiObj.IsDirty = false;
				ProgettoAllegatiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ProgettoAllegati ProgettoAllegatiObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZProgettoAllegatiUpdate", new string[] {"Id", "IdProgetto", "IdAllegato", 
"IdFile", "DescrizioneBreve", "CodEnteEmettitore", 
"IdComune", "Numero", "Data", 
"GiaPresentato", "CodEsitoIstruttoria", "NoteIstruttoria", 

}, new string[] {"int", "int", "int", 
"int", "string", "string", 
"int", "string", "DateTime", 
"bool", "string", "string", 

},"");
				CompileIUCmd(true, updateCmd,ProgettoAllegatiObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ProgettoAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoAllegatiObj.IsDirty = false;
				ProgettoAllegatiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ProgettoAllegati ProgettoAllegatiObj)
		{
			switch (ProgettoAllegatiObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ProgettoAllegatiObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ProgettoAllegatiObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ProgettoAllegatiObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ProgettoAllegatiCollection ProgettoAllegatiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZProgettoAllegatiUpdate", new string[] {"Id", "IdProgetto", "IdAllegato", 
"IdFile", "DescrizioneBreve", "CodEnteEmettitore", 
"IdComune", "Numero", "Data", 
"GiaPresentato", "CodEsitoIstruttoria", "NoteIstruttoria", 

}, new string[] {"int", "int", "int", 
"int", "string", "string", 
"int", "string", "DateTime", 
"bool", "string", "string", 

},"");
				IDbCommand insertCmd = db.InitCmd( "ZProgettoAllegatiInsert", new string[] {"IdProgetto", "IdAllegato", 
"IdFile", "DescrizioneBreve", "CodEnteEmettitore", 
"IdComune", "Numero", "Data", 
"GiaPresentato", "CodEsitoIstruttoria", "NoteIstruttoria", 

}, new string[] {"int", "int", 
"int", "string", "string", 
"int", "string", "DateTime", 
"bool", "string", "string", 

},"");
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoAllegatiDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ProgettoAllegatiCollectionObj.Count; i++)
				{
					switch (ProgettoAllegatiCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ProgettoAllegatiCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ProgettoAllegatiCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
									ProgettoAllegatiCollectionObj[i].GiaPresentato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["GIA_PRESENTATO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ProgettoAllegatiCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ProgettoAllegatiCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)ProgettoAllegatiCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ProgettoAllegatiCollectionObj.Count; i++)
				{
					if ((ProgettoAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettoAllegatiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ProgettoAllegatiCollectionObj[i].IsDirty = false;
						ProgettoAllegatiCollectionObj[i].IsPersistent = true;
					}
					if ((ProgettoAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ProgettoAllegatiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettoAllegatiCollectionObj[i].IsDirty = false;
						ProgettoAllegatiCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ProgettoAllegati ProgettoAllegatiObj)
		{
			int returnValue = 0;
			if (ProgettoAllegatiObj.IsPersistent) 
			{
				returnValue = Delete(db, ProgettoAllegatiObj.Id);
			}
			ProgettoAllegatiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ProgettoAllegatiObj.IsDirty = false;
			ProgettoAllegatiObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoAllegatiDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ProgettoAllegatiCollection ProgettoAllegatiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoAllegatiDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ProgettoAllegatiCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", ProgettoAllegatiCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ProgettoAllegatiCollectionObj.Count; i++)
				{
					if ((ProgettoAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettoAllegatiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettoAllegatiCollectionObj[i].IsDirty = false;
						ProgettoAllegatiCollectionObj[i].IsPersistent = false;
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
		public static ProgettoAllegati GetById(DbProvider db, int IdValue)
		{
			ProgettoAllegati ProgettoAllegatiObj = null;
			IDbCommand readCmd = db.InitCmd( "ZProgettoAllegatiGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ProgettoAllegatiObj = GetFromDatareader(db);
				ProgettoAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoAllegatiObj.IsDirty = false;
				ProgettoAllegatiObj.IsPersistent = true;
			}
			db.Close();
			return ProgettoAllegatiObj;
		}

		//getFromDatareader
		public static ProgettoAllegati GetFromDatareader(DbProvider db)
		{
			ProgettoAllegati ProgettoAllegatiObj = new ProgettoAllegati();
			ProgettoAllegatiObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			ProgettoAllegatiObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			ProgettoAllegatiObj.IdAllegato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ALLEGATO"]);
			ProgettoAllegatiObj.IdFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILE"]);
			ProgettoAllegatiObj.DescrizioneBreve = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_BREVE"]);
			ProgettoAllegatiObj.CodEnteEmettitore = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE_EMETTITORE"]);
			ProgettoAllegatiObj.IdComune = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COMUNE"]);
			ProgettoAllegatiObj.Numero = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO"]);
			ProgettoAllegatiObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
			ProgettoAllegatiObj.GiaPresentato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["GIA_PRESENTATO"]);
			ProgettoAllegatiObj.CodEsitoIstruttoria = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ESITO_ISTRUTTORIA"]);
			ProgettoAllegatiObj.NoteIstruttoria = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE_ISTRUTTORIA"]);
			ProgettoAllegatiObj.Allegato = new SiarLibrary.NullTypes.StringNT(db.DataReader["ALLEGATO"]);
			ProgettoAllegatiObj.Misura = new SiarLibrary.NullTypes.StringNT(db.DataReader["MISURA"]);
			ProgettoAllegatiObj.CodTipoEnteEmettitore = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_ENTE_EMETTITORE"]);
			ProgettoAllegatiObj.Esito = new SiarLibrary.NullTypes.StringNT(db.DataReader["ESITO"]);
			ProgettoAllegatiObj.EsitoPositivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ESITO_POSITIVO"]);
			ProgettoAllegatiObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
			ProgettoAllegatiObj.TipoAllegato = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_ALLEGATO"]);
			ProgettoAllegatiObj.Ente = new SiarLibrary.NullTypes.StringNT(db.DataReader["ENTE"]);
			ProgettoAllegatiObj.DimensioneFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["DIMENSIONE_FILE"]);
			ProgettoAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ProgettoAllegatiObj.IsDirty = false;
			ProgettoAllegatiObj.IsPersistent = true;
			return ProgettoAllegatiObj;
		}

		//Find Select

		public static ProgettoAllegatiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdAllegatoEqualThis, 
SiarLibrary.NullTypes.IntNT IdFileEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneBreveEqualThis, SiarLibrary.NullTypes.StringNT CodEnteEmettitoreEqualThis, 
SiarLibrary.NullTypes.IntNT IdComuneEqualThis, SiarLibrary.NullTypes.StringNT NumeroEqualThis, SiarLibrary.NullTypes.DatetimeNT DataEqualThis, 
SiarLibrary.NullTypes.BoolNT GiaPresentatoEqualThis, SiarLibrary.NullTypes.StringNT CodEsitoIstruttoriaEqualThis, SiarLibrary.NullTypes.StringNT NoteIstruttoriaEqualThis)

		{

			ProgettoAllegatiCollection ProgettoAllegatiCollectionObj = new ProgettoAllegatiCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettoallegatifindselect", new string[] {"Idequalthis", "IdProgettoequalthis", "IdAllegatoequalthis", 
"IdFileequalthis", "DescrizioneBreveequalthis", "CodEnteEmettitoreequalthis", 
"IdComuneequalthis", "Numeroequalthis", "Dataequalthis", 
"GiaPresentatoequalthis", "CodEsitoIstruttoriaequalthis", "NoteIstruttoriaequalthis"}, new string[] {"int", "int", "int", 
"int", "string", "string", 
"int", "string", "DateTime", 
"bool", "string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAllegatoequalthis", IdAllegatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFileequalthis", IdFileEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneBreveequalthis", DescrizioneBreveEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodEnteEmettitoreequalthis", CodEnteEmettitoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdComuneequalthis", IdComuneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Numeroequalthis", NumeroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Dataequalthis", DataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "GiaPresentatoequalthis", GiaPresentatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodEsitoIstruttoriaequalthis", CodEsitoIstruttoriaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NoteIstruttoriaequalthis", NoteIstruttoriaEqualThis);
			ProgettoAllegati ProgettoAllegatiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettoAllegatiObj = GetFromDatareader(db);
				ProgettoAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoAllegatiObj.IsDirty = false;
				ProgettoAllegatiObj.IsPersistent = true;
				ProgettoAllegatiCollectionObj.Add(ProgettoAllegatiObj);
			}
			db.Close();
			return ProgettoAllegatiCollectionObj;
		}

		//Find Find

		public static ProgettoAllegatiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis)

		{

			ProgettoAllegatiCollection ProgettoAllegatiCollectionObj = new ProgettoAllegatiCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettoallegatifindfind", new string[] {"IdProgettoequalthis", "CodTipoequalthis"}, new string[] {"int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
			ProgettoAllegati ProgettoAllegatiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettoAllegatiObj = GetFromDatareader(db);
				ProgettoAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoAllegatiObj.IsDirty = false;
				ProgettoAllegatiObj.IsPersistent = true;
				ProgettoAllegatiCollectionObj.Add(ProgettoAllegatiObj);
			}
			db.Close();
			return ProgettoAllegatiCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ProgettoAllegatiCollectionProvider:IProgettoAllegatiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProgettoAllegatiCollectionProvider : IProgettoAllegatiProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ProgettoAllegati
		protected ProgettoAllegatiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ProgettoAllegatiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ProgettoAllegatiCollection(this);
		}

		//Costruttore 2: popola la collection
		public ProgettoAllegatiCollectionProvider(IntNT IdprogettoEqualThis, StringNT CodtipoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdprogettoEqualThis, CodtipoEqualThis);
		}

		//Costruttore3: ha in input progettoallegatiCollectionObj - non popola la collection
		public ProgettoAllegatiCollectionProvider(ProgettoAllegatiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ProgettoAllegatiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ProgettoAllegatiCollection(this);
		}

		//Get e Set
		public ProgettoAllegatiCollection CollectionObj
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
		public int SaveCollection(ProgettoAllegatiCollection collectionObj)
		{
			return ProgettoAllegatiDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ProgettoAllegati progettoallegatiObj)
		{
			return ProgettoAllegatiDAL.Save(_dbProviderObj, progettoallegatiObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ProgettoAllegatiCollection collectionObj)
		{
			return ProgettoAllegatiDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ProgettoAllegati progettoallegatiObj)
		{
			return ProgettoAllegatiDAL.Delete(_dbProviderObj, progettoallegatiObj);
		}

		//getById
		public ProgettoAllegati GetById(IntNT IdValue)
		{
			ProgettoAllegati ProgettoAllegatiTemp = ProgettoAllegatiDAL.GetById(_dbProviderObj, IdValue);
			if (ProgettoAllegatiTemp!=null) ProgettoAllegatiTemp.Provider = this;
			return ProgettoAllegatiTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ProgettoAllegatiCollection Select(IntNT IdEqualThis, IntNT IdprogettoEqualThis, IntNT IdallegatoEqualThis, 
IntNT IdfileEqualThis, StringNT DescrizionebreveEqualThis, StringNT CodenteemettitoreEqualThis, 
IntNT IdcomuneEqualThis, StringNT NumeroEqualThis, DatetimeNT DataEqualThis, 
BoolNT GiapresentatoEqualThis, StringNT CodesitoistruttoriaEqualThis, StringNT NoteistruttoriaEqualThis)
		{
			ProgettoAllegatiCollection ProgettoAllegatiCollectionTemp = ProgettoAllegatiDAL.Select(_dbProviderObj, IdEqualThis, IdprogettoEqualThis, IdallegatoEqualThis, 
IdfileEqualThis, DescrizionebreveEqualThis, CodenteemettitoreEqualThis, 
IdcomuneEqualThis, NumeroEqualThis, DataEqualThis, 
GiapresentatoEqualThis, CodesitoistruttoriaEqualThis, NoteistruttoriaEqualThis);
			ProgettoAllegatiCollectionTemp.Provider = this;
			return ProgettoAllegatiCollectionTemp;
		}

		//Find: popola la collection
		public ProgettoAllegatiCollection Find(IntNT IdprogettoEqualThis, StringNT CodtipoEqualThis)
		{
			ProgettoAllegatiCollection ProgettoAllegatiCollectionTemp = ProgettoAllegatiDAL.Find(_dbProviderObj, IdprogettoEqualThis, CodtipoEqualThis);
			ProgettoAllegatiCollectionTemp.Provider = this;
			return ProgettoAllegatiCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PROGETTO_ALLEGATI>
  <ViewName>vPROGETTO_ALLEGATI</ViewName>
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
    <Find OrderBy="ORDER BY MISURA, ID">
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <COD_TIPO>Equal</COD_TIPO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PROGETTO_ALLEGATI>
*/
