using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace web.CONTROLS
{

    public partial class SNCUploadFileControlAgid : System.Web.UI.UserControl
    {
        private SiarLibrary.NullTypes.IntNT _idFile;
        public SiarLibrary.NullTypes.IntNT IdFile
        {
            set { _idFile = value; }
            get { return hdnSNCUFUploadFile.Value; }
        }

        private bool _segnaDaEliminare = true;
        public bool SegnaDaEliminare
        {
            get { return _segnaDaEliminare; }
            set { _segnaDaEliminare = value; }
        }

        private bool _abilitaModifica = false;
        public bool AbilitaModifica { set { _abilitaModifica = value; } }

        SiarLibrary.ArchivioFile file_selezionato;
        SiarBLL.ArchivioFileCollectionProvider file_provider = new SiarBLL.ArchivioFileCollectionProvider();

        private TipoFile _tipoFile;
        public TipoFile TipoFile
        {
            get { return _tipoFile; }
            set { _tipoFile = value; }
        }

        private DimensioneFile _dimensioneMassima;
        public DimensioneFile DimensioneMassima
        {
            get { return _dimensioneMassima; }
            set { _dimensioneMassima = value; }
        }

        private string _text = "";
        public string Text { set { _text = value; } }

        //public bool Obbligatorio { set { if (value) txtSNCUFPercorsoFile.Obbligatorio = true; } }
       


        protected override void OnPreRender(EventArgs e)
        {
            if (file_selezionato == null && _idFile != null) file_selezionato = file_provider.GetSenzaContenutoById(_idFile);
            if (file_selezionato != null)
            {
                _text = file_selezionato.NomeFile;
                hdnSNCUFUploadFile.Value = file_selezionato.Id;
                btnSNCUFAggiungiFile.Text = "Rimuovi";
                btnSNCUFAggiungiFile.Attributes.Add("onclick", "SNCUFTipoFile='" + _tipoFile + "';SNCUFDimensioneMassima='" + _dimensioneMassima + "';SNCUFRimuoviFile('" + this.UniqueID.Replace("$", "_") + "');");
                btnSNCUFVisualizzaFile.Attributes.Add("onclick", "SNCUFVisualizzaFile(" + file_selezionato.Id + ");");
            }
            else
            {
                //_text = "Selezionare un file";
                hdnSNCUFUploadFile.Value = "";
                btnSNCUFVisualizzaFile.Enabled = false;
                btnSNCUFAggiungiFile.Text = "Aggiungi";
                //btnSNCUFAggiungiFile.Attributes.Add("onclick", "SNCUFTipoFile='" + _tipoFile + "';SNCUFDimensioneMassima='" + _dimensioneMassima + "';SNCUFUploadPageAgid(this);");
            }
            txtSNCUFPercorsoFile.Text = _text;
            btnSNCUFAggiungiFile.Enabled = _abilitaModifica;
            base.OnPreRender(e);
        }


        protected void btnSNCUFAggiungiFile_Click(object sender, EventArgs e)
        {
            string folderPath = Server.MapPath("~/Upload/");

            //Check whether Directory (Folder) exists, although we have created, if it si not created this code will check
            if (!Directory.Exists(folderPath))
            {
                //If folder does not exists. Create it.
                Directory.CreateDirectory(folderPath);
            }

            //save file in the specified folder and path
            SNCUFileUpload.SaveAs(folderPath + Path.GetFileName(SNCUFileUpload.FileName));

            //once file is uploaded show message to user in label control
            //Label1.Text = Path.GetFileName(SNCUFileUpload.FileName) + " has been uploaded.";
        }

        protected void btnSNCUFVisualizzaFile_Click(object sender, EventArgs e)
        {
            if (this.SNCUFileUpload.HasFile)
            {
                this.SNCUFileUpload.SaveAs("c:\\" + this.SNCUFileUpload.FileName);
            }
        }


    }
    //Già dichiarate dichiarate in 'SNCUploadFileControl.ascx'
    //public enum TipoFile { NonSpecificato = 1, Immagine = 2, Documento = 3, WordFile = 4, ExcelsFile = 5, DocumentoFE = 6, DocumentoFirmato = 7 }
    //public enum DimensioneFile { NoLimit = 1, _500kb = 2, _1Mb = 3, _2Mb = 4 }
}
