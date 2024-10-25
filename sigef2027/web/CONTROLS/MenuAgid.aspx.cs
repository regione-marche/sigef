using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace web.CONTROLS
{
    public partial class MenuAgid : System.Web.UI.Page
    {
        int _idprofilo = -1;
        bool ie6_browser = false;
        //HtmlTable tabMenu = new HtmlTable();
        HtmlGenericControl tabMenu = new HtmlGenericControl("div");


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
            htmlMenu();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter sw = new System.IO.StringWriter(sb);
            HtmlTextWriter hWriter = new HtmlTextWriter(sw);
            tabMenu.RenderControl(hWriter);
            Response.Write(sb.ToString());
            Response.End();
        }

        private void htmlMenu()
        {
            tabMenu.Attributes.Add("class", "sidebar-wrapper");

            scriviMenu();
            if (_idprofilo <= 0)
            {
                HtmlGenericControl login = new HtmlGenericControl("h3");
                login.Attributes.Add("onclick", "location='" + Request.ApplicationPath + "/private/welcome.aspx'");
                login.InnerText = "Login";
                tabMenu.Controls.AddAt(0, login);
            }
            else
            {
                HtmlGenericControl logout = new HtmlGenericControl("h3");
                logout.Attributes.Add("onclick", "location='" + Request.ApplicationPath + "/Logout.aspx'");
                logout.InnerText = "Logout";
                tabMenu.Controls.AddAt(0, logout);
            }
        }

        private void scriviMenu()
        {
            SiarLibrary.FunzionalitaCollection menu_operatore = MenuOperatore;
            //SiarLibrary.Funzionalita fpadre = new SiarLibrary.Funzionalita(), fnonno = new SiarLibrary.Funzionalita();
            if (!string.IsNullOrEmpty(FunzionePagina))
            {
                SiarLibrary.FunzionalitaCollection figli = menu_operatore.SubSelect(null, null, null, FunzionePagina, null, null, null, null);
                if (figli.Count > 0) fpadre = menu_operatore.CollectionGetById(figli[0].Padre);
                if (fpadre != null) fnonno = menu_operatore.CollectionGetById(fpadre.Padre);
                if (fnonno != null) froot = menu_operatore.CollectionGetById(fnonno.Padre);
            }

            createMenu(tabMenu, null);
        }

        public void createMenu(HtmlGenericControl p, SiarLibrary.Funzionalita padre)
        {
            int i = 0;
            HtmlGenericControl linkList = new HtmlGenericControl();

            SiarLibrary.FunzionalitaCollection listaFigli = new SiarLibrary.FunzionalitaCollection();
            if (padre == null)
                listaFigli = MenuOperatore.SubSelect(null, null, null, null, null, -1, null, null);
            else
                listaFigli = MenuOperatore.SubSelect(null, null, null, null, null, padre.CodFunzione, null, null);

            foreach (SiarLibrary.Funzionalita f in listaFigli)
            {
                if (f.FlagMenu)
                {
                    switch (f.Livello.Value)
                    {
                        case 0:
                            HtmlGenericControl h3 = new HtmlGenericControl("h3");
                            p.Controls.Add(h3);

                            HtmlGenericControl a = new HtmlGenericControl("a");
                            a.Attributes.Add("class", "list-item large medium right-icon");
                            a.Attributes.Add("data-bs-target", "#" + f.DescMenu);
                            a.Attributes.Add("data-bs-toggle", "collapse");
                            if ((froot != null && froot.DescMenu == f.DescMenu) || (fnonno != null && fnonno.DescMenu == f.DescMenu) || (fpadre != null && fpadre.DescMenu == f.DescMenu))
                                a.Attributes.Add("aria-expanded", "true");
                            else
                                a.Attributes.Add("aria-expanded", "false");
                            a.Attributes.Add("aria-controls", f.DescMenu);
                            h3.Controls.Add(a);

                            HtmlGenericControl span = new HtmlGenericControl("span");
                            span.InnerText = f.Descrizione;

                            a.Controls.Add(span);
                            createMenu(p, f);
                            break;
                        case 1:
                            if (i == 0)
                            {
                                HtmlGenericControl linklistwrapper = new HtmlGenericControl("div");
                                linklistwrapper.Attributes.Add("class", "sidebar-linklist-wrapper");

                                p.Controls.Add(linklistwrapper);

                                HtmlGenericControl listwrapper = new HtmlGenericControl("div");
                                listwrapper.Attributes.Add("class", "link-list-wrapper");

                                linklistwrapper.Controls.Add(listwrapper);

                                linkList = new HtmlGenericControl();

                                linkList = new HtmlGenericControl("div");
                                if ((froot != null && froot.DescMenu == padre.DescMenu) || (fnonno != null && fnonno.DescMenu == padre.DescMenu) || (fpadre != null && fpadre.DescMenu == padre.DescMenu))
                                    linkList.Attributes.Add("class", "link-sublist collapse show");
                                else
                                    linkList.Attributes.Add("class", "link-sublist collapse");
                                linkList.ID = padre.DescMenu;

                                listwrapper.Controls.Add(linkList);
                            }
                            HtmlGenericControl h4 = new HtmlGenericControl("h4");
                            linkList.Controls.Add(h4);

                            if (f.Descrizione.Equals("Cruscotto"))
                                h4.Attributes.Add("onclick", "location='" + Request.ApplicationPath + f.Link + "'");

                            HtmlGenericControl a1 = new HtmlGenericControl("a");
                            a1.Attributes.Add("class", "list-item large medium right-icon");
                            a1.Attributes.Add("data-bs-target", "#" + f.DescMenu);
                            a1.Attributes.Add("data-bs-toggle", "collapse");

                            if ((froot != null && froot.DescMenu == f.DescMenu) || (fnonno != null && fnonno.DescMenu == f.DescMenu) || (fpadre != null && fpadre.DescMenu == f.DescMenu))
                                a1.Attributes.Add("aria-expanded", "true");
                            else
                                a1.Attributes.Add("aria-expanded", "false");
                            a1.Attributes.Add("aria-controls", f.DescMenu);
                            h4.Controls.Add(a1);

                            HtmlGenericControl span1 = new HtmlGenericControl("span");
                            span1.InnerText = f.Descrizione;

                            a1.Controls.Add(span1);

                            //HtmlGenericControl svg = new HtmlGenericControl("svg");
                            //svg.Attributes.Add("class", "icon icon-xs icon-primary right");

                            //span1.Controls.Add(svg);

                            //HtmlGenericControl use = new HtmlGenericControl("use");
                            //use.Attributes.Add("href", "/web/bootstrap-italia/svg/sprites.svg#it-expand");

                            //svg.Controls.Add(use);

                            createMenu(linkList, f);
                            break;
                        case 2:
                            if (i == 0)
                            {
                                HtmlGenericControl linklistwrapper = new HtmlGenericControl("div");
                                linklistwrapper.Attributes.Add("class", "sidebar-linklist-wrapper");

                                p.Controls.Add(linklistwrapper);

                                HtmlGenericControl listwrapper = new HtmlGenericControl("div");
                                listwrapper.Attributes.Add("class", "link-list-wrapper");

                                linklistwrapper.Controls.Add(listwrapper);

                                linkList = new HtmlGenericControl();

                                linkList = new HtmlGenericControl("ul");
                                if ((fnonno != null && fnonno.DescMenu == padre.DescMenu) || (fpadre != null && fpadre.DescMenu == padre.DescMenu))
                                    linkList.Attributes.Add("class", "link-sublist collapse show");
                                else
                                    linkList.Attributes.Add("class", "link-sublist collapse");
                                linkList.ID = padre.DescMenu;

                                listwrapper.Controls.Add(linkList);
                            }

                            HtmlGenericControl liSub2 = new HtmlGenericControl("li");
                            linkList.Controls.Add(liSub2);

                            HtmlGenericControl a2 = new HtmlGenericControl("a");
                            a2.Attributes.Add("class", "list-item large medium right-icon");
                            a2.Attributes.Add("data-bs-target", "#" + f.DescMenu);
                            a2.Attributes.Add("data-bs-toggle", "collapse");
                            if ((fnonno != null && fnonno.DescMenu == f.DescMenu) || (fpadre != null && fpadre.DescMenu == f.DescMenu))
                                a2.Attributes.Add("aria-expanded", "true");
                            else
                                a2.Attributes.Add("aria-expanded", "false");
                            a2.Attributes.Add("aria-controls", f.DescMenu);
                            liSub2.Controls.Add(a2);

                            HtmlGenericControl spanwrappericon = new HtmlGenericControl("span");
                            spanwrappericon.Attributes.Add("class", "list-item-title-icon-wrapper");

                            a2.Controls.Add(spanwrappericon);

                            HtmlGenericControl span2 = new HtmlGenericControl("span");
                            span2.InnerText = f.Descrizione;

                            spanwrappericon.Controls.Add(span2);

                            HtmlGenericControl svg2 = new HtmlGenericControl("svg");
                            svg2.Attributes.Add("class", "icon icon-xs icon-primary right");

                            span2.Controls.Add(svg2);

                            HtmlGenericControl use2 = new HtmlGenericControl("use");
                            use2.Attributes.Add("href", "/web/bootstrap-italia/svg/sprites.svg#it-expand");

                            svg2.Controls.Add(use2);

                            createMenu(liSub2, f);
                            break;
                        case 3:
                            if (i == 0)
                            {
                                HtmlGenericControl linklistwrapperextra = new HtmlGenericControl("div");
                                linklistwrapperextra.Attributes.Add("class", "sidebar-linklist-wrapper");

                                p.Controls.Add(linklistwrapperextra);

                                HtmlGenericControl listwrapperextra = new HtmlGenericControl("div");
                                listwrapperextra.Attributes.Add("class", "link-list-wrapper");

                                linklistwrapperextra.Controls.Add(listwrapperextra);

                                linkList = new HtmlGenericControl("ul");
                                if ((fnonno != null && fnonno.DescMenu == padre.DescMenu) || (fpadre != null && fpadre.DescMenu == padre.DescMenu))
                                    linkList.Attributes.Add("class", "link-sublist collapse show");
                                else
                                    linkList.Attributes.Add("class", "link-sublist collapse");
                                linkList.ID = padre.DescMenu;

                                listwrapperextra.Controls.Add(linkList);

                            }
                            HtmlGenericControl liSub = new HtmlGenericControl("li");
                            linkList.Controls.Add(liSub);

                            HtmlGenericControl aSub = new HtmlGenericControl("a");
                            if (FunzionePagina == f.DescMenu)
                                aSub.Attributes.Add("class", "list-item active");
                            else
                                aSub.Attributes.Add("class", "list-item");
                            aSub.Attributes.Add("href", Request.ApplicationPath + f.Link);
                            liSub.Controls.Add(aSub);

                            HtmlGenericControl spanSub = new HtmlGenericControl("span");
                            spanSub.InnerText = f.Descrizione;

                            aSub.Controls.Add(spanSub);
                            break;
                        default:
                            break;
                    }
                }
                i++;
            }
        }
    }
}