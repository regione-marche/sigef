using System;
using System.Data;
using SiarLibrary;
using SiarDAL;
using System.Data.SqlClient;


namespace SiarBLL
{

    public partial class CertspTestaCollectionProvider : ICertspTestaProvider
    {
        #region Sql string

        private string sqlSelect()
        {
            string str = @"SELECT   IdCertSp,
                                    CodPsr,
                                    DataInizio,
                                    DataFine,
                                    Id_File,
                                    Note,
                                    Definitivo,
                                    Tipo,
                                    DataInserimento,
                                    DataModifica,
                                    Operatore,
                                    DataSegnatura,
                                    Segnatura,
                                    Segnatura_Certificazione";
            return str;
        }

        private string sqlFrom()
        {
            string str = " FROM dbo.CertSp_Testa ";
            return str;
        }

        #endregion

        #region Get object

        public bool noTemporaryLot(string codPsr)
        {
            int nrRecord = 1;
            bool ret = false;

            string strSql = @"SELECT COUNT(1)
                              FROM dbo.CertSp_Testa
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

        public CertspTestaCollection getAll()
        {
            CertspTesta tst = null;
            CertspTestaCollection tsts = new CertspTestaCollection();

            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlSelect() + sqlFrom();

            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                tst = (CertspTestaDAL.GetFromDatareader(dbPro));
                tsts.Add(tst);
            }
            dbPro.Close();

            return tsts;
        }

        public CertspTestaCollection getBy_CodPsr(string codPsr)
        {
            CertspTesta tst = null;
            CertspTestaCollection tsts = new CertspTestaCollection();

            string strWhere = @" WHERE CodPsr = @CodPsr ";
            string strOrder = @" ORDER BY DataFine DESC ";

            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlSelect() + sqlFrom() + strWhere + strOrder;
            cmd.Parameters.Add(new SqlParameter("@CodPsr", codPsr));

            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                tst = (CertspTestaDAL.GetFromDatareader(dbPro));
                tsts.Add(tst);
            }
            dbPro.Close();

            return tsts;
        }

