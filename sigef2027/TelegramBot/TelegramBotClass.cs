using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.Enums;
using System.IO;
using SiarLibrary;
using SiarBLL;
using Newtonsoft.Json;

namespace TelegramBot
{
    public class TelegramBotClass
    {
        string Token;
        long ChatIdCanaleSigef;
        TelegramBotClient BotClient;

        public TelegramBotClass()
        {
            //Bot.StartReceiving();
            //Bot.OnMessage += Bot_OnMessage;

            try
            {
                var chat_id_canale_sigef = ConfigurationManager.AppSettings["TelegramChatIdCanaleSigeft"];
                if (chat_id_canale_sigef == null || chat_id_canale_sigef == "")
                    throw new Exception("Id canale Sigef mancante");
                if (!long.TryParse(chat_id_canale_sigef, out ChatIdCanaleSigef))
                    throw new Exception("Formato Id canale Sigef errato");

                Token = ConfigurationManager.AppSettings["TelegramTokenBot"];
                if (Token == null || Token == "")
                    throw new Exception("Token mancante");

                var proxy_string = ConfigurationManager.AppSettings["TelegramProxy"];
                if (proxy_string != null && proxy_string != "")
                {
                    var proxy_address = proxy_string.Split(':');
                    if (proxy_address.Length > 2)
                        throw new Exception("Proxy per connesione a Telegram errato");

                    WebProxy web_proxy = new WebProxy(proxy_address[0], int.Parse(proxy_address[1]));
                    BotClient = new TelegramBotClient(Token, web_proxy);
                }
                else
                    BotClient = new TelegramBotClient(Token);
            }
            catch (Exception ex)
            {
                throw new Exception("Connessione al bot Telegram non riuscita, errore: " + ex.Message);
            }
        }

        //private async static void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        //{

        //}

        public async Task<string> SendMessageAsync(string cfUtente, long? chatId, string message)
        {
            string esitoFinale = "";

            var logTelegram = new LogTelegram();
            logTelegram.OperatoreInserimento = logTelegram.OperatoreModifica = cfUtente;
            logTelegram.DataInserirmento = logTelegram.DataModifica = DateTime.Now;
            logTelegram.TokenBot = Token;
            logTelegram.TipoChiamata = "SendMessageAsync";

            try
            {
                long c = chatId != null ? chatId.Value : ChatIdCanaleSigef;
                bool canaleSigef = c == ChatIdCanaleSigef;
                logTelegram.IdChat = c.ToString();
                logTelegram.CanaleSigef = canaleSigef;
                var logParametri = new LogTelegramSendMessageAsync(cfUtente, c, canaleSigef, message);
                logTelegram.Parametri = JsonConvert.SerializeObject(logParametri);

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                var esito = await BotClient.TestApiAsync();

                if (esito)
                {
                    if (message == null || message == "")
                        throw new Exception("Il messaggio non può essere vuoto.");

                    Message result = await BotClient.SendTextMessageAsync(c, message, ParseMode.Html);

                    if (result == null)
                    {
                        logTelegram.Esito = "KO";
                        esitoFinale = "Errore nell'invio messaggio";
                    }
                    else
                    {
                        logTelegram.Esito = "OK";
                        logTelegram.IdMessage = result.MessageId;
                    }
                }
                else
                {
                    logTelegram.Esito = "KO";
                    esitoFinale = "Connessione al bot non riuscita";
                }
            }
            catch (ThreadAbortException ex)
            {
                Thread.ResetAbort(); //evita solo il blocco del codice
            }
            catch (Telegram.Bot.Exceptions.ChatNotFoundException)
            {
                logTelegram.Esito = "KO";
                esitoFinale = "Chat non trovata";
            }
            catch (Telegram.Bot.Exceptions.ChatNotInitiatedException)
            {
                logTelegram.Esito = "KO";
                esitoFinale = "Chat non ancora inziata con il bot";
            }
            catch (Telegram.Bot.Exceptions.InvalidUserIdException)
            {
                logTelegram.Esito = "KO";
                esitoFinale = "Id utente non valido";
            }
            catch (Telegram.Bot.Exceptions.UserNotFoundException)
            {
                logTelegram.Esito = "KO";
                esitoFinale = "Utente non trovato";
            }
            catch (Exception ex)
            {
                logTelegram.Esito = "KO";
                esitoFinale = ex.Message;
            }
            finally
            {
                logTelegram.DettaglioEsito = esitoFinale;

                new LogTelegramCollectionProvider().Save(logTelegram);
            }

            return esitoFinale;
        }

