using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using RnaManager;
using SiarBLL;
using SiarLibrary;
using SiarLibrary.Web;
using System.Linq;

namespace web.CONTROLS
{
    public partial class ucVisure : System.Web.UI.UserControl
    {
        private Progetto _progetto;
        public Progetto Progetto
        {
            get { return _progetto; }
            set { _progetto = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //imgMostraVisure.Attributes.Add("src", VirtualPathUtility.ToAbsolute("~/Images/") + "ArrowUpSolid.png");
            bool utenteRnaAbilitato = false;
            RnaEntiCollectionProvider rnaEntiCollectionProvider = new RnaEntiCollectionProvider();
            RnaEntiCollection rnaEntiCollection = rnaEntiCollectionProvider.FindCodEnte(((PrivatePage)Page).Operatore.Utente.CodEnte);

            foreach(RnaEnti rnaEnte in rnaEntiCollection)
                if (rnaEnte.Abilitato && rnaEnte.CredenzialiProduzione)
                    utenteRnaAbilitato = true;

            divVisure.Visible = utenteRnaAbilitato ? true : false;

        }

        protected override void OnPreRender(EventArgs e)
        {
            caricaDgVisure(Progetto.IdProgetto);

            base.OnPreRender(e);
        }

        #region Visure
        enum statoVisura
        {
            darichiedere,
            daVerificare,
            daScaricare,
            errore
        }
        enum tipoVisura
        {
            deggendorf,
            deminimis,
            aiuti
        }

        //private statoVisura getStatoVisura(int idProgetto, int idImpresa, string tipoV)
        //{
        //    statoVisura result;
        //                if (vrnaEsitoVisura == null)
        //        result = statoVisura.darichiedere;
        //    else
        //        result = statoVisura.daScaricare;
        //    return result;
        //}
        private void caricaDgVisure(int idProgetto)
        {

            SiarBLL.VimpreseXProgettoCollectionProvider vimpreseXProgettoCollectionProvider = new SiarBLL.VimpreseXProgettoCollectionProvider();
            SiarLibrary.VimpreseXProgettoCollection vimpreseXProgettoCollection = vimpreseXProgettoCollectionProvider.Find(idProgetto);
            dgDownloadVisure.Visible = true;
            dgDownloadVisure.DataSource = vimpreseXProgettoCollection;
            dgDownloadVisure.ItemDataBound += new DataGridItemEventHandler(dgVisure_ItemDataBound);
            dgDownloadVisure.DataBind();
        }

        void dgVisure_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                VimpreseXProgetto impreseXProgetto = (VimpreseXProgetto)dgi.DataItem;
                VrnaEsitoVisureCollection vRnaEsitoVisureCollection = new VrnaEsitoVisureCollectionProvider().Find(null, impreseXProgetto.IdProgetto, impreseXProgetto.IdImpresa, null, null);
                VrnaEsitoVisure vRnaEsitoVisura;
                RnaLogVisureCollectionProvider rnaLogVisureCollectionProvider = new RnaLogVisureCollectionProvider();
                RnaLogVisureCollection rnaLogVisureCollection = new RnaLogVisureCollection();
                //aiuti
                var visureAiuti = vRnaEsitoVisureCollection.ToArrayList<SiarLibrary.VrnaEsitoVisure>().Where(x => x.TipoVisura == tipoVisura.aiuti.ToString()).ToList<VrnaEsitoVisure>();
                vRnaEsitoVisura = visureAiuti.FirstOrDefault(x => x.IdRichiesta == visureAiuti.Max(w => int.Parse(w.IdRichiesta)).ToString());
                if (vRnaEsitoVisura != null)
                    if (vRnaEsitoVisura.DescrizioneStatoRichiesta == "Completata")
                    {
                        rnaLogVisureCollection = rnaLogVisureCollectionProvider.Find(null, null, null, vRnaEsitoVisura.IdRichiesta, null, null, null, null, null);
                        dgi.Cells[2].Text = string.Format("<a href=\"javascript:fnRNAScaricaVisura({0})\">Scarica Visura</a>", rnaLogVisureCollection[0].IdArchivioFile);
                    }
                    else
                    {
                        dgi.Cells[2].Text = string.Format("<a href=\"javascript:richiediVisura({0},{1},{2},this)\">Verifica Visura</a>", "'verificaVisura'", impreseXProgetto.IdImpresa, "'aiuti'");
                    }

                //De Minimis
                var visureDeMinimis = vRnaEsitoVisureCollection.ToArrayList<SiarLibrary.VrnaEsitoVisure>().Where(x => x.TipoVisura == tipoVisura.deminimis.ToString()).ToList<VrnaEsitoVisure>();
                vRnaEsitoVisura = visureDeMinimis.FirstOrDefault(x => x.IdRichiesta == visureDeMinimis.Max(w => int.Parse(w.IdRichiesta)).ToString());
                if (vRnaEsitoVisura != null)
                    if (vRnaEsitoVisura.DescrizioneStatoRichiesta == "Completata")
                    {
                        rnaLogVisureCollection = rnaLogVisureCollectionProvider.Find(null, null, null, vRnaEsitoVisura.IdRichiesta, null, null, null, null, null);
                        dgi.Cells[3].Text = string.Format("<a href=\"javascript:fnRNAScaricaVisura({0})\">Scarica Visura</a>", rnaLogVisureCollection[0].IdArchivioFile);
                    }
                    else
                    {
                        dgi.Cells[3].Text = string.Format("<a href=\"javascript:richiediVisura({0},{1},{2},this)\">Verifica Visura</a>", "'verificaVisura'", impreseXProgetto.IdImpresa, "'deminimis'");
                    }

                //Deggendorf
                var visureDeggendorf = vRnaEsitoVisureCollection.ToArrayList<SiarLibrary.VrnaEsitoVisure>().Where(x => x.TipoVisura == tipoVisura.deggendorf.ToString()).ToList<VrnaEsitoVisure>();
                vRnaEsitoVisura = visureDeggendorf.FirstOrDefault(x => x.IdRichiesta == visureDeggendorf.Max(w => int.Parse(w.IdRichiesta)).ToString());
                if (vRnaEsitoVisura != null)
                    if (vRnaEsitoVisura.DescrizioneStatoRichiesta == "Completata")
                    {
                        rnaLogVisureCollection = rnaLogVisureCollectionProvider.Find(null, null, null, vRnaEsitoVisura.IdRichiesta, null, null, null, null, null);
                        dgi.Cells[4].Text = string.Format("<a href=\"javascript:fnRNAScaricaVisura({0})\">Scarica Visura</a>", rnaLogVisureCollection[0].IdArchivioFile);
                    }
                    else
                    {
                        dgi.Cells[4].Text = string.Format("<a href=\"javascript:richiediVisura({0},{1},{2},this)\">Verifica Visura</a>", "'verificaVisura'", impreseXProgetto.IdImpresa, "'deggendorf'");
                    }

                dgi.Cells[5].Text = string.Format("<select id='cmbTipoVisura_{0}'><option value = \"aiuti\"> Aiuti </option><option value = \"deminimis\"> De Minimis </option><option value = \"deggendorf\"> Deggendorf </option></ select>", impreseXProgetto.IdImpresa);
                dgi.Cells[6].Text = dgi.Cells[6].Text.Replace("richiediVisura(this);", string.Format("richiediVisura({0},{1},'',this);", "'richiedi'", impreseXProgetto.IdImpresa));
            }
        }
        protected void btnDownloadVisura_Click(object sender, EventArgs e)
        {
            string azioneVisura = hdnAzioneVisura.Value;
            string tipoVisura = hdnTipoVisura.Value;
            int idImpresa = int.Parse(hdnIdImpresa.Value);
            //var rnaBando = new RnaBandoConfigCollectionProvider().Select(null, Progetto.IdBando, null, null, null, null, null)[0];

            RnaEntiCollectionProvider rnaEntiCollectionProvider = new RnaEntiCollectionProvider();
            RnaEntiCollection rnaEntiCollection = rnaEntiCollectionProvider.FindCodEnte(((PrivatePage)Page).Operatore.Utente.CodEnte);
            RnaEnti rnaEnte = null;
            foreach(RnaEnti ente in rnaEntiCollection)
            {
                if(ente.Abilitato && ente.CredenzialiProduzione)
                {
                    if (rnaEnte == null)
                        rnaEnte = ente;
                    else
                    {
                        if (ente.DataPassword > rnaEnte.DataPassword)
                            rnaEnte = ente;
                    }
                }
            }
            RnaOperazioni rnaOp = new RnaOperazioni(rnaEnte.IdRnaEnte);
            ResultInfoVisura risVisura;
            RnaLogVisureCollectionProvider rnaLogVisureCollectionProvider = new RnaLogVisureCollectionProvider();
            RnaLogVisureCollection rnaLogVisureCollection;
            ArchivioFileCollectionProvider archivioFileCollectionProvider = new ArchivioFileCollectionProvider();
            SiarLibrary.Impresa imp = new SiarBLL.ImpresaCollectionProvider().GetById(idImpresa);
            switch (azioneVisura)
            {
                case "richiedi":

                    ProjectInfo projectInfo = new ProjectInfo()
                    {
                        IdProgetto = Progetto.IdProgetto,
                        IdImpresa = idImpresa,
                        IdFiscaleImpresa = imp.Cuaa,
                        IdOperatore = ((PrivatePage)Page).Operatore.Utente.IdUtente
                    };

                    switch (tipoVisura)
                    {
                        case "aiuti":

                            var resultAiuti = rnaOp.RequestVisuraAiuti(projectInfo, new DateTime(DateTime.Now.Year - 10, DateTime.Now.Month, DateTime.Now.Day));
                            if (resultAiuti.DescrizioneEsito == "Autenticazione non valida")
                                ((PrivatePage)Page).ShowError("Credenziali RNA Errate, il suo ente deve prima essere abilitato per l'invio al servizio RNA. ");
                            else
                                ((PrivatePage)Page).ShowMessage("Richiesta Inviata Correttamente");
                            break;

                        case "deminimis":
                            var resultDeminimis = rnaOp.RequestVisuraDeminimis(projectInfo, new DateTime(DateTime.Now.Year, 12, 31), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day));
                            if (resultDeminimis.DescrizioneEsito == "Autenticazione non valida")
                                ((PrivatePage)Page).ShowError("Credenziali RNA Errate, il suo ente deve prima essere abilitato per l'invio al servizio RNA. ");
                            else
                                ((PrivatePage)Page).ShowMessage("Richiesta Inviata Correttamente");
                            break;

                        case "deggendorf":
                            var resultDeggendorf = rnaOp.RequestVisuraDeggendorf(projectInfo);
                            if (resultDeggendorf.DescrizioneEsito == "Autenticazione non valida")
                                ((PrivatePage)Page).ShowError("Credenziali RNA Errate, il suo ente deve prima essere abilitato per l'invio al servizio RNA. ");
                            else
                                ((PrivatePage)Page).ShowMessage("Richiesta Inviata Correttamente");
                            break;
                    }

                    break;

                case "verificaVisura":

                    rnaLogVisureCollection = rnaLogVisureCollectionProvider.Find(null, Progetto.IdProgetto, idImpresa, null, tipoVisura, null, null, null, null);
                    RnaLogVisure visura = rnaLogVisureCollection.ToArrayList<RnaLogVisure>().FirstOrDefault(x => x.DataInserimento == rnaLogVisureCollection.ToArrayList<RnaLogVisure>().Max(w => w.DataInserimento));
                    if (rnaLogVisureCollection != null)
                    {
                        risVisura = rnaOp.GetVisura(visura.IdRichiesta);
                        if (risVisura.DescrizioneEsito == "Autenticazione non valida")
                        { ((PrivatePage)Page).ShowError("Credenziali RNA Errate, il suo ente deve prima essere abilitato per l'invio al servizio RNA. "); }
                        else
                        {
                            if (risVisura.DescrizioneEsito == "Richiesta elaborata correttamente")
                            {
                                rnaLogVisureCollection = rnaLogVisureCollectionProvider.Find(null, Progetto.IdProgetto, idImpresa, null, tipoVisura, null, null, null, null);
                                visura = rnaLogVisureCollection.ToArrayList<RnaLogVisure>().FirstOrDefault(x => x.DataInserimento == rnaLogVisureCollection.ToArrayList<RnaLogVisure>().Max(w => w.DataInserimento));
                                string nome = tipoVisura.ToUpper() + "_" + Progetto.IdProgetto.ToString() + "_" + visura.IdFiscaleImpresa;
                                ArchivioFile archivioFile = new ArchivioFile()
                                {
                                    Tipo = "application/pdf",
                                    Dimensione = 1,
                                    NomeFile = nome,
                                    NomeCompleto = visura.IdRichiesta,
                                    Contenuto = risVisura.PayloadEsito
                                };

                                archivioFileCollectionProvider.Save(archivioFile);
                                ArchivioFileCollection archivioFileCollection = archivioFileCollectionProvider.Find(null, nome, null);
                                rnaLogVisureCollection = rnaLogVisureCollectionProvider.Find(null, Progetto.IdProgetto, idImpresa, null, tipoVisura, null, null, null, null);
                                archivioFile = archivioFileCollection.ToArrayList<ArchivioFile>().FirstOrDefault(x => x.NomeCompleto == visura.IdRichiesta);
                                visura.IdArchivioFile = archivioFile.Id;
                                rnaLogVisureCollectionProvider.Save(visura);
                                ((PrivatePage)Page).ShowMessage("La visura è pronta per il download");
                            }
                            else
                                ((PrivatePage)Page).ShowError(risVisura.DescrizioneEsito);
                        }
                    }

                    else
                        throw new Exception("Richiesta non trovata");
                    break;

                case "scaricaAiuti":

                    rnaLogVisureCollection = rnaLogVisureCollectionProvider.Find(null, Progetto.IdProgetto, idImpresa, null, "aiuti", null, null, null, null);
                    if (rnaLogVisureCollection != null)
                    {
                        risVisura = rnaOp.GetVisura(rnaLogVisureCollection[0].IdRichiesta);
                        //download visura
                    }
                    else
                        ((PrivatePage)Page).ShowError("C'è stato un problema con la richiesta effettuata, si prega di ritentare. In caso il problema persista contattare l'helpdesk");
                    break;
            }

        }
        #endregion
    }
}