        public CertspTesta getLast_ByCodPsr(string codPsr)
        {
            CertspTesta tst = null;
            int _idLoco;

            string strSelect = @"SELECT TOP 1 IdCertSp ";
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

        #endregion

        #region Data edit

        public int creaLotto(string codPsr, DateTime dataFine, string tipo, int operatore)
        {
            CertspTesta tst = null;
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
            return creaLotto(codPsr, dataInizio, dataFine, tipo, operatore);
        }

        public int creaLotto(string codPsr, DateTime dataInizio, DateTime dataFine, string tipo, int operatore)
        {
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd;

            string strSql;
            int _idCertSp = 0;
            string dataFinale;
            int last_IdCertSp = 0;

            try
            {
                object result;
                dbPro.BeginTran();

                // Leggo l'id del lotto precedente
                strSql = @"SELECT TOP 1 IdCertSp
                           FROM CertSp_Testa
                           WHERE CodPsr = @codPsr
                             AND Definitivo = 'TRUE'
                           ORDER BY DataFine DESC ";
                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@codPsr", codPsr));
                result = dbPro.ExecuteScalar(cmd);
                if (result != null)
                {
                    last_IdCertSp = int.Parse(result.ToString());
                }

                // Leggo la data dell'ultimo lotto Finale (F)
                strSql = @"SELECT TOP 1 CONVERT(Varchar(8), DataFine, 112)
                           FROM CertSp_Testa
                           WHERE CodPsr = @codPsr
                             AND Tipo = 'F'
                           ORDER BY DataFine DESC ";
                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@codPsr", codPsr));

                result = dbPro.ExecuteScalar(cmd);
                if (result == null)
                {
                    dataFinale = "19000101";
                }
                else
                {
                    dataFinale = result.ToString();
                }

                // Creare record su CertSp_Testa e leggere l'IdCertSp attribuito al record
                strSql = @"INSERT INTO CertSp_Testa(CodPsr,
                                                    DataInizio,
                                                    DataFine,
                                                    Definitivo,
                                                    Tipo,
                                                    DataInserimento,
                                                    DataModifica,
                                                    Operatore)
                           output INSERTED.IdCertSp
                           VALUES (@CodPsr,
                                   @DataInizio,
                                   @DataFine,
                                   'FALSE',
                                   @Tipo,
                                   @DataInserimento,
                                   @DataModifica,
                                   @Operatore) ";
                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@CodPsr", codPsr));
                cmd.Parameters.Add(new SqlParameter("@DataInizio", dataInizio.Date));
                cmd.Parameters.Add(new SqlParameter("@DataFine", dataFine.Date));
                cmd.Parameters.Add(new SqlParameter("@Tipo", tipo));
                cmd.Parameters.Add(new SqlParameter("@DataInserimento", DateTime.Now));
                cmd.Parameters.Add(new SqlParameter("@DataModifica", DateTime.Now));
                cmd.Parameters.Add(new SqlParameter("@Operatore", operatore));

                result = dbPro.ExecuteScalar(cmd);
                if (result == null)
                {
                    throw new System.Exception("Errore nella creazione del record di testa");
                }
                int.TryParse(result.ToString(), out _idCertSp);

                // INSERT: 
                // Ora prende direttamente dai lotti definitivi e validati delle verifiche amministrative interne al periodo della certificazione di spesa
                strSql = @"INSERT INTO CertSp_Dettaglio( IdCertSp,
                        Id_Domanda_Pagamento,
                        Id_Progetto,
                        Asse,
                        Selezionata,
                        CostoTotale,
                        ImportoAmmesso,
                        Beneficiario,
                        SpesaAmmessa,
                        SpesaAmmessa_Incrementale,
                        ImportoContributoPubblico_Incrementale,
                        Operatore,
                        DataInserimento,
                        DataModifica)

                    SELECT @IdCertSp,
	                    DET.Id_Domanda_Pagamento,
	                    DET.Id_Progetto,
	                    DET.Asse,
	                    1,
	                    DET.Costo_Totale,
	                    DET.Importo_Ammesso,
	                    DET.Beneficiario,
	                    DET.Spesa_Ammessa,
	                    DET.Spesa_Ammessa_Incrementale,
	                    CASE 
	                    WHEN vi.COD_FORMA_GIURIDICA like '1.%' 
			                    AND vd.COD_TIPO = 'ANT' 
			                    AND dmfr.CUP_NATURA IN ('06','07')
		                    THEN
			                    CASE 
				                    WHEN DET.Importo_Contributo_Pubblico_Incrementale <= DET.Importo_Ammesso * 0.4
					                    THEN DET.Importo_Contributo_Pubblico_Incrementale
				                    ELSE
					                    ROUND(CONVERT(decimal(18,2), DET.Importo_Ammesso * 0.4), 2) 
			                    END
	                    ELSE
		                    DET.Importo_Contributo_Pubblico_Incrementale
	                    END AS ImportoContributoPubblico_Incrementale,
	                    @Operatore,
	                    @DataInserimento,
	                    @DataModifica
                    FROM VVERIFICA_AMMINISTRATIVA_DETTAGLIO DET --vCntrLoco_Dettaglio l 
	                    LEFT JOIN CertSp_Dettaglio d ON DET.Id_Domanda_Pagamento = d.Id_Domanda_Pagamento
	                    LEFT JOIN DOMANDA_DI_PAGAMENTO vd ON DET.Id_Domanda_Pagamento = vd.ID_DOMANDA_PAGAMENTO
	                    LEFT JOIN DATI_MONITORAGGIO_FESR dmfr ON DET.Id_Progetto = dmfr.ID_PROGETTO
	                    LEFT JOIN vPROGETTO p ON DET.Id_Progetto = p.ID_PROGETTO
	                    LEFT JOIN vIMPRESA vi ON p.ID_IMPRESA = vi.ID_IMPRESA
                    WHERE 1 = 1
	                    AND DET.CodPsr      =  @CodPsr
	                    AND DET.DEFINITIVO = 1
	                    AND DET.DATA_INIZIO  >= @DataInizio
	                    AND DET.DATA_FINE	 <= @DataFine
	                    AND d.Id_Domanda_Pagamento IS NULL -- VERIFICO CHE NON SIA GIA' CERTIFICATA
	                    AND p.COD_STATO NOT IN ('R', 'E', 'Y') -- clausola di esclusione per progetti in stato R rinuncia, E escluso, Y Revocato
                           ";
                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@CodPsr", codPsr));
                cmd.Parameters.Add(new SqlParameter("@IdCertSp", _idCertSp));
                cmd.Parameters.Add(new SqlParameter("@DataInserimento", DateTime.Now));
                cmd.Parameters.Add(new SqlParameter("@DataModifica", DateTime.Now));
                cmd.Parameters.Add(new SqlParameter("@Operatore", operatore));
                cmd.Parameters.Add(new SqlParameter("@DataInizio", dataInizio.ToString("yyyyMMdd")));
                cmd.Parameters.Add(new SqlParameter("@DataFine", dataFine.ToString("yyyyMMdd")));
                dbPro.Execute(cmd);

                /*
                // INIZIO VECCHIA INSERT

                // CertSp_Dettaglio, insert: 
                //      - lotto definitivo,
                //      - domanda non sottoposta a controllo in loco,
                //      - data fine inclusa nel periodo selezionato.
                //      02/11/2023 Aggiunta esclusione progetti con rinuncia, revocati e esclusi per sicurezza riferimento pass Supporto #199803
                strSql = @"INSERT INTO CertSp_Dettaglio(    IdCertSp,
                                                            Id_Domanda_Pagamento,
                                                            Id_Progetto,
                                                            Asse,
                                                            Selezionata,
                                                            CostoTotale,
                                                            ImportoAmmesso,
                                                            Beneficiario,
                                                            SpesaAmmessa,
                                                            SpesaAmmessa_Incrementale,
                                                            ImportoContributoPubblico_Incrementale,
                                                            Operatore,
                                                            DataInserimento,
                                                            DataModifica)
                           SELECT   @IdCertSp,
                                    l.Id_Domanda_Pagamento,
                                    l.Id_Progetto,
                                    l.Asse,
                                    'TRUE',
                                    l.CostoTotale,
                                    l.ImportoAmmesso,
                                    l.Beneficiario,
                                    l.SpesaAmmessa,
                                    l.SpesaAmmessa_Incrementale,
                                    CASE 
                                    WHEN vi.COD_FORMA_GIURIDICA like '1.%' AND vd.COD_TIPO = 'ANT' AND dmfr.CUP_NATURA IN ('06','07')
                                    THEN
			                            CASE WHEN 
			                            l.ImportoContributoPubblico_Incrementale <= l.ImportoAmmesso*0.4
			                            THEN 
			                            l.ImportoContributoPubblico_Incrementale
			                            ELSE
			                            ROUND(CONVERT(decimal(18,2),l.ImportoAmmesso*0.4),2) END
		                            ELSE
                                    l.ImportoContributoPubblico_Incrementale
                                    END AS ImportoContributoPubblico_Incrementale,
                                    @Operatore,
                                    @DataInserimento,
                                    @DataModifica
                           FROM vCntrLoco_Dettaglio l
	                            LEFT OUTER JOIN
	                            CertSp_Dettaglio d ON l.Id_Domanda_Pagamento = d.Id_Domanda_Pagamento
	                            LEFT OUTER JOIN
	                            DOMANDA_DI_PAGAMENTO vd ON
	                            l.Id_Domanda_Pagamento = vd.ID_DOMANDA_PAGAMENTO
	                            LEFT OUTER JOIN
	                            DATI_MONITORAGGIO_FESR dmfr ON
	                            l.Id_Progetto = dmfr.ID_PROGETTO
	                            LEFT OUTER JOIN
	                            vPROGETTO p ON 
	                            l.Id_Progetto = p.ID_PROGETTO
	                            LEFT OUTER JOIN
	                            vIMPRESA vi ON 
	                            p.ID_IMPRESA = vi.ID_IMPRESA
                           WHERE 
                                l.CodPsr      =  @CodPsr
                                AND l.Definitivo  =  'TRUE'
                                AND l.Selezionata =  'FALSE'
                                -- AND l.DataFine    >= @DataInizio -- modifica per pass Supporto #199788 
                                AND l.DataFine    <= @DataFine
                                AND d.Id_Domanda_Pagamento IS NULL
                                --clausola di esclusione per progetti con natura cup <> 06, 07, anticipi e di soggetti pubblici
                                AND NOT
                                (
                                    dmfr.CUP_NATURA not in ('06','07') AND  vd.COD_TIPO = 'ANT' AND vi.COD_FORMA_GIURIDICA  like '2.%'
                                )
                                --clausola di esclusione per progetti con natura cup <> 06, 07, 08, anticipi e di soggetti privati (eccezione legata al bando trasporti)
                                    --la clausola non va applicata in caso di progetti degli strumenti finanziari (identificati in natura cup 08 come da pass 171118)
	                            AND NOT
                                (
                                    dmfr.CUP_NATURA not in ('06','07', '08') AND  vd.COD_TIPO = 'ANT' AND vi.COD_FORMA_GIURIDICA  like '1.%'
                                )
                                AND p.COD_STATO NOT IN ('R', 'E', 'Y') -- clausola di esclusione per progetti in stato R rinuncia, E escluso, Y Revocato
                           ";
                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@CodPsr", codPsr));
                cmd.Parameters.Add(new SqlParameter("@IdCertSp", _idCertSp));
                cmd.Parameters.Add(new SqlParameter("@DataInserimento", DateTime.Now));
                cmd.Parameters.Add(new SqlParameter("@DataModifica", DateTime.Now));
                cmd.Parameters.Add(new SqlParameter("@Operatore", operatore));
                cmd.Parameters.Add(new SqlParameter("@DataInizio", dataInizio.ToString("yyyyMMdd")));
                cmd.Parameters.Add(new SqlParameter("@DataFine", dataFine.ToString("yyyyMMdd")));
                dbPro.Execute(cmd);

                // CertSp_Dettaglio, insert: 
                //      - lotto definitivo,
                //      - domanda sottoposta a controllo in loco,
                //      - controllo in loco superato,
                //      - data sopralluogo entro la fine del lotto
                //      02/11/2023 Aggiunta esclusione progetti con rinuncia, revocati e esclusi per sicurezza riferimento pass Supporto #199803
                strSql = @"WITH IRRE AS (
                            SELECT 
	                            ID_PROGETTO,
	                            ID_DOMANDA,
	                            SUM(IMPORTO_IRREGOLARE_AMMESSO) AS IMPORTO_IRREGOLARE_AMMESSO,
	                            SUM(IMPORTO_IRREGOLARE_CONCESSO) AS IMPORTO_IRREGOLARE_CONCESSO
                            FROM PAGAMENTI_IRREGOLARITA
                            GROUP BY ID_PROGETTO, ID_DOMANDA
                            --ORDER BY ID_PROGETTO, ID_DOMANDA
                            )

                            INSERT INTO CertSp_Dettaglio(    IdCertSp,
                                                            Id_Domanda_Pagamento,
                                                            Id_Progetto,
                                                            Asse,
                                                            Selezionata,
                                                            CostoTotale,

                                                            ImportoAmmesso,
                                                            Beneficiario,
                                                            SpesaAmmessa,
                                                            SpesaAmmessa_Incrementale,
                                                            ImportoContributoPubblico_Incrementale,
                                                            Operatore,
                                                            DataInserimento,
                                                            DataModifica)
                            SELECT  @IdCertSp,
                                    l.Id_Domanda_Pagamento,
                                    l.Id_Progetto,
                                    l.Asse,
                                    'TRUE',
                                    l.CostoTotale,
                                    l.ImportoAmmesso,
                                    l.Beneficiario,
                                    l.SpesaAmmessa - ISNULL(IR.IMPORTO_IRREGOLARE_AMMESSO, 0) AS SpesaAmmessa,
                                    l.SpesaAmmessa_Incrementale,
                                    CASE 
                                    WHEN vi.COD_FORMA_GIURIDICA like '1.%' AND vd.COD_TIPO = 'ANT' AND dmfr.CUP_NATURA IN ('06','07')
                                    THEN
			                            CASE WHEN 
			                            l.ImportoContributoPubblico_Incrementale <= l.ImportoAmmesso*0.4
			                            THEN 
			                            l.ImportoContributoPubblico_Incrementale
			                            ELSE
			                            ROUND(CONVERT(decimal(18,2),l.ImportoAmmesso*0.4),2) END
		                            ELSE
                                    l.ImportoContributoPubblico_Incrementale
                                    END - ISNULL(IR.IMPORTO_IRREGOLARE_CONCESSO, 0) AS ImportoContributoPubblico_Incrementale,
                                    @Operatore,
                                    @DataInserimento,
                                    @DataModifica
                            FROM vCntrLoco_Dettaglio l
                                 LEFT JOIN
                                 CertSp_Dettaglio d ON l.Id_Domanda_Pagamento = d.Id_Domanda_Pagamento
                                 INNER JOIN
                                 Testata_Controlli_Loco tcl ON l.IdLoco_Dettaglio = tcl.IdLoco_Dettaglio
                                 LEFT OUTER JOIN
	                             DOMANDA_DI_PAGAMENTO vd ON
	                             l.Id_Domanda_Pagamento = vd.ID_DOMANDA_PAGAMENTO
	                             LEFT OUTER JOIN
	                             DATI_MONITORAGGIO_FESR dmfr ON
	                             l.Id_Progetto = dmfr.ID_PROGETTO
	                             LEFT OUTER JOIN
	                             vPROGETTO p ON 
	                             l.Id_Progetto = p.ID_PROGETTO
	                             LEFT OUTER JOIN
	                             vIMPRESA vi ON 
	                             p.ID_IMPRESA = vi.ID_IMPRESA
                                 LEFT JOIN 
                                 IRRE IR on IR.ID_DOMANDA = l.Id_Domanda_Pagamento
                            WHERE l.CodPsr        =  @CodPsr
                                AND l.Definitivo  =  'TRUE'
                                AND l.Selezionata =  'TRUE'
                                AND l.DataFine    <= @DataFine
                                AND tcl.Data_Sopralluogo   <= @DataFine
                                AND d.Id_Domanda_Pagamento IS NULL
                                AND tcl.Esito_Testata      = 'TRUE'
                                --clausola di esclusione per progetti con natura cup <> 06, 07, anticipi e di soggetti pubblici
                                AND NOT
                                (
                                    dmfr.CUP_NATURA not in ('06','07') AND  vd.COD_TIPO = 'ANT' AND vi.COD_FORMA_GIURIDICA  like '2.%'
                                )
                                --clausola di esclusione per progetti con natura cup <> 06, 07, 08, anticipi e di soggetti privati (eccezione legata al bando trasporti)
                                    --la clausola non va applicata in caso di progetti degli strumenti finanziari (identificati in natura cup 08 come da pass 171118)
	                            AND NOT
                                (
                                    dmfr.CUP_NATURA not in ('06','07', '08') AND  vd.COD_TIPO = 'ANT' AND vi.COD_FORMA_GIURIDICA  like '1.%'
                                )
                                AND p.COD_STATO NOT IN ('R', 'E', 'Y') -- clausola di esclusione per progetti in stato R rinuncia, E escluso, Y Revocato
                    ";
                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@CodPsr", codPsr));
                cmd.Parameters.Add(new SqlParameter("@IdCertSp", _idCertSp));
                cmd.Parameters.Add(new SqlParameter("@DataInserimento", DateTime.Now));
                cmd.Parameters.Add(new SqlParameter("@DataModifica", DateTime.Now));
                cmd.Parameters.Add(new SqlParameter("@Operatore", operatore));
                cmd.Parameters.Add(new SqlParameter("@DataFine", dataFine.ToString("yyyyMMdd")));
                dbPro.Execute(cmd);

                // CertSp_Dettaglio, insert:
                //      - Domande escluse da una certificazione precedente.
                //      02/11/2023 Aggiunta esclusione progetti con rinuncia, revocati e esclusi per sicurezza riferimento pass Supporto #199803
                strSql = @"INSERT INTO CertSp_Dettaglio(IdCertSp,
                                                        Id_Domanda_Pagamento,
                                                        Id_Progetto,
                                                        Asse,
                                                        Selezionata,
                                                        CostoTotale,
                                                        ImportoAmmesso,
                                                        Beneficiario,
                                                        SpesaAmmessa,
                                                        SpesaAmmessa_Incrementale,
                                                        ImportoContributoPubblico_Incrementale,
                                                        ImportoConcesso,
                                                        ImportoContributoPubblico,
                                                        QuotaUe,
                                                        QuotaStato,
                                                        QuotaRegione,
                                                        QuotaPrivato,
                                                        Operatore,
                                                        DataInserimento,
                                                        DataModifica)
                           SELECT   @IdCertSp,
                                    d.Id_Domanda_Pagamento,
                                    d.Id_Progetto,
                                    Asse,
                                    'TRUE',
                                    CostoTotale,
                                    ImportoAmmesso,
                                    Beneficiario,
                                    SpesaAmmessa,
                                    SpesaAmmessa_Incrementale,
                                    CASE 
                                    WHEN vi.COD_FORMA_GIURIDICA like '1.%' AND vd.COD_TIPO = 'ANT' AND dmfr.CUP_NATURA IN ('06','07')
                                    THEN
		 	                           CASE WHEN 
		 	                           d.ImportoContributoPubblico_Incrementale <= d.ImportoAmmesso*0.4
		 	                           THEN 
		 	                           d.ImportoContributoPubblico_Incrementale
		 	                           ELSE
		 	                           ROUND(CONVERT(decimal(18,2),d.ImportoAmmesso*0.4),2) END
		                            ELSE
                                    d.ImportoContributoPubblico_Incrementale
                                    END AS ImportoContributoPubblico_Incrementale,
                                    ImportoConcesso,
                                    ImportoContributoPubblico,
                                    QuotaUe,
                                    QuotaStato,
                                    QuotaRegione,
                                    QuotaPrivato,
                                    @Operatore,
                                    @DataInserimento,
                                    @DataModifica
                           FROM CertSp_Dettaglio d
                           LEFT OUTER JOIN
                           DOMANDA_DI_PAGAMENTO vd ON
                           d.Id_Domanda_Pagamento = vd.ID_DOMANDA_PAGAMENTO
                           LEFT OUTER JOIN
                           DATI_MONITORAGGIO_FESR dmfr ON
                           d.Id_Progetto = dmfr.ID_PROGETTO
                           LEFT OUTER JOIN
                           vPROGETTO p ON 
                           d.Id_Progetto = p.ID_PROGETTO
                           LEFT OUTER JOIN
                           vIMPRESA vi ON 
                           p.ID_IMPRESA = vi.ID_IMPRESA
                           WHERE IdCertSp = @last_IdCertSp
                             AND Selezionata = 'FALSE'
                           --clausola di esclusione per progetti con natura cup <> 06, 07, anticipi e di soggetti pubblici
                           AND NOT
                           (
                               dmfr.CUP_NATURA not in ('06','07') AND  vd.COD_TIPO = 'ANT' AND vi.COD_FORMA_GIURIDICA  like '2.%'
                           )
                           --clausola di esclusione per progetti con natura cup <> 06, 07, 08, anticipi e di soggetti privati (eccezione legata al bando trasporti)
                                --la clausola non va applicata in caso di progetti degli strumenti finanziari (identificati in natura cup 08 come da pass 171118)
	                        AND NOT
                            (
                                dmfr.CUP_NATURA not in ('06','07', '08') AND  vd.COD_TIPO = 'ANT' AND vi.COD_FORMA_GIURIDICA  like '1.%'
                            )
                            AND p.COD_STATO NOT IN ('R', 'E', 'Y') -- clausola di esclusione per progetti in stato R rinuncia, E escluso, Y Revocato
                          ";
                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@IdCertSp", _idCertSp));
                cmd.Parameters.Add(new SqlParameter("@DataInserimento", DateTime.Now));
                cmd.Parameters.Add(new SqlParameter("@DataModifica", DateTime.Now));
                cmd.Parameters.Add(new SqlParameter("@Operatore", operatore));
                cmd.Parameters.Add(new SqlParameter("@last_IdCertSp", last_IdCertSp));
                dbPro.Execute(cmd);
                // Fine vecchia insert
                */

                // Lettura importo quietanza di pagamento (non applicato alle imprese di tipo pubblico)
                // Pulisco il valore di ImportoContributoPubblico_Incrementale prima di valorizzarlo
                /*strSql = @" UPDATE CertSp_Dettaglio                            //NON METTO PIù A NULL ImportoContributoPubblico_Incrementale
                            SET CertSp_Dettaglio.ImportoContributoPubblico_Incrementale = NULL
                            FROM CertSp_Dettaglio
                                 INNER JOIN
                                 vProgetto ON CertSp_Dettaglio.Id_Progetto = vProgetto.Id_Progetto
                                 INNER JOIN     
                                 vImpresa ON vProgetto.Id_Impresa = vImpresa.Id_Impresa
                                 INNER JOIN 
                                        DATI_MONITORAGGIO_FESR DMF ON DMF.ID_PROGETTO = CertSp_Dettaglio.Id_Progetto
                                 WHERE DMF.CUP_NATURA IN ('06','07')
                              AND CertSp_Dettaglio.IdCertSp = @IdCertSp
                          ";
                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@IdCertSp", _idCertSp));
                dbPro.Execute(cmd);*/
                // --versione precedente:
                //strSql = @" UPDATE CertSp_Dettaglio
                //            SET CertSp_Dettaglio.ImportoContributoPubblico_Incrementale = t.ImportoPagato
                //            FROM CertSp_Dettaglio
                //                 INNER JOIN
                //                 (  SELECT Id_Domanda_Pagamento,
                //                           SUM(Quietanza_Importo) AS ImportoPagato
                //                    FROM Domanda_Pagamento_Liquidazione
                //                    WHERE Liquidato = 'TRUE'
                //                      AND Quietanza_Data <= @DataFine
                //                    GROUP BY Id_Domanda_Pagamento) AS t ON CertSp_Dettaglio.Id_Domanda_Pagamento = t.Id_Domanda_Pagamento
                //                 INNER JOIN
                //                 vProgetto ON CertSp_Dettaglio.Id_Progetto = vProgetto.Id_Progetto
                //                 INNER JOIN     
                //                 vImpresa ON vProgetto.Id_Impresa = vImpresa.Id_Impresa
                //            WHERE CertSp_Dettaglio.IdCertSp = @IdCertSp
                //              AND LEFT(LTRIM(RTRIM(vImpresa.Cod_Forma_Giuridica)), 1) <> '2'
                //        ";
                strSql = @" UPDATE CertSp_Dettaglio
                            SET CertSp_Dettaglio.ImportoContributoPubblico_Incrementale = CASE 
                            WHEN
                            dp.COD_TIPO <> 'ANT'
                            THEN
                             csd.ImportoContributoPubblico_Incrementale
                            ELSE
                            CASE 
                            WHEN dmfr.CUP_NATURA IN ('06','07')
                            THEN
                             CASE WHEN 
                              t.ImportoPagato <= ROUND(CONVERT(decimal(18,2),csd.ImportoAmmesso*0.4),2)
                              THEN 
                               t.ImportoPagato
                              ELSE 
                               ROUND(CONVERT(decimal(18,2),csd.ImportoAmmesso*0.4),2) 
                              END
                             END
                            END
                            FROM CertSp_Dettaglio csd
                            INNER JOIN
                            (  SELECT Id_Domanda_Pagamento,
                                    SUM(Quietanza_Importo) AS ImportoPagato
                            FROM Domanda_Pagamento_Liquidazione
                            WHERE Liquidato = 'TRUE'
                                AND Quietanza_Data <= @DataFine
                            GROUP BY Id_Domanda_Pagamento) AS t ON 
                            csd.Id_Domanda_Pagamento = t.Id_Domanda_Pagamento
                            INNER JOIN
                            vProgetto ON csd.Id_Progetto = vProgetto.Id_Progetto
                            INNER JOIN     
                            vImpresa ON vProgetto.Id_Impresa = vImpresa.Id_Impresa
                            INNER JOIN
                            DATI_MONITORAGGIO_FESR dmfr on 
                            csd.Id_Progetto = dmfr.ID_PROGETTO
                            inner join 
                            DOMANDA_DI_PAGAMENTO dp on 
                            csd.Id_Domanda_Pagamento = dp.ID_DOMANDA_PAGAMENTO
                            WHERE csd.IdCertSp = @IdCertSp
                            --AND LEFT(LTRIM(RTRIM(vImpresa.Cod_Forma_Giuridica)), 1) <> '2'
                            --clausola di esclusione per progetti con natura cup <> 06, 07, anticipi e di soggetti pubblici
                            AND NOT
                            (
                                dmfr.CUP_NATURA not in ('06','07') AND  dp.COD_TIPO = 'ANT' AND vIMPRESA.COD_FORMA_GIURIDICA  like '2.%'
                            )
                            --clausola di esclusione per progetti con natura cup <> 06, 07, 08, anticipi e di soggetti privati (eccezione legata al bando trasporti)
                                --la clausola non va applicata in caso di progetti degli strumenti finanziari (identificati in natura cup 08 come da pass 171118)
	                        AND NOT
                            (
                                dmfr.CUP_NATURA not in ('06','07', '08') AND  dp.COD_TIPO = 'ANT' AND vIMPRESA.COD_FORMA_GIURIDICA  like '1.%'
                            )
                        ";
                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@IdCertSp", _idCertSp));
                cmd.Parameters.Add(new SqlParameter("@DataFine", dataFine.ToString("yyyyMMdd")));
                dbPro.Execute(cmd);

                // Leggo dalla tabella dei ritiri quelli che fanno parte di questa certificazione e li carico nella 
                // tabelle CertSp_Dettaglio_Ritiri
                strSql = @" WITH cte AS (
                            SELECT d.*,
                                    p.Data_Approvazione,
                                    ROW_NUMBER() OVER(PARTITION BY d.Id_Progetto ORDER BY p.Data_Approvazione DESC, d.Id_Domanda_Pagamento DESC) AS [r]
                            FROM CertSp_Dettaglio d
                                    INNER JOIN
                                    Domanda_di_Pagamento p ON d.Id_Domanda_Pagamento = p.ID_DOMANDA_PAGAMENTO
                                    INNER JOIN
                                    CertSp_Testa t ON d.IdCertSp = t.IdCertSp
                            WHERE t.DataFine >  @DataFinaleUltima
                              AND t.DataFine <= @DataFine
                              AND t.CodPsr   =  @codPsr
                              AND d.Selezionata = 'TRUE'
                            )

