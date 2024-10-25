using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for SchedaValutazioneCollectionProvider:ISchedaValutazioneProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class SchedaValutazioneCollectionProvider : ISchedaValutazioneProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di SchedaValutazione
		protected SchedaValutazioneCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public SchedaValutazioneCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new SchedaValutazioneCollection(this);
		}

		//Costruttore 2: popola la collection
		public SchedaValutazioneCollectionProvider(IntNT IdschedavalutazioneEqualThis, BoolNT FlagtemplateEqualThis, StringNT DescrizioneLikeThis, 
StringNT ParolechiaveLikeThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdschedavalutazioneEqualThis, FlagtemplateEqualThis, DescrizioneLikeThis, 
ParolechiaveLikeThis);
		}

		//Costruttore3: ha in input schedavalutazioneCollectionObj - non popola la collection
		public SchedaValutazioneCollectionProvider(SchedaValutazioneCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public SchedaValutazioneCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new SchedaValutazioneCollection(this);
		}

		//Get e Set
		public SchedaValutazioneCollection CollectionObj
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
		public int SaveCollection(SchedaValutazioneCollection collectionObj)
		{
			return SchedaValutazioneDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(SchedaValutazione schedavalutazioneObj)
		{
			return SchedaValutazioneDAL.Save(_dbProviderObj, schedavalutazioneObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(SchedaValutazioneCollection collectionObj)
		{
			return SchedaValutazioneDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(SchedaValutazione schedavalutazioneObj)
		{
			return SchedaValutazioneDAL.Delete(_dbProviderObj, schedavalutazioneObj);
		}

		//getById
		public SchedaValutazione GetById(IntNT IdSchedaValutazioneValue)
		{
			SchedaValutazione SchedaValutazioneTemp = SchedaValutazioneDAL.GetById(_dbProviderObj, IdSchedaValutazioneValue);
			if (SchedaValutazioneTemp!=null) SchedaValutazioneTemp.Provider = this;
			return SchedaValutazioneTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public SchedaValutazioneCollection Select(IntNT IdschedavalutazioneEqualThis, StringNT DescrizioneEqualThis, BoolNT FlagtemplateEqualThis, 
DecimalNT ValoremaxEqualThis, DecimalNT ValoreminEqualThis, StringNT ParolechiaveEqualThis, 
DatetimeNT DatamodificaEqualThis)
		{
			SchedaValutazioneCollection SchedaValutazioneCollectionTemp = SchedaValutazioneDAL.Select(_dbProviderObj, IdschedavalutazioneEqualThis, DescrizioneEqualThis, FlagtemplateEqualThis, 
ValoremaxEqualThis, ValoreminEqualThis, ParolechiaveEqualThis, 
DatamodificaEqualThis);
			SchedaValutazioneCollectionTemp.Provider = this;
			return SchedaValutazioneCollectionTemp;
		}

		//Find: popola la collection
		public SchedaValutazioneCollection Find(IntNT IdschedavalutazioneEqualThis, BoolNT FlagtemplateEqualThis, StringNT DescrizioneLikeThis, 
StringNT ParolechiaveLikeThis)
		{
			SchedaValutazioneCollection SchedaValutazioneCollectionTemp = SchedaValutazioneDAL.Find(_dbProviderObj, IdschedavalutazioneEqualThis, FlagtemplateEqualThis, DescrizioneLikeThis, 
ParolechiaveLikeThis);
			SchedaValutazioneCollectionTemp.Provider = this;
			return SchedaValutazioneCollectionTemp;
		}


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