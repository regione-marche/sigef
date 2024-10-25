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
    public partial class BandoComuniLocalizzazioniCollectionProvider : IBandoComuniLocalizzazioniProvider
    {
        public BandoComuniLocalizzazioniCollection GetBandoComuniLocalizzazione(int id_bando, bool cratere, string prov, string denominazione)
        {
            BandoComuniLocalizzazioniCollection bc = new BandoComuniLocalizzazioniCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpGetComuniLocalizzazioneBando";
            cmd.Parameters.Add(new SqlParameter("@ID_BANDO", id_bando));
            cmd.Parameters.Add(new SqlParameter("@CRATERE", cratere));
            if (!string.IsNullOrEmpty(prov)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PROV", prov));
            if (!string.IsNullOrEmpty(denominazione)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DENOMINAZIONE", denominazione));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read()) bc.Add(SiarDAL.BandoComuniLocalizzazioniDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return bc;
        }

    }
}