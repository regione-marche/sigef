using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for PianoDiSviluppoDomandaPagamentoCollectionProvider:IPianoDiSviluppoDomandaPagamentoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class PianoDiSviluppoDomandaPagamentoCollectionProvider : IPianoDiSviluppoDomandaPagamentoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di PianoDiSviluppoDomandaPagamento
		protected PianoDiSviluppoDomandaPagamentoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public PianoDiSviluppoDomandaPagamentoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new PianoDiSviluppoDomandaPagamentoCollection(this);
		}

		//Costruttore 2: popola la collection
		public PianoDiSviluppoDomandaPagamentoCollectionProvider(IntNT AnnoEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdprogettoEqualThis, 
IntNT IdimpresaEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(AnnoEqualThis, IddomandapagamentoEqualThis, IdprogettoEqualThis, 
IdimpresaEqualThis);
		}

		//Costruttore3: ha in input pianodisviluppodomandapagamentoCollectionObj - non popola la collection
		public PianoDiSviluppoDomandaPagamentoCollectionProvider(PianoDiSviluppoDomandaPagamentoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public PianoDiSviluppoDomandaPagamentoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new PianoDiSviluppoDomandaPagamentoCollection(this);
		}

		//Get e Set
		public PianoDiSviluppoDomandaPagamentoCollection CollectionObj
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
		public int SaveCollection(PianoDiSviluppoDomandaPagamentoCollection collectionObj)
		{
			return PianoDiSviluppoDomandaPagamentoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(PianoDiSviluppoDomandaPagamento pianodisviluppodomandapagamentoObj)
		{
			return PianoDiSviluppoDomandaPagamentoDAL.Save(_dbProviderObj, pianodisviluppodomandapagamentoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(PianoDiSviluppoDomandaPagamentoCollection collectionObj)
		{
			return PianoDiSviluppoDomandaPagamentoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(PianoDiSviluppoDomandaPagamento pianodisviluppodomandapagamentoObj)
		{
			return PianoDiSviluppoDomandaPagamentoDAL.Delete(_dbProviderObj, pianodisviluppodomandapagamentoObj);
		}

		//getById
		public PianoDiSviluppoDomandaPagamento GetById(IntNT IdPianoValue)
		{
			PianoDiSviluppoDomandaPagamento PianoDiSviluppoDomandaPagamentoTemp = PianoDiSviluppoDomandaPagamentoDAL.GetById(_dbProviderObj, IdPianoValue);
			if (PianoDiSviluppoDomandaPagamentoTemp!=null) PianoDiSviluppoDomandaPagamentoTemp.Provider = this;
			return PianoDiSviluppoDomandaPagamentoTemp;
		}

		//Select: popola la collection
		public PianoDiSviluppoDomandaPagamentoCollection Select(IntNT IdpianoEqualThis, IntNT AnnoEqualThis, IntNT IddomandapagamentoEqualThis, 
IntNT IdimpresaEqualThis, IntNT IdprogettoEqualThis, DecimalNT CostoinvestimentoEqualThis, 
DecimalNT MezzipropriEqualThis, DecimalNT RisorseterziEqualThis, DecimalNT ContributipubbliciEqualThis, 
DecimalNT SpesegestioneEqualThis, DecimalNT RimborsodebitoEqualThis, DecimalNT EntratagestioneEqualThis, 
DecimalNT AltrecopertureEqualThis)
		{
			PianoDiSviluppoDomandaPagamentoCollection PianoDiSviluppoDomandaPagamentoCollectionTemp = PianoDiSviluppoDomandaPagamentoDAL.Select(_dbProviderObj, IdpianoEqualThis, AnnoEqualThis, IddomandapagamentoEqualThis, 
IdimpresaEqualThis, IdprogettoEqualThis, CostoinvestimentoEqualThis, 
MezzipropriEqualThis, RisorseterziEqualThis, ContributipubbliciEqualThis, 
SpesegestioneEqualThis, RimborsodebitoEqualThis, EntratagestioneEqualThis, 
AltrecopertureEqualThis);
			PianoDiSviluppoDomandaPagamentoCollectionTemp.Provider = this;
			return PianoDiSviluppoDomandaPagamentoCollectionTemp;
		}

		//Find: popola la collection
		public PianoDiSviluppoDomandaPagamentoCollection Find(IntNT AnnoEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdprogettoEqualThis, 
IntNT IdimpresaEqualThis)
		{
			PianoDiSviluppoDomandaPagamentoCollection PianoDiSviluppoDomandaPagamentoCollectionTemp = PianoDiSviluppoDomandaPagamentoDAL.Find(_dbProviderObj, AnnoEqualThis, IddomandapagamentoEqualThis, IdprogettoEqualThis, 
IdimpresaEqualThis);
			PianoDiSviluppoDomandaPagamentoCollectionTemp.Provider = this;
			return PianoDiSviluppoDomandaPagamentoCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<PIANO_DI_SVILUPPO_DOMANDA_PAGAMENTO>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>True</chkDataModifica>
  <txtNomeCampoDataModifica>DATA_MODIFICA</txtNomeCampoDataModifica>
  <chkOptimisticCouncurrency>True</chkOptimisticCouncurrency>
  <chkShortNames>False</chkShortNames>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds>
    <Find OrderBy="ORDER BY ANNO DESC">
      <ANNO>Equal</ANNO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PIANO_DI_SVILUPPO_DOMANDA_PAGAMENTO>
*/