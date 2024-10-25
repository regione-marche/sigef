using System;
using System.Data;
using System.Web.UI.WebControls;
using SiarLibrary.Extensions;

namespace web.Private.PPagamento.Variante
{
    public partial class Allegati : SiarLibrary.Web.VariantePage
    {
        SiarLibrary.VariantiAllegati allegato_selezionato;
        SiarBLL.VariantiAllegatiCollectionProvider allegati_provider = new SiarBLL.VariantiAllegatiCollectionProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            int idAllegato;
            if (int.TryParse(hdnIdAllegato.Value, out idAllegato)) allegato_selezionato = allegati_provider.GetById(idAllegato);
        }

        protected override void OnPreRender(EventArgs e)
        {
            lstNATipoEnte.Attributes.Add("onchange", "lstNATipoEnte_changed();");
            lstCategoria.Attributes.Add("onchange", "lstCategoria_changed();");
            lstCategoria.CommandText = @"SELECT CODICE , '('+FORMATO+') ' + SUBSTRING(DESCRIZIONE,0,100) AS DESCRIZIONE, FORMATO FROM TIPO_DOCUMENTO WHERE ATTIVO =1 ORDER BY CODICE DESC,DESCRIZIONE";
            lstCategoria.DataBind();
            ufcNAAllegato.AbilitaModifica = AbilitaModifica;
            txtNAEnte.AddJSAttribute("onkeydown", "SNCVolatileZoom(this,event,'SNCVZCercaAmministrazione');");
            if (allegato_selezionato != null)
            {
                hdnIdAllegato.Value = allegato_selezionato.IdAllegato;
                lstCategoria.SelectedValue = allegato_selezionato.CodTipoDocumento;
                txtDescrizione.Text = allegato_selezionato.Descrizione;
                if (allegato_selezionato.Formato == "S")
                {
                    hdnCodEnte.Value = allegato_selezionato.IdComune.IsNullAlt(allegato_selezionato.CodEnteEmettitore);
                    lstNATipoEnte.SelectedValue = allegato_selezionato.IdComune != null ? "CM" : (allegato_selezionato.CodEnteEmettitore != null ? "PR" : "");
                    txtNAEnte.Text = allegato_selezionato.Ente;
                    txtNANumeroDoc.Text = allegato_selezionato.Numero;
                    txtNADatadoc.Text = allegato_selezionato.Data;
                }
                else if (allegato_selezionato.Formato == "D") ufcNAAllegato.IdFile = allegato_selezionato.IdFile;

            }
            RegisterClientScriptBlock("lstCategoria_changed();");

            SiarLibrary.VariantiAllegatiCollection allegati = allegati_provider.Find(Variante.IdVariante, null, null);
            dgAllegati.DataSource = allegati;
            dgAllegati.SetTitoloNrElementi();
            dgAllegati.ItemDataBound += new DataGridItemEventHandler(dgAllegati_ItemDataBound);
            dgAllegati.DataBind();
            base.OnPreRender(e);
        }

        void dgAllegati_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataGridItem dgi = (DataGridItem)e.Item;
                SiarLibrary.VariantiAllegati allegato = (SiarLibrary.VariantiAllegati)dgi.DataItem;
                if (allegato.IdFile == null) e.Item.Cells[5].Text = "";
                if (allegato.Formato == "S") e.Item.Cells[3].Text = "<b>Nr.</b> " + allegato.Numero + " <b>del</b> " + allegato.Data + "<br /><b>Presso:</b> " + allegato.Ente
                    + "<br /><b>Descrizione:</b> " + e.Item.Cells[3].Text;
            }
        }
        protected void btnDettaglioPost_Click(object sender, EventArgs e) { }
        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (string.IsNullOrEmpty(lstCategoria.SelectedValue)) throw new Exception("E' obbligatorio selezionare la categoria del documento.");
                SiarLibrary.TipoDocumento tipologia = new SiarBLL.TipoDocumentoCollectionProvider().GetById(lstCategoria.SelectedValue);
                if (tipologia == null) throw new Exception("La tipologia di documento selezionata non è valida.");
                if (allegato_selezionato == null)
                {
                    allegato_selezionato = new SiarLibrary.VariantiAllegati();
                    allegato_selezionato.IdVariante = Variante.IdVariante;
                }
                allegato_selezionato.CodTipoDocumento = lstCategoria.SelectedValue;
                if (tipologia.Formato == "C") throw new Exception("La tipologia di documento selezionata non è più valida.");
                else if (tipologia.Formato == "S")
                {
                    if (string.IsNullOrEmpty(lstNATipoEnte.SelectedValue) || string.IsNullOrEmpty(hdnCodEnte.Value)
                        || string.IsNullOrEmpty(txtNADatadoc.Text) || string.IsNullOrEmpty(txtNANumeroDoc.Text))
                        throw new Exception("Specificare tutti i campi previsti per l'identificazione del documento.");

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
                    allegato_selezionato.IdFile = null;
                }
                else
                {
                    if (ufcNAAllegato.IdFile == null) throw new Exception("La categoria di documento selezionata richiede di caricare il documento digitale.");
                    allegato_selezionato.IdFile = ufcNAAllegato.IdFile;
                    allegato_selezionato.CodEnteEmettitore = null;
                    allegato_selezionato.IdComune = null;
                    allegato_selezionato.Numero = null;
                    allegato_selezionato.Data = null;
                }

                allegato_selezionato.Descrizione = txtDescrizione.Text;
                allegati_provider.Save(allegato_selezionato);
                VarianteProvider.AggiornaVariante(Variante, Operatore);
                allegato_selezionato = allegati_provider.GetById(allegato_selezionato.IdAllegato);
                ShowMessage("Allegato inserito correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            int idallegato;
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (!int.TryParse(hdnIdAllegato.Value, out idallegato))
                    throw new Exception("Errore nella selezione dell`allegato. Impossibile continuare.");
                SiarLibrary.VariantiAllegati allegato = allegati_provider.GetById(idallegato);
                if (allegato == null || allegato.IdVariante != Variante.IdVariante)
                    throw new Exception("Errore nella selezione dell`allegato. Impossibile continuare.");
                allegati_provider.Delete(allegato);
                VarianteProvider.AggiornaVariante(Variante, Operatore);
                ShowMessage("Allegato eliminato correttamente.");
                RegisterClientScriptBlock("pulisciCampi();");
            }
            catch (Exception ex) { ShowError(ex); }
        }
    }
}