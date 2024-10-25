
namespace TelegramBot
{
    public class LogTelegramSendMessageAsync
    {
        public string CfUtente;
        public long IdChat;
        public bool CanaleSigef;
        public string Message;

        public LogTelegramSendMessageAsync(string cfUtente, long idChat, bool canaleSigef, string message)
        {
            CfUtente = cfUtente;
            IdChat = idChat;
            CanaleSigef = canaleSigef;
            Message = message;
        }
    }

    public class LogTelegramEditMessageAsync
    {
        public string CfUtente;
        public long IdChat;
        public bool CanaleSigef;
        public int IdMessage;
        public string Message;

        public LogTelegramEditMessageAsync(string cfUtente, long idChat, bool canaleSigef, int idMessage, string message)
        {
            CfUtente = cfUtente;
            IdChat = idChat;
            CanaleSigef = canaleSigef;
            IdMessage = idMessage;
            Message = message;
        }
    }

    public class LogTelegramSendFileAsync
    {
        public string CfUtente;
        public long IdChat;
        public bool CanaleSigef;
        public int IdFile;
        public string Didascalia;

        public LogTelegramSendFileAsync(string cfUtente, long idChat, bool canaleSigef, int idFile, string didascalia)
        {
            CfUtente = cfUtente;
            IdChat = idChat;
            CanaleSigef = canaleSigef;
            IdFile = idFile;
            Didascalia = didascalia;
        }
    }

    public class LogTelegramEditFileAsync
    {
        public string CfUtente;
        public long IdChat;
        public bool CanaleSigef;
        public int IdMessage;
        public int IdFile;
        public string Didascalia;

        public LogTelegramEditFileAsync(string cfUtente, long idChat, bool canaleSigef, int idMessage, int idFile, string didascalia)
        {
            CfUtente = cfUtente;
            IdChat = idChat;
            CanaleSigef = canaleSigef;
            IdMessage = idMessage;
            IdFile = idFile;
            Didascalia = didascalia;
        }
    }
}
