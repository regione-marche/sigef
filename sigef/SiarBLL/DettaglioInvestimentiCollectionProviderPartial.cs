using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class DettaglioInvestimentiCollectionProvider : IDettaglioInvestimentiProvider
    {
        public DettaglioInvestimentiCollection FindByIdBando(int id_bando, IntNT IdCodificaInvestimento)
        {
            DettaglioInvestimentiCollection dettaglio_investimenti_bando = new DettaglioInvestimentiCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = @"SELECT D.*,U.DESCRIZIONE AS UNITA_DI_MISURA FROM DETTAGLIO_INVESTIMENTI D 
                                INNER JOIN CODIFICA_INVESTIMENTO C ON D.ID_CODIFICA_INVESTIMENTO=C.ID_CODIFICA_INVESTIMENTO
                                LEFT JOIN UNITA_DI_MISURA U ON D.ID_UDM=U.ID_UNITA_MISURA WHERE ID_BANDO=@ID_BANDO"
                                + (IdCodificaInvestimento != null ? " AND D.ID_CODIFICA_INVESTIMENTO=@ID_CODIFICA_INVESTIMENTO" : "");
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_BANDO", id_bando));
            if (IdCodificaInvestimento != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_CODIFICA_INVESTIMENTO", IdCodificaInvestimento.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                DettaglioInvestimenti d = DettaglioInvestimentiDAL.GetFromDatareader(DbProviderObj);
                d.AdditionalAttributes.Add("UNITA_DI_MISURA", new StringNT(DbProviderObj.DataReader["UNITA_DI_MISURA"]));
                dettaglio_investimenti_bando.Add(d);
            }
            DbProviderObj.Close();
            return dettaglio_investimenti_bando;
        }
    }
}
