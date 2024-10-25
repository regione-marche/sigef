using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for GraduatoriaProgettiFinanziabilitaCollectionProvider:IGraduatoriaProgettiFinanziabilitaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class GraduatoriaProgettiFinanziabilitaCollectionProvider : IGraduatoriaProgettiFinanziabilitaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di GraduatoriaProgettiFinanziabilita
		protected GraduatoriaProgettiFinanziabilitaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public GraduatoriaProgettiFinanziabilitaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new GraduatoriaProgettiFinanziabilitaCollection(this);
		}

		//Costruttore 2: popola la collection
		public GraduatoriaProgettiFinanziabilitaCollectionProvider(IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis, IntNT IdprogintegratoEqualThis, 
StringNT MisuraEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdbandoEqualThis, IdprogettoEqualThis, IdprogintegratoEqualThis, 
MisuraEqualThis);
		}

		//Costruttore3: ha in input graduatoriaprogettifinanziabilitaCollectionObj - non popola la collection
		public GraduatoriaProgettiFinanziabilitaCollectionProvider(GraduatoriaProgettiFinanziabilitaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public GraduatoriaProgettiFinanziabilitaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new GraduatoriaProgettiFinanziabilitaCollection(this);
		}

		//Get e Set
		public GraduatoriaProgettiFinanziabilitaCollection CollectionObj
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
		public int SaveCollection(GraduatoriaProgettiFinanziabilitaCollection collectionObj)
		{
			return GraduatoriaProgettiFinanziabilitaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(GraduatoriaProgettiFinanziabilita graduatoriaprogettifinanziabilitaObj)
		{
			return GraduatoriaProgettiFinanziabilitaDAL.Save(_dbProviderObj, graduatoriaprogettifinanziabilitaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(GraduatoriaProgettiFinanziabilitaCollection collectionObj)
		{
			return GraduatoriaProgettiFinanziabilitaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(GraduatoriaProgettiFinanziabilita graduatoriaprogettifinanziabilitaObj)
		{
			return GraduatoriaProgettiFinanziabilitaDAL.Delete(_dbProviderObj, graduatoriaprogettifinanziabilitaObj);
		}

		//getById
		public GraduatoriaProgettiFinanziabilita GetById(IntNT IdBandoValue, IntNT IdProgettoValue)
		{
			GraduatoriaProgettiFinanziabilita GraduatoriaProgettiFinanziabilitaTemp = GraduatoriaProgettiFinanziabilitaDAL.GetById(_dbProviderObj, IdBandoValue, IdProgettoValue);
			if (GraduatoriaProgettiFinanziabilitaTemp!=null) GraduatoriaProgettiFinanziabilitaTemp.Provider = this;
			return GraduatoriaProgettiFinanziabilitaTemp;
		}

		//Select: popola la collection
		public GraduatoriaProgettiFinanziabilitaCollection Select(IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis, IntNT IdprogintegratoEqualThis, 
DecimalNT CostototaleEqualThis, DecimalNT ContributodimisuraEqualThis, DecimalNT ContributorimanenteEqualThis, 
StringNT MisuraEqualThis, BoolNT MisuraprevalenteEqualThis)
		{
			GraduatoriaProgettiFinanziabilitaCollection GraduatoriaProgettiFinanziabilitaCollectionTemp = GraduatoriaProgettiFinanziabilitaDAL.Select(_dbProviderObj, IdbandoEqualThis, IdprogettoEqualThis, IdprogintegratoEqualThis, 
CostototaleEqualThis, ContributodimisuraEqualThis, ContributorimanenteEqualThis, 
MisuraEqualThis, MisuraprevalenteEqualThis);
			GraduatoriaProgettiFinanziabilitaCollectionTemp.Provider = this;
			return GraduatoriaProgettiFinanziabilitaCollectionTemp;
		}

		//Find: popola la collection
		public GraduatoriaProgettiFinanziabilitaCollection Find(IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis, IntNT IdprogintegratoEqualThis, 
StringNT MisuraEqualThis)
		{
			GraduatoriaProgettiFinanziabilitaCollection GraduatoriaProgettiFinanziabilitaCollectionTemp = GraduatoriaProgettiFinanziabilitaDAL.Find(_dbProviderObj, IdbandoEqualThis, IdprogettoEqualThis, IdprogintegratoEqualThis, 
MisuraEqualThis);
			GraduatoriaProgettiFinanziabilitaCollectionTemp.Provider = this;
			return GraduatoriaProgettiFinanziabilitaCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<GRADUATORIA_PROGETTI_FINANZIABILITA>
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
    <Find OrderBy="ORDER BY MISURA_PREVALENTE DESC, MISURA">
      <ID_BANDO>Equal</ID_BANDO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_PROG_INTEGRATO>Equal</ID_PROG_INTEGRATO>
      <MISURA>Equal</MISURA>
    </Find>
  </Finds>
  <Filters>
    <FiltroMisura>
      <MISURA>Equal</MISURA>
    </FiltroMisura>
  </Filters>
  <externalFields />
  <AddedFkFields />
</GRADUATORIA_PROGETTI_FINANZIABILITA>
*/