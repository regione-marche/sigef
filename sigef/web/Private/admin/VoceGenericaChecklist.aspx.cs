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
    public partial class VoceGenericaChecklist : VoceGenericaPage
    {
        VoceGenericaCollectionProvider voci_provider;

        protected void Page_Load(object sender, EventArgs e)
        {
            lstFiltro.DataBind();
        }

        protected override void OnPreRender(EventArgs e)
        {
            InizializzaProvider();

            RiempiFormVoce();

            base.OnPreRender(e);
        }

        private void InizializzaProvider()
        {
            voci_provider = new VoceGenericaCollectionProvider();
        }

        private void RiempiFormVoce()
        {
            if (VoceGenerica != null && VoceGenerica.IdVoceGenerica != null)
            {
                txtDescrizioneVoceGenerica.Text = VoceGenerica.Descrizione;
                txtCommentoVoceGenerica.Text = VoceGenerica.Commento;
                lstFiltro.SelectedValue = VoceGenerica.IdFiltro;
                txtValoreMinimo.Text = VoceGenerica.ValMinimo;
                txtValoreMassimo.Text = VoceGenerica.ValMassimo;
                chkTitolo.Checked = VoceGenerica.Titolo ?? false;
                chkAutomatico.Checked = VoceGenerica.Automatico ?? false;
                txtQuerySql.Text = VoceGenerica.QuerySql;
                txtQuerySqlPost.Text = VoceGenerica.QuerySqlPost;
                txtNomeMetodo.Text = VoceGenerica.CodeMethod;
                txtUrl.Text = VoceGenerica.Url;
            }
            else
            {
                txtDescrizioneVoceGenerica.Text = null;
                txtCommentoVoceGenerica.Text = null;
                lstFiltro.SelectedValue = null;
                txtValoreMinimo.Text = null;
                txtValoreMassimo.Text = null;
                chkTitolo.Checked = false;
                chkAutomatico.Checked = false;
                txtQuerySql.Text = null;
                txtQuerySqlPost.Text = null;
                txtNomeMetodo.Text = null;
                txtUrl.Text = null;
            }
        }

        private void PopolaVoce(ref VoceGenerica voce)
        {
            voce.Descrizione = txtDescrizioneVoceGenerica.Text;
            voce.Commento = txtCommentoVoceGenerica.Text;
            voce.IdFiltro = lstFiltro.SelectedValue; 
            voce.ValMinimo = txtValoreMinimo.Text;
            voce.ValMassimo = txtValoreMassimo.Text;
            voce.Titolo = chkTitolo.Checked;
            voce.Automatico = chkAutomatico.Checked;
            voce.QuerySql = txtQuerySql.Text;
            voce.QuerySqlPost = txtQuerySqlPost.Text;
            voce.CodeMethod = txtNomeMetodo.Text;
            voce.Url =txtUrl.Text;
        }

        #region Button Click

        protected void btnSalvaVoceGenerica_Click(object sender, EventArgs e)
        {
            try
            {
                voci_provider = new VoceGenericaCollectionProvider();
                voci_provider.DbProviderObj.BeginTran();

                VoceGenerica voce;
                if (VoceGenerica == null)
                {
                    voce = new VoceGenerica();
                    voce.CfInserimento = Operatore.Utente.CfUtente;
                    voce.DataInserimento = DateTime.Now;
                }
                else
                    voce = VoceGenerica;

                voce.CfModifica = Operatore.Utente.CfUtente;
                voce.DataModifica = DateTime.Now;

                PopolaVoce(ref voce);

                voci_provider.Save(voce);
                voci_provider.DbProviderObj.Commit();
                VoceGenerica = voce;
                ShowMessage("Voce salvata correttamente");
            }
            catch (Exception ex)
            {
                VoceGenerica = null;
                voci_provider.DbProviderObj.Rollback();
                ShowError(ex.Message);
            }
        }

        protected void btnEliminaVoceGenerica_Click(object sender, EventArgs e)
        {
            try
            {
                voci_provider = new VoceGenericaCollectionProvider();
                voci_provider.DbProviderObj.BeginTran();

                if (VoceGenerica != null && VoceGenerica.IdVoceGenerica != null)
                {
                    var voci_checklist_coll = new VoceXChecklistGenericaCollectionProvider().FindGenerica(null, null, VoceGenerica.IdVoceGenerica);
                    if (voci_checklist_coll.Count > 0)
                        throw new Exception("La voce e' associata a " + voci_checklist_coll.Count + " checklist: non è possibile eliminarla");

                    voci_provider.Delete(VoceGenerica);

                    voci_provider.DbProviderObj.Commit();
                    Redirect(PATH_ADMIN + "RicercaVoceChecklistGenerica.aspx", "Voce eliminata correttamente", false);
                }
                else
                    throw new Exception("Voce non salvata");
            }
            catch (Exception ex)
            {
                voci_provider.DbProviderObj.Rollback();
                ShowError(ex.Message);
            }
        }

        #endregion
    }
}