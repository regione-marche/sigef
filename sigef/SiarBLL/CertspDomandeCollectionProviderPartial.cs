using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class CertspDomandeCollectionProvider : ICertspDomandeProvider
    {
        private string sqlSelect()
        {
            string str = @"SELECT  Id_Domanda,
                                   Id_Atto,
                                   Data_Pres,
                                   Spese_Amm,
                                   Spesa_Pubb,
                                   SF_Tot,
                                   SF_Spesa_Pubb,
                                   SF_Spese_Amm,
                                   SF_Spesa_Pubb_Amm,
                                   AS_Tot,
                                   AS_Coperto,
                                   AS_Non_Coperto ";
            return str;
        }

        private string sqlFrom()
        {
            string str = @" FROM CertSp_Domande ";

            return str;
        }

        public CertspDomandeCollection getAll()
        {
            SiarLibrary.CertspDomande dom = null;
            SiarLibrary.CertspDomandeCollection doms = new CertspDomandeCollection();

            // Lettura dal db
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlSelect() + sqlFrom();
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                dom = (SiarDAL.CertspDomandeDAL.GetFromDatareader(dbPro));
                doms.Add(dom);
            }
            dbPro.Close();

            return doms;
        }
    }
}