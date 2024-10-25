using System;
using System.Linq;
using System.Web.UI.WebControls;
using SiarBLL;
using SiarBLL.AttiwebService;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarLibrary.Web;
using static SiarBLL.RegistroModificheAutorizzateCollectionProvider;

namespace web.Private.admin
{
    public partial class ModificheAutorizzate : PrivatePage
    {
        #region Indici colonne Datagrid

        private int col_IdModifica = 0,
            col_OperatoreInserimentoNominativo = 1,
            col_DataInserimento = 2,
            col_DescrizioneModifica = 3,
            col_RiferimentoPass = 4,
            col_SegnaturaRichiesta = 5,
            col_IdRiferimentoPrincipale = 6,
            col_IgnoraControlli = 7,
            col_Note = 8,
            col_Esito = 9,
            col_IdTipoModifica = 10;

        #endregion

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "ModificheAutorizzate";

            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            BindEnumToListControls(typeof(RegistroModificheAutorizzateCollectionProvider.EnumTipoModificaAutorizzata), rblTipoModifica);
            if (hdnTipoModificaSelezionata.Value != null && hdnTipoModificaSelezionata.Value != "")
            {
                string tipoModifica = hdnTipoModificaSelezionata.Value;
                var intTipoModifica = (int)Enum.Parse(typeof(EnumTipoModificaAutorizzata), tipoModifica);
                rblTipoModifica.Items[intTipoModifica - 1].Selected = true;
            }
            else
                rblTipoModifica.Items[0].Selected = true;

            BindEnumToListControls(typeof(RegistroModificheAutorizzateCollectionProvider.EnumTipoModificaAutorizzata), lstTipoModificaRicerca);
            lstTipoModificaRicerca.Items.Insert(0, new ListItem("", null));
            lstTipoModificaRicerca.Items[0].Selected = true;
        }

        protected override void OnPreRender(EventArgs e)
        {
            popolaImg();

            var tipoModifica = rblTipoModifica.SelectedValue;
            EnumTipoModificaAutorizzata enumModifica = (EnumTipoModificaAutorizzata)Enum.Parse(typeof(EnumTipoModificaAutorizzata), tipoModifica);
            var pass = txtRiferimentoPass.Text;
            var idRiferimentoText = txtIdRiferimento.Text;
            IntNT idRiferimento = null;
            int x;
            if (int.TryParse(idRiferimentoText, out x))
                idRiferimento = x;

            var modificheList = new RegistroModificheAutorizzateCollectionProvider()
                //.RicercaModifiche(enumModifica, pass, idRiferimento)
                .Select(null, null, null, null, null, null, null, null, null, null)
                .ToArrayList<RegistroModificheAutorizzate>();
            modificheList = modificheList
                .OrderByDescending(m => m.IdModifica)
                .ToList();

            if (modificheList.Count > 0)
            {
                lblNrRecordModifiche.Text = string.Format("Visualizzate {0} righe", modificheList.Count.ToString());

                dgElencoModifiche.DataSource = modificheList;
                dgElencoModifiche.ItemDataBound += new DataGridItemEventHandler(dgElencoModifiche_ItemDataBound);
                dgElencoModifiche.DataBind();
            }
            else
            {
                dgElencoModifiche.Visible = false;
                lblNrRecordModifiche.Text = "Nessuna modifica trovata.";
            }
            

            base.OnPreRender(e);
        }

        protected void BindEnumToListControls(Type enumType, ListControl listcontrol)
        {
            string[] names = Enum.GetNames(enumType);
            listcontrol.DataSource = Enum.GetValues(enumType).Cast<Int32>()
                                      .ToDictionary(currentItem =>
                                          Enum.GetName(enumType, currentItem));
            listcontrol.DataTextField = "Key";
            listcontrol.DataValueField = "Key";
            listcontrol.DataBind();
        }

        protected void popolaImg()
        {
            imgMostraNuovaModifica.Attributes.Add("src", PATH_IMAGES + "ArrowUpSolid.png");
            imgMostraElencoModifiche.Attributes.Add("src", PATH_IMAGES + "ArrowUpSolid.png");
            imgRicerca.Attributes.Add("src", PATH_IMAGES + "lente24.png");
        }

        void dgElencoModifiche_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var modificaAutorizzata = (RegistroModificheAutorizzate)dgi.DataItem;
                
                if (modificaAutorizzata.SegnaturaRichiesta != null)
                    dgi.Cells[col_SegnaturaRichiesta].Text = "<img src='" + PATH_IMAGES + "print_ico.gif' alt='Domanda'  onclick=\"sncAjaxCallVisualizzaProtocollo('" + modificaAutorizzata.SegnaturaRichiesta + "');\" style='cursor: pointer;'>";
                else
                    dgi.Cells[col_SegnaturaRichiesta].Text = "";

