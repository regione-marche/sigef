using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.Fem
{
    public partial class PistaControlloFem : SiarLibrary.Web.PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "pista_controllo";
            base.OnPreInit(e);
        }

        SiarLibrary.Progetto progetto_selezionato = null;
        SiarLibrary.Bando bando_selezionato = null;
        SiarBLL.BandoCollectionProvider bando_prov = new SiarBLL.BandoCollectionProvider();
        SiarBLL.ProgettoCollectionProvider prog_prov = new SiarBLL.ProgettoCollectionProvider();
        SiarBLL.TipoPistaControlloCollectionProvider tipo_pista_prov = new SiarBLL.TipoPistaControlloCollectionProvider();
        SiarBLL.PistaControlloFemCollectionProvider pista_prov = new SiarBLL.PistaControlloFemCollectionProvider();
        SiarLibrary.PistaControlloFem voce_pista_selezionata = null;
        SiarBLL.ProgettoSoggettoGestoreCollectionProvider prog_sog_gest_prov = new SiarBLL.ProgettoSoggettoGestoreCollectionProvider();
        bool responsabile = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_Bando;
            if (int.TryParse(hdnIdBando.Value, out id_Bando))
            {
                bando_selezionato = bando_prov.GetById(id_Bando);
                responsabile = new SiarBLL.BandoResponsabiliCollectionProvider().Find(bando_selezionato.IdBando, Operatore.Utente.IdUtente, null, true, true).Count > 0;

                int id_progetto;
                if (int.TryParse(hdnIdProgetto.Value, out id_progetto))
                {
                    progetto_selezionato = prog_prov.GetById(id_progetto);

                    int id_Pista_controllo;
                    if (int.TryParse(hdnIdPistaControllo.Value, out id_Pista_controllo))
                    {
                        voce_pista_selezionata = pista_prov.GetById(id_Pista_controllo);
                    }
                }
            }
            //else
            //{
            //    hdnIdProgetto.Value = "";
            //}
        }

        protected override void OnPreRender(EventArgs e)
        {

            SiarLibrary.BandoCollection bandi_coll = new SiarLibrary.BandoCollection();

            if (bando_selezionato == null)
            {
                List<int> list_bando = new List<int>();
                SiarLibrary.ProgettoSoggettoGestoreCollection prog_gest_coll = prog_sog_gest_prov.FindProgettiSoggettoGestore(null, null, null, null, null, null, null);
                foreach (SiarLibrary.ProgettoSoggettoGestore pg in prog_gest_coll)
                {
                    if (!list_bando.Contains(pg.IdBando))
                        list_bando.Add(pg.IdBando);
                }

                foreach (int i in list_bando)
                    bandi_coll.Add(bando_prov.GetById(i));
                divProg.Visible = false;
                divTab.Visible = false;
            }
            else
            {
                bandi_coll.Add(bando_selezionato);
                divProg.Visible = true;
                

                SiarLibrary.ProgettoCollection prog_coll = new SiarLibrary.ProgettoCollection();
                if (progetto_selezionato == null)
                {
                    divTab.Visible = false;
                    
                    List<int> list_prog = new List<int>();
                    SiarLibrary.ProgettoSoggettoGestoreCollection prog_gest_coll = prog_sog_gest_prov.FindProgettiSoggettoGestore(null, null, null, null, null, bando_selezionato.IdBando, null);
                    foreach (SiarLibrary.ProgettoSoggettoGestore pg in prog_gest_coll)
                    {
                        prog_coll.Add(prog_prov.GetById(pg.IdProgettoRiferimento));
                    }
                }
                else
                {
                    prog_coll.Add(progetto_selezionato);
                    divTab.Visible = true;
                    switch (ucSiarNewTab.TabSelected)
                    {
                        case 2:
                            divPista.Visible = false;
                            lstTipoPistaLiv1.Livello = 1;
                            lstTipoPistaLiv1.IdPadre = 0;
                            lstTipoPistaLiv1.DataBind();
                            if (!string.IsNullOrEmpty(lstTipoPistaLiv1.SelectedValue))
                            {
                                lstTipoPistaLiv2.Livello = 2;
                                lstTipoPistaLiv2.IdPadre = Convert.ToInt32(lstTipoPistaLiv1.SelectedValue);
                                lstTipoPistaLiv2.DataBind();
                            }
                            lstAttoDefinizione.DataBind();
                            lstAttoRegistro.DataBind();
                            if (responsabile || Operatore.Utente.CodEnte == "%")
                            {
                                btnAggiungiVoce.Enabled = true;
                                if (voce_pista_selezionata != null)
                                    btnEliminaVoce.Enabled = true;
                                else
                                    btnEliminaVoce.Enabled = false;
                            }
                            else
                            {
                                btnAggiungiVoce.Enabled = false;
                                btnEliminaVoce.Enabled = false;
                            }


                            if (voce_pista_selezionata != null)
                            {
                                SiarLibrary.TipoPistaControllo tipo_liv2 = tipo_pista_prov.GetById(voce_pista_selezionata.IdTipoPistaControllo);
                                lstTipoPistaLiv1.SelectedValue = tipo_liv2.IdPadre;
                                lstTipoPistaLiv2.Livello = 2;
                                lstTipoPistaLiv2.IdPadre = Convert.ToInt32(lstTipoPistaLiv1.SelectedValue);
                                lstTipoPistaLiv2.DataBind();
                                lstTipoPistaLiv2.SelectedValue = voce_pista_selezionata.IdTipoPistaControllo;
                                txtDescrizione.Text = voce_pista_selezionata.Descrizione;
                                txtOrdine.Text = voce_pista_selezionata.Ordine;
                                if (voce_pista_selezionata.Data != null)
                                    txtData.Text = voce_pista_selezionata.Data;
                                else
                                    txtData.Text = "";
                                rblTipoVoce.SelectedValue = voce_pista_selezionata.IdTipoPistaControlloVoce;
                                switch (voce_pista_selezionata.IdTipoPistaControlloVoce.ToString())
                                {
                                    case "0":
                                        //verifico segnatura
                                        txtSegnatura.Text = voce_pista_selezionata.Testo;
                                        break;

                                    case "1":
                                        SiarLibrary.Atti atto = new SiarBLL.AttiCollectionProvider().GetById(voce_pista_selezionata.IdAtto);
                                        txtAttoData.Text = atto.Data;
                                        txtAttoNumero.Text = atto.Numero;
                                        lstAttoDefinizione.SelectedValue = atto.CodDefinizione;

                                        foreach (ListItem l in lstAttoRegistro.Items) if (l.Value.StartsWith(atto.Registro)) { l.Selected = true; break; }
                                        break;

                                    case "2":
                                        txtTestoLink.Text = voce_pista_selezionata.Testo;
                                        txtLink.Text = voce_pista_selezionata.Link;
                                        break;
                                    case "3":
                                        txtTesto.Text = voce_pista_selezionata.Testo;
                                        break;
                                    case "4":
                                        ufImmagine.IdFile = voce_pista_selezionata.IdFile;
                                        break;
                                    case "5":
                                        txtQuery.Text = voce_pista_selezionata.QuerySql;
                                        break;
                                }
                            }
                            break;

                        default:
                            divVoce.Visible = false;

                            SiarLibrary.ProgettoSoggettoGestoreCollection gest_coll = new SiarBLL.ProgettoSoggettoGestoreCollectionProvider().FindProgettiSoggettoGestore(null, progetto_selezionato.IdImpresa, null, null, null, progetto_selezionato.IdBando, progetto_selezionato.IdProgetto);
                            if (gest_coll.Count != 1)
                                throw new Exception("Progetto non selezionato. Contattare l'helpdesk per risolvere il problema.");
                            //if(gest_coll[0].IdSoggettoGestore == (int)SiarBLL.SoggettoGestoreCollectionProvider.EnumSoggettiGestore.Artigiancassa)
                            ////if (progetto_selezionato.IdProgetto == int.Parse(ConfigurationManager.AppSettings["IdProgettoArtigiancassa"]))
                            //    txtTitolo.Text = "Fondo Energia e Mobilità Marche";
                            //else
                            //    txtTitolo.Text = "Sostegno ai processi di fusione dei confidi";

                            SiarLibrary.BandoProgrammazioneCollection programm_coll = new SiarBLL.BandoProgrammazioneCollectionProvider().Find(bando_selezionato.IdBando, null, null, null);
                            SiarLibrary.Zprogrammazione zprog_int = new SiarBLL.ZprogrammazioneCollectionProvider().GetById(programm_coll[0].IdProgrammazione);
                            SiarLibrary.Zprogrammazione zprog_az = new SiarBLL.ZprogrammazioneCollectionProvider().GetById(zprog_int.IdPadre);
                            SiarLibrary.Zprogrammazione zprog_ass = new SiarBLL.ZprogrammazioneCollectionProvider().GetById(zprog_az.IdPadre);
                            lblAsse.Text = "ASSE: " + zprog_ass.Codice + " - " + zprog_ass.Descrizione;
                            lblAzione.Text = "AZIONE: " + zprog_az.Codice + " - " + zprog_az.Descrizione;
                            lblIntervento.Text = "INTERVENTO: " + zprog_int.Codice + " - " + zprog_int.Descrizione;
                            lblBando.Text = "BANDO: " + bando_selezionato.Descrizione;
                            SiarLibrary.Impresa imp = new SiarBLL.ImpresaCollectionProvider().GetById(progetto_selezionato.IdImpresa);
                            lbAzienda.Text = "AZIENDA/ENTE: " + imp.RagioneSociale;
                            lbProgetto.Text = "PROGETTO NUM: " + progetto_selezionato.IdProgetto;

                            SiarLibrary.TipoPistaControlloCollection tipo_pista_liv1_coll = tipo_pista_prov.GetTipoPistaControlloPadre(progetto_selezionato.IdProgetto);
                            rptTipoLiv1.DataSource = tipo_pista_liv1_coll;
                            rptTipoLiv1.DataBind();


                            break;
                    }
                }

                dgProgetti.DataSource = prog_coll;
                dgProgetti.SetTitoloNrElementi();
                dgProgetti.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgProgetti_ItemDataBound);
                dgProgetti.DataBind();

            }

            dgBandi.DataSource = bandi_coll;
            dgBandi.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgBandi_ItemDataBound);
            dgBandi.DataBind();
            base.OnPreRender(e);
        }

        void dgBandi_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            int col_Id = 0,

                col_Descr = 1,

                col_Importo = 2,

                col_Rup = 3,

                col_Check = 4;

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.Bando bando = (SiarLibrary.Bando)e.Item.DataItem;

                SiarLibrary.BandoResponsabiliCollection resp_coll = new SiarBLL.BandoResponsabiliCollectionProvider().Find(bando.IdBando, null, null, null, true);
                foreach (SiarLibrary.BandoResponsabili resp in resp_coll)
                {
                    if (resp.Provincia == null)
                    {
                        e.Item.Cells[col_Rup].Text = resp.Nominativo;
                    }
                }
                //responsabile = new SiarBLL.BandoResponsabiliCollectionProvider().Find(Bando.IdBando, Operatore.Utente.IdUtente, null, true, true).Count > 0;
                e.Item.Cells[col_Importo].Text = string.Format("{0:c}", bando.Importo);


                e.Item.Cells[col_Check].Text = e.Item.Cells[col_Check].Text.Replace("<input", "<input checked onclick=\"selezionaBando(" + bando.IdBando + ",this);\"");
                if (hdnIdBando.Value == null || hdnIdBando.Value == "")
                {
                    e.Item.Cells[col_Check].Text = e.Item.Cells[col_Check].Text.Replace("checked", "");
                }
            }
        }

        void dgProgetti_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            int col_p_Id = 0,

                col_p_ragSoc = 1,

                col_p_Importo = 2,

                col_p_Check = 3;

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.Progetto progetto = (SiarLibrary.Progetto)e.Item.DataItem;
                SiarLibrary.Impresa imp = new SiarBLL.ImpresaCollectionProvider().GetById(progetto.IdImpresa);

                e.Item.Cells[col_p_ragSoc].Text = imp.RagioneSociale;


                //Calcolo contributo Progetto
                decimal contributo = 0;
                int idVariante = 0;
                SiarLibrary.VariantiCollection var_coll = new SiarBLL.VariantiCollectionProvider().Find(null, progetto.IdProgetto, null);
                foreach (SiarLibrary.Varianti v in var_coll)
                {
                    if (v.SegnaturaApprovazione != null && v.SegnaturaApprovazione != "" && v.Approvata == true)
                        idVariante = v.IdVariante;
                }

                SiarLibrary.PianoInvestimentiCollection pianoInv_col;
                if (idVariante == 0)
                    pianoInv_col = new SiarBLL.PianoInvestimentiCollectionProvider().GetSituazionePianoInvestimenti(progetto.IdProgetto);
                else
                    pianoInv_col = new SiarBLL.PianoInvestimentiCollectionProvider().GetPianoInvestimentiVariante(progetto.IdProgetto, idVariante);

                foreach (SiarLibrary.PianoInvestimenti p in pianoInv_col)
                {
                    if (p.CodVariazione != "A")
                        contributo += p.ContributoRichiesto;
                }
                e.Item.Cells[col_p_Importo].Text = string.Format("{0:c}", contributo);



                e.Item.Cells[col_p_Check].Text = e.Item.Cells[col_p_Check].Text.Replace("<input", "<input checked onclick=\"selezionaProgetto(" + progetto.IdProgetto + ",this);\"");
                if (hdnIdProgetto.Value == null || hdnIdProgetto.Value == "")
                {
                    e.Item.Cells[col_p_Check].Text = e.Item.Cells[col_p_Check].Text.Replace("checked", "");
                }
            }
        }

        protected void rptTipoLiv1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.TipoPistaControllo pista = (SiarLibrary.TipoPistaControllo)e.Item.DataItem;

                SiarLibrary.TipoPistaControlloCollection tipo_liv2_coll = tipo_pista_prov.GetTipoPistaControlloFiglio(progetto_selezionato.IdProgetto, pista.IdTipoPistaControllo);
                Repeater rptPistaLiv2 = (Repeater)e.Item.FindControl("rptTipoLiv2");
                rptPistaLiv2.DataSource = tipo_liv2_coll;
                rptPistaLiv2.DataBind();
            }
        }

        protected void rptTipoLiv2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.TipoPistaControllo pista = (SiarLibrary.TipoPistaControllo)e.Item.DataItem;
                Label lbTitolo2 = (Label)e.Item.FindControl("lbTitoloLiv2");
                lbTitolo2.Text = pista.Descrizione;

                SiarLibrary.PistaControlloFemCollection pista_coll = pista_prov.Find(null, progetto_selezionato.IdProgetto, pista.IdTipoPistaControllo, null);
               
                SiarLibrary.Web.DataGrid dgPista = (SiarLibrary.Web.DataGrid)e.Item.FindControl("dgPista");
                dgPista.DataSource = pista_coll;
                dgPista.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgPista_ItemDataBound);
                dgPista.DataBind();
            }
        }
        void dgPista_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.PistaControlloFem pista = (SiarLibrary.PistaControlloFem)e.Item.DataItem;
                switch (pista.IdTipoPistaControlloVoce.ToString())
                {
                    case "0":
                        //e.Item.Cells[1].Text = "< input type = 'image' src = '../../images/lente24.png' value='Link'  class='elenco' onclick='sncAjaxCallVisualizzaProtocollo('" + pista.Testo + "');' /> <span>" + pista.Testo + " </span>";
                        e.Item.Cells[1].Text = "<img src='" + Page.ResolveUrl("~/images/lente24.png") + "' alt='File'  onclick=\"sncAjaxCallVisualizzaProtocollo('" + pista.Testo + "');\" style='cursor: pointer;'> <span>" + pista.Testo + " </span> ";
                        break;

                    case "1":
                        SiarLibrary.Atti atto = new SiarBLL.AttiCollectionProvider().GetById(pista.IdAtto);
                        e.Item.Cells[1].Text = "<img src='" + Page.ResolveUrl("~/images/lente24.png") + "' alt='File'  onclick=\"visualizzaAtto(" + pista.IdAtto + ");\" style='cursor: pointer;'> <span>" + atto.Numero+" | "+atto.Data+" | "+atto.Registro+ " </span> ";
                        break;

                    case "2":
                        e.Item.Cells[1].Text = "<a href ='" + pista.Link + "' target = '_blank' ><img src='" + Page.ResolveUrl("~/images/lente24.png") + "' style='cursor: pointer;' /></a>" + pista.Testo;
                        break;
                    case "3":
                        e.Item.Cells[1].Text = pista.Testo;
                        break;
                    case "4":
                        SiarLibrary.ArchivioFile file = new SiarBLL.ArchivioFileCollectionProvider().GetById(pista.IdFile);
                        e.Item.Cells[1].Text = "<img src='" + Page.ResolveUrl("~/images/lente24.png") + "' alt='File'  onclick=\"SNCUFVisualizzaFile(" + pista.IdFile + ");\" style='cursor: pointer;'> <span>" + file.NomeFile + " </span> ";
                        break;
                    case "5":
                        string sql = pista.QuerySql;
                        int i = 0;
                        sql = sql.Replace("@IdProgetto", progetto_selezionato.IdProgetto.ToString());
                        sql = sql.Replace("\n", " " );
                        sql = sql.Replace("`", "'");
                        SiarLibrary.DbProvider _db = new SiarLibrary.DbProvider();
                        IDbCommand cmd;
                        cmd = _db.GetCommand();
                        cmd.CommandText = sql;
                        _db.InitDatareader(cmd);
                        while(_db.DataReader.Read())
                        {
                            if (i == 0)
                                e.Item.Cells[1].Text = "";
                            else
                                e.Item.Cells[1].Text += "<br>";

                            string tipo = new SiarLibrary.NullTypes.StringNT(_db.DataReader["Tipo"]);
                            switch (tipo)
                            {
                                case "Segnatura":
                                    string segnatuta = new SiarLibrary.NullTypes.StringNT(_db.DataReader["Valore"]);
                                    e.Item.Cells[1].Text += "<img src='" + Page.ResolveUrl("~/images/lente24.png") + "' alt='File'  onclick=\"sncAjaxCallVisualizzaProtocollo('" + segnatuta + "');\" style='cursor: pointer;'> <span>" + segnatuta + " </span> ";
                                    break;
                                case "Atto":
                                    int idAtto = new SiarLibrary.NullTypes.IntNT(_db.DataReader["Valore"]);
                                    SiarLibrary.Atti atto_ = new SiarBLL.AttiCollectionProvider().GetById(idAtto);
                                    e.Item.Cells[1].Text += "<img src='" + Page.ResolveUrl("~/images/lente24.png") + "' alt='File'  onclick=\"visualizzaAtto(" + idAtto + ");\" style='cursor: pointer;'> <span>" + atto_.Numero + " | " + atto_.Data + " | " + atto_.Registro + " </span> ";
                                    break;
                                case "File":
                                    int idFile = new SiarLibrary.NullTypes.IntNT(_db.DataReader["Valore"]);
                                    SiarLibrary.ArchivioFile file_ = new SiarBLL.ArchivioFileCollectionProvider().GetById(idFile);
                                    e.Item.Cells[1].Text += "<img src='" + Page.ResolveUrl("~/images/lente24.png") + "' alt='File'  onclick=\"SNCUFVisualizzaFile(" + idFile + ");\" style='cursor: pointer;'> <span>" + file_.NomeFile + " </span> ";
                                    break;
                                case "Testo":
                                    string testo = new SiarLibrary.NullTypes.StringNT(_db.DataReader["Valore"]);
                                    e.Item.Cells[1].Text += "<span>" + testo + " </span> ";
                                    break;
                            }
                            i++;
                        }
                        break;
                }
                 
            }
            else if(e.Item.ItemType == ListItemType.Header)
            {
                e.Item.CssClass = "nascondi";
            }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {

        }

        protected void btnAggiungiVoce_Click(object sender, EventArgs e)
        {
            try
            {
                if (rblTipoVoce.SelectedValue == "5" && Operatore.Utente.CodEnte != "%")
                    throw new Exception("Solo gli amministratori del sistema possono inserire le voci SIGEF!");

                if (voce_pista_selezionata == null)
                {
                    voce_pista_selezionata = new SiarLibrary.PistaControlloFem();
                    voce_pista_selezionata.IdProgetto = progetto_selezionato.IdProgetto;
                    voce_pista_selezionata.OperatoreCreazione = Operatore.Utente.IdUtente;
                    voce_pista_selezionata.DataCreazione = DateTime.Now;
                }
                voce_pista_selezionata.IdTipoPistaControllo = lstTipoPistaLiv2.SelectedValue;
                voce_pista_selezionata.Descrizione = txtDescrizione.Text;
                voce_pista_selezionata.Ordine = txtOrdine.Text;
                voce_pista_selezionata.IdTipoPistaControlloVoce = rblTipoVoce.SelectedValue;
                if (txtData.Text != "" && txtData.Text != null)
                    voce_pista_selezionata.Data = txtData.Text;
                switch (rblTipoVoce.SelectedValue)
                {
                    case "0":
                        //verifico segnatura
                        if (!new SiarLibrary.Protocollo().ProtocolloEsistente(txtSegnatura.Text))
                            throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.DocumentoNonValido);
                        voce_pista_selezionata.Testo = txtSegnatura.Text;
                        break;

                    case "1":
                        int numero;
                        int.TryParse(txtAttoNumero.Text, out numero);
                        DateTime data;
                        DateTime.TryParse(txtAttoData.Text, out data);
                        string registro = lstAttoRegistro.SelectedValue;
                        if (!string.IsNullOrEmpty(lstAttoRegistro.SelectedValue) && lstAttoRegistro.SelectedValue.IndexOf("|") > 0)
                            registro = lstAttoRegistro.SelectedValue.Substring(0, lstAttoRegistro.SelectedValue.IndexOf("|"));
                        // controllo che l'atto sia registrato su db, altrimenti lo importo
                        SiarBLL.AttiCollectionProvider atti_provider = new SiarBLL.AttiCollectionProvider();
                        SiarLibrary.AttiCollection atti_trovati = atti_provider.Find(numero, data, lstAttoDefinizione.SelectedValue, registro);
                        if (atti_trovati.Count == 0)
                        {
                            atti_trovati = atti_provider.ImportaAtto(numero, data, lstAttoDefinizione.SelectedValue, lstAttoRegistro.SelectedValue);
                            if (atti_trovati.Count > 0) atti_provider.Save(atti_trovati[0]);
                        }
                        if (atti_trovati.Count > 0)
                        {
                            voce_pista_selezionata.IdAtto = atti_trovati[0].IdAtto;
                        }
                        else throw new Exception("La ricerca non ha prodotto nessun risultato.");
                        break;

                    case "2":
                        voce_pista_selezionata.Testo = txtTestoLink.Text;
                        voce_pista_selezionata.Link = txtLink.Text;
                        break;
                    case "3":
                        voce_pista_selezionata.Testo = txtTesto.Text;
                        break;
                    case "4":
                        voce_pista_selezionata.IdFile = ufImmagine.IdFile;
                        break;
                    case "5":
                        voce_pista_selezionata.QuerySql = txtQuery.Text.Replace("`", "'");
                        break;
                }

                pista_prov.Save(voce_pista_selezionata);
                ShowMessage("Voce della Pista di Controllo salvata correttamente.");
            }
            catch (Exception ex) {
                voce_pista_selezionata = null;
                ShowError(ex); 
            }
        }

        protected void btnEliminaVoce_Click(object sender, EventArgs e)
        {
            try
            {
                if (voce_pista_selezionata == null)
                    throw new Exception("Nessuna voce selezionata!");
                pista_prov.Delete(voce_pista_selezionata);
                PulisciCampi();
                ShowMessage("Voce della pista di controllo eliminata correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnNuovaVoce_Click(object sender, EventArgs e)
        {
            try
            {
                PulisciCampi();
            }
            catch (Exception ex) { ShowError(ex); }
        }

        private void PulisciCampi()
        {
            hdnIdPistaControllo.Value = "";
            voce_pista_selezionata = null;
            lstTipoPistaLiv1.DataBind();
            lstTipoPistaLiv2.DataBind();
            txtDescrizione.Text = "";
            txtOrdine.Text = "";
            txtData.Text = "";
            txtSegnatura.Text = "";
            txtAttoNumero.Text = "";
            txtAttoData.Text = "";
            txtTesto.Text = "";
            txtTestoLink.Text = "";
            txtLink.Text = "";
            txtQuery.Text = "";
            ufImmagine.IdFile = null;
        }
    }
}