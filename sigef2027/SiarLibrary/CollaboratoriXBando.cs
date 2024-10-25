using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per CollaboratoriXBando
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ICollaboratoriXBandoProvider
	{
		int Save(CollaboratoriXBando CollaboratoriXBandoObj);
		int SaveCollection(CollaboratoriXBandoCollection collectionObj);
		int Delete(CollaboratoriXBando CollaboratoriXBandoObj);
		int DeleteCollection(CollaboratoriXBandoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for CollaboratoriXBando
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class CollaboratoriXBando: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdCollaboratore;
		private NullTypes.IntNT _IdBando;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.StringNT _Provincia;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.DatetimeNT _DataFineValidita;
		private NullTypes.StringNT _Nominativo;
		private NullTypes.StringNT _CodEnte;
		private NullTypes.StringNT _ProvinciaUtente;
		private NullTypes.IntNT _IdUtente;
		private NullTypes.IntNT _OperatoreInserimento;
		private NullTypes.IntNT _OperatoreFineValidita;
		private NullTypes.BoolNT _Attivo;
		[NonSerialized] private ICollaboratoriXBandoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICollaboratoriXBandoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public CollaboratoriXBando()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_COLLABORATORE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdCollaboratore
		{
			get { return _IdCollaboratore; }
			set {
				if (IdCollaboratore != value)
				{
					_IdCollaboratore = value;
					SetDirtyFlag();
				}
			}
		}

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
		/// Corrisponde al campo:NOMINATIVO
		/// Tipo sul db:VARCHAR(255)
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
		/// Corrisponde al campo:PROVINCIA_UTENTE
		/// Tipo sul db:CHAR(2)
		/// </summary>
		public NullTypes.StringNT ProvinciaUtente
		{
			get { return _ProvinciaUtente; }
			set {
				if (ProvinciaUtente != value)
				{
					_ProvinciaUtente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_UTENTE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdUtente
		{
			get { return _IdUtente; }
			set {
				if (IdUtente != value)
				{
					_IdUtente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE_INSERIMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OperatoreInserimento
		{
			get { return _OperatoreInserimento; }
			set {
				if (OperatoreInserimento != value)
				{
					_OperatoreInserimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE_FINE_VALIDITA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OperatoreFineValidita
		{
			get { return _OperatoreFineValidita; }
			set {
				if (OperatoreFineValidita != value)
				{
					_OperatoreFineValidita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ATTIVO
		/// Tipo sul db:BIT
		/// Default:((0))
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
<COLLABORATORI_X_BANDO>
  <ViewName>vCOLLABORATORI_X_BANDO</ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
  <txtNomeCampoDataModifica>DATA</txtNomeCampoDataModifica>
  <chkOptimisticCouncurrency>False</chkOptimisticCouncurrency>
  <chkShortNames>False</chkShortNames>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds>
    <Find OrderBy="ORDER BY ID_PROGETTO">
      <ID_BANDO>Equal</ID_BANDO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_UTENTE>Equal</ID_UTENTE>
      <PROVINCIA>Equal</PROVINCIA>
      <ATTIVO>Equal</ATTIVO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</COLLABORATORI_X_BANDO>
*/