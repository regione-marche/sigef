using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for CheckListCollectionProvider:ICheckListProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class CheckListCollectionProvider : ICheckListProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di CheckList
		protected CheckListCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public CheckListCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new CheckListCollection(this);
		}

		//Costruttore 2: popola la collection
		public CheckListCollectionProvider(StringNT DescrizioneLikeThis, BoolNT FlagtemplateEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(DescrizioneLikeThis, FlagtemplateEqualThis);
		}

		//Costruttore3: ha in input checklistCollectionObj - non popola la collection
		public CheckListCollectionProvider(CheckListCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public CheckListCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new CheckListCollection(this);
		}

		//Get e Set
		public CheckListCollection CollectionObj
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
		public int SaveCollection(CheckListCollection collectionObj)
		{
			return CheckListDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(CheckList checklistObj)
		{
			return CheckListDAL.Save(_dbProviderObj, checklistObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(CheckListCollection collectionObj)
		{
			return CheckListDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(CheckList checklistObj)
		{
			return CheckListDAL.Delete(_dbProviderObj, checklistObj);
		}

		//getById
		public CheckList GetById(IntNT IdCheckListValue)
		{
			CheckList CheckListTemp = CheckListDAL.GetById(_dbProviderObj, IdCheckListValue);
			if (CheckListTemp!=null) CheckListTemp.Provider = this;
			return CheckListTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public CheckListCollection Select(IntNT IdchecklistEqualThis, StringNT DescrizioneEqualThis, BoolNT FlagtemplateEqualThis, 
DatetimeNT DatamodificaEqualThis, StringNT OperatoreEqualThis)
		{
			CheckListCollection CheckListCollectionTemp = CheckListDAL.Select(_dbProviderObj, IdchecklistEqualThis, DescrizioneEqualThis, FlagtemplateEqualThis, 
DatamodificaEqualThis, OperatoreEqualThis);
			CheckListCollectionTemp.Provider = this;
			return CheckListCollectionTemp;
		}

		//Find: popola la collection
		public CheckListCollection Find(StringNT DescrizioneLikeThis, BoolNT FlagtemplateEqualThis)
		{
			CheckListCollection CheckListCollectionTemp = CheckListDAL.Find(_dbProviderObj, DescrizioneLikeThis, FlagtemplateEqualThis);
			CheckListCollectionTemp.Provider = this;
			return CheckListCollectionTemp;
		}

        public CheckListCollection FindFASE(StringNT fase, BoolNT flag_template)
        {
            CheckListCollection chk = new CheckListCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpCheckListFase";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COD_FASE", fase.Value));
            if (flag_template!=null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FLAG_TEMPLATE", (flag_template ? 1:0) ));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                CheckList c = CheckListDAL .GetFromDatareader(DbProviderObj);
                chk.Add(c);
            }
             
            DbProviderObj.Close();
            return chk;
        }


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<CHECK_LIST>
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
    <Find OrderBy="ORDER BY ID_CHECK_LIST">
      <DESCRIZIONE>Like</DESCRIZIONE>
      <FLAG_TEMPLATE>Equal</FLAG_TEMPLATE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CHECK_LIST>
*/