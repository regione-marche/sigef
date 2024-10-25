using System;
using System.Data;
using SiarLibrary;
using SiarDAL;
using System.Data.SqlClient;
using System.Collections.Generic;
using SiarLibrary.NullTypes;

namespace SiarBLL
{
    public partial class CertspDettaglioCollectionProvider : ICertspDettaglioProvider
    {
        public enum TipoId { IdCertSp, IdCertSp_Dettaglio }
        public enum TipoDomande { Tutte, SelezionateSi, SelezionateNo, ChecklistSi, ChecklistNo,
            Asse1, Asse2, Asse3, Asse4, Asse5, Asse6, Asse7 }
        public enum DomSelezionata { Si, No, Tutte }
        public enum TipoPagamento { Tutte, Anticipo, Saldo, SAL }
        public enum DomDefinitiva { Si, No, Tutte }

        const string vistaDtt = "vCertSp_Dettaglio",
                     vistaGrp = "vCertSp_Dettaglio_Prj",
                     vistaPer = "vCertSp_Dettaglio_Data";

        #region Sql string

        private string WhereTipoDomande(TipoDomande tdDmn)
        {
            string strWhere = String.Empty;

            switch (tdDmn)
            {
                case TipoDomande.Tutte:
                    // Nessun filtro
                    break;
                case TipoDomande.SelezionateSi:
                    strWhere = " AND Selezionata = 'TRUE' ";
                    break;
                case TipoDomande.SelezionateNo:
                    strWhere = " AND Selezionata = 'FALSE' ";
                    break;
                case TipoDomande.ChecklistSi:
                    strWhere = " AND Id_File IS NOT NULL ";
                    break;
                case TipoDomande.ChecklistNo:
                    strWhere = " AND Id_File IS NULL ";
                    break;
                case TipoDomande.Asse1:
                    strWhere = " AND Asse = 1 ";
                    break;
                case TipoDomande.Asse2:
                    strWhere = " AND Asse = 2 ";
                    break;
                case TipoDomande.Asse3:
                    strWhere = " AND Asse = 3 ";
                    break;
                case TipoDomande.Asse4:
                    strWhere = " AND Asse = 4 ";
                    break;
                case TipoDomande.Asse5:
                    strWhere = " AND Asse = 5 ";
                    break;
                case TipoDomande.Asse6:
                    strWhere = " AND Asse = 6 ";
                    break;
                case TipoDomande.Asse7:
                    strWhere = " AND Asse = 7 ";
                    break;
            }
            return strWhere;
        }

        private string WhereTipoPagamento(TipoPagamento tpPag)
        {
            string strWhere = String.Empty;

            switch (tpPag)
            {
                case TipoPagamento.Tutte:
                    // Nessun filtro
                    break;
                case TipoPagamento.Anticipo:
                    strWhere = " AND TipoDomanda = 'ANT' ";
                    break;
                case TipoPagamento.SAL:
                    strWhere = " AND TipoDomanda = 'SAL' ";
                    break;
                case TipoPagamento.Saldo:
                    strWhere = " AND TipoDomanda = 'SLD' ";
                    break;
            }
            return strWhere;
        }

        private string WhereSelezionata(DomSelezionata dSel)
        {
            string strWhere = String.Empty;

            switch (dSel)
            {
                case DomSelezionata.Tutte:
                    // Nessun filtro
                    break;
                case DomSelezionata.Si:
                    strWhere = " AND Selezionata = 'TRUE' ";
                    break;
                case DomSelezionata.No:
                    strWhere = " AND Selezionata = 'FALSE' ";
                    break;
            }
            return strWhere;
        }

        #endregion

        #region Get object

        public CertspDettaglioCollection getBy_IdCertSp(int idCertSp)
        {
            return getBy_IdCertSp(idCertSp, TipoDomande.Tutte);
        }

        public CertspDettaglioCollection getBy_IdCertSp(int idCertSp, TipoDomande tpDom)
        {
            CertspDettaglio det = null;
            CertspDettaglioCollection dets = new CertspDettaglioCollection();
            string strSql = String.Format(@"SELECT * FROM {0} WHERE IdCertSp = @IdCertSp " + WhereTipoDomande(tpDom),
                                          vistaDtt);
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@IdCertSp", idCertSp));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                det = (CertspDettaglioDAL.GetFromDatareader(dbPro));
                dets.Add(det);
            }
            dbPro.Close();
            return dets;
        }

