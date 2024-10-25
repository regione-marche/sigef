using System;
using System.Web.UI.WebControls;


namespace web.Private.admin
{
    public partial class GestioneBanche : SiarLibrary.Web.PrivatePage
    {
        int idBando=4;
        SiarBLL.BancheIstitutiCollectionProvider istituto_banche_prov = new SiarBLL.BancheIstitutiCollectionProvider();
        SiarLibrary.BancheIstituti istituto_selezionato;
        SiarBLL.BancheFilialiCollectionProvider filiali_banche_prov = new SiarBLL.BancheFilialiCollectionProvider();
        SiarLibrary.BancheFiliali filiale_selezionata;

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "gestione_banche";
            base.OnPreInit(e);
        }

        protected override void OnPreRender(EventArgs e)
        {
            switch (ucSiarNewTab.TabSelected)
            {
                case 2:
                    tabIstituti.Visible = false;
                    tabElencoIstituti.Visible = true;
                    tabFiliali.Visible = false;
                    lstProvincia.DataBind();
                    if (istituto_selezionato != null)
                    {
                        txtAbi2.Text = istituto_selezionato.Abi;
                        txtAbi2.ReadOnly = true;
                        txtDenominazione2.Text = istituto_selezionato.Denominazione;
                        txtDataInizio.Text = istituto_selezionato.DataInizioValidita.ToString();
                        if (istituto_selezionato.DataFineValidita != null) txtDataFine.Text = istituto_selezionato.DataFineValidita.ToString();
                        if (istituto_selezionato.Attivo) ckAttivo.Checked = true;
                        string cab = null;
                        string filiale = null;
                        //Filiali
                        if (!string.IsNullOrEmpty(txtCab.Text)) cab = "%" + txtCab.Text + "%";
                        if (!string.IsNullOrEmpty(txtFiliale.Text)) filiale = "%" + txtFiliale.Text + "%";
                        SiarLibrary.BancheFilialiCollection filiali = filiali_banche_prov.Find(istituto_selezionato.Abi,
                            cab, filiale, lstProvincia.Text);
                        dgFiliali.DataSource = filiali;
                        dgFiliali.ItemDataBound += new DataGridItemEventHandler(dgFiliali_ItemDataBound);
                        dgFiliali.Titolo = "Filiali trovate: "+filiali.Count+ " per "+istituto_selezionato.Denominazione;
                        dgFiliali.DataBind();

                    }
                    else
                    {
                        txtAbi2.ReadOnly = false;
                    }
                    break;
                case 3:
                    tabIstituti.Visible = false;
                    tabElencoIstituti.Visible = false;
                    tabFiliali.Visible = true;
                    if (istituto_selezionato != null)
                    {
                        txtAbi3.Text = istituto_selezionato.Abi;
                        txtAbi3.ReadOnly = true;
                    }
                    if (filiale_selezionata != null)
                    {
                        txtAbi3.Text = filiale_selezionata.Abi;
                        txtCab3.Text = filiale_selezionata.Cab;
                        txtFiliale3.Text = filiale_selezionata.Note;
                        txtIndirizzo3.Text = filiale_selezionata.Indirizzo;
                        txtComune3.Text = filiale_selezionata.Comune;
                        IdComuneHide.Value = filiale_selezionata.IdComune.ToString();
                        txtProv3.Text = filiale_selezionata.Provincia;
                        txtCap3.Text = filiale_selezionata.Cap;
                        txtDataInizio3.Text = filiale_selezionata.DataInizioValidita.ToString();
                        if (filiale_selezionata.DataFineValidita != null) txtDataFine3.Text = filiale_selezionata.DataFineValidita.ToString();
                        if (filiale_selezionata.Attivo) ckAttivo3.Checked = true;

                    }
                    else
                    {
                        txtCab3.ReadOnly = false;
                    }
                    break;
                default:
                    tabIstituti.Visible = true;
                    tabFiliali.Visible = false;
                    tabElencoIstituti.Visible = false;
                    string denominazione = null;
                    string abi = null;
                    if (!string.IsNullOrEmpty(txtDenominazione.Text)) denominazione = "%" + txtDenominazione.Text + "%";
                    if (!string.IsNullOrEmpty(txtAbi.Text)) abi =  txtAbi.Text;
                    SiarLibrary.BancheIstitutiCollection istituti = istituto_banche_prov.Find(abi, denominazione, null);
                    dgbanche.DataSource = istituti;
                    dgbanche.ItemDataBound += new DataGridItemEventHandler(dgbanche_ItemDataBound);
                    dgbanche.Titolo = "Elementi trovati: " + istituti.Count;
                    dgbanche.DataBind();
                    break;

                    
            }
            base.OnPreRender(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (hdnIdBanca.Value != "")
                istituto_selezionato = istituto_banche_prov.GetById(hdnIdBanca.Value);
            else
                istituto_selezionato = null;

            int IdFiliale;
            if (int.TryParse(hdnIdFiliale.Value, out IdFiliale))
                filiale_selezionata = filiali_banche_prov.GetById(IdFiliale);
            else
                filiale_selezionata = null;


            txtComune3.AddJSAttribute("onkeydown", "apriSNCZoomComuni(this,event);");

        }

        void dgbanche_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
           
        }
        void dgFiliali_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
           
        }

        protected void btnCerca_Click(object sender, EventArgs e)
        {
            dgbanche.SetPageIndex(0);
        }

        protected void btnSalvaIstituto_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDenominazione2.Text == null) throw new Exception("Descrizione obbligatoria");
                if (txtDataInizio.Text == null) throw new Exception("Data inizio validità obbligatoria");

                if (istituto_selezionato == null)
                {   
                    //Controllo se gia nmon esiste record con lo stesso ABI
                    SiarLibrary.BancheIstituti istituto_esiste;
                    istituto_esiste = istituto_banche_prov.GetById(txtAbi2.Text);
                    if (istituto_esiste != null) throw new Exception("Banca con ABI già esistente");

                    istituto_selezionato = new SiarLibrary.BancheIstituti();
                    if (txtAbi2.Text == null) throw new Exception("ABI obbligatoria");
                }

                

                istituto_selezionato.Abi = txtAbi2.Text;
                istituto_selezionato.Denominazione = txtDenominazione2.Text;
                istituto_selezionato.DataInizioValidita = Convert.ToDateTime(txtDataInizio.Text);
                if (txtDataFine.Text != "" && txtDataFine.Text != null )
                    istituto_selezionato.DataFineValidita = Convert.ToDateTime(txtDataFine.Text);
                else
                    istituto_selezionato.DataFineValidita = null;
                if (ckAttivo.Checked)
                    istituto_selezionato.Attivo = true;
                else
                    istituto_selezionato.Attivo = false;
                istituto_banche_prov.Save(istituto_selezionato);
                hdnIdBanca.Value = istituto_selezionato.Abi;
                istituto_selezionato = istituto_banche_prov.GetById(hdnIdBanca.Value);
                ShowMessage("Banca salvata correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }
        protected void btnFiltra_Click(object sender, EventArgs e)
        {
            dgFiliali.SetPageIndex(0);
        }


        protected void btnSalvaFiliale_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFiliale3.Text == null || txtFiliale3.Text == "") throw new Exception("Descrizione Filiale obbligatoria");
                if (txtIndirizzo3.Text == null) throw new Exception("Indirizzo obbligatorio");
                if (txtComune3.Text == null) throw new Exception("Comune obbligatorio");
                if (IdComuneHide.Value == null || IdComuneHide.Value == "") throw new Exception("Comune obbligatorio, selezionare da menu a tendina");
                if (txtDataInizio3.Text == null) throw new Exception("Data inizio obbligatorio");

                if (filiale_selezionata == null)
                {
                    if (txtAbi3.Text == null) throw new Exception("ABI NON SELEZIONATA");
                    //Controllo se gia nmon esiste record con lo stesso ABI
                    SiarLibrary.BancheFilialiCollection filiali_temp = filiali_banche_prov.Find(txtAbi3.Text,
                            txtCab3.Text, null, null);
                    if (filiali_temp.Count > 0) throw new Exception("Filiale con lo stesso CAB gia esistente");
                    filiale_selezionata = new SiarLibrary.BancheFiliali();
                    if (txtCab3.Text == null) throw new Exception("CAB obbligatoria");
                }

                

                filiale_selezionata.Abi = txtAbi3.Text;
                filiale_selezionata.Cab = txtCab3.Text;
                filiale_selezionata.Note = txtFiliale3.Text;
                filiale_selezionata.Indirizzo = txtIndirizzo3.Text;
                filiale_selezionata.Comune = txtComune3.Text;
                filiale_selezionata.IdComune = IdComuneHide.Value;
                filiale_selezionata.Provincia = txtProv3.Text;
                filiale_selezionata.Cap = txtCap3.Text;
                filiale_selezionata.DataInizioValidita = Convert.ToDateTime(txtDataInizio3.Text);
                if (txtDataFine3.Text != "" && txtDataFine3.Text != null)
                    filiale_selezionata.DataFineValidita = Convert.ToDateTime(txtDataFine3.Text);
                else
                    filiale_selezionata.DataFineValidita = null;
                if (ckAttivo3.Checked)
                    filiale_selezionata.Attivo = true;
                else
                    filiale_selezionata.Attivo = false;
                filiali_banche_prov.Save(filiale_selezionata);

                int iDFil = 0;
                SiarLibrary.DbProvider DbProviderObj = new SiarLibrary.DbProvider();
                System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT ID FROM BANCHE_FILIALI WHERE CAB =" + txtCab3.Text + " AND ABI =" + txtAbi3.Text;
                DbProviderObj.InitDatareader(cmd);
                while (DbProviderObj.DataReader.Read())
                {

                    iDFil = new SiarLibrary.NullTypes.IntNT(DbProviderObj.DataReader["ID"]);
                }
                DbProviderObj.Close();
                hdnIdFiliale.Value = iDFil.ToString();
                filiale_selezionata = filiali_banche_prov.GetById(iDFil);
                ShowMessage("Filiale salvata correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

    }
}
