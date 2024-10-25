using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;
using System.Linq;

namespace SiarBLL
{
    public partial class DomandaDiPagamentoCollectionProvider : IDomandaDiPagamentoProvider
    {
        public void AggiornaDomandaDiPagamento(DomandaDiPagamento domanda, Operatore op)
        {
            try
            {
                domanda.CfOperatore = op.Utente.CfUtente;
                domanda.DataModifica = DateTime.Now;
                domanda.CodEnte = op.Utente.CodEnte;
                Save(domanda);
            }
            catch { throw; }
        }

        public void AggiornaDomandaDiPagamento(DomandaDiPagamento domanda, Utenti ut)
        {
            try
            {
                domanda.CfOperatore = ut.CfUtente;
                domanda.DataModifica = DateTime.Now;
                domanda.CodEnte = ut.CodEnte;
                Save(domanda);
            }
            catch { throw; }
        }

        public void AggiornaDomandaDiPagamentoIstruttore(DomandaDiPagamento domanda, Operatore op)
        {
            try
            {
                domanda.CfIstruttore = op.Utente.CfUtente;
                domanda.DataApprovazione = DateTime.Now;
                Save(domanda);
            }
            catch { throw; }
        }

        public void AggiornaDomandaDiPagamentoIstruttore(DomandaDiPagamento domanda, Utenti ut)
        {
            try
            {
                domanda.CfIstruttore = ut.CfUtente;
                domanda.DataApprovazione = DateTime.Now;
                Save(domanda);
            }
            catch { throw; }
        }