                            INSERT INTO CertSp_Dettaglio_Recuperi ( IdCertSp_Dettaglio,
                                                                    Id_Registro_Recupero,
                                                                    Importo_da_Recuperare_totale,
                                                                    Importo_preRitiro,
                                                                    Data_Segnatura,
                                                                    Segnatura,
                                                                    ID_ERRORE,
                                                                    CONTRIBUTO_PUBBLICO_ERRORE )
                            SELECT  Cte.IdCertSp_Dettaglio,
                                    rr.Id_Registro_Recupero,
                                    rr.Importo_da_Recuperare_totale,
                                    Cte.ImportoContributoPubblico_Incrementale AS Importo_preRitiro,
                                    rr.Data_Segnatura,
                                    rr.Segnatura,
		                            er.ID_ERRORE,
		                            er.CONTRIBUTO_PUBBLICO_ERRORE
                            FROM Cte 
                                 LEFT JOIN
                                 Registro_Recupero AS rr ON Cte.Id_Progetto = rr.Id_Progetto
                                 LEFT JOIN 
		                         ERRORE er ON Cte.Id_Domanda_Pagamento = er.ID_DOMANDA_PAGAMENTO
                                 LEFT JOIN
                                 CertSp_Dettaglio_Recuperi AS cr ON rr.Id_Registro_Recupero = cr.Id_Registro_Recupero
                            WHERE Cte.r = 1
                              AND rr.Recuperabile   = 'TRUE'
                              AND rr.Storico        = 'FALSE'
                              AND rr.Data_Segnatura <= @DataFine
                              AND cr.Id_Registro_Recupero IS NULL
                              AND er.AZIONE_CERTIFICAZIONE = 'Ritiro'
                              AND er.DATA_RILEVAZIONE >  @DataFinaleUltima
                              AND er.DATA_RILEVAZIONE <= @DataFine
                          ";
                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@DataFinaleUltima", dataFinale));
                cmd.Parameters.Add(new SqlParameter("@DataFine", dataFine.ToString("yyyyMMdd")));
                cmd.Parameters.Add(new SqlParameter("@codPsr", codPsr));
                dbPro.Execute(cmd);

