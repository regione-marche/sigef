using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for VisiteAziendaliCollectionProvider:IVisiteAziendaliProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class VisiteAziendaliCollectionProvider : IVisiteAziendaliProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di VisiteAziendali
		protected VisiteAziendaliCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public VisiteAziendaliCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new VisiteAziendaliCollection(this);
		}

		//Costruttore 2: popola la collection
		public VisiteAziendaliCollectionProvider(IntNT IdvisitaEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdimpresaEqualThis, 
StringNT CodtipoEqualThis, IntNT IdprogettoEqualThis, IntNT IddomandaeroaEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdvisitaEqualThis, IddomandapagamentoEqualThis, IdimpresaEqualThis, 
CodtipoEqualThis, IdprogettoEqualThis, IddomandaeroaEqualThis);
		}

		//Costruttore3: ha in input visiteaziendaliCollectionObj - non popola la collection
		public VisiteAziendaliCollectionProvider(VisiteAziendaliCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public VisiteAziendaliCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new VisiteAziendaliCollection(this);
		}

		//Get e Set
		public VisiteAziendaliCollection CollectionObj
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
		public int SaveCollection(VisiteAziendaliCollection collectionObj)
		{
			return VisiteAziendaliDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(VisiteAziendali visiteaziendaliObj)
		{
			return VisiteAziendaliDAL.Save(_dbProviderObj, visiteaziendaliObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(VisiteAziendaliCollection collectionObj)
		{
			return VisiteAziendaliDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(VisiteAziendali visiteaziendaliObj)
		{
			return VisiteAziendaliDAL.Delete(_dbProviderObj, visiteaziendaliObj);
		}

		//getById
		public VisiteAziendali GetById(IntNT IdVisitaValue)
		{
			VisiteAziendali VisiteAziendaliTemp = VisiteAziendaliDAL.GetById(_dbProviderObj, IdVisitaValue);
			if (VisiteAziendaliTemp!=null) VisiteAziendaliTemp.Provider = this;
			return VisiteAziendaliTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public VisiteAziendaliCollection Select(IntNT IdvisitaEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IddomandaeroaEqualThis, 
IntNT IdimpresaEqualThis, StringNT CodtipoEqualThis, DatetimeNT DataaperturaEqualThis, 
StringNT OperatoreaperturaEqualThis, BoolNT ControlloconclusoEqualThis, DatetimeNT DatachiusuraEqualThis, 
StringNT OperatorechiusuraEqualThis, StringNT SegnaturaverbaleEqualThis)
		{
			VisiteAziendaliCollection VisiteAziendaliCollectionTemp = VisiteAziendaliDAL.Select(_dbProviderObj, IdvisitaEqualThis, IddomandapagamentoEqualThis, IddomandaeroaEqualThis, 
IdimpresaEqualThis, CodtipoEqualThis, DataaperturaEqualThis, 
OperatoreaperturaEqualThis, ControlloconclusoEqualThis, DatachiusuraEqualThis, 
OperatorechiusuraEqualThis, SegnaturaverbaleEqualThis);
			VisiteAziendaliCollectionTemp.Provider = this;
			return VisiteAziendaliCollectionTemp;
		}

		//Find: popola la collection
		public VisiteAziendaliCollection Find(IntNT IdvisitaEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdimpresaEqualThis, 
StringNT CodtipoEqualThis, IntNT IdprogettoEqualThis, IntNT IddomandaeroaEqualThis)
		{
			VisiteAziendaliCollection VisiteAziendaliCollectionTemp = VisiteAziendaliDAL.Find(_dbProviderObj, IdvisitaEqualThis, IddomandapagamentoEqualThis, IdimpresaEqualThis, 
CodtipoEqualThis, IdprogettoEqualThis, IddomandaeroaEqualThis);
			VisiteAziendaliCollectionTemp.Provider = this;
			return VisiteAziendaliCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<VISITE_AZIENDALI>
  <ViewName>vVISITE_AZIENDALI</ViewName>
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
    <Find OrderBy="ORDER BY ID_VISITA DESC">
      <ID_VISITA>Equal</ID_VISITA>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <COD_TIPO>Equal</COD_TIPO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_DOMANDA_EROA>Equal</ID_DOMANDA_EROA>
    </Find>
  </Finds>
  <Filters>
    <FiltroControlloConcluso>
      <CONTROLLO_CONCLUSO>Equal</CONTROLLO_CONCLUSO>
    </FiltroControlloConcluso>
    <FiltroTipo>
      <COD_TIPO>Equal</COD_TIPO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
    </FiltroTipo>
  </Filters>
  <externalFields />
  <AddedFkFields />
</VISITE_AZIENDALI>
*/