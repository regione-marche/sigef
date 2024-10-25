using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per VoceXChecklistGenerica
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IVoceXChecklistGenericaProvider
	{
		int Save(VoceXChecklistGenerica VoceXChecklistGenericaObj);
		int SaveCollection(VoceXChecklistGenericaCollection collectionObj);
		int Delete(VoceXChecklistGenerica VoceXChecklistGenericaObj);
		int DeleteCollection(VoceXChecklistGenericaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for VoceXChecklistGenerica
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class VoceXChecklistGenerica : BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdVoceXChecklistGenerica;
		private NullTypes.IntNT _IdChecklistGenerica;
		private NullTypes.IntNT _IdVoceGenerica;
		private NullTypes.IntNT _Ordine;
		private NullTypes.BoolNT _Obbligatorio;
		private NullTypes.DecimalNT _Peso;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.StringNT _CfInserimento;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.StringNT _CfModifica;
		private NullTypes.StringNT _Misura;
		private NullTypes.StringNT _DescrizioneVoce;
		private NullTypes.BoolNT _AutomaticoVoce;
		private NullTypes.StringNT _QuerySqlVoce;
		private NullTypes.StringNT _QuerySqlPostVoce;
		private NullTypes.StringNT _CodeMethodVoce;
		private NullTypes.StringNT _UrlVoce;
		private NullTypes.StringNT _ValMinimoVoce;
		private NullTypes.StringNT _ValMassimoVoce;
		private NullTypes.BoolNT _ValEsitoNegativoVoce;
		private NullTypes.StringNT _IdFiltroVoce;
		private NullTypes.BoolNT _TitoloVoce;
		private NullTypes.StringNT _CommentoVoce;
		private NullTypes.StringNT _DescrizioneFiltroVoce;
		private NullTypes.IntNT _OrdineFiltroVoce;
		private NullTypes.StringNT _DescrizioneChecklist;
		private NullTypes.BoolNT _FlagTemplateChecklist;
		private NullTypes.IntNT _IdTipoChecklist;
		private NullTypes.StringNT _DescrizioneTipoChecklist;
		private NullTypes.BoolNT _ContieneVociTipoChecklist;
		private NullTypes.BoolNT _SchedaTipoChecklist;
		private NullTypes.StringNT _IdFiltroChecklist;
		private NullTypes.StringNT _DescrizioneFiltroChecklist;
		private NullTypes.IntNT _OrdineFiltroCheklist;
		[NonSerialized] private IVoceXChecklistGenericaProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public IVoceXChecklistGenericaProvider Provider
		{
			get { return _provider; }
			set { _provider = value; }
		}


		//Costruttore
		public VoceXChecklistGenerica()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_VOCE_X_CHECKLIST_GENERICA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdVoceXChecklistGenerica
		{
			get { return _IdVoceXChecklistGenerica; }
			set
			{
				if (IdVoceXChecklistGenerica != value)
				{
					_IdVoceXChecklistGenerica = value;
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
			set
			{
				if (IdChecklistGenerica != value)
				{
					_IdChecklistGenerica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_VOCE_GENERICA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdVoceGenerica
		{
			get { return _IdVoceGenerica; }
			set
			{
				if (IdVoceGenerica != value)
				{
					_IdVoceGenerica = value;
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
			set
			{
				if (Ordine != value)
				{
					_Ordine = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OBBLIGATORIO
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT Obbligatorio
		{
			get { return _Obbligatorio; }
			set
			{
				if (Obbligatorio != value)
				{
					_Obbligatorio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PESO
		/// Tipo sul db:DECIMAL(10,2)
		/// </summary>
		public NullTypes.DecimalNT Peso
		{
			get { return _Peso; }
			set
			{
				if (Peso != value)
				{
					_Peso = value;
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
			set
			{
				if (DataInserimento != value)
				{
					_DataInserimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_INSERIMENTO
		/// Tipo sul db:CHAR(16)
		/// </summary>
		public NullTypes.StringNT CfInserimento
		{
			get { return _CfInserimento; }
			set
			{
				if (CfInserimento != value)
				{
					_CfInserimento = value;
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
		/// Corrisponde al campo:CF_MODIFICA
		/// Tipo sul db:CHAR(16)
		/// </summary>
		public NullTypes.StringNT CfModifica
		{
			get { return _CfModifica; }
			set
			{
				if (CfModifica != value)
				{
					_CfModifica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MISURA
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT Misura
		{
			get { return _Misura; }
			set
			{
				if (Misura != value)
				{
					_Misura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_VOCE
		/// Tipo sul db:VARCHAR(8000)
		/// </summary>
		public NullTypes.StringNT DescrizioneVoce
		{
			get { return _DescrizioneVoce; }
			set
			{
				if (DescrizioneVoce != value)
				{
					_DescrizioneVoce = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:AUTOMATICO_VOCE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT AutomaticoVoce
		{
			get { return _AutomaticoVoce; }
			set
			{
				if (AutomaticoVoce != value)
				{
					_AutomaticoVoce = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUERY_SQL_VOCE
		/// Tipo sul db:VARCHAR(8000)
		/// </summary>
		public NullTypes.StringNT QuerySqlVoce
		{
			get { return _QuerySqlVoce; }
			set
			{
				if (QuerySqlVoce != value)
				{
					_QuerySqlVoce = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUERY_SQL_POST_VOCE
		/// Tipo sul db:VARCHAR(300)
		/// </summary>
		public NullTypes.StringNT QuerySqlPostVoce
		{
			get { return _QuerySqlPostVoce; }
			set
			{
				if (QuerySqlPostVoce != value)
				{
					_QuerySqlPostVoce = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODE_METHOD_VOCE
		/// Tipo sul db:VARCHAR(30)
		/// </summary>
		public NullTypes.StringNT CodeMethodVoce
		{
			get { return _CodeMethodVoce; }
			set
			{
				if (CodeMethodVoce != value)
				{
					_CodeMethodVoce = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:URL_VOCE
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT UrlVoce
		{
			get { return _UrlVoce; }
			set
			{
				if (UrlVoce != value)
				{
					_UrlVoce = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VAL_MINIMO_VOCE
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT ValMinimoVoce
		{
			get { return _ValMinimoVoce; }
			set
			{
				if (ValMinimoVoce != value)
				{
					_ValMinimoVoce = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VAL_MASSIMO_VOCE
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT ValMassimoVoce
		{
			get { return _ValMassimoVoce; }
			set
			{
				if (ValMassimoVoce != value)
				{
					_ValMassimoVoce = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VAL_ESITO_NEGATIVO_VOCE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT ValEsitoNegativoVoce
		{
			get { return _ValEsitoNegativoVoce; }
			set
			{
				if (ValEsitoNegativoVoce != value)
				{
					_ValEsitoNegativoVoce = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_FILTRO_VOCE
		/// Tipo sul db:VARCHAR(200)
		/// </summary>
		public NullTypes.StringNT IdFiltroVoce
		{
			get { return _IdFiltroVoce; }
			set
			{
				if (IdFiltroVoce != value)
				{
					_IdFiltroVoce = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TITOLO_VOCE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT TitoloVoce
		{
			get { return _TitoloVoce; }
			set
			{
				if (TitoloVoce != value)
				{
					_TitoloVoce = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COMMENTO_VOCE
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT CommentoVoce
		{
			get { return _CommentoVoce; }
			set
			{
				if (CommentoVoce != value)
				{
					_CommentoVoce = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_FILTRO_VOCE
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT DescrizioneFiltroVoce
		{
			get { return _DescrizioneFiltroVoce; }
			set
			{
				if (DescrizioneFiltroVoce != value)
				{
					_DescrizioneFiltroVoce = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORDINE_FILTRO_VOCE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OrdineFiltroVoce
		{
			get { return _OrdineFiltroVoce; }
			set
			{
				if (OrdineFiltroVoce != value)
				{
					_OrdineFiltroVoce = value;
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
			set
			{
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
			set
			{
				if (FlagTemplateChecklist != value)
				{
					_FlagTemplateChecklist = value;
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
			set
			{
				if (IdTipoChecklist != value)
				{
					_IdTipoChecklist = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_TIPO_CHECKLIST
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT DescrizioneTipoChecklist
		{
			get { return _DescrizioneTipoChecklist; }
			set
			{
				if (DescrizioneTipoChecklist != value)
				{
					_DescrizioneTipoChecklist = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTIENE_VOCI_TIPO_CHECKLIST
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT ContieneVociTipoChecklist
		{
			get { return _ContieneVociTipoChecklist; }
			set
			{
				if (ContieneVociTipoChecklist != value)
				{
					_ContieneVociTipoChecklist = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SCHEDA_TIPO_CHECKLIST
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT SchedaTipoChecklist
		{
			get { return _SchedaTipoChecklist; }
			set
			{
				if (SchedaTipoChecklist != value)
				{
					_SchedaTipoChecklist = value;
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
			set
			{
				if (IdFiltroChecklist != value)
				{
					_IdFiltroChecklist = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_FILTRO_CHECKLIST
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT DescrizioneFiltroChecklist
		{
			get { return _DescrizioneFiltroChecklist; }
			set
			{
				if (DescrizioneFiltroChecklist != value)
				{
					_DescrizioneFiltroChecklist = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORDINE_FILTRO_CHEKLIST
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OrdineFiltroCheklist
		{
			get { return _OrdineFiltroCheklist; }
			set
			{
				if (OrdineFiltroCheklist != value)
				{
					_OrdineFiltroCheklist = value;
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
	/// Summary description for VoceXChecklistGenericaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VoceXChecklistGenericaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private VoceXChecklistGenericaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
		{
			int c = info.GetInt32("_count");
			for (int i = 0; i < c; i++)
			{
				this.Add((VoceXChecklistGenerica)info.GetValue(i.ToString(), typeof(VoceXChecklistGenerica)));
			}
		}

		//Costruttore
		public VoceXChecklistGenericaCollection()
		{
			this.ItemType = typeof(VoceXChecklistGenerica);
		}

		//Costruttore con provider
		public VoceXChecklistGenericaCollection(IVoceXChecklistGenericaProvider providerObj)
		{
			this.ItemType = typeof(VoceXChecklistGenerica);
			this.Provider = providerObj;
		}

		//Get e Set
		public new VoceXChecklistGenerica this[int index]
		{
			get { return (VoceXChecklistGenerica)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VoceXChecklistGenericaCollection GetChanges()
		{
			return (VoceXChecklistGenericaCollection)base.GetChanges();
		}

		[NonSerialized] private IVoceXChecklistGenericaProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public IVoceXChecklistGenericaProvider Provider
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
		public int Add(VoceXChecklistGenerica VoceXChecklistGenericaObj)
		{
			if (VoceXChecklistGenericaObj.Provider == null) VoceXChecklistGenericaObj.Provider = this.Provider;
			return base.Add(VoceXChecklistGenericaObj);
		}

		//AddCollection
		public void AddCollection(VoceXChecklistGenericaCollection VoceXChecklistGenericaCollectionObj)
		{
			foreach (VoceXChecklistGenerica VoceXChecklistGenericaObj in VoceXChecklistGenericaCollectionObj)
				this.Add(VoceXChecklistGenericaObj);
		}

		//Insert
		public void Insert(int index, VoceXChecklistGenerica VoceXChecklistGenericaObj)
		{
			if (VoceXChecklistGenericaObj.Provider == null) VoceXChecklistGenericaObj.Provider = this.Provider;
			base.Insert(index, VoceXChecklistGenericaObj);
		}

		//CollectionGetById
		public VoceXChecklistGenerica CollectionGetById(NullTypes.IntNT IdVoceXChecklistGenericaValue)
		{
			int i = 0;
			bool find = false;
			while ((i < this.Count) && (!find))
			{
				if ((this[i].IdVoceXChecklistGenerica == IdVoceXChecklistGenericaValue))
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
		public VoceXChecklistGenericaCollection SubSelect(NullTypes.IntNT IdVoceXChecklistGenericaEqualThis, NullTypes.IntNT IdChecklistGenericaEqualThis, NullTypes.IntNT IdVoceGenericaEqualThis,
NullTypes.IntNT OrdineEqualThis, NullTypes.BoolNT ObbligatorioEqualThis, NullTypes.DecimalNT PesoEqualThis,
NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.StringNT CfInserimentoEqualThis, NullTypes.DatetimeNT DataModificaEqualThis,
NullTypes.StringNT CfModificaEqualThis, NullTypes.StringNT MisuraEqualThis)
		{
			VoceXChecklistGenericaCollection VoceXChecklistGenericaCollectionTemp = new VoceXChecklistGenericaCollection();
			foreach (VoceXChecklistGenerica VoceXChecklistGenericaItem in this)
			{
				if (((IdVoceXChecklistGenericaEqualThis == null) || ((VoceXChecklistGenericaItem.IdVoceXChecklistGenerica != null) && (VoceXChecklistGenericaItem.IdVoceXChecklistGenerica.Value == IdVoceXChecklistGenericaEqualThis.Value))) && ((IdChecklistGenericaEqualThis == null) || ((VoceXChecklistGenericaItem.IdChecklistGenerica != null) && (VoceXChecklistGenericaItem.IdChecklistGenerica.Value == IdChecklistGenericaEqualThis.Value))) && ((IdVoceGenericaEqualThis == null) || ((VoceXChecklistGenericaItem.IdVoceGenerica != null) && (VoceXChecklistGenericaItem.IdVoceGenerica.Value == IdVoceGenericaEqualThis.Value))) &&
((OrdineEqualThis == null) || ((VoceXChecklistGenericaItem.Ordine != null) && (VoceXChecklistGenericaItem.Ordine.Value == OrdineEqualThis.Value))) && ((ObbligatorioEqualThis == null) || ((VoceXChecklistGenericaItem.Obbligatorio != null) && (VoceXChecklistGenericaItem.Obbligatorio.Value == ObbligatorioEqualThis.Value))) && ((PesoEqualThis == null) || ((VoceXChecklistGenericaItem.Peso != null) && (VoceXChecklistGenericaItem.Peso.Value == PesoEqualThis.Value))) &&
((DataInserimentoEqualThis == null) || ((VoceXChecklistGenericaItem.DataInserimento != null) && (VoceXChecklistGenericaItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((CfInserimentoEqualThis == null) || ((VoceXChecklistGenericaItem.CfInserimento != null) && (VoceXChecklistGenericaItem.CfInserimento.Value == CfInserimentoEqualThis.Value))) && ((DataModificaEqualThis == null) || ((VoceXChecklistGenericaItem.DataModifica != null) && (VoceXChecklistGenericaItem.DataModifica.Value == DataModificaEqualThis.Value))) &&
((CfModificaEqualThis == null) || ((VoceXChecklistGenericaItem.CfModifica != null) && (VoceXChecklistGenericaItem.CfModifica.Value == CfModificaEqualThis.Value))) && ((MisuraEqualThis == null) || ((VoceXChecklistGenericaItem.Misura != null) && (VoceXChecklistGenericaItem.Misura.Value == MisuraEqualThis.Value))))
				{
					VoceXChecklistGenericaCollectionTemp.Add(VoceXChecklistGenericaItem);
				}
			}
			return VoceXChecklistGenericaCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for VoceXChecklistGenericaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class VoceXChecklistGenericaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, VoceXChecklistGenerica VoceXChecklistGenericaObj, string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd, firstChar + "IdVoceXChecklistGenerica", VoceXChecklistGenericaObj.IdVoceXChecklistGenerica);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd, firstChar + "IdChecklistGenerica", VoceXChecklistGenericaObj.IdChecklistGenerica);
			DbProvider.SetCmdParam(cmd, firstChar + "IdVoceGenerica", VoceXChecklistGenericaObj.IdVoceGenerica);
			DbProvider.SetCmdParam(cmd, firstChar + "Ordine", VoceXChecklistGenericaObj.Ordine);
			DbProvider.SetCmdParam(cmd, firstChar + "Obbligatorio", VoceXChecklistGenericaObj.Obbligatorio);
			DbProvider.SetCmdParam(cmd, firstChar + "Peso", VoceXChecklistGenericaObj.Peso);
			DbProvider.SetCmdParam(cmd, firstChar + "DataInserimento", VoceXChecklistGenericaObj.DataInserimento);
			DbProvider.SetCmdParam(cmd, firstChar + "CfInserimento", VoceXChecklistGenericaObj.CfInserimento);
			DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", VoceXChecklistGenericaObj.DataModifica);
			DbProvider.SetCmdParam(cmd, firstChar + "CfModifica", VoceXChecklistGenericaObj.CfModifica);
			DbProvider.SetCmdParam(cmd, firstChar + "Misura", VoceXChecklistGenericaObj.Misura);
		}
		//Insert
		private static int Insert(DbProvider db, VoceXChecklistGenerica VoceXChecklistGenericaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd("ZVoceXChecklistGenericaInsert", new string[] {"IdChecklistGenerica", "IdVoceGenerica",
"Ordine", "Obbligatorio", "Peso",
"DataInserimento", "CfInserimento", "DataModifica",
"CfModifica", "Misura",






}, new string[] {"int", "int",
"int", "bool", "decimal",
"DateTime", "string", "DateTime",
"string", "string",






}, "");
				CompileIUCmd(false, insertCmd, VoceXChecklistGenericaObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
				{
					VoceXChecklistGenericaObj.IdVoceXChecklistGenerica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VOCE_X_CHECKLIST_GENERICA"]);
					VoceXChecklistGenericaObj.Obbligatorio = new SiarLibrary.NullTypes.BoolNT(db.DataReader["OBBLIGATORIO"]);
					VoceXChecklistGenericaObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
					VoceXChecklistGenericaObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
				}
				VoceXChecklistGenericaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VoceXChecklistGenericaObj.IsDirty = false;
				VoceXChecklistGenericaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, VoceXChecklistGenerica VoceXChecklistGenericaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZVoceXChecklistGenericaUpdate", new string[] {"IdVoceXChecklistGenerica", "IdChecklistGenerica", "IdVoceGenerica",
"Ordine", "Obbligatorio", "Peso",
"DataInserimento", "CfInserimento", "DataModifica",
"CfModifica", "Misura",






}, new string[] {"int", "int", "int",
"int", "bool", "decimal",
"DateTime", "string", "DateTime",
"string", "string",






}, "");
				CompileIUCmd(true, updateCmd, VoceXChecklistGenericaObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d != null)
				{
					i = 1;
					VoceXChecklistGenericaObj.DataModifica = d;
				}
				VoceXChecklistGenericaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VoceXChecklistGenericaObj.IsDirty = false;
				VoceXChecklistGenericaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, VoceXChecklistGenerica VoceXChecklistGenericaObj)
		{
			switch (VoceXChecklistGenericaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added: return Insert(db, VoceXChecklistGenericaObj);
				case BaseObject.ObjectStateType.Changed: return Update(db, VoceXChecklistGenericaObj);
				case BaseObject.ObjectStateType.Deleted: return Delete(db, VoceXChecklistGenericaObj);
				default: return 0;
			}
		}

		public static int SaveCollection(DbProvider db, VoceXChecklistGenericaCollection VoceXChecklistGenericaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZVoceXChecklistGenericaUpdate", new string[] {"IdVoceXChecklistGenerica", "IdChecklistGenerica", "IdVoceGenerica",
"Ordine", "Obbligatorio", "Peso",
"DataInserimento", "CfInserimento", "DataModifica",
"CfModifica", "Misura",






}, new string[] {"int", "int", "int",
"int", "bool", "decimal",
"DateTime", "string", "DateTime",
"string", "string",






}, "");
				IDbCommand insertCmd = db.InitCmd("ZVoceXChecklistGenericaInsert", new string[] {"IdChecklistGenerica", "IdVoceGenerica",
"Ordine", "Obbligatorio", "Peso",
"DataInserimento", "CfInserimento", "DataModifica",
"CfModifica", "Misura",






}, new string[] {"int", "int",
"int", "bool", "decimal",
"DateTime", "string", "DateTime",
"string", "string",






}, "");
				IDbCommand deleteCmd = db.InitCmd("ZVoceXChecklistGenericaDelete", new string[] { "IdVoceXChecklistGenerica" }, new string[] { "int" }, "");
				for (int i = 0; i < VoceXChecklistGenericaCollectionObj.Count; i++)
				{
					switch (VoceXChecklistGenericaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added:
							{
								CompileIUCmd(false, insertCmd, VoceXChecklistGenericaCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									VoceXChecklistGenericaCollectionObj[i].IdVoceXChecklistGenerica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VOCE_X_CHECKLIST_GENERICA"]);
									VoceXChecklistGenericaCollectionObj[i].Obbligatorio = new SiarLibrary.NullTypes.BoolNT(db.DataReader["OBBLIGATORIO"]);
									VoceXChecklistGenericaCollectionObj[i].DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
									VoceXChecklistGenericaCollectionObj[i].DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed:
							{
								CompileIUCmd(true, updateCmd, VoceXChecklistGenericaCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d != null)
								{
									returnValue++;
									VoceXChecklistGenericaCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted:
							{
								if (VoceXChecklistGenericaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdVoceXChecklistGenerica", (SiarLibrary.NullTypes.IntNT)VoceXChecklistGenericaCollectionObj[i].IdVoceXChecklistGenerica);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < VoceXChecklistGenericaCollectionObj.Count; i++)
				{
					if ((VoceXChecklistGenericaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (VoceXChecklistGenericaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						VoceXChecklistGenericaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						VoceXChecklistGenericaCollectionObj[i].IsDirty = false;
						VoceXChecklistGenericaCollectionObj[i].IsPersistent = true;
					}
					if ((VoceXChecklistGenericaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						VoceXChecklistGenericaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						VoceXChecklistGenericaCollectionObj[i].IsDirty = false;
						VoceXChecklistGenericaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, VoceXChecklistGenerica VoceXChecklistGenericaObj)
		{
			int returnValue = 0;
			if (VoceXChecklistGenericaObj.IsPersistent)
			{
				returnValue = Delete(db, VoceXChecklistGenericaObj.IdVoceXChecklistGenerica);
			}
			VoceXChecklistGenericaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			VoceXChecklistGenericaObj.IsDirty = false;
			VoceXChecklistGenericaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdVoceXChecklistGenericaValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZVoceXChecklistGenericaDelete", new string[] { "IdVoceXChecklistGenerica" }, new string[] { "int" }, "");
				DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdVoceXChecklistGenerica", (SiarLibrary.NullTypes.IntNT)IdVoceXChecklistGenericaValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, VoceXChecklistGenericaCollection VoceXChecklistGenericaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZVoceXChecklistGenericaDelete", new string[] { "IdVoceXChecklistGenerica" }, new string[] { "int" }, "");
				for (int i = 0; i < VoceXChecklistGenericaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdVoceXChecklistGenerica", VoceXChecklistGenericaCollectionObj[i].IdVoceXChecklistGenerica);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < VoceXChecklistGenericaCollectionObj.Count; i++)
				{
					if ((VoceXChecklistGenericaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (VoceXChecklistGenericaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						VoceXChecklistGenericaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						VoceXChecklistGenericaCollectionObj[i].IsDirty = false;
						VoceXChecklistGenericaCollectionObj[i].IsPersistent = false;
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
		public static VoceXChecklistGenerica GetById(DbProvider db, int IdVoceXChecklistGenericaValue)
		{
			VoceXChecklistGenerica VoceXChecklistGenericaObj = null;
			IDbCommand readCmd = db.InitCmd("ZVoceXChecklistGenericaGetById", new string[] { "IdVoceXChecklistGenerica" }, new string[] { "int" }, "");
			DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdVoceXChecklistGenerica", (SiarLibrary.NullTypes.IntNT)IdVoceXChecklistGenericaValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				VoceXChecklistGenericaObj = GetFromDatareader(db);
				VoceXChecklistGenericaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VoceXChecklistGenericaObj.IsDirty = false;
				VoceXChecklistGenericaObj.IsPersistent = true;
			}
			db.Close();
			return VoceXChecklistGenericaObj;
		}

		//getFromDatareader
		public static VoceXChecklistGenerica GetFromDatareader(DbProvider db)
		{
			VoceXChecklistGenerica VoceXChecklistGenericaObj = new VoceXChecklistGenerica();
			VoceXChecklistGenericaObj.IdVoceXChecklistGenerica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VOCE_X_CHECKLIST_GENERICA"]);
			VoceXChecklistGenericaObj.IdChecklistGenerica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CHECKLIST_GENERICA"]);
			VoceXChecklistGenericaObj.IdVoceGenerica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VOCE_GENERICA"]);
			VoceXChecklistGenericaObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
			VoceXChecklistGenericaObj.Obbligatorio = new SiarLibrary.NullTypes.BoolNT(db.DataReader["OBBLIGATORIO"]);
			VoceXChecklistGenericaObj.Peso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PESO"]);
			VoceXChecklistGenericaObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			VoceXChecklistGenericaObj.CfInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_INSERIMENTO"]);
			VoceXChecklistGenericaObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			VoceXChecklistGenericaObj.CfModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_MODIFICA"]);
			VoceXChecklistGenericaObj.Misura = new SiarLibrary.NullTypes.StringNT(db.DataReader["MISURA"]);
			VoceXChecklistGenericaObj.DescrizioneVoce = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_VOCE"]);
			VoceXChecklistGenericaObj.AutomaticoVoce = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AUTOMATICO_VOCE"]);
			VoceXChecklistGenericaObj.QuerySqlVoce = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_SQL_VOCE"]);
			VoceXChecklistGenericaObj.QuerySqlPostVoce = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_SQL_POST_VOCE"]);
			VoceXChecklistGenericaObj.CodeMethodVoce = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODE_METHOD_VOCE"]);
			VoceXChecklistGenericaObj.UrlVoce = new SiarLibrary.NullTypes.StringNT(db.DataReader["URL_VOCE"]);
			VoceXChecklistGenericaObj.ValMinimoVoce = new SiarLibrary.NullTypes.StringNT(db.DataReader["VAL_MINIMO_VOCE"]);
			VoceXChecklistGenericaObj.ValMassimoVoce = new SiarLibrary.NullTypes.StringNT(db.DataReader["VAL_MASSIMO_VOCE"]);
			VoceXChecklistGenericaObj.ValEsitoNegativoVoce = new SiarLibrary.NullTypes.BoolNT(db.DataReader["VAL_ESITO_NEGATIVO_VOCE"]);
			VoceXChecklistGenericaObj.IdFiltroVoce = new SiarLibrary.NullTypes.StringNT(db.DataReader["ID_FILTRO_VOCE"]);
			VoceXChecklistGenericaObj.TitoloVoce = new SiarLibrary.NullTypes.BoolNT(db.DataReader["TITOLO_VOCE"]);
			VoceXChecklistGenericaObj.CommentoVoce = new SiarLibrary.NullTypes.StringNT(db.DataReader["COMMENTO_VOCE"]);
			VoceXChecklistGenericaObj.DescrizioneFiltroVoce = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_FILTRO_VOCE"]);
			VoceXChecklistGenericaObj.OrdineFiltroVoce = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE_FILTRO_VOCE"]);
			VoceXChecklistGenericaObj.DescrizioneChecklist = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_CHECKLIST"]);
			VoceXChecklistGenericaObj.FlagTemplateChecklist = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_TEMPLATE_CHECKLIST"]);
			VoceXChecklistGenericaObj.IdTipoChecklist = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO_CHECKLIST"]);
			VoceXChecklistGenericaObj.DescrizioneTipoChecklist = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_TIPO_CHECKLIST"]);
			VoceXChecklistGenericaObj.ContieneVociTipoChecklist = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CONTIENE_VOCI_TIPO_CHECKLIST"]);
			VoceXChecklistGenericaObj.SchedaTipoChecklist = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SCHEDA_TIPO_CHECKLIST"]);
			VoceXChecklistGenericaObj.IdFiltroChecklist = new SiarLibrary.NullTypes.StringNT(db.DataReader["ID_FILTRO_CHECKLIST"]);
			VoceXChecklistGenericaObj.DescrizioneFiltroChecklist = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_FILTRO_CHECKLIST"]);
			VoceXChecklistGenericaObj.OrdineFiltroCheklist = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE_FILTRO_CHEKLIST"]);
			VoceXChecklistGenericaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			VoceXChecklistGenericaObj.IsDirty = false;
			VoceXChecklistGenericaObj.IsPersistent = true;
			return VoceXChecklistGenericaObj;
		}

		//Find Select

		public static VoceXChecklistGenericaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdVoceXChecklistGenericaEqualThis, SiarLibrary.NullTypes.IntNT IdChecklistGenericaEqualThis, SiarLibrary.NullTypes.IntNT IdVoceGenericaEqualThis,
SiarLibrary.NullTypes.IntNT OrdineEqualThis, SiarLibrary.NullTypes.BoolNT ObbligatorioEqualThis, SiarLibrary.NullTypes.DecimalNT PesoEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.StringNT CfInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis,
SiarLibrary.NullTypes.StringNT CfModificaEqualThis, SiarLibrary.NullTypes.StringNT MisuraEqualThis)

		{

			VoceXChecklistGenericaCollection VoceXChecklistGenericaCollectionObj = new VoceXChecklistGenericaCollection();

			IDbCommand findCmd = db.InitCmd("Zvocexchecklistgenericafindselect", new string[] {"IdVoceXChecklistGenericaequalthis", "IdChecklistGenericaequalthis", "IdVoceGenericaequalthis",
"Ordineequalthis", "Obbligatorioequalthis", "Pesoequalthis",
"DataInserimentoequalthis", "CfInserimentoequalthis", "DataModificaequalthis",
"CfModificaequalthis", "Misuraequalthis"}, new string[] {"int", "int", "int",
"int", "bool", "decimal",
"DateTime", "string", "DateTime",
"string", "string"}, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdVoceXChecklistGenericaequalthis", IdVoceXChecklistGenericaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdChecklistGenericaequalthis", IdChecklistGenericaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdVoceGenericaequalthis", IdVoceGenericaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Obbligatorioequalthis", ObbligatorioEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Pesoequalthis", PesoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfInserimentoequalthis", CfInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfModificaequalthis", CfModificaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Misuraequalthis", MisuraEqualThis);
			VoceXChecklistGenerica VoceXChecklistGenericaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VoceXChecklistGenericaObj = GetFromDatareader(db);
				VoceXChecklistGenericaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VoceXChecklistGenericaObj.IsDirty = false;
				VoceXChecklistGenericaObj.IsPersistent = true;
				VoceXChecklistGenericaCollectionObj.Add(VoceXChecklistGenericaObj);
			}
			db.Close();
			return VoceXChecklistGenericaCollectionObj;
		}

		//Find GetStepByChecklist

		public static VoceXChecklistGenericaCollection GetStepByChecklist(DbProvider db, SiarLibrary.NullTypes.IntNT IdChecklistGenericaEqualThis, SiarLibrary.NullTypes.StringNT MisuraEqualThis)

		{

			VoceXChecklistGenericaCollection VoceXChecklistGenericaCollectionObj = new VoceXChecklistGenericaCollection();

			IDbCommand findCmd = db.InitCmd("Zvocexchecklistgenericafindgetstepbychecklist", new string[] { "IdChecklistGenericaequalthis", "Misuraequalthis" }, new string[] { "int", "string" }, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdChecklistGenericaequalthis", IdChecklistGenericaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Misuraequalthis", MisuraEqualThis);
			VoceXChecklistGenerica VoceXChecklistGenericaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VoceXChecklistGenericaObj = GetFromDatareader(db);
				VoceXChecklistGenericaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VoceXChecklistGenericaObj.IsDirty = false;
				VoceXChecklistGenericaObj.IsPersistent = true;
				VoceXChecklistGenericaCollectionObj.Add(VoceXChecklistGenericaObj);
			}
			db.Close();
			return VoceXChecklistGenericaCollectionObj;
		}

		//Find FindGenerica

		public static VoceXChecklistGenericaCollection FindGenerica(DbProvider db, SiarLibrary.NullTypes.IntNT IdVoceXChecklistGenericaEqualThis, SiarLibrary.NullTypes.IntNT IdChecklistGenericaEqualThis, SiarLibrary.NullTypes.IntNT IdVoceGenericaEqualThis)

		{

			VoceXChecklistGenericaCollection VoceXChecklistGenericaCollectionObj = new VoceXChecklistGenericaCollection();

			IDbCommand findCmd = db.InitCmd("Zvocexchecklistgenericafindfindgenerica", new string[] { "IdVoceXChecklistGenericaequalthis", "IdChecklistGenericaequalthis", "IdVoceGenericaequalthis" }, new string[] { "int", "int", "int" }, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdVoceXChecklistGenericaequalthis", IdVoceXChecklistGenericaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdChecklistGenericaequalthis", IdChecklistGenericaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdVoceGenericaequalthis", IdVoceGenericaEqualThis);
			VoceXChecklistGenerica VoceXChecklistGenericaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VoceXChecklistGenericaObj = GetFromDatareader(db);
				VoceXChecklistGenericaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VoceXChecklistGenericaObj.IsDirty = false;
				VoceXChecklistGenericaObj.IsPersistent = true;
				VoceXChecklistGenericaCollectionObj.Add(VoceXChecklistGenericaObj);
			}
			db.Close();
			return VoceXChecklistGenericaCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for VoceXChecklistGenericaCollectionProvider:IVoceXChecklistGenericaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VoceXChecklistGenericaCollectionProvider : IVoceXChecklistGenericaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di VoceXChecklistGenerica
		protected VoceXChecklistGenericaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public VoceXChecklistGenericaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new VoceXChecklistGenericaCollection(this);
		}

		//Costruttore 2: popola la collection
		public VoceXChecklistGenericaCollectionProvider(IntNT IdchecklistgenericaEqualThis, StringNT MisuraEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = GetStepByChecklist(IdchecklistgenericaEqualThis, MisuraEqualThis);
		}

		//Costruttore3: ha in input vocexchecklistgenericaCollectionObj - non popola la collection
		public VoceXChecklistGenericaCollectionProvider(VoceXChecklistGenericaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public VoceXChecklistGenericaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new VoceXChecklistGenericaCollection(this);
		}

		//Get e Set
		public VoceXChecklistGenericaCollection CollectionObj
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
		public int SaveCollection(VoceXChecklistGenericaCollection collectionObj)
		{
			return VoceXChecklistGenericaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(VoceXChecklistGenerica vocexchecklistgenericaObj)
		{
			return VoceXChecklistGenericaDAL.Save(_dbProviderObj, vocexchecklistgenericaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(VoceXChecklistGenericaCollection collectionObj)
		{
			return VoceXChecklistGenericaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(VoceXChecklistGenerica vocexchecklistgenericaObj)
		{
			return VoceXChecklistGenericaDAL.Delete(_dbProviderObj, vocexchecklistgenericaObj);
		}

		//getById
		public VoceXChecklistGenerica GetById(IntNT IdVoceXChecklistGenericaValue)
		{
			VoceXChecklistGenerica VoceXChecklistGenericaTemp = VoceXChecklistGenericaDAL.GetById(_dbProviderObj, IdVoceXChecklistGenericaValue);
			if (VoceXChecklistGenericaTemp != null) VoceXChecklistGenericaTemp.Provider = this;
			return VoceXChecklistGenericaTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public VoceXChecklistGenericaCollection Select(IntNT IdvocexchecklistgenericaEqualThis, IntNT IdchecklistgenericaEqualThis, IntNT IdvocegenericaEqualThis,
IntNT OrdineEqualThis, BoolNT ObbligatorioEqualThis, DecimalNT PesoEqualThis,
DatetimeNT DatainserimentoEqualThis, StringNT CfinserimentoEqualThis, DatetimeNT DatamodificaEqualThis,
StringNT CfmodificaEqualThis, StringNT MisuraEqualThis)
		{
			VoceXChecklistGenericaCollection VoceXChecklistGenericaCollectionTemp = VoceXChecklistGenericaDAL.Select(_dbProviderObj, IdvocexchecklistgenericaEqualThis, IdchecklistgenericaEqualThis, IdvocegenericaEqualThis,
OrdineEqualThis, ObbligatorioEqualThis, PesoEqualThis,
DatainserimentoEqualThis, CfinserimentoEqualThis, DatamodificaEqualThis,
CfmodificaEqualThis, MisuraEqualThis);
			VoceXChecklistGenericaCollectionTemp.Provider = this;
			return VoceXChecklistGenericaCollectionTemp;
		}

		//GetStepByChecklist: popola la collection
		public VoceXChecklistGenericaCollection GetStepByChecklist(IntNT IdchecklistgenericaEqualThis, StringNT MisuraEqualThis)
		{
			VoceXChecklistGenericaCollection VoceXChecklistGenericaCollectionTemp = VoceXChecklistGenericaDAL.GetStepByChecklist(_dbProviderObj, IdchecklistgenericaEqualThis, MisuraEqualThis);
			VoceXChecklistGenericaCollectionTemp.Provider = this;
			return VoceXChecklistGenericaCollectionTemp;
		}

		//FindGenerica: popola la collection
		public VoceXChecklistGenericaCollection FindGenerica(IntNT IdvocexchecklistgenericaEqualThis, IntNT IdchecklistgenericaEqualThis, IntNT IdvocegenericaEqualThis)
		{
			VoceXChecklistGenericaCollection VoceXChecklistGenericaCollectionTemp = VoceXChecklistGenericaDAL.FindGenerica(_dbProviderObj, IdvocexchecklistgenericaEqualThis, IdchecklistgenericaEqualThis, IdvocegenericaEqualThis);
			VoceXChecklistGenericaCollectionTemp.Provider = this;
			return VoceXChecklistGenericaCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<VOCE_X_CHECKLIST_GENERICA>
  <ViewName>VVOCE_X_CHECKLIST_GENERICA</ViewName>
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
    <GetStepByChecklist OrderBy="ORDER BY ORDINE">
      <ID_CHECKLIST_GENERICA>Equal</ID_CHECKLIST_GENERICA>
      <MISURA>Equal</MISURA>
    </GetStepByChecklist>
    <FindGenerica OrderBy="ORDER BY ORDINE">
      <ID_VOCE_X_CHECKLIST_GENERICA>Equal</ID_VOCE_X_CHECKLIST_GENERICA>
      <ID_CHECKLIST_GENERICA>Equal</ID_CHECKLIST_GENERICA>
      <ID_VOCE_GENERICA>Equal</ID_VOCE_GENERICA>
    </FindGenerica>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</VOCE_X_CHECKLIST_GENERICA>
*/
