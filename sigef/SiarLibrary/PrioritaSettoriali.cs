using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per PrioritaSettoriali
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IPrioritaSettorialiProvider
	{
		int Save(PrioritaSettoriali PrioritaSettorialiObj);
		int SaveCollection(PrioritaSettorialiCollection collectionObj);
		int Delete(PrioritaSettoriali PrioritaSettorialiObj);
		int DeleteCollection(PrioritaSettorialiCollection collectionObj);
	}
	/// <summary>
	/// Summary description for PrioritaSettoriali
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class PrioritaSettoriali: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdPrioritaSettoriale;
		private NullTypes.StringNT _Descrizione;
		[NonSerialized] private IPrioritaSettorialiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IPrioritaSettorialiProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public PrioritaSettoriali()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_PRIORITA_SETTORIALE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdPrioritaSettoriale
		{
			get { return _IdPrioritaSettoriale; }
			set {
				if (IdPrioritaSettoriale != value)
				{
					_IdPrioritaSettoriale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(1000)
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
<PRIORITA_SETTORIALI>
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
    <Find OrderBy="ORDER BY DESCRIZIONE">
      <ID_PRIORITA_SETTORIALE>Equal</ID_PRIORITA_SETTORIALE>
      <DESCRIZIONE>Like</DESCRIZIONE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PRIORITA_SETTORIALI>
*/