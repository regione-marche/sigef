using System;
using System.Data;
using SiarLibrary;
using SiarDAL;
using System.Data.SqlClient;
using System.Collections.Generic;
using SiarLibrary.NullTypes;

namespace SiarBLL
{
    public partial class RigaGrigliaImporti : BaseObject
    {
        private string _descrizione;
        private DecimalNT _tutte;
        private DecimalNT _incluse;
        private DecimalNT _escluse;
        private DecimalNT _alto;
        private DecimalNT _medio;
        private DecimalNT _basso;

        public string Descrizione { get => _descrizione; set => _descrizione = value; }
        public DecimalNT Tutte { get => _tutte; set => _tutte = value; }
        public DecimalNT Incluse { get => _incluse; set => _incluse = value; }
        public DecimalNT Alto { get => _alto; set => _alto = value; }
        public DecimalNT Escluse { get => _escluse; set => _escluse = value; }
        public DecimalNT Medio { get => _medio; set => _medio = value; }
        public DecimalNT Basso { get => _basso; set => _basso = value; }
    }

    public partial class RigaGrigliaPercentuali : BaseObject
    {
        private string _descrizione;
        private DecimalNT _teorico;
        private DecimalNT _selezionato;
        private DecimalNT _definitivo;

        public DecimalNT Definitivo { get => _definitivo; set => _definitivo = value; }
        public DecimalNT Selezionato { get => _selezionato; set => _selezionato = value; }
        public DecimalNT Teorico { get => _teorico; set => _teorico = value; }
        public DecimalNT Descrizione { get => _descrizione; set => _descrizione = value; }
    }

    public partial class CntrlocoDettaglioCollectionProvider : ICntrlocoDettaglioProvider
	{
        public enum TipoDomande {Tutte, 
                                 Incluse, Escluse, Selezionate,
                                 Alta, Media, Bassa,
                                 SelAlta, SelMedia, SelBassa,
                                 DefAlta, DefMedia, DefBassa
        }

        const string vistaDtt = "vCntrLoco_Dettaglio",
                     vistaGrp = "vCntrLoco_Dettaglio_Prj";