        public CertspDettaglioCollection getPrjBy_IdCertSp(int idCertSp, TipoDomande tpDom)
        {
            CertspDettaglio det = null;
            CertspDettaglioCollection dets = new CertspDettaglioCollection();
            string strSql = String.Format(@"SELECT * FROM {0} WHERE IdCertSp = @IdCertSp " + WhereTipoDomande(tpDom),
                                          vistaGrp);
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@IdCertSp", idCertSp));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                det = (CertspDettaglioDAL.GetFromDatareader(dbPro));
                dets.Add(det);
            }
            dbPro.Close();
            return dets;
        }

        public DateTime getDataUltimoFinale_ByDataLotto(DateTime dataLotto)
        {
            DateTime dataFinale;
            string apDataFinale;
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd;
            string strSql;
            object result;

            // Lettura DataFine lotto Finale precedente
            strSql = @"SELECT TOP 1 CONVERT(Varchar(8), DataFine, 112)
                           FROM CertSp_Testa
                           WHERE Tipo = 'F'
                             AND CONVERT(Varchar(8), DataFine, 112) < @DataLotto
                           ORDER BY DataFine DESC ";
            cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@DataLotto", dataLotto.ToString("yyyyMMdd")));
            result = dbPro.ExecuteScalar(cmd);
            if (result == null)
            {
                apDataFinale = "20131231";
            }
            else
            {
                apDataFinale = result.ToString();
            }
            dbPro.Close();
            dataFinale = DateTime.ParseExact(apDataFinale, "yyyyMMdd", null);
            return dataFinale;
        }

        public DateTime getDataInizioPrimoLottoDefinitivi()
        {
            DateTime dataFinale;
            string apDataFinale;
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd;
            string strSql;
            object result;

            strSql = @"SELECT CONVERT(Varchar(8), MIN(DataInizio), 112)
                         FROM CertSp_Testa 
                        WHERE Definitivo = 1 ";
            cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            result = dbPro.ExecuteScalar(cmd);

            if (result == null)
                apDataFinale = "20131231";
            else
                apDataFinale = result.ToString();

            dbPro.Close();
            dataFinale = DateTime.ParseExact(apDataFinale, "yyyyMMdd", null);
            return dataFinale;
        }

        public CertspDettaglioCollection getPrjBy_DataFine(string codPsr, DateTime dataLotto, TipoDomande tpDom)
        {
            CertspDettaglio det = null;
            CertspDettaglioCollection dets = new CertspDettaglioCollection();
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd;
            string strSql;
            DateTime dataFinale;

            dataFinale = getDataUltimoFinale_ByDataLotto(dataLotto);

            // Lettura dati CertSp_Dettaglio per data
//            strSql = String.Format(@"SELECT * 
//                                     FROM {0} 
//                                     WHERE DataFine = @dataLotto 
//                                       AND CodPsr = @codPsr " + WhereTipoDomande(tpDom) + 
//                                   @"UNION
//                                     SELECT * 
//                                     FROM {0} 
//                                     WHERE DataFine > @dataFinale 
//                                       AND DataFine < @dataLotto 
//                                       AND Selezionata = 'TRUE' 
//                                       AND CodPsr = @codPsr " + WhereTipoDomande(tpDom),
//                                   vistaPer);
            strSql = @"WITH cte AS (
                        SELECT d.*,
                                p.Data_Approvazione,
                                ROW_NUMBER() OVER(PARTITION BY d.Id_Progetto ORDER BY d.idcertSp DESC, p.Data_Approvazione DESC, d.Id_Domanda_Pagamento DESC, d.DataFine DESC) AS [r],
                                lo.ID_TESTATA as IdTestataControlliLoco
                        FROM vCertSp_Dettaglio d
                                JOIN Domanda_di_Pagamento p ON d.Id_Domanda_Pagamento = p.Id_Domanda_Pagamento
                                LEFT JOIN VTESTATA_CONTROLLI_LOCO lo on d.Id_Domanda_Pagamento = lo.Id_Domanda_Pagamento
                        WHERE d.DataFine >  @dataFinale
                          AND d.DataFine <= @dataLotto
                          AND d.CodPsr   =  @codPsr
                        )

                        SELECT  IdCertSp_Dettaglio,
                                IdCertSp,
                                Id_Domanda_Pagamento,
                                Id_Progetto,
                                Asse,
                                Selezionata,
                                Esito,
                                DataEsito,
                                Id_File,
                                CostoTotale,
                                ImportoAmmesso,
                                ImportoConcesso,
                                Beneficiario,
                                SpesaAmmessa,
                                ImportoContributoPubblico,
                                SpesaAmmessa_Incrementale,
                                ImportoContributoPubblico_Incrementale,
                                Note,
                                Operatore,
                                DataInserimento,
                                DataModifica,
                                QuotaUe,
                                QuotaStato,
                                QuotaRegione,
                                QuotaPrivato,
                                CodPsr,
                                DataFine,
                                Definitivo,
                                Tipo,
                                Codice_Cup,
                                Cup_Natura_Codice,
                                Cup_Natura_Descrizione,
                                TitoloProgetto,
                                TipoDomanda,
                                Azione,
                                Intervento,
                                Id_Bando,
                                IdTestataControlliLoco
                        FROM Cte
                        WHERE r = 1 " + WhereTipoDomande(tpDom) + 
                        @" ORDER BY Id_Progetto
                ";
            
            cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.Text; 
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@dataFinale", dataFinale.ToString("yyyyMMdd")));
            cmd.Parameters.Add(new SqlParameter("@dataLotto", dataLotto.ToString("yyyyMMdd")));
            cmd.Parameters.Add(new SqlParameter("@codPsr", codPsr));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                det = (CertspDettaglioDAL.GetFromDatareader(dbPro));
                det.AdditionalAttributes.Add("IdTestataControlliLoco", new IntNT(dbPro.DataReader["IdTestataControlliLoco"]));
                dets.Add(det);
            }
            dbPro.Close();
            return dets;
        }

        public CertspDettaglio getPrjBy_IdProgetto(int idProgetto, DateTime dataLotto)
        {
            CertspDettaglio det = null;
            DateTime dataFinale = getDataUltimoFinale_ByDataLotto(dataLotto);
            string strSql = String.Format(@"SELECT TOP 1 t.*
                                            FROM (
                                            SELECT * FROM {0} WHERE Id_Progetto = @IdProgetto 
                                                                AND DataFine    = @dataLotto 
                                            UNION 
                                            SELECT * FROM {0} WHERE Id_Progetto = @IdProgetto 
                                                                AND DataFine    > @dataFinale 
                                                                AND DataFine    < @dataLotto
                                                                AND Selezionata = 'TRUE'
                                            ) AS t ORDER BY  t.IdCertSp desc",
                                          vistaGrp);
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@IdProgetto", idProgetto));
            cmd.Parameters.Add(new SqlParameter("@dataLotto", dataLotto.ToString("yyyyMMdd")));
            cmd.Parameters.Add(new SqlParameter("@dataFinale", dataFinale.ToString("yyyyMMdd")));            
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                det = (CertspDettaglioDAL.GetFromDatareader(dbPro));
            }
            dbPro.Close();
            return det;
        }

        //Sostituisce la precedente 07/12/2021
        public CertspDettaglio getPrjBy_IdProgetto2(int idProgetto , int IdCertSp)
        {
            CertspDettaglio det = null;
            
            string strSql = String.Format(@"SELECT TOP 1 *
                                            FROM {0} WHERE Id_Progetto = @IdProgetto and IdCertSp = @IdCertSp",
                                          vistaGrp);
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@IdProgetto", idProgetto));
            cmd.Parameters.Add(new SqlParameter("@IdCertSp", IdCertSp));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                det = (CertspDettaglioDAL.GetFromDatareader(dbPro));
            }
            dbPro.Close();
            return det;
        }


        public CertspDettaglioCollection getBy_IdProgetto(int idCertSp, int idProgetto)
        {
            CertspDettaglio det = null;
            CertspDettaglioCollection dets = new CertspDettaglioCollection();
            string strSql = String.Format(@"SELECT * FROM {0} WHERE IdCertSp = @IdCertSp AND Id_Progetto = @IdProgetto ",
                                          vistaDtt);
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@IdCertSp", idCertSp));
            cmd.Parameters.Add(new SqlParameter("@IdProgetto", idProgetto));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                det = (CertspDettaglioDAL.GetFromDatareader(dbPro));
                dets.Add(det);
            }
            dbPro.Close();
            return dets;
        }

        public CertspDettaglioCollection FindDefinitiviSelezionatiXProgetto(int idProgetto)
        {
            CertspDettaglio det = null;
            CertspDettaglioCollection dets = new CertspDettaglioCollection();
            string strSql = String.Format(@"SELECT * 
                                            FROM {0} 
                                            WHERE 1 = 1 
                                                AND Id_Progetto = @IdProgetto 
                                                AND Definitivo = 1 
                                                AND Selezionata = 1
                                            ORDER BY DataFine DESC ",
                                          vistaDtt);
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@IdProgetto", idProgetto));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                det = (CertspDettaglioDAL.GetFromDatareader(dbPro));
                dets.Add(det);
            }
            dbPro.Close();
            return dets;
        }

        public CertspDettaglioCollection getBy_IdProgetto(int idProgetto, DateTime dataLotto)
        {
            CertspDettaglio det = null;
            CertspDettaglioCollection dets = new CertspDettaglioCollection();
            DateTime dataFinale = getDataUltimoFinale_ByDataLotto(dataLotto);
            string strSql = String.Format(@"SELECT * FROM {0} WHERE Id_Progetto = @IdProgetto 
                                                                AND DataFine    = @dataLotto 
                                            UNION 
                                            SELECT * FROM {0} WHERE Id_Progetto = @IdProgetto 
                                                                AND DataFine    > @dataFinale 
                                                                AND DataFine    < @dataLotto
                                                                AND Selezionata = 'TRUE'",
                                          vistaDtt);
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@IdProgetto", idProgetto));
            cmd.Parameters.Add(new SqlParameter("@dataFinale", dataFinale.ToString("yyyyMMdd")));
            cmd.Parameters.Add(new SqlParameter("@dataLotto", dataLotto.ToString("yyyyMMdd")));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                det = (CertspDettaglioDAL.GetFromDatareader(dbPro));
                dets.Add(det);
            }
            dbPro.Close();
            return dets;
        }

        public string GetNote_ByIdProgetto(int idCertSp, int idProgetto)
        {
            object result;
            string ret = null;

            string strSql = @"SELECT TOP 1 Note
                              FROM CertSp_Dettaglio 
                              WHERE IdCertSp = @IdCertSp 
                                AND Id_Progetto = @IdProgetto ";

            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@IdCertSp", idCertSp));
            cmd.Parameters.Add(new SqlParameter("@IdProgetto", idProgetto));
            result = dbPro.ExecuteScalar(cmd);
            if (result != null)
            {
                ret = result.ToString();
            }
            dbPro.Close();

            return ret;
        }

        public int GetIdFile_ByIdProgetto(int idCertSp, int idProgetto)
        {
            object result;
            int ret = 0;

            string strSql = @"SELECT TOP 1 Id_File
                              FROM CertSp_Dettaglio 
                              WHERE IdCertSp = @IdCertSp 
                                AND Id_Progetto = @IdProgetto ";

            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@IdCertSp", idCertSp));
            cmd.Parameters.Add(new SqlParameter("@IdProgetto", idProgetto));
            result = dbPro.ExecuteScalar(cmd);
            if (result != null)
            {
                int.TryParse(result.ToString(), out ret);
            }
            dbPro.Close();

            return ret;
        }

        #endregion

        #region Get totali

        public decimal SommaImporti_Lotto(TipoDomande tpDmn, int idCertSp, string colonna, DomSelezionata selezionata, TipoPagamento tpPag)
        {
            decimal ret = 0;
            string strSql;
            object result;
            IDbCommand cmd;
            DbProvider dbPro = new DbProvider();

            strSql = String.Format(@"SELECT COUNT(1)
                                     FROM information_schema.columns
                                     WHERE Column_Name = '{0}'
                                       AND Table_Schema = 'dbo'
                                       AND Table_Name = 'CertSp_Dettaglio'
                                       AND Numeric_Precision IS NOT NULL ",
                                   colonna);
            cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            result = dbPro.ExecuteScalar(cmd);
            if (result != null)
            {
                decimal.TryParse(result.ToString(), out ret);
            }
            // Il nome della colonna è sbagliato oppure la colonna non è numerica.
            if (ret == 0)
            {
                return ret;
            }

            // Se sono qua la colonna esiste. Pulisco le variabili e procedo con i calcoli.
            ret = 0;
            strSql = null;
            cmd = null;
            result = null;
            strSql = String.Format(@"SELECT SUM({0}) FROM {1} WHERE IdCertSp = @IdCertSp " + WhereTipoDomande(tpDmn)
                                                                                           + WhereTipoPagamento(tpPag)
                                                                                           + WhereSelezionata(selezionata),
                                   colonna,
                                   vistaDtt);
            cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@IdCertSp", idCertSp));
            result = dbPro.ExecuteScalar(cmd);
            dbPro.Close();
            if (result != null)
            {
                decimal.TryParse(result.ToString(), out ret);
            }
            return ret;
        }

        public decimal SommaImporti_Periodo(string codPsr, TipoDomande tpDmn, DateTime dataLotto, string colonna, DomSelezionata selezionata, TipoPagamento tpPag)
        {
            decimal ret = 0;
            string strSql;
            object result;
            IDbCommand cmd;
            DbProvider dbPro = new DbProvider();
            DateTime dataFinale;

            strSql = String.Format(@"SELECT COUNT(1)
                                     FROM information_schema.columns
                                     WHERE Column_Name = '{0}'
                                       AND Table_Schema = 'dbo'
                                       AND Table_Name = 'CertSp_Dettaglio'
                                       AND Numeric_Precision IS NOT NULL ",
                                   colonna);
            cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            result = dbPro.ExecuteScalar(cmd);
            if (result != null)
            {
                decimal.TryParse(result.ToString(), out ret);
            }
            // Il nome della colonna è sbagliato oppure la colonna non è numerica.
            if (ret == 0)
            {
                return ret;
            }

            // Se sono qua la colonna esiste. Pulisco le variabili e procedo con i calcoli.
            dataFinale = getDataUltimoFinale_ByDataLotto(dataLotto);
            ret = 0;
            strSql = null;
            cmd = null;
            result = null;
            strSql = String.Format(@"SELECT SUM({0}) FROM {1} WHERE DataFine  > @dataFinale 
                                                                AND DataFine <= @dataLotto 
                                                                AND CodPsr    = @codPsr " + 
                                                                WhereTipoDomande(tpDmn) + 
                                                                WhereTipoPagamento(tpPag) + 
                                                                WhereSelezionata(selezionata),
                                   colonna,
                                   //vistaDtt);
                                   vistaGrp);
            cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@dataFinale", dataFinale.ToString("yyyyMMdd")));
            cmd.Parameters.Add(new SqlParameter("@dataLotto", dataLotto.ToString("yyyyMMdd")));
            cmd.Parameters.Add(new SqlParameter("@codPsr", codPsr));
            result = dbPro.ExecuteScalar(cmd);
            dbPro.Close();
            if (result != null)
            {
                decimal.TryParse(result.ToString(), out ret);
            }
            return ret;
        }

        public decimal SommaImporti_All(TipoDomande tpDmn, string colonna, DomSelezionata selezionata, TipoPagamento tpPag, DomDefinitiva domDef)
        {
            decimal ret = 0;
            string strSql;
            object result;
            IDbCommand cmd;
            DbProvider dbPro = new DbProvider();

            strSql = String.Format(@"SELECT COUNT(1)
                                     FROM information_schema.columns
                                     WHERE Column_Name = '{0}'
                                       AND Table_Schema = 'dbo'
                                       AND Table_Name = 'CertSp_Dettaglio'
                                       AND Numeric_Precision IS NOT NULL ",
                                   colonna);
            cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            result = dbPro.ExecuteScalar(cmd);
            if (result != null)
            {
                decimal.TryParse(result.ToString(), out ret);
            }
            // Il nome della colonna è sbagliato oppure la colonna non è numerica.
            if (ret == 0)
            {
                return ret;
            }

            // Se sono qua la colonna esiste. Pulisco le variabili e procedo con i calcoli.
            ret = 0;
            strSql = null;
            cmd = null;
            result = null;
            strSql = String.Format(@"SELECT SUM({0}) FROM {1} ",
                                   colonna,
                                   vistaDtt);
            switch (domDef)
            {
                case DomDefinitiva.Si:
                    strSql += " WHERE Definitivo = 'TRUE' ";
                    break;
                case DomDefinitiva.No:
                    strSql += " WHERE Definitivo = 'FALSE' ";
                    break;
                case DomDefinitiva.Tutte:
                    strSql += "WHERE 1 = 1 ";
                    break;
            }
            strSql += WhereTipoDomande(tpDmn);
            strSql += WhereTipoPagamento(tpPag);
            strSql += WhereSelezionata(selezionata);

            cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            result = dbPro.ExecuteScalar(cmd);
            dbPro.Close();
            if (result != null)
            {
                decimal.TryParse(result.ToString(), out ret);
            }
            return ret;
        }

        public class RigaStrumentiFinanziari
        {
            public string  Asse { get; set; }
            public decimal ImportoComplessivoContributi { get; set; }
            public decimal ImportoSpesaPubblica1 { get; set; }
            public decimal ImportoContributiErogati { get; set; }
            public decimal ImportoSpesaPubblica2 { get; set; }

            public RigaStrumentiFinanziari() { }
            public RigaStrumentiFinanziari(string asse, 
                                           decimal importoComplessivoContributi, 
                                           decimal importoSpesaPubblica1, 
                                           decimal importoContributiErogati, 
                                           decimal importoSpesaPubblica2)
            {
                Asse                            = asse;
                ImportoComplessivoContributi    = importoComplessivoContributi;
                ImportoSpesaPubblica1           = importoSpesaPubblica1;
                ImportoContributiErogati        = importoContributiErogati;
                ImportoSpesaPubblica2           = importoSpesaPubblica2;
            }
        }


        public List<RigaStrumentiFinanziari> GrigliaStrumentiFinanziari_Dati(string codPsr, DateTime dataLotto)
        {
            return GrigliaStrumentiFinanziari_Dati(codPsr, dataLotto, true);
        }


        public List<RigaStrumentiFinanziari> GrigliaStrumentiFinanziari_Dati(string codPsr, DateTime dataLotto, bool soloDefinitivi)
        {
            RigaStrumentiFinanziari rStr;
            List<RigaStrumentiFinanziari> ret = new List<RigaStrumentiFinanziari>();

            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spGrigliaStrumentiFinanziari_Dati"; 
            cmd.Parameters.Add(new SqlParameter("@codPsr", codPsr));
            cmd.Parameters.Add(new SqlParameter("@dataLotto", dataLotto));
            cmd.Parameters.Add(new SqlParameter("@soloDefinitivi", soloDefinitivi ? 1 : 0));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                rStr = new RigaStrumentiFinanziari();
                rStr.Asse                           = dbPro.DataReader["Asse"].ToString();
                rStr.ImportoComplessivoContributi   = Convert.ToDecimal(dbPro.DataReader["ImportoComplessivoContributi"]); 
                rStr.ImportoSpesaPubblica1          = Convert.ToDecimal(dbPro.DataReader["ImportoSpesaPubblica1"]);
                rStr.ImportoContributiErogati       = Convert.ToDecimal(dbPro.DataReader["ImportoContributiErogati"]);
                rStr.ImportoSpesaPubblica2          = Convert.ToDecimal(dbPro.DataReader["ImportoSpesaPubblica2"]);

                ret.Add(rStr);
            }
            dbPro.Close();

            return ret;
        }

        public class RigaSpesa
        {
            public string Asse { get; set; }
            public decimal ImportoContributo { get; set; }
            public decimal ImportoRendicontato { get; set; }

            public RigaSpesa() { }
            public RigaSpesa(string asse, decimal importoContributo, decimal importoRendicontato)
            {
                Asse = asse;
                ImportoContributo = importoContributo;
                ImportoRendicontato = importoRendicontato;
            }
        }

        public List<RigaSpesa> GrigliaSpesa_Dati(string codPsr, DateTime dataLotto, bool complessivi)
        {
            return GrigliaSpesa_Dati(codPsr, dataLotto, true, complessivi);
        }

        public List<RigaSpesa> GrigliaSpesa_Dati(string codPsr, DateTime dataLotto, bool soloDefinitivi, bool complessivi)
        {
            DateTime DataFine;
            RigaSpesa rSpe;
            List<RigaSpesa> ret = new List<RigaSpesa>();

            string strSql = String.Format(@"SELECT  Asse,
                                                    SUM(ISNULL(ImportoContributoPubblico_Incrementale, 0))  AS ImportoContributo,
                                                    SUM(ISNULL(SpesaAmmessa, 0))                            AS ImportoRendicontato
                                            FROM vCertSp_Dettaglio ");
            if (soloDefinitivi)
            {
                strSql += String.Format(@" WHERE DataFine    >  @dataFine
                                              AND DataFine    <= @dataLotto
                                              AND Definitivo  =  'TRUE'
                                              AND Selezionata =  'TRUE'
                                              AND CodPsr      =  @codPsr
                                            GROUP BY Asse");
            }
            else
            {
                strSql += String.Format(@" WHERE DataFine    >  @dataFine
                                              AND DataFine    <= @dataLotto
                                              AND Selezionata =  'TRUE'
                                              AND CodPsr      =  @codPsr
                                            GROUP BY Asse");
            }

            if (complessivi)
                DataFine = getDataInizioPrimoLottoDefinitivi(); //"01/01/2014";
            else
                DataFine = getDataUltimoFinale_ByDataLotto(dataLotto);

            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@codPsr", codPsr));
            cmd.Parameters.Add(new SqlParameter("@dataFine", DataFine.ToString("yyyyMMdd")));
            cmd.Parameters.Add(new SqlParameter("@dataLotto", dataLotto.ToString("yyyyMMdd")));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                rSpe = new RigaSpesa();
                rSpe.Asse = dbPro.DataReader["Asse"].ToString();
                rSpe.ImportoContributo = Convert.ToDecimal(dbPro.DataReader["ImportoContributo"]);
                rSpe.ImportoRendicontato = Convert.ToDecimal(dbPro.DataReader["ImportoRendicontato"]);

                ret.Add(rSpe);
            }
            dbPro.Close();

            return ret;
        }

        public class RigaAnticipi
        {
            public string Asse { get; set; }
            public decimal ContributoRendicontato { get; set; }
            public decimal ImportoCoperto3Anni { get; set; }
            public decimal ImportoOltre3Anni { get; set; }

            public RigaAnticipi() { }

            public RigaAnticipi(string asse, decimal contributoRendicontato, decimal importoCoperto3Anni, decimal importoOltre3Anni)
            {
                Asse = asse;
                ContributoRendicontato = contributoRendicontato;
                ImportoCoperto3Anni = importoCoperto3Anni;
                ImportoOltre3Anni = importoOltre3Anni;
            }
        }


        public List<RigaAnticipi> GrigliaAnticipi_Dati(string codPsr, DateTime dataLotto)
        {
            return GrigliaAnticipi_Dati(codPsr, dataLotto, true);
        }


        public List<RigaAnticipi> GrigliaAnticipi_Dati(string codPsr, DateTime dataLotto, bool soloDefinitivi)
        {
            RigaAnticipi rAnt;
            List<RigaAnticipi> ret = new List<RigaAnticipi>(); 

            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spGrigliaAnticipi_Dati";
            cmd.Parameters.Add(new SqlParameter("@DataLotto", dataLotto));
            cmd.Parameters.Add(new SqlParameter("@SoloDefinitivi", soloDefinitivi ? 1 : 0));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                rAnt = new RigaAnticipi();
                rAnt.Asse = dbPro.DataReader["Asse"].ToString();
                rAnt.ContributoRendicontato = Convert.ToDecimal(dbPro.DataReader["ContributoRendicontato"]);
                rAnt.ImportoCoperto3Anni = Convert.ToDecimal(dbPro.DataReader["ImportoCoperto3Anni"]);
                rAnt.ImportoOltre3Anni = Convert.ToDecimal(dbPro.DataReader["ImportoOltre3Anni"]);

                ret.Add(rAnt);
            }
            dbPro.Close();

            return ret;
        }

        #endregion

        #region Data edit

        public int SelezionataCambia(TipoId tipoId, int idRecord, bool isSeleziona)
        {
            DbProvider dbPro = new DbProvider();
            return this.SelezionataCambia(tipoId, idRecord, isSeleziona, dbPro);
        }

        public int SelezionataCambia(TipoId tipoId, int idRecord, bool isSeleziona, DbProvider _dbPro)
        {
            int ret = 0;
            IDbCommand cmd;
            string strSql;

            strSql = String.Format(@"UPDATE CertSp_Dettaglio 
                                     SET Selezionata  = '{0}',
                                         DataModifica = @DataModifica ",
                                   isSeleziona.ToString()
                                   );
            switch (tipoId)
            {
                case TipoId.IdCertSp:
                    strSql += @" WHERE IdCertSp = @Id ";
                    break;
                case TipoId.IdCertSp_Dettaglio:
                    strSql += @" WHERE IdCertSp_Dettaglio = @Id ";
                    break;
            }

            cmd = _dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@Id", idRecord));
            cmd.Parameters.Add(new SqlParameter("@DataModifica", DateTime.Now));
            ret = _dbPro.Execute(cmd);

            return ret;
        }

        public int SelezioneCambia_ByIdProgetto(int idCertSp, int idProgetto, bool isSelezionata)
        {
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd;
            int ret = 0;
            string strSql;

            strSql = String.Format(@"UPDATE CertSp_Dettaglio 
                                     SET Selezionata  = '{0}',
                                         DataModifica = @DataModifica 
                                     WHERE IdCertSp    = @IdCertSp
                                       AND Id_Progetto = @IdProgetto ",
                                   isSelezionata.ToString()
                                   );
            cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@IdCertSp", idCertSp));
            cmd.Parameters.Add(new SqlParameter("@IdProgetto", idProgetto));
            cmd.Parameters.Add(new SqlParameter("@DataModifica", DateTime.Now));
            ret = dbPro.Execute(cmd);
            
            return ret;
        }

        public int SalvaNote_ByIdProgetto(int idCertSp, int idProgetto, string nota)
        {
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd;
            int ret = 0;
            string strSql;

            strSql = String.Format(@"UPDATE CertSp_Dettaglio 
                                     SET Note         = '{0}',
                                         DataModifica = @DataModifica 
                                     WHERE IdCertSp    = @IdCertSp
                                       AND Id_Progetto = @IdProgetto ",
                                   nota
                                   );
            cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@IdCertSp", idCertSp));
            cmd.Parameters.Add(new SqlParameter("@IdProgetto", idProgetto));
            cmd.Parameters.Add(new SqlParameter("@DataModifica", DateTime.Now));
            ret = dbPro.Execute(cmd);

            return ret;
        }

        public int SalvaFile_ByIdProgetto(int idCertSp, int idProgetto, SiarLibrary.NullTypes.IntNT idFile)
        {
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd;
            int idFileI;
            int ret = 0;
            string strSql;

            if (idFile != null)
            {
                idFileI = idFile;
            }
            else
            {
                idFileI = 0;
            }

            strSql = String.Format(@"UPDATE CertSp_Dettaglio 
                                     SET Id_File      = {0},
                                         DataModifica = @DataModifica 
                                     WHERE IdCertSp    = @IdCertSp
                                       AND Id_Progetto = @IdProgetto ",
                                   idFileI
                                   );
            cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@IdCertSp", idCertSp));
            cmd.Parameters.Add(new SqlParameter("@IdProgetto", idProgetto));
            cmd.Parameters.Add(new SqlParameter("@DataModifica", DateTime.Now));
            ret = dbPro.Execute(cmd);

            return ret;
        }

        #endregion

        public List<RiepilogoPrevisioneProgettiCertificabili> GetRiepilogoPrevisioneProgettiCertificabili(string ente)
        {
            RiepilogoPrevisioneProgettiCertificabili riga;
            List<RiepilogoPrevisioneProgettiCertificabili> ret = new List<RiepilogoPrevisioneProgettiCertificabili>();

            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spGetRiepilogoPrevisioneProgettiCertificabili";
            cmd.Parameters.Add(new SqlParameter("@ENTE", ente));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                riga = new RiepilogoPrevisioneProgettiCertificabili();
                riga.Asse = int.Parse(dbPro.DataReader["ASSE"].ToString());
                riga.DaIstruire = Convert.ToDecimal(dbPro.DataReader["DA_ISTRUIRE"]);
                riga.DaValidare = Convert.ToDecimal(dbPro.DataReader["DA_VALIDARE"]);
                riga.DaCertificare = Convert.ToDecimal(dbPro.DataReader["DA_CERTIFICARE"]);

                ret.Add(riga);
            }
            dbPro.Close();

            return ret;
        }
    }
}
