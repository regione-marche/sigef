using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
	public partial class ProgettoComunicazioneCollectionProvider : IProgettoComunicazioneProvider
	{
        public ProgettoComunicazioneCollection GetComunicazioniOrdinate(int id_progetto)
        {
            ProgettoComunicazioneCollection comunicazioni = new ProgettoComunicazioneCollection();
            DbProvider db = DbProviderObj;
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetComunicazioniOrdinate";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", id_progetto));
            db.InitDatareader(cmd);
            while (db.DataReader.Read()) comunicazioni.Add(SiarDAL.ProgettoComunicazioneDAL.GetFromDatareader(db));
            db.Close();
            return comunicazioni;
        }

        public ProgettoComunicazioneCollection FindRichiesteAccessoAtti(int id_utente)
        {
            ProgettoComunicazioneCollection comunicazioni = new ProgettoComunicazioneCollection();
            DbProvider db = DbProviderObj;
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetRichiesteAccessoAtti";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_UTENTE", id_utente));
            db.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                SiarLibrary.ProgettoComunicazione c = SiarDAL.ProgettoComunicazioneDAL.GetFromDatareader(DbProviderObj);
                c.AdditionalAttributes.Add("ID_BANDO", new IntNT(DbProviderObj.DataReader["ID_BANDO"]));
                c.AdditionalAttributes.Add("DESCRIZIONE_BANDO", new StringNT(DbProviderObj.DataReader["DESCRIZIONE_BANDO"]));
                c.AdditionalAttributes.Add("COD_ENTE", new StringNT(DbProviderObj.DataReader["COD_ENTE"]));
                c.AdditionalAttributes.Add("ID_UTENTE", new IntNT(DbProviderObj.DataReader["ID_UTENTE"]));
                comunicazioni.Add(c);
            }
            db.Close();
            return comunicazioni;
        }

        public ArchivioFileCollection GetFileXProtocollazioneNoStream(int id_comunicazione, int id_progetto)
        {
            ArchivioFileCollection cc = new ArchivioFileCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpProgettoComunicazioniFileXProtocollazione";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_COMUNICAZIONE", id_comunicazione));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", id_progetto));
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
<PROGETTO_COMUNICAZIONE>
  <ViewName>vPROGETTO_COMUNICAZIONE</ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
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
      <COD_TIPO>Equal</COD_TIPO>
      <OPERATORE>Equal</OPERATORE>
      <SEGNATURA>Equal</SEGNATURA>
      <SEGNATURA_ESTERNA>Equal</SEGNATURA_ESTERNA>
      <IN_ENTRATA>Equal</IN_ENTRATA>
    </Find>
  </Finds>
  <Filters>
    <Filter>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <COD_TIPO>Equal</COD_TIPO>
      <OPERATORE>Equal</OPERATORE>
      <SEGNATURA>Equal</SEGNATURA>
      <SEGNATURA_ESTERNA>Equal</SEGNATURA_ESTERNA>
      <IN_ENTRATA>Equal</IN_ENTRATA>
    </Filter>
  </Filters>
  <externalFields />
  <AddedFkFields />
</PROGETTO_COMUNICAZIONE>
*/
