using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ProgettoComunicazioniDocumenti
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IProgettoComunicazioniDocumentiProvider
	{
		int Save(ProgettoComunicazioniDocumenti ProgettoComunicazioniDocumentiObj);
		int SaveCollection(ProgettoComunicazioniDocumentiCollection collectionObj);
		int Delete(ProgettoComunicazioniDocumenti ProgettoComunicazioniDocumentiObj);
		int DeleteCollection(ProgettoComunicazioniDocumentiCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ProgettoComunicazioniDocumenti
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ProgettoComunicazioniDocumenti: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdComunicazione;
		private NullTypes.IntNT _IdDomandaPagamentoAllegati;
		private NullTypes.IntNT _IdVarianteAllegati;
		private NullTypes.StringNT _CodTipoDocumento;
		private NullTypes.IntNT _IdFile;
		private NullTypes.StringNT _CodEnteEmettitore;
		private NullTypes.IntNT _IdComune;
		private NullTypes.StringNT _Numero;
		private NullTypes.DatetimeNT _Data;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.IntNT _IdNoteComunicazione;
		private NullTypes.StringNT _Formato;
		private NullTypes.StringNT _DescrizioneDocumento;
		private NullTypes.BoolNT _Attivo;
		private NullTypes.StringNT _Ente;
		private NullTypes.StringNT _CodTipoEnte;
		private NullTypes.StringNT _Note;
		[NonSerialized] private IProgettoComunicazioniDocumentiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IProgettoComunicazioniDocumentiProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ProgettoComunicazioniDocumenti()
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
		/// Corrisponde al campo:ID_DOMANDA_PAGAMENTO_ALLEGATI
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDomandaPagamentoAllegati
		{
			get { return _IdDomandaPagamentoAllegati; }
			set {
				if (IdDomandaPagamentoAllegati != value)
				{
					_IdDomandaPagamentoAllegati = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_VARIANTE_ALLEGATI
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdVarianteAllegati
		{
			get { return _IdVarianteAllegati; }
			set {
				if (IdVarianteAllegati != value)
				{
					_IdVarianteAllegati = value;
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
		/// Corrisponde al campo:ID_NOTE_COMUNICAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdNoteComunicazione
		{
			get { return _IdNoteComunicazione; }
			set {
				if (IdNoteComunicazione != value)
				{
					_IdNoteComunicazione = value;
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
		/// Corrisponde al campo:DESCRIZIONE_DOCUMENTO
		/// Tipo sul db:VARCHAR(250)
		/// </summary>
		public NullTypes.StringNT DescrizioneDocumento
		{
			get { return _DescrizioneDocumento; }
			set {
				if (DescrizioneDocumento != value)
				{
					_DescrizioneDocumento = value;
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
		/// Corrisponde al campo:COD_TIPO_ENTE
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT CodTipoEnte
		{
			get { return _CodTipoEnte; }
			set {
				if (CodTipoEnte != value)
				{
					_CodTipoEnte = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOTE
		/// Tipo sul db:NVARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT Note
		{
			get { return _Note; }
			set {
				if (Note != value)
				{
					_Note = value;
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
	/// Summary description for ProgettoComunicazioniDocumentiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProgettoComunicazioniDocumentiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ProgettoComunicazioniDocumentiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ProgettoComunicazioniDocumenti) info.GetValue(i.ToString(),typeof(ProgettoComunicazioniDocumenti)));
			}
		}

		//Costruttore
		public ProgettoComunicazioniDocumentiCollection()
		{
			this.ItemType = typeof(ProgettoComunicazioniDocumenti);
		}

		//Costruttore con provider
		public ProgettoComunicazioniDocumentiCollection(IProgettoComunicazioniDocumentiProvider providerObj)
		{
			this.ItemType = typeof(ProgettoComunicazioniDocumenti);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ProgettoComunicazioniDocumenti this[int index]
		{
			get { return (ProgettoComunicazioniDocumenti)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ProgettoComunicazioniDocumentiCollection GetChanges()
		{
			return (ProgettoComunicazioniDocumentiCollection) base.GetChanges();
		}

		[NonSerialized] private IProgettoComunicazioniDocumentiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IProgettoComunicazioniDocumentiProvider Provider
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
		public int Add(ProgettoComunicazioniDocumenti ProgettoComunicazioniDocumentiObj)
		{
			if (ProgettoComunicazioniDocumentiObj.Provider == null) ProgettoComunicazioniDocumentiObj.Provider = this.Provider;
			return base.Add(ProgettoComunicazioniDocumentiObj);
		}

		//AddCollection
		public void AddCollection(ProgettoComunicazioniDocumentiCollection ProgettoComunicazioniDocumentiCollectionObj)
		{
			foreach (ProgettoComunicazioniDocumenti ProgettoComunicazioniDocumentiObj in ProgettoComunicazioniDocumentiCollectionObj)
				this.Add(ProgettoComunicazioniDocumentiObj);
		}

		//Insert
		public void Insert(int index, ProgettoComunicazioniDocumenti ProgettoComunicazioniDocumentiObj)
		{
			if (ProgettoComunicazioniDocumentiObj.Provider == null) ProgettoComunicazioniDocumentiObj.Provider = this.Provider;
			base.Insert(index, ProgettoComunicazioniDocumentiObj);
		}

		//CollectionGetById
		public ProgettoComunicazioniDocumenti CollectionGetById(NullTypes.IntNT IdValue)
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
		public ProgettoComunicazioniDocumentiCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdComunicazioneEqualThis, NullTypes.IntNT IdDomandaPagamentoAllegatiEqualThis, 
NullTypes.IntNT IdVarianteAllegatiEqualThis, NullTypes.StringNT CodTipoDocumentoEqualThis, NullTypes.IntNT IdFileEqualThis, 
NullTypes.StringNT CodEnteEmettitoreEqualThis, NullTypes.IntNT IdComuneEqualThis, NullTypes.StringNT NumeroEqualThis, 
NullTypes.DatetimeNT DataEqualThis, NullTypes.StringNT DescrizioneEqualThis, NullTypes.IntNT IdNoteComunicazioneEqualThis)
		{
			ProgettoComunicazioniDocumentiCollection ProgettoComunicazioniDocumentiCollectionTemp = new ProgettoComunicazioniDocumentiCollection();
			foreach (ProgettoComunicazioniDocumenti ProgettoComunicazioniDocumentiItem in this)
			{
				if (((IdEqualThis == null) || ((ProgettoComunicazioniDocumentiItem.Id != null) && (ProgettoComunicazioniDocumentiItem.Id.Value == IdEqualThis.Value))) && ((IdComunicazioneEqualThis == null) || ((ProgettoComunicazioniDocumentiItem.IdComunicazione != null) && (ProgettoComunicazioniDocumentiItem.IdComunicazione.Value == IdComunicazioneEqualThis.Value))) && ((IdDomandaPagamentoAllegatiEqualThis == null) || ((ProgettoComunicazioniDocumentiItem.IdDomandaPagamentoAllegati != null) && (ProgettoComunicazioniDocumentiItem.IdDomandaPagamentoAllegati.Value == IdDomandaPagamentoAllegatiEqualThis.Value))) && 
((IdVarianteAllegatiEqualThis == null) || ((ProgettoComunicazioniDocumentiItem.IdVarianteAllegati != null) && (ProgettoComunicazioniDocumentiItem.IdVarianteAllegati.Value == IdVarianteAllegatiEqualThis.Value))) && ((CodTipoDocumentoEqualThis == null) || ((ProgettoComunicazioniDocumentiItem.CodTipoDocumento != null) && (ProgettoComunicazioniDocumentiItem.CodTipoDocumento.Value == CodTipoDocumentoEqualThis.Value))) && ((IdFileEqualThis == null) || ((ProgettoComunicazioniDocumentiItem.IdFile != null) && (ProgettoComunicazioniDocumentiItem.IdFile.Value == IdFileEqualThis.Value))) && 
((CodEnteEmettitoreEqualThis == null) || ((ProgettoComunicazioniDocumentiItem.CodEnteEmettitore != null) && (ProgettoComunicazioniDocumentiItem.CodEnteEmettitore.Value == CodEnteEmettitoreEqualThis.Value))) && ((IdComuneEqualThis == null) || ((ProgettoComunicazioniDocumentiItem.IdComune != null) && (ProgettoComunicazioniDocumentiItem.IdComune.Value == IdComuneEqualThis.Value))) && ((NumeroEqualThis == null) || ((ProgettoComunicazioniDocumentiItem.Numero != null) && (ProgettoComunicazioniDocumentiItem.Numero.Value == NumeroEqualThis.Value))) && 
((DataEqualThis == null) || ((ProgettoComunicazioniDocumentiItem.Data != null) && (ProgettoComunicazioniDocumentiItem.Data.Value == DataEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((ProgettoComunicazioniDocumentiItem.Descrizione != null) && (ProgettoComunicazioniDocumentiItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((IdNoteComunicazioneEqualThis == null) || ((ProgettoComunicazioniDocumentiItem.IdNoteComunicazione != null) && (ProgettoComunicazioniDocumentiItem.IdNoteComunicazione.Value == IdNoteComunicazioneEqualThis.Value))))
				{
					ProgettoComunicazioniDocumentiCollectionTemp.Add(ProgettoComunicazioniDocumentiItem);
				}
			}
			return ProgettoComunicazioniDocumentiCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ProgettoComunicazioniDocumentiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ProgettoComunicazioniDocumentiDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ProgettoComunicazioniDocumenti ProgettoComunicazioniDocumentiObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", ProgettoComunicazioniDocumentiObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdComunicazione", ProgettoComunicazioniDocumentiObj.IdComunicazione);
			DbProvider.SetCmdParam(cmd,firstChar + "IdDomandaPagamentoAllegati", ProgettoComunicazioniDocumentiObj.IdDomandaPagamentoAllegati);
			DbProvider.SetCmdParam(cmd,firstChar + "IdVarianteAllegati", ProgettoComunicazioniDocumentiObj.IdVarianteAllegati);
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipoDocumento", ProgettoComunicazioniDocumentiObj.CodTipoDocumento);
			DbProvider.SetCmdParam(cmd,firstChar + "IdFile", ProgettoComunicazioniDocumentiObj.IdFile);
			DbProvider.SetCmdParam(cmd,firstChar + "CodEnteEmettitore", ProgettoComunicazioniDocumentiObj.CodEnteEmettitore);
			DbProvider.SetCmdParam(cmd,firstChar + "IdComune", ProgettoComunicazioniDocumentiObj.IdComune);
			DbProvider.SetCmdParam(cmd,firstChar + "Numero", ProgettoComunicazioniDocumentiObj.Numero);
			DbProvider.SetCmdParam(cmd,firstChar + "Data", ProgettoComunicazioniDocumentiObj.Data);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", ProgettoComunicazioniDocumentiObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "IdNoteComunicazione", ProgettoComunicazioniDocumentiObj.IdNoteComunicazione);
		}
		//Insert
		private static int Insert(DbProvider db, ProgettoComunicazioniDocumenti ProgettoComunicazioniDocumentiObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZProgettoComunicazioniDocumentiInsert", new string[] {"IdComunicazione", "IdDomandaPagamentoAllegati", 
"IdVarianteAllegati", "CodTipoDocumento", "IdFile", 
"CodEnteEmettitore", "IdComune", "Numero", 
"Data", "Descrizione", "IdNoteComunicazione", 
}, new string[] {"int", "int", 
"int", "string", "int", 
"string", "int", "string", 
"DateTime", "string", "int", 
},"");
				CompileIUCmd(false, insertCmd,ProgettoComunicazioniDocumentiObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ProgettoComunicazioniDocumentiObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				ProgettoComunicazioniDocumentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoComunicazioniDocumentiObj.IsDirty = false;
				ProgettoComunicazioniDocumentiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ProgettoComunicazioniDocumenti ProgettoComunicazioniDocumentiObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZProgettoComunicazioniDocumentiUpdate", new string[] {"Id", "IdComunicazione", "IdDomandaPagamentoAllegati", 
"IdVarianteAllegati", "CodTipoDocumento", "IdFile", 
"CodEnteEmettitore", "IdComune", "Numero", 
"Data", "Descrizione", "IdNoteComunicazione", 
}, new string[] {"int", "int", "int", 
"int", "string", "int", 
"string", "int", "string", 
"DateTime", "string", "int", 
},"");
				CompileIUCmd(true, updateCmd,ProgettoComunicazioniDocumentiObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ProgettoComunicazioniDocumentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoComunicazioniDocumentiObj.IsDirty = false;
				ProgettoComunicazioniDocumentiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ProgettoComunicazioniDocumenti ProgettoComunicazioniDocumentiObj)
		{
			switch (ProgettoComunicazioniDocumentiObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ProgettoComunicazioniDocumentiObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ProgettoComunicazioniDocumentiObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ProgettoComunicazioniDocumentiObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ProgettoComunicazioniDocumentiCollection ProgettoComunicazioniDocumentiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZProgettoComunicazioniDocumentiUpdate", new string[] {"Id", "IdComunicazione", "IdDomandaPagamentoAllegati", 
"IdVarianteAllegati", "CodTipoDocumento", "IdFile", 
"CodEnteEmettitore", "IdComune", "Numero", 
"Data", "Descrizione", "IdNoteComunicazione", 
}, new string[] {"int", "int", "int", 
"int", "string", "int", 
"string", "int", "string", 
"DateTime", "string", "int", 
},"");
				IDbCommand insertCmd = db.InitCmd( "ZProgettoComunicazioniDocumentiInsert", new string[] {"IdComunicazione", "IdDomandaPagamentoAllegati", 
"IdVarianteAllegati", "CodTipoDocumento", "IdFile", 
"CodEnteEmettitore", "IdComune", "Numero", 
"Data", "Descrizione", "IdNoteComunicazione", 
}, new string[] {"int", "int", 
"int", "string", "int", 
"string", "int", "string", 
"DateTime", "string", "int", 
},"");
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoComunicazioniDocumentiDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ProgettoComunicazioniDocumentiCollectionObj.Count; i++)
				{
					switch (ProgettoComunicazioniDocumentiCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ProgettoComunicazioniDocumentiCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ProgettoComunicazioniDocumentiCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ProgettoComunicazioniDocumentiCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ProgettoComunicazioniDocumentiCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)ProgettoComunicazioniDocumentiCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ProgettoComunicazioniDocumentiCollectionObj.Count; i++)
				{
					if ((ProgettoComunicazioniDocumentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoComunicazioniDocumentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettoComunicazioniDocumentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ProgettoComunicazioniDocumentiCollectionObj[i].IsDirty = false;
						ProgettoComunicazioniDocumentiCollectionObj[i].IsPersistent = true;
					}
					if ((ProgettoComunicazioniDocumentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ProgettoComunicazioniDocumentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettoComunicazioniDocumentiCollectionObj[i].IsDirty = false;
						ProgettoComunicazioniDocumentiCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ProgettoComunicazioniDocumenti ProgettoComunicazioniDocumentiObj)
		{
			int returnValue = 0;
			if (ProgettoComunicazioniDocumentiObj.IsPersistent) 
			{
				returnValue = Delete(db, ProgettoComunicazioniDocumentiObj.Id);
			}
			ProgettoComunicazioniDocumentiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ProgettoComunicazioniDocumentiObj.IsDirty = false;
			ProgettoComunicazioniDocumentiObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoComunicazioniDocumentiDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ProgettoComunicazioniDocumentiCollection ProgettoComunicazioniDocumentiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoComunicazioniDocumentiDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ProgettoComunicazioniDocumentiCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", ProgettoComunicazioniDocumentiCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ProgettoComunicazioniDocumentiCollectionObj.Count; i++)
				{
					if ((ProgettoComunicazioniDocumentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoComunicazioniDocumentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettoComunicazioniDocumentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettoComunicazioniDocumentiCollectionObj[i].IsDirty = false;
						ProgettoComunicazioniDocumentiCollectionObj[i].IsPersistent = false;
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
		public static ProgettoComunicazioniDocumenti GetById(DbProvider db, int IdValue)
		{
			ProgettoComunicazioniDocumenti ProgettoComunicazioniDocumentiObj = null;
			IDbCommand readCmd = db.InitCmd( "ZProgettoComunicazioniDocumentiGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ProgettoComunicazioniDocumentiObj = GetFromDatareader(db);
				ProgettoComunicazioniDocumentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoComunicazioniDocumentiObj.IsDirty = false;
				ProgettoComunicazioniDocumentiObj.IsPersistent = true;
			}
			db.Close();
			return ProgettoComunicazioniDocumentiObj;
		}

		//getFromDatareader
		public static ProgettoComunicazioniDocumenti GetFromDatareader(DbProvider db)
		{
			ProgettoComunicazioniDocumenti ProgettoComunicazioniDocumentiObj = new ProgettoComunicazioniDocumenti();
			ProgettoComunicazioniDocumentiObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			ProgettoComunicazioniDocumentiObj.IdComunicazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COMUNICAZIONE"]);
			ProgettoComunicazioniDocumentiObj.IdDomandaPagamentoAllegati = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO_ALLEGATI"]);
			ProgettoComunicazioniDocumentiObj.IdVarianteAllegati = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VARIANTE_ALLEGATI"]);
			ProgettoComunicazioniDocumentiObj.CodTipoDocumento = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_DOCUMENTO"]);
			ProgettoComunicazioniDocumentiObj.IdFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILE"]);
			ProgettoComunicazioniDocumentiObj.CodEnteEmettitore = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE_EMETTITORE"]);
			ProgettoComunicazioniDocumentiObj.IdComune = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COMUNE"]);
			ProgettoComunicazioniDocumentiObj.Numero = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO"]);
			ProgettoComunicazioniDocumentiObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
			ProgettoComunicazioniDocumentiObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			ProgettoComunicazioniDocumentiObj.IdNoteComunicazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_NOTE_COMUNICAZIONE"]);
			ProgettoComunicazioniDocumentiObj.Formato = new SiarLibrary.NullTypes.StringNT(db.DataReader["FORMATO"]);
			ProgettoComunicazioniDocumentiObj.DescrizioneDocumento = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_DOCUMENTO"]);
			ProgettoComunicazioniDocumentiObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
			ProgettoComunicazioniDocumentiObj.Ente = new SiarLibrary.NullTypes.StringNT(db.DataReader["ENTE"]);
			ProgettoComunicazioniDocumentiObj.CodTipoEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_ENTE"]);
			ProgettoComunicazioniDocumentiObj.Note = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE"]);
			ProgettoComunicazioniDocumentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ProgettoComunicazioniDocumentiObj.IsDirty = false;
			ProgettoComunicazioniDocumentiObj.IsPersistent = true;
			return ProgettoComunicazioniDocumentiObj;
		}

		//Find Select

		public static ProgettoComunicazioniDocumentiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdComunicazioneEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoAllegatiEqualThis, 
SiarLibrary.NullTypes.IntNT IdVarianteAllegatiEqualThis, SiarLibrary.NullTypes.StringNT CodTipoDocumentoEqualThis, SiarLibrary.NullTypes.IntNT IdFileEqualThis, 
SiarLibrary.NullTypes.StringNT CodEnteEmettitoreEqualThis, SiarLibrary.NullTypes.IntNT IdComuneEqualThis, SiarLibrary.NullTypes.StringNT NumeroEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.IntNT IdNoteComunicazioneEqualThis)

		{

			ProgettoComunicazioniDocumentiCollection ProgettoComunicazioniDocumentiCollectionObj = new ProgettoComunicazioniDocumentiCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettocomunicazionidocumentifindselect", new string[] {"Idequalthis", "IdComunicazioneequalthis", "IdDomandaPagamentoAllegatiequalthis", 
"IdVarianteAllegatiequalthis", "CodTipoDocumentoequalthis", "IdFileequalthis", 
"CodEnteEmettitoreequalthis", "IdComuneequalthis", "Numeroequalthis", 
"Dataequalthis", "Descrizioneequalthis", "IdNoteComunicazioneequalthis"}, new string[] {"int", "int", "int", 
"int", "string", "int", 
"string", "int", "string", 
"DateTime", "string", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdComunicazioneequalthis", IdComunicazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoAllegatiequalthis", IdDomandaPagamentoAllegatiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdVarianteAllegatiequalthis", IdVarianteAllegatiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoDocumentoequalthis", CodTipoDocumentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFileequalthis", IdFileEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodEnteEmettitoreequalthis", CodEnteEmettitoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdComuneequalthis", IdComuneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Numeroequalthis", NumeroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Dataequalthis", DataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdNoteComunicazioneequalthis", IdNoteComunicazioneEqualThis);
			ProgettoComunicazioniDocumenti ProgettoComunicazioniDocumentiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettoComunicazioniDocumentiObj = GetFromDatareader(db);
				ProgettoComunicazioniDocumentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoComunicazioniDocumentiObj.IsDirty = false;
				ProgettoComunicazioniDocumentiObj.IsPersistent = true;
				ProgettoComunicazioniDocumentiCollectionObj.Add(ProgettoComunicazioniDocumentiObj);
			}
			db.Close();
			return ProgettoComunicazioniDocumentiCollectionObj;
		}

		//Find Find

		public static ProgettoComunicazioniDocumentiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdComunicazioneEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoAllegatiEqualThis, SiarLibrary.NullTypes.IntNT IdVarianteAllegatiEqualThis, 
SiarLibrary.NullTypes.StringNT CodTipoDocumentoEqualThis)

		{

			ProgettoComunicazioniDocumentiCollection ProgettoComunicazioniDocumentiCollectionObj = new ProgettoComunicazioniDocumentiCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettocomunicazionidocumentifindfind", new string[] {"IdComunicazioneequalthis", "IdDomandaPagamentoAllegatiequalthis", "IdVarianteAllegatiequalthis", 
"CodTipoDocumentoequalthis"}, new string[] {"int", "int", "int", 
"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdComunicazioneequalthis", IdComunicazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoAllegatiequalthis", IdDomandaPagamentoAllegatiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdVarianteAllegatiequalthis", IdVarianteAllegatiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoDocumentoequalthis", CodTipoDocumentoEqualThis);
			ProgettoComunicazioniDocumenti ProgettoComunicazioniDocumentiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettoComunicazioniDocumentiObj = GetFromDatareader(db);
				ProgettoComunicazioniDocumentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoComunicazioniDocumentiObj.IsDirty = false;
				ProgettoComunicazioniDocumentiObj.IsPersistent = true;
				ProgettoComunicazioniDocumentiCollectionObj.Add(ProgettoComunicazioniDocumentiObj);
			}
			db.Close();
			return ProgettoComunicazioniDocumentiCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ProgettoComunicazioniDocumentiCollectionProvider:IProgettoComunicazioniDocumentiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProgettoComunicazioniDocumentiCollectionProvider : IProgettoComunicazioniDocumentiProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ProgettoComunicazioniDocumenti
		protected ProgettoComunicazioniDocumentiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ProgettoComunicazioniDocumentiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ProgettoComunicazioniDocumentiCollection(this);
		}

		//Costruttore 2: popola la collection
		public ProgettoComunicazioniDocumentiCollectionProvider(IntNT IdcomunicazioneEqualThis, IntNT IddomandapagamentoallegatiEqualThis, IntNT IdvarianteallegatiEqualThis, 
StringNT CodtipodocumentoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdcomunicazioneEqualThis, IddomandapagamentoallegatiEqualThis, IdvarianteallegatiEqualThis, 
CodtipodocumentoEqualThis);
		}

		//Costruttore3: ha in input progettocomunicazionidocumentiCollectionObj - non popola la collection
		public ProgettoComunicazioniDocumentiCollectionProvider(ProgettoComunicazioniDocumentiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ProgettoComunicazioniDocumentiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ProgettoComunicazioniDocumentiCollection(this);
		}

		//Get e Set
		public ProgettoComunicazioniDocumentiCollection CollectionObj
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
		public int SaveCollection(ProgettoComunicazioniDocumentiCollection collectionObj)
		{
			return ProgettoComunicazioniDocumentiDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ProgettoComunicazioniDocumenti progettocomunicazionidocumentiObj)
		{
			return ProgettoComunicazioniDocumentiDAL.Save(_dbProviderObj, progettocomunicazionidocumentiObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ProgettoComunicazioniDocumentiCollection collectionObj)
		{
			return ProgettoComunicazioniDocumentiDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ProgettoComunicazioniDocumenti progettocomunicazionidocumentiObj)
		{
			return ProgettoComunicazioniDocumentiDAL.Delete(_dbProviderObj, progettocomunicazionidocumentiObj);
		}

		//getById
		public ProgettoComunicazioniDocumenti GetById(IntNT IdValue)
		{
			ProgettoComunicazioniDocumenti ProgettoComunicazioniDocumentiTemp = ProgettoComunicazioniDocumentiDAL.GetById(_dbProviderObj, IdValue);
			if (ProgettoComunicazioniDocumentiTemp!=null) ProgettoComunicazioniDocumentiTemp.Provider = this;
			return ProgettoComunicazioniDocumentiTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ProgettoComunicazioniDocumentiCollection Select(IntNT IdEqualThis, IntNT IdcomunicazioneEqualThis, IntNT IddomandapagamentoallegatiEqualThis, 
IntNT IdvarianteallegatiEqualThis, StringNT CodtipodocumentoEqualThis, IntNT IdfileEqualThis, 
StringNT CodenteemettitoreEqualThis, IntNT IdcomuneEqualThis, StringNT NumeroEqualThis, 
DatetimeNT DataEqualThis, StringNT DescrizioneEqualThis, IntNT IdnotecomunicazioneEqualThis)
		{
			ProgettoComunicazioniDocumentiCollection ProgettoComunicazioniDocumentiCollectionTemp = ProgettoComunicazioniDocumentiDAL.Select(_dbProviderObj, IdEqualThis, IdcomunicazioneEqualThis, IddomandapagamentoallegatiEqualThis, 
IdvarianteallegatiEqualThis, CodtipodocumentoEqualThis, IdfileEqualThis, 
CodenteemettitoreEqualThis, IdcomuneEqualThis, NumeroEqualThis, 
DataEqualThis, DescrizioneEqualThis, IdnotecomunicazioneEqualThis);
			ProgettoComunicazioniDocumentiCollectionTemp.Provider = this;
			return ProgettoComunicazioniDocumentiCollectionTemp;
		}

		//Find: popola la collection
		public ProgettoComunicazioniDocumentiCollection Find(IntNT IdcomunicazioneEqualThis, IntNT IddomandapagamentoallegatiEqualThis, IntNT IdvarianteallegatiEqualThis, 
StringNT CodtipodocumentoEqualThis)
		{
			ProgettoComunicazioniDocumentiCollection ProgettoComunicazioniDocumentiCollectionTemp = ProgettoComunicazioniDocumentiDAL.Find(_dbProviderObj, IdcomunicazioneEqualThis, IddomandapagamentoallegatiEqualThis, IdvarianteallegatiEqualThis, 
CodtipodocumentoEqualThis);
			ProgettoComunicazioniDocumentiCollectionTemp.Provider = this;
			return ProgettoComunicazioniDocumentiCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PROGETTO_COMUNICAZIONI_DOCUMENTI>
  <ViewName>vPROGETTO_COMUNICAZIONI_DOCUMENTI</ViewName>
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
      <ID_COMUNICAZIONE>Equal</ID_COMUNICAZIONE>
      <ID_DOMANDA_PAGAMENTO_ALLEGATI>Equal</ID_DOMANDA_PAGAMENTO_ALLEGATI>
      <ID_VARIANTE_ALLEGATI>Equal</ID_VARIANTE_ALLEGATI>
      <COD_TIPO_DOCUMENTO>Equal</COD_TIPO_DOCUMENTO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PROGETTO_COMUNICAZIONI_DOCUMENTI>
*/
