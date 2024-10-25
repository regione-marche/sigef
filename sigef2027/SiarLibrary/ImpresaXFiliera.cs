using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per ImpresaXFiliera
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IImpresaXFilieraProvider
	{
		int Save(ImpresaXFiliera ImpresaXFilieraObj);
		int SaveCollection(ImpresaXFilieraCollection collectionObj);
		int Delete(ImpresaXFiliera ImpresaXFilieraObj);
		int DeleteCollection(ImpresaXFilieraCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ImpresaXFiliera
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class ImpresaXFiliera: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdImpresaXFiliera;
		private NullTypes.IntNT _IdFiliera;
		private NullTypes.StringNT _Cuaa;
		private NullTypes.BoolNT _FlagPartecipante;
		private NullTypes.StringNT _CodRuoloSitra;
		private NullTypes.StringNT _RuoloSitra;
		private NullTypes.StringNT _CodRuoloPartecipante;
		private NullTypes.StringNT _RuoloPartecipante;
		private NullTypes.DecimalNT _Quantita;
		private NullTypes.IntNT _UnitaMisura;
		private NullTypes.StringNT _DescrizioneUnitaMisura;
		private NullTypes.StringNT _SistemaQualita;
		private NullTypes.StringNT _DescrizioneSistemaQualita;
		private NullTypes.IntNT _IdPsr;
		private NullTypes.StringNT _Psr;
		private NullTypes.IntNT _CodMisura;
		private NullTypes.StringNT _Misura;
		private NullTypes.IntNT _CodObiettivo;
		private NullTypes.StringNT _Obiettivo;
		private NullTypes.IntNT _CodAsse;
		private NullTypes.StringNT _Asse;
		private NullTypes.StringNT _CodSubmisura;
		private NullTypes.StringNT _Submisura;
		private NullTypes.StringNT _CodificaInterventi;
		private NullTypes.StringNT _Operatore;
		private NullTypes.StringNT _Codice;
		private NullTypes.BoolNT _Ammesso;
		[NonSerialized] private IImpresaXFilieraProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IImpresaXFilieraProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ImpresaXFiliera()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_IMPRESA_X_FILIERA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdImpresaXFiliera
		{
			get { return _IdImpresaXFiliera; }
			set {
				if (IdImpresaXFiliera != value)
				{
					_IdImpresaXFiliera = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_FILIERA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdFiliera
		{
			get { return _IdFiliera; }
			set {
				if (IdFiliera != value)
				{
					_IdFiliera = value;
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
		/// Corrisponde al campo:FLAG_PARTECIPANTE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT FlagPartecipante
		{
			get { return _FlagPartecipante; }
			set {
				if (FlagPartecipante != value)
				{
					_FlagPartecipante = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_RUOLO_SITRA
		/// Tipo sul db:CHAR(3)
		/// </summary>
		public NullTypes.StringNT CodRuoloSitra
		{
			get { return _CodRuoloSitra; }
			set {
				if (CodRuoloSitra != value)
				{
					_CodRuoloSitra = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RUOLO_SITRA
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT RuoloSitra
		{
			get { return _RuoloSitra; }
			set {
				if (RuoloSitra != value)
				{
					_RuoloSitra = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_RUOLO_PARTECIPANTE
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT CodRuoloPartecipante
		{
			get { return _CodRuoloPartecipante; }
			set {
				if (CodRuoloPartecipante != value)
				{
					_CodRuoloPartecipante = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RUOLO_PARTECIPANTE
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT RuoloPartecipante
		{
			get { return _RuoloPartecipante; }
			set {
				if (RuoloPartecipante != value)
				{
					_RuoloPartecipante = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUANTITA
		/// Tipo sul db:DECIMAL(10,2)
		/// </summary>
		public NullTypes.DecimalNT Quantita
		{
			get { return _Quantita; }
			set {
				if (Quantita != value)
				{
					_Quantita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:UNITA_MISURA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT UnitaMisura
		{
			get { return _UnitaMisura; }
			set {
				if (UnitaMisura != value)
				{
					_UnitaMisura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_UNITA_MISURA
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT DescrizioneUnitaMisura
		{
			get { return _DescrizioneUnitaMisura; }
			set {
				if (DescrizioneUnitaMisura != value)
				{
					_DescrizioneUnitaMisura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SISTEMA_QUALITA
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT SistemaQualita
		{
			get { return _SistemaQualita; }
			set {
				if (SistemaQualita != value)
				{
					_SistemaQualita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_SISTEMA_QUALITA
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT DescrizioneSistemaQualita
		{
			get { return _DescrizioneSistemaQualita; }
			set {
				if (DescrizioneSistemaQualita != value)
				{
					_DescrizioneSistemaQualita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_PSR
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdPsr
		{
			get { return _IdPsr; }
			set {
				if (IdPsr != value)
				{
					_IdPsr = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PSR
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Psr
		{
			get { return _Psr; }
			set {
				if (Psr != value)
				{
					_Psr = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_MISURA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT CodMisura
		{
			get { return _CodMisura; }
			set {
				if (CodMisura != value)
				{
					_CodMisura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MISURA
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Misura
		{
			get { return _Misura; }
			set {
				if (Misura != value)
				{
					_Misura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_OBIETTIVO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT CodObiettivo
		{
			get { return _CodObiettivo; }
			set {
				if (CodObiettivo != value)
				{
					_CodObiettivo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OBIETTIVO
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Obiettivo
		{
			get { return _Obiettivo; }
			set {
				if (Obiettivo != value)
				{
					_Obiettivo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_ASSE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT CodAsse
		{
			get { return _CodAsse; }
			set {
				if (CodAsse != value)
				{
					_CodAsse = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ASSE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Asse
		{
			get { return _Asse; }
			set {
				if (Asse != value)
				{
					_Asse = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_SUBMISURA
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT CodSubmisura
		{
			get { return _CodSubmisura; }
			set {
				if (CodSubmisura != value)
				{
					_CodSubmisura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SUBMISURA
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Submisura
		{
			get { return _Submisura; }
			set {
				if (Submisura != value)
				{
					_Submisura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODIFICA_INTERVENTI
		/// Tipo sul db:NTEXT
		/// </summary>
		public NullTypes.StringNT CodificaInterventi
		{
			get { return _CodificaInterventi; }
			set {
				if (CodificaInterventi != value)
				{
					_CodificaInterventi = value;
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
		/// Corrisponde al campo:CODICE
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT Codice
		{
			get { return _Codice; }
			set {
				if (Codice != value)
				{
					_Codice = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:AMMESSO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Ammesso
		{
			get { return _Ammesso; }
			set {
				if (Ammesso != value)
				{
					_Ammesso = value;
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
<IMPRESA_X_FILIERA>
  <ViewName>vIMPRESA_X_FILIERA</ViewName>
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
    <Find OrderBy="ORDER BY AMMESSO, CUAA">
      <ID_FILIERA>Equal</ID_FILIERA>
      <CUAA>Like</CUAA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</IMPRESA_X_FILIERA>
*/