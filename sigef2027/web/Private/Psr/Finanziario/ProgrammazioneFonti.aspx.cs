using System;
using System.Web.UI.WebControls;

namespace web.Private.Psr.Programmazione
{
    public partial class ProgrammazioneFonti : SiarLibrary.Web.PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "psr_fin_fonti";
            base.OnPreInit(e);
        }

        SiarBLL.ZprogrammazioneCollectionProvider prog_provider = new SiarBLL.ZprogrammazioneCollectionProvider();
        SiarLibrary.Zprogrammazione prog_selezionata = null;
        SiarBLL.ZprogrammazioneFontiCollectionProvider fonti_provider;        
        SiarBLL.FontiFinanziarieCollectionProvider fontif;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            fonti_provider = new SiarBLL.ZprogrammazioneFontiCollectionProvider(prog_provider.DbProviderObj);
            fontif = new SiarBLL.FontiFinanziarieCollectionProvider(prog_provider.DbProviderObj);
            int id_programmazione;//, id_fonte;
            if (int.TryParse(hdnIdProgrammazione.Value, out id_programmazione)) prog_selezionata = prog_provider.GetById(id_programmazione);
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
                    tbFonti.Visible = true;

                    SiarLibrary.ZprogrammazioneFontiCollection pf = fonti_provider.GetProgrammazioneFonti(prog_selezionata.Id);
                    dgFonti.DataSource = pf;
                    dgFonti.ItemDataBound += new DataGridItemEventHandler(dgFonti_ItemDataBound);
                    dgFonti.DataBind();

                }
                else
                {
                    prog_selezionata = null;
                    hdnIdProgrammazione.Value = null;
                    progs = prog_provider.GetProgrammazionePsr(lstPsr.SelectedValue, null, null, null, null, null, true);
                }
                if (progs.Count == 0) dgProgrammazione.Titolo = "Il Psr selezionato non possiede nessun albero di programmazione.";
                else
                {
                    dgProgrammazione.Titolo = "Selezionare l`elemento di programmazione a cui agganciare le fonti:";
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

        protected void btnFonteSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (prog_selezionata == null) throw new Exception("Per proseguire è necessario selezionare l'elemento di programmazione desiderato.");


                string[] selezionati = ((SiarLibrary.Web.CheckColumn)dgFonti.Columns[5]).GetSelected();
                SiarBLL.ZprogrammazioneFontiCollectionProvider programmazionefonti_provider = new SiarBLL.ZprogrammazioneFontiCollectionProvider();
                double perctot = 0;
                double perc;
                foreach (string s in selezionati)
                {
                    if (double.TryParse(Request.Form["dgtxtPercentuale" + s + "_text"], out perc))
                        perctot = perctot + perc;
                }

                if (perctot > 100)
                {
                    ShowMessage("Il totale delle percentuali non può superare 100.");
                }
                else
                {
                    //Deselezionati: modifico
                    SiarLibrary.ZprogrammazioneFontiCollection pfcol = fonti_provider.Select(null, prog_selezionata.Id, null, null, null, null, null, null, true);
                    bool disattivato = true;
                    int i;
                    for (i = 0; i < pfcol.Count; i++)
                    {
                        disattivato = true;
                        foreach (string s in selezionati)
                        {
                            if (pfcol[i].IdFonte == s) disattivato = false;
                        }
                    
                        if (disattivato == true)
                        {
                            pfcol[i].DataFine = DateTime.Now;
                            pfcol[i].OperatoreFine = Operatore.Utente.IdUtente;
                            pfcol[i].Attiva = false;
                            programmazionefonti_provider.Save(pfcol[i]);
                        }
                    }

                    //Selezionati: se esistono già non faccio niente, altrimenti inserisco
                    foreach (string s in selezionati)
                    {
                        decimal quota;
                        SiarLibrary.ZprogrammazioneFontiCollection pfc = fonti_provider.Select( null, prog_selezionata.Id, s, null, null, null, null, null, true);
                        if (pfc.Count == 0)
                        {
                            SiarLibrary.ZprogrammazioneFonti pf = new SiarLibrary.ZprogrammazioneFonti();
                            pf.IdFonte = s;
                            pf.IdProgrammazione = prog_selezionata.Id;
                            if (decimal.TryParse(Request.Form["dgtxtPercentuale" + s + "_text"], out quota))
                            {
                                if (quota < 0) throw new Exception("Non è possibile specificare percentuali negative.");
                            }
                            else
                            {
                                SiarLibrary.FontiFinanziarie ff = new SiarLibrary.FontiFinanziarie();
                                ff = fontif.GetById(s);
                                quota = ff.Percentuale;
                            }
                            pf.Percentuale = quota;
                            pf.DataInizio = DateTime.Now;
                            pf.OperatoreInizio = Operatore.Utente.IdUtente;
                            pf.Attiva = true;
                            programmazionefonti_provider.Save(pf);


                        }
                    }

                    ShowMessage("Fonti su programmazione salvate correttamente.");
                }
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnProgrammazionePost_Click(object sender, EventArgs e)
        {

        }

        void dgFonti_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.ZprogrammazioneFonti b = (SiarLibrary.ZprogrammazioneFonti)e.Item.DataItem;
                if (b.IdProgrammazione != null)
                {
                    e.Item.Cells[5].Text = e.Item.Cells[5].Text.Replace("<input ", "<input checked ");
                }
                else
                {
                    e.Item.Cells[5].Text = e.Item.Cells[5].Text.Replace("<input checked ", "<input ");

                }
            }
        }
    }
}
