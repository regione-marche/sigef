using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class BandoTipoInvestimentiCollectionProvider : IBandoTipoInvestimentiProvider
    {
        public BandoTipoInvestimentiCollection GetTipoInvestimentiBando(int id_bando)
        {
            BandoTipoInvestimentiCollection cc = new BandoTipoInvestimentiCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGetTipoInvestimentiBando";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_BANDO", id_bando));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read()) cc.Add(SiarDAL.BandoTipoInvestimentiDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return cc;
        }

        public BandoTipoInvestimentiCollection GetTipoInvestimentiProgetto(int id_bando, bool mostra_tutti)
        {
            BandoTipoInvestimentiCollection cc = new BandoTipoInvestimentiCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGetTipoInvestimentiProgetto";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_BANDO", id_bando));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MOSTRA_TUTTI", mostra_tutti));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                BandoTipoInvestimenti t = new BandoTipoInvestimenti();
                t.CodTipoInvestimento = new IntNT(DbProviderObj.DataReader["COD_TIPO_INVESTIMENTO"]);
                t.Descrizione = new StringNT(DbProviderObj.DataReader["DESCRIZIONE"]);
                t.Url = new StringNT(DbProviderObj.DataReader["URL"]);
                t.Text = new StringNT(DbProviderObj.DataReader["TEXT"]);
                cc.Add(t);
            }
            DbProviderObj.Close();
            return cc;
        }
    }
}
