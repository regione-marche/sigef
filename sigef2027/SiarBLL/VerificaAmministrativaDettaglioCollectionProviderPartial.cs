using SiarLibrary;
using System.Data.SqlClient;
using System.Data;
using System;
using SiarDAL;
using System.Collections.Generic;
using SiarLibrary.NullTypes;


namespace SiarBLL
{
    public partial class VerificaAmministrativaDettaglioCollectionProvider : IVerificaAmministrativaDettaglioProvider
    {
        public enum TipoDomande
        {
            Tutte,
            Incluse, Escluse, Selezionate,
            Sempre, Alta, Media, Bassa,
            SelSempre, SelAlta, SelMedia, SelBassa,
            DefSempre, DefAlta, DefMedia, DefBassa
        }

        const string vistaDtt = "VVERIFICA_AMMINISTRATIVA_DETTAGLIO",
            vistaGrp = "VVERIFICA_AMMINISTRATIVA_DETTAGLIO_PRJ";

        private string WhereTipoDomande(TipoDomande tpDmn)
        {
            string strWhere = string.Empty;

            switch (tpDmn)
            {
                case TipoDomande.Tutte:
                    // Nessun filtro
                    break;
                case TipoDomande.Incluse:
                    strWhere = " AND COALESCE(Esclusione, '') = '' ";
                    break;
                case TipoDomande.Escluse:
                    strWhere = " AND COALESCE(Esclusione, '') <> ''";
                    break;
                case TipoDomande.Selezionate:
                    strWhere = " AND Selezionata = 'TRUE' ";
                    break;
                case TipoDomande.Sempre:
                    strWhere = @" AND RISCHIO_COMPLESSIVO = 'Sempre'";
                    break;
                case TipoDomande.Alta:
                    strWhere = @" AND COALESCE(Esclusione, '') = ''
                                  AND RISCHIO_COMPLESSIVO = 'Alta'";
                    break;
                case TipoDomande.Media:
                    strWhere = @" AND COALESCE(Esclusione, '') = ''
                                  AND RISCHIO_COMPLESSIVO = 'Media'";
                    break;
                case TipoDomande.Bassa:
                    strWhere = @" AND COALESCE(Esclusione, '') = ''
                                  AND RISCHIO_COMPLESSIVO = 'Bassa'";
                    break;
                case TipoDomande.SelSempre:
                    strWhere = @" AND Selezionata = 'TRUE'
                                  AND RISCHIO_COMPLESSIVO = 'Sempre'";
                    break;
                case TipoDomande.SelAlta:
                    strWhere = @" AND Selezionata = 'TRUE'
                                  AND RISCHIO_COMPLESSIVO = 'Alta'";
                    break;
                case TipoDomande.SelMedia:
                    strWhere = @" AND Selezionata = 'TRUE'
                                  AND RISCHIO_COMPLESSIVO = 'Media'";
                    break;
                case TipoDomande.SelBassa:
                    strWhere = @" AND Selezionata = 'TRUE'
                                  AND RISCHIO_COMPLESSIVO = 'Bassa'";
                    break;
                case TipoDomande.DefSempre:
                    strWhere = @" AND Definitivo = 'TRUE'
                                  AND Selezionata = 'TRUE'
                                  AND RISCHIO_COMPLESSIVO = 'Sempre'";
                    break;
                case TipoDomande.DefAlta:
                    strWhere = @" AND Definitivo = 'TRUE'
                                  AND Selezionata = 'TRUE'
                                  AND RISCHIO_COMPLESSIVO = 'Alta'";
                    break;
                case TipoDomande.DefMedia:
                    strWhere = @" AND Definitivo = 'TRUE'
                                  AND Selezionata = 'TRUE'
                                  AND RISCHIO_COMPLESSIVO = 'Media'";
                    break;
                case TipoDomande.DefBassa:
                    strWhere = @" AND Definitivo = 'TRUE'
                                  AND Selezionata = 'TRUE'
                                  AND RISCHIO_COMPLESSIVO = 'Bassa'";
                    break;
            }
            return strWhere;
        }

