using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

    /// <summary>
    /// Summary description for ProgettoSegnatureCollectionProvider:IProgettoSegnatureProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public class ProgettoSegnatureCollectionProvider : IProgettoSegnatureProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di ProgettoSegnature
        protected ProgettoSegnatureCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public ProgettoSegnatureCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new ProgettoSegnatureCollection(this);
        }

        //Costruttore 2: popola la collection
        public ProgettoSegnatureCollectionProvider(IntNT IdprogettoEqualThis, StringNT OperatoreEqualThis, StringNT SegnaturaEqualThis,
StringNT CodtipoLikeThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IdprogettoEqualThis, OperatoreEqualThis, SegnaturaEqualThis,
CodtipoLikeThis);
        }

        //Costruttore3: ha in input progettosegnatureCollectionObj - non popola la collection
        public ProgettoSegnatureCollectionProvider(ProgettoSegnatureCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public ProgettoSegnatureCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new ProgettoSegnatureCollection(this);
        }

        //Get e Set
        public ProgettoSegnatureCollection CollectionObj
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
        public int SaveCollection(ProgettoSegnatureCollection collectionObj)
        {
            return ProgettoSegnatureDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(ProgettoSegnature progettosegnatureObj)
        {
            return ProgettoSegnatureDAL.Save(_dbProviderObj, progettosegnatureObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(ProgettoSegnatureCollection collectionObj)
        {
            return ProgettoSegnatureDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(ProgettoSegnature progettosegnatureObj)
        {
            return ProgettoSegnatureDAL.Delete(_dbProviderObj, progettosegnatureObj);
        }

        //getById
        public ProgettoSegnature GetById(IntNT IdProgettoValue, StringNT CodTipoValue)
        {
            ProgettoSegnature ProgettoSegnatureTemp = ProgettoSegnatureDAL.GetById(_dbProviderObj, IdProgettoValue, CodTipoValue);
            if (ProgettoSegnatureTemp != null) ProgettoSegnatureTemp.Provider = this;
            return ProgettoSegnatureTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public ProgettoSegnatureCollection Select(IntNT IdprogettoEqualThis, StringNT CodtipoEqualThis, DatetimeNT DataEqualThis,
StringNT OperatoreEqualThis, StringNT SegnaturaEqualThis, BoolNT RiapridomandaEqualThis)
        {
            ProgettoSegnatureCollection ProgettoSegnatureCollectionTemp = ProgettoSegnatureDAL.Select(_dbProviderObj, IdprogettoEqualThis, CodtipoEqualThis, DataEqualThis,
OperatoreEqualThis, SegnaturaEqualThis, RiapridomandaEqualThis);
            ProgettoSegnatureCollectionTemp.Provider = this;
            return ProgettoSegnatureCollectionTemp;
        }

        //Find: popola la collection
        public ProgettoSegnatureCollection Find(IntNT IdprogettoEqualThis, StringNT OperatoreEqualThis, StringNT SegnaturaEqualThis,
StringNT CodtipoLikeThis)
        {
            ProgettoSegnatureCollection ProgettoSegnatureCollectionTemp = ProgettoSegnatureDAL.Find(_dbProviderObj, IdprogettoEqualThis, OperatoreEqualThis, SegnaturaEqualThis,
CodtipoLikeThis);
            ProgettoSegnatureCollectionTemp.Provider = this;
            return ProgettoSegnatureCollectionTemp;
        }

        public ProgettoSegnatureCollection FindSegnatureDomandePagamento(int id_progetto)
        {
            ProgettoSegnatureCollection segnature = new ProgettoSegnatureCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetSegnatureDomandaPagamento";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGETTO", id_progetto));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                ProgettoSegnature s = ProgettoSegnatureDAL.GetFromDatareader(DbProviderObj);
                s.AdditionalAttributes.Add("IdDomandaPagamento", new IntNT(DbProviderObj.DataReader["ID_DOMANDA_PAGAMENTO"]));
                segnature.Add(s);
            }
            DbProviderObj.Close();
            return segnature;
        }

        public ProgettoSegnatureCollection FindSegnatureVarianti(int id_progetto)
        {
            ProgettoSegnatureCollection segnature = new ProgettoSegnatureCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetSegnatureVarianti";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGETTO", id_progetto));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                ProgettoSegnature s = ProgettoSegnatureDAL.GetFromDatareader(DbProviderObj);
                s.AdditionalAttributes.Add("IdVariante", new IntNT(DbProviderObj.DataReader["ID_VARIANTE"]));
                segnature.Add(s);
            }
            DbProviderObj.Close();
            return segnature;
        }

        public ProgettoSegnatureCollection GetComunicazioniEntrataBando(int id_bando, IntNT id_progetto, string tipo_documento)
        {
            ProgettoSegnatureCollection comunicazioni = new ProgettoSegnatureCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetComunicazioniEntrataBando";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_BANDO", id_bando));
            if (id_progetto != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGETTO", id_progetto.Value));
            if (!string.IsNullOrEmpty(tipo_documento)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COD_TIPO", tipo_documento));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                ProgettoSegnature c = ProgettoSegnatureDAL.GetFromDatareader(DbProviderObj);
                //c.AdditionalAttributes.Add("IdVariante", DbProviderObj.DataReader["ID_VARIANTE"].ToString());
                comunicazioni.Add(c);
            }
            DbProviderObj.Close();
            return comunicazioni;
        }
    }
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<PROGETTO_SEGNATURE>
  <ViewName>vPROGETTO_SEGNATURE</ViewName>
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
    <Find OrderBy="ORDER BY ID_PROGETTO, DATA DESC">
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <OPERATORE>Equal</OPERATORE>
      <SEGNATURA>Equal</SEGNATURA>
      <COD_TIPO>Like</COD_TIPO>
    </Find>
  </Finds>
  <Filters>
    <FiltroLikeTipoSegnatura>
      <COD_TIPO>Like</COD_TIPO>
    </FiltroLikeTipoSegnatura>
  </Filters>
  <externalFields />
  <AddedFkFields />
</PROGETTO_SEGNATURE>
*/