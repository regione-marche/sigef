using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per ControlliParametriXLotto
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IControlliParametriXLottoProvider
	{
		int Save(ControlliParametriXLotto ControlliParametriXLottoObj);
		int SaveCollection(ControlliParametriXLottoCollection collectionObj);
		int Delete(ControlliParametriXLotto ControlliParametriXLottoObj);
		int DeleteCollection(ControlliParametriXLottoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ControlliParametriXLotto
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class ControlliParametriXLotto: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdLotto;
		private NullTypes.IntNT _IdParametro;
		private NullTypes.IntNT _PesoReale;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.StringNT _QuerySql;
		private NullTypes.IntNT _Peso;
		private NullTypes.BoolNT _Manuale;
		[NonSerialized] private IControlliParametriXLottoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IControlliParametriXLottoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ControlliParametriXLotto()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
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
		/// Corrisponde al campo:PESO_REALE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT PesoReale
		{
			get { return _PesoReale; }
			set {
				if (PesoReale != value)
				{
					_PesoReale = value;
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

		/// <summary>
		/// Corrisponde al campo:PESO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Peso
		{
			get { return _Peso; }
			set {
				if (Peso != value)
				{
					_Peso = value;
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
<CONTROLLI_PARAMETRI_X_LOTTO>
  <ViewName>vCONTROLLI_PARAMETRI_X_LOTTO</ViewName>
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
      <ID_LOTTO>Equal</ID_LOTTO>
      <ID_PARAMETRO>Equal</ID_PARAMETRO>
      <MANUALE>Equal</MANUALE>
      <DESCRIZIONE>Like</DESCRIZIONE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CONTROLLI_PARAMETRI_X_LOTTO>
*/