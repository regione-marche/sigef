using System;

namespace web.Private.Impresa
{
    public partial class ImpresaBusinessPlan : SiarLibrary.Web.ImpresaPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "impresa_business_plan";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SiarLibrary.QuadriXDomandaCollection quadri_domanda = new SiarLibrary.QuadriXDomandaCollection();
            SiarLibrary.DbProvider db = new SiarLibrary.DbProvider();
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandText = "SELECT URL,TITOLO FROM QUADRI_BUSINESS_PLAN WHERE DOMANDA=0 ORDER BY ORDINE";
            cmd.CommandType = System.Data.CommandType.Text;
            db.InitDatareader(cmd);
            while (db.DataReader.Read())
            {
                SiarLibrary.QuadriXDomanda qd = new SiarLibrary.QuadriXDomanda();
                qd.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["TITOLO"]);
                qd.Denominazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["URL"]);
                quadri_domanda.Add(qd);
            }
            dg.DataSource = quadri_domanda;
            dg.DataBind();
        }
    }
}
