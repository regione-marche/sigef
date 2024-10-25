using System;

namespace web.Private.Istruttoria
{
    public partial class GraduatoriaDettaglio : SiarLibrary.Web.IstruttoriaPage
    {
        SiarBLL.GraduatoriaProgettiCollectionProvider graduatoria_provider = new SiarBLL.GraduatoriaProgettiCollectionProvider();
        SiarBLL.ProgettoCollectionProvider progetto_provider = new SiarBLL.ProgettoCollectionProvider();
        SiarLibrary.GraduatoriaProgetti gprogetto;
        SiarLibrary.NullTypes.DecimalNT ImportoRiservaBando, ImportoRiservaUtilizzato, ContributoProgetto;

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "Graduatoria";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int id_progetto;

                if (int.TryParse(Request.QueryString["iddom"], out id_progetto))
                {
                    ucInfoDomanda.Progetto = progetto_provider.GetById(id_progetto);
                }
                if (ucInfoDomanda.Progetto == null || ucInfoDomanda.Progetto.IdBando != Bando.IdBando)
                {
                    throw new Exception("La domanda selezionata non è valida.");
                }
                gprogetto = graduatoria_provider.GetById(Bando.IdBando, id_progetto);
                if (gprogetto == null)
                {
                    throw new Exception("La domanda selezionata non è valida.");
                }

                SiarLibrary.NullTypes.DecimalNT[] importi_bando = graduatoria_provider.CalcoloImportiFondoRiservaBando(Bando.IdBando, gprogetto.IdProgetto);
                
                ImportoRiservaBando      = importi_bando[0]; 
                ImportoRiservaUtilizzato = importi_bando[1]; 
                ContributoProgetto       = importi_bando[2];
                AbilitaModifica          = AbilitaModifica && 
                                           (ucInfoDomanda.Progetto.CodStato == "A" && !ucInfoDomanda.DomandaInRiesame && !ucInfoDomanda.DomandaInRevisione) && 
                                           (Operatore.Utente.CodEnte == "%" || new SiarBLL.BandoResponsabiliCollectionProvider().Find(Bando.IdBando, Operatore.Utente.IdUtente, null, true, true).Count > 0);
            }
            catch (Exception ex) 
            { 
                Redirect("Graduatoria.aspx", ex.Message, true); 
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            btnUtilizzaRiserva.Enabled      = AbilitaModifica && !gprogetto.UtilizzaFondiRiserva;
            btnRevocaRiserva.Enabled        = AbilitaModifica && gprogetto.UtilizzaFondiRiserva;
            txtFondoRiservaTotale.Text      = ImportoRiservaBando;
            txtFondoRiservaUtilizzato.Text  = ImportoRiservaUtilizzato;
            txtFondoRiservaDisponibile.Text = string.Format("{0:N}", ImportoRiservaBando - ImportoRiservaUtilizzato);
            txtContributoTotaleDomanda.Text = ContributoProgetto;
            txtFondoRiservaDomanda.Text     = gprogetto.AmmontareFondiRiservaUtilizzato;
            //per ora non abilitati
            btnAnnullaContributo.Enabled    = false;
            btnConferma.Enabled             = false;
            //

            switch (gprogetto.Finanziabilita)
            {
                case "S":
                    lblFinanziabilita.Text = "FINANZIABILE TOTALMENTE";
                    if (gprogetto.UtilizzaFondiRiserva)
                    {
                        lblFinanziabilita.Text += " CON UTILIZZO DEI FONDI DI RISERVA";
                    }
                    break;
                case "N":
                    lblFinanziabilita.Text = "NON FINANZIABILE";
                    break;
                case "P":
                    lblFinanziabilita.Text = "FINANZIABILE PARZIALMENTE";
                    break;
                case "M":
                    lblFinanziabilita.Text = "FINANZIABILE TOTALMENTE CON CONTRIBUTO RIDOTTO PER SUPERAMENTO DEI MASSIMALI PER BENEFICIARIO NELLA PROGRAMMAZIONE";
                    break;
            }
            dg.DataSource = new SiarBLL.GraduatoriaProgettiFinanziabilitaCollectionProvider().Find(null, null, ucInfoDomanda.Progetto.IdProgetto, null);
            dg.MostraTotale("DataField", 1, 2);
            dg.DataBind();
            base.OnPreRender(e);
        }

        protected void btnUtilizzaRiserva_Click(object sender, EventArgs e)
        {
            try
            {
                decimal fondo_riserva_domanda;
                if (!decimal.TryParse(txtFondoRiservaDomanda.Text, out fondo_riserva_domanda) || fondo_riserva_domanda <= 0)
                {
                    ShowError("Inserire un importo valido da finanziare col fondo di riserva.");
                }
                else
                {
                    decimal fondo_riserva_rimasto = ImportoRiservaBando - ImportoRiservaUtilizzato;
                    if (gprogetto.UtilizzaFondiRiserva)
                    {
                        fondo_riserva_rimasto += gprogetto.AmmontareFondiRiservaUtilizzato;
                    }
                    if (fondo_riserva_domanda > fondo_riserva_rimasto)
                    {
                        throw new Exception("L`importo da finanziare per la domanda non può superare l`ammontare di riserva disponibile.");
                    }
                    // ShowError("Il fondo di riserva del bando non ha la capienza necessaria per finanziare questa domanda di aiuto.");
                    if (fondo_riserva_domanda > ContributoProgetto)
                    {
                        throw new Exception("L`importo da finanziare per la domanda non può superare il contributo totale della domanda.");
                    }
                    gprogetto.UtilizzaFondiRiserva            = true;
                    gprogetto.AmmontareFondiRiservaUtilizzato = fondo_riserva_domanda;
                    graduatoria_provider.Save(gprogetto);
                    //aggiorno interfaccia
                    fondo_riserva_rimasto -= fondo_riserva_domanda;
                    ImportoRiservaUtilizzato = ImportoRiservaBando - fondo_riserva_rimasto;
                    ShowMessage("Salvataggio completato. La domanda di aiuto verrà finanziata con il fondo di riserva del bando.");
                }
            }
            catch (Exception ex) 
            { 
                ShowError(ex); 
            }
        }

        protected void btnRevocaRiserva_Click(object sender, EventArgs e)
        {
            try
            {
                ImportoRiservaUtilizzato -= gprogetto.AmmontareFondiRiservaUtilizzato;
                gprogetto.UtilizzaFondiRiserva = false;
                gprogetto.AmmontareFondiRiservaUtilizzato = 0;
                graduatoria_provider.Save(gprogetto);
                ShowMessage("Salvataggio completato. La domanda di aiuto NON sarà più finanziata con il fondo di riserva del bando.");
            }
            catch (Exception ex) 
            { 
                ShowError(ex); 
            }
        }
        
        protected void btnAnnullaContributo_Click(object sender, EventArgs e) { }
        protected void btnConferma_Click(object sender, EventArgs e) { }
    }
}


