using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class VriepilogoDomandeAiutoDownloadMassivoCollectionProvider
    {
        public VriepilogoDomandeAiutoDownloadMassivoCollection GetRiepilogoDomandeAiutoDownloadMassivo(IntNT idProgetto, StringNT cfUtente)
        {
            VriepilogoDomandeAiutoDownloadMassivoCollection riepilogo = new VriepilogoDomandeAiutoDownloadMassivoCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpRiepilogoDomandeAiutoDownloadMassivo";
            if (idProgetto != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", idProgetto.Value));
            if (cfUtente != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("CF_UTENTE", cfUtente.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                VriepilogoDomandeAiutoDownloadMassivo v = new VriepilogoDomandeAiutoDownloadMassivo();
                v.IdProgetto = new IntNT(DbProviderObj.DataReader["ID_PROGETTO"]);                
                v.RagioneSociale = new StringNT(DbProviderObj.DataReader["RAGIONE_SOCIALE"]);
                v.Cuaa = new StringNT(DbProviderObj.DataReader["CUAA"]);
                v.Segnatura = new StringNT(DbProviderObj.DataReader["SEGNATURA"]);
                v.CfOperatore = new StringNT(DbProviderObj.DataReader["CF_OPERATORE"]);
                v.Eseguito = new BoolNT(DbProviderObj.DataReader["ESEGUITO"]);
                v.IdTicket = new IntNT(DbProviderObj.DataReader["ID_TICKET"]);
                v.DimensioneFile = new DecimalNT(DbProviderObj.DataReader["DIMENSIONE_FILE"]);
                v.DataFineEstrazione = new DatetimeNT(DbProviderObj.DataReader["DATA_FINE_ESTRAZIONE"]);
                riepilogo.Add(v);
            }
            DbProviderObj.Close();
            return riepilogo;
        }
    }
}
