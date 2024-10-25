using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.IPagamento
{
    public partial class DecretiVarianti : SiarLibrary.Web.IstruttoriaPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "selezione_domande_rendicontazione";
            base.OnPreInit(e);
        }

        SiarBLL.VariantiCollectionProvider varianti_provider = new SiarBLL.VariantiCollectionProvider();
        SiarBLL.AttiCollectionProvider atti_provider = new SiarBLL.AttiCollectionProvider();
        SiarLibrary.Varianti variante_selezionata;
        SiarLibrary.Atti decreto;

        protected void Page_Load(object sender, EventArgs e)
        {
            string[] vselezionate = ((SiarLibrary.Web.CheckColumn)dgVarianti.Columns[7]).GetSelected();
            if (vselezionate.Length > 0)
            {
                variante_selezionata = new SiarBLL.VariantiCollectionProvider().GetById(vselezionate[0]);
                if (!string.IsNullOrEmpty(hdnDecretoJson.Value))
                {
                    decreto = new SiarLibrary.Atti();
                    decreto.FillByJsonObject(hdnDecretoJson.Value);
                }
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            btnStampa.Attributes.Add("onclick", "StampaXLS(" + Bando.IdBando + ");");
            SiarLibrary.VariantiCollection varianti;
            if (variante_selezionata != null)
            {
                varianti = new SiarLibrary.VariantiCollection();
                tbDettaglioDecreto.Visible = true;
                lstRegistro.DataBind();
                if (variante_selezionata.IdAttoApprovazione != null && decreto == null) decreto = atti_provider.GetById(variante_selezionata.IdAttoApprovazione);
                if (decreto != null)
                {
                    bindDecreto();
                    variante_selezionata.AdditionalAttributes.Add("DATA_DECRETO", decreto.Data);
                }
                varianti.Add(variante_selezionata);
                btnCercaDecreto.Enabled = btnInserisciDecreto.Enabled = AbilitaModifica && variante_selezionata.IdAttoApprovazione == null;
                btnEliminaDecreto.Enabled = AbilitaModifica && variante_selezionata.IdAttoApprovazione != null;
            }
            else varianti = varianti_provider.FindDecretiApprovazione(Bando.IdBando, txtIdProgetto.Text, (rblEsitoVarianti.SelectedValue == "T" ?
                new SiarLibrary.NullTypes.BoolNT() : new SiarLibrary.NullTypes.BoolNT(rblEsitoVarianti.SelectedValue == "A")), chkDecretiInseriti.Checked);
            dgVarianti.DataSource = varianti;
            dgVarianti.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgVarianti_ItemDataBound);
            dgVarianti.Titolo = "<b>&nbsp;&nbsp;Elementi trovati: " + varianti.Count.ToString() + "</b>";
            dgVarianti.DataBind();
            base.OnPreRender(e);
        }

        void dgVarianti_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.Varianti v = (SiarLibrary.Varianti)e.Item.DataItem;
                if (v.Descrizione != null && v.Descrizione.Value.Length > 190) e.Item.Cells[2].Text = v.Descrizione.Value.Substring(0, 190) + "...";
                e.Item.Cells[4].Text = "<a href=\"javascript:sncAjaxCallVisualizzaProtocollo('" + v.Segnatura + "');\"><img src='../../images/acrobat.gif' alt='Visualizza documento' /></a>";
                e.Item.Cells[5].Text = "<a href=\"javascript:sncAjaxCallVisualizzaProtocollo('" + v.SegnaturaApprovazione + "');\"><img src='../../images/acrobat.gif' alt='Visualizza documento' /></a>";
                if (v.IdAttoApprovazione != null)
                    e.Item.Cells[6].Text = "<a href=\"" + SiarLibrary.DbStaticProvider.GetJsUrlDecreto(v.CodDefinizione, new SiarLibrary.NullTypes.DatetimeNT(v.AdditionalAttributes["DATA_DECRETO"]),
                        v.AwDocnumber, v.AwDocnumberNuovo) + "\"><img src='../../images/word.gif' alt='Visualizza documento' /></a>";
            }
        }

        private void bindDecreto()
        {
            if (decreto != null)
            {
                txtNumeroDecreto.Text = decreto.Numero;
                txtDataDecreto.Text = decreto.Data;
                txtNumeroBur.Text = decreto.NumeroBur;
                txtDataBur.Text = decreto.DataBur;
                txtRegistro.Text = decreto.Registro;
                lstDefAtto.DataBind();
                lstDefAtto.SelectedValue = decreto.CodDefinizione;
                lstOrgIstituzionale.DataBind();
                lstOrgIstituzionale.SelectedValue = decreto.CodOrganoIstituzionale;
                lstTipoAtto.DataBind();
                lstTipoAtto.SelectedValue = decreto.CodTipo;
                txtDescrizione.Text = decreto.Descrizione;
                trDettaglioDecreto.Visible = true;
            }
        }

        protected void btnCerca_Click(object sender, EventArgs e)
        {
            dgVarianti.CurrentPageIndex = 0;
            ((SiarLibrary.Web.CheckColumn)dgVarianti.Columns[7]).ClearSelected();
            variante_selezionata = null;
            decreto = null;
            hdnDecretoJson.Value = null;
        }

        protected void btnCercaDecreto_Click(object sender, EventArgs e)
        {
            try
            {
                hdnDecretoJson.Value = null;
                decreto = null;
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                int numero;
                int.TryParse(txtNumeroDecreto.Text, out numero);
                DateTime data;
                DateTime.TryParse(txtDataDecreto.Text, out data);
                SiarLibrary.AttiCollection atti_trovati = atti_provider.ImportaAtto(numero, data, "D", lstRegistro.SelectedValue);
                if (atti_trovati.Count > 0)
                {
                    if (atti_trovati.Count > 1)
                    {
                        dgDecreti.DataSource = atti_trovati;
                        dgDecreti.Titolo = "Elementi trovati: " + atti_trovati.Count.ToString();
                        dgDecreti.ItemDataBound += new DataGridItemEventHandler(dgDecreti_ItemDataBound);
                        dgDecreti.DataBind();
                        trElencoDecreti.Visible = true;
                    }
                    else
                    {
                        decreto = atti_trovati[0];
                        hdnDecretoJson.Value = decreto.ConvertToJSonObject();
                        trDettaglioDecreto.Visible = true;
                    }
                }
                else ShowError("Il decreto cercato non è stato trovato.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        void dgDecreti_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.Atti a = (SiarLibrary.Atti)e.Item.DataItem;
                e.Item.Cells[4].Text = "<input type=button class=ButtonGrid style='width:100px' value='Seleziona' onclick=\"selezionaDecreto("
                    + a.ConvertToJSonObject() + ");\" />";
            }
        }

        protected void btnInserisciDecreto_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (variante_selezionata == null) throw new Exception("Nessuna variante selezionata.");
                if (decreto == null) throw new Exception("Il decreto cercato non è stato trovato.");
                if (decreto.IdAtto == null)
                {
                    // se non e' ancora salvato sul db controllo che non sia duplicato
                    SiarLibrary.AttiCollection atti_simili = atti_provider.Find(decreto.Numero, decreto.Data, "D", decreto.Registro);
                    if (atti_simili.Count > 0) decreto = atti_simili[0];
                }
                decreto.CodTipo = lstTipoAtto.SelectedValue;
                atti_provider.Save(decreto);
                variante_selezionata.IdAttoApprovazione = decreto.IdAtto;
                variante_selezionata.AwDocnumber = decreto.AwDocnumber;
                variante_selezionata.CodDefinizione = decreto.CodDefinizione;
                variante_selezionata.AwDocnumberNuovo = decreto.AwDocnumberNuovo; 
                varianti_provider.Save(variante_selezionata);
                ShowMessage("Decreto registrato correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnEliminaDecreto_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (variante_selezionata == null) throw new Exception("Nessuna variante selezionata.");
                if (variante_selezionata.IdAttoApprovazione == null) throw new Exception("La variante selezionata non ha nessun decreto di approvazione.");
                variante_selezionata.IdAttoApprovazione = null;
                varianti_provider.Save(variante_selezionata);
                decreto = null;
                hdnDecretoJson.Value = null;
                ShowMessage("Decreto eliminato correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
        }
    }
}