        /// <summary>
        /// Somma la colonna indicata in base a IdLotto e TipoDomande
        /// </summary>
        /// <param name="tpDmn">Tipo di domande in base alle quali creare il filtro</param>
        /// <param name="idLotto">Lotto da filtrare</param>
        /// <param name="colonna">Colonna da sommare</param>
        /// <returns>Risultato della somma</returns>
        public decimal Somma_Importi(TipoDomande tpDmn, int idLotto, string colonna)
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
                                       AND Table_Name = 'VERIFICA_AMMINISTRATIVA_DETTAGLIO'
                                       AND Numeric_Precision IS NOT NULL",
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

            strSql = String.Format(@"SELECT SUM({0}) 
                                    FROM {1} 
                                    WHERE ID_LOTTO = @IdLotto " + WhereTipoDomande(tpDmn),
                                   colonna,
                                   vistaDtt);

            cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@IdLotto", idLotto));

            result = dbPro.ExecuteScalar(cmd);
            dbPro.Close();

            if (result != null)
            {
                decimal.TryParse(result.ToString(), out ret);
            }
            return ret;
        }

        private decimal Calcola40Percento(int idLotto)
        {
            decimal ret = 0;
            //Non sommo la SPESA_AMMESSA perchè sarebbe a 0 per gli anticipi, da pass Funzionalita' #209277 prendo il contributo ammesso
            ret = (Somma_Importi(TipoDomande.Incluse, idLotto, "IMPORTO_CONTRIBUTO_PUBBLICO_INCREMENTALE") * 40) / 100;

            return ret;
        }

        private decimal CalcolaImportoSempre(int idLotto)
        {
            decimal ret = 0;
            //Non sommo la SPESA_AMMESSA perchè sarebbe a 0 per gli anticipi, da pass Funzionalita' #209277 prendo il contributo ammesso
            ret = (Somma_Importi(TipoDomande.Sempre, idLotto, "IMPORTO_CONTRIBUTO_PUBBLICO_INCREMENTALE") * 40) / 100;

            return ret;
        }

        /// <summary>
        /// Restituisce il valore corrispondente al rischio selezionato.
        /// </summary>
        /// <param name="tDom">Rischio: Alta, Media, Bassa. Gli altri elementi ritornano 0.</param>
        /// <param name="idLotto">Id lotto controllo in loco</param>
        /// <returns>Importo corrispondente al rischio</returns>
        private decimal CalcolaPercDel40(TipoDomande tDom, int idLotto)
        {
            decimal ret = 0;
            decimal prc40 = 100;

            switch (tDom)
            {
                case TipoDomande.Alta:
                    prc40 = 50;
                    break;
                case TipoDomande.Media:
                    prc40 = 30;
                    break;
                case TipoDomande.Bassa:
                    prc40 = 20;
                    break;
                default:
                    return 0;
            }

            //decimal importoTotale = Somma_Importi(TipoDomande.Incluse, idLotto, "SPESA_AMMESSA");
            //decimal importoSempre = Somma_Importi(TipoDomande.Sempre, idLotto, "SPESA_AMMESSA");

            ret = (Calcola40Percento(idLotto) * prc40) / 100;
            return ret;
        }

        private decimal CalcolaPercDel40(decimal importo5perc, TipoDomande tDom)
        {
            decimal ret = 0;
            decimal prc5 = 100;

            switch (tDom)
            {
                case TipoDomande.Alta:
                    prc5 = 50;
                    break;
                case TipoDomande.Media:
                    prc5 = 30;
                    break;
                case TipoDomande.Bassa:
                    prc5 = 20;
                    break;
                default:
                    return 0;
            }
            ret = (importo5perc * prc5) / 100;
            return ret;
        }

        /// <summary>
        /// Imposta a FALSE il flag Selezionata per il lotto indicato
        /// </summary>
        /// <param name="idLotto">IdLoco - Lotto da modificare</param>
        /// <param name="_dbPro">DbProvider da utilizzare</param>
        public void AzzeraSelezionate(int idLotto, string operatore, DbProvider _dbPro)
        {
            IDbCommand cmd;

            string strSql = @"UPDATE VERIFICA_AMMINISTRATIVA_DETTAGLIO
                              SET Selezionata  = 0,
                                  OPERATORE_MODIFICA = @OperatoreModifica,
                                  DATA_MODIFICA = @DataModifica
                              WHERE Id_LOTTO = @IdLotto";
            cmd = _dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@IdLotto", idLotto));
            cmd.Parameters.Add(new SqlParameter("@OperatoreModifica", operatore));
            cmd.Parameters.Add(new SqlParameter("@DataModifica", DateTime.Now));
            _dbPro.Execute(cmd);
        }

