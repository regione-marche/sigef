using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;

namespace web.CONTROLS
{
    public partial class DatiDomanda : SiarLibrary.Web.SigefUserControl
    {
        private SiarLibrary.Bando _bando;
        public SiarLibrary.Bando Bando
        {
            get { return _bando; }
            set { _bando = value; }
        }

        private SiarLibrary.Progetto _progetto;
        public SiarLibrary.Progetto Progetto
        {
            get { return _progetto; }
            set { _progetto = value; }
        }

        private SiarLibrary.Impresa _impresa;
        public SiarLibrary.Impresa Impresa
        {
            get { return _impresa; }
            //set { _impresa = value; }
        }

        private SiarLibrary.ProgettoSegnatureCollection _segnatureProgetto;
        public SiarLibrary.ProgettoSegnatureCollection SegnatureProgetto
        {
            get
            {
                if (_segnatureProgetto == null) _segnatureProgetto = new SiarBLL.ProgettoSegnatureCollectionProvider().Find(_progetto.IdProgetto, null, null, null);
                return _segnatureProgetto;
            }
        }

        private SiarLibrary.ProgettoStoricoCollection _storicoProgetto;
        public SiarLibrary.ProgettoStoricoCollection StoricoProgetto
        {
            get
            {
                if (_storicoProgetto == null) _storicoProgetto = new SiarBLL.ProgettoStoricoCollectionProvider().Find(_progetto.IdProgetto, null, "A");
                return _storicoProgetto;
            }
        }

        private SiarLibrary.NullTypes.BoolNT _domandaInRiesame;
        public SiarLibrary.NullTypes.BoolNT DomandaInRiesame
        {
            get
            {
                if (_domandaInRiesame == null)
                {
                    SiarLibrary.ProgettoSegnatureCollection riesami = SegnatureProgetto.FiltroLikeTipoSegnatura("RID");
                    _domandaInRiesame = (_progetto.CodFase == "A" && riesami.Count > 0 && riesami[0].RiapriDomanda &&
                        StoricoProgetto.FiltroRevisioneRiesameRicorso(null, true, null).Count == 0);
                }
                return _domandaInRiesame;
            }
            set { _domandaInRiesame = value; }
        }

        private SiarLibrary.NullTypes.BoolNT _domandaInRevisione;
        public SiarLibrary.NullTypes.BoolNT DomandaInRevisione
        {
            get
            {
                if (_domandaInRevisione == null)
                {
                    SiarLibrary.ProgettoSegnatureCollection revisioni = SegnatureProgetto.FiltroLikeTipoSegnatura("REV");
                    _domandaInRevisione = (_progetto.CodFase == "A" && revisioni.Count > 0 && revisioni[0].RiapriDomanda &&
                        StoricoProgetto.FiltroRevisioneRiesameRicorso(true, null, null).Count == 0);
                }
                return _domandaInRevisione;
            }
            set { _domandaInRevisione = value; }
        }

