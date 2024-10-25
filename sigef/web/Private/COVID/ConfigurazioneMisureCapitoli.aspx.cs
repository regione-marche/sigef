using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.COVID
{
    public partial class ConfigurazioneMisureCapitoli : SiarLibrary.Web.PrivatePage
    {
        SiarBLL.CovidCapitoliBandiCollectionProvider capitoli_bandi_prov = new SiarBLL.CovidCapitoliBandiCollectionProvider();
        SiarLibrary.CovidCapitoliBandi capitolo_selezionato;

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "configurazione_misure_capitoli";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (hdnIdConfigurazione.Value != "")
                capitolo_selezionato = capitoli_bandi_prov.GetById(hdnIdConfigurazione.Value);
            else
                capitolo_selezionato = null;
        }

        protected override void OnPreRender(EventArgs e)
        {
            switch (ucSiarNewTab.TabSelected)
            {
                case 2:
                    tabConfigurazioni.Visible = false;
                    tabNuovaConfigurazione.Visible = true;
                    lstBando.IdRup = Operatore.Utente.IdUtente;
                    lstBando.DataBind();
                    if (capitolo_selezionato != null)
                    {
                        txtCapitolo.Text = capitolo_selezionato.Capitolo;
                        txtAnnoImp.Text = capitolo_selezionato.AnnoImp;
                        txtAnnoSubimp.Text = capitolo_selezionato.AnnoSubimp;
                        txtDescrizioneImpSubimp.Text = capitolo_selezionato.DescrizioneImpSubimp;
                        txtPercentualeImporto.Text = capitolo_selezionato.PercentualeImporto;
                        txtAnnoProposta.Text = capitolo_selezionato.AnnoProposta;
                        txtUnitaProponente.Text = capitolo_selezionato.UnitaProponente;
                        txtNumeroProposta.Text = capitolo_selezionato.NumeroProposta;
                        txtTransazione.Text = capitolo_selezionato.Transazione;
                        txtCodiceRitenuta.Text = capitolo_selezionato.CodiceRitenuta;
                        txtAliquotaRitenuta.Text = capitolo_selezionato.AliquotaRitenuta;
                        txtCausaleIrpef.Text = capitolo_selezionato.CausaleIrpef;
                        txtControlloEquitalia.Text = capitolo_selezionato.ControlloEquitalia;
                        txtNote.Text = capitolo_selezionato.Note;
                        txtRimodulazioneContributo.Text = capitolo_selezionato.RimodulazioneContributo;
                        lstBando.SelectedValue = capitolo_selezionato.IdBando;
                    }
                    else
                        svuotaCampi();
                    break;
                default:
                    tabConfigurazioni.Visible = true;
                    tabNuovaConfigurazione.Visible = false;
                    lstBandoExport.IdRup = Operatore.Utente.IdUtente;
                    lstBandoExport.DataBind();
                    SiarLibrary.CovidCapitoliBandiCollection capitoli = capitoli_bandi_prov.Find(null, null, null, null, null, null, null, Operatore.Utente.IdUtente, null);
                    dgConfigurazioni.DataSource = capitoli;

                    dgConfigurazioni.ItemDataBound += new DataGridItemEventHandler(dgConfigurazioni_ItemDataBound);
                    dgConfigurazioni.Titolo = "Elementi trovati: " + capitoli.Count;
                    dgConfigurazioni.DataBind();

                    if (dgConfigurazioni.Items.Count > 0)
                        btnExportConfigurazioni.Enabled = true;
                    else
                        btnExportConfigurazioni.Enabled = false;

                    SiarLibrary.BandoCollection bando_col = new SiarLibrary.BandoCollection();
                    SiarLibrary.DbProvider _db = new SiarLibrary.DbProvider();
                    IDbCommand cmd;
                    cmd = _db.GetCommand();
                    cmd.CommandText = @"select L.ID_BANDO as IdBando,convert(varchar,L.DATA_INSERT,103) as DataInserimentoXLS,B.DESCRIZIONE  from  COVID_LIQUIDAZIONI L "+
                                                        " inner join COVID_BANDO_RUP_PAGAMENTO P on p.ID_BANDO = L.ID_BANDO "+
                                                        " inner join BANDO B on b.ID_BANDO = L.ID_BANDO "+
                                                        " where P.ID_OPERATORE = " + Operatore.Utente.IdUtente + 
                                                        " group by L.ID_BANDO,convert(varchar, DATA_INSERT, 103),B.DESCRIZIONE";
                    _db.InitDatareader(cmd);
                    while(_db.DataReader.Read())
                    { 
                        int idBando = new SiarLibrary.NullTypes.IntNT( _db.DataReader["IdBando"]);
                        SiarLibrary.Bando b = new SiarBLL.BandoCollectionProvider().GetById(idBando);
                        b.AdditionalAttributes.Add("DataInserimentoXLS", new SiarLibrary.NullTypes.StringNT(_db.DataReader["DataInserimentoXLS"]));
                        bando_col.Add(b);
                    }
                    dgEstrazioni.DataSource = bando_col;
                    dgEstrazioni.ItemDataBound += new DataGridItemEventHandler(dgEstrazioni_ItemDataBound);
                    dgEstrazioni.DataBind();
                    _db.DataReader.Close();
                    if (bando_col.Count > 0)
                        divEstrazioni.Visible = true;
                    break;
            }
            base.OnPreRender(e);
        }

        void dgEstrazioni_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.Bando b = (SiarLibrary.Bando)e.Item.DataItem;
                e.Item.Cells[2].Text =  b.AdditionalAttributes["DataInserimentoXLS"];

                e.Item.Cells[3].Text = "<img src='" + Page.ResolveUrl("~/images/lente24.png") + "' alt='File'  onclick=\"EstraiXLS(" + b.IdBando + ",'" + b.AdditionalAttributes["DataInserimentoXLS"] + "');\" style='cursor: pointer;'>";
            }
        }
        void dgConfigurazioni_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.CovidCapitoliBandi b = (SiarLibrary.CovidCapitoliBandi)e.Item.DataItem;
                e.Item.Cells[1].Text = new SiarBLL.BandoCollectionProvider().GetById(b.IdBando).Descrizione;
            }
        }

        public void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                capitoli_bandi_prov.DbProviderObj.BeginTran();

                SiarLibrary.CovidCapitoliBandi capitolo = new SiarLibrary.CovidCapitoliBandi();
                if (capitolo_selezionato != null)
                    capitolo = capitolo_selezionato;

                if (capitolo_selezionato != null && capitolo_selezionato.Confermata)
                    throw new Exception();

                capitolo.Capitolo = txtCapitolo.Text;
                capitolo.AnnoImp = txtAnnoImp.Text;
                capitolo.AnnoSubimp = txtAnnoSubimp.Text;
                capitolo.DescrizioneImpSubimp = txtDescrizioneImpSubimp.Text;
                capitolo.RimodulazioneContributo = txtRimodulazioneContributo.Text;
                capitolo.PercentualeImporto = txtPercentualeImporto.Text;
                capitolo.AnnoProposta = txtAnnoProposta.Text;
                capitolo.UnitaProponente = txtUnitaProponente.Text;
                capitolo.NumeroProposta = txtNumeroProposta.Text;
                capitolo.Transazione = txtTransazione.Text;
                capitolo.CodiceRitenuta = txtCodiceRitenuta.Text;
                capitolo.AliquotaRitenuta = txtAliquotaRitenuta.Text;
                capitolo.CausaleIrpef = txtCausaleIrpef.Text;
                capitolo.ControlloEquitalia = txtControlloEquitalia.Text;
                capitolo.Note = txtNote.Text;
                capitolo.IdBando = lstBando.SelectedValue;
                if (capitolo_selezionato == null)
                    capitolo.DataInserimento = DateTime.Now;
                capitolo.IdOperatore = Operatore.Utente.IdUtente;
                capitolo.Confermata = false;

                capitoli_bandi_prov.Save(capitolo);
                capitoli_bandi_prov.DbProviderObj.Commit();
                ShowMessage("Configurazione salvata correttamente.");
                capitolo_selezionato = null;
            }
            catch (Exception ex)
            {
                capitoli_bandi_prov.DbProviderObj.Rollback();
                capitolo_selezionato = null;
                ShowError("Impossibile salvare, ricorda che non è possibile modificare una configurazione confermata.");
            }

        }

        public void svuotaCampi()
        {
            txtCapitolo.Text = string.Empty;
            txtAnnoImp.Text = string.Empty;
            txtAnnoSubimp.Text = string.Empty;
            txtDescrizioneImpSubimp.Text = string.Empty;
            txtPercentualeImporto.Text = string.Empty;
            txtAnnoProposta.Text = string.Empty;
            txtUnitaProponente.Text = string.Empty;
            txtNumeroProposta.Text = string.Empty;
            txtTransazione.Text = string.Empty;
            txtCodiceRitenuta.Text = string.Empty;
            txtAliquotaRitenuta.Text = string.Empty;
            txtCausaleIrpef.Text = string.Empty;
            txtControlloEquitalia.Text = string.Empty;
            txtNote.Text = string.Empty;
            txtRimodulazioneContributo.Text = "100,00";
            lstBando.SelectedValue = string.Empty;
            hdnIdConfigurazione.Value = string.Empty;
        }

        public void btnConferma_Click(object sender, EventArgs e)
        {
            try
            {
                capitoli_bandi_prov.DbProviderObj.BeginTran();

                SiarLibrary.CovidCapitoliBandi capitolo = new SiarLibrary.CovidCapitoliBandi();
                if (capitolo_selezionato == null) throw new Exception("Occorre selezionare una configurazione per poterla confermare.");
                if (capitolo_selezionato.Confermata) throw new Exception("Non si può confermare una configurazione già confermata.");

                capitolo_selezionato.Confermata = true;
                capitoli_bandi_prov.Save(capitolo_selezionato);
                capitoli_bandi_prov.DbProviderObj.Commit();
                ShowMessage("Configurazione confermata correttamente.");
                capitolo_selezionato = null;
            }
            catch (Exception ex)
            {
                capitoli_bandi_prov.DbProviderObj.Rollback();
                ShowError(ex.Message);
            }
        }

        public void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                capitoli_bandi_prov.DbProviderObj.BeginTran();

                SiarLibrary.CovidCapitoliBandi capitolo = new SiarLibrary.CovidCapitoliBandi();
                if (capitolo_selezionato == null) throw new Exception("Occorre selezionare una configurazione per poterla eliminare.");
                if (capitolo_selezionato.Confermata) throw new Exception("Non si può eliminare una configurazione confermata.");

                capitoli_bandi_prov.Delete(capitolo_selezionato);
                capitoli_bandi_prov.DbProviderObj.Commit();
                ShowMessage("Configurazione eliminata correttamente.");
                capitolo_selezionato = null;
            }
            catch (Exception ex)
            {
                capitoli_bandi_prov.DbProviderObj.Rollback();
                ShowError(ex.Message);
            }
        }

        public void btnExport_Click(object sender, EventArgs e)
        {
            SiarBLL.CovidLiquidazioniCollectionProvider liquidazioneProvider = new SiarBLL.CovidLiquidazioniCollectionProvider();

            try
            {
                SiarBLL.VcovidConcessioneProgettiCollectionProvider concessioneProvider = new SiarBLL.VcovidConcessioneProgettiCollectionProvider(liquidazioneProvider.DbProviderObj);
                liquidazioneProvider.DbProviderObj.BeginTran();
                SiarLibrary.VcovidConcessioneProgettiCollection progettiExport = concessioneProvider.Find(lstBandoExport.SelectedValue);

                if (progettiExport.Count == 0) throw new Exception("Il bando selezionato non è stato configurato oppure non ha domande.");

                SiarLibrary.CovidLiquidazioniCollection liquidazioniCollection = new SiarLibrary.CovidLiquidazioniCollection();

                int progressivo = 1;
                foreach (SiarLibrary.VcovidConcessioneProgetti p in progettiExport)
                {
                    SiarLibrary.CovidLiquidazioni l = new SiarLibrary.CovidLiquidazioni();
                    
                    l.AliquotaRitenuta = p.AliquotaRitenuta;
                    l.AnnoImp = p.AnnoImp;
                    l.AnnoProposta = p.AnnoProposta;
                    l.AnnoSubimp = p.AnnoSubimp;
                    l.Bollo = null;
                    l.Capitolo = p.Capitolo;
                    l.CausaleIrpef = p.CausaleIrpef;
                    if (p.CodiceCor != null)
                        l.CodiceCor = p.CodiceCor.ToString();
                    l.CodiceRitenuta = p.CodiceRitenuta;
                    l.ControlloEquitalia = p.ControlloEquitalia;
                    l.DataInsert = p.DataInserimento;
                    l.DescrizioneImpSubimp = p.DescrizioneImpSubimp;
                    l.DurcRegolare = p.DurcRegolare;
                    l.IdDomanda = p.IdDomanda;
                    l.ImponibileRitenuta = p.ImponibileRitenuta;
                    l.Importo = p.Importo;
                    l.ImportoRitenute = p.ImportoRitenute;
                    l.Note = p.Note;
                    l.NumeroProposta = p.NumeroProposta;
                    l.Progressivo = progressivo;
                    l.SistemaOrigine = p.Sistemaorigine;
                    l.Transazione = p.Transazione;
                    l.Ufficio = null;
                    l.UnitaProponente = p.UnitaProponente;
                    l.IdBando = p.IdBando;
                    l.DescrizioneInterventoSostitutivo = p.DescrizioneInterventoSostitutivo;
                    liquidazioniCollection.Add(l);
                    progressivo++;
                }

                liquidazioneProvider.SaveCollection(liquidazioniCollection);
                liquidazioneProvider.DbProviderObj.Commit();

                ShowMessage("Esportazione avvenuta con successo. E' possibile visualizzarlo e scaricarlo dalla griglia!");

            }
            catch (Exception ex)
            {
                liquidazioneProvider.DbProviderObj.Rollback();
                ShowError(ex.Message);
            }
        }
    }
}