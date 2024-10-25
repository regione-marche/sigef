using System;
using System.Data;
using System.Web.UI.WebControls;

namespace web.CONTROLS
{
    public partial class InvestimentoDettaglioMutuoTip2 : System.Web.UI.UserControl
    {
        private SiarLibrary.PianoInvestimenti _investimento, _investimentoOriginale;
        public SiarLibrary.PianoInvestimenti Investimento
        {
            get { return _investimento; }
            set { _investimento = value; }
        }

        public SiarLibrary.PianoInvestimenti InvestimentoOriginale
        {
            get { return _investimentoOriginale; }
            set { _investimentoOriginale = value; }
        }

        private SiarLibrary.Progetto _progetto;
        public SiarLibrary.Progetto Progetto
        {
            get { return _progetto; }
            set { _progetto = value; }
        }

        private string _fase;
        public string Fase { set { _fase = value; } }

        private bool _ricaricaInvestimento;
        public bool RicaricaInvestimento { set { _ricaricaInvestimento = value; } }

        private void ShowMessage(string message)
        {
            ((SiarLibrary.Web.Page)Page).ShowMessage(message);
        }

        private void ShowError(string message)
        {
            ((SiarLibrary.Web.Page)Page).ShowError(message);
        }

        decimal max_quota_contributo, max_importo_contributo;
        SiarLibrary.LocalizzazioneInvestimentoCollection domande_da_selezionare;
        SiarLibrary.LocalizzazioneInvestimento domanda_selezionata;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (_investimento == null) _investimento = new SiarLibrary.PianoInvestimenti();
            if (_investimento.CodTipoInvestimento != null && _investimento.CodTipoInvestimento != 2) throw new Exception("Tipologia di investimento non valida.");
            /*if (_fase == "PVARIANTE" || _fase == "IVARIANTE")
            {
                try { _investimento.IdVariante = ((SiarLibrary.Web.VariantePage)Page).Variante.IdVariante; }
                catch { throw new Exception("Nessuna variante valida trovata per l'investimento."); }
            }*/
            try
            {
                string cuaa = new SiarBLL.ImpresaCollectionProvider().GetById(Progetto.IdImpresa).Cuaa;
                domande_da_selezionare = GetSelezioneDomandeDataSource(cuaa);
                if (domande_da_selezionare.Count == 1) domanda_selezionata = domande_da_selezionare[0];
                else if (!IsPostBack && Investimento.Descrizione != null)
                    ((SiarLibrary.Web.CheckColumn)dgDomandaPsr.Columns[5]).SetSelected(new string[] { Investimento.Descrizione });
                string[] selezionate = ((SiarLibrary.Web.CheckColumn)dgDomandaPsr.Columns[5]).GetSelected();
                if (selezionate.Length > 0 && domanda_selezionata == null)
                {
                    foreach (SiarLibrary.LocalizzazioneInvestimento l in domande_da_selezionare)
                        if (l.IdLocalizzazione == int.Parse(selezionate[0]))
                        {
                            domanda_selezionata = l;
                            domande_da_selezionare = new SiarLibrary.LocalizzazioneInvestimentoCollection();
                            domande_da_selezionare.Add(domanda_selezionata);
                            break;
                        }
                }
                if (domanda_selezionata != null)
                {
                    btnVisualizzaPianoInvestimentiSelezionata.Visible = true;
                    btnVisualizzaPianoInvestimentiSelezionata.Attributes.Add("onclick", "SNCVisualizzaReport('rptQuadroRichiestaMutuo',1,'ID_Domanda="
                        + _progetto.IdProgetto + "');");
                    ((SiarLibrary.Web.CheckColumn)dgDomandaPsr.Columns[5]).SetSelected(new string[] { domanda_selezionata.IdLocalizzazione });
                    SiarLibrary.BandoTipoInvestimenti btipoinvestimento = new SiarBLL.BandoTipoInvestimentiCollectionProvider().
                        Find(Progetto.IdBando, 2, null)[0];
                    max_quota_contributo = btipoinvestimento.QuotaMax;
                    if (max_quota_contributo <= 0) throw new Exception("Massimali di aiuto per il conto interessi non trovati. Impossibile continuare.");
                    max_importo_contributo = (btipoinvestimento.ImportoMax != null ? btipoinvestimento.ImportoMax : 0);
                }
                dgDomandaPsr.DataSource = domande_da_selezionare;
                if (domande_da_selezionare.Count == 0)
                {
                    dgDomandaPsr.Titolo = "<br /><br /><b> Nessuna domanda selezionabile per l`impresa. Impossibile continuare.</b>";
                    btnCalcolaContributo.Enabled = false;
                }
            }
            catch (Exception ex) { ShowError(ex.Message); btnCalcolaContributo.Enabled = false; }
        }

