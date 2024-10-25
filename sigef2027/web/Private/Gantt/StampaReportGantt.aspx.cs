using System;
using System.Data;

namespace web.Private.Gantt
{
    public partial class StampaReportGantt : SiarLibrary.Web.PrivatePage
     {
        SiarLibrary.DbProvider _db = new SiarLibrary.DbProvider();
        protected string m_srcBando = "";
        protected string m_srcAsse = "";

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "gantt";
            base.OnPreInit(e);
        }

         protected void Page_Load(object sender, EventArgs e)
         {
             try
             {
                 int idUo = -1;
                 idUo = GetUO_ID(Operatore.Utente.CodEnte);

                 IDbCommand cmd;
                 cmd = _db.GetCommand();
                 cmd.CommandText = @"select ID_UTENTE from GANTT_UTENTI where VEDE_TUTTO = 1 and ID_UTENTE=" + Operatore.Utente.IdUtente.ToString();
                 object isLettoreOb = _db.ExecuteScalar(cmd);
                 bool isLettore = false;
                 if (isLettoreOb != null && isLettoreOb != DBNull.Value && Convert.ToInt32(isLettoreOb) > 0) isLettore = true;

                 SiarLibrary.Web.ReportTemplates rt = new SiarLibrary.Web.ReportTemplates();
                 byte[] quadro = null;
                 switch (Request.Params["rpt"]) {
                     case "3":
                         // report steps con ritardi
                         quadro = rt.getReportByName("rptGantt_UltimoAggiornamento", new string[] { "ID_UO=" + (isLettore ? "0" : idUo.ToString()) });
                         break;
                     case "2":
                         // report steps con ritardi
                         m_srcBando = Request.Params["nomeBandoLike"];
                         m_srcAsse = Request.Params["asseID"];
                         quadro = rt.getReportByName("rptGantt_StepRitardo", new string[] { "ID_UO=" + (isLettore ? "0" : idUo.ToString()), "ASSE=" + (m_srcAsse=="" ? "0" : m_srcAsse), "BANDO=" + m_srcBando });
                         break;
                     default:
                         // certificabile per anno
                         quadro = rt.getReportByName("rptGantt_CertificabilePerAnno", new string[] { "ID_UO=" + (isLettore ? "0" : idUo.ToString()) });
                         break;
                 }
                 if (quadro == null && quadro.Length == 0) throw new Exception("Il documento è inesistente.");
                 Session["doc"] = quadro;
                 rt.Dispose();
             }
             catch (Exception ex) { Response.Write(ex.Message); }
         }

         private int GetUO_ID(string cod_ente)
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
    }
}
