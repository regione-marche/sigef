using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.Istruttoria
{
    public partial class GraduatoriaIndividualeAtti : SiarLibrary.Web.IstruttoriaPage
    {

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "Graduatoria";
            base.OnPreInit(e);
        }

        SiarBLL.GraduatoriaProgettiCollectionProvider graduatoria_provider = new SiarBLL.GraduatoriaProgettiCollectionProvider();
        SiarBLL.GraduatoriaProgettiAttiCollectionProvider graduatoria_atti_provider = new SiarBLL.GraduatoriaProgettiAttiCollectionProvider();
        SiarBLL.AttiCollectionProvider atti_provider = new SiarBLL.AttiCollectionProvider();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int id_progetto;

                if (int.TryParse(Request.QueryString["iddom"], out id_progetto))
                {
                    hdnIdProgetto.Value = id_progetto.ToString();
                    SiarLibrary.GraduatoriaProgettiCollection graduatoria_bando = graduatoria_provider.Find(Bando.IdBando, null, null);
                    SiarLibrary.GraduatoriaProgetti gp = graduatoria_bando.CollectionGetById(Bando.IdBando,id_progetto );
                    txtProgetto.Text = id_progetto.ToString();
                    txtContributoTotale.Text = gp.ContributoTotale.ToString();

                    //Popolo la tabella
                }
                
            }
            catch (Exception ex)
            {
                Redirect("GraduatoriaIndividuale.aspx", ex.Message, true);
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            //graduatoria = graduatoria_provider.GetListaProgettiInGraduatoria(Bando.IdBando);
            //dgProgetti.DataSource = graduatoria;
            //dgProgetti.ItemDataBound += new DataGridItemEventHandler(dgProgetti_ItemDataBound);
            //dgProgetti.DataBind();

            SiarLibrary.GraduatoriaProgettiAttiCollection atti_coll = graduatoria_atti_provider.Find(Bando.IdBando,Convert.ToInt32(hdnIdProgetto.Value),null,null);
            dgGradAtti.DataSource = atti_coll;
            dgGradAtti.ItemDataBound  += new DataGridItemEventHandler(dgGradAtti_ItemDataBound);
            dgGradAtti.DataBind();

            lstAttoDefinizione.DataBind();
            lstAttoDefinizione.ClearSelection();
            lstAttoRegistro.DataBind();
            lstAttoRegistro.ClearSelection();

            //se seleziono una riga 
            int idGradProgAtto;
            if (int.TryParse(HdnIdGradProgettiAtti.Value, out idGradProgAtto))
            {
                divAtto.Visible = true;
                SiarLibrary.GraduatoriaProgettiAtti gpa = graduatoria_atti_provider.GetById(idGradProgAtto);
                txtAttoImporto.Text = gpa.Importo;
                SiarBLL.AttiCollectionProvider atti_prov = new SiarBLL.AttiCollectionProvider();
                SiarLibrary.Atti atto = atti_prov.GetById(gpa.IdAtto);
                foreach (ListItem l in lstAttoRegistro.Items) if (l.Value.StartsWith(atto.Registro)) { l.Selected = true; break; }
                //lstAttoRegistro.SelectedValue = atto.Registro;
                lstAttoDefinizione.SelectedValue = atto.CodDefinizione;
                txtAttoNumero.Text = atto.Numero;
                txtAttoData.Text = atto.Data.ToStringAgid();
            }
            else
            {
                txtAttoImporto.Text = "";
                txtAttoNumero.Text = "";
                txtAttoData.Text = "";
            }


            base.OnPreRender(e);
        }

        decimal tot_contributo = 0;

        void dgGradAtti_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.GraduatoriaProgettiAtti gpa = (SiarLibrary.GraduatoriaProgettiAtti)e.Item.DataItem;
                if (gpa.IdAtto != null)
                {
                    SiarBLL.AttiCollectionProvider atti_prov = new SiarBLL.AttiCollectionProvider();
                    SiarLibrary.Atti atto = atti_prov.GetById(gpa.IdAtto);
                    e.Item.Cells[2].Text = "<input type=button class='btn btn-secondary py-1' value='" + atto.Numero.ToString() + "|"
                       + atto.Data.ToString() + "|" + atto.Registro + "' onclick=\"visualizzaAtto(" + atto.IdAtto + ");\" />";
                }

                //calcolo totale del footer
                if (gpa.Importo != null) tot_contributo += gpa.Importo;
                
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells[1].Text = string.Format("{0:c}", tot_contributo);
            }
        }

        
        protected void AggiungiDecr_Click(object sender, EventArgs e)
        {
            try
            {

                divAtto.Visible = true;
                HdnIdGradProgettiAtti.Value = null;
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnSelezionaGradProgettiAtti_Click(object sender, EventArgs e)
        {        }

        protected void btnSalvaRiga_Click(object sender, EventArgs e)
        {
            try
            {
                //
                if (txtAttoImporto.Text == "" || txtAttoImporto.Text == null)
                    throw new Exception("Per proseguire è necessario inserire il contributo del progetto relativo al decreto/delibera.");
                // le delibere non hanno il registro
                if (txtAttoData.Text == "" || txtAttoData.Text == null
                    || txtAttoNumero.Text == "" || txtAttoNumero.Text == null
                    || lstAttoDefinizione.SelectedValue == ""
                    || (lstAttoDefinizione.SelectedValue == "Decreto" && (lstAttoRegistro.SelectedValue == "" || lstAttoRegistro.SelectedValue == null)))
                    throw new Exception("Per proseguire è necessario compilare tutti i dati relativi al decreto/delibera.");

                //Calcolo la somma degli importi che non sia superiore al totale
                SiarLibrary.GraduatoriaProgettiAttiCollection coll = graduatoria_atti_provider.Find(Bando.IdBando, Convert.ToInt32(hdnIdProgetto.Value), null, null);
                decimal totale_calcolato = 0;
                decimal totale_prog = Convert.ToDecimal(txtContributoTotale.Text);
                int id = 0;
                if (HdnIdGradProgettiAtti.Value != null && HdnIdGradProgettiAtti.Value != "")
                    id = Convert.ToInt32(HdnIdGradProgettiAtti.Value);
                foreach (SiarLibrary.GraduatoriaProgettiAtti a in coll)
                {
                    if (a.IdGraduatoriaProgettiAtti != id)
                        totale_calcolato += a.Importo;
                }
                totale_calcolato += Convert.ToDecimal(txtAttoImporto.Text);
                if (totale_calcolato > totale_prog)
                    throw new Exception("Impossibile salvare. Il totale dei decreti/delibere supera il contributo complessivo del progetto. Diminuire l'importo del decreto che si sta per inserire o di quelli giò inseriti.");

                //Verifico che l'atto esisti
                int numero, id_atto;
                int.TryParse(txtAttoNumero.Text, out numero);
                DateTime data;
                DateTime.TryParse(txtAttoData.Text, out data);
                string registro = lstAttoRegistro.SelectedValue;
                if (!string.IsNullOrEmpty(lstAttoRegistro.SelectedValue) && lstAttoRegistro.SelectedValue.IndexOf("|") > 0)
                    registro = lstAttoRegistro.SelectedValue.Substring(0, lstAttoRegistro.SelectedValue.IndexOf("|"));
                // controllo che l'atto sia registrato su db, altrimenti lo importo
                SiarLibrary.AttiCollection atti_trovati = atti_provider.Find(numero, data, lstAttoDefinizione.SelectedValue, registro);
                if (atti_trovati.Count == 0)
                {
                    atti_trovati = atti_provider.ImportaAtto(numero, data, lstAttoDefinizione.SelectedValue, lstAttoRegistro.SelectedValue);
                    if (atti_trovati.Count > 0) atti_provider.Save(atti_trovati[0]);
                }
                if (atti_trovati.Count > 0)
                {
                    id_atto = atti_trovati[0].IdAtto;
                }
                else throw new Exception("Attenzione, nessuna delibera/decreto trovato con i parametri inseriti!.");

                SiarLibrary.GraduatoriaProgettiAtti atto;
                if (id == 0)
                {
                    atto = new SiarLibrary.GraduatoriaProgettiAtti();
                    atto.IdBando = Bando.IdBando;
                    atto.IdProgetto = Convert.ToInt32(hdnIdProgetto.Value);
                    atto.DataCreazione = DateTime.Today;
                    atto.OperatoreCreazione = Operatore.Utente.IdUtente;
                }
                else
                    atto = graduatoria_atti_provider.GetById(id);
                atto.DataAggiornamento = DateTime.Today;
                atto.OperatoreAggiornamento = Operatore.Utente.IdUtente;
                atto.Importo = txtAttoImporto.Text;
                atto.IdAtto = id_atto;
                atto.FinanziabilitaTotale = false;
                if(totale_calcolato == totale_prog)
                {
                    atto.FinanziabilitaTotale = true;
                    foreach (SiarLibrary.GraduatoriaProgettiAtti a in coll)
                    {
                        if (a.IdGraduatoriaProgettiAtti != id)
                        {
                            a.FinanziabilitaTotale = false;
                            graduatoria_atti_provider.Save(a);
                        }
                    }
                }
                graduatoria_atti_provider.Save(atto);

                HdnIdGradProgettiAtti.Value = "";
                ShowMessage("Decreto inserito correttamente!");

            }
            catch (Exception ex) { ShowError(ex); }
        }

    }
}