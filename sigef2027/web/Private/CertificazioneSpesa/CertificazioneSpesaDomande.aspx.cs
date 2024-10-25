using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.CertificazioneSpesa
{
    public partial class CertificazioneSpesaDomande : SiarLibrary.Web.CertificazioneSpesaPage
    {
        public SiarLibrary.Progetto Progetto
        {
            get { return (SiarLibrary.Progetto)Session["_progetto"]; }
            set { Session["_progetto"] = value; }
        }

        public SiarLibrary.DomandaDiPagamento DomandaPagamento
        {
            get { return (SiarLibrary.DomandaDiPagamento)Session["domanda_pagamento"]; }
            set { Session["domanda_pagamento"] = value; }
        }

        SiarBLL.UtentiCollectionProvider utenti_provider = new SiarBLL.UtentiCollectionProvider();
        SiarBLL.VisiteAziendaliCollectionProvider visite_provider = new SiarBLL.VisiteAziendaliCollectionProvider();
        SiarBLL.CertspDomandePagamentoCollectionProvider cdomande_provider = new SiarBLL.CertspDomandePagamentoCollectionProvider();
        SiarLibrary.VisiteAziendaliCollection visite_aziendali;
        SiarLibrary.CertspDomandePagamento cdomanda;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int id_domanda_pagamento, id_lotto;
                if (int.TryParse(Request.QueryString["idpag"], out id_domanda_pagamento))
                    DomandaPagamento = new SiarBLL.DomandaDiPagamentoCollectionProvider().GetById(id_domanda_pagamento);
                if (DomandaPagamento == null) throw new Exception("La domanda selezionata non è valida.");
                if (int.TryParse(Request.QueryString["idlotto"], out id_lotto))
                    cdomanda = cdomande_provider.Find(id_lotto, id_domanda_pagamento, null)[0];
                if (cdomanda == null) throw new Exception("La domanda selezionata non è valida.");
                Progetto = new SiarBLL.ProgettoCollectionProvider().GetById(DomandaPagamento.IdProgetto);
                AbilitaModifica = !cdomanda.ControlloConcluso && Operatore.Utente.IdUtente == cdomanda.OperatoreAssegnato;
            }
            catch (Exception ex) { Redirect("LottidiControllo.aspx", ex.Message, true); }
        }

        protected override void OnPreRender(EventArgs e)
        {
            visite_aziendali = visite_provider.Find(null, null, ucIDomandaPagamento.Impresa.IdImpresa, null, null, null);
            dgVisite.Titolo = "Elementi trovati: " + visite_aziendali.Count.ToString();
            dgVisite.DataSource = visite_aziendali;
            dgVisite.ItemDataBound += new DataGridItemEventHandler(dgVisite_ItemDataBound);
            dgVisite.DataBind();

            SiarLibrary.VisiteAziendaliCollection visita = visite_aziendali.FiltroTipo("CIL", DomandaPagamento.IdDomandaPagamento);
            btnAvviaVisita.Enabled = AbilitaModifica && visita.Count == 0;
            if (AbilitaModifica && visita.Count > 0)
            {
                btnChiudiVisita.Enabled = !cdomanda.ControlloConcluso;
                btnStampaVerbale.Disabled = cdomanda.ControlloConcluso;
                btnStampaVerbale.Attributes.Add("onclick", "SNCVisualizzaReport('rptVerbaleControlloInLoco',2,'IdVisita=" + visita[0].IdVisita + "');");
            }
            txtStato.Text = visita.Count == 0 ? "Non avviata" : (cdomanda.ControlloConcluso ? "Conclusa" : "In corso");
            txtSegnatura.Text = visita.Count > 0 ? visita[0].SegnaturaVerbale : null;
            if (cdomanda.OperatoreAssegnato != null)
            {
                SiarLibrary.Utenti operatore = utenti_provider.GetById(cdomanda.OperatoreAssegnato);
                if (operatore != null) txtOperatore.Text = operatore.Nominativo;
            }
            base.OnPreRender(e);
        }

        void dgVisite_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                SiarLibrary.VisiteAziendali v = (SiarLibrary.VisiteAziendali)e.Item.DataItem;
                if (v.ControlloConcluso)
                    e.Item.Cells[7].Text = "<img src='../../images/lente.png' style='width:24px;height:24px;cursor:pointer' alt='Visualizza il verbale' onclick=\"javascript:sncAjaxCallVisualizzaProtocollo('" + v.SegnaturaVerbale + "');\" />";
            }
        }

        protected void btnAvviaVisita_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                SiarLibrary.VisiteAziendali v = new SiarLibrary.VisiteAziendali();
                v.CodTipo = "CIL";
                v.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
                v.IdImpresa = ucIDomandaPagamento.Impresa.IdImpresa;
                v.DataApertura = DateTime.Now;
                v.OperatoreApertura = Operatore.Utente.CfUtente;
                visite_provider.Save(v);
                ShowMessage("Controllo in loco avviato. Ora è possibile stamapare il verbale di visita.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnChiudiVisita_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                SiarLibrary.VisiteAziendaliCollection visite = visite_provider.Find(null, DomandaPagamento.IdDomandaPagamento,
                    ucIDomandaPagamento.Impresa.IdImpresa, "CIL", Progetto.IdProgetto, null);
                if (visite.Count == 0) throw new Exception("Nessuna visita in azienda trovata. Impossibile continuare.");
                if (visite[0].ControlloConcluso) throw new Exception("La visita in azienda selezionata è già stata chiusa.");
                //controllo che il documento sia stato acquisito
                if (!new SiarLibrary.Protocollo().ProtocolloEsistente(txtSegnatura.Text))
                    throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.DocumentoNonValido);

                cdomande_provider.DbProviderObj.BeginTran();
                visite[0].SegnaturaVerbale = txtSegnatura.Text;
                visite[0].ControlloConcluso = true;
                visite[0].DataChiusura = DateTime.Now;
                visite[0].OperatoreChiusura = Operatore.Utente.CfUtente;
                new SiarBLL.VisiteAziendaliCollectionProvider(cdomande_provider.DbProviderObj).Save(visite[0]);

                cdomanda.ControlloConcluso = true;
                cdomanda.DataModifica = DateTime.Now;
                cdomanda.Operatore = Operatore.Utente.IdUtente;
                cdomande_provider.Save(cdomanda);

                //se tutte le domande selezionate a controllo sono chiuse allora chiudo anche il lotto
                if (cdomande_provider.Find(cdomanda.IdLotto, null, null).FiltroControlli(true, false).Count == 0)
                {
                    SiarBLL.CertspLocoLottoCollectionProvider lotto_provider = new SiarBLL.CertspLocoLottoCollectionProvider(
                        cdomande_provider.DbProviderObj);
                    SiarLibrary.CertspLocoLotto lotto = lotto_provider.GetById(cdomanda.IdLotto);
                    if (lotto == null) throw new Exception("Lotto di appartenenza della domanda non trovato");
                    lotto.DataModifica = DateTime.Now;
                    lotto.ControlloConcluso = true;
                    lotto_provider.Save(lotto);
                }
                cdomande_provider.DbProviderObj.Commit();
                ShowMessage("Visita di controllo in loco chiusa correttamente.");
            }
            catch (Exception ex) { cdomande_provider.DbProviderObj.Rollback(); ShowError(ex); }
        }
    }
}
