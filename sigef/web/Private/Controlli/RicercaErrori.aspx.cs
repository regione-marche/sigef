using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SiarLibrary;
using SiarLibrary.Web;
using SiarBLL;
using SiarLibrary.NullTypes;

namespace web.Private.Controlli
{
    public partial class RicercaErrori : ErrorePage
    {
        BandoCollectionProvider bando_provider;
        ProgettoCollectionProvider progetto_provider;
        ImpresaCollectionProvider impresa_provider;
        ErroreCollectionProvider errore_provider;
        ProfiloXFunzioniCollectionProvider funzioni_profilo_provider;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            InizializzaProvider();
            CaricaImmagini();
            CaricaComboBox();

            CaricaErrori();
            ControlloPermessiUtente();

            base.OnPreRender(e);
        }

        private void InizializzaProvider()
        {
            bando_provider = new BandoCollectionProvider();
            progetto_provider = new ProgettoCollectionProvider();
            impresa_provider = new ImpresaCollectionProvider();
            errore_provider = new ErroreCollectionProvider();
            funzioni_profilo_provider = new ProfiloXFunzioniCollectionProvider();
        }

        private void CaricaImmagini()
        {
            imgMostraElencoErrori.Attributes.Add("src", PATH_IMAGES + "ArrowUpSolid.png");
            imgMostraInserisciErrore.Attributes.Add("src", PATH_IMAGES + "ArrowUpSolid.png");

            imgSearchFiltraRicercaErrore.Attributes.Add("src", PATH_IMAGES + "lente24.png");
        }

        private void CaricaComboBox()
        {
            //Combo stato progetto 
            lstRicercaStatoProgetto.Items.Add(new ListItem("", ""));

            //Combo azione  ai fini della certificazione
            lstRicercaAzione.Items.Clear();
            lstRicercaAzione.Items.Add(new ListItem("", ""));
            lstRicercaAzione.Items.Add(new ListItem("Nessuna"));
            lstRicercaAzione.Items.Add(new ListItem("Ritiro"));
            lstRicercaAzione.Items.Add(new ListItem("Recupero"));
            lstRicercaAzione.Items.Add(new ListItem("Recupero pendente"));
        }

        private void CaricaErrori()
        {
            var errori_coll = errore_provider.Find(null, null, null, null, null, null);

            if (errori_coll.Count > 0)
            {
                lblNumErrori.Text = string.Format("Visualizzate {0} righe", errori_coll.Count.ToString());

                dgErrori.DataSource = errori_coll;
                dgErrori.ItemDataBound += new DataGridItemEventHandler(dgErrori_ItemDataBound);
                dgErrori.DataBind();
            }
            else
            {
                lblNumErrori.Text = "Nessun errore trovato";
            }
        }

        private void ControlloPermessiUtente()
        {
            var funzioni_profilo_coll = funzioni_profilo_provider.Find(Operatore.Utente.IdProfilo, null, null, "errori", null, null, null, null);

            if (funzioni_profilo_coll.Count > 0)
            {
                var funzione = funzioni_profilo_coll[0];
                if (funzione.Modifica == null || funzione.Modifica == false)
                    divInserisciErrore.Visible = false;
            }
            else
                Redirect(PATH_PRIVATE + "welcome.aspx", "L'utente non dispone dei permessi necessari per visualizzare questa funzionalità", true);
        }

        #region ButtonClick

        protected void btnInserisciErrore_Click(object sender, EventArgs e)
        {
            InizializzaProvider();

            try
            {
                int id_progetto;
                if (int.TryParse(txtIdProgettoInserisciErrore.Text, out id_progetto))
                {
                    var progetto = progetto_provider.GetById(id_progetto);

                    if (progetto != null)
                    {
                        Progetto = progetto;
                        Errore = null;
                        Redirect(PATH_CONTROLLI + "Errori.aspx");
                    }
                    else
                        throw new Exception("Non esiste una domanda di aiuto con questo identificativo");
                }
                else
                    throw new Exception("Inserire un identificativo di domanda valido");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        protected void btnSelezionaErrore_Click(object sender, EventArgs e)
        {
            try
            {
                int id_errore;
                if (int.TryParse(hdnIdErrore.Value, out id_errore))
                {
                    var errore = new ErroreCollectionProvider().GetById(id_errore);

                    Errore = errore ?? throw new Exception("Errore non esistente");
                    var progetto = new ProgettoCollectionProvider().GetById(errore.IdProgetto);
                    Progetto = progetto ?? throw new Exception("Progetto non esistente");
                    Redirect(PATH_CONTROLLI + "Errori.aspx");
                }
                else
                    throw new Exception("Errore non selezionato");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        #endregion

        #region ItemDataBound

        void dgErrori_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            int col_IdAsse = 0,
                col_IdBando = 1,
                col_DescrizioneBando = 2,
                col_IdProgetto = 3,
                col_StatoProgetto = 4,
                col_IdErrore = 5,
                col_DataRilevazione = 6,
                col_SoggettoRilevazione = 7,
                col_SpesaAmmessaErrore = 8,
                col_ContributoPubblicoErrore = 9,
                col_Certificato = 10,
                col_DaRecuperare = 11,
                col_Recuperato = 12,
                col_Azione = 13,
                col_VaiA = 14;

            DataGridItem dgi = (DataGridItem)e.Item;

            if (dgi.ItemType == ListItemType.Header)
            {
                dgi.CssClass = "TESTA1";
                dgi.Cells[col_IdAsse].ColumnSpan = 3;
                dgi.Cells[col_IdAsse].HorizontalAlign = HorizontalAlign.Center;
                dgi.Cells[col_IdAsse].Text = "BANDO</td><td colspan=2 align=center>DOMANDA AIUTO</td><td colspan=9 align=center>ERRORE</td><td></td></tr><tr class='TESTA'><td>Asse";
            }
            else if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                var err = (Errore)dgi.DataItem;

                var statoProgetto = new ListItem(err.StatoProgetto, err.StatoProgetto);
                if (!lstRicercaStatoProgetto.Items.Contains(statoProgetto))
                    lstRicercaStatoProgetto.Items.Add(statoProgetto);

                if (err.Certificato != null && err.Certificato)
                    dgi.Cells[col_Certificato].Text = dgi.Cells[col_Certificato].Text.Replace("<input", "<input checked");
                else
                    dgi.Cells[col_Certificato].Text = dgi.Cells[col_Certificato].Text.Replace("checked", "");

                if (err.DaRecuperare != null && err.DaRecuperare)
                    dgi.Cells[col_DaRecuperare].Text = dgi.Cells[col_DaRecuperare].Text.Replace("<input", "<input checked");
                else
                    dgi.Cells[col_DaRecuperare].Text = dgi.Cells[col_DaRecuperare].Text.Replace("checked", "");

                if (err.Recuperato != null && err.Recuperato)
                    dgi.Cells[col_Recuperato].Text = dgi.Cells[col_Recuperato].Text.Replace("<input", "<input checked");
                else
                    dgi.Cells[col_Recuperato].Text = dgi.Cells[col_Recuperato].Text.Replace("checked", "");
            }
        }

        #endregion
    }
}