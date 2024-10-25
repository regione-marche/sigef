using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for ControlliParametriXLottoCollectionProvider:IControlliParametriXLottoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class ControlliParametriXLottoCollectionProvider : IControlliParametriXLottoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ControlliParametriXLotto
		protected ControlliParametriXLottoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ControlliParametriXLottoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ControlliParametriXLottoCollection(this);
		}

		//Costruttore 2: popola la collection
		public ControlliParametriXLottoCollectionProvider(IntNT IdlottoEqualThis, IntNT IdparametroEqualThis, BoolNT ManualeEqualThis, 
StringNT DescrizioneLikeThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdlottoEqualThis, IdparametroEqualThis, ManualeEqualThis, 
DescrizioneLikeThis);
		}

		//Costruttore3: ha in input controlliparametrixlottoCollectionObj - non popola la collection
		public ControlliParametriXLottoCollectionProvider(ControlliParametriXLottoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ControlliParametriXLottoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ControlliParametriXLottoCollection(this);
		}

		//Get e Set
		public ControlliParametriXLottoCollection CollectionObj
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
		public int SaveCollection(ControlliParametriXLottoCollection collectionObj)
		{
			return ControlliParametriXLottoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ControlliParametriXLotto controlliparametrixlottoObj)
		{
			return ControlliParametriXLottoDAL.Save(_dbProviderObj, controlliparametrixlottoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ControlliParametriXLottoCollection collectionObj)
		{
			return ControlliParametriXLottoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ControlliParametriXLotto controlliparametrixlottoObj)
		{
			return ControlliParametriXLottoDAL.Delete(_dbProviderObj, controlliparametrixlottoObj);
		}

		//getById
		public ControlliParametriXLotto GetById(IntNT IdLottoValue, IntNT IdParametroValue)
		{
			ControlliParametriXLotto ControlliParametriXLottoTemp = ControlliParametriXLottoDAL.GetById(_dbProviderObj, IdLottoValue, IdParametroValue);
			if (ControlliParametriXLottoTemp!=null) ControlliParametriXLottoTemp.Provider = this;
			return ControlliParametriXLottoTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ControlliParametriXLottoCollection Select(IntNT IdlottoEqualThis, IntNT IdparametroEqualThis, IntNT PesorealeEqualThis)
		{
			ControlliParametriXLottoCollection ControlliParametriXLottoCollectionTemp = ControlliParametriXLottoDAL.Select(_dbProviderObj, IdlottoEqualThis, IdparametroEqualThis, PesorealeEqualThis);
			ControlliParametriXLottoCollectionTemp.Provider = this;
			return ControlliParametriXLottoCollectionTemp;
		}

		//Find: popola la collection
		public ControlliParametriXLottoCollection Find(IntNT IdlottoEqualThis, IntNT IdparametroEqualThis, BoolNT ManualeEqualThis, 
StringNT DescrizioneLikeThis)
		{
			ControlliParametriXLottoCollection ControlliParametriXLottoCollectionTemp = ControlliParametriXLottoDAL.Find(_dbProviderObj, IdlottoEqualThis, IdparametroEqualThis, ManualeEqualThis, 
DescrizioneLikeThis);
			ControlliParametriXLottoCollectionTemp.Provider = this;
			return ControlliParametriXLottoCollectionTemp;
		}

        public ControlliParametriXLottoCollection FindByIdLotto(IntNT IdlottoEqualThis)
        {
            ControlliParametriXLottoCollection retcoll = new ControlliParametriXLottoCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT P.*,ID_LOTTO, PESO_REALE FROM CONTROLLI_PARAMETRI_DI_RISCHIO P LEFT JOIN CONTROLLI_PARAMETRI_X_LOTTO L ON P.ID_PARAMETRO = L.ID_PARAMETRO AND (ID_LOTTO="
                + IdlottoEqualThis + " OR ID_LOTTO IS NULL)";
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
                retcoll.Add(ControlliParametriXLottoDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return retcoll;
        }
	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<CONTROLLI_PARAMETRI_X_LOTTO>
  <ViewName>vCONTROLLI_PARAMETRI_X_LOTTO</ViewName>
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
      <ID_LOTTO>Equal</ID_LOTTO>
      <ID_PARAMETRO>Equal</ID_PARAMETRO>
      <MANUALE>Equal</MANUALE>
      <DESCRIZIONE>Like</DESCRIZIONE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CONTROLLI_PARAMETRI_X_LOTTO>
*/