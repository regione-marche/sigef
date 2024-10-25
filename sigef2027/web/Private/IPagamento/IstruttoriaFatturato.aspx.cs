using System;
using System.Web.UI.WebControls;

namespace web.Private.IPagamento
{

    public partial class IstruttoriaFatturato : SiarLibrary.Web.IstruttoriaPagamentoPage
    {
        private SiarBLL.FatturatoAziendaCollectionProvider fattprovider = new SiarBLL.FatturatoAziendaCollectionProvider();
        SiarLibrary.Impresa impresa;
        decimal ricavo_footer = 0;
        decimal fatturato_footer = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            impresa = new SiarBLL.ImpresaCollectionProvider().GetById(Progetto.IdImpresa);
            lstAnno.DataBinding += new EventHandler(lstAnno_DataBinding);
           // lstAliquota.DataBinding += new EventHandler(lstAliquota_DataBinding);

        }
        protected override void OnPreRender(EventArgs e)
        {
            if (Request.QueryString["redir"] == "revisione") btnBack.Attributes["onclick"] = "location='Revisionedomande.aspx?&idpag="
               + DomandaPagamento.IdDomandaPagamento + "'";
            lstAliquota.DataBind();
            lstAnno.DataBind();
            SiarLibrary.FatturatoAziendaCollection fatturato = fattprovider.Find(null, impresa.IdImpresa, lstAnno.SelectedValue, null);
            if (string.IsNullOrEmpty(lstAnno.SelectedValue)) { btnInsertProdotto.Enabled = false; lstAliquota.SelectedValue = ""; }

            if (fatturato.Count == 0)
            {
                dgFatturato.Titolo = "<em>- Nessun fatturato presente per l'anno selezionato.</em>";
                btnSalva.Visible = false;
                btnBack.Visible = false;
            }

            dgFatturato.DataSource = fatturato;
            dgFatturato.ItemDataBound += new DataGridItemEventHandler(dgFatturato_ItemDataBound);
            dgFatturato.DataBind();
            base.OnPreRender(e);
        }

        void dgFatturato_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.FatturatoAzienda fatturatoAzienda = (SiarLibrary.FatturatoAzienda)dgi.DataItem;

                Literal l = new Literal();
                l.Text = "Aliquota IVA " + fatturatoAzienda.Aliquota + "%";
                e.Item.Cells[1].Controls.Add(l);
                // imposto un hidden per memorizzare l'id della plv

                HiddenField hda = new HiddenField();
                hda.ID = "AliquotaIVA" + fatturatoAzienda.IdFatturato;
                hda.Value = fatturatoAzienda.Aliquota;
                e.Item.Cells[1].Controls.Add(hda);
                //---   

