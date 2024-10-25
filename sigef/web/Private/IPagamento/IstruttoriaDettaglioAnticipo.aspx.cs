using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.IPagamento
{
    public partial class IstruttoriaDettaglioAnticipo : SiarLibrary.Web.IstruttoriaPagamentoPage
    {
        SiarLibrary.NotAutogeneratedClasses.AnticipiRichiestiCollection anticipi;
        SiarBLL.AnticipiRichiestiCollectionProvider anticipi_provider;

        protected void Page_Load(object sender, EventArgs e)
        {
            anticipi_provider = new SiarBLL.AnticipiRichiestiCollectionProvider(PagamentoProvider.DbProviderObj);
            anticipi = new SiarLibrary.NotAutogeneratedClasses.AnticipiRichiestiCollectionProvider()
                .CalcoloAmmontareAnticipo(Progetto.IdBando, DomandaPagamento.IdDomandaPagamento);
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (Request.QueryString["redir"] == "revisione") btnBack.Attributes["onclick"] = "location='Revisionedomande.aspx?&idpag="
                + DomandaPagamento.IdDomandaPagamento + "'";
            dgMisure.DataSource = anticipi;
            dgMisure.MostraTotale("Importo", 1, 2, 3, 5);
            dgMisure.ItemDataBound += new DataGridItemEventHandler(dgMisure_ItemDataBound);
            dgMisure.DataBind();
            base.OnPreRender(e);
        }

        void dgMisure_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.NotAutogeneratedClasses.AnticipiRichiesti ant = (SiarLibrary.NotAutogeneratedClasses.AnticipiRichiesti)e.Item.DataItem;
                if (ant.CodTipo == null)
                {
                    e.Item.BackColor = System.Drawing.Color.FromArgb(204, 204, 179);
                    e.Item.Cells[5].Enabled = false; 
                }
                else
                {
                    decimal quota_richiesta = 0, quota_ammessa = 0;
                    if (ant.AmmontareRichiesto != null)
                        if (ant.ContributoDiMisura > 0 && ant.AmmontareRichiesto > 0) quota_richiesta = Math.Round(100 * ant.AmmontareRichiesto / ant.ContributoDiMisura, 2, MidpointRounding.AwayFromZero);
                    if (ant.AmmontareAmmesso != null)
                        if (ant.ContributoDiMisura > 0 && ant.AmmontareAmmesso > 0) quota_ammessa = Math.Round(100 * ant.AmmontareAmmesso / ant.ContributoDiMisura, 2, MidpointRounding.AwayFromZero);
                    e.Item.Cells[4].Text = e.Item.Cells[4].Text.Replace("value=\"\"", "value=\"" + quota_richiesta + "\"");
                    e.Item.Cells[6].Text = e.Item.Cells[6].Text.Replace("value=\"\"", "value=\"" + quota_ammessa + "\"");
                }
            }
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                PagamentoProvider.DbProviderObj.BeginTran();
                string messaggio_esito = null;
                foreach (SiarLibrary.NotAutogeneratedClasses.AnticipiRichiesti ant in anticipi)
                {
                    if (ant.ContributoDiMisura != null)
                    {
                        string ammesso = null;
                        foreach (string s in Request.Form.AllKeys)
                            if (s.EndsWith("txtAmmontareAmmesso" + ant.IdBando + "_text")) { ammesso = Request.Form[s]; break; }

                        decimal ammontare;
                        if (decimal.TryParse(ammesso, out ammontare))
                        {
                            //controllo range valori
                            decimal quota_minima = 0, quota_massima = 0, importo_minimo = 0, importo_massimo = 0, ammontare_richiesto = 0; 
                            decimal.TryParse(ant.ImportoMin, out importo_minimo);
                            decimal.TryParse(ant.ImportoMax, out importo_massimo);
                            decimal.TryParse(ant.AmmontareRichiesto, out ammontare_richiesto);
                            if (ant.QuotaMin != null)
                                decimal.TryParse(Convert.ToString(Math.Round(ant.ContributoDiMisura.Value * ant.QuotaMin.Value / 100, 2, MidpointRounding.AwayFromZero)),
                                    out quota_minima);
                            if (ant.QuotaMax != null)
                                decimal.TryParse(Convert.ToString(Math.Round(ant.ContributoDiMisura.Value * ant.QuotaMax.Value / 100, 2, MidpointRounding.AwayFromZero)),
                                    out quota_massima);
                            if (quota_massima > 0 && importo_massimo > 0) quota_massima = Math.Min(quota_massima, importo_massimo);
                            else quota_massima = Math.Max(quota_massima, importo_massimo);//se una delle 2 =0 allora prendo il massimo tra le due                        
                            quota_minima = Math.Max(quota_minima, importo_minimo);
                            if (quota_minima > quota_massima)
                                throw new Exception("L`ammontare dell`anticipo non rientra nell`intervallo concedibile da bando. Non � possibile richiedere un anticipo.");
                            if (ammontare_richiesto < ammontare)
                                throw new Exception("L`ammontare ammesso dell`anticipo supera l'ammontare richiesto. Non � possibile procedere.");
                            if (ammontare < quota_minima)
                            {
                                ammontare = quota_minima;
                                messaggio_esito = "L`ammontare dell`anticipo non rientra nell`intervallo concedibile da bando, si � proceduto ad un allineamento automatico dei valori richiesti. Salvataggio completato.";
                            }
                            else if (ammontare > quota_massima)
                            {
                                ammontare = quota_massima;
                                messaggio_esito = "L`ammontare dell`anticipo non rientra nell`intervallo concedibile da bando, si � proceduto ad un allineamento automatico dei valori richiesti. Salvataggio completato.";
                            }

                            SiarLibrary.AnticipiRichiesti anticipo = anticipi_provider.Find(null, DomandaPagamento.IdDomandaPagamento, ant.IdBando)[0];
                            anticipo.DataValutazione = DateTime.Now;
                            anticipo.ContributoAmmesso = ammontare;
                            anticipo.Istruttore = Operatore.Utente.CfUtente;
                            anticipo.Ammesso = true;
                            anticipi_provider.Save(anticipo);
                            ant.AmmontareAmmesso = ammontare;
                            ant.Istruttore = Operatore.Utente.Nominativo;
                        }
                    }
                }
                PagamentoProvider.AggiornaDomandaDiPagamentoIstruttore(DomandaPagamento, Operatore);
                PagamentoProvider.DbProviderObj.Commit();
                ShowMessage((messaggio_esito == null ? "Dati salvati correttamente." : messaggio_esito));
            }
            catch (Exception ex) { PagamentoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }
    }
}