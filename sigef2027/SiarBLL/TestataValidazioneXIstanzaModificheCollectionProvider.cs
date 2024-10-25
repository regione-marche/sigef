using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per TestataValidazioneXIstanzaModifiche
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ITestataValidazioneXIstanzaModificheProvider
	{
		int Save(TestataValidazioneXIstanzaModifiche TestataValidazioneXIstanzaModificheObj);
		int SaveCollection(TestataValidazioneXIstanzaModificheCollection collectionObj);
		int Delete(TestataValidazioneXIstanzaModifiche TestataValidazioneXIstanzaModificheObj);
		int DeleteCollection(TestataValidazioneXIstanzaModificheCollection collectionObj);
	}
	/// <summary>
	/// Summary description for TestataValidazioneXIstanzaModifiche
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class TestataValidazioneXIstanzaModifiche: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdTestataValidazioneXIstanza;
		private NullTypes.StringNT _CfInserimento;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.StringNT _CfModifica;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.IntNT _IdTestataValidazione;
		private NullTypes.IntNT _IdIstanzaChecklistGenerica;
		private NullTypes.IntNT _Ordine;
		private NullTypes.StringNT _Note;
		private NullTypes.BoolNT _Autovalutazione;
		private NullTypes.BoolNT _Approvata;
		private NullTypes.DatetimeNT _DataValidazione;
		private NullTypes.StringNT _CfValidatore;
		private NullTypes.StringNT _NominativoValidatore;
		private NullTypes.IntNT _IdChecklistGenerica;
		private NullTypes.StringNT _CodFaseIstanza;
		private NullTypes.StringNT _DescrizioneChecklist;
		private NullTypes.BoolNT _FlagTemplateChecklist;
		private NullTypes.StringNT _IdFiltroChecklist;
		private NullTypes.IntNT _IdTipoChecklist;
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdModifica;
		[NonSerialized] private ITestataValidazioneXIstanzaModificheProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ITestataValidazioneXIstanzaModificheProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public TestataValidazioneXIstanzaModifiche()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_TESTATA_VALIDAZIONE_X_ISTANZA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdTestataValidazioneXIstanza
		{
			get { return _IdTestataValidazioneXIstanza; }
			set {
				if (IdTestataValidazioneXIstanza != value)
				{
					_IdTestataValidazioneXIstanza = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_INSERIMENTO
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CfInserimento
		{
			get { return _CfInserimento; }
			set {
				if (CfInserimento != value)
				{
					_CfInserimento = value;
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
		/// Corrisponde al campo:CF_MODIFICA
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CfModifica
		{
			get { return _CfModifica; }
			set {
				if (CfModifica != value)
				{
					_CfModifica = value;
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
		/// Corrisponde al campo:ID_TESTATA_VALIDAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdTestataValidazione
		{
			get { return _IdTestataValidazione; }
			set {
				if (IdTestataValidazione != value)
				{
					_IdTestataValidazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_ISTANZA_CHECKLIST_GENERICA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdIstanzaChecklistGenerica
		{
			get { return _IdIstanzaChecklistGenerica; }
			set {
				if (IdIstanzaChecklistGenerica != value)
				{
					_IdIstanzaChecklistGenerica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORDINE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Ordine
		{
			get { return _Ordine; }
			set {
				if (Ordine != value)
				{
					_Ordine = value;
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
			set {
				if (Note != value)
				{
					_Note = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:AUTOVALUTAZIONE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Autovalutazione
		{
			get { return _Autovalutazione; }
			set {
				if (Autovalutazione != value)
				{
					_Autovalutazione = value;
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
		/// Corrisponde al campo:DATA_VALIDAZIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataValidazione
		{
			get { return _DataValidazione; }
			set {
				if (DataValidazione != value)
				{
					_DataValidazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_VALIDATORE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CfValidatore
		{
			get { return _CfValidatore; }
			set {
				if (CfValidatore != value)
				{
					_CfValidatore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOMINATIVO_VALIDATORE
		/// Tipo sul db:VARCHAR(511)
		/// </summary>
		public NullTypes.StringNT NominativoValidatore
		{
			get { return _NominativoValidatore; }
			set {
				if (NominativoValidatore != value)
				{
					_NominativoValidatore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_CHECKLIST_GENERICA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdChecklistGenerica
		{
			get { return _IdChecklistGenerica; }
			set {
				if (IdChecklistGenerica != value)
				{
					_IdChecklistGenerica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_FASE_ISTANZA
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT CodFaseIstanza
		{
			get { return _CodFaseIstanza; }
			set {
				if (CodFaseIstanza != value)
				{
					_CodFaseIstanza = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_CHECKLIST
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT DescrizioneChecklist
		{
			get { return _DescrizioneChecklist; }
			set {
				if (DescrizioneChecklist != value)
				{
					_DescrizioneChecklist = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FLAG_TEMPLATE_CHECKLIST
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT FlagTemplateChecklist
		{
			get { return _FlagTemplateChecklist; }
			set {
				if (FlagTemplateChecklist != value)
				{
					_FlagTemplateChecklist = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_FILTRO_CHECKLIST
		/// Tipo sul db:VARCHAR(200)
		/// </summary>
		public NullTypes.StringNT IdFiltroChecklist
		{
			get { return _IdFiltroChecklist; }
			set {
				if (IdFiltroChecklist != value)
				{
					_IdFiltroChecklist = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_TIPO_CHECKLIST
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdTipoChecklist
		{
			get { return _IdTipoChecklist; }
			set {
				if (IdTipoChecklist != value)
				{
					_IdTipoChecklist = value;
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
		/// Corrisponde al campo:ID_MODIFICA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdModifica
		{
			get { return _IdModifica; }
			set {
				if (IdModifica != value)
				{
					_IdModifica = value;
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
	/// Summary description for TestataValidazioneXIstanzaModificheCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class TestataValidazioneXIstanzaModificheCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private TestataValidazioneXIstanzaModificheCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((TestataValidazioneXIstanzaModifiche) info.GetValue(i.ToString(),typeof(TestataValidazioneXIstanzaModifiche)));
			}
		}

		//Costruttore
		public TestataValidazioneXIstanzaModificheCollection()
		{
			this.ItemType = typeof(TestataValidazioneXIstanzaModifiche);
		}

		//Costruttore con provider
		public TestataValidazioneXIstanzaModificheCollection(ITestataValidazioneXIstanzaModificheProvider providerObj)
		{
			this.ItemType = typeof(TestataValidazioneXIstanzaModifiche);
			this.Provider = providerObj;
		}

		//Get e Set
		public new TestataValidazioneXIstanzaModifiche this[int index]
		{
			get { return (TestataValidazioneXIstanzaModifiche)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new TestataValidazioneXIstanzaModificheCollection GetChanges()
		{
			return (TestataValidazioneXIstanzaModificheCollection) base.GetChanges();
		}

		[NonSerialized] private ITestataValidazioneXIstanzaModificheProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ITestataValidazioneXIstanzaModificheProvider Provider
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
		public int Add(TestataValidazioneXIstanzaModifiche TestataValidazioneXIstanzaModificheObj)
		{
			if (TestataValidazioneXIstanzaModificheObj.Provider == null) TestataValidazioneXIstanzaModificheObj.Provider = this.Provider;
			return base.Add(TestataValidazioneXIstanzaModificheObj);
		}

		//AddCollection
		public void AddCollection(TestataValidazioneXIstanzaModificheCollection TestataValidazioneXIstanzaModificheCollectionObj)
		{
			foreach (TestataValidazioneXIstanzaModifiche TestataValidazioneXIstanzaModificheObj in TestataValidazioneXIstanzaModificheCollectionObj)
				this.Add(TestataValidazioneXIstanzaModificheObj);
		}

		//Insert
		public void Insert(int index, TestataValidazioneXIstanzaModifiche TestataValidazioneXIstanzaModificheObj)
		{
			if (TestataValidazioneXIstanzaModificheObj.Provider == null) TestataValidazioneXIstanzaModificheObj.Provider = this.Provider;
			base.Insert(index, TestataValidazioneXIstanzaModificheObj);
		}

		//CollectionGetById
		public TestataValidazioneXIstanzaModifiche CollectionGetById(NullTypes.IntNT IdValue)
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
		public TestataValidazioneXIstanzaModificheCollection SubSelect(NullTypes.IntNT IdTestataValidazioneXIstanzaEqualThis, NullTypes.StringNT CfInserimentoEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, 
NullTypes.StringNT CfModificaEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.IntNT IdTestataValidazioneEqualThis, 
NullTypes.IntNT IdIstanzaChecklistGenericaEqualThis, NullTypes.IntNT OrdineEqualThis, NullTypes.StringNT NoteEqualThis, 
NullTypes.BoolNT AutovalutazioneEqualThis, NullTypes.BoolNT ApprovataEqualThis, NullTypes.DatetimeNT DataValidazioneEqualThis, 
NullTypes.StringNT CfValidatoreEqualThis, NullTypes.StringNT NominativoValidatoreEqualThis, NullTypes.IntNT IdChecklistGenericaEqualThis, 
NullTypes.StringNT CodFaseIstanzaEqualThis, NullTypes.StringNT DescrizioneChecklistEqualThis, NullTypes.BoolNT FlagTemplateChecklistEqualThis, 
NullTypes.StringNT IdFiltroChecklistEqualThis, NullTypes.IntNT IdTipoChecklistEqualThis, NullTypes.IntNT IdEqualThis, 
NullTypes.IntNT IdModificaEqualThis)
		{
			TestataValidazioneXIstanzaModificheCollection TestataValidazioneXIstanzaModificheCollectionTemp = new TestataValidazioneXIstanzaModificheCollection();
			foreach (TestataValidazioneXIstanzaModifiche TestataValidazioneXIstanzaModificheItem in this)
			{
				if (((IdTestataValidazioneXIstanzaEqualThis == null) || ((TestataValidazioneXIstanzaModificheItem.IdTestataValidazioneXIstanza != null) && (TestataValidazioneXIstanzaModificheItem.IdTestataValidazioneXIstanza.Value == IdTestataValidazioneXIstanzaEqualThis.Value))) && ((CfInserimentoEqualThis == null) || ((TestataValidazioneXIstanzaModificheItem.CfInserimento != null) && (TestataValidazioneXIstanzaModificheItem.CfInserimento.Value == CfInserimentoEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((TestataValidazioneXIstanzaModificheItem.DataInserimento != null) && (TestataValidazioneXIstanzaModificheItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && 
((CfModificaEqualThis == null) || ((TestataValidazioneXIstanzaModificheItem.CfModifica != null) && (TestataValidazioneXIstanzaModificheItem.CfModifica.Value == CfModificaEqualThis.Value))) && ((DataModificaEqualThis == null) || ((TestataValidazioneXIstanzaModificheItem.DataModifica != null) && (TestataValidazioneXIstanzaModificheItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((IdTestataValidazioneEqualThis == null) || ((TestataValidazioneXIstanzaModificheItem.IdTestataValidazione != null) && (TestataValidazioneXIstanzaModificheItem.IdTestataValidazione.Value == IdTestataValidazioneEqualThis.Value))) && 
((IdIstanzaChecklistGenericaEqualThis == null) || ((TestataValidazioneXIstanzaModificheItem.IdIstanzaChecklistGenerica != null) && (TestataValidazioneXIstanzaModificheItem.IdIstanzaChecklistGenerica.Value == IdIstanzaChecklistGenericaEqualThis.Value))) && ((OrdineEqualThis == null) || ((TestataValidazioneXIstanzaModificheItem.Ordine != null) && (TestataValidazioneXIstanzaModificheItem.Ordine.Value == OrdineEqualThis.Value))) && ((NoteEqualThis == null) || ((TestataValidazioneXIstanzaModificheItem.Note != null) && (TestataValidazioneXIstanzaModificheItem.Note.Value == NoteEqualThis.Value))) && 
((AutovalutazioneEqualThis == null) || ((TestataValidazioneXIstanzaModificheItem.Autovalutazione != null) && (TestataValidazioneXIstanzaModificheItem.Autovalutazione.Value == AutovalutazioneEqualThis.Value))) && ((ApprovataEqualThis == null) || ((TestataValidazioneXIstanzaModificheItem.Approvata != null) && (TestataValidazioneXIstanzaModificheItem.Approvata.Value == ApprovataEqualThis.Value))) && ((DataValidazioneEqualThis == null) || ((TestataValidazioneXIstanzaModificheItem.DataValidazione != null) && (TestataValidazioneXIstanzaModificheItem.DataValidazione.Value == DataValidazioneEqualThis.Value))) && 
((CfValidatoreEqualThis == null) || ((TestataValidazioneXIstanzaModificheItem.CfValidatore != null) && (TestataValidazioneXIstanzaModificheItem.CfValidatore.Value == CfValidatoreEqualThis.Value))) && ((NominativoValidatoreEqualThis == null) || ((TestataValidazioneXIstanzaModificheItem.NominativoValidatore != null) && (TestataValidazioneXIstanzaModificheItem.NominativoValidatore.Value == NominativoValidatoreEqualThis.Value))) && ((IdChecklistGenericaEqualThis == null) || ((TestataValidazioneXIstanzaModificheItem.IdChecklistGenerica != null) && (TestataValidazioneXIstanzaModificheItem.IdChecklistGenerica.Value == IdChecklistGenericaEqualThis.Value))) && 
((CodFaseIstanzaEqualThis == null) || ((TestataValidazioneXIstanzaModificheItem.CodFaseIstanza != null) && (TestataValidazioneXIstanzaModificheItem.CodFaseIstanza.Value == CodFaseIstanzaEqualThis.Value))) && ((DescrizioneChecklistEqualThis == null) || ((TestataValidazioneXIstanzaModificheItem.DescrizioneChecklist != null) && (TestataValidazioneXIstanzaModificheItem.DescrizioneChecklist.Value == DescrizioneChecklistEqualThis.Value))) && ((FlagTemplateChecklistEqualThis == null) || ((TestataValidazioneXIstanzaModificheItem.FlagTemplateChecklist != null) && (TestataValidazioneXIstanzaModificheItem.FlagTemplateChecklist.Value == FlagTemplateChecklistEqualThis.Value))) && 
((IdFiltroChecklistEqualThis == null) || ((TestataValidazioneXIstanzaModificheItem.IdFiltroChecklist != null) && (TestataValidazioneXIstanzaModificheItem.IdFiltroChecklist.Value == IdFiltroChecklistEqualThis.Value))) && ((IdTipoChecklistEqualThis == null) || ((TestataValidazioneXIstanzaModificheItem.IdTipoChecklist != null) && (TestataValidazioneXIstanzaModificheItem.IdTipoChecklist.Value == IdTipoChecklistEqualThis.Value))) && ((IdEqualThis == null) || ((TestataValidazioneXIstanzaModificheItem.Id != null) && (TestataValidazioneXIstanzaModificheItem.Id.Value == IdEqualThis.Value))) && 
((IdModificaEqualThis == null) || ((TestataValidazioneXIstanzaModificheItem.IdModifica != null) && (TestataValidazioneXIstanzaModificheItem.IdModifica.Value == IdModificaEqualThis.Value))))
				{
					TestataValidazioneXIstanzaModificheCollectionTemp.Add(TestataValidazioneXIstanzaModificheItem);
				}
			}
			return TestataValidazioneXIstanzaModificheCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for TestataValidazioneXIstanzaModificheDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class TestataValidazioneXIstanzaModificheDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, TestataValidazioneXIstanzaModifiche TestataValidazioneXIstanzaModificheObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", TestataValidazioneXIstanzaModificheObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdTestataValidazioneXIstanza", TestataValidazioneXIstanzaModificheObj.IdTestataValidazioneXIstanza);
			DbProvider.SetCmdParam(cmd,firstChar + "CfInserimento", TestataValidazioneXIstanzaModificheObj.CfInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", TestataValidazioneXIstanzaModificheObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "CfModifica", TestataValidazioneXIstanzaModificheObj.CfModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", TestataValidazioneXIstanzaModificheObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "IdTestataValidazione", TestataValidazioneXIstanzaModificheObj.IdTestataValidazione);
			DbProvider.SetCmdParam(cmd,firstChar + "IdIstanzaChecklistGenerica", TestataValidazioneXIstanzaModificheObj.IdIstanzaChecklistGenerica);
			DbProvider.SetCmdParam(cmd,firstChar + "Ordine", TestataValidazioneXIstanzaModificheObj.Ordine);
			DbProvider.SetCmdParam(cmd,firstChar + "Note", TestataValidazioneXIstanzaModificheObj.Note);
			DbProvider.SetCmdParam(cmd,firstChar + "Autovalutazione", TestataValidazioneXIstanzaModificheObj.Autovalutazione);
			DbProvider.SetCmdParam(cmd,firstChar + "Approvata", TestataValidazioneXIstanzaModificheObj.Approvata);
			DbProvider.SetCmdParam(cmd,firstChar + "DataValidazione", TestataValidazioneXIstanzaModificheObj.DataValidazione);
			DbProvider.SetCmdParam(cmd,firstChar + "CfValidatore", TestataValidazioneXIstanzaModificheObj.CfValidatore);
			DbProvider.SetCmdParam(cmd,firstChar + "NominativoValidatore", TestataValidazioneXIstanzaModificheObj.NominativoValidatore);
			DbProvider.SetCmdParam(cmd,firstChar + "IdChecklistGenerica", TestataValidazioneXIstanzaModificheObj.IdChecklistGenerica);
			DbProvider.SetCmdParam(cmd,firstChar + "CodFaseIstanza", TestataValidazioneXIstanzaModificheObj.CodFaseIstanza);
			DbProvider.SetCmdParam(cmd,firstChar + "DescrizioneChecklist", TestataValidazioneXIstanzaModificheObj.DescrizioneChecklist);
			DbProvider.SetCmdParam(cmd,firstChar + "FlagTemplateChecklist", TestataValidazioneXIstanzaModificheObj.FlagTemplateChecklist);
			DbProvider.SetCmdParam(cmd,firstChar + "IdFiltroChecklist", TestataValidazioneXIstanzaModificheObj.IdFiltroChecklist);
			DbProvider.SetCmdParam(cmd,firstChar + "IdTipoChecklist", TestataValidazioneXIstanzaModificheObj.IdTipoChecklist);
			DbProvider.SetCmdParam(cmd,firstChar + "IdModifica", TestataValidazioneXIstanzaModificheObj.IdModifica);
		}
		//Insert
		private static int Insert(DbProvider db, TestataValidazioneXIstanzaModifiche TestataValidazioneXIstanzaModificheObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZTestataValidazioneXIstanzaModificheInsert", new string[] {"IdTestataValidazioneXIstanza", "CfInserimento", "DataInserimento", 
"CfModifica", "DataModifica", "IdTestataValidazione", 
"IdIstanzaChecklistGenerica", "Ordine", "Note", 
"Autovalutazione", "Approvata", "DataValidazione", 
"CfValidatore", "NominativoValidatore", "IdChecklistGenerica", 
"CodFaseIstanza", "DescrizioneChecklist", "FlagTemplateChecklist", 
"IdFiltroChecklist", "IdTipoChecklist", 
"IdModifica"}, new string[] {"int", "string", "DateTime", 
"string", "DateTime", "int", 
"int", "int", "string", 
"bool", "bool", "DateTime", 
"string", "string", "int", 
"string", "string", "bool", 
"string", "int", 
"int"},"");
				CompileIUCmd(false, insertCmd,TestataValidazioneXIstanzaModificheObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				TestataValidazioneXIstanzaModificheObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				TestataValidazioneXIstanzaModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TestataValidazioneXIstanzaModificheObj.IsDirty = false;
				TestataValidazioneXIstanzaModificheObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, TestataValidazioneXIstanzaModifiche TestataValidazioneXIstanzaModificheObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZTestataValidazioneXIstanzaModificheUpdate", new string[] {"IdTestataValidazioneXIstanza", "CfInserimento", "DataInserimento", 
"CfModifica", "DataModifica", "IdTestataValidazione", 
"IdIstanzaChecklistGenerica", "Ordine", "Note", 
"Autovalutazione", "Approvata", "DataValidazione", 
"CfValidatore", "NominativoValidatore", "IdChecklistGenerica", 
"CodFaseIstanza", "DescrizioneChecklist", "FlagTemplateChecklist", 
"IdFiltroChecklist", "IdTipoChecklist", "Id", 
"IdModifica"}, new string[] {"int", "string", "DateTime", 
"string", "DateTime", "int", 
"int", "int", "string", 
"bool", "bool", "DateTime", 
"string", "string", "int", 
"string", "string", "bool", 
"string", "int", "int", 
"int"},"");
				CompileIUCmd(true, updateCmd,TestataValidazioneXIstanzaModificheObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					TestataValidazioneXIstanzaModificheObj.DataModifica = d;
				}
				TestataValidazioneXIstanzaModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TestataValidazioneXIstanzaModificheObj.IsDirty = false;
				TestataValidazioneXIstanzaModificheObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, TestataValidazioneXIstanzaModifiche TestataValidazioneXIstanzaModificheObj)
		{
			switch (TestataValidazioneXIstanzaModificheObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, TestataValidazioneXIstanzaModificheObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, TestataValidazioneXIstanzaModificheObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,TestataValidazioneXIstanzaModificheObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, TestataValidazioneXIstanzaModificheCollection TestataValidazioneXIstanzaModificheCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZTestataValidazioneXIstanzaModificheUpdate", new string[] {"IdTestataValidazioneXIstanza", "CfInserimento", "DataInserimento", 
"CfModifica", "DataModifica", "IdTestataValidazione", 
"IdIstanzaChecklistGenerica", "Ordine", "Note", 
"Autovalutazione", "Approvata", "DataValidazione", 
"CfValidatore", "NominativoValidatore", "IdChecklistGenerica", 
"CodFaseIstanza", "DescrizioneChecklist", "FlagTemplateChecklist", 
"IdFiltroChecklist", "IdTipoChecklist", "Id", 
"IdModifica"}, new string[] {"int", "string", "DateTime", 
"string", "DateTime", "int", 
"int", "int", "string", 
"bool", "bool", "DateTime", 
"string", "string", "int", 
"string", "string", "bool", 
"string", "int", "int", 
"int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZTestataValidazioneXIstanzaModificheInsert", new string[] {"IdTestataValidazioneXIstanza", "CfInserimento", "DataInserimento", 
"CfModifica", "DataModifica", "IdTestataValidazione", 
"IdIstanzaChecklistGenerica", "Ordine", "Note", 
"Autovalutazione", "Approvata", "DataValidazione", 
"CfValidatore", "NominativoValidatore", "IdChecklistGenerica", 
"CodFaseIstanza", "DescrizioneChecklist", "FlagTemplateChecklist", 
"IdFiltroChecklist", "IdTipoChecklist", 
"IdModifica"}, new string[] {"int", "string", "DateTime", 
"string", "DateTime", "int", 
"int", "int", "string", 
"bool", "bool", "DateTime", 
"string", "string", "int", 
"string", "string", "bool", 
"string", "int", 
"int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZTestataValidazioneXIstanzaModificheDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < TestataValidazioneXIstanzaModificheCollectionObj.Count; i++)
				{
					switch (TestataValidazioneXIstanzaModificheCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,TestataValidazioneXIstanzaModificheCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									TestataValidazioneXIstanzaModificheCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,TestataValidazioneXIstanzaModificheCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									TestataValidazioneXIstanzaModificheCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (TestataValidazioneXIstanzaModificheCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)TestataValidazioneXIstanzaModificheCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < TestataValidazioneXIstanzaModificheCollectionObj.Count; i++)
				{
					if ((TestataValidazioneXIstanzaModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (TestataValidazioneXIstanzaModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						TestataValidazioneXIstanzaModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						TestataValidazioneXIstanzaModificheCollectionObj[i].IsDirty = false;
						TestataValidazioneXIstanzaModificheCollectionObj[i].IsPersistent = true;
					}
					if ((TestataValidazioneXIstanzaModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						TestataValidazioneXIstanzaModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						TestataValidazioneXIstanzaModificheCollectionObj[i].IsDirty = false;
						TestataValidazioneXIstanzaModificheCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, TestataValidazioneXIstanzaModifiche TestataValidazioneXIstanzaModificheObj)
		{
			int returnValue = 0;
			if (TestataValidazioneXIstanzaModificheObj.IsPersistent) 
			{
				returnValue = Delete(db, TestataValidazioneXIstanzaModificheObj.Id);
			}
			TestataValidazioneXIstanzaModificheObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			TestataValidazioneXIstanzaModificheObj.IsDirty = false;
			TestataValidazioneXIstanzaModificheObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZTestataValidazioneXIstanzaModificheDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, TestataValidazioneXIstanzaModificheCollection TestataValidazioneXIstanzaModificheCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZTestataValidazioneXIstanzaModificheDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < TestataValidazioneXIstanzaModificheCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", TestataValidazioneXIstanzaModificheCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < TestataValidazioneXIstanzaModificheCollectionObj.Count; i++)
				{
					if ((TestataValidazioneXIstanzaModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (TestataValidazioneXIstanzaModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						TestataValidazioneXIstanzaModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						TestataValidazioneXIstanzaModificheCollectionObj[i].IsDirty = false;
						TestataValidazioneXIstanzaModificheCollectionObj[i].IsPersistent = false;
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
		public static TestataValidazioneXIstanzaModifiche GetById(DbProvider db, int IdValue)
		{
			TestataValidazioneXIstanzaModifiche TestataValidazioneXIstanzaModificheObj = null;
			IDbCommand readCmd = db.InitCmd( "ZTestataValidazioneXIstanzaModificheGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				TestataValidazioneXIstanzaModificheObj = GetFromDatareader(db);
				TestataValidazioneXIstanzaModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TestataValidazioneXIstanzaModificheObj.IsDirty = false;
				TestataValidazioneXIstanzaModificheObj.IsPersistent = true;
			}
			db.Close();
			return TestataValidazioneXIstanzaModificheObj;
		}

		//getFromDatareader
		public static TestataValidazioneXIstanzaModifiche GetFromDatareader(DbProvider db)
		{
			TestataValidazioneXIstanzaModifiche TestataValidazioneXIstanzaModificheObj = new TestataValidazioneXIstanzaModifiche();
			TestataValidazioneXIstanzaModificheObj.IdTestataValidazioneXIstanza = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TESTATA_VALIDAZIONE_X_ISTANZA"]);
			TestataValidazioneXIstanzaModificheObj.CfInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_INSERIMENTO"]);
			TestataValidazioneXIstanzaModificheObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			TestataValidazioneXIstanzaModificheObj.CfModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_MODIFICA"]);
			TestataValidazioneXIstanzaModificheObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			TestataValidazioneXIstanzaModificheObj.IdTestataValidazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TESTATA_VALIDAZIONE"]);
			TestataValidazioneXIstanzaModificheObj.IdIstanzaChecklistGenerica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ISTANZA_CHECKLIST_GENERICA"]);
			TestataValidazioneXIstanzaModificheObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
			TestataValidazioneXIstanzaModificheObj.Note = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE"]);
			TestataValidazioneXIstanzaModificheObj.Autovalutazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AUTOVALUTAZIONE"]);
			TestataValidazioneXIstanzaModificheObj.Approvata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["APPROVATA"]);
			TestataValidazioneXIstanzaModificheObj.DataValidazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_VALIDAZIONE"]);
			TestataValidazioneXIstanzaModificheObj.CfValidatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_VALIDATORE"]);
			TestataValidazioneXIstanzaModificheObj.NominativoValidatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO_VALIDATORE"]);
			TestataValidazioneXIstanzaModificheObj.IdChecklistGenerica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CHECKLIST_GENERICA"]);
			TestataValidazioneXIstanzaModificheObj.CodFaseIstanza = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_FASE_ISTANZA"]);
			TestataValidazioneXIstanzaModificheObj.DescrizioneChecklist = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_CHECKLIST"]);
			TestataValidazioneXIstanzaModificheObj.FlagTemplateChecklist = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_TEMPLATE_CHECKLIST"]);
			TestataValidazioneXIstanzaModificheObj.IdFiltroChecklist = new SiarLibrary.NullTypes.StringNT(db.DataReader["ID_FILTRO_CHECKLIST"]);
			TestataValidazioneXIstanzaModificheObj.IdTipoChecklist = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO_CHECKLIST"]);
			TestataValidazioneXIstanzaModificheObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			TestataValidazioneXIstanzaModificheObj.IdModifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_MODIFICA"]);
			TestataValidazioneXIstanzaModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			TestataValidazioneXIstanzaModificheObj.IsDirty = false;
			TestataValidazioneXIstanzaModificheObj.IsPersistent = true;
			return TestataValidazioneXIstanzaModificheObj;
		}

		//Find Select

		public static TestataValidazioneXIstanzaModificheCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdTestataValidazioneXIstanzaEqualThis, SiarLibrary.NullTypes.StringNT CfInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, 
SiarLibrary.NullTypes.StringNT CfModificaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.IntNT IdTestataValidazioneEqualThis, 
SiarLibrary.NullTypes.IntNT IdIstanzaChecklistGenericaEqualThis, SiarLibrary.NullTypes.IntNT OrdineEqualThis, SiarLibrary.NullTypes.StringNT NoteEqualThis, 
SiarLibrary.NullTypes.BoolNT AutovalutazioneEqualThis, SiarLibrary.NullTypes.BoolNT ApprovataEqualThis, SiarLibrary.NullTypes.DatetimeNT DataValidazioneEqualThis, 
SiarLibrary.NullTypes.StringNT CfValidatoreEqualThis, SiarLibrary.NullTypes.StringNT NominativoValidatoreEqualThis, SiarLibrary.NullTypes.IntNT IdChecklistGenericaEqualThis, 
SiarLibrary.NullTypes.StringNT CodFaseIstanzaEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneChecklistEqualThis, SiarLibrary.NullTypes.BoolNT FlagTemplateChecklistEqualThis, 
SiarLibrary.NullTypes.StringNT IdFiltroChecklistEqualThis, SiarLibrary.NullTypes.IntNT IdTipoChecklistEqualThis, SiarLibrary.NullTypes.IntNT IdEqualThis, 
SiarLibrary.NullTypes.IntNT IdModificaEqualThis)

		{

			TestataValidazioneXIstanzaModificheCollection TestataValidazioneXIstanzaModificheCollectionObj = new TestataValidazioneXIstanzaModificheCollection();

			IDbCommand findCmd = db.InitCmd("Ztestatavalidazionexistanzamodifichefindselect", new string[] {"IdTestataValidazioneXIstanzaequalthis", "CfInserimentoequalthis", "DataInserimentoequalthis", 
"CfModificaequalthis", "DataModificaequalthis", "IdTestataValidazioneequalthis", 
"IdIstanzaChecklistGenericaequalthis", "Ordineequalthis", "Noteequalthis", 
"Autovalutazioneequalthis", "Approvataequalthis", "DataValidazioneequalthis", 
"CfValidatoreequalthis", "NominativoValidatoreequalthis", "IdChecklistGenericaequalthis", 
"CodFaseIstanzaequalthis", "DescrizioneChecklistequalthis", "FlagTemplateChecklistequalthis", 
"IdFiltroChecklistequalthis", "IdTipoChecklistequalthis", "Idequalthis", 
"IdModificaequalthis"}, new string[] {"int", "string", "DateTime", 
"string", "DateTime", "int", 
"int", "int", "string", 
"bool", "bool", "DateTime", 
"string", "string", "int", 
"string", "string", "bool", 
"string", "int", "int", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdTestataValidazioneXIstanzaequalthis", IdTestataValidazioneXIstanzaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfInserimentoequalthis", CfInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfModificaequalthis", CfModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdTestataValidazioneequalthis", IdTestataValidazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdIstanzaChecklistGenericaequalthis", IdIstanzaChecklistGenericaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Noteequalthis", NoteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Autovalutazioneequalthis", AutovalutazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Approvataequalthis", ApprovataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataValidazioneequalthis", DataValidazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfValidatoreequalthis", CfValidatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NominativoValidatoreequalthis", NominativoValidatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdChecklistGenericaequalthis", IdChecklistGenericaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodFaseIstanzaequalthis", CodFaseIstanzaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneChecklistequalthis", DescrizioneChecklistEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FlagTemplateChecklistequalthis", FlagTemplateChecklistEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFiltroChecklistequalthis", IdFiltroChecklistEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdTipoChecklistequalthis", IdTipoChecklistEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdModificaequalthis", IdModificaEqualThis);
			TestataValidazioneXIstanzaModifiche TestataValidazioneXIstanzaModificheObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				TestataValidazioneXIstanzaModificheObj = GetFromDatareader(db);
				TestataValidazioneXIstanzaModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TestataValidazioneXIstanzaModificheObj.IsDirty = false;
				TestataValidazioneXIstanzaModificheObj.IsPersistent = true;
				TestataValidazioneXIstanzaModificheCollectionObj.Add(TestataValidazioneXIstanzaModificheObj);
			}
			db.Close();
			return TestataValidazioneXIstanzaModificheCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for TestataValidazioneXIstanzaModificheCollectionProvider:ITestataValidazioneXIstanzaModificheProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class TestataValidazioneXIstanzaModificheCollectionProvider : ITestataValidazioneXIstanzaModificheProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di TestataValidazioneXIstanzaModifiche
		protected TestataValidazioneXIstanzaModificheCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public TestataValidazioneXIstanzaModificheCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new TestataValidazioneXIstanzaModificheCollection(this);
		}

		//Costruttore3: ha in input testatavalidazionexistanzamodificheCollectionObj - non popola la collection
		public TestataValidazioneXIstanzaModificheCollectionProvider(TestataValidazioneXIstanzaModificheCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public TestataValidazioneXIstanzaModificheCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new TestataValidazioneXIstanzaModificheCollection(this);
		}

		//Get e Set
		public TestataValidazioneXIstanzaModificheCollection CollectionObj
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
		public int SaveCollection(TestataValidazioneXIstanzaModificheCollection collectionObj)
		{
			return TestataValidazioneXIstanzaModificheDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(TestataValidazioneXIstanzaModifiche testatavalidazionexistanzamodificheObj)
		{
			return TestataValidazioneXIstanzaModificheDAL.Save(_dbProviderObj, testatavalidazionexistanzamodificheObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(TestataValidazioneXIstanzaModificheCollection collectionObj)
		{
			return TestataValidazioneXIstanzaModificheDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(TestataValidazioneXIstanzaModifiche testatavalidazionexistanzamodificheObj)
		{
			return TestataValidazioneXIstanzaModificheDAL.Delete(_dbProviderObj, testatavalidazionexistanzamodificheObj);
		}

		//getById
		public TestataValidazioneXIstanzaModifiche GetById(IntNT IdValue)
		{
			TestataValidazioneXIstanzaModifiche TestataValidazioneXIstanzaModificheTemp = TestataValidazioneXIstanzaModificheDAL.GetById(_dbProviderObj, IdValue);
			if (TestataValidazioneXIstanzaModificheTemp!=null) TestataValidazioneXIstanzaModificheTemp.Provider = this;
			return TestataValidazioneXIstanzaModificheTemp;
		}

		//Select: popola la collection
		public TestataValidazioneXIstanzaModificheCollection Select(IntNT IdtestatavalidazionexistanzaEqualThis, StringNT CfinserimentoEqualThis, DatetimeNT DatainserimentoEqualThis, 
StringNT CfmodificaEqualThis, DatetimeNT DatamodificaEqualThis, IntNT IdtestatavalidazioneEqualThis, 
IntNT IdistanzachecklistgenericaEqualThis, IntNT OrdineEqualThis, StringNT NoteEqualThis, 
BoolNT AutovalutazioneEqualThis, BoolNT ApprovataEqualThis, DatetimeNT DatavalidazioneEqualThis, 
StringNT CfvalidatoreEqualThis, StringNT NominativovalidatoreEqualThis, IntNT IdchecklistgenericaEqualThis, 
StringNT CodfaseistanzaEqualThis, StringNT DescrizionechecklistEqualThis, BoolNT FlagtemplatechecklistEqualThis, 
StringNT IdfiltrochecklistEqualThis, IntNT IdtipochecklistEqualThis, IntNT IdEqualThis, 
IntNT IdmodificaEqualThis)
		{
			TestataValidazioneXIstanzaModificheCollection TestataValidazioneXIstanzaModificheCollectionTemp = TestataValidazioneXIstanzaModificheDAL.Select(_dbProviderObj, IdtestatavalidazionexistanzaEqualThis, CfinserimentoEqualThis, DatainserimentoEqualThis, 
CfmodificaEqualThis, DatamodificaEqualThis, IdtestatavalidazioneEqualThis, 
IdistanzachecklistgenericaEqualThis, OrdineEqualThis, NoteEqualThis, 
AutovalutazioneEqualThis, ApprovataEqualThis, DatavalidazioneEqualThis, 
CfvalidatoreEqualThis, NominativovalidatoreEqualThis, IdchecklistgenericaEqualThis, 
CodfaseistanzaEqualThis, DescrizionechecklistEqualThis, FlagtemplatechecklistEqualThis, 
IdfiltrochecklistEqualThis, IdtipochecklistEqualThis, IdEqualThis, 
IdmodificaEqualThis);
			TestataValidazioneXIstanzaModificheCollectionTemp.Provider = this;
			return TestataValidazioneXIstanzaModificheCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<TESTATA_VALIDAZIONE_X_ISTANZA_MODIFICHE>
  <ViewName>
  </ViewName>
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
  <Finds />
  <Filters />
  <externalFields />
  <AddedFkFields />
</TESTATA_VALIDAZIONE_X_ISTANZA_MODIFICHE>
*/
