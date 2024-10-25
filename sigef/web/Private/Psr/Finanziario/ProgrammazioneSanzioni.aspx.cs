using System;
using System.Web.UI.WebControls;

namespace web.Private.Psr.Programmazione
{
    public partial class ProgrammazioneSanzioni : SiarLibrary.Web.PrivatePage
    {
        // ZProgrammazione
        SiarBLL.ZprogrammazioneCollectionProvider prog_provider = new SiarBLL.ZprogrammazioneCollectionProvider();
        SiarLibrary.Zprogrammazione prog_selezionata = null;
        // ZProgrammazione_Sanzioni
        SiarBLL.ZprogrammazioneSanzioniCollectionProvider Sanzioni_Provider;        


        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "psr_fin_sanzioni";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Sanzioni_Provider = new SiarBLL.ZprogrammazioneSanzioniCollectionProvider(prog_provider.DbProviderObj);
            HiddenFields_Valorizza();
        }

        protected override void OnPreRender(EventArgs e)
        {
            lstPsr.DataBind();
            if (!string.IsNullOrEmpty(lstPsr.SelectedValue))
            {
                SiarLibrary.ZprogrammazioneCollection progs;
                if (prog_selezionata != null && prog_selezionata.CodPsr == lstPsr.SelectedValue)
                {
                    progs = Sanzioni_Visualizza();
                }
                else
                {
                    prog_selezionata = null;
                    hdnIdProgrammazione.Value = null;
                    progs = prog_provider.GetProgrammazionePsr(lstPsr.SelectedValue, null, null, null, true, null, null);
                }

                if (progs.Count == 0)
                {
                    dgProgrammazione.Titolo = "Il Psr selezionato non possiede nessun albero di programmazione.";
                }
                else
                {
                    dgProgrammazione.Titolo = "Selezionare l`elemento di programmazione a cui agganciare le sanzioni:";
                    dgProgrammazione.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgProgrammazione_ItemDataBound);
                }

                dgProgrammazione.DataSource = progs;
                dgProgrammazione.DataBind();
            }
            base.OnPreRender(e);
        }

        private SiarLibrary.ZprogrammazioneCollection Sanzioni_Visualizza()
        {
            SiarLibrary.ZprogrammazioneCollection progs;
            progs = new SiarLibrary.ZprogrammazioneCollection();
            progs.Add(prog_selezionata);
            
            // Visualizza griglia sanzioni
            tbSanzioni.Visible = true;
            
            // SiarLibrary.ZprogrammazioneSanzioniCollection snz = Sanzioni_Provider.GetByIdProgrammazione(prog_selezionata.Id);
            SiarLibrary.ZprogrammazioneSanzioniCollection snz = Sanzioni_Provider.GetByIdProgrammazione_Attivo(prog_selezionata.Id);
            dgSanzioni.Titolo = "Elementi trovati: " + snz.Count;
            dgSanzioni.DataSource = snz;
            dgSanzioni.ItemDataBound += new DataGridItemEventHandler(dgSanzioni_ItemDataBound);
            dgSanzioni.DataBind();

            return progs;
        }

        void dgSanzioni_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.ZprogrammazioneSanzioni s = (SiarLibrary.ZprogrammazioneSanzioni)e.Item.DataItem;
                if (s.Id != null)
                {
                    e.Item.Cells[5].Text = e.Item.Cells[5].Text.Replace("<input ", "<input checked ");
                }
            }
        }

        void dgProgrammazione_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (prog_selezionata != null)
                {
                    SiarLibrary.Zprogrammazione p = (SiarLibrary.Zprogrammazione)e.Item.DataItem;
                    if (p.Id == prog_selezionata.Id)
                    {
                        e.Item.Cells[4].Text = e.Item.Cells[4].Text.Replace("<input ", "<input checked ");
                    }
                }
                else
                {
                    e.Item.Cells[4].Text = e.Item.Cells[4].Text.Replace("checked", "");
                }
            }
        }

        protected void btnProgrammazionePost_Click(object sender, EventArgs e)
        {

        }

        private void HiddenFields_Valorizza()
        {
            int id_programmazione;

            // hdnIdProgrammazione
            if (int.TryParse(hdnIdProgrammazione.Value, out id_programmazione))
            {
                prog_selezionata = prog_provider.GetById(id_programmazione);
            }
        }

        protected void btnSanzioniSalva_Click(object sender, EventArgs e)
        {
            SiarLibrary.ZprogrammazioneSanzioniCollection sanzioni_db = Sanzioni_Provider.GetByIdProgrammazione_Attivo(prog_selezionata.Id);
            SiarLibrary.ZprogrammazioneSanzioniCollection sanzioni_new = new SiarLibrary.ZprogrammazioneSanzioniCollection();
            string[] snzSel = ((SiarLibrary.Web.CheckColumn)dgSanzioni.Columns[5]).GetSelected();

            foreach (SiarLibrary.ZprogrammazioneSanzioni snz in sanzioni_db)
            {
                snz.Attiva = false;
                snz.Ordine = null;

                foreach (string s in snzSel)
                {
                    int ordine;
                    string CodSanzione;

                    int.TryParse(Request.Form["dgTxtOrdine" + s + "_text"], out ordine);
                    CodSanzione = s;

                    if (snz.CodSanzione == s)
                    {
                        snz.Attiva = true;
                        snz.Ordine = ordine;
                    }
                }

                // Valorizzo i campi base nel caso in cui la sanzione non sia mai stata usata su questa Programmazione
                if (snz.IdProgrammazione == null)
                {
                    snz.IdProgrammazione = prog_selezionata.Id;
                }

                sanzioni_new.Add(snz);
            }

            SiarBLL.ZprogrammazioneSanzioniCollectionProvider snzpro = new SiarBLL.ZprogrammazioneSanzioniCollectionProvider();
            foreach (SiarLibrary.ZprogrammazioneSanzioni snz in sanzioni_new)
            {
                if (snz.Attiva)
                {
                    snzpro.Sanzione_Attiva(snz.IdProgrammazione, snz.CodSanzione, snz.Ordine, Operatore.Utente.IdUtente);
                }
                else
                {
                    snzpro.Sanzioni_Disattiva(snz.IdProgrammazione, snz.CodSanzione, Operatore.Utente.IdUtente);
                }
            }
        }

    }
}
