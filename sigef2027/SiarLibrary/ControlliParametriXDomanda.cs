using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per ControlliParametriXDomanda
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IControlliParametriXDomandaProvider
	{
		int Save(ControlliParametriXDomanda ControlliParametriXDomandaObj);
		int SaveCollection(ControlliParametriXDomandaCollection collectionObj);
		int Delete(ControlliParametriXDomanda ControlliParametriXDomandaObj);
		int DeleteCollection(ControlliParametriXDomandaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ControlliParametriXDomanda
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class ControlliParametriXDomanda: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdDomandaPagamento;
		private NullTypes.IntNT _IdParametro;
		private NullTypes.IntNT _IdLotto;
		private NullTypes.IntNT _Punteggio;
		private NullTypes.DatetimeNT _DataValutazione;
		private NullTypes.StringNT _Operatore;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.BoolNT _Manuale;
		private NullTypes.StringNT _QuerySql;
		[NonSerialized] private IControlliParametriXDomandaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IControlliParametriXDomandaProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ControlliParametriXDomanda()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
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
		/// Corrisponde al campo:ID_PARAMETRO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdParametro
		{
			get { return _IdParametro; }
			set {
				if (IdParametro != value)
				{
					_IdParametro = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_LOTTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdLotto
		{
			get { return _IdLotto; }
			set {
				if (IdLotto != value)
				{
					_IdLotto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PUNTEGGIO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Punteggio
		{
			get { return _Punteggio; }
			set {
				if (Punteggio != value)
				{
					_Punteggio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_VALUTAZIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataValutazione
		{
			get { return _DataValutazione; }
			set {
				if (DataValutazione != value)
				{
					_DataValutazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT Operatore
		{
			get { return _Operatore; }
			set {
				if (Operatore != value)
				{
					_Operatore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(500)
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
		/// Corrisponde al campo:MANUALE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Manuale
		{
			get { return _Manuale; }
			set {
				if (Manuale != value)
				{
					_Manuale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUERY_SQL
		/// Tipo sul db:VARCHAR(3000)
		/// </summary>
		public NullTypes.StringNT QuerySql
		{
			get { return _QuerySql; }
			set {
				if (QuerySql != value)
				{
					_QuerySql = value;
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
<CONTROLLI_PARAMETRI_X_DOMANDA>
  <ViewName>vCONTROLLI_PARAMETRI_X_DOMANDA</ViewName>
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
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_PARAMETRO>Equal</ID_PARAMETRO>
      <ID_LOTTO>Equal</ID_LOTTO>
      <MANUALE>Equal</MANUALE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CONTROLLI_PARAMETRI_X_DOMANDA>
*/