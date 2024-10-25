using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace web.Private.Psr.Programmazione
{
    public partial class Report : SiarLibrary.Web.PrivatePage
    {
        SiarLibrary.DbProvider _db = null;

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "report_asse";
            base.OnPreInit(e);
        }

        SiarBLL.VestrazioneXAsseCollectionProvider estrazione_provider = new SiarBLL.VestrazioneXAsseCollectionProvider();

        protected void Page_Load(object sender, EventArgs e)
        {
            _db = new SiarLibrary.DbProvider();
        }

        protected override void OnPreRender(EventArgs e)
        {
            lstProgrammazione.CodiceTipo = "POR20142020L1";
            lstProgrammazione.DataBind();

            int id_asse = 0;
            if (!string.IsNullOrEmpty(lstProgrammazione.SelectedValue))
                id_asse = Convert.ToInt32(lstProgrammazione.SelectedValue);
            //int id_UO = getIdUO(Operatore.Utente.CodEnte);
            string ente = Operatore.Utente.CodEnte;
            ente = ente.Replace("RM_", "");

            SiarLibrary.VestrazioneXAsseCollection estraz_coll = estrazione_provider.GetEstrazioneXasse(id_asse, ente);
            dgInterventi.DataSource = estraz_coll;
            dgInterventi.DataBind();
            btnEstraiXls.Attributes.Add("onclick", "SNCVisualizzaReport('rptEstrazioneAsseXls',2,'IdAsse=" + id_asse.ToString() + "|ENTE="+ ente + "');");           
            btnEstraiProgetti.Attributes.Add("onclick", "SNCVisualizzaReport('rptEstrazioneProgettiXls',2,'ENTE=" + ente + "');");
            btnEstraiBeneficiari.Attributes.Add("onclick", "SNCVisualizzaReport('rptEstrazioneBeneficiariXls',2,'ENTE=" + ente + "');");
            btnEstraiProgettiProv.Attributes.Add("onclick", "SNCVisualizzaReport('rptEstrazioneProgettiXlsProvvisori',2,'ENTE=" + ente + "');");
            btnEstraiBeneficiariProv.Attributes.Add("onclick", "SNCVisualizzaReport('rptEstrazioneBeneficiariXlsProvvisori',2,'ENTE=" + ente + "');");
            btnEstraiCertificati.Attributes.Add("onclick", "SNCVisualizzaReport('rptImportiCertificati',2,'ENTE=" + ente + "');");
            btnEstraiCertificabili.Attributes.Add("onclick", "SNCVisualizzaReport('rptPrevisioneCertificabili',2,'ENTE=" + ente + "');");
            
            base.OnPreRender(e);
        }

        private int getIdUO(string cod_ente)
        {
            try
            {
                if (cod_ente == "%" || cod_ente == "RM") return 1;   // utente = Admin: torna UO = 1
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
            catch (Exception ex)
            {
                throw new Exception("Errore nella lettura della Unità Organizzativa di appartenenza dell'utente: " + ex.Message);
            }
        }
    }
}