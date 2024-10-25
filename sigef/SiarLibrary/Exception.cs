using System;

namespace SiarLibrary
{
    public class SiarException : System.Exception
    {
        [System.ComponentModel.DefaultValue(SiarExceptionCodes.None)]
        private SiarExceptionCodes _codice;
        public SiarExceptionCodes Codice
        {
            get { return _codice; }
            set { _codice = value; }
        }

        [System.ComponentModel.DefaultValue(SiarExceptionSeverity.Error)]
        private SiarExceptionSeverity _gravita;
        public SiarExceptionSeverity Gravita
        {
            get { return _gravita; }
            set { _gravita = value; }
        }

        public SiarException() { }

        public SiarException(string messaggio_errore)
            : base(messaggio_errore)
        {
            _codice = SiarExceptionCodes.None;
            _gravita = SiarExceptionSeverity.Error;
        }

        public SiarException(string messaggio_errore, SiarExceptionCodes codice)
            : base(messaggio_errore)
        {
            _codice = codice;
            _gravita = SiarExceptionSeverity.Error;
        }

        public SiarException(string messaggio_errore, SiarExceptionCodes codice, SiarExceptionSeverity gravita)
            : base(messaggio_errore)
        {
            _codice = codice;
            _gravita = gravita;
            /*if (_gravita == SiarExceptionSeverity.Suspected)
                new Email("AUTO ERROR LOG", "").SendAlert(this);*/
        }

        public SiarException(SiarLibrary.TextErrorCodes c)
            : base(SiarLibrary.TextProvider.Get(c))
        {
            _codice = SiarExceptionCodes.None;
            _gravita = SiarExceptionSeverity.Error;
        }
    }

    public enum SiarExceptionSeverity
    {
        Warning = 1, Error = 2, Critical = 3, Suspected = 4
    }

    public enum SiarExceptionCodes
    {
        None = 1
    }
}