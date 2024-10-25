using SianWebSrv.PSR;
using SiarLibrary;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace web.CONTROLS
{
    public partial class ProgettoIndicatori : System.Web.UI.UserControl
    {
        private const int    c_CalcoloIndicatore       = 4;
        private const int    cVal_ProgrammatoRichiesto = 5;
        private const int    cVal_ProgrammatoAmmesso   = 6;
        private const int    cVal_RealizzatoRichiesto  = 7;
        private const int    cVal_RealizzatoAmmesso    = 8;
        private const string cManuale   = "S";
        private const string cCalcolato = "N";

        public enum eIstruttoria { Si, No, ND };
        public enum eStato { Domanda, Pagamento, Variante, ND };

        private SiarLibrary.Progetto _progetto    = new SiarLibrary.Progetto();
        private bool                 _modificaDatiGenerale = false;
        private bool                 _pistaDiControllo = false;
        private eIstruttoria         _istruttoria = eIstruttoria.ND;
        private eStato               _stato       = eStato.ND;
        private string               _codTipo     = string.Empty;
        private int                  _operatore   = 0;
        private int                  _idDomanda;
        private int                  _idVariante;


        SiarLibrary.ProgettoIndicatoriCollection ProgettoIndColl = new SiarLibrary.ProgettoIndicatoriCollection();
        SiarBLL.ProgettoIndicatoriCollectionProvider pProv = new SiarBLL.ProgettoIndicatoriCollectionProvider();

        #region Properties

        public SiarLibrary.Progetto Progetto
        {
            get { return _progetto; }
            set { _progetto = value; }
        }

        public bool ModificaDatiGenerale
        {
            get { return _modificaDatiGenerale; }
            set { _modificaDatiGenerale = value; }
        }

        public bool PistaDiControllo
        {
            get { return _pistaDiControllo; }
            set { _pistaDiControllo = value; }
        }

        public eIstruttoria Istruttoria
        {
            get { return _istruttoria; }
            set { _istruttoria = value; }
        }

        public eStato StatoProgetto
        {
            get { return _stato; }
            set 
            { 
                _stato = value;
                switch (_stato)
                {
                    case eStato.Domanda:
                        _codTipo = "DOMANDA";
                        break;
                    case eStato.Pagamento:
                        _codTipo = "PAGAMENTO";
                        break;
                    case eStato.Variante:
                        _codTipo = "VARIANTE";
                        break;
                    case eStato.ND:
                        _codTipo = string.Empty;
                        break;
                }
            }
        }

        public int Operatore
        {
            get { return _operatore; }
            set { _operatore = value; }
        }

        public int IdDomanda
        {
            get { return _idDomanda; }
            set { _idDomanda = value; }
        }

        public int IdVariante
        {
            get { return _idVariante; }
            set { _idVariante = value; }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e) {}

        protected override void OnPreRender(EventArgs e)
        {
            if (StatoProgetto == eStato.Variante && IdVariante == 0)
            {
                throw new ArgumentNullException("IdVariante", @"Indicare l'id della variante");
            }
            if (StatoProgetto == eStato.Pagamento && IdDomanda == 0)
            {
                throw new ArgumentNullException("IdDomanda", @"Indicare l'id della domanda");
            }

            ProgettoIndColl = LeggiIndicatori();

            dgProgrammazione.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgProgrammazione_ItemDataBound);
            dgProgrammazione.DataSource = ProgettoIndColl;
            dgProgrammazione.DataBind();

            base.OnPreRender(e);
        }


        #region Gestione griglia

        void dgProgrammazione_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                if (ModificaDatiGenerale)
                    e.Item.Cells[c_CalcoloIndicatore].Visible = true;
                else
                    e.Item.Cells[c_CalcoloIndicatore].Visible = false;
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Disabilito tutte le celle, 
                // poi in base a Richiedibile e Istruttoria vado ad abilitare quelle che servono
                CellaDisabilita(e.Item.Cells[cVal_ProgrammatoRichiesto]);
                CellaDisabilita(e.Item.Cells[cVal_ProgrammatoAmmesso]);
                CellaDisabilita(e.Item.Cells[cVal_RealizzatoRichiesto]);
                CellaDisabilita(e.Item.Cells[cVal_RealizzatoAmmesso]);

                SiarLibrary.ProgettoIndicatori pind = (SiarLibrary.ProgettoIndicatori)e.Item.DataItem;
                if (ModificaDatiGenerale)
                {
                    CellaAbilita(e.Item.Cells[cVal_ProgrammatoRichiesto]);
                    CellaAbilita(e.Item.Cells[cVal_RealizzatoRichiesto]);
                    CellaAbilita(e.Item.Cells[cVal_ProgrammatoAmmesso]);
                    CellaAbilita(e.Item.Cells[cVal_RealizzatoAmmesso]);

                    if (pind.Richiedibile == cManuale)
                        e.Item.Cells[c_CalcoloIndicatore].Text = "Manuale";
                    else
                        e.Item.Cells[c_CalcoloIndicatore].Text = "Automatico";
                }
                else if (pind.Richiedibile == cManuale)     // Gli indicatori calcolati sono bloccati se ModificaDatiGenerale = false
                {
                    e.Item.Cells[c_CalcoloIndicatore].Visible = false;

                    if (!PistaDiControllo) //se sono nella pista di controllo non abilito nessuna cella
                    {
                        if (Istruttoria == eIstruttoria.Si)
                        {
                            if (StatoProgetto == eStato.Domanda || StatoProgetto == eStato.Variante)
                            {
                                CellaAbilita(e.Item.Cells[cVal_ProgrammatoAmmesso]);
                            }
                            CellaAbilita(e.Item.Cells[cVal_RealizzatoAmmesso]);
                        }
                        else if (Istruttoria == eIstruttoria.No)
                        {
                            if (StatoProgetto == eStato.Domanda || StatoProgetto == eStato.Variante)
                            {
                                CellaAbilita(e.Item.Cells[cVal_ProgrammatoRichiesto]);
                            }
                            CellaAbilita(e.Item.Cells[cVal_RealizzatoRichiesto]);
                        }
                    }
                }
                else
                    e.Item.Cells[c_CalcoloIndicatore].Visible = false;
            }

            if (PistaDiControllo)
            {
                //e.Item.Cells[c_CalcoloIndicatore].Visible = false;
                e.Item.Cells[cVal_ProgrammatoRichiesto].Visible = false;
                e.Item.Cells[cVal_RealizzatoRichiesto].Visible = false;
            }
            else
            {
                //e.Item.Cells[c_CalcoloIndicatore].Visible = true;
                e.Item.Cells[cVal_ProgrammatoRichiesto].Visible = true;
                e.Item.Cells[cVal_RealizzatoRichiesto].Visible = true;
            }
        }

        private void CellaAbilita(TableCell cella)
        {
            cella.Text = cella.Text.Replace("disabled", "");
        }

        private void CellaDisabilita(TableCell cella)
        {
            cella.Text = cella.Text.Replace("<input ", "<input disabled ");
        }

        #endregion

        #region Lettura dati

        private SiarLibrary.ProgettoIndicatoriCollection LeggiIndicatori()
        {
            SiarLibrary.ProgettoIndicatoriCollection retu = new SiarLibrary.ProgettoIndicatoriCollection();
            SiarLibrary.ProgettoIndicatori vecchio = null;
            decimal vCalcolato;
            SiarBLL.ProgettoIndicatoriCollectionProvider.isIstruttoria isIstr;
            bool indicatori_nuovi = false;

            if (Istruttoria == eIstruttoria.Si)
            {
                isIstr = SiarBLL.ProgettoIndicatoriCollectionProvider.isIstruttoria.si;
            }
            else
            {
                isIstr = SiarBLL.ProgettoIndicatoriCollectionProvider.isIstruttoria.no;
            }

            if (PistaDiControllo) // prendo gli ultimi indicatori validi
            {
                retu = pProv.GetUltimiIndicatoriValidi(Progetto.IdProgetto);  
            }
            else
            {
                // Lettura dati dalla tabella Progetto_Indicatori
                switch (StatoProgetto)
                {
                    case eStato.Domanda:
                        retu = pProv.GetDomanda(Progetto.IdProgetto);
                        break;
                    case eStato.Pagamento:
                        retu = pProv.GetPagamento(Progetto.IdProgetto, IdDomanda);
                        break;
                    case eStato.Variante:
                        retu = pProv.GetVariante(Progetto.IdProgetto, IdVariante);
                        break;
                }
            }
           
            if (retu.Count == 0)    // Per questo stato non c'è nessun dato salvato
            {
                indicatori_nuovi = true;
                retu = pProv.GetNew_ByIdProgetto(Progetto.IdProgetto);
                
                foreach (SiarLibrary.ProgettoIndicatori ind in retu)
                {
                    if (StatoProgetto == eStato.Variante)
                        ind.IdVariante = IdVariante;
                    if (StatoProgetto == eStato.Pagamento)
                        ind.IdDomandaPagamento = IdDomanda;

                    if (ind.Richiedibile == cManuale)
                    {
                        vecchio = pProv.GetStatoPrecedente(ind);
                        if (vecchio != null && vecchio.IdProgettoIndicatori != 0)    // Nello stato DOMANDA sarà sempre NULL
                        {
                            ind.ValoreProgrammatoAmmesso = vecchio.ValoreProgrammatoAmmesso;
                            ind.ValoreProgrammatoRichiesto = vecchio.ValoreProgrammatoRichiesto;
                            if (vecchio.ValoreRealizzatoAmmesso != null)
                                ind.ValoreRealizzatoRichiesto = vecchio.ValoreRealizzatoAmmesso;
                            else
                                ind.ValoreRealizzatoRichiesto = vecchio.ValoreRealizzatoRichiesto;
                        }
                    }
                }
            }

            if (_modificaDatiGenerale)
            {
                ProgettoIndicatoriCollection indicatoriAggiuntiCollection = new ProgettoIndicatoriCollection();

                switch (StatoProgetto)
                {
                    case eStato.Domanda:
                        indicatoriAggiuntiCollection = pProv.GetIndicatoriAggiuntiSuccessivamente(Progetto.IdProgetto, null, null);
                        break;
                    case eStato.Pagamento:
                        indicatoriAggiuntiCollection = pProv.GetIndicatoriAggiuntiSuccessivamente(Progetto.IdProgetto, IdDomanda, null);
                        break;
                    case eStato.Variante:
                        indicatoriAggiuntiCollection = pProv.GetIndicatoriAggiuntiSuccessivamente(Progetto.IdProgetto, null, IdVariante);
                        break;
                }
                
                retu.AddCollection(indicatoriAggiuntiCollection);
                retu.Sort("Richiedibile DESC, ProgrammazioneCodice, DimCodice");
            }

            foreach (SiarLibrary.ProgettoIndicatori ind in retu)
            {
                if (ind.Richiedibile == cCalcolato)       // Indicatori Calcolati
                {
                    //Se ho modificato i valori da modifica dati generale, prendo quei valori invece che quelli calcolati
                    vCalcolato = pProv.GetValoriCalcolati(ind, isIstr);

                    if (ind.ValoreProgrammatoRichiesto == null)
                        ind.ValoreProgrammatoRichiesto = vCalcolato;
                    if (ind.ValoreRealizzatoRichiesto == null)
                        ind.ValoreRealizzatoRichiesto = vCalcolato;

                    //Se è calcolato e non ho un valore, indipendemente se domanda di aiuto o altre fasi il valore calcolato è anche il programmato ammesso e realizzato ammesso
                    if (ind.ValoreProgrammatoAmmesso == null)
                        ind.ValoreProgrammatoAmmesso = vCalcolato;
                    if (ind.ValoreRealizzatoAmmesso == null)
                        ind.ValoreRealizzatoAmmesso = vCalcolato;
                }
                
                if (indicatori_nuovi || ind.IdProgettoIndicatori == null) //se gli indicatori sono nuovi devo salvarli perché se gli istruttori non li ammettono non aggiornerei mai i valori calcolati
                {
                    ind.MarkAsNew();
                    ind.CodTipo = _codTipo;
                    ind.Operatore = Operatore;
                    ind.DataRegistrazione = DateTime.Now;

                    if (ind.Richiedibile == cManuale) //se è nuovo e manuale deve avere il valore programmato e realizzato richiesto != null
                    {
                        //se non ho i valori dello stato precedente li metto a 0
                        if (ind.ValoreProgrammatoRichiesto == null)
                            ind.ValoreProgrammatoRichiesto = 0;
                        if (ind.ValoreRealizzatoRichiesto == null)
                            ind.ValoreRealizzatoRichiesto = 0;
                    }

                    pProv.Save(ind);
                }
            }

            return retu;
        }


        #endregion
        
        #region Salvataggio dati

        public void Salva()
        {
            SiarLibrary.NullTypes.DecimalNT valProgRichiesto;
            SiarLibrary.NullTypes.DecimalNT valProgAmmesso;
            SiarLibrary.NullTypes.DecimalNT valRealRichiesto;
            SiarLibrary.NullTypes.DecimalNT valRealAmmesso;

            SiarLibrary.ProgettoIndicatoriCollection pinds = LeggiIndicatori();

            foreach (SiarLibrary.ProgettoIndicatori pind in pinds)
            {
                if (pind.IdProgettoIndicatori == null)  // Se non lo trovo è un nuovo record
                {
                    pind.MarkAsNew();
                    pind.CodTipo = _codTipo;
                }

                valProgRichiesto = pind.ValoreProgrammatoRichiesto;
                valProgAmmesso   = pind.ValoreProgrammatoAmmesso;
                valRealRichiesto = pind.ValoreRealizzatoRichiesto;
                valRealAmmesso   = pind.ValoreRealizzatoAmmesso;

                pind.ValoreProgrammatoRichiesto = Val_ProgrammatoRichiesto(pind.IdDimXProgrammazione);
                pind.ValoreProgrammatoAmmesso   = Val_ProgrammatoAmmesso(pind.IdDimXProgrammazione);
                pind.ValoreRealizzatoRichiesto  = Val_RealizzatoRichiesto(pind.IdDimXProgrammazione);
                pind.ValoreRealizzatoAmmesso    = Val_RealizzatoAmmesso(pind.IdDimXProgrammazione);

                if (pind.ValoreProgrammatoRichiesto != valProgRichiesto || pind.ValoreRealizzatoRichiesto != valRealRichiesto)
                {
                    pind.Operatore = Operatore;
                    pind.DataRegistrazione = DateTime.Now;
                }

                // Se i valori ammessi sono stati modificati segno l'operatore e la data istruttoria
                // indipendentemente dallo stato.
                // Vale anche se e' calcolato
                if (pind.ValoreProgrammatoAmmesso != valProgAmmesso || pind.ValoreRealizzatoAmmesso != valRealAmmesso
                    || pind.Richiedibile == cCalcolato)
                {
                    pind.Istruttore = Operatore;
                    pind.DataIstruttoria = DateTime.Now;
                }

                // Pulizia Id Domanda e Id Variante
                pind.IdVariante         = null;
                pind.IdDomandaPagamento = null;

                // Se sono in una Varitante salvo _idVariante
                if (StatoProgetto == eStato.Variante)
                {
                    pind.IdVariante = IdVariante;
                }

                // Se sono in una domanda di Pagamento salvo _idDomanda
                if (StatoProgetto == eStato.Pagamento)
                {
                    pind.IdDomandaPagamento = IdDomanda;
                }

                // Campi NOT NULL sul db
                if (pind.Operatore == null) { pind.Operatore = Operatore; }
                if (pind.DataRegistrazione == null) { pind.DataRegistrazione = DateTime.Now; }
            }

            pProv.SaveCollection(pinds);
        }

        public void SalvaModificaDatiGenerale(string noteModifica)
        {
            if (ModificaDatiGenerale)
            {
                try
                {
                    pProv = new SiarBLL.ProgettoIndicatoriCollectionProvider();
                    pProv.DbProviderObj.BeginTran();
                    var modifiche_provider = new SiarBLL.ModificaDatiGeneraleCollectionProvider(pProv.DbProviderObj);

                    SiarLibrary.NullTypes.DecimalNT valProgRichiesto;
                    SiarLibrary.NullTypes.DecimalNT valProgAmmesso;
                    SiarLibrary.NullTypes.DecimalNT valRealRichiesto;
                    SiarLibrary.NullTypes.DecimalNT valRealAmmesso;

                    SiarLibrary.ProgettoIndicatoriCollection pinds = LeggiIndicatori();

                    var modifica_dati = new SiarLibrary.ModificaDatiGenerale();
                    modifica_dati.IdUtenteModifica = Operatore;
                    modifica_dati.DataModifica = DateTime.Now;
                    modifica_dati.Note = noteModifica;
                    modifica_dati.IdProgetto = Progetto.IdProgetto;
                    if (StatoProgetto == eStato.Pagamento) // Se sono in una domanda di Pagamento salvo _idDomanda
                        modifica_dati.IdDomanda = IdDomanda;
                    if (StatoProgetto == eStato.Variante) // Se sono in una Varitante salvo _idVariante
                    {
                        modifica_dati.IdVariante = IdVariante;
                    }
                    modifica_dati.CodTipoModifica = new SiarBLL.TipoModificaGeneraleCollectionProvider().Find(null, SiarLibrary.ModificaDatiGenerale.eTipoModifica.Indicatori.ToString(), true)[0].IdTipoModifica;
                    var istanza_indicatori = new SiarBLL.IstanzaProgettoIndicatori(pinds);
                    modifica_dati.IstanzaPrecedente = istanza_indicatori.Serialize();

                    foreach (SiarLibrary.ProgettoIndicatori pind in pinds)
                    {
                        if (pind.IdProgettoIndicatori == null)  // Se non lo trovo è un nuovo record
                        {
                            pind.MarkAsNew();
                            pind.CodTipo = _codTipo;
                        }

                        valProgRichiesto = pind.ValoreProgrammatoRichiesto;
                        valProgAmmesso = pind.ValoreProgrammatoAmmesso;
                        valRealRichiesto = pind.ValoreRealizzatoRichiesto;
                        valRealAmmesso = pind.ValoreRealizzatoAmmesso;

                        pind.ValoreProgrammatoRichiesto = Val_ProgrammatoRichiesto(pind.IdDimXProgrammazione);
                        pind.ValoreProgrammatoAmmesso = Val_ProgrammatoAmmesso(pind.IdDimXProgrammazione);
                        pind.ValoreRealizzatoRichiesto = Val_RealizzatoRichiesto(pind.IdDimXProgrammazione);
                        pind.ValoreRealizzatoAmmesso = Val_RealizzatoAmmesso(pind.IdDimXProgrammazione);

                        if (pind.ValoreProgrammatoRichiesto != valProgRichiesto || pind.ValoreRealizzatoRichiesto != valRealRichiesto)
                        {
                            pind.Operatore = Operatore;
                            pind.DataRegistrazione = DateTime.Now;
                        }

                        // Se i valori ammessi sono stati modificati segno l'operatore e la data istruttoria
                        // indipendentemente dallo stato.
                        // Vale anche se e' calcolato
                        if (pind.ValoreProgrammatoAmmesso != valProgAmmesso || pind.ValoreRealizzatoAmmesso != valRealAmmesso
                            || pind.Richiedibile == cCalcolato)
                        {
                            pind.Istruttore = Operatore;
                            pind.DataIstruttoria = DateTime.Now;
                        }

                        // Pulizia Id Domanda e Id Variante
                        pind.IdVariante = null;
                        pind.IdDomandaPagamento = null;

                        // Se sono in una Varitante salvo _idVariante
                        if (StatoProgetto == eStato.Variante)
                        {
                            pind.IdVariante = IdVariante;
                        }

                        // Se sono in una domanda di Pagamento salvo _idDomanda
                        if (StatoProgetto == eStato.Pagamento)
                        {
                            pind.IdDomandaPagamento = IdDomanda;
                        }

                        // Campi NOT NULL sul db
                        if (pind.Operatore == null) { pind.Operatore = Operatore; }
                        if (pind.DataRegistrazione == null) { pind.DataRegistrazione = DateTime.Now; }
                    }

                    pProv.SaveCollection(pinds);

                    istanza_indicatori = new SiarBLL.IstanzaProgettoIndicatori(pinds);
                    modifica_dati.IstanzaNuovo = istanza_indicatori.Serialize();
                    modifiche_provider.Save(modifica_dati);

                    pProv.DbProviderObj.Commit();
                }
                catch(Exception ex)
                {
                    pProv.DbProviderObj.Rollback();
                    throw ex;
                }
            }
            else
                Salva();
        }

        private SiarLibrary.NullTypes.DecimalNT Val_ProgrammatoRichiesto(int idDimXProgrammazione)
        {
            // Nota: è not null su db
            decimal vGriglia;
            SiarLibrary.NullTypes.DecimalNT vOutput;

            if (!decimal.TryParse(Request.Form["ValoreProgrammatoRichiesto" + idDimXProgrammazione + "_text"],
                                  out vGriglia))
            {
                vGriglia = 0;
            }

            vOutput = vGriglia;
            return vOutput;
        }

        private SiarLibrary.NullTypes.DecimalNT Val_ProgrammatoAmmesso(int idDimXProgrammazione)
        {
            decimal vGriglia;
            SiarLibrary.NullTypes.DecimalNT vOutput = null;

            if (decimal.TryParse(Request.Form["ValoreProgrammatoAmmesso" + idDimXProgrammazione + "_text"],
                      out vGriglia))
            {
                vOutput = vGriglia;
            }

            return vOutput;
        }

        private SiarLibrary.NullTypes.DecimalNT Val_RealizzatoRichiesto(int idDimXProgrammazione)
        {
            // Nota: è not null su db
            decimal vGriglia;
            SiarLibrary.NullTypes.DecimalNT vOutput;

            if (!decimal.TryParse(Request.Form["ValoreRealizzatoRichiesto" + idDimXProgrammazione + "_text"],
                      out vGriglia))
            {
                vGriglia = 0;
            }

            vOutput = vGriglia;
            return vOutput;
        }

        private SiarLibrary.NullTypes.DecimalNT Val_RealizzatoAmmesso(int idDimXProgrammazione)
        {
            decimal vGriglia;
            SiarLibrary.NullTypes.DecimalNT vOutput = null;

            if (decimal.TryParse(Request.Form["ValoreRealizzatoAmmesso" + idDimXProgrammazione + "_text"],
                      out vGriglia))
            {
                vOutput = vGriglia;
            }

            return vOutput;
        }
        
        #endregion

    }
}