using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;


namespace SiarBLL
{

    public partial class CertspContiCollectionProvider : ICertspContiProvider
    {
        private string sqlSelect()
        {
            string str = @"SELECT ID_CONTO,
                                    ID_PROGETTO,
                                    ID_ATTO,
                                    DATA_PRES_CONTAB,
                                    DATA_PRES_CONTI,
                                    TOT_REGISTRATE,
                                    TOT_SPESAPUB_REGISTRATE,
                                    TOT_PAGAMENTI_REGISTRATE,
                                    TOT_RITIRATA,
                                    TOT_SPESAPUB_RITIRATA,
                                    TOT_RECUPERATA,
                                    TOT_SPESAPUB_RECUPERATA,
                                    TOT_DARECUPERARE,
                                    TOT_SPESAPUB_DARECUPERARE,
                                    RECUPERATO_ART71,
                                    TOT_NONRECUPERAB,
                                    TOT_SPESAPUB_NONRECUPERAB,
                                    RECUPERATO_ART71_PUBBLICA ";
            return str;
        }

        private string sqlFrom()
        {
            string str = @" FROM CertSp_Conti ";

            return str;
        }

        public CertspContiCollection getAll()
        {
            SiarLibrary.CertspConti rec = null;
            SiarLibrary.CertspContiCollection recs = new CertspContiCollection();

            // Lettura dal db
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlSelect() + sqlFrom();
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                rec = (SiarDAL.CertspContiDAL.GetFromDatareader(dbPro));
                recs.Add(rec);
            }
            dbPro.Close();

            return recs;
        }
    }
}

