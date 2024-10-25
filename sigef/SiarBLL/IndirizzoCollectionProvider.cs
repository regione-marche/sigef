using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for IndirizzoCollectionProvider:IIndirizzoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class IndirizzoCollectionProvider : IIndirizzoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di Indirizzo
		protected IndirizzoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public IndirizzoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new IndirizzoCollection(this);
		}

		//Costruttore 2: popola la collection
		public IndirizzoCollectionProvider(IntNT IdindirizzoEqualThis, IntNT IdcomuneEqualThis, StringNT ViaLikeThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdindirizzoEqualThis, IdcomuneEqualThis, ViaLikeThis);
		}

		//Costruttore3: ha in input indirizzoCollectionObj - non popola la collection
		public IndirizzoCollectionProvider(IndirizzoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public IndirizzoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new IndirizzoCollection(this);
		}

		//Get e Set
		public IndirizzoCollection CollectionObj
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
		public int SaveCollection(IndirizzoCollection collectionObj)
		{
			return IndirizzoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(Indirizzo indirizzoObj)
		{
			return IndirizzoDAL.Save(_dbProviderObj, indirizzoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(IndirizzoCollection collectionObj)
		{
			return IndirizzoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(Indirizzo indirizzoObj)
		{
			return IndirizzoDAL.Delete(_dbProviderObj, indirizzoObj);
		}

		//getById
		public Indirizzo GetById(IntNT IdIndirizzoValue)
		{
			Indirizzo IndirizzoTemp = IndirizzoDAL.GetById(_dbProviderObj, IdIndirizzoValue);
			if (IndirizzoTemp!=null) IndirizzoTemp.Provider = this;
			return IndirizzoTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Find: popola la collection
		public IndirizzoCollection Find(IntNT IdindirizzoEqualThis, IntNT IdcomuneEqualThis, StringNT ViaLikeThis)
		{
			IndirizzoCollection IndirizzoCollectionTemp = IndirizzoDAL.Find(_dbProviderObj, IdindirizzoEqualThis, IdcomuneEqualThis, ViaLikeThis);
			IndirizzoCollectionTemp.Provider = this;
			return IndirizzoCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<INDIRIZZO>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>True</chkDataModifica>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds>
    <Find>
      <ID_INDIRIZZO>Equal</ID_INDIRIZZO>
      <ID_COMUNE>Equal</ID_COMUNE>
      <VIA>Like</VIA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</INDIRIZZO>
*/