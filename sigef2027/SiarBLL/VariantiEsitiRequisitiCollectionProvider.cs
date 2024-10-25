using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for VariantiEsitiRequisitiCollectionProvider:IVariantiEsitiRequisitiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class VariantiEsitiRequisitiCollectionProvider : IVariantiEsitiRequisitiProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di VariantiEsitiRequisiti
		protected VariantiEsitiRequisitiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public VariantiEsitiRequisitiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new VariantiEsitiRequisitiCollection(this);
		}

		//Costruttore 2: popola la collection
		public VariantiEsitiRequisitiCollectionProvider(IntNT IdvarianteEqualThis, IntNT IdrequisitoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdvarianteEqualThis, IdrequisitoEqualThis);
		}

		//Costruttore3: ha in input variantiesitirequisitiCollectionObj - non popola la collection
		public VariantiEsitiRequisitiCollectionProvider(VariantiEsitiRequisitiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public VariantiEsitiRequisitiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new VariantiEsitiRequisitiCollection(this);
		}

		//Get e Set
		public VariantiEsitiRequisitiCollection CollectionObj
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
		public int SaveCollection(VariantiEsitiRequisitiCollection collectionObj)
		{
			return VariantiEsitiRequisitiDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(VariantiEsitiRequisiti variantiesitirequisitiObj)
		{
			return VariantiEsitiRequisitiDAL.Save(_dbProviderObj, variantiesitirequisitiObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(VariantiEsitiRequisitiCollection collectionObj)
		{
			return VariantiEsitiRequisitiDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(VariantiEsitiRequisiti variantiesitirequisitiObj)
		{
			return VariantiEsitiRequisitiDAL.Delete(_dbProviderObj, variantiesitirequisitiObj);
		}

		//getById
		public VariantiEsitiRequisiti GetById(IntNT IdVarianteValue, IntNT IdRequisitoValue)
		{
			VariantiEsitiRequisiti VariantiEsitiRequisitiTemp = VariantiEsitiRequisitiDAL.GetById(_dbProviderObj, IdVarianteValue, IdRequisitoValue);
			if (VariantiEsitiRequisitiTemp!=null) VariantiEsitiRequisitiTemp.Provider = this;
			return VariantiEsitiRequisitiTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public VariantiEsitiRequisitiCollection Select(IntNT IdvarianteEqualThis, IntNT IdrequisitoEqualThis, StringNT CodesitoEqualThis, 
DatetimeNT DataEqualThis, StringNT CfoperatoreEqualThis, StringNT CodesitoistruttoreEqualThis, 
DatetimeNT DatavalutazioneEqualThis, StringNT IstruttoreEqualThis, BoolNT EscludidacomunicazioneEqualThis)
		{
			VariantiEsitiRequisitiCollection VariantiEsitiRequisitiCollectionTemp = VariantiEsitiRequisitiDAL.Select(_dbProviderObj, IdvarianteEqualThis, IdrequisitoEqualThis, CodesitoEqualThis, 
DataEqualThis, CfoperatoreEqualThis, CodesitoistruttoreEqualThis, 
DatavalutazioneEqualThis, IstruttoreEqualThis, EscludidacomunicazioneEqualThis);
			VariantiEsitiRequisitiCollectionTemp.Provider = this;
			return VariantiEsitiRequisitiCollectionTemp;
		}

		//Find: popola la collection
		public VariantiEsitiRequisitiCollection Find(IntNT IdvarianteEqualThis, IntNT IdrequisitoEqualThis)
		{
			VariantiEsitiRequisitiCollection VariantiEsitiRequisitiCollectionTemp = VariantiEsitiRequisitiDAL.Find(_dbProviderObj, IdvarianteEqualThis, IdrequisitoEqualThis);
			VariantiEsitiRequisitiCollectionTemp.Provider = this;
			return VariantiEsitiRequisitiCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<VARIANTI_ESITI_REQUISITI>
  <ViewName>vVARIANTI_ESITI_REQUISITI</ViewName>
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
      <ID_VARIANTE>Equal</ID_VARIANTE>
      <ID_REQUISITO>Equal</ID_REQUISITO>
    </Find>
  </Finds>
  <Filters>
    <FiltroEsitoPositivo>
      <ESITO_POSITIVO>Equal</ESITO_POSITIVO>
      <ESITO_POSITIVO_ISTRUTTORE>Equal</ESITO_POSITIVO_ISTRUTTORE>
    </FiltroEsitoPositivo>
  </Filters>
  <externalFields />
  <AddedFkFields />
</VARIANTI_ESITI_REQUISITI>
*/