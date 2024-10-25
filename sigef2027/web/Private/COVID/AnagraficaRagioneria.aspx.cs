using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SiarLibrary.Web;

namespace web.Private.COVID
{
    public partial class AnagraficaRagioneria : SiarLibrary.Web.PrivatePage
    {
        SiarBLL.CovidAutodichiarazioneExportElencoCollectionProvider elenco_provider = new SiarBLL.CovidAutodichiarazioneExportElencoCollectionProvider();

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "anagrafica_ragioneria";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            ComboBandi.Items.Clear();
            ComboBandi.Items.Add("");
            SiarBLL.BandoCollectionProvider bando_prov = new SiarBLL.BandoCollectionProvider();
            int id_rup = 0;
            if (Operatore.Utente.CodEnte != "%")
                id_rup = Operatore.Utente.IdUtente;
            SiarLibrary.BandoCollection bando = bando_prov.ElencoBandiCovid(id_rup);
            foreach (SiarLibrary.Bando a in bando)
            {

                ComboBandi.Items.Add(new ListItem(a.Descrizione, a.IdBando));
            }
            foreach (ListItem li in ComboBandi.Items)
                if (li.Value == ComboBandi.SelectedValue) { li.Selected = true; break; }

            SiarLibrary.CovidAutodichiarazioneExportElencoCollection elenco_app_coll = new SiarLibrary.CovidAutodichiarazioneExportElencoCollection();
            foreach (SiarLibrary.Bando a in bando)
            {
                SiarLibrary.CovidAutodichiarazioneExportElencoCollection elenco_coll = elenco_provider.Find(a.IdBando, null, null, null);
                foreach (SiarLibrary.CovidAutodichiarazioneExportElenco el in elenco_coll)
                {
                    elenco_app_coll.Add(el);
                }
            }
            List<SiarLibrary.CovidAutodichiarazioneExportElenco> list = elenco_app_coll.ToArrayList<SiarLibrary.CovidAutodichiarazioneExportElenco>() ;
            var list_app =  list.OrderByDescending(l => l.DataEstrazione);

            dgElenco.DataSource = list_app;
            dgElenco.ItemDataBound += new DataGridItemEventHandler(dgElenco_ItemDataBound);
            dgElenco.DataBind();

            base.OnPreRender(e);


        }
        void dgElenco_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            var dgi = e.Item;

            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.CovidAutodichiarazioneExportElenco el = (SiarLibrary.CovidAutodichiarazioneExportElenco)e.Item.DataItem;
                if (el.ImpresaIndividuale == true)
                    e.Item.Cells[2].Text = "Impresa Individuale";
                else
                    e.Item.Cells[2].Text = "Forma Giuridica";
            }
        }

        protected void btnCrea_Click(object sender, EventArgs e)
        {
            try
            {

                if (ComboBandi.SelectedValue == null || ComboBandi.SelectedValue == "")
                    throw new Exception("Selezionare il bando!");
                SiarLibrary.Bando bando = new SiarBLL.BandoCollectionProvider().GetById(ComboBandi.SelectedValue);
                SiarBLL.ArchivioFileCollectionProvider file_provider = new SiarBLL.ArchivioFileCollectionProvider();
                SiarLibrary.Web.ReportTemplates rt = new SiarLibrary.Web.ReportTemplates();
                string[] parametri =  new string[] { "IdBando=" + ComboBandi.SelectedValue, "DataOggi=" +DateTime.Today.ToString("yyyy-MM-dd") };
                string reportName;
                if (rblTipoBeneficiario.SelectedValue == "1")
                    reportName = "rptCovidEstrazioneRagioneriaIndividuali";
                else
                    reportName = "rptCovidEstrazioneRagioneriaGiuridiche";
                
                SiarLibrary.CovidAutodichiarazioneExportElencoCollection elenco_coll = elenco_provider.Find(ComboBandi.SelectedValue, rblTipoBeneficiario.SelectedValue, null, null);
                int progressivo = elenco_coll.Count + 1;
                if(elenco_coll.Count > 0)
                {
                    if (elenco_coll[0].DataEstrazione.ToString("yyyy-MM-dd") == DateTime.Today.ToString("yyyy-MM-dd"))
                        throw new Exception("E' possibile effetuare una solo estrazione giornaliera per bando e tipologia di beneficiario");
                }
                byte[] reportXls = rt.getReportByName(reportName, 2, parametri);
                if (reportXls == null)
                    throw new Exception("Errore nella generazione del file XLS!");
                SiarLibrary.ArchivioFile file = new SiarLibrary.ArchivioFile();
                file.Tipo = "application/xls";
                string nome = DateTime.Today.Year.ToString()+"." + DateTime.Today.Month.ToString() + "."+ DateTime.Today.Day.ToString() 
                    +"_"+DateTime.Today.Hour.ToString()+"."+DateTime.Today.Minute+ "_Estrazione Ragioneria " + bando.Descrizione + ".xls";
                file.NomeFile = nome;
                file.NomeCompleto = nome;
                file.Dimensione = reportXls.Length;
                file.Contenuto = reportXls;
                System.Security.Cryptography.HashAlgorithm alg = System.Security.Cryptography.HashAlgorithm.Create("SHA256");
                byte[] fileHashValue = alg.ComputeHash(reportXls);
                string hash_code = BinaryToHex(fileHashValue);
                file.HashCode = hash_code;
                file_provider.Save(file);

                SiarLibrary.CovidAutodichiarazioneExportElenco elenco = new SiarLibrary.CovidAutodichiarazioneExportElenco();
                elenco.IdBando = bando.IdBando;
                elenco.DescrizioneBando = bando.Descrizione;
                if (rblTipoBeneficiario.SelectedValue == "1")
                    elenco.ImpresaIndividuale = true;
                else
                    elenco.ImpresaIndividuale = false;
                elenco.DataEstrazione =DateTime.Now;
                elenco.Progressivo = progressivo;
                elenco.IdFile = file.Id;
                elenco_provider.Save(elenco);
                ShowMessage("File XLS creato correttamente, è possibile visualizzarlo e scaricarlo dalla griglia!");

            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        public string BinaryToHex(byte[] data)
        {
            char[] hex = new char[data.Length * 2];

            for (int iter = 0; iter < data.Length; iter++)
            {
                byte hexChar = ((byte)(data[iter] >> 4));
                hex[iter * 2] = (char)(hexChar > 9 ? hexChar + 0x37 : hexChar + 0x30);
                hexChar = ((byte)(data[iter] & 0xF));
                hex[(iter * 2) + 1] = (char)(hexChar > 9 ? hexChar + 0x37 : hexChar + 0x30);
            }
            return new string(hex);
        }
    }
}