        /// <summary>
        /// Collection di VERIFICA_AMMINISTRATIVA_DETTAGLIO filtrati per IdLotto e TipoDomande raggruppate per progetto
        /// </summary>
        /// <param name="idLotto">Lotto da filtrare</param>
        /// <param name="tpDom">Tipo di Domande da filtrare</param>
        /// <param name="casuale">Ottenere i record in ordine casuale</param>
        /// <returns>Collection di CntrlocoDettaglio</returns>
        public VerificaAmministrativaDettaglioCollection GetPrjBy_IdLottoTipoDomanda(int idLotto, TipoDomande tpDom, bool casuale)
        {
            VerificaAmministrativaDettaglio det = null;
            VerificaAmministrativaDettaglioCollection dets = new VerificaAmministrativaDettaglioCollection();
            string strSql;

            if (casuale)
            {
                strSql = String.Format(@"SELECT *, ABS(CHECKSUM(NewId())) AS Casuale 
                                            FROM {0} 
                                            WHERE ID_LOTTO = @IdLotto " + WhereTipoDomande(tpDom) +
                                            " ORDER BY Casuale ",
                                       vistaGrp);
            }
            else
            {
                strSql = String.Format(@"SELECT * 
                                        FROM {0} 
                                        WHERE ID_LOTTO = @IdLotto " + WhereTipoDomande(tpDom),
                                       vistaGrp);
            }

            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@IdLotto", idLotto));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                det = (VerificaAmministrativaDettaglioDAL.GetFromDatareader(dbPro));
                dets.Add(det);
            }
            dbPro.Close();

