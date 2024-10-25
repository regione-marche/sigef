using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace web.Private.Gantt
{
    /// <summary>
    /// La pagina processa i seguenti parametri:
    /// idg = sempre richiesto = ID del GANTT su cui lavorare
    /// deleteIDS = id del passo di idg da eliminare; esegue l'azione Elimina seguita da "redirect"
    /// salvaDefIDG = id del gantt (==idg) da salvare come definitivo; esegue l'azione di salvataggio seguita da "redirect"
    /// eliminaIDG = id del gantt (==idg) da eliminare; esegue l'azione Elimina (se non ci sono passi) seguita da "redirect"
    /// </summary>
    public partial class Definizione : SiarLibrary.Web.PrivatePage
    {
        SiarLibrary.DbProvider _db = null;
        protected string _arrayJSTipiPassiList = "";
        protected int _idg = 0;
        protected string _idUO_Utente;

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "gantt";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _db = new SiarLibrary.DbProvider();

                if (Request.Params["idg"] != null && Request.Params["idg"].Trim() != "")
                    _idg = Convert.ToInt32(Request.Params["idg"]);
                if (_idg <= 0) Response.Redirect("ElencoBandi.aspx", true);

                #region "azioni di pagina"
                // elimina un passo
                if (Request.Params["deleteIDS"] != null && Request.Params["deleteIDS"].Trim() != "")
                {
                    int delID = Convert.ToInt32(Request.Params["deleteIDS"]);
                    string errDel = eliminaStep(delID, _idg);
                    if (errDel == String.Empty) Response.Redirect("Definizione.aspx?idg=" + _idg.ToString(), true);
                    else ShowError(errDel);
                }
                //salvaDefIDG: salva GANTT come definitivo
                if (Request.Params["salvaDefIDG"] != null && Request.Params["salvaDefIDG"].Trim() != "")
                {
                    int saveID = Convert.ToInt32(Request.Params["salvaDefIDG"]);
                    string errDel = salvaGanttDefinitivo(_idg);
                    if (errDel == String.Empty) Response.Redirect("ElencoBandi.aspx", true);
                    else ShowError(errDel);
                }
                //eliminaIDG
                if (Request.Params["eliminaIDG"] != null && Request.Params["eliminaIDG"].Trim() != "")
                {
                    int delID = Convert.ToInt32(Request.Params["salvaDefIDG"]);
                    string errDel = eliminaGantt(_idg);
                    if (errDel == String.Empty) Response.Redirect("ElencoBandi.aspx", true);
                    else ShowError(errDel);
                }

                #endregion

                // visualizza i vaori del gantt e dell'intervento: nome, stato, importi...
                IDbCommand cmd;
                cmd = _db.GetCommand();
                cmd.CommandText = @"SELECT GANTT.*, TIPO_GANTT_STATO.NOME, null as ID_TIPOOP_BANDO
                            FROM GANTT inner join 
                            TIPO_GANTT_STATO ON TIPO_GANTT_STATO.ID_STATO = GANTT.ID_STATO inner join 
                            GANTT_BANDO ON GANTT.ID_BANDO = GANTT_BANDO.ID_BANDO_GANTT
                            WHERE ID_GANTT = " + _idg;
                _db.InitDatareader(cmd);
                IDataReader dr = _db.DataReader;
                dr.Read();

                //...
                int stato = Convert.ToInt32(dr["ID_STATO"]);
                int tipoOperazioneBando = -1;
                if (dr["ID_TIPOOP"] != DBNull.Value) tipoOperazioneBando = Convert.ToInt32(dr["ID_TIPOOP"]);
                //...

                dr.Close();

                // 3 stati: definizione, compilazione e terminato
                if (stato != 0) Response.Redirect("ElencoBandi.aspx");

                popolaSelectUO();
                if(Operatore.Utente.CodEnte!="%")
                    _idUO_Utente = GetUO_ID(Operatore.Utente.CodEnte);
                else
                    _idUO_Utente = "0";
                visualizaPassi(_idg, tipoOperazioneBando);

                GetClassificazione(_idg);
            }
            catch (Exception exc)
            {
                ShowError(exc.Message);
            }
            finally
            {
                if (_db != null) _db.Close();
            }
        }

        /// <summary>
        /// Popoa la select delle UO
        /// </summary>
        /// <param name="tipoOperazioneBando"></param>
        private void popolaSelectUO()
        {

            IDbCommand cmd;
            cmd = _db.GetCommand();
            cmd.CommandText = @"SELECT ID_UO, NOME, TIPO FROM UO where DATA_CHIUSURA is null ORDER BY NOME";
            _db.InitDatareader(cmd);
            IDataReader dr = null;

            try
            {
                dr = _db.DataReader;

                while (dr.Read())
                    edUO.Items.Add(new ListItem(dr["TIPO"] + " - " + dr["NOME"].ToString(), dr["ID_UO"].ToString()));
                dr.Close();

                string selVal = Request[edUO.UniqueID];
                    //GetUO_ID(Operatore.Utente.CodEnte);
                if (selVal != null) edUO.SelectedValue = selVal;
            }
            catch (Exception ex)
            {
                if (dr != null && dr.IsClosed) dr.Close();
                throw ex;
            }
        }

        private string GetUO_ID(string cod_ente)
        { 
            string id_uo = null;
            IDbCommand cmd;
            cmd = _db.GetCommand();
            cmd.CommandText = @"SELECT ID_UO FROM GANTT_UO_SIGEF WHERE COD_ENTE_SIGEF='" + cod_ente + "'";
            _db.InitDatareader(cmd);
            IDataReader rd = _db.DataReader;
            if (rd.Read())
                if (rd["ID_UO"] != DBNull.Value) id_uo = rd["ID_UO"].ToString();
            rd.Close();
            return id_uo;
        }

        /// <summary>
        /// Popoa la select impostando l'eventuale valore inviato in POST, e popola la stringa _arrayJSTipiPassiList per il funzionamenot del JS
        /// </summary>
        /// <param name="tipoOperazioneBando"></param>
        private void popolaSelectTipiPasso(int tipoOperazioneBando)
        {

            IDbCommand cmd;
            cmd = _db.GetCommand();
            cmd.CommandText = @"SELECT TIPO_GANTT_PASSI.ID_PASSO ID_PASSO, DESCRIZIONE, NUM_GG_STANDARD, FLAG_VALORE, TIPO_GANTT_PASSI.ID_TIPO_VALORE, VALORE_AUTOMATICO, TIPO_GANTT_VALORI.NOME as VALORE_NOME, TIPO_GANTT_VALORI.FORMATO as VALORE_FORMATO, TIPO_GANTT_VALORI.PATTERN as VALORE_PATTERN
                FROM TIPO_GANTT_PASSI 
                INNER JOIN GANTT_PASSI_TIPIOPERAZIONI ON TIPO_GANTT_PASSI.ID_PASSO = GANTT_PASSI_TIPIOPERAZIONI.ID_PASSO 
                LEFT JOIN TIPO_GANTT_VALORI ON TIPO_GANTT_PASSI.ID_TIPO_VALORE = TIPO_GANTT_VALORI.ID_TIPO_VALORE
                WHERE GANTT_PASSI_TIPIOPERAZIONI.ID_TIPOOP = "+tipoOperazioneBando.ToString()+"ORDER BY GANTT_PASSI_TIPIOPERAZIONI.ORDINE";
            _db.InitDatareader(cmd);
            IDataReader dr = null;

            try
            {
                dr = _db.DataReader;
                /* tipiPassiList[10] = {'DESCRIZIONE': 'Istituzione dei capitoli', 'NUM_GG_STANDARD': '', 'VALORE_NOME' : '', 'VALORE_FORMATO' : '', 'VALORE_PATTERN' : '' };
                   tipiPassiList[20] = {'DESCRIZIONE': 'DRG di prenotazione/riparto risorse', 'NUM_GG_STANDARD': '', 'TIPOVALORE_NOME' : '', "TIPOVALORE_FORMATO" : '', 'VALORE_PATTERN' : '' };"
                 * ...
                 */

                while (dr.Read())
                {
                    string varNUM_GG_STANDARD = "", varVALORE_NOME = "", varVALORE_FORMATO = "", varVALORE_PATTERN = "";
                    if (dr["NUM_GG_STANDARD"] != DBNull.Value) varNUM_GG_STANDARD = dr["NUM_GG_STANDARD"].ToString();
                    if (dr["VALORE_NOME"] != DBNull.Value) varVALORE_NOME = dr["VALORE_NOME"].ToString();
                    if (dr["VALORE_FORMATO"] != DBNull.Value) varVALORE_FORMATO = dr["VALORE_FORMATO"].ToString();
                    if (dr["VALORE_PATTERN"] != DBNull.Value) varVALORE_PATTERN = dr["VALORE_PATTERN"].ToString();
                    _arrayJSTipiPassiList = _arrayJSTipiPassiList +
                        "tipiPassiList[" + dr["ID_PASSO"].ToString() + "] = {" +
                        "'DESCRIZIONE': '" + dr["DESCRIZIONE"].ToString().Replace("'", "\\'") + "', 'NUM_GG_STANDARD': '" + varNUM_GG_STANDARD + "', 'VALORE_NOME' : '" + varVALORE_NOME + "', 'VALORE_FORMATO' : '" + varVALORE_FORMATO + "'" + ", 'VALORE_PATTERN' : '" + varVALORE_PATTERN.Replace("\\", "\\\\") + "'" +
                        "};\n";
                    edTipoPasso.Items.Add(new ListItem(dr["DESCRIZIONE"].ToString(), dr["ID_PASSO"].ToString()));
                }
                dr.Close();

                string selVal = Request[edTipoPasso.UniqueID];
                if (selVal != null)
                    edTipoPasso.SelectedValue = selVal;
            }
            catch (Exception ex)
            {
                if (dr != null && dr.IsClosed) dr.Close();
                throw ex;
            }
        }

        private void visualizaPassi(int idg, int tipoOperazioneBando)
        {
            popolaSelectTipiPasso(tipoOperazioneBando);

            try
            {
                IDbCommand cmd;
                cmd = _db.GetCommand();
                cmd.CommandText = @"SELECT ID_STEP, ID_GNATT, ID_TIPO_PASSO, UO_PASSO, ORDINE, DATA_INIZIO_PREVISTA, DATA_FINE_PREVISTA, GANTT_STEPS.NUM_GG_STANDARD, VALORE_PREVISTO,NOTA_PREVISTO,UO.NOME as UO_NOME,
                                    TIPO_GANTT_PASSI.DESCRIZIONE, TIPO_GANTT_PASSI.FLAG_VALORE, 
                                    TIPO_GANTT_VALORI.NOME AS VALORE_NOME, TIPO_GANTT_VALORI.FORMATO AS VALORE_FORMATO, TIPO_GANTT_VALORI.PATTERN as VALORE_PATTERN, TIPO_GANTT_PASSI.VALORE_AUTOMATICO
                                    FROM GANTT_STEPS INNER JOIN
                                    UO ON UO.ID_UO = GANTT_STEPS.UO_PASSO INNER JOIN
                                    TIPO_GANTT_PASSI ON GANTT_STEPS.ID_TIPO_PASSO = TIPO_GANTT_PASSI.ID_PASSO LEFT JOIN
                                    TIPO_GANTT_VALORI ON TIPO_GANTT_PASSI.ID_TIPO_VALORE = TIPO_GANTT_VALORI.ID_TIPO_VALORE
                                    where ID_GNATT = " + idg.ToString() + " ORDER BY DATA_INIZIO_PREVISTA, DATA_FINE_PREVISTA, ID_STEP";
                _db.InitDatareader(cmd);
                grvPassi.DataSource = _db.DataReader;
                grvPassi.DataBind();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _db.DataReader.Close();
            }
        }

        private void GetClassificazione(int idGantt)
        {
            try
            {
                IDbCommand cmd;
                cmd = _db.GetCommand();
                cmd.CommandText = @"SELECT B.ID_BANDO_GANTT ID_BANDO,
                    ASSE.CODICE COD_ASSE,
                    ASSE.DESCRIZIONE DESC_ASSE,
                    P.CODICE COD_AZIONE,
                    P.DESCRIZIONE DESC_AZIONE,
                    IP.CODICE COD_INTERVENTO,
                    IP.DESCRIZIONE DESC_INTERVENTO,
                    B.OGGETTO DESC_BANDO,
                    TIPO_GANTT_TIPIOPERAZIONE.NOME_TIPOOP DESC_TIPOOPERAZIONE,
                    B.IMPORTO, B.IMPORTO_PREVISTO, B.IMPORTO_FINANZIATO, B.IMPORTO_CERTIFICATO
                    FROM GANTT_BANDO B
                    INNER JOIN GANTT ON 
                    GANTT.ID_BANDO = B.ID_BANDO_GANTT
                    INNER JOIN TIPO_GANTT_TIPIOPERAZIONE ON GANTT.ID_TIPOOP = TIPO_GANTT_TIPIOPERAZIONE.ID_TIPOOP
                    INNER JOIN zPROGRAMMAZIONE IP ON
                    B.ID_PROGRAMMAZIONE = IP.ID
                    INNER JOIN zPROGRAMMAZIONE P ON
                    P.ID = IP.ID_PADRE
                    INNER JOIN zPROGRAMMAZIONE ASSE ON
                    ASSE.ID = P.ID_PADRE
                    INNER JOIN zPSR_ALBERO PA ON
                    ASSE.COD_TIPO = PA.CODICE
                    INNER JOIN zPSR PSR ON
                    PA.COD_PSR = PSR.CODICE
                    WHERE 
                    (PSR.CODICE = 'POR20142020' or PSR.CODICE = 'FSE20142020')
                    AND
                    ID_GANTT=" + idGantt.ToString();
                _db.InitDatareader(cmd);
                IDataReader rd = _db.DataReader;
                rd.Read();
                if ((rd["COD_ASSE"] != DBNull.Value) && (rd["DESC_ASSE"] != DBNull.Value)) lblAsse.Text = "ASSE " + rd["COD_ASSE"].ToString() + " - " + rd["DESC_ASSE"].ToString();
                if ((rd["COD_AZIONE"] != DBNull.Value) && (rd["DESC_AZIONE"] != DBNull.Value)) lblAzione.Text = "AZIONE " + rd["COD_AZIONE"].ToString() + " - " + rd["DESC_AZIONE"].ToString();
                if ((rd["COD_INTERVENTO"] != DBNull.Value) && (rd["DESC_INTERVENTO"] != DBNull.Value)) lblIntervento.Text = "INTERVENTO " + rd["COD_INTERVENTO"].ToString() + " - " + rd["DESC_INTERVENTO"].ToString();
                if ((rd["DESC_BANDO"] != DBNull.Value) && (rd["DESC_BANDO"] != DBNull.Value)) lblBando.Text = "BANDO: " + rd["DESC_BANDO"].ToString();
                if ((rd["DESC_TIPOOPERAZIONE"] != DBNull.Value) && (rd["DESC_TIPOOPERAZIONE"] != DBNull.Value)) lblTipoOp.Text = "TIPO OPERAZIONE: " + rd["DESC_TIPOOPERAZIONE"].ToString();
                if ((rd["IMPORTO"] != DBNull.Value) && (rd["IMPORTO"] != DBNull.Value)) lblImporto.Text = rd["IMPORTO"].ToString();
                else lblImporto.Text = "0,00";
                if ((rd["IMPORTO_PREVISTO"] != DBNull.Value) && (rd["IMPORTO_PREVISTO"] != DBNull.Value)) lblImportoComplessivo.Text = rd["IMPORTO_PREVISTO"].ToString();
                else lblImportoComplessivo.Text = "0,00";
                if ((rd["IMPORTO_FINANZIATO"] != DBNull.Value) && (rd["IMPORTO_FINANZIATO"] != DBNull.Value)) lblImportoFinanziato.Text = rd["IMPORTO_FINANZIATO"].ToString();
                else lblImportoFinanziato.Text = "0,00";
                if ((rd["IMPORTO_CERTIFICATO"] != DBNull.Value) && (rd["IMPORTO_CERTIFICATO"] != DBNull.Value)) lblImportoCertificato.Text = rd["IMPORTO_CERTIFICATO"].ToString();
                else lblImportoCertificato.Text = "0,00";

                rd.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Azione richiamata se è impostato il parametro di pagina deleteIDS: elimina lo step con ID = idToDel
        /// </summary>
        /// <param name="idToDel"></param>
        /// <param name="idGantDel"></param>
        /// <returns></returns>
        private string eliminaStep(int idToDel, int idGantDel)
        {
            try
            {
                IDbCommand cmd;
                cmd = _db.GetCommand();
                cmd.CommandText = @"DELETE FROM GANTT_STEPS where ID_STEP=" + idToDel.ToString() + " AND ID_GNATT=" + idGantDel.ToString();
                _db.Execute(cmd);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// Azione richiamata se è impostato il parametro di pagina eliminaIDG: elimina il gantt di ID  = idGantDel
        /// </summary>
        /// <param name="idGantDel"></param>
        /// <returns></returns>
        private string eliminaGantt(int idGantDel)
        {
            try
            {
                bool esistonoSteps = false;
                IDbCommand cmdSel;
                cmdSel = _db.GetCommand();
                cmdSel.CommandText = @"SELECT TOP 1 ID_STEP FROM GANTT_STEPS WHERE ID_GNATT=" + idGantDel.ToString();
                object res = _db.ExecuteScalar(cmdSel);
                if (res != null & res != DBNull.Value) esistonoSteps = true;
                if (esistonoSteps)
                    return "Impossibile eliminare: è necessario cancellare tutti i passi prima di eliminare la pianificazione";
                else
                {
                    IDbCommand cmd;
                    cmd = _db.GetCommand();
                    cmd.CommandText = @"DELETE FROM GANTT where ID_GANTT=" + idGantDel.ToString();
                    _db.Execute(cmd);
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// Azione richiamata se è impostato il parametro di pagina salvaDefIDG: salva come definitivo il gantt di ID  = idGantSave
        /// </summary>
        /// <param name="idGantDel"></param>
        /// <returns></returns>
        private string salvaGanttDefinitivo(int idGantSave)
        {
            string retval = string.Empty;
            try
            {
                IDbCommand cmd;
                cmd = _db.GetCommand();
                cmd.CommandText = @"UPDATE GANTT set ID_STATO=1, DATA_CAMBIOSTATO=GETDATE() where ID_STATO=0 and ID_GANTT=" + idGantSave.ToString();
                _db.Execute(cmd);
            }
            catch (Exception ex)
            {
                retval = ex.Message;
            }
            return retval;
        }


        /// <summary>
        /// salva i dati inseriti nella modale del singolo step (insert o update)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btSalvaModal_Click(object sender, EventArgs e)
        {
            int retval = -1;
            try
            {
                int insIDStep = -1, insTipoPasso = -1, insIdUO = -1, insNGGStandard = 0;
                DateTime insDtInizioPrev, insDtFinePrev;
                decimal insValorePrev = decimal.MinValue;
                string insNotaPrev="";

                if (HedIDStep.Value != "") insIDStep = Convert.ToInt32(HedIDStep.Value);
                insTipoPasso = Convert.ToInt32(edTipoPasso.SelectedValue);
                insIdUO = Convert.ToInt32(edUO.SelectedValue);
                if (HedNGGStandard.Value != "") insNGGStandard = Convert.ToInt32(HedNGGStandard.Value);
                insDtInizioPrev = Convert.ToDateTime(HedDtInizioPrev.Value);
                insDtFinePrev = Convert.ToDateTime(HedDtFinePrev.Value);
                if (HedValorePrev.Value != "") insValorePrev = Convert.ToDecimal(HedValorePrev.Value);
                insNotaPrev = HedNotaPrev.Value;

                if (insIDStep <= 0)
                {
                    // esegue [ZGanttStepInsert]
                    IDbCommand cmd = _db.InitCmd("ZGanttStepInsert", new string[] { "IdGantt", "IdTipoPasso", "IdUO", "DataInizioPrevista", "DataFinePrevista", "nGGStandard", "valorePrevisto", "notaPrevisto", "isInDefinizione" }, new string[] { "int", "int", "int", "DateTime", "DateTime", "int", "decimal", "string", "bool" }, "idStep");
                    SiarLibrary.DbProvider.SetCmdParam(cmd, _db.CommandFirstChar + "IdGantt", (SiarLibrary.NullTypes.IntNT)_idg);
                    SiarLibrary.DbProvider.SetCmdParam(cmd, _db.CommandFirstChar + "IdTipoPasso", (SiarLibrary.NullTypes.IntNT)insTipoPasso);
                    SiarLibrary.DbProvider.SetCmdParam(cmd, _db.CommandFirstChar + "IdUO", (SiarLibrary.NullTypes.IntNT)insIdUO);
                    SiarLibrary.DbProvider.SetCmdParam(cmd, _db.CommandFirstChar + "DataInizioPrevista", (SiarLibrary.NullTypes.DatetimeNT)insDtInizioPrev);
                    SiarLibrary.DbProvider.SetCmdParam(cmd, _db.CommandFirstChar + "DataFinePrevista", (SiarLibrary.NullTypes.DatetimeNT)insDtFinePrev);
                    SiarLibrary.DbProvider.SetCmdParam(cmd, _db.CommandFirstChar + "nGGStandard", insNGGStandard == 0 ? null : (SiarLibrary.NullTypes.IntNT)insNGGStandard);
                    SiarLibrary.DbProvider.SetCmdParam(cmd, _db.CommandFirstChar + "valorePrevisto", insValorePrev == decimal.MinValue ? null : (SiarLibrary.NullTypes.DecimalNT)insValorePrev);
                    SiarLibrary.DbProvider.SetCmdParam(cmd, _db.CommandFirstChar + "notaPrevisto", insNotaPrev == "" ? null : (SiarLibrary.NullTypes.StringNT)insNotaPrev);
                    SiarLibrary.DbProvider.SetCmdParam(cmd, _db.CommandFirstChar + "isInDefinizione", (SiarLibrary.NullTypes.BoolNT)false);
                    retval = Convert.ToInt32(_db.ExecuteScalar(cmd));
                }
                else
                {
                    // esegue [ZGanttStepUpdate]
                    IDbCommand cmd = _db.InitCmd("ZGanttStepUpdate", new string[] { "IdStep", "IdTipoPasso", "IdUO", "DataInizioPrevista", "DataFinePrevista", "nGGStandard", "valorePrevisto", "notaPrevisto" }, new string[] { "int", "int", "int", "DateTime", "DateTime", "int", "decimal", "string" }, "");
                    SiarLibrary.DbProvider.SetCmdParam(cmd, _db.CommandFirstChar + "IdStep", (SiarLibrary.NullTypes.IntNT)insIDStep);
                    SiarLibrary.DbProvider.SetCmdParam(cmd, _db.CommandFirstChar + "IdTipoPasso", (SiarLibrary.NullTypes.IntNT)insTipoPasso);
                    SiarLibrary.DbProvider.SetCmdParam(cmd, _db.CommandFirstChar + "IdUO", (SiarLibrary.NullTypes.IntNT)insIdUO);
                    SiarLibrary.DbProvider.SetCmdParam(cmd, _db.CommandFirstChar + "DataInizioPrevista", (SiarLibrary.NullTypes.DatetimeNT)insDtInizioPrev);
                    SiarLibrary.DbProvider.SetCmdParam(cmd, _db.CommandFirstChar + "DataFinePrevista", (SiarLibrary.NullTypes.DatetimeNT)insDtFinePrev);
                    SiarLibrary.DbProvider.SetCmdParam(cmd, _db.CommandFirstChar + "nGGStandard", insNGGStandard == 0 ? null : (SiarLibrary.NullTypes.IntNT)insNGGStandard);
                    SiarLibrary.DbProvider.SetCmdParam(cmd, _db.CommandFirstChar + "valorePrevisto", insValorePrev == decimal.MinValue ? null : (SiarLibrary.NullTypes.DecimalNT)insValorePrev);
                    SiarLibrary.DbProvider.SetCmdParam(cmd, _db.CommandFirstChar + "notaPrevisto", insNotaPrev == "" ? null : (SiarLibrary.NullTypes.StringNT)insNotaPrev);
                    _db.ExecuteScalar(cmd);
                }
                Response.Redirect("Definizione.aspx?idg=" + _idg.ToString());

            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

    }
}