        public string ControlloMassimaliDomandaPagamento(int id_progetto, int id_domanda_pagamento)
        {
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT DBO.controlloMassimaliPagamento(@ID_PROGETTO,@ID_DOMANDA_PAGAMENTO)";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGETTO", id_progetto));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_DOMANDA_PAGAMENTO", id_domanda_pagamento));
            object result = DbProviderObj.ExecuteScalar(cmd);
            DbProviderObj.Close();
            int ritorno;
            int.TryParse(result.ToString(), out ritorno);
            string messaggio = null;
            switch (ritorno)
            {
                case 3:
                    messaggio = "Non è possibile richiedere tale tipo di pagamento per la presente domanda di aiuto.";
                    break;
                case 2:
                    messaggio = "Il contributo richiesto supera il massimo concedibile per la presente domanda di pagamento.";
                    break;
                case 1:
                    messaggio = "Il contributo richiesto non raggiunge il minimo concedibile per la presente domanda di pagamento.";
                    break;
            }
            return messaggio;
        }

        public string StepControlliInLocoDomandaPagamento(IntNT id_domanda_pagamento)
        {
            string retval = "NO";
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT dbo.controlliInLocoDomandaPagamento(" + id_domanda_pagamento + ")";
            object result = DbProviderObj.ExecuteScalar(cmd);
            DbProviderObj.Close();
            if (result != null) retval = result.ToString();
            return retval;
        }

        public decimal CalcoloContributoRichiestoDisponibilePagamento(int id_progetto, int id_domanda_pagamento, string cod_tipo_investimento,
            IntNT IdPagamentoRichiesto)
        {
            decimal contributo_disponibile_domanda = 0;
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpCalcoloContributoRichiestoDisponibilePagamento";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", id_progetto));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_DOMANDA_PAGAMENTO", id_domanda_pagamento));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_TIPO_INVESTIMENTO", cod_tipo_investimento));
            if (IdPagamentoRichiesto != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PAGAMENTO_RICHIESTO", IdPagamentoRichiesto.Value));
            DbProviderObj.InitDatareader(cmd);
            if (DbProviderObj.DataReader.Read())
                contributo_disponibile_domanda = Convert.ToDecimal(DbProviderObj.DataReader["CONTRIBUTO_RICHIESTO_DISPONIBILE"]);
            DbProviderObj.Close();
            return contributo_disponibile_domanda;
        }

        public decimal CalcoloContributoAmmessoDisponibilePagamento(int id_progetto, int id_domanda_pagamento, string cod_tipo_investimento, int id_pagamento)
        {
            decimal contributo_disponibile_domanda = 0;
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpCalcoloContributoAmmessoDisponibilePagamento";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", id_progetto));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_DOMANDA_PAGAMENTO", id_domanda_pagamento));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_TIPO_INVESTIMENTO", cod_tipo_investimento));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PAGAMENTO_RICHIESTO", id_pagamento));
            DbProviderObj.InitDatareader(cmd);
            if (DbProviderObj.DataReader.Read())
                contributo_disponibile_domanda = Convert.ToDecimal(DbProviderObj.DataReader["CONTRIBUTO_AMMESSO_DISPONIBILE"]);
            DbProviderObj.Close();
            return contributo_disponibile_domanda;
        }

        public DomandaDiPagamentoCollection GetDomandePerRevisione(int id_utente_rup, IntNT id_bando)
        {
            DomandaDiPagamentoCollection dc = new DomandaDiPagamentoCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGetDomandePerRevisioneByRupAndBando";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_UTENTE", id_utente_rup));
            if (id_bando != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_BANDO", id_bando.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                DomandaDiPagamento d = DomandaDiPagamentoDAL.GetFromDatareader(DbProviderObj);
                d.AdditionalAttributes.Add("ID_BANDO", new StringNT(DbProviderObj.DataReader["ID_BANDO"]));
                d.AdditionalAttributes.Add("DESCRIZIONE_BANDO", new StringNT(DbProviderObj.DataReader["DESCRIZIONE_BANDO"]));
                dc.Add(d);
            }
            DbProviderObj.Close();
            return dc;
        }

        public DomandaDiPagamentoCollection GetDomandePerRevisioneFem(int id_utente_rup, IntNT id_bando)
        {
            DomandaDiPagamentoCollection dc = new DomandaDiPagamentoCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGetDomandePerRevisioneByRupAndBandoFem";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_UTENTE", id_utente_rup));
            if (id_bando != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_BANDO", id_bando.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                DomandaDiPagamento d = DomandaDiPagamentoDAL.GetFromDatareader(DbProviderObj);
                d.AdditionalAttributes.Add("ID_BANDO", new StringNT(DbProviderObj.DataReader["ID_BANDO"]));
                d.AdditionalAttributes.Add("DESCRIZIONE_BANDO", new StringNT(DbProviderObj.DataReader["DESCRIZIONE_BANDO"]));
                dc.Add(d);
            }
            DbProviderObj.Close();
            return dc;
        }

        public ArchivioFileCollection GetFileXProtocollazione(int id_domanda_pagamento)
        {
            ArchivioFileCollection cc = new ArchivioFileCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrDomandaPagamentoFileXProtocollazione";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_DOMANDA_PAGAMENTO", id_domanda_pagamento));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                ArchivioFile f = new ArchivioFile();
                f.Id = (int)DbProviderObj.DataReader["ID_FILE"];
                f.Tipo = new SiarLibrary.NullTypes.StringNT(DbProviderObj.DataReader["TIPO"]); // ESTENSIONE
                f.NomeFile = new SiarLibrary.NullTypes.StringNT(DbProviderObj.DataReader["NOME_FILE_EFFETTIVO"]);
                f.NomeCompleto = new SiarLibrary.NullTypes.StringNT(DbProviderObj.DataReader["NOME_FILE"]);
                f.Contenuto = (byte[])DbProviderObj.DataReader["CONTENUTO"];
                cc.Add(f);
            }
            DbProviderObj.Close();
            return cc;
        }

        public ArchivioFileCollection GetFileXProtocollazioneDomandaPagamentoNoStream(int id_domanda_pagamento)
        {
            ArchivioFileCollection cc = new ArchivioFileCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrDomandaPagamentoFileXProtocollazioneNoStream";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_DOMANDA_PAGAMENTO", id_domanda_pagamento));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                ArchivioFile f = new ArchivioFile();
                f.Id = (int)DbProviderObj.DataReader["ID_FILE"];
                f.Tipo = new StringNT(DbProviderObj.DataReader["TIPO"]); // ESTENSIONE
                f.NomeFile = new StringNT(DbProviderObj.DataReader["NOME_FILE_EFFETTIVO"]);
                f.NomeCompleto = new StringNT(DbProviderObj.DataReader["NOME_FILE"]);
                f.HashCode = new StringNT(DbProviderObj.DataReader["HASH_CODE"]);
                cc.Add(f);
            }
            DbProviderObj.Close();
            return cc;
        }

        public ArchivioFileCollection GetFileXProtocollazioneIntegrazioneDomandaPagamentoNoStream(int id_integrazione_domanda_pagamento)
        {
            ArchivioFileCollection cc = new ArchivioFileCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrIntegrazioneFileXProtocollazioneNoStream";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_INTEGRAZIONE_DOMANDA", id_integrazione_domanda_pagamento));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                ArchivioFile f = new ArchivioFile();
                f.Id = (int)DbProviderObj.DataReader["ID_FILE"];
                f.Tipo = new StringNT(DbProviderObj.DataReader["TIPO"]); // ESTENSIONE
                f.NomeFile = new StringNT(DbProviderObj.DataReader["NOME_FILE_EFFETTIVO"]);
                f.NomeCompleto = new StringNT(DbProviderObj.DataReader["NOME_FILE"]);
                f.HashCode = new StringNT(DbProviderObj.DataReader["HASH_CODE"]);
                cc.Add(f);
            }
            DbProviderObj.Close();
            return cc;
        }

        /// <summary>
        /// aggiorna il campo pagamento_erogabile in domanda_pagamento_esportazione
        /// </summary>
        /// <param name="idDomandaPagamento"></param>
        /// <param name="dbProvider"></param>
        /// <returns>ritorna il numero dei record aggiornati ovvero il numero delle misure attivate</returns>
        public void DeterminaImportoErogabileDomandaPagamento(DomandaDiPagamento pag, bool esitoPositivo, Operatore op)
        {
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpDeterminaImportoErogabileDomandaPagamento";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_DOMANDA_PAGAMENTO", pag.IdDomandaPagamento.Value));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ESITO", esitoPositivo));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("OPERATORE", op.Utente.CfUtente.Value));
            DbProviderObj.Execute(cmd);
            DbProviderObj.Close();
        }

        /// <summary>
        /// metodo per la certificazione di spesa
        /// </summary>
        /// <param name="CodPsr"></param>
        /// <param name="CodTipoPagamento"></param>
        /// /// <param name="IdPadre"></param>
        /// <returns>ritorna il computo totale delle domande di pagamento presentate per asse di programmazione</returns>
        public ZprogrammazioneCollection GetRiepilogoSpeseXAsse(string cod_psr, StringNT cod_tipo_pagamento, IntNT id_padre, DatetimeNT data_inizio, DatetimeNT data_fine)
        {
            ZprogrammazioneCollection zc = new ZprogrammazioneCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpCertspGetRiepilogoSpeseXAsse";
            // cod_psr
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_PSR", cod_psr));
            // cod_tipo_pagamento
            if (cod_tipo_pagamento != null)
            {
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_TIPO_PAGAMENTO", cod_tipo_pagamento.Value));
            }
            else
            {
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_TIPO_PAGAMENTO", cod_tipo_pagamento));
            }
            // id_padre
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PADRE", id_padre));
            // data_inizio
            if (data_inizio != null)
            {
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("DATA_INIZIO", data_inizio.Value));
            }
            else
            {
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("DATA_INIZIO", data_inizio));
            }
            // data_fine
            if (data_fine != null)
            {
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("DATA_FINE", data_fine.Value));
            }
            else
            {
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("DATA_FINE", data_fine));
            }

            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                Zprogrammazione z = SiarDAL.ZprogrammazioneDAL.GetFromDatareader(DbProviderObj);
                z.AdditionalAttributes.Add("ASSE", new StringNT(DbProviderObj.DataReader["ASSE"]));
                z.AdditionalAttributes.Add("CONTRIBUTO_RICHIESTO_TOTALE", new StringNT(DbProviderObj.DataReader["CONTRIBUTO_RICHIESTO_TOTALE"]));
                z.AdditionalAttributes.Add("CONTRIBUTO_AMMESSO_TOTALE", new StringNT(DbProviderObj.DataReader["CONTRIBUTO_AMMESSO_TOTALE"]));
                z.AdditionalAttributes.Add("CONTRIBUTO_PAGATO_TOTALE", new StringNT(DbProviderObj.DataReader["CONTRIBUTO_PAGATO_TOTALE"]));
                zc.Add(z);
            }
            DbProviderObj.Close();
            return zc;
        }


        /// <summary>
        /// Certificazione di spesa Strumenti Finanziari
        /// </summary>
        /// <param name="CodPsr"></param>
        /// <param name="CodTipoPagamento"></param>
        /// /// <param name="IdPadre"></param>
        /// <returns>Ritorna il computo totale delle domande di pagamento presentate come Strumenti Finanziari</returns>
        public ZprogrammazioneCollection GetStrumentiFinanziari(string cod_psr, StringNT cod_tipo_pagamento, IntNT id_padre, DatetimeNT data_inizio, DatetimeNT data_fine)
        {
            ZprogrammazioneCollection zc = new ZprogrammazioneCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpCertspStrumentiFinanziari";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_PSR", cod_psr));
            if (cod_tipo_pagamento != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_TIPO_PAGAMENTO", cod_tipo_pagamento.Value));
            else
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_TIPO_PAGAMENTO", cod_tipo_pagamento));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PADRE", id_padre));
            if (data_inizio != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("DATA_INIZIO", data_inizio.Value));
            else
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("DATA_INIZIO", data_inizio));
            if (data_fine != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("DATA_FINE", data_fine.Value));
            else
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("DATA_FINE", data_fine));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                Zprogrammazione z = SiarDAL.ZprogrammazioneDAL.GetFromDatareader(DbProviderObj);
                z.AdditionalAttributes.Add("ASSE", new StringNT(DbProviderObj.DataReader["ASSE"]));
                z.AdditionalAttributes.Add("CONTRIBUTO_RICHIESTO_TOTALE", new StringNT(DbProviderObj.DataReader["CONTRIBUTO_RICHIESTO_TOTALE"]));
                z.AdditionalAttributes.Add("CONTRIBUTO_AMMESSO_TOTALE", new StringNT(DbProviderObj.DataReader["CONTRIBUTO_AMMESSO_TOTALE"]));
                z.AdditionalAttributes.Add("CONTRIBUTO_PAGATO_TOTALE", new StringNT(DbProviderObj.DataReader["CONTRIBUTO_PAGATO_TOTALE"]));
                zc.Add(z);
            }
            DbProviderObj.Close();
            return zc;
        }

        /// <summary>
        /// metodo per la certificazione di spesa
        /// </summary>
        /// <param name="CodPsr"></param>
        /// <param name="CodTipoPagamento"></param>
        /// /// <param name="IdPadre"></param>
        /// <returns>ritorna il computo totale delle spese ammissibili delle domande e della relativa spesa pubblica sia per aiuti di stato che per finanziamenti pubblici</returns>
        public ZprogrammazioneCollection GetSpesePubblichePrivate(string cod_psr, IntNT id_padre, DatetimeNT data_inizio, DatetimeNT data_fine)
        {
            ZprogrammazioneCollection zc = new ZprogrammazioneCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpCertspSpeseBenediciariEPubbliche";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_PSR", cod_psr));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PADRE", id_padre));
            if (data_inizio != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("DATA_INIZIO", data_inizio.Value));
            else
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("DATA_INIZIO", data_inizio));
            if (data_fine != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("DATA_FINE", data_fine.Value));
            else
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("DATA_FINE", data_fine));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                Zprogrammazione z = SiarDAL.ZprogrammazioneDAL.GetFromDatareader(DbProviderObj);
                z.AdditionalAttributes.Add("ASSE", new StringNT(DbProviderObj.DataReader["ASSE"]));
                z.AdditionalAttributes.Add("CONTRIBUTO_RICHIESTO_TOTALE", new StringNT(DbProviderObj.DataReader["CONTRIBUTO_RICHIESTO_TOTALE"]));
                z.AdditionalAttributes.Add("CONTRIBUTO_AMMISSIBILE_TOTALE", new StringNT(DbProviderObj.DataReader["CONTRIBUTO_AMMISSIBILE_TOTALE"]));
                z.AdditionalAttributes.Add("CONTRIBUTO_PAGATO_TOTALE", new StringNT(DbProviderObj.DataReader["CONTRIBUTO_PAGATO_TOTALE"]));
                zc.Add(z);
            }
            DbProviderObj.Close();
            return zc;
        }

        /// <summary>
        /// metodo per la certificazione di spesa
        /// </summary>
        /// <param name="CodPsr"></param>
        /// <param name="CodTipoPagamento"></param>
        /// /// <param name="IdPadre"></param>
        /// <returns>ritorna il computo totale delle spese ammissibili delle domande e della relativa spesa pubblica sia per aiuti di stato che per finanziamenti pubblici</returns>
        public ZprogrammazioneCollection GetAnticipiAiutiDiStato(string cod_psr, IntNT id_padre)
        {
            ZprogrammazioneCollection zc = new ZprogrammazioneCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpCertspSpeseAnticipi";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_PSR", cod_psr));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PADRE", id_padre));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                Zprogrammazione z = SiarDAL.ZprogrammazioneDAL.GetFromDatareader(DbProviderObj);
                z.AdditionalAttributes.Add("ASSE", new StringNT(DbProviderObj.DataReader["ASSE"]));
                z.AdditionalAttributes.Add("ANTICIPI", new StringNT(DbProviderObj.DataReader["ANTICIPI"]));
                z.AdditionalAttributes.Add("IMPORTO_COPERTO_ANTICIPI", new StringNT(DbProviderObj.DataReader["IMPORTO_COPERTO_ANTICIPI"]));
                z.AdditionalAttributes.Add("DISAVANZO", new StringNT(DbProviderObj.DataReader["DISAVANZO"]));
                zc.Add(z);
            }
            DbProviderObj.Close();
            return zc;
        }

        public DomandaDiPagamentoCollection GetDomandePagamentoPerDecreti(int id_bando, IntNT id_progetto, IntNT id_domanda_pagamento, bool nascondi_decreti, bool nascondi_liquidati, bool dettaglio_decreti, bool dettaglio_mandati)
        {
            DomandaDiPagamentoCollection cc = new DomandaDiPagamentoCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetDomandePagamentoPerDecreti";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_BANDO", id_bando));
            if (id_progetto != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGETTO", id_progetto.Value));
            if (id_domanda_pagamento != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_DOMANDA", id_domanda_pagamento.Value));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NASCONDI_DECRETI", nascondi_decreti));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NASCONDI_LIQUIDATI", nascondi_liquidati));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DettaglioDecreti", dettaglio_decreti));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DettaglioMandati", dettaglio_mandati));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                DomandaDiPagamento c = new DomandaDiPagamento();
                c.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(DbProviderObj.DataReader["ID_DOMANDA_PAGAMENTO"]);
                c.IdProgetto = new SiarLibrary.NullTypes.IntNT(DbProviderObj.DataReader["ID_PROGETTO"]);
                c.Descrizione = new SiarLibrary.NullTypes.StringNT(DbProviderObj.DataReader["DESCRIZIONE"]);
                c.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(DbProviderObj.DataReader["DATA_MODIFICA"]);

                c.AdditionalAttributes.Add("CONTRIBUTO_AMMESSO", new DecimalNT(DbProviderObj.DataReader["CONTRIBUTO_AMMESSO"]));
                //c.AdditionalAttributes.Add("ID_ATTO_PAGAMENTO", new IntNT(DbProviderObj.DataReader["ID_ATTO_PAGAMENTO"]));
                //c.AdditionalAttributes.Add("ATTO_PAGAMENTO", new StringNT(DbProviderObj.DataReader["ATTO_PAGAMENTO"]));
                c.AdditionalAttributes.Add("STATO_LIQUIDAZIONE", new StringNT(DbProviderObj.DataReader["STATO_LIQUIDAZIONE"]));

                c.AdditionalAttributes.Add("IMPORTO_DECRETI", new DecimalNT(DbProviderObj.DataReader["IMPORTO_DECRETI"]));
                c.AdditionalAttributes.Add("IMPORTO_RICHIESTE_LIQUIDAZIONE", new DecimalNT(DbProviderObj.DataReader["IMPORTO_RICHIESTE_LIQUIDAZIONE"]));
                c.AdditionalAttributes.Add("IMPORTO_LIQUIDATO", new DecimalNT(DbProviderObj.DataReader["IMPORTO_LIQUIDATO"]));
                c.AdditionalAttributes.Add("IMPORTO_QUIETANZA", new DecimalNT(DbProviderObj.DataReader["IMPORTO_QUIETANZA"]));

                cc.Add(c);
            }
            DbProviderObj.Close();
            return cc;
        }

        public GraduatoriaProgettiFinanziabilitaCollection GetRiepilogoSpesaXMisura(int id_domanda_pagamento)
        {
            GraduatoriaProgettiFinanziabilitaCollection cc = new GraduatoriaProgettiFinanziabilitaCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGetDPagamentoSpesaXMisura";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_DOMANDA_PAGAMENTO", id_domanda_pagamento));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                GraduatoriaProgettiFinanziabilita misura = new GraduatoriaProgettiFinanziabilita();
                misura.Misura = new SiarLibrary.NullTypes.StringNT(DbProviderObj.DataReader["MISURA"]);
                misura.MisuraPrevalente = new SiarLibrary.NullTypes.BoolNT(DbProviderObj.DataReader["MISURA_PREVALENTE"]);
                misura.ContributoDiMisura = new SiarLibrary.NullTypes.DecimalNT(DbProviderObj.DataReader["IMPORTO_AMMESSO"]);
                cc.Add(misura);
            }
            DbProviderObj.Close();
            return cc;
        }



        /// <summary>
        /// metodo per la certificazione di spese sulla base dei costi effettivi
        /// </summary>
        /// <param name="CodPsr"></param>
        /// <param name="CodTipoPagamento"></param>
        /// /// <param name="IdPadre"></param>
        /// <returns>ritorna il computo totale delle spese ammissibili delle domande e della relativa spesa pubblica e dati aggiutivi</returns>
        public ZprogrammazioneCollection GetSpeseCostiEffett(string cod_psr, DatetimeNT data_inizio, DatetimeNT data_fine)
        {
            ZprogrammazioneCollection zc = new ZprogrammazioneCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpCertspSpeseCostiEffett";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_PSR", cod_psr));
            if (data_inizio != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("DATA_INIZIO", data_inizio.Value));
            else
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("DATA_INIZIO", data_inizio));
            if (data_fine != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("DATA_FINE", data_fine.Value));
            else
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("DATA_FINE", data_fine));

            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                Zprogrammazione z = SiarDAL.ZprogrammazioneDAL.GetFromDatareader(DbProviderObj);
                z.AdditionalAttributes.Add("AZIONE", new StringNT(DbProviderObj.DataReader["AZIONE"]));
                z.AdditionalAttributes.Add("ID_PROGETTO", new StringNT(DbProviderObj.DataReader["ID_PROGETTO"]));
                z.AdditionalAttributes.Add("TIPO_DOMPAG", new StringNT(DbProviderObj.DataReader["TIPO_DOMPAG"]));
                z.AdditionalAttributes.Add("CONTRIBUTO_AMMISSIBILE_TOTALE", new StringNT(DbProviderObj.DataReader["CONTRIBUTO_AMMISSIBILE_TOTALE"]));
                z.AdditionalAttributes.Add("CONTRIBUTO_PAGATO_TOTALE", new StringNT(DbProviderObj.DataReader["CONTRIBUTO_PAGATO_TOTALE"]));
                z.AdditionalAttributes.Add("TIPO_APPALTO", new StringNT(DbProviderObj.DataReader["TIPO_APPALTO"]));
                z.AdditionalAttributes.Add("IMPORTO_APPALTO", new StringNT(DbProviderObj.DataReader["IMPORTO_APPALTO"]));
                z.AdditionalAttributes.Add("CONTRIBUTO_AMMISSIBILE_APPALTO", new StringNT(DbProviderObj.DataReader["CONTRIBUTO_AMMISSIBILE_APPALTO"]));
                z.AdditionalAttributes.Add("TIPO_PROCAGG_APPALTO", new StringNT(DbProviderObj.DataReader["TIPO_PROCAGG_APPALTO"]));
                z.AdditionalAttributes.Add("IMPRESA_APPALTO", new StringNT(DbProviderObj.DataReader["IMPRESA_APPALTO"]));
                z.AdditionalAttributes.Add("Forma", new StringNT(DbProviderObj.DataReader["Forma"]));
                z.AdditionalAttributes.Add("Importo_Ammesso_Totale", new StringNT(DbProviderObj.DataReader["Importo_Ammesso_Totale"]));
                zc.Add(z);
            }
            DbProviderObj.Close();
            return zc;
        }


        public DomandaDiPagamentoCollection GetDomandePagamentoInviate(int idProgetto)
        {
            DomandaDiPagamentoCollection DomColl = new DomandaDiPagamentoCollection();

            string sqlCode = @"SELECT *
                               FROM DOMANDA_DI_PAGAMENTO
                               WHERE Id_Progetto  = @IdProgetto
                                 AND SEGNATURA IS NOT NULL ORDER BY ID_DOMANDA_PAGAMENTO";

            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sqlCode;
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IdProgetto", idProgetto));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                DomandaDiPagamento dp = new DomandaDiPagamento();
                dp.IdDomandaPagamento = new IntNT(DbProviderObj.DataReader["ID_DOMANDA_PAGAMENTO"]);
                dp.Segnatura = new StringNT(DbProviderObj.DataReader["SEGNATURA"]);
                dp.SegnaturaApprovazione = new StringNT(DbProviderObj.DataReader["SEGNATURA_APPROVAZIONE"]);
                dp.CodTipo = new StringNT(DbProviderObj.DataReader["COD_TIPO"]);
                dp.DataModifica = new DatetimeNT(DbProviderObj.DataReader["DATA_MODIFICA"]);
                dp.DataApprovazione = new DatetimeNT(DbProviderObj.DataReader["DATA_APPROVAZIONE"]);
                DomColl.Add(dp);
            }
            DbProviderObj.Close();
            return DomColl;
        }

        /// <summary>
        /// Metodo per verificare se è possibile richiedere o rilasciare una variante controllando domande in fase di presentazione o in istruttoria
        /// </summary>
        /// <param name="idProgetto"></param>
        /// <param name="istruttore"></param>
        /// <param name="verificaAltreVarianti"></param>
        /// <returns>ritorna null se è tutto ok o una stringa di errore con il dettaglio nel caso in cui non si possa rilasciare la variante</returns>
        public string ControlloVarianteRilasciabile(IntNT idProgetto, bool istruttore, bool verificaAltreVarianti)
        {
            var domande_prog_list = this
                    .Find(null, null, idProgetto, null)
                    .ToArrayList<DomandaDiPagamento>();

            //Controllo se ci sono domande da rilasciare prima di richiedere la variante
            var num_domande_presentazione = (from d in domande_prog_list
                                             where 1 == 1
                                                && (d.Annullata == null || d.Annullata == false)
                                                && d.Segnatura == null
                                             select d)
                                             .Count();
            if (num_domande_presentazione > 0)
            {
                if (istruttore)
                    return "E' presente almeno una domanda di pagamento in fase di presentazione. E' necessario farle annullare dal beneficiario o attenderne il rilascio e istruirle prima di istruire la variante.";
                else
                    return "E' presente almeno una domanda di pagamento in fase di presentazione. E' necessario annullarle prima di presentare la variante.";
            }

            //Controllo se ci sono domande in istruttoria prima di richiedere la variante
            var num_domande_istruttoria = (from d in domande_prog_list
                                           where 1 == 1
                                            && (d.Annullata == null || d.Annullata == false)
                                            && d.Segnatura != null
                                            && d.SegnaturaApprovazione == null
                                           select d)
                                           .Count();
            if (num_domande_istruttoria > 0)
            {
                if (istruttore)
                    return "E' presente almeno una domanda di pagamento in fase di istruttoria. E' necessario terminarne l'istruttoria prima di istruire la variante.";
                else
                    return "E' presente almeno una domanda di pagamento in fase di istruttoria. E' necessario il termine delle istruttorie prima di presentare la variante.";
            }

            //Verifico se controllare la presenza di altre varianti in corso
            if (verificaAltreVarianti)
            {
                var varianti_list = new VariantiCollectionProvider()
                    .Find(null, idProgetto, null)
                    .ToArrayList<Varianti>();
                var num_varianti_in_corso = (from v in varianti_list
                                             where 1 == 1
                                                && (v.Annullata == null || v.Annullata == false)
                                                && (v.Segnatura == null
                                                    || v.Segnatura != null && v.SegnaturaApprovazione == null)
                                             select v)
                                             .Count();

                if (num_varianti_in_corso > 0)
                    return "E' già presente una variante/variazione finanziaria da firmare o da istruire.";
            }

            return null;
        }

        /// <summary>
        /// Metodo per verificare se è possibile richiedere o rilasciare una domanda di pagamento controllando varianti in fase di presentazione o in istruttoria
        /// </summary>
        /// <param name="idProgetto"></param>
        /// <returns>ritorna null se è tutto ok o una stringa di errore con il dettaglio nel caso in cui non si possa rilasciare la domanda</returns>
        public string ControlloDomandaRilasciabile(IntNT idProgetto)
        {
            //Verifico se controllare la presenza di altre varianti in corso
            var varianti_list = new VariantiCollectionProvider()
                .Find(null, idProgetto, null)
                .ToArrayList<Varianti>();
            var num_varianti_in_corso = (from v in varianti_list
                                            where 1 == 1
                                            && (v.Annullata == null || v.Annullata == false)
                                            && (v.Segnatura == null
                                                || v.Segnatura != null && v.SegnaturaApprovazione == null)
                                            select v)
                                            .Count();

            if (num_varianti_in_corso > 0)
                return "E' già presente una variante/variazione finanziaria da firmare o da istruire.";

            return null;
        }

        public DomandaDiPagamento GeneraDomandaPagamentoFem(DbProvider provider, Utenti operatoreInserimento, ErogazioneFem erogazioneFem)
        {
            var domanda = new DomandaDiPagamento();

            try
            {
                if (provider != null)
                    this.DbProviderObj = provider;
                else
                    this.DbProviderObj.BeginTran();

                var impresa_provider = new ImpresaCollectionProvider(this.DbProviderObj);
                var domanda_esportazione_provider = new DomandaDiPagamentoEsportazioneCollectionProvider(this.DbProviderObj);
                var progetto_provider = new ProgettoCollectionProvider(this.DbProviderObj);
                var anticipi_provider = new AnticipiRichiestiCollectionProvider(this.DbProviderObj);
                var investimenti_provider = new PianoInvestimentiCollectionProvider(this.DbProviderObj);
                var pag_richiesti_provider = new PagamentiRichiestiCollectionProvider(this.DbProviderObj);
                var pag_richiesti_fem_provider = new PagamentiRichiestiFemCollectionProvider(this.DbProviderObj);
                var pag_beneficiario_provider = new PagamentiBeneficiarioCollectionProvider(this.DbProviderObj);
                var giustificativi_provider = new GiustificativiCollectionProvider(this.DbProviderObj);
                var spese_provider = new SpeseSostenuteCollectionProvider(this.DbProviderObj);
                var decreti_x_dom_provider = new DecretiXDomPagEsportazioneCollectionProvider(this.DbProviderObj);
                var erogazione_x_decreti_provider = new ErogazioneFemXDecretiCollectionProvider(this.DbProviderObj);
                var domanda_liquid = new DomandaPagamentoLiquidazioneCollectionProvider(this.DbProviderObj);
                var erogazione_liquid = new ErogazioneLiquidazioniCollectionProvider(this.DbProviderObj);

                var progetto_erogazione = progetto_provider.GetById(erogazioneFem.IdProgetto);
                var impresa_prog_erogazione = impresa_provider.GetById(progetto_erogazione.IdImpresa);
                var adesso = DateTime.Now;

                //Genero la domanda di pagamento fittizia per la gestione Fem
                domanda.DataInserimento = domanda.DataModifica = domanda.DataApprovazione = DateTime.Now;
                domanda.CfOperatore = domanda.CfIstruttore = operatoreInserimento.CfUtente;

                if (erogazioneFem.Anticipo)
                    domanda.CodTipo = "ANT";
                else
                    domanda.CodTipo = "SAL";

                domanda.IdProgetto = erogazioneFem.IdProgetto;
                domanda.CodEnte = operatoreInserimento.CodEnte;
                domanda.Approvata = true;
                domanda.Segnatura = erogazioneFem.Segnatura;
                domanda.SegnaturaApprovazione = erogazioneFem.Segnatura;
                domanda.Annullata = false;
                domanda.ValiditaVersioneAdc = true;
                domanda.PredispostaAControllo = false;
                domanda.FirmaPredisposta = false;
                domanda.FirmaPredispostaRup = false;
                domanda.InIntegrazione = false;
                this.Save(domanda);

                //Se è un anticipo genero l'anticipo, altrimenti il piano investimenti
                if (domanda.CodTipo == "ANT")
                {
                    var anticipo = new AnticipiRichiesti();
                    anticipo.IdDomandaPagamento = domanda.IdDomandaPagamento;
                    anticipo.IdBando = progetto_erogazione.IdBando;
                    anticipo.DataRichiesta = anticipo.DataValutazione = adesso;
                    anticipo.ContributoRichiesto = erogazioneFem.SommaDecretiAmmessi;
                    anticipo.ContributoAmmesso = erogazioneFem.SommaDecretiAmmessi;
                    anticipo.Ammesso = true;
                    anticipo.Istruttore = operatoreInserimento.CfUtente;
                    anticipi_provider.Save(anticipo);
                }
                else 
                {
                    var investimenti = investimenti_provider.GetPianoInvestimentiDomandaPagamento(domanda.IdProgetto, domanda.IdDomandaPagamento);

                    if (investimenti.Count > 0)
                    {
                        var investimento = investimenti[0];

                        var pag_richiesto = new PagamentiRichiesti();
                        var pag_richiesto_fem = new PagamentiRichiestiFem();
                        var pag_beneficiario = new PagamentiBeneficiario();
                        var giustificativo = new Giustificativi();
                        var spesa = new SpeseSostenute();

                        //Gestisco il pagamento richiesto
                        var pag_richiesto_coll = pag_richiesti_provider.Find(null, investimento.IdInvestimento, domanda.IdProgetto, domanda.IdDomandaPagamento);
                        if (pag_richiesto_coll.Count > 0)
                        {
                            pag_richiesto = pag_richiesto_coll[0];
                        }
                        else
                        {
                            pag_richiesto.IdDomandaPagamento = domanda.IdDomandaPagamento;
                            pag_richiesto.IdInvestimento = investimento.IdInvestimento;
                            pag_richiesto.DataRichiestaPagamento = adesso;
                        }

                        pag_richiesto.ImportoRichiesto = erogazioneFem.SommaDecretiAmmessi;
                        pag_richiesto.ContributoRichiesto = erogazioneFem.SommaDecretiAmmessi;
                        pag_richiesto.ImportoAmmesso = erogazioneFem.SommaDecretiAmmessi;
                        pag_richiesto.ContributoAmmesso = erogazioneFem.SommaDecretiAmmessi;
                        pag_richiesto.Ammesso = true;
                        pag_richiesto.Istruttore = operatoreInserimento.CfUtente;
                        pag_richiesto.DataValutazione = adesso;
                        pag_richiesti_provider.Save(pag_richiesto);

                        //Gestisco il pagamento beneficiario, il giustificativo e la spesa
                        var pag_beneficiario_coll = pag_beneficiario_provider.Find(pag_richiesto.IdPagamentoRichiesto, null, domanda.IdProgetto, null, null, null);
                        if (pag_beneficiario_coll.Count > 0) //se ho già il pagamento beneficiario ho già anche il giustificativo associato
                        {
                            pag_beneficiario = pag_beneficiario_coll[0];

                            giustificativo = giustificativi_provider.GetById(pag_beneficiario.IdGiustificativo);

                            //elimino gli altri pagamenti beneficiario per far tornare i conti
                            pag_beneficiario_coll.Remove(pag_beneficiario);
                            pag_beneficiario_provider.DeleteCollection(pag_beneficiario_coll);
                        }
                        else
                        {
                            giustificativo.IdProgetto = domanda.IdProgetto;
                            giustificativo.Numero = domanda.IdDomandaPagamento.ToString();
                            giustificativo.CodTipo = "SPG"; //Spese generali
                            giustificativo.Data = adesso;
                            giustificativo.Iva = 0.00;
                            giustificativo.IvaNonRecuperabile = true;
                            giustificativo.Descrizione = "Giustificativo domanda Fem";
                            giustificativo.CfFornitore = impresa_prog_erogazione.Cuaa ?? impresa_prog_erogazione.CodiceFiscale;
                            giustificativo.DescrizioneFornitore = impresa_prog_erogazione.RagioneSociale;
                        }

                        giustificativo.Imponibile = erogazioneFem.SommaDecretiAmmessi;
                        giustificativi_provider.Save(giustificativo);

                        spesa.IdDomandaPagamento = domanda.IdDomandaPagamento;
                        spesa.IdGiustificativo = giustificativo.IdGiustificativo;
                        spesa.Importo = erogazioneFem.SommaDecretiAmmessi;
                        spesa.Netto = erogazioneFem.SommaDecretiAmmessi;
                        spesa.Ammesso = true;
                        spesa.CodTipo = "SPG";
                        spesa.Estremi = "Spesa domanda Fem";
                        spesa.DataApprovazione = adesso;
                        spesa.Data = adesso;
                        spesa.OperatoreApprovazione = operatoreInserimento.IdUtente;
                        spese_provider.Save(spesa);

                        pag_beneficiario.IdPagamentoRichiesto = pag_richiesto.IdPagamentoRichiesto;
                        pag_beneficiario.IdGiustificativo = giustificativo.IdGiustificativo;
                        pag_beneficiario.ImportoAmmesso = erogazioneFem.SommaDecretiAmmessi;
                        pag_beneficiario.ImportoRichiesto = erogazioneFem.SommaDecretiAmmessi;
                        pag_beneficiario.ContributoAmmesso = erogazioneFem.SommaDecretiAmmessi;
                        pag_beneficiario.QuotaContributoAmmesso = 100.00;
                        pag_beneficiario_provider.Save(pag_beneficiario);

                        //Gestisco il pagamento richiesto fem per le modifiche sulla certificazione
                        pag_richiesto_fem.DataInserimento = adesso;
                        pag_richiesto_fem.CfInserimento = operatoreInserimento.CfUtente;
                        pag_richiesto_fem.IdInvestimento = investimento.IdInvestimento;
                        pag_richiesto_fem.ImportoRichiesto = erogazioneFem.SommaDecretiAmmessi;
                        pag_richiesto_fem.ImportoAmmesso = erogazioneFem.SommaDecretiAmmessi;
                        pag_richiesto_fem.Ammesso = true;
                        pag_richiesto_fem.DataValutazione = adesso;
                        pag_richiesto_fem.CfIstruttore = operatoreInserimento.CfUtente;
                        pag_richiesto_fem.DataModifica = adesso;
                        pag_richiesto_fem.CfModifica = operatoreInserimento.CfUtente;
                        pag_richiesto_fem.IdDomandaPagamento = domanda.IdDomandaPagamento;
                        pag_richiesto_fem.IdGiustificativo = giustificativo.IdGiustificativo;
                        pag_richiesti_fem_provider.Save(pag_richiesto_fem);
                    }
                    else
                        throw new Exception("Piano investimenti della domanda non trovato");
                }

                //Genero la domanda pagamento esportazione
                var domanda_esportazione = new DomandaDiPagamentoEsportazione();
                domanda_esportazione.IdDomandaPagamento = domanda.IdDomandaPagamento;
                domanda_esportazione.IdProgetto = domanda.IdProgetto;
                domanda_esportazione.Barcode = domanda.IdDomandaPagamento.ToString() + progetto_erogazione.IdProgetto.ToString();
                domanda_esportazione.MisuraPrevalente = 1;
                domanda_esportazione.ImportoAmmissibile = erogazioneFem.SommaDecretiAmmessi;
                domanda_esportazione.ImportoAmmesso = erogazioneFem.SommaDecretiAmmessi;
                domanda_esportazione.ImportoSanzione = 0.00;
                domanda_esportazione.ImportoRecuperoAnticipo = 0.00;
                domanda_esportazione.FlagLiquidato = false;
                domanda_esportazione_provider.Save(domanda_esportazione);

                //Genero i decreti x dom pagamento esportazione
                var decreti_erogazione_coll = erogazione_x_decreti_provider.FindDecretiErogazione(null, erogazioneFem.IdErogazione, null, null, null);
                foreach (ErogazioneFemXDecreti dec in decreti_erogazione_coll)
                {
                    var decreto = new DecretiXDomPagEsportazione();
                    decreto.IdDomandaPagamento = domanda.IdDomandaPagamento;
                    decreto.IdProgetto = domanda.IdProgetto;
                    decreto.IdDecreto = dec.IdDecreto;
                    //decreto.Importo = erogazioneFem.SommaDecretiAmmessi;
                    decreto.Importo = dec.ImportoAmmesso;
                    decreto.DataInserimento = decreto.DataModifica = adesso;
                    decreti_x_dom_provider.Save(decreto);
                    var erogazione_liquid_coll = erogazione_liquid.FindLiquidazione(null, dec.IdErogazioneXDecreti, null, null, erogazioneFem.IdErogazione, dec.IdDecreto);
                    foreach(ErogazioneLiquidazioni liq in erogazione_liquid_coll)
                    {
                        var liquid = new DomandaPagamentoLiquidazione();
                        liquid.IdDomandaPagamento = domanda.IdDomandaPagamento;
                        liquid.IdProgetto = domanda.IdProgetto;
                        liquid.IdImpresaBeneficiaria = progetto_erogazione.IdImpresa;
                        liquid.IdDecreto = dec.IdDecreto;
                        liquid.MandatoNumero = liq.MandatoNumero;
                        liquid.MandatoData = liq.MandatoData;
                        liquid.MandatoImporto = liq.MandatoImporto;
                        liquid.MandatoIdFile = liq.MandatoIdFile;
                        liquid.QuietanzaData = liq.QuietanzaData;
                        liquid.QuietanzaImporto = liq.QuietanzaImporto;
                        domanda_liquid.Save(liquid);
                    }
                }

                if (provider == null)
                    this.DbProviderObj.Commit();
            }
            catch (Exception ex)
            {
                if (provider == null)
                    this.DbProviderObj.Rollback();

                throw ex;
            }

            return domanda;
        }
    }
}

