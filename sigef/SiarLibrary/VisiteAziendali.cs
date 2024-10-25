using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per VisiteAziendali
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IVisiteAziendaliProvider
	{
		int Save(VisiteAziendali VisiteAziendaliObj);
		int SaveCollection(VisiteAziendaliCollection collectionObj);
		int Delete(VisiteAziendali VisiteAziendaliObj);
		int DeleteCollection(VisiteAziendaliCollection collectionObj);
	}
	/// <summary>
	/// Summary description for VisiteAziendali
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class VisiteAziendali: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdVisita;
		private NullTypes.IntNT _IdDomandaPagamento;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.StringNT _CodTipo;
		private NullTypes.DatetimeNT _DataApertura;
		private NullTypes.StringNT _OperatoreApertura;
		private NullTypes.BoolNT _ControlloConcluso;
		private NullTypes.DatetimeNT _DataChiusura;
		private NullTypes.StringNT _OperatoreChiusura;
		private NullTypes.StringNT _SegnaturaVerbale;
		private NullTypes.StringNT _TipoVisitaAziendale;
		private NullTypes.StringNT _NominativoOperatoreApertura;
		private NullTypes.StringNT _NominativoOperatoreChiusura;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.StringNT _TipoDomandaPagamento;
		private NullTypes.IntNT _IdDomandaEroa;
		[NonSerialized] private IVisiteAziendaliProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IVisiteAziendaliProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public VisiteAziendali()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_VISITA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdVisita
		{
			get { return _IdVisita; }
			set {
				if (IdVisita != value)
				{
					_IdVisita = value;
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
		/// Corrisponde al campo:COD_TIPO
		/// Tipo sul db:CHAR(3)
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
		/// Corrisponde al campo:DATA_APERTURA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataApertura
		{
			get { return _DataApertura; }
			set {
				if (DataApertura != value)
				{
					_DataApertura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE_APERTURA
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT OperatoreApertura
		{
			get { return _OperatoreApertura; }
			set {
				if (OperatoreApertura != value)
				{
					_OperatoreApertura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTROLLO_CONCLUSO
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT ControlloConcluso
		{
			get { return _ControlloConcluso; }
			set {
				if (ControlloConcluso != value)
				{
					_ControlloConcluso = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_CHIUSURA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataChiusura
		{
			get { return _DataChiusura; }
			set {
				if (DataChiusura != value)
				{
					_DataChiusura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE_CHIUSURA
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT OperatoreChiusura
		{
			get { return _OperatoreChiusura; }
			set {
				if (OperatoreChiusura != value)
				{
					_OperatoreChiusura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SEGNATURA_VERBALE
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT SegnaturaVerbale
		{
			get { return _SegnaturaVerbale; }
			set {
				if (SegnaturaVerbale != value)
				{
					_SegnaturaVerbale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO_VISITA_AZIENDALE
		/// Tipo sul db:VARCHAR(200)
		/// </summary>
		public NullTypes.StringNT TipoVisitaAziendale
		{
			get { return _TipoVisitaAziendale; }
			set {
				if (TipoVisitaAziendale != value)
				{
					_TipoVisitaAziendale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOMINATIVO_OPERATORE_APERTURA
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT NominativoOperatoreApertura
		{
			get { return _NominativoOperatoreApertura; }
			set {
				if (NominativoOperatoreApertura != value)
				{
					_NominativoOperatoreApertura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOMINATIVO_OPERATORE_CHIUSURA
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT NominativoOperatoreChiusura
		{
			get { return _NominativoOperatoreChiusura; }
			set {
				if (NominativoOperatoreChiusura != value)
				{
					_NominativoOperatoreChiusura = value;
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
		/// Corrisponde al campo:TIPO_DOMANDA_PAGAMENTO
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT TipoDomandaPagamento
		{
			get { return _TipoDomandaPagamento; }
			set {
				if (TipoDomandaPagamento != value)
				{
					_TipoDomandaPagamento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_DOMANDA_EROA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDomandaEroa
		{
			get { return _IdDomandaEroa; }
			set {
				if (IdDomandaEroa != value)
				{
					_IdDomandaEroa = value;
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
/*Config
<?xml version="1.0" encoding="utf-16"?>
<VISITE_AZIENDALI>
  <ViewName>vVISITE_AZIENDALI</ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>True</chkDataModifica>
  <txtNomeCampoDataModifica>DATA_MODIFICA</txtNomeCampoDataModifica>
  <chkOptimisticCouncurrency>True</chkOptimisticCouncurrency>
  <chkShortNames>False</chkShortNames>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds>
    <Find OrderBy="ORDER BY ID_VISITA DESC">
      <ID_VISITA>Equal</ID_VISITA>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <COD_TIPO>Equal</COD_TIPO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_DOMANDA_EROA>Equal</ID_DOMANDA_EROA>
    </Find>
  </Finds>
  <Filters>
    <FiltroControlloConcluso>
      <CONTROLLO_CONCLUSO>Equal</CONTROLLO_CONCLUSO>
    </FiltroControlloConcluso>
    <FiltroTipo>
      <COD_TIPO>Equal</COD_TIPO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
    </FiltroTipo>
  </Filters>
  <externalFields />
  <AddedFkFields />
</VISITE_AZIENDALI>
*/