                // Tramite i dati della tabella CertSp_Dettaglio_Ritiri vado a sottrarre l'importo ritirato dalla domanda.
                strSql = @" UPDATE c
                            SET c.ImportoContributoPubblico_Incrementale = r.Importo_preRitiro - r.Importo
                            FROM CertSp_Dettaglio AS c
                                 INNER JOIN
                                 (  SELECT  IdCertSp_Dettaglio,
                                            Importo_preRitiro,
                                            SUM(CONTRIBUTO_PUBBLICO_ERRORE) AS Importo
                                    FROM CertSp_Dettaglio_Recuperi
                                    GROUP BY IdCertSp_Dettaglio,
                                             Importo_preRitiro
                                 ) AS r ON c.IdCertSp_Dettaglio = r.IdCertSp_Dettaglio
                            --WHERE c.IdCertSp = @idCertSp
                          ";
                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@idCertSp", _idCertSp));
                dbPro.Execute(cmd);

                // Sottraggo Irregolarità ai progetti esclusi dai precedenti lotti
                strSql = @"update dbo.CertSp_Dettaglio SET
                             ImportoContributoPubblico_Incrementale = ImportoContributoPubblico_Incrementale -
                                                             (SELECT SUM(DECERT.IMPORTO_DECERTIFICAZIONE_CONCESSO) FROM CERT_DECERTIFICAZIONE DECERT WHERE DECERT.ID_DOMANDA_PAGAMENTO = certSp.ID_DOMANDA_Pagamento),
                             --ImportoContributoPubblico = ImportoContributoPubblico_Incrementale -
                             --(SELECT SUM(IMPORTO_IRREGOLARE_CONCESSO) FROM PAGAMENTI_IRREGOLARITA IRR WHERE IRR.ID_DOMANDA = certSp.ID_DOMANDA_Pagamento),
                             SpesaAmmessa = SpesaAmmessa -
                                                             (SELECT SUM(DECERT.IMPORTO_DECERTIFICAZIONE_AMMESSO) FROM CERT_DECERTIFICAZIONE DECERT WHERE DECERT.ID_DOMANDA_PAGAMENTO = certSp.ID_DOMANDA_Pagamento)
                             
