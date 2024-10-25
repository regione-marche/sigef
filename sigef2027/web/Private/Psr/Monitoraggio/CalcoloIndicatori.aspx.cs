using System;
using SiarLibrary;
using SiarBLL;


namespace web.Private.Psr.Monitoraggio
{
    public partial class CalcoloIndicatori : SiarLibrary.Web.PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "psr_mon_calc_indic";
            base.OnPreInit(e);
        }

        ZdimensioniEstrazioniIoCollectionProvider dec_provider = new ZdimensioniEstrazioniIoCollectionProvider();
        ZdimensioniEstrazioniIoCollection de_selezionata = null;

        ZdimensioniEstrazioniTCollectionProvider deT_provider = new ZdimensioniEstrazioniTCollectionProvider();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            cmbPsr.DataBind();

            if (!string.IsNullOrEmpty(cmbPsr.SelectedValue))
            {
                Alimenta_cmbAnno(cmbPsr.SelectedValue);
            }
            if (!string.IsNullOrEmpty(cmbAnno.SelectedValue) &&
               (!string.IsNullOrEmpty(cmbPsr.SelectedValue)))
            {
                try
                {
                    de_selezionata = dec_provider.Find(cmbPsr.SelectedValue, int.Parse(cmbAnno.SelectedValue));
                    if (de_selezionata == null || de_selezionata.Count == 0)
                    {
                        // de_selezionata = dec_provider.GetNewIndicatori(cmbPsr.SelectedValue, int.Parse(cmbAnno.SelectedValue));
                        de_selezionata = dec_provider.GetIndicatoriVuoti(cmbPsr.SelectedValue, int.Parse(cmbAnno.SelectedValue));
                        //     btnSalva.Enabled = true;
                        btnBlocca.Enabled = false;
                        btnRicalcola.Enabled = true;
                    }
                    else
                    {
                        //  btnSalva.Enabled = false;

                        if (de_selezionata[0].Bloccato == false)
                        {
                            btnBlocca.Enabled = true;
                            btnRicalcola.Enabled = true;
                        }
                        else
                        {
                            btnBlocca.Enabled = false;
                            btnRicalcola.Enabled = false;
                        }
                    }
                    tbCalcIndic.Visible = true;
                    dgCalcIndic.DataSource = de_selezionata;
                    dgCalcIndic.DataBind();
                    if (cmbPsr.SelectedValue == "POR20142020")
                    {
                        divDownloadRptIN01.Visible = true;
                        btnDownloadRptIN01.Attributes.Add("onclick", "SNCVisualizzaReport('rptIN01_Output',2,'');");
                    }
                    else if (cmbPsr.SelectedValue == "PORFESR20212027")
                    {
                        divDownloadRptIN01.Visible = true;
                        btnDownloadRptIN01.Attributes.Add("onclick", "SNCVisualizzaReport('rptIN01_Output_2127',2,'');");
                    }
                    else
                        divDownloadRptIN01.Visible = false;
                }
                catch (Exception ex)
                {
                    ShowError(ex.Message);
                }
            }

            base.OnPreRender(e);
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbAnno.SelectedValue) &&
               (!string.IsNullOrEmpty(cmbPsr.SelectedValue)))
            {
                int i_anno = int.Parse(cmbAnno.SelectedValue);

                try
                {
                    int risultato = SalvaIndicatori(cmbPsr.SelectedValue, i_anno);
                    ShowMessage("Calcolo indicatori salvato correttamente");
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
        }

        protected void btnBlocca_Click(object sender, EventArgs e)
        {
            try
            {
                int i_anno = int.Parse(cmbAnno.SelectedValue);
                int risultato = BloccaIndicatori(cmbPsr.SelectedValue, i_anno);
                ShowMessage("Indicatori bloccati correttamente");
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        protected void btnRicalcola_Click(object sender, EventArgs e)
        {
            try
            {
                de_selezionata = dec_provider.Find(cmbPsr.SelectedValue, int.Parse(cmbAnno.SelectedValue));
                if (de_selezionata != null && de_selezionata.Count > 0)
                {
                    de_selezionata.DeleteCollection();
                }
                de_selezionata = dec_provider.GetNewIndicatori(cmbPsr.SelectedValue, int.Parse(cmbAnno.SelectedValue));
                int risultato = SalvaIndicatori(cmbPsr.SelectedValue, int.Parse(cmbAnno.SelectedValue));
                //btnSalva.Enabled = true;
                btnBlocca.Enabled = true;
                btnRicalcola.Enabled = false;
                dgCalcIndic.DataBind();

                //int risultato = SalvaIndicatori(cmbPsr.SelectedValue, int.Parse(cmbAnno.SelectedValue));
                //btnSalva.Enabled = true;
                //btnBlocca.Enabled = false;
                //btnRicalcola.Enabled = false;

                ShowMessage("Indicatori ricalcolati correttamente");
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }

        }

        private int SalvaIndicatori(string id_prs, int i_anno)
        {
            DateTime dtInizio = new DateTime(i_anno, 01, 01, 0, 0, 0);
            DateTime dtFine = new DateTime(i_anno, 12, 31, 23, 59, 59);

            de_selezionata = dec_provider.GetNewIndicatori(id_prs, i_anno);
            if (de_selezionata.Count > 0)
            {
                try
                {
                    ZdimensioniEstrazioniTCollectionProvider dimTp = new ZdimensioniEstrazioniTCollectionProvider();
                    ZdimensioniEstrazioniTCollection dimTc;
                    ZdimensioniEstrazioniT dimT;

                    ZdimensioniEstrazioniIoCollectionProvider dimIOp = new ZdimensioniEstrazioniIoCollectionProvider();
                    ZdimensioniEstrazioniIo dimIO;
                    int i = 0;
                    int id_estraz = 0;
                    foreach (ZdimensioniEstrazioniIo estraz in de_selezionata)
                    {
                        if (i == 0)
                        {
                            dimTc = dimTp.Find(id_prs, i_anno, "IO");
                            if (dimTc == null || dimTc.Count == 0)
                            {
                                dimT = new SiarLibrary.ZdimensioniEstrazioniT();
                                dimT.DataInizio = dtInizio;
                                dimT.DataFine = dtFine;
                                dimT.CodPsr = id_prs;
                                dimT.Bloccato = false;
                                dimT.TipoIndicatori = "IO";
                                dimT.MarkAsNew();
                                dimTp.Save(dimT);
                                id_estraz = dimT.IdEstrazione;
                            }
                            else
                            {
                                id_estraz = dimTc[0].IdEstrazione;
                            }
                        }
                        i++;
                        dimIO = new SiarLibrary.ZdimensioniEstrazioniIo();
                        //de.DataEstrazione = dtNow;
                        dimIO.DataEstrazione = DateTime.Now.ToString(); //hdnDtNow.Value;
                        dimIO.CodPsr = id_prs;
                        dimIO.IdEstrazione = id_estraz;
                        dimIO.IdDimPriorita = estraz.IdDimPriorita;
                        dimIO.Codpriorita = estraz.Codpriorita;
                        dimIO.Despriorita = estraz.Despriorita;
                        dimIO.IdDimIndicatore = estraz.IdDimIndicatore;
                        dimIO.Codindicatore = estraz.Codindicatore;
                        dimIO.ValoreRtot = estraz.ValoreRtot;
                        dimIO.ValorePf = estraz.ValorePf;
                        dimIO.ValoreF = estraz.ValoreF;
                        dimIO.DataPf = estraz.DataPf;
                        dimIO.DataF = estraz.DataF;
                        dimIOp.Save(dimIO);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return 0;
        }

        private int BloccaIndicatori(string id_prs, int i_anno)
        {
            try
            {
                ZdimensioniEstrazioniTCollectionProvider dimTp = new ZdimensioniEstrazioniTCollectionProvider();
                ZdimensioniEstrazioniTCollection dimTc = new ZdimensioniEstrazioniTCollection();
                ZdimensioniEstrazioniT dimT;

                dimTc = dimTp.Find(id_prs, i_anno, "IO");
                if (dimTc != null)
                {
                    dimT = dimTc[0];
                    dimT.Bloccato = true;
                    dimTp.Save(dimT);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return 0;

        }

        #region ComboBox

        private void Alimenta_cmbAnno(string codicePsr)
        {
            ZpsrCollectionProvider psrPro = new ZpsrCollectionProvider();
            Zpsr psr = new Zpsr();

            psr = psrPro.GetById(cmbPsr.SelectedValue);
            cmbAnno.SortDirection = SiarLibrary.Web.SortDirection.Asc;
            cmbAnno.AnnoDa = psr.AnnoDa;
            cmbAnno.AnnoA = psr.AnnoA;
            cmbAnno.DataBind();
        }

        #endregion

    }
}
