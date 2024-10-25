using System;
using System.Web.UI;

namespace web.Private.PDomanda
{
    public partial class RelazioneTecnica : SiarLibrary.Web.ProgettoPage
    {
        SiarBLL.ProgettoRelazioneTecnicaCollectionProvider relazione_provider;
        SiarLibrary.BandoRelazioneTecnicaCollection bandoRelazioneTecnicaCollection = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            relazione_provider = new SiarBLL.ProgettoRelazioneTecnicaCollectionProvider(ProgettoProvider.DbProviderObj);
            bandoRelazioneTecnicaCollection = new SiarBLL.BandoRelazioneTecnicaCollectionProvider().Find(Progetto.IdBando);

            if (Bando.Aggregazione)
            {
                btnPrev.Value = "<<< (5/8)";
                btnCurrent.Value = "(6/8)";
                btnGo.Value = "(7/8) >>>";
                btnPrev.Attributes.Add("onclick", "location='RequisitiImpresa.aspx'");
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (bandoRelazioneTecnicaCollection.Count > 0)
            {
                trSiRelazione.Visible = true;
                trNoRelazione.Visible = false;
                SiarLibrary.ProgettoRelazioneTecnicaCollection paragrafi_progetto = relazione_provider.Find(Progetto.IdProgetto, null);
                foreach (SiarLibrary.BandoRelazioneTecnica parag in bandoRelazioneTecnicaCollection)
                {
                    Control c = LoadControl("~/CONTROLS/QuadroRelazioneTecnica.ascx");
                    c.ID = "quadro_paragrafo_" + parag.IdParagrafo;
                    ((web.CONTROLS.QuadroRelazioneTecnica)c).Paragrafo = parag;
                    SiarLibrary.ProgettoRelazioneTecnica pp = paragrafi_progetto.CollectionGetById(parag.IdParagrafo, Progetto.IdProgetto);
                    if (pp != null)
                    {
                        ((web.CONTROLS.QuadroRelazioneTecnica)c).Testo = pp.Testo;
                    }
                    rowEdit.Controls.Add(c);
                }
            }
            base.OnPreRender(e);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ProgettoProvider.DbProviderObj.BeginTran();
                relazione_provider.DeleteCollection(relazione_provider.Find(Progetto.IdProgetto, null));
                foreach (string s in Request.Form.AllKeys)
                {
                    int i = s.IndexOf("quadro_paragrafo_");
                    if (i > 0 && !string.IsNullOrEmpty(Request.Form[s]))
                    {
                        string str = s.Substring(i);
                        str = str.Replace("$txtDescrizioneLunga_text", "").Replace("quadro_paragrafo_", "");
                        SiarLibrary.ProgettoRelazioneTecnica parag = new SiarLibrary.ProgettoRelazioneTecnica();
                        parag.IdParagrafo = str;
                        parag.IdProgetto = Progetto.IdProgetto;
                        parag.Testo = Request.Form[s];
                        relazione_provider.Save(parag);
                    }
                }
                ProgettoProvider.AggiornaProgetto(Progetto, Operatore.Utente.IdUtente);
                ProgettoProvider.DbProviderObj.Commit();
                ShowMessage("Relazione tecnica salvata correttamente.");
            }
            catch (Exception ex) 
            { 
                ProgettoProvider.DbProviderObj.Rollback(); 
                ShowError(ex); 
            }
        }
    }
}