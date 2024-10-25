using System;
using System.Data;

namespace web.Private.CertificazioneSpesa
{
    public partial class RiepilogoControlli : SiarLibrary.Web.CertificazioneSpesaPage
    {
        protected void Page_Load(object sender, EventArgs e) { }

        protected override void OnPreRender(EventArgs e)
        {
            if (!IsPostBack) lstAnno.SelectedValue = DateTime.Now.Year.ToString();
            lstAnno.DataBind();
            lstProgrammazione.AttivazioneBandi = true;
            lstProgrammazione.DataBind();
            caricaRiepilogo();
            base.OnPreRender(e);
        }

        private void caricaRiepilogo()
        {
            decimal lotti_creati = 0, lotti_campionati = 0, lotti_conclusi = 0, totale_domande = 0, totale_domande_lotti = 0, totale_domande_controllate = 0,
                contributo_richiesto_totale = 0, contributo_richiesto_totale_lotti = 0, contributo_richiesto_controllato = 0,
                contributo_ammesso_totale = 0, contributo_ammesso_totale_lotti = 0, contributo_ammesso_controllato = 0,
                contributo_pagato_totale = 0, contributo_pagato_totale_lotti = 0, contributo_pagato_controllato = 0,
                contributo_pagato_anno_totale = 0, contributo_pagato_anno_totale_lotti = 0, contributo_pagato_anno_controllato = 0;
            try
            {
                SiarLibrary.DbProvider db = new SiarLibrary.DbProvider();
                IDbCommand cmd = db.GetCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SpCertspRiepilogoControlliLoco";
                if (!string.IsNullOrEmpty(lstProgrammazione.SelectedValue))
                    cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGRAMMAZIONE", lstProgrammazione.SelectedValue));
                if (!string.IsNullOrEmpty(lstAnno.SelectedValue))
                    cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ANNO", lstAnno.SelectedValue));
                db.InitDatareader(cmd);
                if (db.DataReader.Read())
                {
                    lotti_creati = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["LOTTI_CREATI"]);
                    lotti_campionati = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["LOTTI_CAMPIONATI"]);
                    lotti_conclusi = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["LOTTI_CONCLUSI"]);
                    totale_domande = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TOTALE_DOMANDE"]);
                    totale_domande_lotti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TOTALE_DOMANDE_LOTTI"]);
                    totale_domande_controllate = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TOTALE_DOMANDE_CONTROLLATE"]);
                    contributo_richiesto_totale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_RICHIESTO_TOTALE"]);
                    contributo_richiesto_totale_lotti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_RICHIESTO_TOTALE_LOTTI"]);
                    contributo_richiesto_controllato = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_RICHIESTO_CONTROLLATO"]);
                    contributo_ammesso_totale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_AMMESSO_TOTALE"]);
                    contributo_ammesso_totale_lotti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_AMMESSO_TOTALE_LOTTI"]);
                    contributo_ammesso_controllato = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_AMMESSO_CONTROLLATO"]);
                    contributo_pagato_totale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_PAGATO_TOTALE"]);
                    contributo_pagato_totale_lotti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_PAGATO_TOTALE_LOTTI"]);
                    contributo_pagato_controllato = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_PAGATO_CONTROLLATO"]);
                    contributo_pagato_anno_totale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_PAGATO_ANNO_TOTALE"]);
                    contributo_pagato_anno_totale_lotti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_PAGATO_ANNO_TOTALE_LOTTI"]);
                    contributo_pagato_anno_controllato = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_PAGATO_ANNO_CONTROLLATO"]);
                }
                db.Close();
                // lotti
                tbRiepilogoLotti.Rows[1].Cells[1].InnerText = string.Format("{0:N0}", lotti_creati);
                tbRiepilogoLotti.Rows[1].Cells[2].InnerText = string.Format("{0:N0}", lotti_campionati);
                tbRiepilogoLotti.Rows[1].Cells[3].InnerText = string.Format("{0:N0}", lotti_conclusi);
                tbRiepilogoLotti.Rows[1].Cells[4].InnerText = string.Format("{0:N2}", (lotti_creati > 0 ? 100 * lotti_conclusi / lotti_creati : 0));
                tbRiepilogoLotti.Rows[1].Cells[5].InnerText = string.Format("{0:N2}", (lotti_campionati > 0 ? 100 * lotti_conclusi / lotti_campionati : 0));
                // domande
                tbRiepilogoDomande.Rows[1].Cells[1].InnerText = string.Format("{0:N0}", totale_domande);
                tbRiepilogoDomande.Rows[1].Cells[2].InnerText = string.Format("{0:N0}", totale_domande_lotti);
                tbRiepilogoDomande.Rows[1].Cells[3].InnerText = string.Format("{0:N0}", totale_domande_controllate);
                tbRiepilogoDomande.Rows[1].Cells[4].InnerText = string.Format("{0:N2}", (totale_domande > 0 ? 100 * totale_domande_controllate / totale_domande : 0));
                tbRiepilogoDomande.Rows[1].Cells[5].InnerText = string.Format("{0:N2}", (totale_domande_lotti > 0 ? 100 * totale_domande_controllate / totale_domande_lotti : 0));
                // contributo richiesto
                tbRiepilogoContributo.Rows[1].Cells[1].InnerText = string.Format("{0:c}", contributo_richiesto_totale);
                tbRiepilogoContributo.Rows[1].Cells[2].InnerText = string.Format("{0:c}", contributo_richiesto_totale_lotti);
                tbRiepilogoContributo.Rows[1].Cells[3].InnerText = string.Format("{0:c}", contributo_richiesto_controllato);
                tbRiepilogoContributo.Rows[1].Cells[4].InnerText = string.Format("{0:N2}", (contributo_richiesto_totale > 0 ? 100 *
                    (contributo_richiesto_controllato / contributo_richiesto_totale) : 0));
                tbRiepilogoContributo.Rows[1].Cells[5].InnerText = string.Format("{0:N2}", (contributo_richiesto_totale_lotti > 0 ? 100 *
                    (contributo_richiesto_controllato / contributo_richiesto_totale_lotti) : 0));
                // contributo ammesso
                tbRiepilogoContributo.Rows[2].Cells[1].InnerText = string.Format("{0:c}", contributo_ammesso_totale);
                tbRiepilogoContributo.Rows[2].Cells[2].InnerText = string.Format("{0:c}", contributo_ammesso_totale_lotti);
                tbRiepilogoContributo.Rows[2].Cells[3].InnerText = string.Format("{0:c}", contributo_ammesso_controllato);
                tbRiepilogoContributo.Rows[2].Cells[4].InnerText = string.Format("{0:N2}", (contributo_ammesso_totale > 0 ? 100 * contributo_ammesso_controllato / contributo_ammesso_totale : 0));
                tbRiepilogoContributo.Rows[2].Cells[5].InnerText = string.Format("{0:N2}", (contributo_ammesso_totale_lotti > 0 ? 100 * contributo_ammesso_controllato / contributo_ammesso_totale_lotti : 0));
                // contributo pagato
                tbRiepilogoContributo.Rows[3].Cells[1].InnerText = string.Format("{0:c}", contributo_pagato_totale);
                tbRiepilogoContributo.Rows[3].Cells[2].InnerText = string.Format("{0:c}", contributo_pagato_totale_lotti);
                tbRiepilogoContributo.Rows[3].Cells[3].InnerText = string.Format("{0:c}", contributo_pagato_controllato);
                tbRiepilogoContributo.Rows[3].Cells[4].InnerText = string.Format("{0:N2}", (contributo_pagato_totale > 0 ? 100 * contributo_pagato_controllato / contributo_pagato_totale : 0));
                tbRiepilogoContributo.Rows[3].Cells[5].InnerText = string.Format("{0:N2}", (contributo_pagato_totale_lotti > 0 ? 100 * contributo_pagato_controllato / contributo_pagato_totale_lotti : 0));
                // contributo pagato durante l'anno
                tbRiepilogoContributo.Rows[4].Cells[1].InnerText = string.Format("{0:c}", contributo_pagato_anno_totale);
                tbRiepilogoContributo.Rows[4].Cells[2].InnerText = string.Format("{0:c}", contributo_pagato_anno_totale_lotti);
                tbRiepilogoContributo.Rows[4].Cells[3].InnerText = string.Format("{0:c}", contributo_pagato_anno_controllato);
                tbRiepilogoContributo.Rows[4].Cells[4].InnerText = string.Format("{0:N2}", (contributo_pagato_anno_totale > 0 ? 100 * contributo_pagato_anno_controllato / contributo_pagato_anno_totale : 0));
                tbRiepilogoContributo.Rows[4].Cells[5].InnerText = string.Format("{0:N2}", (contributo_pagato_anno_totale_lotti > 0 ? 100 * contributo_pagato_anno_controllato / contributo_pagato_anno_totale_lotti : 0));
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnCerca_Click(object sender, EventArgs e)
        {

        }
    }
}
