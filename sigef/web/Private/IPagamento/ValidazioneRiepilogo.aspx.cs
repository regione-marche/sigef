using System;
using System.Web.UI.WebControls;

namespace web.Private.IPagamento
{
    public partial class ValidazioneRiepilogo : SiarLibrary.Web.IstruttoriaPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "selezione_domande_rendicontazione";
            base.OnPreInit(e);
        }

        SiarBLL.BandoValidatoriCollectionProvider validatori_provider = new SiarBLL.BandoValidatoriCollectionProvider();

        protected void Page_Load(object sender, EventArgs e)
        {
            AbilitaModifica = AbilitaModifica && new SiarBLL.BandoResponsabiliCollectionProvider().Find(Bando.IdBando, Operatore.Utente.IdUtente,
                null, true, true).Count > 0;
        }

        protected override void OnPreRender(EventArgs e)
        {
            SiarLibrary.NullTypes.IntNT nr_pag_pervenute = 0, nr_pag_istruite = 0, nr_pag_validate = 0,
                nr_lotti = 0, nr_lotti_campionati = 0, nr_lotti_conclusi = 0;
            new SiarBLL.LottoDiRevisioneCollectionProvider().GetRevisioneRiepilogo(Bando.IdBando, ref nr_pag_pervenute, ref nr_pag_istruite,
                 ref nr_pag_validate, ref nr_lotti, ref nr_lotti_campionati, ref nr_lotti_conclusi);
            txtNrPagPervenute.Text = nr_pag_pervenute;
            txtNrPagIstruite.Text = nr_pag_istruite;
            txtNrPagValidate.Text = nr_pag_validate;
            txtNrLottiTotali.Text = nr_lotti;
            txtNrLottiEstratti.Text = nr_lotti_campionati;
            txtNrLottiConclusi.Text = nr_lotti_conclusi;

            txtValidatore.AddJSAttribute("onkeydown", "SNCVolatileZoom(this,event,'SNCVZCercaUtenti');");
            SiarLibrary.BandoValidatoriCollection operatori = validatori_provider.Find(Bando.IdBando, null, null, null);
            dgOperatoriValidazione.DataSource = operatori;
            dgOperatoriValidazione.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgOperatoriValidazione_ItemDataBound);
            dgOperatoriValidazione.SetTitoloNrElementi();
            dgOperatoriValidazione.DataBind();
            base.OnPreRender(e);
        }

        void dgOperatoriValidazione_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.BandoValidatori v = (SiarLibrary.BandoValidatori)e.Item.DataItem;
                if (v.Attivo && AbilitaModifica)
                    e.Item.Cells[4].Text = "<input type=button class=ButtonGrid value=Disabilita style='width:120px' onclick='disabilitaValidatore(" + v.Id + ");' />";
                if (!v.Attivo) e.Item.Cells[4].Text = "Disabilitato";
            }
        }

        protected void btnSalvaValidatore_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                int id_utente;
                if (!int.TryParse(hdnIdUtenteSelezionato.Value, out id_utente)) throw new Exception("Per continuare si richiede di specificare un operatore.");
                SiarLibrary.Utenti u = new SiarBLL.UtentiCollectionProvider().GetById(id_utente);
                if (u == null || !u.Attivo) throw new Exception("L`operatore selezionato non è valido.");
                if (validatori_provider.Find(Bando.IdBando, id_utente, null, true).Count > 0) throw new Exception("L`operatore selezionato è già stato nominato.");
                SiarLibrary.BandoValidatori v = new SiarLibrary.BandoValidatori();
                v.IdBando = Bando.IdBando;
                v.IdUtente = id_utente;
                v.Responsabile = chkResponsabile.Checked;
                v.Attivo = true;
                v.DataInizio = DateTime.Now;
                v.OperatoreInizio = Operatore.Utente.IdUtente;
                validatori_provider.Save(v);
                ShowMessage("Operatore di validazione nominato correttamente.");
                txtValidatore.Text = hdnIdUtenteSelezionato.Value = "";
                chkResponsabile.Checked = false;
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnDisabilitaValidatore_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                int id_validatore;
                if (!int.TryParse(hdnIdValidatore.Value, out id_validatore)) throw new Exception("Per continuare si richiede di specificare un operatore.");
                SiarLibrary.BandoValidatori v = validatori_provider.GetById(id_validatore);
                if (v == null || !v.Attivo) throw new Exception("L`operatore selezionato non è valido.");
                v.Attivo = false;
                v.DataFine = DateTime.Now;
                v.OperatoreFine = Operatore.Utente.IdUtente;
                validatori_provider.Save(v);
                ShowMessage("Operatore di validazione disabilitato correttamente.");
                hdnIdValidatore.Value = "";
            }
            catch (Exception ex) { ShowError(ex); }
        }
    }
}
