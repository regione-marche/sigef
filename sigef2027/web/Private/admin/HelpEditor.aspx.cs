using System;
using System.Web.UI.WebControls;
using System.Reflection;

namespace web.Private.admin
{
    public partial class HelpEditor : SiarLibrary.Web.PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "adm_help_editor";
            base.OnPreInit(e);
        }

        SiarBLL.PageHelpCollectionProvider help_provider = new SiarBLL.PageHelpCollectionProvider();
        SiarLibrary.PageHelp help_selezionato;

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Collections.Generic.List<ListItem> tipi = new System.Collections.Generic.List<ListItem>();
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                string nome_pagina = type.FullName.ToLower();
                if (type.BaseType.ToString().EndsWith("Page") && nome_pagina.StartsWith("web.") && !nome_pagina.StartsWith("web.controls"))
                    tipi.Add(new ListItem(nome_pagina.Replace(".", "/") + ".aspx", nome_pagina));
            }
            tipi.Sort(delegate(ListItem x, ListItem y) { return x.Value.CompareTo(y.Value); });
            lstPages.Items.Clear();
            lstPages.Items.Add("");
            lstPages.Items.AddRange(tipi.ToArray());
            int id_help;
            if (int.TryParse(hdnIdHelp.Value, out id_help)) help_selezionato = help_provider.GetById(id_help);
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (help_selezionato != null)
            {
                lstPages.SelectedValue = help_selezionato.Page;
                txtParametri.Text = help_selezionato.Parametri;
                ucFileModifica.IdFile = help_selezionato.IdDoc;
                ucFilePubblicazione.IdFile = help_selezionato.IdPdf;
            }

            SiarLibrary.PageHelpCollection phs = help_provider.Find(null, null, null);
            dgHelp.DataSource = phs;
            dgHelp.SetTitoloNrElementi();
            dgHelp.DataBind();
            base.OnPreRender(e);
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (help_selezionato != null)
                {
                    help_selezionato.Operatore = Operatore.Utente.IdUtente;
                    help_selezionato.Data = DateTime.Now;
                    help_selezionato.Attivo = false;
                    help_provider.Save(help_selezionato);
                }
                help_selezionato = new SiarLibrary.PageHelp();
                help_selezionato.Page = lstPages.SelectedValue;
                help_selezionato.Parametri = txtParametri.Text;
                help_selezionato.IdDoc = ucFileModifica.IdFile;
                help_selezionato.IdPdf = ucFilePubblicazione.IdFile;
                help_selezionato.Operatore = Operatore.Utente.IdUtente;
                help_selezionato.Data = DateTime.Now;
                help_selezionato.Attivo = true;
                help_provider.Save(help_selezionato);
                hdnIdHelp.Value = help_selezionato.Id;
                ShowMessage("Voce di help online salvata correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                if (help_selezionato == null || !help_selezionato.Attivo) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ElementoNonSelezionato);
                help_selezionato.Operatore = Operatore.Utente.IdUtente;
                help_selezionato.Data = DateTime.Now;
                help_selezionato.Attivo = false;
                help_provider.Save(help_selezionato);
                hdnIdHelp.Value = help_selezionato.Id;
                ShowMessage("Voce di help online eliminata correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {

        }
    }
}
