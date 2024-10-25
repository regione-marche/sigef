using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class VldCheckListStepCollectionProvider : IVldCheckListStepProvider
    {
        private string sqlSelect()
        {
            string sSql;

            sSql = @"SELECT cls.ID_VLD_CHECK_LIST,
                           cls.ID_VLD_STEP,
                           cls.Ordine,
                           cls.OBBLIGATORIO,
                           cls.INCLUDI_VERBALE_VIS,
                           s.DESCRIZIONE,
                           s.AUTOMATICO ";

            return sSql;
        }

        private string sqlFrom()
        {
            string sSql;

            sSql = @" FROM Vld_Check_List_Step cls
                           LEFT JOIN
                           Vld_Step s ON cls.Id_Vld_Step = s.Id ";
            return sSql;
        }

        public VldCheckListStepCollection GetAll(string Cod_Tipo, bool Pubblico)
        {
            SiarLibrary.VldCheckListStep rec = null;
            SiarLibrary.VldCheckListStepCollection recs = new VldCheckListStepCollection();

            // Lettura dal db
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlSelect() + sqlFrom();
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                rec = (SiarDAL.VldCheckListStepDAL.GetFromDatareader(dbPro));
                recs.Add(rec);
            }
            dbPro.Close();

            return recs;
        }

        public VldCheckListStepCollection GetBy_TipoPubblico(string cod_Tipo, string tpAppalto)
        {
            string sSql;
            SiarLibrary.VldCheckListStep rec = null;
            SiarLibrary.VldCheckListStepCollection recs = new VldCheckListStepCollection();

            sSql = @" INNER JOIN 
                      Vld_Check_List cl ON cls.ID_VLD_CHECK_LIST = cl.Id 
                      WHERE cl.TPAPPALTO = @tpAppalto 
                        AND cl.COD_TIPO_DPAGAMENTO = @cod_Tipo 
                      ORDER BY cls.Ordine ";
            
            // Lettura dal db
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlSelect() + sqlFrom() + sSql;
            cmd.Parameters.Add(new SqlParameter("@cod_Tipo", cod_Tipo));
            cmd.Parameters.Add(new SqlParameter("@tpAppalto", tpAppalto));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                rec = (SiarDAL.VldCheckListStepDAL.GetFromDatareader(dbPro));
                recs.Add(rec);
            }
            dbPro.Close();

            return recs;
        }

        public bool Get_AziendaPubblica(int id_Domanda_Pagamento)
        {
            bool ret = false;
            string sSql;
            int conteggio = 0;

            sSql = @"SELECT COUNT(1)
                       FROM Domanda_di_Pagamento ddp
                            INNER JOIN
                            Progetto pr ON ddp.Id_Progetto = pr.Id_Progetto
                            INNER JOIN
                            vImpresa vi ON pr.Id_Impresa = vi.Id_Impresa
                     WHERE ddp.Id_Domanda_Pagamento = @id_Domanda_Pagamento
                       AND SUBSTRING(Cod_Forma_Giuridica, 1, 1) = '2'";
            // Lettura dal db
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sSql;
            cmd.Parameters.Add(new SqlParameter("@id_Domanda_Pagamento", id_Domanda_Pagamento));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                conteggio = dbPro.DataReader.GetInt32(0);
            }
            dbPro.Close();

            if (conteggio > 0)
            {
                ret = true;
            }

            return ret;
        }

        public string Get_TpAppalto(int idBando)
        {
            BandoConfigCollectionProvider bndP = new BandoConfigCollectionProvider();
            string tpa = string.Empty;
            string valore;

            valore = bndP.GetBandoConfig_TpAppalto(idBando);

            if (valore == string.Empty)     // Aiuti
            {
                tpa = "AIUTI";
            }
            else if (valore == "01" ||      // Appalti
                     valore == "02" ||
                     valore == "03")
            {
                tpa = "APPAL";
            }
            else                            // Strumenti finanziari
            {
                tpa = "STRFI";
            }


            return tpa;
        }
    }
}
