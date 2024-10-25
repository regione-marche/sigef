using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per DichiarazioniXProgetto
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IDichiarazioniXProgettoProvider
	{
		int Save(DichiarazioniXProgetto DichiarazioniXProgettoObj);
		int SaveCollection(DichiarazioniXProgettoCollection collectionObj);
		int Delete(DichiarazioniXProgetto DichiarazioniXProgettoObj);
		int DeleteCollection(DichiarazioniXProgettoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for DichiarazioniXProgetto
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class DichiarazioniXProgetto: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdDichiarazione;
		private NullTypes.IntNT _IdProgetto;
		[NonSerialized] private IDichiarazioniXProgettoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IDichiarazioniXProgettoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public DichiarazioniXProgetto()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_DICHIARAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDichiarazione
		{
			get { return _IdDichiarazione; }
			set {
				if (IdDichiarazione != value)
				{
					_IdDichiarazione = value;
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
<DICHIARAZIONI_X_PROGETTO>
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
      <ID_DICHIARAZIONE>Equal</ID_DICHIARAZIONE>
      <ID_PROGETTO>Equal</ID_PROGETTO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</DICHIARAZIONI_X_PROGETTO>
*/