using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;
using System.Data;
using System.Data.SqlClient;

namespace SiarBLL
{
    public partial class EsitoIstanzaChecklistGenericoCollectionProvider : IEsitoIstanzaChecklistGenericoProvider
    {
       
        public string VerificaCheckListDomandaDiAiuto(IntNT IdProgetto, IntNT IdDomandaPagamento, StringNT CodFase, StringNT Operatore) 
        {
            /*
             * //su IterProgettoCollectionProvider è così
           try
           {
               System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
               cmd.CommandType = System.Data.CommandType.StoredProcedure;
               cmd.CommandText = "SpVerificaCheckListDomandaDiAiuto";
               cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", IdProgetto.Value));
               if (IdDomandaPagamento != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_DOMANDA_PAGAMENTO", IdDomandaPagamento.Value));
               cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_FASE", CodFase.Value));
               cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("OPERATORE", Operatore.Value));

               System.Data.SqlClient.SqlParameter p_out = new System.Data.SqlClient.SqlParameter();
               p_out.Direction = System.Data.ParameterDirection.ReturnValue;
               cmd.Parameters.Add(p_out);

               int result = DbProviderObj.Execute(cmd);
               DbProviderObj.Close();
               // 1: verificata, altrimenti no
               int esito_checklist;
               if (p_out.Value == null || !int.TryParse(p_out.Value.ToString(), out esito_checklist)) throw new Exception("errore");
               return (esito_checklist == 1 ? "SI" : "NO");
           }
           catch { throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.GenericoConLink); }
           */

            throw new Exception("Metodo non ancora controllato!");
        }

        public EsitoIstanzaChecklistGenericoCollection FindEsitiSenzaTitoli(IntNT IdistanzagenericaEqualThis, IntNT IdvocegenericaEqualThis, StringNT CodesitoEqualThis,
StringNT CodesitorevisoreEqualThis, IntNT IdchecklistgenericaEqualThis)
        {
            EsitoIstanzaChecklistGenericoCollection esiti_coll = new EsitoIstanzaChecklistGenericoCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpFindEsitiSenzaTitoli";
            
            if (IdistanzagenericaEqualThis != null)
                cmd.Parameters.Add(new SqlParameter("@IdIstanzaGenericaequalthis", IdistanzagenericaEqualThis.Value));
            if (IdvocegenericaEqualThis != null)
                cmd.Parameters.Add(new SqlParameter("@IdVoceGenericaequalthis", IdvocegenericaEqualThis.Value));
            if (CodesitoEqualThis != null)
                cmd.Parameters.Add(new SqlParameter("@CodEsitoequalthis", CodesitoEqualThis));
            if (CodesitorevisoreEqualThis != null)
                cmd.Parameters.Add(new SqlParameter("@CodEsitoRevisoreequalthis", CodesitorevisoreEqualThis));
            if (IdchecklistgenericaEqualThis != null)
                cmd.Parameters.Add(new SqlParameter("@IdChecklistGenericaequalthis", IdchecklistgenericaEqualThis.Value));
            
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
                esiti_coll.Add(EsitoIstanzaChecklistGenericoDAL.GetFromDatareader(DbProviderObj));
            
            DbProviderObj.Close();
            
            return esiti_coll;
        }
    }
}
