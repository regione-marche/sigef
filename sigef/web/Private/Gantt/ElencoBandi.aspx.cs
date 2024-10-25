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
    /// Cerca tra tutti i bandi e visualizza l'elenco con lo stato dell'eventuale GANTT associato; consente di accedere ai GANTT e di crearne per bandi che non ne hanno uno associato 
    /// Memorizza la ricerca del nome bando in variabile di sessione SelectGanttBando_CercaDescr
    /// </summary>
    public partial class ElencoBandi : SiarLibrary.Web.PrivatePage
    {
        SiarLibrary.DbProvider _db = null;

        protected string m_srcBando = "";
        protected string m_srcAsse = "";
        protected string m_srcAsseCodProgrammazione = "";

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
                popolaSelectTipiOp();

                // sessione SelectGanttBando_CercaDescr
                if (!IsPostBack)
                {
                    if (Session["SelectGanttBando_CercaDescr"] != null) {
                        m_srcBando = Session["SelectGanttBando_CercaDescr"].ToString();
                        srcBando.Text = m_srcBando;
                    }
                    if (Session["SelectGanttBando_CercaAsse"] != null && Session["SelectGanttBando_CercaAsse"].ToString() != "") {
                        m_srcAsse = Session["SelectGanttBando_CercaAsse"].ToString();
                        srcAsse.SelectedValue = m_srcAsse;
                        m_srcAsseCodProgrammazione = srcAsse.SelectedItem.Text.Substring(0, 1);
                    } 
                }

                // se c'è richiesta di creazione: la esegue e poi visualizza il GANTT creato
                if (Request.Params["creaIDB"] != null && Request.Params["creaIDB"].Trim() != "" && Request.Params["tipoOp"] != null && Request.Params["tipoOp"].Trim() != "")
                {
                    int idg = 0;
                    int idUo = 0;
                    idUo = GetUO_ID(Operatore.Utente.CodEnte);
                    int idb = Convert.ToInt32(Request.Params["creaIDB"]);
                    int idTipoOp = Convert.ToInt32(Request.Params["tipoOp"]);
                    if (idb > 0 && idTipoOp > 0) idg = creaGanttBando(idb, idTipoOp, idUo);
                    if (idg > 0) Response.Redirect("Definizione.aspx?idg=" + idg);
                    else Response.Redirect("ElencoBandi.aspx");
                }
                else
                {
                    string asseCerca = "";
                    if (srcAsse.SelectedIndex > 0) asseCerca = srcAsse.SelectedValue;
                    popolaGridBandi(srcBando.Text, asseCerca);
                }

                int idUo1 = -1;
                idUo1 = GetUO_IDEXC(Operatore.Utente.CodEnte);
                int idAsse = 0;
                if (srcAsse.SelectedIndex > 0)
                    idAsse = Convert.ToInt32( srcAsse.SelectedValue);

                    IDbCommand cmd;
                cmd = _db.GetCommand();
                cmd.CommandText = @"select ID_UTENTE from GANTT_UTENTI where VEDE_TUTTO = 1 and ID_UTENTE=" + Operatore.Utente.IdUtente.ToString();
                object isLettoreOb = _db.ExecuteScalar(cmd);
                bool isLettore = false;
                if (isLettoreOb != null && isLettoreOb != DBNull.Value && Convert.ToInt32(isLettoreOb) > 0) isLettore = true;
                btnEstraiXls.Attributes.Add("onclick", "SNCVisualizzaReport('rptGantt_CertificabilePerAnnoXls',2,'ID_UO=" + (isLettore ? "0" : idUo1.ToString()) + "|ID_ASSE="+idAsse+"');");

            }
            catch (Exception exc)
            {
                ShowError(exc); 
            }
            finally
            {
                if (_db != null) _db.Close();
            }
        }
        private int GetUO_ID(string cod_ente)
        {
            try
            {
                if (cod_ente == "%") return 1;   // utente = Admin: torna UO = 1
                string id_uo = null;
                IDbCommand cmd;
                cmd = _db.GetCommand();
                cmd.CommandText = @"SELECT ID_UO FROM GANTT_UO_SIGEF WHERE COD_ENTE_SIGEF='" + cod_ente + "'";
                _db.InitDatareader(cmd);
                IDataReader rd = _db.DataReader;
                rd.Read();
                if (rd["ID_UO"] != DBNull.Value)
                {
                    id_uo = rd["ID_UO"].ToString();
                }
                rd.Close();
                return Convert.ToInt32(id_uo);
            }
            catch (Exception ex) {
                throw new Exception("Errore nella lettura della Unità Organizzativa di appartenenza dell'utente: " + ex.Message); 
            }
        }
        private int GetUO_IDEXC(string cod_ente)
        {
            try
            {
                if (cod_ente == "%") return 0;
                string id_uo = "-1";
                IDbCommand cmd;
                cmd = _db.GetCommand();
                cmd.CommandText = @"SELECT ID_UO FROM GANTT_UO_SIGEF WHERE COD_ENTE_SIGEF='" + cod_ente + "'";
                _db.InitDatareader(cmd);
                IDataReader rd = _db.DataReader;
                if (rd.Read())
                    if (rd["ID_UO"] != DBNull.Value)
                        id_uo = rd["ID_UO"].ToString();

                rd.Close();
                return Convert.ToInt32(id_uo);
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        private void popolaSelectTipiOp()
        {
            try
            {
                IDbCommand cmd;
                cmd = _db.GetCommand();
                cmd.CommandText = @"SELECT ID_TIPOOP, NOME_TIPOOP
                                FROM TIPO_GANTT_TIPIOPERAZIONE
                                order by ID_TIPOOP";
                _db.InitDatareader(cmd);
                edTipoOperazione.DataSource = _db.DataReader;
                edTipoOperazione.DataBind();
                _db.DataReader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void popolaGridBandi(string srcDescrBando, string srcIDAsse){
            try
            {
                
                string cod_ente_sigef = Operatore.Utente.CodEnte;
                IDbCommand cmd;
                cmd = _db.GetCommand();
//                cmd.CommandText = @"SELECT  BANDO.ID_BANDO, BANDO.DESCRIZIONE, GANTT.ID_GANTT, GANTT.ID_UO, 
//                                case when GANTT.ID_STATO is null then -1 else GANTT.ID_STATO end as ID_STATO, 
//                                TIPO_GANTT_STATO.NOME
//                                FROM BANDO 
//                                left join GANTT ON GANTT.ID_BANDO = BANDO.ID_BANDO 
//                                left join TIPO_GANTT_STATO ON TIPO_GANTT_STATO.ID_STATO = GANTT.ID_STATO";
                cmd.CommandText = @"select ID_UTENTE from GANTT_UTENTI where VEDE_TUTTO = 1 and ID_UTENTE=" + Operatore.Utente.IdUtente.ToString();
                object isLettoreOb = _db.ExecuteScalar(cmd);
                bool isLettore = false;
                if (isLettoreOb != null && isLettoreOb != DBNull.Value && Convert.ToInt32(isLettoreOb) > 0) isLettore = true;

                string andWhereAsse = "";
                if (srcIDAsse != "") andWhereAsse = " AND asse.ID=" + srcIDAsse;

                if (cod_ente_sigef == "%" || isLettore)
                    cmd.CommandText = @"SELECT  BANDO.ID_BANDO_GANTT ID_BANDO, BANDO.OGGETTO AS DESCRIZIONE, GANTT.ID_GANTT, GANTT.ID_UO, 
                                case when GANTT.ID_STATO is null then -1 else GANTT.ID_STATO end as ID_STATO, 
                                TIPO_GANTT_STATO.NOME,
                                isnull((select top 1 ID_STEP FROM GANTT_STEPS WHERE ID_GNATT = GANTT.ID_GANTT), 0) as ESISTONO_STEPS,
                                asse.ID as ASSE_ID, intervento.CODICE as CODICE_INTERVENTO
                                FROM GANTT_BANDO BANDO 
                                left join GANTT ON GANTT.ID_BANDO = BANDO.ID_BANDO_GANTT 
                                left join TIPO_GANTT_STATO ON TIPO_GANTT_STATO.ID_STATO = GANTT.ID_STATO
                                INNER JOIN zPROGRAMMAZIONE AS intervento ON intervento.ID = BANDO.ID_PROGRAMMAZIONE 
                                INNER JOIN zPROGRAMMAZIONE AS azione ON azione.ID = intervento.ID_PADRE 
                                INNER JOIN zPROGRAMMAZIONE AS asse ON asse.ID = azione.ID_PADRE
                                WHERE BANDO.OGGETTO like '%" + srcDescrBando.Replace("'", "''") + "%'" + andWhereAsse + " ORDER BY intervento.CODICE, BANDO.ID_BANDO_GANTT ";
                else
                    cmd.CommandText = @"SELECT  BANDO.ID_BANDO_GANTT ID_BANDO, BANDO.OGGETTO AS DESCRIZIONE, GANTT.ID_GANTT, GANTT.ID_UO, 
                                case when GANTT.ID_STATO is null then -1 else GANTT.ID_STATO end as ID_STATO, 
                                TIPO_GANTT_STATO.NOME,
                                isnull((select top 1 ID_STEP FROM GANTT_STEPS WHERE ID_GNATT = GANTT.ID_GANTT), 0) as ESISTONO_STEPS,
                                asse.ID as ASSE_ID, intervento.CODICE as CODICE_INTERVENTO
                                FROM GANTT_BANDO BANDO 
                                left join GANTT ON GANTT.ID_BANDO = BANDO.ID_BANDO_GANTT 
                                left join TIPO_GANTT_STATO ON TIPO_GANTT_STATO.ID_STATO = GANTT.ID_STATO
                                INNER JOIN zPROGRAMMAZIONE AS intervento ON intervento.ID = BANDO.ID_PROGRAMMAZIONE 
                                INNER JOIN zPROGRAMMAZIONE AS azione ON azione.ID = intervento.ID_PADRE 
                                INNER JOIN zPROGRAMMAZIONE AS asse ON asse.ID = azione.ID_PADRE
                                WHERE BANDO.ID_PROGRAMMAZIONE IN 
                                (SELECT ID_PROGRAMMAZIONE from GANTT_UO_PROGRAMMAZIONE
                                INNER JOIN UO ON UO.ID_UO = GANTT_UO_PROGRAMMAZIONE.ID_UO
                                INNER JOIN GANTT_UO_SIGEF ON  GANTT_UO_SIGEF.ID_UO = UO.ID_UO
                                where GANTT_UO_SIGEF.COD_ENTE_SIGEF = '" + cod_ente_sigef + @"')
                                AND BANDO.OGGETTO like '%" + srcDescrBando.Replace("'", "''") + "%'" + andWhereAsse + " ORDER BY intervento.CODICE,BANDO.ID_BANDO_GANTT ";
                _db.InitDatareader(cmd);
                grvBandi.DataSource = _db.DataReader;
                grvBandi.DataBind();
                _db.DataReader.Close();
            }
            catch (Exception ex) {
                throw ex; 
            }
        }

        private int creaGanttBando(int id_bando, int idTipoOperazione , int idUo)
        {
            int retval = -1;
            try
            {
                IDbCommand cmd = _db.InitCmd("ZGanttInsert", new string[] { "idBando", "Data", "idTipoOperazione", "Operatore" , "IdUo" }, new string[] { "int", "DateTime", "int", "int", "int" }, "idGant");
                SiarLibrary.DbProvider.SetCmdParam(cmd, _db.CommandFirstChar + "idBando", (SiarLibrary.NullTypes.IntNT)id_bando);
                SiarLibrary.DbProvider.SetCmdParam(cmd, _db.CommandFirstChar + "Data", (SiarLibrary.NullTypes.DatetimeNT)DBNull.Value);
                SiarLibrary.DbProvider.SetCmdParam(cmd, _db.CommandFirstChar + "idTipoOperazione", (SiarLibrary.NullTypes.IntNT)idTipoOperazione);
                SiarLibrary.DbProvider.SetCmdParam(cmd, _db.CommandFirstChar + "Operatore", (SiarLibrary.NullTypes.IntNT)0);
                SiarLibrary.DbProvider.SetCmdParam(cmd, _db.CommandFirstChar + "IdUo", (SiarLibrary.NullTypes.IntNT)idUo);
                //SiarLibrary.DbProvider.SetCmdParam(cmd, _db.CommandFirstChar + "idGant", (SiarLibrary.NullTypes.IntNT)0);
                retval = Convert.ToInt32(_db.ExecuteScalar(cmd));
                return retval;
            }
            catch (Exception ex)
            {
                throw ex; 
            }
           
        }

        protected void btCerca_Click(object sender, EventArgs e)
        {
            Session["SelectGanttBando_CercaDescr"] = srcBando.Text;
            if (srcAsse.SelectedIndex > 0) Session["SelectGanttBando_CercaAsse"] = srcAsse.SelectedValue;
            else Session["SelectGanttBando_CercaAsse"] = "";
            Response.Redirect(Request.Url.PathAndQuery);
        }

    }
}