        #region Sql string

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
                case TipoDomande.Alta:
                    strWhere = @" AND COALESCE(Esclusione, '') = ''
                                  AND RischioComp = 'Alta'";
                    break;
                case TipoDomande.Media:
                    strWhere = @" AND COALESCE(Esclusione, '') = ''
                                  AND RischioComp = 'Media'";
                    break;
                case TipoDomande.Bassa:
                    strWhere = @" AND COALESCE(Esclusione, '') = ''
                                  AND RischioComp = 'Bassa'";
                    break;
                case TipoDomande.SelAlta:
                    strWhere = @" AND Selezionata = 'TRUE'
                                  AND RischioComp = 'Alta'";
                    break;
                case TipoDomande.SelMedia:
                    strWhere = @" AND Selezionata = 'TRUE'
                                  AND RischioComp = 'Media'";
                    break;
                case TipoDomande.SelBassa:
                    strWhere = @" AND Selezionata = 'TRUE'
                                  AND RischioComp = 'Bassa'";
                    break;
                case TipoDomande.DefAlta:
                    strWhere = @" AND Definitivo = 'TRUE'
                                  AND Selezionata = 'TRUE'
                                  AND RischioComp = 'Alta'";
                    break;
                case TipoDomande.DefMedia:
                    strWhere = @" AND Definitivo = 'TRUE'
                                  AND Selezionata = 'TRUE'
                                  AND RischioComp = 'Media'";
                    break;
                case TipoDomande.DefBassa:
                    strWhere = @" AND Definitivo = 'TRUE'
                                  AND Selezionata = 'TRUE'
                                  AND RischioComp = 'Bassa'";
                    break;
            }
            return strWhere;
        }

        #endregion

        #region Get object

        /// <summary>
        /// Collection di CntrlocoDettaglio filtrati per IdLoco
        /// </summary>
        /// <param name="idLoco">Lotto da filtrare</param>
        /// <returns>Collection di CntrlocoDettaglio</returns>
        public CntrlocoDettaglioCollection getBy_IdLoco(int idLoco)
        {
            CntrlocoDettaglio det = null;
            CntrlocoDettaglioCollection dets = new CntrlocoDettaglioCollection();

            string strSql = String.Format(@"SELECT * FROM {0} WHERE IdLoco = @IdLoco ",
                                          vistaDtt);

            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@IdLoco", idLoco));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                det = (CntrlocoDettaglioDAL.GetFromDatareader(dbPro));
                dets.Add(det);
            }
            dbPro.Close();

            return dets;
        }

        /// <summary>
        /// Collection di CntrlocoDettaglio filtrati per IdLoco e TipoDomande
        /// </summary>
        /// <param name="idLoco">Lotto da filtrare</param>
        /// <param name="tpDom">Tipo di Domande da filtrare</param>
        /// <param name="casuale">Ottenere i record in ordine casuale</param>
        /// <returns>Collection di CntrlocoDettaglio</returns>
        public CntrlocoDettaglioCollection getBy_IdLocoTipoDomanda(int idLoco, TipoDomande tpDom, bool casuale)
        {
            CntrlocoDettaglio det = null;
            CntrlocoDettaglioCollection dets = new CntrlocoDettaglioCollection();
            string strSql;

            if (casuale)
            {
                strSql = String.Format(@"SELECT *, ABS(CHECKSUM(NewId())) AS Casuale  
                                            FROM {0} 
                                            WHERE IdLoco = @IdLoco " + WhereTipoDomande(tpDom) +
                                            " ORDER BY Casuale ",
                                       vistaDtt);
            }
            else
            {
                strSql = String.Format(@"SELECT * FROM {0} WHERE IdLoco = @IdLoco " + WhereTipoDomande(tpDom),
                                       vistaDtt);
            }

            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@IdLoco", idLoco));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                det = (CntrlocoDettaglioDAL.GetFromDatareader(dbPro));
                dets.Add(det);
            }
            dbPro.Close();

            return dets;
        }

        /// <summary>
        /// Collection di CntrlocoDettaglio filtrati per IdLoco e TipoDomande raggruppate per progetto
        /// </summary>
        /// <param name="idLoco">Lotto da filtrare</param>
        /// <param name="tpDom">Tipo di Domande da filtrare</param>
        /// <param name="casuale">Ottenere i record in ordine casuale</param>
        /// <returns>Collection di CntrlocoDettaglio</returns>
        public CntrlocoDettaglioCollection getPrjBy_IdLocoTipoDomanda(int idLoco, TipoDomande tpDom, bool casuale)
        {
            CntrlocoDettaglio det = null;
            CntrlocoDettaglioCollection dets = new CntrlocoDettaglioCollection();
            string strSql;

            if (casuale)
            {
                strSql = String.Format(@"SELECT *, ABS(CHECKSUM(NewId())) AS Casuale 
                                            FROM {0} 
                                            WHERE IdLoco = @IdLoco " + WhereTipoDomande(tpDom) +
                                            " ORDER BY Casuale ",
                                       vistaGrp);
            }
            else
            {
                strSql = String.Format(@"SELECT * FROM {0} WHERE IdLoco = @IdLoco " + WhereTipoDomande(tpDom),
                                       vistaGrp);
            }

            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@IdLoco", idLoco));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                det = (CntrlocoDettaglioDAL.GetFromDatareader(dbPro));
                dets.Add(det);
            }
            dbPro.Close();

            return dets;
        }

        public CntrlocoDettaglio getPrjBy_IdProgetto(int idLoco, int idProgetto)
        {
            CntrlocoDettaglio det = null;
            string strSql;
            strSql = String.Format(@"SELECT * FROM {0} WHERE IdLoco = @IdLoco AND Id_Progetto = @IdProgetto ",
                                   vistaGrp);

            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@IdLoco", idLoco));
            cmd.Parameters.Add(new SqlParameter("@IdProgetto", idProgetto));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                det = (CntrlocoDettaglioDAL.GetFromDatareader(dbPro));
            }
            dbPro.Close();

            return det;
        }

        public CntrlocoDettaglioCollection getBy_IdProgetto(int idLoco, int idProgetto)
        {
            CntrlocoDettaglio det = null;
            CntrlocoDettaglioCollection dets = new CntrlocoDettaglioCollection();
            string strSql;

            strSql = String.Format(@"SELECT * FROM {0} WHERE IdLoco = @IdLoco AND Id_Progetto = @IdProgetto ",
                                   vistaDtt);

            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@IdLoco", idLoco));
            cmd.Parameters.Add(new SqlParameter("@IdProgetto", idProgetto));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                det = (CntrlocoDettaglioDAL.GetFromDatareader(dbPro));
                dets.Add(det);
            }
            dbPro.Close();

            return dets;
        }

        public List<int> getArrayIdLoco_IdProgetto(int idProgetto)
        {
            int det;
            List<int> list_det = new List<int>();
            string strSql;

            strSql = String.Format(@"SELECT DISTINCT IDLOCO FROM {0} WHERE Id_Progetto = @IdProgetto  ",
                                   vistaDtt);

            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@IdProgetto", idProgetto));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                det = Convert.ToInt32(dbPro.DataReader["IDLOCO"]);
                list_det.Add(det);
            }
            dbPro.Close();

            return list_det;
        }
        

        /// <summary>
        /// Collection di CntrlocoDettaglio filtrati per IdLoco e Selezionata
        /// </summary>
        /// <param name="idLocoEqualTo">IdLoco da filtrare</param>
        /// <param name="selezionataEqualTo">Valore di Selezionata da filtrare</param>
        /// <returns>Collection di CntrlocoDettaglio</returns>
        public CntrlocoDettaglioCollection Find(Nullable<int> idLocoEqualTo, Nullable<bool> selezionataEqualTo)
        {
            CntrlocoDettaglio det = null;
            CntrlocoDettaglioCollection dets = new CntrlocoDettaglioCollection();

            string strSql = @"SELECT * 
                              FROM {0} 
                             WHERE 1 = 1 ";

            if (idLocoEqualTo != null)
                strSql += "AND ((@IdLoco IS NULL) OR IDLOCO = @IdLoco) "; 
            if (selezionataEqualTo != null)
                strSql += "AND ((@SelezionataEqualTo IS NULL) OR SELEZIONATA = @selezionataEqualTo) ";

            strSql = String.Format(strSql, vistaDtt);

            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;

            if (idLocoEqualTo != null)
                cmd.Parameters.Add(new SqlParameter("@IdLoco", idLocoEqualTo));
            if (selezionataEqualTo != null) 
                cmd.Parameters.Add(new SqlParameter("@SelezionataEqualTo", selezionataEqualTo));

            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                det = (CntrlocoDettaglioDAL.GetFromDatareader(dbPro));
                dets.Add(det);
            }
            dbPro.Close();

            return dets;
        }

        #endregion

        # region Get totali

        /// <summary>
        /// Somma la colonna indicata in base a IdLoco e TipoDomande
        /// </summary>
        /// <param name="tpDmn">Tipo di domande in base alle quali creare il filtro</param>
        /// <param name="idLoco">Lotto da filtrare</param>
        /// <param name="colonna">Colonna da sommare</param>
        /// <returns>Risultato della somma</returns>
        public decimal Somma_Importi(TipoDomande tpDmn, int idLoco, string colonna)
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
                                       AND Table_Name = 'CntrLoco_Dettaglio'
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

            strSql = String.Format(@"SELECT SUM({0}) FROM {1} WHERE IdLoco = @IdLoco " + WhereTipoDomande(tpDmn),
                                   colonna,
                                   vistaDtt);

            cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@IdLoco", idLoco));

            result = dbPro.ExecuteScalar(cmd);
            dbPro.Close();

            if (result != null)
            {
                decimal.TryParse(result.ToString(), out ret);
            }
            return ret;
        }

        /// <summary>
        /// Somma la colonna indicata in base a IdLoco e TipoDomande degli importi riferiti ai progetti
        /// </summary>
        /// <param name="tpDmn">Tipo di domande in base alle quali creare il filtro</param>
        /// <param name="idLoco">Lotto da filtrare</param>
        /// <param name="colonna">Colonna da sommare</param>
        /// <returns>Risultato della somma</returns>
        public decimal Somma_Importi_Prj(TipoDomande tpDmn, int idLoco, string colonna)
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
                                       AND Table_Name = 'CntrLoco_Dettaglio'
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
            strSql = String.Format(@"SELECT SUM({0}) FROM {1} WHERE IdLoco = @IdLoco " + WhereTipoDomande(tpDmn),
                                   colonna,
                                   vistaGrp);

            cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@IdLoco", idLoco));

            result = dbPro.ExecuteScalar(cmd);
            dbPro.Close();

            if (result != null)
            {
                decimal.TryParse(result.ToString(), out ret);
            }
            return ret;
        }

        public List<RigaGrigliaImporti> Get_Totale_Importi_griglia(int idLoco)
        {
            List<RigaGrigliaImporti> ret = new List<RigaGrigliaImporti>();
            string strSql;
            IDbCommand cmd;
            DbProvider dbPro = new DbProvider();
            strSql = "CalcolaTotaliRiassuntiviControlliInLoco";
            cmd = dbPro.GetCommand();
            cmd.Parameters.Add(new SqlParameter("@IdLoco", idLoco));
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

        public List<RigaGrigliaPercentuali> Get_Totali_Percentuali_Griglia(int idLoco)
        {
            List<RigaGrigliaPercentuali> ret = new List<RigaGrigliaPercentuali>();
            string strSql;
            IDbCommand cmd;
            DbProvider dbPro = new DbProvider();
            strSql = "CalcolaPercentualiRiassuntiviControlliInLoco";
            cmd = dbPro.GetCommand();
            cmd.Parameters.Add(new SqlParameter("@IdLoco", idLoco));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = strSql;
            dbPro.InitDatareader(cmd);

            while (dbPro.DataReader.Read())
            {
                ret.Add(new RigaGrigliaPercentuali
                {
                    Descrizione = (string)dbPro.DataReader["descrizione"],
                    Teorico = new DecimalNT((dbPro.DataReader.IsDBNull(1) ? 0 : dbPro.DataReader["Teorico"])),
                    Selezionato = new DecimalNT((dbPro.DataReader.IsDBNull(2) ? 0 : dbPro.DataReader["Selezionato"])),
                    Definitivo = new DecimalNT((dbPro.DataReader.IsDBNull(3) ? 0 : dbPro.DataReader["Definitivo"]))
                });
            }
            dbPro.Close();
            return ret;
        }

    /// <summary>
    /// Calcola il 5% delle domande di pagamento incluse
    /// </summary>
    /// <param name="idLoco">Id lotto controllo in loco</param>
    /// <returns>Importo corrispondente al 5% delle domande di pagamento incluse</returns>
    public decimal Calcola5Percento(int idLoco)
        {
            decimal ret = 0;
            ret = (Somma_Importi(TipoDomande.Incluse, idLoco, "SpesaAmmessa") * 5) / 100;

            return ret;
        }

        /// <summary>
        /// Restituisce il valore corrispondente al rischio selezionato.
        /// </summary>
        /// <param name="tDom">Rischio: Alta, Media, Bassa. Gli altri elementi ritornano 0.</param>
        /// <param name="idLoco">Id lotto controllo in loco</param>
        /// <returns>Importo corrispondente la rischio</returns>
        public decimal CalcolaPercDel5(TipoDomande tDom, int idLoco)
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
            ret = (Calcola5Percento(idLoco) * prc5) / 100;
            return ret;
        }

        public decimal CalcolaPercDel5(decimal importo5perc, TipoDomande tDom)
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
        /// Permette di sapere se la domanda di pagamento è definitiva
        /// </summary>
        /// <param name="idLocoDettaglio">IdLoco_Dettaglio - Id loco domanda di pagamento</param>
        /// <returns>Se definitiva restituisce TRUE, altrimenti FALSE</returns>
        public bool IsDomandaDefinitiva(int idLocoDettaglio)
        {
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd;
            Object result;
            bool ret = false;
            string strSql;

            strSql = String.Format(@"SELECT COUNT(1) FROM {0} WHERE IdLoco_Dettaglio = @IdLocoDettaglio
                                                                AND Definitivo = 'TRUE'",
                                   vistaDtt);
            cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            result = dbPro.ExecuteScalar(cmd);
            if (result != null)
            {
                bool.TryParse(result.ToString(), out ret);
            }

            return ret;
        }

        #endregion

        #region Data edit

        /// <summary>
        /// Marca la domanda di pagamento come selezionata per il controllo in loco
        /// </summary>
        /// <param name="idLocoDettaglio">IdLocoDettaglio</param>
        /// <returns>Numero record modificati</returns>
        public int SeleziondaDomandaPagamento(int idLocoDettaglio)
        {
            DbProvider dbPro = new DbProvider();
            return this.SelezionaDomandaPagamento(idLocoDettaglio, dbPro);
        }

        /// <summary>
        /// Marca la domanda di pagamento come selezionata per il controllo in loco
        /// </summary>
        /// <param name="idLocoDettaglio">IdLocoDettaglio</param>
        /// <param name="_dbPro">DbProvider da utilizzare</param>
        /// <returns>Numero record modificati</returns>
        public int SelezionaDomandaPagamento(int idLocoDettaglio, DbProvider _dbPro)
        {
            int ret = 0;
            IDbCommand cmd;

            string strSql = @"UPDATE CntrLoco_Dettaglio 
                              SET Selezionata  = 'TRUE',
                                  DataModifica = @DataModifica
                              WHERE IdLoco_Dettaglio = @IdLocoDettaglio";
            cmd = _dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@IdLocoDettaglio", idLocoDettaglio));
            cmd.Parameters.Add(new SqlParameter("@DataModifica", DateTime.Now));
            ret = _dbPro.Execute(cmd);

            return ret;
        }

        public int SeleziondaDomandaPagamento_ByPrj(int idLoco, int idProgetto)
        {
            DbProvider dbPro = new DbProvider();
            return this.SelezionaDomandaPagamento_ByPrj(idLoco, idProgetto, dbPro);
        }

        public int SelezionaDomandaPagamento_ByPrj(int idLoco, int idProgetto, DbProvider _dbPro)
        {
            int ret = 0;
            IDbCommand cmd;

            string strSql = @"UPDATE CntrLoco_Dettaglio 
                              SET Selezionata  = 'TRUE',
                                  DataModifica = @DataModifica
                              WHERE IdLoco      = @IdLoco
                                AND Id_Progetto = @IdProgetto ";
            cmd = _dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@IdLoco", idLoco));
            cmd.Parameters.Add(new SqlParameter("@IdProgetto", idProgetto));
            cmd.Parameters.Add(new SqlParameter("@DataModifica", DateTime.Now));
            ret = _dbPro.Execute(cmd);

            return ret;
        }

        /// <summary>
        /// Imposta a FALSE il flag Selezionata per il lotto indicato
        /// </summary>
        /// <param name="idLoco">IdLoco - Lotto da modificare</param>
        /// <param name="_dbPro">DbProvider da utilizzare</param>
        public void AzzeraSelezionate(int idLoco, DbProvider _dbPro)
        {
            IDbCommand cmd;

            string strSql = @"UPDATE CntrLoco_Dettaglio
                              SET Selezionata  = 'FALSE',
                                  DataModifica = @DataModifica
                              WHERE IdLoco = @IdLoco";
            cmd = _dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@IdLoco", idLoco));
            cmd.Parameters.Add(new SqlParameter("@DataModifica", DateTime.Now));
            _dbPro.Execute(cmd);
        }

        /// <summary>
        /// Seleziona in modo casuale le domande da sottoporro a controllo in loco
        /// </summary>
        /// <param name="idLoco">IdLoco - Lotto da cui selezionare le domande</param>
        public void SelezionaDomande(int idLoco)
        {
            CntrlocoTesta testa = new CntrlocoTesta();
            CntrlocoTestaCollectionProvider tstPro = new CntrlocoTestaCollectionProvider();

            CntrlocoDettaglioCollection detAlta;
            CntrlocoDettaglioCollection detMedia;
            CntrlocoDettaglioCollection detBassa;
            CntrlocoDettaglioCollectionProvider detPro = new CntrlocoDettaglioCollectionProvider();

            DbProvider dbPro;

            decimal obiettivo5 = this.Calcola5Percento(idLoco);
            decimal obiettivoAlta = this.CalcolaPercDel5(TipoDomande.Alta, idLoco);
            decimal obiettivoMedia = this.CalcolaPercDel5(TipoDomande.Media, idLoco);
            decimal obiettivoBassa = this.CalcolaPercDel5(TipoDomande.Bassa, idLoco);

            decimal effettivo5 = 0;
            decimal effettivoAlta = 0;
            decimal effettivoMedia = 0;
            decimal effettivoBassa = 0;

            testa = tstPro.GetById(idLoco);
            detAlta = detPro.getPrjBy_IdLocoTipoDomanda(idLoco, TipoDomande.Alta, true);
            detMedia = detPro.getPrjBy_IdLocoTipoDomanda(idLoco, TipoDomande.Media, true);
            detBassa = detPro.getPrjBy_IdLocoTipoDomanda(idLoco, TipoDomande.Bassa, true);

            dbPro = new DbProvider();
            try
            {                
                dbPro.BeginTran();

                if (testa.Definitivo.Value == true)
                {
                    throw new SiarException("Non è possibile modificare un lotto definitivo");
                }

                // Pulizia delle domande selezionate prima di selezionarne di nuove
                AzzeraSelezionate(idLoco, dbPro);

                // Alta
                foreach (CntrlocoDettaglio det in detAlta)
                {
                    effettivo5 += det.Spesaammessa;
                    effettivoAlta += det.Spesaammessa;
                    SelezionaDomandaPagamento_ByPrj(det.Idloco, det.IdProgetto, dbPro);
                    if (effettivoAlta >= obiettivoAlta)
                    {
                        break;
                    }
                }

                // Media
                foreach (CntrlocoDettaglio det in detMedia)
                {
                    effettivo5 += det.Spesaammessa;
                    effettivoMedia += det.Spesaammessa;
                    SelezionaDomandaPagamento_ByPrj(det.Idloco, det.IdProgetto, dbPro);
                    if ((effettivoMedia >= obiettivoMedia) &&
                        (effettivo5 > (obiettivoMedia + obiettivoAlta)))
                    {
                        break;
                    }
                }
                // Bassa
                foreach (CntrlocoDettaglio det in detBassa)
                {
                    effettivo5 += det.Spesaammessa;
                    effettivoBassa += det.Spesaammessa;
                    SelezionaDomandaPagamento_ByPrj(det.Idloco, det.IdProgetto, dbPro);
                    if ((effettivoBassa >= obiettivoBassa) &&
                       (effettivo5 > (obiettivoBassa + obiettivoMedia + obiettivoAlta)))
                    {
                        break;
                    }
                }

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
        }

        #endregion

        #region Controlli checklist

        /// <summary>
        /// Esito della checklist dei controlli in loco 
        /// </summary>
        /// <param name="idLocoDettaglio">Id del loco dettaglio di cui voglio sapere l'esito</param>
        /// <param name="irregolarita_provider">Provider delle irregolarità (opzionale)</param>
        /// <returns>Esito della checklist</returns>
        public string verificaEsitoChecklistCntrLoco(int idLocoDettaglio, IrregolaritaCollectionProvider irregolarita_provider)
        {
            string esito = "";
            IrregolaritaCollectionProvider irr_provider = (irregolarita_provider == null) ? new IrregolaritaCollectionProvider() : irregolarita_provider;

            try
            {
                var testata_provider = new TestataControlliLocoCollectionProvider();
                var testate_collection = testata_provider.Find(null, null, idLocoDettaglio, null, null, null, null);

                if (testate_collection.Count > 0)
                {
                    var testata = testate_collection[0];

                    if (testata.EsitoTestata != null && testata.EsitoTestata)
                    {
                        if (irr_provider.Find(null, null, testata.IdProgetto, null, null).Count > 0)
                            esito = "Parzialmente negativo";
                        else
                            esito = "Positivo";
                    }
                    else if (testate_collection[0].EsitoTestata != null && !testate_collection[0].EsitoTestata)
                        esito = "Negativo";
                    else
                        esito = "Non verificata";
                }
                else
                    esito = "Non verificata";
            }
            catch (Exception ex) { esito = ex.ToString(); }

            return esito;
        }

        /// <summary>
        /// Collection di CntrlocoDettaglio filtrati per IdLoco e Selezionata contenente l'esito della checklist e gli importi irregolari
        /// </summary>
        /// <param name="idLocoEqualTo">IdLoco da filtrare</param>
        /// <param name="selezionataEqualTo">Valore di Selezionata da filtrare</param>
        /// <returns>Collection di CntrlocoDettaglio contenente l'esito della checklist e gli importi irregolari</returns>
        public CntrlocoDettaglioCollection FindConEsitoChecklistCntrLoco(IntNT idLocoEqualTo, BoolNT selezionataEqualTo)
        {
            CntrlocoDettaglioCollection dets = new CntrlocoDettaglioCollection();
            
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "FindConEsitoChecklistCntrLoco";
            if (idLocoEqualTo != null)
                cmd.Parameters.Add(new SqlParameter("IdLoco", idLocoEqualTo.Value));
            if (selezionataEqualTo != null)
                cmd.Parameters.Add(new SqlParameter("SelezionataEqualTo", selezionataEqualTo.Value));
            
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                var det = CntrlocoDettaglioDAL.GetFromDatareader(DbProviderObj);
                det.AdditionalAttributes.Add("ImportoIrregolareAmmesso", new DecimalNT(DbProviderObj.DataReader["IMPORTO_IRREGOLARE_AMMESSO"]));
                det.AdditionalAttributes.Add("ImportoIrregolareConcesso", new DecimalNT(DbProviderObj.DataReader["IMPORTO_IRREGOLARE_CONCESSO"]));
                det.AdditionalAttributes.Add("EsitoChecklist", new StringNT(DbProviderObj.DataReader["ESITO_CHECKLIST"]));
                dets.Add(det);
            }
            
            DbProviderObj.Close();
            
            return dets;
        }

        public void EscludiDomanda(int idLoco, int idProgetto, string motivoEsclusione)
        {
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd;

            string strSql;

            //Assegna Esclusione
            strSql = @"UPDATE CntrLoco_Dettaglio
                       SET Esclusione   = @MotivoEsclusione
                       WHERE IdLoco = @IdLoco
                       AND Id_Progetto=@IdProgetto";
            cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@IdLoco", idLoco));
            cmd.Parameters.Add(new SqlParameter("@MotivoEsclusione", motivoEsclusione));
            cmd.Parameters.Add(new SqlParameter("@IdProgetto", idProgetto));
            dbPro.Execute(cmd);
            dbPro.Close();
        }
        #endregion
    }
}