        protected override void OnPreRender(EventArgs e)
        {
            lstAnni.DataBinding += new EventHandler(lstAnni_DataBinding);
            lstAnni.DataBind();
            txtRateAnnuali.Text = "2";
            if (domanda_selezionata != null)
            {
                txtAmmontareInvestimenti.Text = string.Format("{0:c}", domanda_selezionata.Sezione);
                txtTasso.Text = string.Format("{0:N}", (domanda_selezionata.Svantaggio == null ? 45 : 70));
            }
            else
            {
                txtAmmontareInvestimenti.Text = null;
                txtTasso.Text = null;
            }

            if (!IsPostBack || _ricaricaInvestimento)
            {
                txtAmmontare.Text = _investimento.CostoInvestimento;
                txtAttualizzazione.Text = _investimento.QuotaContributoRichiesto;
                txtContributoAmmissibile.Text = _investimento.ContributoRichiesto;
                if (_investimento.TassoAbbuono != null) txtTasso.Text = string.Format("{0:N}", 100 * _investimento.TassoAbbuono);
                lstAnni.SelectedValue = (_investimento.Quantita != null ? Convert.ToInt32(_investimento.Quantita.Value) : 0).ToString();
            }
            dgDomandaPsr.ItemDataBound += new DataGridItemEventHandler(dgDomandaPsr_ItemDataBound);
            dgDomandaPsr.DataBind();

            if (!(_progetto.CodStato == "P" || (_fase == "PVARIANTE" && ((SiarLibrary.Web.PrivatePage)Page).TipoModifica == 2)))
            {
                string scpt_storico_investimento = "alert('Nessun precedente investimento trovato.');";
                if (_investimento.IdInvestimentoOriginale != null)
                    scpt_storico_investimento = "mostraStoricoInvestimento(" + _investimento.IdInvestimentoOriginale + ");";
                btnVisualizzaOriginale.Attributes.Add("onclick", scpt_storico_investimento);
                tableValutazione.Visible = true;
                txtValutazioneLunga.ReadOnly = false;
                txtValutazioneLunga.Text = _investimento.ValutazioneInvestimento;
            }
            base.OnPreRender(e);
        }

        void lstAnni_DataBinding(object sender, EventArgs e)
        {
            lstAnni.Items.Clear();
            lstAnni.Items.Add(new ListItem());
            lstAnni.Items.Add(new ListItem("15", "15"));
            lstAnni.Items.Add(new ListItem("20", "20"));
            foreach (ListItem l in lstAnni.Items)
                if (l.Value == lstAnni.SelectedValue) l.Selected = true;
        }

