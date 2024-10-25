using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class VariantiCollectionProvider : IVariantiProvider
    {
        public VariantiCollection FindDecretiApprovazione(IntNT IdBando, IntNT IdProgetto, BoolNT Approvate, BoolNT NascondiDecretiRegistrati)
        {
            VariantiCollection vv = new VariantiCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetDecretiVarianti";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_BANDO", IdBando.Value));
            if (IdProgetto != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGETTO", IdProgetto.Value));
            if (Approvate != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@APPROVATA", Approvate.Value));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NASCONDI_DECRETI_REGISTRATI", NascondiDecretiRegistrati.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                Varianti v = new Varianti();
                v.IdVariante = new IntNT(DbProviderObj.DataReader["ID_VARIANTE"]);
                v.CodTipo = new StringNT(DbProviderObj.DataReader["COD_TIPO"]);
                v.IdProgetto = new IntNT(DbProviderObj.DataReader["ID_PROGETTO"]);
                v.Descrizione = new StringNT(DbProviderObj.DataReader["DESCRIZIONE"]);
                v.Approvata = new BoolNT(DbProviderObj.DataReader["APPROVATA"]);
                v.Segnatura = new StringNT(DbProviderObj.DataReader["SEGNATURA"]);
                v.SegnaturaApprovazione = new StringNT(DbProviderObj.DataReader["SEGNATURA_APPROVAZIONE"]);
                v.IdAttoApprovazione = new IntNT(DbProviderObj.DataReader["ID_ATTO_APPROVAZIONE"]);
                v.CodDefinizione = new StringNT(DbProviderObj.DataReader["COD_DEFINIZIONE"]);
                v.AwDocnumber = new StringNT(DbProviderObj.DataReader["AW_DOCNUMBER"]);
                v.AwDocnumberNuovo = new IntNT(DbProviderObj.DataReader["AW_DOCNUMBER_NUOVO"]);
                v.AdditionalAttributes.Add("NUMERO_DECRETO", new IntNT(DbProviderObj.DataReader["NUMERO_DECRETO"]));
                v.AdditionalAttributes.Add("DATA_DECRETO", new DatetimeNT(DbProviderObj.DataReader["DATA_DECRETO"]));
                vv.Add(v);
            }
            DbProviderObj.Close();
            return vv;
        }

        public int DuplicaContributoInvestimentiVariante(IntNT IdVariante)
        {
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpTriggerDuplicaContributoInvestimentiVariante";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_VARIANTE", IdVariante.Value));
            int retval = DbProviderObj.Execute(cmd);
            DbProviderObj.Close();
            return retval;
        }

        public void AggiornaVariante(Varianti v, Operatore op)
        {
            try
            {
                v.Operatore = op.Utente.CfUtente;
                v.DataModifica = DateTime.Now;
                v.CodEnte = op.Utente.CodEnte;
                Save(v);
            }
            catch { throw; }
        }

        public void AggiornaVarianteIstruttoria(Varianti v, Operatore op)
        {
            try
            {
                v.Istruttore = op.Utente.CfUtente;
                v.DataApprovazione = DateTime.Now;
                v.NominativoIstruttore = op.Utente.Nominativo;
                Save(v);

            }
            catch { throw; }
        }
    }
}
