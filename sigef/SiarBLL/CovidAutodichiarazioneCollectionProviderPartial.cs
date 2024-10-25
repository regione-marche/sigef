using System;
using SiarLibrary.NullTypes;
using SiarLibrary;
using SiarDAL;
using SiarBLL;
using System.Data;

namespace SiarBLL
{
    public partial class CovidAutodichiarazioneCollectionProvider : ICovidAutodichiarazioneProvider
    {
        public CovidAutodichiarazioneCollection RicercaAmministratori(IntNT id_autodichiarazione, string ragione_sociale, string piva, string cf, IntNT id_bando, string descrizione_bando)
        {
            CovidAutodichiarazioneCollection autodichiarazioneCollection = new CovidAutodichiarazioneCollection();
            CovidAutodichiarazione autodichiarazione;

            DbProvider db = DbProviderObj;
            IDbCommand cmd = db.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpRicercaPreDomandeAmministratori";

            if (id_autodichiarazione != null) 
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IdAutodichiarazione", id_autodichiarazione.Value));
            if (!string.IsNullOrEmpty(ragione_sociale)) 
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RagioneSociale", ragione_sociale));
            if (!string.IsNullOrEmpty(piva))
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PartitaIva", piva));
            if (!string.IsNullOrEmpty(cf))
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CodiceFiscale", cf));
            if (id_bando != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IdBando", id_bando.Value));
            if (!string.IsNullOrEmpty(descrizione_bando))
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DescrizioneBando", descrizione_bando));

            db.InitDatareader(cmd);
            while (db.DataReader.Read())
            {
                autodichiarazione = CovidAutodichiarazioneDAL.GetFromDatareader(db);
                autodichiarazioneCollection.Add(autodichiarazione);
            }

            db.Close();

            return autodichiarazioneCollection;
        }
    }
}
