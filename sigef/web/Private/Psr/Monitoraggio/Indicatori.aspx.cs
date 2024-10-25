using System;
using System.Web.UI.WebControls;
using System.Linq;
using SiarLibrary;

namespace web.Private.Psr.Monitoraggio
{
    public partial class Indicatori : SiarLibrary.Web.PrivatePage
    {
        const int chkBoxIndicatori = 5;
        const int chkBoxInterventi = 3;

        SiarBLL.ZprogrammazioneCollectionProvider prog_provider = new SiarBLL.ZprogrammazioneCollectionProvider();
        SiarLibrary.Zprogrammazione interv_selezionato = null;

        SiarBLL.ZdimensioniXProgrammazioneCollectionProvider indic_provider = new SiarBLL.ZdimensioniXProgrammazioneCollectionProvider();
        SiarLibrary.ZdimensioniXProgrammazioneCollection ic = new SiarLibrary.ZdimensioniXProgrammazioneCollection();

        private enum Dimensioni
        {
            IOC,
            IOS,
            D1,
            D2,
            D3,
            D6,
            RG
        }

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "psr_mon_indic";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_intervento;
            if (int.TryParse(hdnIdIntervento.Value, out id_intervento))
            {
                interv_selezionato = prog_provider.GetById(id_intervento);
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            SiarLibrary.ZprogrammazioneCollection progs;
            SiarLibrary.ZdimensioniXProgrammazioneCollection dp;
            SiarLibrary.ZdimensioniXProgrammazioneCollection dptot;
            int iAzione;

            lstPsr.DataBind();

            // Selezione Psr
            if (!string.IsNullOrEmpty(lstPsr.SelectedValue))
            {
                tbAzioni.Visible = true;

                lstAzione.CodicePsr = lstPsr.SelectedValue;
                lstAzione.AttivazioneBandi = true;
                lstAzione.DataBind();

                // Selezione Azione
                if (!string.IsNullOrEmpty(lstAzione.SelectedValue))
                {
                    int.TryParse(lstAzione.SelectedValue, out iAzione);

                    // Selezione Tipologia Intervento
                    if (interv_selezionato != null &&
                        interv_selezionato.CodPsr == lstPsr.SelectedValue)
                    {
                        // consideriamo sia il terzo che quarto livello, nel caso sia presente
                        Zprogrammazione padreIntervento = prog_provider.GetById(interv_selezionato.IdPadre);

                        progs = new SiarLibrary.ZprogrammazioneCollection();

                        if (interv_selezionato.IdPadre == iAzione || (padreIntervento != null && padreIntervento.IdPadre == iAzione))
                        {
                            var listDim = Enum.GetValues(typeof(Dimensioni)).Cast<Dimensioni>();
                            // Visualizza solo il Tipo Intervento selezionato                            
                            progs.Add(interv_selezionato);
                            tbIndicatori.Visible = true;
                            // Visualizza gli Indicatori
                            dptot = indic_provider.GetIndicatoriIntervento(interv_selezionato.Id);
                            dp = new ZdimensioniXProgrammazioneCollection();
                            foreach (ZdimensioniXProgrammazione elem in dptot)
                            {
                                if (listDim.Any(x => x.ToString() == elem.CodDim))
                                    dp.Add(elem);
                            }
                            dgIndicatori.DataSource = dp;
                            dgIndicatori.ItemDataBound += new DataGridItemEventHandler(dgIndicatori_ItemDataBound);
                            dgIndicatori.DataBind();
                        }
                    }
                    else
                    {
                        // Visualizza tutti i Tipi Intervento dell'Azione
                        interv_selezionato = null;
                        hdnIdIntervento.Value = null;
                        progs = prog_provider.GetProgrammazionePsr(lstPsr.SelectedValue, lstAzione.SelectedValue, null, null, null, true, null);
                    }
                    if (!(progs.Count == 0))
                    {
                        dgInterventi.ItemDataBound += new DataGridItemEventHandler(dgInterventi_ItemDataBound);
                    }
                    tbInterventi.Visible = true;
                    dgInterventi.DataSource = progs;
                    dgInterventi.Titolo = "Tipi Intervento: ";
                    dgInterventi.DataBind();
                }
            }
            base.OnPreRender(e);
        }


