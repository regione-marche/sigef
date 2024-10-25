using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for ProfiloXFunzioniCollectionProvider:IProfiloXFunzioniProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class ProfiloXFunzioniCollectionProvider : IProfiloXFunzioniProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ProfiloXFunzioni
		protected ProfiloXFunzioniCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ProfiloXFunzioniCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ProfiloXFunzioniCollection(this);
		}

		//Costruttore 2: popola la collection
		public ProfiloXFunzioniCollectionProvider(IntNT IdprofiloEqualThis, IntNT CodfunzioneEqualThis, BoolNT FlagmenuEqualThis, 
StringNT DescmenuEqualThis, IntNT LivelloEqualThis, IntNT PadreEqualThis, 
IntNT OrdineEqualThis, StringNT CodtipoenteEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdprofiloEqualThis, CodfunzioneEqualThis, FlagmenuEqualThis, 
DescmenuEqualThis, LivelloEqualThis, PadreEqualThis, 
OrdineEqualThis, CodtipoenteEqualThis);
		}

		//Costruttore3: ha in input profiloxfunzioniCollectionObj - non popola la collection
		public ProfiloXFunzioniCollectionProvider(ProfiloXFunzioniCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ProfiloXFunzioniCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ProfiloXFunzioniCollection(this);
		}

		//Get e Set
		public ProfiloXFunzioniCollection CollectionObj
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
		public int SaveCollection(ProfiloXFunzioniCollection collectionObj)
		{
			return ProfiloXFunzioniDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ProfiloXFunzioni profiloxfunzioniObj)
		{
			return ProfiloXFunzioniDAL.Save(_dbProviderObj, profiloxfunzioniObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ProfiloXFunzioniCollection collectionObj)
		{
			return ProfiloXFunzioniDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ProfiloXFunzioni profiloxfunzioniObj)
		{
			return ProfiloXFunzioniDAL.Delete(_dbProviderObj, profiloxfunzioniObj);
		}

		//getById
		public ProfiloXFunzioni GetById(IntNT IdProfiloValue, IntNT CodFunzioneValue)
		{
			ProfiloXFunzioni ProfiloXFunzioniTemp = ProfiloXFunzioniDAL.GetById(_dbProviderObj, IdProfiloValue, CodFunzioneValue);
			if (ProfiloXFunzioniTemp!=null) ProfiloXFunzioniTemp.Provider = this;
			return ProfiloXFunzioniTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ProfiloXFunzioniCollection Select(IntNT IdprofiloEqualThis, IntNT CodfunzioneEqualThis, BoolNT ModificaEqualThis)
		{
			ProfiloXFunzioniCollection ProfiloXFunzioniCollectionTemp = ProfiloXFunzioniDAL.Select(_dbProviderObj, IdprofiloEqualThis, CodfunzioneEqualThis, ModificaEqualThis);
			ProfiloXFunzioniCollectionTemp.Provider = this;
			return ProfiloXFunzioniCollectionTemp;
		}

		//Find: popola la collection
		public ProfiloXFunzioniCollection Find(IntNT IdprofiloEqualThis, IntNT CodfunzioneEqualThis, BoolNT FlagmenuEqualThis, 
StringNT DescmenuEqualThis, IntNT LivelloEqualThis, IntNT PadreEqualThis, 
IntNT OrdineEqualThis, StringNT CodtipoenteEqualThis)
		{
			ProfiloXFunzioniCollection ProfiloXFunzioniCollectionTemp = ProfiloXFunzioniDAL.Find(_dbProviderObj, IdprofiloEqualThis, CodfunzioneEqualThis, FlagmenuEqualThis, 
DescmenuEqualThis, LivelloEqualThis, PadreEqualThis, 
OrdineEqualThis, CodtipoenteEqualThis);
			ProfiloXFunzioniCollectionTemp.Provider = this;
			return ProfiloXFunzioniCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<PROFILO_X_FUNZIONI>
  <ViewName>vPROFILO_X_FUNZIONI</ViewName>
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
      <ID_PROFILO>Equal</ID_PROFILO>
      <COD_FUNZIONE>Equal</COD_FUNZIONE>
      <FLAG_MENU>Equal</FLAG_MENU>
      <DESC_MENU>Equal</DESC_MENU>
      <LIVELLO>Equal</LIVELLO>
      <PADRE>Equal</PADRE>
      <ORDINE>Equal</ORDINE>
      <COD_TIPO_ENTE>Equal</COD_TIPO_ENTE>
    </Find>
  </Finds>
  <Filters>
    <FiltroModifica>
      <MODIFICA>Equal</MODIFICA>
    </FiltroModifica>
  </Filters>
  <externalFields />
  <AddedFkFields />
</PROFILO_X_FUNZIONI>
*/