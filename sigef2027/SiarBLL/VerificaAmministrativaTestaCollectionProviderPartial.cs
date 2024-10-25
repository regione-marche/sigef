using SiarLibrary;
using System.Data.SqlClient;
using System.Data;
using System;
using SiarDAL;

namespace SiarBLL
{
    public partial class VerificaAmministrativaTestaCollectionProvider : IVerificaAmministrativaTestaProvider
    {
        public bool LottiNonDefinitiviPresenti(string codPsr)
        {
            var result = FindDefinitivo(null, codPsr, false);

            if (result.Count > 0)
                return true;
            else
                return false;
        }

        public VerificaAmministrativaTesta GetLastByCodPsr(string codPsr)
        {
            VerificaAmministrativaTesta testa = null;

            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpVerificaAmministrativaTestaGetLastByCodPsr";

            cmd.Parameters.Add(new SqlParameter("CodPsr", codPsr));

            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                var f = VerificaAmministrativaTestaDAL.GetFromDatareader(DbProviderObj);
                testa = f;
            }

            DbProviderObj.Close();
            return testa;
        }

        public void CancellaLotto(int idLotto)
        {
            VerificaAmministrativaTesta tst = GetById(idLotto);
            if (tst == null)
            {
                return;
            }

            if (tst.Definitivo.Value)
            {
                throw new SiarException("Non è possibile cancellare un lotto marcato come 'definitivo'");
            }

            try
            {
                DbProviderObj.BeginTran();
                var dettaglioProvider = new VerificaAmministrativaDettaglioCollectionProvider(DbProviderObj);

                var dettagliCollection = dettaglioProvider.Find(idLotto, null, null, null, null);
                dettaglioProvider.DeleteCollection(dettagliCollection);
                Delete(tst);

                DbProviderObj.Commit();
            }
            catch
            {
                DbProviderObj.Rollback();
            }
            finally
            {
                DbProviderObj.Close();
            }
        }

        public int CreaLotto(string codPsr, DateTime dataFine, string operatore)
        {
            VerificaAmministrativaTesta testa = null;
            DateTime dataInizio;
            
            // Ricavare la data inizio (data fine ultimo periodo x psr + 1gg)
            testa = this.GetLastByCodPsr(codPsr);
            if (testa != null)
                dataInizio = ((DateTime)testa.DataFine).AddDays(1);
            else
                dataInizio = new DateTime(1900, 01, 01);

            return CreaLotto(codPsr, dataInizio, dataFine, operatore);
        }