        private SiarLibrary.NullTypes.BoolNT _domandaInRicorso;
        public SiarLibrary.NullTypes.BoolNT DomandaInRicorso
        {
            get
            {
                if (_domandaInRicorso == null)
                {
                    SiarLibrary.ProgettoSegnatureCollection ricorsi = SegnatureProgetto.FiltroLikeTipoSegnatura("RIC");
                    _domandaInRicorso = (_progetto.CodFase == "A" && ricorsi.Count > 0 &&
                        StoricoProgetto.FiltroRevisioneRiesameRicorso(null, null, true).Count == 0);
                }
                return _domandaInRicorso;
            }
            set { _domandaInRicorso = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private bool _datiCaricati = false;
        public bool ForzaCaricamentoDati = false;
        public void loadData()
        {
            if (!_datiCaricati || ForzaCaricamentoDati)
            {
                if (Page is SiarLibrary.Web.ProgettoPage)
                {
                    _progetto = ((SiarLibrary.Web.ProgettoPage)Page).Progetto;
                    _bando = ((SiarLibrary.Web.ProgettoPage)Page).Bando;
                    _impresa = ((SiarLibrary.Web.ProgettoPage)Page).Azienda;
                }
                else if (Page is SiarLibrary.Web.ModificaPage)
                {
                    _progetto = ((SiarLibrary.Web.ModificaPage)Page).Progetto;
                    _bando = new SiarBLL.BandoCollectionProvider().GetById(_progetto.IdBando);
                    _impresa = new SiarBLL.ImpresaCollectionProvider().GetById(_progetto.IdImpresa);
                }
                else if (_progetto != null)
                {
                    _bando = new SiarBLL.BandoCollectionProvider().GetById(_progetto.IdBando);
                    _impresa = new SiarBLL.ImpresaCollectionProvider().GetById(_progetto.IdImpresa);
                }
                // presentazione
                SiarLibrary.ProgettoStoricoCollection stato_presentazione = new SiarBLL.ProgettoStoricoCollectionProvider().Find(_progetto.IdProgetto, "L", null);

                if (stato_presentazione.Count > 0) { lblOperatore.Text = stato_presentazione[0].Nominativo; lblModifica.Text = stato_presentazione[0].Data.ToString("dd/MM/yyyy HH:mm"); ucSNCVisualizzaProtocollo.Segnatura = stato_presentazione[0].Segnatura; }
                else { lblOperatore.Text = _progetto.Nominativo; lblModifica.Text = _progetto.Data.ToString("dd/MM/yyyy HH:mm"); ucSNCVisualizzaProtocollo.Segnatura = _progetto.Segnatura; }
                lblNumero.Text = _progetto.IdProgetto;
                lblCodiceCUP.Text = _progetto.CodAgea;
                lblStato.Text = (DomandaInRevisione ? "revisione in corso" : (DomandaInRiesame ? "riesame in corso" :
                        (DomandaInRicorso ? "istruttoria di ricorso" : _progetto.Stato.Value)));

                if (_impresa == null) _impresa = new SiarBLL.ImpresaCollectionProvider().GetById(_progetto.IdImpresa);
                if (_impresa != null)
                {
                    lblCodiceFiscale.Text = _impresa.CodiceFiscale;
                    lblRagioneSociale.Text = _impresa.RagioneSociale;
                    btnSezioneImpresa.Attributes.Add("onclick", "location='../Impresa/ImpresaDomande.aspx?idimp=" + _impresa.IdImpresa + "'");
                }

                lnkDocumentiBando.HRef = "javascript:mostraPopupDocumentiBando(" + _bando.IdBando + ")";
                lblScadenzaBando.Text = _bando.DataScadenza;
                if (_bando.DataScadenza < DateTime.Now) lblScadenzaBando.Style.Add("color", "red");
                lblIdBando.Text = _bando.IdBando;
                lblDescBando.Text = _bando.Descrizione;

                if (stato_presentazione.Count == 0) ucVRRicevutaProtocollazione.ReportViewOptions = web.CONTROLS.SNCOptions.ViewOption.Invisibile;
                else
                {
                    ucVRRicevutaProtocollazione.ReportName = "rptFrontespizio";
                    ucVRRicevutaProtocollazione.ReportParameters = "ID_Domanda=" + _progetto.IdProgetto;
                }

                // blocco della visualizzazione dei dati della domanda in istruttoria per utenti esterni
                string cod_ente_operatore = ((SiarLibrary.Web.PrivatePage)Page).Operatore.Utente.CodEnte;
                if (cod_ente_operatore != "%" && cod_ente_operatore != Bando.CodEnte && 
                    (Progetto.CodStato == "I" || DomandaInRevisione || DomandaInRiesame || DomandaInRicorso))
                {
                    ucVRDomandaAttuale.ReportViewOptions = web.CONTROLS.SNCOptions.ViewOption.Invisibile;

                    btnApriDomanda.Visible = false;

                    tdLinks.InnerHtml = "<br /> "
                        + "<div style='text-align:center;font-weight:bold;color:red;display:inline-block;'> "
                        + "Attenzione! La domanda è non accessibile finché è in corso l`istruttoria. "
                        + "</div> ";
                    
                    if (Page is SiarLibrary.Web.ProgettoPage 
                        && Page.AppRelativeVirtualPath.ToLower() != "~/private/pdomanda/comunicazioni.aspx" && Page.AppRelativeVirtualPath.ToLower() != "~/private/pdomanda/riepilogodomanda.aspx")
                    {
                        ((SiarLibrary.Web.PrivatePage)Page).Redirect("RicercaDomanda.aspx", "Non è possibile visualizzare la domanda selezionata perchè è ancora in corso l'istruttoria.", true);
                        return;
                    }
                }
                else
                {

                    SiarLibrary.ModelloDomanda md = new SiarBLL.ModelloDomandaCollectionProvider().GetById(_bando.IdModelloDomanda);
                    if (md != null)
                    {
                        ucVRDomandaAttuale.ReportName = "rptModelloDomanda" + md.IdDomanda;
                        ucVRDomandaAttuale.ReportParameters = "ID_Domanda=" + _progetto.IdProgetto;
                    }
                }

                var cup_doppi = new SiarBLL.ProgettoCollectionProvider().GetProgettiCupDoppi(_progetto.IdProgetto, _progetto.CodAgea);
                if (cup_doppi.Count > 0)
                {
                    trCupDoppi.Visible = true;
                    string prog_cup = string.Empty;
                    foreach (int item in cup_doppi)
                    {
                        prog_cup += item.ToString() + ", ";
                    }
                    prog_cup = prog_cup.Remove(prog_cup.LastIndexOf(","));
                    lblCupDoppi.Text = prog_cup;
                }
                else
                {
                    trCupDoppi.Visible = false;
                }


                if (_progetto.CodStato == "P")
                    tdComunicazioni.Visible = false;
                else
                    tdComunicazioni.Visible = true;
                //if (_bando.Aggregazione)
                //    tdAggregazione.Visible = true;
                //else
                //    tdAggregazione.Visible = false;

                _datiCaricati = true;
            }
        }
    }
}