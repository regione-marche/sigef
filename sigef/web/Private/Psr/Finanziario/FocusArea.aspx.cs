using System;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace web.Private.Psr.Finanziario
{
    public partial class FocusArea : SiarLibrary.Web.PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "psr_fin_focus_area";
            base.OnPreInit(e);
        }

        SiarBLL.ZfocusAreaCollectionProvider fa_provider = new SiarBLL.ZfocusAreaCollectionProvider();
        SiarBLL.ZprogFaCollectionProvider progfa_provider;
        SiarLibrary.ZfocusArea fa_selezionata = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            progfa_provider = new SiarBLL.ZprogFaCollectionProvider(fa_provider.DbProviderObj);
            if (!string.IsNullOrEmpty(hdnCodFA.Value) && hdnCodFA.Value.Length < 11)
                fa_selezionata = fa_provider.GetById(hdnCodFA.Value);
        }

        protected override void OnPreRender(EventArgs e)
        {
            switch (ucSiarNewTab.TabSelected)
            {
                case 2:
                    tabDettaglio.Visible = true;
                    lstPsr.DataBind();
                    if (fa_selezionata != null)
                    {
                        txtCodice.Text = fa_selezionata.Codice;
                        lstPsr.SelectedValue = fa_selezionata.CodPsr;
                        chkObTrasversale.Checked = fa_selezionata.Trasversale;
                        txtDescrizione.Text = fa_selezionata.Descrizione;
                        trDotazioneFinanziaria.Visible = true;

                        SiarLibrary.ZprogFaCollection prog_fa = progfa_provider.GetDotazioneFinanziariaFA(fa_selezionata.Codice);
                        dgProgrammazione.DataSource = prog_fa;
                        dgProgrammazione.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgProgrammazione_ItemDataBound);
                        dgProgrammazione.DataBind();
                        RegisterClientScriptBlock("checkDgProgInputColumnsOnLoad_handler();");
                    }
                    else btnElimina.Enabled = false;
                    break;
                case 3:
                    tabOperazione.Visible = true;
                    lstProgrammazione.Attributes.Add("onchange", "swapTab(3);");
                    lstProgrammazione.DataBind();

                    if (!string.IsNullOrEmpty(lstProgrammazione.SelectedValue))
                    {
                        SiarLibrary.ZprogFaCollection cc = progfa_provider.Find(lstProgrammazione.SelectedValue, null, null, null,
                            null, null, null, null, null, null, true);
                        dgFAXOperazione.DataSource = cc;
                        dgFAXOperazione.Titolo = "Elementi trovati: " + cc.Count;
                        dgFAXOperazione.MostraTotale(5, "DotFinanziaria");
                        dgFAXOperazione.DataBind();
                    }
                    break;
                default:
                    tabElenco.Visible = true;
                    SiarLibrary.ZfocusAreaCollection fac = fa_provider.Find(null, null, null);
                    dgFA.DataSource = fac;
                    dgFA.Titolo = "Elementi trovati: " + fac.Count.ToString();
                    dgFA.MostraTotale(5, "DotFinanziaria");
                    dgFA.DataBind();
                    break;
            }

            base.OnPreRender(e);
        }

        decimal tot_dot_finanziaria = 0;
        void dgProgrammazione_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.ZprogFa fa = (SiarLibrary.ZprogFa)e.Item.DataItem;
                HtmlSelect lst = new HtmlSelect();
                lst.ID = "dglstContributoFA_" + fa.IdProgrammazione;
                lst.Attributes.Add("onchange", "lstChange_handler(this);");
                e.Item.Cells[4].Controls.Add(lst);
                lst.Items.Add("");
                ListItem li = new ListItem("Diretto", "D");
                li.Selected = li.Value == fa.TipoContributo;
                lst.Items.Add(li);
                ListItem li2 = new ListItem("Indiretto", "I");
                li2.Selected = li2.Value == fa.TipoContributo;
                lst.Items.Add(li2);
                if (fa.DotFinanziaria != null) tot_dot_finanziaria += fa.DotFinanziaria;
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                SiarLibrary.Web.CurrencyBox cb = new SiarLibrary.Web.CurrencyBox();
                cb.ID = "dgTotFooterDotFinanziaria";
                cb.ReadOnly = true;
                cb.Width = new Unit(100);
                cb.Text = string.Format("{0:N2}", tot_dot_finanziaria);
                e.Item.Cells[5].Controls.Add(cb);
                e.Item.Cells[5].Style.Add("padding-right", "15px");
            }
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (fa_selezionata == null)
                {
                    fa_selezionata = new SiarLibrary.ZfocusArea();
                    fa_selezionata.Codice = txtCodice.Text;
                    fa_selezionata.CodPsr = lstPsr.SelectedValue;
                }
                fa_selezionata.Trasversale = chkObTrasversale.Checked;
                fa_selezionata.Descrizione = txtDescrizione.Text;
                fa_provider.Save(fa_selezionata);
                hdnCodFA.Value = fa_selezionata.Codice;
                ShowMessage("Focus area salvata correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (fa_selezionata == null) throw new Exception("Per proseguire è necessario selezionare l'elemento da eliminare.");
                fa_provider.DbProviderObj.BeginTran();

                progfa_provider.DeleteCollection(progfa_provider.Find(null, fa_selezionata.Codice, null, null, null, null, null, null, null, null, null));
                fa_provider.Delete(fa_selezionata);
                fa_provider.DbProviderObj.Commit();
                ShowMessage("Focus area eliminata correttamente.");
                RegisterClientScriptBlock("nuovaFA();");
            }
            catch (Exception ex) { fa_provider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnSalvaDotazione_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (fa_selezionata == null) throw new Exception("Per proseguire è necessario selezionare la Focus Area desiderata.");
                fa_provider.DbProviderObj.BeginTran();
                decimal dot_finanziaria_fa = 0;

                /* nuovo codice, quando avro' voja de farlo
                foreach (SiarLibrary.ZprogFa pf in progfa_provider.GetDotazioneFinanziariaFA(fa_selezionata.Codice))
                {
                    string tipo_contributo = Request.Form["dglstContributoFA_" + pf.IdProgrammazione];
                    decimal df = 0;
                    decimal.TryParse(Request.Form["dgTxtDotFinanziaria" + pf.IdProgrammazione + "_text"], out df);
                    switch (tipo_contributo)
                    {
                        case "I":
                        case "D":
                            if (pf.Id == null) pf.MarkAsNew();
                            else if(

                            break;
                        default: break;
                    }




                    pf.Attivo = false;
                    progfa_provider.Save(pf);
                }

                foreach (string s in Request.Form.AllKeys)
                {
                    if (s.Contains("dglstContributoFA_"))
                    {
                        string tipo_contributo = Request.Form[s];
                        if (!string.IsNullOrEmpty(tipo_contributo))
                        {
                            string id_programmazione = s.Substring(s.IndexOf("dglstContributoFA_") + "dglstContributoFA_".Length);
                            SiarLibrary.ZprogFa pf = new SiarLibrary.ZprogFa();
                            pf.CodFa = fa_selezionata.Codice;
                            pf.IdProgrammazione = id_programmazione;
                            pf.TipoContributo = tipo_contributo;
                            decimal df = 0;
                            decimal.TryParse(Request.Form["dgTxtDotFinanziaria" + id_programmazione + "_text"], out df);
                            pf.DotFinanziaria = df;
                            dot_finanziaria_fa += df;
                            pf.Attivo = true;
                            pf.Data = DateTime.Now;
                            pf.Operatore = Operatore.Utente.IdUtente;
                            progfa_provider.Save(pf);
                        }
                    }
                }
                */


                foreach (SiarLibrary.ZprogFa pf in progfa_provider.Find(null, fa_selezionata.Codice, null, null, null, null, null, null, null, null, true))
                {
                    pf.Attivo = false;
                    progfa_provider.Save(pf);
                }

                foreach (string s in Request.Form.AllKeys)
                {
                    if (s.Contains("dglstContributoFA_"))
                    {
                        string tipo_contributo = Request.Form[s];
                        if (!string.IsNullOrEmpty(tipo_contributo))
                        {
                            string id_programmazione = s.Substring(s.IndexOf("dglstContributoFA_") + "dglstContributoFA_".Length);
                            SiarLibrary.ZprogFa pf = new SiarLibrary.ZprogFa();
                            pf.CodFa = fa_selezionata.Codice;
                            pf.IdProgrammazione = id_programmazione;
                            pf.TipoContributo = tipo_contributo;
                            decimal df = 0;
                            decimal.TryParse(Request.Form["dgTxtDotFinanziaria" + id_programmazione + "_text"], out df);
                            pf.DotFinanziaria = df;
                            dot_finanziaria_fa += df;
                            pf.Attivo = true;
                            pf.Data = DateTime.Now;
                            pf.Operatore = Operatore.Utente.IdUtente;
                            progfa_provider.Save(pf);
                        }
                    }
                }
                // aggiorno la focus area
                fa_selezionata.DotFinanziaria = dot_finanziaria_fa;
                fa_provider.Save(fa_selezionata);
                fa_provider.DbProviderObj.Commit();
                ShowMessage("Dotazione finanziaria salvata correttamente.");
            }
            catch (Exception ex) { fa_provider.DbProviderObj.Rollback(); ShowError(ex); }
        }
    }
}
