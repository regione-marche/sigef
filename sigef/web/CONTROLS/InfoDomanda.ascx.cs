using System;
using System.Globalization;
using System.Collections.Generic;

namespace web.CONTROLS
{
    public partial class InfoDomanda : System.Web.UI.UserControl
    {
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

        private SiarLibrary.NullTypes.BoolNT _domandaInIstruttoriaProvinciale;
        public SiarLibrary.NullTypes.BoolNT DomandaInIstruttoriaProvinciale
        {
            get
            {
                if (_domandaInIstruttoriaProvinciale == null)
                {
                    _domandaInIstruttoriaProvinciale = (_progetto.CodFase == "A" && Progetto.RiaperturaProvinciale);
                }
                return _domandaInIstruttoriaProvinciale;
            }
            set { _domandaInIstruttoriaProvinciale = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            loadData();
        }

        public void loadData()
        {
            if (_progetto != null)
            {
                SiarLibrary.ProgettoStoricoCollection ps = new SiarBLL.ProgettoStoricoCollectionProvider().Find(_progetto.IdProgetto, "L", null);
                lblNumero.Text = _progetto.IdProgetto;
                lblCodiceCUP.Text = _progetto.CodAgea;
                lblStato.Text = (DomandaInRevisione ? "revisione in corso" : (DomandaInRiesame ? "riesame in corso" :
                    (DomandaInRicorso ? "istruttoria di ricorso" : _progetto.Stato.Value)));
                DateTime dateValue;

                if (ps.Count > 0)
                {
                    if (ps[0].Segnatura != null && ps[0].Segnatura.Value.Length > 4)
                    {
                        var segnatura = ps[0].Segnatura.ToString();
                        var data_segnatura_string = segnatura.Substring(segnatura.IndexOf("|", 0) + 1, 10);
                        if (DateTime.TryParseExact(data_segnatura_string, "dd/MM/yyyy", new CultureInfo("it-IT"), DateTimeStyles.None, out dateValue))
                            lblDataPresentazione.Text = data_segnatura_string;
                        ucSNCVPPDomanda.Segnatura = segnatura;
                    }
                }
                else
                {
                    if (Progetto.Segnatura != null && Progetto.Segnatura.Value.Length > 4)
                    {
                        var segnatura = Progetto.Segnatura.ToString();
                        var data_segnatura_string = segnatura.Substring(segnatura.IndexOf("|", 0) + 1, 10);
                        if (DateTime.TryParseExact(data_segnatura_string, "dd/MM/yyyy", new CultureInfo("it-IT"), DateTimeStyles.None, out dateValue))
                            lblDataPresentazione.Text = data_segnatura_string;
                        ucSNCVPPDomanda.Segnatura = Progetto.Segnatura;
                    }
                }

                _impresa = new SiarBLL.ImpresaCollectionProvider().GetById(_progetto.IdImpresa);
                if (_impresa != null)
                {
                    lblCodiceFiscale.Text = _impresa.CodiceFiscale;
                    lblRagioneSociale.Text = _impresa.RagioneSociale;
                }

                var cup_doppi = new SiarBLL.ProgettoCollectionProvider().GetProgettiCupDoppi(_progetto.IdProgetto, _progetto.CodAgea);
                if(cup_doppi.Count > 0)
                {
                    trCupDoppi.Visible = true;
                    string prog_cup = string.Empty;
                    foreach(int item in cup_doppi)
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

                ucVRDomandaAttuale.ReportName = "rptModelloDomanda" + new SiarBLL.ModelloDomandaCollectionProvider().Find(null, _progetto.IdBando, null)[0].IdDomanda;
                ucVRDomandaAttuale.ReportParameters = "ID_Domanda=" + _progetto.IdProgetto;
                ucVRRicevutaProtocollazione.ReportParameters = "ID_Domanda=" + _progetto.IdProgetto;
            }
        }
    }
}