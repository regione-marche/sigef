using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class SpecificaInvestimentiCollectionProvider : ISpecificaInvestimentiProvider
    {
        public SpecificaInvestimentiCollection FindByIdBando(int id_bando, IntNT IdDettaglioInvestimento)
        {
            SpecificaInvestimentiCollection cc = new SpecificaInvestimentiCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = @"SELECT S.* FROM SPECIFICA_INVESTIMENTI S INNER JOIN DETTAGLIO_INVESTIMENTI D 
                                ON S.ID_DETTAGLIO_INVESTIMENTO=D.ID_DETTAGLIO_INVESTIMENTO INNER JOIN CODIFICA_INVESTIMENTO C 
                                ON D.ID_CODIFICA_INVESTIMENTO=C.ID_CODIFICA_INVESTIMENTO WHERE ID_BANDO=" + id_bando
                                + (IdDettaglioInvestimento != null ? " AND S.ID_DETTAGLIO_INVESTIMENTO=" + IdDettaglioInvestimento : "");
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read()) cc.Add(SpecificaInvestimentiDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return cc;
        }
    }
}
