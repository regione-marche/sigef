using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for SettoriProduttiviCollectionProvider:ISettoriProduttiviProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class SettoriProduttiviCollectionProvider : ISettoriProduttiviProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di SettoriProduttivi
		protected SettoriProduttiviCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public SettoriProduttiviCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new SettoriProduttiviCollection(this);
		}

		//Costruttore 2: popola la collection
		public SettoriProduttiviCollectionProvider(IntNT IdsettoreproduttivoEqualThis, StringNT DescrizioneLikeThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdsettoreproduttivoEqualThis, DescrizioneLikeThis);
		}

		//Costruttore3: ha in input settoriproduttiviCollectionObj - non popola la collection
		public SettoriProduttiviCollectionProvider(SettoriProduttiviCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public SettoriProduttiviCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new SettoriProduttiviCollection(this);
		}

		//Get e Set
		public SettoriProduttiviCollection CollectionObj
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
		public int SaveCollection(SettoriProduttiviCollection collectionObj)
		{
			return SettoriProduttiviDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(SettoriProduttivi settoriproduttiviObj)
		{
			return SettoriProduttiviDAL.Save(_dbProviderObj, settoriproduttiviObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(SettoriProduttiviCollection collectionObj)
		{
			return SettoriProduttiviDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(SettoriProduttivi settoriproduttiviObj)
		{
			return SettoriProduttiviDAL.Delete(_dbProviderObj, settoriproduttiviObj);
		}

		//getById
		public SettoriProduttivi GetById(IntNT IdSettoreProduttivoValue)
		{
			SettoriProduttivi SettoriProduttiviTemp = SettoriProduttiviDAL.GetById(_dbProviderObj, IdSettoreProduttivoValue);
			if (SettoriProduttiviTemp!=null) SettoriProduttiviTemp.Provider = this;
			return SettoriProduttiviTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public SettoriProduttiviCollection Select(IntNT IdsettoreproduttivoEqualThis, StringNT DescrizioneEqualThis)
		{
			SettoriProduttiviCollection SettoriProduttiviCollectionTemp = SettoriProduttiviDAL.Select(_dbProviderObj, IdsettoreproduttivoEqualThis, DescrizioneEqualThis);
			SettoriProduttiviCollectionTemp.Provider = this;
			return SettoriProduttiviCollectionTemp;
		}

		//Find: popola la collection
		public SettoriProduttiviCollection Find(IntNT IdsettoreproduttivoEqualThis, StringNT DescrizioneLikeThis)
		{
			SettoriProduttiviCollection SettoriProduttiviCollectionTemp = SettoriProduttiviDAL.Find(_dbProviderObj, IdsettoreproduttivoEqualThis, DescrizioneLikeThis);
			SettoriProduttiviCollectionTemp.Provider = this;
			return SettoriProduttiviCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<SETTORI_PRODUTTIVI>
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
      <ID_SETTORE_PRODUTTIVO>Equal</ID_SETTORE_PRODUTTIVO>
      <DESCRIZIONE>Like</DESCRIZIONE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</SETTORI_PRODUTTIVI>
*/