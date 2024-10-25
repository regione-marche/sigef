using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for NoteCollectionProvider:INoteProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class NoteCollectionProvider : INoteProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di Note
		protected NoteCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public NoteCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new NoteCollection(this);
		}

		//Costruttore 2: popola la collection
		public NoteCollectionProvider(IntNT IdEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdEqualThis);
		}

		//Costruttore3: ha in input noteCollectionObj - non popola la collection
		public NoteCollectionProvider(NoteCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public NoteCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new NoteCollection(this);
		}

		//Get e Set
		public NoteCollection CollectionObj
		{
			get
			{
				return _CollectionObj;
			}
			set
			{
				_CollectionObj = value;
			}
		}

		public DbProvider DbProviderObj
		{
			get
			{
				return _dbProviderObj;
			}
			set
			{
				_dbProviderObj = value;
			}
		}

		//Operazioni

		//Save1: registra l'intera collection
		public int SaveCollection()
		{
			return SaveCollection(_CollectionObj);
		}

		//Save2: registra una collection
		public int SaveCollection(NoteCollection collectionObj)
		{
			return NoteDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(Note noteObj)
		{
			return NoteDAL.Save(_dbProviderObj, noteObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(NoteCollection collectionObj)
		{
			return NoteDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(Note noteObj)
		{
			return NoteDAL.Delete(_dbProviderObj, noteObj);
		}

		//getById
		public Note GetById(IntNT IdValue)
		{
			Note NoteTemp = NoteDAL.GetById(_dbProviderObj, IdValue);
			if (NoteTemp!=null) NoteTemp.Provider = this;
			return NoteTemp;
		}

		//Select: popola la collection
		public NoteCollection Select(IntNT IdEqualThis, StringNT TestoEqualThis)
		{
			NoteCollection NoteCollectionTemp = NoteDAL.Select(_dbProviderObj, IdEqualThis, TestoEqualThis);
			NoteCollectionTemp.Provider = this;
			return NoteCollectionTemp;
		}

		//Find: popola la collection
		public NoteCollection Find(IntNT IdEqualThis)
		{
			NoteCollection NoteCollectionTemp = NoteDAL.Find(_dbProviderObj, IdEqualThis);
			NoteCollectionTemp.Provider = this;
			return NoteCollectionTemp;
		}


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