        protected void btnSalva_Click(object sender, EventArgs e)
        {
            SiarBLL.ZdimensioniXProgrammazioneCollectionProvider dimensioniProg_provider = new SiarBLL.ZdimensioniXProgrammazioneCollectionProvider();
            SiarLibrary.ZdimensioniXProgrammazione dp;
            SiarLibrary.ZdimensioniXProgrammazioneCollection dpc;
            SiarBLL.ProgettoIndicatoriCollectionProvider progetto_indicatori_provider = new SiarBLL.ProgettoIndicatoriCollectionProvider();
            SiarLibrary.ProgettoIndicatoriCollection progetto_indicatori_collection = new SiarLibrary.ProgettoIndicatoriCollection();
            bool disattivato;
            string elenco_err = "";
            string[] selezionati = ((SiarLibrary.Web.CheckColumn)dgIndicatori.Columns[chkBoxIndicatori]).GetSelected();
            //Deselezionati: modifico
            SiarLibrary.ZdimensioniXProgrammazioneCollection dpcol = dimensioniProg_provider.Select(interv_selezionato.Id, null, null);

            //try
            //{


            for (int i = 0; i < dpcol.Count; i++)
            {
                // Altrimenti cancella abbinamenti Indicatori / Tipi Intervento di troppo
                if (!Enum.GetValues(typeof(Dimensioni)).Cast<Dimensioni>().Any(o => o.ToString() == dpcol[i].CodDim))
                {
                    continue;
                }
                disattivato = true;
                foreach (string s in selezionati)
                {
                    if (dpcol[i].IdDimensione.ToString() == s)
                    {
                        disattivato = false;
                    }
                }

                if (disattivato)
                {
                    progetto_indicatori_collection = progetto_indicatori_provider.GetBy_IdDimXProgrammazione(dpcol[i].IdDimXProgrammazione);
                    if (progetto_indicatori_collection.Count == 0)
                        dimensioniProg_provider.Delete(dpcol[i]);
                    else
                        elenco_err += string.Format("{0} - {1}, ", dpcol[i].CodDimensione, dpcol[i].CodDim);
                }
            }

            //decimal importo, importoPF;
            foreach (string s in selezionati)
            {
                //Selezionati: se esistono già update, altrimenti inserisco
                dpc = indic_provider.Select(interv_selezionato.Id, s, null);
                dp = new SiarLibrary.ZdimensioniXProgrammazione();
                if (dpc.Count == 0)
                {
                    //SiarLibrary.ZdimensioniXProgrammazione dp = new SiarLibrary.ZdimensioniXProgrammazione();
                    dp.IdDimensione = s;
                    dp.IdProgrammazione = interv_selezionato.Id;
                }
                else
                {
                    dp = dpc[0];
                }
                dimensioniProg_provider.Save(dp);
            }
            if (elenco_err == "")
                ShowMessage("Indicatori su Intervento salvati correttamente.");
            else
                ShowError(string.Format("Indicatori {0} collegati ad un progetto, non è stato possibile rimuoverli.", elenco_err));
            //}
            //catch (Exception ex) { ShowError(ex); }
        }

        protected void btnAzionePost_Click(object sender, EventArgs e)
        {
        }

        protected void btnInterventoPost_Click(object sender, EventArgs e)
        {
        }

        protected void dgInterventi_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (interv_selezionato != null)
                {
                    SiarLibrary.Zprogrammazione p = (SiarLibrary.Zprogrammazione)e.Item.DataItem;
                    if (p.Id == interv_selezionato.Id)
                    {
                        e.Item.Cells[chkBoxInterventi].Text = e.Item.Cells[chkBoxInterventi].Text.Replace("<input ", "<input checked ");
                    }
                }
                else
                {
                    e.Item.Cells[chkBoxInterventi].Text = e.Item.Cells[chkBoxInterventi].Text.Replace("checked", "");
                }
            }
        }

        protected void dgIndicatori_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.ZdimensioniXProgrammazione d = (SiarLibrary.ZdimensioniXProgrammazione)e.Item.DataItem;
                if (d.IdProgrammazione != null)
                {
                    e.Item.Cells[chkBoxIndicatori].Text = e.Item.Cells[chkBoxIndicatori].Text.Replace("<input ", "<input checked ");
                }
                else
                {
                    e.Item.Cells[chkBoxIndicatori].Text = e.Item.Cells[chkBoxIndicatori].Text.Replace("<input checked ", "<input ");
                }
            }
        }
    }
}
