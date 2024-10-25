using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotificheBatch
{
    public class NotificatoreBase
    {
        public string ERRORE {get; set;}

        public virtual int Invia(SiarLibrary.DbProvider db)
        {
            ERRORE = "";
            return 0;
        }
    }
}
