using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per CollaboratoriXManifestazione
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ICollaboratoriXManifestazioneProvider
	{
		int Save(CollaboratoriXManifestazione CollaboratoriXManifestazioneObj);
		int SaveCollection(CollaboratoriXManifestazioneCollection collectionObj);
		int Delete(CollaboratoriXManifestazione CollaboratoriXManifestazioneObj);
		int DeleteCollection(CollaboratoriXManifestazioneCollection collectionObj);
	}
	/// <summary>
	/// Summary description for CollaboratoriXManifestazione
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class CollaboratoriXManifestazione: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdCollaboratore;
		private NullTypes.IntNT _IdBando;
		private NullTypes.IntNT _IdManifestazione;
		private NullTypes.IntNT _IdUtente;
		private NullTypes.StringNT _CfUtente;
		private NullTypes.StringNT _Operatore;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.StringNT _Cuaa;
		private NullTypes.StringNT _RagioneSociale;
		private NullTypes.StringNT _Via;
		private NullTypes.StringNT _Comune;
		private NullTypes.StringNT _Cap;
		private NullTypes.StringNT _Sigla;
		private NullTypes.DatetimeNT _DataUltimaModifica;
		private NullTypes.StringNT _Nominativo;
		private NullTypes.StringNT _CodEnte;
		private NullTypes.StringNT _Provincia;
		private NullTypes.StringNT _Segnatura;
		[NonSerialized] private ICollaboratoriXManifestazioneProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICollaboratoriXManifestazioneProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public CollaboratoriXManifestazione()
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
		/// Corrisponde al campo:ID_MANIFESTAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdManifestazione
		{
			get { return _IdManifestazione; }
			set {
				if (IdManifestazione != value)
				{
					_IdManifestazione = value;
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
		/// Corrisponde al campo:CF_UTENTE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CfUtente
		{
			get { return _CfUtente; }
			set {
				if (CfUtente != value)
				{
					_CfUtente = value;
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
		/// Corrisponde al campo:CUAA
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT Cuaa
		{
			get { return _Cuaa; }
			set {
				if (Cuaa != value)
				{
					_Cuaa = value;
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
		/// Corrisponde al campo:VIA
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT Via
		{
			get { return _Via; }
			set {
				if (Via != value)
				{
					_Via = value;
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
		/// Corrisponde al campo:DATA_ULTIMA_MODIFICA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataUltimaModifica
		{
			get { return _DataUltimaModifica; }
			set {
				if (DataUltimaModifica != value)
				{
					_DataUltimaModifica = value;
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
<COLLABORATORI_X_MANIFESTAZIONE>
  <ViewName>vCOLLABORATORI_X_MANIFESTAZIONE</ViewName>
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
      <ID_MANIFESTAZIONE>Equal</ID_MANIFESTAZIONE>
      <CF_UTENTE>Equal</CF_UTENTE>
      <CUAA>Like</CUAA>
      <RAGIONE_SOCIALE>Like</RAGIONE_SOCIALE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</COLLABORATORI_X_MANIFESTAZIONE>
*/