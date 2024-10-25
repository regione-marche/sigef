using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;


namespace SiarBLL
{
    public partial class ProgettoValutazioneCollectionProvider : IProgettoValutazioneProvider
    {
        public ArchivioFileCollection GetFileXProtocollazioneNoStreamValutazione(int id_valutazione)
        {
            ArchivioFileCollection cc = new ArchivioFileCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpProgettoValutazioneFileXProtocollazione";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_VALUTAZIONE", id_valutazione));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                ArchivioFile f = new ArchivioFile();
                f.Id = (int)DbProviderObj.DataReader["ID_FILE"];
                f.Tipo = new SiarLibrary.NullTypes.StringNT(DbProviderObj.DataReader["TIPO"]); // ESTENSIONE
                f.NomeFile = new SiarLibrary.NullTypes.StringNT(DbProviderObj.DataReader["NOME_FILE_EFFETTIVO"]);
                f.NomeCompleto = new SiarLibrary.NullTypes.StringNT(DbProviderObj.DataReader["NOME_FILE"]);
                f.HashCode = new SiarLibrary.NullTypes.StringNT(DbProviderObj.DataReader["HASH_CODE"]);
                cc.Add(f);
            }
            DbProviderObj.Close();
            return cc;
        }
    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PROGETTO_VALUTAZIONE>
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
    <Find OrderBy="ORDER BY ">
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_VARIANTE>Equal</ID_VARIANTE>
      <ID_VARIANTE>IsNull</ID_VARIANTE>
      <OPERATORE>Equal</OPERATORE>
      <ANNULLATO>Equal</ANNULLATO>
    </Find>
  </Finds>
  <Filters>
    <Filter>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <OPERATORE>Equal</OPERATORE>
      <ANNULLATO>Equal</ANNULLATO>
    </Filter>
  </Filters>
  <externalFields />
  <AddedFkFields />
</PROGETTO_VALUTAZIONE>
*/
