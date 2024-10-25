using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;

namespace SiarBLL
{
    public partial class BandoAteco2007CollectionProvider : IBandoAteco2007Provider
    {
        public BandoAteco2007Collection GetBandoAteco(int id_bando, string sezione,bool gruppo, bool classe, bool categoria, bool sottocategoria,string ateco)
        {
            BandoAteco2007Collection ba = new BandoAteco2007Collection();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpGetCodicAtecoBando";
            cmd.Parameters.Add(new SqlParameter("@ID_BANDO", id_bando));
            cmd.Parameters.Add(new SqlParameter("@GRUPPO", gruppo));
            cmd.Parameters.Add(new SqlParameter("@CLASSE", classe));
            cmd.Parameters.Add(new SqlParameter("@CATEGORIA", categoria));
            cmd.Parameters.Add(new SqlParameter("@SOTTOCATEGORIA", sottocategoria));
            if (!string.IsNullOrEmpty(sezione)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SEZIONE", sezione));
            if (!string.IsNullOrEmpty(ateco)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ATECO", ateco));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read()) ba.Add(SiarDAL.BandoAteco2007DAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return ba;
        }

    }
}