        public async Task<string> SendFileAsync(string cfUtente, long? chatId, ArchivioFile archivioFile, string didascalia)
        {
            string esitoFinale = "";

            var logTelegram = new LogTelegram();
            logTelegram.OperatoreInserimento = logTelegram.OperatoreModifica = cfUtente;
            logTelegram.DataInserirmento = logTelegram.DataModifica = DateTime.Now;
            logTelegram.TokenBot = Token;
            logTelegram.TipoChiamata = "SendFileAsync";

            try
            {
                long c = chatId != null ? chatId.Value : ChatIdCanaleSigef;
                bool canaleSigef = c == ChatIdCanaleSigef;
                logTelegram.IdChat = c.ToString();
                logTelegram.CanaleSigef = canaleSigef;

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                var esito = await BotClient.TestApiAsync();

                if (esito)
                {
                    if (archivioFile == null || archivioFile.Id == null || archivioFile.NomeCompleto == null)
                        throw new Exception("Il file non può essere vuoto o senza nome");

                    var logParametri = new LogTelegramSendFileAsync(cfUtente, c, canaleSigef, archivioFile.Id, didascalia);
                    logTelegram.Parametri = JsonConvert.SerializeObject(logParametri);

                    Stream contenuto = new MemoryStream(archivioFile.Contenuto);
                    InputOnlineFile file = new InputOnlineFile(contenuto, archivioFile.NomeCompleto);
                    Message result = await BotClient.SendDocumentAsync(c, file, didascalia, ParseMode.Html);

                    if (result == null)
                    {
                        logTelegram.Esito = "KO";
                        esitoFinale = "Errore nell'invio file";
                    }
                    else
                    {
                        logTelegram.Esito = "OK";
                        logTelegram.IdMessage = result.MessageId;
                    }
                }
                else
                {
                    logTelegram.Esito = "KO";
                    esitoFinale = "Connessione al bot non riuscita";
                }
            }
            catch (ThreadAbortException ex)
            {
                Thread.ResetAbort(); //evita solo il blocco del codice
            }
            catch (Telegram.Bot.Exceptions.ChatNotFoundException)
            {
                logTelegram.Esito = "KO";
                esitoFinale = "Chat non trovata";
            }
            catch (Telegram.Bot.Exceptions.ChatNotInitiatedException)
            {
                logTelegram.Esito = "KO";
                esitoFinale = "Chat non ancora inziata con il bot";
            }
            catch (Telegram.Bot.Exceptions.InvalidUserIdException)
            {
                logTelegram.Esito = "KO";
                esitoFinale = "Id utente non valido";
            }
            catch (Telegram.Bot.Exceptions.UserNotFoundException)
            {
                logTelegram.Esito = "KO";
                esitoFinale = "Utente non trovato";
            }
            catch (Exception ex)
            {
                logTelegram.Esito = "KO";
                esitoFinale = ex.Message;
            }
            finally
            {
                logTelegram.DettaglioEsito = esitoFinale;

                new LogTelegramCollectionProvider().Save(logTelegram);
            }

            return esitoFinale;
        }

        public async Task<string> EditMessageAsync(string cfUtente, long? chatId, int messageId, string message)
        {
            string esitoFinale = "";

            var logTelegram = new LogTelegram();
            logTelegram.OperatoreInserimento = logTelegram.OperatoreModifica = cfUtente;
            logTelegram.DataInserirmento = logTelegram.DataModifica = DateTime.Now;
            logTelegram.TokenBot = Token;
            logTelegram.TipoChiamata = "EditMessageAsync";

            try
            {
                long c = chatId != null ? chatId.Value : ChatIdCanaleSigef;
                bool canaleSigef = c == ChatIdCanaleSigef;
                logTelegram.IdChat = c.ToString();
                logTelegram.CanaleSigef = canaleSigef;
                var logParametri = new LogTelegramEditMessageAsync(cfUtente, c, canaleSigef, messageId, message);
                logTelegram.Parametri = JsonConvert.SerializeObject(logParametri);

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                var esito = await BotClient.TestApiAsync();

                if (esito)
                {
                    if (message == null || message == "")
                        throw new Exception("Il messaggio non può essere vuoto.");

                    Message result = await BotClient.EditMessageTextAsync(c, messageId, message, ParseMode.Html);

                    if (result == null)
                    {
                        logTelegram.Esito = "KO";
                        esitoFinale = "Errore nell'invio messaggio";
                    }
                    else
                    {
                        logTelegram.Esito = "OK";
                        logTelegram.IdMessage = result.MessageId;
                    }
                }
                else
                {
                    logTelegram.Esito = "KO";
                    esitoFinale = "Connessione al bot non riuscita";
                }
            }
            catch (ThreadAbortException ex)
            {
                Thread.ResetAbort(); //evita solo il blocco del codice
            }
            catch (Telegram.Bot.Exceptions.ChatNotFoundException)
            {
                logTelegram.Esito = "KO";
                esitoFinale = "Chat non trovata";
            }
            catch (Telegram.Bot.Exceptions.ChatNotInitiatedException)
            {
                logTelegram.Esito = "KO";
                esitoFinale = "Chat non ancora inziata con il bot";
            }
            catch (Telegram.Bot.Exceptions.InvalidUserIdException)
            {
                logTelegram.Esito = "KO";
                esitoFinale = "Id utente non valido";
            }
            catch (Telegram.Bot.Exceptions.UserNotFoundException)
            {
                logTelegram.Esito = "KO";
                esitoFinale = "Utente non trovato";
            }
            catch (Exception ex)
            {
                logTelegram.Esito = "KO";
                esitoFinale = ex.Message;
            }
            finally
            {
                logTelegram.DettaglioEsito = esitoFinale;

                new LogTelegramCollectionProvider().Save(logTelegram);
            }

            return esitoFinale;
        }

