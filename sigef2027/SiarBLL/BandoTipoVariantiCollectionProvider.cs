using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for BandoTipoVariantiCollectionProvider:IBandoTipoVariantiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class BandoTipoVariantiCollectionProvider : IBandoTipoVariantiProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di BandoTipoVarianti
		protected BandoTipoVariantiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public BandoTipoVariantiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new BandoTipoVariantiCollection(this);
		}

		//Costruttore 2: popola la collection
		public BandoTipoVariantiCollectionProvider(IntNT IdbandoEqualThis, StringNT CodtipoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdbandoEqualThis, CodtipoEqualThis);
		}

		//Costruttore3: ha in input bandotipovariantiCollectionObj - non popola la collection
		public BandoTipoVariantiCollectionProvider(BandoTipoVariantiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public BandoTipoVariantiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new BandoTipoVariantiCollection(this);
		}

		//Get e Set
		public BandoTipoVariantiCollection CollectionObj
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
		public int SaveCollection(BandoTipoVariantiCollection collectionObj)
		{
			return BandoTipoVariantiDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(BandoTipoVarianti bandotipovariantiObj)
		{
			return BandoTipoVariantiDAL.Save(_dbProviderObj, bandotipovariantiObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(BandoTipoVariantiCollection collectionObj)
		{
			return BandoTipoVariantiDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(BandoTipoVarianti bandotipovariantiObj)
		{
			return BandoTipoVariantiDAL.Delete(_dbProviderObj, bandotipovariantiObj);
		}

		//getById
		public BandoTipoVarianti GetById(IntNT IdBandoValue, StringNT CodTipoValue)
		{
			BandoTipoVarianti BandoTipoVariantiTemp = BandoTipoVariantiDAL.GetById(_dbProviderObj, IdBandoValue, CodTipoValue);
			if (BandoTipoVariantiTemp!=null) BandoTipoVariantiTemp.Provider = this;
			return BandoTipoVariantiTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public BandoTipoVariantiCollection Select(IntNT IdbandoEqualThis, StringNT CodtipoEqualThis, IntNT NumeromassimoEqualThis)
		{
			BandoTipoVariantiCollection BandoTipoVariantiCollectionTemp = BandoTipoVariantiDAL.Select(_dbProviderObj, IdbandoEqualThis, CodtipoEqualThis, NumeromassimoEqualThis);
			BandoTipoVariantiCollectionTemp.Provider = this;
			return BandoTipoVariantiCollectionTemp;
		}

		//Find: popola la collection
		public BandoTipoVariantiCollection Find(IntNT IdbandoEqualThis, StringNT CodtipoEqualThis)
		{
			BandoTipoVariantiCollection BandoTipoVariantiCollectionTemp = BandoTipoVariantiDAL.Find(_dbProviderObj, IdbandoEqualThis, CodtipoEqualThis);
			BandoTipoVariantiCollectionTemp.Provider = this;
			return BandoTipoVariantiCollectionTemp;
		}

        public BandoTipoVariantiCollection FindByIdBando(IntNT IdbandoEqualThis)
        {
            BandoTipoVariantiCollection tipi = new BandoTipoVariantiCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = @"SELECT T.*,ID_BANDO,NUMERO_MASSIMO FROM TIPO_VARIANTE T LEFT JOIN BANDO_TIPO_VARIANTI B ON T.COD_TIPO = B.COD_TIPO 
                                AND B.ID_BANDO=" + IdbandoEqualThis;
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read()) tipi.Add(SiarDAL.BandoTipoVariantiDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return tipi;
        }
	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<BANDO_TIPO_VARIANTI>
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
      <ID_BANDO>Equal</ID_BANDO>
      <COD_TIPO>Equal</COD_TIPO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</BANDO_TIPO_VARIANTI>
*/