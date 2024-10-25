using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per BandoTipoPagamento
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IBandoTipoPagamentoProvider
	{
		int Save(BandoTipoPagamento BandoTipoPagamentoObj);
		int SaveCollection(BandoTipoPagamentoCollection collectionObj);
		int Delete(BandoTipoPagamento BandoTipoPagamentoObj);
		int DeleteCollection(BandoTipoPagamentoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for BandoTipoPagamento
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class BandoTipoPagamento: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdBando;
		private NullTypes.StringNT _CodTipo;
		private NullTypes.DecimalNT _QuotaMax;
		private NullTypes.DecimalNT _QuotaMin;
		private NullTypes.DecimalNT _ImportoMax;
		private NullTypes.DecimalNT _ImportoMin;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.StringNT _CodFase;
		private NullTypes.StringNT _Fase;
		private NullTypes.IntNT _Ordine;
		private NullTypes.IntNT _Numero;
		private NullTypes.StringNT _CodTipoPolizza;
		private NullTypes.StringNT _TipoPolizza;
		[NonSerialized] private IBandoTipoPagamentoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBandoTipoPagamentoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public BandoTipoPagamento()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_BANDO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdBando
		{
			get { return _IdBando; }
			set {
				if (IdBando != value)
				{
					_IdBando = value;
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
		/// Corrisponde al campo:QUOTA_MAX
		/// Tipo sul db:DECIMAL(10,2)
		/// </summary>
		public NullTypes.DecimalNT QuotaMax
		{
			get { return _QuotaMax; }
			set {
				if (QuotaMax != value)
				{
					_QuotaMax = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUOTA_MIN
		/// Tipo sul db:DECIMAL(10,2)
		/// </summary>
		public NullTypes.DecimalNT QuotaMin
		{
			get { return _QuotaMin; }
			set {
				if (QuotaMin != value)
				{
					_QuotaMin = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_MAX
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoMax
		{
			get { return _ImportoMax; }
			set {
				if (ImportoMax != value)
				{
					_ImportoMax = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_MIN
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoMin
		{
			get { return _ImportoMin; }
			set {
				if (ImportoMin != value)
				{
					_ImportoMin = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(100)
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
		/// Corrisponde al campo:COD_FASE
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT CodFase
		{
			get { return _CodFase; }
			set {
				if (CodFase != value)
				{
					_CodFase = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FASE
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT Fase
		{
			get { return _Fase; }
			set {
				if (Fase != value)
				{
					_Fase = value;
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
		/// Corrisponde al campo:NUMERO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Numero
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
		/// Corrisponde al campo:COD_TIPO_POLIZZA
		/// Tipo sul db:CHAR(3)
		/// </summary>
		public NullTypes.StringNT CodTipoPolizza
		{
			get { return _CodTipoPolizza; }
			set {
				if (CodTipoPolizza != value)
				{
					_CodTipoPolizza = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO_POLIZZA
		/// Tipo sul db:NVARCHAR
		/// </summary>
		public NullTypes.StringNT TipoPolizza
		{
			get { return _TipoPolizza; }
			set {
				if (TipoPolizza != value)
				{
					_TipoPolizza = value;
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
<BANDO_TIPO_PAGAMENTO>
  <ViewName>vBANDO_TIPO_PAGAMENTO</ViewName>
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
      <ID_BANDO>Equal</ID_BANDO>
      <COD_TIPO>Equal</COD_TIPO>
      <COD_FASE>Equal</COD_FASE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</BANDO_TIPO_PAGAMENTO>
*/