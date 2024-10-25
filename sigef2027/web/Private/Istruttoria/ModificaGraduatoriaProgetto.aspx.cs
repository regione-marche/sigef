using SiarBLL;
using SiarLibrary;
using SiarLibrary.NullTypes;
using System;
using System.Linq;

namespace web.Private.Istruttoria
{
    public partial class ModificaGraduatoriaProgetto : SiarLibrary.Web.IstruttoriaPage
    {
        AttiCollectionProvider attiCollectionProvider;
        ImpresaCollectionProvider impresaCollectionProvider;
        GraduatoriaProgettiCollectionProvider graduatoriaProgettiCollectionProvider;
        Atti atto;

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "Graduatoria";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ProgettoModificaGraduatoria == null)
                Redirect("~/private/psr/bandi/ricerca.aspx", "Progetto non selezionato, impossibile continuare", true);

            ucInfoDomanda.Progetto = ProgettoModificaGraduatoria;
        }

        protected override void OnPreRender(EventArgs e)
        {
            InizializzaProvider();
            lstAttoDefinizione.DataBind();
            lstAttoRegistro.DataBind();

            // evento ricerca
            int id_decreto;
            if (atto == null && int.TryParse(hdnIdAtto.Value, out id_decreto))
                atto = attiCollectionProvider.GetById(id_decreto);
            // bind dei campi
            if (atto != null)
            {
                hdnIdAtto.Value = atto.IdAtto;

                txtAttoData.Text = atto.Data;
                txtAttoNumero.Text = atto.Numero;
                txtAttoDescrizione.Text = atto.Descrizione;
            }

            //Carico i dati della domanda
            //txtIdProgetto.Text = ProgettoModificaGraduatoria.IdProgetto;
            //var impresaProgetto = impresaCollectionProvider.GetById(ProgettoModificaGraduatoria.IdImpresa);
            //if (impresaProgetto == null)
            //    Redirect("~/private/psr/bandi/ricerca.aspx", "Impresa non trovata, impossibile continuare", true);
            //txtPartitaIva.Text = impresaProgetto.CodiceFiscale;
            //txtCodiceFiscale.Text = impresaProgetto.Cuaa;
            //txtRagioneSociale.Text = impresaProgetto.RagioneSociale;

            //Carico i dati del progetto
            if (GraduatoriaProgettoModifica == null)
            {
                var result = graduatoriaProgettiCollectionProvider.Find(Bando.IdBando, ProgettoModificaGraduatoria.IdProgetto, null);
                if (result.Count == 1)
                {
                    var graduatoriaProgetto = result[0];

                    txtSpesaAmmessaPrecedente.Text = txtSpesaAmmessaNuova.Text = graduatoriaProgetto.CostoTotale;
                    txtContributoAmmessoPrecedente.Text = txtContributoAmmessoNuovo.Text = graduatoriaProgetto.ContributoTotale;
                }
                else
                    Redirect("~/private/psr/bandi/ricerca.aspx", "Domanda di aiuto trovata più volte in graduatoria, impossibile continuare", true);
            }
            else
            {
                txtSpesaAmmessaPrecedente.Text = GraduatoriaProgettoModifica.CostoTotalePrecedente;
                txtSpesaAmmessaNuova.Text = GraduatoriaProgettoModifica.CostoTotaleNuovo;
                txtContributoAmmessoPrecedente.Text = GraduatoriaProgettoModifica.ContributoTotalePrecedente;
                txtContributoAmmessoNuovo.Text = GraduatoriaProgettoModifica.ContributoTotaleNuovo;
                txtAreaNote.Text = GraduatoriaProgettoModifica.Note;

                txtSpesaAmmessaNuova.ReadOnly = true;
                txtContributoAmmessoNuovo.ReadOnly = true;
            }

            base.OnPreRender(e);
        }

        protected void InizializzaProvider()
        {
            attiCollectionProvider = new AttiCollectionProvider();
            impresaCollectionProvider = new ImpresaCollectionProvider();
            graduatoriaProgettiCollectionProvider = new GraduatoriaProgettiCollectionProvider();
        }

        protected void InizializzaProvider(DbProvider dbProvider)
        {
            attiCollectionProvider = new AttiCollectionProvider(dbProvider);
            impresaCollectionProvider = new ImpresaCollectionProvider(dbProvider);
            graduatoriaProgettiCollectionProvider = new GraduatoriaProgettiCollectionProvider(dbProvider);
        }

        protected void btnIndietro_Click(object sender, EventArgs e)
        {
            GraduatoriaProgettoModifica = null;
            ProgettoModificaGraduatoria = null;

            BandoConfigCollection cc = new BandoConfigCollectionProvider().Find(Bando.IdBando, "ATTGRADBLOCCHI", null, true, null);
            if (cc.Count > 0 && bool.Parse(cc[0].Valore))
                Redirect(PATH_ISTRUTTORIA + "GraduatoriaIndividuale.aspx");
            else
                Redirect(PATH_ISTRUTTORIA + "Graduatoria.aspx");
        }

        protected void btnCercaDecreto_Click(object sender, EventArgs e)
        {
            try
            {
                int numero;
                int.TryParse(txtAttoNumero.Text, out numero);
                DateTime data;
                DateTime.TryParse(txtAttoData.Text, out data);
                string registro = lstAttoRegistro.SelectedValue;
                if (!string.IsNullOrEmpty(lstAttoRegistro.SelectedValue) && lstAttoRegistro.SelectedValue.IndexOf("|") > 0)
                    registro = lstAttoRegistro.SelectedValue.Substring(0, lstAttoRegistro.SelectedValue.IndexOf("|"));

                InizializzaProvider();

                // controllo che l'atto sia registrato su db, altrimenti lo importo
                var atti_trovati = attiCollectionProvider.Find(numero, data, lstAttoDefinizione.SelectedValue, registro);
                if (atti_trovati.Count == 0)
                {
                    atti_trovati = attiCollectionProvider.ImportaAtto(numero, data, lstAttoDefinizione.SelectedValue, lstAttoRegistro.SelectedValue);
                    if (atti_trovati.Count > 0)
                        attiCollectionProvider.Save(atti_trovati[0]);
                }

                if (atti_trovati.Count > 0)
                {
                    atto = atti_trovati[0];
                    hdnIdAtto.Value = atto.IdAtto;
                }
                else
                    ShowError("La ricerca non ha prodotto nessun risultato.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnSalvaModifica_Click(object sender, EventArgs e)
        {
            var graduatoriaProgettoModificheRupCollectionProvider = new GraduatoriaProgettoModificheRupCollectionProvider();

            try
            {
                InizializzaProvider(graduatoriaProgettoModificheRupCollectionProvider.DbProviderObj);
                graduatoriaProgettoModificheRupCollectionProvider.DbProviderObj.BeginTran();

                int idAtto;
                if (!int.TryParse(hdnIdAtto.Value, out idAtto))
                    throw new Exception("Per proseguire è necessario specificare l'atto di riferimento.");

                if (string.IsNullOrEmpty(txtSpesaAmmessaNuova.Text)
                    && string.IsNullOrEmpty(txtContributoAmmessoNuovo.Text))
                    throw new Exception("Inserire un valore per la spesa totale ammessa nuova e per per il contributo totale ammesso nuovo");

                if (string.IsNullOrEmpty(txtSpesaAmmessaNuova.Text))
                    throw new Exception("Inserire un valore per la spesa totale ammessa nuova");

                if (string.IsNullOrEmpty(txtContributoAmmessoNuovo.Text))
                    throw new Exception("Inserire un valore per il contributo totale ammesso nuovo");

                var graduatoriaList = graduatoriaProgettiCollectionProvider.
                        GetListaProgettiInGraduatoria(Bando.IdBando)
                        .ToArrayList<GraduatoriaProgetti>()
                        .OrderBy(g => g.Ordine);

                //Se la differenza del contributo è positiva controllo se ci sono fondi a disposizione prima di andara avanti
                DecimalNT contributoNuovo = txtContributoAmmessoNuovo.Text;
                DecimalNT contributoPrecedente = txtContributoAmmessoPrecedente.Text;
                DecimalNT differenza = contributoNuovo - contributoPrecedente;

                if (differenza > 0)
                {
                    DecimalNT contributoGraduatoria = graduatoriaList
                        .Where(g => g.Finanziabilita == "F" || g.Finanziabilita == "S" || g.Finanziabilita == "P")
                        .Sum(g => g.ContributoTotale);
                    DecimalNT contributoNuovaGraduatoria = contributoGraduatoria.Value + differenza.Value;

                    if (Bando.Importo < contributoNuovaGraduatoria)
                        throw new Exception("Con il contributo che si vorrebbe concedere si superebbe l'importo totale del bando: " +
                            "aumentare prima i fondi del bando o diminuire il contributo di un altra domanda di aiuto.");

                    //graduatoriaProgetto = graduatoriaList
                    //    .Where(g => g.IdProgetto == ProgettoModificaGraduatoria)
                    //    .FirstOrDefault<GraduatoriaProgetti>();
                }

                // salvo la struttura per registrare la modifica dello storico
                if (GraduatoriaProgettoModifica == null)
                {
                    GraduatoriaProgettoModifica = new GraduatoriaProgettoModificheRup();
                    GraduatoriaProgettoModifica.IdBando = Bando.IdBando;
                    GraduatoriaProgettoModifica.IdProgetto = ProgettoModificaGraduatoria.IdProgetto;
                    GraduatoriaProgettoModifica.CfInserimento = Operatore.Utente.CfUtente;
                    GraduatoriaProgettoModifica.DataInserimento = DateTime.Now;
                    GraduatoriaProgettoModifica.ContributoTotalePrecedente = txtContributoAmmessoPrecedente.Text;
                    GraduatoriaProgettoModifica.CostoTotalePrecedente = txtSpesaAmmessaPrecedente.Text;
                }

                GraduatoriaProgettoModifica.CfModifica = Operatore.Utente.CfUtente;
                GraduatoriaProgettoModifica.DataModifica = DateTime.Now;
                GraduatoriaProgettoModifica.IdAtto = idAtto;
                GraduatoriaProgettoModifica.ContributoTotaleNuovo = txtContributoAmmessoNuovo.Text;
                GraduatoriaProgettoModifica.CostoTotaleNuovo = txtSpesaAmmessaNuova.Text;
                GraduatoriaProgettoModifica.Note = txtAreaNote.Text;
                graduatoriaProgettoModificheRupCollectionProvider.Save(GraduatoriaProgettoModifica);

                //// salvo la modifica su graduatoria progetto
                //if (graduatoriaProgetto == null)
                //{
                //    var graduatoriaProgettoCollection = graduatoriaProgettiCollectionProvider
                //        .Find(Bando.IdBando, ProgettoModificaGraduatoria.IdProgetto, null);

                //    if (graduatoriaProgettoCollection.Count == 1)
                //        graduatoriaProgetto = graduatoriaProgettoCollection[0];
                //    else
                //        throw new Exception("Progetto non trovato in graduatoria o trovato più volte");
                //}

                //graduatoriaProgetto.CostoTotale = txtSpesaAmmessaNuova.Text;
                //graduatoriaProgetto.ContributoTotale = txtContributoAmmessoNuovo.Text;
                //graduatoriaProgettiCollectionProvider.Save(graduatoriaProgetto);

                // aggiorno il contributo rimanente di ogni progetto
                // quando trovo il progetto della modifica aggiorno i valori con quelli inseriti
                var importoBandoRimanente = Bando.Importo;
                foreach (GraduatoriaProgetti graduatoriaProgetto in graduatoriaList)
                {
                    if (graduatoriaProgetto.IdProgetto == ProgettoModificaGraduatoria.IdProgetto)
                    {
                        graduatoriaProgetto.CostoTotale = txtSpesaAmmessaNuova.Text;
                        graduatoriaProgetto.ContributoTotale = txtContributoAmmessoNuovo.Text;
                    }

                    if (graduatoriaProgetto.Finanziabilita == "F"
                        || graduatoriaProgetto.Finanziabilita == "S" 
                        || graduatoriaProgetto.Finanziabilita == "P")
                    {
                        importoBandoRimanente -= graduatoriaProgetto.ContributoTotale;
                        if (importoBandoRimanente < 0)
                            importoBandoRimanente = 0;
                        graduatoriaProgetto.ContributoRimanente = importoBandoRimanente;
                    }
                    graduatoriaProgettiCollectionProvider.Save(graduatoriaProgetto);
                }

                graduatoriaProgettoModificheRupCollectionProvider.DbProviderObj.Commit();
                ShowMessage("Modifica degli importi effettuato con successo");
            }
            catch (Exception ex)
            {
                graduatoriaProgettoModificheRupCollectionProvider.DbProviderObj.Rollback();
                ShowError(ex);
            }
        }
    }
}