                decimal ricavo = Math.Round(fatturatoAzienda.Importo.Value + fatturatoAzienda.Importo.Value / 100 * fatturatoAzienda.Aliquota.Value, 2);
                e.Item.Cells[3].ID = "Ricavo" + fatturatoAzienda.IdFatturato + "_text'";
                e.Item.Cells[3].Text = String.Format("{0:N}", ricavo);
                fatturato_footer += fatturatoAzienda.Importo.Value;
                ricavo_footer += ricavo;
                //aggancio l'onblur
                string testo = dgi.Cells[2].Text.Replace("name='Imponibile" + fatturatoAzienda.IdFatturato + "_text'",
                    "name='Imponibile" + fatturatoAzienda.IdFatturato + "_text' onblur='CalcoloRicavo(" + fatturatoAzienda.IdFatturato + ")' ");
                dgi.Cells[2].Text = testo;
                
            }

            if (e.Item.ItemType == ListItemType.Footer)
            {
                dgi.Cells[2].Attributes.Add("align", "right");
                dgi.Cells[3].Attributes.Add("align", "right");
                dgi.Cells[2].ID = "lblFatturatoFooter";
                dgi.Cells[3].ID = "lblRicavoFooter";
                dgi.Cells[2].Text = String.Format("{0:N}", fatturato_footer);
                dgi.Cells[3].Text = String.Format("{0:N}", ricavo_footer);
            }
        }
        //void lstAliquota_DataBinding(object sender, EventArgs e)
        //{
        //    if (lstAliquota.Items.Count == 0)
        //    {
        //        lstAliquota.Items.Add(new ListItem("", ""));
        //        lstAliquota.Items.Add(new ListItem("4%", "4"));
        //        lstAliquota.Items.Add(new ListItem("10%", "10"));
        //        lstAliquota.Items.Add(new ListItem("20%", "20"));
        //        lstAliquota.Items.Add(new ListItem("21%", "21"));
        //        lstAliquota.Items.Add(new ListItem("Esente iva", "0"));
        //    }
        //    if (lstAliquota.SelectedValue != null)
        //        lstAliquota.Items.FindByValue(lstAliquota.SelectedValue).Selected = true;
        //}
        void lstAnno_DataBinding(object sender, EventArgs e)
        {
            if (lstAnno.Items.Count == 0)
            {
                lstAnno.Items.Add(new ListItem("", ""));
                int anno_dom_pag = DomandaPagamento.DataModifica.Value.Year;
                for (int i = 1; i < 5; i++)
                    lstAnno.Items.Add(new ListItem(Convert.ToString(anno_dom_pag - i, null), Convert.ToString(anno_dom_pag - i, null)));
            }
            if (lstAnno.SelectedValue != null)
                lstAnno.Items.FindByValue(lstAnno.SelectedValue).Selected = true;
        }
        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                fattprovider.DbProviderObj.BeginTran();
                SiarLibrary.FatturatoAziendaCollection fatturato = fattprovider.Find(null, impresa.IdImpresa, lstAnno.SelectedValue, null);
                foreach (SiarLibrary.FatturatoAzienda voce in fatturato)
                {
                    voce.Importo = Request.Form["Imponibile" + voce.IdFatturato + "_text"].Replace(".", "");
                    fattprovider.Save(voce);
                }
                PagamentoProvider.AggiornaDomandaDiPagamentoIstruttore(DomandaPagamento, ((SiarLibrary.Web.MasterPage)Master).Operatore);
                fattprovider.DbProviderObj.Commit();
                ShowMessage("Fatturato salvato correttamente.");
            }
            catch (Exception ex) { fattprovider.DbProviderObj.Rollback(); ShowError(ex); }
        }
        protected void btnInsertProdotto_Click(object sender, EventArgs e)
        {
            try
            {
                fattprovider.DbProviderObj.BeginTran();
                if (fattprovider.Find(null, impresa.IdImpresa, lstAnno.SelectedValue, lstAliquota.SelectedValue).Count == 0)
                {
                    SiarLibrary.FatturatoAzienda nuova_voce = new SiarLibrary.FatturatoAzienda();
                    nuova_voce.Aliquota = lstAliquota.SelectedValue;
                    nuova_voce.Anno = lstAnno.SelectedValue;
                    nuova_voce.IdImpresa = impresa.IdImpresa;
                    nuova_voce.Importo = 0;
                    nuova_voce.DataModifica = System.DateTime.Now;
                    fattprovider.Save(nuova_voce);
                    ShowMessage("Voce di aliquota inserita correttamente.");
                    PagamentoProvider.AggiornaDomandaDiPagamentoIstruttore(DomandaPagamento, ((SiarLibrary.Web.MasterPage)Master).Operatore);
              }
                else ShowError("Attenzione", "Aliquota già presente.");

                fattprovider.DbProviderObj.Commit();
            }
            catch (Exception ex) { fattprovider.DbProviderObj.Rollback(); ShowError(ex); }
        }
        protected void btnEliminaFatt_Click(object sender, EventArgs e)
        {
            try
            {
                int id_fat;
                if (!int.TryParse(hdnIdFatt.Value, out id_fat)) ShowError("Nessun dato selezionato.");
                else
                {
                    SiarLibrary.FatturatoAzienda f = fattprovider.GetById(id_fat);
                    if (f == null) ShowError("Nessun dato selezionato.");
                    else
                    {
                        fattprovider.Delete(f);
                        ShowMessage("Dato eliminato correttamente.");
                    }
                }
            }
            catch (Exception ex) { ShowError(ex); }
        }


    }
}