                             FROM
                             CertSp_Dettaglio certSp
                             INNER JOIN CERT_DECERTIFICAZIONE DECERT ON DECERT.ID_DOMANDA_PAGAMENTO = certSp.ID_DOMANDA_PAGAMENTO
                             where certSp.Id_Domanda_Pagamento in (SELECT l.Id_Domanda_Pagamento FROM
                             vCntrLoco_Dettaglio l
                                 LEFT JOIN
                                 CertSp_Dettaglio d ON l.Id_Domanda_Pagamento = d.Id_Domanda_Pagamento
                                 INNER JOIN
                                 Testata_Controlli_Loco tcl ON l.IdLoco_Dettaglio = tcl.IdLoco_Dettaglio
                                 LEFT OUTER JOIN
                                 DOMANDA_DI_PAGAMENTO vd ON

                                 l.Id_Domanda_Pagamento = vd.ID_DOMANDA_PAGAMENTO

                                 LEFT OUTER JOIN
                                 DATI_MONITORAGGIO_FESR dmfr ON

                                 l.Id_Progetto = dmfr.ID_PROGETTO

                                 LEFT OUTER JOIN
                                 vPROGETTO p ON

                                 l.Id_Progetto = p.ID_PROGETTO

                                 LEFT OUTER JOIN
                                 vIMPRESA vi ON

                                 p.ID_IMPRESA = vi.ID_IMPRESA
                            WHERE l.CodPsr = @CodPsr
                                AND l.Definitivo = 'TRUE'
                                AND l.Selezionata = 'TRUE'
                                AND l.DataFine <= @DataFine
                                AND tcl.Data_Sopralluogo <= @DataFine
                                --AND d.Id_Domanda_Pagamento IS NULL
                                AND tcl.Esito_Testata = 'TRUE'
                                AND d.idCertSp = @IdCertSp
                                --clausola di esclusione per progetti con natura cup<> 06, 07, anticipi e di soggetti pubblici
                               AND NOT
                               (
                                   dmfr.CUP_NATURA not in ('06', '07') AND  vd.COD_TIPO = 'ANT' AND vi.COD_FORMA_GIURIDICA  like '2.%'
                               ) 
                               --clausola di esclusione per progetti con natura cup <> 06, 07, 08, anticipi e di soggetti privati (eccezione legata al bando trasporti)
                                    --la clausola non va applicata in caso di progetti degli strumenti finanziari (identificati in natura cup 08 come da pass 171118)
	                            AND NOT
                                (
                                    dmfr.CUP_NATURA not in ('06','07', '08') AND vd.COD_TIPO = 'ANT' AND vi.COD_FORMA_GIURIDICA like '1.%'
                                )
                                )
                          ";
                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@codPsr", codPsr));
                cmd.Parameters.Add(new SqlParameter("@DataFine", dataFine.ToString("yyyyMMdd")));
                cmd.Parameters.Add(new SqlParameter("@IdCertSp", _idCertSp));
                dbPro.Execute(cmd);

