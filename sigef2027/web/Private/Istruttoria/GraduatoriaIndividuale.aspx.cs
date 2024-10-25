using System;
using System.Web.UI.WebControls;
using SiarBLL;
using SiarLibrary.Extensions;

namespace web.Private.Istruttoria
{
    public partial class GraduatoriaIndividuale : SiarLibrary.Web.IstruttoriaPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "Graduatoria";
            base.OnPreInit(e);
        }

        SiarLibrary.GraduatoriaProgettiCollection graduatoria;
        SiarBLL.GraduatoriaProgettiCollectionProvider graduatoria_provider = new SiarBLL.GraduatoriaProgettiCollectionProvider();
        SiarBLL.GraduatoriaProgettiAttiCollectionProvider graduatoria_atti_provider = new SiarBLL.GraduatoriaProgettiAttiCollectionProvider();
        SiarBLL.AttiCollectionProvider atti_provider = new SiarBLL.AttiCollectionProvider();
        bool show_div_decreto = false;
        SiarLibrary.Atti decreto_selezionato = null;
        bool Organismi_intermedi = false;
        bool responsabile;

        protected void Page_Load(object sender, EventArgs e)
        {
            AbilitaModifica = AbilitaModifica && Bando.OrdineStato < 5 && new SiarBLL.BandoResponsabiliCollectionProvider()
                .Find(Bando.IdBando, Operatore.Utente.IdUtente, null, true, true).Count > 0;
            string Str_Organismi_intermedi = "";
            Str_Organismi_intermedi = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_OrganismiIntermedi(Bando.IdBando);
            if (Str_Organismi_intermedi == "True")
                Organismi_intermedi = true;

            //Se il bando è   
            // - almeno pubblicato 
            // - se sono il rup o amministratore  
            //posso modificare la graduatoria con decreto 
            responsabile = new BandoResponsabiliCollectionProvider().Find(Bando.IdBando, Operatore.Utente.IdUtente, null, true, true).Count > 0;
            if (!(Bando.OrdineStato >= 2
                && (Operatore.Utente.Profilo == "Amministratore"
                    || responsabile)))
                dgProgetti.Columns[12].Visible = false;
        }

        protected override void OnPreRender(EventArgs e)
        {
            graduatoria = graduatoria_provider.GetListaProgettiInGraduatoria(Bando.IdBando);
            dgProgetti.DataSource = graduatoria;
            dgProgetti.ItemDataBound += new DataGridItemEventHandler(dgProgetti_ItemDataBound);
            dgProgetti.DataBind();


            // calcolo il budget rimasto del bando
            decimal budget_bando = Bando.Importo;
            SiarLibrary.GraduatoriaProgettiCollection graduatoria_bando = graduatoria_provider.GetListaProgettiInGraduatoria(Bando.IdBando);
            foreach (SiarLibrary.GraduatoriaProgetti gp in graduatoria_bando)
            {
                // la collection e' ordinata per ordine quindi sottraggo con l'ordinamento di default

                ////Controllo se il progetto ha uno stato successivo negativo, in tal caso non sottraggo al totale!
                //SiarLibrary.Progetto p = new SiarBLL.ProgettoCollectionProvider().GetById(gp.IdProgetto);
                //if(p.OrdineStato != 2 )
                //{
                if ((gp.Finanziabilita == "S" && gp.ContributoTotale != null) || (gp.Finanziabilita == "P" && gp.ContributoTotale != null)) budget_bando -= gp.ContributoTotale;
                if (budget_bando <= 0) budget_bando = 0;
                //}
            }
            lbRimanenzaGrad.Value = string.Format("{0:c}", budget_bando);

            btnEstraiXls.Attributes.Add("onclick", "SNCVisualizzaReport('rptGraduatoriaIndividuale',2,'IdBando=" + Bando.IdBando + "')");

            if (show_div_decreto)
            {
                lstAttoDefinizione.DataBind();
                lstAttoRegistro.DataBind();
                lstAttoOrgIstituzionale.DataBind();
                lstAttoTipo.DataBind();
                if (!Organismi_intermedi)
                {
                    if (decreto_selezionato != null)
                    {
                        hdnIdAtto.Value = decreto_selezionato.IdAtto;
                        txtAttoDescrizione.Text = decreto_selezionato.Descrizione;
                        lstAttoOrgIstituzionale.SelectedValue = decreto_selezionato.CodOrganoIstituzionale;
                        if (!string.IsNullOrEmpty(decreto_selezionato.CodTipo))
                        {
                            lstAttoTipo.SelectedValue = decreto_selezionato.CodTipo;
                            lstAttoTipo.Enabled = false;
                        }
                        txtAttoBurNumero.Text = decreto_selezionato.NumeroBur;
                        txtAttoBurData.Text = decreto_selezionato.DataBur;
                    }
                    else hdnIdAtto.Value = null;

                    RegisterClientScriptBlock("mostraPopupTemplate('divDecreto','divBKGMessaggio');");
                }
                else
                {
                    RegisterClientScriptBlock("mostraPopupTemplate('divDecretoOrgInt','divBKGMessaggio');");
                }
            }
            else
            {
                pulisciCampiDecreto();
                ((SiarLibrary.Web.CheckColumnAgid)dgProgetti.Columns[11]).ClearSelected();
            }

            base.OnPreRender(e);
        }

        private void pulisciCampiDecreto()
        {
            txtAttoData.Text = "";
            txtAttoNumero.Text = "";
            lstAttoRegistro.ClearSelection();
            lstAttoTipo.ClearSelection();
            lstAttoOrgIstituzionale.ClearSelection();
            txtAttoDescrizione.Text = "";
            txtAttoBurData.Text = "";
            txtAttoBurNumero.Text = "";
            txtAttoDataXComunicazione.Text = "";
            hdnIdAtto.Value = "";
        }

        decimal tot_spesa = 0, tot_contributo = 0, tot_concesso = 0, tot_riserva = 0;
        void dgProgetti_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.GraduatoriaProgetti gp = (SiarLibrary.GraduatoriaProgetti)e.Item.DataItem;
                e.Item.Cells[1].Style.Add("cursor", "pointer");
                e.Item.Cells[1].CssClass = "clickable";
                e.Item.Cells[1].Attributes.Add("onclick", "dettaglioDomanda(" + gp.IdProgetto + ",this)");
                //dgi.Cells[3].Text = "<a href=\"javascript:" + ucSiarNewZoomPunteggio.GetOpenZoomJsFunction(graduatoria_progetto.IdProgetto) + "\"><img src='../../images/domande.ico' alt='Visualizza dettaglio di priorita' /></a>";
                //e.Item.Cells[8].Text = "<a href='GraduatoriaDettaglio.aspx?iddom=" + gp.IdProgetto
                //    + "'><img src='../../images/euro.gif' alt='Visualizza dettaglio di finanziabilita' /></a>";
                //switch (gp.Finanziabilita)
                //{
                //    case "P":
                //        e.Item.BackColor = System.Drawing.Color.FromArgb(206, 179, 170);
                //        break;
                //    case "N":
                //        e.Item.BackColor = System.Drawing.Color.FromArgb(204, 204, 179);
                //        break;
                //    case "M":
                //        e.Item.Cells[5].Text = "<b>(**)</b>&nbsp;&nbsp;" + e.Item.Cells[5].Text;
                //        break;
                //}
                int id_atto;
                if (int.TryParse(gp.AdditionalAttributes["ID_ATTO"], out id_atto))
                {
                    //verifico se ci sono piu decreti collegati al progetto
                    SiarLibrary.GraduatoriaProgettiAttiCollection atti_coll = graduatoria_atti_provider.Find(gp.IdBando, gp.IdProgetto, null, null);
                    if (atti_coll.Count > 1)
                    {
                        e.Item.Cells[8].Text = "<table>";
                        foreach (SiarLibrary.GraduatoriaProgettiAtti gpa in atti_coll)
                        {
                            SiarLibrary.Atti atto = atti_provider.GetById(gpa.IdAtto);
                            e.Item.Cells[8].Text += "<tr><td>";
                            if (!Organismi_intermedi)
                            {
                                e.Item.Cells[8].Text += "<input type=button class='btn btn-secondary py-1' value='" + atto.Numero.ToString() + "|"
                                    + atto.Data.ToString() + "|" + atto.Registro + "' onclick=\"visualizzaAtto(" + atto.IdAtto + ");\" />";
                            }
                            else
                            {
                                e.Item.Cells[8].Text += "<input type=button class='btn btn-secondary py-1' style=' value='" + atto.Numero.ToString() + "|"
                                    + atto.Data.ToString() + "' onclick=\"window.open('" + atto.LinkEsterno + "');\" />";
                            }
                            e.Item.Cells[8].Text += "</td><td>";
                            e.Item.Cells[8].Text += string.Format("{0:c}", gpa.Importo);
                            e.Item.Cells[8].Text += "</td></tr>";
                        }
                        e.Item.Cells[8].Text += "</table>";
                        e.Item.Cells[9].Text = "<a href='GraduatoriaIndividualeAtti.aspx?iddom=" + gp.IdProgetto + "'><img src='../../images/ifAdd24.png'/></a>";
                    }
                    else
                    {
                        if (atti_coll.Count == 1)
                        {
                            SiarLibrary.Atti atto = atti_provider.GetById(atti_coll[0].IdAtto);
                            // verifico se l'importo è gia stato modificato e lo faccio visualizzare
                            if (atti_coll[0].Importo < gp.ContributoTotale)
                            {
                                e.Item.Cells[8].Text = "<table><tr><td>";
                                if (!Organismi_intermedi)
                                    e.Item.Cells[8].Text += "<input type=button class='btn btn-secondary py-1' value='" + gp.AdditionalAttributes["NUMERO"] + "|"
                                    + new SiarLibrary.NullTypes.DatetimeNT(gp.AdditionalAttributes["DATA"]) + "|" + gp.AdditionalAttributes["REGISTRO"] + "' onclick=\"visualizzaAtto(" + id_atto + ");\" />";
                                else
                                    e.Item.Cells[8].Text += "<input type=button class=ButtonGrid style='width:130px' value='" + atto.Numero.ToString() + "|"
                                    + atto.Data.ToString() + "' onclick=\"window.open('" + atto.LinkEsterno + "');\" />";
                                e.Item.Cells[8].Text += "</td><td>";
                                e.Item.Cells[8].Text += string.Format("{0:c}", atti_coll[0].Importo);
                                e.Item.Cells[8].Text += "</td></tr></table>";

                            }
                            else
                            {
                                if (!Organismi_intermedi)
                                    e.Item.Cells[8].Text = "<input type=button class='btn btn-secondary py-1' value='" + gp.AdditionalAttributes["NUMERO"] + "|"
                                        + new SiarLibrary.NullTypes.DatetimeNT(gp.AdditionalAttributes["DATA"]) + "|" + gp.AdditionalAttributes["REGISTRO"] + "' onclick=\"visualizzaAtto(" + id_atto + ");\" />";
                                else
                                    e.Item.Cells[8].Text += "<input type=button class='btn btn-secondary py-1' value='" + atto.Numero.ToString() + "|"
                                     + atto.Data.ToString() + "' onclick=\"window.open('" + atto.LinkEsterno + "');\" />";
                            }
                            e.Item.Cells[9].Text = "<a href='GraduatoriaIndividualeAtti.aspx?iddom=" + gp.IdProgetto + "'><img src='../../images/ifAdd24.png'/></a>";
                        }
                        else
                        {
                            e.Item.Cells[9].Text = "";
                            //e.Item.Cells[10].Text = "";
                        }
                    }
                    //"<span style='text-decoration:underline;cursor:pointer' onclick=\"visualizzaAtto(" + id_atto + ");\">" + gp.AdditionalAttributes["NUMERO"] + "|"
                    //+ new SiarLibrary.NullTypes.DatetimeNT(gp.AdditionalAttributes["DATA"]) + "|" + gp.AdditionalAttributes["REGISTRO"] + "</span>";

                }


                SiarLibrary.Progetto prog = new SiarBLL.ProgettoCollectionProvider().GetById(gp.IdProgetto);
                if (prog.CodStato != "A")
                    //{
                    //    e.Item.Cells[9].Text = "";
                    e.Item.Cells[10].Text = "";
                //}

                e.Item.Cells[7].Text = gp.Finanziabilita == null ? "" : gp.Finanziabilita == "S" ? "Finanziabile" : "Non Finanziabile";
                e.Item.Cells[5].Text = gp.Finanziabilita == null ? "" : string.Format("{0:c}", gp.Finanziabilita == "S" ? gp.ContributoTotale : 0);
                // blocco la selezione della domanda se gia' resa finanziabile e se non e' stato calcolato l'ordine e gli importi
                if (prog.OrdineFase > 3 || gp.Ordine == null) e.Item.Cells[11].Text = "";
                // calcolo i totali
                if (gp.CostoTotale != null) tot_spesa += gp.CostoTotale;
                if (gp.ContributoTotale != null) tot_contributo += gp.ContributoTotale;
                if (gp.ContributoTotale != null && gp.Finanziabilita == "S") tot_concesso += gp.ContributoTotale;
                if (gp.Finanziabilita == "S" && gp.UtilizzaFondiRiserva && gp.AmmontareFondiRiservaUtilizzato != null)
                    tot_riserva += gp.AmmontareFondiRiservaUtilizzato;
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells[3].Text = string.Format("{0:c}", tot_spesa);
                e.Item.Cells[4].Text = string.Format("{0:c}", tot_contributo);
                e.Item.Cells[5].Text = string.Format("{0:c}", tot_concesso);
                e.Item.Cells[6].Text = string.Format("{0:c}", tot_riserva);
            }
        }

        protected void btnOrdina_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                int nr_dom = graduatoria_provider.OrdinamentoGraduatoriaIndividuale(Bando.IdBando, Operatore.Utente.CfUtente);
                ShowMessage("Nr. " + nr_dom + " domande aggiornate.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnEstraiXls_Click(object sender, EventArgs e)
        {

        }

        protected void btnDecreto_Click(object sender, EventArgs e)
        {
            try
            {
                string[] domande_selezionate = ((SiarLibrary.Web.CheckColumnAgid)dgProgetti.Columns[11]).GetSelected();
                if (domande_selezionate.Length == 0) throw new Exception("Per proseguire è necessario selezionare almeno una domanda.");
                show_div_decreto = true;
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnCercaDecreto_Click(object sender, EventArgs e)
        {
            try
            {
                show_div_decreto = true;
                int numero;
                int.TryParse(txtAttoNumero.Text, out numero);
                DateTime data;
                DateTime.TryParse(txtAttoData.Text, out data);
                string registro = lstAttoRegistro.SelectedValue;
                if (!string.IsNullOrEmpty(lstAttoRegistro.SelectedValue) && lstAttoRegistro.SelectedValue.IndexOf("|") > 0)
                    registro = lstAttoRegistro.SelectedValue.Substring(0, lstAttoRegistro.SelectedValue.IndexOf("|"));
                // controllo che l'atto sia registrato su db, altrimenti lo importo
                SiarLibrary.AttiCollection atti_trovati = atti_provider.Find(numero, data, lstAttoDefinizione.SelectedValue, registro);
                if (atti_trovati.Count == 0)
                {
                    atti_trovati = atti_provider.ImportaAtto(numero, data, lstAttoDefinizione.SelectedValue, lstAttoRegistro.SelectedValue);
                    if (atti_trovati.Count > 0) atti_provider.Save(atti_trovati[0]);
                }
                if (atti_trovati.Count > 0) decreto_selezionato = atti_trovati[0];
                else ShowMessage("La ricerca non ha prodotto nessun risultato.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnFinanziabilita_Click(object sender, EventArgs e)
        {
            SetFinanziabilita(true);
        }

        protected void btnNonFinanziabilita_Click(object sender, EventArgs e)
        {
            SetFinanziabilita(false);
        }

        protected void btnAggiornaRimanente_Click(object sender, EventArgs e)
        {
            try
            {
                decimal budget_bando = Bando.Importo;
                SiarLibrary.GraduatoriaProgettiCollection graduatoria_bando = graduatoria_provider.GetListaProgettiInGraduatoria(Bando.IdBando);
                graduatoria_provider.DbProviderObj.BeginTran();

                int aggiornati = 0;

                foreach (SiarLibrary.GraduatoriaProgetti gp in graduatoria_bando)
                {
                    // la collection e' ordinata per ordine quindi sottraggo con l'ordinamento di default
                    if (gp.ContributoTotale != null)
                        budget_bando -= gp.ContributoTotale;
                    if (budget_bando <= 0)
                    {
                        budget_bando = 0;
                        //break; 
                    }

                    if (gp.ContributoRimanente != budget_bando)
                    {
                        gp.ContributoRimanente = budget_bando;
                        graduatoria_provider.Save(gp);
                        aggiornati++;
                    }
                }

                //throw new Exception("Aggiornerei " + aggiornati + " progetti");
                graduatoria_provider.DbProviderObj.Commit();
                ShowMessage("Aggiornati " + aggiornati + " progetti");
            }
            catch (Exception ex)
            {
                graduatoria_provider.DbProviderObj.Rollback();
                ShowError(ex.Message);
            }
        }

        private void SetFinanziabilita(bool finanziabili)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                string[] domande_selezionate = ((SiarLibrary.Web.CheckColumnAgid)dgProgetti.Columns[11]).GetSelected();
                if (domande_selezionate.Length == 0) throw new Exception("Per proseguire è necessario selezionare almeno una domanda.");

                SiarLibrary.Atti a = new SiarLibrary.Atti();
                if (!Organismi_intermedi)
                {
                    int id_atto;
                    if (!int.TryParse(hdnIdAtto.Value, out id_atto)) throw new Exception("Per proseguire è necessario specificare un atto.");

                    if (string.IsNullOrEmpty(lstAttoTipo.SelectedValue)) throw new Exception("Per proseguire è necessario specificare la tipologia dell'atto.");
                    a = atti_provider.GetById(id_atto);
                    if (a == null) throw new Exception("L'atto selezionato non è valido.");
                    if (a.CodTipo == null)
                    {
                        a.CodTipo = lstAttoTipo.SelectedValue;
                        atti_provider.Save(a);
                    }
                }
                else
                {
                    a.CodTipo = "A";
                    a.CodDefinizione = "D";
                    a.CodOrganoIstituzionale = "OI";
                    a.Numero = new SiarLibrary.NullTypes.IntNT(txtNumeroDecretoOrg.Text);
                    a.Data = txtDataDecretoOrg.Text;
                    a.Descrizione = txtDescrizioneDecretoOrg.Text;
                    a.LinkEsterno = txtLinkEst.Text;
                    atti_provider.Save(a);
                }

                // calcolo il budget rimasto del bando
                decimal budget_bando = Bando.Importo;
                SiarLibrary.GraduatoriaProgettiCollection graduatoria_bando = graduatoria_provider.GetListaProgettiInGraduatoria(Bando.IdBando);
                foreach (SiarLibrary.GraduatoriaProgetti gp in graduatoria_bando)
                {
                    // la collection e' ordinata per ordine quindi sottraggo con l'ordinamento di default
                    if (gp.Finanziabilita == "S" && gp.ContributoTotale != null) budget_bando -= gp.ContributoTotale;
                    if (budget_bando <= 0) { budget_bando = 0; break; }
                }



                SiarBLL.ProgettoCollectionProvider progetto_provider = new SiarBLL.ProgettoCollectionProvider(graduatoria_provider.DbProviderObj);
                graduatoria_provider.DbProviderObj.BeginTran();
                graduatoria_atti_provider.DbProviderObj.BeginTran();
                foreach (string s in domande_selezionate)
                {
                    SiarLibrary.GraduatoriaProgetti gp = graduatoria_bando.CollectionGetById(Bando.IdBando, s);
                    SiarLibrary.Progetto prog_principale = progetto_provider.GetById(s);
                    if (gp == null || prog_principale == null || prog_principale.OrdineFase > 3)
                        throw new Exception("E' stata selezionata una domanda non valida: id " + s + ", operazione annullata.");
                    if (prog_principale.CodStato != "A")
                        throw new Exception("E' stata selezionata una domanda che non ha la fase di ammissibilità positiva chiusa.");

                    if (finanziabili)
                    {
                        if (budget_bando <= 0) throw new Exception("Il budget del bando e' esaurito, non è possibile finanziare le domande selezionate.");
                        if (budget_bando < gp.ContributoTotale) gp.ContributoTotale = budget_bando;
                        budget_bando -= gp.ContributoTotale;

                        //salvo in graduatoria_progetti_atti
                        SiarLibrary.GraduatoriaProgettiAtti grad_atto = new SiarLibrary.GraduatoriaProgettiAtti();
                        grad_atto.IdBando = Bando.IdBando;
                        grad_atto.IdProgetto = gp.IdProgetto;
                        grad_atto.IdAtto = a.IdAtto;
                        grad_atto.Importo = gp.ContributoTotale;
                        grad_atto.FinanziabilitaTotale = true;
                        grad_atto.DataCreazione = DateTime.Today;
                        grad_atto.OperatoreCreazione = Operatore.Utente.IdUtente;
                        grad_atto.DataAggiornamento = DateTime.Today;
                        grad_atto.OperatoreAggiornamento = Operatore.Utente.IdUtente;
                        graduatoria_atti_provider.Save(grad_atto);
                    }

                    gp.Finanziabilita = finanziabili ? "S" : "N";
                    gp.ContributoRimanente = budget_bando;
                    graduatoria_provider.Save(gp);



                    progetto_provider.CambioStatoProgetto(prog_principale, "G", a.IdAtto, Operatore);
                    progetto_provider.CambioStatoProgetto(prog_principale, finanziabili ? "F" : "N", a.IdAtto, Operatore);
                    // cambio stato anche agli eventuali progetti correlati
                    if (prog_principale.IdProgIntegrato != null)
                    {
                        SiarLibrary.ProgettoCollection progetti_correlati = progetto_provider.Find(null, null, prog_principale.IdProgIntegrato,
                            null, null, false, true);
                        foreach (SiarLibrary.Progetto p in progetti_correlati)
                            if (p.IdProgetto != p.IdProgIntegrato)
                            {
                                progetto_provider.CambioStatoProgetto(p, "G", Operatore);
                                progetto_provider.CambioStatoProgetto(p, finanziabili ? "F" : "N", Operatore);
                            }
                    }
                }
                graduatoria_provider.DbProviderObj.Commit();
                graduatoria_atti_provider.DbProviderObj.Commit();
                RegisterClientScriptBlock("chiudiPopup();");
            }
            catch (Exception ex)
            {
                graduatoria_provider.DbProviderObj.Rollback(); show_div_decreto = true;
                RegisterClientScriptBlock("alert('" + ex.Message.ToCleanJsString() + "');");
            }
        }

        protected void btnCambioStato_Click(object sender, EventArgs e)
        {
            try
            {
                if (new SiarBLL.BandoResponsabiliCollectionProvider().Find(Bando.IdBando, Operatore.Utente.IdUtente, null, true, true).Count == 0)
                    throw new Exception("Atenzione! Solo il responsabile del bando è abilitato ad utilizzare la funzione.");

                int idProgetto;
                if (int.TryParse(hdnIdProgettoCambiostato.Value, out idProgetto))
                {
                    SiarBLL.ProgettoCollectionProvider progetto_provider = new SiarBLL.ProgettoCollectionProvider();
                    SiarLibrary.Progetto progettoC = progetto_provider.GetById(idProgetto);

                    //controllo se ci sono domande di pagamento 
                    SiarLibrary.DomandaDiPagamentoCollection dp_coll = new SiarBLL.DomandaDiPagamentoCollectionProvider().Find(null, null, idProgetto, null);
                    if (dp_coll.Count > 0)
                    {
                        foreach (SiarLibrary.DomandaDiPagamento dp in dp_coll)
                        {
                            if (dp.SegnaturaAnnullamento == null || dp.SegnaturaAnnullamento == "")
                                throw new Exception("Sono presenti domande di pagamento. Impossibile riportare la domanda allo stato Acquisito. Procedere con l'annullamento delle domande di pagamento e riprovare.");
                        }
                    }

                    string stato = "I";
                    SiarLibrary.ProgettoCollection progetti_correlati;

                    progetto_provider.CambioStatoProgetto(progettoC, stato, Operatore);
                    if (progettoC.IdProgIntegrato != null)
                    {
                        progetti_correlati = progetto_provider.Find(null, null, idProgetto, null, null, false, true);
                        foreach (SiarLibrary.Progetto p in progetti_correlati)
                            if (p.IdProgetto != p.IdProgIntegrato) progetto_provider.CambioStatoProgetto(p, stato, Operatore);
                    }


                    //cancello le righe di graduatoria_progettia_atti
                    SiarLibrary.GraduatoriaProgettiAttiCollection atti_grad_col = graduatoria_atti_provider.Find(Bando.IdBando, idProgetto, null, null);
                    foreach (SiarLibrary.GraduatoriaProgettiAtti a in atti_grad_col)
                        graduatoria_atti_provider.Delete(a);

                    SiarLibrary.GraduatoriaProgettiCollection grad_coll = graduatoria_provider.Find(Bando.IdBando, idProgetto, null);
                    foreach (SiarLibrary.GraduatoriaProgetti gp in grad_coll)
                    {
                        gp.ContributoRimanente = null;
                        gp.Finanziabilita = null;
                        graduatoria_provider.Save(gp);
                    }

                    ShowMessage("Il progetto è stato riportato allo stato Acquisito. Ora è possibile procedere con l'istruttoria di ammissibilità.");

                }
                else
                    throw new Exception("Errore nella selezione del progetto.");

                hdnIdProgettoCambiostato.Value = "";

            }
            catch (Exception ex) { ShowError(ex); }
        }


        protected void btnSalvaDescretoOrg_Click(object sender, EventArgs e)
        {
            string messaggio = "";
            try
            {
                messaggio = "";

                //SiarBLL.BandoStoricoCollectionProvider bstorico_provider = new SiarBLL.BandoStoricoCollectionProvider(BandoProvider.DbProviderObj);
                //SiarLibrary.BandoStoricoCollection bsc = bstorico_provider.Find(Bando.IdBando, "G");
                //if (bsc.Count == 0)
                //    throw new Exception("La graduatoria non è stata ancora resa definitiva. Impossibile continuare..");
                if (txtDataDecretoOrg.Text == "" || txtDataDecretoOrg.Text == null
                        || txtNumeroDecretoOrg.Text == "" || txtNumeroDecretoOrg.Text == null
                        || txtDescrizioneDecretoOrg.Text == "" || txtDescrizioneDecretoOrg.Text == null
                        || txtLinkEst.Text == "" || txtLinkEst.Text == null)
                    throw new Exception("Informazioni mancanti. Inserire tutti i dati relativi al Decreto/Atto.");

                SetFinanziabilita(true);
            }
            catch (Exception ex)
            {
                RegisterClientScriptBlock("chiudiPopupTemplate();");
                messaggio = "Attenzione! " + ex.Message;
                RegisterClientScriptBlock("alert('" + messaggio + "');");
            }
        }

        protected void btnModificaProgetto_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(responsabile || Operatore.Utente.Profilo == "Amministratore"))
                    throw new Exception("Attenzione! Solo il responsabile del bando è abilitato ad utilizzare la funzione.");

                //Se il bando è  
                // - almeno pubblicato  
                // - se sono il rup o amministratore  
                // - se il progetto ha già un contributo concesso diverso da null per evitare che usino questa funzione invece del giro corretto 
                //posso modificare la graduatoria con decreto  
                if (!(Bando.OrdineStato >= 2))
                    throw new Exception("Attenzione! Il bando deve essere almeno pubblicato");

                int idProgetto;
                if (int.TryParse(hdnIdProgettoModifica.Value, out idProgetto))
                {
                    GraduatoriaProgettiCollectionProvider graduatoria_progetti_provider = new GraduatoriaProgettiCollectionProvider();
                    var graduatoriaProgettoCollection = graduatoria_progetti_provider.Find(Bando.IdBando, idProgetto, null);
                    if (graduatoriaProgettoCollection.Count == 0)
                        throw new Exception("Non ho trovato il progetto id " + idProgetto + " nella graduatoria del bando id " + Bando.IdBando);

                    var graduatoriaProgetto = graduatoriaProgettoCollection[0];
                    if (graduatoriaProgetto.ContributoTotale == null)
                        throw new Exception("Il progetto non ha ancora un contributo assegnato: utilizzare l'apposita funzione di caricamento con decreto.");

                    ProgettoCollectionProvider progetto_provider = new ProgettoCollectionProvider();
                    ProgettoModificaGraduatoria = progetto_provider.GetById(idProgetto);
                    GraduatoriaProgettoModifica = null;

                    Response.Redirect(PATH_ISTRUTTORIA + "ModificaGraduatoriaProgetto.aspx");
                }
                else
                    throw new Exception("Errore nella selezione del progetto.");

                hdnIdProgettoModifica.Value = "";
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }
    }
}