                if (modificaAutorizzata.IgnoraControlli == null || !modificaAutorizzata.IgnoraControlli)
                    dgi.Cells[col_IgnoraControlli].Text = dgi.Cells[col_IgnoraControlli].Text.Replace("checked", "");
                else
                    dgi.Cells[col_IgnoraControlli].Text = dgi.Cells[col_IgnoraControlli].Text.Replace("input ", "input checked ");
            }
        }
        
        protected void btnRicerca_Click(object sender, EventArgs e) { }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            var tipoModifica = rblTipoModifica.SelectedValue;
            if (tipoModifica == null || tipoModifica == "")
                throw new Exception("Tipo modifica non selezionato");

            var pass = txtRiferimentoPass.Text;
            var segnatura = txtSegnaturaRichiesta.Text;
            var idRiferimentoText = txtIdRiferimento.Text;
            var ignoraControlli = chkIgnoraControlli.Checked;
            var note = txtNote.Text;

            int idRiferimento;
            if (int.TryParse(idRiferimentoText, out idRiferimento))
            {
                var registroModificheCollectionProvider = new RegistroModificheAutorizzateCollectionProvider();
                var modificaAutorizzata = new RegistroModificheAutorizzate();
                modificaAutorizzata.OperatoreInserimento = Operatore.Utente.IdUtente;
                modificaAutorizzata.DataInserimento = DateTime.Now;
                modificaAutorizzata.IdTipoModifica = (int)Enum.Parse(typeof(EnumTipoModificaAutorizzata), tipoModifica);
                modificaAutorizzata.RiferimentoPass = pass;
                modificaAutorizzata.SegnaturaRichiesta = segnatura;
                modificaAutorizzata.IdRiferimentoPrincipale = idRiferimento;
                modificaAutorizzata.IgnoraControlli = ignoraControlli;
                modificaAutorizzata.Note = note;
                registroModificheCollectionProvider.Save(modificaAutorizzata);

                switch (modificaAutorizzata.IdTipoModifica.Value)
                {
                    case (int)EnumTipoModificaAutorizzata.RiaperturaIstruttoriaPagamento:
                        modificaAutorizzata.Esito = registroModificheCollectionProvider.RiaperturaIstruttoriaPagamento(modificaAutorizzata.IdModifica, idRiferimento, ignoraControlli);
                        break;
                    
                    case (int)EnumTipoModificaAutorizzata.RiaperturaBeneficiarioPagamento:
                        var riapriLatoIstruttorePagamento = chkRiapriBeneficiarioEIstruttorePagamento.Checked;
                        if (riapriLatoIstruttorePagamento)
                            note += "\r\nE' stato spuntato il check per la riapertura lato istruttore"; 
                        modificaAutorizzata.Esito = registroModificheCollectionProvider.RiaperturaBeneficiarioPagamento(modificaAutorizzata.IdModifica, idRiferimento, ignoraControlli, riapriLatoIstruttorePagamento);
                        break;
                    
                    case (int)EnumTipoModificaAutorizzata.RiaperturaIstruttoriaVariante:
                        modificaAutorizzata.Esito = registroModificheCollectionProvider.RiaperturaIstruttoriaVariante(modificaAutorizzata.IdModifica, idRiferimento, ignoraControlli);
                        break;
                    
                    case (int)EnumTipoModificaAutorizzata.RiaperturaBeneficiarioVariante:
                        var riapriLatoIstruttoreVariante = chkRiapriBeneficiarioEIstruttoreVariante.Checked;
                        if (riapriLatoIstruttoreVariante)
                            note += "\r\nE' stato spuntato il check per la riapertura lato istruttore";
                        modificaAutorizzata.Esito = registroModificheCollectionProvider.RiaperturaBeneficiarioVariante(modificaAutorizzata.IdModifica, idRiferimento, ignoraControlli, riapriLatoIstruttoreVariante);
                        break;
                    
                    case (int)EnumTipoModificaAutorizzata.EliminazioneSingolaValidazione:
                        modificaAutorizzata.Esito = registroModificheCollectionProvider.EliminazioneSingolaValidazione(modificaAutorizzata.IdModifica, idRiferimento, ignoraControlli);
                        break;

                    case (int)EnumTipoModificaAutorizzata.EliminazioneMandatiLiquidazionePagamento:
                        modificaAutorizzata.Esito = registroModificheCollectionProvider.EliminazioneMandatiLiquidazionePagamento(modificaAutorizzata.IdModifica, idRiferimento, ignoraControlli);
                        break;

                    case (int)EnumTipoModificaAutorizzata.AnnullamentoIstruttoriaAmmissibilitaProgetto:
                        modificaAutorizzata.Esito = registroModificheCollectionProvider.AnnullamentoIstruttoriaAmmissibilitaProgetto(modificaAutorizzata.IdModifica, idRiferimento, ignoraControlli);
                        break;

                    case (int)EnumTipoModificaAutorizzata.AnnullamentoPresentazioneProgetto:
                        modificaAutorizzata.Esito = registroModificheCollectionProvider.AnnullamentoPresentazioneProgetto(modificaAutorizzata.IdModifica, idRiferimento, ignoraControlli);
                        break;

                    case (int)EnumTipoModificaAutorizzata.EliminazioneDecretiMandatiLiquidazionePagamento:
                        modificaAutorizzata.Esito = registroModificheCollectionProvider.EliminazioneDecretiMandatiLiquidazionePagamento(modificaAutorizzata.IdModifica, idRiferimento, ignoraControlli);
                        break;

                    case (int)EnumTipoModificaAutorizzata.RiaperturaLottoCertificazioneSpesa:
                        modificaAutorizzata.Esito = registroModificheCollectionProvider.RiaperturaLottoCertificazioneSpesa(modificaAutorizzata.IdModifica, idRiferimento, ignoraControlli); ;
                        break;

                    default:
                        modificaAutorizzata.Esito = "Tipo " + modificaAutorizzata.IdTipoModifica.Value + " non ancora gestito o da rilasciare";
                        break;
                }

                modificaAutorizzata.Note = note; // salvo le note sia prima che dopo per aggiungere le informazioni degli eventuali check in più
                registroModificheCollectionProvider.Save(modificaAutorizzata);

                if (modificaAutorizzata.Esito == "OK")
                    ShowMessage("Modifica apportata correttamente");
                else
                    ShowError(modificaAutorizzata.Esito);
            }
            else
                ShowError("Id di riferimento mancante o non numerico");
        }
    }
}