                // Aggiorno il valore del Importo Ammesso e del Contributo Concesso a partire dall'ultimo
                // lotto finale
                strSql = @" WITH cte AS (
                                SELECT d.*,
                                       p.Data_Approvazione,
                                       ROW_NUMBER() OVER(ORDER BY d.idcertSp, d.Id_Progetto, p.Data_Approvazione, d.Id_Domanda_Pagamento) AS [r]
                                FROM CertSp_Dettaglio d
                                     INNER JOIN
                                     Domanda_di_Pagamento p ON d.Id_Domanda_Pagamento = p.ID_DOMANDA_PAGAMENTO
                                     INNER JOIN
                                     CertSp_Testa t ON d.IdCertSp = t.IdCertSp
                                WHERE t.DataFine > @DataFine
                                  AND t.CodPsr = @codPsr
                                  AND d.Selezionata = 'TRUE'
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
                            --WHERE IdCertSp = @IdCertSp
                            ";
                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@codPsr", codPsr));
                cmd.Parameters.Add(new SqlParameter("@IdCertSp", _idCertSp));
                cmd.Parameters.Add(new SqlParameter("@DataFine", dataFinale));
                dbPro.Execute(cmd);

                // Aggiorno il valore di QuotaUe e QuotaStato
                strSql = @" UPDATE CertSp_Dettaglio
                            SET QuotaUe     = ImportoContributoPubblico * 0.5,
                                QuotaStato  = CASE WHEN Asse = '8' THEN  ImportoContributoPubblico * 0.5 ELSE ImportoContributoPubblico*0.35 END
                            WHERE IdCertSp = @IdCertSp 
                          ";
                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@IdCertSp", _idCertSp));
                dbPro.Execute(cmd);

                // Aggiorno il valore di QuotaRegione e QuotaPrivato
                strSql = @" UPDATE CertSp_Dettaglio
                            SET QuotaRegione = ImportoContributoPubblico - (QuotaUe + QuotaStato),
                                QuotaPrivato = ImportoConcesso - ImportoContributoPubblico
                            WHERE IdCertSp = @IdCertSp
                          ";
                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@IdCertSp", _idCertSp));
                dbPro.Execute(cmd);

                // Fix arrotondamento per l'Asse 8
                strSql = @" UPDATE
	                            CertSp_Dettaglio
                            SET
	                            QuotaStato  = QuotaStato - 0.01,
	                            QuotaRegione = 0
                            WHERE
	                            IdCertSp = @IdCertSp
	                            AND Asse = '8'
	                            AND QuotaRegione = -0.01
                         ";
                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@IdCertSp", _idCertSp));
                dbPro.Execute(cmd);

                //Aggiorno le Quote per l'asse 9 che deve essere 100% QuotaUE, vedi pass 199788
                strSql = @" UPDATE CertSp_Dettaglio
                            SET QuotaUe     = ImportoContributoPubblico,
                                QuotaStato  = 0,
                                QuotaRegione = 0
                            WHERE IdCertSp = @IdCertSp 
                                AND Asse = '9'
                          ";
                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@IdCertSp", _idCertSp));
                dbPro.Execute(cmd);

