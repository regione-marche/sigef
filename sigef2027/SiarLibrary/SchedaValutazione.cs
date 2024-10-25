using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per SchedaValutazione
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ISchedaValutazioneProvider
	{
		int Save(SchedaValutazione SchedaValutazioneObj);
		int SaveCollection(SchedaValutazioneCollection collectionObj);
		int Delete(SchedaValutazione SchedaValutazioneObj);
		int DeleteCollection(SchedaValutazioneCollection collectionObj);
	}
	/// <summary>
	/// Summary description for SchedaValutazione
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class SchedaValutazione: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdSchedaValutazione;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.BoolNT _FlagTemplate;
		private NullTypes.DecimalNT _ValoreMax;
		private NullTypes.DecimalNT _ValoreMin;
		private NullTypes.StringNT _ParoleChiave;
		private NullTypes.DatetimeNT _DataModifica;
		[NonSerialized] private ISchedaValutazioneProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ISchedaValutazioneProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public SchedaValutazione()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_SCHEDA_VALUTAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdSchedaValutazione
		{
			get { return _IdSchedaValutazione; }
			set {
				if (IdSchedaValutazione != value)
				{
					_IdSchedaValutazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(255)
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
		/// Corrisponde al campo:FLAG_TEMPLATE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT FlagTemplate
		{
			get { return _FlagTemplate; }
			set {
				if (FlagTemplate != value)
				{
					_FlagTemplate = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VALORE_MAX
		/// Tipo sul db:DECIMAL(10,2)
		/// </summary>
		public NullTypes.DecimalNT ValoreMax
		{
			get { return _ValoreMax; }
			set {
				if (ValoreMax != value)
				{
					_ValoreMax = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VALORE_MIN
		/// Tipo sul db:DECIMAL(10,2)
		/// </summary>
		public NullTypes.DecimalNT ValoreMin
		{
			get { return _ValoreMin; }
			set {
				if (ValoreMin != value)
				{
					_ValoreMin = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PAROLE_CHIAVE
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT ParoleChiave
		{
			get { return _ParoleChiave; }
			set {
				if (ParoleChiave != value)
				{
					_ParoleChiave = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_MODIFICA
		/// Tipo sul db:DATETIME
		/// Default:(getdate())
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
<SCHEDA_VALUTAZIONE>
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
    <Find OrderBy="ORDER BY DATA_MODIFICA DESC">
      <ID_SCHEDA_VALUTAZIONE>Equal</ID_SCHEDA_VALUTAZIONE>
      <FLAG_TEMPLATE>Equal</FLAG_TEMPLATE>
      <DESCRIZIONE>Like</DESCRIZIONE>
      <PAROLE_CHIAVE>Like</PAROLE_CHIAVE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</SCHEDA_VALUTAZIONE>
*/