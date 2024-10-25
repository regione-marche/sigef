using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using SiarLibrary;
using SiarLibrary.Web;
using SiarBLL;
using System.Web;

namespace web.CONTROLS
{
    public partial class ucVisualizzaProtocollo : SigefUserControl
    {
        private string _mostra;
        public string Mostra
        {
            get { return _mostra; }
            //set { _mostra = value; }
        }

        private string _segnatura;
        public string Segnatura
        {
            get { return _segnatura; }
            set { _segnatura = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _mostra = "mostraPopupTemplate('" + divVisualizzaProtocollo.UniqueID.Replace('$', '_') + "','divBKGMessaggio');";
        }

        protected override void OnPreRender(EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(_segnatura) || _segnatura == "undefined"))
                {
                    inputSegnatura.Value = _segnatura;
                    var segnatureMultipleCollectionProvider = new SegnatureMultipleCollectionProvider();
                    var segnatureMultipleCollection = segnatureMultipleCollectionProvider.FindPerSignaturaPrincipale(_segnatura);

                    if (segnatureMultipleCollection.Count == 0)
                    {
                        divSceltaVistaAvanzata.Visible = false;
                        MostraVistaSemplice();
                    }
                    else
                    {
                        var allegatiProtocollatiCollectionProvider = new AllegatiProtocollatiCollectionProvider();

                        Protocollo doc = new Protocollo();
                        ArchivioFileCollection docs = doc.AF_RicercaProtocolloSingolo(_segnatura, true);
                        if (docs == null)
                            throw new SiarException(TextErrorCodes.DocumentoNonValido);

                        foreach (ArchivioFile archivioFile in docs)
                            archivioFile.AdditionalAttributes.Add("Segnatura", _segnatura);

                        foreach (SegnatureMultiple segnaturaMultipla in segnatureMultipleCollection)
                        {
                            doc = new Protocollo();
                            ArchivioFileCollection docsSecondaria = doc.AF_RicercaProtocolloSingolo(segnaturaMultipla.SegnaturaSecondaria, true);
                            if (docsSecondaria == null)
                                throw new SiarException(TextErrorCodes.DocumentoNonValido);

                            foreach (ArchivioFile archivioFile in docsSecondaria)
                                archivioFile.AdditionalAttributes.Add("Segnatura", segnaturaMultipla.SegnaturaSecondaria);

                            docs.AddCollection(docsSecondaria);
                        }

                        SegnatureMultiple segnaturaPrincipale = new SegnatureMultiple();
                        segnaturaPrincipale.Ordine = 0;
                        segnaturaPrincipale.SegnaturaPrincipale = segnaturaPrincipale.SegnaturaSecondaria = _segnatura;
                        segnatureMultipleCollection.Insert(0, segnaturaPrincipale);

                        dgVistaSemplice.DataSource = docs;
                        dgVistaSemplice.ItemDataBound += new DataGridItemEventHandler(dgVistaSemplice_ItemDataBound);
                        dgVistaSemplice.DataBind();
                        lblNrVistaSemplice.Text = "Selezionare il documento desiderato per aprirlo (" + docs.Count + " documenti)";

                        dgElencoSegnature.DataSource = segnatureMultipleCollection;
                        dgElencoSegnature.ItemDataBound += new DataGridItemEventHandler(dgElencoSegnature_ItemDataBound);
                        dgElencoSegnature.DataBind();
                        lblNrElencoSegnature.Text = "Selezionare il protocollo per filtrare gli allegati (" + segnatureMultipleCollection.Count + " protocolli)";

                        dgVistaAvanzata.DataSource = docs;
                        dgVistaAvanzata.ItemDataBound += new DataGridItemEventHandler(dgVistaAvanzata_ItemDataBound);
                        dgVistaAvanzata.DataBind();
                        lblNrVistaAvanzata.Text = "Selezionare il documento desiderato per aprirlo (" + docs.Count + " documenti)";

                        Session["siar_view_file"] = docs;
                    }
                }
            }
            catch (Exception ex) 
            {
                txtErrore.Visible = true;
                txtErrore.Value = ex.Message;
                //((PrivatePage)Page).ShowError(ex.Message); 
            }

            base.OnPreRender(e);
        }

        protected void MostraVistaSemplice()
        {
            divVistaAvanzata.Visible = false;

            Protocollo doc = new Protocollo();
            ArchivioFileCollection docs = doc.AF_RicercaProtocollo(_segnatura, true);
            if (docs == null)
                throw new SiarException(TextErrorCodes.DocumentoNonValido);

            Session["siar_view_file"] = docs;

            dgVistaSemplice.DataSource = docs;
            dgVistaSemplice.ItemDataBound += new DataGridItemEventHandler(dgVistaSemplice_ItemDataBound);
            dgVistaSemplice.DataBind();
            lblNrVistaSemplice.Text = "Selezionare il documento desiderato per aprirlo (" + docs.Count + " documenti)";
        }

        protected void btnChiudi_Click(object sender, EventArgs e)
        {
            _segnatura = null;
            ((PrivatePage)Page).RegisterClientScriptBlock("chiudiPopupTemplate();");
        }

        void dgVistaSemplice_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;

            if (dgi.ItemType != ListItemType.Header && dgi.ItemType != ListItemType.Footer)
            {
                ArchivioFile archivioFile = (ArchivioFile)dgi.DataItem;

                if (dgi.ItemIndex == 0)
                    dgi.Cells[0].Text = "Documento principale";
                else
                    dgi.Cells[0].Text = "Allegato " + dgi.ItemIndex;

                e.Item.Cells[4].Text = dgi.ItemIndex.ToString();
            }
        }

        void dgElencoSegnature_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;

            if (dgi.ItemType != ListItemType.Header && dgi.ItemType != ListItemType.Footer)
            {
                SegnatureMultiple segnatureMultiple = (SegnatureMultiple)dgi.DataItem;

                if (dgi.ItemIndex == 0)
                    dgi.Cells[0].Text = "Segnatura principale";
                else
                    dgi.Cells[0].Text = segnatureMultiple.Ordine.ToString();
            }
        }

        void dgVistaAvanzata_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;

            if (dgi.ItemType != ListItemType.Header && dgi.ItemType != ListItemType.Footer)
            {
                ArchivioFile archivioFile = (ArchivioFile)dgi.DataItem;

                if (dgi.ItemIndex == 0)
                    dgi.Cells[0].Text = "Documento principale";
                else
                    dgi.Cells[0].Text = "Allegato " + dgi.ItemIndex;

                e.Item.Cells[4].Text = dgi.ItemIndex.ToString();
                e.Item.Cells[5].Text = archivioFile.AdditionalAttributes["Segnatura"].ToString();
            }
        }
    }
}