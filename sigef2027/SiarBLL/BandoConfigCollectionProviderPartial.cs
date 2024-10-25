using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;

namespace SiarLibrary
{
    public partial class BandoConfig : BaseObject
    {
        /// <summary>Restituisce una stringa contenente le nature cup CON descrizione contenute nel campo valore separate da ';'.
        /// </summary>
        public string MultiValoreDescrizione()
        {
            if (!_Formato.Equals("multivalore"))
                return _Descrizione;

            string ret = string.Empty;
            string sSql;

            sSql = @"SELECT 
                        (SELECT STUFF((SELECT ';' + DESCRIZIONE
                                    FROM BANDO_CONFIG_TIPO_PARAMETRI 
				                    WHERE 1 = 1
					                    AND ';' + BANDO_CONFIG.VALORE + ';' like '%;' + BANDO_CONFIG_TIPO_PARAMETRI.CODICE + ';%'
					                    AND BANDO_CONFIG.COD_TIPO = BANDO_CONFIG_TIPO_PARAMETRI.COD_TIPO
                                    FOR XML PATH('')), 1, 1, '') AS Txt) AS DESCRIZIONE_STUFF
                    FROM BANDO_CONFIG
                    WHERE ID = @IdBandoConfig;";
            // Lettura dal db
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sSql;
            cmd.Parameters.Add(new SqlParameter("@IdBandoConfig", _Id.Value));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                ret = dbPro.DataReader.GetString(0);
            }
            dbPro.Close();

            return ret;
        }
    }
}

namespace SiarBLL
{
    public partial class BandoConfigCollectionProvider : IBandoConfigProvider
    {
        public BandoConfigCollection GetBandoConfig(int id_bando)
        {
            BandoConfigCollection cc = new BandoConfigCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGetBandoConfig";
            cmd.Parameters.Add(new SqlParameter("@ID_BANDO", id_bando));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read()) cc.Add(SiarDAL.BandoConfigDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return cc;
        }

        public string GetBandoConfig_TpAppalto(int idBando)
        {
            string ret = string.Empty;
            string sSql;

            sSql = @"SELECT TOP 1
                            VALORE
                     FROM Bando_Config
                     WHERE Cod_Tipo = 'TPAPPALTO'
                       AND ID_BANDO = @idBando
                       AND Attivo = 1
                     ORDER BY DATA_INIZIO DESC";
            // Lettura dal db
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sSql;
            cmd.Parameters.Add(new SqlParameter("@idBando", idBando));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                ret = dbPro.DataReader.GetString(0);
            }
            dbPro.Close();

            return ret;
        }

        public string GetBandoConfig_TpAppaltoDescrizione(int idBando)
        {
            string ret = string.Empty;
            string sSql;

            sSql = @"SELECT TOP 1
                            VALORE_DESCRIZIONE
                     FROM vBando_Config
                     WHERE Cod_Tipo = 'TPAPPALTO'
                       AND ID_BANDO = @idBando
                       AND Attivo = 1
                     ORDER BY DATA_INIZIO DESC";
            // Lettura dal db
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sSql;
            cmd.Parameters.Add(new SqlParameter("@idBando", idBando));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                ret = dbPro.DataReader.GetString(0);
            }
            dbPro.Close();

