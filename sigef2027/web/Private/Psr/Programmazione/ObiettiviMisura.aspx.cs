using System;
using System.Web.UI.WebControls;

namespace web.Private.Psr.Programmazione
{
    public partial class ObiettiviMisura : SiarLibrary.Web.PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "psr_ob_misura";
            base.OnPreInit(e);
        }

        SiarBLL.ZprogrammazioneCollectionProvider prog_provider = new SiarBLL.ZprogrammazioneCollectionProvider();
        SiarLibrary.Zprogrammazione prog_selezionata = null;
        SiarBLL.ZobMisuraCollectionProvider obmisura_provider;
        SiarLibrary.ZobMisura obmisura_selezionato = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            obmisura_provider = new SiarBLL.ZobMisuraCollectionProvider(prog_provider.DbProviderObj);
            int id_programmazione, id_obmisura;
            if (int.TryParse(hdnIdProgrammazione.Value, out id_programmazione)) prog_selezionata = prog_provider.GetById(id_programmazione);
            if (int.TryParse(hdnIdObMisura.Value, out id_obmisura)) obmisura_selezionato = obmisura_provider.GetById(id_obmisura);
        }

        protected override void OnPreRender(EventArgs e)
        {
            lstPsr.DataBind();
            if (!string.IsNullOrEmpty(lstPsr.SelectedValue))
            {
                SiarLibrary.ZprogrammazioneCollection progs;
                if (prog_selezionata != null && prog_selezionata.CodPsr == lstPsr.SelectedValue)
                {
                    progs = new SiarLibrary.ZprogrammazioneCollection();
                    progs.Add(prog_selezionata);
                    tbObMisura.Visible = true;

                    SiarLibrary.ZobMisuraCollection obs = obmisura_provider.Find(prog_selezionata.Id, null);
                    dgObMisura.DataSource = obs;
                    dgObMisura.Titolo = "Elementi trovati: " + obs.Count;
                    dgObMisura.DataBind();

                    if (obmisura_selezionato != null)
                    {
                        if (obmisura_selezionato.IdProgrammazione != prog_selezionata.Id) { obmisura_selezionato = null; hdnIdObMisura.Value = null; }
                        else
                        {
                            txtObCodice.Text = obmisura_selezionato.Codice;
                            txtObDescrizione.Text = obmisura_selezionato.Descrizione;
                        }
                    }
                    btnObElimina.Enabled = obmisura_selezionato != null;
                }
                else
                {
                    prog_selezionata = null;
                    hdnIdProgrammazione.Value = null;
                    progs = prog_provider.GetProgrammazionePsr(lstPsr.SelectedValue, null, null, null, true, null, null);
                }
                if (progs.Count == 0) dgProgrammazione.Titolo = "Il Psr selezionato non possiede nessun albero di programmazione.";
                else
                {
                    dgProgrammazione.Titolo = "Selezionare l`elemento di programmazione a cui agganciare gli obiettivi e le finalità:";
                    dgProgrammazione.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgProgrammazione_ItemDataBound);
                }
                dgProgrammazione.DataSource = progs;
                dgProgrammazione.DataBind();
            }
            base.OnPreRender(e);
        }

        void dgProgrammazione_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (prog_selezionata != null)
                {
                    SiarLibrary.Zprogrammazione p = (SiarLibrary.Zprogrammazione)e.Item.DataItem;
                    if (p.Id == prog_selezionata.Id)
                        e.Item.Cells[4].Text = e.Item.Cells[4].Text.Replace("<input ", "<input checked ");
                }
                else e.Item.Cells[4].Text = e.Item.Cells[4].Text.Replace("checked", "");
            }
        }

        protected void btnProgrammazionePost_Click(object sender, EventArgs e)
        {

        }

        protected void btnObSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (prog_selezionata == null) throw new Exception("Per proseguire è necessario selezionare l'elemento di programmazione desiderato.");
                if (obmisura_selezionato == null)
                {
                    obmisura_selezionato = new SiarLibrary.ZobMisura();
                    obmisura_selezionato.IdProgrammazione = prog_selezionata.Id;
                }
                else if (obmisura_selezionato.IdProgrammazione != prog_selezionata.Id)
                    throw new Exception("Per proseguire è necessario selezionare l'elemento di programmazione desiderato.");
                obmisura_selezionato.Codice = txtObCodice.Text;
                obmisura_selezionato.Descrizione = txtObDescrizione.Text;
                obmisura_provider.Save(obmisura_selezionato);
                ShowMessage("Obiettivo salvato correttamente.");
                hdnIdObMisura.Value = obmisura_selezionato.Id;
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnObElimina_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (prog_selezionata == null) throw new Exception("Per proseguire è necessario selezionare l'elemento di programmazione desiderato.");
                if (obmisura_selezionato == null) throw new Exception("Per proseguire è necessario selezionare l'obiettivo da eliminare.");
                obmisura_provider.Delete(obmisura_selezionato);
                ShowMessage("Obiettivo eliminato correttamente.");
                obmisura_selezionato = null;
                RegisterClientScriptBlock("nuovoObMisura();");
            }
            catch (Exception ex) { ShowError(ex); }
        }
    }
}
