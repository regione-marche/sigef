using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

    public partial class CertspRecuperiCollectionProvider : ICertspRecuperiProvider
    {
        private string sqlSelect()
        {
             string str = @"SELECT  Id_Recupero,
                                    Id_Progetto,
                                    Id_Atto,
                                    Sostegno,
                                    Spese_Amm,
                                    Data_Ricev_Rimb,
                                    Rimb_Sostegno,
                                    Rimb_Spese_Amm,
                                    NonR_Sostegno,
                                    NonR_Spese_Amm ";
            return str;
        }

        private string sqlFrom()
        {
            string str = @" FROM CertSp_Recuperi ";
            
            return str;
        }

        public CertspRecuperiCollection getAll()
        {
            SiarLibrary.CertspRecuperi rec = null;
            SiarLibrary.CertspRecuperiCollection recs = new CertspRecuperiCollection();

            // Lettura dal db
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlSelect() + sqlFrom();
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                rec = (SiarDAL.CertspRecuperiDAL.GetFromDatareader(dbPro));
                recs.Add(rec);
            }
            dbPro.Close();

            return recs;
        }
    }
}
