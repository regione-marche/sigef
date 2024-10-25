using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per PartecipantiXFiliera
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IPartecipantiXFilieraProvider
	{
		int Save(PartecipantiXFiliera PartecipantiXFilieraObj);
		int SaveCollection(PartecipantiXFilieraCollection collectionObj);
		int Delete(PartecipantiXFiliera PartecipantiXFilieraObj);
		int DeleteCollection(PartecipantiXFilieraCollection collectionObj);
	}
	/// <summary>
	/// Summary description for PartecipantiXFiliera
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class PartecipantiXFiliera: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdPartecipante;
		private NullTypes.StringNT _CodFiliera;
		private NullTypes.StringNT _Cuaa;
		private NullTypes.IntNT _IdProgettoValidato;
		private NullTypes.StringNT _CodRuoloSitra;
		private NullTypes.BoolNT _Ammesso;
		private NullTypes.DatetimeNT _DataValidazione;
		private NullTypes.StringNT _CfOperatore;
		[NonSerialized] private IPartecipantiXFilieraProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IPartecipantiXFilieraProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public PartecipantiXFiliera()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_PARTECIPANTE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdPartecipante
		{
			get { return _IdPartecipante; }
			set {
				if (IdPartecipante != value)
				{
					_IdPartecipante = value;
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
		/// Corrisponde al campo:ID_PROGETTO_VALIDATO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProgettoValidato
		{
			get { return _IdProgettoValidato; }
			set {
				if (IdProgettoValidato != value)
				{
					_IdProgettoValidato = value;
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

		/// <summary>
		/// Corrisponde al campo:DATA_VALIDAZIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataValidazione
		{
			get { return _DataValidazione; }
			set {
				if (DataValidazione != value)
				{
					_DataValidazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_OPERATORE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CfOperatore
		{
			get { return _CfOperatore; }
			set {
				if (CfOperatore != value)
				{
					_CfOperatore = value;
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
<PARTECIPANTI_X_FILIERA>
  <ViewName>
  </ViewName>
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
      <ID_PARTECIPANTE>Equal</ID_PARTECIPANTE>
      <COD_FILIERA>Equal</COD_FILIERA>
      <CUAA>Equal</CUAA>
      <ID_PROGETTO_VALIDATO>Equal</ID_PROGETTO_VALIDATO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PARTECIPANTI_X_FILIERA>
*/