using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ImpresaStorico
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IImpresaStoricoProvider
	{
		int Save(ImpresaStorico ImpresaStoricoObj);
		int SaveCollection(ImpresaStoricoCollection collectionObj);
		int Delete(ImpresaStorico ImpresaStoricoObj);
		int DeleteCollection(ImpresaStoricoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ImpresaStorico
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ImpresaStorico: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdStoricoImpresa;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.DatetimeNT _DataInizioValidita;
		private NullTypes.DatetimeNT _DataFineValidita;
		private NullTypes.StringNT _RagioneSociale;
		private NullTypes.StringNT _CodiceInps;
		private NullTypes.StringNT _CodFormaGiuridica;
		private NullTypes.IntNT _IdDimensione;
		private NullTypes.StringNT _RegistroImpreseNumero;
		private NullTypes.StringNT _ReaNumero;
		private NullTypes.IntNT _ReaAnno;
		private NullTypes.StringNT _DimensioneImpresa;
		private NullTypes.StringNT _FormaGiuridica;
		private NullTypes.StringNT _CodClassificazioneUma;
		private NullTypes.BoolNT _Attiva;
		private NullTypes.DatetimeNT _DataCessazione;
		private NullTypes.StringNT _SegnaturaCessazione;
		private NullTypes.StringNT _CodTipoCessazione;
		private NullTypes.StringNT _CodAteco2007;
		[NonSerialized] private IImpresaStoricoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IImpresaStoricoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ImpresaStorico()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_STORICO_IMPRESA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdStoricoImpresa
		{
			get { return _IdStoricoImpresa; }
			set {
				if (IdStoricoImpresa != value)
				{
					_IdStoricoImpresa = value;
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
		/// Corrisponde al campo:DATA_INIZIO_VALIDITA
		/// Tipo sul db:DATETIME
		/// Default:(getdate())
		/// </summary>
		public NullTypes.DatetimeNT DataInizioValidita
		{
			get { return _DataInizioValidita; }
			set {
				if (DataInizioValidita != value)
				{
					_DataInizioValidita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_FINE_VALIDITA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataFineValidita
		{
			get { return _DataFineValidita; }
			set {
				if (DataFineValidita != value)
				{
					_DataFineValidita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RAGIONE_SOCIALE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT RagioneSociale
		{
			get { return _RagioneSociale; }
			set {
				if (RagioneSociale != value)
				{
					_RagioneSociale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE_INPS
		/// Tipo sul db:VARCHAR(15)
		/// </summary>
		public NullTypes.StringNT CodiceInps
		{
			get { return _CodiceInps; }
			set {
				if (CodiceInps != value)
				{
					_CodiceInps = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_FORMA_GIURIDICA
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT CodFormaGiuridica
		{
			get { return _CodFormaGiuridica; }
			set {
				if (CodFormaGiuridica != value)
				{
					_CodFormaGiuridica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_DIMENSIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDimensione
		{
			get { return _IdDimensione; }
			set {
				if (IdDimensione != value)
				{
					_IdDimensione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:REGISTRO_IMPRESE_NUMERO
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT RegistroImpreseNumero
		{
			get { return _RegistroImpreseNumero; }
			set {
				if (RegistroImpreseNumero != value)
				{
					_RegistroImpreseNumero = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:REA_NUMERO
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT ReaNumero
		{
			get { return _ReaNumero; }
			set {
				if (ReaNumero != value)
				{
					_ReaNumero = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:REA_ANNO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT ReaAnno
		{
			get { return _ReaAnno; }
			set {
				if (ReaAnno != value)
				{
					_ReaAnno = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DIMENSIONE_IMPRESA
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT DimensioneImpresa
		{
			get { return _DimensioneImpresa; }
			set {
				if (DimensioneImpresa != value)
				{
					_DimensioneImpresa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FORMA_GIURIDICA
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT FormaGiuridica
		{
			get { return _FormaGiuridica; }
			set {
				if (FormaGiuridica != value)
				{
					_FormaGiuridica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_CLASSIFICAZIONE_UMA
		/// Tipo sul db:VARCHAR(3)
		/// </summary>
		public NullTypes.StringNT CodClassificazioneUma
		{
			get { return _CodClassificazioneUma; }
			set {
				if (CodClassificazioneUma != value)
				{
					_CodClassificazioneUma = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ATTIVA
		/// Tipo sul db:BIT
		/// Default:((1))
		/// </summary>
		public NullTypes.BoolNT Attiva
		{
			get { return _Attiva; }
			set {
				if (Attiva != value)
				{
					_Attiva = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_CESSAZIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataCessazione
		{
			get { return _DataCessazione; }
			set {
				if (DataCessazione != value)
				{
					_DataCessazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SEGNATURA_CESSAZIONE
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT SegnaturaCessazione
		{
			get { return _SegnaturaCessazione; }
			set {
				if (SegnaturaCessazione != value)
				{
					_SegnaturaCessazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_TIPO_CESSAZIONE
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT CodTipoCessazione
		{
			get { return _CodTipoCessazione; }
			set {
				if (CodTipoCessazione != value)
				{
					_CodTipoCessazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_ATECO2007
		/// Tipo sul db:CHAR(9)
		/// </summary>
		public NullTypes.StringNT CodAteco2007
		{
			get { return _CodAteco2007; }
			set {
				if (CodAteco2007 != value)
				{
					_CodAteco2007 = value;
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
	/// Summary description for ImpresaStoricoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ImpresaStoricoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ImpresaStoricoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ImpresaStorico) info.GetValue(i.ToString(),typeof(ImpresaStorico)));
			}
		}

		//Costruttore
		public ImpresaStoricoCollection()
		{
			this.ItemType = typeof(ImpresaStorico);
		}

		//Costruttore con provider
		public ImpresaStoricoCollection(IImpresaStoricoProvider providerObj)
		{
			this.ItemType = typeof(ImpresaStorico);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ImpresaStorico this[int index]
		{
			get { return (ImpresaStorico)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ImpresaStoricoCollection GetChanges()
		{
			return (ImpresaStoricoCollection) base.GetChanges();
		}

		[NonSerialized] private IImpresaStoricoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IImpresaStoricoProvider Provider
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
		public int Add(ImpresaStorico ImpresaStoricoObj)
		{
			if (ImpresaStoricoObj.Provider == null) ImpresaStoricoObj.Provider = this.Provider;
			return base.Add(ImpresaStoricoObj);
		}

		//AddCollection
		public void AddCollection(ImpresaStoricoCollection ImpresaStoricoCollectionObj)
		{
			foreach (ImpresaStorico ImpresaStoricoObj in ImpresaStoricoCollectionObj)
				this.Add(ImpresaStoricoObj);
		}

		//Insert
		public void Insert(int index, ImpresaStorico ImpresaStoricoObj)
		{
			if (ImpresaStoricoObj.Provider == null) ImpresaStoricoObj.Provider = this.Provider;
			base.Insert(index, ImpresaStoricoObj);
		}

		//CollectionGetById
		public ImpresaStorico CollectionGetById(NullTypes.IntNT IdStoricoImpresaValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdStoricoImpresa == IdStoricoImpresaValue))
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
		public ImpresaStoricoCollection SubSelect(NullTypes.IntNT IdStoricoImpresaEqualThis, NullTypes.IntNT IdImpresaEqualThis, NullTypes.DatetimeNT DataInizioValiditaEqualThis, 
NullTypes.DatetimeNT DataFineValiditaEqualThis, NullTypes.StringNT RagioneSocialeEqualThis, NullTypes.StringNT CodiceInpsEqualThis, 
NullTypes.StringNT CodFormaGiuridicaEqualThis, NullTypes.IntNT IdDimensioneEqualThis, NullTypes.StringNT RegistroImpreseNumeroEqualThis, 
NullTypes.StringNT ReaNumeroEqualThis, NullTypes.IntNT ReaAnnoEqualThis, NullTypes.StringNT CodClassificazioneUmaEqualThis, 
NullTypes.BoolNT AttivaEqualThis, NullTypes.DatetimeNT DataCessazioneEqualThis, NullTypes.StringNT SegnaturaCessazioneEqualThis, 
NullTypes.StringNT CodTipoCessazioneEqualThis, NullTypes.StringNT CodAteco2007EqualThis)
		{
			ImpresaStoricoCollection ImpresaStoricoCollectionTemp = new ImpresaStoricoCollection();
			foreach (ImpresaStorico ImpresaStoricoItem in this)
			{
				if (((IdStoricoImpresaEqualThis == null) || ((ImpresaStoricoItem.IdStoricoImpresa != null) && (ImpresaStoricoItem.IdStoricoImpresa.Value == IdStoricoImpresaEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((ImpresaStoricoItem.IdImpresa != null) && (ImpresaStoricoItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((DataInizioValiditaEqualThis == null) || ((ImpresaStoricoItem.DataInizioValidita != null) && (ImpresaStoricoItem.DataInizioValidita.Value == DataInizioValiditaEqualThis.Value))) && 
((DataFineValiditaEqualThis == null) || ((ImpresaStoricoItem.DataFineValidita != null) && (ImpresaStoricoItem.DataFineValidita.Value == DataFineValiditaEqualThis.Value))) && ((RagioneSocialeEqualThis == null) || ((ImpresaStoricoItem.RagioneSociale != null) && (ImpresaStoricoItem.RagioneSociale.Value == RagioneSocialeEqualThis.Value))) && ((CodiceInpsEqualThis == null) || ((ImpresaStoricoItem.CodiceInps != null) && (ImpresaStoricoItem.CodiceInps.Value == CodiceInpsEqualThis.Value))) && 
((CodFormaGiuridicaEqualThis == null) || ((ImpresaStoricoItem.CodFormaGiuridica != null) && (ImpresaStoricoItem.CodFormaGiuridica.Value == CodFormaGiuridicaEqualThis.Value))) && ((IdDimensioneEqualThis == null) || ((ImpresaStoricoItem.IdDimensione != null) && (ImpresaStoricoItem.IdDimensione.Value == IdDimensioneEqualThis.Value))) && ((RegistroImpreseNumeroEqualThis == null) || ((ImpresaStoricoItem.RegistroImpreseNumero != null) && (ImpresaStoricoItem.RegistroImpreseNumero.Value == RegistroImpreseNumeroEqualThis.Value))) && 
((ReaNumeroEqualThis == null) || ((ImpresaStoricoItem.ReaNumero != null) && (ImpresaStoricoItem.ReaNumero.Value == ReaNumeroEqualThis.Value))) && ((ReaAnnoEqualThis == null) || ((ImpresaStoricoItem.ReaAnno != null) && (ImpresaStoricoItem.ReaAnno.Value == ReaAnnoEqualThis.Value))) && ((CodClassificazioneUmaEqualThis == null) || ((ImpresaStoricoItem.CodClassificazioneUma != null) && (ImpresaStoricoItem.CodClassificazioneUma.Value == CodClassificazioneUmaEqualThis.Value))) && 
((AttivaEqualThis == null) || ((ImpresaStoricoItem.Attiva != null) && (ImpresaStoricoItem.Attiva.Value == AttivaEqualThis.Value))) && ((DataCessazioneEqualThis == null) || ((ImpresaStoricoItem.DataCessazione != null) && (ImpresaStoricoItem.DataCessazione.Value == DataCessazioneEqualThis.Value))) && ((SegnaturaCessazioneEqualThis == null) || ((ImpresaStoricoItem.SegnaturaCessazione != null) && (ImpresaStoricoItem.SegnaturaCessazione.Value == SegnaturaCessazioneEqualThis.Value))) && 
((CodTipoCessazioneEqualThis == null) || ((ImpresaStoricoItem.CodTipoCessazione != null) && (ImpresaStoricoItem.CodTipoCessazione.Value == CodTipoCessazioneEqualThis.Value))) && ((CodAteco2007EqualThis == null) || ((ImpresaStoricoItem.CodAteco2007 != null) && (ImpresaStoricoItem.CodAteco2007.Value == CodAteco2007EqualThis.Value))))
				{
					ImpresaStoricoCollectionTemp.Add(ImpresaStoricoItem);
				}
			}
			return ImpresaStoricoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ImpresaStoricoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ImpresaStoricoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ImpresaStorico ImpresaStoricoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdStoricoImpresa", ImpresaStoricoObj.IdStoricoImpresa);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdImpresa", ImpresaStoricoObj.IdImpresa);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInizioValidita", ImpresaStoricoObj.DataInizioValidita);
			DbProvider.SetCmdParam(cmd,firstChar + "DataFineValidita", ImpresaStoricoObj.DataFineValidita);
			DbProvider.SetCmdParam(cmd,firstChar + "RagioneSociale", ImpresaStoricoObj.RagioneSociale);
			DbProvider.SetCmdParam(cmd,firstChar + "CodiceInps", ImpresaStoricoObj.CodiceInps);
			DbProvider.SetCmdParam(cmd,firstChar + "CodFormaGiuridica", ImpresaStoricoObj.CodFormaGiuridica);
			DbProvider.SetCmdParam(cmd,firstChar + "IdDimensione", ImpresaStoricoObj.IdDimensione);
			DbProvider.SetCmdParam(cmd,firstChar + "RegistroImpreseNumero", ImpresaStoricoObj.RegistroImpreseNumero);
			DbProvider.SetCmdParam(cmd,firstChar + "ReaNumero", ImpresaStoricoObj.ReaNumero);
			DbProvider.SetCmdParam(cmd,firstChar + "ReaAnno", ImpresaStoricoObj.ReaAnno);
			DbProvider.SetCmdParam(cmd,firstChar + "CodClassificazioneUma", ImpresaStoricoObj.CodClassificazioneUma);
			DbProvider.SetCmdParam(cmd,firstChar + "Attiva", ImpresaStoricoObj.Attiva);
			DbProvider.SetCmdParam(cmd,firstChar + "DataCessazione", ImpresaStoricoObj.DataCessazione);
			DbProvider.SetCmdParam(cmd,firstChar + "SegnaturaCessazione", ImpresaStoricoObj.SegnaturaCessazione);
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipoCessazione", ImpresaStoricoObj.CodTipoCessazione);
			DbProvider.SetCmdParam(cmd,firstChar + "CodAteco2007", ImpresaStoricoObj.CodAteco2007);
		}
		//Insert
		private static int Insert(DbProvider db, ImpresaStorico ImpresaStoricoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZImpresaStoricoInsert", new string[] {"IdImpresa", "DataInizioValidita", 
"DataFineValidita", "RagioneSociale", "CodiceInps", 
"CodFormaGiuridica", "IdDimensione", "RegistroImpreseNumero", 
"ReaNumero", "ReaAnno", 
"CodClassificazioneUma", "Attiva", 
"DataCessazione", "SegnaturaCessazione", "CodTipoCessazione", 
"CodAteco2007"}, new string[] {"int", "DateTime", 
"DateTime", "string", "string", 
"string", "int", "string", 
"string", "int", 
"string", "bool", 
"DateTime", "string", "string", 
"string"},"");
				CompileIUCmd(false, insertCmd,ImpresaStoricoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ImpresaStoricoObj.IdStoricoImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_STORICO_IMPRESA"]);
				ImpresaStoricoObj.DataInizioValidita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO_VALIDITA"]);
				ImpresaStoricoObj.Attiva = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVA"]);
				}
				ImpresaStoricoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ImpresaStoricoObj.IsDirty = false;
				ImpresaStoricoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ImpresaStorico ImpresaStoricoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZImpresaStoricoUpdate", new string[] {"IdStoricoImpresa", "IdImpresa", "DataInizioValidita", 
"DataFineValidita", "RagioneSociale", "CodiceInps", 
"CodFormaGiuridica", "IdDimensione", "RegistroImpreseNumero", 
"ReaNumero", "ReaAnno", 
"CodClassificazioneUma", "Attiva", 
"DataCessazione", "SegnaturaCessazione", "CodTipoCessazione", 
"CodAteco2007"}, new string[] {"int", "int", "DateTime", 
"DateTime", "string", "string", 
"string", "int", "string", 
"string", "int", 
"string", "bool", 
"DateTime", "string", "string", 
"string"},"");
				CompileIUCmd(true, updateCmd,ImpresaStoricoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ImpresaStoricoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ImpresaStoricoObj.IsDirty = false;
				ImpresaStoricoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ImpresaStorico ImpresaStoricoObj)
		{
			switch (ImpresaStoricoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ImpresaStoricoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ImpresaStoricoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ImpresaStoricoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ImpresaStoricoCollection ImpresaStoricoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZImpresaStoricoUpdate", new string[] {"IdStoricoImpresa", "IdImpresa", "DataInizioValidita", 
"DataFineValidita", "RagioneSociale", "CodiceInps", 
"CodFormaGiuridica", "IdDimensione", "RegistroImpreseNumero", 
"ReaNumero", "ReaAnno", 
"CodClassificazioneUma", "Attiva", 
"DataCessazione", "SegnaturaCessazione", "CodTipoCessazione", 
"CodAteco2007"}, new string[] {"int", "int", "DateTime", 
"DateTime", "string", "string", 
"string", "int", "string", 
"string", "int", 
"string", "bool", 
"DateTime", "string", "string", 
"string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZImpresaStoricoInsert", new string[] {"IdImpresa", "DataInizioValidita", 
"DataFineValidita", "RagioneSociale", "CodiceInps", 
"CodFormaGiuridica", "IdDimensione", "RegistroImpreseNumero", 
"ReaNumero", "ReaAnno", 
"CodClassificazioneUma", "Attiva", 
"DataCessazione", "SegnaturaCessazione", "CodTipoCessazione", 
"CodAteco2007"}, new string[] {"int", "DateTime", 
"DateTime", "string", "string", 
"string", "int", "string", 
"string", "int", 
"string", "bool", 
"DateTime", "string", "string", 
"string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZImpresaStoricoDelete", new string[] {"IdStoricoImpresa"}, new string[] {"int"},"");
				for (int i = 0; i < ImpresaStoricoCollectionObj.Count; i++)
				{
					switch (ImpresaStoricoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ImpresaStoricoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ImpresaStoricoCollectionObj[i].IdStoricoImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_STORICO_IMPRESA"]);
									ImpresaStoricoCollectionObj[i].DataInizioValidita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO_VALIDITA"]);
									ImpresaStoricoCollectionObj[i].Attiva = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ImpresaStoricoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ImpresaStoricoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdStoricoImpresa", (SiarLibrary.NullTypes.IntNT)ImpresaStoricoCollectionObj[i].IdStoricoImpresa);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ImpresaStoricoCollectionObj.Count; i++)
				{
					if ((ImpresaStoricoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ImpresaStoricoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ImpresaStoricoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ImpresaStoricoCollectionObj[i].IsDirty = false;
						ImpresaStoricoCollectionObj[i].IsPersistent = true;
					}
					if ((ImpresaStoricoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ImpresaStoricoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ImpresaStoricoCollectionObj[i].IsDirty = false;
						ImpresaStoricoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ImpresaStorico ImpresaStoricoObj)
		{
			int returnValue = 0;
			if (ImpresaStoricoObj.IsPersistent) 
			{
				returnValue = Delete(db, ImpresaStoricoObj.IdStoricoImpresa);
			}
			ImpresaStoricoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ImpresaStoricoObj.IsDirty = false;
			ImpresaStoricoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdStoricoImpresaValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZImpresaStoricoDelete", new string[] {"IdStoricoImpresa"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdStoricoImpresa", (SiarLibrary.NullTypes.IntNT)IdStoricoImpresaValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ImpresaStoricoCollection ImpresaStoricoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZImpresaStoricoDelete", new string[] {"IdStoricoImpresa"}, new string[] {"int"},"");
				for (int i = 0; i < ImpresaStoricoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdStoricoImpresa", ImpresaStoricoCollectionObj[i].IdStoricoImpresa);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ImpresaStoricoCollectionObj.Count; i++)
				{
					if ((ImpresaStoricoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ImpresaStoricoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ImpresaStoricoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ImpresaStoricoCollectionObj[i].IsDirty = false;
						ImpresaStoricoCollectionObj[i].IsPersistent = false;
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
		public static ImpresaStorico GetById(DbProvider db, int IdStoricoImpresaValue)
		{
			ImpresaStorico ImpresaStoricoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZImpresaStoricoGetById", new string[] {"IdStoricoImpresa"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdStoricoImpresa", (SiarLibrary.NullTypes.IntNT)IdStoricoImpresaValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ImpresaStoricoObj = GetFromDatareader(db);
				ImpresaStoricoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ImpresaStoricoObj.IsDirty = false;
				ImpresaStoricoObj.IsPersistent = true;
			}
			db.Close();
			return ImpresaStoricoObj;
		}

		//getFromDatareader
		public static ImpresaStorico GetFromDatareader(DbProvider db)
		{
			ImpresaStorico ImpresaStoricoObj = new ImpresaStorico();
			ImpresaStoricoObj.IdStoricoImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_STORICO_IMPRESA"]);
			ImpresaStoricoObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			ImpresaStoricoObj.DataInizioValidita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO_VALIDITA"]);
			ImpresaStoricoObj.DataFineValidita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE_VALIDITA"]);
			ImpresaStoricoObj.RagioneSociale = new SiarLibrary.NullTypes.StringNT(db.DataReader["RAGIONE_SOCIALE"]);
			ImpresaStoricoObj.CodiceInps = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_INPS"]);
			ImpresaStoricoObj.CodFormaGiuridica = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_FORMA_GIURIDICA"]);
			ImpresaStoricoObj.IdDimensione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DIMENSIONE"]);
			ImpresaStoricoObj.RegistroImpreseNumero = new SiarLibrary.NullTypes.StringNT(db.DataReader["REGISTRO_IMPRESE_NUMERO"]);
			ImpresaStoricoObj.ReaNumero = new SiarLibrary.NullTypes.StringNT(db.DataReader["REA_NUMERO"]);
			ImpresaStoricoObj.ReaAnno = new SiarLibrary.NullTypes.IntNT(db.DataReader["REA_ANNO"]);
			ImpresaStoricoObj.DimensioneImpresa = new SiarLibrary.NullTypes.StringNT(db.DataReader["DIMENSIONE_IMPRESA"]);
			ImpresaStoricoObj.FormaGiuridica = new SiarLibrary.NullTypes.StringNT(db.DataReader["FORMA_GIURIDICA"]);
			ImpresaStoricoObj.CodClassificazioneUma = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_CLASSIFICAZIONE_UMA"]);
			ImpresaStoricoObj.Attiva = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVA"]);
			ImpresaStoricoObj.DataCessazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CESSAZIONE"]);
			ImpresaStoricoObj.SegnaturaCessazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_CESSAZIONE"]);
			ImpresaStoricoObj.CodTipoCessazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_CESSAZIONE"]);
			ImpresaStoricoObj.CodAteco2007 = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ATECO2007"]);
			ImpresaStoricoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ImpresaStoricoObj.IsDirty = false;
			ImpresaStoricoObj.IsPersistent = true;
			return ImpresaStoricoObj;
		}

		//Find Select

		public static ImpresaStoricoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdStoricoImpresaEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInizioValiditaEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataFineValiditaEqualThis, SiarLibrary.NullTypes.StringNT RagioneSocialeEqualThis, SiarLibrary.NullTypes.StringNT CodiceInpsEqualThis, 
SiarLibrary.NullTypes.StringNT CodFormaGiuridicaEqualThis, SiarLibrary.NullTypes.IntNT IdDimensioneEqualThis, SiarLibrary.NullTypes.StringNT RegistroImpreseNumeroEqualThis, 
SiarLibrary.NullTypes.StringNT ReaNumeroEqualThis, SiarLibrary.NullTypes.IntNT ReaAnnoEqualThis, SiarLibrary.NullTypes.StringNT CodClassificazioneUmaEqualThis, 
SiarLibrary.NullTypes.BoolNT AttivaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataCessazioneEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaCessazioneEqualThis, 
SiarLibrary.NullTypes.StringNT CodTipoCessazioneEqualThis, SiarLibrary.NullTypes.StringNT CodAteco2007EqualThis)

		{

			ImpresaStoricoCollection ImpresaStoricoCollectionObj = new ImpresaStoricoCollection();

			IDbCommand findCmd = db.InitCmd("Zimpresastoricofindselect", new string[] {"IdStoricoImpresaequalthis", "IdImpresaequalthis", "DataInizioValiditaequalthis", 
"DataFineValiditaequalthis", "RagioneSocialeequalthis", "CodiceInpsequalthis", 
"CodFormaGiuridicaequalthis", "IdDimensioneequalthis", "RegistroImpreseNumeroequalthis", 
"ReaNumeroequalthis", "ReaAnnoequalthis", "CodClassificazioneUmaequalthis", 
"Attivaequalthis", "DataCessazioneequalthis", "SegnaturaCessazioneequalthis", 
"CodTipoCessazioneequalthis", "CodAteco2007equalthis"}, new string[] {"int", "int", "DateTime", 
"DateTime", "string", "string", 
"string", "int", "string", 
"string", "int", "string", 
"bool", "DateTime", "string", 
"string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdStoricoImpresaequalthis", IdStoricoImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInizioValiditaequalthis", DataInizioValiditaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataFineValiditaequalthis", DataFineValiditaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RagioneSocialeequalthis", RagioneSocialeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceInpsequalthis", CodiceInpsEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodFormaGiuridicaequalthis", CodFormaGiuridicaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDimensioneequalthis", IdDimensioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RegistroImpreseNumeroequalthis", RegistroImpreseNumeroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ReaNumeroequalthis", ReaNumeroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ReaAnnoequalthis", ReaAnnoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodClassificazioneUmaequalthis", CodClassificazioneUmaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivaequalthis", AttivaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataCessazioneequalthis", DataCessazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SegnaturaCessazioneequalthis", SegnaturaCessazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoCessazioneequalthis", CodTipoCessazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodAteco2007equalthis", CodAteco2007EqualThis);
			ImpresaStorico ImpresaStoricoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ImpresaStoricoObj = GetFromDatareader(db);
				ImpresaStoricoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ImpresaStoricoObj.IsDirty = false;
				ImpresaStoricoObj.IsPersistent = true;
				ImpresaStoricoCollectionObj.Add(ImpresaStoricoObj);
			}
			db.Close();
			return ImpresaStoricoCollectionObj;
		}

		//Find Find

		public static ImpresaStoricoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis)

		{

			ImpresaStoricoCollection ImpresaStoricoCollectionObj = new ImpresaStoricoCollection();

			IDbCommand findCmd = db.InitCmd("Zimpresastoricofindfind", new string[] {"IdImpresaequalthis"}, new string[] {"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			ImpresaStorico ImpresaStoricoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ImpresaStoricoObj = GetFromDatareader(db);
				ImpresaStoricoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ImpresaStoricoObj.IsDirty = false;
				ImpresaStoricoObj.IsPersistent = true;
				ImpresaStoricoCollectionObj.Add(ImpresaStoricoObj);
			}
			db.Close();
			return ImpresaStoricoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ImpresaStoricoCollectionProvider:IImpresaStoricoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ImpresaStoricoCollectionProvider : IImpresaStoricoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ImpresaStorico
		protected ImpresaStoricoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ImpresaStoricoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ImpresaStoricoCollection(this);
		}

		//Costruttore 2: popola la collection
		public ImpresaStoricoCollectionProvider(IntNT IdimpresaEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdimpresaEqualThis);
		}

		//Costruttore3: ha in input impresastoricoCollectionObj - non popola la collection
		public ImpresaStoricoCollectionProvider(ImpresaStoricoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ImpresaStoricoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ImpresaStoricoCollection(this);
		}

		//Get e Set
		public ImpresaStoricoCollection CollectionObj
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
		public int SaveCollection(ImpresaStoricoCollection collectionObj)
		{
			return ImpresaStoricoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ImpresaStorico impresastoricoObj)
		{
			return ImpresaStoricoDAL.Save(_dbProviderObj, impresastoricoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ImpresaStoricoCollection collectionObj)
		{
			return ImpresaStoricoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ImpresaStorico impresastoricoObj)
		{
			return ImpresaStoricoDAL.Delete(_dbProviderObj, impresastoricoObj);
		}

		//getById
		public ImpresaStorico GetById(IntNT IdStoricoImpresaValue)
		{
			ImpresaStorico ImpresaStoricoTemp = ImpresaStoricoDAL.GetById(_dbProviderObj, IdStoricoImpresaValue);
			if (ImpresaStoricoTemp!=null) ImpresaStoricoTemp.Provider = this;
			return ImpresaStoricoTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ImpresaStoricoCollection Select(IntNT IdstoricoimpresaEqualThis, IntNT IdimpresaEqualThis, DatetimeNT DatainiziovaliditaEqualThis, 
DatetimeNT DatafinevaliditaEqualThis, StringNT RagionesocialeEqualThis, StringNT CodiceinpsEqualThis, 
StringNT CodformagiuridicaEqualThis, IntNT IddimensioneEqualThis, StringNT RegistroimpresenumeroEqualThis, 
StringNT ReanumeroEqualThis, IntNT ReaannoEqualThis, StringNT CodclassificazioneumaEqualThis, 
BoolNT AttivaEqualThis, DatetimeNT DatacessazioneEqualThis, StringNT SegnaturacessazioneEqualThis, 
StringNT CodtipocessazioneEqualThis, StringNT Codateco2007EqualThis)
		{
			ImpresaStoricoCollection ImpresaStoricoCollectionTemp = ImpresaStoricoDAL.Select(_dbProviderObj, IdstoricoimpresaEqualThis, IdimpresaEqualThis, DatainiziovaliditaEqualThis, 
DatafinevaliditaEqualThis, RagionesocialeEqualThis, CodiceinpsEqualThis, 
CodformagiuridicaEqualThis, IddimensioneEqualThis, RegistroimpresenumeroEqualThis, 
ReanumeroEqualThis, ReaannoEqualThis, CodclassificazioneumaEqualThis, 
AttivaEqualThis, DatacessazioneEqualThis, SegnaturacessazioneEqualThis, 
CodtipocessazioneEqualThis, Codateco2007EqualThis);
			ImpresaStoricoCollectionTemp.Provider = this;
			return ImpresaStoricoCollectionTemp;
		}

		//Find: popola la collection
		public ImpresaStoricoCollection Find(IntNT IdimpresaEqualThis)
		{
			ImpresaStoricoCollection ImpresaStoricoCollectionTemp = ImpresaStoricoDAL.Find(_dbProviderObj, IdimpresaEqualThis);
			ImpresaStoricoCollectionTemp.Provider = this;
			return ImpresaStoricoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<IMPRESA_STORICO>
  <ViewName>vIMPRESA_STORICO</ViewName>
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
    <Find OrderBy="ORDER BY DATA_INIZIO_VALIDITA DESC">
      <ID_IMPRESA>Equal</ID_IMPRESA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</IMPRESA_STORICO>
*/
