using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for ControlliParametriXDomandaCollectionProvider:IControlliParametriXDomandaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class ControlliParametriXDomandaCollectionProvider : IControlliParametriXDomandaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ControlliParametriXDomanda
		protected ControlliParametriXDomandaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ControlliParametriXDomandaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ControlliParametriXDomandaCollection(this);
		}

		//Costruttore 2: popola la collection
		public ControlliParametriXDomandaCollectionProvider(IntNT IddomandapagamentoEqualThis, IntNT IdparametroEqualThis, IntNT IdlottoEqualThis, 
BoolNT ManualeEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IddomandapagamentoEqualThis, IdparametroEqualThis, IdlottoEqualThis, 
ManualeEqualThis);
		}

		//Costruttore3: ha in input controlliparametrixdomandaCollectionObj - non popola la collection
		public ControlliParametriXDomandaCollectionProvider(ControlliParametriXDomandaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ControlliParametriXDomandaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ControlliParametriXDomandaCollection(this);
		}

		//Get e Set
		public ControlliParametriXDomandaCollection CollectionObj
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
		public int SaveCollection(ControlliParametriXDomandaCollection collectionObj)
		{
			return ControlliParametriXDomandaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ControlliParametriXDomanda controlliparametrixdomandaObj)
		{
			return ControlliParametriXDomandaDAL.Save(_dbProviderObj, controlliparametrixdomandaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ControlliParametriXDomandaCollection collectionObj)
		{
			return ControlliParametriXDomandaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ControlliParametriXDomanda controlliparametrixdomandaObj)
		{
			return ControlliParametriXDomandaDAL.Delete(_dbProviderObj, controlliparametrixdomandaObj);
		}

		//getById
		public ControlliParametriXDomanda GetById(IntNT IdDomandaPagamentoValue, IntNT IdParametroValue, IntNT IdLottoValue)
		{
			ControlliParametriXDomanda ControlliParametriXDomandaTemp = ControlliParametriXDomandaDAL.GetById(_dbProviderObj, IdDomandaPagamentoValue, IdParametroValue, IdLottoValue);
			if (ControlliParametriXDomandaTemp!=null) ControlliParametriXDomandaTemp.Provider = this;
			return ControlliParametriXDomandaTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ControlliParametriXDomandaCollection Select(IntNT IddomandapagamentoEqualThis, IntNT IdparametroEqualThis, IntNT IdlottoEqualThis, 
IntNT PunteggioEqualThis, DatetimeNT DatavalutazioneEqualThis, StringNT OperatoreEqualThis)
		{
			ControlliParametriXDomandaCollection ControlliParametriXDomandaCollectionTemp = ControlliParametriXDomandaDAL.Select(_dbProviderObj, IddomandapagamentoEqualThis, IdparametroEqualThis, IdlottoEqualThis, 
PunteggioEqualThis, DatavalutazioneEqualThis, OperatoreEqualThis);
			ControlliParametriXDomandaCollectionTemp.Provider = this;
			return ControlliParametriXDomandaCollectionTemp;
		}

		//Find: popola la collection
		public ControlliParametriXDomandaCollection Find(IntNT IddomandapagamentoEqualThis, IntNT IdparametroEqualThis, IntNT IdlottoEqualThis, 
BoolNT ManualeEqualThis)
		{
			ControlliParametriXDomandaCollection ControlliParametriXDomandaCollectionTemp = ControlliParametriXDomandaDAL.Find(_dbProviderObj, IddomandapagamentoEqualThis, IdparametroEqualThis, IdlottoEqualThis, 
ManualeEqualThis);
			ControlliParametriXDomandaCollectionTemp.Provider = this;
			return ControlliParametriXDomandaCollectionTemp;
		}

        public ControlliParametriXDomandaCollection GetListaParametriLotto(IntNT IdlottoEqualThis,IntNT IddomandapagamentoEqualThis)
        {
            ControlliParametriXDomandaCollection lista_completa=new ControlliParametriXDomandaCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType=System.Data.CommandType.Text;
            cmd.CommandText = @"SELECT PXL.ID_LOTTO, PXL.ID_PARAMETRO, DESCRIZIONE, MANUALE,QUERY_SQL, ID_DOMANDA_PAGAMENTO, PUNTEGGIO, DATA_VALUTAZIONE, 
OPERATORE FROM CONTROLLI_PARAMETRI_X_LOTTO PXL INNER JOIN CONTROLLI_PARAMETRI_DI_RISCHIO P ON PXL.ID_PARAMETRO = P.ID_PARAMETRO                       
LEFT OUTER JOIN CONTROLLI_PARAMETRI_X_DOMANDA D ON D.ID_LOTTO = PXL.ID_LOTTO AND PXL.ID_PARAMETRO = D.ID_PARAMETRO
AND (ID_DOMANDA_PAGAMENTO IS NULL OR ID_DOMANDA_PAGAMENTO=" + IddomandapagamentoEqualThis + ") WHERE PXL.ID_LOTTO=" + IdlottoEqualThis;
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
                lista_completa.Add(SiarDAL.ControlliParametriXDomandaDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return lista_completa;
        }
	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<CONTROLLI_PARAMETRI_X_DOMANDA>
  <ViewName>vCONTROLLI_PARAMETRI_X_DOMANDA</ViewName>
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
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_PARAMETRO>Equal</ID_PARAMETRO>
      <ID_LOTTO>Equal</ID_LOTTO>
      <MANUALE>Equal</MANUALE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CONTROLLI_PARAMETRI_X_DOMANDA>
*/