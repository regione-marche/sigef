using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for VariantiSegnatureCollectionProvider:IVariantiSegnatureProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class VariantiSegnatureCollectionProvider : IVariantiSegnatureProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di VariantiSegnature
		protected VariantiSegnatureCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public VariantiSegnatureCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new VariantiSegnatureCollection(this);
		}

		//Costruttore 2: popola la collection
		public VariantiSegnatureCollectionProvider(IntNT IdvarianteEqualThis, StringNT CodtipoEqualThis, BoolNT RiaprivarianteEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdvarianteEqualThis, CodtipoEqualThis, RiaprivarianteEqualThis);
		}

		//Costruttore3: ha in input variantisegnatureCollectionObj - non popola la collection
		public VariantiSegnatureCollectionProvider(VariantiSegnatureCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public VariantiSegnatureCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new VariantiSegnatureCollection(this);
		}

		//Get e Set
		public VariantiSegnatureCollection CollectionObj
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
		public int SaveCollection(VariantiSegnatureCollection collectionObj)
		{
			return VariantiSegnatureDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(VariantiSegnature variantisegnatureObj)
		{
			return VariantiSegnatureDAL.Save(_dbProviderObj, variantisegnatureObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(VariantiSegnatureCollection collectionObj)
		{
			return VariantiSegnatureDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(VariantiSegnature variantisegnatureObj)
		{
			return VariantiSegnatureDAL.Delete(_dbProviderObj, variantisegnatureObj);
		}

		//getById
		public VariantiSegnature GetById(IntNT IdVarianteValue, StringNT CodTipoValue)
		{
			VariantiSegnature VariantiSegnatureTemp = VariantiSegnatureDAL.GetById(_dbProviderObj, IdVarianteValue, CodTipoValue);
			if (VariantiSegnatureTemp!=null) VariantiSegnatureTemp.Provider = this;
			return VariantiSegnatureTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public VariantiSegnatureCollection Select(IntNT IdvarianteEqualThis, StringNT CodtipoEqualThis, StringNT SegnaturaEqualThis, 
DatetimeNT DataEqualThis, StringNT OperatoreEqualThis, BoolNT RiaprivarianteEqualThis)
		{
			VariantiSegnatureCollection VariantiSegnatureCollectionTemp = VariantiSegnatureDAL.Select(_dbProviderObj, IdvarianteEqualThis, CodtipoEqualThis, SegnaturaEqualThis, 
DataEqualThis, OperatoreEqualThis, RiaprivarianteEqualThis);
			VariantiSegnatureCollectionTemp.Provider = this;
			return VariantiSegnatureCollectionTemp;
		}

		//Find: popola la collection
		public VariantiSegnatureCollection Find(IntNT IdvarianteEqualThis, StringNT CodtipoEqualThis, BoolNT RiaprivarianteEqualThis)
		{
			VariantiSegnatureCollection VariantiSegnatureCollectionTemp = VariantiSegnatureDAL.Find(_dbProviderObj, IdvarianteEqualThis, CodtipoEqualThis, RiaprivarianteEqualThis);
			VariantiSegnatureCollectionTemp.Provider = this;
			return VariantiSegnatureCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<VARIANTI_SEGNATURE>
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
    <Find OrderBy="ORDER BY DATA DESC">
      <ID_VARIANTE>Equal</ID_VARIANTE>
      <COD_TIPO>Equal</COD_TIPO>
      <RIAPRI_VARIANTE>Equal</RIAPRI_VARIANTE>
    </Find>
  </Finds>
  <Filters>
    <FiltroTipo>
      <COD_TIPO>Equal</COD_TIPO>
      <RIAPRI_VARIANTE>Equal</RIAPRI_VARIANTE>
    </FiltroTipo>
  </Filters>
  <externalFields />
  <AddedFkFields />
</VARIANTI_SEGNATURE>
*/