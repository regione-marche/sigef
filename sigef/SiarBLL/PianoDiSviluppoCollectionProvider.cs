using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for PianoDiSviluppoCollectionProvider:IPianoDiSviluppoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class PianoDiSviluppoCollectionProvider : IPianoDiSviluppoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di PianoDiSviluppo
		protected PianoDiSviluppoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public PianoDiSviluppoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new PianoDiSviluppoCollection(this);
		}

		//Costruttore 2: popola la collection
		public PianoDiSviluppoCollectionProvider(IntNT IdpianoEqualThis, IntNT AnnoEqualThis, IntNT IdprogettoEqualThis, 
IntNT IdimpresaEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdpianoEqualThis, AnnoEqualThis, IdprogettoEqualThis, 
IdimpresaEqualThis);
		}

		//Costruttore3: ha in input pianodisviluppoCollectionObj - non popola la collection
		public PianoDiSviluppoCollectionProvider(PianoDiSviluppoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public PianoDiSviluppoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new PianoDiSviluppoCollection(this);
		}

		//Get e Set
		public PianoDiSviluppoCollection CollectionObj
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
		public int SaveCollection(PianoDiSviluppoCollection collectionObj)
		{
			return PianoDiSviluppoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(PianoDiSviluppo pianodisviluppoObj)
		{
			return PianoDiSviluppoDAL.Save(_dbProviderObj, pianodisviluppoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(PianoDiSviluppoCollection collectionObj)
		{
			return PianoDiSviluppoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(PianoDiSviluppo pianodisviluppoObj)
		{
			return PianoDiSviluppoDAL.Delete(_dbProviderObj, pianodisviluppoObj);
		}

		//getById
		public PianoDiSviluppo GetById(IntNT IdPianoValue)
		{
			PianoDiSviluppo PianoDiSviluppoTemp = PianoDiSviluppoDAL.GetById(_dbProviderObj, IdPianoValue);
			if (PianoDiSviluppoTemp!=null) PianoDiSviluppoTemp.Provider = this;
			return PianoDiSviluppoTemp;
		}

		//Select: popola la collection
		public PianoDiSviluppoCollection Select(IntNT IdpianoEqualThis, IntNT AnnoEqualThis, IntNT IdimpresaEqualThis, 
IntNT IdprogettoEqualThis, DecimalNT CostoinvestimentoEqualThis, DecimalNT MezzipropriEqualThis, 
DecimalNT RisorseterziEqualThis, DecimalNT ContributipubbliciEqualThis, DecimalNT SpesegestioneEqualThis, 
DecimalNT RimborsodebitoEqualThis, DecimalNT EntratagestioneEqualThis, DecimalNT AltrecopertureEqualThis)
		{
			PianoDiSviluppoCollection PianoDiSviluppoCollectionTemp = PianoDiSviluppoDAL.Select(_dbProviderObj, IdpianoEqualThis, AnnoEqualThis, IdimpresaEqualThis, 
IdprogettoEqualThis, CostoinvestimentoEqualThis, MezzipropriEqualThis, 
RisorseterziEqualThis, ContributipubbliciEqualThis, SpesegestioneEqualThis, 
RimborsodebitoEqualThis, EntratagestioneEqualThis, AltrecopertureEqualThis);
			PianoDiSviluppoCollectionTemp.Provider = this;
			return PianoDiSviluppoCollectionTemp;
		}

		//Find: popola la collection
		public PianoDiSviluppoCollection Find(IntNT IdpianoEqualThis, IntNT AnnoEqualThis, IntNT IdprogettoEqualThis, 
IntNT IdimpresaEqualThis)
		{
			PianoDiSviluppoCollection PianoDiSviluppoCollectionTemp = PianoDiSviluppoDAL.Find(_dbProviderObj, IdpianoEqualThis, AnnoEqualThis, IdprogettoEqualThis, 
IdimpresaEqualThis);
			PianoDiSviluppoCollectionTemp.Provider = this;
			return PianoDiSviluppoCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<PIANO_DI_SVILUPPO>
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
      <ID_PIANO>Equal</ID_PIANO>
      <ANNO>Equal</ANNO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
    </Find>
  </Finds>
  <Filters>
    <FiltroAttuale>
      <ID_PROGETTO>IsNull</ID_PROGETTO>
    </FiltroAttuale>
  </Filters>
  <externalFields />
  <AddedFkFields />
</PIANO_DI_SVILUPPO>
*/