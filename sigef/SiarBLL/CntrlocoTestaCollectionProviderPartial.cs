using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;
using System.Data.SqlClient;

namespace SiarBLL
{
	public partial class CntrlocoTestaCollectionProvider : ICntrlocoTestaProvider
    {
        #region Sql string

        private string sqlSelect()
        {
            string str = @"SELECT   IdLoco,
                                    CodPsr,
                                    DataInizio,
                                    DataFine,
                                    Note,
                                    Definitivo,
                                    DataInserimento,
                                    DataModifica,
                                    Operatore,
                                    DataSegnatura,
                                    Segnatura";
            return str;
        }

        private string sqlFrom()
        {
            string str = " FROM dbo.CntrLoco_Testa ";
            return str;
        }

        #endregion

        #region Get object

        public bool noTemporaryLot(string codPsr)
        {
            int nrRecord = 1;
            bool ret = false;

            string strSql = @"SELECT COUNT(1)
                              FROM dbo.CntrLoco_Testa
                              WHERE Definitivo = 'FALSE' 
                                AND CodPsr = @CodPsr ";

            // Lettura dal db
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@CodPsr", codPsr));
            object result = dbPro.ExecuteScalar(cmd);
            dbPro.Close();
            if (result != null)
            {
                int.TryParse(result.ToString(), out nrRecord);
            }

            if (nrRecord == 0)
            {
                ret = true;
            }
            return ret;
        }

        public CntrlocoTestaCollection getAll()
        {
            CntrlocoTesta tst = null;
            CntrlocoTestaCollection tsts = new CntrlocoTestaCollection();

            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlSelect() + sqlFrom();
            
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                tst = (CntrlocoTestaDAL.GetFromDatareader(dbPro));
                tsts.Add(tst);
            }
            dbPro.Close();

            return tsts;
        }

        public CntrlocoTestaCollection getBy_CodPsr(string codPsr)
        {
            CntrlocoTesta tst = null;
            CntrlocoTestaCollection tsts = new CntrlocoTestaCollection();

            string strWhere = @" WHERE CodPsr = @CodPsr ";
            string strOrder = @" ORDER BY DataFine DESC ";

            // Lettura dal db
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlSelect() + sqlFrom() + strWhere + strOrder;
            cmd.Parameters.Add(new SqlParameter("@CodPsr", codPsr));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                tst = (CntrlocoTestaDAL.GetFromDatareader(dbPro));
                tsts.Add(tst);
            }
            dbPro.Close();

