using System;

namespace web.CONTROLS
{
    public partial class AttestazioneUploadFileControl : System.Web.UI.UserControl
    {
        //public string Width { set { tableSNCUFUploadFile.Width = value; } }

        private SiarLibrary.NullTypes.IntNT _idFile;
        public SiarLibrary.NullTypes.IntNT IdFile
        {
            set { _idFile = value; }
            get { return hdnUploadFile.Value; }
        }


        private SiarLibrary.NullTypes.DatetimeNT _dataAttestazione;
        public SiarLibrary.NullTypes.DatetimeNT DataAttestazione
        {
            set { _dataAttestazione = value; }
            get { return _dataAttestazione.Value;  }

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

        //public bool Obbligatorio { set { if (value)txtPercorsoFile.Obbligatorio = true; } }

        public string XmlFile { get; set; }

        protected void Page_Load(object sender, EventArgs e) { }

        protected override void OnPreRender(EventArgs e)
        {
            if (file_selezionato == null && _idFile != null) file_selezionato = file_provider.GetSenzaContenutoById(_idFile);
            if (file_selezionato != null)
            {
                _text = file_selezionato.NomeFile;
                hdnUploadFile.Value = file_selezionato.Id;              
                btnAggiungiFile.Value = "Rimuovi";
                btnAggiungiFile.Attributes.Add("onclick", "SNCUFTipoFile='" + _tipoFile + "';SNCUFDimensioneMassima='" + _dimensioneMassima + "';SNCUFRimuoviFile('" + this.UniqueID.Replace("$", "_") + "');");
                btnVisualizzaFile.Attributes.Add("onclick", "SNCUFVisualizzaFile(" + file_selezionato.Id + ");");
            }
            else
            {
                _text = "Selezionare un file";
                hdnUploadFile.Value = "";
                btnVisualizzaFile.Disabled = true;
                btnAggiungiFile.Value = "Aggiungi";
                btnAggiungiFile.Attributes.Add("onclick", "SNCUFTipoFile='" + _tipoFile + "';SNCUFDimensioneMassima='" + _dimensioneMassima + "';SNCUFLoadPage(this);");
            }
            txtPercorsoFile.Value = _text;
            //txtDataAttestazione.Value = DataAttestazione.ToFullDate();
                                        
            btnAggiungiFile.Disabled = !_abilitaModifica;
            base.OnPreRender(e);
        }
    }

    //public enum TipoFile { NonSpecificato = 1, Immagine = 2, Documento = 3, WordFile = 4, ExcelsFile = 5, DocumentoFE = 6, DocumentoFirmato = 7 }
    //public enum DimensioneFile { NoLimit = 1, _500kb = 2, _1Mb = 3, _2Mb = 4 }
}