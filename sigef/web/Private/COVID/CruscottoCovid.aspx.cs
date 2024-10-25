using System;
using SiarLibrary;
using SiarLibrary.Web;
using SiarBLL;
using System.Web.UI.WebControls;
using SiarLibrary.NullTypes;
using System.Linq;

namespace web.Private.COVID
{
    public partial class CruscottoCovid : PrivatePage
    {
        int totProvvisorie = 0, totDefNonProtocollate = 0, totDefProtocollate = 0, totDefinitive = 0;


        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "cruscotto_covid";

            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["id_progetto_covid"] = null;
            Session["id_bando_covid"] = null;
        }

        protected override void OnPreRender(EventArgs e)
        {
            try
            {
                var cruscotto_coll = new VcovidCruscottoClasseCollectionProvider().FindOrdinato(null, null, null, null, null, null);

                if (cruscotto_coll.Count > 0)
                {
                    var cruscotto_list = cruscotto_coll.ToArrayList<VcovidCruscottoClasse>();

                    totProvvisorie = cruscotto_list.Sum<VcovidCruscottoClasse>(c => c.Provvisorie);
                    totDefNonProtocollate = cruscotto_list.Sum<VcovidCruscottoClasse>(c => c.DefNonProtocollate);
                    totDefProtocollate = cruscotto_list.Sum<VcovidCruscottoClasse>(c => c.DefProtocollate);
                    totDefinitive = cruscotto_list.Sum<VcovidCruscottoClasse>(c => c.TotDefinitive);
                }

                dgCruscotto.DataSource = cruscotto_coll;
                dgCruscotto.ShowFooter = true;
                dgCruscotto.FooterStyle.CssClass = "TotaliFooter";
                dgCruscotto.ItemDataBound += new DataGridItemEventHandler(dgCruscotto_ItemDataBound);
                dgCruscotto.DataBind();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }

            base.OnPreRender(e);
        }

        void dgCruscotto_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            var dgi = e.Item;

            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                var cruscotto = (VcovidCruscottoClasse)dgi.DataItem;
            }
            else if (dgi.ItemType == ListItemType.Footer)
            {
                dgi.Cells[2].Text = totProvvisorie.ToString();
                dgi.Cells[3].Text = totDefNonProtocollate.ToString();
                dgi.Cells[4].Text = totDefProtocollate.ToString();
                dgi.Cells[5].Text = totDefinitive.ToString();
            }
        }
    }
}