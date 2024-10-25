using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.Impresa
{
    public partial class ImpresaRiepilogo : SiarLibrary.Web.ImpresaPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "impresa_riepilogo";
            base.OnPreInit(e);
        }

        SiarBLL.ImpresaCollectionProvider impresa_provider = new SiarBLL.ImpresaCollectionProvider();
        SiarLibrary.Impresa impresa;

        protected void Page_Load(object sender, EventArgs e)
        {
            impresa = impresa_provider.GetById(Azienda.IdImpresa);
        }

        protected override void OnPreRender(EventArgs e)
        {
            txtDataInizioAttivita.Text = impresa.DataInizioAttivita;
            txtStatoImpresa.Text = impresa.Attiva ? "ATTIVA" : "CESSATA";

            System.Data.IDbCommand cmd = impresa_provider.DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpRiepilogoAttivitaImpresa";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_IMPRESA", impresa.IdImpresa.Value));
            impresa_provider.DbProviderObj.InitDatareader(cmd);
            if (impresa_provider.DbProviderObj.DataReader.Read())
            {
                txtNrPrPresentati.Text = new SiarLibrary.NullTypes.IntNT(impresa_provider.DbProviderObj.DataReader["PR_PRESENTATI"]);
                txtNrPrAttivi.Text = new SiarLibrary.NullTypes.IntNT(impresa_provider.DbProviderObj.DataReader["PR_ATTIVI"]);
                txtNrPrUltimo.Text = new SiarLibrary.NullTypes.IntNT(impresa_provider.DbProviderObj.DataReader["PR_ULTIMO"]);
                txtStatoPrUltimo.Text = new SiarLibrary.NullTypes.StringNT(impresa_provider.DbProviderObj.DataReader["PR_STATO_ULTIMO"]);

                txtUmaPrimoAnno.Text = new SiarLibrary.NullTypes.IntNT(impresa_provider.DbProviderObj.DataReader["UMA_PRIMO_ANNO"]);
                txtUmaIdUltimo.Text = new SiarLibrary.NullTypes.IntNT(impresa_provider.DbProviderObj.DataReader["UMA_ULTIMO_ID"]);
                txtUmaAnnoUltimo.Text = new SiarLibrary.NullTypes.IntNT(impresa_provider.DbProviderObj.DataReader["UMA_ULTIMO_ANNO"]);
                txtUmaTipoUltimo.Text = new SiarLibrary.NullTypes.StringNT(impresa_provider.DbProviderObj.DataReader["UMA_ULTIMO_TIPO"]);
                txtUmaStatoUltimo.Text = new SiarLibrary.NullTypes.StringNT(impresa_provider.DbProviderObj.DataReader["UMA_ULTIMO_STATO"]);

                txtBioAnno.Text = new SiarLibrary.NullTypes.IntNT(impresa_provider.DbProviderObj.DataReader["BIO_ANNO"]);
                txtBioOdc.Text = new SiarLibrary.NullTypes.StringNT(impresa_provider.DbProviderObj.DataReader["BIO_ODC"]);
                SiarLibrary.NullTypes.StringNT cod_attivita = new SiarLibrary.NullTypes.StringNT(impresa_provider.DbProviderObj.DataReader["BIO_ATTIVITA"]);
                if (cod_attivita != null)
                {
                    string attivita_bio = "";
                    if (cod_attivita.Value.Contains("01")) attivita_bio = "Produttore";
                    if (cod_attivita.Value.Contains("02")) attivita_bio += " - Preparatore";
                    if (cod_attivita.Value.Contains("03")) attivita_bio += " - Importatore";
                    txtBioAttivita.Text = attivita_bio;
                }

                txtEroaAnno.Text = new SiarLibrary.NullTypes.IntNT(impresa_provider.DbProviderObj.DataReader["EROA_ANNO"]);
                txtEroaNumero.Text = new SiarLibrary.NullTypes.StringNT(impresa_provider.DbProviderObj.DataReader["EROA_NUMERO"]);
                txtEroaStato.Text = new SiarLibrary.NullTypes.StringNT(impresa_provider.DbProviderObj.DataReader["EROA_STATO"]);
                if (string.IsNullOrEmpty(txtEroaStato.Text)) txtEroaStato.Text = "Non Iscritta";
                chkEroaAttMinima.Checked = new SiarLibrary.NullTypes.BoolNT(impresa_provider.DbProviderObj.DataReader["EROA_ATT_MINIMA"]);
            }
            impresa_provider.DbProviderObj.Close();
            base.OnPreRender(e);
        }
    }
}
