using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

    /// <summary>
    /// Summary description for VistruttoriaDomandeCollectionProvider:IVistruttoriaDomandeProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public class VistruttoriaDomandeCollectionProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di VistruttoriaDomande
        protected VistruttoriaDomandeCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public VistruttoriaDomandeCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new VistruttoriaDomandeCollection();
        }

        //Costruttore 2: popola la collection
        public VistruttoriaDomandeCollectionProvider(IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis, IntNT IdistruttoreEqualThis,
StringNT ProvinciaassegnazioneEqualThis, IntNT IdimpresaEqualThis, StringNT CuaaEqualThis,
StringNT RagionesocialeLikeThis, StringNT FiltrostatoistruttoriaEqualThis, BoolNT SelezionataxrevisioneEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IdbandoEqualThis, IdprogettoEqualThis, IdistruttoreEqualThis,
ProvinciaassegnazioneEqualThis, IdimpresaEqualThis, CuaaEqualThis,
RagionesocialeLikeThis, FiltrostatoistruttoriaEqualThis, SelezionataxrevisioneEqualThis);
        }

        //Costruttore3: ha in input vistruttoriadomandeCollectionObj - non popola la collection
        public VistruttoriaDomandeCollectionProvider(VistruttoriaDomandeCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public VistruttoriaDomandeCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new VistruttoriaDomandeCollection();
        }

        //Get e Set
        public VistruttoriaDomandeCollection CollectionObj
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

        //Select: popola la collection
        public VistruttoriaDomandeCollection Select(IntNT IdprogettoEqualThis, IntNT IdbandoEqualThis, IntNT IdprogintegratoEqualThis,
StringNT CodstatoEqualThis, StringNT StatoEqualThis, StringNT CuaaEqualThis,
StringNT PartitaivaEqualThis, StringNT RagionesocialeEqualThis, StringNT ComuneEqualThis,
StringNT SiglaEqualThis, StringNT CapEqualThis, StringNT IstruttoreEqualThis,
StringNT ProvinciaassegnazioneEqualThis, BoolNT SelezionataxrevisioneEqualThis, StringNT ProvinciadipresentazioneEqualThis,
IntNT IdistruttoreEqualThis, StringNT ViaEqualThis, StringNT SegnaturariEqualThis,
StringNT FiltrostatoistruttoriaEqualThis, IntNT OrdinestatoEqualThis, IntNT IdimpresaEqualThis)
        {
            VistruttoriaDomandeCollection VistruttoriaDomandeCollectionTemp = VistruttoriaDomandeDAL.Select(_dbProviderObj, IdprogettoEqualThis, IdbandoEqualThis, IdprogintegratoEqualThis,
CodstatoEqualThis, StatoEqualThis, CuaaEqualThis,
PartitaivaEqualThis, RagionesocialeEqualThis, ComuneEqualThis,
SiglaEqualThis, CapEqualThis, IstruttoreEqualThis,
ProvinciaassegnazioneEqualThis, SelezionataxrevisioneEqualThis, ProvinciadipresentazioneEqualThis,
IdistruttoreEqualThis, ViaEqualThis, SegnaturariEqualThis,
FiltrostatoistruttoriaEqualThis, OrdinestatoEqualThis, IdimpresaEqualThis);
            return VistruttoriaDomandeCollectionTemp;
        }

        //Find: popola la collection
        public VistruttoriaDomandeCollection Find(IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis, IntNT IdistruttoreEqualThis,
StringNT ProvinciaassegnazioneEqualThis, IntNT IdimpresaEqualThis, StringNT CuaaEqualThis,
StringNT RagionesocialeLikeThis, StringNT FiltrostatoistruttoriaEqualThis, BoolNT SelezionataxrevisioneEqualThis)
        {
            VistruttoriaDomandeCollection VistruttoriaDomandeCollectionTemp = VistruttoriaDomandeDAL.Find(_dbProviderObj, IdbandoEqualThis, IdprogettoEqualThis, IdistruttoreEqualThis,
ProvinciaassegnazioneEqualThis, IdimpresaEqualThis, CuaaEqualThis,
RagionesocialeLikeThis, FiltrostatoistruttoriaEqualThis, SelezionataxrevisioneEqualThis);
            return VistruttoriaDomandeCollectionTemp;
        }

        public VistruttoriaDomandeCollection FindIPagamenti(int id_bando, IntNT id_istruttore, IntNT id_progetto, string cod_stato,
            string provincia, string cuaa, string ragsoc, bool CercaPagamenti, bool CercaVarianti,
            bool CercaAdeguamentiTecnici, bool IstruttoriaConclusa, bool IstruttoriaInCorso, bool Annullati)
        {
            VistruttoriaDomandeCollection progetti = new VistruttoriaDomandeCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetIstruttoriaDomandePagamento";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_BANDO", id_bando));
            if (id_istruttore != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_ISTRUTTORE", id_istruttore.Value));
            if (id_progetto != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGETTO", id_progetto.Value));
            if (!string.IsNullOrEmpty(cod_stato)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COD_STATO", cod_stato));
            if (!string.IsNullOrEmpty(provincia)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PROVINCIA", provincia));
            if (!string.IsNullOrEmpty(cuaa)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CUAA", cuaa));
            if (!string.IsNullOrEmpty(ragsoc)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RAGIONE_SOCIALE", ragsoc));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CERCA_PAGAMENTI", CercaPagamenti));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CERCA_VARIANTI", CercaVarianti));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CERCA_ADEGTECNICI", CercaAdeguamentiTecnici));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ISTRUTTORIA_CONCLUSA", IstruttoriaConclusa));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ISTRUTTORIA_IN_CORSO", IstruttoriaInCorso));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ANNULLATI", Annullati));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read()) progetti.Add(VistruttoriaDomandeDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return progetti;
        }

        public VistruttoriaDomandeCollection FindComunicazioni(IntNT id_bando, StringNT cod_tipo_like, IntNT id_progetto, StringNT provincia, StringNT cod_stato)
        {
            VistruttoriaDomandeCollection progetti = new VistruttoriaDomandeCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpFindComunicazioni";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_BANDO", id_bando.Value));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COD_TIPO", cod_tipo_like.Value));
            if (id_progetto != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGETTO", id_progetto.Value));
            if (provincia != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PROVINCIA", provincia.Value));
            if (cod_stato != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COD_STATO", cod_stato.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                VistruttoriaDomande progetto = VistruttoriaDomandeDAL.GetFromDatareader(DbProviderObj);
                progetto.AdditionalAttributes.Add("CodTipoComunicazione", new StringNT(DbProviderObj.DataReader["COD_TIPO_COMUNICAZIONE"]));
                progetto.AdditionalAttributes.Add("SegnaturaComunicazione", new StringNT(DbProviderObj.DataReader["SEGNATURA_COMUNICAZIONE"]));
                progetto.AdditionalAttributes.Add("TipoSegnaturaComunicazione", new StringNT(DbProviderObj.DataReader["TIPO_SEGNATURA_COMUNICAZIONE"]));
                progetti.Add(progetto);
            }
            DbProviderObj.Close();
            return progetti;
        }

        public bool FindAttoXComunicazione(IntNT id_progetto, StringNT cod_stato)
        {
            bool result = false;
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrFindAttoXComunicazione";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGETTO", id_progetto.Value));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COD_STATO", cod_stato.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                if (new IntNT(DbProviderObj.DataReader["RESULT"]) > 0)
                    result = true;
            }
            DbProviderObj.Close();
            return result;
        }
    }
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<vISTRUTTORIA_DOMANDE>
  <ViewName>vISTRUTTORIA_DOMANDE</ViewName>
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
    <Find OrderBy="ORDER BY ID_PROGETTO">
      <ID_BANDO>Equal</ID_BANDO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_ISTRUTTORE>Equal</ID_ISTRUTTORE>
      <PROVINCIA_ASSEGNAZIONE>Equal</PROVINCIA_ASSEGNAZIONE>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <CUAA>Equal</CUAA>
      <RAGIONE_SOCIALE>Like</RAGIONE_SOCIALE>
      <FILTRO_STATO_ISTRUTTORIA>Equal</FILTRO_STATO_ISTRUTTORIA>
      <SELEZIONATA_X_REVISIONE>Equal</SELEZIONATA_X_REVISIONE>
    </Find>
  </Finds>
  <Filters>
    <FiltroIstruttoria>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_ISTRUTTORE>Equal</ID_ISTRUTTORE>
      <PROVINCIA_ASSEGNAZIONE>Equal</PROVINCIA_ASSEGNAZIONE>
      <FILTRO_STATO_ISTRUTTORIA>Equal</FILTRO_STATO_ISTRUTTORIA>
      <CUAA>Equal</CUAA>
      <RAGIONE_SOCIALE>Like</RAGIONE_SOCIALE>
    </FiltroIstruttoria>
  </Filters>
  <externalFields />
  <AddedFkFields />
</vISTRUTTORIA_DOMANDE>
*/