using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per Note
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface INoteProvider
	{
		int Save(Note NoteObj);
		int SaveCollection(NoteCollection collectionObj);
		int Delete(Note NoteObj);
		int DeleteCollection(NoteCollection collectionObj);
	}
	/// <summary>
	/// Summary description for Note
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class Note: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.StringNT _Testo;
		[NonSerialized] private INoteProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public INoteProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public Note()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Id
		{
			get { return _Id; }
			set {
				if (Id != value)
				{
					_Id = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TESTO
		/// Tipo sul db:NVARCHAR
		/// </summary>
		public NullTypes.StringNT Testo
		{
			get { return _Testo; }
			set {
				if (Testo != value)
				{
					_Testo = value;
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
<NOTE>
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
      <ID>Equal</ID>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</NOTE>
*/