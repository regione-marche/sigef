using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SiarLibrary;
using SiarLibrary.Web;
using SiarBLL;
using System.Web.UI.HtmlControls;

namespace web.CONTROLS
{
    public partial class ucAccordion : SigefUserControl
    {
        private string _divNames;
        public string DivNames
        {
            set { _divNames = value; }
        }

        public int DivSelected
        {
            get { int val; int.TryParse(hdnDivSelected.Value, out val); return val < 1 ? 1 : val; }
            set { hdnDivSelected.Value = value.ToString(); }
        }

        private string _nome_contenuto;
        public string NomeContenuto
        {
            get { return _nome_contenuto; }
            set { _nome_contenuto = value; }
        }

        private HtmlGenericControl divContent = new HtmlGenericControl("div");
        public Control Contenuto
        {
            get { return divContent.Controls[0]; }
            set { divContent.Controls.Clear(); divContent.Controls.Add(value); }
        }

        public string Width
        {
            set { divAccordion.Style.Add("width", value); }
            get { return divAccordion.Style["width"]; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected override void OnPreRender(EventArgs e)
        {
            //((PrivatePage)Page).RegisterClientScriptBlock("alert('occazzo');");
            Page.Master.Page.RegisterClientScriptBlock("sdfsff", "alert('occazzo');");
            var elenco_div = _divNames.Split('|');
            int indice = 1;

            foreach (string nome_div in elenco_div)
            {
                var myDiv = new HtmlGenericControl("div");
                var divSeparatore = new HtmlGenericControl("div");
                var textParagrafo = new HtmlGenericControl("p");
                //var img = new HtmlGenericControl("img");
                //img.Attributes.Add("src", PATH_IMAGES + "ArrowUpSolid.png");
                //img.Attributes.Add("style", "width: 23px; height: 23px;");

                //divSeparatore.Controls.Add(img);
                divSeparatore.Controls.Add(textParagrafo);
                myDiv.Controls.Add(divSeparatore);
                divAccordion.Controls.Add(myDiv);
                myDiv.Attributes.Add("class", "css_accordion_box");

                if (indice == DivSelected)
                {
                    //divSeparatore.Controls.Add(divContent);
                    textParagrafo.InnerText = " ▽ " + nome_div;
                    textParagrafo.Attributes.Add("style", "color: white");
                    myDiv.Controls.Add(divContent);
                    divSeparatore.Attributes.Add("class", "css_accordion_selected");
                }
                else
                {
                    textParagrafo.InnerText = " ▶ " + nome_div;
                    divSeparatore.Attributes.Add("class", "css_accordion");
                    divSeparatore.Attributes.Add("onclick", "swapAccordion(" + indice.ToString() + ")");
                }

                indice++;
            }

            //if (_nome_contenuto != null && _nome_contenuto != "")
            //{
            //    Control contenuto = Parent.FindControl(_nome_contenuto);
            //    if (contenuto == null)
            //        throw new Exception(_nome_contenuto + " non trovato, impossibile visualizzare la pagina.");
            //    Parent.Controls.Remove(contenuto);
            //    divAccordionContent.Controls.Add(contenuto);
            //}

            base.OnPreRender(e);
        }

        /// <summary>
        /// l'evento si scatena quando l'utente clicca su una tab e fa postback
        /// </summary>
        public event EventHandler DivClicked;


        protected void btnPostDivSelect_Click(object sender, EventArgs e)
        {
            // era già tutto fatto bastava scatenare l'evento.
            if (this.DivClicked != null)
            {
                this.DivClicked(this, new EventArgs());
            }
        }
    }
}