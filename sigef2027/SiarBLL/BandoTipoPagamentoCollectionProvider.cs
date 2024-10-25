using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for BandoTipoPagamentoCollectionProvider:IBandoTipoPagamentoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class BandoTipoPagamentoCollectionProvider : IBandoTipoPagamentoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di BandoTipoPagamento
		protected BandoTipoPagamentoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public BandoTipoPagamentoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new BandoTipoPagamentoCollection(this);
		}

		//Costruttore 2: popola la collection
		public BandoTipoPagamentoCollectionProvider(IntNT IdbandoEqualThis, StringNT CodtipoEqualThis, StringNT CodfaseEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdbandoEqualThis, CodtipoEqualThis, CodfaseEqualThis);
		}

		//Costruttore3: ha in input bandotipopagamentoCollectionObj - non popola la collection
		public BandoTipoPagamentoCollectionProvider(BandoTipoPagamentoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public BandoTipoPagamentoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new BandoTipoPagamentoCollection(this);
		}

		//Get e Set
		public BandoTipoPagamentoCollection CollectionObj
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
		public int SaveCollection(BandoTipoPagamentoCollection collectionObj)
		{
			return BandoTipoPagamentoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(BandoTipoPagamento bandotipopagamentoObj)
		{
			return BandoTipoPagamentoDAL.Save(_dbProviderObj, bandotipopagamentoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(BandoTipoPagamentoCollection collectionObj)
		{
			return BandoTipoPagamentoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(BandoTipoPagamento bandotipopagamentoObj)
		{
			return BandoTipoPagamentoDAL.Delete(_dbProviderObj, bandotipopagamentoObj);
		}

		//getById
		public BandoTipoPagamento GetById(IntNT IdBandoValue, StringNT CodTipoValue)
		{
			BandoTipoPagamento BandoTipoPagamentoTemp = BandoTipoPagamentoDAL.GetById(_dbProviderObj, IdBandoValue, CodTipoValue);
			if (BandoTipoPagamentoTemp!=null) BandoTipoPagamentoTemp.Provider = this;
			return BandoTipoPagamentoTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public BandoTipoPagamentoCollection Select(IntNT IdbandoEqualThis, StringNT CodtipoEqualThis, DecimalNT QuotamaxEqualThis, 
DecimalNT QuotaminEqualThis, DecimalNT ImportomaxEqualThis, DecimalNT ImportominEqualThis, 
IntNT NumeroEqualThis, StringNT CodtipopolizzaEqualThis)
		{
			BandoTipoPagamentoCollection BandoTipoPagamentoCollectionTemp = BandoTipoPagamentoDAL.Select(_dbProviderObj, IdbandoEqualThis, CodtipoEqualThis, QuotamaxEqualThis, 
QuotaminEqualThis, ImportomaxEqualThis, ImportominEqualThis, 
NumeroEqualThis, CodtipopolizzaEqualThis);
			BandoTipoPagamentoCollectionTemp.Provider = this;
			return BandoTipoPagamentoCollectionTemp;
		}

		//Find: popola la collection
		public BandoTipoPagamentoCollection Find(IntNT IdbandoEqualThis, StringNT CodtipoEqualThis, StringNT CodfaseEqualThis)
		{
			BandoTipoPagamentoCollection BandoTipoPagamentoCollectionTemp = BandoTipoPagamentoDAL.Find(_dbProviderObj, IdbandoEqualThis, CodtipoEqualThis, CodfaseEqualThis);
			BandoTipoPagamentoCollectionTemp.Provider = this;
			return BandoTipoPagamentoCollectionTemp;
		}

        public BandoTipoPagamentoCollection FindByIdBando(IntNT IdBando)
        {
            BandoTipoPagamentoCollection tpagamenti = new BandoTipoPagamentoCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetTipoPagamentoByIdBando";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IDBANDO", IdBando.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
                tpagamenti.Add(SiarDAL.BandoTipoPagamentoDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return tpagamenti;
        }

	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<BANDO_TIPO_PAGAMENTO>
  <ViewName>vBANDO_TIPO_PAGAMENTO</ViewName>
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
      <COD_FASE>Equal</COD_FASE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</BANDO_TIPO_PAGAMENTO>
*/