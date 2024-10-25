using System;
using System.Web.UI.WebControls;
using SiarLibrary.Extensions;

namespace web.Private.PDomanda
{
    public partial class AllegatiDomanda : SiarLibrary.Web.ProgettoPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "Presentazione_domanda";
            base.OnPreInit(e);
        }

        SiarBLL.ProgettoAllegatiCollectionProvider allegati_provider;
        SiarLibrary.ProgettoAllegati allegato_selezionato = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            allegati_provider = new SiarBLL.ProgettoAllegatiCollectionProvider(ProgettoProvider.DbProviderObj);
            int id_axp;
            if (int.TryParse(hdnIdProgettoAllegati.Value, out id_axp)) allegato_selezionato = allegati_provider.GetById(id_axp);
        }

        protected override void OnPreRender(EventArgs e)
        {
            lstNATipoEnte.Attributes.Add("onchange", "lstNATipoEnte_changed();");
            lstNACategoria.Attributes.Add("onchange", "lstNACategoria_changed();");
            lstNACategoria.CommandText = @"SELECT ID_ALLEGATO,'('+COD_TIPO+') '+SUBSTRING(DESCRIZIONE,0,100) AS DESCRIZIONE,COD_TIPO FROM vALLEGATI_x_DOMANDA
                    WHERE ID_DOMANDA=" + Bando.IdModelloDomanda + " ORDER BY COD_TIPO DESC,DESCRIZIONE";
            lstNACategoria.DataBind();
            ufcNAAllegato.AbilitaModifica = AbilitaModifica;
            txtNAEnte.AddJSAttribute("onkeydown", "SNCVolatileZoom(this,event,'SNCVZCercaAmministrazione');");

            if (allegato_selezionato != null)
            {
                hdnIdProgettoAllegati.Value = allegato_selezionato.Id;
                lstNACategoria.SelectedValue = allegato_selezionato.IdAllegato;
                txtNADescrizioneBreve.Text = allegato_selezionato.DescrizioneBreve;
                if (allegato_selezionato.CodTipo == "D")
                {
                    ufcNAAllegato.IdFile = allegato_selezionato.IdFile;
                    chkNAPresentato.Checked = allegato_selezionato.GiaPresentato;
                }
                else if (allegato_selezionato.CodTipo == "S")
                {
                    hdnCodEnte.Value = allegato_selezionato.IdComune.IsNullAlt(allegato_selezionato.CodEnteEmettitore);
                    lstNATipoEnte.SelectedValue = allegato_selezionato.IdComune != null ? "CM" : (allegato_selezionato.CodEnteEmettitore != null ? "PR" : "");
                    txtNAEnte.Text = allegato_selezionato.Ente;
                    txtNADatadoc.Text = allegato_selezionato.Data;
                    txtNANumeroDoc.Text = allegato_selezionato.Numero;
                }
            }
            RegisterClientScriptBlock("lstNACategoria_changed();");

            SiarLibrary.ProgettoAllegatiCollection allegati_domanda = allegati_provider.Find(Progetto.IdProgetto, null);
            dgAllegati.DataSource = allegati_domanda;
            dgAllegati.Titolo = "Elementi trovati: " + allegati_domanda.Count;
            dgAllegati.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgAllegati_ItemDataBound);
            dgAllegati.DataBind();
            if (allegati_domanda.Count > 0) divDimTotAllegati.InnerText = "Dimensione totale degli allegati: " + string.Format("{0:N0}", dimensione_totale_allegati) + " Kb";
            base.OnPreRender(e);
        }

        int dimensione_totale_allegati = 0;
        void dgAllegati_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.ProgettoAllegati a = (SiarLibrary.ProgettoAllegati)e.Item.DataItem;
                if (a.IdFile == null) e.Item.Cells[5].Text = "";
                if (a.CodTipo == "S") e.Item.Cells[3].Text = "<b>Nr.</b> " + a.Numero + " <b>del</b> " + a.Data + "<br /><b>Presso:</b> " + a.Ente
                    + "<br /><b>Descrizione:</b> " + e.Item.Cells[3].Text;
                dimensione_totale_allegati += a.DimensioneFile ?? 0;
            }
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (string.IsNullOrEmpty(lstNACategoria.SelectedValue)) throw new Exception("E' obbligatorio selezionare la categoria del documento.");
                SiarLibrary.Allegati categoria = new SiarBLL.AllegatiCollectionProvider().GetById(lstNACategoria.SelectedValue);
                if (categoria == null) throw new Exception("La categoria di documento selezionata non è valida.");
                if (allegato_selezionato == null)
                {
                    allegato_selezionato = new SiarLibrary.ProgettoAllegati();
                    allegato_selezionato.IdProgetto = Progetto.IdProgetto;
                }
                allegato_selezionato.IdAllegato = lstNACategoria.SelectedValue;
                if (categoria.CodTipo == "C") throw new Exception("La categoria di documento selezionata non è più valida.");
                else if (categoria.CodTipo == "S")
                {
                    if (string.IsNullOrEmpty(lstNATipoEnte.SelectedValue) || string.IsNullOrEmpty(hdnCodEnte.Value)
                        || string.IsNullOrEmpty(txtNADatadoc.Text) || string.IsNullOrEmpty(txtNANumeroDoc.Text))
                        throw new Exception("Specificare tutti i campi previsti per l'identificazione del documento.");
                    //if (ente.CodTipoEnte == null) throw new Exception("Non è stata specificata l'amministrazione emettitrice del documento selezionato.");
                    if (lstNATipoEnte.SelectedValue == "CM")
                    {
                        int id_comune;
                        if (!int.TryParse(hdnCodEnte.Value, out id_comune)) throw new Exception("Non è stato specificato il comune emettitore del documento selezionato.");
                        allegato_selezionato.IdComune = id_comune;
                        allegato_selezionato.CodEnteEmettitore = null;
                    }
                    else
                    {
                        allegato_selezionato.CodEnteEmettitore = hdnCodEnte.Value;
                        allegato_selezionato.IdComune = null;
                    }
                    allegato_selezionato.Numero = txtNANumeroDoc.Text;
                    allegato_selezionato.Data = txtNADatadoc.Text;
                    allegato_selezionato.GiaPresentato = false;
                    allegato_selezionato.IdFile = null;
                }
                else
                {
                    if (!chkNAPresentato.Checked && ufcNAAllegato.IdFile == null)
                        throw new Exception("La categoria di documento selezionata richiede di caricare il documento digitale o di specificare se esso sia già in possesso dell'amministrazione.");
                    allegato_selezionato.GiaPresentato = chkNAPresentato.Checked;
                    allegato_selezionato.IdFile = ufcNAAllegato.IdFile;
                    allegato_selezionato.CodEnteEmettitore = null;
                    allegato_selezionato.IdComune = null;
                    allegato_selezionato.Numero = null;
                    allegato_selezionato.Data = null;
                }
                allegato_selezionato.DescrizioneBreve = txtNADescrizioneBreve.Text;
                allegati_provider.Save(allegato_selezionato);
                ProgettoProvider.AggiornaProgetto(Progetto, Operatore.Utente.IdUtente);
                allegato_selezionato = allegati_provider.GetById(allegato_selezionato.Id);
                ShowMessage("Allegato salvato correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (allegato_selezionato == null || allegato_selezionato.IdProgetto != Progetto.IdProgetto) throw new Exception("L'allegato selezionato non è valido.");
                allegati_provider.Delete(allegato_selezionato);
                ProgettoProvider.AggiornaProgetto(Progetto, Operatore.Utente.IdUtente);
                ShowMessage("Allegato eliminato correttamente.");
                RegisterClientScriptBlock("pulisciCampi();");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnDettaglioAllegatoPost_Click(object sender, EventArgs e) { }

        protected void btnNuovoPost_Click(object sender, EventArgs e) 
        {
            ufcNAAllegato.IdFile = null;
        }
    }
}