        public int CreaLotto(string codPsr, DateTime dataInizio, DateTime dataFine, string operatore)
        {
            string strSql;
            int idLotto = -1;
            IDbCommand cmd;

            try
            {
                DbProviderObj.BeginTran();

                var testa = new VerificaAmministrativaTesta();
                testa.OperatoreInserimento = testa.OperatoreModifica = operatore;
                testa.DataInserimento = testa.DataModifica = DateTime.Now;
                testa.DataInizio = dataInizio;
                testa.DataFine = dataFine;
                testa.Codpsr = codPsr;
                testa.Note = null;
                testa.Definitivo = false;
                testa.Segnatura = null;
                testa.DataSegnatura = null;

                this.Save(testa);
                idLotto = testa.IdLotto;

                //per ora inserisco tutte le domande nel lotto al 100%, poi dovranno essere selezionate dalla matrice
                //codice basato su creazione lotti dei controlli in loco "mischiando" vCertSpLiv_1
                //  con le regole di estrazione di SpPsrGetDomandePerRevisioneByRupAndBando 

                // Caricare, tramite la vista VDOMANDE_PER_VERIFICHE_AMMINISTRATIVE.sql, le nuove righe su VerificaAmministrativaDettaglio
                strSql = @"
                    INSERT INTO VERIFICA_AMMINISTRATIVA_DETTAGLIO (
	                    ID_LOTTO,
	                    OPERATORE_INSERIMENTO,
	                    DATA_INSERIMENTO,
	                    OPERATORE_MODIFICA,
	                    DATA_MODIFICA,
	                    ID_DOMANDA_PAGAMENTO,
	                    ID_PROGETTO,
	                    ASSE,
	                    AZIONE,
	                    INTERVENTO,
	                    OBIETTIVO_SPECIFICO,
	                    SELEZIONATA,
	                    COSTO_TOTALE,
	                    IMPORTO_AMMESSO,
	                    NR_OPERAZIONI_B,
	                    BENEFICIARIO,
	                    SPESA_AMMESSA,
	                    SPESA_AMMESSA_INCREMENTALE,
	                    IMPORTO_CONTRIBUTO_PUBBLICO_INCREMENTALE,
	                    ESCLUSIONE,
	                    RISCHIO_IR,
                        RISCHIO_CR,
	                    RISCHIO_COMPLESSIVO
                    )

                    SELECT   
	                    @IdLotto AS ID_LOTTO,
                        @Operatore AS OPERATORE_INSERIMENTO,
	                    @DataInserimento AS DATA_INSERIMENTO,
	                    @Operatore AS OPERATORE_MODIFICA,
	                    @DataModifica AS DATA_MODIFICA,
                        Id_Domanda_Pagamento,
                        Id_Progetto,
                        Asse_Codice,
                        Azione,
                        Intervento,
                        Obiettivo_Specifico,
                        0 AS SELEZIONATA,
                        Costo_Totale,
                        Importo_Ammesso,
                        Operazioni_Beneficiario,
                        Beneficiario,
                        Spesa_Ammessa,
                        Spesa_Ammessa_Incrementale,
                        Importo_Contributo_Pubblico_Incrementale,
                        Motivo_Esclusione,
                        RischioIR,
                        RischioCR,
                        RischioComplessivo
                    FROM VDOMANDE_PER_VERIFICHE_AMMINISTRATIVE
                    WHERE Cod_Psr = @CodPsr
                ";

                cmd = DbProviderObj.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.CommandTimeout = 180;
                cmd.Parameters.Add(new SqlParameter("@CodPsr", codPsr));
                cmd.Parameters.Add(new SqlParameter("@IdLotto", idLotto));
                cmd.Parameters.Add(new SqlParameter("@DataInserimento", DateTime.Now));
                cmd.Parameters.Add(new SqlParameter("@DataModifica", DateTime.Now));
                cmd.Parameters.Add(new SqlParameter("@Operatore", operatore));
                DbProviderObj.Execute(cmd);

                // Lettura importo quietanza di pagamento (non applicato alle imprese di tipo pubblico)
                // Pulisco il valore di ImportoContributoPubblico_Incrementale prima di valorizzarlo
                strSql = @" 
                    UPDATE VERIFICA_AMMINISTRATIVA_DETTAGLIO
                    SET VERIFICA_AMMINISTRATIVA_DETTAGLIO.IMPORTO_CONTRIBUTO_PUBBLICO_INCREMENTALE = 0
                    FROM VERIFICA_AMMINISTRATIVA_DETTAGLIO
	                    JOIN vProgetto ON VERIFICA_AMMINISTRATIVA_DETTAGLIO.Id_Progetto = vProgetto.Id_Progetto
                        JOIN DATI_MONITORAGGIO_FESR DMF ON DMF.ID_PROGETTO = VERIFICA_AMMINISTRATIVA_DETTAGLIO.Id_Progetto
                    WHERE DMF.CUP_NATURA IN ('06','07')
                        AND VERIFICA_AMMINISTRATIVA_DETTAGLIO.ID_LOTTO = @IdLotto
                ";

                cmd = DbProviderObj.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@IdLotto", idLotto));
                DbProviderObj.Execute(cmd);

                strSql = @" 
                    UPDATE VERIFICA_AMMINISTRATIVA_DETTAGLIO
                    SET VERIFICA_AMMINISTRATIVA_DETTAGLIO.IMPORTO_CONTRIBUTO_PUBBLICO_INCREMENTALE = t.ImportoPagato
                    FROM VERIFICA_AMMINISTRATIVA_DETTAGLIO
                            INNER JOIN
                            (  SELECT Id_Domanda_Pagamento,
                                    SUM(Quietanza_Importo) AS ImportoPagato
                            FROM Domanda_Pagamento_Liquidazione
                            WHERE Liquidato = 'TRUE'
                                AND Quietanza_Data <= @DataFine
                            GROUP BY Id_Domanda_Pagamento) AS t ON VERIFICA_AMMINISTRATIVA_DETTAGLIO.Id_Domanda_Pagamento = t.Id_Domanda_Pagamento
                            INNER JOIN
                            vProgetto ON VERIFICA_AMMINISTRATIVA_DETTAGLIO.Id_Progetto = vProgetto.Id_Progetto
                            INNER JOIN     
                            vImpresa ON vProgetto.Id_Impresa = vImpresa.Id_Impresa
                            INNER JOIN 
                            DATI_MONITORAGGIO_FESR DMF ON DMF.ID_PROGETTO = VERIFICA_AMMINISTRATIVA_DETTAGLIO.Id_Progetto
                    WHERE VERIFICA_AMMINISTRATIVA_DETTAGLIO.ID_LOTTO = @IdLotto
                        AND DMF.CUP_NATURA IN ('06','07')
                ";

                cmd = DbProviderObj.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@IdLotto", idLotto));
                cmd.Parameters.Add(new SqlParameter("@DataFine", dataFine));
                DbProviderObj.Execute(cmd);

                // Aggiornamento valore Importo Ammesso e Contributo Concesso in rolling dall'inizio del progetto
                strSql = @" 
                    WITH cte AS (
                        SELECT d.*,
                            p.Data_Approvazione,
                            ROW_NUMBER() OVER(ORDER BY d.Id_Progetto, p.Data_Approvazione, d.Id_Domanda_Pagamento) AS [r]
                        FROM VERIFICA_AMMINISTRATIVA_DETTAGLIO d
		                    JOIN Domanda_di_Pagamento p ON d.Id_Domanda_Pagamento = p.ID_DOMANDA_PAGAMENTO
                    )

                    UPDATE cur
                    SET cur.IMPORTO_CONCESSO = (    SELECT SUM(ref1.SPESA_AMMESSA)
                                                    FROM cte ref1
                                                    WHERE ref1.[r] <= cur.[r]
                                                        AND ref1.Id_Progetto = cur.Id_Progetto
                                                ),
                        cur.IMPORTO_CONTRIBUTO_PUBBLICO = (   SELECT SUM(ref2.IMPORTO_CONTRIBUTO_PUBBLICO_INCREMENTALE)
                                                            FROM cte ref2
                                                            WHERE ref2.[r] <= cur.[r]
                                                                AND ref2.Id_Progetto = cur.Id_Progetto
                                                        )
                    FROM cte cur
                    WHERE ID_LOTTO = @IdLotto
                ";

                cmd = DbProviderObj.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@IdLotto", idLotto));
                DbProviderObj.Execute(cmd);

                DbProviderObj.Commit();
            }
            catch(Exception ex) 
            {
                DbProviderObj.Rollback();
                throw ex;
            }

            // Restituire l'IdLotto alla funzione chiamante
            return idLotto;
        }

        public void RendiDefinitivoLotto(int idLotto, string operatore)
        {
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd;

            string strSql = @"UPDATE VERIFICA_AMMINISTRATIVA_TESTA
                       SET Definitivo = 1,
                           OPERATORE_MODIFICA = @Operatore,
                           DATA_MODIFICA = @DataModifica
                       WHERE ID_LOTTO = @IdLotto";
            cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@IdLotto", idLotto));
            cmd.Parameters.Add(new SqlParameter("@Operatore", operatore));
            cmd.Parameters.Add(new SqlParameter("@DataModifica", DateTime.Now));
            dbPro.Execute(cmd);
            dbPro.Close();
        }
    }
}
