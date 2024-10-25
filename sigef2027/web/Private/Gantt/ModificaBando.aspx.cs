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
    public partial class ModificaBando : SiarLibrary.Web.PrivatePage
    {
        SiarLibrary.DbProvider _db = null;
        protected int _idgb = 0;
        protected int _del = 0;

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "gantt";
            base.OnPreInit(e);
        }

        protected override void OnInit(EventArgs e) {
            _db = new SiarLibrary.DbProvider();
            popolaSelBandiSIGEF();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["idbandogantt"] != null && Request.Params["idbandogantt"].Trim() != "")
                _idgb = Convert.ToInt32(Request.Params["idbandogantt"]);
            if (_idgb <= 0) Response.Redirect("ElencoBandi.aspx", true);
            if (Request.Params["del"] != null && Request.Params["del"].Trim() != "")
                _del = Convert.ToInt32(Request.Params["del"]);
            if (_del == 1)
            {
                EliminaBando(_idgb);
                Response.Redirect("ElencoBandi.aspx", true);
            }

            if (!IsPostBack) {
                CaricaDatiBando(_idgb);
            }
                
            GetClassificazione(_idgb);
        }

        private void popolaSelBandiSIGEF() { 
            try
            {
                string cod_ente_sigef = Operatore.Utente.CodEnte;
                IDbCommand cmdLett;
                cmdLett = _db.GetCommand();
                cmdLett.CommandText = @"select ID_UTENTE from GANTT_UTENTI where VEDE_TUTTO = 1 and ID_UTENTE=" + Operatore.Utente.IdUtente.ToString();
                object isLettoreOb = _db.ExecuteScalar(cmdLett);
                bool isLettore = false;
                if (isLettoreOb != null && isLettoreOb != DBNull.Value && Convert.ToInt32(isLettoreOb) > 0) isLettore = true;

                IDbCommand cmd;
                cmd = _db.GetCommand();
                cmd.CommandText = @"SELECT ID_BANDO, DESCRIZIONE FROM vBANDO where cod_stato <> 'P'";
                if (!isLettore && cod_ente_sigef != "%") cmd.CommandText = cmd.CommandText + " and COD_ENTE='" + cod_ente_sigef + @"' 
                  or COD_ENTE = (
                    select top(1) padri.COD_ENTE_SIGEF from uo padri inner join uo figli on padri.ID_UO = figli.ID_PADRE where figli.COD_ENTE_SIGEF='" + cod_ente_sigef + @"'
                  )";
                _db.InitDatareader(cmd);
                edIdBandoSIGEF.DataSource = _db.DataReader;
                edIdBandoSIGEF.DataBind();
                _db.DataReader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void GetClassificazione(int idGantt_Bando)
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
                    B.IMPORTO
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
                    (PSR.CODICE = 'POR20142020' OR PSR.CODICE = 'FSE20142020')
                    and B.ID_BANDO_GANTT =" + idGantt_Bando.ToString();
                _db.InitDatareader(cmd);
                IDataReader rd = _db.DataReader;
                rd.Read();
                if ((rd["COD_ASSE"] != DBNull.Value) && (rd["DESC_ASSE"] != DBNull.Value)) lblAsse.Text = "ASSE " + rd["COD_ASSE"].ToString() + " - " + rd["DESC_ASSE"].ToString();
                if ((rd["COD_AZIONE"] != DBNull.Value) && (rd["DESC_AZIONE"] != DBNull.Value)) lblAzione.Text = "AZIONE " + rd["COD_AZIONE"].ToString() + " - " + rd["DESC_AZIONE"].ToString();
                if ((rd["COD_INTERVENTO"] != DBNull.Value) && (rd["DESC_INTERVENTO"] != DBNull.Value)) lblIntervento.Text = "INTERVENTO " + rd["COD_INTERVENTO"].ToString() + " - " + rd["DESC_INTERVENTO"].ToString();
                if ((rd["DESC_BANDO"] != DBNull.Value) && (rd["DESC_BANDO"] != DBNull.Value)) lblBando.Text = "BANDO: " + rd["DESC_BANDO"].ToString();
                if ((rd["DESC_TIPOOPERAZIONE"] != DBNull.Value) && (rd["DESC_TIPOOPERAZIONE"] != DBNull.Value)) lblTipoOp.Text = "TIPO OPERAZIONE: " + rd["DESC_TIPOOPERAZIONE"].ToString();
                rd.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void EliminaBando(int idGantt_Bando)
        {
            try
            {
                IDbCommand cmd;
                cmd = _db.GetCommand();
                cmd.CommandText = @"DELETE 
                                    FROM GANTT
                                    WHERE  ID_BANDO= "+idGantt_Bando.ToString();
                _db.ExecuteScalar(cmd);

                cmd.CommandText = @"DELETE 
                                    FROM GANTT_BANDO
                                    WHERE  ID_BANDO_GANTT= " + idGantt_Bando.ToString();
                _db.ExecuteScalar(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void CaricaDatiBando(int idGantt_Bando)
        {
            try
            {
                IDbCommand cmd;
                cmd = _db.GetCommand();
                cmd.CommandText = @"SELECT IMPORTO
                      ,IMPORTO_PREVISTO
                      ,IMPORTO_FINANZIATO
                      ,IMPORTO_CERTIFICATO
                      ,ID_BANDO_BANDI
                      FROM GANTT_BANDO WHERE ID_BANDO_GANTT =" + idGantt_Bando.ToString();
                _db.InitDatareader(cmd);
                IDataReader rd = _db.DataReader;
                rd.Read();
                if ((rd["IMPORTO"] != DBNull.Value) && (rd["IMPORTO"] != DBNull.Value))
                    edValorePrev.Value = rd["IMPORTO"].ToString();
                else
                    edValorePrev.Value = "0";
                if ((rd["IMPORTO_PREVISTO"] != DBNull.Value) && (rd["IMPORTO_PREVISTO"] != DBNull.Value)) 
                    edValoreComplPrev.Value = rd["IMPORTO_PREVISTO"].ToString();
                else
                    edValoreComplPrev.Value = "0";
                if ((rd["IMPORTO_FINANZIATO"] != DBNull.Value) && (rd["IMPORTO_FINANZIATO"] != DBNull.Value)) 
                    edValoreFinanziato.Value = rd["IMPORTO_FINANZIATO"].ToString();
                else
                    edValoreFinanziato.Value = "0";
                if ((rd["IMPORTO_CERTIFICATO"] != DBNull.Value) && (rd["IMPORTO_CERTIFICATO"] != DBNull.Value)) 
                    edValoreCertificato.Value = rd["IMPORTO_CERTIFICATO"].ToString();
                else
                    edValoreCertificato.Value = "0";

                if (rd["ID_BANDO_BANDI"] != DBNull.Value)
                    edIdBandoSIGEF.SelectedValue = rd["ID_BANDO_BANDI"].ToString();
                else
                    edIdBandoSIGEF.SelectedIndex = -1;
                rd.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void SalvaBando_click(object sender, EventArgs e)
        {
            try
            {
                decimal importo = 0, importoPrevisto = 0, importoFinanziato = 0, importoCertificato = 0;
                string insIDBando = "";
                if (edValorePrev.Value == null || edValorePrev.Value == "")
                    throw new Exception("Inserire l'importo fondo FESR");
                else
                    importo = Convert.ToDecimal(edValorePrev.Value);
                if (edValoreComplPrev.Value == null || edValoreComplPrev.Value == "")
                    throw new Exception("Inserire l'importo complessivo previsto");
                else
                    importoPrevisto = Convert.ToDecimal(edValoreComplPrev.Value);
                if (edValoreFinanziato.Value == null || edValoreFinanziato.Value == "")
                    throw new Exception("Inserire l'importo finanziato");
                else
                    importoFinanziato = Convert.ToDecimal(edValoreFinanziato.Value);
                if (edValoreCertificato.Value == null || edValoreCertificato.Value == "")
                    throw new Exception("Inserire l'importo già certificato");
                else
                    importoCertificato = Convert.ToDecimal(edValoreCertificato.Value);
                if (edIdBandoSIGEF.SelectedIndex > 0)
                    insIDBando = edIdBandoSIGEF.SelectedValue;
                else
                    insIDBando = "";

                IDbCommand cmd = _db.InitCmd("ZGanttBandoUpdate", new string[] { "ID_GANTT_BANDO", "importo", "IMPORTO_PREVISTO", "IMPORTO_FINANZIATO", "IMPORTO_CERTIFICATO", "ID_BANDO_BANDI" }, new string[] { "int", "decimal", "decimal", "decimal", "decimal", "int" }, null);
                SiarLibrary.DbProvider.SetCmdParam(cmd, _db.CommandFirstChar + "ID_GANTT_BANDO", (SiarLibrary.NullTypes.IntNT)_idgb);
                SiarLibrary.DbProvider.SetCmdParam(cmd, _db.CommandFirstChar + "importo", (SiarLibrary.NullTypes.DecimalNT)importo);
                SiarLibrary.DbProvider.SetCmdParam(cmd, _db.CommandFirstChar + "IMPORTO_PREVISTO", (SiarLibrary.NullTypes.DecimalNT)importoPrevisto);
                SiarLibrary.DbProvider.SetCmdParam(cmd, _db.CommandFirstChar + "IMPORTO_FINANZIATO", (SiarLibrary.NullTypes.DecimalNT)importoFinanziato);
                SiarLibrary.DbProvider.SetCmdParam(cmd, _db.CommandFirstChar + "IMPORTO_CERTIFICATO", (SiarLibrary.NullTypes.DecimalNT)importoCertificato);
                SiarLibrary.DbProvider.SetCmdParam(cmd, _db.CommandFirstChar + "ID_BANDO_BANDI", (SiarLibrary.NullTypes.IntNT)(insIDBando == "" ? (SiarLibrary.NullTypes.IntNT)null : (SiarLibrary.NullTypes.IntNT)Convert.ToInt32(insIDBando)));
                _db.ExecuteScalar(cmd);
                ShowMessage("Intervento modificato");
                //Response.Redirect("ElencoBandi.aspx");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }


    }
}