        void dgDomandaPsr_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                e.Item.Attributes.Add("onclick", "ctrlCheckBox(this);");
                e.Item.Attributes.Add("onmouseover", "selectRow(this,'#fefeee');");
                e.Item.Attributes.Add("onmouseout", "unselectRow(this);");
                SiarLibrary.LocalizzazioneInvestimento l = (SiarLibrary.LocalizzazioneInvestimento)e.Item.DataItem;
                e.Item.Cells[2].Text = SiarLibrary.DbStaticProvider.ConvertToHa(l.SuperficieCatastale);
                e.Item.Cells[4].Text = "% " + string.Format("{0:N}", (l.Svantaggio == null ? 45 : 70));
            }
        }

        protected void btnCalcolaContributo_Click(object sender, EventArgs e)
        {
            try
            {
                CalcolaContributoInvestimento();
                ShowMessage("Contributo ricalcolato.");
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        public void CalcolaContributoInvestimento()
        {
            if (domanda_selezionata == null) throw new Exception("E` necessario selezionare l`ID Siar di riferimento.");
            if (decimal.Parse(txtAmmontare.Text) > decimal.Parse(txtAmmontareInvestimenti.Text))
                throw new Exception("Non è possibile richiedere un mutuo di importo superiore all`ammontare degli investimenti per cui lo si richiede.");
            if (decimal.Parse(txtAttualizzazione.Text) <= 0) throw new Exception("Inserire un tasso di riferimento valido.");

            bool zona_svantaggiata = domanda_selezionata.Svantaggio != null;
            double importo_mutuo, durata_anni, nr_rate_anno, nr_rate, tasso_riferimento;
            double.TryParse(txtAmmontare.Text, out importo_mutuo);
            double.TryParse(lstAnni.SelectedValue, out durata_anni);
            double.TryParse(txtRateAnnuali.Text, out nr_rate_anno);
            double.TryParse(txtAttualizzazione.Text, out tasso_riferimento);

            nr_rate = nr_rate_anno * durata_anni;
            double tasso_abbattimento_regionale = (zona_svantaggiata ? 0.7 : 0.45);
            double tasso_effettivo_annuo_coltivatore = 100 * ceiling(tasso_riferimento * (1 - tasso_abbattimento_regionale) / 100, 0.0005);
            double tasso_rata_nominale_coltivatore = 100 * (Math.Pow((100 + tasso_effettivo_annuo_coltivatore) / 100, 0.5) - 1);
            double tasso_rata_coltivatore = tasso_rata_nominale_coltivatore;
            double tasso_effettivo_annuo = tasso_riferimento;
            double tasso_rata_nominale = 100 * (Math.Pow((100 + tasso_effettivo_annuo) / 100, 0.5) - 1);
            double tasso_rata = tasso_rata_nominale;
            double rata_totale = importo_mutuo * (Math.Pow((100 + tasso_rata) / 100, nr_rate) * tasso_rata) / (100 * (Math.Pow((100 + tasso_rata) / 100, nr_rate) - 1));
            double rata_coltivatore = importo_mutuo * (Math.Pow((tasso_rata_coltivatore + 100) / 100, nr_rate) * tasso_rata_coltivatore) /
                (100 * (Math.Pow((tasso_rata_coltivatore + 100) / 100, nr_rate) - 1));
            double presumibile_contributo_regionale = Math.Round(rata_totale - rata_coltivatore, 2, MidpointRounding.AwayFromZero);
            double tasso_effettivo_attualizzazione = tasso_riferimento - 1.18;
            double tasso_rata_nominale_attualizzazione = 100 * (Math.Pow((100 + tasso_effettivo_attualizzazione) / 100, 0.5) - 1);
            /*double contributo_regionale_attualizzato_erogazione = presumibile_contributo_regionale *
                100 * (Math.Pow((100 + tasso_rata_nominale_attualizzazione) / 100, nr_rate) - 1) /
                (tasso_rata_nominale_attualizzazione * (Math.Pow((100 + tasso_rata_nominale_attualizzazione) / 100, nr_rate)));*/
            double contributo_regionale_attualizzato_prima_rata = presumibile_contributo_regionale *
                100 * (Math.Pow((100 + tasso_rata_nominale_attualizzazione) / 100, nr_rate) - 1) /
                (tasso_rata_nominale_attualizzazione * (Math.Pow((100 + tasso_rata_nominale_attualizzazione) / 100, (nr_rate - 1))));

            decimal contributo = Convert.ToDecimal(Math.Round(contributo_regionale_attualizzato_prima_rata, 2, MidpointRounding.AwayFromZero));

            rowContributoMessaggio.InnerHtml = "";
            if (max_importo_contributo > 0 && contributo > max_importo_contributo)
            {
                rowContributoMessaggio.InnerHtml = "<br />Attenzione! <br /><br />Il contributo calcolato supera il massimo di " +
                    string.Format("{0:c}", max_importo_contributo) + "<br />ammissibile da bando. E` necessario ridurre l`ammontare del mutuo.<br />";
                throw new Exception("Il contributo calcolato supera il massimo di " + string.Format("{0:c}", max_importo_contributo) +
                    " ammissibile da bando. E` necessario ridurre l`ammontare del mutuo.");
            }

            // per ora lascio cosi' ma devo vedere meglio
            if (_fase == "IDOMANDA" && _investimentoOriginale.ContributoRichiesto < contributo)
            {
                rowContributoMessaggio.InnerHtml = "<br />Attenzione! <br /><br />Il contributo calcolato ammonta a € " + string.Format("{0:c}", contributo)
                    + "<br />superando l`ammontare richesto dal beneficiario. E` stato troncato.<br /><br />";
                contributo = _investimentoOriginale.ContributoRichiesto;
            }
            /*
            if (_fase == "PVARIANTE" || _fase == "IVARIANTE")
            {
                if (new SiarBLL.VariantiCollectionProvider().GetById(_investimento.IdVariante).CodTipo != "AR")
                {
                    decimal contributo_rimanente = new SiarBLL.PianoInvestimentiCollectionProvider().GetContributoRimanenteMisura(progetto_correlato.IdProgetto,
                        _investimento.IdVariante, _investimento.IdInvestimento);
                    if (contributo_rimanente < contributo)
                    {
                        rowContributoMessaggio.InnerHtml = "<br />Attenzione! <br /><br />Il contributo calcolato ammonta a € " + string.Format("{0:c}", contributo)
                            + "<br />superando il massimo ammesso a finanziamento. E` stato troncato.<br /><br />";
                        contributo = contributo_rimanente;
                    }
                }
            }*/

            _investimento.IdProgetto = Progetto.IdProgetto;
            // cerco id programmazione            
            throw new Exception("da implementare");
            //SiarLibrary.ProgrammazioneBandoCollection pbando = new SiarBLL.ProgrammazioneBandoCollectionProvider().Find(Progetto.IdBando, null);
            //if (pbando.Count == 0) throw new Exception("Il bando non prevede investimenti di questo tipo. Impossibile continuare.");
            //_investimento.IdProgrammazione = pbando[0].IdProgrammazione;
            //_investimento.CodTipoInvestimento = 2;
            //_investimento.Descrizione = domanda_selezionata.IdLocalizzazione.ToString();
            //_investimento.Quantita = lstAnni.SelectedValue;
            //_investimento.TassoAbbuono = tasso_abbattimento_regionale;
            //_investimento.ValutazioneInvestimento = txtValutazioneLunga.Text;
            //_investimento.CostoInvestimento = txtAmmontare.Text;
            //_investimento.SpeseGenerali = txtAmmontareInvestimenti.Text;
            //_investimento.QuotaContributoRichiesto = txtAttualizzazione.Text;
            //_investimento.Quantita = lstAnni.SelectedValue;
            //_investimento.ContributoRichiesto = Math.Round(contributo, 2, MidpointRounding.AwayFromZero);

            //txtContributoAmmissibile.Text = _investimento.ContributoRichiesto;
        }

        private double ceiling(double numero, double pattern)
        {
            int nr_volte = (int)Math.Truncate(numero / pattern);
            double result = pattern * nr_volte;
            if (numero > result) result = pattern * (nr_volte + 1);
            return result;
        }

        protected void btnPostBack_Click(object sender, EventArgs e)
        {
            // attivato sul click delle checkbox per gli obiettivi e interventi
        }

        private SiarLibrary.LocalizzazioneInvestimentoCollection GetSelezioneDomandeDataSource(string cuaa)
        {
            SiarLibrary.LocalizzazioneInvestimentoCollection domande = new SiarLibrary.LocalizzazioneInvestimentoCollection();
            SiarLibrary.DbProvider db = new SiarLibrary.DbProvider();
            //db.ConnectionString = "packet size=4096;user id=agrinet_sa;data source=hikkaru64;persist security info=True;initial catalog=SIAR;password=ag7_mke0LI";
            IDbCommand cmd = db.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpSelezionaIdDomandaSiarBandoSeverini";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CUAA", cuaa));
            db.InitDatareader(cmd);
            while (db.DataReader.Read())
            {
                //i campi sono sballati, uso la struttura localizzazzione investimento per non crearne altre di nuove
                SiarLibrary.LocalizzazioneInvestimento l = new SiarLibrary.LocalizzazioneInvestimento();
                l.Particella = new SiarLibrary.NullTypes.StringNT(db.DataReader["ID"]);
                l.FoglioCatastale = new SiarLibrary.NullTypes.StringNT(db.DataReader["MISURA"]);
                l.IdLocalizzazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO_CORRELATO"]);
                l.IdCatasto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
                l.SuperficieCatastale = new SiarLibrary.NullTypes.IntNT(db.DataReader["SUPERFICIE_CATASTALE"]);
                l.Svantaggio = new SiarLibrary.NullTypes.StringNT(db.DataReader["SVANTAGGIO"]);
                l.Sezione = new SiarLibrary.NullTypes.StringNT(db.DataReader["COSTO_TOTALE_PROGETTO"]);
                domande.Add(l);
            }
            db.Close();
            return domande;
        }
    }
}