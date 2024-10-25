using SiarLibrary;
using SiarDAL;
using System.Data;
using SiarLibrary.NullTypes;
using System.Data.SqlClient;

namespace SiarBLL
{
    public partial class VcruscottoBandiRupCollectionProvider
    {
        public VcruscottoBandiRupCollection FindDomande(int id_utente)
        {
            VcruscottoBandiRupCollection cruscotto_bandi = new VcruscottoBandiRupCollection();

            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"SELECT * 
                                FROM VCRUSCOTTO_BANDI_RUP 
                                WHERE 1 = 1 
	                                AND (ID_RUP = @IdUtente 
		                                OR ID_ISTRUTTORE_PROGETTO = @IdUtente 
		                                OR ID_ISTRUTTORE_DOMANDA_PAGAMENTO = @IdUtente) 
                                ORDER BY 
                                    ID_BANDO, 
                                    ID_PROGETTO, 
                                    ID_DOMANDA_PAGAMENTO ";
            cmd.Parameters.Add(new SqlParameter("IdUtente", id_utente));

            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                var f = VcruscottoBandiRupDAL.GetFromDatareader(DbProviderObj);
                cruscotto_bandi.Add(f);
            }

            DbProviderObj.Close();
            return cruscotto_bandi;
        }

        public VcruscottoBandiRupCollection FindDomandeNew(int IdUtente, 
            IntNT IdBando, StringNT StatoBando, 
            IntNT IdProgetto, StringNT StatoProgetto, IntNT IdImpresaProgetto, IntNT IdIstruttoreProgetto,
            IntNT IdDomandaPagamento, StringNT FaseDomandaPagamento, BoolNT AnnullataDomandaPagamento, BoolNT FirmaPredispostaDomandaPagamento)
        {
            VcruscottoBandiRupCollection cruscotto_bandi = new VcruscottoBandiRupCollection();

            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpVCruscottoBandiRupFindDomandeNew";

            cmd.Parameters.Add(new SqlParameter("IdUtente", IdUtente));

            if (IdBando != null)
                cmd.Parameters.Add(new SqlParameter("IdBando", IdBando.Value));
            if (StatoBando != null)
                cmd.Parameters.Add(new SqlParameter("StatoBando", StatoBando.Value));

            if (IdProgetto != null)
                cmd.Parameters.Add(new SqlParameter("IdProgetto", IdProgetto.Value));
            if (StatoProgetto != null)
                cmd.Parameters.Add(new SqlParameter("StatoProgetto", StatoProgetto.Value));
            if (IdImpresaProgetto != null)
                cmd.Parameters.Add(new SqlParameter("IdImpresaProgetto", IdImpresaProgetto.Value));
            if (IdIstruttoreProgetto != null)
                cmd.Parameters.Add(new SqlParameter("IdIstruttoreProgetto", IdIstruttoreProgetto.Value));

            if (IdDomandaPagamento != null)
                cmd.Parameters.Add(new SqlParameter("IdDomandaPagamento", IdDomandaPagamento.Value));
            if (FaseDomandaPagamento != null)
                cmd.Parameters.Add(new SqlParameter("FaseDomandaPagamento", FaseDomandaPagamento.Value));
            if (AnnullataDomandaPagamento != null)
                cmd.Parameters.Add(new SqlParameter("AnnullataDomandaPagamento", AnnullataDomandaPagamento.Value));
            if (FirmaPredispostaDomandaPagamento != null)
                cmd.Parameters.Add(new SqlParameter("FirmaPredispostaDomandaPagamento", FirmaPredispostaDomandaPagamento.Value));

            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                var f = VcruscottoBandiRupDAL.GetFromDatareader(DbProviderObj);
                cruscotto_bandi.Add(f);
            }

            DbProviderObj.Close();
            return cruscotto_bandi;
        }
    }
}
