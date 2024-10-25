using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using SiarLibrary;

namespace web.CONTROLS
{
    public partial class BreadcrumbAgid : System.Web.UI.Page
    {
        int _idprofilo = -1;
        bool ie6_browser = false;
        //HtmlTable tabMenu = new HtmlTable();
        HtmlGenericControl tabMenu = new HtmlGenericControl("ol");


        private string FunzioneMenu { get { return Request.Params["funcmenu"]; } }
        private string FunzionePagina { get { return Request.Params["funcpagina"]; } }
        SiarLibrary.Funzionalita fpadre = new SiarLibrary.Funzionalita(), fnonno = new SiarLibrary.Funzionalita(), froot = new SiarLibrary.Funzionalita();
        private SiarLibrary.Operatore Operatore
        {
            get { return (SiarLibrary.Operatore)(Session["OperatoreAlias"] ?? Session["Operatore"]); }
        }

        private SiarLibrary.FunzionalitaCollection MenuOperatore
        {
            get
            {
                if (Session["FUNZIONALITA_OPERATORE"] == null && _idprofilo > 0)
                    Session["FUNZIONALITA_OPERATORE"] = new SiarBLL.FunzionalitaCollectionProvider().GetMenuOperatore(_idprofilo);
                return ((SiarLibrary.FunzionalitaCollection)Session["FUNZIONALITA_OPERATORE"]) ??
                    new SiarBLL.FunzionalitaCollectionProvider().GetMenuOperatore(_idprofilo);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(2000);
            Response.ClearHeaders();
            Response.ClearContent();
            if (Request.Browser.Type == "IE6") ie6_browser = true;
            if (Operatore != null) _idprofilo = Operatore.Utente.IdProfilo;
            htmlBreadcrumb();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter sw = new System.IO.StringWriter(sb);
            HtmlTextWriter hWriter = new HtmlTextWriter(sw);
            tabMenu.RenderControl(hWriter);
            Response.Write(sb.ToString());
            Response.End();
        }

        private void htmlBreadcrumb()
        {
            tabMenu.Attributes.Add("class", "breadcrumb");

            SiarLibrary.Funzionalita home = new SiarBLL.FunzionalitaCollectionProvider().Find(null, "Pagina_iniziale_agid", null, null, null, null)[0];

            HtmlGenericControl liHome = new HtmlGenericControl("li");
            liHome.Attributes.Add("class", "breadcrumb-item");

            HtmlGenericControl aHome = new HtmlGenericControl("a");
            aHome.Attributes.Add("href", Request.ApplicationPath + home.Link);
            aHome.InnerText = "Home";

            HtmlGenericControl spanHome = new HtmlGenericControl("span");
            spanHome.Attributes.Add("class", "separator");
            spanHome.InnerText = "/";

            liHome.Controls.Add(aHome);
            aHome.Controls.Add(spanHome);
           
            SiarLibrary.Funzionalita paginaAttuale = new SiarBLL.FunzionalitaCollectionProvider().Find(null, FunzionePagina, null, null, null, null)[0];

            scriviBreadcrumb(paginaAttuale);

            tabMenu.Controls.AddAt(0, liHome);

            //            < ol class="breadcrumb">
            //  <li class="breadcrumb-item"><a href = "#" > Home </ a >< span class="separator">/</span></li>
            //  <li class="breadcrumb-item"><a href = "#" > Sottosezione </ a >< span class="separator">/</span></li>
            //  <li class="breadcrumb-item active" aria-current="page">Nome pagina</li>
            //</ol>
        }

        private void scriviBreadcrumb(SiarLibrary.Funzionalita f)
        {
            HtmlGenericControl liHome = new HtmlGenericControl("li");
            liHome.Attributes.Add("class", "breadcrumb-item");

            if (f.Link != null && !string.IsNullOrEmpty(f.Link.Value.Replace(" ", "")))
            {
                HtmlGenericControl aHome = new HtmlGenericControl("a");
                aHome.Attributes.Add("href", Request.ApplicationPath + f.Link);
                aHome.InnerText = f.Descrizione;

                if (f.DescMenu != FunzionePagina)
                {
                    HtmlGenericControl spanHome = new HtmlGenericControl("span");
                    spanHome.Attributes.Add("class", "separator");
                    spanHome.InnerText = "/";
                    aHome.Controls.Add(spanHome);
                }

                liHome.Controls.Add(aHome);
            }
            else
            {
                HtmlGenericControl aHome = new HtmlGenericControl("span");                
                aHome.InnerText = f.Descrizione;

                if (f.DescMenu != FunzionePagina)
                {
                    HtmlGenericControl spanHome = new HtmlGenericControl("span");
                    spanHome.Attributes.Add("class", "separator");
                    spanHome.InnerText = "/";
                    aHome.Controls.Add(spanHome);
                }

                liHome.Controls.Add(aHome);
            }

            tabMenu.Controls.AddAt(0, liHome);

            if (f.Padre != null && f.Padre != -1)
            {
                SiarLibrary.Funzionalita paginaPadre = new SiarBLL.FunzionalitaCollectionProvider().Find(f.Padre, null, null, null, null, null)[0];
                scriviBreadcrumb(paginaPadre);
            }
        }
    }
}