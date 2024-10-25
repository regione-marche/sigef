using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per ProgettoSegnature
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IProgettoSegnatureProvider
	{
		int Save(ProgettoSegnature ProgettoSegnatureObj);
		int SaveCollection(ProgettoSegnatureCollection collectionObj);
		int Delete(ProgettoSegnature ProgettoSegnatureObj);
		int DeleteCollection(ProgettoSegnatureCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ProgettoSegnature
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class ProgettoSegnature: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.StringNT _CodTipo;
		private NullTypes.DatetimeNT _Data;
		private NullTypes.StringNT _Operatore;
		private NullTypes.StringNT _Segnatura;
		private NullTypes.StringNT _TipoSegnatura;
		private NullTypes.StringNT _Profilo;
		private NullTypes.StringNT _Ente;
		private NullTypes.IntNT _IdProfilo;
		private NullTypes.StringNT _Nominativo;
		private NullTypes.StringNT _CodEnte;
		private NullTypes.StringNT _Provincia;
		private NullTypes.BoolNT _RiapriDomanda;
		private NullTypes.StringNT _Motivazione;
		[NonSerialized] private IProgettoSegnatureProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IProgettoSegnatureProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ProgettoSegnature()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
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
		/// Corrisponde al campo:SEGNATURA
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT Segnatura
		{
			get { return _Segnatura; }
			set {
				if (Segnatura != value)
				{
					_Segnatura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO_SEGNATURA
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT TipoSegnatura
		{
			get { return _TipoSegnatura; }
			set {
				if (TipoSegnatura != value)
				{
					_TipoSegnatura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PROFILO
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Profilo
		{
			get { return _Profilo; }
			set {
				if (Profilo != value)
				{
					_Profilo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ENTE
		/// Tipo sul db:VARCHAR(255)
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
		/// Corrisponde al campo:ID_PROFILO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProfilo
		{
			get { return _IdProfilo; }
			set {
				if (IdProfilo != value)
				{
					_IdProfilo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOMINATIVO
		/// Tipo sul db:VARCHAR(511)
		/// </summary>
		public NullTypes.StringNT Nominativo
		{
			get { return _Nominativo; }
			set {
				if (Nominativo != value)
				{
					_Nominativo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_ENTE
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT CodEnte
		{
			get { return _CodEnte; }
			set {
				if (CodEnte != value)
				{
					_CodEnte = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PROVINCIA
		/// Tipo sul db:CHAR(2)
		/// </summary>
		public NullTypes.StringNT Provincia
		{
			get { return _Provincia; }
			set {
				if (Provincia != value)
				{
					_Provincia = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RIAPRI_DOMANDA
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT RiapriDomanda
		{
			get { return _RiapriDomanda; }
			set {
				if (RiapriDomanda != value)
				{
					_RiapriDomanda = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MOTIVAZIONE
		/// Tipo sul db:NTEXT
		/// </summary>
		public NullTypes.StringNT Motivazione
		{
			get { return _Motivazione; }
			set {
				if (Motivazione != value)
				{
					_Motivazione = value;
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
<PROGETTO_SEGNATURE>
  <ViewName>vPROGETTO_SEGNATURE</ViewName>
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
    <Find OrderBy="ORDER BY ID_PROGETTO, DATA DESC">
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <OPERATORE>Equal</OPERATORE>
      <SEGNATURA>Equal</SEGNATURA>
      <COD_TIPO>Like</COD_TIPO>
    </Find>
  </Finds>
  <Filters>
    <FiltroLikeTipoSegnatura>
      <COD_TIPO>Like</COD_TIPO>
    </FiltroLikeTipoSegnatura>
  </Filters>
  <externalFields />
  <AddedFkFields />
</PROGETTO_SEGNATURE>
*/