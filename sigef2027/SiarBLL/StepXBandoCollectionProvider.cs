using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for StepXBandoCollectionProvider:IStepXBandoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class StepXBandoCollectionProvider : IStepXBandoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di StepXBando
		protected StepXBandoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public StepXBandoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new StepXBandoCollection(this);
		}

		//Costruttore 2: popola la collection
		public StepXBandoCollectionProvider(IntNT IdbandoEqualThis, IntNT IdchecklistEqualThis, IntNT OrdineEqualThis, 
StringNT CodfaseEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdbandoEqualThis, IdchecklistEqualThis, OrdineEqualThis, 
CodfaseEqualThis);
		}

		//Costruttore3: ha in input stepxbandoCollectionObj - non popola la collection
		public StepXBandoCollectionProvider(StepXBandoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public StepXBandoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new StepXBandoCollection(this);
		}

		//Get e Set
		public StepXBandoCollection CollectionObj
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
		public int SaveCollection(StepXBandoCollection collectionObj)
		{
			return StepXBandoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(StepXBando stepxbandoObj)
		{
			return StepXBandoDAL.Save(_dbProviderObj, stepxbandoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(StepXBandoCollection collectionObj)
		{
			return StepXBandoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(StepXBando stepxbandoObj)
		{
			return StepXBandoDAL.Delete(_dbProviderObj, stepxbandoObj);
		}

		//getById
		public StepXBando GetById(IntNT IdBandoValue, IntNT IdCheckListValue)
		{
			StepXBando StepXBandoTemp = StepXBandoDAL.GetById(_dbProviderObj, IdBandoValue, IdCheckListValue);
			if (StepXBandoTemp!=null) StepXBandoTemp.Provider = this;
			return StepXBandoTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public StepXBandoCollection Select(IntNT IdbandoEqualThis, IntNT IdchecklistEqualThis, StringNT CodfaseEqualThis)
		{
			StepXBandoCollection StepXBandoCollectionTemp = StepXBandoDAL.Select(_dbProviderObj, IdbandoEqualThis, IdchecklistEqualThis, CodfaseEqualThis);
			StepXBandoCollectionTemp.Provider = this;
			return StepXBandoCollectionTemp;
		}

		//Find: popola la collection
		public StepXBandoCollection Find(IntNT IdbandoEqualThis, IntNT IdchecklistEqualThis, IntNT OrdineEqualThis, 
StringNT CodfaseEqualThis)
		{
			StepXBandoCollection StepXBandoCollectionTemp = StepXBandoDAL.Find(_dbProviderObj, IdbandoEqualThis, IdchecklistEqualThis, OrdineEqualThis, 
CodfaseEqualThis);
			StepXBandoCollectionTemp.Provider = this;
			return StepXBandoCollectionTemp;
		}

        public StepXBandoCollection FindCheckListFasi(IntNT IdBando)
        {
            StepXBandoCollection checklist = new StepXBandoCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandText = @"SELECT ST.COD_FASE,ST.DESCRIZIONE AS FASE_PROCEDURALE,ID_BANDO, SB.ID_CHECK_LIST,ORDINE,CHECK_LIST.DESCRIZIONE AS CHECK_LIST, 
                                FLAG_TEMPLATE FROM FASI_PROCEDURALI AS ST LEFT JOIN STEP_X_BANDO AS SB ON ST.COD_FASE = SB.COD_FASE AND ID_BANDO="+ IdBando 
                            + " LEFT JOIN CHECK_LIST ON SB.ID_CHECK_LIST = CHECK_LIST.ID_CHECK_LIST ORDER BY ORDINE";
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read()) checklist.Add(SiarDAL.StepXBandoDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return checklist;
        }

        public bool CheckModificaChecklist(IntNT IdChecklist)
        {
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpCheckModificaChecklist";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_CHEKLIST", IdChecklist.Value));
            object o = DbProviderObj.ExecuteScalar(cmd);
            DbProviderObj.Close();
            if (o == null) return false;
            int nr_bandi_pubblicati;
            int.TryParse(o.ToString(), out nr_bandi_pubblicati);
            return nr_bandi_pubblicati == 0;
        }
	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<STEP_X_BANDO>
  <ViewName>vSTEP_X_BANDO</ViewName>
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
    <Find>
      <ID_BANDO>Equal</ID_BANDO>
      <ID_CHECK_LIST>Equal</ID_CHECK_LIST>
      <ORDINE>Equal</ORDINE>
      <COD_FASE>Equal</COD_FASE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</STEP_X_BANDO>
*/