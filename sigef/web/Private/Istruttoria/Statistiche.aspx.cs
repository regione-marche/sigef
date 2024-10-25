using System;
using System.Web.UI.WebControls;

namespace web.Private.Istruttoria
{
    public partial class Statistiche : SiarLibrary.Web.IstruttoriaPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "istruttoria_statistiche";
            base.OnPreInit(e);
        }
        protected void Page_Load(object sender, EventArgs e) { }

        protected override void OnPreRender(EventArgs e)
        {
            SiarLibrary.ProgettoCollection progetti = BandoProvider.GetStatisticheProgetti(Bando.IdBando),
                progetti_ds = new SiarLibrary.ProgettoCollection();
            string cod_fase_supp = null;
            SiarLibrary.Progetto p_tmp = null;
            foreach (SiarLibrary.Progetto p in progetti)
            {
                if (p.CodFase != cod_fase_supp)
                {
                    cod_fase_supp = p.CodFase;
                    p_tmp = new SiarLibrary.Progetto();
                    p_tmp.CodFase = p.CodFase;
                    p_tmp.Fase = p.Fase;
                    p_tmp.CodStato = p.CodStato;
                    p_tmp.Stato = p.Stato;
                    p_tmp.IdProgetto = p.IdProgetto;
                    progetti_ds.Add(p_tmp);
                }
                else
                {
                    p_tmp.Segnatura = p.CodStato;
                    p_tmp.SegnaturaAllegati = p.Stato;
                    p_tmp.IdBando = p.IdProgetto;
                }
            }
            dgStatistiche.DataSource = progetti_ds;
            dgStatistiche.DataBind();
            base.OnPreRender(e);
        }
    }
}