            return ret;
        }

        public string GetBandoConfig_UtStrumFin(int idBando)
        {
            string ret = string.Empty;
            string sSql;

            sSql = @"SELECT TOP 1
                            VALORE
                     FROM Bando_Config
                     WHERE Cod_Tipo = 'UTSTRUMFIN'
                       AND ID_BANDO = @idBando
                       AND Attivo = 1
                     ORDER BY DATA_INIZIO DESC";
            // Lettura dal db
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sSql;
            cmd.Parameters.Add(new SqlParameter("@idBando", idBando));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                ret = dbPro.DataReader.GetString(0);
            }
            dbPro.Close();

            return ret;
        }

        public bool GetBandoConfig_RichiediAutovalutazione(int idBando)
        {
            string ret = string.Empty;
            string sSql;

            sSql = @"SELECT TOP 1
                            VALORE
                     FROM Bando_Config
                     WHERE Cod_Tipo = 'RICHAUTOVAL'
                       AND ID_BANDO = @idBando
                       AND Attivo = 1
                     ORDER BY DATA_INIZIO DESC";
            // Lettura dal db
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sSql;
            cmd.Parameters.Add(new SqlParameter("@idBando", idBando));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                ret = dbPro.DataReader.GetString(0);
            }
            dbPro.Close();

            if (ret != null && ret != string.Empty && ret.ToUpper().Equals("TRUE"))
                return true;
            else
                return false;
        }

        public string GetBandoConfig_PregressoDomanda(int idBando)
        {
            string ret = string.Empty;
            string sSql;

            sSql = @"SELECT TOP 1
                            VALORE
                     FROM Bando_Config
                     WHERE Cod_Tipo = 'PREGDOM'
                       AND ID_BANDO = @idBando
                       AND Attivo = 1
                     ORDER BY DATA_INIZIO DESC";
            // Lettura dal db
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sSql;
            cmd.Parameters.Add(new SqlParameter("@idBando", idBando));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                ret = dbPro.DataReader.GetString(0);
            }
            dbPro.Close();

            return ret;
        }

        public string GetBandoConfig_PregressoRicevibilita(int idBando)
        {
            string ret = string.Empty;
            string sSql;

            sSql = @"SELECT TOP 1
                            VALORE
                     FROM Bando_Config
                     WHERE Cod_Tipo = 'PREGRIC'
                       AND ID_BANDO = @idBando
                       AND Attivo = 1
                     ORDER BY DATA_INIZIO DESC";
            // Lettura dal db
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sSql;
            cmd.Parameters.Add(new SqlParameter("@idBando", idBando));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                ret = dbPro.DataReader.GetString(0);
            }
            dbPro.Close();

            return ret;
        }

        public string GetBandoConfig_PregressoAmmissibilita(int idBando)
        {
            string ret = string.Empty;
            string sSql;

            sSql = @"SELECT TOP 1
                            VALORE
                     FROM Bando_Config
                     WHERE Cod_Tipo = 'PREGAMM'
                       AND ID_BANDO = @idBando
                       AND Attivo = 1
                     ORDER BY DATA_INIZIO DESC";
            // Lettura dal db
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sSql;
            cmd.Parameters.Add(new SqlParameter("@idBando", idBando));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                ret = dbPro.DataReader.GetString(0);
            }
            dbPro.Close();

            return ret;
        }

        public string GetBandoConfig_PregressoFinanziabilita(int idBando)
        {
            string ret = string.Empty;
            string sSql;

            sSql = @"SELECT TOP 1
                            VALORE
                     FROM Bando_Config
                     WHERE Cod_Tipo = 'PREGFIN'
                       AND ID_BANDO = @idBando
                       AND Attivo = 1
                     ORDER BY DATA_INIZIO DESC";
            // Lettura dal db
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sSql;
            cmd.Parameters.Add(new SqlParameter("@idBando", idBando));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                ret = dbPro.DataReader.GetString(0);
            }
            dbPro.Close();

            return ret;
        }

        public string GetBandoConfig_PregressoPDomandaPag(int idBando)
        {
            string ret = string.Empty;
            string sSql;

            sSql = @"SELECT TOP 1
                            VALORE
                     FROM Bando_Config
                     WHERE Cod_Tipo = 'PREGPDOM'
                       AND ID_BANDO = @idBando
                       AND Attivo = 1
                     ORDER BY DATA_INIZIO DESC";
            // Lettura dal db
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sSql;
            cmd.Parameters.Add(new SqlParameter("@idBando", idBando));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                ret = dbPro.DataReader.GetString(0);
            }
            dbPro.Close();

            return ret;
        }

        public string GetBandoConfig_PregressoIDomandaPag(int idBando)
        {
            string ret = string.Empty;
            string sSql;

            sSql = @"SELECT TOP 1
                            VALORE
                     FROM Bando_Config
                     WHERE Cod_Tipo = 'PREGIDOM'
                       AND ID_BANDO = @idBando
                       AND Attivo = 1
                     ORDER BY DATA_INIZIO DESC";
            // Lettura dal db
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sSql;
            cmd.Parameters.Add(new SqlParameter("@idBando", idBando));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                ret = dbPro.DataReader.GetString(0);
            }
            dbPro.Close();

            return ret;
        }

        public string GetBandoConfig_SismaLAbel(int idBando)
        {
            string ret = string.Empty;
            string sSql;

            sSql = @"SELECT TOP 1
                            VALORE
                     FROM Bando_Config
                     WHERE Cod_Tipo = 'SISMALABEL'
                       AND ID_BANDO = @idBando
                       AND Attivo = 1
                     ORDER BY DATA_INIZIO DESC";
            // Lettura dal db
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sSql;
            cmd.Parameters.Add(new SqlParameter("@idBando", idBando));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                ret = dbPro.DataReader.GetString(0);
            }
            dbPro.Close();

            return ret;
        }

        /// <summary>Restituisce una stringa contenente le nature cup SENZA descrizione contenute nel campo valore separate da ';'.
        /// <param name="idBando">Id del bando da cui verificare le nature cup permesse</param>  
        /// </summary>
        public string GetBandoConfig_NaturaCup(int idBando)
        {
            string ret = string.Empty;
            string sSql;

            sSql = @"SELECT TOP 1
                            VALORE
                     FROM Bando_Config
                     WHERE Cod_Tipo = 'NATURACUP'
                       AND ID_BANDO = @idBando
                       AND Attivo = 1
                     ORDER BY DATA_INIZIO DESC";
            // Lettura dal db
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sSql;
            cmd.Parameters.Add(new SqlParameter("@idBando", idBando));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                ret = dbPro.DataReader.GetString(0);
            }
            dbPro.Close();

            return ret;
        }

        /// <summary>Restituisce una lista di stringhe contenente le nature cup SENZA descrizione contenute nel campo valore separate da ';'.
        /// <param name="idBando">Id del bando da cui verificare le nature cup permesse</param>  
        /// </summary>
        public List<string> GetBandoConfig_NaturaCupList(int idBando)
        {
            var retList = new List<string>();
            var ret = GetBandoConfig_NaturaCup(idBando);

            if (ret.Length > 0)
                retList = ret.Split(';').ToList();

            return retList;
        }

        /// <summary>Restituisce una stringa contenente le nature cup SENZA descrizione contenute nel campo valore separate da ';'.
        /// <param name="idBando">Id del bando da cui verificare le nature cup permesse</param>  
        /// </summary>
        public string GetBandoConfig_EditImpresa(int idBando)
        {
            string ret = string.Empty;
            string sSql;

            sSql = @"SELECT TOP 1
                            VALORE
                     FROM Bando_Config
                     WHERE Cod_Tipo = 'BANDOENERGIA'
                       AND ID_BANDO = @idBando
                       AND Attivo = 1
                     ORDER BY DATA_INIZIO DESC";
            // Lettura dal db
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sSql;
            cmd.Parameters.Add(new SqlParameter("@idBando", idBando));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                ret = dbPro.DataReader.GetString(0);
            }
            dbPro.Close();

            return ret;
        }

        /// <summary>Restituisce una lista di stringhe contenente le nature cup CON descrizione contenute nel campo valore separate da ';'.
        /// <param name="idBando">Id del bando da cui verificare le nature cup permesse</param>  
        /// </summary>
        public List<string> GetNatureCupPermesse(int idBando)
        {
            try
            {
                var codNaturaCupBando = this.GetBandoConfig_NaturaCup(idBando);
                var bandoConfigList = this.GetBandoConfig(idBando)
                    .ToArrayList<BandoConfig>();
                var natureCupList = new List<string>();

                if (codNaturaCupBando != null)
                {
                    string natureCupDescPermesse = (from bc in bandoConfigList
                                                    where bc.CodTipo.Equals("NATURACUP")
                                                    select bc)
                                                    .First()
                                                    .MultiValoreDescrizione();

                    if (natureCupDescPermesse.Length > 0)
                        natureCupList = natureCupDescPermesse.Split(';').ToList();

                    return natureCupList;
                }
                else
                    throw new Exception("Il bando non ha limitazioni sulla Natura CUP.");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public string GetBandoConfig_QuotaFidej(int idBando)
        {
            string ret = string.Empty;
            string sSql;

            sSql = @"SELECT TOP 1
                            VALORE
                     FROM Bando_Config
                     WHERE Cod_Tipo = 'QUOTIMPGARFID'
                       AND ID_BANDO = @idBando
                       AND Attivo = 1
                     ORDER BY DATA_INIZIO DESC";
            // Lettura dal db
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sSql;
            cmd.Parameters.Add(new SqlParameter("@idBando", idBando));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                ret = dbPro.DataReader.GetString(0);
            }
            dbPro.Close();

            return ret;
        }

        public string GetBandoConfig_MesiDurataFidej(int idBando)
        {
            string ret = string.Empty;
            string sSql;

            sSql = @"SELECT TOP 1
                            VALORE
                     FROM Bando_Config
                     WHERE Cod_Tipo = 'MESIDURGARFID'
                       AND ID_BANDO = @idBando
                       AND Attivo = 1
                     ORDER BY DATA_INIZIO DESC";
            // Lettura dal db
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sSql;
            cmd.Parameters.Add(new SqlParameter("@idBando", idBando));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                ret = dbPro.DataReader.GetString(0);
            }
            dbPro.Close();

            return ret;
        }

        public string GetBandoConfig_TrasferimentoEnte(int idBando)
        {
            string ret = string.Empty;
            string sSql;

            sSql = @"SELECT TOP 1
                            VALORE
                     FROM Bando_Config
                     WHERE Cod_Tipo = 'TRASFENTE'
                       AND ID_BANDO = @idBando
                       AND Attivo = 1
                     ORDER BY DATA_INIZIO DESC";
            // Lettura dal db
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sSql;
            cmd.Parameters.Add(new SqlParameter("@idBando", idBando));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                ret = dbPro.DataReader.GetString(0);
            }
            dbPro.Close();

            return ret;
        }

        public string GetBandoConfig_OrganismiIntermedi(int idBando)
        {
            string ret = string.Empty;
            string sSql;

            sSql = @"SELECT TOP 1
                            VALORE
                     FROM Bando_Config
                     WHERE Cod_Tipo = 'ORGINTER'
                       AND ID_BANDO = @idBando
                       AND Attivo = 1
                     ORDER BY DATA_INIZIO DESC";
            // Lettura dal db
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sSql;
            cmd.Parameters.Add(new SqlParameter("@idBando", idBando));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                ret = dbPro.DataReader.GetString(0);
            }
            dbPro.Close();

            return ret;
        }

        public string GetBandoConfig_OrganismiIntermediPec(int idBando)
        {
            string ret = string.Empty;
            string sSql;

            sSql = @"SELECT TOP 1
                            VALORE
                     FROM Bando_Config
                     WHERE Cod_Tipo = 'ORGINTER_PEC'
                       AND ID_BANDO = @idBando
                       AND Attivo = 1
                     ORDER BY DATA_INIZIO DESC";
            // Lettura dal db
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sSql;
            cmd.Parameters.Add(new SqlParameter("@idBando", idBando));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                ret = dbPro.DataReader.GetString(0);
            }
            dbPro.Close();

            return ret;
        }

        public string GetBandoConfig_NascondiPInv(int idBando)
        {
            string ret = string.Empty;
            string sSql;

            sSql = @"SELECT TOP 1
                            VALORE
                     FROM Bando_Config
                     WHERE Cod_Tipo = 'NASCONDIPINV'
                       AND ID_BANDO = @idBando
                       AND Attivo = 1
                     ORDER BY DATA_INIZIO DESC";
            // Lettura dal db
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sSql;
            cmd.Parameters.Add(new SqlParameter("@idBando", idBando));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                ret = dbPro.DataReader.GetString(0);
            }
            dbPro.Close();

            return ret;
        }

        public string GetBandoConfig_MessTelegram(int idBando)
        {
            string ret = string.Empty;
            string sSql;

            sSql = @"SELECT TOP 1
                            VALORE
                     FROM Bando_Config
                     WHERE Cod_Tipo = 'MESSTELEGRAM'
                       AND ID_BANDO = @idBando
                       AND Attivo = 1
                     ORDER BY DATA_INIZIO DESC";
            // Lettura dal db
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sSql;
            cmd.Parameters.Add(new SqlParameter("@idBando", idBando));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                ret = dbPro.DataReader.GetString(0);
            }
            dbPro.Close();

            return ret;
        }
    }
}
