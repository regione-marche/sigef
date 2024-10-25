using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;
using System.Collections.Generic;

namespace SiarBLL
{
    public partial class NewsCollectionProvider : INewsProvider
    {
        public NewsCollection GetUltimeNews(int numero_ultime_news)
        {
            var news_coll = new NewsCollection();
            var NewsObj = new News();

            string strSql =
                String.Format(@"SELECT TOP " + numero_ultime_news + " * FROM NEWS ORDER BY DATA DESC");

            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            dbPro.InitDatareader(cmd);

            while (dbPro.DataReader.Read())
            {
                NewsObj = new News();
                NewsObj.IdNews = new IntNT(dbPro.DataReader["ID_NEWS"]);
                NewsObj.Titolo = new StringNT(dbPro.DataReader["TITOLO"]);
                NewsObj.Testo = new StringNT(dbPro.DataReader["TESTO"]);
                NewsObj.Url = new StringNT(dbPro.DataReader["URL"]);
                NewsObj.Data = new DatetimeNT(dbPro.DataReader["DATA"]);
                NewsObj.Operatore = new StringNT(dbPro.DataReader["OPERATORE"]);
                NewsObj.InterruzioneSistema = new BoolNT(dbPro.DataReader["INTERRUZIONE_SISTEMA"]);
                NewsObj.DataInizio = new DatetimeNT(dbPro.DataReader["DATA_INIZIO"]);
                NewsObj.DataFine = new DatetimeNT(dbPro.DataReader["DATA_FINE"]);

                news_coll.Add(NewsObj);
            }
            dbPro.Close();

            return news_coll;
        }
    }
}
