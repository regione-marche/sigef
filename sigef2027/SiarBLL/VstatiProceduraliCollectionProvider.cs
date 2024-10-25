using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for VstatiProceduraliCollectionProvider:IVstatiProceduraliProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class VstatiProceduraliCollectionProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di VstatiProcedurali
		protected VstatiProceduraliCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public VstatiProceduraliCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new VstatiProceduraliCollection();
		}

		//Costruttore 2: popola la collection
		public VstatiProceduraliCollectionProvider(StringNT CodstatoEqualThis, StringNT CodfaseEqualThis, IntNT OrdinefaseGreaterThanThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(CodstatoEqualThis, CodfaseEqualThis, OrdinefaseGreaterThanThis);
		}

		//Costruttore3: ha in input vstatiproceduraliCollectionObj - non popola la collection
		public VstatiProceduraliCollectionProvider(VstatiProceduraliCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public VstatiProceduraliCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new VstatiProceduraliCollection();
		}

		//Get e Set
		public VstatiProceduraliCollection CollectionObj
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
		public VstatiProceduraliCollection Select(StringNT CodstatoEqualThis, StringNT StatoEqualThis, StringNT CodfaseEqualThis, 
StringNT FaseEqualThis, IntNT OrdinefaseEqualThis, IntNT OrdinestatoEqualThis)
		{
			VstatiProceduraliCollection VstatiProceduraliCollectionTemp = VstatiProceduraliDAL.Select(_dbProviderObj, CodstatoEqualThis, StatoEqualThis, CodfaseEqualThis, 
FaseEqualThis, OrdinefaseEqualThis, OrdinestatoEqualThis);
			return VstatiProceduraliCollectionTemp;
		}

		//Find: popola la collection
		public VstatiProceduraliCollection Find(StringNT CodstatoEqualThis, StringNT CodfaseEqualThis, IntNT OrdinefaseGreaterThanThis)
		{
			VstatiProceduraliCollection VstatiProceduraliCollectionTemp = VstatiProceduraliDAL.Find(_dbProviderObj, CodstatoEqualThis, CodfaseEqualThis, OrdinefaseGreaterThanThis);
			return VstatiProceduraliCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<vSTATI_PROCEDURALI>
  <ViewName>vSTATI_PROCEDURALI</ViewName>
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
    <Find OrderBy="ORDER BY ORDINE_FASE, ORDINE_STATO">
      <COD_STATO>Equal</COD_STATO>
      <COD_FASE>Equal</COD_FASE>
      <ORDINE_FASE>GreaterThan</ORDINE_FASE>
    </Find>
  </Finds>
  <Filters>
    <FiltroOrdine>
      <ORDINE_FASE>Equal</ORDINE_FASE>
      <ORDINE_STATO>Equal</ORDINE_STATO>
      <ORDINE_FASE>GreaterThan</ORDINE_FASE>
      <ORDINE_STATO>GreaterThan</ORDINE_STATO>
      <ORDINE_FASE>LessThan</ORDINE_FASE>
      <ORDINE_STATO>LessThan</ORDINE_STATO>
    </FiltroOrdine>
  </Filters>
  <externalFields />
  <AddedFkFields />
</vSTATI_PROCEDURALI>
*/