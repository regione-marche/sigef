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
    public partial class CreaBando : SiarLibrary.Web.PrivatePage
    {
        SiarLibrary.DbProvider _db = null;

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "gantt";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //if (!IsPostBack)
                
                   _db = new SiarLibrary.DbProvider();
                
                int IdAsse =0 , IdAzione = 0 , IdIntervento = 0;

                if (hdnIdAsse.Value != null && hdnIdAsse.Value != "")
                    IdAsse = Convert.ToInt32(hdnIdAsse.Value.ToString());
                //edAsse.SelectedIndex = Convert.ToInt32(hdnIdAsse.Value);
                popolaAsse(IdAsse);
                if (edAsse.SelectedValue != null && edAsse.SelectedValue != "")
                {
                    IdAsse = Convert.ToInt32(edAsse.SelectedValue);
                    if (hdnIdAzione.Value != null && hdnIdAzione.Value != "")
                        IdAzione = Convert.ToInt32(hdnIdAzione.Value.ToString());
                    popolaAzione(IdAsse,IdAzione);
                    if (edAzione.SelectedValue != null && edAzione.SelectedValue != "")
                    {
                        IdAzione = Convert.ToInt32(edAzione.SelectedValue);
                        if (hdnIdIntervento.Value != null && hdnIdIntervento.Value != "")
                            IdIntervento = Convert.ToInt32(hdnIdIntervento.Value.ToString());
                        popolaIntervento(IdAzione, IdIntervento);
                    }
                }
                    
            }
            catch (Exception exc)
            {
                ShowError(exc.Message);
            }
            finally{
                if (_db != null) _db.Close();
            }
        }

        private void popolaAsse(int IdAsseSelected)
        {
            IDbCommand cmd;
                cmd = _db.GetCommand();
                cmd.CommandText = @"SELECT ID, CODICE, DESCRIZIONE, COD_TIPO FROM zPROGRAMMAZIONE where COD_TIPO='POR20142020L1' or COD_TIPO='FSE20142020L1' ORDER BY ID";
                _db.InitDatareader(cmd);
                IDataReader dr = null;

                try
                {
                    dr = _db.DataReader;
                    while (dr.Read())
                        edAsse.Items.Add(new ListItem("ASSE " + dr["CODICE"] + (dr["COD_TIPO"].ToString()=="FSE20142020L1" ? " (FSE)" : "") + " - " + dr["DESCRIZIONE"].ToString(), dr["ID"].ToString()));
                    dr.Close();
                }
                catch (Exception ex)
                {
                    if (dr != null && dr.IsClosed) dr.Close();
                    throw ex;
                }
                if(IdAsseSelected != 0 )
                    edAsse.Items.FindByValue(Convert.ToString(IdAsseSelected)).Selected= true; 

        }

        private void popolaAzione(int IdAsse, int IdAzioneSelected)
        {
            IDbCommand cmd;
            cmd = _db.GetCommand();
            cmd.CommandText = @"SELECT ID, CODICE, DESCRIZIONE FROM zPROGRAMMAZIONE where (COD_TIPO='POR20142020L2' or COD_TIPO='FSE20142020L2') and ID_PADRE=" + IdAsse.ToString() + " ORDER BY ID";
            _db.InitDatareader(cmd);
            IDataReader dr = null;

            try
            {
                dr = _db.DataReader;

                while (dr.Read())
                    edAzione.Items.Add(new ListItem("AZIONE " + dr["CODICE"] + " - " + dr["DESCRIZIONE"].ToString(), dr["ID"].ToString()));
                dr.Close();
            }
            catch (Exception ex)
            {
                if (dr != null && dr.IsClosed) dr.Close();
                throw ex;
            }
            if (IdAzioneSelected != 0)
            {
                edAzione.Items.FindByValue(Convert.ToString(IdAzioneSelected)).Selected = true; 
            }
        }

        private void popolaIntervento(int IdAzione, int IdInterventoSelected)
        {
            string cod_ente_sigef = Operatore.Utente.CodEnte;
            string whereFiltroUO = @"";
            if (cod_ente_sigef != "%") 
                whereFiltroUO = @" and zPROGRAMMAZIONE.ID IN 
                                    (SELECT ID_PROGRAMMAZIONE from GANTT_UO_PROGRAMMAZIONE
                                    INNER JOIN UO ON UO.ID_UO = GANTT_UO_PROGRAMMAZIONE.ID_UO
                                    INNER JOIN GANTT_UO_SIGEF ON  GANTT_UO_SIGEF.ID_UO = UO.ID_UO
                                    where GANTT_UO_SIGEF.COD_ENTE_SIGEF = '" + cod_ente_sigef + @"')";                

            IDbCommand cmd;
            cmd = _db.GetCommand();
            cmd.CommandText = @"SELECT ID, CODICE, DESCRIZIONE FROM zPROGRAMMAZIONE where (COD_TIPO='POR20142020L3' or COD_TIPO='FSE20142020L3') and ID_PADRE=" + IdAzione.ToString() + whereFiltroUO + " ORDER BY ID";

            /*
             * string cod_ente_sigef = Operatore.Utente.CodEnte;
             * if (cod_ente_sigef == "%")
             * WHERE */

            _db.InitDatareader(cmd);
            IDataReader dr = null;
            
            try
            {
                dr = _db.DataReader;

                while (dr.Read())
                    edIntervento.Items.Add(new ListItem("INTERVENTO " + dr["CODICE"] + " - " + dr["DESCRIZIONE"].ToString(), dr["ID"].ToString()));
                dr.Close();
            }
            catch (Exception ex)
            {
                if (dr != null && dr.IsClosed) dr.Close();
                throw ex;
            }
            if (IdInterventoSelected != 0)
            {
                edIntervento.Items.FindByValue(Convert.ToString(IdInterventoSelected)).Selected = true;
            }
        }

        protected void SalvaBando_click(object sender, EventArgs e)
        {
            try
            {
                int retval = -1;
                decimal importo=0, importoPrevisto=0, importoFinanziato = 0, importoCertificato=0 , idIntervento=0;
                if (txtOggetto.Value == null || txtOggetto.Value == "")
                    throw new Exception("Inserire l'oggetto");
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
                
                idIntervento = Convert.ToInt32( edIntervento.SelectedValue);
                IDbCommand cmd = _db.InitCmd("ZGanttBandoInsert", new string[] { "oggetto", "importo", "IMPORTO_PREVISTO", "IMPORTO_FINANZIATO", "IMPORTO_CERTIFICATO", "ID_PROGRAMMAZIONE" }, new string[] { "string", "decimal", "decimal", "decimal", "decimal", "int" }, null);
                SiarLibrary.DbProvider.SetCmdParam(cmd, _db.CommandFirstChar + "oggetto", (SiarLibrary.NullTypes.StringNT)txtOggetto.Value);
                SiarLibrary.DbProvider.SetCmdParam(cmd, _db.CommandFirstChar + "importo", (SiarLibrary.NullTypes.DecimalNT)importo);
                SiarLibrary.DbProvider.SetCmdParam(cmd, _db.CommandFirstChar + "IMPORTO_PREVISTO", (SiarLibrary.NullTypes.DecimalNT)importoPrevisto);
                SiarLibrary.DbProvider.SetCmdParam(cmd, _db.CommandFirstChar + "IMPORTO_FINANZIATO", (SiarLibrary.NullTypes.DecimalNT)importoFinanziato);
                SiarLibrary.DbProvider.SetCmdParam(cmd, _db.CommandFirstChar + "IMPORTO_CERTIFICATO", (SiarLibrary.NullTypes.DecimalNT)importoCertificato);
                SiarLibrary.DbProvider.SetCmdParam(cmd, _db.CommandFirstChar + "ID_PROGRAMMAZIONE", (SiarLibrary.NullTypes.IntNT)idIntervento);
                
                _db.ExecuteScalar(cmd);
                Response.Redirect("ElencoBandi.aspx");
            }
            catch (Exception ex)
            {
                //if (dr != null && dr.IsClosed) dr.Close();
                ShowError(ex.Message);
            }
        }

    }
}
