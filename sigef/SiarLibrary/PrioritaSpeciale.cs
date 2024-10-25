using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per PrioritaSpeciale
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IPrioritaSpecialeProvider
	{
		int Save(PrioritaSpeciale PrioritaSpecialeObj);
		int SaveCollection(PrioritaSpecialeCollection collectionObj);
		int Delete(PrioritaSpeciale PrioritaSpecialeObj);
		int DeleteCollection(PrioritaSpecialeCollection collectionObj);
	}
	/// <summary>
	/// Summary description for PrioritaSpeciale
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class PrioritaSpeciale: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdSchedaValutazione;
		private NullTypes.IntNT _IdPriorita;
		private NullTypes.IntNT _IdPrioritaSelezionata;
		private NullTypes.BoolNT _IsMax;
		[NonSerialized] private IPrioritaSpecialeProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IPrioritaSpecialeProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public PrioritaSpeciale()
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
		/// Corrisponde al campo:ID_PRIORITA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdPriorita
		{
			get { return _IdPriorita; }
			set {
				if (IdPriorita != value)
				{
					_IdPriorita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_PRIORITA_SELEZIONATA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdPrioritaSelezionata
		{
			get { return _IdPrioritaSelezionata; }
			set {
				if (IdPrioritaSelezionata != value)
				{
					_IdPrioritaSelezionata = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IS_MAX
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT IsMax
		{
			get { return _IsMax; }
			set {
				if (IsMax != value)
				{
					_IsMax = value;
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
<PRIORITA_SPECIALE>
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
    <Find>
      <ID_SCHEDA_VALUTAZIONE>Equal</ID_SCHEDA_VALUTAZIONE>
      <ID_PRIORITA>Equal</ID_PRIORITA>
      <ID_PRIORITA_SELEZIONATA>Equal</ID_PRIORITA_SELEZIONATA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PRIORITA_SPECIALE>
*/