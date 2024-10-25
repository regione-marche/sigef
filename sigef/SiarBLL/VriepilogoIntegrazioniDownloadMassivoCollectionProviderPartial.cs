using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
	public partial class VriepilogoIntegrazioniDownloadMassivoCollectionProvider
	{
        public VriepilogoIntegrazioniDownloadMassivoCollection GetRiepilogoIntegrazioniDownloadMassivo(IntNT idProgetto, StringNT cfUtente)
        {
            VriepilogoIntegrazioniDownloadMassivoCollection riepilogo = new VriepilogoIntegrazioniDownloadMassivoCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpRiepilogoIntegrazioniDownloadMassivo";
            if (idProgetto != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", idProgetto.Value));
            if (cfUtente != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("CF_UTENTE", cfUtente.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                VriepilogoIntegrazioniDownloadMassivo v = new VriepilogoIntegrazioniDownloadMassivo();
                v.IdProgetto = new IntNT(DbProviderObj.DataReader["ID_PROGETTO"]);
                v.IdDomandaPagamento = new IntNT(DbProviderObj.DataReader["ID_DOMANDA_PAGAMENTO"]);
                v.Descrizione = new StringNT(DbProviderObj.DataReader["DESCRIZIONE"]);
                v.IdIntegrazioneDomandaDiPagamento = new IntNT(DbProviderObj.DataReader["ID_INTEGRAZIONE_DOMANDA_DI_PAGAMENTO"]);
                v.SegnaturaBeneficiario = new StringNT(DbProviderObj.DataReader["SEGNATURA_BENEFICIARIO"]);
                v.CfOperatore = new StringNT(DbProviderObj.DataReader["CF_OPERATORE"]);
                v.Eseguito = new BoolNT(DbProviderObj.DataReader["ESEGUITO"]);
                v.IdTicket = new IntNT(DbProviderObj.DataReader["ID_TICKET"]);
                v.DimensioneFile = new DecimalNT(DbProviderObj.DataReader["DIMENSIONE_FILE"]);
                v.DataFineEstrazione = new DatetimeNT(DbProviderObj.DataReader["DATA_FINE_ESTRAZIONE"]);
                riepilogo.Add(v);
            }
            DbProviderObj.Close();
            return riepilogo;
        }
    }
}