                dbPro.Commit();
            }
            catch (Exception ex)
            {
                dbPro.Rollback();
                throw ex;
            }
            finally
            {
                dbPro.Close();
            }

            return _idCertSp;
        }

        public void CancellaLotto(int idCertSp)
        {
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd;

            string strSql;

            CertspTesta tst = GetById(idCertSp);
            if (tst == null)
            {
                return;
            }
            if (tst.Definitivo.Value == true)
            {
                throw new System.Exception("Non è possibile cancellare un lotto marcato come 'definitivo'");
            }

            try
            {
                dbPro.BeginTran();

                // Cancellazione dettaglio
                strSql = @"DELETE
                           FROM CertSp_Dettaglio
                           WHERE IdCertSp = @IdCertSp ";
                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@IdCertSp", idCertSp));
                dbPro.Execute(cmd);

                // Cancellazione testa
                strSql = @"DELETE
                           FROM CertSp_Testa
                           WHERE IdCertSp = @IdCertSp";
                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@IdCertSp", idCertSp));
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

        public void RendiDefinitivo(int idCertSp)
        {
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd;

            string strSql;

            strSql = @"UPDATE CertSp_Testa
                       SET Definitivo   = 'TRUE',
                           DataModifica = @DataModifica
                       WHERE IdCertSp = @IdCertSp";
            cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@IdCertSp", idCertSp));
            cmd.Parameters.Add(new SqlParameter("@DataModifica", DateTime.Now));
            dbPro.Execute(cmd);
            dbPro.Close();
        }

        public CertspTesta GetByIdDomandaPagamento(int idDomandaPagamento)
        {
            CertspTesta det = null;
            CertspTestaCollection dets = new CertspTestaCollection();
            //string strSql = String.Format(@"SELECT * 
            //                                FROM {0} 
            //                                WHERE 1 = 1 
            //                                    AND Id_Progetto = @IdProgetto
            //                                    AND Definitivo = 1 
            //                                    AND Selezionata = 1
            //                                ORDER BY DataFine DESC ",
            //                              vistaDtt);
            string strSql = String.Format(@"select top 1 t.* 
                                            from CertSp_Testa t
                                            inner join CertSp_Dettaglio d on d.IdCertSp = t.IdCertSp
                                            where d.Id_Domanda_Pagamento = @IdDomandaPagamento ",
                                            "CertSp_Testa");
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@IdDomandaPagamento", idDomandaPagamento));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                det = (CertspTestaDAL.GetFromDatareader(dbPro));
                dets.Add(det);
            }
            dbPro.Close();
            return det;
        }

        public void Sottrai_importi_decertificati(DbProvider dbProvider, int idDomandaPagamento, int idCertSp, int idCertDecertificazione)
        {
            DbProvider dbPro;
            if (dbProvider != null)
                dbPro = dbProvider;
            else
                dbPro = new DbProvider();
            IDbCommand cmd;

            string strSql;

            try
            {
                if (dbProvider == null)
                    dbPro.BeginTran();

                strSql = @"UPDATE 
	                           dbo.CertSp_Dettaglio 
                           SET
	                           ImportoContributoPubblico_Incrementale = ISNULL(ImportoContributoPubblico_Incrementale, 0) -
				 		  		                            (SELECT ISNULL(DECERT.IMPORTO_DECERTIFICAZIONE_CONCESSO, 0) FROM CERT_DECERTIFICAZIONE DECERT WHERE DECERT.ID_CERT_DECERTIFICAZIONE = @IdCertDecertificazione),
                               ImportoContributoPubblico = ISNULL(ImportoContributoPubblico, 0) -
				 		  		                            (SELECT ISNULL(DECERT.IMPORTO_DECERTIFICAZIONE_CONCESSO, 0) FROM CERT_DECERTIFICAZIONE DECERT WHERE DECERT.ID_CERT_DECERTIFICAZIONE = @IdCertDecertificazione),
	                           SpesaAmmessa = ISNULL(SpesaAmmessa, 0) -
				 		  		                            (SELECT ISNULL(DECERT.IMPORTO_DECERTIFICAZIONE_AMMESSO, 0) FROM CERT_DECERTIFICAZIONE DECERT WHERE DECERT.ID_CERT_DECERTIFICAZIONE = @IdCertDecertificazione),
                               ImportoConcesso = ISNULL(ImportoConcesso, 0) - 
                                                            (SELECT ISNULL(DECERT.IMPORTO_DECERTIFICAZIONE_AMMESSO, 0) FROM CERT_DECERTIFICAZIONE DECERT WHERE DECERT.ID_CERT_DECERTIFICAZIONE = @IdCertDecertificazione)
                           FROM
	                           CertSp_Dettaglio CERTSP
                           WHERE
	                           CERTSP.IdCertSp = @IdCertSp AND
	                           CERTSP.Id_Domanda_Pagamento = @IdDomandaPagamento";

                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@idDomandaPagamento", idDomandaPagamento));
                cmd.Parameters.Add(new SqlParameter("@IdCertSp", idCertSp));
                cmd.Parameters.Add(new SqlParameter("@IdCertDecertificazione", idCertDecertificazione));
                dbPro.Execute(cmd);

                if (dbProvider == null)
                    dbPro.Commit();
            }
            catch (Exception ex)
            {
                if (dbProvider == null)
                    dbPro.Rollback();
            }
            finally
            {
                if (dbProvider == null)
                    dbPro.Close();
            }
        }

        public void Sottrai_importi_decertificati(DbProvider dbProvider, int idCertSpDettaglio, int idCertDecertificazione)
        {
            DbProvider dbPro;
            if (dbProvider != null)
                dbPro = dbProvider;
            else
                dbPro = new DbProvider();
            IDbCommand cmd;

            string strSql;

            try
            {
                if (dbProvider == null)
                    dbPro.BeginTran();

                strSql = @"UPDATE 
	                           dbo.CertSp_Dettaglio 
                           SET
	                           ImportoContributoPubblico_Incrementale = ISNULL(ImportoContributoPubblico_Incrementale, 0) -
				 		  		                            (SELECT ISNULL(DECERT.IMPORTO_DECERTIFICAZIONE_CONCESSO, 0) FROM CERT_DECERTIFICAZIONE DECERT WHERE DECERT.ID_CERT_DECERTIFICAZIONE = @IdCertDecertificazione),
                               ImportoContributoPubblico = ISNULL(ImportoContributoPubblico, 0) -
				 		  		                            (SELECT ISNULL(DECERT.IMPORTO_DECERTIFICAZIONE_CONCESSO, 0) FROM CERT_DECERTIFICAZIONE DECERT WHERE DECERT.ID_CERT_DECERTIFICAZIONE = @IdCertDecertificazione),
	                           SpesaAmmessa = ISNULL(SpesaAmmessa, 0) -
				 		  		                            (SELECT ISNULL(DECERT.IMPORTO_DECERTIFICAZIONE_AMMESSO, 0) FROM CERT_DECERTIFICAZIONE DECERT WHERE DECERT.ID_CERT_DECERTIFICAZIONE = @IdCertDecertificazione),
                               ImportoConcesso = ISNULL(ImportoConcesso, 0) - 
                                                            (SELECT ISNULL(DECERT.IMPORTO_DECERTIFICAZIONE_AMMESSO, 0) FROM CERT_DECERTIFICAZIONE DECERT WHERE DECERT.ID_CERT_DECERTIFICAZIONE = @IdCertDecertificazione)
                           FROM
	                           CertSp_Dettaglio CERTSP
                           WHERE
	                           CERTSP.IdCertSp_Dettaglio = @IdCertSpDettaglio";

                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@IdCertSpDettaglio", idCertSpDettaglio));
                cmd.Parameters.Add(new SqlParameter("@IdCertDecertificazione", idCertDecertificazione));
                dbPro.Execute(cmd);

                if (dbProvider == null)
                    dbPro.Commit();
            }
            catch (Exception ex)
            {
                if (dbProvider == null)
                    dbPro.Rollback();
            }
            finally
            {
                if (dbProvider == null)
                    dbPro.Close();
            }
        }

        public void Sottrai_importi_decertificati_domande_successive(DbProvider dbProvider, int idProgetto, int idCertSpDettaglio, int idCertDecertificazione)
        {
            DbProvider dbPro;
            if (dbProvider != null)
                dbPro = dbProvider;
            else
                dbPro = new DbProvider();
            IDbCommand cmd;

            string strSql;

            try
            {
                if (dbProvider == null)
                    dbPro.BeginTran();

                strSql = @"UPDATE 
	                           dbo.CertSp_Dettaglio 
                           SET
                               ImportoContributoPubblico = ISNULL(ImportoContributoPubblico, 0) -
				 		  		                            (SELECT ISNULL(DECERT.IMPORTO_DECERTIFICAZIONE_CONCESSO, 0) FROM CERT_DECERTIFICAZIONE DECERT WHERE DECERT.ID_CERT_DECERTIFICAZIONE = @IdCertDecertificazione),
                               ImportoConcesso = ISNULL(ImportoConcesso, 0) - 
                                                            (SELECT ISNULL(DECERT.IMPORTO_DECERTIFICAZIONE_AMMESSO, 0) FROM CERT_DECERTIFICAZIONE DECERT WHERE DECERT.ID_CERT_DECERTIFICAZIONE = @IdCertDecertificazione)
                           FROM
	                           CertSp_Dettaglio CERTSP
                           WHERE
	                           CERTSP.IdCertSp_Dettaglio > @IdCertSpDettaglio AND
                               CERTSP.Id_Progetto = @IdProgetto";

                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@IdProgetto", idProgetto));
                cmd.Parameters.Add(new SqlParameter("@IdCertSpDettaglio", idCertSpDettaglio));
                cmd.Parameters.Add(new SqlParameter("@IdCertDecertificazione", idCertDecertificazione));
                dbPro.Execute(cmd);

                if (dbProvider == null)
                    dbPro.Commit();
            }
            catch (Exception ex)
            {
                if (dbProvider == null)
                    dbPro.Rollback();
            }
            finally
            {
                if (dbProvider == null)
                    dbPro.Close();
            }
        }

        public void Somma_importi_decertificati(DbProvider dbProvider, int idDomandaPagamento, int idCertSp, int idCertDecertificazione)
        {
            DbProvider dbPro;
            if (dbProvider != null)
                dbPro = dbProvider;
            else
                dbPro = new DbProvider();
            IDbCommand cmd;

            string strSql;

            try
            {
                if (dbProvider == null)
                    dbPro.BeginTran();

                strSql = @"UPDATE 
	                           dbo.CertSp_Dettaglio 
                           SET
	                           ImportoContributoPubblico_Incrementale = ISNULL(ImportoContributoPubblico_Incrementale, 0) +
				 		  		                            (SELECT ISNULL(DECERT.IMPORTO_DECERTIFICAZIONE_CONCESSO, 0) FROM CERT_DECERTIFICAZIONE DECERT WHERE DECERT.ID_CERT_DECERTIFICAZIONE = @IdCertDecertificazione),
                               ImportoContributoPubblico = ISNULL(ImportoContributoPubblico, 0) +
				 		  		                            (SELECT ISNULL(DECERT.IMPORTO_DECERTIFICAZIONE_CONCESSO, 0) FROM CERT_DECERTIFICAZIONE DECERT WHERE DECERT.ID_CERT_DECERTIFICAZIONE = @IdCertDecertificazione),
	                           SpesaAmmessa = ISNULL(SpesaAmmessa, 0) +
				 		  		                            (SELECT ISNULL(DECERT.IMPORTO_DECERTIFICAZIONE_AMMESSO, 0) FROM CERT_DECERTIFICAZIONE DECERT WHERE DECERT.ID_CERT_DECERTIFICAZIONE = @IdCertDecertificazione),
                               ImportoConcesso = ISNULL(ImportoConcesso, 0) + 
                                                            (SELECT ISNULL(DECERT.IMPORTO_DECERTIFICAZIONE_AMMESSO, 0) FROM CERT_DECERTIFICAZIONE DECERT WHERE DECERT.ID_CERT_DECERTIFICAZIONE = @IdCertDecertificazione)      
                           FROM
	                           CertSp_Dettaglio CERTSP
                           WHERE
	                           CERTSP.IdCertSp = @IdCertSp AND
	                           CERTSP.Id_Domanda_Pagamento = @IdDomandaPagamento";

                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@IdDomandaPagamento", idDomandaPagamento));
                cmd.Parameters.Add(new SqlParameter("@IdCertSp", idCertSp));
                cmd.Parameters.Add(new SqlParameter("@IdCertDecertificazione", idCertDecertificazione));
                dbPro.Execute(cmd);

                if (dbProvider == null)
                    dbPro.Commit();
            }
            catch (Exception ex)
            {
                if (dbProvider == null)
                    dbPro.Rollback();
            }
            finally
            {
                if (dbProvider == null)
                    dbPro.Close();
            }
        }

        public void Somma_importi_decertificati(DbProvider dbProvider, int idCertSpDettaglio, int idCertDecertificazione)
        {
            DbProvider dbPro;
            if (dbProvider != null)
                dbPro = dbProvider;
            else
                dbPro = new DbProvider();
            IDbCommand cmd;

            string strSql;

            try
            {
                if (dbProvider == null)
                    dbPro.BeginTran();

                strSql = @"UPDATE 
	                           dbo.CertSp_Dettaglio 
                           SET
	                           ImportoContributoPubblico_Incrementale = ISNULL(ImportoContributoPubblico_Incrementale, 0) +
				 		  		                            (SELECT ISNULL(DECERT.IMPORTO_DECERTIFICAZIONE_CONCESSO, 0) FROM CERT_DECERTIFICAZIONE DECERT WHERE DECERT.ID_CERT_DECERTIFICAZIONE = @IdCertDecertificazione),
                               ImportoContributoPubblico = ISNULL(ImportoContributoPubblico, 0) +
				 		  		                            (SELECT ISNULL(DECERT.IMPORTO_DECERTIFICAZIONE_CONCESSO, 0) FROM CERT_DECERTIFICAZIONE DECERT WHERE DECERT.ID_CERT_DECERTIFICAZIONE = @IdCertDecertificazione),
	                           SpesaAmmessa = ISNULL(SpesaAmmessa, 0) +
				 		  		                            (SELECT ISNULL(DECERT.IMPORTO_DECERTIFICAZIONE_AMMESSO, 0) FROM CERT_DECERTIFICAZIONE DECERT WHERE DECERT.ID_CERT_DECERTIFICAZIONE = @IdCertDecertificazione),
                               ImportoConcesso = ISNULL(ImportoConcesso, 0) + 
                                                            (SELECT ISNULL(DECERT.IMPORTO_DECERTIFICAZIONE_AMMESSO, 0) FROM CERT_DECERTIFICAZIONE DECERT WHERE DECERT.ID_CERT_DECERTIFICAZIONE = @IdCertDecertificazione)      
                           FROM
	                           CertSp_Dettaglio CERTSP
                           WHERE
	                           CERTSP.IdCertSp_Dettaglio = @IdCertSpDettaglio";

                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@IdCertSpDettaglio", idCertSpDettaglio));
                cmd.Parameters.Add(new SqlParameter("@IdCertDecertificazione", idCertDecertificazione));
                dbPro.Execute(cmd);

                if (dbProvider == null)
                    dbPro.Commit();
            }
            catch (Exception ex)
            {
                if (dbProvider == null)
                    dbPro.Rollback();
            }
            finally
            {
                if (dbProvider == null)
                    dbPro.Close();
            }
        }

        public void Somma_importi_decertificati_domande_successive(DbProvider dbProvider, int idProgetto, int idCertSpDettaglio, int idCertDecertificazione)
        {
            DbProvider dbPro;
            if (dbProvider != null)
                dbPro = dbProvider;
            else
                dbPro = new DbProvider();
            IDbCommand cmd;

            string strSql;

            try
            {
                if (dbProvider == null)
                    dbPro.BeginTran();

                strSql = @"UPDATE 
	                           dbo.CertSp_Dettaglio 
                           SET
                               ImportoContributoPubblico = ISNULL(ImportoContributoPubblico, 0) +
				 		  		                            (SELECT ISNULL(DECERT.IMPORTO_DECERTIFICAZIONE_CONCESSO, 0) FROM CERT_DECERTIFICAZIONE DECERT WHERE DECERT.ID_CERT_DECERTIFICAZIONE = @IdCertDecertificazione),
                               ImportoConcesso = ISNULL(ImportoConcesso, 0) + 
                                                            (SELECT ISNULL(DECERT.IMPORTO_DECERTIFICAZIONE_AMMESSO, 0) FROM CERT_DECERTIFICAZIONE DECERT WHERE DECERT.ID_CERT_DECERTIFICAZIONE = @IdCertDecertificazione)      
                           FROM
	                           CertSp_Dettaglio CERTSP
                           WHERE
	                           CERTSP.IdCertSp_Dettaglio > @IdCertSpDettaglio AND
                               CERTSP.Id_Progetto = @IdProgetto";

                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@IdProgetto", idProgetto));
                cmd.Parameters.Add(new SqlParameter("@IdCertSpDettaglio", idCertSpDettaglio));
                cmd.Parameters.Add(new SqlParameter("@IdCertDecertificazione", idCertDecertificazione));
                dbPro.Execute(cmd);

                if (dbProvider == null)
                    dbPro.Commit();
            }
            catch (Exception ex)
            {
                if (dbProvider == null)
                    dbPro.Rollback();
            }
            finally
            {
                if (dbProvider == null)
                    dbPro.Close();
            }
        }

        public void Calcola_quote(DbProvider dbProvider, int idDomandaPagamento, int idCertSp, int idCertDecertificazione)
        {
            DbProvider dbPro;
            if (dbProvider != null)
                dbPro = dbProvider;
            else 
                dbPro = new DbProvider();
            IDbCommand cmd;

            string strSql;

            try
            {
                if (dbProvider == null)
                    dbPro.BeginTran();

                // Aggiorno il valore di QuotaUe e QuotaStato
                strSql = @" UPDATE CertSp_Dettaglio
                            SET QuotaUe     = ImportoContributoPubblico * 0.5,
                                QuotaStato  = CASE WHEN Asse = '8' THEN  ImportoContributoPubblico * 0.5 ELSE ImportoContributoPubblico*0.35 END
                            WHERE IdCertSp = @IdCertSp 
                          ";
                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@IdCertSp", idCertSp));
                dbPro.Execute(cmd);

                // Aggiorno il valore di QuotaRegione e QuotaPrivato
                strSql = @" UPDATE CertSp_Dettaglio
                            SET QuotaRegione = ImportoContributoPubblico - (QuotaUe + QuotaStato),
                                QuotaPrivato = ImportoConcesso - ImportoContributoPubblico
                            WHERE IdCertSp = @IdCertSp
                          ";
                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@IdCertSp", idCertSp));
                dbPro.Execute(cmd);

                // Fix arrotondamento per l'Asse 8
                strSql = @" UPDATE
	                            CertSp_Dettaglio
                            SET
	                            QuotaStato  = QuotaStato - 0.01,
	                            QuotaRegione = 0
                            WHERE
	                            IdCertSp = @IdCertSp
	                            AND Asse = '8'
	                            AND QuotaRegione = -0.01
                         ";
                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@IdCertSp", idCertSp));
                dbPro.Execute(cmd);

                //Aggiorno le Quote per l'asse 9 che deve essere 100% QuotaUE, vedi pass 199788
                strSql = @" UPDATE CertSp_Dettaglio
                            SET QuotaUe     = ImportoContributoPubblico,
                                QuotaStato  = 0,
                                QuotaRegione = 0
                            WHERE IdCertSp = @IdCertSp 
                                AND Asse = '9'
                          ";
                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@IdCertSp", idCertSp));
                dbPro.Execute(cmd);

                if (dbProvider == null)
                    dbPro.Commit();
            }
            catch (Exception ex)
            {
                if (dbProvider == null)
                    dbPro.Rollback();
            }
            finally
            {
                if (dbProvider == null)
                    dbPro.Close();
            }
        }

        public string GetPeriodoContabileCertificazione(int idCertSp)
        {
            string result = string.Empty;
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd;
            
            try
            {
                string strSql = @"TrovaPeriodoContabileCertificazioneSpesa";
                cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new SqlParameter("@idLotto", idCertSp));
                result = dbPro.ExecuteScalar(cmd).ToString();
                dbPro.Close();

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }


            
        }
        #endregion
    }
}