            return tsts;
        }

        public CntrlocoTesta getLast_ByCodPsr(string codPsr)
        {
            CntrlocoTesta tst = null;
            int _idLoco;

            string strSelect = @"SELECT TOP 1 IdLoco ";
            string strWhere = @" WHERE CodPsr = @CodPsr ";
            string strOrder = @" ORDER BY DataFine DESC ";

            // Lettura dal db
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSelect + sqlFrom() + strWhere + strOrder;
            cmd.Parameters.Add(new SqlParameter("@CodPsr", codPsr));

            object result = dbPro.ExecuteScalar(cmd);
            dbPro.Close();

            if (result != null)
            {
                int.TryParse(result.ToString(), out _idLoco);
                tst = GetById(_idLoco);
            }

            return tst;
        }

        public bool EsisteCheckListCollegata(int idLoco)
        {
            bool esito = false;
            string sql;
            int nrRecord = 0;

            sql = @"SELECT Count(1) AS EsisteFK
                    FROM CntrLoco_Dettaglio AS l
                         INNER JOIN
                         Testata_Controlli_Loco AS c ON l.IdLoco_Dettaglio = c.IdLoco_Dettaglio
                    WHERE l.IdLoco = @IdLoco ";
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            cmd.Parameters.Add(new SqlParameter("@IdLoco", idLoco));

            object result = dbPro.ExecuteScalar(cmd);
            dbPro.Close();

            if (result != null)
            {
                int.TryParse(result.ToString(), out nrRecord);
            }

            if (nrRecord > 0)
            {
                esito = true;
            }

            return esito;
        }

        #endregion

        #region Data edit

        public int creaLoco(string codPsr, DateTime dataFine, int operatore)
        {
            CntrlocoTesta tst = null;
            DateTime dataInizio;
            // Ricavare la data inizio (data fine ultimo periodo x psr + 1gg)
            tst = this.getLast_ByCodPsr(codPsr);
            if (tst != null)
            {
                dataInizio = ((DateTime)tst.Datafine).AddDays(1);
            }
            else
            {
                dataInizio = new DateTime(1900, 01, 01);
            }

            return creaLoco(codPsr, dataInizio, dataFine, operatore);

        }


        public int creaLoco(string codPsr, DateTime dataInizio, DateTime dataFine, int operatore)
        {
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd;            
            
            string strSql;
            int _idLoco = 0;
            
            try
            {
                dbPro.BeginTran();
                // Creare record su CntrLoco_Testa e leggere l'IdLoco attributi al record
                strSql = @"INSERT INTO dbo.CntrLoco_Testa(CodPsr,
                                                          DataInizio,
                                                          DataFine,
                                                          Definitivo,
                                                          DataInserimento,
                                                          DataModifica,
                                                          Operatore)
                       output INSERTED.IdLoco
                       VALUES (@CodPsr,
                               @DataInizio,
                               @DataFine,
                               'FALSE',
                               @DataInserimento,
                               @DataModifica,
                               @Operatore) ";
                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@CodPsr", codPsr));
                cmd.Parameters.Add(new SqlParameter("@DataInizio", dataInizio));
                cmd.Parameters.Add(new SqlParameter("@DataFine", dataFine));
                cmd.Parameters.Add(new SqlParameter("@DataInserimento", DateTime.Now));
                cmd.Parameters.Add(new SqlParameter("@DataModifica", DateTime.Now));
                cmd.Parameters.Add(new SqlParameter("@Operatore", operatore));
                object result = dbPro.ExecuteScalar(cmd);
                if (result == null)
                {
                    throw new System.Exception("Errore nella creazione del record di testa");
                }
                int.TryParse(result.ToString(), out _idLoco);

                // Caricare, tramite la vista vCertSpLiv_1.sql, le nuove righe su CntrLoco_Dettaglio
                strSql = @"INSERT INTO dbo.CntrLoco_Dettaglio(  IdLoco,
                                                                Id_Domanda_Pagamento,
                                                                Id_Progetto,
                                                                Asse,
                                                                Azione,
                                                                Intervento,
                                                                Selezionata,
	                                                            CostoTotale,
	                                                            ImportoAmmesso,
	                                                            NrOperazioniB,
	                                                            Beneficiario,
	                                                            SpesaAmmessa,
	                                                            SpesaAmmessa_Incrementale,
	                                                            ImportoContributoPubblico_Incrementale,
	                                                            Esclusione,
	                                                            RischioIR,
	                                                            RischioCR,
	                                                            RischioComp,
                                                                Operatore,
	                                                            DataInserimento,
	                                                            DataModifica)
                       SELECT   @IdLoco,
                                Id_Domanda_Pagamento,
                                Id_Progetto,
                                Asse_Codice,
                                Azione,
                                Intervento,
                                'FALSE',
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
                                Rischio,
                                @Operatore,
                                @DataInserimento,
                                @DataModifica 
                       FROM dbo.vCertSpLiv_1
                       WHERE Cod_Psr = @CodPsr
                         AND CAST(Data_VerDocum AS Date) >= @DataInizio
                         AND CAST(Data_VerDocum AS Date) <= @DataFine
                       ";
                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.CommandTimeout = 180;
                cmd.Parameters.Add(new SqlParameter("@CodPsr", codPsr));
                cmd.Parameters.Add(new SqlParameter("@IdLoco", _idLoco));
                cmd.Parameters.Add(new SqlParameter("@DataInserimento", DateTime.Now));
                cmd.Parameters.Add(new SqlParameter("@DataModifica", DateTime.Now));
                cmd.Parameters.Add(new SqlParameter("@Operatore", operatore));
                cmd.Parameters.Add(new SqlParameter("@DataInizio", dataInizio));
                cmd.Parameters.Add(new SqlParameter("@DataFine", dataFine));
                dbPro.Execute(cmd);

                // Lettura importo quietanza di pagamento (non applicato alle imprese di tipo pubblico)
                // Pulisco il valore di ImportoContributoPubblico_Incrementale prima di valorizzarlo
                strSql = @" UPDATE CntrLoco_Dettaglio
                            SET CntrLoco_Dettaglio.ImportoContributoPubblico_Incrementale = 0
                            FROM CntrLoco_Dettaglio
                                 INNER JOIN
                                 vProgetto ON CntrLoco_Dettaglio.Id_Progetto = vProgetto.Id_Progetto
                                 INNER JOIN     
                                 vImpresa ON vProgetto.Id_Impresa = vImpresa.Id_Impresa
                                 INNER JOIN 
                                 DATI_MONITORAGGIO_FESR DMF ON DMF.ID_PROGETTO = CntrLoco_Dettaglio.Id_Progetto
                            WHERE DMF.CUP_NATURA IN ('06','07')
                              AND CntrLoco_Dettaglio.IdLoco = @IdLoco
                          ";
                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@IdLoco", _idLoco));
                dbPro.Execute(cmd);
                strSql = @" UPDATE CntrLoco_Dettaglio
                            SET CntrLoco_Dettaglio.ImportoContributoPubblico_Incrementale = t.ImportoPagato
                            FROM CntrLoco_Dettaglio
                                 INNER JOIN
                                 (  SELECT Id_Domanda_Pagamento,
                                           SUM(Quietanza_Importo) AS ImportoPagato
                                    FROM Domanda_Pagamento_Liquidazione
                                    WHERE Liquidato = 'TRUE'
                                      AND Quietanza_Data <= @DataFine
                                    GROUP BY Id_Domanda_Pagamento) AS t ON CntrLoco_Dettaglio.Id_Domanda_Pagamento = t.Id_Domanda_Pagamento
                                 INNER JOIN
                                 vProgetto ON CntrLoco_Dettaglio.Id_Progetto = vProgetto.Id_Progetto
                                 INNER JOIN     
                                 vImpresa ON vProgetto.Id_Impresa = vImpresa.Id_Impresa
                                 INNER JOIN 
                                 DATI_MONITORAGGIO_FESR DMF ON DMF.ID_PROGETTO = CntrLoco_Dettaglio.Id_Progetto
                            WHERE CntrLoco_Dettaglio.IdLoco = @IdLoco
                              AND DMF.CUP_NATURA IN ('06','07')
                        ";
                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@IdLoco", _idLoco));
                cmd.Parameters.Add(new SqlParameter("@DataFine", dataFine));
                dbPro.Execute(cmd);

                //Sottraggo Irregolarità
                strSql = @"UPDATE dbo.CntrLoco_Dettaglio
                           SET ImportoContributoPubblico_Incrementale = ImportoContributoPubblico_Incrementale - 
                           (SELECT SUM(IMPORTO_IRREGOLARE_CONCESSO) FROM PAGAMENTI_IRREGOLARITA IRR WHERE IRR.ID_DOMANDA = CntrLoco.ID_DOMANDA_PAGAMENTO),
                           SpesaAmmessa = SpesaAmmessa - 
                           (SELECT SUM(IMPORTO_IRREGOLARE_AMMESSO) FROM PAGAMENTI_IRREGOLARITA IRR WHERE IRR.ID_DOMANDA = CntrLoco.ID_DOMANDA_PAGAMENTO)
                           FROM dbo.CntrLoco_Dettaglio CntrLoco INNER JOIN
                           PAGAMENTI_iRREGOLARITA IRR ON IRR.ID_DOMANDA = CntrLoco.ID_DOMANDA_PAGAMENTO
                           WHERE IdLoco = @IdLoco ";
                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@IdLoco", _idLoco));
                dbPro.Execute(cmd);

                // Aggiornamento valore Importo Ammesso e Contributo Concesso in rolling dall'inizio del progetto
                strSql = @" WITH cte AS (
                                SELECT d.*,
                                       p.Data_Approvazione,
                                       ROW_NUMBER() OVER(ORDER BY d.Id_Progetto, p.Data_Approvazione, d.Id_Domanda_Pagamento) AS [r]
                                FROM CntrLoco_Dettaglio d
                                     INNER JOIN
                                     Domanda_di_Pagamento p ON d.Id_Domanda_Pagamento = p.ID_DOMANDA_PAGAMENTO
                            )
                            UPDATE cur
                            SET cur.ImportoConcesso = (    SELECT SUM(ref1.SpesaAmmessa)
                                                            FROM cte ref1
                                                            WHERE ref1.[r] <= cur.[r]
                                                              AND ref1.Id_Progetto = cur.Id_Progetto
                                                       ),
                                cur.ImportoContributoPubblico = (   SELECT SUM(ref2.ImportoContributoPubblico_Incrementale)
                                                                    FROM cte ref2
                                                                    WHERE ref2.[r] <= cur.[r]
                                                                      AND ref2.Id_Progetto = cur.Id_Progetto
                                                                )
                            FROM cte cur
                            WHERE IdLoco = @IdLoco 
                          ";
                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@IdLoco", _idLoco));
                dbPro.Execute(cmd);

                // Esclusione "Realizzazione finanziaria inferiore al 35%"
                strSql = @"UPDATE dbo.CntrLoco_Dettaglio
                           SET Esclusione = 'Realizzazione finanziaria inferiore al 35%'
                           FROM dbo.CntrLoco_Dettaglio
                                INNER JOIN
                                dbo.vCntrLoco_Dettaglio_Prj ON dbo.CntrLoco_Dettaglio.Id_Progetto = dbo.vCntrLoco_Dettaglio_Prj.Id_Progetto
                                                           AND dbo.CntrLoco_Dettaglio.IdLoco      = dbo.vCntrLoco_Dettaglio_Prj.IdLoco
                           WHERE dbo.CntrLoco_Dettaglio.IdLoco =  @IdLoco
                             AND (dbo.vCntrLoco_Dettaglio_Prj.ImportoConcesso * 100) / dbo.vCntrLoco_Dettaglio_Prj.CostoTotale < 35";
                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@IdLoco", _idLoco));
                dbPro.Execute(cmd);
                
                // Esclusione "Contributo inferiore a 10.000 euro"
                strSql = @"UPDATE dbo.CntrLoco_Dettaglio
                           SET Esclusione = 'Contributo inferiore a 10.000 euro'
                           WHERE IdLoco         =  @IdLoco 
                             AND ImportoAmmesso <  10000
                             AND NrOperazioniB  <= 1";
                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@IdLoco", _idLoco));
                dbPro.Execute(cmd);

                // Esclusione "Operazione già sottoposta a controllo in loco"
                strSql = @"UPDATE dbo.CntrLoco_Dettaglio
                           SET Esclusione = 'Operazione già sottoposta a controllo in loco'
                           WHERE IdLoco      =  @IdLoco 
                             AND Id_Progetto IN (   SELECT DISTINCT Id_Progetto
                                                    FROM dbo.CntrLoco_Dettaglio
                                                    WHERE Selezionata = 'TRUE'
                                                )";
                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@IdLoco", _idLoco));
                dbPro.Execute(cmd);

                // Esclusione "Anticipo"
                strSql = @" UPDATE dbo.CntrLoco_Dettaglio
                            SET Esclusione = 'Anticipo'
                            WHERE IdLoco = @IdLoco
                              AND Id_Progetto IN (  SELECT Id_Progetto 
                                                    FROM (  SELECT  l1.Id_Progetto,
                                                                    l1.IdLoco,
                                                                    CASE
                                                                        WHEN COUNT(d1.Id_Progetto) >= 1
                                                                             AND
                                                                             (COUNT(d1.Id_Progetto) = COUNT(l1.Id_Progetto)) THEN 'Anticipo'
                                                                        ELSE ''
                                                                    END AS ClEsclusione
                                                            FROM dbo.CntrLoco_Dettaglio l1
                                                                 LEFT JOIN 
                                                                 dbo.Domanda_di_Pagamento d1 ON l1.Id_Domanda_Pagamento = d1.Id_Domanda_Pagamento
                                                                                            AND d1.Cod_Tipo = 'ANT'
                                                            WHERE l1.IdLoco = @IdLoco
                                                            GROUP BY l1.Id_Progetto,
                                                                     l1.IdLoco
                                                        ) t1
                                                    WHERE t1.ClEsclusione = 'Anticipo') ";
                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@IdLoco", _idLoco));
                dbPro.Execute(cmd);

                // Esclusione "Asse 7"
                strSql = @"UPDATE dbo.CntrLoco_Dettaglio
                           SET Esclusione = 'Asse 7'
                           WHERE Asse = '7'
                             AND IdLoco = @IdLoco ";
                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@IdLoco", _idLoco));
                dbPro.Execute(cmd);

                // Commit
                dbPro.Commit();

            }
            catch (Exception ex)
            {
                // Rollback
                dbPro.Rollback();
                throw ex;
            }
            finally
            {
                dbPro.Close();
            }

            // Restituire l'IdLoco alla funzione chiamante
            return _idLoco;
        }

        public void CancellaLoco(int idLoco)
        {
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd;

            string strSql;
            
            CntrlocoTesta tst = GetById(idLoco);
            if (tst == null)
            {
                return;
            }
            if (tst.Definitivo.Value)
            {
                throw new SiarException("Non è possibile cancellare un lotto marcato come 'definitivo'");
            }
            /* 17-10-2022 NP: Disabilitato il controllo se esiste o meno una checklist collegata 
             * se il lotto non è definitivo*/
            //if  (EsisteCheckListCollegata(idLoco))
            //{
            //    throw new SiarException("Non è possibile cancellare un lotto a cui è associata una 'Checklist Controlli in Loco'.");
            //}

            try
            {
                dbPro.BeginTran();

                // Cancellazione testata controlli loco
                strSql = @"DELETE 
                           FROM Testata_Controlli_Loco 
                           WHERE IdLoco_Dettaglio IN (
                           SELECT IdLoco_Dettaglio 
                           FROM CntrLoco_Dettaglio 
                           WHERE IdLoco = @IdLoco)";
                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@IdLoco", idLoco));
                dbPro.Execute(cmd);

                // Cancellazione dettaglio
                strSql = @"DELETE 
                           FROM CntrLoco_Dettaglio 
                           WHERE IdLoco = @IdLoco";
                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@IdLoco", idLoco));
                dbPro.Execute(cmd);

                // Cancellazione testa
                strSql = @"DELETE 
                           FROM CntrLoco_Testa 
                           WHERE IdLoco = @IdLoco";
                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@IdLoco", idLoco));
                dbPro.Execute(cmd);

                dbPro.Commit();
            }
            catch
            {
                dbPro.Rollback();
            }
            finally
            {
                dbPro.Close();
            }
        }

        public void RendiDefinitivoLoco(int idLoco)
        {
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd;
                        
            string strSql;

            // Cancellazione dettaglio
            strSql = @"UPDATE CntrLoco_Testa
                       SET Definitivo   = 'TRUE',
                           DataModifica = @DataModifica
                       WHERE IdLoco = @IdLoco";
            cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@IdLoco", idLoco));
            cmd.Parameters.Add(new SqlParameter("@DataModifica", DateTime.Now));
            dbPro.Execute(cmd);
            dbPro.Close();
        }

        #endregion
    }
}