            return dets;
        }

        public VerificaAmministrativaDettaglio GetPrjBy_IdProgetto(int idLotto, int idProgetto)
        {
            VerificaAmministrativaDettaglio det = null;
            string strSql;
            strSql = String.Format(@"SELECT * 
                                    FROM {0} 
                                    WHERE ID_LOTTO = @IdLotto 
                                        AND Id_PROGETTO = @IdProgetto ",
                                   vistaGrp);

            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@IdLotto", idLotto));
            cmd.Parameters.Add(new SqlParameter("@IdProgetto", idProgetto));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                det = (VerificaAmministrativaDettaglioDAL.GetFromDatareader(dbPro));
            }
            dbPro.Close();

            return det;
        }

        public VerificaAmministrativaDettaglioCollection GetBy_IdProgetto(int idLotto, int idProgetto)
        {
            VerificaAmministrativaDettaglio det = null;
            VerificaAmministrativaDettaglioCollection dets = new VerificaAmministrativaDettaglioCollection();
            string strSql;

            strSql = String.Format(@"SELECT * 
                                    FROM {0} 
                                    WHERE Id_LOTTO = @IdLotto 
                                        AND ID_PROGETTO = @IdProgetto ",
                                   vistaDtt);

            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@IdLotto", idLotto));
            cmd.Parameters.Add(new SqlParameter("@IdProgetto", idProgetto));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                det = (VerificaAmministrativaDettaglioDAL.GetFromDatareader(dbPro));
                dets.Add(det);
            }
            dbPro.Close();

            return dets;
        }

        public int SelezionaDomandaPagamento_ByPrj(int idLotto, int idProgetto, string operatore, DbProvider _dbPro)
        {
            int ret = 0;
            IDbCommand cmd;

            string strSql = @"UPDATE VERIFICA_AMMINISTRATIVA_DETTAGLIO 
                              SET Selezionata  = 1,
                                  OPERATORE_MODIFICA = @OperatoreModifica,
                                  DATA_MODIFICA = @DataModifica
                              WHERE ID_LOTTO      = @IdLotto
                                AND Id_Progetto = @IdProgetto ";
            cmd = _dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@IdLotto", idLotto));
            cmd.Parameters.Add(new SqlParameter("@IdProgetto", idProgetto));
            cmd.Parameters.Add(new SqlParameter("@OperatoreModifica", operatore));
            cmd.Parameters.Add(new SqlParameter("@DataModifica", DateTime.Now));
            ret = _dbPro.Execute(cmd);

            return ret;
        }

        /// <summary>
        /// Seleziona in modo casuale le domande da sottoporre a verifiche amministrative
        /// </summary>
        /// <param name="idLotto">IdLotto - Lotto da cui selezionare le domande</param>
        public void SelezionaDomande(int idLotto, string operatore)
        {
            // NEW 
            VerificaAmministrativaTesta testa = new VerificaAmministrativaTesta();
            bool obiettivoRaggiunto = false;

            VerificaAmministrativaDettaglioCollection detSempre;
            VerificaAmministrativaDettaglioCollection detAlta;
            VerificaAmministrativaDettaglioCollection detMedia;
            VerificaAmministrativaDettaglioCollection detBassa;

            DecimalNT obiettivo40 = Calcola40Percento(idLotto);
            DecimalNT importoObiettivoAlta = CalcolaPercDel40(TipoDomande.Alta, idLotto);
            DecimalNT importoObiettivoMedia = CalcolaPercDel40(TipoDomande.Media, idLotto);
            DecimalNT importoObiettivoBassa = CalcolaPercDel40(TipoDomande.Bassa, idLotto);

            DecimalNT importo40 = 0;
            DecimalNT importoSempre = 0;
            DecimalNT effettivoAlta = 0;
            DecimalNT effettivoMedia = 0;
            DecimalNT effettivoBassa = 0;

            detSempre = GetPrjBy_IdLottoTipoDomanda(idLotto, TipoDomande.Sempre, true);
            detAlta = GetPrjBy_IdLottoTipoDomanda(idLotto, TipoDomande.Alta, true);
            detMedia = GetPrjBy_IdLottoTipoDomanda(idLotto, TipoDomande.Media, true);
            detBassa = GetPrjBy_IdLottoTipoDomanda(idLotto, TipoDomande.Bassa, true);

            try
            {
                DbProviderObj.BeginTran();
                var testaProvider = new VerificaAmministrativaTestaCollectionProvider(DbProviderObj);
                testa = testaProvider.GetById(idLotto);

                if (testa.Definitivo.Value == true)
                {
                    throw new SiarException("Non è possibile modificare un lotto definitivo");
                }

                // Pulizia delle domande selezionate prima di selezionarne di nuove
                AzzeraSelezionate(idLotto, operatore, DbProviderObj);

                // Sempre 
                foreach (VerificaAmministrativaDettaglio det in detSempre)
                {
                    importo40 += det.ImportoContributoPubblico.Value;
                    importoSempre += det.ImportoContributoPubblico.Value;

                    SelezionaDomandaPagamento_ByPrj(det.IdLotto, det.IdProgetto, operatore, DbProviderObj);
                }

                // Se con le operazioni estratte al 100 % supero l'obiettivo del 40% non estraggo altro
                if (importo40 < obiettivo40) 
                {
                    // altrimenti estraggo per rischio a partire dalle alte


                    // Alta
                    foreach (VerificaAmministrativaDettaglio det in detAlta)
                    {
                        if (!obiettivoRaggiunto)
                        {
                            importo40 += det.ImportoContributoPubblico.Value;
                            effettivoAlta += det.ImportoContributoPubblico.Value;

                            SelezionaDomandaPagamento_ByPrj(det.IdLotto, det.IdProgetto, operatore, DbProviderObj);

                            if (importo40 >= obiettivo40)
                            {
                                obiettivoRaggiunto = true;
                                break;
                            }
                            
                            if (effettivoAlta >= importoObiettivoAlta)
                            {
                                break;
                            }
                        }
                    }

                    // Media
                    foreach (VerificaAmministrativaDettaglio det in detMedia)
                    {
                        if (!obiettivoRaggiunto)
                        {
                            importo40 += det.ImportoContributoPubblico.Value;
                            effettivoMedia += det.ImportoContributoPubblico.Value;

                            SelezionaDomandaPagamento_ByPrj(det.IdLotto, det.IdProgetto, operatore, DbProviderObj);

                            if (importo40 >= obiettivo40)
                            {
                                obiettivoRaggiunto = true;
                                break;
                            }

                            if ((effettivoMedia >= importoObiettivoMedia) &&
                                (importo40 > (importoObiettivoMedia.Value + importoObiettivoAlta.Value)))
                            {
                                break;
                            }
                        }
                    }
                    // Bassa
                    foreach (VerificaAmministrativaDettaglio det in detBassa)
                    {
                        if (!obiettivoRaggiunto)
                        {
                            importo40 += det.ImportoContributoPubblico.Value;
                            effettivoBassa += det.ImportoContributoPubblico.Value;

                            SelezionaDomandaPagamento_ByPrj(det.IdLotto, det.IdProgetto, operatore, DbProviderObj);

                            if (importo40 >= obiettivo40)
                            {
                                obiettivoRaggiunto = true;
                                break;
                            }

                            if ((effettivoBassa >= importoObiettivoBassa) &&
                               (importo40 > (importoObiettivoBassa.Value + importoObiettivoMedia.Value + importoObiettivoAlta.Value)))
                            {
                                break;
                            }
                        }
                    }
                }

                DbProviderObj.Commit();
            }
            catch (Exception ex)
            {
                DbProviderObj.Rollback();
                throw ex;
            }
            finally
            {
                DbProviderObj.Close();
            }

            // OLD -- COSI' LA SELEZIONA
            /*
            VerificaAmministrativaTesta testa = new VerificaAmministrativaTesta();

            VerificaAmministrativaDettaglioCollection detAlta;
            VerificaAmministrativaDettaglioCollection detMedia;
            VerificaAmministrativaDettaglioCollection detBassa;

            //decimal obiettivo5 = Calcola40Percento(idLotto);
            DecimalNT obiettivoAlta = CalcolaPercDel40(TipoDomande.Alta, idLotto);
            DecimalNT obiettivoMedia = CalcolaPercDel40(TipoDomande.Media, idLotto);
            DecimalNT obiettivoBassa = CalcolaPercDel40(TipoDomande.Bassa, idLotto);

            DecimalNT effettivo5 = 0;
            DecimalNT effettivoAlta = 0;
            DecimalNT effettivoMedia = 0;
            DecimalNT effettivoBassa = 0;

            detAlta = GetPrjBy_IdLottoTipoDomanda(idLotto, TipoDomande.Alta, true);
            detMedia = GetPrjBy_IdLottoTipoDomanda(idLotto, TipoDomande.Media, true);
            detBassa = GetPrjBy_IdLottoTipoDomanda(idLotto, TipoDomande.Bassa, true);

            try
            {
                DbProviderObj.BeginTran();
                var testaProvider = new VerificaAmministrativaTestaCollectionProvider(DbProviderObj);
                testa = testaProvider.GetById(idLotto);

                if (testa.Definitivo.Value == true)
                {
                    throw new SiarException("Non è possibile modificare un lotto definitivo");
                }

                // Pulizia delle domande selezionate prima di selezionarne di nuove
                AzzeraSelezionate(idLotto, operatore, DbProviderObj);

                // Alta
                foreach (VerificaAmministrativaDettaglio det in detAlta)
                {
                    decimal valSpesa = det.SpesaAmmessa != null ? det.SpesaAmmessa.Value : 0;
                    effettivo5 += valSpesa;
                    effettivoAlta += valSpesa;
                    SelezionaDomandaPagamento_ByPrj(det.IdLotto, det.IdProgetto, operatore, DbProviderObj);
                    if (effettivoAlta >= obiettivoAlta)
                    {
                        break;
                    }
                }

                // Media
                foreach (VerificaAmministrativaDettaglio det in detMedia)
                {
                    decimal valSpesa = det.SpesaAmmessa != null ? det.SpesaAmmessa.Value : 0;
                    effettivo5 += valSpesa;
                    effettivoMedia += valSpesa;
                    SelezionaDomandaPagamento_ByPrj(det.IdLotto, det.IdProgetto, operatore, DbProviderObj);
                    if ((effettivoMedia >= obiettivoMedia) &&
                        (effettivo5 > (obiettivoMedia.Value + obiettivoAlta.Value)))
                    {
                        break;
                    }
                }
                // Bassa
                foreach (VerificaAmministrativaDettaglio det in detBassa)
                {
                    decimal valSpesa = det.SpesaAmmessa != null ? det.SpesaAmmessa.Value : 0;
                    effettivo5 += valSpesa;
                    effettivoBassa += valSpesa;
                    SelezionaDomandaPagamento_ByPrj(det.IdLotto, det.IdProgetto, operatore, DbProviderObj);
                    if ((effettivoBassa >= obiettivoBassa) &&
                       (effettivo5 > (obiettivoBassa.Value + obiettivoMedia.Value + obiettivoAlta.Value)))
                    {
                        break;
                    }
                }

                DbProviderObj.Commit();
            }
            catch (Exception ex)
            {
                DbProviderObj.Rollback();
                throw ex;
            }
            finally
            {
                DbProviderObj.Close();
            }
            */
        }

        /// <summary>
        /// Seleziona TUTTE le domande da sottoporre a verifiche amministrative
        /// </summary>
        /// <param name="idLotto">IdLotto - Lotto da cui selezionare le domande</param>
        public void SelezionaTutteDomande(int idLotto, string operatore)
        {
            try
            {
                DbProviderObj.BeginTran();
                var testaProvider = new VerificaAmministrativaTestaCollectionProvider(DbProviderObj);
                VerificaAmministrativaTesta testa = testaProvider.GetById(idLotto);

                if (testa.Definitivo.Value == true)
                {
                    throw new SiarException("Non è possibile modificare un lotto definitivo");
                }

                var dettagliList = Find(idLotto, null, null, null, null)
                    .ToArrayList<VerificaAmministrativaDettaglio>();

                // Pulizia delle domande selezionate prima di selezionarne di nuove
                AzzeraSelezionate(idLotto, operatore, DbProviderObj);

                foreach (VerificaAmministrativaDettaglio det in dettagliList)
                {
                    det.Selezionata = true;
                    det.DataModifica = DateTime.Now;
                    det.OperatoreModifica = operatore;
                    Save(det);
                }

                DbProviderObj.Commit();
            }
            catch (Exception ex)
            {
                DbProviderObj.Rollback();
                throw ex;
            }
            finally
            {
                DbProviderObj.Close();
            }
        }

        public List<RigaGrigliaImporti> GetTotaleImportiGriglia(int idLotto)
        {
            List<RigaGrigliaImporti> ret = new List<RigaGrigliaImporti>();
            string strSql;
            IDbCommand cmd;
            DbProvider dbPro = new DbProvider();
            strSql = "CalcolaTotaliRiassuntiviVerificheAmministrative";
            cmd = dbPro.GetCommand();
            cmd.Parameters.Add(new SqlParameter("@IdLotto", idLotto));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = strSql;
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                ret.Add(new RigaGrigliaImporti
                {
                    Descrizione = (string)dbPro.DataReader["Descrizione"],
                    Tutte = new DecimalNT(dbPro.DataReader["Tutte"]),
                    Incluse = new DecimalNT(dbPro.DataReader["Incluse"]),
                    Escluse = new DecimalNT(dbPro.DataReader["Escluse"]),
                    Alto = new DecimalNT(dbPro.DataReader["Alta"]),
                    Medio = new DecimalNT(dbPro.DataReader["Media"]),
                    Basso = new DecimalNT(dbPro.DataReader["Bassa"])
                });
            }
            dbPro.Close();
            return ret;
        }

        public List<RigaGrigliaPercentuali> GetTotaliPercentualiGriglia(int idLotto)
        {
            List<RigaGrigliaPercentuali> ret = new List<RigaGrigliaPercentuali>();
            string strSql;
            IDbCommand cmd;
            DbProvider dbPro = new DbProvider();
            strSql = "CalcolaPercentualiRiassuntiviVerificheAmministrative";
            cmd = dbPro.GetCommand();
            cmd.Parameters.Add(new SqlParameter("@IdLotto", idLotto));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = strSql;
            dbPro.InitDatareader(cmd);

            while (dbPro.DataReader.Read())
            {
                ret.Add(new RigaGrigliaPercentuali
                {
                    Descrizione = (string)dbPro.DataReader["descrizione"],
                    //Teorico = (decimal)(dbPro.DataReader.IsDBNull(1) ? 0 : dbPro.DataReader["Teorico"]),
                    //Selezionato = (decimal)(dbPro.DataReader.IsDBNull(2) ? 0 : dbPro.DataReader["Selezionato"]),
                    //Definitivo = (decimal)(dbPro.DataReader.IsDBNull(3) ? 0 : dbPro.DataReader["Definitivo"])
                    Teorico = new DecimalNT(dbPro.DataReader["Teorico"]),
                    Selezionato = new DecimalNT(dbPro.DataReader["Selezionato"]),
                    Definitivo = new DecimalNT(dbPro.DataReader["Definitivo"])
                });
            }
            dbPro.Close();
            return ret;
        }
    }
}