namespace SiarLibrary
{
    public partial class DomandaDiPagamento :BaseObject
    {
        public bool TpAppaltoStrumentiFinanziari
        {
            get
            {
                bool strumenti_finanziari = false;

                if (this != null && this.IdProgetto != null)
                {
                    string TpAppalto = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_TpAppaltoDescrizione(new SiarBLL.ProgettoCollectionProvider().GetById(this.IdProgetto).IdBando);
                    if (TpAppalto == null || TpAppalto == "Strumenti finanziari")
                        strumenti_finanziari = true;
                }

                return strumenti_finanziari;
            }
        }

        public bool UtilizzaStrumentiFinanziari
        {
            get
            {
                bool strumenti_finanziari = false;

                if (this != null && this.IdProgetto != null)
                {
                    string UtStrumFin = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_UtStrumFin(
                        new SiarBLL.ProgettoCollectionProvider().GetById(this.IdProgetto).IdBando);
                    if (UtStrumFin == "True")
                        strumenti_finanziari = true;
                }

                return strumenti_finanziari;
            }
        }

        public bool RichiedeAutovalutazione
        {
            get
            {
                if (this != null && this.IdProgetto != null)
                     return new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_RichiediAutovalutazione(new SiarBLL.ProgettoCollectionProvider().GetById(this.IdProgetto).IdBando);

                return false;
            }
        }

        public string NaturaCup
        {
            get
            {
                var dati_mon_coll = new SiarBLL.DatiMonitoraggioFESRCollectionProvider().Find(null, this.IdProgetto);

                if (dati_mon_coll.Count > 0)
                {
                    return dati_mon_coll[0].IdCUPNatura.Value;
                }

                return "";
                
            }
        }
    }
}
