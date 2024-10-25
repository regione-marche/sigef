using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for BandoRequisitiPagamentoCollectionProvider:IBandoRequisitiPagamentoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class BandoRequisitiPagamentoCollectionProvider : IBandoRequisitiPagamentoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di BandoRequisitiPagamento
		protected BandoRequisitiPagamentoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public BandoRequisitiPagamentoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new BandoRequisitiPagamentoCollection(this);
		}

		//Costruttore 2: popola la collection
		public BandoRequisitiPagamentoCollectionProvider(IntNT IdbandoEqualThis, StringNT CodtipoEqualThis, IntNT IdrequisitoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdbandoEqualThis, CodtipoEqualThis, IdrequisitoEqualThis);
		}

		//Costruttore3: ha in input bandorequisitipagamentoCollectionObj - non popola la collection
		public BandoRequisitiPagamentoCollectionProvider(BandoRequisitiPagamentoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public BandoRequisitiPagamentoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new BandoRequisitiPagamentoCollection(this);
		}

		//Get e Set
		public BandoRequisitiPagamentoCollection CollectionObj
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
		public int SaveCollection(BandoRequisitiPagamentoCollection collectionObj)
		{
			return BandoRequisitiPagamentoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(BandoRequisitiPagamento bandorequisitipagamentoObj)
		{
			return BandoRequisitiPagamentoDAL.Save(_dbProviderObj, bandorequisitipagamentoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(BandoRequisitiPagamentoCollection collectionObj)
		{
			return BandoRequisitiPagamentoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(BandoRequisitiPagamento bandorequisitipagamentoObj)
		{
			return BandoRequisitiPagamentoDAL.Delete(_dbProviderObj, bandorequisitipagamentoObj);
		}

		//getById
		public BandoRequisitiPagamento GetById(IntNT IdBandoValue, StringNT CodTipoValue, IntNT IdRequisitoValue)
		{
			BandoRequisitiPagamento BandoRequisitiPagamentoTemp = BandoRequisitiPagamentoDAL.GetById(_dbProviderObj, IdBandoValue, CodTipoValue, IdRequisitoValue);
			if (BandoRequisitiPagamentoTemp!=null) BandoRequisitiPagamentoTemp.Provider = this;
			return BandoRequisitiPagamentoTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public BandoRequisitiPagamentoCollection Select(IntNT IdbandoEqualThis, StringNT CodtipoEqualThis, IntNT IdrequisitoEqualThis, 
BoolNT ObbligatorioEqualThis, BoolNT RequisitodiinserimentoEqualThis, BoolNT RequisitodicontrolloEqualThis, 
IntNT OrdineEqualThis)
		{
			BandoRequisitiPagamentoCollection BandoRequisitiPagamentoCollectionTemp = BandoRequisitiPagamentoDAL.Select(_dbProviderObj, IdbandoEqualThis, CodtipoEqualThis, IdrequisitoEqualThis, 
ObbligatorioEqualThis, RequisitodiinserimentoEqualThis, RequisitodicontrolloEqualThis, 
OrdineEqualThis);
			BandoRequisitiPagamentoCollectionTemp.Provider = this;
			return BandoRequisitiPagamentoCollectionTemp;
		}

		//Find: popola la collection
		public BandoRequisitiPagamentoCollection Find(IntNT IdbandoEqualThis, StringNT CodtipoEqualThis, IntNT IdrequisitoEqualThis)
		{
			BandoRequisitiPagamentoCollection BandoRequisitiPagamentoCollectionTemp = BandoRequisitiPagamentoDAL.Find(_dbProviderObj, IdbandoEqualThis, CodtipoEqualThis, IdrequisitoEqualThis);
			BandoRequisitiPagamentoCollectionTemp.Provider = this;
			return BandoRequisitiPagamentoCollectionTemp;
		}

        public BandoRequisitiPagamentoCollection FindByIdBandoTipo(IntNT IdBando,StringNT CodTipo)
        {
            BandoRequisitiPagamentoCollection requisiti = new BandoRequisitiPagamentoCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandText = @"SELECT R.*,R.DESCRIZIONE AS REQUISITO, BRP.*,NULL AS COD_FASE, NULL AS FASE, NULL AS ORDINE_FASE FROM REQUISITI_PAGAMENTO AS R 
                    LEFT JOIN BANDO_REQUISITI_PAGAMENTO AS BRP ON R.ID_REQUISITO = BRP.ID_REQUISITO AND BRP.ID_BANDO=" + IdBando
                + " AND BRP.COD_TIPO = '" + CodTipo + "' ORDER BY ID_BANDO DESC,ORDINE";
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
                requisiti.Add(SiarDAL.BandoRequisitiPagamentoDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return requisiti;
        }

        public BandoRequisitiPagamentoCollection FindRequisitiEsistentiXMultimisura(IntNT IdBando, StringNT CodTipo)
        {
            BandoRequisitiPagamentoCollection requisiti = new BandoRequisitiPagamentoCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandText = "SELECT * FROM vBANDO_REQUISITI_PAGAMENTO R WHERE COD_TIPO='"+CodTipo+ @"' AND ID_BANDO IN 
                               (SELECT DISTINCT ISNULL(ID_DISPOSIZIONI_ATTUATIVE,ID_BANDO) FROM BANDO_PROGRAMMAZIONE WHERE ID_BANDO IN 
                               (SELECT DISTINCT ID_BANDO FROM BANDO_PROGRAMMAZIONE WHERE ISNULL(ID_DISPOSIZIONI_ATTUATIVE,ID_BANDO)=" + IdBando + "))";
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
                requisiti.Add(SiarDAL.BandoRequisitiPagamentoDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return requisiti;
        }
	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<BANDO_REQUISITI_PAGAMENTO>
  <ViewName>vBANDO_REQUISITI_PAGAMENTO</ViewName>
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
    <Find OrderBy="ORDER BY ORDINE, ORDINE_FASE">
      <ID_BANDO>Equal</ID_BANDO>
      <COD_TIPO>Equal</COD_TIPO>
      <ID_REQUISITO>Equal</ID_REQUISITO>
    </Find>
  </Finds>
  <Filters>
    <FiltroObbligatorio>
      <OBBLIGATORIO>Equal</OBBLIGATORIO>
    </FiltroObbligatorio>
    <FiltroDiControllo>
      <REQUISITO_DI_CONTROLLO>Equal</REQUISITO_DI_CONTROLLO>
    </FiltroDiControllo>
    <FiltroDiInserimento>
      <REQUISITO_DI_INSERIMENTO>Equal</REQUISITO_DI_INSERIMENTO>
    </FiltroDiInserimento>
    <FiltroMisura>
      <MISURA>Equal</MISURA>
    </FiltroMisura>
  </Filters>
  <externalFields />
  <AddedFkFields />
</BANDO_REQUISITI_PAGAMENTO>
*/