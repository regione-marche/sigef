using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for VworkflowPagamentoCollectionProvider:IVworkflowPagamentoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class VworkflowPagamentoCollectionProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di VworkflowPagamento
		protected VworkflowPagamentoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public VworkflowPagamentoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new VworkflowPagamentoCollection();
		}

		//Costruttore 2: popola la collection
		public VworkflowPagamentoCollectionProvider(StringNT CodtipoEqualThis, StringNT CodworkflowEqualThis, StringNT CodfaseEqualThis, 
StringNT DescrizioneLikeThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(CodtipoEqualThis, CodworkflowEqualThis, CodfaseEqualThis, 
DescrizioneLikeThis);
		}

		//Costruttore3: ha in input vworkflowpagamentoCollectionObj - non popola la collection
		public VworkflowPagamentoCollectionProvider(VworkflowPagamentoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public VworkflowPagamentoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new VworkflowPagamentoCollection();
		}

		//Get e Set
		public VworkflowPagamentoCollection CollectionObj
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

		//Select: popola la collection
		public VworkflowPagamentoCollection Select(StringNT CodtipoEqualThis, StringNT CodworkflowEqualThis, IntNT OrdineEqualThis, 
BoolNT ObbligatorioEqualThis, StringNT DescrizioneEqualThis, StringNT UrlEqualThis, 
StringNT TipopagamentoEqualThis, StringNT CodfaseEqualThis, StringNT FaseEqualThis, 
IntNT OrdinefaseEqualThis)
		{
			VworkflowPagamentoCollection VworkflowPagamentoCollectionTemp = VworkflowPagamentoDAL.Select(_dbProviderObj, CodtipoEqualThis, CodworkflowEqualThis, OrdineEqualThis, 
ObbligatorioEqualThis, DescrizioneEqualThis, UrlEqualThis, 
TipopagamentoEqualThis, CodfaseEqualThis, FaseEqualThis, 
OrdinefaseEqualThis);
			return VworkflowPagamentoCollectionTemp;
		}

		//Find: popola la collection
		public VworkflowPagamentoCollection Find(StringNT CodtipoEqualThis, StringNT CodworkflowEqualThis, StringNT CodfaseEqualThis, 
StringNT DescrizioneLikeThis)
		{
			VworkflowPagamentoCollection VworkflowPagamentoCollectionTemp = VworkflowPagamentoDAL.Find(_dbProviderObj, CodtipoEqualThis, CodworkflowEqualThis, CodfaseEqualThis, 
DescrizioneLikeThis);
			return VworkflowPagamentoCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<vWORKFLOW_PAGAMENTO>
  <ViewName>vWORKFLOW_PAGAMENTO</ViewName>
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
    <Find OrderBy="ORDER BY ORDINE">
      <COD_TIPO>Equal</COD_TIPO>
      <COD_WORKFLOW>Equal</COD_WORKFLOW>
      <COD_FASE>Equal</COD_FASE>
      <DESCRIZIONE>Like</DESCRIZIONE>
    </Find>
  </Finds>
  <Filters>
    <FiltroObbligatorio>
      <OBBLIGATORIO>Equal</OBBLIGATORIO>
    </FiltroObbligatorio>
  </Filters>
  <externalFields />
  <AddedFkFields />
</vWORKFLOW_PAGAMENTO>
*/