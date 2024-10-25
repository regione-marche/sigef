using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SiarLibrary;
using SiarLibrary.Web;
using SiarBLL;
using SiarLibrary.NullTypes;

namespace web.Private.admin
{
    public partial class FiltroChecklistVocePage : FiltroChecklistVoceClassPage
    {
        FiltroChecklistVoceCollectionProvider filtri_provider;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            InizializzaProvider();

            RiempiFormFiltro();

            base.OnPreRender(e);
        }

        private void InizializzaProvider()
        {
            filtri_provider = new FiltroChecklistVoceCollectionProvider();
        }

        private void RiempiFormFiltro()
        {
            if (FiltroChecklistVoce != null && FiltroChecklistVoce.IdFiltro != null)
            {
                txtIdFiltro.Text = FiltroChecklistVoce.IdFiltro;
                txtDescrizione.Text = FiltroChecklistVoce.Descrizione;
                txtOrdine.Text = FiltroChecklistVoce.Ordine;
            }
            else
            {
                txtIdFiltro.Text = null;
                txtDescrizione.Text = null;
                txtOrdine.Text = null;
            }
        }

        private void PopolaFiltro(ref FiltroChecklistVoce filtro)
        {
            filtro.IdFiltro = txtIdFiltro.Text;
            filtro.Descrizione = txtDescrizione.Text;
            filtro.Ordine = txtOrdine.Text;
        }

        #region Button Click

        protected void btnSalvaFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                filtri_provider = new FiltroChecklistVoceCollectionProvider();
                filtri_provider.DbProviderObj.BeginTran();

                FiltroChecklistVoce filtro;
                if (FiltroChecklistVoce == null)
                {
                    filtro = new FiltroChecklistVoce();
                    filtro.CfInserimento = Operatore.Utente.CfUtente;
                    filtro.DataInserimento = DateTime.Now;
                }
                else
                    filtro = FiltroChecklistVoce;

                filtro.CfModifica = Operatore.Utente.CfUtente;
                filtro.DataModifica = DateTime.Now;

                PopolaFiltro(ref filtro);

                filtri_provider.Save(filtro);
                filtri_provider.DbProviderObj.Commit();
                FiltroChecklistVoce = filtro;
                ShowMessage("Filtro salvato correttamente");
            }
            catch (Exception ex)
            {
                FiltroChecklistVoce = null;
                filtri_provider.DbProviderObj.Rollback();
                ShowError(ex.Message);
            }
        }

        protected void btnEliminaFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                filtri_provider = new FiltroChecklistVoceCollectionProvider();
                filtri_provider.DbProviderObj.BeginTran();

                if (FiltroChecklistVoce != null && FiltroChecklistVoce.IdFiltro != null)
                {
                    var voci_coll = new VoceGenericaCollectionProvider().FindVoce(null, null, FiltroChecklistVoce.IdFiltro, null, null, null);
                    if (voci_coll.Count > 0)
                        throw new Exception("Il filtro e' associato a " + voci_coll.Count + " voci: non è possibile eliminarlo");

                    var checklist_coll = new ChecklistGenericaCollectionProvider().FindChecklist(null, null, null, FiltroChecklistVoce.IdFiltro, null, null, null, null, null);
                    if (checklist_coll.Count > 0)
                        throw new Exception("Il filtro e' associato a " + checklist_coll.Count + " checklist: non è possibile eliminarlo");

                    filtri_provider.Delete(FiltroChecklistVoce);

                    filtri_provider.DbProviderObj.Commit();
                    Redirect(PATH_ADMIN + "RicercaFiltroChecklistVoce.aspx", "Filtro eliminato correttamente", false);
                }
                else
                    throw new Exception("Voce non salvata");
            }
            catch (Exception ex)
            {
                filtri_provider.DbProviderObj.Rollback();
                ShowError(ex.Message);
            }
        }

        #endregion
    }
}