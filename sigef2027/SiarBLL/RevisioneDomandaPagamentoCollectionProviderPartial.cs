using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class RevisioneDomandaPagamentoCollectionProvider : IRevisioneDomandaPagamentoProvider
    {
        public RevisioneDomandaPagamentoCollection FindByLottoApprovata(int IdLottoEqualThis, bool? ApprovataNotEqualThis)
        {
            RevisioneDomandaPagamentoCollection RevisioneDomandaPagamentoCollectionObj = new RevisioneDomandaPagamentoCollection();
            DbProvider db = DbProviderObj;
            IDbCommand cmd = db.GetCommand();
            RevisioneDomandaPagamento RevisioneDomandaPagamentoObj;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "Zrevisionedomandapagamentofindfindbylottoapprovata";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("IdLottoequalthis", IdLottoEqualThis));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("Approvatanotequalthis", ApprovataNotEqualThis));
            db.InitDatareader(cmd);
            while (db.DataReader.Read())
            {
                RevisioneDomandaPagamentoObj = RevisioneDomandaPagamentoDAL.GetFromDatareader(db);
                RevisioneDomandaPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                RevisioneDomandaPagamentoObj.IsDirty = false;
                RevisioneDomandaPagamentoObj.IsPersistent = true;
                RevisioneDomandaPagamentoCollectionObj.Add(RevisioneDomandaPagamentoObj);
            }
            db.Close();
            return RevisioneDomandaPagamentoCollectionObj;
        }

        public RevisioneDomandaPagamentoCollection GetRevisioneDomandeRup(int id_utente_rup, IntNT id_bando, IntNT id_progetto, IntNT id_domanda_pagamento)
        {
            RevisioneDomandaPagamentoCollection rdp = new RevisioneDomandaPagamentoCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGetRevisioneDomandeRup";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_UTENTE", id_utente_rup));
            if (id_bando != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_BANDO", id_bando.Value));
            if (id_progetto != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", id_progetto.Value));
            if (id_domanda_pagamento != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_DOMANDA_PAGAMENTO", id_domanda_pagamento.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                RevisioneDomandaPagamento r = RevisioneDomandaPagamentoDAL.GetFromDatareader(DbProviderObj);
                r.AdditionalAttributes.Add("DESCRIZIONE", new StringNT(DbProviderObj.DataReader["DESCRIZIONE"]));
                rdp.Add(r);
            }
            DbProviderObj.Close();
            return rdp;
        }

        public RevisioneDomandaPagamentoCollection GetRevisioneDomandeValidatore(string cf_validatore, IntNT id_bando, IntNT id_progetto, IntNT id_domanda_pagamento)
        {
            RevisioneDomandaPagamentoCollection rdp = new RevisioneDomandaPagamentoCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGetRevisioneDomandeValidatore";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("CF_VALIDATORE", cf_validatore));
            if (id_bando != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_BANDO", id_bando.Value));
            if (id_progetto != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", id_progetto.Value));
            if (id_domanda_pagamento != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_DOMANDA_PAGAMENTO", id_domanda_pagamento.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                RevisioneDomandaPagamento r = RevisioneDomandaPagamentoDAL.GetFromDatareader(DbProviderObj);
                r.AdditionalAttributes.Add("DESCRIZIONE", new StringNT(DbProviderObj.DataReader["DESCRIZIONE"]));
                rdp.Add(r);
            }
            DbProviderObj.Close();
            return rdp;
        }

        public RevisioneDomandaPagamentoCollection GetRevisioneDomandeGenerico(IntNT id_progetto, IntNT id_domanda_pagamento)
        {
            RevisioneDomandaPagamentoCollection rdp = new RevisioneDomandaPagamentoCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGetRevisioneDomandeGenerico";
            if (id_progetto != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", id_progetto.Value));
            if (id_domanda_pagamento != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_DOMANDA_PAGAMENTO", id_domanda_pagamento.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                RevisioneDomandaPagamento r = RevisioneDomandaPagamentoDAL.GetFromDatareader(DbProviderObj);
                r.AdditionalAttributes.Add("DESCRIZIONE", new StringNT(DbProviderObj.DataReader["DESCRIZIONE"]));
                rdp.Add(r);
            }
            DbProviderObj.Close();
            return rdp;
        }

        public RevisioneDomandaPagamentoCollection GetRevisioneDomandeRupFem(int id_utente_rup, IntNT id_bando, IntNT id_progetto, IntNT id_domanda_pagamento)
        {
            RevisioneDomandaPagamentoCollection rdp = new RevisioneDomandaPagamentoCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGetRevisioneDomandeRupFem";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_UTENTE", id_utente_rup));
            if (id_bando != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_BANDO", id_bando.Value));
            if (id_progetto != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", id_progetto.Value));
            if (id_domanda_pagamento != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_DOMANDA_PAGAMENTO", id_domanda_pagamento.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                RevisioneDomandaPagamento r = RevisioneDomandaPagamentoDAL.GetFromDatareader(DbProviderObj);
                r.AdditionalAttributes.Add("DESCRIZIONE", new StringNT(DbProviderObj.DataReader["DESCRIZIONE"]));
                rdp.Add(r);
            }
            DbProviderObj.Close();
            return rdp;
        }

        public RevisioneDomandaPagamentoCollection GetRevisioneDomandeValidatoreFem(string cf_validatore, IntNT id_bando, IntNT id_progetto, IntNT id_domanda_pagamento)
        {
            RevisioneDomandaPagamentoCollection rdp = new RevisioneDomandaPagamentoCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGetRevisioneDomandeValidatoreFem";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("CF_VALIDATORE", cf_validatore));
            if (id_bando != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_BANDO", id_bando.Value));
            if (id_progetto != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", id_progetto.Value));
            if (id_domanda_pagamento != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_DOMANDA_PAGAMENTO", id_domanda_pagamento.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                RevisioneDomandaPagamento r = RevisioneDomandaPagamentoDAL.GetFromDatareader(DbProviderObj);
                r.AdditionalAttributes.Add("DESCRIZIONE", new StringNT(DbProviderObj.DataReader["DESCRIZIONE"]));
                rdp.Add(r);
            }
            DbProviderObj.Close();
            return rdp;
        }

        public RevisioneDomandaPagamentoCollection GetRevisioneDomandeGenericoFem(IntNT id_progetto, IntNT id_domanda_pagamento)
        {
            RevisioneDomandaPagamentoCollection rdp = new RevisioneDomandaPagamentoCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGetRevisioneDomandeGenericoFem";
            if (id_progetto != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", id_progetto.Value));
            if (id_domanda_pagamento != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_DOMANDA_PAGAMENTO", id_domanda_pagamento.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                RevisioneDomandaPagamento r = RevisioneDomandaPagamentoDAL.GetFromDatareader(DbProviderObj);
                r.AdditionalAttributes.Add("DESCRIZIONE", new StringNT(DbProviderObj.DataReader["DESCRIZIONE"]));
                rdp.Add(r);
            }
            DbProviderObj.Close();
            return rdp;
        }
    }
}