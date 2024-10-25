using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per ContoCorrente
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IContoCorrenteProvider
	{
		int Save(ContoCorrente ContoCorrenteObj);
		int SaveCollection(ContoCorrenteCollection collectionObj);
		int Delete(ContoCorrente ContoCorrenteObj);
		int DeleteCollection(ContoCorrenteCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ContoCorrente
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class ContoCorrente: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdContoCorrente;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.IntNT _IdPersona;
		private NullTypes.StringNT _CodPaese;
		private NullTypes.StringNT _CinEuro;
		private NullTypes.StringNT _Cin;
		private NullTypes.StringNT _Abi;
		private NullTypes.StringNT _Cab;
		private NullTypes.StringNT _Numero;
		private NullTypes.StringNT _Note;
		private NullTypes.DatetimeNT _DataInizioValidita;
		private NullTypes.DatetimeNT _DataFineValidita;
		private NullTypes.StringNT _Istituto;
		private NullTypes.StringNT _Agenzia;
		private NullTypes.IntNT _IdComune;
		private NullTypes.StringNT _CodBelfiore;
		private NullTypes.StringNT _Comune;
		private NullTypes.StringNT _Sigla;
		private NullTypes.StringNT _Cap;
		[NonSerialized] private IContoCorrenteProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IContoCorrenteProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ContoCorrente()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_CONTO_CORRENTE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdContoCorrente
		{
			get { return _IdContoCorrente; }
			set {
				if (IdContoCorrente != value)
				{
					_IdContoCorrente = value;
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
		/// Corrisponde al campo:ID_PERSONA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdPersona
		{
			get { return _IdPersona; }
			set {
				if (IdPersona != value)
				{
					_IdPersona = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_PAESE
		/// Tipo sul db:CHAR(2)
		/// </summary>
		public NullTypes.StringNT CodPaese
		{
			get { return _CodPaese; }
			set {
				if (CodPaese != value)
				{
					_CodPaese = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CIN_EURO
		/// Tipo sul db:CHAR(2)
		/// </summary>
		public NullTypes.StringNT CinEuro
		{
			get { return _CinEuro; }
			set {
				if (CinEuro != value)
				{
					_CinEuro = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CIN
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT Cin
		{
			get { return _Cin; }
			set {
				if (Cin != value)
				{
					_Cin = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ABI
		/// Tipo sul db:VARCHAR(5)
		/// </summary>
		public NullTypes.StringNT Abi
		{
			get { return _Abi; }
			set {
				if (Abi != value)
				{
					_Abi = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CAB
		/// Tipo sul db:VARCHAR(5)
		/// </summary>
		public NullTypes.StringNT Cab
		{
			get { return _Cab; }
			set {
				if (Cab != value)
				{
					_Cab = value;
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
		/// Corrisponde al campo:NOTE
		/// Tipo sul db:VARCHAR(500)
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
		/// Corrisponde al campo:ISTITUTO
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Istituto
		{
			get { return _Istituto; }
			set {
				if (Istituto != value)
				{
					_Istituto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:AGENZIA
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Agenzia
		{
			get { return _Agenzia; }
			set {
				if (Agenzia != value)
				{
					_Agenzia = value;
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
		/// Corrisponde al campo:COD_BELFIORE
		/// Tipo sul db:CHAR(4)
		/// </summary>
		public NullTypes.StringNT CodBelfiore
		{
			get { return _CodBelfiore; }
			set {
				if (CodBelfiore != value)
				{
					_CodBelfiore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COMUNE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Comune
		{
			get { return _Comune; }
			set {
				if (Comune != value)
				{
					_Comune = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SIGLA
		/// Tipo sul db:CHAR(2)
		/// </summary>
		public NullTypes.StringNT Sigla
		{
			get { return _Sigla; }
			set {
				if (Sigla != value)
				{
					_Sigla = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CAP
		/// Tipo sul db:VARCHAR(5)
		/// </summary>
		public NullTypes.StringNT Cap
		{
			get { return _Cap; }
			set {
				if (Cap != value)
				{
					_Cap = value;
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
<CONTO_CORRENTE>
  <ViewName>vCONTO_CORRENTE</ViewName>
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
      <ID_CONTO_CORRENTE>Equal</ID_CONTO_CORRENTE>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <ID_PERSONA>Equal</ID_PERSONA>
      <DATA_INIZIO_VALIDITA>EqLessThan</DATA_INIZIO_VALIDITA>
      <DATA_FINE_VALIDITA>EqGreaterThan</DATA_FINE_VALIDITA>
      <DATA_FINE_VALIDITA>IsNull</DATA_FINE_VALIDITA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CONTO_CORRENTE>
*/