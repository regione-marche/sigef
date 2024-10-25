using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class UtentiCollectionProvider : IUtentiProvider
    {
        public UtentiCollection GetStatisticaOperatoriEnte(StringNT CodenteEqualThis, StringNT ProvinciaEqualThis)
        {
            UtentiCollection utenti = new UtentiCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetStatisticaOperatoriEnte";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_ENTE", CodenteEqualThis.Value));
            if (ProvinciaEqualThis != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("PROVINCIA", ProvinciaEqualThis.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                object progetti_provvisori = DbProviderObj.DataReader["PROGETTI_PROVVISORI"];
                object progetti_definitivi = DbProviderObj.DataReader["PROGETTI_DEFINITIVI"];
                object pagamenti_provvisori = DbProviderObj.DataReader["PAGAMENTI_PROVVISORI"];
                object pagamenti_definitivi = DbProviderObj.DataReader["PAGAMENTI_DEFINITIVI"];
                object varianti_provvisorie = DbProviderObj.DataReader["VARIANTI_PROVVISORIE"];
                object varianti_definitive = DbProviderObj.DataReader["VARIANTI_DEFINITIVE"];
                Utenti u = UtentiDAL.GetFromDatareader(DbProviderObj);
                u.AdditionalAttributes.Add("ProgettiProvvisori", progetti_provvisori != System.DBNull.Value ? progetti_provvisori.ToString() : "0");
                u.AdditionalAttributes.Add("ProgettiDefinitivi", progetti_definitivi != System.DBNull.Value ? progetti_definitivi.ToString() : "0");
                u.AdditionalAttributes.Add("PagamentiProvvisori", pagamenti_provvisori != System.DBNull.Value ? pagamenti_provvisori.ToString() : "0");
                u.AdditionalAttributes.Add("PagamentiDefinitivi", pagamenti_definitivi != System.DBNull.Value ? pagamenti_definitivi.ToString() : "0");
                u.AdditionalAttributes.Add("VariantiProvvisorie", varianti_provvisorie != System.DBNull.Value ? varianti_provvisorie.ToString() : "0");
                u.AdditionalAttributes.Add("VariantiDefinitive", varianti_definitive != System.DBNull.Value ? varianti_definitive.ToString() : "0");
                utenti.Add(u);
            }
            DbProviderObj.Close();
            return utenti;
        }

        public Utenti NuovoUtente(int id_persona_fisica, int id_profilo, string cod_ente, string provincia, int id_operatore)
        {
            try
            {
                UtentiStoricoCollectionProvider storico_provider = new UtentiStoricoCollectionProvider(DbProviderObj);
                DbProviderObj.BeginTran();
                SiarLibrary.Utenti u = new Utenti();
                u.IdPersonaFisica = id_persona_fisica;
                Save(u);
                // nuovo storico                
                UtentiStorico s = new UtentiStorico();
                s.IdUtente = u.IdUtente;
                s.IdProfilo = id_profilo;
                s.CodEnte = cod_ente;
                s.Provincia = provincia;
                s.Attivo = true;
                s.Data = DateTime.Now;
                s.Operatore = id_operatore;
                storico_provider.Save(s);
                // aggiorno l'utente
                u.IdStoricoUltimo = s.Id;
                Save(u);
                DbProviderObj.Commit();
                return GetById(u.IdUtente);
            }
            catch { DbProviderObj.Rollback(); throw; }
        }

        public void ModificaUtente(ref Utenti utente)
        {
            try
            {
                if (utente == null) throw new Exception("L'operatore selezionato non è valido.");
                DbProviderObj.BeginTran();
                // salvo in caso di nuovo utente
                if (utente.IdUtente == null) Save(utente);
                // nuovo storico
                UtentiStoricoCollectionProvider storico_provider = new UtentiStoricoCollectionProvider(DbProviderObj);
                UtentiStorico nuovo_storico = new UtentiStorico();
                nuovo_storico.IdUtente = utente.IdUtente;
                nuovo_storico.IdProfilo = utente.IdProfilo;
                nuovo_storico.CodEnte = utente.CodEnte;
                nuovo_storico.Provincia = utente.Provincia;
                nuovo_storico.Attivo = utente.Attivo;
                nuovo_storico.Data = DateTime.Now;
                nuovo_storico.Operatore = utente.Operatore;
                storico_provider.Save(nuovo_storico);
                // aggiorno l'utente
                utente.IdStoricoUltimo = nuovo_storico.Id;
                Save(utente);
                DbProviderObj.Commit();
            }
            catch { DbProviderObj.Rollback(); throw; }
        }

        public void DisabilitaUtente(ref Utenti utente, int id_operatore)
        {
            if (utente == null || utente.IdUtente == null) throw new Exception("L'operatore selezionato non è valido.");
            utente.Attivo = false;
            utente.Operatore = id_operatore;
            ModificaUtente(ref utente);
        }

        public void DisabilitaUtente(int id_utente, int id_operatore)
        {
            if (id_utente <= 0) throw new Exception("L'operatore selezionato non è valido.");
            SiarLibrary.Utenti u = GetById(id_utente);
            DisabilitaUtente(ref u, id_operatore);
        }
    }
}
