using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

    /// <summary>
    /// Summary description for ControlliDomandePagamentoCollectionProvider:IControlliDomandePagamentoProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public class ControlliDomandePagamentoCollectionProvider : IControlliDomandePagamentoProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di ControlliDomandePagamento
        protected ControlliDomandePagamentoCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public ControlliDomandePagamentoCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new ControlliDomandePagamentoCollection(this);
        }

        //Costruttore 2: popola la collection
        public ControlliDomandePagamentoCollectionProvider(IntNT IdlottoEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdprogettoEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IdlottoEqualThis, IddomandapagamentoEqualThis, IdprogettoEqualThis);
        }

        //Costruttore3: ha in input controllidomandepagamentoCollectionObj - non popola la collection
        public ControlliDomandePagamentoCollectionProvider(ControlliDomandePagamentoCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public ControlliDomandePagamentoCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new ControlliDomandePagamentoCollection(this);
        }

        //Get e Set
        public ControlliDomandePagamentoCollection CollectionObj
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
        public int SaveCollection(ControlliDomandePagamentoCollection collectionObj)
        {
            return ControlliDomandePagamentoDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(ControlliDomandePagamento controllidomandepagamentoObj)
        {
            return ControlliDomandePagamentoDAL.Save(_dbProviderObj, controllidomandepagamentoObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(ControlliDomandePagamentoCollection collectionObj)
        {
            return ControlliDomandePagamentoDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(ControlliDomandePagamento controllidomandepagamentoObj)
        {
            return ControlliDomandePagamentoDAL.Delete(_dbProviderObj, controllidomandepagamentoObj);
        }

        //getById
        public ControlliDomandePagamento GetById(IntNT IdLottoValue, IntNT IdDomandaPagamentoValue)
        {
            ControlliDomandePagamento ControlliDomandePagamentoTemp = ControlliDomandePagamentoDAL.GetById(_dbProviderObj, IdLottoValue, IdDomandaPagamentoValue);
            if (ControlliDomandePagamentoTemp != null) ControlliDomandePagamentoTemp.Provider = this;
            return ControlliDomandePagamentoTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public ControlliDomandePagamentoCollection Select(IntNT IdlottoEqualThis, IntNT IddomandapagamentoEqualThis, StringNT OperatoreassegnatoEqualThis,
BoolNT SelezionataxcontrolloEqualThis, StringNT TipoestrazioneEqualThis, DecimalNT ValoredirischioEqualThis,
StringNT ClassedirischioEqualThis, IntNT OrdineclassedirischioEqualThis, DecimalNT ContributorichiestoEqualThis,
DatetimeNT DatamodificaEqualThis, StringNT OperatoreEqualThis, BoolNT ControlloconclusoEqualThis)
        {
            ControlliDomandePagamentoCollection ControlliDomandePagamentoCollectionTemp = ControlliDomandePagamentoDAL.Select(_dbProviderObj, IdlottoEqualThis, IddomandapagamentoEqualThis, OperatoreassegnatoEqualThis,
SelezionataxcontrolloEqualThis, TipoestrazioneEqualThis, ValoredirischioEqualThis,
ClassedirischioEqualThis, OrdineclassedirischioEqualThis, ContributorichiestoEqualThis,
DatamodificaEqualThis, OperatoreEqualThis, ControlloconclusoEqualThis);
            ControlliDomandePagamentoCollectionTemp.Provider = this;
            return ControlliDomandePagamentoCollectionTemp;
        }

        //Find: popola la collection
        public ControlliDomandePagamentoCollection Find(IntNT IdlottoEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdprogettoEqualThis)
        {
            ControlliDomandePagamentoCollection ControlliDomandePagamentoCollectionTemp = ControlliDomandePagamentoDAL.Find(_dbProviderObj, IdlottoEqualThis, IddomandapagamentoEqualThis, IdprogettoEqualThis);
            ControlliDomandePagamentoCollectionTemp.Provider = this;
            return ControlliDomandePagamentoCollectionTemp;
        }

        public ControlliDomandePagamentoCollection CreaElencoDomandeXControlliLoco(IntNT idLotto)
        {
            ControlliDomandePagamentoCollection domande_selezionate = new ControlliDomandePagamentoCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrCreaElencoDomandeXControlliLoco";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_LOTTO", idLotto.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
                domande_selezionate.Add(SiarDAL.ControlliDomandePagamentoDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return domande_selezionate;
        }

        public int EstraiCampioneDomandeXControlliLoco(IntNT idLotto,string cf_operatore, bool estrazione_aggiuntiva)
        {
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpEstraiCampioneDomandeXControlliLoco";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_LOTTO", idLotto.Value));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("OPERATORE", cf_operatore));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("CAMPIONE_AGGIUNTIVO", estrazione_aggiuntiva));
            //cmd..Add(new System.Data.SqlClient.SqlParameter("CAMPIONE_AGGIUNTIVO", estrazione_aggiuntiva));
            System.Data.SqlClient.SqlParameter param_out = new System.Data.SqlClient.SqlParameter("RETURN_VALUE", System.Data.SqlDbType.Int);
            param_out.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(param_out);
            DbProviderObj.ExecuteScalar(cmd);
            DbProviderObj.Close();
            if (param_out.Value == null) return -1;
            return (int)param_out.Value;
        }
    }
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<CONTROLLI_DOMANDE_PAGAMENTO>
  <ViewName>vCONTROLLI_DOMANDE_PAGAMENTO</ViewName>
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
    <Find OrderBy="ORDER BY SELEZIONATA_X_CONTROLLO DESC, TIPO_ESTRAZIONE, COD_TIPO DESC, VALORE_DI_RISCHIO DESC, CONTRIBUTO_RICHIESTO DESC">
      <ID_LOTTO>Equal</ID_LOTTO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
    </Find>
  </Finds>
  <Filters>
    <FiltroControlli>
      <SELEZIONATA_X_CONTROLLO>Equal</SELEZIONATA_X_CONTROLLO>
      <CONTROLLO_CONCLUSO>Equal</CONTROLLO_CONCLUSO>
    </FiltroControlli>
    <FiltroTipo>
      <COD_TIPO>Equal</COD_TIPO>
    </FiltroTipo>
  </Filters>
  <externalFields />
  <AddedFkFields />
</CONTROLLI_DOMANDE_PAGAMENTO>
*/