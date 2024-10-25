using SiarBLL;
using System;
using System.Web.UI;
using TelegramBot;

namespace web.Private.admin
{
    public partial class MessaggiTelegram : SiarLibrary.Web.PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "Telegram";
            base.OnPreInit(e);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void MostraMessaggio(string messaggio, bool errore)
        {
            string fn = "";
            if (errore)
                fn = "mostraPopupMessaggio('" + messaggio + "', 1)";
            else
                fn = "mostraPopupMessaggio('" + messaggio + "', 0)";

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "myJsFn", fn, true);
        }

        protected async void btnInviaMessaggio_Click(object sender, EventArgs e) 
        {
            string esito = "";
            string testo = "";
            string didascalia = "";

            try
            {
                string chatText = txtIdChat.Text;
                long chatId;

                switch (rblTipoMessaggio.SelectedValue)
                {
                    case "0":
                        testo = Server.HtmlDecode(txtTesto.Text);

                        if (testo == null || testo == "")
                            throw new Exception("Il messaggio non può essere vuoto.");

                        if (chatText != null && chatText != "")
                        {
                            if (long.TryParse(chatText, out chatId))
                                esito = await new TelegramBotClass().SendMessageAsync(Operatore.Utente.CfUtente, chatId, testo);
                            else
                                throw new Exception("Formato numero canale errato");
                        }
                        else
                            esito = await new TelegramBotClass().SendMessageAsync(Operatore.Utente.CfUtente, null, testo);

                        break;
                    case "1":
                        didascalia = Server.HtmlDecode(txtDidascalia.Text);

                        if (ufFileTelegram.IdFile == null)
                            throw new Exception("Il file non può essere vuoto.");

                        var file = new ArchivioFileCollectionProvider().GetById(ufFileTelegram.IdFile);

                        if (chatText != null && chatText != "")
                        {
                            if (long.TryParse(chatText, out chatId))
                                esito = await new TelegramBotClass().SendFileAsync(Operatore.Utente.CfUtente, chatId, file, didascalia);
                            else
                                throw new Exception("Formato numero canale errato");
                        }
                        else
                            esito = await new TelegramBotClass().SendFileAsync(Operatore.Utente.CfUtente, null, file, didascalia);

                        break;
                    default:
                        throw new Exception("Valore tipo messaggio non valido");
                }

                if (esito == "")
                    MostraMessaggio("Messaggio inviato correttamente", false);
                else
                    MostraMessaggio(esito, true);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
            finally
            {
                txtTesto.Text = testo;
                txtDidascalia.Text = didascalia;
            }
        }

        protected async void btnModificaMessaggio_Click(object sender, EventArgs e)
        {
            string esito = "";
            string testo = "";
            string didascalia = "";

            try
            {
                string chatText = txtIdChatModifica.Text;
                string messageText = txtIdMessageModifica.Text;
                long chatId;
                int messageId;

                if (messageText == null || messageText == "")
                    throw new Exception("L'ID del messaggio non può essere vuoto.");

                if (!int.TryParse(messageText, out messageId))
                    throw new Exception("Formato ID messaggio errato");

                switch (rblTipoModifica.SelectedValue)
                {
                    case "0":
                        testo = Server.HtmlDecode(txtTestoModifica.Text);

                        if (testo == null || testo == "")
                            throw new Exception("Il messaggio non può essere vuoto.");

                        if (chatText != null && chatText != "")
                        {
                            if (long.TryParse(chatText, out chatId))
                                esito = await new TelegramBotClass().EditMessageAsync(Operatore.Utente.CfUtente, chatId, messageId, testo);
                            else
                                throw new Exception("Formato numero canale errato");
                        }
                        else
                            esito = await new TelegramBotClass().EditMessageAsync(Operatore.Utente.CfUtente, null, messageId, testo);

                        break;
                    case "1":
                        didascalia = Server.HtmlDecode(txtDidascaliaModifica.Text);

                        if (ufFileTelegramModifica.IdFile == null)
                            throw new Exception("Il file non può essere vuoto.");

                        var file = new ArchivioFileCollectionProvider().GetById(ufFileTelegramModifica.IdFile);

                        if (chatText != null && chatText != "")
                        {
                            if (long.TryParse(chatText, out chatId))
                                esito = await new TelegramBotClass().EditFileAsync(Operatore.Utente.CfUtente, chatId, messageId, file, didascalia);
                            else
                                throw new Exception("Formato numero canale errato");
                        }
                        else
                            esito = await new TelegramBotClass().EditFileAsync(Operatore.Utente.CfUtente, null, messageId, file, didascalia);

                        break;
                    default:
                        throw new Exception("Valore tipo messaggio non valido");
                }

                if (esito == "")
                    MostraMessaggio("Messaggio modificato correttamente", false);
                else
                    MostraMessaggio(esito, true);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
            finally
            {
                txtTestoModifica.Text = testo;
                txtDidascaliaModifica.Text = didascalia;
            }
        }
    }
}