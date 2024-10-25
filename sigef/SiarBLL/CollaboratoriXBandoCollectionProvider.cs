using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

    /// <summary>
    /// Summary description for CollaboratoriXBandoCollectionProvider:ICollaboratoriXBandoProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public class CollaboratoriXBandoCollectionProvider : ICollaboratoriXBandoProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di CollaboratoriXBando
        protected CollaboratoriXBandoCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public CollaboratoriXBandoCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new CollaboratoriXBandoCollection(this);
        }

        //Costruttore 2: popola la collection
        public CollaboratoriXBandoCollectionProvider(IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis, IntNT IdutenteEqualThis,
StringNT ProvinciaEqualThis, BoolNT AttivoEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IdbandoEqualThis, IdprogettoEqualThis, IdutenteEqualThis,
ProvinciaEqualThis, AttivoEqualThis);
        }

        //Costruttore3: ha in input collaboratorixbandoCollectionObj - non popola la collection
        public CollaboratoriXBandoCollectionProvider(CollaboratoriXBandoCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public CollaboratoriXBandoCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new CollaboratoriXBandoCollection(this);
        }

        //Get e Set
        public CollaboratoriXBandoCollection CollectionObj
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
        public int SaveCollection(CollaboratoriXBandoCollection collectionObj)
        {
            return CollaboratoriXBandoDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(CollaboratoriXBando collaboratorixbandoObj)
        {
            return CollaboratoriXBandoDAL.Save(_dbProviderObj, collaboratorixbandoObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(CollaboratoriXBandoCollection collectionObj)
        {
            return CollaboratoriXBandoDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(CollaboratoriXBando collaboratorixbandoObj)
        {
            return CollaboratoriXBandoDAL.Delete(_dbProviderObj, collaboratorixbandoObj);
        }

        //getById
        public CollaboratoriXBando GetById(IntNT IdCollaboratoreValue)
        {
            CollaboratoriXBando CollaboratoriXBandoTemp = CollaboratoriXBandoDAL.GetById(_dbProviderObj, IdCollaboratoreValue);
            if (CollaboratoriXBandoTemp != null) CollaboratoriXBandoTemp.Provider = this;
            return CollaboratoriXBandoTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public CollaboratoriXBandoCollection Select(IntNT IdcollaboratoreEqualThis, IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis,
IntNT IdutenteEqualThis, StringNT ProvinciaEqualThis, IntNT OperatoreinserimentoEqualThis,
DatetimeNT DatainserimentoEqualThis, IntNT OperatorefinevaliditaEqualThis, DatetimeNT DatafinevaliditaEqualThis,
BoolNT AttivoEqualThis)
        {
            CollaboratoriXBandoCollection CollaboratoriXBandoCollectionTemp = CollaboratoriXBandoDAL.Select(_dbProviderObj, IdcollaboratoreEqualThis, IdbandoEqualThis, IdprogettoEqualThis,
IdutenteEqualThis, ProvinciaEqualThis, OperatoreinserimentoEqualThis,
DatainserimentoEqualThis, OperatorefinevaliditaEqualThis, DatafinevaliditaEqualThis,
AttivoEqualThis);
            CollaboratoriXBandoCollectionTemp.Provider = this;
            return CollaboratoriXBandoCollectionTemp;
        }

        //Find: popola la collection
        public CollaboratoriXBandoCollection Find(IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis, IntNT IdutenteEqualThis,
StringNT ProvinciaEqualThis, BoolNT AttivoEqualThis)
        {
            CollaboratoriXBandoCollection CollaboratoriXBandoCollectionTemp = CollaboratoriXBandoDAL.Find(_dbProviderObj, IdbandoEqualThis, IdprogettoEqualThis, IdutenteEqualThis,
ProvinciaEqualThis, AttivoEqualThis);
            CollaboratoriXBandoCollectionTemp.Provider = this;
            return CollaboratoriXBandoCollectionTemp;
        }

        public CollaboratoriXBandoCollection GetDomandeInRiesame(int id_bando)
        {
            CollaboratoriXBandoCollection cc = new CollaboratoriXBandoCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetDomandeInRiesame";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_BANDO", id_bando));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                CollaboratoriXBando c = CollaboratoriXBandoDAL.GetFromDatareader(DbProviderObj);
                c.AdditionalAttributes.Add("Data", new SiarLibrary.NullTypes.DatetimeNT(DbProviderObj.DataReader["DATA_DOCUMENTO"]));
                c.AdditionalAttributes.Add("SegnaturaDocumento", new SiarLibrary.NullTypes.StringNT(DbProviderObj.DataReader["SEGNATURA_DOCUMENTO"]));
                c.AdditionalAttributes.Add("OperatoreDocumento", new SiarLibrary.NullTypes.StringNT(DbProviderObj.DataReader["OPERATORE_DOCUMENTO"]));
                c.AdditionalAttributes.Add("CodStatoRiesaminato", new SiarLibrary.NullTypes.StringNT(DbProviderObj.DataReader["COD_STATO_RIESAMINATO"]));
                c.AdditionalAttributes.Add("StatoRiesaminato", new SiarLibrary.NullTypes.StringNT(DbProviderObj.DataReader["STATO_RIESAMINATO"]));
                cc.Add(c);
            }
            DbProviderObj.Close();
            return cc;
        }

        public CollaboratoriXBandoCollection GetCollabBandoDatiProgettoImpresa(IntNT id_bando, IntNT id_progetto, IntNT id_utente,
            StringNT provincia, StringNT cod_stato)
        {
            CollaboratoriXBandoCollection cc = new CollaboratoriXBandoCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetCollabBandoDatiProgettoImpresa";
            if (id_bando != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_BANDO", id_bando.Value));
            if (id_progetto != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGETTO", id_progetto.Value));
            if (id_utente != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_UTENTE", id_utente.Value));
            if (provincia != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PROVINCIA", provincia.Value));
            if (cod_stato != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COD_STATO", cod_stato.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                CollaboratoriXBando c = CollaboratoriXBandoDAL.GetFromDatareader(DbProviderObj);
                c.AdditionalAttributes.Add("ID_IMPRESA", new IntNT(DbProviderObj.DataReader["ID_IMPRESA"]));
                c.AdditionalAttributes.Add("CUAA", new StringNT(DbProviderObj.DataReader["CUAA"]));
                c.AdditionalAttributes.Add("CODICE_FISCALE", new StringNT(DbProviderObj.DataReader["CODICE_FISCALE"]));
                c.AdditionalAttributes.Add("RAGIONE_SOCIALE", new StringNT(DbProviderObj.DataReader["RAGIONE_SOCIALE"]));
                c.AdditionalAttributes.Add("COMUNE", new StringNT(DbProviderObj.DataReader["COMUNE"]));
                c.AdditionalAttributes.Add("SIGLA", new StringNT(DbProviderObj.DataReader["SIGLA"]));
                c.AdditionalAttributes.Add("CAP", new StringNT(DbProviderObj.DataReader["CAP"]));
                c.AdditionalAttributes.Add("COD_STATO", new StringNT(DbProviderObj.DataReader["COD_STATO"]));
                c.AdditionalAttributes.Add("STATO", new StringNT(DbProviderObj.DataReader["STATO"]));
                c.AdditionalAttributes.Add("REVISIONE", new BoolNT(DbProviderObj.DataReader["REVISIONE"]));
                c.AdditionalAttributes.Add("SEGNATURA_RI", new StringNT(DbProviderObj.DataReader["SEGNATURA_RI"]));
                c.AdditionalAttributes.Add("ID_PROG_INTEGRATO", new IntNT(DbProviderObj.DataReader["ID_PROG_INTEGRATO"]));
                c.AdditionalAttributes.Add("PROVINCIA_DI_PRESENTAZIONE", new StringNT(DbProviderObj.DataReader["PROVINCIA_DI_PRESENTAZIONE"]));
                c.AdditionalAttributes.Add("DATA_RILASCIO", new DatetimeNT(DbProviderObj.DataReader["DATA_RILASCIO"]));
                cc.Add(c);
            }
            DbProviderObj.Close();
            return cc;
        }

        public CollaboratoriXBandoCollection GetRiepilogoXBando(int id_bando, string provincia)
        {
            CollaboratoriXBandoCollection cc = new CollaboratoriXBandoCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpRiepilogoCollaboratoriXBando";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_BANDO", id_bando));
            if (!string.IsNullOrEmpty( provincia )) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PROVINCIA", provincia));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                CollaboratoriXBando c = new CollaboratoriXBando();
                c.IdUtente = new IntNT(DbProviderObj.DataReader["ID_UTENTE"]);
                c.Provincia = new StringNT(DbProviderObj.DataReader["PROVINCIA"]);
                c.Nominativo = new StringNT(DbProviderObj.DataReader["NOMINATIVO"]);
                c.CodEnte = new StringNT(DbProviderObj.DataReader["COD_ENTE"]);
                c.AdditionalAttributes.Add("PROGETTI_ASSEGNATI", new IntNT(DbProviderObj.DataReader["PROGETTI_ASSEGNATI"]));
                c.AdditionalAttributes.Add("PROGETTI_RICEVIBILI", new IntNT(DbProviderObj.DataReader["PROGETTI_RICEVIBILI"]));
                c.AdditionalAttributes.Add("PROGETTI_NON_RICEVIBILI", new IntNT(DbProviderObj.DataReader["PROGETTI_NON_RICEVIBILI"]));
                c.AdditionalAttributes.Add("PROGETTI_AMMISSIBILI", new IntNT(DbProviderObj.DataReader["PROGETTI_AMMISSIBILI"]));
                c.AdditionalAttributes.Add("PROGETTI_NON_AMMISSIBILI", new IntNT(DbProviderObj.DataReader["PROGETTI_NON_AMMISSIBILI"]));
                c.AdditionalAttributes.Add("PROGETTI_ISTRUITI_DA_ALTRI", new IntNT(DbProviderObj.DataReader["PROGETTI_ISTRUITI_DA_ALTRI"]));
                cc.Add(c);
            }
            DbProviderObj.Close();
            return cc;
        }
    }
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<COLLABORATORI_X_BANDO>
  <ViewName>vCOLLABORATORI_X_BANDO</ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
  <txtNomeCampoDataModifica>DATA</txtNomeCampoDataModifica>
  <chkOptimisticCouncurrency>False</chkOptimisticCouncurrency>
  <chkShortNames>False</chkShortNames>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds>
    <Find OrderBy="ORDER BY ID_PROGETTO">
      <ID_BANDO>Equal</ID_BANDO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_UTENTE>Equal</ID_UTENTE>
      <PROVINCIA>Equal</PROVINCIA>
      <ATTIVO>Equal</ATTIVO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</COLLABORATORI_X_BANDO>
*/