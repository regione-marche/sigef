using System;

namespace web.Private.PDomanda
{
    public partial class Dichiarazioni : SiarLibrary.Web.ProgettoPage
    {
        SiarLibrary.DichiarazioniXDomandaCollection diccoll;
        SiarLibrary.DichiarazioniXProgettoCollection dicXprogettoColl;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Progetto == null) Redirect("RicercaDomanda.aspx");
            if (Bando.IdModelloDomanda != null)
            {
                diccoll = new SiarBLL.DichiarazioniXDomandaCollectionProvider().Find(null, Bando.IdModelloDomanda);
                diccoll.Sort("Ordine, Misura, Descrizione");
            }
        }
        protected override void OnPreRender(EventArgs e)
        {
            if (diccoll != null)
            {
                dgObbligatorie.DataSource = diccoll.FiltroObbligatorio(true);
                dgObbligatorie.DataBind();
                dgFacoltative.DataSource = diccoll.FiltroObbligatorio(false);
            }

            dicXprogettoColl = new SiarBLL.DichiarazioniXProgettoCollectionProvider().Find(null, Progetto.IdProgetto);
            string[] sel = new string[dicXprogettoColl.Count];
            for (int i = 0; i < dicXprogettoColl.Count; i++)
            {
                sel[i] = dicXprogettoColl[i].IdDichiarazione.ToString();
            }
            ((SiarLibrary.Web.CheckColumn)dgFacoltative.Columns[2]).SetSelected(sel);
            dgFacoltative.DataBind();

            base.OnPreRender(e);
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Redirect("RiepilogoDomanda.aspx?iddom=" + Progetto.IdProgetto);
        }

        protected void btnAccettazione_Click(object sender, EventArgs e)
        {
            SiarBLL.DichiarazioniXProgettoCollectionProvider dichXprogettoPro = new SiarBLL.DichiarazioniXProgettoCollectionProvider();
            SiarLibrary.DichiarazioniXProgetto dichiarazioniProgetto;
            try
            {
                dichXprogettoPro.DbProviderObj.BeginTran();
                dichXprogettoPro.DeleteCollection(dichXprogettoPro.Find(null, Progetto.IdProgetto));

                //dichiarazioni obbligatorie
                foreach (SiarLibrary.DichiarazioniXDomanda dXd in diccoll.FiltroObbligatorio(true))
                {
                    dichiarazioniProgetto = new SiarLibrary.DichiarazioniXProgetto();
                    dichiarazioniProgetto.Provider = dichXprogettoPro;
                    dichiarazioniProgetto.IdDichiarazione = dXd.IdDichiarazione;
                    dichiarazioniProgetto.IdProgetto = Progetto.IdProgetto;
                    dichXprogettoPro.Save(dichiarazioniProgetto);
                }

                //Dichiarazioni Facoltative
                string[] selezionati = ((SiarLibrary.Web.CheckColumn)dgFacoltative.Columns[2]).GetSelected();
                foreach (string s in selezionati)
                {
                    dichiarazioniProgetto = new SiarLibrary.DichiarazioniXProgetto();
                    dichiarazioniProgetto.Provider = dichXprogettoPro;
                    dichiarazioniProgetto.IdDichiarazione = s;
                    dichiarazioniProgetto.IdProgetto = Progetto.IdProgetto;
                    dichXprogettoPro.Save(dichiarazioniProgetto);

                }
                dichXprogettoPro.DbProviderObj.Commit();
                ShowMessage("Salvataggio completato.");
            }
            catch
            {
                dichXprogettoPro.DbProviderObj.Rollback();
                ShowError("Impossibile salvare le dichiarazioni.");
            }
        }
    }
}