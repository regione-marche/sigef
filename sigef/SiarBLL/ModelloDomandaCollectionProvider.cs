using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for ModelloDomandaCollectionProvider:IModelloDomandaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class ModelloDomandaCollectionProvider : IModelloDomandaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ModelloDomanda
		protected ModelloDomandaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ModelloDomandaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ModelloDomandaCollection(this);
		}

		//Costruttore 2: popola la collection
		public ModelloDomandaCollectionProvider(IntNT IddomandaEqualThis, IntNT IdbandoEqualThis, BoolNT DefinitivoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IddomandaEqualThis, IdbandoEqualThis, DefinitivoEqualThis);
		}

		//Costruttore3: ha in input modellodomandaCollectionObj - non popola la collection
		public ModelloDomandaCollectionProvider(ModelloDomandaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ModelloDomandaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ModelloDomandaCollection(this);
		}

		//Get e Set
		public ModelloDomandaCollection CollectionObj
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
		public int SaveCollection(ModelloDomandaCollection collectionObj)
		{
			return ModelloDomandaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ModelloDomanda modellodomandaObj)
		{
			return ModelloDomandaDAL.Save(_dbProviderObj, modellodomandaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ModelloDomandaCollection collectionObj)
		{
			return ModelloDomandaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ModelloDomanda modellodomandaObj)
		{
			return ModelloDomandaDAL.Delete(_dbProviderObj, modellodomandaObj);
		}

		//getById
		public ModelloDomanda GetById(IntNT IdDomandaValue)
		{
			ModelloDomanda ModelloDomandaTemp = ModelloDomandaDAL.GetById(_dbProviderObj, IdDomandaValue);
			if (ModelloDomandaTemp!=null) ModelloDomandaTemp.Provider = this;
			return ModelloDomandaTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ModelloDomandaCollection Select(IntNT IddomandaEqualThis, IntNT IdbandoEqualThis, BoolNT DefinitivoEqualThis, 
StringNT OperatoreEqualThis, StringNT DenominazioneEqualThis, StringNT DescrizioneEqualThis)
		{
			ModelloDomandaCollection ModelloDomandaCollectionTemp = ModelloDomandaDAL.Select(_dbProviderObj, IddomandaEqualThis, IdbandoEqualThis, DefinitivoEqualThis, 
OperatoreEqualThis, DenominazioneEqualThis, DescrizioneEqualThis);
			ModelloDomandaCollectionTemp.Provider = this;
			return ModelloDomandaCollectionTemp;
		}

		//Find: popola la collection
		public ModelloDomandaCollection Find(IntNT IddomandaEqualThis, IntNT IdbandoEqualThis, BoolNT DefinitivoEqualThis)
		{
			ModelloDomandaCollection ModelloDomandaCollectionTemp = ModelloDomandaDAL.Find(_dbProviderObj, IddomandaEqualThis, IdbandoEqualThis, DefinitivoEqualThis);
			ModelloDomandaCollectionTemp.Provider = this;
			return ModelloDomandaCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<MODELLO_DOMANDA>
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
      <ID_DOMANDA>Equal</ID_DOMANDA>
      <ID_BANDO>Equal</ID_BANDO>
      <DEFINITIVO>Equal</DEFINITIVO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</MODELLO_DOMANDA>
*/