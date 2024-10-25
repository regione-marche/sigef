using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for ContoCorrenteCollectionProvider:IContoCorrenteProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class ContoCorrenteCollectionProvider : IContoCorrenteProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ContoCorrente
		protected ContoCorrenteCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ContoCorrenteCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ContoCorrenteCollection(this);
		}

		//Costruttore 2: popola la collection
		public ContoCorrenteCollectionProvider(IntNT IdcontocorrenteEqualThis, IntNT IdimpresaEqualThis, IntNT IdpersonaEqualThis, 
DatetimeNT DatainiziovaliditaEqLessThanThis, DatetimeNT DatafinevaliditaEqGreaterThanThis, BoolNT DatafinevaliditaIsNull)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdcontocorrenteEqualThis, IdimpresaEqualThis, IdpersonaEqualThis, 
DatainiziovaliditaEqLessThanThis, DatafinevaliditaEqGreaterThanThis, DatafinevaliditaIsNull);
		}

		//Costruttore3: ha in input contocorrenteCollectionObj - non popola la collection
		public ContoCorrenteCollectionProvider(ContoCorrenteCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ContoCorrenteCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ContoCorrenteCollection(this);
		}

		//Get e Set
		public ContoCorrenteCollection CollectionObj
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
		public int SaveCollection(ContoCorrenteCollection collectionObj)
		{
			return ContoCorrenteDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ContoCorrente contocorrenteObj)
		{
			return ContoCorrenteDAL.Save(_dbProviderObj, contocorrenteObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ContoCorrenteCollection collectionObj)
		{
			return ContoCorrenteDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ContoCorrente contocorrenteObj)
		{
			return ContoCorrenteDAL.Delete(_dbProviderObj, contocorrenteObj);
		}

		//getById
		public ContoCorrente GetById(IntNT IdContoCorrenteValue)
		{
			ContoCorrente ContoCorrenteTemp = ContoCorrenteDAL.GetById(_dbProviderObj, IdContoCorrenteValue);
			if (ContoCorrenteTemp!=null) ContoCorrenteTemp.Provider = this;
			return ContoCorrenteTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ContoCorrenteCollection Select(IntNT IdcontocorrenteEqualThis, IntNT IdimpresaEqualThis, IntNT IdpersonaEqualThis, 
StringNT CodpaeseEqualThis, StringNT CineuroEqualThis, StringNT CinEqualThis, 
StringNT AbiEqualThis, StringNT CabEqualThis, StringNT NumeroEqualThis, 
StringNT NoteEqualThis, DatetimeNT DatainiziovaliditaEqualThis, DatetimeNT DatafinevaliditaEqualThis, 
StringNT IstitutoEqualThis, StringNT AgenziaEqualThis, IntNT IdcomuneEqualThis)
		{
			ContoCorrenteCollection ContoCorrenteCollectionTemp = ContoCorrenteDAL.Select(_dbProviderObj, IdcontocorrenteEqualThis, IdimpresaEqualThis, IdpersonaEqualThis, 
CodpaeseEqualThis, CineuroEqualThis, CinEqualThis, 
AbiEqualThis, CabEqualThis, NumeroEqualThis, 
NoteEqualThis, DatainiziovaliditaEqualThis, DatafinevaliditaEqualThis, 
IstitutoEqualThis, AgenziaEqualThis, IdcomuneEqualThis);
			ContoCorrenteCollectionTemp.Provider = this;
			return ContoCorrenteCollectionTemp;
		}

		//Find: popola la collection
		public ContoCorrenteCollection Find(IntNT IdcontocorrenteEqualThis, IntNT IdimpresaEqualThis, IntNT IdpersonaEqualThis, 
DatetimeNT DatainiziovaliditaEqLessThanThis, DatetimeNT DatafinevaliditaEqGreaterThanThis, BoolNT DatafinevaliditaIsNull)
		{
			ContoCorrenteCollection ContoCorrenteCollectionTemp = ContoCorrenteDAL.Find(_dbProviderObj, IdcontocorrenteEqualThis, IdimpresaEqualThis, IdpersonaEqualThis, 
DatainiziovaliditaEqLessThanThis, DatafinevaliditaEqGreaterThanThis, DatafinevaliditaIsNull);
			ContoCorrenteCollectionTemp.Provider = this;
			return ContoCorrenteCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<CONTO_CORRENTE>
  <ViewName>vCONTO_CORRENTE</ViewName>
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
    <Find OrderBy="ORDER BY DATA_INIZIO_VALIDITA DESC">
      <ID_CONTO_CORRENTE>Equal</ID_CONTO_CORRENTE>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <ID_PERSONA>Equal</ID_PERSONA>
      <DATA_INIZIO_VALIDITA>EqLessThan</DATA_INIZIO_VALIDITA>
      <DATA_FINE_VALIDITA>EqGreaterThan</DATA_FINE_VALIDITA>
      <DATA_FINE_VALIDITA>IsNull</DATA_FINE_VALIDITA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CONTO_CORRENTE>
*/