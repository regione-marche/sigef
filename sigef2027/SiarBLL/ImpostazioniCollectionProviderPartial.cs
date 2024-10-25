using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;
using System.Data;
using System;

namespace SiarBLL
{
    public partial class ImpostazioniCollectionProvider : IImpostazioniProvider
    {
        public BoolNT GetIngressiContingentatiAbilitati(string istanza)
        {
            BoolNT abilitato = false;

            DbProvider db = DbProviderObj;
            IDbCommand cmd = db.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpGetIngressiContingentatiAbilitati";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Istanza", istanza));

            object result = db.ExecuteScalar(cmd);
            db.Close();

            if (result == null)
                abilitato = null; //errore generico
            else
                abilitato = result.ToString();

            return abilitato;
        }

        public int GetIngressiContingentatiUtentiMax(string istanza)
        {
            int utenti = 0;

            DbProvider db = DbProviderObj;
            IDbCommand cmd = db.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpGetIngressiContingentatiUtentiMax";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Istanza", istanza));

            object result = db.ExecuteScalar(cmd);
            db.Close();

            if (result == null || !int.TryParse(result.ToString(), out utenti))
                utenti = -1; //errore generico

            return utenti;
        }
    }
}