        public async Task<string> EditFileAsync(string cfUtente, long? chatId, int messageId, ArchivioFile archivioFile, string didascalia)
        {
            string esitoFinale = "";

            var logTelegram = new LogTelegram();
            logTelegram.OperatoreInserimento = logTelegram.OperatoreModifica = cfUtente;
            logTelegram.DataInserirmento = logTelegram.DataModifica = DateTime.Now;
            logTelegram.TokenBot = Token;
            logTelegram.TipoChiamata = "EditFileAsync";

            try
            {
                long c = chatId != null ? chatId.Value : ChatIdCanaleSigef;
                bool canaleSigef = c == ChatIdCanaleSigef;
                logTelegram.IdChat = c.ToString();
                logTelegram.CanaleSigef = canaleSigef;

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                var esito = await BotClient.TestApiAsync();

                if (esito)
                {
                    if (archivioFile == null || archivioFile.Id == null || archivioFile.NomeCompleto == null)
                        throw new Exception("Il file non può essere vuoto o senza nome");

                    var logParametri = new LogTelegramEditFileAsync(cfUtente, c, canaleSigef, messageId, archivioFile.Id, didascalia);
                    logTelegram.Parametri = JsonConvert.SerializeObject(logParametri);

                    Stream contenuto = new MemoryStream(archivioFile.Contenuto);
                    Message result = await BotClient.EditMessageMediaAsync(
                        /* chatId: */ c,
                        /* messageId: */ messageId,
                        media: new InputMediaDocument(new InputMedia(contenuto, archivioFile.NomeCompleto))
                        {
                            Caption = didascalia,
                            ParseMode = ParseMode.Markdown,
                        }
                    );

                    if (result == null)
                    {
                        logTelegram.Esito = "KO";
                        esitoFinale = "Errore nell'invio file";
                    }
                    else
                    {
                        logTelegram.Esito = "OK";
                        logTelegram.IdMessage = result.MessageId;
                    }
                }
                else
                {
                    logTelegram.Esito = "KO";
                    esitoFinale = "Connessione al bot non riuscita";
                }
            }
            catch (ThreadAbortException ex)
            {
                Thread.ResetAbort(); //evita solo il blocco del codice
            }
            catch (Telegram.Bot.Exceptions.ChatNotFoundException)
            {
                logTelegram.Esito = "KO";
                esitoFinale = "Chat non trovata";
            }
            catch (Telegram.Bot.Exceptions.ChatNotInitiatedException)
            {
                logTelegram.Esito = "KO";
                esitoFinale = "Chat non ancora inziata con il bot";
            }
            catch (Telegram.Bot.Exceptions.InvalidUserIdException)
            {
                logTelegram.Esito = "KO";
                esitoFinale = "Id utente non valido";
            }
            catch (Telegram.Bot.Exceptions.UserNotFoundException)
            {
                logTelegram.Esito = "KO";
                esitoFinale = "Utente non trovato";
            }
            catch (Exception ex)
            {
                logTelegram.Esito = "KO";
                esitoFinale = ex.Message;
            }
            finally
            {
                logTelegram.DettaglioEsito = esitoFinale;

                new LogTelegramCollectionProvider().Save(logTelegram);
            }

            return esitoFinale;
        }
    }
}
