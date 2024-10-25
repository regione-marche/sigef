using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per PartecipanteRuolo
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IPartecipanteRuoloProvider
	{
		int Save(PartecipanteRuolo PartecipanteRuoloObj);
		int SaveCollection(PartecipanteRuoloCollection collectionObj);
		int Delete(PartecipanteRuolo PartecipanteRuoloObj);
		int DeleteCollection(PartecipanteRuoloCollection collectionObj);
	}
	/// <summary>
	/// Summary description for PartecipanteRuolo
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class PartecipanteRuolo: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdPartcipanteRuolo;
		private NullTypes.StringNT _CodFiliera;
		private NullTypes.StringNT _Cuaa;
		private NullTypes.BoolNT _FlagPartecipante;
		private NullTypes.StringNT _CodRuoloSitra;
		private NullTypes.StringNT _CodRuoloPartecipante;
		private NullTypes.StringNT _OperatoreInserimento;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.StringNT _RuoloOperativo;
		private NullTypes.StringNT _RuoloSitra;
		private NullTypes.IntNT _IdProgettoPif;
		private NullTypes.StringNT _SistemaDiQualita;
		private NullTypes.StringNT _CodSistemaQualita;
		[NonSerialized] private IPartecipanteRuoloProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IPartecipanteRuoloProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public PartecipanteRuolo()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_PARTCIPANTE_RUOLO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdPartcipanteRuolo
		{
			get { return _IdPartcipanteRuolo; }
			set {
				if (IdPartcipanteRuolo != value)
				{
					_IdPartcipanteRuolo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_FILIERA
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT CodFiliera
		{
			get { return _CodFiliera; }
			set {
				if (CodFiliera != value)
				{
					_CodFiliera = value;
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
		/// Corrisponde al campo:OPERATORE_INSERIMENTO
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT OperatoreInserimento
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
		/// Corrisponde al campo:DATA_MODIFICA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataModifica
		{
			get { return _DataModifica; }
			set {
				if (DataModifica != value)
				{
					_DataModifica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RUOLO_OPERATIVO
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT RuoloOperativo
		{
			get { return _RuoloOperativo; }
			set {
				if (RuoloOperativo != value)
				{
					_RuoloOperativo = value;
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
		/// Corrisponde al campo:ID_PROGETTO_PIF
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProgettoPif
		{
			get { return _IdProgettoPif; }
			set {
				if (IdProgettoPif != value)
				{
					_IdProgettoPif = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SISTEMA_DI_QUALITA
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT SistemaDiQualita
		{
			get { return _SistemaDiQualita; }
			set {
				if (SistemaDiQualita != value)
				{
					_SistemaDiQualita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_SISTEMA_QUALITA
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT CodSistemaQualita
		{
			get { return _CodSistemaQualita; }
			set {
				if (CodSistemaQualita != value)
				{
					_CodSistemaQualita = value;
					SetDirtyFlag();
				}
			}
		}



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
<PARTECIPANTE_RUOLO>
  <ViewName>vPARTECIPANTE_RUOLO</ViewName>
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
    <Find OrderBy="ORDER BY ">
      <CUAA>Equal</CUAA>
      <ID_PROGETTO_PIF>Equal</ID_PROGETTO_PIF>
    </Find>
  </Finds>
  <Filters>
    <FiltroSitra>
      <COD_RUOLO_SITRA>Equal</COD_RUOLO_SITRA>
    </FiltroSitra>
    <FiltroRuoloOperativo>
      <COD_RUOLO_PARTECIPANTE>Equal</COD_RUOLO_PARTECIPANTE>
    </FiltroRuoloOperativo>
    <FiltroQualita>
      <COD_SISTEMA_QUALITA>Equal</COD_SISTEMA_QUALITA>
    </FiltroQualita>
  </Filters>
  <externalFields />
  <AddedFkFields />
</PARTECIPANTE_RUOLO>
*/