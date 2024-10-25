using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;


namespace SiarBLL
{
    public partial class VcruscottoVariantiCollectionProvider
    {
        public VcruscottoVariantiCollection GetByIdUtente(int id_utente)
        {
            VcruscottoVariantiCollection cruscotto_domande = new VcruscottoVariantiCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpCruscottoGetVarianti";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("IdUtente", id_utente));

            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                VcruscottoVarianti f = SiarDAL.VcruscottoVariantiDAL.GetFromDatareader(DbProviderObj);
                cruscotto_domande.Add(f);
            }

            DbProviderObj.Close();
            return cruscotto_domande;
        }
    }
}
